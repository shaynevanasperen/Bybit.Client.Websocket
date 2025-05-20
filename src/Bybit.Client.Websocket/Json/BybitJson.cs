using System.Text.Json;
using System.Text.Json.Serialization;
using Bybit.Client.Websocket.Requests;
using Bybit.Client.Websocket.Responses;

namespace Bybit.Client.Websocket.Json;

[JsonSourceGenerationOptions(IgnoreReadOnlyProperties = true)]
[JsonSerializable(typeof(AuthenticationRequest))]
[JsonSerializable(typeof(AuthenticationResponse))]
[JsonSerializable(typeof(PingRequest))]
[JsonSerializable(typeof(SubscribeRequest))]
[JsonSerializable(typeof(UnsubscribeRequest))]
[JsonSerializable(typeof(OrderBookSnapshotResponse))]
[JsonSerializable(typeof(OrderBookDeltaResponse))]
[JsonSerializable(typeof(PrivatePongResponse))]
[JsonSerializable(typeof(PublicPongResponse))]
[JsonSerializable(typeof(PublicSubscriptionResponse))]
[JsonSerializable(typeof(PrivateSubscriptionResponse))]
[JsonSerializable(typeof(PublicTradeResponse))]
[JsonSerializable(typeof(ExecutionResponse))]
[JsonSerializable(typeof(WalletResponse))]
partial class BybitJson : JsonSerializerContext
{
	static BybitJson? _web;

	public static BybitJson Web => _web ??= new(new(JsonSerializerDefaults.Web) { PropertyNameCaseInsensitive = false });
}
