using System;
using UnityEngine;

namespace Unity.Networking.QoS
{
	// Token: 0x0200000D RID: 13
	[Serializable]
	internal struct UcgQosServer
	{
		// Token: 0x0600003F RID: 63 RVA: 0x000033A8 File Offset: 0x000015A8
		public override string ToString()
		{
			if (!string.IsNullOrEmpty(this.ipv6))
			{
				return string.Format("[{0}]:{1}, {2}, {3}", new object[]
				{
					this.ipv6,
					this.port,
					this.regionid,
					this.BackoffUntilUtc
				});
			}
			if (!string.IsNullOrEmpty(this.ipv4))
			{
				return string.Format("{0}:{1}, {2}, {3}", new object[]
				{
					this.ipv4,
					this.port,
					this.regionid,
					this.BackoffUntilUtc
				});
			}
			return "";
		}

		// Token: 0x0400003D RID: 61
		internal string regionid;

		// Token: 0x0400003E RID: 62
		internal string ipv4;

		// Token: 0x0400003F RID: 63
		internal string ipv6;

		// Token: 0x04000040 RID: 64
		internal ushort port;

		// Token: 0x04000041 RID: 65
		[HideInInspector]
		[NonSerialized]
		internal DateTime BackoffUntilUtc;
	}
}
