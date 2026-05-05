using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000159 RID: 345
	public class CharacterController3rdPerson : MonoBehaviour
	{
		// Token: 0x06000A6D RID: 2669 RVA: 0x000424F3 File Offset: 0x000406F3
		private void Start()
		{
			this.animatorController = base.GetComponent<AnimatorController3rdPerson>();
			this.cam.enabled = false;
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x00042510 File Offset: 0x00040710
		private void LateUpdate()
		{
			this.cam.UpdateInput();
			this.cam.UpdateTransform();
			Vector3 inputVector = CharacterController3rdPerson.inputVector;
			bool isMoving = CharacterController3rdPerson.inputVector != Vector3.zero || CharacterController3rdPerson.inputVectorRaw != Vector3.zero;
			Vector3 forward = this.cam.transform.forward;
			Vector3 aimTarget = this.cam.transform.position + forward * 10f;
			this.animatorController.Move(inputVector, isMoving, forward, aimTarget);
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000A6F RID: 2671 RVA: 0x00041155 File Offset: 0x0003F355
		private static Vector3 inputVector
		{
			get
			{
				return new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000A70 RID: 2672 RVA: 0x0004259E File Offset: 0x0004079E
		private static Vector3 inputVectorRaw
		{
			get
			{
				return new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
			}
		}

		// Token: 0x04000A06 RID: 2566
		public CameraController cam;

		// Token: 0x04000A07 RID: 2567
		private AnimatorController3rdPerson animatorController;
	}
}
