﻿using CHAT_WPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CHAT_WPF.Services
{
    class UserService : Service
    {
        public UserService(): base()
        {

        }

        public static UserModel Login(string Username, string Password) {
            if(!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                var node = Client.Get("Users").ResultAs<Dictionary<string, UserModel>>()
                                 .Where(u => u.Value.Username == Username && u.Value.Password == Password).FirstOrDefault();  
                if (node.Value != null)
                {
                    UserID = node.Key;
                    return node.Value;
                }
            }
            return null;
        }

        public static void Register(UserModel User)
        {
            if (User!=null)
            {
                if (!CheckUsernameDuplicate(User.Username))
                {
                    var rsp = Client.Push("Users", User);
                    MessageBox.Show(rsp.Body.ToString());
                }
            }
        }

        public static void Logout(string Username)
        {

        }

        public static bool CheckUsernameDuplicate(string username)
        {
            var user = Client.Get("Users").ResultAs<Dictionary<string, UserModel>>()
                             .Where(u => u.Value.Username == username).FirstOrDefault();

            if (user.Key == null || user.Value == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool CheckPhoneDuplicate(string Phone)
        {
            return true;
        }

        public static UserModel GetUserInfo()
        {
            if (!string.IsNullOrEmpty(UserID))
            {
                var node = Client.Get("Users").ResultAs<Dictionary<string, UserModel>>()
                                 .Where(u => u.Key == UserID).FirstOrDefault();

                if (node.Value != null)
                {
                    return node.Value;
                }
            }
            return null;
        }

        public static UserModel GetUserById(string userID) 
        {
            if (!string.IsNullOrEmpty(UserID))
            {
                var node = Client.Get("Users").ResultAs<Dictionary<string, UserModel>>()
                                 .Where(u => u.Key == userID).FirstOrDefault();

                if (node.Value != null)
                {
                    return node.Value;
                }
            }
            return null;
        }

        public static KeyValuePair<string, UserModel> GetUser(string userID)
        {
            var node = Client.Get("Users").ResultAs<Dictionary<string, UserModel>>().Where(u => u.Key == userID).FirstOrDefault();
            return node;
        }

        public static async Task<KeyValuePair<string, UserModel>> GetUserAsync(string userID)
        {
            var rsp = await Client.GetAsync("Users/"+userID);
            var userinfo = rsp.ResultAs<UserModel>();
            var user = new KeyValuePair<string, UserModel>(userID, userinfo);
            return user;
        }


        public static UserModel GetUserByPhone(string Phone)
        {
            return null;
        }

        public static void UpdateUserInfo(KeyValuePair<string, UserModel> user)
        {
            Client.SetAsync("Users/" + user.Key, user.Value);
        }
        public static bool ChangeAvatar(string userID, string ImgPath)
        {
            if (!string.IsNullOrEmpty(ImgPath))
            {
                var stream = File.Open(ImgPath, FileMode.Open);
                MemoryStream ms = new MemoryStream();
                stream.CopyTo(ms);
                var imgbase64 = Convert.ToBase64String(ms.GetBuffer());
                var rsp = Client.Set("Users/" + userID + "/Avatar/", imgbase64);
                //Changed(conversationID);
                
                return true;
            }
            return false;
        }

        public static Dictionary<string, UserModel> GetAllUsers()
        {
            var users =  Client.Get("Users").ResultAs<Dictionary<string, UserModel>>().ToDictionary(u => u.Key, u => u.Value);
            return users;
        }

    }
}
