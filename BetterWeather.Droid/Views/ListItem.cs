using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BetterWeather.Data.ViewModels;
using ReactiveUI;

namespace BetterWeather.Droid.Views
{
    public class ListItem : ReactiveViewHost<ListItemViewModel>
    {
        public ListItem(ListItemViewModel viewModel, Context context, ViewGroup parent)
            : base(context, Resource.Layout.ListItem, parent)
        {
            this.ViewModel = viewModel;

            this.OneWayBind(this.ViewModel, vm => vm.CityName, v => v.CityName.Text);
        }

        /// <summary>
        /// This corresponds with the id in the ListItem.axml
        /// android:id="@+id/cityName" ==> CityName
        /// </summary>
        public TextView CityName { get; private set; }
    }
}