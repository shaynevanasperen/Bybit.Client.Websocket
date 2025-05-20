using System.Reactive.Subjects;
using Bybit.Client.Websocket.Responses;

namespace Bybit.Client.Websocket.Client;

/// <summary>
/// All provided streams.
/// You need to send subscription request in advance (via method `Send()` on BybitPublicWebsocketClient).
/// </summary>
public class BybitPublicClientStreams
{
	/// <summary>
	/// Pong stream - emits on in response to ping requests.
	/// </summary>
	public readonly Subject<PublicPongResponse> PongStream = new();

	/// <summary>
	/// SubscriptionResponse stream - emits in response to subscription requests.
	/// </summary>
	public readonly Subject<PublicSubscriptionResponse> SubscriptionResponseStream = new();

	/// <summary>
	/// OrderBook stream - emits once after subscription, and possibly later on again if there was a problem on Bybit's end.
	/// </summary>
	public readonly Subject<OrderBookSnapshotResponse> OrderBookSnapshotStream = new();

	/// <summary>
	/// OrderBook stream - emits on every change to the order book after the initial snapshot.
	/// </summary>
	public readonly Subject<OrderBookDeltaResponse> OrderBookDeltaStream = new();
	
	/// <summary>
	/// Trade stream - emits on every trade executed.
	/// </summary>
	public readonly Subject<PublicTradeResponse> TradeStream = new();
}
