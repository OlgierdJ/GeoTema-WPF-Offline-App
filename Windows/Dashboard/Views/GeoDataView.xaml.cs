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
    /// Interaction logic for GeoDataView.xaml
    /// </summary>
    public partial class GeoDataView : UserControl
    {
        public GeoDataView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
        #region Create_Click
        public void Create_Click(object sender, RoutedEventArgs e)
        {
            GeoDataModel geoData = new GeoDataModel();
            try
            {
                geoData.PostalCode = int.Parse(PostalCodeBox.Text);
                geoData.City = CityBox.Text;
                geoData.Population = int.Parse(PopulationBox.Text);
                geoData.Temperature = double.Parse(TemperatureBox.Text);
                SQLToolbox.CreateGeoData(geoData);
                MainViewModel.GeoDataList.Add(SQLToolbox.ReturnIDGeo(geoData));
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
            GeoDataModel updatedData = (GeoDataModel)GeoDataList.SelectedItem;
            try
            {
                updatedData.PostalCode = int.Parse(PostalCodeBox.Text);
                updatedData.City = CityBox.Text;
                updatedData.Population = int.Parse(PopulationBox.Text);
                updatedData.Temperature = double.Parse(TemperatureBox.Text);
                SQLToolbox.UpdateGeoData(updatedData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            GeoDataList.Items.Refresh();
        }
        #endregion

        #region Delete_Click
        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            SQLToolbox.DeleteGeoData((GeoDataModel)GeoDataList.SelectedItem);
            MainViewModel.GeoDataList.Remove((GeoDataModel)GeoDataList.SelectedItem);
        }
        #endregion
    }
}
