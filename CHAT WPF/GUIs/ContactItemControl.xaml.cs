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
    /// Interaction logic for ContactItemControl.xaml
    /// </summary>
    public partial class ContactItemControl : UserControl
    {
        public KeyValuePair<string, UserModel> Model { get; set; }

        public ContactItemControl(string userID)
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
                }
            }
        }



        private void _Event_MouseEnter(object sender, MouseEventArgs e)
        {
            Wrapper.Background = Brushes.LightGray;
        }

        private void _Event_MouseLeave(object sender, MouseEventArgs e)
        {
            Wrapper.Background = Brushes.White;
        }

        private void _Event_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.InvokeAsync(async () => {
                await LoadAsync();
            }, DispatcherPriority.ApplicationIdle);
        }

        private void _Event_OpenConversation_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
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

        private void _Event_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.Instance.ContactTab.OpenPersonalPage(Model);
        }
    }
}
