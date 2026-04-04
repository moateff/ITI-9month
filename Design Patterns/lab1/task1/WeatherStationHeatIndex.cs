using System;
using System.Collections.Generic;

namespace Task1
{
    class WeatherStationHeatIndex
    {
        static void Main(string[] args)
        {
            var weatherData = new WeatherData();

            var currentDisplay = new CurrentConditionsDisplay(weatherData);
            var statisticsDisplay = new StatisticsDisplay(weatherData);
            var forecastDisplay = new ForecastDisplay(weatherData);
            var heatIndexDisplay = new HeatIndexDisplay(weatherData);

            weatherData.SetMeasurements(80, 65, 30.4f);
            weatherData.SetMeasurements(82, 70, 29.2f);
            weatherData.SetMeasurements(78, 90, 29.2f);

            // Wait for user
            Console.ReadKey();
        }
    }

    #region Delegate
    public delegate void MeasurementsChangedHandler(object sender, MeasurementsEventArgs e);

    public class MeasurementsEventArgs : EventArgs
    {
        public float Temperature { get; }
        public float Humidity { get; }
        public float Pressure { get; }

        public MeasurementsEventArgs(float temperature, float humidity, float pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
        }
    }

    #endregion

    
    #region Subject

    public class WeatherData 
    {
        public event MeasurementsChangedHandler? MeasurementsChanged;

        public void OnMeasurementsChanged()
        {
            MeasurementsChanged?.Invoke(this, new(_temperature, _humidity, _pressure));
        }

        private float _temperature;
        private float _humidity;
        private float _pressure;

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            this._temperature = temperature;
            this._humidity = humidity;
            this._pressure = pressure;
            OnMeasurementsChanged();
        }
    }
    #endregion
    
    #region Observer
    public interface IDisplayElement
    {
        void Display();
    }

    public class CurrentConditionsDisplay : IDisplayElement
    {
        private float _temperature;
        private float _humidity;
        private WeatherData _weatherData;

        public CurrentConditionsDisplay(WeatherData weatherData)
        {
            this._weatherData = weatherData;
            weatherData.MeasurementsChanged += Update;
        }

        public void Update(object sender, MeasurementsEventArgs e)
        {
            this._temperature = e.Temperature;
            this._humidity = e.Humidity;
            Display();
        }

        public void Display()
        {
            Console.WriteLine("Current conditions: " + _temperature
                + "F degrees and " + _humidity + "% humidity");
        }
    }

    public class ForecastDisplay : IDisplayElement
    {
        private float _currentPressure = 29.92f;
        private float _lastPressure;
        private WeatherData _weatherData;

        public ForecastDisplay(WeatherData weatherData)
        {
            this._weatherData = weatherData;
            weatherData.MeasurementsChanged += Update;
        }

        public void Update(object sender, MeasurementsEventArgs e)
        {
            _lastPressure = _currentPressure;
            _currentPressure = e.Pressure;

            Display();
        }

        public void Display()
        {
            Console.Write("Forecast: ");

            if (_currentPressure > _lastPressure)
            {
                Console.WriteLine("Improving weather on the way!");
            }
            else if (_currentPressure == _lastPressure)
            {
                Console.WriteLine("More of the same");
            }
            else if (_currentPressure < _lastPressure)
            {
                Console.WriteLine("Watch out for cooler, rainy weather");
            }
        }
    }

    public class HeatIndexDisplay : IDisplayElement
    {
        private float _heatIndex = 0.0f;
        private WeatherData _weatherData;

        public HeatIndexDisplay(WeatherData weatherData)
        {
            this._weatherData = weatherData;
            weatherData.MeasurementsChanged += Update;
        }

        public void Update(object sender, MeasurementsEventArgs e)
        {
            _heatIndex = ComputeHeatIndex(e.Temperature, e.Humidity);
            Display();
        }

        private float ComputeHeatIndex(float t, float rh)
        {
            float heatindex = (float)
                    (
                    (16.923 + (0.185212 * t)) +
                    (5.37941 * rh) -
                    (0.100254 * t * rh) +
                    (0.00941695 * (t * t)) +
                    (0.00728898 * (rh * rh)) +
                    (0.000345372 * (t * t * rh)) -
                    (0.000814971 * (t * rh * rh)) +
                    (0.0000102102 * (t * t * rh * rh)) -
                    (0.000038646 * (t * t * t)) +
                    (0.0000291583 * (rh * rh * rh)) +
                    (0.00000142721 * (t * t * t * rh)) +
                    (0.000000197483 * (t * rh * rh * rh)) -
                    (0.0000000218429 * (t * t * t * rh * rh)) +
                    (0.000000000843296 * (t * t * rh * rh * rh)) -
                    (0.0000000000481975 * (t * t * t * rh * rh * rh)));
            return heatindex;
        }

        public void Display()
        {
            Console.WriteLine("Heat index is " + _heatIndex + "\n");
        }
    }

    public class StatisticsDisplay : IDisplayElement
    {
        private float _maxTemp = 0.0f;
        private float _minTemp = 200;
        private float _tempSum = 0.0f;
        private int _numReadings;
        private WeatherData _weatherData;

        public StatisticsDisplay(WeatherData weatherData)
        {
            this._weatherData = weatherData;
            weatherData.MeasurementsChanged += Update;
        }

        public void Update(object sender, MeasurementsEventArgs e)
        {
            _tempSum += e.Temperature;
            _numReadings++;

            if (e.Temperature > _maxTemp)
            {
                _maxTemp = e.Temperature;
            }

            if (e.Temperature < _minTemp)
            {
                _minTemp = e.Temperature;
            }

            Display();
        }

        public void Display()
        {
            Console.WriteLine("Avg/Max/Min temperature = " + (_tempSum / _numReadings)
                + "/" + _maxTemp + "/" + _minTemp);
        }
    }

    #endregion
}