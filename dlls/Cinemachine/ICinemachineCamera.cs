using System;
using UnityEngine;

namespace Cinemachine
{
	// Token: 0x02000047 RID: 71
	public interface ICinemachineCamera
	{
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x0600031F RID: 799
		string Name { get; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000320 RID: 800
		string Description { get; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000321 RID: 801
		// (set) Token: 0x06000322 RID: 802
		int Priority { get; set; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000323 RID: 803
		// (set) Token: 0x06000324 RID: 804
		Transform LookAt { get; set; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000325 RID: 805
		// (set) Token: 0x06000326 RID: 806
		Transform Follow { get; set; }

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000327 RID: 807
		CameraState State { get; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000328 RID: 808
		GameObject VirtualCameraGameObject { get; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000329 RID: 809
		bool IsValid { get; }

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x0600032A RID: 810
		ICinemachineCamera ParentCamera { get; }

		// Token: 0x0600032B RID: 811
		bool IsLiveChild(ICinemachineCamera vcam, bool dominantChildOnly = false);

		// Token: 0x0600032C RID: 812
		void UpdateCameraState(Vector3 worldUp, float deltaTime);

		// Token: 0x0600032D RID: 813
		void InternalUpdateCameraState(Vector3 worldUp, float deltaTime);

		// Token: 0x0600032E RID: 814
		void OnTransitionFromCamera(ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime);

		// Token: 0x0600032F RID: 815
		void OnTargetObjectWarped(Transform target, Vector3 positionDelta);
	}
}
