using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace BetterWeather.Data.ViewModels
{
    public class ListItemViewModel : ReactiveObject
    {
        private readonly string cityName;

        public string CityName
        {
            get { return this.cityName; }
        }

        public ListItemViewModel(string cityName)
        {
            this.cityName = cityName;
        }
    }
}
