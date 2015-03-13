using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using ReactiveUI;

namespace BetterWeather.Data.ViewModels
{
	public class ListViewModel : ReactiveObject
	{
	    private ReactiveList<ListItemViewModel> cityNames;
        public ReactiveList<ListItemViewModel> CityNames
	    {
	        get { return this.cityNames; }
	        set { this.RaiseAndSetIfChanged(ref this.cityNames, value); }
	    }

	    private string cityName;
	    public string CityName
	    {
            get { return this.cityName; }
            set { this.RaiseAndSetIfChanged(ref this.cityName, value); }
	    }

	    private int count = 0;

		public ListViewModel ()
		{
		    this.CityNames = new ReactiveList<ListItemViewModel>();
		    this.CityName = "Darmstadt";

		    this.WhenAnyValue(x => x.CityName)
		        .Subscribe(name =>
		        {
		            this.CityNames.Add(new ListItemViewModel(name));
		            this.CityNames.Add(new ListItemViewModel(name + count++));
                    this.CityNames.Add(new ListItemViewModel(name + count++));
                    this.CityNames.Add(new ListItemViewModel(name + count++));
                    this.CityNames.Add(new ListItemViewModel(name + count++));
		        });

            // We have to use the MainThreadScheduler for this!
		    var timer = Observable.Interval(TimeSpan.FromSeconds(2), RxApp.MainThreadScheduler);
		    timer
                .Subscribe(x => this.CityNames.Add(new ListItemViewModel(x + " " + this.CityName + count++)),
                x => this.CityNames.Add(new ListItemViewModel("Finished Interval")));
		}
	}
}

