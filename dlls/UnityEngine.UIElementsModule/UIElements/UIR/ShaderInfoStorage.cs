using System;
using Unity.Collections;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000460 RID: 1120
	internal class ShaderInfoStorage<T> : BaseShaderInfoStorage where T : struct
	{
		// Token: 0x060022FB RID: 8955 RVA: 0x000878AC File Offset: 0x00085AAC
		public ShaderInfoStorage(TextureFormat format, Func<Color, T> convert, int initialSize = 64, int maxSize = 4096)
		{
			Debug.Assert(maxSize <= SystemInfo.maxTextureSize);
			Debug.Assert(initialSize <= maxSize);
			Debug.Assert(Mathf.IsPowerOfTwo(initialSize));
			Debug.Assert(Mathf.IsPowerOfTwo(maxSize));
			Debug.Assert(convert != null);
			this.m_InitialSize = initialSize;
			this.m_MaxSize = maxSize;
			this.m_Format = format;
			this.m_Convert = convert;
		}

		// Token: 0x060022FC RID: 8956 RVA: 0x00087924 File Offset: 0x00085B24
		protected override void Dispose(bool disposing)
		{
			bool flag = !base.disposed && disposing;
			if (flag)
			{
				UIRUtility.Destroy(this.m_Texture);
				this.m_Texture = null;
				this.m_Texels = default(NativeArray<T>);
				UIRAtlasAllocator allocator = this.m_Allocator;
				if (allocator != null)
				{
					allocator.Dispose();
				}
				this.m_Allocator = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x170007F2 RID: 2034
		// (get) Token: 0x060022FD RID: 8957 RVA: 0x00087983 File Offset: 0x00085B83
		public override Texture2D texture
		{
			get
			{
				return this.m_Texture;
			}
		}

		// Token: 0x060022FE RID: 8958 RVA: 0x0008798C File Offset: 0x00085B8C
		public override bool AllocateRect(int width, int height, out RectInt uvs)
		{
			bool disposed = base.disposed;
			bool result;
			if (disposed)
			{
				DisposeHelper.NotifyDisposedUsed(this);
				uvs = default(RectInt);
				result = false;
			}
			else
			{
				bool flag = this.m_Allocator == null;
				if (flag)
				{
					this.m_Allocator = new UIRAtlasAllocator(this.m_InitialSize, this.m_MaxSize, 0);
				}
				bool flag2 = !this.m_Allocator.TryAllocate(width, height, out uvs);
				if (flag2)
				{
					result = false;
				}
				else
				{
					uvs = new RectInt(uvs.x, uvs.y, width, height);
					this.CreateOrExpandTexture();
					result = true;
				}
			}
			return result;
		}

		// Token: 0x060022FF RID: 8959 RVA: 0x00087A1C File Offset: 0x00085C1C
		public override void SetTexel(int x, int y, Color color)
		{
			bool disposed = base.disposed;
			if (disposed)
			{
				DisposeHelper.NotifyDisposedUsed(this);
			}
			else
			{
				bool flag = !this.m_Texels.IsCreated;
				if (flag)
				{
					this.m_Texels = this.m_Texture.GetRawTextureData<T>();
				}
				this.m_Texels[x + y * this.m_Texture.width] = this.m_Convert(color);
			}
		}

		// Token: 0x06002300 RID: 8960 RVA: 0x00087A8C File Offset: 0x00085C8C
		public override void UpdateTexture()
		{
			bool disposed = base.disposed;
			if (disposed)
			{
				DisposeHelper.NotifyDisposedUsed(this);
			}
			else
			{
				bool flag = this.m_Texture == null || !this.m_Texels.IsCreated;
				if (!flag)
				{
					this.m_Texture.Apply(false, false);
					this.m_Texels = default(NativeArray<T>);
				}
			}
		}

		// Token: 0x06002301 RID: 8961 RVA: 0x00087AF0 File Offset: 0x00085CF0
		private void CreateOrExpandTexture()
		{
			int physicalWidth = this.m_Allocator.physicalWidth;
			int physicalHeight = this.m_Allocator.physicalHeight;
			bool flag = false;
			bool flag2 = this.m_Texture != null;
			if (flag2)
			{
				bool flag3 = this.m_Texture.width == physicalWidth && this.m_Texture.height == physicalHeight;
				if (flag3)
				{
					return;
				}
				flag = true;
			}
			Texture2D texture2D = new Texture2D(this.m_Allocator.physicalWidth, this.m_Allocator.physicalHeight, this.m_Format, false)
			{
				name = "UIR Shader Info " + BaseShaderInfoStorage.s_TextureCounter++.ToString(),
				hideFlags = HideFlags.HideAndDontSave,
				filterMode = FilterMode.Point
			};
			bool flag4 = flag;
			if (flag4)
			{
				NativeArray<T> src = this.m_Texels.IsCreated ? this.m_Texels : this.m_Texture.GetRawTextureData<T>();
				NativeArray<T> rawTextureData = texture2D.GetRawTextureData<T>();
				ShaderInfoStorage<T>.CpuBlit(src, this.m_Texture.width, this.m_Texture.height, rawTextureData, texture2D.width, texture2D.height);
				this.m_Texels = rawTextureData;
			}
			else
			{
				this.m_Texels = default(NativeArray<T>);
			}
			UIRUtility.Destroy(this.m_Texture);
			this.m_Texture = texture2D;
		}

		// Token: 0x06002302 RID: 8962 RVA: 0x00087C3C File Offset: 0x00085E3C
		private static void CpuBlit(NativeArray<T> src, int srcWidth, int srcHeight, NativeArray<T> dst, int dstWidth, int dstHeight)
		{
			Debug.Assert(dstWidth >= srcWidth && dstHeight >= srcHeight);
			int num = dstWidth - srcWidth;
			int num2 = dstHeight - srcHeight;
			int num3 = srcWidth * srcHeight;
			int i = 0;
			int num4 = 0;
			int num5 = srcWidth;
			while (i < num3)
			{
				while (i < num5)
				{
					dst[num4] = src[i];
					num4++;
					i++;
				}
				num5 += srcWidth;
				num4 += num;
			}
		}

		// Token: 0x0400101D RID: 4125
		private readonly int m_InitialSize;

		// Token: 0x0400101E RID: 4126
		private readonly int m_MaxSize;

		// Token: 0x0400101F RID: 4127
		private readonly TextureFormat m_Format;

		// Token: 0x04001020 RID: 4128
		private readonly Func<Color, T> m_Convert;

		// Token: 0x04001021 RID: 4129
		private UIRAtlasAllocator m_Allocator;

		// Token: 0x04001022 RID: 4130
		private Texture2D m_Texture;

		// Token: 0x04001023 RID: 4131
		private NativeArray<T> m_Texels;
	}
}
