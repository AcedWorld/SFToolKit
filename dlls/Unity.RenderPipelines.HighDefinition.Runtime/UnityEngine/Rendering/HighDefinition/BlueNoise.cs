using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001C7 RID: 455
	public sealed class BlueNoise
	{
		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06000DCA RID: 3530 RVA: 0x0006F1DB File Offset: 0x0006D3DB
		public Texture2D[] textures16L
		{
			get
			{
				return this.m_Textures16L;
			}
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06000DCB RID: 3531 RVA: 0x0006F1E3 File Offset: 0x0006D3E3
		public Texture2D[] textures16RGB
		{
			get
			{
				return this.m_Textures16RGB;
			}
		}

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000DCC RID: 3532 RVA: 0x0006F1EB File Offset: 0x0006D3EB
		public Texture2DArray textureArray16L
		{
			get
			{
				return this.m_TextureArray16L;
			}
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06000DCD RID: 3533 RVA: 0x0006F1F3 File Offset: 0x0006D3F3
		public Texture2DArray textureArray16RGB
		{
			get
			{
				return this.m_TextureArray16RGB;
			}
		}

		// Token: 0x06000DCE RID: 3534 RVA: 0x0006F1FC File Offset: 0x0006D3FC
		internal BlueNoise(HDRenderPipelineRuntimeResources resources)
		{
			this.m_RenderPipelineResources = resources;
			BlueNoise.InitTextures(16, TextureFormat.Alpha8, resources.textures.blueNoise16LTex, out this.m_Textures16L, out this.m_TextureArray16L);
			BlueNoise.InitTextures(16, TextureFormat.RGB24, resources.textures.blueNoise16RGBTex, out this.m_Textures16RGB, out this.m_TextureArray16RGB);
		}

		// Token: 0x06000DCF RID: 3535 RVA: 0x0006F254 File Offset: 0x0006D454
		public void Cleanup()
		{
			CoreUtils.Destroy(this.m_TextureArray16L);
			CoreUtils.Destroy(this.m_TextureArray16RGB);
			this.m_TextureArray16L = null;
			this.m_TextureArray16RGB = null;
		}

		// Token: 0x06000DD0 RID: 3536 RVA: 0x0006F27A File Offset: 0x0006D47A
		public Texture2D GetRandom16L()
		{
			return this.textures16L[(int)(BlueNoise.m_Random.NextDouble() * (double)(this.textures16L.Length - 1))];
		}

		// Token: 0x06000DD1 RID: 3537 RVA: 0x0006F29A File Offset: 0x0006D49A
		public Texture2D GetRandom16RGB()
		{
			return this.textures16RGB[(int)(BlueNoise.m_Random.NextDouble() * (double)(this.textures16RGB.Length - 1))];
		}

		// Token: 0x06000DD2 RID: 3538 RVA: 0x0006F2BC File Offset: 0x0006D4BC
		private static void InitTextures(int size, TextureFormat format, Texture2D[] sourceTextures, out Texture2D[] destination, out Texture2DArray destinationArray)
		{
			int num = sourceTextures.Length;
			destination = new Texture2D[num];
			destinationArray = new Texture2DArray(size, size, num, format, false, true);
			destinationArray.hideFlags = HideFlags.HideAndDontSave;
			for (int i = 0; i < num; i++)
			{
				Texture2D texture2D = sourceTextures[i];
				if (texture2D == null)
				{
					destination[i] = Texture2D.whiteTexture;
				}
				else
				{
					destination[i] = texture2D;
					Graphics.CopyTexture(texture2D, 0, 0, destinationArray, i, 0);
				}
			}
		}

		// Token: 0x06000DD3 RID: 3539 RVA: 0x0006F324 File Offset: 0x0006D524
		internal void BindDitheredRNGData1SPP(CommandBuffer cmd)
		{
			cmd.SetGlobalTexture(HDShaderIDs._OwenScrambledTexture, this.m_RenderPipelineResources.textures.owenScrambled256Tex);
			cmd.SetGlobalTexture(HDShaderIDs._ScramblingTileXSPP, this.m_RenderPipelineResources.textures.scramblingTile1SPP);
			cmd.SetGlobalTexture(HDShaderIDs._RankingTileXSPP, this.m_RenderPipelineResources.textures.rankingTile1SPP);
			cmd.SetGlobalTexture(HDShaderIDs._ScramblingTexture, this.m_RenderPipelineResources.textures.scramblingTex);
		}

		// Token: 0x06000DD4 RID: 3540 RVA: 0x0006F3B4 File Offset: 0x0006D5B4
		internal void BindDitheredRNGData8SPP(CommandBuffer cmd)
		{
			cmd.SetGlobalTexture(HDShaderIDs._OwenScrambledTexture, this.m_RenderPipelineResources.textures.owenScrambled256Tex);
			cmd.SetGlobalTexture(HDShaderIDs._ScramblingTileXSPP, this.m_RenderPipelineResources.textures.scramblingTile8SPP);
			cmd.SetGlobalTexture(HDShaderIDs._RankingTileXSPP, this.m_RenderPipelineResources.textures.rankingTile8SPP);
			cmd.SetGlobalTexture(HDShaderIDs._ScramblingTexture, this.m_RenderPipelineResources.textures.scramblingTex);
		}

		// Token: 0x06000DD5 RID: 3541 RVA: 0x0006F444 File Offset: 0x0006D644
		internal BlueNoise.DitheredTextureSet DitheredTextureSet1SPP()
		{
			return new BlueNoise.DitheredTextureSet
			{
				owenScrambled256Tex = this.m_RenderPipelineResources.textures.owenScrambled256Tex,
				scramblingTile = this.m_RenderPipelineResources.textures.scramblingTile1SPP,
				rankingTile = this.m_RenderPipelineResources.textures.rankingTile1SPP,
				scramblingTex = this.m_RenderPipelineResources.textures.scramblingTex
			};
		}

		// Token: 0x06000DD6 RID: 3542 RVA: 0x0006F4B8 File Offset: 0x0006D6B8
		internal BlueNoise.DitheredTextureSet DitheredTextureSet8SPP()
		{
			return new BlueNoise.DitheredTextureSet
			{
				owenScrambled256Tex = this.m_RenderPipelineResources.textures.owenScrambled256Tex,
				scramblingTile = this.m_RenderPipelineResources.textures.scramblingTile8SPP,
				rankingTile = this.m_RenderPipelineResources.textures.rankingTile8SPP,
				scramblingTex = this.m_RenderPipelineResources.textures.scramblingTex
			};
		}

		// Token: 0x06000DD7 RID: 3543 RVA: 0x0006F52C File Offset: 0x0006D72C
		internal BlueNoise.DitheredTextureSet DitheredTextureSet256SPP()
		{
			return new BlueNoise.DitheredTextureSet
			{
				owenScrambled256Tex = this.m_RenderPipelineResources.textures.owenScrambled256Tex,
				scramblingTile = this.m_RenderPipelineResources.textures.scramblingTile256SPP,
				rankingTile = this.m_RenderPipelineResources.textures.rankingTile256SPP,
				scramblingTex = this.m_RenderPipelineResources.textures.scramblingTex
			};
		}

		// Token: 0x06000DD8 RID: 3544 RVA: 0x0006F5A0 File Offset: 0x0006D7A0
		internal void BindDitheredRNGData256SPP(CommandBuffer cmd)
		{
			cmd.SetGlobalTexture(HDShaderIDs._OwenScrambledTexture, this.m_RenderPipelineResources.textures.owenScrambled256Tex);
			cmd.SetGlobalTexture(HDShaderIDs._ScramblingTileXSPP, this.m_RenderPipelineResources.textures.scramblingTile256SPP);
			cmd.SetGlobalTexture(HDShaderIDs._RankingTileXSPP, this.m_RenderPipelineResources.textures.rankingTile256SPP);
			cmd.SetGlobalTexture(HDShaderIDs._ScramblingTexture, this.m_RenderPipelineResources.textures.scramblingTex);
		}

		// Token: 0x06000DD9 RID: 3545 RVA: 0x0006F630 File Offset: 0x0006D830
		internal static void BindDitheredTextureSet(CommandBuffer cmd, BlueNoise.DitheredTextureSet ditheredTextureSet)
		{
			cmd.SetGlobalTexture(HDShaderIDs._OwenScrambledTexture, ditheredTextureSet.owenScrambled256Tex);
			cmd.SetGlobalTexture(HDShaderIDs._ScramblingTileXSPP, ditheredTextureSet.scramblingTile);
			cmd.SetGlobalTexture(HDShaderIDs._RankingTileXSPP, ditheredTextureSet.rankingTile);
			cmd.SetGlobalTexture(HDShaderIDs._ScramblingTexture, ditheredTextureSet.scramblingTex);
		}

		// Token: 0x040015B6 RID: 5558
		private readonly Texture2D[] m_Textures16L;

		// Token: 0x040015B7 RID: 5559
		private readonly Texture2D[] m_Textures16RGB;

		// Token: 0x040015B8 RID: 5560
		private Texture2DArray m_TextureArray16L;

		// Token: 0x040015B9 RID: 5561
		private Texture2DArray m_TextureArray16RGB;

		// Token: 0x040015BA RID: 5562
		private HDRenderPipelineRuntimeResources m_RenderPipelineResources;

		// Token: 0x040015BB RID: 5563
		private static readonly Random m_Random = new Random();

		// Token: 0x02000408 RID: 1032
		internal struct DitheredTextureSet
		{
			// Token: 0x040028C6 RID: 10438
			public Texture2D owenScrambled256Tex;

			// Token: 0x040028C7 RID: 10439
			public Texture2D scramblingTile;

			// Token: 0x040028C8 RID: 10440
			public Texture2D rankingTile;

			// Token: 0x040028C9 RID: 10441
			public Texture2D scramblingTex;
		}
	}
}
