using System;
using UnityEngine.UIElements.UIR;

namespace UnityEngine.UIElements
{
	// Token: 0x020002A8 RID: 680
	internal class DynamicAtlasPage : IDisposable
	{
		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x06001385 RID: 4997 RVA: 0x0004422B File Offset: 0x0004242B
		// (set) Token: 0x06001386 RID: 4998 RVA: 0x00044233 File Offset: 0x00042433
		public TextureId textureId { get; private set; }

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x06001387 RID: 4999 RVA: 0x0004423C File Offset: 0x0004243C
		// (set) Token: 0x06001388 RID: 5000 RVA: 0x00044244 File Offset: 0x00042444
		public RenderTexture atlas { get; private set; }

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x06001389 RID: 5001 RVA: 0x0004424D File Offset: 0x0004244D
		public RenderTextureFormat format { get; }

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x0600138A RID: 5002 RVA: 0x00044255 File Offset: 0x00042455
		public FilterMode filterMode { get; }

		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x0600138B RID: 5003 RVA: 0x0004425D File Offset: 0x0004245D
		public Vector2Int minSize { get; }

		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x0600138C RID: 5004 RVA: 0x00044265 File Offset: 0x00042465
		public Vector2Int maxSize { get; }

		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x0600138D RID: 5005 RVA: 0x0004426D File Offset: 0x0004246D
		public Vector2Int currentSize
		{
			get
			{
				return this.m_CurrentSize;
			}
		}

		// Token: 0x0600138E RID: 5006 RVA: 0x00044278 File Offset: 0x00042478
		public DynamicAtlasPage(RenderTextureFormat format, FilterMode filterMode, Vector2Int minSize, Vector2Int maxSize)
		{
			this.textureId = TextureRegistry.instance.AllocAndAcquireDynamic();
			this.format = format;
			this.filterMode = filterMode;
			this.minSize = minSize;
			this.maxSize = maxSize;
			this.m_Allocator = new Allocator2D(minSize, maxSize, this.m_2Padding);
			this.m_Blitter = new TextureBlitter(64);
		}

		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x0600138F RID: 5007 RVA: 0x000442EA File Offset: 0x000424EA
		// (set) Token: 0x06001390 RID: 5008 RVA: 0x000442F2 File Offset: 0x000424F2
		private protected bool disposed { protected get; private set; }

		// Token: 0x06001391 RID: 5009 RVA: 0x000442FB File Offset: 0x000424FB
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06001392 RID: 5010 RVA: 0x00044310 File Offset: 0x00042510
		protected virtual void Dispose(bool disposing)
		{
			bool disposed = this.disposed;
			if (!disposed)
			{
				if (disposing)
				{
					bool flag = this.atlas != null;
					if (flag)
					{
						UIRUtility.Destroy(this.atlas);
						this.atlas = null;
					}
					bool flag2 = this.m_Allocator != null;
					if (flag2)
					{
						this.m_Allocator = null;
					}
					bool flag3 = this.m_Blitter != null;
					if (flag3)
					{
						this.m_Blitter.Dispose();
						this.m_Blitter = null;
					}
					bool flag4 = this.textureId != TextureId.invalid;
					if (flag4)
					{
						TextureRegistry.instance.Release(this.textureId);
						this.textureId = TextureId.invalid;
					}
				}
				this.disposed = true;
			}
		}

