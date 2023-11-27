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
        // BindingContext = LocationData;
        // locationsListView.ItemsSource = Result;
        lblSearchResults.Text = LocationData.Count().ToString();
        //ListView listView = new ListView();
        //listView.SetBinding(LocationData, new Binding("Posting"));    
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        itemsListView.ItemsSource = Result;
    }
}