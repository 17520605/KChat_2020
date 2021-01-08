using CHAT_WPF.Models;
using CHAT_WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CHAT_WPF.GUIs
{
    /// <summary>
    /// Interaction logic for NotificationFriendshipRequestControL.xaml
    /// </summary>
    public partial class NotificationFriendshipRequestControl : UserControl
    {
        public KeyValuePair<string, NotificationModel> Model { get; set; }
        public NotificationFriendshipRequestControl(KeyValuePair<string, NotificationModel> model)
        {
            InitializeComponent();
            Model = model;
            Load();
        }

        public void Load()
        {
            if (Model.Value != null)
            {
                NotificationConversationRequestModel content = Newtonsoft.Json.JsonConvert.DeserializeObject<NotificationConversationRequestModel>(Model.Value.Content.ToString());
                UserModel fromUser = UserService.GetUserById(content.FromUserID);
                FromUserAvatar.ImageSource = Utilities.Ultilities.ConvertBase64StringToBitmapImage(fromUser.Avatar);
                ContentText.Text = "You have received a friend invitation from " + fromUser.Fullname;
                ChangeTime.Text = Model.Value.ChangeTime.ToString();
            }
        }

        private void _Event_AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            NotificationFriendshipRequestModel content = Newtonsoft.Json.JsonConvert.DeserializeObject<NotificationFriendshipRequestModel>(Model.Value.Content.ToString());
            NotificationService.AcceptFriendInvitationAsync(Model.Key, content.FromUserID, content.ToUserID);
        }

        private void _Event_RefuseButton_Click(object sender, RoutedEventArgs e)
        {
            NotificationFriendshipRequestModel content = Newtonsoft.Json.JsonConvert.DeserializeObject<NotificationFriendshipRequestModel>(Model.Value.Content.ToString());
            NotificationService.RefustFriendInvitationAsync(Model.Key, content.FromUserID, content.ToUserID);
        }
    }
}
