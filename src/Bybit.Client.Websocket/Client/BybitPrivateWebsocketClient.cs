using System.Text.Json;
using Bybit.Client.Websocket.Json;
using Microsoft.Extensions.Logging;
using Websocket.Client;

namespace Bybit.Client.Websocket.Client;

/// <summary>
/// Bybit public websocket client.
/// </summary>
/// <inheritdoc cref="IBybitPrivateWebsocketClient" />
public class BybitPrivateWebsocketClient(ILogger logger, IWebsocketClient client) : BybitWebsocketClient(logger, client), IBybitPrivateWebsocketClient
{
	/// <inheritdoc />
	protected override string Type => "PRIVATE";

	/// <inheritdoc cref="IBybitPrivateWebsocketClient" />
	public BybitPrivateClientStreams Streams { get; } = new();

	/// <inheritdoc />
	protected override bool HandleObjectMessage(string message)
	{
		using var document = JsonDocument.Parse(message);

		if (document.RootElement.TryGetProperty("op", out var property))
		{
			var op = property.GetString();
			if (op != null)
				return op switch
				{
					"auth" => TryHandle(message, BybitJson.Web.AuthenticationResponse, Streams.AuthenticationResponseStream),
					"pong" => TryHandle(message, BybitJson.Web.PrivatePongResponse, Streams.PongStream),
					"subscribe" => TryHandle(message, BybitJson.Web.PrivateSubscriptionResponse, Streams.SubscriptionResponseStream),
					_ => false
				};
		}

		var topic = document.RootElement.GetProperty("topic").GetString();

		if (topic == null)
			return false;

		return topic switch
		{
			"execution" => TryHandle(message, BybitJson.Web.ExecutionResponse, Streams.ExecutionStream),
			"wallet" => TryHandle(message, BybitJson.Web.WalletResponse, Streams.WalletStream),
			_ => false
		};
	}
}
