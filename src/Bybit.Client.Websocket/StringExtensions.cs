using System;
using System.Security.Cryptography;
using System.Text;

namespace Bybit.Client.Websocket;

static class StringExtensions
{
	public static string SignPayloadHmacSha256(this string key, string payload, Encoding encoding) => key.SignPayload(payload, encoding, x => new HMACSHA256(x));

	static string SignPayload(this string key, string payload, Encoding encoding, Func<byte[], HashAlgorithm> createHashAlgorithm)
	{
		var bytes = encoding.GetBytes(payload);

		using var hashAlgorithm = createHashAlgorithm(encoding.GetBytes(key));
		var hash = hashAlgorithm.ComputeHash(bytes);

		return ToHexStringLower(hash).Replace("-", string.Empty, StringComparison.InvariantCulture).ToLowerInvariant();
	}

	static string ToHexStringLower(byte[] bytes)
	{
		var sb = new StringBuilder(bytes.Length * 2);
		foreach (var b in bytes)
		{
			sb.Append(b.ToString("x2")); // lowercase hex
		}
		return sb.ToString();
	}
}
