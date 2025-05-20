using System.Collections.Generic;
using System.Text.Json.Serialization;
using Bybit.Client.Websocket.Models;

namespace Bybit.Client.Websocket.Responses;

/// <summary>
/// Represents the response containing the answer to a ping request on private websocket channels.
/// </summary>
public sealed class PrivatePongResponse : Response
{
	/// <summary>
	/// The request identifier with which this response is correlated.
	/// </summary>
	[JsonPropertyName("req_id")]
	public string? RequestId { get; set; }

	/// <summary>
	/// The arguments of the response. Only used for options/spread trading.
	/// </summary>
	[JsonPropertyName("args")]
	public IReadOnlyCollection<object> Arguments { get; set; } = [];
}
