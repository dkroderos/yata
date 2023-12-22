using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yata.Models;

namespace Yata.ViewModels
{
    [QueryProperty("TodoGroup", "TodoGroup")]
    public partial class EditTodoGroupViewModel : BaseViewModel
    {
        public EditTodoGroupViewModel()
        {
            Title = TodoGroup!.Name;
        }

        [ObservableProperty]
        private TodoGroup? todoGroup;

        [RelayCommand]
        private async Task UpdateTodoGroupAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to update Todo Group: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
