using System;
using UnityEngine;

namespace Unity.Networking.Transport
{
	// Token: 0x02000054 RID: 84
	public struct NetworkPipelineParams : INetworkParameter
	{
		// Token: 0x060001A0 RID: 416 RVA: 0x00008CC8 File Offset: 0x00006EC8
		public bool Validate()
		{
			bool result = true;
			if (this.initialCapacity < 0)
			{
				result = false;
				Debug.LogError(string.Format("{0} value ({1}) must be greater or equal to 0", "initialCapacity", this.initialCapacity));
			}
			return result;
		}

		// Token: 0x04000116 RID: 278
		internal const int k_DefaultInitialCapacity = 0;

		// Token: 0x04000117 RID: 279
		public int initialCapacity;
	}
}
