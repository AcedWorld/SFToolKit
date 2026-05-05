using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001E0 RID: 480
	internal class HDRISkyRenderer : SkyRenderer
	{
		// Token: 0x06000E83 RID: 3715 RVA: 0x00073035 File Offset: 0x00071235
		public HDRISkyRenderer()
		{
			this.SupportDynamicSunLight = false;
		}

		// Token: 0x06000E84 RID: 3716 RVA: 0x00073050 File Offset: 0x00071250
		public override void Build()
		{
			this.m_SkyHDRIMaterial = CoreUtils.CreateEngineMaterial(HDRenderPipelineGlobalSettings.instance.renderPipelineResources.shaders.hdriSkyPS);
			this.m_RenderCubemapID = this.m_SkyHDRIMaterial.FindPass("FragBaking");
			this.m_RenderFullscreenSkyID = this.m_SkyHDRIMaterial.FindPass("FragRender");
			this.m_RenderFullscreenSkyWithBackplateID = this.m_SkyHDRIMaterial.FindPass("FragRenderBackplate");
			this.m_RenderDepthOnlyFullscreenSkyWithBackplateID = this.m_SkyHDRIMaterial.FindPass("FragRenderBackplateDepth");
		}

		// Token: 0x06000E85 RID: 3717 RVA: 0x000730D4 File Offset: 0x000712D4
		public override void Cleanup()
		{
			CoreUtils.Destroy(this.m_SkyHDRIMaterial);
		}

		// Token: 0x06000E86 RID: 3718 RVA: 0x000730E1 File Offset: 0x000712E1
		private void GetParameters(out float intensity, out float phi, out float backplatePhi, BuiltinSkyParameters builtinParams, HDRISky hdriSky)
		{
			intensity = SkyRenderer.GetSkyIntensity(hdriSky, builtinParams.debugSettings);
			phi = -0.017453292f * hdriSky.rotation.value;
			backplatePhi = phi - 0.017453292f * hdriSky.plateRotation.value;
		}

		// Token: 0x06000E87 RID: 3719 RVA: 0x00073120 File Offset: 0x00071320
		private Vector4 GetBackplateParameters0(HDRISky hdriSky)
		{
			float num = Mathf.Abs(hdriSky.scale.value.x);
			float y = Mathf.Abs(hdriSky.scale.value.y);
			if (hdriSky.backplateType.value == BackplateType.Disc)
			{
				y = num;
			}
			return new Vector4(num, y, hdriSky.groundLevel.value, hdriSky.projectionDistance.value);
		}

		// Token: 0x06000E88 RID: 3720 RVA: 0x00073188 File Offset: 0x00071388
		private Vector4 GetBackplateParameters1(float backplatePhi, HDRISky hdriSky)
		{
			float x = 3f;
			float y = hdriSky.blendAmount.value / 100f;
			switch (hdriSky.backplateType.value)
			{
			case BackplateType.Disc:
				x = 0f;
				break;
			case BackplateType.Rectangle:
				x = 1f;
				break;
			case BackplateType.Ellipse:
				x = 2f;
				break;
			case BackplateType.Infinite:
				x = 3f;
				y = 0f;
				break;
			}
			return new Vector4(x, y, Mathf.Cos(backplatePhi), Mathf.Sin(backplatePhi));
		}

		// Token: 0x06000E89 RID: 3721 RVA: 0x00073208 File Offset: 0x00071408
		private Vector4 GetBackplateParameters2(HDRISky hdriSky)
		{
			float f = -0.017453292f * hdriSky.plateTexRotation.value;
			return new Vector4(Mathf.Cos(f), Mathf.Sin(f), hdriSky.plateTexOffset.value.x, hdriSky.plateTexOffset.value.y);
		}

		// Token: 0x06000E8A RID: 3722 RVA: 0x00073258 File Offset: 0x00071458
		public override bool RequiresPreRender(SkySettings skySettings)
		{
			HDRISky hdrisky = skySettings as HDRISky;
			return hdrisky != null && hdrisky.enableBackplate.value;
		}

		// Token: 0x06000E8B RID: 3723 RVA: 0x00073284 File Offset: 0x00071484
		public override void PreRenderSky(BuiltinSkyParameters builtinParams)
		{
			HDRISky hdrisky = builtinParams.skySettings as HDRISky;
			float x;
			float f;
			float num;
			this.GetParameters(out x, out f, out num, builtinParams, hdrisky);
			using (new ProfilingScope(builtinParams.commandBuffer, ProfilingSampler.Get<HDProfileId>(HDProfileId.PreRenderSky)))
			{
				this.m_SkyHDRIMaterial.SetTexture(HDShaderIDs._Cubemap, hdrisky.hdriSky.value);
				this.m_SkyHDRIMaterial.SetVector(HDShaderIDs._SkyParam, new Vector4(x, 0f, Mathf.Cos(f), Mathf.Sin(f)));
				this.m_SkyHDRIMaterial.SetVector(HDShaderIDs._BackplateParameters0, this.GetBackplateParameters0(hdrisky));
				this.m_PropertyBlock.SetMatrix(HDShaderIDs._PixelCoordToViewDirWS, builtinParams.pixelCoordToViewDirMatrix);
				CoreUtils.DrawFullScreen(builtinParams.commandBuffer, this.m_SkyHDRIMaterial, this.m_PropertyBlock, this.m_RenderDepthOnlyFullscreenSkyWithBackplateID);
			}
		}

		// Token: 0x06000E8C RID: 3724 RVA: 0x0007336C File Offset: 0x0007156C
		public override void RenderSky(BuiltinSkyParameters builtinParams, bool renderForCubemap, bool renderSunDisk)
		{
			HDRISky hdrisky = builtinParams.skySettings as HDRISky;
			float x;
			float f;
			float backplatePhi;
			this.GetParameters(out x, out f, out backplatePhi, builtinParams, hdrisky);
			int shaderPassId;
			if (renderForCubemap)
			{
				shaderPassId = this.m_RenderCubemapID;
			}
			else if (!hdrisky.enableBackplate.value)
			{
				shaderPassId = this.m_RenderFullscreenSkyID;
			}
			else
			{
				shaderPassId = this.m_RenderFullscreenSkyWithBackplateID;
			}
			bool flag = builtinParams.hdCamera.frameSettings.IsEnabled(FrameSettingsField.FPTLForForwardOpaque);
			CoreUtils.SetKeyword(builtinParams.commandBuffer, "USE_FPTL_LIGHTLIST", flag);
			CoreUtils.SetKeyword(builtinParams.commandBuffer, "USE_CLUSTERED_LIGHTLIST", !flag);
			CoreUtils.SetKeyword(this.m_SkyHDRIMaterial, "DISTORTION_PROCEDURAL", hdrisky.distortionMode.value == HDRISky.DistortionMode.Procedural);
			CoreUtils.SetKeyword(this.m_SkyHDRIMaterial, "DISTORTION_FLOWMAP", hdrisky.distortionMode.value == HDRISky.DistortionMode.Flowmap);
			if (hdrisky.distortionMode.value != HDRISky.DistortionMode.None)
			{
				if (hdrisky.distortionMode.value == HDRISky.DistortionMode.Flowmap)
				{
					this.m_SkyHDRIMaterial.SetTexture(HDShaderIDs._Flowmap, hdrisky.flowmap.value);
				}
				HDCamera hdCamera = builtinParams.hdCamera;
				float f2 = 0.017453292f * (hdrisky.scrollOrientation.GetValue(hdCamera) - hdrisky.rotation.value);
				Vector4 value = new Vector4((hdrisky.upperHemisphereOnly.value || hdrisky.distortionMode.value == HDRISky.DistortionMode.Procedural) ? 1f : 0f, this.scrollFactor / 200f, -Mathf.Cos(f2), -Mathf.Sin(f2));
				this.m_SkyHDRIMaterial.SetVector(HDShaderIDs._FlowmapParam, value);
				this.scrollFactor += (hdCamera.animateMaterials ? (hdrisky.scrollSpeed.GetValue(hdCamera) * (hdCamera.time - this.lastTime) * 0.01f) : 0f);
				this.lastTime = hdCamera.time;
			}
			this.m_SkyHDRIMaterial.SetTexture(HDShaderIDs._Cubemap, hdrisky.hdriSky.value);
			this.m_SkyHDRIMaterial.SetVector(HDShaderIDs._SkyParam, new Vector4(x, 0f, Mathf.Cos(f), Mathf.Sin(f)));
			this.m_SkyHDRIMaterial.SetVector(HDShaderIDs._BackplateParameters0, this.GetBackplateParameters0(hdrisky));
			this.m_SkyHDRIMaterial.SetVector(HDShaderIDs._BackplateParameters1, this.GetBackplateParameters1(backplatePhi, hdrisky));
			this.m_SkyHDRIMaterial.SetVector(HDShaderIDs._BackplateParameters2, this.GetBackplateParameters2(hdrisky));
			this.m_SkyHDRIMaterial.SetColor(HDShaderIDs._BackplateShadowTint, hdrisky.shadowTint.value);
			uint num = 0U;
			if (hdrisky.pointLightShadow.value)
			{
				num |= 4096U;
			}
			if (hdrisky.dirLightShadow.value)
			{
				num |= 16384U;
			}
			if (hdrisky.rectLightShadow.value)
			{
				num |= 8192U;
			}
			this.m_SkyHDRIMaterial.SetInt(HDShaderIDs._BackplateShadowFilter, (int)num);
			this.m_PropertyBlock.SetMatrix(HDShaderIDs._PixelCoordToViewDirWS, builtinParams.pixelCoordToViewDirMatrix);
			CoreUtils.DrawFullScreen(builtinParams.commandBuffer, this.m_SkyHDRIMaterial, this.m_PropertyBlock, shaderPassId);
		}

		// Token: 0x040016E3 RID: 5859
		private Material m_SkyHDRIMaterial;

		// Token: 0x040016E4 RID: 5860
		private MaterialPropertyBlock m_PropertyBlock = new MaterialPropertyBlock();

		// Token: 0x040016E5 RID: 5861
		private float scrollFactor;

		// Token: 0x040016E6 RID: 5862
		private float lastTime;

		// Token: 0x040016E7 RID: 5863
		private int m_RenderCubemapID;

		// Token: 0x040016E8 RID: 5864
		private int m_RenderFullscreenSkyID;

		// Token: 0x040016E9 RID: 5865
		private int m_RenderFullscreenSkyWithBackplateID;

		// Token: 0x040016EA RID: 5866
		private int m_RenderDepthOnlyFullscreenSkyWithBackplateID;
	}
}
