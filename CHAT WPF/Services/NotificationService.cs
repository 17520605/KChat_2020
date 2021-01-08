using CHAT_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAT_WPF.Services
{

    public class FriendshipStatuses
    {
        public static String Confirmed = "Confirmed";
        public static String Waiting = "Waiting";
        public static String RequestSent = "RequestSent";
        public static String Unfriened = "Unfriened";
    }

    public class NotificationService : Service
    {
        public static KeyValuePair<string, NotificationModel> GetNotificationOfUserById(string userID, string notificationID)
        {
            var notification = Client.Get("Users/" + userID + "/Notifications")
                                      .ResultAs<Dictionary<string, NotificationModel>>()
                                      .Where(n => n.Key == notificationID).FirstOrDefault();
            return notification;
        }

        public static async Task<Dictionary<string, NotificationModel>> GetNotificationsOfUserAsync(string userID)
        {
            var rsp = await Client.GetAsync("Users/" + userID + "/Notifications");
            if (rsp != null && rsp.Body != "null")
            {
                return rsp.ResultAs<Dictionary<string, NotificationModel>>().ToDictionary(n => n.Key, n => n.Value);
            }
            return null;
        }

        public static async Task ChangeNotificationTimeOfUserAsync(string userID)
        {
            await Client.SetAsync("Users/" + userID + "/NotificationChangeTime", DateTime.Now);
        }

        public static async Task<bool> SendInvitationJoinConversationAsync(string conversationID, string fromUserID, string toUserID)
        {
            //Thêm tạm user vào cuộc hội thoại
            await Client.SetAsync("Conversations/" + conversationID + "/Members/" + toUserID, new MemberModel()
            {
                IsEntering = false,
                Status = MemberModel.Statuses.Invited,
            });

            // Thêm thông báo cho người yêu cầu
            await Client.PushAsync("Users/" + fromUserID + "/Notifications", new NotificationModel()
            {
                ChangeTime = DateTime.Now,
                NotificationType = NotificationTypes.SystemNotification,
                Content = new NotificationSystemModel()
                {
                    Text = "You have sent " + UserService.GetUserById(toUserID).Fullname + " an invitation to join the conversation."
                }
            });
            await ChangeNotificationTimeOfUserAsync(fromUserID);

            // Thêm thông báo cho người nhận 
            await Client.PushAsync("Users/" + toUserID + "/Notifications", new NotificationModel()
            {
                ChangeTime = DateTime.Now,
                NotificationType = NotificationTypes.ConversationInvitationRequest,
                Content = new NotificationConversationRequestModel()
                {
                    ConversationID = conversationID,
                    FromUserID = fromUserID,
                    ToUserID = toUserID
                }
            });
            await ChangeNotificationTimeOfUserAsync(toUserID);

            return true;
        }

        public static bool SendInvitationJoinConversationWithoutNotification(string conversationID, string fromUserID, string toUserID)
        {
            //Thêm tạm user vào cuộc hội thoại
            Client.SetAsync("Conversations/" + conversationID + "/Members/" + toUserID, new MemberModel()
            {
                IsEntering = false,
                Status = MemberModel.Statuses.Invited,
            });

            // Thêm thông báo cho người nhận 
            Client.PushAsync("Users/" + toUserID + "/Notifications", new NotificationModel()
            {
                ChangeTime = DateTime.Now,
                NotificationType = NotificationTypes.ConversationInvitationRequest,
                Content = new NotificationConversationRequestModel()
                {
                    ConversationID = conversationID,
                    FromUserID = fromUserID,
                    ToUserID = toUserID
                }
            });
            Client.SetAsync("Users/" + toUserID + "/ChangeTime", DateTime.Now);

            return true;
        }

        public static async Task<bool> AcceptInvitationJoinConversationAsync(string conversationID, string notificationID, string fromUserID, string toUserID)
        {
            // Xác thực user vào cuộc hội thoại
            await Client.SetAsync("Conversations/" + conversationID + "/Members/" + toUserID, new MemberModel()
            {
                IsEntering = false,
                Status = MemberModel.Statuses.Joined,
            });

            // Them message thong bao thanh vien moi
            ConversationService.SendMessageToConversation(conversationID, new MessageModel()
            {
                SendTime = DateTime.Now,
                UserID = "SYS",
                Text = UserService.GetUserById(toUserID).Fullname + " added to this conversation by " + UserService.GetUserById(fromUserID).Fullname
            });

            // Thêm thông báo đã tham gia cuộc hội thoại
            await Client.PushAsync("Users/" + toUserID + "/Notifications", new NotificationModel()
            {
                ChangeTime = DateTime.Now,
                NotificationType = NotificationTypes.SystemNotification,
                Content = new NotificationSystemModel()
                {
                    Text = "You joined the conversation with " + UserService.GetUserById(fromUserID).Fullname + "."
                }
            });
            

            // Xóa lời mời cho toUser
            await Client.DeleteAsync("Users/" + toUserID + "/Notifications/" + notificationID);

            //
            await ChangeNotificationTimeOfUserAsync(toUserID);

            // change conversations time
            await ConversationService.ChangeConversationTimeOfUserAsync(toUserID);

            return true;
        }

        public static async Task<bool> RefuseInvitationJoinConversationAsync(string conversationID, string notificationID, string fromUserID, string toUserID)
        {
            // Xóa toUser đàn tạm lưu khỏi cuộc hội thoại 
            await Client.DeleteAsync("Conversations/" + conversationID + "/Members/" + toUserID);

            // Xóa thông báo của toUser
            await Client.DeleteAsync("Users/" + toUserID + "/Notifications/" + notificationID);
            await ChangeNotificationTimeOfUserAsync(toUserID);

            // Thêm thông báo đã bị từ chối cho fromUser
            await Client.PushAsync("Users/" + fromUserID + "/Notifications", new NotificationSystemModel()
            {
                Text = UserService.GetUserById(toUserID).Fullname + " was refused your invitation."
            });
            await ChangeNotificationTimeOfUserAsync(fromUserID);

            return true;
        }

        public static async Task<bool> SendFriendInvitationAsync(string fromUserID, string toUserID)
        {
            // Thêm bạn bè tạm thời
            await ContactService.CreateTemporaryFriendshipAsync(fromUserID, toUserID);

            // Thêm thông báo cho người yêu cầu
            await Client.PushAsync("Users/" + fromUserID + "/Notifications", new NotificationModel()
            {
                ChangeTime = DateTime.Now,
                NotificationType = NotificationTypes.SystemNotification,
                Content = new NotificationSystemModel()
                {
                    Text = "You have sent to " + UserService.GetUserById(toUserID).Fullname + " a friend invitation."
                }
            });
            await ChangeNotificationTimeOfUserAsync(fromUserID);

            // Thêm thông báo cho người nhận 
            await Client.PushAsync("Users/" + toUserID + "/Notifications", new NotificationModel()
            {
                ChangeTime = DateTime.Now,
                NotificationType = NotificationTypes.FriendshipInvitationRequest,
                Content = new NotificationFriendshipRequestModel()
                {
                    FromUserID = fromUserID,
                    ToUserID = toUserID
                }
            });
            await ChangeNotificationTimeOfUserAsync(toUserID);

            return true;
        }

        public static async Task<bool> AcceptFriendInvitationAsync(string notificationID, string fromUserID, string toUserID)
        {
            // Xác nhận kết bạn
            await ContactService.AcceptFriendInvitationAsync(fromUserID, toUserID);

            // Thêm thông báo cho fromUser răng toUser đã châp nhận lời mời kết bạn
            await Client.PushAsync("Users/" + fromUserID + "/Notifications", new NotificationModel()
            {
                ChangeTime = DateTime.Now,
                NotificationType = NotificationTypes.SystemNotification,
                Content = new NotificationSystemModel()
                {
                    Text = UserService.GetUserById(toUserID).Fullname + " accepted your friend invitation."
                }
            });
            await ChangeNotificationTimeOfUserAsync(fromUserID);

            // Xóa yêu cầu kết ban trong toUser
            await Client.DeleteAsync("Users/" + toUserID + "/Notifications/" + notificationID);
            await ChangeNotificationTimeOfUserAsync(toUserID);

            return true;
        }

        public static async Task<bool> RefustFriendInvitationAsync(string notificationID, string fromUserID, string toUserID)
        {
            // Xóa kết bạn dẫ thêm tạm
            await ContactService.AcceptFriendInvitationAsync(fromUserID, toUserID);


            // Thêm thông báo cho fromUser răng toUser đã từ chối lời mời kết bạn
            await Client.PushAsync("Users/" + fromUserID + "/Notifications", new NotificationModel()
            {
                ChangeTime = DateTime.Now,
                NotificationType = NotificationTypes.SystemNotification,
                Content = new NotificationSystemModel()
                {
                    Text = UserService.GetUserById(toUserID).Fullname + " refused your friend invitation."
                }
            });
            await ChangeNotificationTimeOfUserAsync(fromUserID);

            // Xóa yêu thông cầu kết ban  toUser
            await Client.DeleteAsync("Users/" + toUserID + "/Notifications/" + notificationID);
            await ChangeNotificationTimeOfUserAsync(toUserID);

            return true;
        }

        public static async Task UnFriendAsync(String fromUserID, string toUserID)
        {
            // Xóa contact
            await ContactService.UpdateFriend(fromUserID, toUserID);

            // Thêm thông báo cho fromUser 
            await Client.PushAsync("Users/" + fromUserID + "/Notifications", new NotificationModel()
            {
                ChangeTime = DateTime.Now,
                NotificationType = NotificationTypes.SystemNotification,
                Content = new NotificationSystemModel()
                {
                    Text = "You you unfriended " + UserService.GetUserById(toUserID).Fullname + "."
                }
            });
            await ChangeNotificationTimeOfUserAsync(fromUserID);

            // Thêm thông báo cho toUser 
            await Client.PushAsync("Users/" + toUserID + "/Notifications", new NotificationModel()
            {
                ChangeTime = DateTime.Now,
                NotificationType = NotificationTypes.SystemNotification,
                Content = new NotificationSystemModel()
                {
                    Text = "You were unfriended by " + UserService.GetUserById(fromUserID).Fullname + "."
                }
            });
            await ChangeNotificationTimeOfUserAsync(toUserID);
        }


        public static async Task<DateTime> GetNotificationChangeTimeOfUserAsync(string userID)
        {
            var rsp = await Client.GetAsync("Users/" + userID + "/NotificationChangeTime");
            if (rsp != null && rsp.Body != "null")
            {
                return rsp.ResultAs<DateTime>();
            }
            return DateTime.MinValue;
        }

        public static async Task<DateTime> GetSystemSeenTimeAsync(string userID)
        {
            var rsp = await Client.GetAsync("Users/" + userID + "/SystemNotifSeenTime");
            if (rsp != null && rsp.Body != "null")
            {
                return rsp.ResultAs<DateTime>();
            }
            return DateTime.MinValue;
        }

        public static async Task<DateTime> GetFriendSeenTimeAsync(string userID)
        {
            var rsp = await Client.GetAsync("Users/" + userID + "/FriendNotifSeenTime");
            if (rsp != null && rsp.Body != "null")
            {
                return rsp.ResultAs<DateTime>();
            }
            return DateTime.MinValue;
        }
        
        public static async Task<DateTime> GetGroupSeenTimeAsync(string userID)
        {
            var rsp = await Client.GetAsync("Users/" + userID + "/GroupNotifSeenTime");
            if (rsp != null && rsp.Body != "null")
            {
                return rsp.ResultAs<DateTime>();
            }
            return DateTime.MinValue;
        }

        public static async Task ChangeSystemSeenTimeAsync()
        {
            await Client.SetAsync("Users/" + Service.UserID + "/SystemNotifSeenTime", DateTime.Now);
        }

        public static async Task ChangeFriendSeenTimeAsync()
        {
            await Client.SetAsync("Users/" + Service.UserID + "/FriendNotifSeenTime", DateTime.Now);
        }

        public static async Task ChangeGroupSeenTimeAsync()
        {
            await Client.SetAsync("Users/" + Service.UserID + "/GroupNotifSeenTime", DateTime.Now);
        }
    }
}
