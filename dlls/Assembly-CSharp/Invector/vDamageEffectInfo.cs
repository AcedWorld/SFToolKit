using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000385 RID: 901
	public class vDamageEffectInfo
	{
		// Token: 0x0600124A RID: 4682 RVA: 0x00061202 File Offset: 0x0005F402
		public vDamageEffectInfo(Vector3 position, Quaternion rotation, string damageType = "", Transform receiver = null)
		{
			this.receiver = receiver;
			this.position = position;
			this.rotation = rotation;
			this.damageType = damageType;
		}

		// Token: 0x0400180F RID: 6159
		public Transform receiver;

		// Token: 0x04001810 RID: 6160
		public Vector3 position;

		// Token: 0x04001811 RID: 6161
		public Quaternion rotation;

		// Token: 0x04001812 RID: 6162
		public string damageType;
	}
}
