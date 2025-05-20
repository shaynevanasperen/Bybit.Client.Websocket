using System.Text.Json.Serialization;

namespace Bybit.Client.Websocket.Models;

/// <summary>
/// Represents the response containing websocket connection details.
/// </summary>
public abstract class ConnectionResponse : Response
{
	/// <summary>
	/// Whether the operation was successful.
	/// </summary>
	[JsonPropertyName("success")]
	public bool Success { get; set; }

	/// <summary>
	/// Response message.
	/// </summary>
	[JsonPropertyName("ret_msg")]
	public string Message { get; set; } = null!;
}
