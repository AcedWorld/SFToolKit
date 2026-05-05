using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001C9 RID: 457
	internal class Texture3DAtlas
	{
		// Token: 0x06000E27 RID: 3623 RVA: 0x00070838 File Offset: 0x0006EA38
		public Texture3DAtlas(GraphicsFormat format, int maxElementSize, int maxElementCount, bool hasMipMaps = true)
		{
			this.m_format = format;
			this.m_MaxElementSize = maxElementSize;
			this.m_MaxElementCount = maxElementCount;
			this.m_HasMipMaps = hasMipMaps;
			int num = 2048 / maxElementSize;
			int num2 = Mathf.Min(maxElementCount, num);
			int num3 = (maxElementCount < num) ? 1 : Mathf.CeilToInt((float)(maxElementCount / num));
			this.m_Atlas = new RenderTexture(num2 * maxElementSize, num3 * maxElementSize, 0, format)
			{
				volumeDepth = maxElementSize,
				dimension = TextureDimension.Tex3D,
				hideFlags = HideFlags.HideAndDontSave,
				enableRandomWrite = true,
				useMipMap = hasMipMaps,
				autoGenerateMips = false,
				name = string.Format("Texture 3D Atlas - {0}x{1}x{2}", num2 * maxElementSize, num3 * maxElementSize, maxElementSize)
			};
			this.m_Atlas.Create();
			this.m_MipMapGenerationTemp = new RenderTexture(maxElementSize / 4, maxElementSize / 4, 0, format)
			{
				volumeDepth = maxElementSize / 4,
				dimension = TextureDimension.Tex3D,
				hideFlags = HideFlags.HideAndDontSave,
				enableRandomWrite = true,
				useMipMap = hasMipMaps,
				autoGenerateMips = false,
				name = string.Format("Texture 3D MipMap Temp - {0}x{1}x{2}", maxElementSize / 4, maxElementSize / 4, maxElementSize / 4)
			};
			this.m_MipMapGenerationTemp.Create();
			for (int i = 0; i < maxElementCount; i++)
			{
				Texture3DAtlas.AtlasElement item = new Texture3DAtlas.AtlasElement(new Vector3Int(i % num2 * maxElementSize, Mathf.FloorToInt((float)i / (float)num2) * maxElementSize, 0), maxElementSize, null);
				this.m_Elements.Add(item);
			}
			this.m_Texture3DAtlasCompute = HDRenderPipelineGlobalSettings.instance.renderPipelineResources.shaders.texture3DAtlasCS;
			this.m_CopyKernel = this.m_Texture3DAtlasCompute.FindKernel("Copy");
			this.m_GenerateMipKernel = this.m_Texture3DAtlasCompute.FindKernel("GenerateMipMap");
			uint x;
			uint y;
			uint z;
			this.m_Texture3DAtlasCompute.GetKernelThreadGroupSizes(this.m_CopyKernel, out x, out y, out z);
			this.m_KernelGroupSize = new Vector3Int((int)x, (int)y, (int)z);
		}

		// Token: 0x06000E28 RID: 3624 RVA: 0x00070A34 File Offset: 0x0006EC34
		private int GetTextureDepth(Texture t)
		{
			Texture3D texture3D = t as Texture3D;
			if (texture3D != null)
			{
				return texture3D.depth;
			}
			RenderTexture renderTexture = t as RenderTexture;
			if (renderTexture != null)
			{
				return renderTexture.volumeDepth;
			}
			return 0;
		}

		// Token: 0x06000E29 RID: 3625 RVA: 0x00070A64 File Offset: 0x0006EC64
		protected int GetTextureHash(Texture texture)
		{
			int num = texture.GetHashCode();
			num = 23 * num + texture.GetInstanceID().GetHashCode();
			num = 23 * num + texture.graphicsFormat.GetHashCode();
			num = 23 * num + texture.width.GetHashCode();
			num = 23 * num + texture.height.GetHashCode();
			return 23 * num + texture.updateCount.GetHashCode();
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x00070AE4 File Offset: 0x0006ECE4
		public bool IsTextureValid(Texture tex)
		{
			if (tex.width != tex.height || tex.height != this.GetTextureDepth(tex))
			{
				Debug.LogError(string.Format("3D Texture Atlas: Added texture {0} is not doesn't have a cubic size {1}x{2}x{3}.", new object[]
				{
					tex,
					tex.width,
					tex.height,
					this.GetTextureDepth(tex)
				}));
				return false;
			}
			if (tex.width > this.m_MaxElementSize)
			{
				Debug.LogError(string.Format("3D Texture Atlas: Added texture {0} size {1} is bigger than the max element atlas size {2}.", tex, tex.width, this.m_MaxElementSize));
				return false;
			}
			if (tex.width < 1)
			{
				Debug.LogError(string.Format("3D Texture Atlas: Added texture {0} size {1} is smaller than 1.", tex, tex.width));
				return false;
			}
			if (!Mathf.IsPowerOfTwo(tex.width))
			{
				Debug.LogError(string.Format("3D Texture Atlas: Added texture {0} size {1} is not power of two.", tex, tex.width));
				return false;
			}
			return true;
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x00070BDB File Offset: 0x0006EDDB
		public bool AddTexture(Texture tex)
		{
			return this.m_TextureElementsMap.ContainsKey(tex) || (this.IsTextureValid(tex) && this.TryAddTextureToTree(tex));
		}

		// Token: 0x06000E2C RID: 3628 RVA: 0x00070C04 File Offset: 0x0006EE04
		private bool TryAddTextureToTree(Texture tex)
		{
			if (tex.width == this.m_MaxElementSize)
			{
				Texture3DAtlas.AtlasElement atlasElement = this.m_Elements.FirstOrDefault((Texture3DAtlas.AtlasElement e) => e.IsFree());
				if (atlasElement != null)
				{
					this.<TryAddTextureToTree>g__SetTextureToElem|19_0(atlasElement, tex);
					return true;
				}
				return false;
			}
			else
			{
				Texture3DAtlas.AtlasElement atlasElement2 = this.FindFreeElementWithSize(tex.width);
				if (atlasElement2 != null)
				{
					this.<TryAddTextureToTree>g__SetTextureToElem|19_0(atlasElement2, tex);
					return true;
				}
				atlasElement2 = this.m_Elements.FirstOrDefault((Texture3DAtlas.AtlasElement e) => e.IsFree());
				if (atlasElement2 == null)
				{
					return true;
				}
				while (atlasElement2.size > tex.width)
				{
					atlasElement2.PopulateChildren();
					atlasElement2 = atlasElement2.children[0];
				}
				this.<TryAddTextureToTree>g__SetTextureToElem|19_0(atlasElement2, tex);
				return true;
			}
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x00070CCC File Offset: 0x0006EECC
		private Texture3DAtlas.AtlasElement FindFreeElementWithSize(int size)
		{
			foreach (Texture3DAtlas.AtlasElement elem in this.m_Elements)
			{
				Texture3DAtlas.AtlasElement atlasElement = Texture3DAtlas.<FindFreeElementWithSize>g__FindFreeElement|20_0(size, elem);
				if (atlasElement != null)
				{
					return atlasElement;
				}
			}
			return null;
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x00070D2C File Offset: 0x0006EF2C
		public void RemoveTexture(Texture tex)
		{
			Texture3DAtlas.AtlasElement atlasElement;
			if (this.m_TextureElementsMap.TryGetValue(tex, out atlasElement))
			{
				atlasElement.texture = null;
				if (atlasElement.parent != null)
				{
					atlasElement.parent.RemoveChildrenIfEmpty();
				}
				this.m_TextureElementsMap.Remove(tex);
			}
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x00070D70 File Offset: 0x0006EF70
		public void ClearTextures()
		{
			foreach (Texture3DAtlas.AtlasElement atlasElement in this.m_Elements)
			{
				atlasElement.texture = null;
				atlasElement.children = null;
			}
			this.m_TextureElementsMap.Clear();
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x00070DD4 File Offset: 0x0006EFD4
		public Vector3 GetTextureOffset(Texture tex)
		{
			Texture3DAtlas.AtlasElement atlasElement;
			if (tex != null && this.m_TextureElementsMap.TryGetValue(tex, out atlasElement))
			{
				return atlasElement.position;
			}
			return -Vector3.one;
		}

		// Token: 0x06000E31 RID: 3633 RVA: 0x00070E10 File Offset: 0x0006F010
		public void Update(CommandBuffer cmd)
		{
			if (this.m_TextureElementsMap.Count == 0)
			{
				return;
			}
			foreach (Texture3DAtlas.AtlasElement atlasElement in this.m_Elements)
			{
				Texture texture = atlasElement.texture;
				if (!(texture == null) && texture.width != atlasElement.size)
				{
					this.RemoveTexture(texture);
					this.AddTexture(texture);
				}
			}
			foreach (Texture3DAtlas.AtlasElement atlasElement2 in this.m_TextureElementsMap.Values)
			{
				if (!(atlasElement2.texture == null))
				{
					int textureHash = this.GetTextureHash(atlasElement2.texture);
					if (atlasElement2.hash != textureHash)
					{
						atlasElement2.hash = textureHash;
						this.CopyTexture(cmd, atlasElement2);
					}
				}
			}
		}

		// Token: 0x06000E32 RID: 3634 RVA: 0x00070F14 File Offset: 0x0006F114
		private void CopyTexture(CommandBuffer cmd, Texture3DAtlas.AtlasElement element)
		{
			this.CopyMip(cmd, element.texture, 0, this.m_Atlas, element.position, 0);
			if (this.m_HasMipMaps)
			{
				int num = this.m_HasMipMaps ? (Mathf.FloorToInt(Mathf.Log((float)element.texture.width, 2f)) + 1) : 1;
				if (element.texture.mipmapCount > 1)
				{
					this.CopyMips(cmd, element.texture, this.m_Atlas, element.position);
					return;
				}
				this.GenerateMip(cmd, element.texture, Vector3Int.zero, 0, this.m_Atlas, element.position, 1);
				Texture3DAtlas.MipGenerationSwapData mipGenerationSwapData = new Texture3DAtlas.MipGenerationSwapData
				{
					target = this.m_Atlas,
					offset = element.position,
					mipOffset = 0
				};
				int num2 = (int)Mathf.Log((float)(this.m_MipMapGenerationTemp.width / (element.size >> 2)), 2f);
				Texture3DAtlas.MipGenerationSwapData mipGenerationSwapData2 = new Texture3DAtlas.MipGenerationSwapData
				{
					target = this.m_MipMapGenerationTemp,
					offset = Vector3Int.zero,
					mipOffset = num2 - 2
				};
				for (int i = 2; i < num; i++)
				{
					this.GenerateMip(cmd, mipGenerationSwapData.target, mipGenerationSwapData.offset, i + mipGenerationSwapData.mipOffset - 1, mipGenerationSwapData2.target, mipGenerationSwapData2.offset, i + mipGenerationSwapData2.mipOffset);
					Texture3DAtlas.MipGenerationSwapData mipGenerationSwapData3 = mipGenerationSwapData;
					mipGenerationSwapData = mipGenerationSwapData2;
					mipGenerationSwapData2 = mipGenerationSwapData3;
				}
				for (int j = 2; j < num; j += 2)
				{
					Vector3Int destinationOffset = new Vector3Int(element.position.x >> j, element.position.y >> j, element.position.z >> j);
					this.CopyMip(cmd, this.m_MipMapGenerationTemp, j - 2 + num2, this.m_Atlas, destinationOffset, j);
				}
			}
		}

		// Token: 0x06000E33 RID: 3635 RVA: 0x000710E4 File Offset: 0x0006F2E4
		private void CopyMips(CommandBuffer cmd, Texture source, Texture destination, Vector3Int destinationOffset)
		{
			int num = Mathf.FloorToInt(Mathf.Log((float)source.width, 2f)) + 1;
			for (int i = 1; i < num; i++)
			{
				Vector3Int destinationOffset2 = new Vector3Int(destinationOffset.x >> i, destinationOffset.y >> i, destinationOffset.z >> i);
				this.CopyMip(cmd, source, i, destination, destinationOffset2, i);
			}
		}

		// Token: 0x06000E34 RID: 3636 RVA: 0x00071150 File Offset: 0x0006F350
		private void CopyMip(CommandBuffer cmd, Texture source, int sourceMip, Texture destination, Vector3Int destinationOffset, int destinationMip)
		{
			cmd.SetComputeTextureParam(this.m_Texture3DAtlasCompute, this.m_CopyKernel, HDShaderIDs._Src3DTexture, source);
			cmd.SetComputeFloatParam(this.m_Texture3DAtlasCompute, HDShaderIDs._SrcMip, (float)sourceMip);
			cmd.SetComputeTextureParam(this.m_Texture3DAtlasCompute, this.m_CopyKernel, HDShaderIDs._Dst3DTexture, destination, destinationMip);
			cmd.SetComputeVectorParam(this.m_Texture3DAtlasCompute, HDShaderIDs._DstOffset, destinationOffset);
			Texture3D texture3D = source as Texture3D;
			bool flag = texture3D != null && texture3D.format == TextureFormat.Alpha8;
			cmd.SetComputeFloatParam(this.m_Texture3DAtlasCompute, HDShaderIDs._AlphaOnlyTexture, (float)(flag ? 1 : 0));
			int num = source.width >> sourceMip;
			cmd.SetComputeIntParam(this.m_Texture3DAtlasCompute, HDShaderIDs._SrcSize, num);
			cmd.DispatchCompute(this.m_Texture3DAtlasCompute, this.m_CopyKernel, Mathf.Max(num / this.m_KernelGroupSize.x, 1), Mathf.Max(num / this.m_KernelGroupSize.y, 1), Mathf.Max(num / this.m_KernelGroupSize.z, 1));
		}

		// Token: 0x06000E35 RID: 3637 RVA: 0x00071264 File Offset: 0x0006F464
		private void GenerateMip(CommandBuffer cmd, Texture source, Vector3Int sourceOffset, int sourceMip, Texture destination, Vector3Int destinationOffset, int destinationMip)
		{
			Vector3 v = new Vector3((float)sourceOffset.x / (float)source.width, (float)sourceOffset.y / (float)source.height, (float)sourceOffset.z / (float)this.GetTextureDepth(source));
			Vector3Int v2 = new Vector3Int(destinationOffset.x >> destinationMip, destinationOffset.y >> destinationMip, destinationOffset.z >> destinationMip);
			new Vector3Int(Mathf.Min(source.width, destination.width), Mathf.Min(source.height, destination.height), Mathf.Min(this.GetTextureDepth(source), this.GetTextureDepth(destination)));
			new Vector3Int(destination.width >> destinationMip, destination.height >> destinationMip, this.GetTextureDepth(destination) >> destinationMip);
			Vector3 one = Vector3.one;
			Vector3Int vector3Int = new Vector3Int(source.width >> sourceMip + 1, source.height >> sourceMip + 1, this.GetTextureDepth(source) >> sourceMip + 1);
			Vector3Int vector3Int2 = new Vector3Int(destination.width >> destinationMip, destination.height >> destinationMip, this.GetTextureDepth(destination) >> destinationMip);
			one = new Vector3(Mathf.Min((float)vector3Int2.x / (float)vector3Int.x, 1f), Mathf.Min((float)vector3Int2.y / (float)vector3Int.y, 1f), Mathf.Min((float)vector3Int2.z / (float)vector3Int.z, 1f));
			cmd.SetComputeTextureParam(this.m_Texture3DAtlasCompute, this.m_GenerateMipKernel, HDShaderIDs._Src3DTexture, source);
			cmd.SetComputeVectorParam(this.m_Texture3DAtlasCompute, HDShaderIDs._SrcScale, one);
			cmd.SetComputeVectorParam(this.m_Texture3DAtlasCompute, HDShaderIDs._SrcOffset, v);
			cmd.SetComputeFloatParam(this.m_Texture3DAtlasCompute, HDShaderIDs._SrcMip, (float)sourceMip);
			cmd.SetComputeTextureParam(this.m_Texture3DAtlasCompute, this.m_GenerateMipKernel, HDShaderIDs._Dst3DTexture, destination, destinationMip);
			cmd.SetComputeVectorParam(this.m_Texture3DAtlasCompute, HDShaderIDs._DstOffset, v2);
			int num = Mathf.Min(this.GetTextureDepth(source) >> sourceMip + 1, this.GetTextureDepth(destination) >> destinationMip);
			cmd.SetComputeIntParam(this.m_Texture3DAtlasCompute, HDShaderIDs._SrcSize, num);
			Texture3D texture3D = source as Texture3D;
			bool flag = texture3D != null && texture3D.format == TextureFormat.Alpha8;
			cmd.SetComputeFloatParam(this.m_Texture3DAtlasCompute, HDShaderIDs._AlphaOnlyTexture, (float)(flag ? 1 : 0));
			cmd.DispatchCompute(this.m_Texture3DAtlasCompute, this.m_GenerateMipKernel, Mathf.Max(num / this.m_KernelGroupSize.x, 1), Mathf.Max(num / this.m_KernelGroupSize.y, 1), Mathf.Max(num / this.m_KernelGroupSize.z, 1));
		}

		// Token: 0x06000E36 RID: 3638 RVA: 0x00071557 File Offset: 0x0006F757
		public RenderTexture GetAtlas()
		{
			return this.m_Atlas;
		}

		// Token: 0x06000E37 RID: 3639 RVA: 0x0007155F File Offset: 0x0006F75F
		public void Release()
		{
			this.ClearTextures();
			CoreUtils.Destroy(this.m_Atlas);
			CoreUtils.Destroy(this.m_MipMapGenerationTemp);
		}

		// Token: 0x06000E38 RID: 3640 RVA: 0x00071580 File Offset: 0x0006F780
		public static long GetApproxCacheSizeInByte(int elementSize, int elementCount, GraphicsFormat format, bool hasMipMaps)
		{
			int formatSizeInBytes = HDUtils.GetFormatSizeInBytes(format);
			return (long)((float)(elementSize * elementSize * elementSize * formatSizeInBytes) * (hasMipMaps ? 1.33f : 1f)) * (long)elementCount;
		}

		// Token: 0x06000E39 RID: 3641 RVA: 0x000715B0 File Offset: 0x0006F7B0
		public static int GetMaxElementCountForWeightInByte(long weight, int elementSize, int elementCount, GraphicsFormat format, bool hasMipMaps)
		{
			long num = (long)((float)((long)elementSize * (long)elementSize * (long)elementSize * (long)HDUtils.GetFormatSizeInBytes(format)) * (hasMipMaps ? 1.33f : 1f));
			return (int)Mathf.Clamp((float)(weight / num), 1f, (float)elementCount);
		}

		// Token: 0x06000E3A RID: 3642 RVA: 0x000715F2 File Offset: 0x0006F7F2
		[CompilerGenerated]
		private void <TryAddTextureToTree>g__SetTextureToElem|19_0(Texture3DAtlas.AtlasElement element, Texture texture)
		{
			element.texture = texture;
			this.m_TextureElementsMap.Add(texture, element);
		}

		// Token: 0x06000E3B RID: 3643 RVA: 0x00071608 File Offset: 0x0006F808
		[CompilerGenerated]
		internal static Texture3DAtlas.AtlasElement <FindFreeElementWithSize>g__FindFreeElement|20_0(int size, Texture3DAtlas.AtlasElement elem)
		{
			if (elem.size == size)
			{
				if (elem.IsFree())
				{
					return elem;
				}
				return null;
			}
			else
			{
				if (elem.children == null)
				{
					return null;
				}
				foreach (Texture3DAtlas.AtlasElement atlasElement in elem.children)
				{
					if (atlasElement.children != null && atlasElement.size >= size)
					{
						Texture3DAtlas.AtlasElement atlasElement2 = Texture3DAtlas.<FindFreeElementWithSize>g__FindFreeElement|20_0(size, atlasElement);
						if (atlasElement2 != null)
						{
							return atlasElement2;
						}
					}
					else if (atlasElement.IsFree())
					{
						return atlasElement;
					}
				}
				return null;
			}
		}

		// Token: 0x040015C1 RID: 5569
		private List<Texture3DAtlas.AtlasElement> m_Elements = new List<Texture3DAtlas.AtlasElement>();

		// Token: 0x040015C2 RID: 5570
		private Dictionary<Texture, Texture3DAtlas.AtlasElement> m_TextureElementsMap = new Dictionary<Texture, Texture3DAtlas.AtlasElement>();

		// Token: 0x040015C3 RID: 5571
		private RenderTexture m_Atlas;

		// Token: 0x040015C4 RID: 5572
		private RenderTexture m_MipMapGenerationTemp;

		// Token: 0x040015C5 RID: 5573
		private GraphicsFormat m_format;

		// Token: 0x040015C6 RID: 5574
		private ComputeShader m_Texture3DAtlasCompute;

		// Token: 0x040015C7 RID: 5575
		private int m_CopyKernel;

		// Token: 0x040015C8 RID: 5576
		private int m_GenerateMipKernel;

		// Token: 0x040015C9 RID: 5577
		private Vector3Int m_KernelGroupSize;

		// Token: 0x040015CA RID: 5578
		private int m_MaxElementSize;

		// Token: 0x040015CB RID: 5579
		private int m_MaxElementCount;

		// Token: 0x040015CC RID: 5580
		private bool m_HasMipMaps;

		// Token: 0x040015CD RID: 5581
		private const float k_MipmapFactorApprox = 1.33f;

		// Token: 0x0200040B RID: 1035
		private class AtlasElement
		{
			// Token: 0x060013EF RID: 5103 RVA: 0x00096FE9 File Offset: 0x000951E9
			public bool IsFree()
			{
				return this.texture == null && this.children == null;
			}

			// Token: 0x060013F0 RID: 5104 RVA: 0x00097004 File Offset: 0x00095204
			public AtlasElement(Vector3Int position, int size, Texture texture = null)
			{
				this.position = position;
				this.size = size;
				this.texture = texture;
				this.hash = 0;
			}

			// Token: 0x060013F1 RID: 5105 RVA: 0x00097028 File Offset: 0x00095228
			public void PopulateChildren()
			{
				this.children = new Texture3DAtlas.AtlasElement[8];
				int num = this.size / 2;
				this.children[0] = new Texture3DAtlas.AtlasElement(this.position + new Vector3Int(0, 0, 0), num, null);
				this.children[1] = new Texture3DAtlas.AtlasElement(this.position + new Vector3Int(num, 0, 0), num, null);
				this.children[2] = new Texture3DAtlas.AtlasElement(this.position + new Vector3Int(0, 0, num), num, null);
				this.children[3] = new Texture3DAtlas.AtlasElement(this.position + new Vector3Int(num, 0, num), num, null);
				this.children[4] = new Texture3DAtlas.AtlasElement(this.position + new Vector3Int(0, num, 0), num, null);
				this.children[5] = new Texture3DAtlas.AtlasElement(this.position + new Vector3Int(num, num, 0), num, null);
				this.children[6] = new Texture3DAtlas.AtlasElement(this.position + new Vector3Int(0, num, num), num, null);
				this.children[7] = new Texture3DAtlas.AtlasElement(this.position + new Vector3Int(num, num, num), num, null);
				Texture3DAtlas.AtlasElement[] array = this.children;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].parent = this;
				}
			}

			// Token: 0x060013F2 RID: 5106 RVA: 0x00097178 File Offset: 0x00095378
			public void RemoveChildrenIfEmpty()
			{
				bool flag = true;
				Texture3DAtlas.AtlasElement[] array = this.children;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].texture != null)
					{
						flag = false;
					}
				}
				if (flag)
				{
					this.children = null;
				}
			}

			// Token: 0x060013F3 RID: 5107 RVA: 0x000971B8 File Offset: 0x000953B8
			public override string ToString()
			{
				return string.Format("3D Atlas Element, pos: {0}, size: {1}, texture:{2}, children: {3}", new object[]
				{
					this.position,
					this.size,
					this.texture,
					this.children != null
				});
			}

			// Token: 0x040028D2 RID: 10450
			public Vector3Int position;

			// Token: 0x040028D3 RID: 10451
			public int size;

			// Token: 0x040028D4 RID: 10452
			public Texture texture;

			// Token: 0x040028D5 RID: 10453
			public int hash;

			// Token: 0x040028D6 RID: 10454
			public Texture3DAtlas.AtlasElement[] children;

			// Token: 0x040028D7 RID: 10455
			public Texture3DAtlas.AtlasElement parent;
		}

		// Token: 0x0200040C RID: 1036
		private struct MipGenerationSwapData
		{
			// Token: 0x040028D8 RID: 10456
			public RenderTexture target;

			// Token: 0x040028D9 RID: 10457
			public Vector3Int offset;

			// Token: 0x040028DA RID: 10458
			public int mipOffset;
		}
	}
}
