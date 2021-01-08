using CHAT_WPF.Models;
using CHAT_WPF.Services;
using CHAT_WPF.Utilities;
using Microsoft.Win32;
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
using System.Windows.Threading;

namespace CHAT_WPF.GUIs
{
    /// <summary>
    /// Interaction logic for UpdateInfomation.xaml
    /// </summary>
    public partial class UpdateInfomation : Window
    {
        private string ChangedAvatarPath { get; set; }
        public KeyValuePair<string, UserModel> Model { get; set; }
        public UpdateInfomation(KeyValuePair<string, UserModel> model)
        {
            InitializeComponent();
            Model = model;
        }

        public void Load()
        {
            if (Model.Value != null)
            {

                this.avatarchange.ImageSource = Ultilities.ConvertBase64StringToBitmapImage(Model.Value.Avatar);

                this.Fullnamechange.Text = Model.Value.Fullname;

                this.phonechange.Text = Model.Value.Phone;

                this.genderchange.Text = Model.Value.Gender;

                this.Emailchange.Text = Model.Value.Email;

                this.Addresschange.Text = Model.Value.Address;
            }

            this.Loading.Visibility = Visibility.Collapsed;
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


        private void Update()
        {
            if (CheckValidate())
            {
                if (!string.IsNullOrEmpty(ChangedAvatarPath))
                {
                    UserService.ChangeAvatar(Service.UserID, ChangedAvatarPath);
                }

                UserService.UpdateUserInfo(new KeyValuePair<string, UserModel>(Model.Key, new UserModel()
                {
                    Avatar = Model.Value.Avatar,
                    Fullname = Fullnamechange.Text,
                    Gender = genderchange.Text,
                    Email = Emailchange.Text,
                    Phone = Model.Value.Phone,
                    Username = Model.Value.Username,
                    Password = Model.Value.Password,
                    Address = Addresschange.Text
                }));

                MessageBox.Show("Thông tin tài khoản đã được cập nhật thành công !");
                this.Close();
            }

        }


        private void iconchangeavatar_Click(object sender, RoutedEventArgs e)
        {
            ChangeAvatar();
        }
        private void ChangeAvatar()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files | *.jpg; *.jpeg; *.png;";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                var stream = new StreamReader(dialog.FileName);
                this.avatarchange.ImageSource = Utilities.Ultilities.ConvertStreamToBitmapImage(stream.BaseStream);
                stream.Close();
                ChangedAvatarPath = dialog.FileName;
            }

        }
        private bool CheckValidate()
        {
            return true;
        }

        private void close_btn_infoUpdate_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void close_btn_infoUpdate_Click1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void _Event_MouseEnter(object sender, MouseEventArgs e)
        {
            iconchangebackground.Visibility = Visibility.Visible;
        }

        private void _Event_MouseLeave(object sender, MouseEventArgs e)
        {
            iconchangebackground.Visibility = Visibility.Hidden;
        }
        private void _Event_MouseEnter1(object sender, MouseEventArgs e)
        {
            iconchangeavatar.Visibility = Visibility.Visible;
        }

        private void _Event_MouseLeave1(object sender, MouseEventArgs e)
        {
            iconchangeavatar.Visibility = Visibility.Hidden;
        }

        private void _Event_UpdateButon_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void _Event_Loaded(object sender, RoutedEventArgs e)
        {

            Dispatcher.InvokeAsync(() => {
                Load();
            }, DispatcherPriority.ApplicationIdle);
        }
    }
}
