using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000174 RID: 372
	public class RagdollUtilityDemo : MonoBehaviour
	{
		// Token: 0x06000AD1 RID: 2769 RVA: 0x0004531A File Offset: 0x0004351A
		private void OnGUI()
		{
			GUILayout.Label(" Press R to switch to ragdoll. \n Weigh in one of the FBBIK effectors to make kinematic changes to the ragdoll pose.\n A to blend back to animation", Array.Empty<GUILayoutOption>());
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x0004532C File Offset: 0x0004352C
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				this.ragdollUtility.EnableRagdoll();
			}
			if (Input.GetKeyDown(KeyCode.A))
			{
				Vector3 b = this.pelvis.position - this.root.position;
				this.root.position += b;
				this.pelvis.transform.position -= b;
				this.ragdollUtility.DisableRagdoll();
			}
		}

		// Token: 0x04000AAD RID: 2733
		public RagdollUtility ragdollUtility;

		// Token: 0x04000AAE RID: 2734
		public Transform root;

		// Token: 0x04000AAF RID: 2735
		public Rigidbody pelvis;
	}
}
