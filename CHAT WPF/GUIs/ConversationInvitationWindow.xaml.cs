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
    /// Interaction logic for ConversationInvitationWindow.xaml
    /// </summary>
    public partial class ConversationInvitationWindow : Window
    {
        public Dictionary<string, UserModel> Friends { get; set; }
        public Dictionary<string, UserModel> InvitedUsers { get; set; }
        public Dictionary<string, MemberModel> Members { get; set; }
        public KeyValuePair<string, ConversationModel> Model { get; set; }

        public ConversationInvitationWindow(KeyValuePair<string, ConversationModel> model)
        { 
            InitializeComponent();
            Model = model;
            InvitedUsers = new Dictionary<string, UserModel>();
            Members = new Dictionary<string, MemberModel>();
            Friends = new Dictionary<string, UserModel>();
        }
        private void dragMe(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

                //throw;
            }
        }

        public async Task LoadAsync()
        {
            Members = await ConversationService.GetAllMembersOfConversationAsync(Model.Key);
            Friends = await ContactService.GetFriendsAsync();
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
                        if (IsJoinedMember(friend.Key))
                        {
                            // khog moi nguoi da tham gia nhom
                        }
                        else
                        if (IsInvitedMember(friend.Key))
                        {
                            SearchResultsContainer.Children.Add(new ConversationInvitationItemControl(this, friend, MemberModel.Statuses.Invited));
                        }
                        else
                        {
                            SearchResultsContainer.Children.Add(new ConversationInvitationItemControl(this, friend));
                        }
                    }
                }
            }
            else
            {
                foreach (var friend in Friends)
                {
                    if (!IsInListInvitedUsers(friend.Key) && (friend.Value.Fullname.ToLower().Contains(keyword) || friend.Value.Phone.Contains(keyword)))
                    {
                        if (IsJoinedMember(friend.Key))
                        {
                            // khog moi nguoi da tham gia nhom
                        }
                        else
                        if (IsInvitedMember(friend.Key))
                        {
                            SearchResultsContainer.Children.Add(new ConversationInvitationItemControl(this, friend, MemberModel.Statuses.Invited));
                        }
                        else
                        {
                            SearchResultsContainer.Children.Add(new ConversationInvitationItemControl(this, friend));
                        }
                    }
                }
            }
        }


        private bool IsJoinedMember(string userid)
        {
            if (Members.ContainsKey(userid))
            {
                MemberModel member;
                Members.TryGetValue(userid, out member);
                if(member!=null && member.Status == MemberModel.Statuses.Joined)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsInvitedMember(string userid)
        {
            if (Members.ContainsKey(userid))
            {
                MemberModel member;
                Members.TryGetValue(userid, out member);
                if (member != null && member.Status == MemberModel.Statuses.Invited)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsInListInvitedUsers(string userid)
        {
            if(InvitedUsers != null && InvitedUsers.ContainsKey(userid))
            {
                return true;
            }
            return false;
        }

        private void close_btn_invite_friend_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void _Event_SearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            LoadSearchResults();
        }

        private void _Event_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.InvokeAsync(async () => {
                await LoadAsync();
                Loading.Visibility = Visibility.Collapsed;
            }, DispatcherPriority.Background);
        }
    }
}
