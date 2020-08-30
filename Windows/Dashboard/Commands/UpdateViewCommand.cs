using GeoTema_WPF_Offline_App.Windows.Dashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GeoTema_WPF_Offline_App.Windows.Dashboard.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Home")
            {
                viewModel.SelectedViewModel = new HomeViewModel();
            }
            else if (parameter.ToString() == "GeoData")
            {
                viewModel.SelectedViewModel = new GeoDataViewModel();
            }
            else if (parameter.ToString() == "Users")
            {
                viewModel.SelectedViewModel = new UsersViewModel();
            }
        }
    }
}
