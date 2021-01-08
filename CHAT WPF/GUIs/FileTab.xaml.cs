using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CHAT_WPF.GUIs
{
    /// <summary>
    /// Interaction logic for FileTab.xaml
    /// </summary>
    public partial class FileTab : UserControl
    {

        private static FileTab _instance;

        public int NewFileCount = 0;

        public static FileTab Instance
        {
            get
            {
                if (_instance == null)
                {
                    return new FileTab();
                }
                else
                {
                    //DEFAULT value here. 
                    return _instance;
                }
            }
            set
            {
                _instance = value;
            }
        }
        public FileTab()
        {
            InitializeComponent();
            _instance = this;
            LoadLocalFiles();
        }

        public void LoadNewFileCount() {
            if (NewFileCount > 0)
            {
                MainWindow.Instance.FileCount.Text = NewFileCount.ToString();
                MainWindow.Instance.FileCountBorder.Visibility = Visibility.Visible;
            }
            else {
                MainWindow.Instance.FileCountBorder.Visibility = Visibility.Hidden;
            }
        }

        public void LoadLocalFiles()
        {
            FileLocalContainer.Children.Clear();

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@"C:\KChat\");
            var files = di.GetFiles("*.*").OrderByDescending(f => f.LastWriteTime);
            foreach (FileInfo file in files)
            {
                FileLocalContainer.Children.Add(new FileItemControl(file));
            }
        }

        private void _Event_OpenFolderButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", @"C:\KChat\");
        }
    }
}
