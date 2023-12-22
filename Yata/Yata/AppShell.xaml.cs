using Yata.Views;

namespace Yata
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(TodosPage), typeof(TodosPage));
        }
    }
}
