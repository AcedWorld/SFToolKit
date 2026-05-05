using System;
using Unity.Collections;

namespace UnityEngine.Rendering.RendererUtils
{
	// Token: 0x0200048B RID: 1163
	public struct RendererListDesc
	{
		// Token: 0x17000776 RID: 1910
		// (get) Token: 0x06002811 RID: 10257 RVA: 0x00044AE5 File Offset: 0x00042CE5
		// (set) Token: 0x06002812 RID: 10258 RVA: 0x00044AED File Offset: 0x00042CED
		internal CullingResults cullingResult { readonly get; private set; }

		// Token: 0x17000777 RID: 1911
		// (get) Token: 0x06002813 RID: 10259 RVA: 0x00044AF6 File Offset: 0x00042CF6
		// (set) Token: 0x06002814 RID: 10260 RVA: 0x00044AFE File Offset: 0x00042CFE
		internal Camera camera { readonly get; set; }

		// Token: 0x17000778 RID: 1912
		// (get) Token: 0x06002815 RID: 10261 RVA: 0x00044B07 File Offset: 0x00042D07
		// (set) Token: 0x06002816 RID: 10262 RVA: 0x00044B0F File Offset: 0x00042D0F
		internal ShaderTagId passName { readonly get; private set; }

		// Token: 0x17000779 RID: 1913
		// (get) Token: 0x06002817 RID: 10263 RVA: 0x00044B18 File Offset: 0x00042D18
		// (set) Token: 0x06002818 RID: 10264 RVA: 0x00044B20 File Offset: 0x00042D20
		internal ShaderTagId[] passNames { readonly get; private set; }

		// Token: 0x06002819 RID: 10265 RVA: 0x00044B2C File Offset: 0x00042D2C
		public RendererListDesc(ShaderTagId passName, CullingResults cullingResult, Camera camera)
		{
			this = default(RendererListDesc);
			this.passName = passName;
			this.passNames = null;
			this.cullingResult = cullingResult;
			this.camera = camera;
			this.layerMask = -1;
			this.renderingLayerMask = uint.MaxValue;
			this.overrideMaterialPassIndex = 0;
			this.overrideShaderPassIndex = 0;
		}

		// Token: 0x0600281A RID: 10266 RVA: 0x00044B80 File Offset: 0x00042D80
		public RendererListDesc(ShaderTagId[] passNames, CullingResults cullingResult, Camera camera)
		{
			this = default(RendererListDesc);
			this.passNames = passNames;
			this.passName = ShaderTagId.none;
			this.cullingResult = cullingResult;
			this.camera = camera;
			this.layerMask = -1;
			this.renderingLayerMask = uint.MaxValue;
			this.overrideMaterialPassIndex = 0;
		}

		// Token: 0x0600281B RID: 10267 RVA: 0x00044BD0 File Offset: 0x00042DD0
		public bool IsValid()
		{
			bool flag = this.camera == null || (this.passName == ShaderTagId.none && (this.passNames == null || this.passNames.Length == 0));
			return !flag;
		}

		// Token: 0x0600281C RID: 10268 RVA: 0x00044C28 File Offset: 0x00042E28
		public static RendererListParams ConvertToParameters(in RendererListDesc desc)
		{
			RendererListDesc rendererListDesc = desc;
			bool flag = !rendererListDesc.IsValid();
			RendererListParams result;
			if (flag)
			{
				result = RendererListParams.Invalid;
			}
			else
			{
				RendererListParams rendererListParams = default(RendererListParams);
				SortingSettings sortingSettings = new SortingSettings(desc.camera)
				{
					criteria = desc.sortingCriteria
				};
				DrawingSettings drawSettings = new DrawingSettings(RendererListDesc.s_EmptyName, sortingSettings)
				{
					perObjectData = desc.rendererConfiguration
				};
				bool flag2 = desc.passName != ShaderTagId.none;
				if (flag2)
				{
					Debug.Assert(desc.passNames == null);
					drawSettings.SetShaderPassName(0, desc.passName);
				}
				else
				{
					for (int i = 0; i < desc.passNames.Length; i++)
					{
						drawSettings.SetShaderPassName(i, desc.passNames[i]);
					}
				}
				bool flag3 = desc.overrideShader != null;
				if (flag3)
				{
					drawSettings.overrideShader = desc.overrideShader;
					drawSettings.overrideShaderPassIndex = desc.overrideShaderPassIndex;
				}
				bool flag4 = desc.overrideMaterial != null;
				if (flag4)
				{
					drawSettings.overrideMaterial = desc.overrideMaterial;
					drawSettings.overrideMaterialPassIndex = desc.overrideMaterialPassIndex;
				}
				FilteringSettings filteringSettings = new FilteringSettings(new RenderQueueRange?(desc.renderQueueRange), desc.layerMask, desc.renderingLayerMask, 0)
				{
					excludeMotionVectorObjects = desc.excludeObjectMotionVectors
				};
				rendererListParams.cullingResults = desc.cullingResult;
				rendererListParams.drawSettings = drawSettings;
				rendererListParams.filteringSettings = filteringSettings;
				rendererListParams.tagName = ShaderTagId.none;
				rendererListParams.isPassTagName = false;
				bool flag5 = desc.stateBlock != null && desc.stateBlock != null;
				if (flag5)
				{
					NativeArray<RenderStateBlock> value = new NativeArray<RenderStateBlock>(1, Allocator.Temp, NativeArrayOptions.ClearMemory);
					value[0] = desc.stateBlock.Value;
					rendererListParams.stateBlocks = new NativeArray<RenderStateBlock>?(value);
					NativeArray<ShaderTagId> value2 = new NativeArray<ShaderTagId>(1, Allocator.Temp, NativeArrayOptions.ClearMemory);
					value2[0] = ShaderTagId.none;
					rendererListParams.tagValues = new NativeArray<ShaderTagId>?(value2);
				}
				result = rendererListParams;
			}
			return result;
		}

		// Token: 0x04000F2B RID: 3883
		public SortingCriteria sortingCriteria;

		// Token: 0x04000F2C RID: 3884
		public PerObjectData rendererConfiguration;

		// Token: 0x04000F2D RID: 3885
		public RenderQueueRange renderQueueRange;

		// Token: 0x04000F2E RID: 3886
		public RenderStateBlock? stateBlock;

		// Token: 0x04000F2F RID: 3887
		public Shader overrideShader;

		// Token: 0x04000F30 RID: 3888
		public Material overrideMaterial;

		// Token: 0x04000F31 RID: 3889
		public bool excludeObjectMotionVectors;

		// Token: 0x04000F32 RID: 3890
		public int layerMask;

		// Token: 0x04000F33 RID: 3891
		public uint renderingLayerMask;

		// Token: 0x04000F34 RID: 3892
		public int overrideMaterialPassIndex;

		// Token: 0x04000F35 RID: 3893
		public int overrideShaderPassIndex;

		// Token: 0x04000F3A RID: 3898
		private static readonly ShaderTagId s_EmptyName = new ShaderTagId("");
	}
}
