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
using System.Windows.Threading;

namespace CHAT_WPF.GUIs
{
    /// <summary>
    /// Interaction logic for ContactSuggestItemControl.xaml
    /// </summary>
    public partial class ContactSuggestItemControl : UserControl
    {
        public KeyValuePair<string, UserModel> Model { get; set; }
        public ContactSuggestItemControl(string userID)
        {
            InitializeComponent();
            Model = new KeyValuePair<string, UserModel>(userID, null);
        }


        public async Task LoadAsync()
        {
            if (!string.IsNullOrEmpty(Model.Key))
            {
                Model = await UserService.GetUserAsync(Model.Key);
                if (Model.Value != null)
                {
                    Avatar.ImageSource = Utilities.Ultilities.ConvertBase64StringToBitmapImage(Model.Value.Avatar);
                    FullName.Text = Model.Value.Fullname;

                    var status = await ContactService.GetFriendshipStatusAsync(Model.Key);

                    if (status == null || status.Contains(FriendshipStatuses.Unfriened))
                    {
                        AddFriendButton.Visibility = Visibility.Visible;
                        Sent.Visibility = Visibility.Hidden;
                        Waitting.Visibility = Visibility.Hidden;
                    }
                    else
                    if (status.Contains(FriendshipStatuses.RequestSent))
                    {
                        AddFriendButton.Visibility = Visibility.Hidden;
                        Sent.Visibility = Visibility.Visible;
                        Waitting.Visibility = Visibility.Hidden;
                    }
                    else
                    if (status.Contains(FriendshipStatuses.Waiting))
                    {
                        AddFriendButton.Visibility = Visibility.Hidden;
                        Sent.Visibility = Visibility.Hidden;
                        Waitting.Visibility = Visibility.Visible;
                    }
                    
                }

            }
        }



        private void _Event_SuggestItem_MouseEnter(object sender, MouseEventArgs e)
        {
            Wrapper.Background = Brushes.LightGray;
        }

        private void _Event_SuggestItem_MouseLeave(object sender, MouseEventArgs e)
        {
            Wrapper.Background = Brushes.White;
        }

        private void _Event_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.InvokeAsync(async () => {
                await LoadAsync();
            }, DispatcherPriority.ApplicationIdle);
        }

        private void _Event_Click(object sender, RoutedEventArgs e)
        {
            this.Loading.Visibility = Visibility.Visible;
            this.AddFriendButton.Visibility = Visibility.Collapsed;

            Dispatcher.InvokeAsync(async () => {
                await NotificationService.SendFriendInvitationAsync(Service.UserID, Model.Key);
                this.Visibility = Visibility.Collapsed;
            }, DispatcherPriority.Background);
        }
        private void _Event_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.Instance.ContactTab.OpenPersonalPage(Model);
        }
    }
}
