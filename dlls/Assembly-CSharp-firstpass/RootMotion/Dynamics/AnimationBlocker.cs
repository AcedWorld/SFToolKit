using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000038 RID: 56
	public class AnimationBlocker : MonoBehaviour
	{
		// Token: 0x0600015C RID: 348 RVA: 0x000088C2 File Offset: 0x00006AC2
		private void LateUpdate()
		{
			base.transform.localPosition = Vector3.zero;
			base.transform.localRotation = Quaternion.identity;
		}
	}
}
