using Tag_Go.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tag_Go.DAL.Entities.WeatherForecast;

namespace Tag_Go.DAL.Interfaces
{
    public interface IWeatherForecastRepository
    {
        bool Create(WeatherForecast wearherForecast);
        void CreateWeatherForecast(WeatherForecast weatherForecast);
        IEnumerable<WeatherForecast?> GetAll();
        WeatherForecast? GetById(int weatherForecast_Id);
        WeatherForecast? Delete(int weatherForecast_Id);
        WeatherForecast? Update(int weatherForecast_Id, DateTime date, string? temperatureC, string? temperatureF, string? summary, string? description, string? humidity, string? precipitation);
    }
}
