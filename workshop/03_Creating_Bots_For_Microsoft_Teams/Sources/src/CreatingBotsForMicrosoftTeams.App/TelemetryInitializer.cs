using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace CreatingBotsForMicrosoftTeams.App;

internal class TelemetryInitializer : ITelemetryInitializer
{
	private readonly string _roleName;

	public TelemetryInitializer()
	{
		_roleName = "CreatingBotsForMicrosoftTeams.App";
	}

	public void Initialize(ITelemetry telemetry)
	{
		telemetry.Context.Cloud.RoleName = _roleName;
		telemetry.Context.Cloud.RoleInstance = _roleName;
	}
}