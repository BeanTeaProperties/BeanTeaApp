using BeanTea.ViewModels;
using System.Collections.ObjectModel;

namespace BeanTea;

public partial class SearchResultsPage : ContentPage
{
	public List<SearchResultViewModel> Result; 

	public SearchResultsPage(List<SearchResultViewModel> LocationData)
	{
        InitializeComponent();
        Result = LocationData;

	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        itemsCollectionView.ItemsSource = Result;
    }

    private async void OnTapped(object sender, TappedEventArgs e)
    {
        var layout = (BindableObject)sender;
        var item = (SearchResultViewModel)layout.BindingContext;

        await Launcher.OpenAsync(new Uri(item.url));

    }
}