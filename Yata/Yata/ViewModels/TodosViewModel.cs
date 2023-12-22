using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yata.Models;

namespace Yata.ViewModels
{
    public partial class TodosViewModel : BaseViewModel
    {
        private ObservableCollection<TodoGroup> TodoGroups { get; set; } = [];

        public TodosViewModel()
        {
            Title = "Todos";
        }

        [ObservableProperty]
        private bool isRefreshing;

        [RelayCommand]
        private async Task GetTodoGroupsAsync()
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
                await Shell.Current.DisplayAlert("Error!", $"Unable to get Todo Groups: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }
    }
}
