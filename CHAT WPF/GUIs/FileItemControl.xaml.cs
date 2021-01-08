using CHAT_WPF.Models;
using CHAT_WPF.Services;
using CHAT_WPF.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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
    /// Interaction logic for FileItemControl.xaml
    /// </summary>
    public partial class FileItemControl : UserControl
    {
        public System.IO.FileInfo FileInfo { get; set; }
        public MessageFileModel Model { get; set; }

        public FileItemControl(FileInfo fileInfo)
        {
            InitializeComponent();
            FileInfo = fileInfo;
            Load();
        }

        public FileItemControl(MessageFileModel model)
        {
            InitializeComponent();
            Model = model;
            Load();
        }

        public void Load()
        {
            if(Model!= null)
            {
                string fileExtension = System.IO.Path.GetExtension(Model.FileName);
                string fileIconPath = Ultilities.GetRootPath() + "\\Asset\\FileIcons\\" + fileExtension + ".png";
                string unknownIconPath = Ultilities.GetRootPath() + "\\Asset\\FileIcons\\unknown.png";

                if (System.IO.File.Exists(fileIconPath))
                {
                    FileIcon.ImageSource = new BitmapImage(new Uri(fileIconPath));
                }
                else
                {
                    FileIcon.ImageSource = new BitmapImage(new Uri(unknownIconPath));
                }

                FileName.Text = Model.FileName;

                DowloadedTime.Text = DateTime.Now.ToString();

            }
            else
            {
                if (FileInfo != null)
                {
                    string fileExtension = System.IO.Path.GetExtension(FileInfo.Name);
                    string fileIconPath = Ultilities.GetRootPath() + "\\Asset\\FileIcons\\" + fileExtension + ".png";
                    string unknownIconPath = Ultilities.GetRootPath() + "\\Asset\\FileIcons\\unknown.png";

                    if (System.IO.File.Exists(fileIconPath))
                    {
                        FileIcon.ImageSource = new BitmapImage(new Uri(fileIconPath));
                    }
                    else
                    {
                        FileIcon.ImageSource = new BitmapImage(new Uri(unknownIconPath));
                    }

                    FileName.Text = FileInfo.Name;

                    DowloadedTime.Text = FileInfo.LastWriteTime.ToString();

                    FileSize.Text = (FileInfo.Length / (1024 * 1024)).ToString() + " MB";

                    Loading.Visibility = Visibility.Collapsed;
                    FileSize.Visibility = Visibility.Visible;
                }
            }
        }

        public async Task DowloadAsync(MessageFileControl control) {

            MainWindow.Instance.FileTab.NewFileCount++;
            MainWindow.Instance.FileTab.LoadNewFileCount();

            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler((sender, e) => {
                    Dispatcher.InvokeAsync(() => {
                        MaterialDesignThemes.Wpf.ButtonProgressAssist.SetValue(Loading, e.ProgressPercentage);
                        Console.WriteLine(e.ProgressPercentage);
                        if (e.ProgressPercentage >= 100)
                        {
                            Loading.Visibility = Visibility.Collapsed;
                            FileSize.Visibility = Visibility.Visible;
                            FileSize.Text = (e.BytesReceived / (1024 * 1024)).ToString() + " MB";

                            control.DownloadButton.Visibility = Visibility.Visible;
                            control.Loading.Visibility = Visibility.Hidden;

                            MainWindow.Instance.FileTab.LoadLocalFiles();
                        }
                    }, DispatcherPriority.ApplicationIdle);
                });

                await client.DownloadFileTaskAsync(Model.DowloadUrl, @"C:\KChat\" + Model.FileName);
            }
        }

        private void _Event_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.InvokeAsync(() => {
                Load();
            }, DispatcherPriority.ApplicationIdle);
        }

        private void _Event_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(Model!= null)
            {
                Process.Start("explorer.exe", @"C:\KChat\" + Model.FileName);
            }
            else
            if(FileInfo != null)
            {
                Process.Start("explorer.exe", FileInfo.FullName);
            }
        }

        private void _Event_MouseEnter(object sender, MouseEventArgs e)
        {
            Wrapper.Background = Brushes.LightGray;
        }

        private void _Event_MouseLeave(object sender, MouseEventArgs e)
        {
            Wrapper.Background = Brushes.Transparent;
        }

    }
}
