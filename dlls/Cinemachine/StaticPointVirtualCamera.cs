using System;
using UnityEngine;

namespace Cinemachine
{
	// Token: 0x02000030 RID: 48
	internal class StaticPointVirtualCamera : ICinemachineCamera
	{
		// Token: 0x06000233 RID: 563 RVA: 0x00011685 File Offset: 0x0000F885
		public StaticPointVirtualCamera(CameraState state, string name)
		{
			this.State = state;
			this.Name = name;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0001169B File Offset: 0x0000F89B
		public void SetState(CameraState state)
		{
			this.State = state;
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000235 RID: 565 RVA: 0x000116A4 File Offset: 0x0000F8A4
		// (set) Token: 0x06000236 RID: 566 RVA: 0x000116AC File Offset: 0x0000F8AC
		public string Name { get; private set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000237 RID: 567 RVA: 0x000116B5 File Offset: 0x0000F8B5
		public string Description
		{
			get
			{
				return "";
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000238 RID: 568 RVA: 0x000116BC File Offset: 0x0000F8BC
		// (set) Token: 0x06000239 RID: 569 RVA: 0x000116C4 File Offset: 0x0000F8C4
		public int Priority { get; set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600023A RID: 570 RVA: 0x000116CD File Offset: 0x0000F8CD
		// (set) Token: 0x0600023B RID: 571 RVA: 0x000116D5 File Offset: 0x0000F8D5
		public Transform LookAt { get; set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x0600023C RID: 572 RVA: 0x000116DE File Offset: 0x0000F8DE
		// (set) Token: 0x0600023D RID: 573 RVA: 0x000116E6 File Offset: 0x0000F8E6
		public Transform Follow { get; set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600023E RID: 574 RVA: 0x000116EF File Offset: 0x0000F8EF
		// (set) Token: 0x0600023F RID: 575 RVA: 0x000116F7 File Offset: 0x0000F8F7
		public CameraState State { get; private set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000240 RID: 576 RVA: 0x00011700 File Offset: 0x0000F900
		public GameObject VirtualCameraGameObject
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000241 RID: 577 RVA: 0x00011703 File Offset: 0x0000F903
		public bool IsValid
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000242 RID: 578 RVA: 0x00011706 File Offset: 0x0000F906
		public ICinemachineCamera ParentCamera
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00011709 File Offset: 0x0000F909
		public bool IsLiveChild(ICinemachineCamera vcam, bool dominantChildOnly = false)
		{
			return false;
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0001170C File Offset: 0x0000F90C
		public void UpdateCameraState(Vector3 worldUp, float deltaTime)
		{
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0001170E File Offset: 0x0000F90E
		public void InternalUpdateCameraState(Vector3 worldUp, float deltaTime)
		{
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00011710 File Offset: 0x0000F910
		public void OnTransitionFromCamera(ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime)
		{
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00011712 File Offset: 0x0000F912
		public void OnTargetObjectWarped(Transform target, Vector3 positionDelta)
		{
		}
	}
}
