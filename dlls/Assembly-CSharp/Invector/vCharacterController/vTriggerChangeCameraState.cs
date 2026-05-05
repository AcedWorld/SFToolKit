using System;
using UnityEngine;

namespace Invector.vCharacterController
{
	// Token: 0x02000401 RID: 1025
	[vClassHeader("Trigger Change Camera State", true, "icon_v2", false, "", openClose = false)]
	public class vTriggerChangeCameraState : vMonoBehaviour
	{
		// Token: 0x060014EE RID: 5358 RVA: 0x0006CF4C File Offset: 0x0006B14C
		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				if (this.tpInput == null || this.tpInput.gameObject != other.gameObject)
				{
					this.tpInput = other.GetComponent<vThirdPersonInput>();
				}
				if (this.tpInput != null)
				{
					if (this.cameraState != string.Empty)
					{
						this.tpInput.ChangeCameraState(this.cameraState, this.smoothTransition);
					}
					else if (this.cameraState == string.Empty)
					{
						this.tpInput.ResetCameraState();
					}
					if (!string.IsNullOrEmpty(this.customCameraPoint))
					{
						this.tpInput.customlookAtPoint = this.customCameraPoint;
					}
					this.tpInput.cc.keepDirection = this.keepDirection;
				}
			}
		}

		// Token: 0x060014EF RID: 5359 RVA: 0x0006D02A File Offset: 0x0006B22A
		private void OnTriggerExit(Collider other)
		{
			if (this.resetCameraStateOnExitTrigger && other.gameObject.CompareTag("Player") && this.tpInput != null)
			{
				this.tpInput.ResetCameraState();
			}
		}

		// Token: 0x060014F0 RID: 5360 RVA: 0x0006D060 File Offset: 0x0006B260
		private void OnDrawGizmos()
		{
			Gizmos.color = this.gizmoColor;
			this.comp = base.gameObject.GetComponent<BoxCollider>();
			if (this.comp != null)
			{
				base.gameObject.GetComponent<BoxCollider>().isTrigger = true;
				base.gameObject.GetComponent<BoxCollider>().center = Vector3.zero;
				base.gameObject.GetComponent<BoxCollider>().size = Vector3.one;
			}
			Gizmos.matrix = base.transform.localToWorldMatrix;
			if (this.comp == null)
			{
				base.gameObject.AddComponent<BoxCollider>();
			}
			Gizmos.DrawCube(Vector3.zero, Vector3.one);
		}

		// Token: 0x060014F1 RID: 5361 RVA: 0x0006D10C File Offset: 0x0006B30C
		private Vector3 getLargerScale(Vector3 value)
		{
			if (value.x > value.y || value.x > value.z)
			{
				return new Vector3(value.x, value.x, value.x);
			}
			if (value.y > value.x || value.y > value.z)
			{
				return new Vector3(value.y, value.y, value.y);
			}
			if (value.z > value.y || value.z > value.x)
			{
				return new Vector3(value.z, value.z, value.z);
			}
			return base.transform.localScale;
		}

		// Token: 0x04001AAD RID: 6829
		[Tooltip("Check if you want to lerp the state transitions, you can change the lerp value on the TPCamera - Smooth Follow variable")]
		public bool smoothTransition = true;

		// Token: 0x04001AAE RID: 6830
		public bool keepDirection = true;

		// Token: 0x04001AAF RID: 6831
		[vHelpBox("Keep it empty to Reset back to Default", vHelpBoxAttribute.MessageType.None)]
		[Tooltip("Check your CameraState List and set the State here, use the same String value.\n*Leave this field empty to return the original state")]
		public string cameraState;

		// Token: 0x04001AB0 RID: 6832
		public bool resetCameraStateOnExitTrigger;

		// Token: 0x04001AB1 RID: 6833
		[Tooltip("Set a new target for the camera.\n*Leave this field empty to return the original target (Player)")]
		public string customCameraPoint;

		// Token: 0x04001AB2 RID: 6834
		public Color gizmoColor = Color.green;

		// Token: 0x04001AB3 RID: 6835
		private Component comp;

		// Token: 0x04001AB4 RID: 6836
		public vThirdPersonInput tpInput;
	}
}
