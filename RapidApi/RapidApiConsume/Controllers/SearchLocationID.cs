using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
	public class SearchLocationID : Controller
	{
		public async Task<IActionResult> Index(string cityName)
		{
			if (!string.IsNullOrEmpty(cityName))
			{
				List<BookinkApiLocationSearchViewModel> model = new List<BookinkApiLocationSearchViewModel>();
				var client = new HttpClient();
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={cityName}"),
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
					model = JsonConvert.DeserializeObject<List<BookinkApiLocationSearchViewModel>>(body);
					return View(model.Take(1).ToList());
				}
			}
			else
			{
				List<BookinkApiLocationSearchViewModel> model = new List<BookinkApiLocationSearchViewModel>();
				var client = new HttpClient();
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name=Paris"),
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
					model = JsonConvert.DeserializeObject<List<BookinkApiLocationSearchViewModel>>(body);
					return View(model.Take(1).ToList());
				}
			}
		}
	}
}
