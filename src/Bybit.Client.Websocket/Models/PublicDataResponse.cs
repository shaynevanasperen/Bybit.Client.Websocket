using System;
using System.Text.Json.Serialization;
using Bybit.Client.Websocket.Json;

namespace Bybit.Client.Websocket.Models;

/// <summary>
/// Base class for public data response messages.
/// </summary>
/// <typeparam name="T">The type of data.</typeparam>
public abstract class PublicDataResponse<T> where T : class
{
	/// <summary>
	/// The channel topic.
	/// </summary>
	[JsonPropertyName("topic")]
	public string Topic { get; set; } = null!;

	/// <summary>
	/// Data type. Either "snapshot" or "delta".
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// The timestamp that the system generates the data.
	/// </summary>
	[JsonPropertyName("ts")]
	[JsonConverter(typeof(DateTimeIntegerMillisecondsConverter))]
	public DateTime Timestamp { get; set; }

	/// <summary>
	/// The data for this response.
	/// </summary>
	[JsonPropertyName("data")]
	public T Data { get; set; } = null!;
}
