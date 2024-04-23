using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarRental_desktop
{
	public class Car
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("license_plate_number")]
		public string License_plate_number {  get; set; }

		[JsonPropertyName("brand")]
		public string brand { get; set; }

		[JsonPropertyName("model")]
		public string model { get; set; }

		[JsonPropertyName("daily_cost")]
		public int daily_cost { get; set; }
	}
}
