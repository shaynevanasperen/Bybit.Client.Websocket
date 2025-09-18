using System;
using System.Reactive.Subjects;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using Bybit.Client.Websocket.Json;
using Bybit.Client.Websocket.Requests;
using Microsoft.Extensions.Logging;
using Websocket.Client;

namespace Bybit.Client.Websocket.Client;

/// <inheritdoc cref="IBybitWebsocketClient" />
public abstract class BybitWebsocketClient : IBybitWebsocketClient
{
	readonly ILogger _logger;
	readonly IWebsocketClient _client;
	readonly IDisposable _clientMessageReceivedSubscription;

	/// <summary>
	/// Creates a new instance.
	/// </summary>
	/// <param name="logger">The logger to use for logging any warnings or errors.</param>
	/// <param name="client">The client to use for the trade websocket.</param>
	protected BybitWebsocketClient(ILogger logger, IWebsocketClient client)
	{
		_logger = logger;
		_client = client;

		_clientMessageReceivedSubscription = _client.MessageReceived.Subscribe(HandleMessage);
	}

	/// <summary>
	/// The type of the websocket client (PUBLIC or PRIVATE).
	/// </summary>
	protected abstract string Type { get; }

	/// <inheritdoc />
	public void Send<T>(T request) where T : GenericRequest
	{
		try
		{
			var serialized = request switch
			{
				AuthenticationRequest authenticationRequest => JsonSerializer.Serialize(authenticationRequest, BybitJson.Web.AuthenticationRequest),
				PingRequest pingRequest => JsonSerializer.Serialize(pingRequest, BybitJson.Web.PingRequest),
				SubscribeRequest subscribeRequest => JsonSerializer.Serialize(subscribeRequest, BybitJson.Web.SubscribeRequest),
				UnsubscribeRequest unsubscribeRequest => JsonSerializer.Serialize(unsubscribeRequest, BybitJson.Web.UnsubscribeRequest),
				_ => JsonSerializer.Serialize(request, JsonSerializerOptions.Web)
			};

			_client.Send(serialized);
		}
		catch (Exception e)
		{
			_logger.LogError(e, LogMessage($"Exception while sending message '{request}'. Error: {e.Message}"));
			throw;
		}
	}

	void HandleMessage(ResponseMessage message)
	{
		try
		{
			var messageSafe = (message.Text ?? string.Empty).Trim();

			if (messageSafe.StartsWith("{", StringComparison.OrdinalIgnoreCase))
				if (HandleObjectMessage(messageSafe))
					return;

			_logger.LogWarning(LogMessage($"Unhandled response:  '{messageSafe}'"));
		}
		catch (Exception e)
		{
			_logger.LogError(e, LogMessage("Exception while receiving message"));
		}
	}

	string LogMessage(string message) => $"[{_client.Name ?? "BYBIT " + Type} WEBSOCKET CLIENT] {message}";

	/// <summary>
	/// Tries to deserialize the message and push it into the stream.
	/// </summary>
	/// <typeparam name="TResponse">The type of response.</typeparam>
	/// <param name="message">The message to handle.</param>
	/// <param name="typeInfo">The type information for deserialization.</param>
	/// <param name="subject">The stream subject.</param>
	/// <returns></returns>
	protected static bool TryHandle<TResponse>(string message, JsonTypeInfo<TResponse> typeInfo, ISubject<TResponse> subject)
	{
		TResponse? value;
		try
		{
			value = JsonSerializer.Deserialize(message, typeInfo);
		}
		catch (Exception exception)
		{
			throw new($"Failed to deserialize JSON: {message}", exception);
		}

		if (value == null)
			return false;

		subject.OnNext(value);
		return true;
	}

	/// <summary>
	/// Handles the message and publishes new stream elements.
	/// </summary>
	/// <param name="message">The message to handle.</param>
	/// <returns>A boolean value to signify whether the message could be handled.</returns>
	protected abstract bool HandleObjectMessage(string message);

	/// <summary>
	/// Cleanup.
	/// </summary>
	public void Dispose() => _clientMessageReceivedSubscription.Dispose();
}
