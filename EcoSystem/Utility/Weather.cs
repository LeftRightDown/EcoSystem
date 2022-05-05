using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    enum WeatherType
    {
        Sunny,
        Cloudy,
        Rainy
    }

    internal class Weather
    {
        static Random random = new Random();
        static CountUI count = new CountUI();

        public static WeatherType CurrentWeather = WeatherType.Sunny;

        public static WeatherType GetWeather()
        {
            int num = random.Next(Enum.GetNames(typeof(WeatherType)).Length);
            CurrentWeather = (WeatherType)num;
            return CurrentWeather;
        }


        public static  void WeatherEffects()
        {
            if (CurrentWeather == WeatherType.Sunny)
            {
                MainWindow.game.Organisms[0].Amount += count.IncrementCounter();
                MainWindow.game.Organisms[1].Amount += count.IncrementCounter();


                MainWindow.game.Organisms[4].Amount -= count.DecrementCounter();
            }
            else if (CurrentWeather == WeatherType.Cloudy)
            {
                MainWindow.game.Organisms[0].Amount -=count.DecrementCounter();
                MainWindow.game.Organisms[1].Amount -= count.DecrementCounter();
                

                MainWindow.game.Organisms[7].Amount += count.IncrementCounter();
                MainWindow.game.Organisms[6].Amount += count.IncrementCounter();
                MainWindow.game.Organisms[4].Amount += count.IncrementCounter();

            }
            else if (CurrentWeather == WeatherType.Rainy)
            {
                MainWindow.game.Organisms[0].Amount += count.IncrementCounter();
                MainWindow.game.Organisms[1].Amount += count.IncrementCounter();

                MainWindow.game.Organisms[5].Amount -= count.IncrementCounter();

                MainWindow.game.Organisms[3].Amount -= count.DecrementCounter();
                MainWindow.game.Organisms[4].Amount -= count.DecrementCounter();
            }
        }
    }
}