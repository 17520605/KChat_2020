using CHAT_WPF.Models;
using CHAT_WPF.Services;
using CHAT_WPF.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    /// Interaction logic for MessageImageControl.xaml
    /// </summary>
    public partial class MessageImageControl : UserControl
    {
        public MessageFileModel Model { get; set; }


        public MessageImageControl(MessageFileModel model)
        {
            InitializeComponent();
            Model = model;
            LoadAsync();
        }

        public MessageImageControl(MessageUploadFileModel model)
        {
            InitializeComponent();
            Load(model);
        }

        public async Task LoadAsync()
        {
            if (Model != null && !string.IsNullOrEmpty(Model.DowloadUrl))
            {
                using (WebClient client = new WebClient())
                {
                    client.OpenReadCompleted += new OpenReadCompletedEventHandler((sender, e) => { 
                        Loading.Visibility = Visibility.Hidden; 
                    });

                    var stream = await client.OpenReadTaskAsync(Model.DowloadUrl); 
                    PictureImage.Source = Ultilities.ConvertStreamToBitmapImage(stream);

                }
            }
        }

        public void Load(MessageUploadFileModel model)
        {
            if (model != null)
            {
                PictureImage.Source = new BitmapImage(new Uri(model.FilePath));
                Loading.Visibility = Visibility.Hidden;
            }
        }

        // MENU CONTEN CLICK RIGHT MOUSE IN IMG CONVERSATION
        private void btCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetImage((BitmapSource)PictureImage.Source);
            if (Clipboard.ContainsImage())
            {
                MessageBox.Show("Copy thành công !");
            }
            else
            {
                MessageBox.Show("Copy Không thành công !");
            }

        }


        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (FileTab.Instance != null && Model != null && Model.DowloadUrl != null)
            {
                FileTab.Instance.FileRecentContainer.Children.Add(new FileItemControl(Model));
                MessageBox.Show("Bạn đã tải hình thành công !");
            }
            else
            {
                MessageBox.Show("Hình ảnh bạn tải gặp lỗi hoặc ảnh rỗng !");
            }
        }
    }
}
