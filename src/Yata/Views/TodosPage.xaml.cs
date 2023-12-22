using Yata.ViewModels;

namespace Yata.Views;

public partial class TodosPage : ContentPage
{
	private readonly TodosViewModel todosViewModel;

	public TodosPage(TodosViewModel todosViewModel)
	{
		InitializeComponent();

		this.todosViewModel = todosViewModel;
		BindingContext = this.todosViewModel;
	}
}