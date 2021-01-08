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

namespace CHAT_WPF.GUIs
{
    /// <summary>
    /// Interaction logic for ConversationItemControl.xaml
    /// </summary>
    public partial class ConversationItemControl : UserControl
    {
        public bool IsShowing { get; set; }
        public KeyValuePair<string, ConversationModel> Model { get; set; }

        public ConversationTabControl ConversationTab { get; set; }

        public ConversationItemControl(ConversationTabControl conversationTab, KeyValuePair<string, ConversationModel> model)
        {
            InitializeComponent();
            ConversationTab = conversationTab;
            Model = model;
            LoadAsync();
            OnAsyns();
        }
        private void _Event_ConversationItem_MouseEnter(object sender, MouseEventArgs e)
        {
            ConversationItem.Background = Brushes.LightGray;
        }

        private void _Event_ConversationItem_MouseLeave(object sender, MouseEventArgs e)
        {
            ConversationItem.Background = Brushes.White;
        }
        private void OnAsyns()
        {
            Service.Client.OnAsync(
                path: "Conversations/" + Model.Key,
                changed: (sender, args, context) =>
                {
                    if (args.Path == "/Title")
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            this.ConversationTitle.Text = args.Data;
                        });
                    }
                    else
                    if (args.Path == "/Avatar")
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            this.ConversationAvatar.ImageSource = Ultilities.ConvertBase64StringToBitmapImage(args.Data);
                        });
                    }
                    else
                    if (args.Path == "/ChangedTime" && IsShowing == false)
                    {
                        this.Dispatcher.Invoke(async () =>
                        {
                            Model = await Task.Run(() => ConversationService.GetConversationByIdAsync(Model.Key));
                            //ConversationService.GetConversationByIdAsync(Model.Key);
                            LoadAsync();
                        });
                    }
                    else
                    if (args.Path == "/Members/" + Service.UserID + "/SeenTime")
                    {
                        this.Dispatcher.Invoke(async () =>
                        {
                            Model = await Task.Run(() => ConversationService.GetConversationByIdAsync(Model.Key));
                            //Model = ConversationService.GetConversationByIdAsync(Model.Key);
                            LoadAsync();
                        });
                    }
                }
            );
        }

        public async Task LoadAsync()
        {
            if (Model.Value != null)
            {

                if (Model.Value.IsGroup) //group
                {
                    // avatar
                    this.ConversationAvatar.ImageSource = Ultilities.ConvertBase64StringToBitmapImage(Model.Value.Avatar);
                    // title
                    this.ConversationTitle.Text = Model.Value.Title;
                }
                else  // chatting
                {
                    foreach (var member in Model.Value.Members)
                    {
                        if(member.Key != Service.UserID) 
                        {
                            var infor = await UserService.GetUserAsync(member.Key);
                            // avatar
                            this.ConversationAvatar.ImageSource = Ultilities.ConvertBase64StringToBitmapImage(infor.Value.Avatar);
                            // title
                            this.ConversationTitle.Text = infor.Value.Fullname;
                        }
                    }

                }

                // unseen messages
                var user = Model.Value.Members.Where(m => m.Key == Service.UserID).FirstOrDefault();
                var unSeenMessages = Model.Value.Messages == null ? null : Model.Value.Messages.Where(m => m.Value.SendTime > user.Value.SeenTime).ToDictionary(m => m.Key, m => m.Value);
                if (unSeenMessages != null && unSeenMessages.Count > 0)
                {
                    // unsent message count
                    this.ConversationUnReadMessageCountBorder.Visibility = Visibility.Visible;
                    this.ConversationUnReadMessageCount.Text = unSeenMessages.Count().ToString();

                    // last message content
                    var lastMessage = unSeenMessages.Last();
                    if (!string.IsNullOrEmpty(lastMessage.Value.Text))
                    {
                        this.ConversationLastMessage.Text = lastMessage.Value.Text;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(lastMessage.Value.Sticker))
                        {
                            this.ConversationLastMessage.Text = "Sticker...";
                        }
                        else
                        {
                            this.ConversationLastMessage.Text = "Images...";
                        }
                    }

                    this.ConversationTitle.FontWeight = FontWeights.Bold;
                }
                else
                {
                    this.ConversationUnReadMessageCountBorder.Visibility = Visibility.Hidden;
                    this.ConversationTitle.FontWeight = FontWeights.Regular;
                    if (Model.Value.Messages != null)
                    {
                        this.ConversationLastMessage.Text = Model.Value.Messages.Last().Value.Text == null ? "Hiện không có tin nhắn mới..." : Model.Value.Messages.Last().Value.Text;
                    }
                    else
                    {
                        this.ConversationLastMessage.Text = Model.Value.Messages.Last().Value.Text == null ? "Hiện không có tin nhắn mới..." : Model.Value.Messages.Last().Value.Text;
                    }    

                }

            }
        }

        public void ShowConversation()
        {
            if (ConversationTab != null && Model.Value != null)
            {
               // MessageBox.Show("Open conversation");
                ConversationTab.OpenConversation(Model);
                IsShowing = true;
            }

        }

        private void _Event_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ConversationTab.Model.CurrentConversation.Key != Model.Key)
            {
                ShowConversation();
            }
        }
    }
}
