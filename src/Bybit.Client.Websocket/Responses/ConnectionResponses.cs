using System.Collections.Generic;
using System.Text.Json.Serialization;
using Bybit.Client.Websocket.Models;

namespace Bybit.Client.Websocket.Responses;

/// <summary>
/// Represents the response containing the answer to an authentication request.
/// </summary>
public sealed class AuthenticationResponse : ConnectionResponse;

/// <summary>
/// Represents the response containing the answer to a subscription request on private websocket channels.
/// </summary>
public sealed class PrivateSubscriptionResponse : ConnectionResponse;

/// <summary>
/// Represents the response containing the answer to a subscription request.
/// </summary>
public sealed class PublicSubscriptionResponse : ConnectionResponse
{
	/// <summary>
	/// The request identifier with which this response is correlated.
	/// </summary>
	[JsonPropertyName("req_id")]
	public string? RequestId { get; set; }

	/// <summary>
	/// The type of response. Only used for options/spread trading.
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary>
	/// The type of response. Only used for options/spread trading.
	/// </summary>
	[JsonPropertyName("data")]
	public SubscriptionResponseData? Data { get; set; }
}

/// <summary>
/// Data about the subscription response.
/// </summary>
public sealed class SubscriptionResponseData
{
	/// <summary>
	/// The topics which failed to be subscribed.
	/// </summary>
	[JsonPropertyName("failTopics")]
	public IReadOnlyCollection<string> FailTopics { get; set; } = [];

	/// <summary>
	/// The topics which were successfully subscribed.
	/// </summary>
	[JsonPropertyName("successTopics")]
	public IReadOnlyCollection<string> SuccessTopics { get; set; } = [];
}
