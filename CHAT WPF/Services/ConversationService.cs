using CHAT_WPF.Models;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CHAT_WPF.Services
{
    public class ConversationService : Service
    {
        public static async Task<string> CreateConversationAsync(string ownerID, string memberID)
        {
            Dictionary<string, MemberModel> members = new Dictionary<string, MemberModel>();
            members.Add(
                ownerID,
                new MemberModel()
                {
                    Status = MemberModel.Statuses.Joined,
                    IsEntering = false,
                }
            );
            members.Add(
                memberID,
                new MemberModel()
                {
                    Status = MemberModel.Statuses.Joined,
                    IsEntering = false,
                }
            );

            var rsp = await Client.PushAsync("Conversations/", new ConversationModel()
            {
                ChangedTime = DateTime.Now,
                Members = members,
                IsGroup = false
            });

            // change time
            await ChangeConversationTimeOfUserAsync(ownerID);
            await ChangeConversationTimeOfUserAsync(memberID);

            return rsp.Result.name;
        }

        public static async Task CreateGroupAsync(String title, List<string> memberIDs)
        {
            // Tạo ds thành viên
            Dictionary<string, MemberModel> members = new Dictionary<string, MemberModel>();

            // Thêm chính mình vào 
            members.Add(
                Service.UserID,
                new MemberModel()
                {
                    Status = MemberModel.Statuses.Joined,
                    IsEntering = false,
                }
            );

            // khởi tạo
            var rsp = await Client.PushAsync("Conversations/", new ConversationModel()
            {
                ChangedTime = DateTime.Now,
                Members = members,
                Title = title,
                Avatar = Utilities.Ultilities.GetDefaultGroupImageBase64String(),
                IsGroup = true
            });

            // gủi lời mòi cho các thành viên khác
            foreach (var memberID in memberIDs)
            {
                NotificationService.SendInvitationJoinConversationWithoutNotification(rsp.Result.name, Service.UserID, memberID);
            }

            // change time
            await ChangeConversationTimeOfUserAsync(Service.UserID);
        }

        public static async Task<Dictionary<string, ConversationModel>> GetConversationsOfUserAsync(string userID)
        {
            if (!string.IsNullOrEmpty(UserID))
            {
                var rsp = await Client.GetAsync("Conversations");
                var conversations = rsp.ResultAs<Dictionary<string, ConversationModel>>()
                                    .Where(c => c.Value.Members.Any(m => m.Key == userID && m.Value.Status == MemberModel.Statuses.Joined))
                                    .ToDictionary(c => c.Key, c => c.Value);
                return conversations;
            }
            return null;
        }

        public static async Task<KeyValuePair<string, ConversationModel>> GetConversationByIdAsync(string ConversationID)
        {
            var rsp = await Client.GetAsync("Conversations");
            if (rsp != null && rsp.Body != null)
            {
                return rsp.ResultAs<Dictionary<string, ConversationModel>>().Where(c => c.Key == ConversationID).FirstOrDefault();
            }
            return new KeyValuePair<string, ConversationModel>(null, null);
        }

        public static KeyValuePair<string, MessageModel> GetMessageOfConversationById(string conversationID, string messageId)
        {
            var message = Client.Get("Conversations/" + conversationID + "/Messages/" + messageId)
                                          .ResultAs<Dictionary<string, MessageModel>>()
                                          .FirstOrDefault();

            return message;
        }

        public static Dictionary<string, MessageModel> GetMessagesOfConversation(string conversationID)
        {
            var messages = Client.Get("Conversations/" + conversationID + "/Messages")
                                 .ResultAs<Dictionary<string, MessageModel>>()
                                 .ToDictionary(m => m.Key, m => m.Value);
            return messages;
        }

        public static async Task<Dictionary<string, UserModel>> GetUsersOfConversationAsync(string conversationID)
        {
            var rsp = await Client.GetAsync("Conversations/" + conversationID + "/Members");
            var members = rsp.ResultAs<Dictionary<string, MemberModel>>().ToDictionary(m => m.Key, m => m.Value);

            var users = new Dictionary<string, UserModel>();
            foreach (var member in members)
            {
                var user = await UserService.GetUserAsync(member.Key);
                users.Add(user.Key, user.Value);
            }

            return users;
        }

        public static async Task<Dictionary<string, MemberModel>> GetUsersEnteringOfConversationAsync(string conversationID)
        {
            var rsp = await Client.GetAsync("Conversations/" + conversationID + "/Members");
            var users = rsp.ResultAs<Dictionary<string, MemberModel>>()
                           .Where(m => m.Value.IsEntering == true)
                           .ToDictionary(c => c.Key, c => c.Value);
            return users;
        }

        public static bool ChangeTitleOfConversation(string conversationID, string Title)
        {
            if (!string.IsNullOrEmpty(conversationID))
            {
                var rsp = Client.Set("Conversations/" + conversationID + "/Title", Title);
                Changed(conversationID);
            }
            return true;
        }

        public static bool ChangeAvatarOfConversation(string conversationID, string ImgPath)
        {
            var stream = File.Open(ImgPath, FileMode.Open);
            MemoryStream ms = new MemoryStream();
            stream.CopyTo(ms);
            var imgbase64 = Convert.ToBase64String(ms.GetBuffer());
            ConversationService.Client.Set("Conversations/" + conversationID + "/Avatar/", imgbase64);
            Changed(conversationID);
            return true;
        }

        public static bool InviteToJoinConversation(string conversationID, string userID)
        {
            if (!string.IsNullOrEmpty(conversationID) && !string.IsNullOrEmpty(userID))
            {
                // Thêm user vào cuộc hôi thoại
                Client.Push(
                    path: "Conversations/" + conversationID + "/Members/" + userID,
                    data: new MemberModel()
                    {
                        IsEntering = false,
                        Status = MemberModel.Statuses.Invited,
                    }
                );

                // Gửi thông báo cho user

            }
            return true;
        }

        public static string SendMessageToConversation(string conversationID, MessageModel message)
        {
            var rsp = Client.Push("Conversations/" + conversationID + "/Messages", message);

            if (rsp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Changed(conversationID);
                return rsp.Result.name;
            }
            else
            {
                return null;
            }
        }

        public static async Task<string> SendMessageToConversationAsync(UnsentMessageModel model)
        {
            if (model != null)
            {
                var rsp = await Client.PushAsync("Conversations/" + model.ConversationID + "/Messages", model.ConvertToMessageModel());

                if (rsp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Changed(model.ConversationID);
                    return rsp.Result.name;
                }
            }

            return null;
        }

        public static void Changed(string conversationID)
        {
            var rsp = Client.Set("Conversations/" + conversationID + "/ChangedTime", DateTime.Now);
        }

        public static List<string> GetAllSystemStickers()
        {
            var stickers = Client.Get("Stickers").ResultAs<List<string>>();

            return stickers;
        }

        public static Dictionary<string, string> GetAllSystemEmojis()
        {
            var emojis = Client.Get("Emojis").ResultAs<Dictionary<string, string>>().ToDictionary(e => e.Key, e => e.Value); ;

            return emojis;
        }

        public static void ChangeMemberIsEntering(string conversationID, string userID, bool isEntering)
        {
            if (!string.IsNullOrEmpty(conversationID) && !string.IsNullOrEmpty(userID))
            {
                Client.SetAsync("Conversations/" + conversationID + "/Members/" + userID + "/IsEntering", isEntering);
            }
        }

        public static async Task ChangeMemberSeenTimeAsync(string conversationID, string userID, DateTime seenTime)
        {
            if (!string.IsNullOrEmpty(conversationID) && !string.IsNullOrEmpty(userID))
            {
                await Client.SetAsync("Conversations/" + conversationID + "/Members/" + userID + "/SeenTime", seenTime);
            }
        }

        public static async Task ChangeConversationTimeOfUserAsync(string userID)
        {
            await Client.SetAsync("Users/" + userID + "/ConversationChangeTime", DateTime.Now);
        }

        public static async Task<DateTime> GetConversationChangeTimeOfUserAsync(string userID)
        {
            var rsp = await Client.GetAsync("Users/" + userID + "/ConversationChangeTime");
            if (rsp != null && rsp.Body != null)
            {
                return rsp.ResultAs<DateTime>();
            }
            return DateTime.MinValue;
        }

        public static async Task<KeyValuePair<string, ConversationModel>> GetConversationWithUserAsync(string otherUserID)
        {
            var rsp = await Client.GetAsync("Conversations");
            if (rsp != null && rsp.Body != "null")
            {
                var conversation = rsp.ResultAs<Dictionary<string, ConversationModel>>()
                                       .Where(c => c.Value.Members.Any(m => m.Key == Service.UserID && m.Value.Status == MemberModel.Statuses.Joined) && c.Value.IsGroup == false)
                                       .Where(c => c.Value.Members.Any(m => m.Key == otherUserID && m.Value.Status == MemberModel.Statuses.Joined))
                                       .FirstOrDefault();
                return conversation;
            }
            return new KeyValuePair<string, ConversationModel>();
        }

        public static async Task<Dictionary<string, MemberModel>> GetAllMembersOfConversationAsync(string conversationID)
        {
            var rsp = await Client.GetAsync("Conversations/" + conversationID + "/Members");
            if (rsp != null && rsp.Body != null && rsp.Body != "null")
            {
                return rsp.ResultAs<Dictionary<string, MemberModel>>();
            }
            return null;
        }

        public async Task<Dictionary<string, UserModel>> GetAllUsersOfConversationAsync(string conversationID)
        {
            Dictionary<string, UserModel> users = new Dictionary<string, UserModel>();
            var members = await GetAllMembersOfConversationAsync(conversationID);
            if (members != null)
            {
                foreach (var member in members)
                {
                    var user = await UserService.GetUserAsync(member.Key);
                    users.Add(user.Key, user.Value);
                }
            }
            return users;
        }
    }
}