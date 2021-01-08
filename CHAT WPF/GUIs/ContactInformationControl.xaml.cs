using CHAT_WPF.Models;
using CHAT_WPF.Services;
using CHAT_WPF.Utilities;
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
using System.Windows.Threading;

namespace CHAT_WPF.GUIs
{
    /// <summary>
    /// Interaction logic for ContactInformationControl.xaml
    /// </summary>
    public partial class ContactInformationControl : UserControl
    {
        public KeyValuePair<string, UserModel> Model { get; set; }

        public ContactInformationControl(KeyValuePair<string, UserModel> model)
        {
            InitializeComponent();
            Model = model;
        }

        public async Task LoadAsync()
        {
            if (Model.Value != null)
            {
                var status = await ContactService.GetFriendshipStatusAsync(Model.Key);

                if (status == null || status.Contains(FriendshipStatuses.Unfriened)) // nguoi la
                {
                    ChatButon.IsEnabled = false;
                    CallButon.IsEnabled = false;

                    AddFriendButon.Visibility = Visibility.Visible;
                    UnFriendButon.Visibility = Visibility.Collapsed;
                    ComfirmRequest.Visibility = Visibility.Collapsed;
                    SentRequest.Visibility = Visibility.Collapsed;
                }
                else
                if (status.Contains(FriendshipStatuses.Confirmed)) // la ban be
                {
                    ChatButon.IsEnabled = true;
                    CallButon.IsEnabled = true;

                    AddFriendButon.Visibility = Visibility.Collapsed;
                    UnFriendButon.Visibility = Visibility.Visible;
                    ComfirmRequest.Visibility = Visibility.Collapsed;
                    SentRequest.Visibility = Visibility.Collapsed;
                    SmallLoading.Visibility = Visibility.Collapsed;
                }
                else
                if (status.Contains(FriendshipStatuses.Waiting)) // dang cho xac nhan cua ban
                {
                    ChatButon.IsEnabled = false;
                    CallButon.IsEnabled = false;

                    AddFriendButon.Visibility = Visibility.Collapsed;
                    UnFriendButon.Visibility = Visibility.Collapsed;
                    ComfirmRequest.Visibility = Visibility.Visible;
                    SentRequest.Visibility = Visibility.Collapsed;
                    SmallLoading.Visibility = Visibility.Collapsed;
                }
                else
                if (status.Contains(FriendshipStatuses.RequestSent))
                {
                    ChatButon.IsEnabled = false;
                    CallButon.IsEnabled = false;

                    AddFriendButon.Visibility = Visibility.Collapsed;
                    UnFriendButon.Visibility = Visibility.Collapsed;
                    ComfirmRequest.Visibility = Visibility.Collapsed;
                    SentRequest.Visibility = Visibility.Visible;
                    SmallLoading.Visibility = Visibility.Collapsed;
                }


                this.avatarinfor.ImageSource = Ultilities.ConvertBase64StringToBitmapImage(Model.Value.Avatar);

                this.nameinfor.Text = Model.Value.Fullname;

                this.phoneinfor.Text = Model.Value.Phone;

                this.genderinfor.Text = Model.Value.Gender;

                this.gmailinfor.Text = Model.Value.Email;

                this.addressinfor.Text = Model.Value.Address;

                this.Loading.Visibility = Visibility.Collapsed;
            }

            //this.Loading.Visibility = Visibility.Collapsed;
        }


        private void _Event_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.InvokeAsync(async () => {
                await LoadAsync();
            }, DispatcherPriority.Background);
        }

        private void AddFriendButon_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _Event_AddFriendButon_Click(object sender, RoutedEventArgs e)
        {
            SmallLoading.Visibility = Visibility.Visible;
            AddFriendButon.IsEnabled = false;
            AddFriendButon.Content = "";

            Dispatcher.InvokeAsync(async () =>
            {
                await NotificationService.SendFriendInvitationAsync(Service.UserID, Model.Key);
                SmallLoading.Visibility = Visibility.Collapsed;
                SentRequest.Visibility = Visibility.Visible;
            }, DispatcherPriority.Normal);
        }

        private void _Event_ChatButon_Click(object sender, RoutedEventArgs e)
        {
            ChatButon.IsEnabled = false;
            Dispatcher.InvokeAsync(async () => {
                var conversation = await ConversationService.GetConversationWithUserAsync(Model.Key);
                if (conversation.Key == null || conversation.Value == null)
                {
                    string id = await ConversationService.CreateConversationAsync(Service.UserID, Model.Key);
                    conversation = await ConversationService.GetConversationByIdAsync(id);
                }
                MainWindow.Instance.ConversationTab.OpenConversation(conversation);
                MainWindow.Instance.Message_sc.Visibility = Visibility.Visible;
            }, DispatcherPriority.Normal);
        }

        private void _Event_UnFriendButon_Click(object sender, RoutedEventArgs e)
        {
            SmallLoading.Visibility = Visibility.Visible;
            UnFriendButon.IsEnabled = false;
            UnFriendButon.Content = "";

            Dispatcher.InvokeAsync(async () => {
                await NotificationService.UnFriendAsync(Service.UserID, Model.Key);

                ChatButon.IsEnabled = false;
                CallButon.IsEnabled = false;

                AddFriendButon.Visibility = Visibility.Visible;
                UnFriendButon.Visibility = Visibility.Collapsed;
                ComfirmRequest.Visibility = Visibility.Collapsed;
                SentRequest.Visibility = Visibility.Collapsed;
                SmallLoading.Visibility = Visibility.Collapsed;

                this.Visibility = Visibility.Collapsed;

            }, DispatcherPriority.Normal);
        }
    }
}
