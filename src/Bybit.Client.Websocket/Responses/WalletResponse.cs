using System.Collections.Generic;
using System.Text.Json.Serialization;
using Bybit.Client.Websocket.Json;
using Bybit.Client.Websocket.Models;

namespace Bybit.Client.Websocket.Responses;

/// <summary>
/// Represents the response containing wallet details for the connected account.
/// </summary>
public sealed class WalletResponse : PrivateDataResponse<IReadOnlyCollection<Wallet>>;

/// <summary>
/// Wallet information for the connected account.
/// </summary>
public sealed class Wallet
{
	/// <summary>
	/// Account type.
	/// UTA2.0: UNIFIED.
	/// UTA1.0: UNIFIED(spot/linear/options), CONTRACT(inverse).
	/// Classic: CONTRACT, SPOT.
	/// </summary>
	[JsonPropertyName("accountType")]
	public string AccountType { get; set; } = null!;

	/// <summary>
	/// Account IM rate.
	/// You can refer to this Glossary to understand the below fields calculation and meaning
	/// All below account wide fields are not applicable to
	/// UTA2.0(isolated margin),
	/// UTA1.0(isolated margin), UTA1.0(CONTRACT),
	/// classic account(SPOT, CONTRACT)
	/// </summary>
	[JsonPropertyName("accountIMRate")]
	public double AccountInitialMarginRate { get; set; }

	/// <summary>
	/// Account MM rate.
	/// </summary>
	[JsonPropertyName("accountMMRate")]
	public double AccountMaintenanceMarginRate { get; set; }

	/// <summary>
	/// Account total equity (USD).
	/// </summary>
	[JsonPropertyName("totalEquity")]
	public double TotalEquity { get; set; }

	/// <summary>
	/// Account wallet balance (USD): ∑ Asset Wallet Balance By USD value of each asset.
	/// </summary>
	[JsonPropertyName("totalWalletBalance")]
	public double TotalWalletBalance { get; set; }

	/// <summary>
	/// Account margin balance (USD): TotalWalletBalance + TotalPerpetualUnrealizedPnl.
	/// </summary>
	[JsonPropertyName("totalMarginBalance")]
	public double TotalMarginBalance { get; set; }

	/// <summary>
	/// Account available balance (USD), Cross Margin: TotalMarginBalance - TotalInitialMargin.
	/// </summary>
	[JsonPropertyName("totalAvailableBalance")]
	public double TotalAvailableBalance { get; set; }

	/// <summary>
	/// Account Perps and Futures unrealised pnl (USD): ∑ Each Perp and USDC Futures upl by base coin.
	/// </summary>
	[JsonPropertyName("totalPerpUPL")]
	public double TotalPerpetualUnrealizedPnl { get; set; }

	/// <summary>
	/// Account initial margin (USD): ∑Asset Total Initial Margin Base Coin.
	/// </summary>
	[JsonPropertyName("totalInitialMargin")]
	public double TotalInitialMargin { get; set; }

	/// <summary>
	/// Account maintenance margin (USD): ∑ Asset Total Maintenance Margin Base Coin.
	/// </summary>
	[JsonPropertyName("totalMaintenanceMargin")]
	public double TotalMaintenanceMargin { get; set; }

	/// <summary>
	/// List of wallet information per coin.
	/// </summary>
	[JsonPropertyName("coin")]
	public Coin[] Coins { get; set; } = [];
}

/// <summary>
/// Wallet information for a specific currency.
/// </summary>
public sealed class Coin
{
	/// <summary>
	/// Coin name, such as BTC, ETH, USDT, USDC.
	/// </summary>
	[JsonPropertyName("coin")]
	public string Name { get; set; } = null!;

	/// <summary>
	/// Equity of coin.
	/// </summary>
	[JsonPropertyName("equity")]
	public double Equity { get; set; }

	/// <summary>
	/// USD value of coin. If this coin cannot be collateral, then it is 0.
	/// </summary>
	[JsonPropertyName("usdValue")]
	public double UsdValue { get; set; }

	/// <summary>
	/// Wallet balance of coin.
	/// </summary>
	[JsonPropertyName("walletBalance")]
	public double WalletBalance { get; set; }

	/// <summary>
	/// Borrow amount of coin.
	/// </summary>
	[JsonPropertyName("borrowAmount")]
	public double BorrowAmount { get; set; }

	/// <summary>
	/// Accrued interest.
	/// </summary>
	[JsonPropertyName("accruedInterest")]
	public double AccruedInterest { get; set; }

	/// <summary>
	/// Pre-occupied margin for order. For portfolio margin mode, it will be null.
	/// </summary>
	[JsonPropertyName("totalOrderIM")]
	[JsonConverter(typeof(NullableDoubleEmptyStringConverter))]
	public double? TotalOrderInitialMargin { get; set; }

	/// <summary>
	/// Sum of initial margin of all positions + Pre-occupied liquidation fee. For portfolio margin mode, it will be null.
	/// </summary>
	[JsonPropertyName("totalPositionIM")]
	[JsonConverter(typeof(NullableDoubleEmptyStringConverter))]
	public double? TotalPositionInitialMargin { get; set; }

	/// <summary>
	/// Sum of maintenance margin for all positions. For portfolio margin mode, it will be null.
	/// </summary>
	[JsonPropertyName("totalPositionMM")]
	[JsonConverter(typeof(NullableDoubleEmptyStringConverter))]
	public double? TotalPositionMaintenanceMargin { get; set; }

	/// <summary>
	/// Unrealised PnL.
	/// </summary>
	[JsonPropertyName("unrealisedPnl")]
	public double UnrealisedPnl { get; set; }

	/// <summary>
	/// Cumulative Realised PnL.
	/// </summary>
	[JsonPropertyName("cumRealisedPnl")]
	public double CumulativeRealisedPnl { get; set; }

	/// <summary>
	/// Bonus. This is a unique field for UNIFIED account.
	/// </summary>
	[JsonPropertyName("bonus")]
	public double Bonus { get; set; }

	/// <summary>
	/// Whether it can be used as a margin collateral currency (platform).
	/// When MarginCollateral is false, then CollateralSwitch is meaningless.
	/// This is a unique field for UNIFIED account.
	/// </summary>
	[JsonPropertyName("collateralSwitch")]
	public bool CollateralSwitch { get; set; }

	/// <summary>
	/// Whether the collateral is turned on by user (user).
	/// When MarginCollateral is true, then CollateralSwitch is meaningful.
	/// This is a unique field for UNIFIED account.
	/// </summary>
	[JsonPropertyName("marginCollateral")]
	public bool MarginCollateral { get; set; }

	/// <summary>
	/// Locked balance due to the Spot open order.
	/// </summary>
	[JsonPropertyName("locked")]
	public double Locked { get; set; }

	/// <summary>
	/// The spot asset qty that is used to hedge in the portfolio margin, truncate to 8 decimals and "0" by default This is a unique field for Unified account.
	/// </summary>
	[JsonPropertyName("spotHedgingQty")]
	public double SpotHedgingQuantity { get; set; }

	/// <summary>
	/// Available balance for Spot wallet. This is a unique field for Classic SPOT.
	/// </summary>
	[JsonPropertyName("free")]
	public double Free { get; set; }
}
