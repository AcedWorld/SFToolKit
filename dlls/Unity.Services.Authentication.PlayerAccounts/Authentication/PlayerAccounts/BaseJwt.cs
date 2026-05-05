using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x02000008 RID: 8
	public class BaseJwt
	{
		// Token: 0x06000015 RID: 21 RVA: 0x00002264 File Offset: 0x00000464
		[Preserve]
		internal BaseJwt()
		{
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000016 RID: 22 RVA: 0x0000226C File Offset: 0x0000046C
		[JsonIgnore]
		public DateTime ExpirationTime
		{
			get
			{
				return this.ConvertTimestamp(this.ExpirationTimeUnix);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000017 RID: 23 RVA: 0x0000227A File Offset: 0x0000047A
		[JsonIgnore]
		public DateTime IssuedAtTime
		{
			get
			{
				return this.ConvertTimestamp(this.IssuedAtTimeUnix);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002288 File Offset: 0x00000488
		[JsonIgnore]
		public DateTime NotBeforeTime
		{
			get
			{
				return this.ConvertTimestamp(this.NotBeforeTimeUnix);
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002298 File Offset: 0x00000498
		internal DateTime ConvertTimestamp(int timestamp)
		{
			if (timestamp != 0)
			{
				return DateTimeOffset.FromUnixTimeSeconds((long)timestamp).DateTime;
			}
			throw new Exception("Token does not contain a value for this timestamp.");
		}

		// Token: 0x0400000C RID: 12
		[JsonProperty("exp")]
		public int ExpirationTimeUnix;

		// Token: 0x0400000D RID: 13
		[JsonProperty("iat")]
		public int IssuedAtTimeUnix;

		// Token: 0x0400000E RID: 14
		[JsonProperty("nbf")]
		public int NotBeforeTimeUnix;
	}
}
