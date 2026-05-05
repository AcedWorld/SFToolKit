using System;
using System.Collections.Generic;
using Unity.Profiling;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x0200046B RID: 1131
	internal class TextureBlitter : IDisposable
	{
		// Token: 0x170007F4 RID: 2036
		// (get) Token: 0x0600231A RID: 8986 RVA: 0x00088371 File Offset: 0x00086571
		// (set) Token: 0x0600231B RID: 8987 RVA: 0x00088379 File Offset: 0x00086579
		private protected bool disposed { protected get; private set; }

		// Token: 0x0600231C RID: 8988 RVA: 0x00088382 File Offset: 0x00086582
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600231D RID: 8989 RVA: 0x00088394 File Offset: 0x00086594
		protected virtual void Dispose(bool disposing)
		{
			bool disposed = this.disposed;
			if (!disposed)
			{
				if (disposing)
				{
					UIRUtility.Destroy(this.m_BlitMaterial);
					this.m_BlitMaterial = null;
				}
				this.disposed = true;
			}
		}

		// Token: 0x0600231E RID: 8990 RVA: 0x000883D4 File Offset: 0x000865D4
		static TextureBlitter()
		{
			TextureBlitter.k_TextureIds = new int[8];
			for (int i = 0; i < 8; i++)
			{
				TextureBlitter.k_TextureIds[i] = Shader.PropertyToID("_MainTex" + i.ToString());
			}
		}

		// Token: 0x0600231F RID: 8991 RVA: 0x00088429 File Offset: 0x00086629
		public TextureBlitter(int capacity = 512)
		{
			this.m_PendingBlits = new List<TextureBlitter.BlitInfo>(capacity);
		}

		// Token: 0x06002320 RID: 8992 RVA: 0x0008844C File Offset: 0x0008664C
		public void QueueBlit(Texture src, RectInt srcRect, Vector2Int dstPos, bool addBorder, Color tint)
		{
			bool disposed = this.disposed;
			if (disposed)
			{
				DisposeHelper.NotifyDisposedUsed(this);
			}
			else
			{
				this.m_PendingBlits.Add(new TextureBlitter.BlitInfo
				{
					src = src,
					srcRect = srcRect,
					dstPos = dstPos,
					border = (addBorder ? 1 : 0),
					tint = tint
				});
			}
		}

		// Token: 0x06002321 RID: 8993 RVA: 0x000884B4 File Offset: 0x000866B4
		public void BlitOneNow(RenderTexture dst, Texture src, RectInt srcRect, Vector2Int dstPos, bool addBorder, Color tint)
		{
			bool disposed = this.disposed;
			if (disposed)
			{
				DisposeHelper.NotifyDisposedUsed(this);
			}
			else
			{
				this.m_SingleBlit[0] = new TextureBlitter.BlitInfo
				{
					src = src,
					srcRect = srcRect,
					dstPos = dstPos,
					border = (addBorder ? 1 : 0),
					tint = tint
				};
				this.BeginBlit(dst);
				this.DoBlit(this.m_SingleBlit, 0);
				this.EndBlit();
			}
		}

		// Token: 0x170007F5 RID: 2037
		// (get) Token: 0x06002322 RID: 8994 RVA: 0x00088539 File Offset: 0x00086739
		public int queueLength
		{
			get
			{
				return this.m_PendingBlits.Count;
			}
		}

		// Token: 0x06002323 RID: 8995 RVA: 0x00088548 File Offset: 0x00086748
		public void Commit(RenderTexture dst)
		{
			bool disposed = this.disposed;
			if (disposed)
			{
				DisposeHelper.NotifyDisposedUsed(this);
			}
			else
			{
				bool flag = this.m_PendingBlits.Count == 0;
				if (!flag)
				{
					this.BeginBlit(dst);
					for (int i = 0; i < this.m_PendingBlits.Count; i += 8)
					{
						this.DoBlit(this.m_PendingBlits, i);
					}
					this.EndBlit();
					this.m_PendingBlits.Clear();
				}
			}
		}

		// Token: 0x06002324 RID: 8996 RVA: 0x000885C1 File Offset: 0x000867C1
		public void Reset()
		{
			this.m_PendingBlits.Clear();
		}

		// Token: 0x06002325 RID: 8997 RVA: 0x000885D0 File Offset: 0x000867D0
		private void BeginBlit(RenderTexture dst)
		{
			bool flag = this.m_BlitMaterial == null;
			if (flag)
			{
				Shader shader = Shader.Find(Shaders.k_AtlasBlit);
				this.m_BlitMaterial = new Material(shader);
				this.m_BlitMaterial.hideFlags |= HideFlags.DontSaveInEditor;
			}
			bool flag2 = this.m_Properties == null;
			if (flag2)
			{
				this.m_Properties = new MaterialPropertyBlock();
			}
			this.m_Viewport = Utility.GetActiveViewport();
			this.m_PrevRT = RenderTexture.active;
			GL.LoadPixelMatrix(0f, (float)dst.width, 0f, (float)dst.height);
			Graphics.SetRenderTarget(dst);
			this.m_BlitMaterial.SetPass(0);
		}

		// Token: 0x06002326 RID: 8998 RVA: 0x0008867C File Offset: 0x0008687C
		private void DoBlit(IList<TextureBlitter.BlitInfo> blitInfos, int startIndex)
		{
			int num = Mathf.Min(blitInfos.Count - startIndex, 8);
			int num2 = startIndex + num;
			int i = startIndex;
			int num3 = 0;
			while (i < num2)
			{
				Texture src = blitInfos[i].src;
				bool flag = src != null;
				if (flag)
				{
					this.m_Properties.SetTexture(TextureBlitter.k_TextureIds[num3], src);
				}
				i++;
				num3++;
			}
			Utility.SetPropertyBlock(this.m_Properties);
			GL.Begin(7);
			int j = startIndex;
			int num4 = 0;
			while (j < num2)
			{
				TextureBlitter.BlitInfo blitInfo = blitInfos[j];
				float num5 = 1f / (float)blitInfo.src.width;
				float num6 = 1f / (float)blitInfo.src.height;
				float x = (float)(blitInfo.dstPos.x - blitInfo.border);
				float y = (float)(blitInfo.dstPos.y - blitInfo.border);
				float x2 = (float)(blitInfo.dstPos.x + blitInfo.srcRect.width + blitInfo.border);
				float y2 = (float)(blitInfo.dstPos.y + blitInfo.srcRect.height + blitInfo.border);
				float x3 = (float)(blitInfo.srcRect.x - blitInfo.border) * num5;
				float y3 = (float)(blitInfo.srcRect.y - blitInfo.border) * num6;
				float x4 = (float)(blitInfo.srcRect.xMax + blitInfo.border) * num5;
				float y4 = (float)(blitInfo.srcRect.yMax + blitInfo.border) * num6;
				GL.Color(blitInfo.tint);
				GL.TexCoord3(x3, y3, (float)num4);
				GL.Vertex3(x, y, 0f);
				GL.Color(blitInfo.tint);
				GL.TexCoord3(x3, y4, (float)num4);
				GL.Vertex3(x, y2, 0f);
				GL.Color(blitInfo.tint);
				GL.TexCoord3(x4, y4, (float)num4);
				GL.Vertex3(x2, y2, 0f);
				GL.Color(blitInfo.tint);
				GL.TexCoord3(x4, y3, (float)num4);
				GL.Vertex3(x2, y, 0f);
				j++;
				num4++;
			}
			GL.End();
		}

		// Token: 0x06002327 RID: 8999 RVA: 0x000888E0 File Offset: 0x00086AE0
		private void EndBlit()
		{
			Graphics.SetRenderTarget(this.m_PrevRT);
			GL.Viewport(new Rect((float)this.m_Viewport.x, (float)this.m_Viewport.y, (float)this.m_Viewport.width, (float)this.m_Viewport.height));
		}

		// Token: 0x04001040 RID: 4160
		private const int k_TextureSlotCount = 8;

		// Token: 0x04001041 RID: 4161
		private static readonly int[] k_TextureIds;

		// Token: 0x04001042 RID: 4162
		private static ProfilerMarker s_CommitSampler = new ProfilerMarker("UIR.TextureBlitter.Commit");

		// Token: 0x04001043 RID: 4163
		private TextureBlitter.BlitInfo[] m_SingleBlit = new TextureBlitter.BlitInfo[1];

		// Token: 0x04001044 RID: 4164
		private Material m_BlitMaterial;

		// Token: 0x04001045 RID: 4165
		private MaterialPropertyBlock m_Properties;

		// Token: 0x04001046 RID: 4166
		private RectInt m_Viewport;

		// Token: 0x04001047 RID: 4167
		private RenderTexture m_PrevRT;

		// Token: 0x04001048 RID: 4168
		private List<TextureBlitter.BlitInfo> m_PendingBlits;

		// Token: 0x0200046C RID: 1132
		private struct BlitInfo
		{
			// Token: 0x0400104A RID: 4170
			public Texture src;

			// Token: 0x0400104B RID: 4171
			public RectInt srcRect;

			// Token: 0x0400104C RID: 4172
			public Vector2Int dstPos;

			// Token: 0x0400104D RID: 4173
			public int border;

			// Token: 0x0400104E RID: 4174
			public Color tint;
		}
	}
}
