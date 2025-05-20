using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Bybit.Client.Websocket.Json;
using Bybit.Client.Websocket.Models;

namespace Bybit.Client.Websocket.Responses;

/// <summary>
/// Represents the response containing trades on public websocket channels.
/// </summary>
public sealed class PublicTradeResponse : PublicDataResponse<IReadOnlyCollection<Trade>>;

/// <summary>
/// Details of a public trade.
/// </summary>
public sealed class Trade
{
	/// <summary>
	/// The timestamp that the order is filled.
	/// </summary>
	[JsonPropertyName("T")]
	[JsonConverter(typeof(DateTimeIntegerMillisecondsConverter))]
	public DateTime ExecutedAt { get; set; }

	/// <summary>
	/// Symbol name.
	/// </summary>
	[JsonPropertyName("s")]
	public string Symbol { get; set; } = null!;

	/// <summary>
	/// Side of taker (Buy or Sell).
	/// </summary>
	[JsonPropertyName("S")]
	public string TakerSide { get; set; } = null!;

	/// <summary>
	/// Trade size.
	/// </summary>
	[JsonPropertyName("v")]
	public double Size { get; set; }

	/// <summary>
	/// Trade price.
	/// </summary>
	[JsonPropertyName("p")]
	public double Price { get; set; }

	/// <summary>
	/// Direction of price change. Unique field for Perps & futures.
	/// </summary>
	[JsonPropertyName("L")]
	public string Direction { get; set; } = null!;

	/// <summary>
	/// Trade ID.
	/// </summary>
	[JsonPropertyName("i")]
	public string TradeId { get; set; } = null!;

	/// <summary>
	/// Whether it is a block trade order or not.
	/// </summary>
	[JsonPropertyName("BT")]
	public bool IsBlockTrade { get; set; }

	/// <summary>
	/// Whether it is an RPI trade or not.
	/// </summary>
	[JsonPropertyName("RPI")]
	public bool IsRetailPriceImprovement { get; set; }

	/// <summary>
	/// Message id. Unique field for option.
	/// </summary>
	[JsonPropertyName("id")]
	public string MessageId { get; set; } = null!;

	/// <summary>
	/// Mark price, unique field for option.
	/// </summary>
	[JsonPropertyName("mP")]
	public double? MarkPrice { get; set; }

	/// <summary>
	/// Index price, unique field for option.
	/// </summary>
	[JsonPropertyName("iP")]
	public double? IndexPrice { get; set; }

	/// <summary>
	/// Mark iv, unique field for option.
	/// </summary>
	[JsonPropertyName("mIv")]
	public double? MarkIv { get; set; }

	/// <summary>
	/// iv, unique field for option.
	/// </summary>
	[JsonPropertyName("iv")]
	public double? Iv { get; set; }
}
