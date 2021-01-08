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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CHAT_WPF.GUIs
{
    /// <summary>
    /// Interaction logic for CreateNewGroupChat.xaml
    /// </summary>
    public partial class CreateNewGroupChat : Window
    {
        public Dictionary<string, UserModel> InvitedUsers { get; set; }

        public Dictionary<string, UserModel> Friends { get; set; }

        public CreateNewGroupChat()
        {
            InitializeComponent();
            InvitedUsers = new Dictionary<string, UserModel>();
            Friends = new Dictionary<string, UserModel>();
        }

        
        public async Task LoadAsync() {
            List<string> ids = await ContactService.GetFriendIDsAsync();
            foreach (var id in ids)
            {
                var friend = await UserService.GetUserAsync(id);
                Friends.Add(friend.Key, friend.Value);
            }

            LoadSearchResults();
        }

        public void LoadSearchResults() {

            SearchResultsContainer.Children.Clear();

            string keyword = SearchTextBox.Text.ToLower();

            if (keyword == "")
            {
                foreach (var friend in Friends)
                {
                    if (!IsInListInvitedUsers(friend.Key))
                    {
                        SearchResultsContainer.Children.Add(new CreateNewGroupChatItemController(this, friend));
                    }
                }
            }
            else {
                foreach (var friend in Friends)
                {
                    if (!IsInListInvitedUsers(friend.Key) && (friend.Value.Fullname.ToLower().Contains(keyword) || friend.Value.Phone.Contains(keyword)))
                    {
                        SearchResultsContainer.Children.Add(new CreateNewGroupChatItemController(this, friend));
                    }
                }
            }
        }

        private bool IsInListInvitedUsers(string userid)
        {
            if (InvitedUsers != null && InvitedUsers.ContainsKey(userid))
            {
                return true;
            }
            return false;
        }

        private bool IsValidate() {
            if (GroupName.Text == "")
            {
                return false;
            }
            else
            if (InvitedUsers.Count == 0) {
                return false;
            }

            return true;
        }

        private void close_btn_creategroup_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void _Event_CreateGroup_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidate()) {
                Dispatcher.InvokeAsync(async () => {
                    await ConversationService.CreateGroupAsync(GroupName.Text, InvitedUsers.Keys.ToList());
                    MessageBox.Show("Created");
                }, DispatcherPriority.ApplicationIdle);
            }
        }

        private void _Event_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.InvokeAsync(async () => {
                await LoadAsync();
            }, DispatcherPriority.ApplicationIdle);
        }

        private void dragMe(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {


            }
        }

        private void _Event_SearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            LoadSearchResults();
        }

        private void _Event_CreateGroup_MouseEnter(object sender, MouseEventArgs e)
        {
            if (IsValidate()) { 
                
            }
        }

        private void _Event_CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void _Event_CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidate()) {
                CreateLoading.Visibility = Visibility.Visible;
                Task.Run(() =>
                {   
                    Dispatcher.InvokeAsync(async () => {
                        await ConversationService.CreateGroupAsync(GroupName.Text, InvitedUsers.Keys.ToList());
                        Close();
                    }, DispatcherPriority.Normal);
                });
            }
        }
    }
}
