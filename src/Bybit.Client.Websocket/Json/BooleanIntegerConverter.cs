using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bybit.Client.Websocket.Json;

sealed class BooleanStringConverter : JsonConverter<bool>
{
	public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
		int.Parse(reader.GetString()!) == 1;

	public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options) =>
		writer.WriteStringValue(value ? "1" : "0");
}
