using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x0200003E RID: 62
	internal class BaseJwt
	{
		// Token: 0x06000180 RID: 384 RVA: 0x00005204 File Offset: 0x00003404
		[Preserve]
		public BaseJwt()
		{
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000181 RID: 385 RVA: 0x0000520C File Offset: 0x0000340C
		[JsonIgnore]
		public DateTime? ExpirationTime
		{
			get
			{
				return this.ConvertTimestamp(this.ExpirationTimeUnix);
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000182 RID: 386 RVA: 0x0000521A File Offset: 0x0000341A
		[JsonIgnore]
		public DateTime? IssuedAtTime
		{
			get
			{
				return this.ConvertTimestamp(this.IssuedAtTimeUnix);
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000183 RID: 387 RVA: 0x00005228 File Offset: 0x00003428
		[JsonIgnore]
		public DateTime? NotBeforeTime
		{
			get
			{
				return this.ConvertTimestamp(this.NotBeforeTimeUnix);
			}
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00005238 File Offset: 0x00003438
		protected DateTime? ConvertTimestamp(int timestamp)
		{
			if (timestamp != 0)
			{
				return new DateTime?(DateTimeOffset.FromUnixTimeSeconds((long)timestamp).DateTime);
			}
			return null;
		}

		// Token: 0x040000C1 RID: 193
		[JsonProperty("exp")]
		public int ExpirationTimeUnix;

		// Token: 0x040000C2 RID: 194
		[JsonProperty("iat")]
		public int IssuedAtTimeUnix;

		// Token: 0x040000C3 RID: 195
		[JsonProperty("nbf")]
		public int NotBeforeTimeUnix;
	}
}
