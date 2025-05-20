using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Bybit.Client.Websocket.Json;
using Bybit.Client.Websocket.Models;

namespace Bybit.Client.Websocket.Responses;

/// <summary>
/// Represents the response containing order book snapshot.
/// </summary>
public sealed class OrderBookSnapshotResponse : OrderBookResponse;

/// <summary>
/// Represents the response containing order book delta.
/// </summary>
public sealed class OrderBookDeltaResponse : OrderBookResponse;

/// <summary>
/// Represents the response containing order book snapshot or delta.
/// </summary>
public abstract class OrderBookResponse : PublicDataResponse<OrderBookUpdate>
{
	/// <summary>
	/// The timestamp from the match engine when this order book data is produced. It can be correlated with T from public trade channel.
	/// </summary>
	[JsonPropertyName("cts")]
	[JsonConverter(typeof(DateTimeIntegerMillisecondsConverter))]
	public DateTime CreatedTimestamp { get; set; }
}

/// <summary>
/// Snapshot or delta data for an order book.
/// </summary>
public sealed class OrderBookUpdate
{
	/// <summary>
	/// Symbol name.
	/// </summary>
	[JsonPropertyName("s")]
	public string Symbol { get; set; } = null!;

	/// <summary>
	/// Bids. For snapshot stream, the element is sorted by price in descending order.
	/// For each bid, index 0 is the price and index 1 is the amount.
	/// The delta data has amount=0, which means that all quotations for this price have been filled or cancelled.
	/// </summary>
	[JsonPropertyName("b")]
	public IReadOnlyCollection<double[]> Bids { get; set; } = [];

	/// <summary>
	/// Asks. For snapshot stream, the element is sorted by price in ascending order.
	/// For each ask, index 0 is the price and index 1 is the amount.
	/// The delta data has amount=0, which means that all quotations for this price have been filled or cancelled.
	/// </summary>
	[JsonPropertyName("a")]
	public IReadOnlyCollection<double[]> Asks { get; set; } = [];

	/// <summary>
	/// Update ID
	/// Occasionally, you'll receive 1, which is a snapshot data due to the restart of the service. So please overwrite your local order book.
	/// For level 1 of linear, inverse Perps and Futures, the snapshot data will be pushed again when there is no change in 3 seconds, and the UpdateId will be the same as that in the previous message.
	/// </summary>
	[JsonPropertyName("u")]
	public int UpdateId { get; set; }

	/// <summary>
	/// Cross sequence
	/// You can use this field to compare different levels order book data, and for the smaller seq, then it means the data is generated earlier.
	/// </summary>
	[JsonPropertyName("seq")]
	public long Sequence { get; set; }
}

