using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns.Observer
{
    public class TestEvents
    {
        public static void Run()
        {
            WeatherDataWithEvent data = new WeatherDataWithEvent(13);

            CurrentConditionDisplayWithEvent display1 = new CurrentConditionDisplayWithEvent("Display1", data);
            // OUTPUT --> Display1 - Temperature: 13
            CurrentConditionDisplayWithEvent display2 = new CurrentConditionDisplayWithEvent("Display2", data);
            // OUTPUT --> Display2 - Temperature: 13

            // update the temperature.
            data.Temperature = 14;

            // Display 1 and 2 show the new temperature
            // OUTPUT: 
            /* Weather data is updated
               Display1 - Temperature: 14
               Weather data is updated
               Display2 - Temperature: 14
            */

            data.OnTemperatureChanged -= display2.OnTemperatureChanged;
            data.Temperature = 15;

            // Only Display 1 shows the new temperature
            // OUTPUT: 
            /* Weather data is updated
               Display1 - Temperature: 15
            */

            Console.ReadLine();
        }
    }
}
