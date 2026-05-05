using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001F7 RID: 503
	[ExecuteAlways]
	[AddComponentMenu("")]
	public class StaticLightingSky : MonoBehaviour
	{
		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000F3D RID: 3901 RVA: 0x00077548 File Offset: 0x00075748
		internal SkySettings skySettings
		{
			get
			{
				SkySettings skySettings;
				Type type;
				this.GetSkyFromIDAndVolume(this.m_StaticLightingSkyUniqueID, this.m_Profile, out skySettings, out type);
				if (skySettings != null)
				{
					int hashCode = skySettings.GetHashCode();
					if (this.m_LastComputedHash != hashCode)
					{
						this.UpdateCurrentStaticLightingSky();
					}
				}
				else
				{
					this.ResetSky();
				}
				return this.m_SkySettings;
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000F3E RID: 3902 RVA: 0x00077598 File Offset: 0x00075798
		internal CloudSettings cloudSettings
		{
			get
			{
				CloudSettings cloudSettings;
				Type type;
				this.GetCloudFromIDAndVolume(this.m_StaticLightingCloudsUniqueID, this.m_Profile, out cloudSettings, out type);
				if (cloudSettings != null)
				{
					int hashCode = cloudSettings.GetHashCode();
					if (this.m_LastComputedCloudHash != hashCode)
					{
						this.UpdateCurrentStaticLightingClouds();
					}
				}
				else
				{
					this.ResetCloud();
				}
				return this.m_CloudSettings;
			}
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000F3F RID: 3903 RVA: 0x000775E8 File Offset: 0x000757E8
		internal VolumetricClouds volumetricClouds
		{
			get
			{
				if (!this.m_StaticLightingVolumetricClouds)
				{
					return null;
				}
				return this.m_VolumetricClouds;
			}
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000F40 RID: 3904 RVA: 0x000775FA File Offset: 0x000757FA
		// (set) Token: 0x06000F41 RID: 3905 RVA: 0x00077604 File Offset: 0x00075804
		public VolumeProfile profile
		{
			get
			{
				return this.m_Profile;
			}
			set
			{
				if (value != this.m_Profile)
				{
					this.m_StaticLightingSkyUniqueID = 0;
					if (this.m_Profile == null)
					{
						SkyManager.RegisterStaticLightingSky(this);
					}
					if (value == null)
					{
						SkyManager.UnRegisterStaticLightingSky(this);
					}
				}
				this.m_Profile = value;
			}
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000F42 RID: 3906 RVA: 0x00077650 File Offset: 0x00075850
		// (set) Token: 0x06000F43 RID: 3907 RVA: 0x00077658 File Offset: 0x00075858
		public int staticLightingSkyUniqueID
		{
			get
			{
				return this.m_StaticLightingSkyUniqueID;
			}
			set
			{
				this.m_StaticLightingSkyUniqueID = value;
				this.UpdateCurrentStaticLightingSky();
			}
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000F44 RID: 3908 RVA: 0x00077667 File Offset: 0x00075867
		// (set) Token: 0x06000F45 RID: 3909 RVA: 0x0007766F File Offset: 0x0007586F
		public int staticLightingCloudsUniqueID
		{
			get
			{
				return this.m_StaticLightingCloudsUniqueID;
			}
			set
			{
				this.m_StaticLightingCloudsUniqueID = value;
				this.UpdateCurrentStaticLightingClouds();
			}
		}

		// Token: 0x06000F46 RID: 3910 RVA: 0x00077680 File Offset: 0x00075880
		private void GetSkyFromIDAndVolume(int skyUniqueID, VolumeProfile profile, out SkySettings skySetting, out Type skyType)
		{
			skySetting = null;
			skyType = typeof(SkySettings);
			if (profile != null && skyUniqueID != 0)
			{
				this.m_VolumeSkyList.Clear();
				if (profile.TryGetAllSubclassOf<SkySettings>(typeof(SkySettings), this.m_VolumeSkyList))
				{
					foreach (SkySettings skySettings in this.m_VolumeSkyList)
					{
						if (skyUniqueID == SkySettings.GetUniqueID(skySettings.GetType()) && skySettings.active)
						{
							skyType = skySettings.GetType();
							skySetting = skySettings;
						}
					}
				}
			}
		}

		// Token: 0x06000F47 RID: 3911 RVA: 0x00077730 File Offset: 0x00075930
		private void GetCloudFromIDAndVolume(int cloudUniqueID, VolumeProfile profile, out CloudSettings cloudSetting, out Type cloudType)
		{
			cloudSetting = null;
			cloudType = typeof(CloudSettings);
			if (profile != null && cloudUniqueID != 0)
			{
				this.m_VolumeCloudsList.Clear();
				if (profile.TryGetAllSubclassOf<CloudSettings>(typeof(CloudSettings), this.m_VolumeCloudsList))
				{
					foreach (CloudSettings cloudSettings in this.m_VolumeCloudsList)
					{
						if (cloudUniqueID == CloudSettings.GetUniqueID(cloudSettings.GetType()) && cloudSettings.active)
						{
							cloudType = cloudSettings.GetType();
							cloudSetting = cloudSettings;
						}
					}
				}
			}
		}

		// Token: 0x06000F48 RID: 3912 RVA: 0x000777E0 File Offset: 0x000759E0
		private void GetVolumetricCloudVolume(VolumeProfile profile, out VolumetricClouds volumetricClouds)
		{
			volumetricClouds = null;
			if (profile != null)
			{
				profile.TryGet<VolumetricClouds>(out volumetricClouds);
			}
		}

		// Token: 0x06000F49 RID: 3913 RVA: 0x000777F8 File Offset: 0x000759F8
		private int InitComponentFromProfile<T>(T component, T componentFromProfile, Type type) where T : VolumeComponent
		{
			ReadOnlyCollection<VolumeParameter> parameters = component.parameters;
			ReadOnlyCollection<VolumeParameter> parameters2 = componentFromProfile.parameters;
			Volume orCreateDefaultVolume = HDRenderPipelineGlobalSettings.instance.GetOrCreateDefaultVolume();
			T t = default(T);
			if (orCreateDefaultVolume.sharedProfile != null)
			{
				orCreateDefaultVolume.sharedProfile.TryGet<T>(type, out t);
			}
			ReadOnlyCollection<VolumeParameter> readOnlyCollection = (t != null) ? t.parameters : null;
			if (parameters2 == null)
			{
				return 0;
			}
			int count = parameters.Count;
			for (int i = 0; i < count; i++)
			{
				if (parameters2[i].overrideState)
				{
					parameters[i].SetValue(parameters2[i]);
				}
				else if (readOnlyCollection != null && readOnlyCollection[i].overrideState)
				{
					parameters[i].SetValue(readOnlyCollection[i]);
				}
			}
			return componentFromProfile.GetHashCode();
		}

		// Token: 0x06000F4A RID: 3914 RVA: 0x000778E4 File Offset: 0x00075AE4
		private void UpdateCurrentStaticLightingSky()
		{
			if (!(RenderPipelineManager.currentPipeline is HDRenderPipeline))
			{
				return;
			}
			CoreUtils.Destroy(this.m_SkySettings);
			this.m_SkySettings = null;
			this.m_LastComputedHash = 0;
			Type type;
			this.GetSkyFromIDAndVolume(this.m_StaticLightingSkyUniqueID, this.m_Profile, out this.m_SkySettingsFromProfile, out type);
			if (this.m_SkySettingsFromProfile != null)
			{
				this.m_SkySettings = (SkySettings)ScriptableObject.CreateInstance(type);
				this.m_LastComputedHash = this.InitComponentFromProfile<SkySettings>(this.m_SkySettings, this.m_SkySettingsFromProfile, type);
			}
		}

		// Token: 0x06000F4B RID: 3915 RVA: 0x0007796C File Offset: 0x00075B6C
		private void UpdateCurrentStaticLightingClouds()
		{
			CoreUtils.Destroy(this.m_CloudSettings);
			this.m_CloudSettings = null;
			this.m_LastComputedCloudHash = 0;
			Type type;
			this.GetCloudFromIDAndVolume(this.m_StaticLightingCloudsUniqueID, this.m_Profile, out this.m_CloudSettingsFromProfile, out type);
			if (this.m_CloudSettingsFromProfile != null)
			{
				this.m_CloudSettings = (CloudSettings)ScriptableObject.CreateInstance(type);
				this.m_LastComputedCloudHash = this.InitComponentFromProfile<CloudSettings>(this.m_CloudSettings, this.m_CloudSettingsFromProfile, type);
			}
		}

		// Token: 0x06000F4C RID: 3916 RVA: 0x000779E4 File Offset: 0x00075BE4
		private void UpdateCurrentStaticLightingVolumetricClouds()
		{
			CoreUtils.Destroy(this.m_VolumetricClouds);
			this.m_VolumetricClouds = null;
			this.m_LastComputedVolumetricCloudHash = 0;
			this.GetVolumetricCloudVolume(this.m_Profile, out this.m_VolumetricCloudSettingsFromProfile);
			if (this.m_VolumetricCloudSettingsFromProfile != null)
			{
				this.m_VolumetricClouds = (VolumetricClouds)ScriptableObject.CreateInstance(typeof(VolumetricClouds));
				this.m_LastComputedVolumetricCloudHash = this.InitComponentFromProfile<VolumetricClouds>(this.m_VolumetricClouds, this.m_VolumetricCloudSettingsFromProfile, typeof(VolumetricClouds));
			}
		}

		// Token: 0x06000F4D RID: 3917 RVA: 0x00077A68 File Offset: 0x00075C68
		private void OnValidate()
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			if (this.m_Profile == null)
			{
				this.m_StaticLightingSkyUniqueID = 0;
				this.m_StaticLightingCloudsUniqueID = 0;
				this.m_StaticLightingVolumetricClouds = false;
			}
			if (this.profile != null)
			{
				if (this.m_SkySettingsFromProfile != null && !this.profile.components.Find((VolumeComponent x) => x == this.m_SkySettingsFromProfile))
				{
					this.m_StaticLightingSkyUniqueID = 0;
				}
				if (this.m_CloudSettingsFromProfile != null && !this.profile.components.Find((VolumeComponent x) => x == this.m_CloudSettingsFromProfile))
				{
					this.m_StaticLightingCloudsUniqueID = 0;
				}
			}
			this.m_NeedUpdateStaticLightingSky = true;
		}

		// Token: 0x06000F4E RID: 3918 RVA: 0x00077B28 File Offset: 0x00075D28
		private bool VerifyProfileComponentsInitialized()
		{
			if (this.m_Profile != null)
			{
				foreach (VolumeComponent volumeComponent in this.m_Profile.components)
				{
					if (volumeComponent.parameters == null || volumeComponent.parameters.Count == 0)
					{
						return false;
					}
				}
				return true;
			}
			return true;
		}

		// Token: 0x06000F4F RID: 3919 RVA: 0x00077BA4 File Offset: 0x00075DA4
		private void OnEnable()
		{
			if (this.VerifyProfileComponentsInitialized())
			{
				this.UpdateCurrentStaticLightingSky();
				this.UpdateCurrentStaticLightingClouds();
				this.UpdateCurrentStaticLightingVolumetricClouds();
			}
			else
			{
				this.m_NeedUpdateStaticLightingSky = true;
			}
			if (this.m_Profile != null)
			{
				SkyManager.RegisterStaticLightingSky(this);
			}
		}

		// Token: 0x06000F50 RID: 3920 RVA: 0x00077BDD File Offset: 0x00075DDD
		private void OnDisable()
		{
			if (this.m_Profile != null)
			{
				SkyManager.UnRegisterStaticLightingSky(this);
			}
			this.ResetSky();
			this.ResetCloud();
			this.ResetVolumetricCloud();
		}

		// Token: 0x06000F51 RID: 3921 RVA: 0x00077C05 File Offset: 0x00075E05
		private void Update()
		{
			if (this.m_NeedUpdateStaticLightingSky)
			{
				this.UpdateCurrentStaticLightingSky();
				this.UpdateCurrentStaticLightingClouds();
				this.UpdateCurrentStaticLightingVolumetricClouds();
				this.m_NeedUpdateStaticLightingSky = false;
			}
		}

		// Token: 0x06000F52 RID: 3922 RVA: 0x00077C28 File Offset: 0x00075E28
		private void ResetSky()
		{
			CoreUtils.Destroy(this.m_SkySettings);
			this.m_SkySettings = null;
			this.m_SkySettingsFromProfile = null;
			this.m_LastComputedHash = 0;
		}

		// Token: 0x06000F53 RID: 3923 RVA: 0x00077C4A File Offset: 0x00075E4A
		private void ResetCloud()
		{
			CoreUtils.Destroy(this.m_CloudSettings);
			this.m_CloudSettings = null;
			this.m_CloudSettingsFromProfile = null;
			this.m_LastComputedCloudHash = 0;
		}

		// Token: 0x06000F54 RID: 3924 RVA: 0x00077C6C File Offset: 0x00075E6C
		private void ResetVolumetricCloud()
		{
			CoreUtils.Destroy(this.m_VolumetricClouds);
			this.m_VolumetricClouds = null;
			this.m_CloudSettingsFromProfile = null;
			this.m_LastComputedVolumetricCloudHash = 0;
		}

		// Token: 0x040017BC RID: 6076
		[SerializeField]
		private VolumeProfile m_Profile;

		// Token: 0x040017BD RID: 6077
		private bool m_NeedUpdateStaticLightingSky;

		// Token: 0x040017BE RID: 6078
		[SerializeField]
		[FormerlySerializedAs("m_BakingSkyUniqueID")]
		private int m_StaticLightingSkyUniqueID;

		// Token: 0x040017BF RID: 6079
		private int m_LastComputedHash;

		// Token: 0x040017C0 RID: 6080
		[SerializeField]
		private int m_StaticLightingCloudsUniqueID;

		// Token: 0x040017C1 RID: 6081
		private int m_LastComputedCloudHash;

		// Token: 0x040017C2 RID: 6082
		private SkySettings m_SkySettings;

		// Token: 0x040017C3 RID: 6083
		private SkySettings m_SkySettingsFromProfile;

		// Token: 0x040017C4 RID: 6084
		private CloudSettings m_CloudSettings;

		// Token: 0x040017C5 RID: 6085
		private CloudSettings m_CloudSettingsFromProfile;

		// Token: 0x040017C6 RID: 6086
		[SerializeField]
		private bool m_StaticLightingVolumetricClouds;

		// Token: 0x040017C7 RID: 6087
		private int m_LastComputedVolumetricCloudHash;

		// Token: 0x040017C8 RID: 6088
		private VolumetricClouds m_VolumetricClouds;

		// Token: 0x040017C9 RID: 6089
		private VolumetricClouds m_VolumetricCloudSettingsFromProfile;

		// Token: 0x040017CA RID: 6090
		private List<SkySettings> m_VolumeSkyList = new List<SkySettings>();

		// Token: 0x040017CB RID: 6091
		private List<CloudSettings> m_VolumeCloudsList = new List<CloudSettings>();
	}
}
