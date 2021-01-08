using CHAT_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAT_WPF.Services
{
    public class ContactService : Service
    {
        public ContactService() : base() { }

        public static async Task<List<string>> GetSuggestedUserIDsAsync()
        {
            var rsp = await Client.GetAsync("/Users/");
            var friendids = await GetFriendIDsAsync();
            if (rsp != null && rsp.Body != "null")
            {
                var users = rsp.ResultAs<Dictionary<string, UserModel>>()
                            .Where(u => u.Key != Service.UserID && !friendids.Contains(u.Key))
                            .ToDictionary(c => c.Key, c => c.Value)
                            .Keys.ToList();
                return users;
            }
            else
            {
                var users = rsp.ResultAs<Dictionary<string, UserModel>>().Keys.ToList();
                return users;
            }
        }

        public static async Task<List<string>> GetFriendIDsAsync()
        {
            var rsp = await Client.GetAsync("Contacts/" + Service.UserID + "/Friends");
            if (rsp != null && rsp.Body != "null")
            {
                var ids = rsp.ResultAs<Dictionary<string, string>>()
                        .Where(u => u.Value == FriendshipStatuses.Confirmed)
                        .ToDictionary(c => c.Key, c => c.Value)
                        .Keys.ToList();
                return ids;
            }
            return new List<string>();
        }

        public static async Task<Dictionary<string, UserModel>> GetFriendsAsync()
        {
            Dictionary<string, UserModel> friends = new Dictionary<string, UserModel>();
            List<string> ids = await GetFriendIDsAsync();
            foreach (var id in ids)
            {
                var friend = await UserService.GetUserAsync(id);
                friends.Add(friend.Key, friend.Value);
            }
            return friends;
        }

        public static async Task<string> GetFriendshipStatusAsync(string otherUserID)
        {
            var rsp = await Client.GetAsync("Contacts/" + Service.UserID + "/Friends/" + otherUserID);
            if (rsp != null && rsp.Body != "null")
            {
                return rsp.Body;
            }
            return null;
        }

        public static async Task CreateTemporaryFriendshipAsync(string fromUserID, string toUserID)
        {
            // Thêm tạm fromUser vào ds bạn bè của toUser
            await Client.SetAsync("Contacts/" + toUserID + "/Friends/" + fromUserID, FriendshipStatuses.Waiting);

            // Thêm tạm toUser vào ds bạn bè của fromUser
            await Client.SetAsync("Contacts/" + fromUserID + "/Friends/" + toUserID, FriendshipStatuses.RequestSent);

            // change time
            await ChangeContactTimeOfUserAsync(fromUserID);
            await ChangeContactTimeOfUserAsync(toUserID);
        }

        public static async Task AcceptFriendInvitationAsync(string fromUserID, string toUserID)
        {
            // chuyển trang thái thành ccomfirmed
            await Client.SetAsync("Contacts/" + toUserID + "/Friends/" + fromUserID, FriendshipStatuses.Confirmed);
            await Client.SetAsync("Contacts/" + fromUserID + "/Friends/" + toUserID, FriendshipStatuses.Confirmed);
            // change time
            await ChangeContactTimeOfUserAsync(fromUserID);
            await ChangeContactTimeOfUserAsync(toUserID);
        }

        public static async Task RefuseFriendInvitationAsync(string fromUserID, string toUserID)
        {
            // Xóa bạn bè đã thêm tạm khi yêu cầu két bạn
            await Client.DeleteAsync("Contacts/" + toUserID + "/Friends/" + fromUserID);
            await Client.DeleteAsync("Contacts/" + fromUserID + "/Friends/" + toUserID);

            // change time
            await ChangeContactTimeOfUserAsync(fromUserID);
            await ChangeContactTimeOfUserAsync(toUserID);
        }

        public static async Task ChangeContactTimeOfUserAsync(string userID)
        {
            await Client.SetAsync("Contacts/" + userID + "/ChangeTime", DateTime.Now);
        }
        public static async Task<DateTime> GetChangeContactTimeOfUserAsync(string userID)
        {
            var rsp = await Client.GetAsync("Contacts/" + userID + "/ChangeTime");
            if (rsp != null && rsp.Body != "null")
            {
                return rsp.ResultAs<DateTime>();
            }
            return DateTime.MinValue;
        }

        public static async Task DeleteContact(string fromUserID, string toUserID)
        {
            await Client.DeleteAsync("Contacts/" + fromUserID + "/Friends/" + toUserID);
            await ChangeContactTimeOfUserAsync(fromUserID);
        }

        public static async Task UpdateFriend(string fromUserID, string toUserID)
        {
            await Client.DeleteAsync("Contacts/" + fromUserID + "/Friends/" + toUserID);

            await Client.SetAsync("Contacts/" + toUserID + "/Friends/" + fromUserID, FriendshipStatuses.Unfriened);

            await ChangeContactTimeOfUserAsync(fromUserID);
            await ChangeContactTimeOfUserAsync(fromUserID);
        }
    }
}
