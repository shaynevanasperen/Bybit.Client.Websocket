using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bybit.Client.Websocket.Json;

sealed class NullableDoubleEmptyStringConverter : JsonConverter<double?>
{
	public override double? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var value = reader.GetString();
		return string.IsNullOrEmpty(value) ? null : double.Parse(value);
	}

	public override void Write(Utf8JsonWriter writer, double? value, JsonSerializerOptions options) =>
		writer.WriteStringValue(value == null ? string.Empty : value.Value.ToString(CultureInfo.InvariantCulture));
}
