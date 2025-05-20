using System;
using System.Text.Json.Serialization;
using Bybit.Client.Websocket.Json;

namespace Bybit.Client.Websocket.Models;

/// <summary>
/// Base class for private data response messages.
/// </summary>
/// <typeparam name="T">The type of data.</typeparam>
public abstract class PrivateDataResponse<T> where T : class
{
	/// <summary>
	/// The channel topic.
	/// </summary>
	[JsonPropertyName("topic")]
	public string Topic { get; set; } = null!;

	/// <summary>
	/// Message ID.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// The timestamp that the system generates the data.
	/// </summary>
	[JsonPropertyName("ts")]
	[JsonConverter(typeof(DateTimeIntegerMillisecondsConverter))]
	public DateTime CreationTime { get; set; }

	/// <summary>
	/// The data for this response.
	/// </summary>
	[JsonPropertyName("data")]
	public T Data { get; set; } = null!;
}
