using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Invector
{
	// Token: 0x02000386 RID: 902
	[Serializable]
	public class vDamageEffect
	{
		// Token: 0x04001813 RID: 6163
		public string damageType = "";

		// Token: 0x04001814 RID: 6164
		public List<GameObject> customDamageEffect;

		// Token: 0x04001815 RID: 6165
		public bool rotateToHitDirection = true;

		// Token: 0x04001816 RID: 6166
		[Tooltip("Attach prefab in Damage Receiver transform")]
		public bool attachInReceiver;

		// Token: 0x04001817 RID: 6167
		public UnityEvent onTriggerEffect;
	}
}
