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
    /// Interaction logic for ToolbarUserControl.xaml
    /// </summary>
    public partial class ToolbarUserControl : UserControl
    {
        public ToolbarUserControl()
        {
            InitializeComponent();

        }

        public async Task LoadAsync() {
            var user = await UserService.GetUserAsync(Service.UserID);
            UserFullname.Text = user.Value.Fullname;
        }

        private void maximize_click(object sender, RoutedEventArgs e)
        {

        }
        private void minimize_click(object sender, RoutedEventArgs e)
        {

        }

        private void close_kchat_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Close();
        }
        private void _Event_Kchat_MouseEnter(object sender, MouseEventArgs e)
        {
            close_btn.Background = Brushes.DarkRed;
            close_btn.Foreground = Brushes.White;
        }

        private void _Event_Kchat_MouseLeave(object sender, MouseEventArgs e)
        {
            close_btn.Background = null;
            close_btn.Foreground = Brushes.Gray;
        }

        private void dragMe(object sender, MouseButtonEventArgs e)
        {
            try
            {
                MainWindow.Instance.DragMove();
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(async () =>
            {
                await LoadAsync();
            });
        }
    }
}
