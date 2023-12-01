using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanTea.ViewModels
{
    public partial class SearchResultViewModel : ObservableObject
    {
        public SearchResultViewModel() { }

        [ObservableProperty]
         public string longitude;

        [ObservableProperty]
        public string latitude;

        [ObservableProperty]
        public string area;

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public string price;

        [ObservableProperty]
        public string url;


    }
}
