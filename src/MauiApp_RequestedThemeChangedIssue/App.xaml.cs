namespace MauiApp_RequestedThemeChangedIssue
{
    public partial class App : Application
    {
        public static IServiceProvider? ServiceProvider;

        public App(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            InitializeComponent();

            if (Current is not null)
            {
                Current.RequestedThemeChanged += (s, a) =>
                {
                    Console.WriteLine($"Current AppTheme: {Current.RequestedTheme}");
                };
            }
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            AppShell? page = ServiceProvider?.GetRequiredService<AppShell>();
            return new Window(page ?? new AppShell());
        }
    }
}
