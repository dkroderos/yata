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
        public ObservableCollection<TodoGroup> TodoGroups { get; set; } = [];

        public TodosViewModel()
        {
            Title = "Todos";

            GetSampleData();
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

        #region Sample Data
        private void GetSampleData()
        {
            List<TodoGroup> todoGroups = new();

            TodoGroup workGroup = new TodoGroup
            {
                Id = 1,
                Name = "Work",
                Description = "Tasks related to work",
                Color = "#FFA500", // Example color code for orange
                UncheckedTodos = new List<Todo>
                {
                    new Todo
                    {
                        Id = 1,
                        GroupId = 1,
                        Name = "Complete project proposal",
                        Description = "Finish the project proposal document",
                        IsCompleted = false,
                        DateCreated = DateTime.Now.AddDays(-5),
                        LastUpdated = DateTime.Now.AddDays(-2),
                        DeadlineDate = DateTime.Now.AddDays(10)
                    },
                    new Todo
                    {
                        Id = 2,
                        GroupId = 1,
                        Name = "Prepare presentation",
                        Description = "Gather materials and create slides",
                        IsCompleted = false,
                        DateCreated = DateTime.Now.AddDays(-3),
                        LastUpdated = DateTime.Now.AddDays(-1),
                        DeadlineDate = DateTime.Now.AddDays(8)
                    }
                },
                CheckedTodos = new List<Todo>
                {
                    new Todo
                    {
                        Id = 3,
                        GroupId = 1,
                        Name = "Review document",
                        Description = "Check and finalize document",
                        IsCompleted = true,
                        DateCreated = DateTime.Now.AddDays(-7),
                        LastUpdated = DateTime.Now.AddDays(-1),
                        DeadlineDate = DateTime.Now.AddDays(5)
                    }
                }
            };

            TodoGroup personalGroup = new TodoGroup
            {
                Id = 2,
                Name = "Personal",
                Description = "Tasks related to personal life",
                Color = "#4169E1", // Example color code for royal blue
                UncheckedTodos = new List<Todo>
                {
                    new Todo
                    {
                        Id = 4,
                        GroupId = 2,
                        Name = "Buy groceries",
                        Description = "Milk, eggs, bread, etc.",
                        IsCompleted = false,
                        DateCreated = DateTime.Now.AddDays(-2),
                        LastUpdated = DateTime.Now.AddDays(-1),
                        DeadlineDate = DateTime.Now.AddDays(3)
                    },
                    new Todo
                    {
                        Id = 5,
                        GroupId = 2,
                        Name = "Exercise",
                        Description = "Go for a run or hit the gym",
                        IsCompleted = false,
                        DateCreated = DateTime.Now.AddDays(-4),
                        LastUpdated = DateTime.Now.AddDays(-1),
                        DeadlineDate = DateTime.Now.AddDays(1)
                    }
                },
                CheckedTodos = new List<Todo>
                {
                    new Todo
                    {
                        Id = 6,
                        GroupId = 2,
                        Name = "Read a book",
                        Description = "Complete reading the novel",
                        IsCompleted = true,
                        DateCreated = DateTime.Now.AddDays(-10),
                        LastUpdated = DateTime.Now.AddDays(-5),
                        DeadlineDate = DateTime.Now.AddDays(-1)
                    }
                }
            };

            todoGroups.Add(workGroup);
            todoGroups.Add(personalGroup);

            foreach (TodoGroup todoGroup in todoGroups)
            {
                TodoGroups.Add(todoGroup);
            }
        }
        #endregion
    }
}
