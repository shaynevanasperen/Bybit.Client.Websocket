namespace Bybit.Client.Websocket.Requests;

/// <summary>
/// Represents a heartbeat request, which will be responded to by a pong response.
/// </summary>
public sealed class PingRequest : GenericRequest
{
	/// <summary>
	/// Creates a new request with the required values.
	/// </summary>
	public PingRequest() => Operation = "ping";
}
