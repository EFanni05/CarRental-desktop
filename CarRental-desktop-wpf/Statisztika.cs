using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_desktop
{
	public class Statisztika
	{
		public List<Car> cars =new List<Car>();

		private static HttpClient _httpClient = new HttpClient();

        public Statisztika()
        {
            _httpClient.BaseAddress = new Uri("http://localhost:3000/");
			_httpClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");
			cars = (List<Car>?)GetCars();
		}

		private IList<Car>? GetCars()
		{
			var response = _httpClient.GetAsync("/cars").Result;
			response.EnsureSuccessStatusCode();
			var json = response.Content.ReadAsStringAsync().Result;
			return (IList<Car>?)JsonConvert.DeserializeObject<Car>(json);
		}

		public string Olcsobb()
		{
			return $"20.000 Ft-nál olcsóbb napidíjú autók száma: {cars.FindAll(x => x.Daily_cost < 20000).Count}";
		}

		public string VanE26()
		{
			if(cars.Find(x => x.Daily_cost > 26000) != null)
			{
				return "Van az adatok között 26.000 Ft-nál drágább napidíjú autó";
			}
			return "Nincs az adatok között 26.000 Ft-nál drágább napidíjú autó";
		}

		public string FindByLicens(string license)
		{
			Car a = cars.Find(x => x.License_plate_number == license);
			if ( a == null)
			{
				return "Nincs ilyen autó";
			}
			return a.Daily_cost < 26000 ? "A megadott autónapidíja nagyobb mint 25.000 Ft" : "A megadott autónapidíja nem nagyobb mint 25.000 Ft";
		}

		public void findbards()
		{

		}
    }
}
