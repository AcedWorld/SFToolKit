using System;
using UnityEngine;

namespace Cinemachine
{
	// Token: 0x02000031 RID: 49
	internal class BlendSourceVirtualCamera : ICinemachineCamera
	{
		// Token: 0x06000248 RID: 584 RVA: 0x00011714 File Offset: 0x0000F914
		public BlendSourceVirtualCamera(CinemachineBlend blend)
		{
			this.Blend = blend;
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000249 RID: 585 RVA: 0x00011723 File Offset: 0x0000F923
		// (set) Token: 0x0600024A RID: 586 RVA: 0x0001172B File Offset: 0x0000F92B
		public CinemachineBlend Blend { get; set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600024B RID: 587 RVA: 0x00011734 File Offset: 0x0000F934
		public string Name
		{
			get
			{
				return "Mid-blend";
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x0600024C RID: 588 RVA: 0x0001173B File Offset: 0x0000F93B
		public string Description
		{
			get
			{
				if (this.Blend != null)
				{
					return this.Blend.Description;
				}
				return "(null)";
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x0600024D RID: 589 RVA: 0x00011756 File Offset: 0x0000F956
		// (set) Token: 0x0600024E RID: 590 RVA: 0x0001175E File Offset: 0x0000F95E
		public int Priority { get; set; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600024F RID: 591 RVA: 0x00011767 File Offset: 0x0000F967
		// (set) Token: 0x06000250 RID: 592 RVA: 0x0001176F File Offset: 0x0000F96F
		public Transform LookAt { get; set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000251 RID: 593 RVA: 0x00011778 File Offset: 0x0000F978
		// (set) Token: 0x06000252 RID: 594 RVA: 0x00011780 File Offset: 0x0000F980
		public Transform Follow { get; set; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000253 RID: 595 RVA: 0x00011789 File Offset: 0x0000F989
		// (set) Token: 0x06000254 RID: 596 RVA: 0x00011791 File Offset: 0x0000F991
		public CameraState State { get; private set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000255 RID: 597 RVA: 0x0001179A File Offset: 0x0000F99A
		public GameObject VirtualCameraGameObject
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000256 RID: 598 RVA: 0x0001179D File Offset: 0x0000F99D
		public bool IsValid
		{
			get
			{
				return this.Blend != null && this.Blend.IsValid;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000257 RID: 599 RVA: 0x000117B4 File Offset: 0x0000F9B4
		public ICinemachineCamera ParentCamera
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06000258 RID: 600 RVA: 0x000117B7 File Offset: 0x0000F9B7
		public bool IsLiveChild(ICinemachineCamera vcam, bool dominantChildOnly = false)
		{
			return this.Blend != null && (vcam == this.Blend.CamA || vcam == this.Blend.CamB);
		}

		// Token: 0x06000259 RID: 601 RVA: 0x000117E1 File Offset: 0x0000F9E1
		public CameraState CalculateNewState(float deltaTime)
		{
			return this.State;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x000117E9 File Offset: 0x0000F9E9
		public void UpdateCameraState(Vector3 worldUp, float deltaTime)
		{
			if (this.Blend != null)
			{
				this.Blend.UpdateCameraState(worldUp, deltaTime);
				this.State = this.Blend.State;
			}
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00011811 File Offset: 0x0000FA11
		public void InternalUpdateCameraState(Vector3 worldUp, float deltaTime)
		{
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00011813 File Offset: 0x0000FA13
		public void OnTransitionFromCamera(ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime)
		{
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00011815 File Offset: 0x0000FA15
		public void OnTargetObjectWarped(Transform target, Vector3 positionDelta)
		{
		}
	}
}
