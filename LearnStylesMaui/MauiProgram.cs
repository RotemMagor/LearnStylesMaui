#if DEBUG
using Microsoft.Maui.DevFlow.Agent;
#endif
using Microsoft.Extensions.Logging;
using LearnStylesMaui.ViewModels;
using LearnStylesMaui.Views;

namespace LearnStylesMaui
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

			// רישום ViewModels ו-Views במערכת ה-Dependency Injection
			builder.Services.AddTransient<StylesDemoViewModel>();
			builder.Services.AddTransient<StylesDemoPage>();

			builder.Services.AddTransient<ConvertersDemoViewModel>();
			builder.Services.AddTransient<ConvertersDemoPage>();

			builder.Services.AddTransient<StudentsDashboardViewModel>();
			builder.Services.AddTransient<StudentsDashboardPage>();

			builder.Services.AddTransient<StudentExerciseViewModel>();
			builder.Services.AddTransient<StudentExercisePage>();

#if DEBUG
			builder.Logging.AddDebug();
#endif

#if DEBUG
			builder.AddMauiDevFlowAgent();
#endif
			return builder.Build();
		}
	}
}
