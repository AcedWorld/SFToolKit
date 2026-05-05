using System;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000198 RID: 408
	public struct AOVRequestData
	{
		// Token: 0x06000C9E RID: 3230 RVA: 0x000688FC File Offset: 0x00066AFC
		public static AOVRequestData NewDefault()
		{
			return new AOVRequestData
			{
				m_Settings = AOVRequest.NewDefault(),
				m_RequestedAOVBuffers = new AOVBuffers[0],
				m_Callback = null
			};
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000C9F RID: 3231 RVA: 0x00068933 File Offset: 0x00066B33
		public bool isValid
		{
			get
			{
				return (this.m_RequestedAOVBuffers != null || this.m_CustomPassAOVBuffers != null) && (this.m_Callback != null || this.m_CallbackEx != null);
			}
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000CA0 RID: 3232 RVA: 0x0006895A File Offset: 0x00066B5A
		public bool overrideRenderFormat
		{
			get
			{
				return this.m_Settings.overrideRenderFormat;
			}
		}

		// Token: 0x06000CA1 RID: 3233 RVA: 0x00068967 File Offset: 0x00066B67
		public AOVRequestData(AOVRequest settings, AOVRequestBufferAllocator bufferAllocator, List<GameObject> lightFilter, AOVBuffers[] requestedAOVBuffers, FramePassCallback callback)
		{
			this.m_Settings = settings;
			this.m_BufferAllocator = bufferAllocator;
			this.m_RequestedAOVBuffers = requestedAOVBuffers;
			this.m_LightFilter = lightFilter;
			this.m_Callback = callback;
			this.m_CallbackEx = null;
			this.m_CustomPassAOVBuffers = null;
			this.m_CustomPassBufferAllocator = null;
		}

		// Token: 0x06000CA2 RID: 3234 RVA: 0x000689A3 File Offset: 0x00066BA3
		public AOVRequestData(AOVRequest settings, AOVRequestBufferAllocator bufferAllocator, List<GameObject> lightFilter, AOVBuffers[] requestedAOVBuffers, CustomPassAOVBuffers[] customPassAOVBuffers, AOVRequestCustomPassBufferAllocator customPassBufferAllocator, FramePassCallbackEx callback)
		{
			this.m_Settings = settings;
			this.m_BufferAllocator = bufferAllocator;
			this.m_RequestedAOVBuffers = requestedAOVBuffers;
			this.m_CustomPassAOVBuffers = customPassAOVBuffers;
			this.m_CustomPassBufferAllocator = customPassBufferAllocator;
			this.m_LightFilter = lightFilter;
			this.m_Callback = null;
			this.m_CallbackEx = callback;
		}

		// Token: 0x06000CA3 RID: 3235 RVA: 0x000689E4 File Offset: 0x00066BE4
		public void AllocateTargetTexturesIfRequired(ref List<RTHandle> textures)
		{
			if (!this.isValid || textures == null)
			{
				return;
			}
			textures.Clear();
			if (this.m_RequestedAOVBuffers != null)
			{
				foreach (AOVBuffers aovBufferId in this.m_RequestedAOVBuffers)
				{
					textures.Add(this.m_BufferAllocator(aovBufferId));
				}
			}
		}

		// Token: 0x06000CA4 RID: 3236 RVA: 0x00068A3C File Offset: 0x00066C3C
		public void AllocateTargetTexturesIfRequired(ref List<RTHandle> textures, ref List<RTHandle> customPassTextures)
		{
			if (!this.isValid || textures == null)
			{
				return;
			}
			textures.Clear();
			customPassTextures.Clear();
			if (this.m_RequestedAOVBuffers != null)
			{
				foreach (AOVBuffers aovBufferId in this.m_RequestedAOVBuffers)
				{
					RTHandle rthandle = this.m_BufferAllocator(aovBufferId);
					textures.Add(rthandle);
					if (rthandle == null)
					{
						Debug.LogError("Allocation for requested AOVBuffers ID: " + aovBufferId.ToString() + " have fail. Please ensure the callback allocator do the correct allocation.");
					}
				}
			}
			if (this.m_CustomPassAOVBuffers != null)
			{
				foreach (CustomPassAOVBuffers customPassAOVBuffers2 in this.m_CustomPassAOVBuffers)
				{
					RTHandle rthandle2 = this.m_CustomPassBufferAllocator(customPassAOVBuffers2);
					customPassTextures.Add(rthandle2);
					if (rthandle2 == null)
					{
						Debug.LogError("Allocation for requested AOVBuffers ID: " + customPassAOVBuffers2.ToString() + " have fail. Please ensure the callback for custom pass allocator do the correct allocation.");
					}
				}
			}
		}

		// Token: 0x06000CA5 RID: 3237 RVA: 0x00068B1C File Offset: 0x00066D1C
		internal void OverrideBufferFormatForAOVs(ref GraphicsFormat format, List<RTHandle> aovBuffers)
		{
			if (this.m_RequestedAOVBuffers == null || aovBuffers.Count == 0)
			{
				return;
			}
			int num = Array.IndexOf<AOVBuffers>(this.m_RequestedAOVBuffers, AOVBuffers.Color);
			if (num < 0)
			{
				num = Array.IndexOf<AOVBuffers>(this.m_RequestedAOVBuffers, AOVBuffers.Output);
			}
			if (num >= 0)
			{
				format = aovBuffers[num].rt.graphicsFormat;
			}
		}

		// Token: 0x06000CA6 RID: 3238 RVA: 0x00068B70 File Offset: 0x00066D70
		internal void PushCameraTexture(RenderGraph renderGraph, AOVBuffers aovBufferId, HDCamera camera, TextureHandle source, List<RTHandle> targets)
		{
			if (!this.isValid || this.m_RequestedAOVBuffers == null)
			{
				return;
			}
			int num = Array.IndexOf<AOVBuffers>(this.m_RequestedAOVBuffers, aovBufferId);
			if (num == -1)
			{
				return;
			}
			AOVRequestData.PushCameraTexturePassData pushCameraTexturePassData;
			using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<AOVRequestData.PushCameraTexturePassData>("Push AOV Camera Texture", out pushCameraTexturePassData, ProfilingSampler.Get<HDProfileId>(HDProfileId.AOVOutput + (int)aovBufferId)))
			{
				pushCameraTexturePassData.source = renderGraphBuilder.ReadTexture(source);
				pushCameraTexturePassData.target = targets[num];
				renderGraphBuilder.SetRenderFunc<AOVRequestData.PushCameraTexturePassData>(delegate(AOVRequestData.PushCameraTexturePassData data, RenderGraphContext ctx)
				{
					HDUtils.BlitCameraTexture(ctx.cmd, data.source, data.target, 0f, false);
				});
			}
		}

		// Token: 0x06000CA7 RID: 3239 RVA: 0x00068C20 File Offset: 0x00066E20
		internal void PushCustomPassTexture(RenderGraph renderGraph, CustomPassInjectionPoint injectionPoint, TextureHandle cameraSource, Lazy<RTHandle> customPassSource, List<RTHandle> targets)
		{
			if (!this.isValid || this.m_CustomPassAOVBuffers == null)
			{
				return;
			}
			int num = -1;
			for (int i = 0; i < this.m_CustomPassAOVBuffers.Length; i++)
			{
				if (this.m_CustomPassAOVBuffers[i].injectionPoint == injectionPoint)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				return;
			}
			AOVRequestData.PushCustomPassTexturePassData pushCustomPassTexturePassData;
			using (RenderGraphBuilder renderGraphBuilder = renderGraph.AddRenderPass<AOVRequestData.PushCustomPassTexturePassData>("Push Custom Pass Texture", out pushCustomPassTexturePassData))
			{
				if (this.m_CustomPassAOVBuffers[num].outputType == CustomPassAOVBuffers.OutputType.Camera)
				{
					pushCustomPassTexturePassData.source = renderGraphBuilder.ReadTexture(cameraSource);
					pushCustomPassTexturePassData.customPassSource = null;
				}
				else
				{
					pushCustomPassTexturePassData.customPassSource = customPassSource.Value;
				}
				pushCustomPassTexturePassData.target = targets[num];
				renderGraphBuilder.SetRenderFunc<AOVRequestData.PushCustomPassTexturePassData>(delegate(AOVRequestData.PushCustomPassTexturePassData data, RenderGraphContext ctx)
				{
					if (data.customPassSource != null)
					{
						HDUtils.BlitCameraTexture(ctx.cmd, data.customPassSource, data.target, 0f, false);
						return;
					}
					HDUtils.BlitCameraTexture(ctx.cmd, data.source, data.target, 0f, false);
				});
			}
		}

		// Token: 0x06000CA8 RID: 3240 RVA: 0x00068D04 File Offset: 0x00066F04
		public void Execute(CommandBuffer cmd, List<RTHandle> framePassTextures, RenderOutputProperties outputProperties)
		{
			if (!this.isValid)
			{
				return;
			}
			this.m_Callback(cmd, framePassTextures, outputProperties);
		}

		// Token: 0x06000CA9 RID: 3241 RVA: 0x00068D1D File Offset: 0x00066F1D
		public void Execute(CommandBuffer cmd, List<RTHandle> framePassTextures, List<RTHandle> customPassTextures, RenderOutputProperties outputProperties)
		{
			if (!this.isValid)
			{
				return;
			}
			if (this.m_CallbackEx != null)
			{
				this.m_CallbackEx(cmd, framePassTextures, customPassTextures, outputProperties);
				return;
			}
			this.m_Callback(cmd, framePassTextures, outputProperties);
		}

		// Token: 0x06000CAA RID: 3242 RVA: 0x00068D50 File Offset: 0x00066F50
		public void SetupDebugData(ref DebugDisplaySettings debugDisplaySettings)
		{
			if (!this.isValid)
			{
				return;
			}
			debugDisplaySettings = new DebugDisplaySettings();
			this.m_Settings.FillDebugData(debugDisplaySettings);
		}

		// Token: 0x06000CAB RID: 3243 RVA: 0x00068D6F File Offset: 0x00066F6F
		public bool IsLightEnabled(GameObject gameObject)
		{
			return this.m_LightFilter == null || this.m_LightFilter.Contains(gameObject);
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000CAC RID: 3244 RVA: 0x00068D87 File Offset: 0x00066F87
		internal bool hasLightFilter
		{
			get
			{
				return this.m_LightFilter != null;
			}
		}

		// Token: 0x06000CAD RID: 3245 RVA: 0x00068D94 File Offset: 0x00066F94
		internal int GetHash()
		{
			int num = this.m_Settings.GetHashCode();
			if (this.m_LightFilter != null)
			{
				foreach (GameObject gameObject in this.m_LightFilter)
				{
					num += gameObject.GetHashCode();
				}
			}
			return num;
		}

		// Token: 0x06000CAE RID: 3246 RVA: 0x00068E04 File Offset: 0x00067004
		internal bool HasSameSettings(AOVRequestData other)
		{
			return !(this.m_Settings != other.m_Settings) && (this.m_LightFilter == null || this.m_LightFilter.Equals(other.m_LightFilter));
		}

		// Token: 0x040013B9 RID: 5049
		[Obsolete("Since 2019.3, use AOVRequestData.NewDefault() instead.")]
		public static readonly AOVRequestData @default = default(AOVRequestData);

		// Token: 0x040013BA RID: 5050
		public static readonly AOVRequestData defaultAOVRequestDataNonAlloc = AOVRequestData.NewDefault();

		// Token: 0x040013BB RID: 5051
		private AOVRequest m_Settings;

		// Token: 0x040013BC RID: 5052
		private AOVBuffers[] m_RequestedAOVBuffers;

		// Token: 0x040013BD RID: 5053
		private CustomPassAOVBuffers[] m_CustomPassAOVBuffers;

		// Token: 0x040013BE RID: 5054
		private FramePassCallback m_Callback;

		// Token: 0x040013BF RID: 5055
		private FramePassCallbackEx m_CallbackEx;

		// Token: 0x040013C0 RID: 5056
		private readonly AOVRequestBufferAllocator m_BufferAllocator;

		// Token: 0x040013C1 RID: 5057
		private readonly AOVRequestCustomPassBufferAllocator m_CustomPassBufferAllocator;

		// Token: 0x040013C2 RID: 5058
		private List<GameObject> m_LightFilter;

		// Token: 0x020003DC RID: 988
		private class PushCameraTexturePassData
		{
			// Token: 0x0400282C RID: 10284
			public TextureHandle source;

			// Token: 0x0400282D RID: 10285
			public RTHandle target;
		}

		// Token: 0x020003DD RID: 989
		private class PushCustomPassTexturePassData
		{
			// Token: 0x0400282E RID: 10286
			public TextureHandle source;

			// Token: 0x0400282F RID: 10287
			public RTHandle customPassSource;

			// Token: 0x04002830 RID: 10288
			public RTHandle target;
		}
	}
}
