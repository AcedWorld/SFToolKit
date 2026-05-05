using System;
using UnityEngine;

namespace Unity.Networking.Transport.Utilities
{
	// Token: 0x020000AB RID: 171
	public struct FragmentationUtility
	{
		// Token: 0x020000AC RID: 172
		public struct Parameters : INetworkParameter
		{
			// Token: 0x060002B3 RID: 691 RVA: 0x0000F8B8 File Offset: 0x0000DAB8
			public bool Validate()
			{
				bool result = true;
				if (this.PayloadCapacity <= 0)
				{
					result = false;
					Debug.LogError(string.Format("{0} value ({1}) must be greater than 0", "PayloadCapacity", this.PayloadCapacity));
				}
				return result;
			}

			// Token: 0x04000245 RID: 581
			internal const int k_DefaultPayloadCapacity = 4096;

			// Token: 0x04000246 RID: 582
			public int PayloadCapacity;
		}
	}
}
