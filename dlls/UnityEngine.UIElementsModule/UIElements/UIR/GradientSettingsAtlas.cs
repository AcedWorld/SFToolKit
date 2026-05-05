using System;
using Unity.Profiling;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000443 RID: 1091
	internal class GradientSettingsAtlas : IDisposable
	{
		// Token: 0x170007D5 RID: 2005
		// (get) Token: 0x06002251 RID: 8785 RVA: 0x00083FCC File Offset: 0x000821CC
		internal int length
		{
			get
			{
				return this.m_Length;
			}
		}

		// Token: 0x170007D6 RID: 2006
		// (get) Token: 0x06002252 RID: 8786 RVA: 0x00083FE4 File Offset: 0x000821E4
		// (set) Token: 0x06002253 RID: 8787 RVA: 0x00083FEC File Offset: 0x000821EC
		private protected bool disposed { protected get; private set; }

		// Token: 0x06002254 RID: 8788 RVA: 0x00083FF5 File Offset: 0x000821F5
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06002255 RID: 8789 RVA: 0x00084008 File Offset: 0x00082208
		protected virtual void Dispose(bool disposing)
		{
			bool disposed = this.disposed;
			if (!disposed)
			{
				if (disposing)
				{
					UIRUtility.Destroy(this.m_Atlas);
				}
				this.disposed = true;
			}
		}

		// Token: 0x06002256 RID: 8790 RVA: 0x0008403F File Offset: 0x0008223F
		public GradientSettingsAtlas(int length = 4096)
		{
			this.m_Length = length;
			this.m_ElemWidth = 3;
			this.Reset();
		}

		// Token: 0x06002257 RID: 8791 RVA: 0x00084060 File Offset: 0x00082260
		public void Reset()
		{
			bool disposed = this.disposed;
			if (disposed)
			{
				DisposeHelper.NotifyDisposedUsed(this);
			}
			else
			{
				this.m_Allocator = new BestFitAllocator((uint)this.m_Length);
				UIRUtility.Destroy(this.m_Atlas);
				this.m_RawAtlas = default(GradientSettingsAtlas.RawTexture);
				this.MustCommit = false;
			}
		}

		// Token: 0x170007D7 RID: 2007
		// (get) Token: 0x06002258 RID: 8792 RVA: 0x000840B4 File Offset: 0x000822B4
		public Texture2D atlas
		{
			get
			{
				return this.m_Atlas;
			}
		}

		// Token: 0x06002259 RID: 8793 RVA: 0x000840CC File Offset: 0x000822CC
		public Alloc Add(int count)
		{
			Debug.Assert(count > 0);
			bool disposed = this.disposed;
			Alloc result;
			if (disposed)
			{
				DisposeHelper.NotifyDisposedUsed(this);
				result = default(Alloc);
			}
			else
			{
				Alloc alloc = this.m_Allocator.Allocate((uint)count);
				result = alloc;
			}
			return result;
		}

		// Token: 0x0600225A RID: 8794 RVA: 0x00084114 File Offset: 0x00082314
		public void Remove(Alloc alloc)
		{
			bool disposed = this.disposed;
			if (disposed)
			{
				DisposeHelper.NotifyDisposedUsed(this);
			}
			else
			{
				this.m_Allocator.Free(alloc);
			}
		}

		// Token: 0x0600225B RID: 8795 RVA: 0x00084144 File Offset: 0x00082344
		public void Write(Alloc alloc, GradientSettings[] settings, GradientRemap remap)
		{
			bool disposed = this.disposed;
			if (disposed)
			{
				DisposeHelper.NotifyDisposedUsed(this);
			}
			else
			{
				bool flag = this.m_RawAtlas.rgba == null;
				if (flag)
				{
					this.m_RawAtlas = new GradientSettingsAtlas.RawTexture
					{
						rgba = new Color32[this.m_ElemWidth * this.m_Length],
						width = this.m_ElemWidth,
						height = this.m_Length
					};
					int num = this.m_ElemWidth * this.m_Length;
					for (int i = 0; i < num; i++)
					{
						this.m_RawAtlas.rgba[i] = Color.black;
					}
				}
				int num2 = (int)alloc.start;
				int j = 0;
				int num3 = settings.Length;
				while (j < num3)
				{
					int num4 = 0;
					GradientSettings gradientSettings = settings[j];
					Debug.Assert(remap == null || num2 == remap.destIndex);
					bool flag2 = gradientSettings.gradientType == GradientType.Radial;
					if (flag2)
					{
						Vector2 vector = gradientSettings.radialFocus;
						vector += Vector2.one;
						vector /= 2f;
						vector.y = 1f - vector.y;
						this.m_RawAtlas.WriteRawFloat4Packed(0.003921569f, (float)gradientSettings.addressMode / 255f, vector.x, vector.y, num4++, num2);
					}
					else
					{
						bool flag3 = gradientSettings.gradientType == GradientType.Linear;
						if (flag3)
						{
							this.m_RawAtlas.WriteRawFloat4Packed(0f, (float)gradientSettings.addressMode / 255f, 0f, 0f, num4++, num2);
						}
					}
					Vector2Int vector2Int = new Vector2Int(gradientSettings.location.x, gradientSettings.location.y);
					Vector2 vector2 = new Vector2((float)(gradientSettings.location.width - 1), (float)(gradientSettings.location.height - 1));
					bool flag4 = remap != null;
					if (flag4)
					{
						vector2Int = new Vector2Int(remap.location.x, remap.location.y);
						vector2 = new Vector2((float)(remap.location.width - 1), (float)(remap.location.height - 1));
					}
					this.m_RawAtlas.WriteRawInt2Packed(vector2Int.x, vector2Int.y, num4++, num2);
					this.m_RawAtlas.WriteRawInt2Packed((int)vector2.x, (int)vector2.y, num4++, num2);
					remap = ((remap != null) ? remap.next : null);
					num2++;
					j++;
				}
				this.MustCommit = true;
			}
		}

		// Token: 0x170007D8 RID: 2008
		// (get) Token: 0x0600225C RID: 8796 RVA: 0x00084405 File Offset: 0x00082605
		// (set) Token: 0x0600225D RID: 8797 RVA: 0x0008440D File Offset: 0x0008260D
		public bool MustCommit { get; private set; }

		// Token: 0x0600225E RID: 8798 RVA: 0x00084418 File Offset: 0x00082618
		public void Commit()
		{
			bool disposed = this.disposed;
			if (disposed)
			{
				DisposeHelper.NotifyDisposedUsed(this);
			}
			else
			{
				bool flag = !this.MustCommit;
				if (!flag)
				{
					this.PrepareAtlas();
					this.m_Atlas.SetPixels32(this.m_RawAtlas.rgba);
					this.m_Atlas.Apply();
					this.MustCommit = false;
				}
			}
		}

		// Token: 0x0600225F RID: 8799 RVA: 0x0008447C File Offset: 0x0008267C
		private void PrepareAtlas()
		{
			bool flag = this.m_Atlas != null;
			if (!flag)
			{
				this.m_Atlas = new Texture2D(this.m_ElemWidth, this.m_Length, TextureFormat.ARGB32, 0, true)
				{
					hideFlags = HideFlags.HideAndDontSave,
					name = "GradientSettings " + GradientSettingsAtlas.s_TextureCounter++.ToString(),
					filterMode = FilterMode.Point
				};
			}
		}

		// Token: 0x04000F2A RID: 3882
		private static ProfilerMarker s_MarkerWrite = new ProfilerMarker("UIR.GradientSettingsAtlas.Write");

		// Token: 0x04000F2B RID: 3883
		private static ProfilerMarker s_MarkerCommit = new ProfilerMarker("UIR.GradientSettingsAtlas.Commit");

		// Token: 0x04000F2C RID: 3884
		private readonly int m_Length;

		// Token: 0x04000F2D RID: 3885
		private readonly int m_ElemWidth;

		// Token: 0x04000F2E RID: 3886
		private BestFitAllocator m_Allocator;

		// Token: 0x04000F2F RID: 3887
		private Texture2D m_Atlas;

		// Token: 0x04000F30 RID: 3888
		private GradientSettingsAtlas.RawTexture m_RawAtlas;

		// Token: 0x04000F31 RID: 3889
		private static int s_TextureCounter;

		// Token: 0x02000444 RID: 1092
		private struct RawTexture
		{
			// Token: 0x06002261 RID: 8801 RVA: 0x00084510 File Offset: 0x00082710
			public void WriteRawInt2Packed(int v0, int v1, int destX, int destY)
			{
				byte b = (byte)(v0 / 255);
				byte g = (byte)(v0 - (int)(b * byte.MaxValue));
				byte b2 = (byte)(v1 / 255);
				byte a = (byte)(v1 - (int)(b2 * byte.MaxValue));
				int num = destY * this.width + destX;
				this.rgba[num] = new Color32(b, g, b2, a);
			}

			// Token: 0x06002262 RID: 8802 RVA: 0x0008456C File Offset: 0x0008276C
			public void WriteRawFloat4Packed(float f0, float f1, float f2, float f3, int destX, int destY)
			{
				byte r = (byte)(f0 * 255f + 0.5f);
				byte g = (byte)(f1 * 255f + 0.5f);
				byte b = (byte)(f2 * 255f + 0.5f);
				byte a = (byte)(f3 * 255f + 0.5f);
				int num = destY * this.width + destX;
				this.rgba[num] = new Color32(r, g, b, a);
			}

			// Token: 0x04000F34 RID: 3892
			public Color32[] rgba;

			// Token: 0x04000F35 RID: 3893
			public int width;

			// Token: 0x04000F36 RID: 3894
			public int height;
		}
	}
}
