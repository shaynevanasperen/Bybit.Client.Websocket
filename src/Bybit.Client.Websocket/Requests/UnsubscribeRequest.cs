using System.Collections.Generic;

namespace Bybit.Client.Websocket.Requests;

/// <summary>
/// Represents a request for unsubscribing from specified topics.
/// </summary>
public sealed class UnsubscribeRequest : GenericRequest
{
	/// <summary>
	/// Creates a new request with the required values.
	/// </summary>
	public UnsubscribeRequest(IEnumerable<string> topics)
	{
		Operation = "unsubscribe";
		Arguments = [.. topics];
	}
}
