using CHAT_WPF.Models;
using CHAT_WPF.Services;
using CHAT_WPF.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace CHAT_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public enum Tabs
    {
        Conversation,
        Contact,
        File,
        Notification
    }

    public partial class MainWindow : Window
    {
        
        public MessageTabModel Model { get; set; }

        public static MainWindow _instance;

        public static MainWindow Instance {
            get
            {
                if (_instance == null) return new MainWindow();
                else return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            _instance = this;
            InitSystemValues();
            OnAsyns();
            UserAvatar.ImageSource = Utilities.Ultilities.ConvertBase64StringToBitmapImage(UserService.GetUserInfo().Avatar);
        }

        public void SwitchTab( Tabs tab)
        {
            if(tab== Tabs.Conversation)
            {
                Message_sc.Visibility = Visibility.Visible;
                Contact_sc.Visibility = Visibility.Collapsed;
                Notification_sc.Visibility = Visibility.Collapsed;
                File_sc.Visibility = Visibility.Collapsed;
                Home_sc.Visibility = Visibility.Collapsed;
            }
            else
            if (tab == Tabs.Contact)
            {
                Message_sc.Visibility = Visibility.Collapsed;
                Contact_sc.Visibility = Visibility.Visible;
                Notification_sc.Visibility = Visibility.Collapsed;
                File_sc.Visibility = Visibility.Collapsed;
                Home_sc.Visibility = Visibility.Collapsed;
            }
            else
            if (tab == Tabs.File)
            {
                Message_sc.Visibility = Visibility.Collapsed;
                Contact_sc.Visibility = Visibility.Collapsed;
                Notification_sc.Visibility = Visibility.Collapsed;
                File_sc.Visibility = Visibility.Visible;
                Home_sc.Visibility = Visibility.Collapsed;
            }
            else
            if (tab == Tabs.Notification)
            {
                Message_sc.Visibility = Visibility.Collapsed;
                Contact_sc.Visibility = Visibility.Collapsed;
                Notification_sc.Visibility = Visibility.Visible;
                File_sc.Visibility = Visibility.Collapsed;
                Home_sc.Visibility = Visibility.Collapsed;
            }
        }

        private void InitSystemValues()
        {
            SystemValues.Emojis = ConversationService.GetAllSystemEmojis();
            SystemValues.Stickers = ConversationService.GetAllSystemStickers();
        }

        private void OnAsyns()
        {
            Service.Client.OnAsync(
                path: "Users/" + Service.UserID + "/Avatar",
                changed: (sender, args, context) =>
                {
                    this.Dispatcher.Invoke(async () =>
                    {
                        await Task.Run(() => {
                            this.Dispatcher.Invoke( () =>
                            {
                                UserAvatar.ImageSource = Utilities.Ultilities.ConvertBase64StringToBitmapImage(args.Data);
                            });
                        });
                    });
                }
            );
        }

        private void btn_close_mainwindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_mimax_mainwindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void btn_hint_mainwindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Minimized;
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

        private void close_kchat_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenUpdateAccountInfor(object sender, MouseButtonEventArgs e)
        {
            new GUIs.UpdateInfomation(UserService.GetUser(Service.UserID)).Show();
        }

        private void _Event_LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Utilities.Ultilities.SaveUserInfor("", "", "");
            MessageBox.Show("Bạn đã đăng xuất thành công !");
            new login().Show();
            this.Close();
            MainWindow.Instance = null;
        }
        //EVENT CLICK BUTTON HOME SCREEN
        private void _Event_ConversationTab_Click(object sender, RoutedEventArgs e)
        {
            SwitchTab(Tabs.Conversation);
        }
        private void _Event_ContactTab_Click(object sender, RoutedEventArgs e)
        {
            SwitchTab(Tabs.Contact);
        }
        private void _Event_FileTab_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.FileTab.NewFileCount = 0;
            MainWindow.Instance.FileTab.LoadNewFileCount();

            SwitchTab(Tabs.File);
        }
        private void _Event_NotificationTab_Click(object sender, RoutedEventArgs e)
        { 
            SwitchTab(Tabs.Notification);
        }

    }
}
