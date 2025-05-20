using System.Text.Json.Serialization;

namespace Bybit.Client.Websocket.Models;

/// <summary>
/// Base class for raw response messages.
/// </summary>
public abstract class Response
{
	/// <summary>
	/// The operation that was performed.
	/// </summary>
	[JsonPropertyName("op")]
	public string Operation { get; set; } = null!;

	/// <summary>
	/// The connection identifier.
	/// </summary>
	[JsonPropertyName("conn_id")]
	public string ConnectionId { get; set; } = null!;
}
