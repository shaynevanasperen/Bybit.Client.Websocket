using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bybit.Client.Websocket.Json;

sealed class BooleanIntegerConverter : JsonConverter<bool>
{
	public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
		reader.GetInt16() == 1;

	public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options) =>
		writer.WriteNumberValue(value ? 1 : 0);
}
