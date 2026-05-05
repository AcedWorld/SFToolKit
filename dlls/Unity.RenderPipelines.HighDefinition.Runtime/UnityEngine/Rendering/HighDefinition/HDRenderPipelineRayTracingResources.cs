using System;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000165 RID: 357
	internal class HDRenderPipelineRayTracingResources : HDRenderPipelineResources
	{
		// Token: 0x04000E61 RID: 3681
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/Reflections/RaytracingReflections.raytrace", ReloadAttribute.Package.Root)]
		public RayTracingShader reflectionRaytracingRT;

		// Token: 0x04000E62 RID: 3682
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/Reflections/RaytracingReflections.compute", ReloadAttribute.Package.Root)]
		public ComputeShader reflectionRaytracingCS;

		// Token: 0x04000E63 RID: 3683
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/RaytracingReflectionFilter.compute", ReloadAttribute.Package.Root)]
		public ComputeShader reflectionBilateralFilterCS;

		// Token: 0x04000E64 RID: 3684
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/Shadows/RaytracingShadow.raytrace", ReloadAttribute.Package.Root)]
		public RayTracingShader shadowRaytracingRT;

		// Token: 0x04000E65 RID: 3685
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/Shadows/RayTracingContactShadow.raytrace", ReloadAttribute.Package.Root)]
		public RayTracingShader contactShadowRayTracingRT;

		// Token: 0x04000E66 RID: 3686
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/Shadows/RaytracingShadow.compute", ReloadAttribute.Package.Root)]
		public ComputeShader shadowRaytracingCS;

		// Token: 0x04000E67 RID: 3687
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/Shadows/RaytracingShadowFilter.compute", ReloadAttribute.Package.Root)]
		public ComputeShader shadowFilterCS;

		// Token: 0x04000E68 RID: 3688
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/RaytracingRenderer.raytrace", ReloadAttribute.Package.Root)]
		public RayTracingShader forwardRaytracing;

		// Token: 0x04000E69 RID: 3689
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/RaytracingLightCluster.compute", ReloadAttribute.Package.Root)]
		public ComputeShader lightClusterBuildCS;

		// Token: 0x04000E6A RID: 3690
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/DebugLightCluster.shader", ReloadAttribute.Package.Root)]
		public Shader lightClusterDebugS;

		// Token: 0x04000E6B RID: 3691
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/DebugLightCluster.compute", ReloadAttribute.Package.Root)]
		public ComputeShader lightClusterDebugCS;

		// Token: 0x04000E6C RID: 3692
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/IndirectDiffuse/RaytracingIndirectDiffuse_APVOff.raytrace", ReloadAttribute.Package.Root)]
		public RayTracingShader indirectDiffuseRaytracingOffRT;

		// Token: 0x04000E6D RID: 3693
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/IndirectDiffuse/RaytracingIndirectDiffuse_APVL1.raytrace", ReloadAttribute.Package.Root)]
		public RayTracingShader indirectDiffuseRaytracingL1RT;

		// Token: 0x04000E6E RID: 3694
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/IndirectDiffuse/RaytracingIndirectDiffuse_APVL2.raytrace", ReloadAttribute.Package.Root)]
		public RayTracingShader indirectDiffuseRaytracingL2RT;

		// Token: 0x04000E6F RID: 3695
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/IndirectDiffuse/RaytracingIndirectDiffuse.compute", ReloadAttribute.Package.Root)]
		public ComputeShader indirectDiffuseRaytracingCS;

		// Token: 0x04000E70 RID: 3696
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/RaytracingAmbientOcclusion.raytrace", ReloadAttribute.Package.Root)]
		public RayTracingShader aoRaytracingRT;

		// Token: 0x04000E71 RID: 3697
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/RaytracingAmbientOcclusion.compute", ReloadAttribute.Package.Root)]
		public ComputeShader aoRaytracingCS;

		// Token: 0x04000E72 RID: 3698
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/RayTracingSubSurface.raytrace", ReloadAttribute.Package.Root)]
		public RayTracingShader subSurfaceRayTracingRT;

		// Token: 0x04000E73 RID: 3699
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/SubSurface/RayTracingSubSurface.compute", ReloadAttribute.Package.Root)]
		public ComputeShader subSurfaceRayTracingCS;

		// Token: 0x04000E74 RID: 3700
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/Denoising/SimpleDenoiser.compute", ReloadAttribute.Package.Root)]
		public ComputeShader simpleDenoiserCS;

		// Token: 0x04000E75 RID: 3701
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/Denoising/ReflectionDenoiser.compute", ReloadAttribute.Package.Root)]
		public ComputeShader reflectionDenoiserCS;

		// Token: 0x04000E76 RID: 3702
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/Denoising/DiffuseShadowDenoiser.compute", ReloadAttribute.Package.Root)]
		public ComputeShader diffuseShadowDenoiserCS;

		// Token: 0x04000E77 RID: 3703
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/Deferred/RaytracingGBuffer.raytrace", ReloadAttribute.Package.Root)]
		public RayTracingShader gBufferRaytracingRT;

		// Token: 0x04000E78 RID: 3704
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/Deferred/RaytracingDeferred.compute", ReloadAttribute.Package.Root)]
		public ComputeShader deferredRaytracingCS;

		// Token: 0x04000E79 RID: 3705
		[Reload("Runtime/RenderPipeline/PathTracing/Shaders/PathTracingMain.raytrace", ReloadAttribute.Package.Root)]
		public RayTracingShader pathTracingRT;

		// Token: 0x04000E7A RID: 3706
		[Reload("Runtime/RenderPipeline/PathTracing/Shaders/PathTracingSkySamplingData.compute", ReloadAttribute.Package.Root)]
		public ComputeShader pathTracingSkySamplingDataCS;

		// Token: 0x04000E7B RID: 3707
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/RayMarching.compute", ReloadAttribute.Package.Root)]
		public ComputeShader rayMarchingCS;

		// Token: 0x04000E7C RID: 3708
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/Common/RayBinning.compute", ReloadAttribute.Package.Root)]
		public ComputeShader rayBinningCS;

		// Token: 0x04000E7D RID: 3709
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/CountTracedRays.compute", ReloadAttribute.Package.Root)]
		public ComputeShader countTracedRays;

		// Token: 0x04000E7E RID: 3710
		[Reload("Runtime/RenderPipelineResources/Texture/ReflectionKernelMapping.png", ReloadAttribute.Package.Root)]
		public Texture2D reflectionFilterMapping;

		// Token: 0x04000E7F RID: 3711
		[Reload("Runtime/RenderPipeline/Raytracing/Shaders/RTASDebug.raytrace", ReloadAttribute.Package.Root)]
		public RayTracingShader rtasDebug;
	}
}
