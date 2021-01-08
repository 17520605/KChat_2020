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
    /// Interaction logic for ReceivedMessageControl.xaml
    /// </summary>
    public partial class ReceivedMessageControl : UserControl
    {
        public KeyValuePair<string, MessageModel> Model { get; set; }
        private Dictionary<string, UserModel> UserInfors { get; set; }

        public ReceivedMessageControl(Dictionary<string, UserModel> userInfors, KeyValuePair<string, MessageModel> model)
        {
            InitializeComponent();
            this.HorizontalAlignment = HorizontalAlignment.Left;
            UserInfors = userInfors;
            Model = model;
            Load();
        }

        private void OnAsyns()
        {
            Service.Client.OnAsync(
                path: "User/" + Model.Value.UserID+ "/Avatar",
                changed: (sender, args, context) =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        Avatar.ImageSource = Utilities.Ultilities.ConvertBase64StringToBitmapImage(args.Data);
                    });
                }
            );
        }

        private void Load()
        {
            if (Model.Value != null)
            {
                UserModel user = null;
                UserInfors.TryGetValue(Model.Value.UserID, out user);
                if(user != null)
                {
                    Avatar.ImageSource = Utilities.Ultilities.ConvertBase64StringToBitmapImage(user.Avatar);
                }

                if (!string.IsNullOrEmpty(Model.Value.Sticker))
                {
                    MessageEmojiContainer.Children.Add(new MessageStickerControl(Model.Value.Sticker));
                }
                else
                {
                    if (Model.Value.Images != null)
                    {
                        foreach (MessageFileModel file in Model.Value.Images)
                        {
                            this.MessageImagesContainer.Children.Add(new MessageImageControl(file));
                        }
                    }

                    if (Model.Value.Files != null)
                    {
                        foreach (MessageFileModel file in Model.Value.Files)
                        {
                            this.MessageFilesContainer.Children.Add(new MessageFileControl(file));
                        }
                    }

                    if (!string.IsNullOrEmpty(Model.Value.Text))
                    {
                        MessageTextContainer.Child = new TextBox()
                        {
                            Text = Model.Value.Text
                        };
                    }
                }

                SendTime.Text = Model.Value.SendTime.ToString();
            }
        }

        private void _Event_MouseEnter(object sender, MouseEventArgs e)
        {
            SendTime.Visibility = Visibility.Visible;
        }

        private void _Event_MouseLeave(object sender, MouseEventArgs e)
        {
            SendTime.Visibility = Visibility.Hidden;
        }
    }
}
