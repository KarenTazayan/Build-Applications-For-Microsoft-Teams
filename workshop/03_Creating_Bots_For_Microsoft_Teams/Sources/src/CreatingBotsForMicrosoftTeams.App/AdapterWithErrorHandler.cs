using System.Security.Claims;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Builder.TraceExtensions;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Bot.Schema;

namespace CreatingBotsForMicrosoftTeams.App;

public class AdapterWithErrorHandler : CloudAdapter
{
	public AdapterWithErrorHandler(BotFrameworkAuthentication auth, ILogger<IBotFrameworkHttpAdapter> logger)
		: base(auth, logger)
	{
		OnTurnError = async (turnContext, exception) =>
		{
			// Log any leaked exception from the application.
			// NOTE: In production environment, you should consider logging this to
			// Azure Application Insights. Visit https://aka.ms/bottelemetry to see how
			// to add telemetry capture to your bot.
			logger.LogError($"Exception caught : {exception.Message}");

			// Uncomment below commented line for local debugging.
			// await turnContext.SendActivityAsync($"Sorry, it looks like something went wrong. Exception Caught: {exception.Message}");

			// Send a trace activity, which will be displayed in the Bot Framework Emulator
			await turnContext.TraceActivityAsync("OnTurnError Trace", exception.Message, "https://www.botframework.com/schemas/error", "TurnError");
		};
	}

	public override Task<InvokeResponse> ProcessActivityAsync(ClaimsIdentity claimsIdentity, Activity activity,
		BotCallbackHandler callback,
		CancellationToken cancellationToken)
	{
		return base.ProcessActivityAsync(claimsIdentity, activity, callback, cancellationToken);
	}
}