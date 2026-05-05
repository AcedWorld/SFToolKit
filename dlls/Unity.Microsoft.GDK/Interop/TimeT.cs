using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001C8 RID: 456
	[MovedFrom("Unity.GameCore.Interop")]
	public struct TimeT
	{
		// Token: 0x06000AA1 RID: 2721 RVA: 0x0001007F File Offset: 0x0000E27F
		internal TimeT(long secondsSinceUnixEpoch)
		{
			this.SecondsSinceUnixEpoch = secondsSinceUnixEpoch;
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x00010088 File Offset: 0x0000E288
		public TimeT(DateTime dateTime)
		{
			if (dateTime.Kind != DateTimeKind.Utc)
			{
				throw new ArgumentException("Supplied DateTime must be UTC");
			}
			this.SecondsSinceUnixEpoch = (long)dateTime.Subtract(TimeT.UnixEpoch).TotalSeconds;
		}

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x06000AA3 RID: 2723 RVA: 0x000100C8 File Offset: 0x0000E2C8
		public DateTime DateTime
		{
			get
			{
				DateTime result;
				try
				{
					if (this.SecondsSinceUnixEpoch == -1L)
					{
						result = DateTime.MaxValue;
					}
					else
					{
						result = TimeT.UnixEpoch.AddSeconds((double)this.SecondsSinceUnixEpoch);
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					result = DateTime.MaxValue;
				}
				return result;
			}
		}

		// Token: 0x040005EF RID: 1519
		private static DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		// Token: 0x040005F0 RID: 1520
		internal readonly long SecondsSinceUnixEpoch;
	}
}
