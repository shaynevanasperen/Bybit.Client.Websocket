namespace Bybit.Client.Websocket.Client;

/// <summary>
/// Bybit private websocket client.
/// </summary>
public interface IBybitPrivateWebsocketClient : IBybitWebsocketClient
{
	/// <summary>
	/// Provided public message streams.
	/// </summary>
	BybitPrivateClientStreams Streams { get; }
}
