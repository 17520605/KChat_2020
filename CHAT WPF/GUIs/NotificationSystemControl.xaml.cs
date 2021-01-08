using CHAT_WPF.Models;
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
    /// Interaction logic for NotificationSystemController.xaml
    /// </summary>
    public partial class NotificationSystemControl : UserControl
    {
        public KeyValuePair<string, NotificationModel> Model { get; set; }
        public NotificationSystemControl(KeyValuePair<string, NotificationModel> model)
        {
            InitializeComponent();
            Model = model;
            Load();
        }

        public void Load()
        {
            if(Model.Value != null)
            {
                NotificationSystemModel content = Newtonsoft.Json.JsonConvert.DeserializeObject<NotificationSystemModel>(Model.Value.Content.ToString());
                ContentText.Text = content.Text;
                ChangeTime.Text = Model.Value.ChangeTime.ToString();
            }
            
        }
    }
}
