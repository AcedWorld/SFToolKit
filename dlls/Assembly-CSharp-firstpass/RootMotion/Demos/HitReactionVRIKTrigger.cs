using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000185 RID: 389
	public class HitReactionVRIKTrigger : MonoBehaviour
	{
		// Token: 0x06000B19 RID: 2841 RVA: 0x0004658C File Offset: 0x0004478C
		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit raycastHit = default(RaycastHit);
				if (Physics.Raycast(ray, out raycastHit, 100f))
				{
					this.hitReaction.Hit(raycastHit.collider, ray.direction * this.hitForce, raycastHit.point);
					this.colliderName = raycastHit.collider.name;
				}
			}
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x00046605 File Offset: 0x00044805
		private void OnGUI()
		{
			GUILayout.Label("LMB to shoot the Dummy, RMB to rotate the camera.", Array.Empty<GUILayoutOption>());
			if (this.colliderName != string.Empty)
			{
				GUILayout.Label("Last Bone Hit: " + this.colliderName, Array.Empty<GUILayoutOption>());
			}
		}

		// Token: 0x04000AFC RID: 2812
		public HitReactionVRIK hitReaction;

		// Token: 0x04000AFD RID: 2813
		public float hitForce = 1f;

		// Token: 0x04000AFE RID: 2814
		private string colliderName;
	}
}
