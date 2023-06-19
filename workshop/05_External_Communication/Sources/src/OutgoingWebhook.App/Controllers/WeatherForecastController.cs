using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using System.Text;

namespace OutgoingWebhook.App.Controllers;

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
	public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

[ApiController]
public class WeatherForecastController : ControllerBase
{
	[HttpPost]
	[Route("weather-forecast")]
	public async Task<Microsoft.Bot.Schema.Activity> Run()
	{

		string requestBody;
		using (var reader = new StreamReader(Request.Body))
		{
			requestBody = await reader.ReadToEndAsync();
		}

		var incomingActivity = JsonConvert.DeserializeObject<Microsoft.Bot.Schema.Activity>(requestBody);
		return CreateActivity(incomingActivity);
	}

	private static Microsoft.Bot.Schema.Activity CreateActivity(IActivity? incomingActivity)
	{
		var summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		var forecast = Enumerable.Range(1, 5).Select(index =>
				new WeatherForecast
				(
					DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
					Random.Shared.Next(20, 35),
					summaries[Random.Shared.Next(summaries.Length)]
				))
			.ToArray();

		var stringBuilder = new StringBuilder();

		foreach (var weather in forecast)
		{
			stringBuilder.Append($"Date: {weather.Date} Temperature: {weather.TemperatureC} °C ");
		}

		var sampleResponseActivity = new Microsoft.Bot.Schema.Activity
		{
			Text = "Here's weather forecast: " + incomingActivity?.From.Name + "\n\r" + stringBuilder
		};

		return sampleResponseActivity;
	}
}