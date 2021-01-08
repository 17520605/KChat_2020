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
    /// Interaction logic for NotificationTabControl.xaml
    /// </summary>
    public partial class NotificationTabControl : UserControl
    {
        public Dictionary<string, NotificationModel> Model { get; set; }

        public DateTime ChangeTime { get; set; }
        public DateTime SystemNotifSeenTime { get; set; }
        public DateTime FriendNotifSeenTime { get; set; }
        public DateTime GroupNotifSeenTime { get; set; }


        public int _NotifCount = 0;
        public int _SystemNotifCount = 0;
        public int _FriendNotifCount = 0;
        public int _GroupNotifCount = 0;

        public NotificationTabControl()
        {
            InitializeComponent();
            LoadAsync();
            OnAsyns();
        }

        [Obsolete]
        private void OnAsyns()
        {
            Service.Client.OnAsync(
                path: "Users/" + Service.UserID + "/NotificationChangeTime",
                changed: (sender, args, context) =>
                {
                    if (DateTime.Parse(args.Data) > ChangeTime)
                    {
                        this.Dispatcher.Invoke(async () =>
                        {
                            await LoadChangeAsync();
                        });
                    }
                }
            );
        }

        public async Task LoadAsync() {
            SystemNotifSeenTime = await NotificationService.GetSystemSeenTimeAsync(Service.UserID);
            GroupNotifSeenTime = await NotificationService.GetGroupSeenTimeAsync(Service.UserID);
            FriendNotifSeenTime = await NotificationService.GetFriendSeenTimeAsync(Service.UserID);
        }

        public async Task LoadChangeAsync()
        {

            Model = await Task.Run(() => NotificationService.GetNotificationsOfUserAsync(Service.UserID));

            if (Model != null)
            {
                NotificationContainer.Children.Clear();
                ConversationRequestContainer.Children.Clear();
                FriendRequestContainer.Children.Clear();

                foreach (var notif in Model)
                {
                    if (notif.Value.NotificationType == NotificationTypes.SystemNotification)
                    {
                        if (notif.Value.ChangeTime > SystemNotifSeenTime)
                        {
                            _SystemNotifCount++;
                        }
                        NotificationContainer.Children.Add(new NotificationSystemControl(notif));
                    }
                    else
                    if (notif.Value.NotificationType == NotificationTypes.ConversationInvitationRequest)
                    {
                        if (notif.Value.ChangeTime > GroupNotifSeenTime)
                        {
                            _GroupNotifCount++;
                        }
                        ConversationRequestContainer.Children.Add(new NotificationConversationRequestControl(notif));
                    }
                    else
                    if (notif.Value.NotificationType == NotificationTypes.FriendshipInvitationRequest)
                    {
                        if (notif.Value.ChangeTime > FriendNotifSeenTime)
                        {
                            _FriendNotifCount++;
                        }
                        FriendRequestContainer.Children.Add(new NotificationFriendshipRequestControl(notif));
                    }

                }

                LoadCount();

            }
            else {
                NotificationContainer.Children.Clear();
                ConversationRequestContainer.Children.Clear();
                FriendRequestContainer.Children.Clear();
            }
        }

        private void _Event_FriendButton_Click(object sender, MouseButtonEventArgs e)
        {
            this.FriendNotifSeenTime = DateTime.Now;
            this._FriendNotifCount = 0;
            this.Dispatcher.Invoke(async () =>
            {
                await NotificationService.ChangeFriendSeenTimeAsync();
            });

            LoadCount();

            this.FriendshipRequestTab.Visibility = Visibility.Visible;
            this.ConversationInvitationTab.Visibility = Visibility.Collapsed;
            this.NotificationTab.Visibility = Visibility.Collapsed;
            this.NotificationImgContainer.Visibility = Visibility.Collapsed;
        }

        private void _Event_ConversationButton_Click(object sender, MouseButtonEventArgs e)
        {
            this.GroupNotifSeenTime =  DateTime.Now;
            this._GroupNotifCount = 0;
            this.Dispatcher.Invoke(async () =>
            {
                await NotificationService.ChangeGroupSeenTimeAsync();
            });

            LoadCount();

            this.FriendshipRequestTab.Visibility = Visibility.Collapsed;
            this.ConversationInvitationTab.Visibility = Visibility.Visible;
            this.NotificationTab.Visibility = Visibility.Collapsed;
            this.NotificationImgContainer.Visibility = Visibility.Collapsed;
        }

        private void _Event_System_Click(object sender, MouseButtonEventArgs e)
        {
            this.SystemNotifSeenTime = DateTime.Now;
            this._SystemNotifCount = 0;
            this.Dispatcher.Invoke(async () =>
            {
                await NotificationService.ChangeSystemSeenTimeAsync();
            });

            LoadCount();

            this.FriendshipRequestTab.Visibility = Visibility.Collapsed;
            this.ConversationInvitationTab.Visibility = Visibility.Collapsed;
            this.NotificationImgContainer.Visibility = Visibility.Collapsed;
            this.NotificationTab.Visibility = Visibility.Visible;

        }

        private void LoadCount() {
            if (_SystemNotifCount > 0)
            {
                SystemNotifBorder.Visibility = Visibility.Visible;
                SystemNotifCount.Text = _SystemNotifCount.ToString();
            }
            else {
                SystemNotifBorder.Visibility = Visibility.Collapsed;
            }

            if (_GroupNotifCount > 0)
            {
                GroupNotifBorder.Visibility = Visibility.Visible;
                GroupNotifCount.Text = _GroupNotifCount.ToString();
            }
            else
            {
                GroupNotifBorder.Visibility = Visibility.Collapsed;
            }


            if (_FriendNotifCount > 0)
            {
                FriendNotifBorder.Visibility = Visibility.Visible;
                FriendNotifCount.Text = _FriendNotifCount.ToString();
            }
            else
            {
                FriendNotifBorder.Visibility = Visibility.Collapsed;
            }

            _NotifCount = _SystemNotifCount + _GroupNotifCount + _FriendNotifCount;

            MainWindow.Instance.NotifCount.Text = _NotifCount.ToString();

            if (_NotifCount > 0)
            {
                MainWindow.Instance.NotifCountBorder.Visibility = Visibility.Visible;
            }
            else {

                MainWindow.Instance.NotifCountBorder.Visibility = Visibility.Collapsed;
            }
            
        }


        private void _Event_FriendButton_MouseEnter(object sender, MouseEventArgs e)
        {
            FriendButton.Background = Brushes.LightGray;
        }

        private void _Event_FriendButton_MouseLeave(object sender, MouseEventArgs e)
        {
            FriendButton.Background = Brushes.White;
        }
        private void _Event_ConversationButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ConversationButton.Background = Brushes.LightGray;
        }

        private void _Event_ConversationButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ConversationButton.Background = Brushes.White;
        }
        private void _Event_system_MouseEnter(object sender, MouseEventArgs e)
        {
            SystemButton.Background = Brushes.LightGray;
        }

        private void _Event_system_MouseLeave(object sender, MouseEventArgs e)
        {
            SystemButton.Background = Brushes.White;
        }

        private void _Event_Loaded(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(async () =>
            {
                await LoadAsync();
            });
        }
    }
}
