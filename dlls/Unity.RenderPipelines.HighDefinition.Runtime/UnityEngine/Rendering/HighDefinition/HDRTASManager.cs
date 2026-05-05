using System;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200017B RID: 379
	internal class HDRTASManager
	{
		// Token: 0x06000C5E RID: 3166 RVA: 0x00066C90 File Offset: 0x00064E90
		public void Initialize()
		{
			this.cullingConfig.lodParameters.orthoSize = 0f;
			this.cullingConfig.lodParameters.isOrthographic = false;
			this.cullingConfig.subMeshFlagsConfig.opaqueMaterials = (RayTracingSubMeshFlags.Enabled | RayTracingSubMeshFlags.ClosestHitOnly);
			this.cullingConfig.subMeshFlagsConfig.transparentMaterials = (RayTracingSubMeshFlags.Enabled | RayTracingSubMeshFlags.UniqueAnyHitCalls);
			this.cullingConfig.subMeshFlagsConfig.alphaTestedMaterials = RayTracingSubMeshFlags.Enabled;
			this.cullingConfig.triangleCullingConfig.checkDoubleSidedGIMaterial = true;
			this.cullingConfig.triangleCullingConfig.frontTriangleCounterClockwise = false;
			this.cullingConfig.triangleCullingConfig.optionalDoubleSidedShaderKeywords = new string[1];
			this.cullingConfig.triangleCullingConfig.optionalDoubleSidedShaderKeywords[0] = "_DOUBLESIDED_ON";
			this.cullingConfig.alphaTestedMaterialConfig.renderQueueLowerBound = HDRenderQueue.k_RenderQueue_OpaqueAlphaTest.lowerBound;
			this.cullingConfig.alphaTestedMaterialConfig.renderQueueUpperBound = HDRenderQueue.k_RenderQueue_OpaqueAlphaTest.upperBound;
			this.cullingConfig.alphaTestedMaterialConfig.optionalShaderKeywords = new string[1];
			this.cullingConfig.alphaTestedMaterialConfig.optionalShaderKeywords[0] = "_ALPHATEST_ON";
			this.cullingConfig.transparentMaterialConfig.renderQueueLowerBound = HDRenderQueue.k_RenderQueue_Transparent.lowerBound;
			this.cullingConfig.transparentMaterialConfig.renderQueueUpperBound = HDRenderQueue.k_RenderQueue_Transparent.upperBound;
			this.cullingConfig.transparentMaterialConfig.optionalShaderKeywords = new string[1];
			this.cullingConfig.transparentMaterialConfig.optionalShaderKeywords[0] = "_SURFACE_TYPE_TRANSPARENT";
			this.cullingConfig.materialTest.requiredShaderTags = new RayTracingInstanceCullingShaderTagConfig[1];
			this.cullingConfig.materialTest.requiredShaderTags[0].tagId = new ShaderTagId("RenderPipeline");
			this.cullingConfig.materialTest.requiredShaderTags[0].tagValueId = new ShaderTagId("HDRenderPipeline");
			this.cullingConfig.materialTest.deniedShaderPasses = DecalSystem.s_MaterialDecalPassNames;
			this.cullingConfig.instanceTests = new RayTracingInstanceCullingTest[9];
			this.ShT_CT.allowOpaqueMaterials = true;
			this.ShT_CT.allowAlphaTestedMaterials = true;
			this.ShT_CT.allowTransparentMaterials = true;
			this.ShT_CT.layerMask = -1;
			this.ShT_CT.shadowCastingModeMask = 14;
			this.ShT_CT.instanceMask = 2U;
			this.ShO_CT.allowOpaqueMaterials = true;
			this.ShO_CT.allowAlphaTestedMaterials = true;
			this.ShO_CT.allowTransparentMaterials = false;
			this.ShO_CT.layerMask = -1;
			this.ShO_CT.shadowCastingModeMask = 14;
			this.ShO_CT.instanceMask = 4U;
			this.AO_CT.allowOpaqueMaterials = true;
			this.AO_CT.allowAlphaTestedMaterials = true;
			this.AO_CT.allowTransparentMaterials = false;
			this.AO_CT.layerMask = -1;
			this.AO_CT.shadowCastingModeMask = 7;
			this.AO_CT.instanceMask = 8U;
			this.Refl_CT.allowOpaqueMaterials = true;
			this.Refl_CT.allowAlphaTestedMaterials = true;
			this.Refl_CT.allowTransparentMaterials = false;
			this.Refl_CT.layerMask = -1;
			this.Refl_CT.shadowCastingModeMask = 7;
			this.Refl_CT.instanceMask = 16U;
			this.GI_CT.allowOpaqueMaterials = true;
			this.GI_CT.allowAlphaTestedMaterials = true;
			this.GI_CT.allowTransparentMaterials = false;
			this.GI_CT.layerMask = -1;
			this.GI_CT.shadowCastingModeMask = 7;
			this.GI_CT.instanceMask = 32U;
			this.RR_CT.allowOpaqueMaterials = true;
			this.RR_CT.allowAlphaTestedMaterials = true;
			this.RR_CT.allowTransparentMaterials = true;
			this.RR_CT.layerMask = -1;
			this.RR_CT.shadowCastingModeMask = 7;
			this.RR_CT.instanceMask = 64U;
			this.RR_CT.allowOpaqueMaterials = true;
			this.RR_CT.allowAlphaTestedMaterials = true;
			this.RR_CT.allowTransparentMaterials = true;
			this.RR_CT.layerMask = -1;
			this.RR_CT.shadowCastingModeMask = 7;
			this.RR_CT.instanceMask = 64U;
			this.SSS_CT.allowOpaqueMaterials = true;
			this.SSS_CT.allowAlphaTestedMaterials = true;
			this.SSS_CT.allowTransparentMaterials = false;
			this.SSS_CT.layerMask = -1;
			this.SSS_CT.shadowCastingModeMask = -1;
			this.SSS_CT.instanceMask = 1U;
			this.PT_CT.allowOpaqueMaterials = true;
			this.PT_CT.allowAlphaTestedMaterials = true;
			this.PT_CT.allowTransparentMaterials = true;
			this.PT_CT.layerMask = -1;
			this.PT_CT.shadowCastingModeMask = 7;
			this.PT_CT.instanceMask = 128U;
		}

		// Token: 0x06000C5F RID: 3167 RVA: 0x0006712C File Offset: 0x0006532C
		private void SetupCullingData(HDCamera hdCamera, bool pathTracingEnabled)
		{
			RayTracingSettings component = hdCamera.volumeStack.GetComponent<RayTracingSettings>();
			RTASCullingMode value = component.cullingMode.value;
			if (value != RTASCullingMode.ExtendedFrustum)
			{
				if (value != RTASCullingMode.Sphere)
				{
					this.cullingConfig.flags = RayTracingInstanceCullingFlags.None;
				}
				else
				{
					this.cullingConfig.flags = RayTracingInstanceCullingFlags.EnableSphereCulling;
					this.cullingConfig.sphereRadius = component.cullingDistance.value;
					this.cullingConfig.sphereCenter = hdCamera.camera.transform.position;
				}
			}
			else
			{
				this.cullingConfig.flags = RayTracingInstanceCullingFlags.EnablePlaneCulling;
				Vector3 position = hdCamera.camera.transform.position;
				Vector3 forward = hdCamera.camera.transform.forward;
				Vector3 right = hdCamera.camera.transform.right;
				Vector3 up = hdCamera.camera.transform.up;
				float farClipPlane = hdCamera.camera.farClipPlane;
				float d = Mathf.Tan(0.017453292f * hdCamera.camera.fieldOfView * 0.5f) * farClipPlane;
				float num = Camera.VerticalToHorizontalFieldOfView(hdCamera.camera.fieldOfView, hdCamera.camera.aspect);
				float d2 = Mathf.Tan(0.017453292f * num * 0.5f) * farClipPlane;
				this.rtCullingPlaneArray[0].normal = -forward;
				this.rtCullingPlaneArray[0].distance = -Vector3.Dot(position + forward * farClipPlane, -forward);
				this.rtCullingPlaneArray[1].normal = forward;
				this.rtCullingPlaneArray[1].distance = -Vector3.Dot(position - forward * farClipPlane, forward);
				this.rtCullingPlaneArray[2].normal = -right;
				this.rtCullingPlaneArray[2].distance = -Vector3.Dot(position + right * d2, -right);
				this.rtCullingPlaneArray[3].normal = right;
				this.rtCullingPlaneArray[3].distance = -Vector3.Dot(position - right * d2, right);
				this.rtCullingPlaneArray[4].normal = -up;
				this.rtCullingPlaneArray[4].distance = -Vector3.Dot(position + up * d, -up);
				this.rtCullingPlaneArray[5].normal = up;
				this.rtCullingPlaneArray[5].distance = -Vector3.Dot(position - up * d, up);
				this.cullingConfig.planes = this.rtCullingPlaneArray;
			}
			this.cullingConfig.flags = (this.cullingConfig.flags | (RayTracingInstanceCullingFlags.EnableLODCulling | RayTracingInstanceCullingFlags.IgnoreReflectionProbes));
			if (pathTracingEnabled)
			{
				this.cullingConfig.flags = (this.cullingConfig.flags | RayTracingInstanceCullingFlags.ComputeMaterialsCRC);
			}
		}

		// Token: 0x06000C60 RID: 3168 RVA: 0x00067414 File Offset: 0x00065614
		public RayTracingInstanceCullingResults Cull(HDCamera hdCamera, in HDEffectsParameters parameters)
		{
			this.instanceTestArray.Clear();
			this.SetupCullingData(hdCamera, parameters.pathTracing);
			this.cullingConfig.lodParameters.fieldOfView = hdCamera.camera.fieldOfView;
			this.cullingConfig.lodParameters.cameraPosition = hdCamera.camera.transform.position;
			this.cullingConfig.lodParameters.cameraPixelHeight = hdCamera.camera.pixelHeight;
			if (parameters.pathTracing)
			{
				this.ShO_CT.layerMask = parameters.ptLayerMask;
				this.ShT_CT.layerMask = parameters.ptLayerMask;
			}
			if (parameters.shadows || parameters.pathTracing)
			{
				this.instanceTestArray.Add(this.ShO_CT);
				this.instanceTestArray.Add(this.ShT_CT);
			}
			if (parameters.ambientOcclusion)
			{
				this.AO_CT.layerMask = parameters.aoLayerMask;
				this.instanceTestArray.Add(this.AO_CT);
			}
			if (parameters.reflections)
			{
				this.Refl_CT.layerMask = parameters.reflLayerMask;
				this.instanceTestArray.Add(this.Refl_CT);
			}
			if (parameters.globalIllumination)
			{
				this.GI_CT.layerMask = parameters.giLayerMask;
				this.instanceTestArray.Add(this.GI_CT);
			}
			if (parameters.recursiveRendering)
			{
				this.RR_CT.layerMask = parameters.recursiveLayerMask;
				this.instanceTestArray.Add(this.RR_CT);
			}
			if (parameters.subSurface)
			{
				this.instanceTestArray.Add(this.SSS_CT);
			}
			if (parameters.pathTracing)
			{
				this.PT_CT.layerMask = parameters.ptLayerMask;
				this.instanceTestArray.Add(this.PT_CT);
			}
			if (this.cullingConfig.instanceTests.Length != this.instanceTestArray.Count)
			{
				this.cullingConfig.instanceTests = this.instanceTestArray.ToArray();
			}
			else
			{
				this.instanceTestArray.CopyTo(0, this.cullingConfig.instanceTests, 0, this.instanceTestArray.Count);
			}
			return this.rtas.CullInstances(ref this.cullingConfig);
		}

		// Token: 0x06000C61 RID: 3169 RVA: 0x0006763C File Offset: 0x0006583C
		public void Build(HDCamera hdCamera)
		{
			if (ShaderConfig.s_CameraRelativeRendering != 0)
			{
				this.rtas.Build(hdCamera.mainViewConstants.worldSpaceCameraPos);
				return;
			}
			this.rtas.Build();
		}

		// Token: 0x06000C62 RID: 3170 RVA: 0x00067667 File Offset: 0x00065867
		public void Reset()
		{
			if (this.rtas != null)
			{
				this.rtas.ClearInstances();
				return;
			}
			this.rtas = new RayTracingAccelerationStructure();
		}

		// Token: 0x06000C63 RID: 3171 RVA: 0x00067688 File Offset: 0x00065888
		public void ReleaseResources()
		{
			if (this.rtas != null)
			{
				this.rtas.Dispose();
			}
		}

		// Token: 0x0400132D RID: 4909
		public RayTracingAccelerationStructure rtas;

		// Token: 0x0400132E RID: 4910
		public RayTracingInstanceCullingConfig cullingConfig;

		// Token: 0x0400132F RID: 4911
		public List<RayTracingInstanceCullingTest> instanceTestArray = new List<RayTracingInstanceCullingTest>();

		// Token: 0x04001330 RID: 4912
		internal Plane[] rtCullingPlaneArray = new Plane[6];

		// Token: 0x04001331 RID: 4913
		private RayTracingInstanceCullingTest ShT_CT;

		// Token: 0x04001332 RID: 4914
		private RayTracingInstanceCullingTest ShO_CT;

		// Token: 0x04001333 RID: 4915
		private RayTracingInstanceCullingTest AO_CT;

		// Token: 0x04001334 RID: 4916
		private RayTracingInstanceCullingTest Refl_CT;

		// Token: 0x04001335 RID: 4917
		private RayTracingInstanceCullingTest GI_CT;

		// Token: 0x04001336 RID: 4918
		private RayTracingInstanceCullingTest RR_CT;

		// Token: 0x04001337 RID: 4919
		private RayTracingInstanceCullingTest SSS_CT;

		// Token: 0x04001338 RID: 4920
		private RayTracingInstanceCullingTest PT_CT;

		// Token: 0x04001339 RID: 4921
		public bool transformsDirty;

		// Token: 0x0400133A RID: 4922
		public bool materialsDirty;
	}
}
