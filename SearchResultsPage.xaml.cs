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

    private async void ViewCell_Tapped(object sender, EventArgs e)
    {
        var test = sender;
        var test1 = e;

   

        var viewCell = sender as ViewCell;
        if (viewCell?.BindingContext is SearchResultViewModel item)
        {
            // Perform action with the tapped item
            await Launcher.OpenAsync(new Uri(item.url));
        }
    }
}