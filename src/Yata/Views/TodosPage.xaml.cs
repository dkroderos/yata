using Yata.ViewModels;

namespace Yata.Views;

public partial class TodosPage : ContentPage
{
	private readonly TodoGroupsViewModel todoGroupsViewModel;

	public TodosPage(TodoGroupsViewModel todoGroupsViewModel)
	{
		InitializeComponent();

		this.todoGroupsViewModel = todoGroupsViewModel;
		BindingContext = this.todoGroupsViewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}