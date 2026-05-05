using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine
{
	// Token: 0x02000016 RID: 22
	[DocumentationSorting(DocumentationSortingAttribute.Level.UserRef)]
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[ExcludeFromPreset]
	[AddComponentMenu("Cinemachine/CinemachineMixingCamera")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.cinemachine@2.9/manual/CinemachineMixingCamera.html")]
	public class CinemachineMixingCamera : CinemachineVirtualCameraBase
	{
		// Token: 0x060000E1 RID: 225 RVA: 0x00008200 File Offset: 0x00006400
		public float GetWeight(int index)
		{
			switch (index)
			{
			case 0:
				return this.m_Weight0;
			case 1:
				return this.m_Weight1;
			case 2:
				return this.m_Weight2;
			case 3:
				return this.m_Weight3;
			case 4:
				return this.m_Weight4;
			case 5:
				return this.m_Weight5;
			case 6:
				return this.m_Weight6;
			case 7:
				return this.m_Weight7;
			default:
				Debug.LogError("CinemachineMixingCamera: Invalid index: " + index.ToString());
				return 0f;
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00008288 File Offset: 0x00006488
		public void SetWeight(int index, float w)
		{
			switch (index)
			{
			case 0:
				this.m_Weight0 = w;
				return;
			case 1:
				this.m_Weight1 = w;
				return;
			case 2:
				this.m_Weight2 = w;
				return;
			case 3:
				this.m_Weight3 = w;
				return;
			case 4:
				this.m_Weight4 = w;
				return;
			case 5:
				this.m_Weight5 = w;
				return;
			case 6:
				this.m_Weight6 = w;
				return;
			case 7:
				this.m_Weight7 = w;
				return;
			default:
				Debug.LogError("CinemachineMixingCamera: Invalid index: " + index.ToString());
				return;
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00008314 File Offset: 0x00006514
		public float GetWeight(CinemachineVirtualCameraBase vcam)
		{
			this.ValidateListOfChildren();
			int index;
			if (this.m_indexMap.TryGetValue(vcam, out index))
			{
				return this.GetWeight(index);
			}
			Debug.LogError("CinemachineMixingCamera: Invalid child: " + ((vcam != null) ? vcam.Name : "(null)"));
			return 0f;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000836C File Offset: 0x0000656C
		public void SetWeight(CinemachineVirtualCameraBase vcam, float w)
		{
			this.ValidateListOfChildren();
			int index;
			if (this.m_indexMap.TryGetValue(vcam, out index))
			{
				this.SetWeight(index, w);
				return;
			}
			Debug.LogError("CinemachineMixingCamera: Invalid child: " + ((vcam != null) ? vcam.Name : "(null)"));
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x000083BD File Offset: 0x000065BD
		// (set) Token: 0x060000E6 RID: 230 RVA: 0x000083C5 File Offset: 0x000065C5
		private ICinemachineCamera LiveChild { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x000083CE File Offset: 0x000065CE
		public override CameraState State
		{
			get
			{
				return this.m_State;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x000083D6 File Offset: 0x000065D6
		// (set) Token: 0x060000E9 RID: 233 RVA: 0x000083DE File Offset: 0x000065DE
		public override Transform LookAt { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000EA RID: 234 RVA: 0x000083E7 File Offset: 0x000065E7
		// (set) Token: 0x060000EB RID: 235 RVA: 0x000083EF File Offset: 0x000065EF
		public override Transform Follow { get; set; }

		// Token: 0x060000EC RID: 236 RVA: 0x000083F8 File Offset: 0x000065F8
		public override void OnTargetObjectWarped(Transform target, Vector3 positionDelta)
		{
			this.ValidateListOfChildren();
			CinemachineVirtualCameraBase[] childCameras = this.m_ChildCameras;
			for (int i = 0; i < childCameras.Length; i++)
			{
				childCameras[i].OnTargetObjectWarped(target, positionDelta);
			}
			base.OnTargetObjectWarped(target, positionDelta);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00008434 File Offset: 0x00006634
		public override void ForceCameraPosition(Vector3 pos, Quaternion rot)
		{
			this.ValidateListOfChildren();
			CinemachineVirtualCameraBase[] childCameras = this.m_ChildCameras;
			for (int i = 0; i < childCameras.Length; i++)
			{
				childCameras[i].ForceCameraPosition(pos, rot);
			}
			base.ForceCameraPosition(pos, rot);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000846E File Offset: 0x0000666E
		protected override void OnEnable()
		{
			base.OnEnable();
			this.InvalidateListOfChildren();
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000847C File Offset: 0x0000667C
		public void OnTransformChildrenChanged()
		{
			this.InvalidateListOfChildren();
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00008484 File Offset: 0x00006684
		protected override void OnValidate()
		{
			base.OnValidate();
			for (int i = 0; i < 8; i++)
			{
				this.SetWeight(i, Mathf.Max(0f, this.GetWeight(i)));
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x000084BC File Offset: 0x000066BC
		public override bool IsLiveChild(ICinemachineCamera vcam, bool dominantChildOnly = false)
		{
			CinemachineVirtualCameraBase[] childCameras = this.ChildCameras;
			int num = 0;
			while (num < 8 && num < childCameras.Length)
			{
				if (childCameras[num] == vcam)
				{
					return this.GetWeight(num) > 0.0001f && childCameras[num].isActiveAndEnabled;
				}
				num++;
			}
			return false;
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00008502 File Offset: 0x00006702
		public CinemachineVirtualCameraBase[] ChildCameras
		{
			get
			{
				this.ValidateListOfChildren();
				return this.m_ChildCameras;
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00008510 File Offset: 0x00006710
		protected void InvalidateListOfChildren()
		{
			this.m_ChildCameras = null;
			this.m_indexMap = null;
			this.LiveChild = null;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00008528 File Offset: 0x00006728
		protected void ValidateListOfChildren()
		{
			if (this.m_ChildCameras != null)
			{
				return;
			}
			this.m_indexMap = new Dictionary<CinemachineVirtualCameraBase, int>();
			List<CinemachineVirtualCameraBase> list = new List<CinemachineVirtualCameraBase>();
			foreach (CinemachineVirtualCameraBase cinemachineVirtualCameraBase in base.GetComponentsInChildren<CinemachineVirtualCameraBase>(true))
			{
				if (cinemachineVirtualCameraBase.transform.parent == base.transform)
				{
					int count = list.Count;
					list.Add(cinemachineVirtualCameraBase);
					if (count < 8)
					{
						this.m_indexMap.Add(cinemachineVirtualCameraBase, count);
					}
				}
			}
			this.m_ChildCameras = list.ToArray();
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x000085B0 File Offset: 0x000067B0
		public override void OnTransitionFromCamera(ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime)
		{
			base.OnTransitionFromCamera(fromCam, worldUp, deltaTime);
			base.InvokeOnTransitionInExtensions(fromCam, worldUp, deltaTime);
			CinemachineVirtualCameraBase[] childCameras = this.ChildCameras;
			int num = 0;
			while (num < 8 && num < childCameras.Length)
			{
				childCameras[num].OnTransitionFromCamera(fromCam, worldUp, deltaTime);
				num++;
			}
			this.InternalUpdateCameraState(worldUp, deltaTime);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x000085FC File Offset: 0x000067FC
		public override void InternalUpdateCameraState(Vector3 worldUp, float deltaTime)
		{
			CinemachineVirtualCameraBase[] childCameras = this.ChildCameras;
			this.LiveChild = null;
			float num = 0f;
			float num2 = 0f;
			int num3 = 0;
			while (num3 < 8 && num3 < childCameras.Length)
			{
				CinemachineVirtualCameraBase cinemachineVirtualCameraBase = childCameras[num3];
				if (cinemachineVirtualCameraBase.isActiveAndEnabled)
				{
					float num4 = Mathf.Max(0f, this.GetWeight(num3));
					if (num4 > 0.0001f)
					{
						num2 += num4;
						if (num2 == num4)
						{
							this.m_State = cinemachineVirtualCameraBase.State;
						}
						else
						{
							this.m_State = CameraState.Lerp(this.m_State, cinemachineVirtualCameraBase.State, num4 / num2);
						}
						if (num4 > num)
						{
							num = num4;
							this.LiveChild = cinemachineVirtualCameraBase;
						}
					}
				}
				num3++;
			}
			base.InvokePostPipelineStageCallback(this, CinemachineCore.Stage.Finalize, ref this.m_State, deltaTime);
		}

		// Token: 0x0400009E RID: 158
		public const int MaxCameras = 8;

		// Token: 0x0400009F RID: 159
		[Tooltip("The weight of the first tracked camera")]
		public float m_Weight0 = 0.5f;

		// Token: 0x040000A0 RID: 160
		[Tooltip("The weight of the second tracked camera")]
		public float m_Weight1 = 0.5f;

		// Token: 0x040000A1 RID: 161
		[Tooltip("The weight of the third tracked camera")]
		public float m_Weight2 = 0.5f;

		// Token: 0x040000A2 RID: 162
		[Tooltip("The weight of the fourth tracked camera")]
		public float m_Weight3 = 0.5f;

		// Token: 0x040000A3 RID: 163
		[Tooltip("The weight of the fifth tracked camera")]
		public float m_Weight4 = 0.5f;

		// Token: 0x040000A4 RID: 164
		[Tooltip("The weight of the sixth tracked camera")]
		public float m_Weight5 = 0.5f;

		// Token: 0x040000A5 RID: 165
		[Tooltip("The weight of the seventh tracked camera")]
		public float m_Weight6 = 0.5f;

		// Token: 0x040000A6 RID: 166
		[Tooltip("The weight of the eighth tracked camera")]
		public float m_Weight7 = 0.5f;

		// Token: 0x040000A7 RID: 167
		private CameraState m_State = CameraState.Default;

		// Token: 0x040000AB RID: 171
		private CinemachineVirtualCameraBase[] m_ChildCameras;

		// Token: 0x040000AC RID: 172
		private Dictionary<CinemachineVirtualCameraBase, int> m_indexMap;
	}
}
