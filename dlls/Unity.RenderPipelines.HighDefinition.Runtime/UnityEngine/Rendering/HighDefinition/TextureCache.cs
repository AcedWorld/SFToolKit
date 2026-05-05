using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200002B RID: 43
	internal abstract class TextureCache
	{
		// Token: 0x0600005D RID: 93 RVA: 0x00004838 File Offset: 0x00002A38
		protected TextureCache(string cacheName, int sliceSize = 1)
		{
			this.m_CacheName = cacheName;
			this.m_SliceSize = sliceSize;
			this.m_NumTextures = 0;
			this.m_NumMipLevels = 0;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00004868 File Offset: 0x00002A68
		public virtual bool IsCreated()
		{
			return true;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000486B File Offset: 0x00002A6B
		public string GetCacheName()
		{
			return this.m_CacheName;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00004873 File Offset: 0x00002A73
		public int GetNumMipLevels()
		{
			return this.m_NumMipLevels;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000487C File Offset: 0x00002A7C
		protected bool AllocTextureArray(int numTextures)
		{
			if (numTextures >= this.m_SliceSize)
			{
				this.m_SliceArray = new TextureCache.SliceEntry[numTextures];
				this.m_SortedIdxArray = new int[numTextures];
				this.m_LocatorInSliceDictionnary = new Dictionary<uint, int>();
				this.m_NumTextures = numTextures / this.m_SliceSize;
				for (int i = 0; i < this.m_NumTextures; i++)
				{
					this.m_SliceArray[i].countLRU = TextureCache.g_MaxFrameCount;
					this.m_SliceArray[i].texId = TextureCache.g_InvalidTexID;
					this.m_SortedIdxArray[i] = i;
				}
			}
			return numTextures >= this.m_SliceSize;
		}

		// Token: 0x06000062 RID: 98
		public abstract Texture GetTexCache();

		// Token: 0x06000063 RID: 99 RVA: 0x00004918 File Offset: 0x00002B18
		public int ReserveSlice(Texture texture, uint textureHash, out bool needUpdate)
		{
			needUpdate = false;
			if (texture == null)
			{
				return -1;
			}
			uint instanceID = (uint)texture.GetInstanceID();
			if (instanceID == TextureCache.g_InvalidTexID)
			{
				return -1;
			}
			int num = -1;
			if (this.m_LocatorInSliceDictionnary.TryGetValue(instanceID, out num))
			{
				needUpdate |= (this.m_SliceArray[num].sliceEntryHash != textureHash);
			}
			else
			{
				bool flag = false;
				int num2 = 0;
				int num3 = 0;
				while (!flag && num2 < this.m_NumTextures)
				{
					num3 = this.m_SortedIdxArray[num2];
					if (this.m_SliceArray[num3].countLRU == 0U)
					{
						num2++;
					}
					else
					{
						flag = true;
					}
				}
				if (flag)
				{
					needUpdate = true;
					if (this.m_SliceArray[num3].texId != TextureCache.g_InvalidTexID)
					{
						this.m_LocatorInSliceDictionnary.Remove(this.m_SliceArray[num3].texId);
					}
					this.m_LocatorInSliceDictionnary.Add(instanceID, num3);
					this.m_SliceArray[num3].texId = instanceID;
					num = num3;
				}
			}
			if (num != -1)
			{
				this.m_SliceArray[num].countLRU = 0U;
			}
			needUpdate |= !this.IsCreated();
			return num;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00004A38 File Offset: 0x00002C38
		public bool UpdateSlice(CommandBuffer cmd, int sliceIndex, Texture[] contentArray, uint textureHash)
		{
			this.SetSliceHash(sliceIndex, textureHash);
			return this.TransferToSlice(cmd, sliceIndex, contentArray);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00004A4C File Offset: 0x00002C4C
		public bool UpdateSlice(CommandBuffer cmd, int sliceIndex, Texture texture, uint textureHash)
		{
			this.SetSliceHash(sliceIndex, textureHash);
			this.m_autoContentArray[0] = texture;
			return this.TransferToSlice(cmd, sliceIndex, this.m_autoContentArray);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00004A6E File Offset: 0x00002C6E
		public void SetSliceHash(int sliceIndex, uint hash)
		{
			this.m_SliceArray[sliceIndex].sliceEntryHash = hash;
		}

		// Token: 0x06000067 RID: 103
		protected abstract bool TransferToSlice(CommandBuffer cmd, int sliceIndex, Texture[] textureArray);

		// Token: 0x06000068 RID: 104 RVA: 0x00004A84 File Offset: 0x00002C84
		public int FetchSlice(CommandBuffer cmd, Texture texture, uint textureHash, bool forceReinject = false)
		{
			bool flag = false;
			int num = this.ReserveSlice(texture, textureHash, out flag);
			bool flag2 = forceReinject || flag;
			if (num != -1 && flag2)
			{
				this.m_autoContentArray[0] = texture;
				this.UpdateSlice(cmd, num, this.m_autoContentArray, textureHash);
			}
			return num;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00004AC8 File Offset: 0x00002CC8
		public void NewFrame()
		{
			int num = 0;
			TextureCache.s_TempIntList.Clear();
			for (int i = 0; i < this.m_NumTextures; i++)
			{
				TextureCache.s_TempIntList.Add(this.m_SortedIdxArray[i]);
				if (this.m_SliceArray[this.m_SortedIdxArray[i]].countLRU != 0U)
				{
					num++;
				}
			}
			int num2 = 0;
			int num3 = 0;
			for (int j = 0; j < this.m_NumTextures; j++)
			{
				if (this.m_SliceArray[TextureCache.s_TempIntList[j]].countLRU == 0U)
				{
					this.m_SortedIdxArray[num3 + num] = TextureCache.s_TempIntList[j];
					num3++;
				}
				else
				{
					this.m_SortedIdxArray[num2] = TextureCache.s_TempIntList[j];
					num2++;
				}
			}
			for (int k = 0; k < this.m_NumTextures; k++)
			{
				if (this.m_SliceArray[k].countLRU < TextureCache.g_MaxFrameCount)
				{
					TextureCache.SliceEntry[] sliceArray = this.m_SliceArray;
					int num4 = k;
					sliceArray[num4].countLRU = sliceArray[num4].countLRU + 1U;
				}
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00004BD4 File Offset: 0x00002DD4
		public void RemoveEntryFromSlice(Texture texture)
		{
			uint instanceID = (uint)texture.GetInstanceID();
			if (instanceID == TextureCache.g_InvalidTexID)
			{
				return;
			}
			if (!this.m_LocatorInSliceDictionnary.ContainsKey(instanceID))
			{
				return;
			}
			int num = this.m_LocatorInSliceDictionnary[instanceID];
			bool flag = false;
			int num2 = 0;
			while (!flag && num2 < this.m_NumTextures)
			{
				if (this.m_SortedIdxArray[num2] == num)
				{
					flag = true;
				}
				else
				{
					num2++;
				}
			}
			if (!flag)
			{
				return;
			}
			for (int i = 0; i < num2; i++)
			{
				this.m_SortedIdxArray[i + 1] = this.m_SortedIdxArray[i];
			}
			this.m_SortedIdxArray[0] = num;
			this.m_LocatorInSliceDictionnary.Remove(instanceID);
			this.m_SliceArray[num].countLRU = TextureCache.g_MaxFrameCount;
			this.m_SliceArray[num].texId = TextureCache.g_InvalidTexID;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00004C9C File Offset: 0x00002E9C
		protected int GetNumMips(int width, int height)
		{
			return this.GetNumMips((width > height) ? width : height);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00004CAC File Offset: 0x00002EAC
		protected int GetNumMips(int dim)
		{
			uint num = (uint)dim;
			int num2 = 0;
			while (num > 0U)
			{
				num2++;
				num >>= 1;
			}
			return num2;
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00004CCC File Offset: 0x00002ECC
		public static bool isMobileBuildTarget
		{
			get
			{
				return Application.isMobilePlatform;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00004CD3 File Offset: 0x00002ED3
		public static bool supportsCubemapArrayTextures
		{
			get
			{
				return !GraphicsSettings.HasShaderDefine(BuiltinShaderDefine.UNITY_NO_CUBEMAP_ARRAY);
			}
		}

		// Token: 0x040000AF RID: 175
		protected string m_CacheName;

		// Token: 0x040000B0 RID: 176
		protected int m_NumMipLevels;

		// Token: 0x040000B1 RID: 177
		protected int m_SliceSize;

		// Token: 0x040000B2 RID: 178
		private int m_NumTextures;

		// Token: 0x040000B3 RID: 179
		private Dictionary<uint, int> m_LocatorInSliceDictionnary;

		// Token: 0x040000B4 RID: 180
		private TextureCache.SliceEntry[] m_SliceArray;

		// Token: 0x040000B5 RID: 181
		private int[] m_SortedIdxArray;

		// Token: 0x040000B6 RID: 182
		private Texture[] m_autoContentArray = new Texture[1];

		// Token: 0x040000B7 RID: 183
		private static uint g_MaxFrameCount = uint.MaxValue;

		// Token: 0x040000B8 RID: 184
		private static uint g_InvalidTexID = 0U;

		// Token: 0x040000B9 RID: 185
		protected const int k_FP16SizeInByte = 2;

		// Token: 0x040000BA RID: 186
		protected const int k_NbChannel = 4;

		// Token: 0x040000BB RID: 187
		protected const float k_MipmapFactorApprox = 1.33f;

		// Token: 0x040000BC RID: 188
		internal const int k_MaxSupported = 250;

		// Token: 0x040000BD RID: 189
		private static List<int> s_TempIntList = new List<int>();

		// Token: 0x02000252 RID: 594
		private struct SliceEntry
		{
			// Token: 0x04001A03 RID: 6659
			public uint texId;

			// Token: 0x04001A04 RID: 6660
			public uint countLRU;

			// Token: 0x04001A05 RID: 6661
			public uint sliceEntryHash;
		}
	}
}
