using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using GamingGroupFinder;
using GamingGroupFinderDatabase;
using GamingGroupFinderGUI.ViewModels;
using GamingGroupFinderGUI.Views;

namespace GamingGroupFinderGUI;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        base.OnFrameworkInitializationCompleted();
        ApplicationContext context = new ApplicationContext();
        UserManager.GetInstance().SetApplicationContext(context);
        ProfileManager.GetInstance().SetApplicationContext(context);
        EventManager.GetInstance().SetApplicationContext(context);
        MessageManager.GetInstance().SetApplicationContext(context);
        GameManager.GetInstance().SetApplicationContext(context);
        PlatformManager.GetInstance().SetApplicationContext(context);
        InterestManager.GetInstance().SetApplicationContext(context);

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {

            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),

            };
        }
    }
}