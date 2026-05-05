using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001C4 RID: 452
	public class UserControlThirdPerson : MonoBehaviour
	{
		// Token: 0x06000C1C RID: 3100 RVA: 0x0004B629 File Offset: 0x00049829
		protected virtual void Start()
		{
			this.cam = Camera.main.transform;
		}

		// Token: 0x06000C1D RID: 3101 RVA: 0x0004B63C File Offset: 0x0004983C
		protected virtual void Update()
		{
			this.state.crouch = (this.canCrouch && Input.GetKey(KeyCode.C));
			this.state.jump = (this.canJump && Input.GetButton("Jump"));
			float axisRaw = Input.GetAxisRaw("Horizontal");
			float axisRaw2 = Input.GetAxisRaw("Vertical");
			Vector3 vector = this.cam.rotation * new Vector3(axisRaw, 0f, axisRaw2).normalized;
			if (vector != Vector3.zero)
			{
				Vector3 up = base.transform.up;
				Vector3.OrthoNormalize(ref up, ref vector);
				this.state.move = vector;
			}
			else
			{
				this.state.move = Vector3.zero;
			}
			bool key = Input.GetKey(KeyCode.LeftShift);
			float d = this.walkByDefault ? (key ? 1f : 0.5f) : (key ? 0.5f : 1f);
			this.state.move = this.state.move * d;
			this.state.lookPos = base.transform.position + this.cam.forward * 100f;
		}

		// Token: 0x04000C76 RID: 3190
		public bool walkByDefault;

		// Token: 0x04000C77 RID: 3191
		public bool canCrouch = true;

		// Token: 0x04000C78 RID: 3192
		public bool canJump = true;

		// Token: 0x04000C79 RID: 3193
		public UserControlThirdPerson.State state;

		// Token: 0x04000C7A RID: 3194
		protected Transform cam;

		// Token: 0x020001C5 RID: 453
		public struct State
		{
			// Token: 0x04000C7B RID: 3195
			public Vector3 move;

			// Token: 0x04000C7C RID: 3196
			public Vector3 lookPos;

			// Token: 0x04000C7D RID: 3197
			public bool crouch;

			// Token: 0x04000C7E RID: 3198
			public bool jump;

			// Token: 0x04000C7F RID: 3199
			public int actionIndex;
		}
	}
}
