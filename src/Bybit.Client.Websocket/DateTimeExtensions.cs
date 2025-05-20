using System;

namespace Bybit.Client.Websocket;

static class DateTimeExtensions
{
	public static long ToUnixTimeMilliseconds(this DateTime value)
	{
		var timespan = value.ToUniversalTime().Subtract(DateTime.UnixEpoch);
		return timespan.Ticks / TimeSpan.TicksPerMillisecond;
	}
}
