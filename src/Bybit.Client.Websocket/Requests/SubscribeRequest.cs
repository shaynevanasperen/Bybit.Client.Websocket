using System.Collections.Generic;

namespace Bybit.Client.Websocket.Requests;

/// <summary>
/// Represents a request for subscribing to specified topics.
/// </summary>
public sealed class SubscribeRequest : GenericRequest
{
	/// <summary>
	/// Creates a new request with the required values.
	/// </summary>
	public SubscribeRequest(IEnumerable<string> topics)
	{
		Operation = "subscribe";
		Arguments = [.. topics];
	}
}