		// Token: 0x06001393 RID: 5011 RVA: 0x000443D8 File Offset: 0x000425D8
		public bool TryAdd(Texture2D image, out Allocator2D.Alloc2D alloc, out RectInt rect)
		{
			bool disposed = this.disposed;
			bool result;
			if (disposed)
			{
				DisposeHelper.NotifyDisposedUsed(this);
				alloc = default(Allocator2D.Alloc2D);
				rect = default(RectInt);
				result = false;
			}
			else
			{
				bool flag = !this.m_Allocator.TryAllocate(image.width + this.m_2Padding, image.height + this.m_2Padding, out alloc);
				if (flag)
				{
					rect = default(RectInt);
					result = false;
				}
				else
				{
					this.m_CurrentSize.x = Mathf.Max(this.m_CurrentSize.x, UIRUtility.GetNextPow2(alloc.rect.xMax));
					this.m_CurrentSize.y = Mathf.Max(this.m_CurrentSize.y, UIRUtility.GetNextPow2(alloc.rect.yMax));
					rect = new RectInt(alloc.rect.xMin + this.m_1Padding, alloc.rect.yMin + this.m_1Padding, image.width, image.height);
					this.Update(image, rect);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06001394 RID: 5012 RVA: 0x000444F0 File Offset: 0x000426F0
		public void Update(Texture2D image, RectInt rect)
		{
			bool disposed = this.disposed;
			if (disposed)
			{
				DisposeHelper.NotifyDisposedUsed(this);
			}
			else
			{
				Debug.Assert(image != null && rect.width > 0 && rect.height > 0);
				this.m_Blitter.QueueBlit(image, new RectInt(0, 0, image.width, image.height), new Vector2Int(rect.x, rect.y), true, Color.white);
			}
		}

		// Token: 0x06001395 RID: 5013 RVA: 0x00044574 File Offset: 0x00042774
		public void Remove(Allocator2D.Alloc2D alloc)
		{
			bool disposed = this.disposed;
			if (disposed)
			{
				DisposeHelper.NotifyDisposedUsed(this);
			}
			else
			{
				Debug.Assert(alloc.rect.width > 0 && alloc.rect.height > 0);
				this.m_Allocator.Free(alloc);
			}
		}

		// Token: 0x06001396 RID: 5014 RVA: 0x000445CC File Offset: 0x000427CC
		public void Commit()
		{
			bool disposed = this.disposed;
			if (disposed)
			{
				DisposeHelper.NotifyDisposedUsed(this);
			}
			else
			{
				this.UpdateAtlasTexture();
				this.m_Blitter.Commit(this.atlas);
			}
		}

		// Token: 0x06001397 RID: 5015 RVA: 0x00044608 File Offset: 0x00042808
		private void UpdateAtlasTexture()
		{
			bool flag = this.atlas == null;
			if (flag)
			{
				this.atlas = this.CreateAtlasTexture();
			}
			else
			{
				bool flag2 = this.atlas.width != this.m_CurrentSize.x || this.atlas.height != this.m_CurrentSize.y;
				if (flag2)
				{
					RenderTexture renderTexture = this.CreateAtlasTexture();
					bool flag3 = renderTexture == null;
					if (flag3)
					{
						Debug.LogErrorFormat("Failed to allocate a render texture for the dynamic atlas. Current Size = {0}x{1}. Requested Size = {2}x{3}.", new object[]
						{
							this.atlas.width,
							this.atlas.height,
							this.m_CurrentSize.x,
							this.m_CurrentSize.y
						});
					}
					else
					{
						this.m_Blitter.BlitOneNow(renderTexture, this.atlas, new RectInt(0, 0, this.atlas.width, this.atlas.height), new Vector2Int(0, 0), false, Color.white);
					}
					UIRUtility.Destroy(this.atlas);
					this.atlas = renderTexture;
				}
			}
		}

		// Token: 0x06001398 RID: 5016 RVA: 0x0004473C File Offset: 0x0004293C
		private RenderTexture CreateAtlasTexture()
		{
			bool flag = this.m_CurrentSize.x == 0 || this.m_CurrentSize.y == 0;
			RenderTexture result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = new RenderTexture(this.m_CurrentSize.x, this.m_CurrentSize.y, 0, this.format)
				{
					hideFlags = HideFlags.HideAndDontSave,
					name = "UIR Dynamic Atlas Page " + DynamicAtlasPage.s_TextureCounter++.ToString(),
					filterMode = this.filterMode
				};
			}
			return result;
		}

		// Token: 0x040008E9 RID: 2281
		private readonly int m_1Padding = 1;

		// Token: 0x040008EA RID: 2282
		private readonly int m_2Padding = 2;

		// Token: 0x040008EB RID: 2283
		private Allocator2D m_Allocator;

		// Token: 0x040008EC RID: 2284
		private TextureBlitter m_Blitter;

		// Token: 0x040008ED RID: 2285
		private Vector2Int m_CurrentSize;

		// Token: 0x040008EE RID: 2286
		private static int s_TextureCounter;
	}
}
