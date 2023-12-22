using Yata.ViewModels;

namespace Yata.Views;

public partial class AddTodoPage : ContentPage
{
	private readonly AddTodoGroupViewModel addTodoGroupViewModel;

	public AddTodoPage(AddTodoGroupViewModel addTodoGroupViewModel)
	{
		InitializeComponent();

		this.addTodoGroupViewModel = addTodoGroupViewModel;
		BindingContext = this.addTodoGroupViewModel;
	}
}