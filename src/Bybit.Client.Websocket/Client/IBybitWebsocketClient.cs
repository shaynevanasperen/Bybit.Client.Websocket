using System;
using Bybit.Client.Websocket.Requests;

namespace Bybit.Client.Websocket.Client;

/// <summary>
/// Bybit websocket client.
/// </summary>
public interface IBybitWebsocketClient : IDisposable
{
	/// <summary>
	/// Serializes request and sends via websocket client.
	/// </summary>
	/// <param name="request">Request/message to be sent</param>
	void Send<T>(T request) where T : GenericRequest;
}
