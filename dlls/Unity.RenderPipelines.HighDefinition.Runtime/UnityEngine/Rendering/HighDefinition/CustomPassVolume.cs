using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine.Experimental.Rendering.RenderGraphModule;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001A0 RID: 416
	[ExecuteAlways]
	public class CustomPassVolume : MonoBehaviour, IVolume
	{
		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000CFD RID: 3325 RVA: 0x0006A87B File Offset: 0x00068A7B
		// (set) Token: 0x06000CFE RID: 3326 RVA: 0x0006A883 File Offset: 0x00068A83
		public bool isGlobal
		{
			get
			{
				return this.m_IsGlobal;
			}
			set
			{
				this.m_IsGlobal = value;
			}
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000CFF RID: 3327 RVA: 0x0006A88C File Offset: 0x00068A8C
		// (set) Token: 0x06000D00 RID: 3328 RVA: 0x0006A89E File Offset: 0x00068A9E
		public Camera targetCamera
		{
			get
			{
				if (!this.useTargetCamera)
				{
					return null;
				}
				return this.m_TargetCamera;
			}
			set
			{
				this.m_TargetCamera = value;
				this.useTargetCamera = (value != null);
			}
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000D01 RID: 3329 RVA: 0x0006A8B4 File Offset: 0x00068AB4
		// (set) Token: 0x06000D02 RID: 3330 RVA: 0x0006A8BC File Offset: 0x00068ABC
		public float fadeValue { get; private set; }

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000D03 RID: 3331 RVA: 0x0006A8C5 File Offset: 0x00068AC5
		public List<Collider> colliders
		{
			get
			{
				return this.m_Colliders;
			}
		}

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000D04 RID: 3332 RVA: 0x0006A8CD File Offset: 0x00068ACD
		private static List<CustomPassInjectionPoint> injectionPoints
		{
			get
			{
				if (CustomPassVolume.m_InjectionPoints == null)
				{
					CustomPassVolume.m_InjectionPoints = Enum.GetValues(typeof(CustomPassInjectionPoint)).Cast<CustomPassInjectionPoint>().ToList<CustomPassInjectionPoint>();
				}
				return CustomPassVolume.m_InjectionPoints;
			}
		}

		// Token: 0x06000D05 RID: 3333 RVA: 0x0006A8F9 File Offset: 0x00068AF9
		private void OnEnable()
		{
			this.customPasses.RemoveAll((CustomPass c) => c == null);
			base.GetComponents<Collider>(this.m_Colliders);
			CustomPassVolume.Register(this);
		}

		// Token: 0x06000D06 RID: 3334 RVA: 0x0006A938 File Offset: 0x00068B38
		private void OnDisable()
		{
			CustomPassVolume.UnRegister(this);
			this.CleanupPasses();
		}

		// Token: 0x06000D07 RID: 3335 RVA: 0x0006A948 File Offset: 0x00068B48
		private bool IsVisible(HDCamera hdCamera)
		{
			if (this.useTargetCamera)
			{
				return this.targetCamera == hdCamera.camera;
			}
			return hdCamera.camera.cameraType == CameraType.SceneView || (hdCamera.volumeLayerMask & 1 << base.gameObject.layer) != 0;
		}

		// Token: 0x06000D08 RID: 3336 RVA: 0x0006A99C File Offset: 0x00068B9C
		internal bool Execute(RenderGraph renderGraph, HDCamera hdCamera, CullingResults cullingResult, CullingResults cameraCullingResult, in CustomPass.RenderTargets targets)
		{
			bool result = false;
			if (!this.IsVisible(hdCamera))
			{
				return false;
			}
			foreach (CustomPass customPass in this.customPasses)
			{
				if (customPass != null && customPass.WillBeExecuted(hdCamera))
				{
					customPass.ExecuteInternal(renderGraph, hdCamera, cullingResult, cameraCullingResult, targets, this);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06000D09 RID: 3337 RVA: 0x0006AA14 File Offset: 0x00068C14
		internal bool WillExecuteInjectionPoint(HDCamera hdCamera)
		{
			bool result = false;
			if (!this.IsVisible(hdCamera))
			{
				return false;
			}
			foreach (CustomPass customPass in this.customPasses)
			{
				if (customPass != null && customPass.WillBeExecuted(hdCamera))
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06000D0A RID: 3338 RVA: 0x0006AA7C File Offset: 0x00068C7C
		internal void CleanupPasses()
		{
			foreach (CustomPass customPass in this.customPasses)
			{
				customPass.CleanupPassInternal();
			}
		}

		// Token: 0x06000D0B RID: 3339 RVA: 0x0006AACC File Offset: 0x00068CCC
		private static void Register(CustomPassVolume volume)
		{
			CustomPassVolume.m_ActivePassVolumes.Add(volume);
		}

		// Token: 0x06000D0C RID: 3340 RVA: 0x0006AADA File Offset: 0x00068CDA
		private static void UnRegister(CustomPassVolume volume)
		{
			CustomPassVolume.m_ActivePassVolumes.Remove(volume);
		}

		// Token: 0x06000D0D RID: 3341 RVA: 0x0006AAE8 File Offset: 0x00068CE8
		internal static void Update(HDCamera camera)
		{
			Vector3 position = camera.volumeAnchor.position;
			CustomPassVolume.m_OverlappingPassVolumes.Clear();
			foreach (CustomPassVolume customPassVolume in CustomPassVolume.m_ActivePassVolumes)
			{
				if (customPassVolume.IsVisible(camera))
				{
					if (customPassVolume.useTargetCamera)
					{
						if (customPassVolume.targetCamera == camera.camera)
						{
							CustomPassVolume.m_OverlappingPassVolumes.Add(customPassVolume);
						}
					}
					else if (customPassVolume.isGlobal)
					{
						customPassVolume.fadeValue = 1f;
						CustomPassVolume.m_OverlappingPassVolumes.Add(customPassVolume);
					}
					else if (customPassVolume.m_Colliders.Count != 0)
					{
						customPassVolume.m_OverlappingColliders.Clear();
						float num = Mathf.Max(float.Epsilon, customPassVolume.fadeRadius * customPassVolume.fadeRadius);
						float num2 = 1E+20f;
						foreach (Collider collider in customPassVolume.m_Colliders)
						{
							if (collider && collider.enabled)
							{
								MeshCollider meshCollider = collider as MeshCollider;
								if (meshCollider == null || meshCollider.convex)
								{
									float sqrMagnitude = (collider.ClosestPoint(position) - position).sqrMagnitude;
									num2 = Mathf.Min(num2, sqrMagnitude);
									if (sqrMagnitude <= num)
									{
										customPassVolume.m_OverlappingColliders.Add(collider);
									}
								}
							}
						}
						customPassVolume.fadeValue = 1f - Mathf.Clamp01(Mathf.Sqrt(num2 / num));
						if (customPassVolume.m_OverlappingColliders.Count > 0)
						{
							CustomPassVolume.m_OverlappingPassVolumes.Add(customPassVolume);
						}
					}
				}
			}
			CustomPassVolume.m_OverlappingPassVolumes.Sort(delegate(CustomPassVolume v1, CustomPassVolume v2)
			{
				if (v1.priority != v2.priority)
				{
					return v2.priority.CompareTo(v1.priority);
				}
				if (v1.isGlobal && v2.isGlobal)
				{
					return 0;
				}
				if (v1.isGlobal)
				{
					return 1;
				}
				if (v2.isGlobal)
				{
					return -1;
				}
				return CustomPassVolume.<Update>g__GetVolumeExtent|34_1(v1).CompareTo(CustomPassVolume.<Update>g__GetVolumeExtent|34_1(v2));
			});
		}

		// Token: 0x06000D0E RID: 3342 RVA: 0x0006ACF8 File Offset: 0x00068EF8
		internal void AggregateCullingParameters(ref ScriptableCullingParameters cullingParameters, HDCamera hdCamera)
		{
			foreach (CustomPass customPass in this.customPasses)
			{
				if (customPass != null && customPass.enabled)
				{
					customPass.InternalAggregateCullingParameters(ref cullingParameters, hdCamera);
				}
			}
		}

		// Token: 0x06000D0F RID: 3343 RVA: 0x0006AD58 File Offset: 0x00068F58
		internal static CullingResults? Cull(ScriptableRenderContext renderContext, HDCamera hdCamera)
		{
			CullingResults? result = null;
			CustomPassVolume.Update(hdCamera);
			ScriptableCullingParameters scriptableCullingParameters;
			hdCamera.camera.TryGetCullingParameters(out scriptableCullingParameters);
			scriptableCullingParameters.cullingMask = 0U;
			scriptableCullingParameters.cullingOptions = CullingOptions.None;
			foreach (CustomPassVolume customPassVolume in CustomPassVolume.m_OverlappingPassVolumes)
			{
				if (customPassVolume != null)
				{
					customPassVolume.AggregateCullingParameters(ref scriptableCullingParameters, hdCamera);
				}
			}
			if (!(true & ((ulong)scriptableCullingParameters.cullingMask & (ulong)((long)hdCamera.camera.cullingMask)) == (ulong)scriptableCullingParameters.cullingMask & scriptableCullingParameters.cullingMatrix == hdCamera.camera.cullingMatrix & scriptableCullingParameters.isOrthographic == hdCamera.camera.orthographic))
			{
				result = new CullingResults?(renderContext.Cull(ref scriptableCullingParameters));
			}
			return result;
		}

		// Token: 0x06000D10 RID: 3344 RVA: 0x0006AE40 File Offset: 0x00069040
		internal static void Cleanup()
		{
			foreach (CustomPassVolume customPassVolume in CustomPassVolume.m_ActivePassVolumes)
			{
				customPassVolume.CleanupPasses();
			}
		}

		// Token: 0x06000D11 RID: 3345 RVA: 0x0006AE90 File Offset: 0x00069090
		[Obsolete("In order to support multiple custom pass volume per injection points, please use GetActivePassVolumes.")]
		public static CustomPassVolume GetActivePassVolume(CustomPassInjectionPoint injectionPoint)
		{
			List<CustomPassVolume> list = new List<CustomPassVolume>();
			CustomPassVolume.GetActivePassVolumes(injectionPoint, list);
			return list.FirstOrDefault<CustomPassVolume>();
		}

		// Token: 0x06000D12 RID: 3346 RVA: 0x0006AEB0 File Offset: 0x000690B0
		public static void GetActivePassVolumes(CustomPassInjectionPoint injectionPoint, List<CustomPassVolume> volumes)
		{
			volumes.Clear();
			foreach (CustomPassVolume customPassVolume in CustomPassVolume.m_OverlappingPassVolumes)
			{
				if (customPassVolume.injectionPoint == injectionPoint)
				{
					volumes.Add(customPassVolume);
				}
			}
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x0006AF14 File Offset: 0x00069114
		public CustomPass AddPassOfType<T>() where T : CustomPass
		{
			return this.AddPassOfType(typeof(T));
		}

		// Token: 0x06000D14 RID: 3348 RVA: 0x0006AF28 File Offset: 0x00069128
		public CustomPass AddPassOfType(Type passType)
		{
			if (!typeof(CustomPass).IsAssignableFrom(passType))
			{
				Debug.LogError(string.Format("Can't add pass type {0} to the list because it does not inherit from CustomPass.", passType));
				return null;
			}
			CustomPass customPass = Activator.CreateInstance(passType) as CustomPass;
			this.customPasses.Add(customPass);
			return customPass;
		}

		// Token: 0x06000D17 RID: 3351 RVA: 0x0006AFC0 File Offset: 0x000691C0
		[CompilerGenerated]
		internal static float <Update>g__GetVolumeExtent|34_1(CustomPassVolume volume)
		{
			float num = 0f;
			foreach (Collider collider in volume.m_OverlappingColliders)
			{
				num += collider.bounds.extents.magnitude;
			}
			return num;
		}

		// Token: 0x04001404 RID: 5124
		[SerializeField]
		[FormerlySerializedAs("isGlobal")]
		private bool m_IsGlobal = true;

		// Token: 0x04001405 RID: 5125
		[Min(0f)]
		public float fadeRadius;

		// Token: 0x04001406 RID: 5126
		[Tooltip("Sets the Volume priority in the stack. A higher value means higher priority. You can use negative values.")]
		public float priority;

		// Token: 0x04001407 RID: 5127
		[SerializeReference]
		public List<CustomPass> customPasses = new List<CustomPass>();

		// Token: 0x04001408 RID: 5128
		public CustomPassInjectionPoint injectionPoint = CustomPassInjectionPoint.BeforeTransparent;

		// Token: 0x04001409 RID: 5129
		[SerializeField]
		internal Camera m_TargetCamera;

		// Token: 0x0400140B RID: 5131
		[SerializeField]
		internal bool useTargetCamera;

		// Token: 0x0400140C RID: 5132
		private static HashSet<CustomPassVolume> m_ActivePassVolumes = new HashSet<CustomPassVolume>();

		// Token: 0x0400140D RID: 5133
		private static List<CustomPassVolume> m_OverlappingPassVolumes = new List<CustomPassVolume>();

		// Token: 0x0400140E RID: 5134
		internal List<Collider> m_Colliders = new List<Collider>();

		// Token: 0x0400140F RID: 5135
		private List<Collider> m_OverlappingColliders = new List<Collider>();

		// Token: 0x04001410 RID: 5136
		private static List<CustomPassInjectionPoint> m_InjectionPoints;
	}
}
