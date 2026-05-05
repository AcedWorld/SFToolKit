using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000163 RID: 355
	public class HitReactionTrigger : MonoBehaviour
	{
		// Token: 0x06000A94 RID: 2708 RVA: 0x0004387C File Offset: 0x00041A7C
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

		// Token: 0x06000A95 RID: 2709 RVA: 0x000438F5 File Offset: 0x00041AF5
		private void OnGUI()
		{
			GUILayout.Label("LMB to shoot the Dummy, RMB to rotate the camera.", Array.Empty<GUILayoutOption>());
			if (this.colliderName != string.Empty)
			{
				GUILayout.Label("Last Bone Hit: " + this.colliderName, Array.Empty<GUILayoutOption>());
			}
		}

		// Token: 0x04000A4B RID: 2635
		public HitReaction hitReaction;

		// Token: 0x04000A4C RID: 2636
		public float hitForce = 1f;

		// Token: 0x04000A4D RID: 2637
		private string colliderName;
	}
}
