using BeanTea.Services.BeanTeaServices;
using BeanTea.ViewModels;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BeanTea;

public partial class SearchResultsPage : ContentPage
{
	public ObservableCollection<SearchResultViewModel> Result; 
    PostingsServices postServices = new PostingsServices();

	public SearchResultsPage(ObservableCollection<SearchResultViewModel> LocationData)
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

        if (await postServices.IsItADeadLink(item.Url))
        {         
            await postServices.RemovePosting(JsonConvert.SerializeObject(item));
            await DisplayAlert("Unfortunately this listing is no longer active.", "Thanks for bringing this to our attention we will de list it.", "Back");
            Result.Remove(item);
        }
        else
        {
            await Launcher.OpenAsync(new Uri(item.Url));
        } 

    }
}