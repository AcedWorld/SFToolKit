using System;
using UnityEngine;

namespace Unity.Networking.Transport
{
	// Token: 0x02000044 RID: 68
	public struct NetworkDataStreamParameter : INetworkParameter
	{
		// Token: 0x0600017D RID: 381 RVA: 0x000086F8 File Offset: 0x000068F8
		public bool Validate()
		{
			bool result = true;
			if (this.size < 0)
			{
				result = false;
				Debug.LogError(string.Format("{0} value ({1}) must be greater or equal to 0", "size", this.size));
			}
			return result;
		}

		// Token: 0x040000E9 RID: 233
		internal const int k_DefaultSize = 0;

		// Token: 0x040000EA RID: 234
		public int size;
	}
}
