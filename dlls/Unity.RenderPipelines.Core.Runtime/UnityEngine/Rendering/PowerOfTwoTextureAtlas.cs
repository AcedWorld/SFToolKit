using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering
{
	// Token: 0x020000B8 RID: 184
	public class PowerOfTwoTextureAtlas : Texture2DAtlas
	{
		// Token: 0x0600056E RID: 1390 RVA: 0x0001BEEE File Offset: 0x0001A0EE
		public PowerOfTwoTextureAtlas(int size, int mipPadding, GraphicsFormat format, FilterMode filterMode = FilterMode.Point, string name = "", bool useMipMap = true) : base(size, size, format, filterMode, true, name, useMipMap)
		{
			this.m_MipPadding = mipPadding;
			int num = size & size - 1;
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x0600056F RID: 1391 RVA: 0x0001BF18 File Offset: 0x0001A118
		public int mipPadding
		{
			get
			{
				return this.m_MipPadding;
			}
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x0001BF20 File Offset: 0x0001A120
		private int GetTexturePadding()
		{
			return (int)Mathf.Pow(2f, (float)this.m_MipPadding) * 2;
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x0001BF38 File Offset: 0x0001A138
		public Vector4 GetPayloadScaleOffset(Texture texture, in Vector4 scaleOffset)
		{
			int texturePadding = this.GetTexturePadding();
			Vector2 vector = Vector2.one * (float)texturePadding;
			Vector2 powerOfTwoTextureSize = this.GetPowerOfTwoTextureSize(texture);
			return PowerOfTwoTextureAtlas.GetPayloadScaleOffset(powerOfTwoTextureSize, vector, scaleOffset);
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x0001BF6C File Offset: 0x0001A16C
		public static Vector4 GetPayloadScaleOffset(in Vector2 textureSize, in Vector2 paddingSize, in Vector4 scaleOffset)
		{
			Vector2 a = new Vector2(scaleOffset.x, scaleOffset.y);
			Vector2 a2 = new Vector2(scaleOffset.z, scaleOffset.w);
			Vector2 b = (textureSize + paddingSize) / textureSize;
			Vector2 b2 = paddingSize / 2f / (textureSize + paddingSize);
			Vector2 vector = a / b;
			Vector2 vector2 = a2 + a * b2;
			return new Vector4(vector.x, vector.y, vector2.x, vector2.y);
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x0001C018 File Offset: 0x0001A218
		private void Blit2DTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips, PowerOfTwoTextureAtlas.BlitType blitType)
		{
			int num = base.GetTextureMipmapCount(texture.width, texture.height);
			int texturePadding = this.GetTexturePadding();
			Vector2 powerOfTwoTextureSize = this.GetPowerOfTwoTextureSize(texture);
			bool bilinear = texture.filterMode > FilterMode.Point;
			if (!blitMips)
			{
				num = 1;
			}
			using (new ProfilingScope(cmd, ProfilingSampler.Get<CoreProfileId>(CoreProfileId.BlitTextureInPotAtlas)))
			{
				for (int i = 0; i < num; i++)
				{
					cmd.SetRenderTarget(this.m_AtlasTexture, i);
					switch (blitType)
					{
					case PowerOfTwoTextureAtlas.BlitType.Padding:
						Blitter.BlitQuadWithPadding(cmd, texture, powerOfTwoTextureSize, sourceScaleOffset, scaleOffset, i, bilinear, texturePadding);
						break;
					case PowerOfTwoTextureAtlas.BlitType.PaddingMultiply:
						Blitter.BlitQuadWithPaddingMultiply(cmd, texture, powerOfTwoTextureSize, sourceScaleOffset, scaleOffset, i, bilinear, texturePadding);
						break;
					case PowerOfTwoTextureAtlas.BlitType.OctahedralPadding:
						Blitter.BlitOctahedralWithPadding(cmd, texture, powerOfTwoTextureSize, sourceScaleOffset, scaleOffset, i, bilinear, texturePadding);
						break;
					case PowerOfTwoTextureAtlas.BlitType.OctahedralPaddingMultiply:
						Blitter.BlitOctahedralWithPaddingMultiply(cmd, texture, powerOfTwoTextureSize, sourceScaleOffset, scaleOffset, i, bilinear, texturePadding);
						break;
					}
				}
			}
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x0001C104 File Offset: 0x0001A304
		public override void BlitTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips = true, int overrideInstanceID = -1)
		{
			if (base.Is2D(texture))
			{
				this.Blit2DTexture(cmd, scaleOffset, texture, sourceScaleOffset, blitMips, PowerOfTwoTextureAtlas.BlitType.Padding);
				base.MarkGPUTextureValid((overrideInstanceID != -1) ? overrideInstanceID : texture.GetInstanceID(), blitMips);
			}
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x0001C134 File Offset: 0x0001A334
		public void BlitTextureMultiply(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips = true, int overrideInstanceID = -1)
		{
			if (base.Is2D(texture))
			{
				this.Blit2DTexture(cmd, scaleOffset, texture, sourceScaleOffset, blitMips, PowerOfTwoTextureAtlas.BlitType.PaddingMultiply);
				base.MarkGPUTextureValid((overrideInstanceID != -1) ? overrideInstanceID : texture.GetInstanceID(), blitMips);
			}
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x0001C164 File Offset: 0x0001A364
		public override void BlitOctahedralTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips = true, int overrideInstanceID = -1)
		{
			if (base.Is2D(texture))
			{
				this.Blit2DTexture(cmd, scaleOffset, texture, sourceScaleOffset, blitMips, PowerOfTwoTextureAtlas.BlitType.OctahedralPadding);
				base.MarkGPUTextureValid((overrideInstanceID != -1) ? overrideInstanceID : texture.GetInstanceID(), blitMips);
			}
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0001C194 File Offset: 0x0001A394
		public void BlitOctahedralTextureMultiply(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips = true, int overrideInstanceID = -1)
		{
			if (base.Is2D(texture))
			{
				this.Blit2DTexture(cmd, scaleOffset, texture, sourceScaleOffset, blitMips, PowerOfTwoTextureAtlas.BlitType.OctahedralPaddingMultiply);
				base.MarkGPUTextureValid((overrideInstanceID != -1) ? overrideInstanceID : texture.GetInstanceID(), blitMips);
			}
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x0001C1C4 File Offset: 0x0001A3C4
		private void TextureSizeToPowerOfTwo(Texture texture, ref int width, ref int height)
		{
			width = Mathf.NextPowerOfTwo(width);
			height = Mathf.NextPowerOfTwo(height);
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x0001C1D8 File Offset: 0x0001A3D8
		private Vector2 GetPowerOfTwoTextureSize(Texture texture)
		{
			int width = texture.width;
			int height = texture.height;
			this.TextureSizeToPowerOfTwo(texture, ref width, ref height);
			return new Vector2((float)width, (float)height);
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x0001C208 File Offset: 0x0001A408
		public override bool AllocateTexture(CommandBuffer cmd, ref Vector4 scaleOffset, Texture texture, int width, int height, int overrideInstanceID = -1)
		{
			if (height != width)
			{
				Debug.LogError(string.Concat(new string[]
				{
					"Can't place ",
					(texture != null) ? texture.ToString() : null,
					" in the atlas ",
					this.m_AtlasTexture.name,
					": Only squared texture are allowed in this atlas."
				}));
				return false;
			}
			this.TextureSizeToPowerOfTwo(texture, ref height, ref width);
			return base.AllocateTexture(cmd, ref scaleOffset, texture, width, height, -1);
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x0001C27C File Offset: 0x0001A47C
		public void ResetRequestedTexture()
		{
			this.m_RequestedTextures.Clear();
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x0001C289 File Offset: 0x0001A489
		public bool ReserveSpace(Texture texture)
		{
			return this.ReserveSpace(texture, texture.width, texture.height);
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x0001C29E File Offset: 0x0001A49E
		public bool ReserveSpace(Texture texture, int width, int height)
		{
			return this.ReserveSpace(base.GetTextureID(texture), width, height);
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x0001C2AF File Offset: 0x0001A4AF
		public bool ReserveSpace(Texture textureA, Texture textureB, int width, int height)
		{
			return this.ReserveSpace(base.GetTextureID(textureA, textureB), width, height);
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x0001C2C4 File Offset: 0x0001A4C4
		private bool ReserveSpace(int id, int width, int height)
		{
			this.m_RequestedTextures[id] = new Vector2Int(width, height);
			Vector2Int cachedTextureSize = base.GetCachedTextureSize(id);
			Vector4 vector;
			if (!base.IsCached(out vector, id) || cachedTextureSize.x != width || cachedTextureSize.y != height)
			{
				Vector4 zero = Vector4.zero;
				if (!this.AllocateTextureWithoutBlit(id, width, height, ref zero))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x0001C324 File Offset: 0x0001A524
		public bool RelayoutEntries()
		{
			List<ValueTuple<int, Vector2Int>> list = new List<ValueTuple<int, Vector2Int>>();
			foreach (KeyValuePair<int, Vector2Int> keyValuePair in this.m_RequestedTextures)
			{
				list.Add(new ValueTuple<int, Vector2Int>(keyValuePair.Key, keyValuePair.Value));
			}
			base.ResetAllocator();
			list.Sort(([TupleElementNames(new string[]
			{
				"instanceId",
				"size"
			})] ValueTuple<int, Vector2Int> c1, [TupleElementNames(new string[]
			{
				"instanceId",
				"size"
			})] ValueTuple<int, Vector2Int> c2) => c2.Item2.magnitude.CompareTo(c1.Item2.magnitude));
			bool flag = true;
			Vector4 zero = Vector4.zero;
			foreach (ValueTuple<int, Vector2Int> valueTuple in list)
			{
				bool flag2 = flag;
				int item = valueTuple.Item1;
				Vector2Int item2 = valueTuple.Item2;
				int x = item2.x;
				item2 = valueTuple.Item2;
				flag = (flag2 & this.AllocateTextureWithoutBlit(item, x, item2.y, ref zero));
			}
			return flag;
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x0001C430 File Offset: 0x0001A630
		public static long GetApproxCacheSizeInByte(int nbElement, int resolution, bool hasMipmap, GraphicsFormat format)
		{
			return (long)((double)(nbElement * resolution * resolution) * (double)((hasMipmap ? 1.33f : 1f) * GraphicsFormatUtility.GetBlockSize(format)));
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x0001C454 File Offset: 0x0001A654
		public static int GetMaxCacheSizeForWeightInByte(int weight, bool hasMipmap, GraphicsFormat format)
		{
			float num = GraphicsFormatUtility.GetBlockSize(format) * (hasMipmap ? 1.33f : 1f);
			return CoreUtils.PreviousPowerOfTwo((int)Mathf.Sqrt((float)weight / num));
		}

		// Token: 0x04000409 RID: 1033
		private readonly int m_MipPadding;

		// Token: 0x0400040A RID: 1034
		private const float k_MipmapFactorApprox = 1.33f;

		// Token: 0x0400040B RID: 1035
		private Dictionary<int, Vector2Int> m_RequestedTextures = new Dictionary<int, Vector2Int>();

		// Token: 0x020001BF RID: 447
		private enum BlitType
		{
			// Token: 0x0400073F RID: 1855
			Padding,
			// Token: 0x04000740 RID: 1856
			PaddingMultiply,
			// Token: 0x04000741 RID: 1857
			OctahedralPadding,
			// Token: 0x04000742 RID: 1858
			OctahedralPaddingMultiply
		}
	}
}
