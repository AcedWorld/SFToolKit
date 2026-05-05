using System;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001CB RID: 459
	internal class Texture3DAtlasDynamic
	{
		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000E42 RID: 3650 RVA: 0x00071AC8 File Offset: 0x0006FCC8
		public RTHandle AtlasTexture
		{
			get
			{
				return this.m_AtlasTexture;
			}
		}

		// Token: 0x06000E43 RID: 3651 RVA: 0x00071AD0 File Offset: 0x0006FCD0
		public Texture3DAtlasDynamic(int width, int height, int depth, int capacity, GraphicsFormat format)
		{
			this.m_Width = width;
			this.m_Height = height;
			this.m_Depth = depth;
			this.m_Format = format;
			this.m_AtlasTexture = RTHandles.Alloc(this.m_Width, this.m_Height, this.m_Depth, DepthBits.None, this.m_Format, FilterMode.Point, TextureWrapMode.Clamp, TextureDimension.Tex3D, false, true, false, false, 1, 0f, MSAASamples.None, false, false, RenderTextureMemoryless.None, VRTextureUsage.None, "");
			this.isAtlasTextureOwner = true;
			this.m_AtlasAllocator = new Atlas3DAllocatorDynamic(width, height, depth, capacity);
			this.m_AllocationCache = new Dictionary<int, Texture3DAtlasDynamic.Texture3DAtlasScaleBias>(capacity);
		}

		// Token: 0x06000E44 RID: 3652 RVA: 0x00071B60 File Offset: 0x0006FD60
		public Texture3DAtlasDynamic(int width, int height, int depth, int capacity, RTHandle atlasTexture)
		{
			this.m_Width = width;
			this.m_Height = height;
			this.m_Depth = depth;
			this.m_Format = atlasTexture.rt.graphicsFormat;
			this.m_AtlasTexture = atlasTexture;
			this.isAtlasTextureOwner = false;
			this.m_AtlasAllocator = new Atlas3DAllocatorDynamic(width, height, depth, capacity);
			this.m_AllocationCache = new Dictionary<int, Texture3DAtlasDynamic.Texture3DAtlasScaleBias>(capacity);
		}

		// Token: 0x06000E45 RID: 3653 RVA: 0x00071BC6 File Offset: 0x0006FDC6
		public void Release()
		{
			this.ResetAllocator();
			if (this.isAtlasTextureOwner)
			{
				RTHandles.Release(this.m_AtlasTexture);
			}
		}

		// Token: 0x06000E46 RID: 3654 RVA: 0x00071BE1 File Offset: 0x0006FDE1
		public void ResetAllocator()
		{
			this.m_AtlasAllocator.Release();
			this.m_AllocationCache.Clear();
		}

		// Token: 0x06000E47 RID: 3655 RVA: 0x00071BFC File Offset: 0x0006FDFC
		public bool TryGetScaleBias(out Vector3 scale, out Vector3 bias, int key)
		{
			Texture3DAtlasDynamic.Texture3DAtlasScaleBias texture3DAtlasScaleBias;
			if (this.m_AllocationCache.TryGetValue(key, out texture3DAtlasScaleBias))
			{
				scale = texture3DAtlasScaleBias.scale;
				bias = texture3DAtlasScaleBias.bias;
				return true;
			}
			scale = Vector3.zero;
			bias = Vector3.zero;
			return false;
		}

		// Token: 0x06000E48 RID: 3656 RVA: 0x00071C4C File Offset: 0x0006FE4C
		public bool EnsureTextureSlot(out bool isUploadNeeded, out Vector3 scale, out Vector3 bias, int key, int width, int height, int depth)
		{
			isUploadNeeded = false;
			Texture3DAtlasDynamic.Texture3DAtlasScaleBias texture3DAtlasScaleBias;
			if (this.m_AllocationCache.TryGetValue(key, out texture3DAtlasScaleBias))
			{
				scale = texture3DAtlasScaleBias.scale;
				bias = texture3DAtlasScaleBias.bias;
				return true;
			}
			if (!this.m_AtlasAllocator.Allocate(out scale, out bias, key, width, height, depth))
			{
				return false;
			}
			isUploadNeeded = true;
			scale.Scale(new Vector3(1f / (float)this.m_Width, 1f / (float)this.m_Height, 1f / (float)this.m_Depth));
			bias.Scale(new Vector3(1f / (float)this.m_Width, 1f / (float)this.m_Height, 1f / (float)this.m_Depth));
			this.m_AllocationCache.Add(key, new Texture3DAtlasDynamic.Texture3DAtlasScaleBias
			{
				scale = scale,
				bias = bias
			});
			return true;
		}

		// Token: 0x06000E49 RID: 3657 RVA: 0x00071D38 File Offset: 0x0006FF38
		public void ReleaseTextureSlot(int key)
		{
			this.m_AtlasAllocator.Release(key);
			this.m_AllocationCache.Remove(key);
		}

		// Token: 0x06000E4A RID: 3658 RVA: 0x00071D53 File Offset: 0x0006FF53
		public string DebugStringFromRoot(int depthMax = -1)
		{
			return this.m_AtlasAllocator.DebugStringFromRoot(depthMax);
		}

		// Token: 0x040015D4 RID: 5588
		private RTHandle m_AtlasTexture;

		// Token: 0x040015D5 RID: 5589
		private bool isAtlasTextureOwner;

		// Token: 0x040015D6 RID: 5590
		private int m_Width;

		// Token: 0x040015D7 RID: 5591
		private int m_Height;

		// Token: 0x040015D8 RID: 5592
		private int m_Depth;

		// Token: 0x040015D9 RID: 5593
		private GraphicsFormat m_Format;

		// Token: 0x040015DA RID: 5594
		private Atlas3DAllocatorDynamic m_AtlasAllocator;

		// Token: 0x040015DB RID: 5595
		private Dictionary<int, Texture3DAtlasDynamic.Texture3DAtlasScaleBias> m_AllocationCache;

		// Token: 0x02000410 RID: 1040
		private struct Texture3DAtlasScaleBias
		{
			// Token: 0x040028E9 RID: 10473
			public Vector3 scale;

			// Token: 0x040028EA RID: 10474
			public Vector3 bias;
		}
	}
}
