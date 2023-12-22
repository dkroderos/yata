using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yata.Models;
using Yata.Services;

namespace Yata.ViewModels;

public partial class AddTodoGroupViewModel : BaseViewModel
{
    public AddTodoGroupViewModel()
    {
        Title = "Add Group";
    }

    [ObservableProperty]
    public string? name;

    [ObservableProperty]
    public string? description;

    [ObservableProperty]
    public string? color;

    [RelayCommand]
    private async Task AddTodoGroupAsync()
    {
        try
        {
            await TodoGroupService.AddTodoGroupAsync(new TodoGroup()
            {
                Name = Name,
                Description = Description is null ? "" : Description,
                Color = Color,
            });

            await Shell.Current.CurrentPage.DisplayAlert("Success!",
                $"Todo added", "OK");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.CurrentPage.DisplayAlert("Error!",
                $"Unable to add Todo: {ex.Message}", "OK");
        }
    }
}
