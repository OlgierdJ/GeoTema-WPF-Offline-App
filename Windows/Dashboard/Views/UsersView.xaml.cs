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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeoTema_WPF_Offline_App.Windows.Dashboard.Views
{
    /// <summary>
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {
        public UsersView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        #region Create_Click
        public void Create_Click(object sender, RoutedEventArgs e)
        {
            UserModel newUser = new UserModel();
            try
            {
                newUser.Username = usernameBox.Text;
                newUser.Password = passwordBox.Text;
                newUser.Type = byte.Parse(typeBox.Text);
                SQLToolbox.CreateUser(newUser);
                MainViewModel.UserList.Add(SQLToolbox.ReturnIDUser(newUser));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Update_Click
        public void Update_Click(object sender, RoutedEventArgs e)
        {
            UserModel updatedUser = (UserModel)UserList.SelectedItem;
            try
            {
                updatedUser.Username = usernameBox.Text;
                updatedUser.Password = passwordBox.Text;
                updatedUser.Type = byte.Parse(typeBox.Text);
                SQLToolbox.UpdateUser(updatedUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UserList.Items.Refresh();
        }
        #endregion

        #region Delete_Click
        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            SQLToolbox.DeleteUser((UserModel)UserList.SelectedItem);
            MainViewModel.UserList.Remove((UserModel)UserList.SelectedItem);
        }
        #endregion

        #region Reset_Click
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            UserModel reset = (UserModel)UserList.SelectedItem;
            reset.Password = SQLToolbox.ResetPassword(reset);
            MainViewModel.UserList.Remove(reset);
            MainViewModel.UserList.Add(reset);
        }
        #endregion

    }
}
