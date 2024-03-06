namespace MauiApp_RequestedThemeChangedIssue
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            if (Current is not null)
            {
                Current.RequestedThemeChanged += (s, a) =>
                {
                    Console.WriteLine($"Current AppTheme: {Current.RequestedTheme}");
                };
            }
            //MainPage = new AppShell();
            MainPage = serviceProvider.GetRequiredService<AppShell>();
        }
    }
}
