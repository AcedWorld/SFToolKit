using System;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering
{
	// Token: 0x020000BE RID: 190
	public class RTHandleSystem : IDisposable
	{
		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060005BB RID: 1467 RVA: 0x0001CBD9 File Offset: 0x0001ADD9
		public RTHandleProperties rtHandleProperties
		{
			get
			{
				return this.m_RTHandleProperties;
			}
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x0001CBE1 File Offset: 0x0001ADE1
		public RTHandleSystem()
		{
			this.m_AutoSizedRTs = new HashSet<RTHandle>();
			this.m_ResizeOnDemandRTs = new HashSet<RTHandle>();
			this.m_MaxWidths = 1;
			this.m_MaxHeights = 1;
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x0001CC0D File Offset: 0x0001AE0D
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x0001CC18 File Offset: 0x0001AE18
		public void Initialize(int width, int height)
		{
			if (this.m_AutoSizedRTs.Count != 0)
			{
				string arg = "Unreleased RTHandles:";
				foreach (RTHandle rthandle in this.m_AutoSizedRTs)
				{
					arg = string.Format("{0}\n    {1}", arg, rthandle.name);
				}
				Debug.LogError(string.Format("RTHandle.Initialize should only be called once before allocating any Render Texture. This may be caused by an unreleased RTHandle resource.\n{0}\n", arg));
			}
			this.m_MaxWidths = width;
			this.m_MaxHeights = height;
			this.m_HardwareDynamicResRequested = DynamicResolutionHandler.instance.RequestsHardwareDynamicResolution();
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0001CCB8 File Offset: 0x0001AEB8
		[Obsolete("useLegacyDynamicResControl is deprecated. Please use SetHardwareDynamicResolutionState() instead.")]
		public void Initialize(int width, int height, bool useLegacyDynamicResControl = false)
		{
			this.Initialize(width, height);
			if (useLegacyDynamicResControl)
			{
				this.m_HardwareDynamicResRequested = true;
			}
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x0001CCCC File Offset: 0x0001AECC
		public void Release(RTHandle rth)
		{
			if (rth != null)
			{
				rth.Release();
			}
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x0001CCD7 File Offset: 0x0001AED7
		internal void Remove(RTHandle rth)
		{
			this.m_AutoSizedRTs.Remove(rth);
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x0001CCE6 File Offset: 0x0001AEE6
		public void ResetReferenceSize(int width, int height)
		{
			this.m_MaxWidths = width;
			this.m_MaxHeights = height;
			this.SetReferenceSize(width, height, true);
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x0001CCFF File Offset: 0x0001AEFF
		public void SetReferenceSize(int width, int height)
		{
			this.SetReferenceSize(width, height, false);
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x0001CD0C File Offset: 0x0001AF0C
		public void SetReferenceSize(int width, int height, bool reset)
		{
			this.m_RTHandleProperties.previousViewportSize = this.m_RTHandleProperties.currentViewportSize;
			this.m_RTHandleProperties.previousRenderTargetSize = this.m_RTHandleProperties.currentRenderTargetSize;
			Vector2 b = new Vector2((float)this.GetMaxWidth(), (float)this.GetMaxHeight());
			width = Mathf.Max(width, 1);
			height = Mathf.Max(height, 1);
			bool flag = width > this.GetMaxWidth() || height > this.GetMaxHeight() || reset;
			if (flag)
			{
				this.Resize(width, height, flag);
			}
			this.m_RTHandleProperties.currentViewportSize = new Vector2Int(width, height);
			this.m_RTHandleProperties.currentRenderTargetSize = new Vector2Int(this.GetMaxWidth(), this.GetMaxHeight());
			if (this.m_RTHandleProperties.previousViewportSize.x == 0)
			{
				this.m_RTHandleProperties.previousViewportSize = this.m_RTHandleProperties.currentViewportSize;
				this.m_RTHandleProperties.previousRenderTargetSize = this.m_RTHandleProperties.currentRenderTargetSize;
				b = new Vector2((float)this.GetMaxWidth(), (float)this.GetMaxHeight());
			}
			Vector2 vector = this.CalculateRatioAgainstMaxSize(this.m_RTHandleProperties.currentViewportSize);
			if (DynamicResolutionHandler.instance.HardwareDynamicResIsEnabled() && this.m_HardwareDynamicResRequested)
			{
				this.m_RTHandleProperties.rtHandleScale = new Vector4(vector.x, vector.y, this.m_RTHandleProperties.rtHandleScale.x, this.m_RTHandleProperties.rtHandleScale.y);
				return;
			}
			Vector2 vector2 = this.m_RTHandleProperties.previousViewportSize / b;
			this.m_RTHandleProperties.rtHandleScale = new Vector4(vector.x, vector.y, vector2.x, vector2.y);
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x0001CEB4 File Offset: 0x0001B0B4
		internal Vector2 CalculateRatioAgainstMaxSize(in Vector2Int viewportSize)
		{
			Vector2 vector = new Vector2((float)this.GetMaxWidth(), (float)this.GetMaxHeight());
			if (DynamicResolutionHandler.instance.HardwareDynamicResIsEnabled() && this.m_HardwareDynamicResRequested && viewportSize != DynamicResolutionHandler.instance.finalViewport)
			{
				Vector2 scales = viewportSize / DynamicResolutionHandler.instance.finalViewport;
				vector = DynamicResolutionHandler.instance.ApplyScalesOnSize(new Vector2Int(this.GetMaxWidth(), this.GetMaxHeight()), scales);
			}
			Vector2Int vector2Int = viewportSize;
			float x = (float)vector2Int.x / vector.x;
			vector2Int = viewportSize;
			return new Vector2(x, (float)vector2Int.y / vector.y);
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x0001CF74 File Offset: 0x0001B174
		public void SetHardwareDynamicResolutionState(bool enableHWDynamicRes)
		{
			if (enableHWDynamicRes != this.m_HardwareDynamicResRequested)
			{
				this.m_HardwareDynamicResRequested = enableHWDynamicRes;
				Array.Resize<RTHandle>(ref this.m_AutoSizedRTsArray, this.m_AutoSizedRTs.Count);
				this.m_AutoSizedRTs.CopyTo(this.m_AutoSizedRTsArray);
				int i = 0;
				int num = this.m_AutoSizedRTsArray.Length;
				while (i < num)
				{
					RTHandle rthandle = this.m_AutoSizedRTsArray[i];
					RenderTexture rt = rthandle.m_RT;
					if (rt)
					{
						rt.Release();
						rt.useDynamicScale = (this.m_HardwareDynamicResRequested && rthandle.m_EnableHWDynamicScale);
						rt.Create();
					}
					i++;
				}
			}
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x0001D00C File Offset: 0x0001B20C
		internal void SwitchResizeMode(RTHandle rth, RTHandleSystem.ResizeMode mode)
		{
			if (!rth.useScaling)
			{
				return;
			}
			if (mode != RTHandleSystem.ResizeMode.Auto)
			{
				if (mode == RTHandleSystem.ResizeMode.OnDemand)
				{
					this.m_AutoSizedRTs.Remove(rth);
					this.m_ResizeOnDemandRTs.Add(rth);
					return;
				}
			}
			else
			{
				if (this.m_ResizeOnDemandRTs.Contains(rth))
				{
					this.DemandResize(rth);
				}
				this.m_ResizeOnDemandRTs.Remove(rth);
				this.m_AutoSizedRTs.Add(rth);
			}
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x0001D074 File Offset: 0x0001B274
		private void DemandResize(RTHandle rth)
		{
			RenderTexture rt = rth.m_RT;
			rth.referenceSize = new Vector2Int(this.m_MaxWidths, this.m_MaxHeights);
			Vector2Int rhs = rth.GetScaledSize(rth.referenceSize);
			rhs = Vector2Int.Max(Vector2Int.one, rhs);
			if (rt.width != rhs.x || rt.height != rhs.y)
			{
				rt.Release();
				rt.width = rhs.x;
				rt.height = rhs.y;
				rt.name = CoreUtils.GetRenderTargetAutoName(rt.width, rt.height, rt.volumeDepth, rt.graphicsFormat, rt.dimension, rth.m_Name, rt.useMipMap, rth.m_EnableMSAA, (MSAASamples)rt.antiAliasing, rt.useDynamicScale);
				rt.Create();
			}
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x0001D14C File Offset: 0x0001B34C
		public int GetMaxWidth()
		{
			return this.m_MaxWidths;
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x0001D154 File Offset: 0x0001B354
		public int GetMaxHeight()
		{
			return this.m_MaxHeights;
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0001D15C File Offset: 0x0001B35C
		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				Array.Resize<RTHandle>(ref this.m_AutoSizedRTsArray, this.m_AutoSizedRTs.Count);
				this.m_AutoSizedRTs.CopyTo(this.m_AutoSizedRTsArray);
				int i = 0;
				int num = this.m_AutoSizedRTsArray.Length;
				while (i < num)
				{
					RTHandle rth = this.m_AutoSizedRTsArray[i];
					this.Release(rth);
					i++;
				}
				this.m_AutoSizedRTs.Clear();
				Array.Resize<RTHandle>(ref this.m_AutoSizedRTsArray, this.m_ResizeOnDemandRTs.Count);
				this.m_ResizeOnDemandRTs.CopyTo(this.m_AutoSizedRTsArray);
				int j = 0;
				int num2 = this.m_AutoSizedRTsArray.Length;
				while (j < num2)
				{
					RTHandle rth2 = this.m_AutoSizedRTsArray[j];
					this.Release(rth2);
					j++;
				}
				this.m_ResizeOnDemandRTs.Clear();
				this.m_AutoSizedRTsArray = null;
			}
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x0001D228 File Offset: 0x0001B428
		private void Resize(int width, int height, bool sizeChanged)
		{
			this.m_MaxWidths = Math.Max(width, this.m_MaxWidths);
			this.m_MaxHeights = Math.Max(height, this.m_MaxHeights);
			Vector2Int vector2Int = new Vector2Int(this.m_MaxWidths, this.m_MaxHeights);
			Array.Resize<RTHandle>(ref this.m_AutoSizedRTsArray, this.m_AutoSizedRTs.Count);
			this.m_AutoSizedRTs.CopyTo(this.m_AutoSizedRTsArray);
			int i = 0;
			int num = this.m_AutoSizedRTsArray.Length;
			while (i < num)
			{
				RTHandle rthandle = this.m_AutoSizedRTsArray[i];
				rthandle.referenceSize = vector2Int;
				RenderTexture rt = rthandle.m_RT;
				rt.Release();
				Vector2Int scaledSize = rthandle.GetScaledSize(vector2Int);
				rt.width = Mathf.Max(scaledSize.x, 1);
				rt.height = Mathf.Max(scaledSize.y, 1);
				rt.name = CoreUtils.GetRenderTargetAutoName(rt.width, rt.height, rt.volumeDepth, rt.graphicsFormat, rt.dimension, rthandle.m_Name, rt.useMipMap, rthandle.m_EnableMSAA, (MSAASamples)rt.antiAliasing, rt.useDynamicScale);
				rt.Create();
				i++;
			}
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x0001D358 File Offset: 0x0001B558
		public RTHandle Alloc(int width, int height, int slices = 1, DepthBits depthBufferBits = DepthBits.None, GraphicsFormat colorFormat = GraphicsFormat.R8G8B8A8_SRGB, FilterMode filterMode = FilterMode.Point, TextureWrapMode wrapMode = TextureWrapMode.Repeat, TextureDimension dimension = TextureDimension.Tex2D, bool enableRandomWrite = false, bool useMipMap = false, bool autoGenerateMips = true, bool isShadowMap = false, int anisoLevel = 1, float mipMapBias = 0f, MSAASamples msaaSamples = MSAASamples.None, bool bindTextureMS = false, bool useDynamicScale = false, RenderTextureMemoryless memoryless = RenderTextureMemoryless.None, VRTextureUsage vrUsage = VRTextureUsage.None, string name = "")
		{
			return this.Alloc(width, height, wrapMode, wrapMode, wrapMode, slices, depthBufferBits, colorFormat, filterMode, dimension, enableRandomWrite, useMipMap, autoGenerateMips, isShadowMap, anisoLevel, mipMapBias, msaaSamples, bindTextureMS, useDynamicScale, memoryless, vrUsage, name);
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x0001D394 File Offset: 0x0001B594
		public RTHandle Alloc(int width, int height, TextureWrapMode wrapModeU, TextureWrapMode wrapModeV, TextureWrapMode wrapModeW = TextureWrapMode.Repeat, int slices = 1, DepthBits depthBufferBits = DepthBits.None, GraphicsFormat colorFormat = GraphicsFormat.R8G8B8A8_SRGB, FilterMode filterMode = FilterMode.Point, TextureDimension dimension = TextureDimension.Tex2D, bool enableRandomWrite = false, bool useMipMap = false, bool autoGenerateMips = true, bool isShadowMap = false, int anisoLevel = 1, float mipMapBias = 0f, MSAASamples msaaSamples = MSAASamples.None, bool bindTextureMS = false, bool useDynamicScale = false, RenderTextureMemoryless memoryless = RenderTextureMemoryless.None, VRTextureUsage vrUsage = VRTextureUsage.None, string name = "")
		{
			bool flag = msaaSamples != MSAASamples.None;
			if (!flag && bindTextureMS)
			{
				Debug.LogWarning("RTHandle allocated without MSAA but with bindMS set to true, forcing bindMS to false.");
				bindTextureMS = false;
			}
			RenderTexture renderTexture;
			if (isShadowMap || depthBufferBits != DepthBits.None)
			{
				RenderTextureFormat format = isShadowMap ? RenderTextureFormat.Shadowmap : RenderTextureFormat.Depth;
				GraphicsFormat stencilFormat = (!isShadowMap && SystemInfo.IsFormatSupported(GraphicsFormat.R8_UInt, FormatUsage.StencilSampling)) ? GraphicsFormat.R8_UInt : GraphicsFormat.None;
				renderTexture = new RenderTexture(width, height, (int)depthBufferBits, format, RenderTextureReadWrite.Linear)
				{
					hideFlags = HideFlags.HideAndDontSave,
					volumeDepth = slices,
					filterMode = filterMode,
					wrapModeU = wrapModeU,
					wrapModeV = wrapModeV,
					wrapModeW = wrapModeW,
					dimension = dimension,
					enableRandomWrite = enableRandomWrite,
					useMipMap = useMipMap,
					autoGenerateMips = autoGenerateMips,
					anisoLevel = anisoLevel,
					mipMapBias = mipMapBias,
					stencilFormat = stencilFormat,
					antiAliasing = (int)msaaSamples,
					bindTextureMS = bindTextureMS,
					useDynamicScale = (this.m_HardwareDynamicResRequested && useDynamicScale),
					memorylessMode = memoryless,
					vrUsage = vrUsage,
					name = CoreUtils.GetRenderTargetAutoName(width, height, slices, format, name, useMipMap, flag, msaaSamples)
				};
			}
			else
			{
				renderTexture = new RenderTexture(width, height, (int)depthBufferBits, colorFormat)
				{
					hideFlags = HideFlags.HideAndDontSave,
					volumeDepth = slices,
					filterMode = filterMode,
					wrapModeU = wrapModeU,
					wrapModeV = wrapModeV,
					wrapModeW = wrapModeW,
					dimension = dimension,
					enableRandomWrite = enableRandomWrite,
					useMipMap = useMipMap,
					autoGenerateMips = autoGenerateMips,
					anisoLevel = anisoLevel,
					mipMapBias = mipMapBias,
					antiAliasing = (int)msaaSamples,
					bindTextureMS = bindTextureMS,
					useDynamicScale = (this.m_HardwareDynamicResRequested && useDynamicScale),
					memorylessMode = memoryless,
					vrUsage = vrUsage,
					name = CoreUtils.GetRenderTargetAutoName(width, height, slices, colorFormat, dimension, name, useMipMap, flag, msaaSamples, useDynamicScale)
				};
			}
			renderTexture.Create();
			RTHandle rthandle = new RTHandle(this);
			rthandle.SetRenderTexture(renderTexture);
			rthandle.useScaling = false;
			rthandle.m_EnableRandomWrite = enableRandomWrite;
			rthandle.m_EnableMSAA = flag;
			rthandle.m_EnableHWDynamicScale = useDynamicScale;
			rthandle.m_Name = name;
			rthandle.referenceSize = new Vector2Int(width, height);
			return rthandle;
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x0001D5A4 File Offset: 0x0001B7A4
		public RTHandle Alloc(Vector2 scaleFactor, int slices = 1, DepthBits depthBufferBits = DepthBits.None, GraphicsFormat colorFormat = GraphicsFormat.R8G8B8A8_SRGB, FilterMode filterMode = FilterMode.Point, TextureWrapMode wrapMode = TextureWrapMode.Repeat, TextureDimension dimension = TextureDimension.Tex2D, bool enableRandomWrite = false, bool useMipMap = false, bool autoGenerateMips = true, bool isShadowMap = false, int anisoLevel = 1, float mipMapBias = 0f, MSAASamples msaaSamples = MSAASamples.None, bool bindTextureMS = false, bool useDynamicScale = false, RenderTextureMemoryless memoryless = RenderTextureMemoryless.None, VRTextureUsage vrUsage = VRTextureUsage.None, string name = "")
		{
			int num = Mathf.Max(Mathf.RoundToInt(scaleFactor.x * (float)this.GetMaxWidth()), 1);
			int num2 = Mathf.Max(Mathf.RoundToInt(scaleFactor.y * (float)this.GetMaxHeight()), 1);
			RTHandle rthandle = this.AllocAutoSizedRenderTexture(num, num2, slices, depthBufferBits, colorFormat, filterMode, wrapMode, dimension, enableRandomWrite, useMipMap, autoGenerateMips, isShadowMap, anisoLevel, mipMapBias, msaaSamples, bindTextureMS, useDynamicScale, memoryless, vrUsage, name);
			rthandle.referenceSize = new Vector2Int(num, num2);
			rthandle.scaleFactor = scaleFactor;
			return rthandle;
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x0001D624 File Offset: 0x0001B824
		public RTHandle Alloc(ScaleFunc scaleFunc, int slices = 1, DepthBits depthBufferBits = DepthBits.None, GraphicsFormat colorFormat = GraphicsFormat.R8G8B8A8_SRGB, FilterMode filterMode = FilterMode.Point, TextureWrapMode wrapMode = TextureWrapMode.Repeat, TextureDimension dimension = TextureDimension.Tex2D, bool enableRandomWrite = false, bool useMipMap = false, bool autoGenerateMips = true, bool isShadowMap = false, int anisoLevel = 1, float mipMapBias = 0f, MSAASamples msaaSamples = MSAASamples.None, bool bindTextureMS = false, bool useDynamicScale = false, RenderTextureMemoryless memoryless = RenderTextureMemoryless.None, VRTextureUsage vrUsage = VRTextureUsage.None, string name = "")
		{
			Vector2Int vector2Int = scaleFunc(new Vector2Int(this.GetMaxWidth(), this.GetMaxHeight()));
			int num = Mathf.Max(vector2Int.x, 1);
			int num2 = Mathf.Max(vector2Int.y, 1);
			RTHandle rthandle = this.AllocAutoSizedRenderTexture(num, num2, slices, depthBufferBits, colorFormat, filterMode, wrapMode, dimension, enableRandomWrite, useMipMap, autoGenerateMips, isShadowMap, anisoLevel, mipMapBias, msaaSamples, bindTextureMS, useDynamicScale, memoryless, vrUsage, name);
			rthandle.referenceSize = new Vector2Int(num, num2);
			rthandle.scaleFunc = scaleFunc;
			return rthandle;
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x0001D6A4 File Offset: 0x0001B8A4
		private RTHandle AllocAutoSizedRenderTexture(int width, int height, int slices, DepthBits depthBufferBits, GraphicsFormat colorFormat, FilterMode filterMode, TextureWrapMode wrapMode, TextureDimension dimension, bool enableRandomWrite, bool useMipMap, bool autoGenerateMips, bool isShadowMap, int anisoLevel, float mipMapBias, MSAASamples msaaSamples, bool bindTextureMS, bool useDynamicScale, RenderTextureMemoryless memoryless, VRTextureUsage vrUsage, string name)
		{
			bool flag = msaaSamples != MSAASamples.None;
			if (!flag && bindTextureMS)
			{
				Debug.LogWarning("RTHandle allocated without MSAA but with bindMS set to true, forcing bindMS to false.");
				bindTextureMS = false;
			}
			if (flag && enableRandomWrite)
			{
				Debug.LogWarning("RTHandle that is MSAA-enabled cannot allocate MSAA RT with 'enableRandomWrite = true'.");
				enableRandomWrite = false;
			}
			RenderTexture renderTexture;
			if (isShadowMap || depthBufferBits != DepthBits.None)
			{
				RenderTextureFormat format = isShadowMap ? RenderTextureFormat.Shadowmap : RenderTextureFormat.Depth;
				GraphicsFormat stencilFormat = (!isShadowMap && SystemInfo.IsFormatSupported(GraphicsFormat.R8_UInt, FormatUsage.StencilSampling)) ? GraphicsFormat.R8_UInt : GraphicsFormat.None;
				renderTexture = new RenderTexture(width, height, (int)depthBufferBits, format, RenderTextureReadWrite.Linear)
				{
					hideFlags = HideFlags.HideAndDontSave,
					volumeDepth = slices,
					filterMode = filterMode,
					wrapMode = wrapMode,
					dimension = dimension,
					enableRandomWrite = enableRandomWrite,
					useMipMap = useMipMap,
					autoGenerateMips = autoGenerateMips,
					anisoLevel = anisoLevel,
					mipMapBias = mipMapBias,
					antiAliasing = (int)msaaSamples,
					bindTextureMS = bindTextureMS,
					useDynamicScale = (this.m_HardwareDynamicResRequested && useDynamicScale),
					memorylessMode = memoryless,
					stencilFormat = stencilFormat,
					vrUsage = vrUsage,
					name = CoreUtils.GetRenderTargetAutoName(width, height, slices, colorFormat, dimension, name, useMipMap, flag, msaaSamples, useDynamicScale)
				};
			}
			else
			{
				renderTexture = new RenderTexture(width, height, (int)depthBufferBits, colorFormat)
				{
					hideFlags = HideFlags.HideAndDontSave,
					volumeDepth = slices,
					filterMode = filterMode,
					wrapMode = wrapMode,
					dimension = dimension,
					enableRandomWrite = enableRandomWrite,
					useMipMap = useMipMap,
					autoGenerateMips = autoGenerateMips,
					anisoLevel = anisoLevel,
					mipMapBias = mipMapBias,
					antiAliasing = (int)msaaSamples,
					bindTextureMS = bindTextureMS,
					useDynamicScale = (this.m_HardwareDynamicResRequested && useDynamicScale),
					memorylessMode = memoryless,
					vrUsage = vrUsage,
					name = CoreUtils.GetRenderTargetAutoName(width, height, slices, colorFormat, dimension, name, useMipMap, flag, msaaSamples, useDynamicScale)
				};
			}
			renderTexture.Create();
			RTHandle rthandle = new RTHandle(this);
			rthandle.SetRenderTexture(renderTexture);
			rthandle.m_EnableMSAA = flag;
			rthandle.m_EnableRandomWrite = enableRandomWrite;
			rthandle.useScaling = true;
			rthandle.m_EnableHWDynamicScale = useDynamicScale;
			rthandle.m_Name = name;
			this.m_AutoSizedRTs.Add(rthandle);
			return rthandle;
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x0001D8AC File Offset: 0x0001BAAC
		public RTHandle Alloc(RenderTexture texture)
		{
			RTHandle rthandle = new RTHandle(this);
			rthandle.SetRenderTexture(texture);
			rthandle.m_EnableMSAA = false;
			rthandle.m_EnableRandomWrite = false;
			rthandle.useScaling = false;
			rthandle.m_EnableHWDynamicScale = false;
			rthandle.m_Name = texture.name;
			return rthandle;
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x0001D8E3 File Offset: 0x0001BAE3
		public RTHandle Alloc(Texture texture)
		{
			RTHandle rthandle = new RTHandle(this);
			rthandle.SetTexture(texture);
			rthandle.m_EnableMSAA = false;
			rthandle.m_EnableRandomWrite = false;
			rthandle.useScaling = false;
			rthandle.m_EnableHWDynamicScale = false;
			rthandle.m_Name = texture.name;
			return rthandle;
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x0001D91A File Offset: 0x0001BB1A
		public RTHandle Alloc(RenderTargetIdentifier texture)
		{
			return this.Alloc(texture, "");
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x0001D928 File Offset: 0x0001BB28
		public RTHandle Alloc(RenderTargetIdentifier texture, string name)
		{
			RTHandle rthandle = new RTHandle(this);
			rthandle.SetTexture(texture);
			rthandle.m_EnableMSAA = false;
			rthandle.m_EnableRandomWrite = false;
			rthandle.useScaling = false;
			rthandle.m_EnableHWDynamicScale = false;
			rthandle.m_Name = name;
			return rthandle;
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x0001D95A File Offset: 0x0001BB5A
		private static RTHandle Alloc(RTHandle tex)
		{
			Debug.LogError("Allocation a RTHandle from another one is forbidden.");
			return null;
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x0001D968 File Offset: 0x0001BB68
		internal string DumpRTInfo()
		{
			string text = "";
			Array.Resize<RTHandle>(ref this.m_AutoSizedRTsArray, this.m_AutoSizedRTs.Count);
			this.m_AutoSizedRTs.CopyTo(this.m_AutoSizedRTsArray);
			int i = 0;
			int num = this.m_AutoSizedRTsArray.Length;
			while (i < num)
			{
				RenderTexture rt = this.m_AutoSizedRTsArray[i].rt;
				text = string.Format("{0}\nRT ({1})\t Format: {2} W: {3} H {4}\n", new object[]
				{
					text,
					i,
					rt.format,
					rt.width,
					rt.height
				});
				i++;
			}
			return text;
		}

		// Token: 0x04000421 RID: 1057
		private bool m_HardwareDynamicResRequested;

		// Token: 0x04000422 RID: 1058
		private HashSet<RTHandle> m_AutoSizedRTs;

		// Token: 0x04000423 RID: 1059
		private RTHandle[] m_AutoSizedRTsArray;

		// Token: 0x04000424 RID: 1060
		private HashSet<RTHandle> m_ResizeOnDemandRTs;

		// Token: 0x04000425 RID: 1061
		private RTHandleProperties m_RTHandleProperties;

		// Token: 0x04000426 RID: 1062
		private int m_MaxWidths;

		// Token: 0x04000427 RID: 1063
		private int m_MaxHeights;

		// Token: 0x020001C1 RID: 449
		internal enum ResizeMode
		{
			// Token: 0x04000746 RID: 1862
			Auto,
			// Token: 0x04000747 RID: 1863
			OnDemand
		}
	}
}
