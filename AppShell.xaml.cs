using System.Runtime.CompilerServices;

namespace BeanTea
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        public async void BackButtonClicked()
        {
            await Navigation.PopToRootAsync();
        }
    }
}