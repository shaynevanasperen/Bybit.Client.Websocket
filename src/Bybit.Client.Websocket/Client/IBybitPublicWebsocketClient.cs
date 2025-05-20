namespace Bybit.Client.Websocket.Client;

/// <summary>
/// Bybit public websocket client.
/// </summary>
public interface IBybitPublicWebsocketClient : IBybitWebsocketClient
{
	/// <summary>
	/// Provided public message streams.
	/// </summary>
	BybitPublicClientStreams Streams { get; }
}
