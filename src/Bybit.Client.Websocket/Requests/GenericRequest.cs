using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bybit.Client.Websocket.Requests;

/// <summary>
/// Represents any type of request on the websocket connection.
/// </summary>
public abstract class GenericRequest
{
	/// <summary>
	/// A customised ID, which is optional.
	/// </summary>
	[JsonPropertyName("req_id")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? RequestId { get; set; }

	/// <summary>
	/// The operation to be performed.
	/// </summary>
	[JsonPropertyName("op")]
	public string Operation { get; protected set; } = null!;

	/// <summary>
	/// The arguments for the operation. Not required for some operations.
	/// </summary>
	[JsonPropertyName("args")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public IReadOnlyCollection<object>? Arguments { get; protected set; }
}

