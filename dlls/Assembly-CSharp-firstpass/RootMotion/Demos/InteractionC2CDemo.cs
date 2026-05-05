using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000165 RID: 357
	public class InteractionC2CDemo : MonoBehaviour
	{
		// Token: 0x06000A9A RID: 2714 RVA: 0x00043B28 File Offset: 0x00041D28
		private void OnGUI()
		{
			if (GUILayout.Button("Shake Hands", Array.Empty<GUILayoutOption>()))
			{
				this.character1.StartInteraction(FullBodyBipedEffector.RightHand, this.handShake, true);
				this.character2.StartInteraction(FullBodyBipedEffector.RightHand, this.handShake, true);
			}
		}

		// Token: 0x06000A9B RID: 2715 RVA: 0x00043B64 File Offset: 0x00041D64
		private void LateUpdate()
		{
			Vector3 position = Vector3.Lerp(this.character1.ik.solver.rightHandEffector.bone.position, this.character2.ik.solver.rightHandEffector.bone.position, 0.5f);
			this.handShake.transform.position = position;
		}

		// Token: 0x04000A56 RID: 2646
		public InteractionSystem character1;

		// Token: 0x04000A57 RID: 2647
		public InteractionSystem character2;

		// Token: 0x04000A58 RID: 2648
		public InteractionObject handShake;
	}
}
