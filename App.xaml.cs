using MauiAuth0App.Auth0;

namespace BeanTea
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}