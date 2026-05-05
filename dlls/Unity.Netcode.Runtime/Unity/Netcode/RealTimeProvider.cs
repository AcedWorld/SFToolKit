using System;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x0200011F RID: 287
	internal class RealTimeProvider : IRealTimeProvider
	{
		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600091F RID: 2335 RVA: 0x00022E56 File Offset: 0x00021056
		public float RealTimeSinceStartup
		{
			get
			{
				return Time.realtimeSinceStartup;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000920 RID: 2336 RVA: 0x00022E5D File Offset: 0x0002105D
		public float UnscaledTime
		{
			get
			{
				return Time.unscaledTime;
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000921 RID: 2337 RVA: 0x00022E64 File Offset: 0x00021064
		public float UnscaledDeltaTime
		{
			get
			{
				return Time.unscaledDeltaTime;
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000922 RID: 2338 RVA: 0x00022E6B File Offset: 0x0002106B
		public float DeltaTime
		{
			get
			{
				return Time.deltaTime;
			}
		}
	}
}
