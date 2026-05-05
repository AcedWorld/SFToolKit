using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnityEngine.Rendering
{
	// Token: 0x0200007E RID: 126
	public abstract class VolumeDebugSettings<T> : IVolumeDebugSettings2, IVolumeDebugSettings where T : MonoBehaviour, IAdditionalData
	{
		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x00010BDA File Offset: 0x0000EDDA
		// (set) Token: 0x060003E7 RID: 999 RVA: 0x00010BE2 File Offset: 0x0000EDE2
		public int selectedComponent { get; set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060003E8 RID: 1000 RVA: 0x00010BEB File Offset: 0x0000EDEB
		public Camera selectedCamera
		{
			get
			{
				return this.m_SelectedCamera;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060003E9 RID: 1001 RVA: 0x00010BF3 File Offset: 0x0000EDF3
		// (set) Token: 0x060003EA RID: 1002 RVA: 0x00010BFC File Offset: 0x0000EDFC
		public int selectedCameraIndex
		{
			get
			{
				return this.m_SelectedCameraIndex;
			}
			set
			{
				this.m_SelectedCameraIndex = value;
				int num = this.cameras.Count<Camera>();
				if (num != 0)
				{
					this.m_SelectedCamera = ((this.m_SelectedCameraIndex < 0 || this.m_SelectedCameraIndex >= num) ? this.cameras.First<Camera>() : this.cameras.ElementAt(this.m_SelectedCameraIndex));
					return;
				}
				this.m_SelectedCamera = null;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060003EB RID: 1003 RVA: 0x00010C60 File Offset: 0x0000EE60
		public IEnumerable<Camera> cameras
		{
			get
			{
				this.m_Cameras.Clear();
				if (this.m_CamerasArray == null || this.m_CamerasArray.Length != Camera.allCamerasCount)
				{
					this.m_CamerasArray = new Camera[Camera.allCamerasCount];
				}
				Camera.GetAllCameras(this.m_CamerasArray);
				foreach (Camera camera in this.m_CamerasArray)
				{
					T t;
					if (!(camera == null) && camera.cameraType != CameraType.Preview && camera.cameraType != CameraType.Reflection && camera.TryGetComponent<T>(out t))
					{
						this.m_Cameras.Add(camera);
					}
				}
				return this.m_Cameras;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060003EC RID: 1004
		public abstract VolumeStack selectedCameraVolumeStack { get; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060003ED RID: 1005
		public abstract LayerMask selectedCameraLayerMask { get; }

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060003EE RID: 1006
		public abstract Vector3 selectedCameraPosition { get; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060003EF RID: 1007 RVA: 0x00010CFC File Offset: 0x0000EEFC
		// (set) Token: 0x060003F0 RID: 1008 RVA: 0x00010D18 File Offset: 0x0000EF18
		public Type selectedComponentType
		{
			get
			{
				return this.volumeComponentsPathAndType[this.selectedComponent - 1].Item2;
			}
			set
			{
				int num = this.volumeComponentsPathAndType.FindIndex((ValueTuple<string, Type> t) => t.Item2 == value);
				if (num != -1)
				{
					this.selectedComponent = num + 1;
				}
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060003F1 RID: 1009 RVA: 0x00010D57 File Offset: 0x0000EF57
		public List<ValueTuple<string, Type>> volumeComponentsPathAndType
		{
			get
			{
				List<ValueTuple<string, Type>> result;
				if ((result = VolumeDebugSettings<T>.s_ComponentPathAndType) == null)
				{
					result = (VolumeDebugSettings<T>.s_ComponentPathAndType = VolumeManager.GetSupportedVolumeComponents(this.targetRenderPipeline));
				}
				return result;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060003F2 RID: 1010
		public abstract Type targetRenderPipeline { get; }

		// Token: 0x060003F3 RID: 1011 RVA: 0x00010D73 File Offset: 0x0000EF73
		internal VolumeParameter GetParameter(VolumeComponent component, FieldInfo field)
		{
			return (VolumeParameter)field.GetValue(component);
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00010D84 File Offset: 0x0000EF84
		internal VolumeParameter GetParameter(FieldInfo field)
		{
			VolumeStack selectedCameraVolumeStack = this.selectedCameraVolumeStack;
			if (selectedCameraVolumeStack != null)
			{
				return this.GetParameter(selectedCameraVolumeStack.GetComponent(this.selectedComponentType), field);
			}
			return null;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00010DB0 File Offset: 0x0000EFB0
		internal VolumeParameter GetParameter(Volume volume, FieldInfo field)
		{
			VolumeComponent component;
			if (!(volume.HasInstantiatedProfile() ? volume.profile : volume.sharedProfile).TryGet<VolumeComponent>(this.selectedComponentType, out component))
			{
				return null;
			}
			VolumeParameter parameter = this.GetParameter(component, field);
			if (!parameter.overrideState)
			{
				return null;
			}
			return parameter;
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00010DF8 File Offset: 0x0000EFF8
		private float ComputeWeight(Volume volume, Vector3 triggerPos)
		{
			if (volume == null)
			{
				return 0f;
			}
			VolumeProfile volumeProfile = volume.HasInstantiatedProfile() ? volume.profile : volume.sharedProfile;
			if (!volume.gameObject.activeInHierarchy)
			{
				return 0f;
			}
			if (!volume.enabled || volumeProfile == null || volume.weight <= 0f)
			{
				return 0f;
			}
			VolumeComponent volumeComponent;
			if (!volumeProfile.TryGet<VolumeComponent>(this.selectedComponentType, out volumeComponent))
			{
				return 0f;
			}
			if (!volumeComponent.active)
			{
				return 0f;
			}
			float num = Mathf.Clamp01(volume.weight);
			if (!volume.isGlobal)
			{
				Collider[] components = volume.GetComponents<Collider>();
				float num2 = float.PositiveInfinity;
				foreach (Collider collider in components)
				{
					if (collider.enabled)
					{
						float sqrMagnitude = (collider.ClosestPoint(triggerPos) - triggerPos).sqrMagnitude;
						if (sqrMagnitude < num2)
						{
							num2 = sqrMagnitude;
						}
					}
				}
				float num3 = volume.blendDistance * volume.blendDistance;
				if (num2 > num3)
				{
					num = 0f;
				}
				else if (num3 > 0f)
				{
					num *= 1f - num2 / num3;
				}
			}
			return num;
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x00010F22 File Offset: 0x0000F122
		public Volume[] GetVolumes()
		{
			return (from v in VolumeManager.instance.GetVolumes(this.selectedCameraLayerMask)
			where v.sharedProfile != null
			select v).Reverse<Volume>().ToArray<Volume>();
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x00010F64 File Offset: 0x0000F164
		private VolumeParameter[,] GetStates()
		{
			FieldInfo[] array = (from t in this.selectedComponentType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
			where t.FieldType.IsSubclassOf(typeof(VolumeParameter))
			select t).ToArray<FieldInfo>();
			VolumeParameter[,] array2 = new VolumeParameter[this.volumes.Length, array.Length];
			for (int i = 0; i < this.volumes.Length; i++)
			{
				VolumeComponent component;
				if ((this.volumes[i].HasInstantiatedProfile() ? this.volumes[i].profile : this.volumes[i].sharedProfile).TryGet<VolumeComponent>(this.selectedComponentType, out component))
				{
					for (int j = 0; j < array.Length; j++)
					{
						VolumeParameter parameter = this.GetParameter(component, array[j]);
						array2[i, j] = (parameter.overrideState ? parameter : null);
					}
				}
			}
			return array2;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00011040 File Offset: 0x0000F240
		private bool ChangedStates(VolumeParameter[,] newStates)
		{
			if (this.savedStates.GetLength(1) != newStates.GetLength(1))
			{
				return true;
			}
			for (int i = 0; i < this.savedStates.GetLength(0); i++)
			{
				for (int j = 0; j < this.savedStates.GetLength(1); j++)
				{
					if (this.savedStates[i, j] == null != (newStates[i, j] == null))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x000110B4 File Offset: 0x0000F2B4
		public bool RefreshVolumes(Volume[] newVolumes)
		{
			bool result = false;
			if (this.volumes == null || !newVolumes.SequenceEqual(this.volumes))
			{
				this.volumes = (Volume[])newVolumes.Clone();
				this.savedStates = this.GetStates();
				result = true;
			}
			else
			{
				VolumeParameter[,] states = this.GetStates();
				if (this.savedStates == null || this.ChangedStates(states))
				{
					this.savedStates = states;
					result = true;
				}
			}
			Vector3 selectedCameraPosition = this.selectedCameraPosition;
			this.weights = new float[this.volumes.Length];
			for (int i = 0; i < this.volumes.Length; i++)
			{
				this.weights[i] = this.ComputeWeight(this.volumes[i], selectedCameraPosition);
			}
			return result;
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00011160 File Offset: 0x0000F360
		public float GetVolumeWeight(Volume volume)
		{
			if (this.weights == null)
			{
				return 0f;
			}
			float num = 0f;
			for (int i = 0; i < this.volumes.Length; i++)
			{
				float num2 = this.weights[i];
				num2 *= 1f - num;
				num += num2;
				if (this.volumes[i] == volume)
				{
					return num2;
				}
			}
			return 0f;
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x000111C8 File Offset: 0x0000F3C8
		public bool VolumeHasInfluence(Volume volume)
		{
			if (this.weights == null)
			{
				return false;
			}
			int num = Array.IndexOf<Volume>(this.volumes, volume);
			return num != -1 && this.weights[num] != 0f;
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x00011204 File Offset: 0x0000F404
		[Obsolete("Please use volumeComponentsPathAndType instead, and get the second element of the tuple", false)]
		public static List<Type> componentTypes
		{
			get
			{
				if (VolumeDebugSettings<T>.s_ComponentTypes == null)
				{
					VolumeDebugSettings<T>.s_ComponentTypes = (from t in VolumeManager.instance.baseComponentTypeArray
					where !t.IsDefined(typeof(HideInInspector), false)
					where !t.IsDefined(typeof(ObsoleteAttribute), false)
					orderby VolumeDebugSettings<T>.ComponentDisplayName(t)
					select t).ToList<Type>();
				}
				return VolumeDebugSettings<T>.s_ComponentTypes;
			}
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x000112A0 File Offset: 0x0000F4A0
		[Obsolete("Please use componentPathAndType instead, and get the first element of the tuple", false)]
		public static string ComponentDisplayName(Type component)
		{
			VolumeComponentMenuForRenderPipeline volumeComponentMenuForRenderPipeline = component.GetCustomAttribute(typeof(VolumeComponentMenuForRenderPipeline), false) as VolumeComponentMenuForRenderPipeline;
			if (volumeComponentMenuForRenderPipeline != null)
			{
				return volumeComponentMenuForRenderPipeline.menu;
			}
			VolumeComponentMenuForRenderPipeline volumeComponentMenuForRenderPipeline2 = component.GetCustomAttribute(typeof(VolumeComponentMenu), false) as VolumeComponentMenuForRenderPipeline;
			if (volumeComponentMenuForRenderPipeline2 != null)
			{
				return volumeComponentMenuForRenderPipeline2.menu;
			}
			return component.Name;
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060003FF RID: 1023 RVA: 0x000112F5 File Offset: 0x0000F4F5
		// (set) Token: 0x06000400 RID: 1024 RVA: 0x000112FC File Offset: 0x0000F4FC
		[Obsolete("Cameras are auto registered/unregistered, use property cameras", false)]
		private protected static List<T> additionalCameraDatas { protected get; private set; } = new List<T>();

		// Token: 0x06000401 RID: 1025 RVA: 0x00011304 File Offset: 0x0000F504
		[Obsolete("Cameras are auto registered/unregistered", false)]
		public static void RegisterCamera(T additionalCamera)
		{
			if (!VolumeDebugSettings<T>.additionalCameraDatas.Contains(additionalCamera))
			{
				VolumeDebugSettings<T>.additionalCameraDatas.Add(additionalCamera);
			}
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x0001131E File Offset: 0x0000F51E
		[Obsolete("Cameras are auto registered/unregistered", false)]
		public static void UnRegisterCamera(T additionalCamera)
		{
			if (VolumeDebugSettings<T>.additionalCameraDatas.Contains(additionalCamera))
			{
				VolumeDebugSettings<T>.additionalCameraDatas.Remove(additionalCamera);
			}
		}

		// Token: 0x04000233 RID: 563
		private Camera m_SelectedCamera;

		// Token: 0x04000234 RID: 564
		protected int m_SelectedCameraIndex = -1;

		// Token: 0x04000235 RID: 565
		private Camera[] m_CamerasArray;

		// Token: 0x04000236 RID: 566
		private List<Camera> m_Cameras = new List<Camera>();

		// Token: 0x04000237 RID: 567
		private static List<ValueTuple<string, Type>> s_ComponentPathAndType;

		// Token: 0x04000238 RID: 568
		private float[] weights;

		// Token: 0x04000239 RID: 569
		private Volume[] volumes;

		// Token: 0x0400023A RID: 570
		private VolumeParameter[,] savedStates;

		// Token: 0x0400023B RID: 571
		private static List<Type> s_ComponentTypes;
	}
}
