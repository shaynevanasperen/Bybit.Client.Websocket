using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Bybit.Client.Websocket.Json;
using Bybit.Client.Websocket.Models;

namespace Bybit.Client.Websocket.Responses;

/// <summary>
/// Represents the response containing private trade executions. There can be many executions per order.
/// </summary>
public sealed class ExecutionResponse : PrivateDataResponse<IReadOnlyCollection<Execution>>;

/// <summary>
/// Execution data for an order.
/// </summary>
public sealed class Execution
{
	/// <summary>
	/// Product type
	/// UTA2.0, UTA1.0: spot, linear, inverse, option.
	/// Classic account: spot, linear, inverse.
	/// </summary>
	[JsonPropertyName("category")]
	public string Category { get; set; } = null!;

	/// <summary>
	/// Symbol name.
	/// </summary>
	[JsonPropertyName("symbol")]
	public string Symbol { get; set; } = null!;

	/// <summary>
	/// Closed position size.
	/// </summary>
	[JsonPropertyName("closedSize")]
	[JsonConverter(typeof(NullableDoubleEmptyStringConverter))]
	public double? ClosedSize { get; set; }

	/// <summary>
	/// Executed trading fee. You can get spot fee currency instruction here: https://bybit-exchange.github.io/docs/v5/enum#spot-fee-currency-instruction.
	/// Classic spot is not supported.
	/// </summary>
	[JsonPropertyName("execFee")]
	public double ExecFee { get; set; }

	/// <summary>
	/// Execution ID.
	/// </summary>
	[JsonPropertyName("execId")]
	public string ExecId { get; set; } = null!;

	/// <summary>
	/// Execution price.
	/// </summary>
	[JsonPropertyName("execPrice")]
	public double ExecPrice { get; set; }

	/// <summary>
	/// Execution qty.
	/// </summary>
	[JsonPropertyName("execQty")]
	public double ExecQty { get; set; }

	/// <summary>
	/// Executed type. Classic spot is not supported.
	/// </summary>
	[JsonPropertyName("execType")]
	public string ExecType { get; set; } = null!;

	/// <summary>
	/// Executed order value. Classic spot is not supported.
	/// </summary>
	[JsonPropertyName("execValue")]
	public double ExecValue { get; set; }

	/// <summary>
	/// Trading fee rate. Classic spot is not supported.
	/// </summary>
	[JsonPropertyName("feeRate")]
	public double FeeRate { get; set; }

	/// <summary>
	/// Implied volatility. Valid for option.
	/// </summary>
	[JsonPropertyName("tradeIv")]
	public string TradeIv { get; set; } = null!;

	/// <summary>
	/// Implied volatility of mark price. Valid for option.
	/// </summary>
	[JsonPropertyName("markIv")]
	public string MarkIv { get; set; } = null!;

	/// <summary>
	/// Paradigm block trade ID.
	/// </summary>
	[JsonPropertyName("blockTradeId")]
	public string BlockTradeId { get; set; } = null!;

	/// <summary>
	/// The mark price of the symbol when executing. Valid for option.
	/// </summary>
	[JsonPropertyName("markPrice")]
	[JsonConverter(typeof(NullableDoubleEmptyStringConverter))]
	public double? MarkPrice { get; set; }

	/// <summary>
	/// The index price of the symbol when executing. Valid for option.
	/// </summary>
	[JsonPropertyName("indexPrice")]
	[JsonConverter(typeof(NullableDoubleEmptyStringConverter))]
	public double? IndexPrice { get; set; }

	/// <summary>
	/// The underlying price of the symbol when executing. Valid for option.
	/// </summary>
	[JsonPropertyName("underlyingPrice")]
	[JsonConverter(typeof(NullableDoubleEmptyStringConverter))]
	public double? UnderlyingPrice { get; set; }

	/// <summary>
	/// The remaining qty not executed. Classic spot is not supported.
	/// </summary>
	[JsonPropertyName("leavesQty")]
	public double LeavesQty { get; set; }

	/// <summary>
	/// Order ID.
	/// </summary>
	[JsonPropertyName("orderId")]
	public string OrderId { get; set; } = null!;

	/// <summary>
	/// User customized order ID.
	/// </summary>
	[JsonPropertyName("orderLinkId")]
	public string OrderLinkId { get; set; } = null!;

	/// <summary>
	/// Order price. Classic spot is not supported.
	/// </summary>
	[JsonPropertyName("orderPrice")]
	public double OrderPrice { get; set; }

	/// <summary>
	/// Order qty. Classic spot is not supported.
	/// </summary>
	[JsonPropertyName("orderQty")]
	public double OrderQty { get; set; }

	/// <summary>
	/// Order type (Market or Limit). Classic spot is not supported.
	/// </summary>
	[JsonPropertyName("orderType")]
	public string OrderType { get; set; } = null!;

	/// <summary>
	/// Stop order type. If the order is not stop order, any type is not returned. Classic spot is not supported.
	/// </summary>
	[JsonPropertyName("stopOrderType")]
	public string StopOrderType { get; set; } = null!;

	/// <summary>
	/// Side (Buy or Sell).
	/// </summary>
	[JsonPropertyName("side")]
	public string Side { get; set; } = null!;

	/// <summary>
	/// Executed timestamp.
	/// </summary>
	[JsonPropertyName("execTime")]
	[JsonConverter(typeof(DateTimeIntegerMillisecondsConverter))]
	public DateTime ExecTime { get; set; }

	/// <summary>
	/// Whether to borrow. Unified spot only. 0: false, 1: true
	/// Classic spot is not supported, always 0.
	/// </summary>
	[JsonPropertyName("isLeverage")]
	[JsonConverter(typeof(BooleanIntegerConverter))]
	public bool IsLeverage { get; set; }

	/// <summary>
	/// Is maker order. true: maker, false: taker.
	/// </summary>
	[JsonPropertyName("isMaker")]
	public bool IsMaker { get; set; }

	/// <summary>
	/// Cross sequence, used to associate each fill and each position update.
	/// The seq will be the same when conclude multiple transactions at the same time.
	/// Different symbols may have the same seq, please use seq + symbol to check unique.
	/// </summary>
	[JsonPropertyName("seq")]
	public long Seq { get; set; }

	/// <summary>
	/// The unit for qty when executing market orders (baseCoin or quoteCoin).
	/// </summary>
	[JsonPropertyName("marketUnit")]
	public string MarketUnit { get; set; } = null!;

	/// <summary>
	/// Profit and Loss for each close position execution. The value keeps consistent with the field "cashFlow" in the Get Transaction Log.
	/// </summary>
	[JsonPropertyName("execPnl")]
	[JsonConverter(typeof(NullableDoubleEmptyStringConverter))]
	public double? ExecPnl { get; set; }

	/// <summary>
	/// Order create type
	/// Classic account & UTA1.0(category=inverse): always "".
	/// Spot, Option do not have this key.
	/// </summary>
	[JsonPropertyName("createType")]
	public string? CreateType { get; set; }
}
