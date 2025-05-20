using System.Text.Json;
using Bybit.Client.Websocket.Json;
using Microsoft.Extensions.Logging;
using Websocket.Client;

namespace Bybit.Client.Websocket.Client;

/// <summary>
/// Bybit public websocket client.
/// </summary>
/// <inheritdoc cref="IBybitPublicWebsocketClient" />
public class BybitPublicWebsocketClient(ILogger logger, IWebsocketClient client) : BybitWebsocketClient(logger, client), IBybitPublicWebsocketClient
{
	/// <inheritdoc />
	protected override string Type => "PUBLIC";

	/// <inheritdoc cref="IBybitPublicWebsocketClient" />
	public BybitPublicClientStreams Streams { get; } = new();

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
					"ping" or "pong" => TryHandle(message, BybitJson.Web.PublicPongResponse, Streams.PongStream),
					"subscribe" => TryHandle(message, BybitJson.Web.PublicSubscriptionResponse, Streams.SubscriptionResponseStream),
					_ => false
				};
		}

		var type = document.RootElement.GetProperty("type").GetString();

		if (type == "COMMAND_RESP")
			return TryHandle(message, BybitJson.Web.PublicSubscriptionResponse, Streams.SubscriptionResponseStream);

		var topic = document.RootElement.GetProperty("topic").GetString();

		if (topic == null)
			return false;

		if (topic.StartsWith("orderbook"))
			return type switch
			{
				"snapshot" => TryHandle(message, BybitJson.Web.OrderBookSnapshotResponse, Streams.OrderBookSnapshotStream),
				"delta" => TryHandle(message, BybitJson.Web.OrderBookDeltaResponse, Streams.OrderBookDeltaStream),
				_ => false
			};

		if (topic.StartsWith("publicTrade"))
			return TryHandle(message, BybitJson.Web.PublicTradeResponse, Streams.TradeStream);

		return false;
	}
}
