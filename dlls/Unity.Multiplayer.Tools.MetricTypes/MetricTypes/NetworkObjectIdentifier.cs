using System;
using Unity.Collections;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x02000012 RID: 18
	[Serializable]
	internal struct NetworkObjectIdentifier
	{
		// Token: 0x0600002A RID: 42 RVA: 0x000024AB File Offset: 0x000006AB
		public NetworkObjectIdentifier(string name, ulong networkId)
		{
			this = new NetworkObjectIdentifier(StringConversionUtility.ConvertToFixedString(name), networkId);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000024BA File Offset: 0x000006BA
		public NetworkObjectIdentifier(FixedString64Bytes name, ulong networkId)
		{
			this.Name = name;
			this.NetworkId = networkId;
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600002C RID: 44 RVA: 0x000024CA File Offset: 0x000006CA
		public readonly FixedString64Bytes Name { get; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600002D RID: 45 RVA: 0x000024D2 File Offset: 0x000006D2
		public readonly ulong NetworkId { get; }
	}
}
