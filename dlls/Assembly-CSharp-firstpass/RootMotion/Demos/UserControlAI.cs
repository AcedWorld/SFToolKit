using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001C3 RID: 451
	public class UserControlAI : UserControlThirdPerson
	{
		// Token: 0x06000C18 RID: 3096 RVA: 0x0004B4DA File Offset: 0x000496DA
		protected override void Start()
		{
			base.Start();
			this.navigator.Initiate(base.transform);
		}

		// Token: 0x06000C19 RID: 3097 RVA: 0x0004B4F4 File Offset: 0x000496F4
		protected override void Update()
		{
			float d = this.walkByDefault ? 0.5f : 1f;
			if (this.navigator.activeTargetSeeking)
			{
				this.navigator.Update(this.moveTarget.position);
				this.state.move = this.navigator.normalizedDeltaPosition * d;
				return;
			}
			Vector3 a = this.moveTarget.position - base.transform.position;
			float magnitude = a.magnitude;
			Vector3 up = base.transform.up;
			Vector3.OrthoNormalize(ref up, ref a);
			float num = (this.state.move != Vector3.zero) ? this.stoppingDistance : (this.stoppingDistance * this.stoppingThreshold);
			this.state.move = ((magnitude > num) ? (a * d) : Vector3.zero);
			this.state.lookPos = this.moveTarget.position;
		}

		// Token: 0x06000C1A RID: 3098 RVA: 0x0004B5F1 File Offset: 0x000497F1
		private void OnDrawGizmos()
		{
			if (this.navigator.activeTargetSeeking)
			{
				this.navigator.Visualize();
			}
		}

		// Token: 0x04000C72 RID: 3186
		public Transform moveTarget;

		// Token: 0x04000C73 RID: 3187
		public float stoppingDistance = 0.5f;

		// Token: 0x04000C74 RID: 3188
		public float stoppingThreshold = 1.5f;

		// Token: 0x04000C75 RID: 3189
		public Navigator navigator;
	}
}
