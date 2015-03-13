using System;
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

		public ListViewModel ()
		{
		    this.CityNames = new ReactiveList<ListItemViewModel>();
		    this.CityName = "Darmstadt";

		    this.WhenAnyValue(x => x.CityName)
		        .Subscribe(name =>
		        {
		            this.CityNames.Add(new ListItemViewModel(name));
		            this.CityNames.Add(new ListItemViewModel(name + "2"));
		            this.CityNames.Add(new ListItemViewModel(name + "3"));
		            this.CityNames.Add(new ListItemViewModel(name + "4"));
                    this.CityNames.Add(new ListItemViewModel(name + "5"));
		        });
		}
	}
}

