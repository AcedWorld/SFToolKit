using System;
using System.Collections.Generic;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000335 RID: 821
	[Serializable]
	public class vThirdPersonCameraState
	{
		// Token: 0x060010F1 RID: 4337 RVA: 0x0005BD68 File Offset: 0x00059F68
		public vThirdPersonCameraState(string name)
		{
			this.Name = name;
			this.forward = -1f;
			this.right = 0f;
			this.defaultDistance = 1.5f;
			this.maxDistance = 3f;
			this.minDistance = 0.5f;
			this.height = 0f;
			this.smooth = 10f;
			this.smoothDamp = 0f;
			this.xMouseSensitivity = 3f;
			this.yMouseSensitivity = 3f;
			this.yMinLimit = -40f;
			this.yMaxLimit = 80f;
			this.xMinLimit = -360f;
			this.xMaxLimit = 360f;
			this.cullingHeight = 0.2f;
			this.cullingMinDist = 0.1f;
			this.fov = 60f;
			this.useZoom = false;
			this.forward = 60f;
			this.fixedAngle = Vector2.zero;
			this.cameraMode = TPCameraMode.FreeDirectional;
		}

		// Token: 0x040016BC RID: 5820
		public string Name;

		// Token: 0x040016BD RID: 5821
		public float forward;

		// Token: 0x040016BE RID: 5822
		public float right;

		// Token: 0x040016BF RID: 5823
		public float defaultDistance;

		// Token: 0x040016C0 RID: 5824
		public float maxDistance;

		// Token: 0x040016C1 RID: 5825
		public float minDistance;

		// Token: 0x040016C2 RID: 5826
		public float height;

		// Token: 0x040016C3 RID: 5827
		public float smooth = 10f;

		// Token: 0x040016C4 RID: 5828
		public float smoothDamp;

		// Token: 0x040016C5 RID: 5829
		public float xMouseSensitivity;

		// Token: 0x040016C6 RID: 5830
		public float yMouseSensitivity;

		// Token: 0x040016C7 RID: 5831
		public float yMinLimit;

		// Token: 0x040016C8 RID: 5832
		public float yMaxLimit;

		// Token: 0x040016C9 RID: 5833
		public float xMinLimit;

		// Token: 0x040016CA RID: 5834
		public float xMaxLimit;

		// Token: 0x040016CB RID: 5835
		public Vector3 rotationOffSet;

		// Token: 0x040016CC RID: 5836
		public float cullingHeight;

		// Token: 0x040016CD RID: 5837
		public float cullingMinDist;

		// Token: 0x040016CE RID: 5838
		public float fov;

		// Token: 0x040016CF RID: 5839
		public bool useZoom;

		// Token: 0x040016D0 RID: 5840
		public Vector2 fixedAngle;

		// Token: 0x040016D1 RID: 5841
		public List<LookPoint> lookPoints;

		// Token: 0x040016D2 RID: 5842
		public TPCameraMode cameraMode;
	}
}
