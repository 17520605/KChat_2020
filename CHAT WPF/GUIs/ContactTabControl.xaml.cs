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
    /// Interaction logic for ContactTabControl.xaml
    /// </summary>
    public partial class ContactTabControl : UserControl
    {
        private DateTime ChangeTime { get; set; } 
        private ContactTabModel Model { get; set; }

        private List<KeyValuePair<string, UserModel>> _Friends = new List<KeyValuePair<string, UserModel>> ();
        private List<KeyValuePair<string, UserModel>> _Users = new List<KeyValuePair<string, UserModel>>();

        public ContactTabControl()
        {
            InitializeComponent();
            
        }

        private void OnAsyns()
        {
            // get event add new message, change title, change avatar 
            Service.Client.OnAsync(
                path: "Contacts/" + Service.UserID + "/ChangeTime",
                changed: (sender, args, context) =>
                {
                    if (DateTime.Parse(args.Data) > ChangeTime)
                    {
                        this.Dispatcher.Invoke(async () =>
                        {
                            await LoadAsync();
                        });
                    }
                }
            );
        }


        public async Task LoadAsync() {

            if (Model == null){Model = new ContactTabModel();}
            Model.FriendIDs = await ContactService.GetFriendIDsAsync();
            Model.SuggestedUserIDs = await ContactService.GetSuggestedUserIDsAsync();
            ChangeTime = await ContactService.GetChangeContactTimeOfUserAsync(Service.UserID);

            FriendsContainer.Children.Clear();
            if (Model.FriendIDs != null && Model.FriendIDs.Count > 0)
            {
                foreach (var friendID in Model.FriendIDs)
                {
                    FriendsContainer.Children.Add(new ContactItemControl(friendID));
                }
            }

            SuggestedUsersContainer.Children.Clear();
            if (Model.SuggestedUserIDs != null && Model.SuggestedUserIDs.Count > 0)
            {
                foreach (var useriID in Model.SuggestedUserIDs)
                {
                    SuggestedUsersContainer.Children.Add(new ContactSuggestItemControl(useriID));
                }
            }


            // load to temp
            foreach (var friendid in Model.FriendIDs)
            {
                var user = await UserService.GetUserAsync(friendid);
                _Friends.Add(user);
            }

            // load to temp
            foreach (var userid in Model.SuggestedUserIDs)
            {
                var user = await UserService.GetUserAsync(userid);
                _Users.Add(user);
            }

        }

        public void LoadFriendTabSearch() {
            string keyword = FriendSearchText.Text.ToLower();
            if (keyword != null && keyword != "") {
                FriendsContainer.Children.Clear();
                foreach (var item in _Friends)
                {
                    if (item.Value.Fullname.Contains(keyword.ToLower()) || item.Value.Phone.Contains(keyword.ToLower())) {
                        FriendsContainer.Children.Add(new ContactItemControl(item.Key));
                    }
                }
            }
        }

        public void LoadSuggestTabSearch()
        {
            string keyword = SuggestSearchText.Text.ToLower();
            if (keyword != null && keyword != "")
            {
                SuggestedUsersContainer.Children.Clear();
                foreach (var item in _Users)
                {
                    if (item.Value.Fullname.Contains(keyword.ToLower()) || item.Value.Phone.Contains(keyword.ToLower()))
                    {
                        SuggestedUsersContainer.Children.Add(new ContactSuggestItemControl(item.Key));
                    }
                }
            }
        }


        public void OpenPersonalPage(KeyValuePair<string, UserModel> user)
        {
            if (user.Value != null)
            {
                Model.ShowedUser = user;
                InformationPersonalContainer.Children.Clear();
                InformationPersonalContainer.Children.Add(new CHAT_WPF.GUIs.ContactInformationControl(user));
                InformationPersonalImageContainer.Visibility = Visibility.Collapsed;
                //CurrentConversationContainer.Children.Clear();
               //CurrentConversationContainer.Children.Add(new CHAT_WPF.GUIs.ConversationBoxControl(conversation));
            }
            else
            {
               
            }
        }

        private void _Event_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.InvokeAsync(async () => {
                await LoadAsync();
                OnAsyns();
            }, DispatcherPriority.ApplicationIdle);
        }

        private void SuggestSearchText_KeyUp(object sender, KeyEventArgs e)
        {
            LoadSuggestTabSearch();
        }

        private void FriendSearchText_KeyUp(object sender, KeyEventArgs e)
        {
            LoadFriendTabSearch();
        }
    }
}
