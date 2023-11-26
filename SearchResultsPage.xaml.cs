using BeanTea.ViewModels;
using System.Collections.ObjectModel;

namespace BeanTea;

public partial class SearchResultsPage : ContentPage
{
	public ObservableCollection<SearchResultViewModel> Result; 

	public SearchResultsPage(ObservableCollection<SearchResultViewModel> LocationData)
	{
		Result = LocationData;
		InitializeComponent();

		BindingContext = Result;
	}
}