using System;
using System.Collections;
using UnityEngine;

namespace Invector.vCamera
{
	// Token: 0x02000428 RID: 1064
	public class vChangeCameraAngleTrigger : MonoBehaviour
	{
		// Token: 0x0600161A RID: 5658 RVA: 0x00075620 File Offset: 0x00073820
		private void OnDrawGizmos()
		{
			if (this.useSelfWorldAngle)
			{
				this.angle.x = base.transform.eulerAngles.y;
				this.angle.y = base.transform.eulerAngles.x;
			}
		}

		// Token: 0x0600161B RID: 5659 RVA: 0x00075660 File Offset: 0x00073860
		private IEnumerator Start()
		{
			this.tpCamera = Object.FindObjectOfType<vThirdPersonCamera>();
			Collider collider = base.GetComponent<Collider>();
			if (collider)
			{
				collider.isTrigger = true;
				collider.enabled = false;
				yield return new WaitForEndOfFrame();
				collider.enabled = true;
			}
			yield break;
		}

		// Token: 0x0600161C RID: 5660 RVA: 0x00075670 File Offset: 0x00073870
		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Player") && this.tpCamera)
			{
				if (this.applyX)
				{
					this.tpCamera.lerpState.fixedAngle.x = this.angle.x;
				}
				if (this.applyY)
				{
					this.tpCamera.lerpState.fixedAngle.y = this.angle.y;
				}
			}
		}

		// Token: 0x04001C2C RID: 7212
		public bool applyY;

		// Token: 0x04001C2D RID: 7213
		public bool applyX;

		// Token: 0x04001C2E RID: 7214
		public Vector2 angle;

		// Token: 0x04001C2F RID: 7215
		public vThirdPersonCamera tpCamera;

		// Token: 0x04001C30 RID: 7216
		public bool useSelfWorldAngle;
	}
}
