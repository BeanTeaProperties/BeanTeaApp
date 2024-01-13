using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanTea.ViewModels
{
    public partial class WatchFoundViewModel : ObservableObject
    {

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public string area;

        [ObservableProperty]
        public string price;

        [ObservableProperty]
        public string url;

        [ObservableProperty]
        public string email;

    }
}
