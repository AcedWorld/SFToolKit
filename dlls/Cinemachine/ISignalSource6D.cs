using System;
using UnityEngine;

namespace Cinemachine
{
	// Token: 0x0200004B RID: 75
	public interface ISignalSource6D
	{
		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600034A RID: 842
		float SignalDuration { get; }

		// Token: 0x0600034B RID: 843
		void GetSignal(float timeSinceSignalStart, out Vector3 pos, out Quaternion rot);
	}
}
