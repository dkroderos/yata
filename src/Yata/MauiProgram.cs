using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Yata.ViewModels;
using Yata.Views;

namespace Yata;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<TodosPage>();
        builder.Services.AddTransient<AddTodoGroupPage>();
        builder.Services.AddTransient<AddTodoPage>();

        builder.Services.AddSingleton<TodoGroupsViewModel>();
        builder.Services.AddTransient<AddTodoGroupViewModel>();
        builder.Services.AddTransient<AddTodoViewModel>();

        return builder.Build();
    }
}
