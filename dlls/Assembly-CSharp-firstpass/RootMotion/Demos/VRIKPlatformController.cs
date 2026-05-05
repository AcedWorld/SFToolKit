using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200018C RID: 396
	public class VRIKPlatformController : MonoBehaviour
	{
		// Token: 0x06000B2B RID: 2859 RVA: 0x00046C94 File Offset: 0x00044E94
		private void LateUpdate()
		{
			if (this.platform != this.lastPlatform)
			{
				if (this.platform != null)
				{
					if (this.moveToPlatform)
					{
						this.lastPosition = this.ik.transform.position;
						this.lastRotation = this.ik.transform.rotation;
						this.ik.transform.position = this.platform.position;
						this.ik.transform.rotation = this.platform.rotation;
						this.trackingSpace.position = this.platform.position;
						this.trackingSpace.rotation = this.platform.rotation;
						this.ik.solver.AddPlatformMotion(this.platform.position - this.lastPosition, this.platform.rotation * Quaternion.Inverse(this.lastRotation), this.platform.position);
					}
					this.lastPosition = this.platform.position;
					this.lastRotation = this.platform.rotation;
				}
				this.ik.transform.parent = this.platform;
				this.trackingSpace.parent = this.platform;
				this.lastPlatform = this.platform;
			}
			if (this.platform != null)
			{
				this.ik.solver.AddPlatformMotion(this.platform.position - this.lastPosition, this.platform.rotation * Quaternion.Inverse(this.lastRotation), this.platform.position);
				this.lastRotation = this.platform.rotation;
				this.lastPosition = this.platform.position;
			}
		}

		// Token: 0x04000B24 RID: 2852
		public VRIK ik;

		// Token: 0x04000B25 RID: 2853
		public Transform trackingSpace;

		// Token: 0x04000B26 RID: 2854
		public Transform platform;

		// Token: 0x04000B27 RID: 2855
		public bool moveToPlatform = true;

		// Token: 0x04000B28 RID: 2856
		private Transform lastPlatform;

		// Token: 0x04000B29 RID: 2857
		private Vector3 lastPosition;

		// Token: 0x04000B2A RID: 2858
		private Quaternion lastRotation = Quaternion.identity;
	}
}
