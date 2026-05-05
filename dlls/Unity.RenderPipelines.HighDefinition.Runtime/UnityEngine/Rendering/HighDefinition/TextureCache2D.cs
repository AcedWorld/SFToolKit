using System;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200002C RID: 44
	internal class TextureCache2D : TextureCache
	{
		// Token: 0x06000070 RID: 112 RVA: 0x00004CF6 File Offset: 0x00002EF6
		public TextureCache2D(string cacheName = "") : base(cacheName, 1)
		{
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00004D00 File Offset: 0x00002F00
		private bool TextureHasMipmaps(Texture texture)
		{
			if (texture is Texture2D)
			{
				return ((Texture2D)texture).mipmapCount > 1;
			}
			return ((RenderTexture)texture).useMipMap;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00004D24 File Offset: 0x00002F24
		public override bool IsCreated()
		{
			return this.m_Cache.IsCreated();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00004D34 File Offset: 0x00002F34
		protected override bool TransferToSlice(CommandBuffer cmd, int sliceIndex, Texture[] textureArray)
		{
			if (textureArray == null || (textureArray.Length == 0 && !(textureArray[0] is RenderTexture) && !(textureArray[0] is Texture2D)))
			{
				return false;
			}
			for (int i = 1; i < textureArray.Length; i++)
			{
				if (textureArray[i].width != textureArray[0].width || textureArray[i].height != textureArray[0].height || (!(textureArray[0] is RenderTexture) && !(textureArray[0] is Texture2D)))
				{
					Debug.LogWarning("All the sub-textures should have the same dimensions to be handled by the texture cache.");
					return false;
				}
			}
			bool flag = this.m_Cache.width != textureArray[0].width || this.m_Cache.height != textureArray[0].height;
			if (textureArray[0] is Texture2D)
			{
				flag |= (this.m_Cache.graphicsFormat != (textureArray[0] as Texture2D).graphicsFormat);
			}
			for (int j = 0; j < textureArray.Length; j++)
			{
				if (!this.TextureHasMipmaps(textureArray[j]))
				{
					string str = "The texture '";
					Texture texture = textureArray[j];
					Debug.LogWarning(str + ((texture != null) ? texture.ToString() : null) + "' should have mipmaps to be handled by the cookie texture array");
				}
				if (flag)
				{
					cmd.Blit(textureArray[j], this.m_Cache, 0, this.m_SliceSize * sliceIndex + j);
				}
				else
				{
					cmd.CopyTexture(textureArray[j], 0, this.m_Cache, this.m_SliceSize * sliceIndex + j);
				}
			}
			return true;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00004E98 File Offset: 0x00003098
		public override Texture GetTexCache()
		{
			return this.m_Cache;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00004EA0 File Offset: 0x000030A0
		public bool AllocTextureArray(int numTextures, int width, int height, GraphicsFormat format, bool isMipMapped)
		{
			bool result = base.AllocTextureArray(numTextures);
			this.m_NumMipLevels = base.GetNumMips(width, height);
			RenderTextureDescriptor desc = new RenderTextureDescriptor(width, height, format, 0)
			{
				dimension = TextureDimension.Tex2DArray,
				volumeDepth = numTextures,
				useMipMap = isMipMapped,
				msaaSamples = 1
			};
			this.m_Cache = new RenderTexture(desc)
			{
				hideFlags = HideFlags.HideAndDontSave,
				wrapMode = TextureWrapMode.Clamp,
				name = CoreUtils.GetTextureAutoName(width, height, format, TextureDimension.Tex2DArray, this.m_CacheName, false, numTextures)
			};
			this.ClearCache();
			this.m_Cache.Create();
			return result;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00004F38 File Offset: 0x00003138
		internal void ClearCache()
		{
			RenderTextureDescriptor descriptor = this.m_Cache.descriptor;
			int num = descriptor.useMipMap ? base.GetNumMips(descriptor.width, descriptor.height) : 1;
			for (int i = 0; i < num; i++)
			{
				Graphics.SetRenderTarget(this.m_Cache, i, CubemapFace.Unknown, -1);
				GL.Clear(false, true, Color.clear);
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00004F98 File Offset: 0x00003198
		public void Release()
		{
			CoreUtils.Destroy(this.m_Cache);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00004FA5 File Offset: 0x000031A5
		internal static long GetApproxCacheSizeInByte(int nbElement, int resolution, int sliceSize)
		{
			return (long)((float)((long)nbElement * (long)resolution * (long)resolution * 2L * 4L) * 1.33f * (float)sliceSize);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00004FC0 File Offset: 0x000031C0
		internal static int GetMaxCacheSizeForWeightInByte(int weight, int resolution, int sliceSize)
		{
			return Mathf.Clamp(Mathf.FloorToInt((float)weight / ((float)((long)resolution * (long)resolution * 2L * 4L) * 1.33f * (float)sliceSize)), 1, 250);
		}

		// Token: 0x040000BE RID: 190
		private RenderTexture m_Cache;
	}
}
