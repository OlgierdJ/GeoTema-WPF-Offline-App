using GeoTema_WPF_Offline_App.Models;
using GeoTema_WPF_Offline_App.Windows.Dashboard.ViewModels;
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
using System.Windows.Shapes;

namespace GeoTema_WPF_Offline_App.Windows.Dashboard
{
    /// <summary>
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        public DashboardWindow(UserModel user)
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            if (user.Type>=2)
            {
                GeoEdit.Visibility = Visibility.Visible;
                if (user.Type == 3)
                {
                    Users.Visibility = Visibility.Visible;
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
