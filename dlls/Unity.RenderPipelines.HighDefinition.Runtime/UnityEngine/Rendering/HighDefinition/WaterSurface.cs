using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000224 RID: 548
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	public class WaterSurface : MonoBehaviour
	{
		// Token: 0x06000FD2 RID: 4050 RVA: 0x0007A88C File Offset: 0x00078A8C
		internal static void RegisterInstance(WaterSurface surface)
		{
			WaterSurface.instances.Add(surface);
			WaterSurface.instanceCount = WaterSurface.instances.Count;
			if (WaterSurface.instanceCount > 0)
			{
				WaterSurface.instancesAsArray = new WaterSurface[WaterSurface.instanceCount];
				WaterSurface.instances.CopyTo(WaterSurface.instancesAsArray);
				return;
			}
			WaterSurface.instancesAsArray = null;
		}

		// Token: 0x06000FD3 RID: 4051 RVA: 0x0007A8E4 File Offset: 0x00078AE4
		internal static void UnregisterInstance(WaterSurface surface)
		{
			WaterSurface.instances.Remove(surface);
			WaterSurface.instanceCount = WaterSurface.instances.Count;
			if (WaterSurface.instanceCount > 0)
			{
				WaterSurface.instancesAsArray = new WaterSurface[WaterSurface.instanceCount];
				WaterSurface.instances.CopyTo(WaterSurface.instancesAsArray);
				return;
			}
			WaterSurface.instancesAsArray = null;
		}

		// Token: 0x06000FD4 RID: 4052 RVA: 0x0007A93C File Offset: 0x00078B3C
		internal void CheckResources(int bandResolution, int bandCount, bool cpuSimActive, out bool gpuSpectrumValid, out bool cpuSpectrumValid, out bool historyValid)
		{
			gpuSpectrumValid = true;
			cpuSpectrumValid = true;
			historyValid = true;
			if (this.simulation != null && !this.simulation.ValidResources(bandResolution, bandCount))
			{
				this.simulation.ReleaseSimulationResources();
				this.simulation = null;
			}
			bool flag = cpuSimActive && this.cpuSimulation;
			if (this.simulation == null)
			{
				gpuSpectrumValid = false;
				cpuSpectrumValid = false;
				historyValid = false;
				this.simulation = new WaterSimulationResources();
				this.simulation.InitializeSimulationResources(bandResolution, bandCount);
				this.simulation.AllocateSimulationBuffersGPU();
				if (flag)
				{
					this.simulation.AllocateSimulationBuffersCPU();
				}
			}
			if (!flag && this.simulation.cpuBuffers != null)
			{
				this.simulation.ReleaseSimulationBuffersCPU();
				cpuSpectrumValid = false;
			}
			if (flag && this.simulation.cpuBuffers == null)
			{
				this.simulation.AllocateSimulationBuffersCPU();
				cpuSpectrumValid = false;
			}
			WaterSpectrumParameters waterSpectrumParameters = this.EvaluateSpectrumParams(this.surfaceType);
			if (this.simulation.spectrum.numActiveBands != waterSpectrumParameters.numActiveBands)
			{
				historyValid = false;
			}
			if (this.simulation.spectrum != waterSpectrumParameters)
			{
				gpuSpectrumValid = false;
				cpuSpectrumValid = false;
				this.simulation.spectrum = waterSpectrumParameters;
			}
			cpuSpectrumValid = false;
			this.simulation.rendering = this.EvaluateRenderingParams(this.surfaceType);
		}

		// Token: 0x06000FD5 RID: 4053 RVA: 0x0007AA7C File Offset: 0x00078C7C
		public WaterSimulationResolution GetSimulationResolutionCPU()
		{
			int result;
			if (this.simulation.simulationResolution != 64)
			{
				result = (this.cpuFullResolution ? this.simulation.simulationResolution : (this.simulation.simulationResolution / 2));
			}
			else
			{
				result = this.simulation.simulationResolution;
			}
			return (WaterSimulationResolution)result;
		}

		// Token: 0x06000FD6 RID: 4054 RVA: 0x0007AACC File Offset: 0x00078CCC
		public bool FillWaterSearchData(ref WaterSimSearchData wsd)
		{
			if (this.simulation != null && this.simulation.cpuBuffers != null)
			{
				wsd.displacementData = this.simulation.cpuBuffers.displacementBufferCPU;
				wsd.waterSurfaceElevation = base.transform.position.y;
				wsd.simulationRes = (int)this.GetSimulationResolutionCPU();
				wsd.spectrum = this.simulation.spectrum;
				wsd.rendering = this.simulation.rendering;
				wsd.activeBandCount = HDRenderPipeline.EvaluateCPUBandCount(this.surfaceType, this.ripples, this.cpuEvaluateRipples);
				return true;
			}
			return false;
		}

		// Token: 0x06000FD7 RID: 4055 RVA: 0x0007AB6C File Offset: 0x00078D6C
		public bool FindWaterSurfaceHeight(WaterSearchParameters wsp, out WaterSearchResult wsr)
		{
			wsr.error = float.MaxValue;
			wsr.height = 0f;
			wsr.candidateLocation = float3.zero;
			wsr.numIterations = wsp.maxIterations;
			WaterSimSearchData wsd = default(WaterSimSearchData);
			if (this.FillWaterSearchData(ref wsd))
			{
				HDRenderPipeline.FindWaterSurfaceHeight(wsd, wsp, out wsr);
				return true;
			}
			return false;
		}

		// Token: 0x06000FD8 RID: 4056 RVA: 0x0007ABC3 File Offset: 0x00078DC3
		private void Start()
		{
			WaterSurface.RegisterInstance(this);
		}

		// Token: 0x06000FD9 RID: 4057 RVA: 0x0007ABCB File Offset: 0x00078DCB
		private void Awake()
		{
			WaterSurface.RegisterInstance(this);
		}

		// Token: 0x06000FDA RID: 4058 RVA: 0x0007ABD3 File Offset: 0x00078DD3
		private void OnEnable()
		{
			WaterSurface.RegisterInstance(this);
		}

		// Token: 0x06000FDB RID: 4059 RVA: 0x0007ABDB File Offset: 0x00078DDB
		private void OnDisable()
		{
			WaterSurface.UnregisterInstance(this);
		}

		// Token: 0x06000FDC RID: 4060 RVA: 0x0007ABE3 File Offset: 0x00078DE3
		private bool SpectrumParametersAreValid(WaterSpectrumParameters spectrum)
		{
			return this.simulation.spectrum == spectrum;
		}

		// Token: 0x06000FDD RID: 4061 RVA: 0x0007ABF8 File Offset: 0x00078DF8
		private WaterSpectrumParameters EvaluateSpectrumParams(WaterSurfaceType type)
		{
			WaterSpectrumParameters result = default(WaterSpectrumParameters);
			switch (type)
			{
			case WaterSurfaceType.OceanSeaLake:
			{
				float num = this.repetitionSize;
				float num2 = HDRenderPipeline.EvaluateSwellSecondPatchSize(num);
				result.numActiveBands = (this.ripples ? 3 : 2);
				result.patchSizes.x = num;
				result.patchSizes.y = num / num2;
				result.patchSizes.z = 10f;
				result.patchWindSpeed.x = this.largeWindSpeed * 0.2777778f;
				result.patchWindSpeed.y = this.largeWindSpeed * 0.2777778f;
				result.patchWindSpeed.z = this.ripplesWindSpeed * 0.2777778f;
				result.patchWindOrientation.x = this.largeWindOrientationValue;
				result.patchWindOrientation.y = this.largeWindOrientationValue;
				result.patchWindOrientation.z = ((this.ripplesWindOrientationMode == WaterPropertyOverrideMode.Inherit) ? this.largeWindOrientationValue : this.ripplesWindOrientationValue);
				result.patchWindDirDampener.x = this.largeChaos;
				result.patchWindDirDampener.y = this.largeChaos;
				result.patchWindDirDampener.z = this.ripplesChaos;
				break;
			}
			case WaterSurfaceType.River:
				result.numActiveBands = (this.ripples ? 2 : 1);
				result.patchSizes.x = this.repetitionSize;
				result.patchSizes.y = 10f;
				result.patchWindSpeed.x = this.largeWindSpeed * 0.2777778f;
				result.patchWindSpeed.y = this.ripplesWindSpeed * 0.2777778f;
				result.patchWindOrientation.x = this.largeWindOrientationValue;
				result.patchWindOrientation.y = ((this.ripplesWindOrientationMode == WaterPropertyOverrideMode.Inherit) ? this.largeWindOrientationValue : this.ripplesWindOrientationValue);
				result.patchWindDirDampener.x = this.largeChaos;
				result.patchWindDirDampener.y = this.ripplesChaos;
				break;
			case WaterSurfaceType.Pool:
				result.numActiveBands = 1;
				result.patchSizes.x = 10f;
				result.patchWindSpeed.x = this.ripplesWindSpeed * 0.2777778f;
				result.patchWindOrientation.x = this.ripplesWindOrientationValue;
				result.patchWindDirDampener.x = this.ripplesChaos;
				break;
			}
			return result;
		}

		// Token: 0x06000FDE RID: 4062 RVA: 0x0007AE54 File Offset: 0x00079054
		private WaterRenderingParameters EvaluateRenderingParams(WaterSurfaceType type)
		{
			WaterRenderingParameters waterRenderingParameters = default(WaterRenderingParameters);
			waterRenderingParameters.simulationTime = this.simulation.simulationTime;
			switch (type)
			{
			case WaterSurfaceType.OceanSeaLake:
			{
				waterRenderingParameters.patchAmplitudeMultiplier.x = this.largeBand0Multiplier;
				waterRenderingParameters.patchAmplitudeMultiplier.y = this.largeBand1Multiplier;
				waterRenderingParameters.patchAmplitudeMultiplier.z = 1f;
				float num = this.largeCurrentSpeedValue * 0.2777778f;
				waterRenderingParameters.patchCurrentSpeed.x = num;
				waterRenderingParameters.patchCurrentSpeed.y = num;
				waterRenderingParameters.patchCurrentSpeed.z = ((this.ripplesCurrentMode == WaterPropertyOverrideMode.Inherit) ? num : (this.ripplesCurrentSpeedValue * 0.2777778f));
				waterRenderingParameters.patchCurrentOrientation.x = this.largeCurrentOrientationValue;
				waterRenderingParameters.patchCurrentOrientation.y = this.largeCurrentOrientationValue;
				waterRenderingParameters.patchCurrentOrientation.z = ((this.ripplesCurrentMode == WaterPropertyOverrideMode.Inherit) ? this.largeCurrentOrientationValue : this.ripplesCurrentOrientationValue);
				waterRenderingParameters.patchFadeStart.x = this.largeBand0FadeStart;
				waterRenderingParameters.patchFadeStart.y = this.largeBand1FadeStart;
				waterRenderingParameters.patchFadeStart.z = this.ripplesFadeStart;
				waterRenderingParameters.patchFadeDistance.x = this.largeBand0FadeDistance;
				waterRenderingParameters.patchFadeDistance.y = this.largeBand1FadeDistance;
				waterRenderingParameters.patchFadeDistance.z = this.ripplesFadeDistance;
				waterRenderingParameters.patchFadeValue.x = (this.largeBand0FadeToggle ? 0f : 1f);
				waterRenderingParameters.patchFadeValue.y = (this.largeBand1FadeToggle ? 0f : 1f);
				waterRenderingParameters.patchFadeValue.z = (this.ripplesFadeToggle ? 0f : 1f);
				break;
			}
			case WaterSurfaceType.River:
				waterRenderingParameters.patchAmplitudeMultiplier.x = this.largeBand0Multiplier;
				waterRenderingParameters.patchAmplitudeMultiplier.y = (this.ripples ? 1f : 0f);
				waterRenderingParameters.patchCurrentSpeed.x = this.largeCurrentSpeedValue * 0.2777778f;
				waterRenderingParameters.patchCurrentSpeed.y = ((this.ripplesCurrentMode == WaterPropertyOverrideMode.Inherit) ? waterRenderingParameters.patchCurrentSpeed.x : (this.ripplesCurrentSpeedValue * 0.2777778f));
				waterRenderingParameters.patchCurrentOrientation.x = this.largeCurrentOrientationValue;
				waterRenderingParameters.patchCurrentOrientation.y = ((this.ripplesCurrentMode == WaterPropertyOverrideMode.Inherit) ? waterRenderingParameters.patchCurrentOrientation.x : this.ripplesCurrentOrientationValue);
				waterRenderingParameters.patchFadeStart.x = this.largeBand0FadeStart;
				waterRenderingParameters.patchFadeStart.y = this.ripplesFadeStart;
				waterRenderingParameters.patchFadeDistance.x = this.largeBand0FadeDistance;
				waterRenderingParameters.patchFadeDistance.y = this.ripplesFadeDistance;
				waterRenderingParameters.patchFadeValue.x = (this.largeBand0FadeToggle ? 0f : 1f);
				waterRenderingParameters.patchFadeValue.y = (this.ripplesFadeToggle ? 0f : 1f);
				break;
			case WaterSurfaceType.Pool:
				waterRenderingParameters.patchAmplitudeMultiplier.x = 1f;
				waterRenderingParameters.patchAmplitudeMultiplier.y = 0f;
				waterRenderingParameters.patchCurrentSpeed.x = this.ripplesCurrentSpeedValue * 0.2777778f;
				waterRenderingParameters.patchCurrentOrientation.x = this.ripplesCurrentOrientationValue;
				waterRenderingParameters.patchFadeStart.x = this.ripplesFadeStart;
				waterRenderingParameters.patchFadeDistance.x = this.ripplesFadeDistance;
				waterRenderingParameters.patchFadeValue.x = (this.ripplesFadeToggle ? 0f : 1f);
				break;
			}
			return waterRenderingParameters;
		}

		// Token: 0x06000FDF RID: 4063 RVA: 0x0007B1F6 File Offset: 0x000793F6
		internal bool IsInfinite()
		{
			return this.surfaceType == WaterSurfaceType.OceanSeaLake && this.geometryType == WaterGeometryType.Infinite;
		}

		// Token: 0x06000FE0 RID: 4064 RVA: 0x0007B20B File Offset: 0x0007940B
		private void OnDestroy()
		{
			WaterSurface.UnregisterInstance(this);
			if (this.simulation != null && this.simulation.AllocatedTextures())
			{
				this.simulation.ReleaseSimulationResources();
			}
		}

		// Token: 0x0400188F RID: 6287
		internal static HashSet<WaterSurface> instances = new HashSet<WaterSurface>();

		// Token: 0x04001890 RID: 6288
		internal static WaterSurface[] instancesAsArray = null;

		// Token: 0x04001891 RID: 6289
		internal static int instanceCount = 0;

		// Token: 0x04001892 RID: 6290
		public WaterSurfaceType surfaceType;

		// Token: 0x04001893 RID: 6291
		public WaterGeometryType geometryType = WaterGeometryType.Infinite;

		// Token: 0x04001894 RID: 6292
		public Mesh mesh;

		// Token: 0x04001895 RID: 6293
		public bool cpuSimulation;

		// Token: 0x04001896 RID: 6294
		public bool cpuFullResolution;

		// Token: 0x04001897 RID: 6295
		public bool cpuEvaluateRipples;

		// Token: 0x04001898 RID: 6296
		public float timeMultiplier = 1f;

		// Token: 0x04001899 RID: 6297
		[Tooltip("")]
		public float repetitionSize = 500f;

		// Token: 0x0400189A RID: 6298
		public float largeWindSpeed = 30f;

		// Token: 0x0400189B RID: 6299
		public float largeWindOrientationValue;

		// Token: 0x0400189C RID: 6300
		public float largeCurrentSpeedValue;

		// Token: 0x0400189D RID: 6301
		public float largeCurrentOrientationValue;

		// Token: 0x0400189E RID: 6302
		public float largeChaos = 0.8f;

		// Token: 0x0400189F RID: 6303
		public float largeBand0Multiplier = 1f;

		// Token: 0x040018A0 RID: 6304
		public bool largeBand0FadeToggle = true;

		// Token: 0x040018A1 RID: 6305
		[Tooltip("")]
		public float largeBand0FadeStart = 1500f;

		// Token: 0x040018A2 RID: 6306
		[Tooltip("")]
		public float largeBand0FadeDistance = 3000f;

		// Token: 0x040018A3 RID: 6307
		[Tooltip("")]
		public float largeBand1Multiplier = 1f;

		// Token: 0x040018A4 RID: 6308
		[Tooltip("")]
		public bool largeBand1FadeToggle = true;

		// Token: 0x040018A5 RID: 6309
		[Tooltip("")]
		public float largeBand1FadeStart = 300f;

		// Token: 0x040018A6 RID: 6310
		[Tooltip("")]
		public float largeBand1FadeDistance = 800f;

		// Token: 0x040018A7 RID: 6311
		public bool ripples = true;

		// Token: 0x040018A8 RID: 6312
		[Tooltip("")]
		public float ripplesWindSpeed = 8f;

		// Token: 0x040018A9 RID: 6313
		[Tooltip("")]
		public WaterPropertyOverrideMode ripplesWindOrientationMode;

		// Token: 0x040018AA RID: 6314
		[Tooltip("")]
		public float ripplesWindOrientationValue;

		// Token: 0x040018AB RID: 6315
		[Tooltip("")]
		public WaterPropertyOverrideMode ripplesCurrentMode;

		// Token: 0x040018AC RID: 6316
		[Tooltip("")]
		public float ripplesCurrentSpeedValue;

		// Token: 0x040018AD RID: 6317
		[Tooltip("")]
		public float ripplesCurrentOrientationValue;

		// Token: 0x040018AE RID: 6318
		[Tooltip("")]
		public float ripplesChaos = 0.8f;

		// Token: 0x040018AF RID: 6319
		[Tooltip("")]
		public bool ripplesFadeToggle = true;

		// Token: 0x040018B0 RID: 6320
		[Tooltip("")]
		public float ripplesFadeStart = 50f;

		// Token: 0x040018B1 RID: 6321
		[Tooltip("")]
		public float ripplesFadeDistance = 200f;

		// Token: 0x040018B2 RID: 6322
		public Material customMaterial;

		// Token: 0x040018B3 RID: 6323
		[Tooltip("")]
		public float startSmoothness = 0.95f;

		// Token: 0x040018B4 RID: 6324
		[Tooltip("")]
		public float endSmoothness = 0.85f;

		// Token: 0x040018B5 RID: 6325
		[Tooltip("")]
		public float smoothnessFadeStart = 100f;

		// Token: 0x040018B6 RID: 6326
		[Tooltip("")]
		public float smoothnessFadeDistance = 500f;

		// Token: 0x040018B7 RID: 6327
		[Tooltip("Sets the color that is used to simulate the under-water refraction.")]
		[ColorUsage(false)]
		public Color refractionColor = new Color(0f, 0.45f, 0.65f);

		// Token: 0x040018B8 RID: 6328
		[Tooltip("Controls the maximum distance in meters used to clamp the under water refraction depth. Higher value increases the distortion amount.")]
		public float maxRefractionDistance = 1f;

		// Token: 0x040018B9 RID: 6329
		[Tooltip("Controls the approximative distance in meters that the camera can perceive through a water surface. This distance can vary widely depending on the intensity of the light the object receives.")]
		public float absorptionDistance = 5f;

		// Token: 0x040018BA RID: 6330
		[Tooltip("Sets the color that is used to simulate the under-water scattering.")]
		[ColorUsage(false)]
		public Color scatteringColor = new Color(0f, 0.27f, 0.23f);

		// Token: 0x040018BB RID: 6331
		[Tooltip("Controls the intensity of the height based scattering. The higher the vertical displacement, the more the water receives scattering. This can be adjusted for artistic purposes.")]
		public float ambientScattering = 0.1f;

		// Token: 0x040018BC RID: 6332
		[Tooltip("Controls the intensity of the height based scattering. The higher the vertical displacement, the more the water receives scattering. This can be adjusted for artistic purposes.")]
		public float heightScattering = 0.1f;

		// Token: 0x040018BD RID: 6333
		[Tooltip("Controls the intensity of the displacement based scattering. The bigger horizontal displacement, the more the water receives scattering. This can be adjusted for artistic purposes.")]
		public float displacementScattering = 0.3f;

		// Token: 0x040018BE RID: 6334
		[Tooltip("Controls the intensity of the direct light scattering on the tip of the waves. The effect is more perceivable at grazing angles.")]
		public float directLightTipScattering = 0.6f;

		// Token: 0x040018BF RID: 6335
		[Tooltip("Controls the intensity of the direct light scattering on the body of the waves. The effect is more perceivable at grazing angles.")]
		public float directLightBodyScattering = 0.4f;

		// Token: 0x040018C0 RID: 6336
		[Tooltip("When enabled, the water surface will render caustics.")]
		public bool caustics = true;

		// Token: 0x040018C1 RID: 6337
		[Tooltip("Sets the intensity of the under-water caustics.")]
		public float causticsIntensity = 0.5f;

		// Token: 0x040018C2 RID: 6338
		[Tooltip("Sets the vertical blending distance for the water caustics.")]
		public float causticsPlaneBlendDistance = 1f;

		// Token: 0x040018C3 RID: 6339
		[Tooltip("Specifies the resolution at which the water caustics are rendered (simulation only).")]
		public WaterSurface.WaterCausticsResolution causticsResolution = WaterSurface.WaterCausticsResolution.Caustics256;

		// Token: 0x040018C4 RID: 6340
		[Tooltip("Controls which band is used for the caustics evaluation.")]
		public int causticsBand = 1;

		// Token: 0x040018C5 RID: 6341
		public float virtualPlaneDistance = 5f;

		// Token: 0x040018C6 RID: 6342
		[Tooltip("")]
		public bool foam = true;

		// Token: 0x040018C7 RID: 6343
		[Tooltip("Controls the simulation foam amount. Higher values generate larger foam patches. Foam presence is highly dependent on the wind speed and chopiness values.")]
		public float simulationFoamAmount = 0.3f;

		// Token: 0x040018C8 RID: 6344
		[Tooltip("Controls the life span of the surface foam. A higher value will cause the foam to persist longer and leave a trail.")]
		public float simulationFoamDrag;

		// Token: 0x040018C9 RID: 6345
		[Tooltip("Controls the surface foam smoothness.")]
		public float simulationFoamSmoothness = 1f;

		// Token: 0x040018CA RID: 6346
		public Texture2D foamMask;

		// Token: 0x040018CB RID: 6347
		[Tooltip("Sets the extent of the foam mask in meters.")]
		public Vector2 foamMaskExtent = new Vector2(100f, 100f);

		// Token: 0x040018CC RID: 6348
		[Tooltip("Sets the offset of the foam mask in meters.")]
		public Vector2 foamMaskOffset = new Vector2(0f, 0f);

		// Token: 0x040018CD RID: 6349
		public AnimationCurve windFoamCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(0.2f, 0f),
			new Keyframe(0.3f, 1f),
			new Keyframe(1f, 1f)
		});

		// Token: 0x040018CE RID: 6350
		[Tooltip("Set the texture used to attenuate or suppress the simulation foam.")]
		public Texture2D foamTexture;

		// Token: 0x040018CF RID: 6351
		[Tooltip("Set the per meter tiling for the foam texture.")]
		public float foamTextureTiling = 0.2f;

		// Token: 0x040018D0 RID: 6352
		public Texture2D waterMask;

		// Token: 0x040018D1 RID: 6353
		[Tooltip("Sets the extent of the water mask in meters.")]
		public Vector2 waterMaskExtent = new Vector2(100f, 100f);

		// Token: 0x040018D2 RID: 6354
		[Tooltip("Sets the offset of the water mask in meters.")]
		public Vector2 waterMaskOffset = new Vector2(0f, 0f);

		// Token: 0x040018D3 RID: 6355
		[Tooltip("Specifies the decal layers that affect the water surface.")]
		public DecalLayerEnum decalLayerMask = DecalLayerEnum.DecalLayerDefault;

		// Token: 0x040018D4 RID: 6356
		[Tooltip("Specifies the light layers that affect the water surface.")]
		public LightLayerEnum lightLayerMask = LightLayerEnum.LightLayerDefault;

		// Token: 0x040018D5 RID: 6357
		[Tooltip("When enabled, HDRP will apply a fog and color shift to the final image when the camera is under the surface. This feature has a cost even when the camera is above the water surface.")]
		public bool underWater;

		// Token: 0x040018D6 RID: 6358
		[Tooltip("Sets a box collider that will be used to define the volume where the under water effect is applied for non infinite surfaces.")]
		public BoxCollider volumeBounds;

		// Token: 0x040018D7 RID: 6359
		[Tooltip("Sets maximum depth at which the under water effect is evaluated for infinite surfaces.")]
		public float volumeDepth = 50f;

		// Token: 0x040018D8 RID: 6360
		[Tooltip("Sets a priority value that is used to define which surface should be considered for under water rendering in the case of multiple overlapping surfaces.")]
		public int volumePrority;

		// Token: 0x040018D9 RID: 6361
		[Tooltip("Sets a vertical distance to the water surface at which the blending between above and under water starts.")]
		public float transitionSize = 0.1f;

		// Token: 0x040018DA RID: 6362
		[Tooltip("Sets the multiplier for the  Absorption Distance when the camera is under water. A value of 2.0 means you will see twice as far underwater.")]
		public float absorbtionDistanceMultiplier = 1f;

		// Token: 0x040018DB RID: 6363
		internal WaterSimulationResources simulation;

		// Token: 0x02000450 RID: 1104
		public enum WaterCausticsResolution
		{
			// Token: 0x040029C9 RID: 10697
			Caustics256 = 256,
			// Token: 0x040029CA RID: 10698
			Caustics512 = 512,
			// Token: 0x040029CB RID: 10699
			Caustics1024 = 1024
		}
	}
}
