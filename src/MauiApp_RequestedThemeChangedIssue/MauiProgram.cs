using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace MauiApp_RequestedThemeChangedIssue
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureLifecycleEvents(events =>
                {
#if ANDROID && false
                events.AddAndroid(android => android
                    // The statusbar color needs to be updated after the activity has been created
                    .OnCreate((activity, bundle) => UpdateThemeColor(activity, bundle))
                    );
                static void UpdateThemeColor(Activity activity, Bundle bundle)
                {
                    new PlatformThemeService().SetStatusBarColor(App.Instance.ThemeColor?.PrimaryColor);
                }
#endif
                            })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<AppShell>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
