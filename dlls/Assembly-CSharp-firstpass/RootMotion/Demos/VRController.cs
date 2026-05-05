using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000186 RID: 390
	public class VRController : MonoBehaviour
	{
		// Token: 0x06000B1C RID: 2844 RVA: 0x00046658 File Offset: 0x00044858
		private void Update()
		{
			Vector3 vector = this.GetInput();
			vector *= this.ik.solver.scale;
			bool flag = Vector3.Dot(vector, Vector3.forward) > 0f;
			float num = this.walkSpeed;
			if (Input.GetKey(KeyCode.LeftShift))
			{
				num = this.runSpeed;
				if (flag)
				{
					num *= this.runForwardSpeedMlp;
				}
			}
			else if (flag)
			{
				num *= this.walkForwardSpeedMlp;
			}
			this.smoothInput = Vector3.SmoothDamp(this.smoothInput, vector * num, ref this.smoothInputV, 0.1f);
			Vector3 forward = this.centerEyeAnchor.forward;
			forward.y = 0f;
			Quaternion rotation = Quaternion.LookRotation(forward);
			base.transform.position += rotation * this.smoothInput * Time.deltaTime;
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x0004673C File Offset: 0x0004493C
		private Vector3 GetInput()
		{
			VRController.InputMode inputMode = this.inputMode;
			if (inputMode != VRController.InputMode.Input)
			{
				if (inputMode != VRController.InputMode.WASDOnly)
				{
					return Vector3.zero;
				}
				Vector3 a = Vector3.zero;
				if (Input.GetKey(KeyCode.W))
				{
					a += Vector3.forward;
				}
				if (Input.GetKey(KeyCode.S))
				{
					a += Vector3.back;
				}
				if (Input.GetKey(KeyCode.A))
				{
					a += Vector3.left;
				}
				if (Input.GetKey(KeyCode.D))
				{
					a += Vector3.right;
				}
				return a.normalized;
			}
			else
			{
				Vector3 vector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
				if (vector.sqrMagnitude < 0.3f)
				{
					return Vector3.zero;
				}
				return vector.normalized;
			}
		}

		// Token: 0x04000AFF RID: 2815
		public VRController.InputMode inputMode;

		// Token: 0x04000B00 RID: 2816
		public VRIK ik;

		// Token: 0x04000B01 RID: 2817
		public Transform centerEyeAnchor;

		// Token: 0x04000B02 RID: 2818
		public float walkSpeed = 1f;

		// Token: 0x04000B03 RID: 2819
		public float runSpeed = 3f;

		// Token: 0x04000B04 RID: 2820
		public float walkForwardSpeedMlp = 1f;

		// Token: 0x04000B05 RID: 2821
		public float runForwardSpeedMlp = 1f;

		// Token: 0x04000B06 RID: 2822
		private Vector3 smoothInput;

		// Token: 0x04000B07 RID: 2823
		private Vector3 smoothInputV;

		// Token: 0x02000187 RID: 391
		[Serializable]
		public enum InputMode
		{
			// Token: 0x04000B09 RID: 2825
			Input,
			// Token: 0x04000B0A RID: 2826
			WASDOnly
		}
	}
}
