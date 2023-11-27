

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
        bool rentingOption = true;

        [ObservableProperty]
        bool sharingOption;

        [ObservableProperty]
        bool sublettingOption;

        [ObservableProperty]
        public int maxBudget;

        [ObservableProperty]
        public int minBudget;

        [ObservableProperty]
        public int distance = 3000;

        //[ObservableProperty]
        //public List<Location> postings = new List<Location>();


        public string longitude;
        public string latitude;




    }

}
