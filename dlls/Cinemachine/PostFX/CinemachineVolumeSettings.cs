using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace Cinemachine.PostFX
{
	// Token: 0x0200005E RID: 94
	[DocumentationSorting(DocumentationSortingAttribute.Level.UserRef)]
	[ExecuteAlways]
	[AddComponentMenu("")]
	[SaveDuringPlay]
	[DisallowMultipleComponent]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.cinemachine@2.9/manual/CinemachineVolumeSettings.html")]
	public class CinemachineVolumeSettings : CinemachineExtension
	{
		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060003AC RID: 940 RVA: 0x00016B05 File Offset: 0x00014D05
		public bool IsValid
		{
			get
			{
				return this.m_Profile != null && this.m_Profile.components.Count > 0;
			}
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00016B2C File Offset: 0x00014D2C
		public void InvalidateCachedProfile()
		{
			List<CinemachineVolumeSettings.VcamExtraState> allExtraStates = base.GetAllExtraStates<CinemachineVolumeSettings.VcamExtraState>();
			for (int i = 0; i < allExtraStates.Count; i++)
			{
				allExtraStates[i].DestroyProfileCopy();
			}
		}

		// Token: 0x060003AE RID: 942 RVA: 0x00016B5D File Offset: 0x00014D5D
		protected override void OnEnable()
		{
			base.OnEnable();
			if (this.m_FocusTracksTarget)
			{
				this.m_FocusTracking = ((base.VirtualCamera.LookAt != null) ? CinemachineVolumeSettings.FocusTrackingMode.LookAtTarget : CinemachineVolumeSettings.FocusTrackingMode.Camera);
			}
			this.m_FocusTracksTarget = false;
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00016B91 File Offset: 0x00014D91
		protected override void OnDestroy()
		{
			this.InvalidateCachedProfile();
			base.OnDestroy();
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x00016BA0 File Offset: 0x00014DA0
		protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
		{
			if (stage == CinemachineCore.Stage.Finalize)
			{
				CinemachineVolumeSettings.VcamExtraState extraState = base.GetExtraState<CinemachineVolumeSettings.VcamExtraState>(vcam);
				if (!this.IsValid)
				{
					extraState.DestroyProfileCopy();
					return;
				}
				VolumeProfile volumeProfile = this.m_Profile;
				if (this.m_FocusTracking == CinemachineVolumeSettings.FocusTrackingMode.None)
				{
					extraState.DestroyProfileCopy();
				}
				else
				{
					if (extraState.mProfileCopy == null)
					{
						extraState.CreateProfileCopy(this.m_Profile);
					}
					volumeProfile = extraState.mProfileCopy;
					DepthOfField depthOfField;
					if (volumeProfile.TryGet<DepthOfField>(out depthOfField))
					{
						float num = this.m_FocusOffset;
						if (this.m_FocusTracking == CinemachineVolumeSettings.FocusTrackingMode.LookAtTarget)
						{
							num += (state.FinalPosition - state.ReferenceLookAt).magnitude;
						}
						else
						{
							Transform transform = null;
							CinemachineVolumeSettings.FocusTrackingMode focusTracking = this.m_FocusTracking;
							if (focusTracking != CinemachineVolumeSettings.FocusTrackingMode.FollowTarget)
							{
								if (focusTracking == CinemachineVolumeSettings.FocusTrackingMode.CustomTarget)
								{
									transform = this.m_FocusTarget;
								}
							}
							else
							{
								transform = base.VirtualCamera.Follow;
							}
							if (transform != null)
							{
								num += (state.FinalPosition - transform.position).magnitude;
							}
						}
						state.Lens.FocusDistance = (depthOfField.focusDistance.value = Mathf.Max(0f, num));
						volumeProfile.isDirty = true;
					}
				}
				state.AddCustomBlendable(new CameraState.CustomBlendable(volumeProfile, 1f));
			}
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00016CD8 File Offset: 0x00014ED8
		private static void OnCameraCut(CinemachineBrain brain)
		{
			Camera outputCamera = brain.OutputCamera;
			if (outputCamera != null)
			{
				HDCamera orCreate = HDCamera.GetOrCreate(outputCamera, 0);
				orCreate.volumetricHistoryIsValid = false;
				orCreate.colorPyramidHistoryIsValid = false;
				orCreate.Reset();
			}
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x00016D10 File Offset: 0x00014F10
		private static void ApplyPostFX(CinemachineBrain brain)
		{
			CameraState currentCameraState = brain.CurrentCameraState;
			int numCustomBlendables = currentCameraState.NumCustomBlendables;
			List<Volume> dynamicBrainVolumes = CinemachineVolumeSettings.GetDynamicBrainVolumes(brain, numCustomBlendables);
			for (int i = 0; i < dynamicBrainVolumes.Count; i++)
			{
				dynamicBrainVolumes[i].weight = 0f;
				dynamicBrainVolumes[i].sharedProfile = null;
				dynamicBrainVolumes[i].profile = null;
			}
			Volume x = null;
			int num = 0;
			for (int j = 0; j < numCustomBlendables; j++)
			{
				CameraState.CustomBlendable customBlendable = currentCameraState.GetCustomBlendable(j);
				VolumeProfile volumeProfile = customBlendable.m_Custom as VolumeProfile;
				if (!(volumeProfile == null))
				{
					Volume volume = dynamicBrainVolumes[j];
					if (x == null)
					{
						x = volume;
					}
					volume.sharedProfile = volumeProfile;
					volume.isGlobal = true;
					volume.priority = CinemachineVolumeSettings.s_VolumePriority - (float)(numCustomBlendables - j) - 1f;
					volume.weight = customBlendable.m_Weight;
					num++;
				}
			}
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x00016E08 File Offset: 0x00015008
		private static List<Volume> GetDynamicBrainVolumes(CinemachineBrain brain, int minVolumes)
		{
			GameObject gameObject = null;
			Transform transform = brain.transform;
			int childCount = transform.childCount;
			CinemachineVolumeSettings.sVolumes.Clear();
			int num = 0;
			while (gameObject == null && num < childCount)
			{
				GameObject gameObject2 = transform.GetChild(num).gameObject;
				if (gameObject2.hideFlags == HideFlags.HideAndDontSave)
				{
					gameObject2.GetComponents<Volume>(CinemachineVolumeSettings.sVolumes);
					if (CinemachineVolumeSettings.sVolumes.Count > 0)
					{
						gameObject = gameObject2;
					}
				}
				num++;
			}
			if (minVolumes > 0)
			{
				if (gameObject == null)
				{
					gameObject = new GameObject(CinemachineVolumeSettings.sVolumeOwnerName);
					gameObject.hideFlags = HideFlags.HideAndDontSave;
					gameObject.transform.parent = transform;
				}
				HDAdditionalCameraData component = brain.gameObject.GetComponent<HDAdditionalCameraData>();
				if (component != null)
				{
					int num2 = component.volumeLayerMask;
					for (int i = 0; i < 32; i++)
					{
						if ((num2 & 1 << i) != 0)
						{
							gameObject.layer = i;
							break;
						}
					}
				}
				while (CinemachineVolumeSettings.sVolumes.Count < minVolumes)
				{
					CinemachineVolumeSettings.sVolumes.Add(gameObject.gameObject.AddComponent<Volume>());
				}
			}
			return CinemachineVolumeSettings.sVolumes;
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x00016F20 File Offset: 0x00015120
		[RuntimeInitializeOnLoadMethod]
		private static void InitializeModule()
		{
			CinemachineCore.CameraUpdatedEvent.RemoveListener(new UnityAction<CinemachineBrain>(CinemachineVolumeSettings.ApplyPostFX));
			CinemachineCore.CameraUpdatedEvent.AddListener(new UnityAction<CinemachineBrain>(CinemachineVolumeSettings.ApplyPostFX));
			CinemachineCore.CameraCutEvent.RemoveListener(new UnityAction<CinemachineBrain>(CinemachineVolumeSettings.OnCameraCut));
			CinemachineCore.CameraCutEvent.AddListener(new UnityAction<CinemachineBrain>(CinemachineVolumeSettings.OnCameraCut));
		}

		// Token: 0x04000284 RID: 644
		public static float s_VolumePriority = 1000f;

		// Token: 0x04000285 RID: 645
		[HideInInspector]
		public bool m_FocusTracksTarget;

		// Token: 0x04000286 RID: 646
		[Tooltip("If the profile has the appropriate overrides, will set the base focus distance to be the distance from the selected target to the camera.The Focus Offset field will then modify that distance.")]
		public CinemachineVolumeSettings.FocusTrackingMode m_FocusTracking;

		// Token: 0x04000287 RID: 647
		[Tooltip("The target to use if Focus Tracks Target is set to Custom Target")]
		public Transform m_FocusTarget;

		// Token: 0x04000288 RID: 648
		[Tooltip("Offset from target distance, to be used with Focus Tracks Target.  Offsets the sharpest point away from the focus target.")]
		public float m_FocusOffset;

		// Token: 0x04000289 RID: 649
		[Tooltip("This profile will be applied whenever this virtual camera is live")]
		public VolumeProfile m_Profile;

		// Token: 0x0400028A RID: 650
		private static string sVolumeOwnerName = "__CMVolumes";

		// Token: 0x0400028B RID: 651
		private static List<Volume> sVolumes = new List<Volume>();

		// Token: 0x020000E5 RID: 229
		public enum FocusTrackingMode
		{
			// Token: 0x04000497 RID: 1175
			None,
			// Token: 0x04000498 RID: 1176
			LookAtTarget,
			// Token: 0x04000499 RID: 1177
			FollowTarget,
			// Token: 0x0400049A RID: 1178
			CustomTarget,
			// Token: 0x0400049B RID: 1179
			Camera
		}

		// Token: 0x020000E6 RID: 230
		private class VcamExtraState
		{
			// Token: 0x0600056B RID: 1387 RVA: 0x00023734 File Offset: 0x00021934
			public void CreateProfileCopy(VolumeProfile source)
			{
				this.DestroyProfileCopy();
				VolumeProfile volumeProfile = ScriptableObject.CreateInstance<VolumeProfile>();
				if (source != null)
				{
					foreach (VolumeComponent original in source.components)
					{
						VolumeComponent item = Object.Instantiate<VolumeComponent>(original);
						volumeProfile.components.Add(item);
						volumeProfile.isDirty = true;
					}
				}
				this.mProfileCopy = volumeProfile;
			}

			// Token: 0x0600056C RID: 1388 RVA: 0x000237B4 File Offset: 0x000219B4
			public void DestroyProfileCopy()
			{
				if (this.mProfileCopy != null)
				{
					RuntimeUtility.DestroyObject(this.mProfileCopy);
				}
				this.mProfileCopy = null;
			}

			// Token: 0x0400049C RID: 1180
			public VolumeProfile mProfileCopy;
		}
	}
}
