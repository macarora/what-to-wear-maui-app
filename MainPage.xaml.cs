using WTW.Pages;

namespace WTW.Pages;
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void GetStartedButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync (new HomeTabPage());
    }
}