using GeoTema_WPF_Offline_App.Models;
using GeoTema_WPF_Offline_App.Windows.Dashboard.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GeoTema_WPF_Offline_App.Windows.Dashboard.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _SelectedViewModel = new HomeViewModel();

        public BaseViewModel SelectedViewModel
        {
            get { return _SelectedViewModel; }
            set 
            {
                _SelectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        private static ObservableCollection<GeoDataModel> _GeoDataList = new ObservableCollection<GeoDataModel>(SQLToolbox.ReadGeoData());
        public static ObservableCollection<GeoDataModel> GeoDataList
        {
            get { return _GeoDataList; }
            set { _GeoDataList = value; }
        }

        private static ObservableCollection<UserModel> _UserList = new ObservableCollection<UserModel>(SQLToolbox.ReadUserData());
        public static ObservableCollection<UserModel> UserList
        {
            get { return _UserList; }
            set { _UserList = value; }
        }

        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }
    }
}
