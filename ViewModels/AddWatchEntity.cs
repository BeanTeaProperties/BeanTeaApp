

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BeanTea.ViewModels
{
    public partial class AddWatchEntity : ObservableObject
    {
        public AddWatchEntity()
        {
        }

        [ObservableProperty]
        bool rentingOption = true;

        [ObservableProperty]
        bool sharingOption;

        [ObservableProperty]
        bool sublettingOption;

        [ObservableProperty]
        public int budget;

        [ObservableProperty]
        public int distance = 3000;

        public string longitude;
        public string latitude;
   

       

    }

}
