using Yata.Views;

namespace Yata
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(TodosPage), typeof(TodosPage));
            Routing.RegisterRoute(nameof(AddTodoGroupPage), typeof(AddTodoGroupPage));
            Routing.RegisterRoute(nameof(AddTodoPage), typeof(AddTodoPage));
        }
    }
}
