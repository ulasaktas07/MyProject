using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
	public class BookingByCityController : Controller
	{
		public async Task<IActionResult> Index(string cityID)
		{
			if (!string.IsNullOrEmpty(cityID))
			{
				var client = new HttpClient();
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/search?categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&adults_number=2&page_number=0&children_number=2&include_adjacency=true&children_ages=5%2C0&locale=en-gb&dest_type=city&filter_by_currency=AED&dest_id={cityID}&order_by=popularity&units=metric&checkout_date=2025-10-18&room_number=1&checkin_date=2025-10-14"),
					Headers =
	{
		{ "x-rapidapi-key", "ebc6120d30mshcaba12226a713cap115b63jsn79340c9e14f1" },
		{ "x-rapidapi-host", "booking-com.p.rapidapi.com" },
	},
				};
				using (var response = await client.SendAsync(request))
				{
					response.EnsureSuccessStatusCode();
					var body = await response.Content.ReadAsStringAsync();
					var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);
					return View(values.result.ToList());
				}
			}
			else
			{
				var client = new HttpClient();
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/search?categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&adults_number=2&page_number=0&children_number=2&include_adjacency=true&children_ages=5%2C0&locale=en-gb&dest_type=city&filter_by_currency=AED&dest_id=-1456928&order_by=popularity&units=metric&checkout_date=2025-10-18&room_number=1&checkin_date=2025-10-14"),
					Headers =
	{
		{ "x-rapidapi-key", "ebc6120d30mshcaba12226a713cap115b63jsn79340c9e14f1" },
		{ "x-rapidapi-host", "booking-com.p.rapidapi.com" },
	},
				};
				using (var response = await client.SendAsync(request))
				{
					response.EnsureSuccessStatusCode();
					var body = await response.Content.ReadAsStringAsync();
					var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);
					return View(values.result.ToList());
				}
			}
		}
	}
}
