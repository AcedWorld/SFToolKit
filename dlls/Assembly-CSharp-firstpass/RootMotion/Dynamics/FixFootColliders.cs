using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000088 RID: 136
	public class FixFootColliders : MonoBehaviour
	{
		// Token: 0x0600044D RID: 1101 RVA: 0x0001ACFC File Offset: 0x00018EFC
		[ContextMenu("Fix")]
		public void Fix()
		{
			BipedRagdollCreator.FixFootCollider(this.leftFoot, this.root);
			BipedRagdollCreator.FixFootCollider(this.rightFoot, this.root);
		}

		// Token: 0x040003DF RID: 991
		public Transform root;

		// Token: 0x040003E0 RID: 992
		public Transform leftFoot;

		// Token: 0x040003E1 RID: 993
		public Transform rightFoot;
	}
}
