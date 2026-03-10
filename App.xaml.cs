using WTW.Pages;

namespace WTW;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new HomeTabPage());
    }
}
