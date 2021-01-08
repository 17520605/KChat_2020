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
    /// Interaction logic for ConversationTabControl.xaml
    /// </summary>
    public partial class ConversationTabControl : UserControl
    {
        private DateTime ChangeTime { get; set; }
        public MessageTabModel Model { get; set; }
        public ConversationTabControl()
        {
            InitializeComponent();

            Model = new MessageTabModel();
            OnAsyns();
        }

        private void OnAsyns()
        {
            // get event add new message, change title, change avatar 
            Service.Client.OnAsync(
                path: "Users/" + Service.UserID + "/ConversationChangeTime",
                changed: (sender, args, context) =>
                {
                    if (DateTime.Parse(args.Data) > this.ChangeTime)
                    {
                        this.Dispatcher.Invoke( async () =>
                        {
                            await LoadAsync();
                        });
                    }
                }
            );
        }

        //public void OpenConversation(string ConversationID)
        //{
        //    if (!string.IsNullOrEmpty(ConversationID))
        //    {
        //        CurrentConversationContainer.Children.Clear();
        //        CurrentConversationContainer.Children.Add(new CHAT_WPF.GUIs.ConversationBoxControl(ConversationID));
        //    }
        //    else
        //    {
        //        MessageBox.Show("Error: CoversationID null");
        //    }
        //}

        public void OpenConversation(KeyValuePair<string, ConversationModel> conversation)
        {
            if (conversation.Value != null && Model.CurrentConversation.Key != conversation.Key)
            {
                Model.CurrentConversation = conversation;
                CurrentConversationContainer.Children.Clear();
                CurrentConversationContainer.Children.Add(new CHAT_WPF.GUIs.ConversationBoxControl(conversation));
                CurrentConversationImageContainer.Visibility = Visibility.Collapsed;
            }
        }

        public async Task LoadAsync()
        {
            Model.Conversations = await ConversationService.GetConversationsOfUserAsync(Service.UserID);

            //load list conversations
            this.ListConversationsContainer.Children.Clear();
            if (Model.Conversations != null)
            {
                foreach (var conversarion in Model.Conversations)
                {

                    this.ListConversationsContainer.Children.Add(new ConversationItemControl(this, conversarion));
                    //if (conversarion.Value.IsGroup == false) // 2ng
                    //{
                    //    // unfriended
                    //    foreach (var member in conversarion.Value.Members)
                    //    {
                    //        if (member.Key.Contains(Service.UserID) == false)
                    //        {
                    //            string status = await ContactService.GetFriendshipStatusAsync(member.Key);
                    //            if (status != null)
                    //            {
                    //                this.ListConversationsContainer.Children.Add(new ConversationItemControl(this, conversarion));
                    //                break;
                    //            }
                    //        }
                    //    }
                    //}
                    //else {
                    //    this.ListConversationsContainer.Children.Add(new ConversationItemControl(this, conversarion));
                    //}
                    
                }
            }

            
            // update change time
            ChangeTime = await ConversationService.GetConversationChangeTimeOfUserAsync(Service.UserID);
        }

        private void Create_group_btn_Click(object sender, RoutedEventArgs e)
        {
            new GUIs.CreateNewGroupChat().Show();
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
