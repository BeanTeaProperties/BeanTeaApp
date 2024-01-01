

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Maps;

namespace BeanTea.ViewModels
{
    public partial class AddWatchViewModel : ObservableObject
    {
        public AddWatchViewModel()
        {
        }

        [ObservableProperty]
        public int maxBudget;

        [ObservableProperty]
        public int minBudget;

        [ObservableProperty]
        public int distance;

        public string longitude;
        public string latitude;

        public string email;




    }

}
