using System.Reactive.Subjects;
using Bybit.Client.Websocket.Responses;

namespace Bybit.Client.Websocket.Client;

/// <summary>
/// All provided streams.
/// You need to send subscription request in advance (via method `Send()` on BybitPrivateWebsocketClient).
/// </summary>
public class BybitPrivateClientStreams
{
	/// <summary>
	/// AuthenticationResponse stream - emits in response to authentication requests.
	/// </summary>
	public readonly Subject<AuthenticationResponse> AuthenticationResponseStream = new();

	/// <summary>
	/// Pong stream - emits in response to ping requests.
	/// </summary>
	public readonly Subject<PrivatePongResponse> PongStream = new();

	/// <summary>
	/// SubscriptionResponse stream - emits in response to subscription requests.
	/// </summary>
	public readonly Subject<PrivateSubscriptionResponse> SubscriptionResponseStream = new();

	/// <summary>
	/// Execution stream - emits on every trade executed for the currently connected account.
	/// </summary>
	public readonly Subject<ExecutionResponse> ExecutionStream = new();

	/// <summary>
	/// Wallet stream - emits on every trade executed for the currently connected account.
	/// </summary>
	public readonly Subject<WalletResponse> WalletStream = new();
}
