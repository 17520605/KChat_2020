﻿using CHAT_WPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAT_WPF.Models
{
    public class UserModel
    {
       
        public string ID { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Avatar { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public DateTime ChangeTime { get; set; }
        public DateTime ConversationChangeTime { get; set; }
        public DateTime NotificationChangeTime { get; set; }
        public DateTime SystemNotifSeenTime { get; set; }
        public DateTime FriendNotifSeenTime { get; set; }
        public DateTime GroupNotifSeenTime { get; set; }

        public UserModel()
        {
            Avatar = Ultilities.GetDefaultAvatarBase64String();
        }

    }
}
