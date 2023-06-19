using System.Net.Http.Headers;
using System.Text;

namespace IncomingWebhook.App.Pages;

public partial class Index
{
	private string _status = "Ready.";

	private string? _webhookUrl = "https://axby.webhook.office.com/webhookb2/6884031e-4c66-4940-b948-9c725b11d42e@9f5c64da-d9da-4b9e-a3eb-8bd7bf6eaa9f/IncomingWebhook/a854b6c5c0664182b5ce62dcca80aa76/9d2f26ef-1c38-43df-8765-7fb1701213d9";

	private async void CallWebhook()
	{
		var client = new HttpClient();
		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		var content = new StringContent(_adaptiveCardJson.Replace("[DateTime.Now]", 
				DateTime.Now.ToLongTimeString()), Encoding.UTF8, "application/json");
		var response = await client.PostAsync(_webhookUrl, content);

		_status = response.ReasonPhrase;
	}

	private readonly string  _adaptiveCardJson = @"{
	  ""type"": ""message"",
	  ""attachments"": [
	    {
	      ""contentType"": ""application/vnd.microsoft.card.adaptive"",
	      ""content"": {
	        ""type"": ""AdaptiveCard"",
	        ""body"": [
	          {
	            ""type"": ""TextBlock"",
	            ""text"": ""Response from IncomingWebhook.App: [DateTime.Now]""
	          }
	        ],
	        ""$schema"": ""http://adaptivecards.io/schemas/adaptive-card.json"",
	        ""version"": ""1.0""
	      }
	    }
	  ]
	}";
}