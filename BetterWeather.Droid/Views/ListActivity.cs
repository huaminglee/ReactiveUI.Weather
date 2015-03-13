using Android.App;
using Android.OS;
using Android.Widget;
using BetterWeather.Data.ViewModels;
using ReactiveUI;
using Splat;

namespace BetterWeather.Droid.Views
{
	[Activity (Label = "ListActivity")]			
	public class ListActivity : ReactiveActivity<ListViewModel>
	{
	    private ListView cityListView;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.ListActivity);

			this.ViewModel = Locator.Current.GetService(typeof(ListViewModel)) as ListViewModel;

            this.cityListView = FindViewById<ListView>(Resource.Id.cityNamesListView);

            ReactiveListAdapter<ListItemViewModel> adapter = new ReactiveListAdapter<ListItemViewModel>(
                this.ViewModel.CityNames,
                (viewModel, parent) => new ListItem(viewModel, this, parent));

		    this.cityListView.Adapter = adapter;
		}
	}
}

