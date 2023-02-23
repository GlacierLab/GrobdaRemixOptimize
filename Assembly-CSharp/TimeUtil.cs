using System;

// Token: 0x020000D7 RID: 215
public class TimeUtil
{
	// Token: 0x060004B5 RID: 1205 RVA: 0x0000FE04 File Offset: 0x0000E204
	public static long DateTimeToUnixTimestamp(DateTime dateTime)
	{
		DateTime dateTime2 = new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
		return Convert.ToInt64((dateTime - dateTime2).TotalSeconds);
	}

	// Token: 0x060004B6 RID: 1206 RVA: 0x0000FE40 File Offset: 0x0000E240
	public static DateTime UnixTimestampToDateTime(long timestamp)
	{
		DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
		long num = long.Parse(timestamp + "0000000");
		TimeSpan timeSpan = new TimeSpan(num);
		return dateTime.Add(timeSpan);
	}
}
