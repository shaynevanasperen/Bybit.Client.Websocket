namespace Bybit.Client.Websocket;

/// <summary>
/// Bybit static urls
/// </summary>
public static class BybitValues
{
	/// <summary>
	/// Main Bybit url to websocket API
	/// </summary>
	public const string MainApiWebsocketUrl = "wss://stream.bybit.com";

	/// <summary>
	/// Main Bybit url to websocket API
	/// </summary>
	public const string TestApiWebsocketUrl = "wss://stream-testnet.bybit.com";

	/// <summary>
	/// Bybit Private websocket path
	/// </summary>
	public const string PrivatePath = "/v5/private";

	/// <summary>
	/// Bybit Public websocket path
	/// </summary>
	public const string PublicPath = "/v5/public";

	/// <summary>
	/// Bybit Public websocket sub-path for spot
	/// </summary>
	public const string SpotPath = "/spot";

	/// <summary>
	/// Bybit Public websocket sub-path for linear futures
	/// </summary>
	public const string LinearPath = "/linear";

	/// <summary>
	/// Bybit Public websocket sub-path for inverse futures
	/// </summary>
	public const string InversePath = "/inverse";

	/// <summary>
	/// Bybit Public websocket sub-path for spread trading
	/// </summary>
	public const string SpreadPath = "/spread";

	/// <summary>
	/// Bybit Public websocket sub-path for options trading
	/// </summary>
	public const string OptionPath = "/option";
}
