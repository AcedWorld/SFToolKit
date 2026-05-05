using System;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x02000016 RID: 22
	internal class DateTimeWrapper : IDateTimeWrapper
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00002F7A File Offset: 0x0000117A
		public DateTime UtcNow
		{
			get
			{
				return DateTime.UtcNow;
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00002F84 File Offset: 0x00001184
		public double SecondsSinceUnixEpoch()
		{
			return Math.Round((DateTime.UtcNow - DateTimeWrapper.k_UnixEpoch).TotalSeconds);
		}

		// Token: 0x04000048 RID: 72
		private static readonly DateTime k_UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
	}
}
