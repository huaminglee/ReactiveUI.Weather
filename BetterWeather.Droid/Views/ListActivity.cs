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
using ReactiveUI;
using BetterWeather.Data;
using Splat;
using Android.Text;

namespace BetterWeather.Droid
{
	[Activity (Label = "ListActivity")]			
	public class ListActivity : ReactiveActivity<ListViewModel>
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.ListActivity);

			this.ViewModel = Locator.Current.GetService<ListViewModel> ();
		}
	}
}

