using System;
using System.Text;

namespace Bybit.Client.Websocket.Requests;

/// <summary>
/// Represents a request for authenticating the websocket connection.
/// </summary>
public sealed class AuthenticationRequest : GenericRequest
{
	/// <summary>
	/// Creates a new request with the required values.
	/// </summary>
	/// <param name="apiKey">The API key.</param>
	/// <param name="apiSecret">The API secret.</param>
	public AuthenticationRequest(string apiKey, string apiSecret)
	{
		var expires = DateTime.UtcNow.ToUnixTimeMilliseconds() + 5000;
		var signature = apiSecret.SignPayloadHmacSha256($"GET/realtime{expires}", Encoding.UTF8);
		Operation = "auth";
		Arguments = [apiKey, expires, signature];
	}
}
