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
    /// Interaction logic for SlideKchat.xaml
    /// </summary>
    public partial class SlideKchat : UserControl
    {
        public SlideKchat()
        {
            InitializeComponent();
        }

        int i = 1;
        private void goNext(object sender, RoutedEventArgs e)
        {
            i++; // increase i by 1

            // if i's value gets larger than 6 then reset i back to 1

            if (i > 6)
            {
                i = 1;
            }

            // change the picture according to the i's value
            picHolder.Source = new BitmapImage(new Uri(@"/CHAT WPF;component/Asset/image/" + i + ".jpg", UriKind.Relative));
        }

        private void goBack(object sender, RoutedEventArgs e)
        {
            i--; // this will decrease 1 from i


            // if the value of i is less than 1
            // then give i the value of 6
            if (i < 1)
            {
                i = 6;
            }

            // change the picture according to the i's value
            picHolder.Source = new BitmapImage(new Uri(@"/CHAT WPF;component/Asset/image/" + i + ".jpg", UriKind.Relative));
        }
    }
}
