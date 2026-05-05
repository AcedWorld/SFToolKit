using System;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering
{
	// Token: 0x020000C2 RID: 194
	internal class Texture2DAtlasDynamic
	{
		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000601 RID: 1537 RVA: 0x0001E87E File Offset: 0x0001CA7E
		public RTHandle AtlasTexture
		{
			get
			{
				return this.m_AtlasTexture;
			}
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x0001E888 File Offset: 0x0001CA88
		public Texture2DAtlasDynamic(int width, int height, int capacity, GraphicsFormat format)
		{
			this.m_Width = width;
			this.m_Height = height;
			this.m_Format = format;
			this.m_AtlasTexture = RTHandles.Alloc(this.m_Width, this.m_Height, 1, DepthBits.None, this.m_Format, FilterMode.Point, TextureWrapMode.Clamp, TextureDimension.Tex2D, false, true, false, false, 1, 0f, MSAASamples.None, false, false, RenderTextureMemoryless.None, VRTextureUsage.None, "");
			this.isAtlasTextureOwner = true;
			this.m_AtlasAllocator = new AtlasAllocatorDynamic(width, height, capacity);
			this.m_AllocationCache = new Dictionary<int, Vector4>(capacity);
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x0001E908 File Offset: 0x0001CB08
		public Texture2DAtlasDynamic(int width, int height, int capacity, RTHandle atlasTexture)
		{
			this.m_Width = width;
			this.m_Height = height;
			this.m_Format = atlasTexture.rt.graphicsFormat;
			this.m_AtlasTexture = atlasTexture;
			this.isAtlasTextureOwner = false;
			this.m_AtlasAllocator = new AtlasAllocatorDynamic(width, height, capacity);
			this.m_AllocationCache = new Dictionary<int, Vector4>(capacity);
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x0001E964 File Offset: 0x0001CB64
		public void Release()
		{
			this.ResetAllocator();
			if (this.isAtlasTextureOwner)
			{
				RTHandles.Release(this.m_AtlasTexture);
			}
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x0001E97F File Offset: 0x0001CB7F
		public void ResetAllocator()
		{
			this.m_AtlasAllocator.Release();
			this.m_AllocationCache.Clear();
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x0001E998 File Offset: 0x0001CB98
		public bool AddTexture(CommandBuffer cmd, out Vector4 scaleOffset, Texture texture)
		{
			int instanceID = texture.GetInstanceID();
			if (this.m_AllocationCache.TryGetValue(instanceID, out scaleOffset))
			{
				return true;
			}
			int width = texture.width;
			int height = texture.height;
			if (this.m_AtlasAllocator.Allocate(out scaleOffset, instanceID, width, height))
			{
				scaleOffset.Scale(new Vector4(1f / (float)this.m_Width, 1f / (float)this.m_Height, 1f / (float)this.m_Width, 1f / (float)this.m_Height));
				for (int i = 0; i < (texture as Texture2D).mipmapCount; i++)
				{
					cmd.SetRenderTarget(this.m_AtlasTexture, i);
					Blitter.BlitQuad(cmd, texture, new Vector4(1f, 1f, 0f, 0f), scaleOffset, i, false);
				}
				this.m_AllocationCache.Add(instanceID, scaleOffset);
				return true;
			}
			return false;
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x0001EA86 File Offset: 0x0001CC86
		public bool IsCached(out Vector4 scaleOffset, int key)
		{
			return this.m_AllocationCache.TryGetValue(key, out scaleOffset);
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x0001EA98 File Offset: 0x0001CC98
		public bool EnsureTextureSlot(out bool isUploadNeeded, out Vector4 scaleOffset, int key, int width, int height)
		{
			isUploadNeeded = false;
			if (this.m_AllocationCache.TryGetValue(key, out scaleOffset))
			{
				return true;
			}
			if (!this.m_AtlasAllocator.Allocate(out scaleOffset, key, width, height))
			{
				return false;
			}
			isUploadNeeded = true;
			scaleOffset.Scale(new Vector4(1f / (float)this.m_Width, 1f / (float)this.m_Height, 1f / (float)this.m_Width, 1f / (float)this.m_Height));
			this.m_AllocationCache.Add(key, scaleOffset);
			return true;
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x0001EB23 File Offset: 0x0001CD23
		public void ReleaseTextureSlot(int key)
		{
			this.m_AtlasAllocator.Release(key);
			this.m_AllocationCache.Remove(key);
		}

		// Token: 0x04000441 RID: 1089
		private RTHandle m_AtlasTexture;

		// Token: 0x04000442 RID: 1090
		private bool isAtlasTextureOwner;

		// Token: 0x04000443 RID: 1091
		private int m_Width;

		// Token: 0x04000444 RID: 1092
		private int m_Height;

		// Token: 0x04000445 RID: 1093
		private GraphicsFormat m_Format;

		// Token: 0x04000446 RID: 1094
		private AtlasAllocatorDynamic m_AtlasAllocator;

		// Token: 0x04000447 RID: 1095
		private Dictionary<int, Vector4> m_AllocationCache;
	}
}
