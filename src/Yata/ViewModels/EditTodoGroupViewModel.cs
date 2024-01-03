using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yata.Models;

namespace Yata.ViewModels;

[QueryProperty("TodoGroup", "TodoGroup")]
public partial class EditTodoGroupViewModel : BaseViewModel
{
    private readonly TodoGroupsViewModel todoGroupsViewModel;

    public EditTodoGroupViewModel(TodoGroupsViewModel todoGroupsViewModel)
    {
        Title = TodoGroup!.Name;

        this.todoGroupsViewModel = todoGroupsViewModel;
    }

    [ObservableProperty]
    private TodoGroup? todoGroup;

    [ObservableProperty]
    public string? name;

    [ObservableProperty]
    public string? description;

    [ObservableProperty]
    public string? color;

    [RelayCommand]
    private async Task UpdateTodoGroupAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            var updatedTodoGroup = new TodoGroup()
            {
                Id = TodoGroup!.Id,
                Name = Name,
                Description = Description,
                Color = Color,
            };

            for (int i = 0; i < todoGroupsViewModel.TodoGroups.Count; i++)
                if (TodoGroup!.Id == todoGroupsViewModel.TodoGroups[i].Id)
                    todoGroupsViewModel.TodoGroups[i] = TodoGroup!;
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
