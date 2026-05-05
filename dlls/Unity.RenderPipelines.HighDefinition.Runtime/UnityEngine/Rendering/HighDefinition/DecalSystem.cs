using System;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Jobs;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000FB RID: 251
	internal class DecalSystem
	{
		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060009C0 RID: 2496 RVA: 0x00054847 File Offset: 0x00052A47
		public static DecalSystem instance
		{
			get
			{
				if (DecalSystem.m_Instance == null)
				{
					DecalSystem.m_Instance = new DecalSystem();
				}
				return DecalSystem.m_Instance;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060009C1 RID: 2497 RVA: 0x00054860 File Offset: 0x00052A60
		public int DrawDistance
		{
			get
			{
				HDRenderPipelineAsset currentAsset = HDRenderPipeline.currentAsset;
				if (currentAsset != null)
				{
					return currentAsset.currentPlatformRenderPipelineSettings.decalSettings.drawDistance;
				}
				return 1000;
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060009C2 RID: 2498 RVA: 0x00054894 File Offset: 0x00052A94
		public bool perChannelMask
		{
			get
			{
				HDRenderPipelineAsset currentAsset = HDRenderPipeline.currentAsset;
				return currentAsset != null && currentAsset.currentPlatformRenderPipelineSettings.decalSettings.perChannelMask;
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060009C3 RID: 2499 RVA: 0x000548C2 File Offset: 0x00052AC2
		// (set) Token: 0x060009C4 RID: 2500 RVA: 0x000548CA File Offset: 0x00052ACA
		public Camera CurrentCamera
		{
			get
			{
				return this.m_Camera;
			}
			set
			{
				this.m_Camera = value;
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060009C5 RID: 2501 RVA: 0x000548D4 File Offset: 0x00052AD4
		public Texture2DAtlas Atlas
		{
			get
			{
				if (this.m_Atlas == null)
				{
					this.m_Atlas = new Texture2DAtlas(HDUtils.hdrpSettings.decalSettings.atlasWidth, HDUtils.hdrpSettings.decalSettings.atlasHeight, GraphicsFormat.R8G8B8A8_UNorm, FilterMode.Point, false, "DecalSystemAtlas", true);
				}
				return this.m_Atlas;
			}
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x00054921 File Offset: 0x00052B21
		public static bool IsHDRenderPipelineDecal(Shader shader)
		{
			return shader.name == "HDRP/Decal";
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x00054933 File Offset: 0x00052B33
		public static bool IsHDRenderPipelineDecal(Material material)
		{
			return material.HasProperty("_Unity_Identify_HDRP_Decal");
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x00054940 File Offset: 0x00052B40
		public static bool IsDecalMaterial(Material material)
		{
			foreach (string passName in DecalSystem.s_MaterialDecalPassNames)
			{
				if (material.FindPass(passName) != -1)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x00054974 File Offset: 0x00052B74
		internal void Initialize()
		{
			int drawDistance = this.DrawDistance;
			if (this.m_GlobalDrawDistance != drawDistance)
			{
				this.m_GlobalDrawDistance = drawDistance;
				DecalProjector[] array = Resources.FindObjectsOfTypeAll<DecalProjector>();
				int num = array.Length;
				for (int i = 0; i < num; i++)
				{
					this.ResetCachedDrawDistance(array[i]);
				}
			}
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x000549B8 File Offset: 0x00052BB8
		private void SetupMipStreamingSettings(Texture texture, bool allMips)
		{
			if (texture && texture.dimension == TextureDimension.Tex2D)
			{
				Texture2D texture2D = texture as Texture2D;
				if (texture2D)
				{
					if (allMips)
					{
						texture2D.requestedMipmapLevel = 0;
						return;
					}
					texture2D.ClearRequestedMipmapLevel();
				}
			}
		}

		// Token: 0x060009CB RID: 2507 RVA: 0x000549F8 File Offset: 0x00052BF8
		private void SetupMipStreamingSettings(Material material, bool allMips)
		{
			if (material != null && DecalSystem.IsHDRenderPipelineDecal(material.shader))
			{
				this.SetupMipStreamingSettings(material.GetTexture("_BaseColorMap"), allMips);
				this.SetupMipStreamingSettings(material.GetTexture("_NormalMap"), allMips);
				this.SetupMipStreamingSettings(material.GetTexture("_MaskMap"), allMips);
			}
		}

		// Token: 0x060009CC RID: 2508 RVA: 0x00054A54 File Offset: 0x00052C54
		public DecalSystem.DecalHandle AddDecal(DecalProjector decalProjector)
		{
			Material material = decalProjector.material;
			DecalSystem.DecalSet decalSet = null;
			int num = (material != null) ? material.GetInstanceID() : int.MaxValue;
			if (!this.m_DecalSets.TryGetValue(num, out decalSet))
			{
				this.SetupMipStreamingSettings(material, true);
				decalSet = new DecalSystem.DecalSet(material);
				this.m_DecalSets.Add(num, decalSet);
			}
			return decalSet.AddDecal(num, decalProjector);
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x00054AB8 File Offset: 0x00052CB8
		public void RemoveDecal(DecalSystem.DecalHandle handle)
		{
			if (!DecalSystem.DecalHandle.IsValid(handle))
			{
				return;
			}
			DecalSystem.DecalSet decalSet = null;
			int materialID = handle.m_MaterialID;
			if (this.m_DecalSets.TryGetValue(materialID, out decalSet))
			{
				decalSet.RemoveDecal(handle);
				if (decalSet.Count == 0)
				{
					this.SetupMipStreamingSettings(decalSet.KeyMaterial, false);
					decalSet.Dispose();
					this.m_DecalSets.Remove(materialID);
				}
			}
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x00054B18 File Offset: 0x00052D18
		public void UpdateCachedData(DecalSystem.DecalHandle handle, DecalProjector decalProjector)
		{
			if (!DecalSystem.DecalHandle.IsValid(handle))
			{
				return;
			}
			DecalSystem.DecalSet decalSet = null;
			int materialID = handle.m_MaterialID;
			if (this.m_DecalSets.TryGetValue(materialID, out decalSet))
			{
				decalSet.UpdateCachedData(handle, decalProjector);
			}
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x00054B50 File Offset: 0x00052D50
		private DecalSystem.DecalSet GetDecalSet(DecalSystem.DecalHandle handle)
		{
			if (!DecalSystem.DecalHandle.IsValid(handle))
			{
				return null;
			}
			DecalSystem.DecalSet result = null;
			int materialID = handle.m_MaterialID;
			if (this.m_DecalSets.TryGetValue(materialID, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x00054B84 File Offset: 0x00052D84
		private void ResetCachedDrawDistance(DecalProjector decalProjector)
		{
			DecalSystem.DecalHandle handle = decalProjector.Handle;
			DecalSystem.DecalSet decalSet = this.GetDecalSet(handle);
			if (decalSet != null)
			{
				decalSet.ResetCachedDrawDistance(handle, decalProjector);
			}
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x00054BAC File Offset: 0x00052DAC
		public void BeginCull(DecalSystem.CullRequest request)
		{
			request.Clear();
			foreach (KeyValuePair<int, DecalSystem.DecalSet> keyValuePair in this.m_DecalSets)
			{
				keyValuePair.Value.BeginCull(request[keyValuePair.Key]);
			}
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x00054C18 File Offset: 0x00052E18
		private int QueryCullResults(DecalSystem.CullRequest decalCullRequest, DecalSystem.CullResult cullResults)
		{
			int num = 0;
			foreach (KeyValuePair<int, DecalSystem.DecalSet> keyValuePair in this.m_DecalSets)
			{
				num += keyValuePair.Value.QueryCullResults(decalCullRequest[keyValuePair.Key], cullResults[keyValuePair.Key]);
			}
			return num;
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x00054C90 File Offset: 0x00052E90
		public void EndCull(DecalSystem.CullRequest cullRequest, DecalSystem.CullResult cullResults)
		{
			cullResults.numResults = this.QueryCullResults(cullRequest, cullResults);
			foreach (KeyValuePair<int, DecalSystem.DecalSet> keyValuePair in this.m_DecalSets)
			{
				keyValuePair.Value.EndCull(cullRequest[keyValuePair.Key]);
			}
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x00054D04 File Offset: 0x00052F04
		public bool HasAnyForwardEmissive()
		{
			using (List<DecalSystem.DecalSet>.Enumerator enumerator = this.m_DecalSetsRenderList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.HasEmissivePass)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x00054D60 File Offset: 0x00052F60
		public void RenderIntoDBuffer(CommandBuffer cmd)
		{
			if (DecalSystem.m_DecalMesh == null)
			{
				DecalSystem.m_DecalMesh = CoreUtils.CreateCubeMesh(DecalSystem.kMin, DecalSystem.kMax);
			}
			foreach (DecalSystem.DecalSet decalSet in this.m_DecalSetsRenderList)
			{
				decalSet.RenderIntoDBuffer(cmd);
			}
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x00054DDC File Offset: 0x00052FDC
		public void RenderForwardEmissive(CommandBuffer cmd)
		{
			if (DecalSystem.m_DecalMesh == null)
			{
				DecalSystem.m_DecalMesh = CoreUtils.CreateCubeMesh(DecalSystem.kMin, DecalSystem.kMax);
			}
			foreach (DecalSystem.DecalSet decalSet in this.m_DecalSetsRenderList)
			{
				decalSet.RenderForwardEmissive(cmd);
			}
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x00054E58 File Offset: 0x00053058
		public void SetAtlas(CommandBuffer cmd)
		{
			cmd.SetGlobalTexture(HDShaderIDs._DecalAtlas2DID, this.Atlas.AtlasTexture);
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x00054E78 File Offset: 0x00053078
		public void AddTexture(CommandBuffer cmd, DecalSystem.TextureScaleBias textureScaleBias)
		{
			if (textureScaleBias.m_Texture != null)
			{
				if (this.Atlas.IsCached(out textureScaleBias.m_ScaleBias, textureScaleBias.m_Texture))
				{
					this.Atlas.UpdateTexture(cmd, textureScaleBias.m_Texture, ref textureScaleBias.m_ScaleBias, true, true);
					return;
				}
				if (!this.Atlas.AddTexture(cmd, ref textureScaleBias.m_ScaleBias, textureScaleBias.m_Texture))
				{
					this.m_AllocationSuccess = false;
					return;
				}
			}
			else
			{
				textureScaleBias.m_ScaleBias = Vector4.zero;
			}
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x00054EF8 File Offset: 0x000530F8
		public void UpdateCachedMaterialData()
		{
			this.m_TextureList.Clear();
			foreach (KeyValuePair<int, DecalSystem.DecalSet> keyValuePair in this.m_DecalSets)
			{
				keyValuePair.Value.InitializeMaterialValues();
			}
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x00054F5C File Offset: 0x0005315C
		private void UpdateDecalDatasWithAtlasInfo()
		{
			for (int i = 0; i < DecalSystem.m_DecalDatasCount; i++)
			{
				DecalSystem.m_DecalDatas[i].diffuseScaleBias = DecalSystem.m_DiffuseTextureScaleBias[i].m_ScaleBias;
				DecalSystem.m_DecalDatas[i].normalScaleBias = DecalSystem.m_NormalTextureScaleBias[i].m_ScaleBias;
				DecalSystem.m_DecalDatas[i].maskScaleBias = DecalSystem.m_MaskTextureScaleBias[i].m_ScaleBias;
			}
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x00054FD0 File Offset: 0x000531D0
		public void UpdateTextureAtlas(CommandBuffer cmd)
		{
			this.m_AllocationSuccess = true;
			foreach (DecalSystem.TextureScaleBias textureScaleBias in this.m_TextureList)
			{
				this.AddTexture(cmd, textureScaleBias);
			}
			if (!this.m_AllocationSuccess)
			{
				this.m_TextureList.Sort();
				this.Atlas.ResetAllocator();
				this.m_AllocationSuccess = true;
				foreach (DecalSystem.TextureScaleBias textureScaleBias2 in this.m_TextureList)
				{
					this.AddTexture(cmd, textureScaleBias2);
				}
			}
			this.m_PrevAllocationSuccess = this.m_AllocationSuccess;
			this.UpdateDecalDatasWithAtlasInfo();
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x000550A8 File Offset: 0x000532A8
		public void CreateDrawData()
		{
			DecalSystem.m_DecalDatasCount = 0;
			if (DecalSystem.m_DecalsVisibleThisFrame > DecalSystem.m_DecalDatas.Length)
			{
				int num = (DecalSystem.m_DecalsVisibleThisFrame + 128 - 1) / 128 * 128;
				DecalSystem.m_DecalDatas = new DecalData[num];
				DecalSystem.m_Bounds = new SFiniteLightBound[num];
				DecalSystem.m_LightVolumes = new LightVolumeData[num];
				DecalSystem.m_DiffuseTextureScaleBias = new DecalSystem.TextureScaleBias[num];
				DecalSystem.m_NormalTextureScaleBias = new DecalSystem.TextureScaleBias[num];
				DecalSystem.m_MaskTextureScaleBias = new DecalSystem.TextureScaleBias[num];
				DecalSystem.m_BaseColor = new Vector4[num];
			}
			this.m_DecalSetsRenderList.Clear();
			foreach (KeyValuePair<int, DecalSystem.DecalSet> keyValuePair in this.m_DecalSets)
			{
				keyValuePair.Value.UpdateCachedDrawOrder();
				if (keyValuePair.Value.IsDrawn())
				{
					int num2 = 0;
					while (num2 < this.m_DecalSetsRenderList.Count && keyValuePair.Value.DrawOrder > this.m_DecalSetsRenderList[num2].DrawOrder)
					{
						num2++;
					}
					this.m_DecalSetsRenderList.Insert(num2, keyValuePair.Value);
				}
			}
			foreach (DecalSystem.DecalSet decalSet in this.m_DecalSetsRenderList)
			{
				decalSet.CreateDrawData();
			}
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x0005521C File Offset: 0x0005341C
		public void Cleanup()
		{
			if (this.m_Atlas != null)
			{
				this.m_Atlas.Release();
			}
			CoreUtils.Destroy(DecalSystem.m_DecalMesh);
			DecalSystem.m_DecalMesh = null;
			this.m_Atlas = null;
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x00055248 File Offset: 0x00053448
		public void RenderDebugOverlay(HDCamera hdCamera, CommandBuffer cmd, int mipLevel, DebugOverlay debugOverlay)
		{
			cmd.SetViewport(debugOverlay.Next(1f));
			HDUtils.BlitQuad(cmd, this.Atlas.AtlasTexture, new Vector4(1f, 1f, 0f, 0f), new Vector4(1f, 1f, 0f, 0f), mipLevel, true);
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x000552B4 File Offset: 0x000534B4
		public void LoadCullResults(DecalSystem.CullResult cullResult)
		{
			DecalSystem.m_DecalsVisibleThisFrame = cullResult.numResults;
			using (Dictionary<int, DecalSystem.CullResult.Set>.Enumerator enumerator = cullResult.requests.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Dictionary<int, DecalSystem.DecalSet> decalSets = this.m_DecalSets;
					KeyValuePair<int, DecalSystem.CullResult.Set> keyValuePair = enumerator.Current;
					DecalSystem.DecalSet decalSet;
					if (decalSets.TryGetValue(keyValuePair.Key, out decalSet))
					{
						DecalSystem.DecalSet decalSet2 = decalSet;
						Dictionary<int, DecalSystem.CullResult.Set> requests = cullResult.requests;
						keyValuePair = enumerator.Current;
						decalSet2.SetCullResult(requests[keyValuePair.Key]);
					}
				}
			}
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x00055344 File Offset: 0x00053544
		public bool IsAtlasAllocatedSuccessfully()
		{
			return this.m_AllocationSuccess;
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x0005534C File Offset: 0x0005354C
		public void StartDecalUpdateJobs()
		{
			foreach (KeyValuePair<int, DecalSystem.DecalSet> keyValuePair in this.m_DecalSets)
			{
				DecalSystem.DecalSet value = keyValuePair.Value;
				if (value.Count != 0)
				{
					value.updateJobHandle.Complete();
					value.StartUpdateJob();
				}
			}
		}

		// Token: 0x04000A95 RID: 2709
		public static readonly string[] s_MaterialDecalPassNames = Enum.GetNames(typeof(DecalSystem.MaterialDecalPass));

		// Token: 0x04000A96 RID: 2710
		public static readonly string s_AtlasSizeWarningMessage = "Decal texture atlas out of space, decals on transparent geometry might not render correctly, atlas size can be changed in HDRenderPipelineAsset";

		// Token: 0x04000A97 RID: 2711
		public static readonly string s_GlobalDrawDistanceWarning = "The Draw Distance on the decal projector is larger than the global Draw Distance of {0} set in the render pipeline settings. The global setting will be used.";

		// Token: 0x04000A98 RID: 2712
		public const int kInvalidIndex = -1;

		// Token: 0x04000A99 RID: 2713
		public const int kNullMaterialIndex = 2147483647;

		// Token: 0x04000A9A RID: 2714
		private static DecalSystem m_Instance;

		// Token: 0x04000A9B RID: 2715
		private const int kDefaultDrawDistance = 1000;

		// Token: 0x04000A9C RID: 2716
		private const int kDecalBlockSize = 128;

		// Token: 0x04000A9D RID: 2717
		private const int kDecalBlockGrowthPercentage = 20;

		// Token: 0x04000A9E RID: 2718
		private const int kDecalMaxBlockSize = 2048;

		// Token: 0x04000A9F RID: 2719
		private const int kDrawIndexedBatchSize = 250;

		// Token: 0x04000AA0 RID: 2720
		private static Vector4 kMin = new Vector4(-0.5f, -0.5f, -0.5f, 1f);

		// Token: 0x04000AA1 RID: 2721
		private static Vector4 kMax = new Vector4(0.5f, 0.5f, 0.5f, 1f);

		// Token: 0x04000AA2 RID: 2722
		public static Mesh m_DecalMesh = null;

		// Token: 0x04000AA3 RID: 2723
		public static DecalData[] m_DecalDatas = new DecalData[128];

		// Token: 0x04000AA4 RID: 2724
		public static SFiniteLightBound[] m_Bounds = new SFiniteLightBound[128];

		// Token: 0x04000AA5 RID: 2725
		public static LightVolumeData[] m_LightVolumes = new LightVolumeData[128];

		// Token: 0x04000AA6 RID: 2726
		public static DecalSystem.TextureScaleBias[] m_DiffuseTextureScaleBias = new DecalSystem.TextureScaleBias[128];

		// Token: 0x04000AA7 RID: 2727
		public static DecalSystem.TextureScaleBias[] m_NormalTextureScaleBias = new DecalSystem.TextureScaleBias[128];

		// Token: 0x04000AA8 RID: 2728
		public static DecalSystem.TextureScaleBias[] m_MaskTextureScaleBias = new DecalSystem.TextureScaleBias[128];

		// Token: 0x04000AA9 RID: 2729
		public static Vector4[] m_BaseColor = new Vector4[128];

		// Token: 0x04000AAA RID: 2730
		public static int m_DecalDatasCount = 0;

		// Token: 0x04000AAB RID: 2731
		public static float[] m_BoundingDistances = new float[1];

		// Token: 0x04000AAC RID: 2732
		private Dictionary<int, DecalSystem.DecalSet> m_DecalSets = new Dictionary<int, DecalSystem.DecalSet>();

		// Token: 0x04000AAD RID: 2733
		private List<DecalSystem.DecalSet> m_DecalSetsRenderList = new List<DecalSystem.DecalSet>();

		// Token: 0x04000AAE RID: 2734
		private Camera m_Camera;

		// Token: 0x04000AAF RID: 2735
		public static int m_DecalsVisibleThisFrame = 0;

		// Token: 0x04000AB0 RID: 2736
		private Texture2DAtlas m_Atlas;

		// Token: 0x04000AB1 RID: 2737
		public bool m_AllocationSuccess = true;

		// Token: 0x04000AB2 RID: 2738
		public bool m_PrevAllocationSuccess = true;

		// Token: 0x04000AB3 RID: 2739
		private int m_GlobalDrawDistance = 1000;

		// Token: 0x04000AB4 RID: 2740
		private List<DecalSystem.TextureScaleBias> m_TextureList = new List<DecalSystem.TextureScaleBias>();

		// Token: 0x04000AB5 RID: 2741
		private const string kIdentifyHDRPDecal = "_Unity_Identify_HDRP_Decal";

		// Token: 0x0200037B RID: 891
		public enum MaterialDecalPass
		{
			// Token: 0x0400242B RID: 9259
			DBufferProjector,
			// Token: 0x0400242C RID: 9260
			DecalProjectorForwardEmissive,
			// Token: 0x0400242D RID: 9261
			DBufferMesh,
			// Token: 0x0400242E RID: 9262
			DecalMeshForwardEmissive
		}

		// Token: 0x0200037C RID: 892
		public class CullResult : IDisposable
		{
			// Token: 0x17000289 RID: 649
			// (get) Token: 0x060012E8 RID: 4840 RVA: 0x00090C38 File Offset: 0x0008EE38
			// (set) Token: 0x060012E9 RID: 4841 RVA: 0x00090C40 File Offset: 0x0008EE40
			public int numResults
			{
				get
				{
					return this.m_NumResults;
				}
				set
				{
					this.m_NumResults = value;
				}
			}

			// Token: 0x1700028A RID: 650
			// (get) Token: 0x060012EA RID: 4842 RVA: 0x00090C49 File Offset: 0x0008EE49
			public Dictionary<int, DecalSystem.CullResult.Set> requests
			{
				get
				{
					return this.m_Requests;
				}
			}

			// Token: 0x1700028B RID: 651
			public DecalSystem.CullResult.Set this[int index]
			{
				get
				{
					DecalSystem.CullResult.Set set;
					if (!this.m_Requests.TryGetValue(index, out set))
					{
						set = GenericPool<DecalSystem.CullResult.Set>.Get();
						this.m_Requests.Add(index, set);
					}
					return set;
				}
			}

			// Token: 0x060012EC RID: 4844 RVA: 0x00090C88 File Offset: 0x0008EE88
			public void Clear()
			{
				foreach (KeyValuePair<int, DecalSystem.CullResult.Set> keyValuePair in this.m_Requests)
				{
					keyValuePair.Value.Clear();
					GenericPool<DecalSystem.CullResult.Set>.Release(keyValuePair.Value);
				}
				this.m_Requests.Clear();
			}

			// Token: 0x060012ED RID: 4845 RVA: 0x00090CF8 File Offset: 0x0008EEF8
			public void Dispose()
			{
				this.Dispose(true);
			}

			// Token: 0x060012EE RID: 4846 RVA: 0x00090D01 File Offset: 0x0008EF01
			private void Dispose(bool disposing)
			{
				if (disposing)
				{
					this.m_Requests.Clear();
					this.m_Requests = null;
				}
			}

			// Token: 0x0400242F RID: 9263
			private int m_NumResults;

			// Token: 0x04002430 RID: 9264
			private Dictionary<int, DecalSystem.CullResult.Set> m_Requests = new Dictionary<int, DecalSystem.CullResult.Set>();

			// Token: 0x02000475 RID: 1141
			public class Set : IDisposable
			{
				// Token: 0x170002A4 RID: 676
				// (get) Token: 0x06001472 RID: 5234 RVA: 0x0009A156 File Offset: 0x00098356
				public int numResults
				{
					get
					{
						return this.m_NumResults;
					}
				}

				// Token: 0x170002A5 RID: 677
				// (get) Token: 0x06001473 RID: 5235 RVA: 0x0009A15E File Offset: 0x0009835E
				public int[] resultIndices
				{
					get
					{
						return this.m_ResultIndices;
					}
				}

				// Token: 0x06001474 RID: 5236 RVA: 0x0009A166 File Offset: 0x00098366
				public void Dispose()
				{
					this.Dispose(true);
				}

				// Token: 0x06001475 RID: 5237 RVA: 0x0009A16F File Offset: 0x0009836F
				private void Dispose(bool disposing)
				{
					if (disposing)
					{
						this.Clear();
						this.m_ResultIndices = null;
					}
				}

				// Token: 0x06001476 RID: 5238 RVA: 0x0009A181 File Offset: 0x00098381
				public void Clear()
				{
					this.m_NumResults = 0;
				}

				// Token: 0x06001477 RID: 5239 RVA: 0x0009A18A File Offset: 0x0009838A
				public int QueryIndices(int maxLength, CullingGroup cullingGroup)
				{
					if (this.m_ResultIndices == null || this.m_ResultIndices.Length < maxLength)
					{
						Array.Resize<int>(ref this.m_ResultIndices, maxLength);
					}
					this.m_NumResults = cullingGroup.QueryIndices(true, this.m_ResultIndices, 0);
					return this.m_NumResults;
				}

				// Token: 0x04002A0B RID: 10763
				private int m_NumResults;

				// Token: 0x04002A0C RID: 10764
				private int[] m_ResultIndices;
			}
		}

		// Token: 0x0200037D RID: 893
		public class CullRequest : IDisposable
		{
			// Token: 0x1700028C RID: 652
			public DecalSystem.CullRequest.Set this[int index]
			{
				get
				{
					DecalSystem.CullRequest.Set set;
					if (!this.m_Requests.TryGetValue(index, out set))
					{
						set = GenericPool<DecalSystem.CullRequest.Set>.Get();
						this.m_Requests.Add(index, set);
					}
					return set;
				}
			}

			// Token: 0x060012F1 RID: 4849 RVA: 0x00090D60 File Offset: 0x0008EF60
			public void Clear()
			{
				foreach (KeyValuePair<int, DecalSystem.CullRequest.Set> keyValuePair in this.m_Requests)
				{
					keyValuePair.Value.Clear();
					GenericPool<DecalSystem.CullRequest.Set>.Release(keyValuePair.Value);
				}
				this.m_Requests.Clear();
			}

			// Token: 0x060012F2 RID: 4850 RVA: 0x00090DD0 File Offset: 0x0008EFD0
			public void Dispose()
			{
				this.Dispose(true);
			}

			// Token: 0x060012F3 RID: 4851 RVA: 0x00090DD9 File Offset: 0x0008EFD9
			private void Dispose(bool disposing)
			{
				if (disposing)
				{
					this.m_Requests.Clear();
					this.m_Requests = null;
				}
			}

			// Token: 0x04002431 RID: 9265
			private Dictionary<int, DecalSystem.CullRequest.Set> m_Requests = new Dictionary<int, DecalSystem.CullRequest.Set>();

			// Token: 0x02000476 RID: 1142
			public class Set : IDisposable
			{
				// Token: 0x170002A6 RID: 678
				// (get) Token: 0x06001479 RID: 5241 RVA: 0x0009A1CD File Offset: 0x000983CD
				public CullingGroup cullingGroup
				{
					get
					{
						return this.m_CullingGroup;
					}
				}

				// Token: 0x0600147A RID: 5242 RVA: 0x0009A1D5 File Offset: 0x000983D5
				public void Dispose()
				{
					this.Dispose(true);
				}

				// Token: 0x0600147B RID: 5243 RVA: 0x0009A1DE File Offset: 0x000983DE
				private void Dispose(bool disposing)
				{
					if (disposing)
					{
						this.Clear();
					}
				}

				// Token: 0x0600147C RID: 5244 RVA: 0x0009A1E9 File Offset: 0x000983E9
				public void Clear()
				{
					if (this.m_CullingGroup != null)
					{
						CullingGroupManager.instance.Free(this.m_CullingGroup);
					}
					this.m_CullingGroup = null;
				}

				// Token: 0x0600147D RID: 5245 RVA: 0x0009A20A File Offset: 0x0009840A
				public void Initialize(CullingGroup cullingGroup)
				{
					this.m_CullingGroup = cullingGroup;
				}

				// Token: 0x04002A0D RID: 10765
				private CullingGroup m_CullingGroup;
			}
		}

		// Token: 0x0200037E RID: 894
		public class DecalHandle
		{
			// Token: 0x060012F5 RID: 4853 RVA: 0x00090E03 File Offset: 0x0008F003
			public DecalHandle(int index, int materialID)
			{
				this.m_MaterialID = materialID;
				this.m_Index = index;
			}

			// Token: 0x060012F6 RID: 4854 RVA: 0x00090E19 File Offset: 0x0008F019
			public static bool IsValid(DecalSystem.DecalHandle handle)
			{
				return handle != null && handle.m_Index != -1;
			}

			// Token: 0x04002432 RID: 9266
			public int m_MaterialID;

			// Token: 0x04002433 RID: 9267
			public int m_Index;
		}

		// Token: 0x0200037F RID: 895
		public class TextureScaleBias : IComparable
		{
			// Token: 0x060012F7 RID: 4855 RVA: 0x00090E2C File Offset: 0x0008F02C
			public int CompareTo(object obj)
			{
				DecalSystem.TextureScaleBias textureScaleBias = obj as DecalSystem.TextureScaleBias;
				int num = this.m_Texture.width * this.m_Texture.height;
				int num2 = textureScaleBias.m_Texture.width * textureScaleBias.m_Texture.height;
				if (num > num2)
				{
					return -1;
				}
				if (num < num2)
				{
					return 1;
				}
				return 0;
			}

			// Token: 0x060012F8 RID: 4856 RVA: 0x00090E7D File Offset: 0x0008F07D
			public void Initialize(Texture texture, Vector4 scaleBias)
			{
				this.m_Texture = texture;
				this.m_ScaleBias = scaleBias;
			}

			// Token: 0x04002434 RID: 9268
			public Texture m_Texture;

			// Token: 0x04002435 RID: 9269
			public Vector4 m_ScaleBias = Vector4.zero;
		}

		// Token: 0x02000380 RID: 896
		private class DecalSet : IDisposable
		{
			// Token: 0x060012FA RID: 4858 RVA: 0x00090EA0 File Offset: 0x0008F0A0
			public void InitializeMaterialValues()
			{
				if (this.m_Material == null)
				{
					return;
				}
				this.m_IsHDRenderPipelineDecal = DecalSystem.IsHDRenderPipelineDecal(this.m_Material);
				if (this.m_IsHDRenderPipelineDecal)
				{
					bool flag = this.m_Material.GetFloat(HDShaderIDs._AffectNormal) != 0f;
					this.m_Normal.Initialize(flag ? this.m_Material.GetTexture("_NormalMap") : null, Vector4.zero);
					bool flag2 = this.m_Material.GetFloat(HDShaderIDs._AffectMetal) != 0f;
					bool flag3 = this.m_Material.GetFloat(HDShaderIDs._AffectAO) != 0f;
					bool flag4 = this.m_Material.GetFloat(HDShaderIDs._AffectSmoothness) != 0f;
					bool flag5 = flag2 || flag3 || flag4;
					this.m_Mask.Initialize(flag5 ? this.m_Material.GetTexture("_MaskMap") : null, Vector4.zero);
					float @float = this.m_Material.GetFloat("_NormalBlendSrc");
					float float2 = this.m_Material.GetFloat("_MaskBlendSrc");
					bool flag6 = this.m_Material.GetFloat(HDShaderIDs._AffectAlbedo) != 0f;
					this.m_Diffuse.Initialize(this.m_Material.GetTexture("_BaseColorMap"), Vector4.zero);
					this.m_Blend = this.m_Material.GetFloat("_DecalBlend");
					this.m_BaseColor = this.m_Material.GetVector("_BaseColor");
					this.m_BlendParams = new Vector3(@float, float2, 0f);
					int num = (flag6 ? 1 : 0) | (flag ? 2 : 0) | (flag2 ? 4 : 0) | (flag3 ? 8 : 0) | (flag4 ? 16 : 0);
					this.m_BlendParams.z = (float)num;
					this.m_ScalingBAndRemappingM = new Vector4(0f, this.m_Material.GetFloat("_DecalMaskMapBlueScale"), 0f, 0f);
					if (this.m_Material.GetTexture("_MaskMap"))
					{
						this.m_RemappingAOS = new Vector4(this.m_Material.GetFloat("_AORemapMin"), this.m_Material.GetFloat("_AORemapMax"), this.m_Material.GetFloat("_SmoothnessRemapMin"), this.m_Material.GetFloat("_SmoothnessRemapMax"));
						this.m_ScalingBAndRemappingM.z = this.m_Material.GetFloat("_MetallicRemapMin");
						this.m_ScalingBAndRemappingM.w = this.m_Material.GetFloat("_MetallicRemapMax");
					}
					else
					{
						this.m_RemappingAOS = new Vector4(this.m_Material.GetFloat("_AO"), this.m_Material.GetFloat("_AO"), this.m_Material.GetFloat("_Smoothness"), this.m_Material.GetFloat("_Smoothness"));
						this.m_ScalingBAndRemappingM.z = this.m_Material.GetFloat("_Metallic");
					}
					this.m_cachedProjectorPassValue = -1;
					if (this.m_Material.GetShaderPassEnabled(DecalSystem.s_MaterialDecalPassNames[0]))
					{
						this.m_cachedProjectorPassValue = 0;
					}
					this.m_cachedProjectorEmissivePassValue = -1;
					if (this.m_Material.GetShaderPassEnabled(DecalSystem.s_MaterialDecalPassNames[1]))
					{
						this.m_cachedProjectorEmissivePassValue = 1;
						return;
					}
				}
				else
				{
					this.m_Blend = 1f;
					this.m_cachedProjectorPassValue = this.m_Material.FindPass(DecalSystem.s_MaterialDecalPassNames[0]);
					if (this.m_cachedProjectorPassValue != -1 && !this.m_Material.GetShaderPassEnabled(DecalSystem.s_MaterialDecalPassNames[0]))
					{
						this.m_cachedProjectorPassValue = -1;
					}
					this.m_cachedProjectorEmissivePassValue = this.m_Material.FindPass(DecalSystem.s_MaterialDecalPassNames[1]);
					if (this.m_cachedProjectorEmissivePassValue != -1 && !this.m_Material.GetShaderPassEnabled(DecalSystem.s_MaterialDecalPassNames[1]))
					{
						this.m_cachedProjectorEmissivePassValue = -1;
					}
				}
			}

			// Token: 0x060012FB RID: 4859 RVA: 0x00091265 File Offset: 0x0008F465
			public void Dispose()
			{
				this.Dispose(true);
			}

			// Token: 0x060012FC RID: 4860 RVA: 0x0009126E File Offset: 0x0008F46E
			private void Dispose(bool disposing)
			{
				if (!disposing)
				{
					return;
				}
				this.DisposeJobArrays();
			}

			// Token: 0x060012FD RID: 4861 RVA: 0x0009127C File Offset: 0x0008F47C
			public DecalSet(Material material)
			{
				this.m_Material = material;
				this.InitializeMaterialValues();
			}

			// Token: 0x060012FE RID: 4862 RVA: 0x00091494 File Offset: 0x0008F694
			private float GetDrawDistance(float projectorDrawDistance)
			{
				float num = (float)DecalSystem.instance.DrawDistance;
				if (projectorDrawDistance >= num)
				{
					return num;
				}
				return projectorDrawDistance;
			}

			// Token: 0x060012FF RID: 4863 RVA: 0x000914B4 File Offset: 0x0008F6B4
			public void UpdateCachedData(DecalSystem.DecalHandle handle, DecalProjector decalProjector)
			{
				DecalProjector.CachedDecalData cachedDecalData = decalProjector.GetCachedDecalData();
				int index = handle.m_Index;
				this.m_CachedDrawDistances[index].x = this.GetDrawDistance(cachedDecalData.drawDistance);
				this.m_CachedDrawDistances[index].y = cachedDecalData.fadeScale;
				if (cachedDecalData.startAngleFade == 180f)
				{
					this.m_CachedAngleFade[index].x = 0f;
					this.m_CachedAngleFade[index].y = 0f;
				}
				else
				{
					float num = cachedDecalData.startAngleFade / 180f;
					float num2 = cachedDecalData.endAngleFade / 180f;
					float num3 = Mathf.Max(0.0001f, num2 - num);
					this.m_CachedAngleFade[index].x = 0.22222222f / num3;
					this.m_CachedAngleFade[index].y = (num2 - 0.5f) / num3;
				}
				this.m_CachedUVScaleBias[index] = cachedDecalData.uvScaleBias;
				this.m_CachedAffectsTransparency[index] = cachedDecalData.affectsTransparency;
				this.m_CachedLayerMask[index] = cachedDecalData.layerMask;
				this.m_CachedSceneLayerMask[index] = cachedDecalData.sceneLayerMask;
				this.m_CachedFadeFactor[index] = cachedDecalData.fadeFactor;
				this.m_CachedDecalLayerMask[index] = cachedDecalData.decalLayerMask;
				this.UpdateCachedDrawOrder();
				this.UpdateJobArrays(index, decalProjector);
			}

			// Token: 0x06001300 RID: 4864 RVA: 0x00091604 File Offset: 0x0008F804
			internal void ResetCachedDrawDistance(DecalSystem.DecalHandle handle, DecalProjector decalProjector)
			{
				DecalProjector.CachedDecalData cachedDecalData = decalProjector.GetCachedDecalData();
				int index = handle.m_Index;
				this.m_CachedDrawDistances[index].x = this.GetDrawDistance(cachedDecalData.drawDistance);
			}

			// Token: 0x06001301 RID: 4865 RVA: 0x0009163C File Offset: 0x0008F83C
			public void UpdateCachedDrawOrder()
			{
				if (this.m_Material != null && this.m_Material.HasProperty(HDShaderIDs._DrawOrder))
				{
					this.m_CachedDrawOrder = this.m_Material.GetInt(HDShaderIDs._DrawOrder);
					return;
				}
				this.m_CachedDrawOrder = 0;
			}

			// Token: 0x06001302 RID: 4866 RVA: 0x0009167C File Offset: 0x0008F87C
			public DecalSystem.DecalHandle AddDecal(int materialID, DecalProjector decalProjector)
			{
				if (this.m_DecalsCount == this.m_Handles.Length)
				{
					int num = Math.Min(Math.Max(this.m_DecalsCount * 20 / 100, 128), 2048);
					int num2 = this.m_DecalsCount + num;
					this.m_ResultIndices = new int[num2];
					this.GrowJobArrays(num);
					ArrayExtensions.ResizeArray<DecalSystem.DecalHandle>(ref this.m_Handles, num2);
					ArrayExtensions.ResizeArray<Vector2>(ref this.m_CachedDrawDistances, num2);
					ArrayExtensions.ResizeArray<Vector2>(ref this.m_CachedAngleFade, num2);
					ArrayExtensions.ResizeArray<Vector4>(ref this.m_CachedUVScaleBias, num2);
					ArrayExtensions.ResizeArray<bool>(ref this.m_CachedAffectsTransparency, num2);
					ArrayExtensions.ResizeArray<int>(ref this.m_CachedLayerMask, num2);
					ArrayExtensions.ResizeArray<ulong>(ref this.m_CachedSceneLayerMask, num2);
					ArrayExtensions.ResizeArray<DecalLayerEnum>(ref this.m_CachedDecalLayerMask, num2);
					ArrayExtensions.ResizeArray<float>(ref this.m_CachedFadeFactor, num2);
				}
				DecalSystem.DecalHandle decalHandle = new DecalSystem.DecalHandle(this.m_DecalsCount, materialID);
				this.m_Handles[this.m_DecalsCount] = decalHandle;
				this.UpdateCachedData(decalHandle, decalProjector);
				this.m_DecalsCount++;
				return decalHandle;
			}

			// Token: 0x06001303 RID: 4867 RVA: 0x00091778 File Offset: 0x0008F978
			public void RemoveDecal(DecalSystem.DecalHandle handle)
			{
				int index = handle.m_Index;
				this.m_Handles[index] = this.m_Handles[this.m_DecalsCount - 1];
				this.m_Handles[index].m_Index = index;
				this.m_Handles[this.m_DecalsCount - 1] = null;
				this.RemoveFromJobArrays(index);
				this.m_CachedDrawDistances[index] = this.m_CachedDrawDistances[this.m_DecalsCount - 1];
				this.m_CachedAngleFade[index] = this.m_CachedAngleFade[this.m_DecalsCount - 1];
				this.m_CachedUVScaleBias[index] = this.m_CachedUVScaleBias[this.m_DecalsCount - 1];
				this.m_CachedAffectsTransparency[index] = this.m_CachedAffectsTransparency[this.m_DecalsCount - 1];
				this.m_CachedLayerMask[index] = this.m_CachedLayerMask[this.m_DecalsCount - 1];
				this.m_CachedSceneLayerMask[index] = this.m_CachedSceneLayerMask[this.m_DecalsCount - 1];
				this.m_CachedFadeFactor[index] = this.m_CachedFadeFactor[this.m_DecalsCount - 1];
				this.m_DecalsCount--;
				handle.m_Index = -1;
			}

			// Token: 0x06001304 RID: 4868 RVA: 0x00091898 File Offset: 0x0008FA98
			public void BeginCull(DecalSystem.CullRequest.Set cullRequest)
			{
				cullRequest.Clear();
				if (this.m_Material == null)
				{
					return;
				}
				if (cullRequest.cullingGroup != null)
				{
					Debug.LogError("Begin/EndCull() called out of sequence for decal projectors.");
				}
				this.ResolveUpdateJob();
				DecalSystem.m_BoundingDistances[0] = (float)DecalSystem.instance.DrawDistance;
				this.m_NumResults = 0;
				CullingGroup cullingGroup = CullingGroupManager.instance.Alloc();
				cullingGroup.targetCamera = DecalSystem.instance.CurrentCamera;
				cullingGroup.SetDistanceReferencePoint(cullingGroup.targetCamera.transform.position);
				cullingGroup.SetBoundingDistances(DecalSystem.m_BoundingDistances);
				cullingGroup.SetBoundingSpheres(this.m_CachedBoundingSpheres);
				cullingGroup.SetBoundingSphereCount(this.m_DecalsCount);
				cullRequest.Initialize(cullingGroup);
			}

			// Token: 0x06001305 RID: 4869 RVA: 0x00091946 File Offset: 0x0008FB46
			public int QueryCullResults(DecalSystem.CullRequest.Set cullRequest, DecalSystem.CullResult.Set cullResult)
			{
				if (this.m_Material == null || cullRequest.cullingGroup == null)
				{
					return 0;
				}
				return cullResult.QueryIndices(this.m_Handles.Length, cullRequest.cullingGroup);
			}

			// Token: 0x06001306 RID: 4870 RVA: 0x00091974 File Offset: 0x0008FB74
			private void GetDecalVolumeDataAndBound(Matrix4x4 decalToWorld, Matrix4x4 worldToView)
			{
				Vector4 a = decalToWorld.GetColumn(0) * 0.5f;
				Vector4 a2 = decalToWorld.GetColumn(1) * 0.5f;
				Vector4 a3 = decalToWorld.GetColumn(2) * 0.5f;
				Vector4 column = decalToWorld.GetColumn(3);
				Vector3 vector = default(Vector3);
				vector.x = a.magnitude;
				vector.y = a2.magnitude;
				vector.z = a3.magnitude;
				Vector3 vector2 = worldToView.MultiplyVector(a / vector.x);
				Vector3 vector3 = worldToView.MultiplyVector(a2 / vector.y);
				Vector3 vector4 = worldToView.MultiplyVector(a3 / vector.z);
				Vector3 vector5 = worldToView.MultiplyPoint(column);
				DecalSystem.m_Bounds[DecalSystem.m_DecalDatasCount].center = vector5;
				DecalSystem.m_Bounds[DecalSystem.m_DecalDatasCount].boxAxisX = vector2 * vector.x;
				DecalSystem.m_Bounds[DecalSystem.m_DecalDatasCount].boxAxisY = vector3 * vector.y;
				DecalSystem.m_Bounds[DecalSystem.m_DecalDatasCount].boxAxisZ = vector4 * vector.z;
				DecalSystem.m_Bounds[DecalSystem.m_DecalDatasCount].scaleXY = 1f;
				DecalSystem.m_Bounds[DecalSystem.m_DecalDatasCount].radius = vector.magnitude;
				DecalSystem.m_LightVolumes[DecalSystem.m_DecalDatasCount].lightCategory = 3U;
				DecalSystem.m_LightVolumes[DecalSystem.m_DecalDatasCount].lightVolume = 2U;
				DecalSystem.m_LightVolumes[DecalSystem.m_DecalDatasCount].featureFlags = 32768U;
				DecalSystem.m_LightVolumes[DecalSystem.m_DecalDatasCount].lightPos = vector5;
				DecalSystem.m_LightVolumes[DecalSystem.m_DecalDatasCount].lightAxisX = vector2;
				DecalSystem.m_LightVolumes[DecalSystem.m_DecalDatasCount].lightAxisY = vector3;
				DecalSystem.m_LightVolumes[DecalSystem.m_DecalDatasCount].lightAxisZ = vector4;
				DecalSystem.m_LightVolumes[DecalSystem.m_DecalDatasCount].boxInnerDist = vector - HDRenderPipeline.k_BoxCullingExtentThreshold;
				DecalSystem.m_LightVolumes[DecalSystem.m_DecalDatasCount].boxInvRange.Set(1f / HDRenderPipeline.k_BoxCullingExtentThreshold.x, 1f / HDRenderPipeline.k_BoxCullingExtentThreshold.y, 1f / HDRenderPipeline.k_BoxCullingExtentThreshold.z);
			}

			// Token: 0x06001307 RID: 4871 RVA: 0x00091C0C File Offset: 0x0008FE0C
			private void AssignCurrentBatches(ref Matrix4x4[] decalToWorldBatch, ref Matrix4x4[] normalToWorldBatch, ref float[] decalLayerMaskBatch, int batchCount)
			{
				if (this.m_DecalToWorld.Count == batchCount)
				{
					decalToWorldBatch = new Matrix4x4[250];
					this.m_DecalToWorld.Add(decalToWorldBatch);
					normalToWorldBatch = new Matrix4x4[250];
					this.m_NormalToWorld.Add(normalToWorldBatch);
					decalLayerMaskBatch = new float[250];
					this.m_DecalLayerMasks.Add(decalLayerMaskBatch);
					return;
				}
				decalToWorldBatch = this.m_DecalToWorld[batchCount];
				normalToWorldBatch = this.m_NormalToWorld[batchCount];
				decalLayerMaskBatch = this.m_DecalLayerMasks[batchCount];
			}

			// Token: 0x06001308 RID: 4872 RVA: 0x00091CA1 File Offset: 0x0008FEA1
			public bool IsDrawn()
			{
				return this.m_Material != null && this.m_NumResults > 0;
			}

			// Token: 0x06001309 RID: 4873 RVA: 0x00091CBC File Offset: 0x0008FEBC
			public void CreateDrawData()
			{
				int num = 0;
				int num2 = 0;
				this.m_InstanceCount = 0;
				Matrix4x4[] array = null;
				Matrix4x4[] array2 = null;
				float[] array3 = null;
				bool flag = false;
				this.AssignCurrentBatches(ref array, ref array2, ref array3, num2);
				NativeArray<Matrix4x4> nativeArray = this.m_DecalToWorlds.Reinterpret<Matrix4x4>();
				NativeArray<Matrix4x4> nativeArray2 = this.m_NormalToWorlds.Reinterpret<Matrix4x4>();
				Vector3 position = DecalSystem.instance.CurrentCamera.transform.position;
				Camera currentCamera = DecalSystem.instance.CurrentCamera;
				Matrix4x4 worldToView = HDRenderPipeline.WorldToCamera(currentCamera);
				int cullingMask = currentCamera.cullingMask;
				HDUtils.GetSceneCullingMaskFromCamera(currentCamera);
				for (int i = 0; i < this.m_NumResults; i++)
				{
					int num3 = this.m_ResultIndices[i];
					int num4 = 1 << this.m_CachedLayerMask[num3];
					ulong num5 = this.m_CachedSceneLayerMask[num3];
					bool flag2 = true;
					if ((cullingMask & num4) != 0 && flag2)
					{
						float magnitude = (position - this.m_CachedBoundingSpheres[num3].position).magnitude;
						float num6 = this.m_CachedDrawDistances[num3].x + this.m_CachedBoundingSpheres[num3].radius;
						if (magnitude < num6)
						{
							array[num] = nativeArray[num3];
							array2[num] = nativeArray2[num3];
							float num7 = this.m_CachedFadeFactor[num3] * Mathf.Clamp((num6 - magnitude) / (num6 * (1f - this.m_CachedDrawDistances[num3].y)), 0f, 1f);
							array2[num].m03 = num7 * this.m_Blend;
							array2[num].m13 = this.m_CachedAngleFade[num3].x;
							array2[num].m23 = this.m_CachedAngleFade[num3].y;
							array2[num].SetRow(3, this.m_CachedUVScaleBias[num3]);
							array3[num] = (float)this.m_CachedDecalLayerMask[num3];
							if (this.m_CachedAffectsTransparency[num3])
							{
								DecalSystem.m_DecalDatas[DecalSystem.m_DecalDatasCount].worldToDecal = array[num].inverse;
								DecalSystem.m_DecalDatas[DecalSystem.m_DecalDatasCount].normalToWorld = array2[num];
								DecalSystem.m_DecalDatas[DecalSystem.m_DecalDatasCount].baseColor = new Vector4(Mathf.GammaToLinearSpace(this.m_BaseColor.x), Mathf.GammaToLinearSpace(this.m_BaseColor.y), Mathf.GammaToLinearSpace(this.m_BaseColor.z), this.m_BaseColor.w);
								DecalSystem.m_DecalDatas[DecalSystem.m_DecalDatasCount].blendParams = this.m_BlendParams;
								DecalSystem.m_DecalDatas[DecalSystem.m_DecalDatasCount].remappingAOS = this.m_RemappingAOS;
								DecalSystem.m_DecalDatas[DecalSystem.m_DecalDatasCount].scalingBAndRemappingM = this.m_ScalingBAndRemappingM;
								DecalSystem.m_DecalDatas[DecalSystem.m_DecalDatasCount].decalLayerMask = (uint)this.m_CachedDecalLayerMask[num3];
								DecalSystem.m_DiffuseTextureScaleBias[DecalSystem.m_DecalDatasCount] = this.m_Diffuse;
								DecalSystem.m_NormalTextureScaleBias[DecalSystem.m_DecalDatasCount] = this.m_Normal;
								DecalSystem.m_MaskTextureScaleBias[DecalSystem.m_DecalDatasCount] = this.m_Mask;
								this.GetDecalVolumeDataAndBound(array[num], worldToView);
								DecalSystem.m_DecalDatasCount++;
								flag = true;
							}
							num++;
							this.m_InstanceCount++;
							if (num == 250)
							{
								num = 0;
								num2++;
								this.AssignCurrentBatches(ref array, ref array2, ref array3, num2);
							}
						}
					}
				}
				if (flag)
				{
					this.AddToTextureList(ref DecalSystem.instance.m_TextureList);
				}
			}

			// Token: 0x0600130A RID: 4874 RVA: 0x00092051 File Offset: 0x00090251
			public void EndCull(DecalSystem.CullRequest.Set request)
			{
				if (this.m_Material == null)
				{
					return;
				}
				if (request.cullingGroup == null)
				{
					Debug.LogError("Begin/EndCull() called out of sequence for decal projectors.");
					return;
				}
				request.Clear();
			}

			// Token: 0x0600130B RID: 4875 RVA: 0x0009207C File Offset: 0x0009027C
			public void AddToTextureList(ref List<DecalSystem.TextureScaleBias> textureList)
			{
				if (this.m_Diffuse.m_Texture != null)
				{
					textureList.Add(this.m_Diffuse);
				}
				if (this.m_Normal.m_Texture != null)
				{
					textureList.Add(this.m_Normal);
				}
				if (this.m_Mask.m_Texture != null)
				{
					textureList.Add(this.m_Mask);
				}
			}

			// Token: 0x0600130C RID: 4876 RVA: 0x000920EC File Offset: 0x000902EC
			public void RenderIntoDBuffer(CommandBuffer cmd)
			{
				if (this.m_Material == null || this.m_cachedProjectorPassValue == -1 || this.m_NumResults == 0)
				{
					return;
				}
				int i = 0;
				int num = this.m_InstanceCount;
				while (i < this.m_InstanceCount / 250)
				{
					this.m_PropertyBlock.SetMatrixArray(HDShaderIDs._NormalToWorldID, this.m_NormalToWorld[i]);
					this.m_PropertyBlock.SetFloatArray("_DecalLayerMaskFromDecal", this.m_DecalLayerMasks[i]);
					cmd.DrawMeshInstanced(DecalSystem.m_DecalMesh, 0, this.m_Material, this.m_cachedProjectorPassValue, this.m_DecalToWorld[i], 250, this.m_PropertyBlock);
					num -= 250;
					i++;
				}
				if (num > 0)
				{
					this.m_PropertyBlock.SetMatrixArray(HDShaderIDs._NormalToWorldID, this.m_NormalToWorld[i]);
					this.m_PropertyBlock.SetFloatArray("_DecalLayerMaskFromDecal", this.m_DecalLayerMasks[i]);
					cmd.DrawMeshInstanced(DecalSystem.m_DecalMesh, 0, this.m_Material, this.m_cachedProjectorPassValue, this.m_DecalToWorld[i], num, this.m_PropertyBlock);
				}
			}

			// Token: 0x0600130D RID: 4877 RVA: 0x00092210 File Offset: 0x00090410
			public void RenderForwardEmissive(CommandBuffer cmd)
			{
				if (this.m_Material == null || this.m_cachedProjectorEmissivePassValue == -1 || this.m_NumResults == 0)
				{
					return;
				}
				int i = 0;
				int num = this.m_InstanceCount;
				while (i < this.m_InstanceCount / 250)
				{
					this.m_PropertyBlock.SetMatrixArray(HDShaderIDs._NormalToWorldID, this.m_NormalToWorld[i]);
					this.m_PropertyBlock.SetFloatArray("_DecalLayerMaskFromDecal", this.m_DecalLayerMasks[i]);
					cmd.DrawMeshInstanced(DecalSystem.m_DecalMesh, 0, this.m_Material, this.m_cachedProjectorEmissivePassValue, this.m_DecalToWorld[i], 250, this.m_PropertyBlock);
					num -= 250;
					i++;
				}
				if (num > 0)
				{
					this.m_PropertyBlock.SetMatrixArray(HDShaderIDs._NormalToWorldID, this.m_NormalToWorld[i]);
					this.m_PropertyBlock.SetFloatArray("_DecalLayerMaskFromDecal", this.m_DecalLayerMasks[i]);
					cmd.DrawMeshInstanced(DecalSystem.m_DecalMesh, 0, this.m_Material, this.m_cachedProjectorEmissivePassValue, this.m_DecalToWorld[i], num, this.m_PropertyBlock);
				}
			}

			// Token: 0x1700028D RID: 653
			// (get) Token: 0x0600130E RID: 4878 RVA: 0x00092334 File Offset: 0x00090534
			public Material KeyMaterial
			{
				get
				{
					return this.m_Material;
				}
			}

			// Token: 0x1700028E RID: 654
			// (get) Token: 0x0600130F RID: 4879 RVA: 0x0009233C File Offset: 0x0009053C
			public int Count
			{
				get
				{
					return this.m_DecalsCount;
				}
			}

			// Token: 0x1700028F RID: 655
			// (get) Token: 0x06001310 RID: 4880 RVA: 0x00092344 File Offset: 0x00090544
			public bool HasEmissivePass
			{
				get
				{
					return this.m_cachedProjectorEmissivePassValue != -1;
				}
			}

			// Token: 0x17000290 RID: 656
			// (get) Token: 0x06001311 RID: 4881 RVA: 0x00092352 File Offset: 0x00090552
			public int DrawOrder
			{
				get
				{
					return this.m_CachedDrawOrder;
				}
			}

			// Token: 0x06001312 RID: 4882 RVA: 0x0009235C File Offset: 0x0009055C
			internal void SetCullResult(DecalSystem.CullResult.Set value)
			{
				this.m_NumResults = value.numResults;
				if (this.m_ResultIndices.Length < this.m_NumResults)
				{
					Array.Resize<int>(ref this.m_ResultIndices, this.m_NumResults);
				}
				Array.Copy(value.resultIndices, this.m_ResultIndices, this.m_NumResults);
			}

			// Token: 0x17000291 RID: 657
			// (get) Token: 0x06001313 RID: 4883 RVA: 0x000923AD File Offset: 0x000905AD
			internal JobHandle updateJobHandle
			{
				get
				{
					return this.m_UpdateJobHandle;
				}
			}

			// Token: 0x06001314 RID: 4884 RVA: 0x000923B5 File Offset: 0x000905B5
			public void ResolveUpdateJob()
			{
				this.m_UpdateJobHandle.Complete();
				this.m_BoundingSpheres.CopyTo(this.m_CachedBoundingSpheres);
			}

			// Token: 0x06001315 RID: 4885 RVA: 0x000923D4 File Offset: 0x000905D4
			private void GrowJobArrays(int growByAmount)
			{
				int capacity = this.m_DecalsCount + growByAmount;
				this.m_CachedTransforms.capacity = capacity;
				ref this.m_Positions.ResizeArray(capacity);
				ref this.m_Rotations.ResizeArray(capacity);
				ref this.m_Scales.ResizeArray(capacity);
				ref this.m_Sizes.ResizeArray(capacity);
				ref this.m_Offsets.ResizeArray(capacity);
				ref this.m_ResolvedRotations.ResizeArray(capacity);
				ref this.m_ResolvedScales.ResizeArray(capacity);
				ref this.m_ResolvedSizeOffsets.ResizeArray(capacity);
				ref this.m_ScaleModes.ResizeArray(capacity);
				ref this.m_NormalToWorlds.ResizeArray(capacity);
				ref this.m_DecalToWorlds.ResizeArray(capacity);
				ref this.m_BoundingSpheres.ResizeArray(capacity);
				ref this.m_Dirty.ResizeArray(capacity);
				ArrayExtensions.ResizeArray<BoundingSphere>(ref this.m_CachedBoundingSpheres, capacity);
			}

			// Token: 0x06001316 RID: 4886 RVA: 0x000924A0 File Offset: 0x000906A0
			private void UpdateJobArrays(int index, DecalProjector decalProjector)
			{
				if (index == this.m_CachedTransforms.length)
				{
					this.m_CachedTransforms.Add(decalProjector.transform);
				}
				else
				{
					this.m_CachedTransforms[index] = decalProjector.transform;
				}
				this.m_Positions[index] = decalProjector.transform.position;
				this.m_Rotations[index] = decalProjector.transform.rotation;
				this.m_Scales[index] = decalProjector.transform.lossyScale;
				this.m_Sizes[index] = decalProjector.size;
				this.m_Offsets[index] = decalProjector.pivot;
				this.m_ScaleModes[index] = decalProjector.scaleMode;
				this.m_Dirty[index] = true;
			}

			// Token: 0x06001317 RID: 4887 RVA: 0x00092584 File Offset: 0x00090784
			private void RemoveFromJobArrays(int removeAtIndex)
			{
				this.m_CachedTransforms.RemoveAtSwapBack(removeAtIndex);
				this.m_Positions[removeAtIndex] = this.m_Positions[this.m_DecalsCount - 1];
				this.m_Rotations[removeAtIndex] = this.m_Rotations[this.m_DecalsCount - 1];
				this.m_Scales[removeAtIndex] = this.m_Scales[this.m_DecalsCount - 1];
				this.m_Sizes[removeAtIndex] = this.m_Sizes[this.m_DecalsCount - 1];
				this.m_Offsets[removeAtIndex] = this.m_Offsets[this.m_DecalsCount - 1];
				this.m_ResolvedRotations[removeAtIndex] = this.m_ResolvedRotations[this.m_DecalsCount - 1];
				this.m_ResolvedScales[removeAtIndex] = this.m_ResolvedScales[this.m_DecalsCount - 1];
				this.m_ResolvedSizeOffsets[removeAtIndex] = this.m_ResolvedSizeOffsets[this.m_DecalsCount - 1];
				this.m_ScaleModes[removeAtIndex] = this.m_ScaleModes[this.m_DecalsCount - 1];
				this.m_NormalToWorlds[removeAtIndex] = this.m_NormalToWorlds[this.m_DecalsCount - 1];
				this.m_DecalToWorlds[removeAtIndex] = this.m_DecalToWorlds[this.m_DecalsCount - 1];
				this.m_BoundingSpheres[removeAtIndex] = this.m_BoundingSpheres[this.m_DecalsCount - 1];
				this.m_Dirty[removeAtIndex] = this.m_Dirty[this.m_DecalsCount - 1];
				this.m_CachedBoundingSpheres[removeAtIndex] = this.m_CachedBoundingSpheres[this.m_DecalsCount - 1];
			}

			// Token: 0x06001318 RID: 4888 RVA: 0x00092750 File Offset: 0x00090950
			private void DisposeJobArrays()
			{
				this.m_CachedTransforms.Dispose();
				this.m_Positions.Dispose();
				this.m_Rotations.Dispose();
				this.m_Scales.Dispose();
				this.m_Sizes.Dispose();
				this.m_Offsets.Dispose();
				this.m_ResolvedRotations.Dispose();
				this.m_ResolvedScales.Dispose();
				this.m_ResolvedSizeOffsets.Dispose();
				this.m_ScaleModes.Dispose();
				this.m_NormalToWorlds.Dispose();
				this.m_DecalToWorlds.Dispose();
				this.m_BoundingSpheres.Dispose();
				this.m_Dirty.Dispose();
				this.m_CachedBoundingSpheres = null;
			}

			// Token: 0x06001319 RID: 4889 RVA: 0x00092800 File Offset: 0x00090A00
			internal void StartUpdateJob()
			{
				this.m_UpdateJobHandle.Complete();
				DecalSystem.UpdateJob jobData = new DecalSystem.UpdateJob
				{
					positions = this.m_Positions,
					rawRotations = this.m_Rotations,
					rawScales = this.m_Scales,
					resolvedScales = this.m_ResolvedScales,
					resolvedRotations = this.m_ResolvedRotations,
					resolvedSizesOffsets = this.m_ResolvedSizeOffsets,
					dirty = this.m_Dirty,
					rawSizes = this.m_Sizes,
					rawOffsets = this.m_Offsets,
					scaleModes = this.m_ScaleModes,
					normalToWorlds = this.m_NormalToWorlds,
					decalToWorlds = this.m_DecalToWorlds,
					boundingSpheres = this.m_BoundingSpheres,
					minDistance = float.Epsilon
				};
				this.m_UpdateJobHandle = jobData.Schedule(this.m_CachedTransforms, default(JobHandle));
			}

			// Token: 0x04002436 RID: 9270
			private List<Matrix4x4[]> m_DecalToWorld = new List<Matrix4x4[]>();

			// Token: 0x04002437 RID: 9271
			private List<Matrix4x4[]> m_NormalToWorld = new List<Matrix4x4[]>();

			// Token: 0x04002438 RID: 9272
			private List<float[]> m_DecalLayerMasks = new List<float[]>();

			// Token: 0x04002439 RID: 9273
			private DecalSystem.DecalHandle[] m_Handles = new DecalSystem.DecalHandle[128];

			// Token: 0x0400243A RID: 9274
			private int[] m_ResultIndices = new int[128];

			// Token: 0x0400243B RID: 9275
			private int m_NumResults;

			// Token: 0x0400243C RID: 9276
			private int m_InstanceCount;

			// Token: 0x0400243D RID: 9277
			private int m_DecalsCount;

			// Token: 0x0400243E RID: 9278
			private int m_CachedDrawOrder;

			// Token: 0x0400243F RID: 9279
			private Vector2[] m_CachedDrawDistances = new Vector2[128];

			// Token: 0x04002440 RID: 9280
			private Vector2[] m_CachedAngleFade = new Vector2[128];

			// Token: 0x04002441 RID: 9281
			private Vector4[] m_CachedUVScaleBias = new Vector4[128];

			// Token: 0x04002442 RID: 9282
			private bool[] m_CachedAffectsTransparency = new bool[128];

			// Token: 0x04002443 RID: 9283
			private int[] m_CachedLayerMask = new int[128];

			// Token: 0x04002444 RID: 9284
			private DecalLayerEnum[] m_CachedDecalLayerMask = new DecalLayerEnum[128];

			// Token: 0x04002445 RID: 9285
			private ulong[] m_CachedSceneLayerMask = new ulong[128];

			// Token: 0x04002446 RID: 9286
			private float[] m_CachedFadeFactor = new float[128];

			// Token: 0x04002447 RID: 9287
			private Material m_Material;

			// Token: 0x04002448 RID: 9288
			private MaterialPropertyBlock m_PropertyBlock = new MaterialPropertyBlock();

			// Token: 0x04002449 RID: 9289
			private float m_Blend;

			// Token: 0x0400244A RID: 9290
			private Vector4 m_BaseColor;

			// Token: 0x0400244B RID: 9291
			private Vector4 m_RemappingAOS;

			// Token: 0x0400244C RID: 9292
			private Vector4 m_ScalingBAndRemappingM;

			// Token: 0x0400244D RID: 9293
			private Vector3 m_BlendParams;

			// Token: 0x0400244E RID: 9294
			private bool m_IsHDRenderPipelineDecal;

			// Token: 0x0400244F RID: 9295
			private int m_cachedProjectorPassValue;

			// Token: 0x04002450 RID: 9296
			private int m_cachedProjectorEmissivePassValue;

			// Token: 0x04002451 RID: 9297
			private DecalSystem.TextureScaleBias m_Diffuse = new DecalSystem.TextureScaleBias();

			// Token: 0x04002452 RID: 9298
			private DecalSystem.TextureScaleBias m_Normal = new DecalSystem.TextureScaleBias();

			// Token: 0x04002453 RID: 9299
			private DecalSystem.TextureScaleBias m_Mask = new DecalSystem.TextureScaleBias();

			// Token: 0x04002454 RID: 9300
			private JobHandle m_UpdateJobHandle;

			// Token: 0x04002455 RID: 9301
			private TransformAccessArray m_CachedTransforms = new TransformAccessArray(128, -1);

			// Token: 0x04002456 RID: 9302
			private NativeArray<float3> m_Positions = new NativeArray<float3>(128, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);

			// Token: 0x04002457 RID: 9303
			private NativeArray<quaternion> m_Rotations = new NativeArray<quaternion>(128, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);

			// Token: 0x04002458 RID: 9304
			private NativeArray<float3> m_Scales = new NativeArray<float3>(128, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);

			// Token: 0x04002459 RID: 9305
			private NativeArray<float3> m_Sizes = new NativeArray<float3>(128, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);

			// Token: 0x0400245A RID: 9306
			private NativeArray<float3> m_Offsets = new NativeArray<float3>(128, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);

			// Token: 0x0400245B RID: 9307
			private NativeArray<quaternion> m_ResolvedRotations = new NativeArray<quaternion>(128, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);

			// Token: 0x0400245C RID: 9308
			private NativeArray<float3> m_ResolvedScales = new NativeArray<float3>(128, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);

			// Token: 0x0400245D RID: 9309
			private NativeArray<float4x4> m_ResolvedSizeOffsets = new NativeArray<float4x4>(128, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);

			// Token: 0x0400245E RID: 9310
			private NativeArray<DecalScaleMode> m_ScaleModes = new NativeArray<DecalScaleMode>(128, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);

			// Token: 0x0400245F RID: 9311
			private NativeArray<float4x4> m_NormalToWorlds = new NativeArray<float4x4>(128, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);

			// Token: 0x04002460 RID: 9312
			private NativeArray<float4x4> m_DecalToWorlds = new NativeArray<float4x4>(128, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);

			// Token: 0x04002461 RID: 9313
			private NativeArray<BoundingSphere> m_BoundingSpheres = new NativeArray<BoundingSphere>(128, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);

			// Token: 0x04002462 RID: 9314
			private NativeArray<bool> m_Dirty = new NativeArray<bool>(128, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);

			// Token: 0x04002463 RID: 9315
			private BoundingSphere[] m_CachedBoundingSpheres = new BoundingSphere[128];
		}

		// Token: 0x02000381 RID: 897
		[BurstCompile]
		internal struct UpdateJob : IJobParallelForTransform
		{
			// Token: 0x0600131A RID: 4890 RVA: 0x000928F2 File Offset: 0x00090AF2
			private float DistanceBetweenQuaternions(quaternion a, quaternion b)
			{
				return math.distancesq(a.value, b.value);
			}

			// Token: 0x0600131B RID: 4891 RVA: 0x00092908 File Offset: 0x00090B08
			private float3 effectiveScale(int index, in TransformAccess transform)
			{
				if (this.scaleModes[index] != DecalScaleMode.InheritFromHierarchy)
				{
					return DecalSystem.UpdateJob.sFloat3One;
				}
				TransformAccess transformAccess = transform;
				return transformAccess.localToWorldMatrix.lossyScale;
			}

			// Token: 0x0600131C RID: 4892 RVA: 0x00092948 File Offset: 0x00090B48
			private float3 resolveDecalSize(int index, float3 scale, in TransformAccess transform)
			{
				if (scale.z < 0f)
				{
					scale.y *= -1f;
				}
				if (scale.x < 0f ^ scale.y < 0f ^ scale.z < 0f)
				{
					scale.z *= -1f;
				}
				float3 @float = this.rawSizes[index];
				return new float3(@float.x * scale.x, @float.z * scale.z, @float.y * scale.y);
			}

			// Token: 0x0600131D RID: 4893 RVA: 0x000929E8 File Offset: 0x00090BE8
			private float3 resolveDecalOffset(int index, float3 scale, in TransformAccess transform)
			{
				if (scale.z < 0f)
				{
					scale.y *= -1f;
					scale.z *= -1f;
				}
				float3 @float = this.rawOffsets[index];
				return new float3(@float.x * scale.x, -@float.z * scale.z, @float.y * scale.y);
			}

			// Token: 0x0600131E RID: 4894 RVA: 0x00092A5C File Offset: 0x00090C5C
			private quaternion resolveRotation(int index, in float3 scale, in TransformAccess transform)
			{
				TransformAccess transformAccess = transform;
				return transformAccess.rotation * ((scale.z >= 0f) ? DecalSystem.UpdateJob.k_MinusYtoZRotation : DecalSystem.UpdateJob.k_YtoZRotation);
			}

			// Token: 0x0600131F RID: 4895 RVA: 0x00092AA0 File Offset: 0x00090CA0
			public void Execute(int index, TransformAccess transform)
			{
				bool flag = this.dirty[index];
				bool flag2 = math.distancesq(transform.position, this.positions[index]) > this.minDistance;
				if (flag2)
				{
					this.positions[index] = transform.position;
				}
				bool flag3 = math.distancesq(transform.localToWorldMatrix.lossyScale, this.rawScales[index]) > this.minDistance;
				if (flag3)
				{
					this.rawScales[index] = transform.localToWorldMatrix.lossyScale;
				}
				if (flag3 || flag)
				{
					this.resolvedScales[index] = this.effectiveScale(index, transform);
				}
				bool flag4 = this.DistanceBetweenQuaternions(transform.rotation, this.rawRotations[index]) > this.minDistance;
				if (flag4)
				{
					this.rawRotations[index] = transform.rotation;
				}
				if (flag4 || flag)
				{
					float3 @float = this.resolvedScales[index];
					this.resolvedRotations[index] = this.resolveRotation(index, @float, transform);
				}
				if (!flag2 && !flag4 && !flag3 && !flag)
				{
					return;
				}
				if (flag || flag4 || flag3)
				{
					this.resolvedSizesOffsets[index] = math.mul(float4x4.Translate(this.resolveDecalOffset(index, this.resolvedScales[index], transform)), float4x4.Scale(this.resolveDecalSize(index, this.resolvedScales[index], transform)));
				}
				float4x4 float4x;
				float4x4 a = float4x = float4x4.TRS(transform.position, this.resolvedRotations[index], DecalSystem.UpdateJob.sFloat3One);
				float4 c = float4x.c1;
				float4x.c1 = float4x.c2;
				float4x.c2 = c;
				this.normalToWorlds[index] = float4x;
				float4x4 b = this.resolvedSizesOffsets[index];
				float4x4 float4x2 = math.mul(a, b);
				this.decalToWorlds[index] = float4x2;
				this.boundingSpheres[index] = this.GetDecalProjectBoundingSphere(float4x2);
				this.dirty[index] = false;
			}

			// Token: 0x06001320 RID: 4896 RVA: 0x00092CC8 File Offset: 0x00090EC8
			private BoundingSphere GetDecalProjectBoundingSphere(Matrix4x4 decalToWorld)
			{
				float4 @float = new float4(-0.5f, -0.5f, -0.5f, 1f);
				float4 float2 = new float4(0.5f, 0.5f, 0.5f, 1f);
				@float = math.mul(decalToWorld, @float);
				float2 = math.mul(decalToWorld, float2);
				float3 xyz = ((float2 + @float) / 2f).xyz;
				float radius = math.length(float2 - @float) / 2f;
				return new BoundingSphere
				{
					position = xyz,
					radius = radius
				};
			}

			// Token: 0x04002464 RID: 9316
			private static readonly quaternion k_MinusYtoZRotation = quaternion.EulerXYZ(-1.5707964f, 0f, 0f);

			// Token: 0x04002465 RID: 9317
			private static readonly quaternion k_YtoZRotation = quaternion.EulerXYZ(1.5707964f, 0f, 0f);

			// Token: 0x04002466 RID: 9318
			private static readonly float3 sFloat3One = new float3(1f, 1f, 1f);

			// Token: 0x04002467 RID: 9319
			public float minDistance;

			// Token: 0x04002468 RID: 9320
			public NativeArray<float3> positions;

			// Token: 0x04002469 RID: 9321
			public NativeArray<quaternion> rawRotations;

			// Token: 0x0400246A RID: 9322
			public NativeArray<float3> rawScales;

			// Token: 0x0400246B RID: 9323
			public NativeArray<float3> resolvedScales;

			// Token: 0x0400246C RID: 9324
			public NativeArray<quaternion> resolvedRotations;

			// Token: 0x0400246D RID: 9325
			public NativeArray<float4x4> resolvedSizesOffsets;

			// Token: 0x0400246E RID: 9326
			public NativeArray<bool> dirty;

			// Token: 0x0400246F RID: 9327
			[ReadOnly]
			public NativeArray<float3> rawSizes;

			// Token: 0x04002470 RID: 9328
			[ReadOnly]
			public NativeArray<float3> rawOffsets;

			// Token: 0x04002471 RID: 9329
			[ReadOnly]
			public NativeArray<DecalScaleMode> scaleModes;

			// Token: 0x04002472 RID: 9330
			[WriteOnly]
			public NativeArray<float4x4> normalToWorlds;

			// Token: 0x04002473 RID: 9331
			[WriteOnly]
			public NativeArray<float4x4> decalToWorlds;

			// Token: 0x04002474 RID: 9332
			[WriteOnly]
			public NativeArray<BoundingSphere> boundingSpheres;
		}
	}
}
