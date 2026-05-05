using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering
{
	// Token: 0x020000D4 RID: 212
	public static class CoreUtils
	{
		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060006F0 RID: 1776 RVA: 0x000222FC File Offset: 0x000204FC
		public static Cubemap blackCubeTexture
		{
			get
			{
				if (CoreUtils.m_BlackCubeTexture == null)
				{
					CoreUtils.m_BlackCubeTexture = new Cubemap(1, GraphicsFormat.R8G8B8A8_SRGB, TextureCreationFlags.None);
					for (int i = 0; i < 6; i++)
					{
						CoreUtils.m_BlackCubeTexture.SetPixel((CubemapFace)i, 0, 0, Color.black);
					}
					CoreUtils.m_BlackCubeTexture.Apply();
				}
				return CoreUtils.m_BlackCubeTexture;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060006F1 RID: 1777 RVA: 0x00022350 File Offset: 0x00020550
		public static Cubemap magentaCubeTexture
		{
			get
			{
				if (CoreUtils.m_MagentaCubeTexture == null)
				{
					CoreUtils.m_MagentaCubeTexture = new Cubemap(1, GraphicsFormat.R8G8B8A8_SRGB, TextureCreationFlags.None);
					for (int i = 0; i < 6; i++)
					{
						CoreUtils.m_MagentaCubeTexture.SetPixel((CubemapFace)i, 0, 0, Color.magenta);
					}
					CoreUtils.m_MagentaCubeTexture.Apply();
				}
				return CoreUtils.m_MagentaCubeTexture;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060006F2 RID: 1778 RVA: 0x000223A4 File Offset: 0x000205A4
		public static CubemapArray magentaCubeTextureArray
		{
			get
			{
				if (CoreUtils.m_MagentaCubeTextureArray == null)
				{
					CoreUtils.m_MagentaCubeTextureArray = new CubemapArray(1, 1, GraphicsFormat.R32G32B32A32_SFloat, TextureCreationFlags.None);
					for (int i = 0; i < 6; i++)
					{
						Color[] colors = new Color[]
						{
							Color.magenta
						};
						CoreUtils.m_MagentaCubeTextureArray.SetPixels(colors, (CubemapFace)i, 0);
					}
					CoreUtils.m_MagentaCubeTextureArray.Apply();
				}
				return CoreUtils.m_MagentaCubeTextureArray;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060006F3 RID: 1779 RVA: 0x00022408 File Offset: 0x00020608
		public static Cubemap whiteCubeTexture
		{
			get
			{
				if (CoreUtils.m_WhiteCubeTexture == null)
				{
					CoreUtils.m_WhiteCubeTexture = new Cubemap(1, GraphicsFormat.R8G8B8A8_SRGB, TextureCreationFlags.None);
					for (int i = 0; i < 6; i++)
					{
						CoreUtils.m_WhiteCubeTexture.SetPixel((CubemapFace)i, 0, 0, Color.white);
					}
					CoreUtils.m_WhiteCubeTexture.Apply();
				}
				return CoreUtils.m_WhiteCubeTexture;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060006F4 RID: 1780 RVA: 0x0002245C File Offset: 0x0002065C
		public static RenderTexture emptyUAV
		{
			get
			{
				if (CoreUtils.m_EmptyUAV == null)
				{
					CoreUtils.m_EmptyUAV = new RenderTexture(1, 1, 0);
					CoreUtils.m_EmptyUAV.enableRandomWrite = true;
					CoreUtils.m_EmptyUAV.Create();
				}
				return CoreUtils.m_EmptyUAV;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060006F5 RID: 1781 RVA: 0x00022494 File Offset: 0x00020694
		public static Texture3D blackVolumeTexture
		{
			get
			{
				if (CoreUtils.m_BlackVolumeTexture == null)
				{
					Color[] colors = new Color[]
					{
						Color.black
					};
					CoreUtils.m_BlackVolumeTexture = new Texture3D(1, 1, 1, GraphicsFormat.R8G8B8A8_SRGB, TextureCreationFlags.None);
					CoreUtils.m_BlackVolumeTexture.SetPixels(colors, 0);
					CoreUtils.m_BlackVolumeTexture.Apply();
				}
				return CoreUtils.m_BlackVolumeTexture;
			}
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x000224EB File Offset: 0x000206EB
		public static void ClearRenderTarget(CommandBuffer cmd, ClearFlag clearFlag, Color clearColor)
		{
			if (clearFlag != ClearFlag.None)
			{
				cmd.ClearRenderTarget((RTClearFlags)clearFlag, clearColor, 1f, 0U);
			}
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x000224FE File Offset: 0x000206FE
		private static int FixupDepthSlice(int depthSlice, RTHandle buffer)
		{
			if (depthSlice == -1)
			{
				RenderTexture rt = buffer.rt;
				if (rt != null && rt.dimension == TextureDimension.Cube)
				{
					depthSlice = 0;
				}
			}
			return depthSlice;
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x0002251F File Offset: 0x0002071F
		private static int FixupDepthSlice(int depthSlice, CubemapFace cubemapFace)
		{
			if (depthSlice == -1 && cubemapFace != CubemapFace.Unknown)
			{
				depthSlice = 0;
			}
			return depthSlice;
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x0002252D File Offset: 0x0002072D
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, ClearFlag clearFlag, Color clearColor, int miplevel = 0, CubemapFace cubemapFace = CubemapFace.Unknown, int depthSlice = -1)
		{
			depthSlice = CoreUtils.FixupDepthSlice(depthSlice, cubemapFace);
			cmd.SetRenderTarget(buffer, miplevel, cubemapFace, depthSlice);
			CoreUtils.ClearRenderTarget(cmd, clearFlag, clearColor);
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x0002254F File Offset: 0x0002074F
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, ClearFlag clearFlag = ClearFlag.None, int miplevel = 0, CubemapFace cubemapFace = CubemapFace.Unknown, int depthSlice = -1)
		{
			CoreUtils.SetRenderTarget(cmd, buffer, clearFlag, Color.clear, miplevel, cubemapFace, depthSlice);
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x00022563 File Offset: 0x00020763
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderTargetIdentifier depthBuffer, int miplevel = 0, CubemapFace cubemapFace = CubemapFace.Unknown, int depthSlice = -1)
		{
			CoreUtils.SetRenderTarget(cmd, colorBuffer, depthBuffer, ClearFlag.None, Color.clear, miplevel, cubemapFace, depthSlice);
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x00022578 File Offset: 0x00020778
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderTargetIdentifier depthBuffer, ClearFlag clearFlag, int miplevel = 0, CubemapFace cubemapFace = CubemapFace.Unknown, int depthSlice = -1)
		{
			CoreUtils.SetRenderTarget(cmd, colorBuffer, depthBuffer, clearFlag, Color.clear, miplevel, cubemapFace, depthSlice);
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x0002258E File Offset: 0x0002078E
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderTargetIdentifier depthBuffer, ClearFlag clearFlag, Color clearColor, int miplevel = 0, CubemapFace cubemapFace = CubemapFace.Unknown, int depthSlice = -1)
		{
			depthSlice = CoreUtils.FixupDepthSlice(depthSlice, cubemapFace);
			cmd.SetRenderTarget(colorBuffer, depthBuffer, miplevel, cubemapFace, depthSlice);
			CoreUtils.ClearRenderTarget(cmd, clearFlag, clearColor);
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x000225B2 File Offset: 0x000207B2
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier[] colorBuffers, RenderTargetIdentifier depthBuffer)
		{
			CoreUtils.SetRenderTarget(cmd, colorBuffers, depthBuffer, ClearFlag.None, Color.clear);
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x000225C2 File Offset: 0x000207C2
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier[] colorBuffers, RenderTargetIdentifier depthBuffer, ClearFlag clearFlag = ClearFlag.None)
		{
			CoreUtils.SetRenderTarget(cmd, colorBuffers, depthBuffer, clearFlag, Color.clear);
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x000225D2 File Offset: 0x000207D2
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier[] colorBuffers, RenderTargetIdentifier depthBuffer, ClearFlag clearFlag, Color clearColor)
		{
			cmd.SetRenderTarget(colorBuffers, depthBuffer, 0, CubemapFace.Unknown, -1);
			CoreUtils.ClearRenderTarget(cmd, clearFlag, clearColor);
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x000225E8 File Offset: 0x000207E8
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, ClearFlag clearFlag, Color clearColor)
		{
			cmd.SetRenderTarget(buffer, loadAction, storeAction);
			CoreUtils.ClearRenderTarget(cmd, clearFlag, clearColor);
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x000225FD File Offset: 0x000207FD
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, int miplevel = 0, CubemapFace cubemapFace = CubemapFace.Unknown, int depthSlice = -1)
		{
			depthSlice = CoreUtils.FixupDepthSlice(depthSlice, cubemapFace);
			buffer = new RenderTargetIdentifier(buffer, miplevel, cubemapFace, depthSlice);
			cmd.SetRenderTarget(buffer, loadAction, storeAction);
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x00022621 File Offset: 0x00020821
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, ClearFlag clearFlag, Color clearColor, int miplevel = 0, CubemapFace cubemapFace = CubemapFace.Unknown, int depthSlice = -1)
		{
			depthSlice = CoreUtils.FixupDepthSlice(depthSlice, cubemapFace);
			buffer = new RenderTargetIdentifier(buffer, miplevel, cubemapFace, depthSlice);
			CoreUtils.SetRenderTarget(cmd, buffer, loadAction, storeAction, clearFlag, clearColor);
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x00022649 File Offset: 0x00020849
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, ClearFlag clearFlag)
		{
			CoreUtils.SetRenderTarget(cmd, buffer, loadAction, storeAction, clearFlag, Color.clear);
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x0002265B File Offset: 0x0002085B
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderTargetIdentifier depthBuffer, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, ClearFlag clearFlag, Color clearColor)
		{
			cmd.SetRenderTarget(colorBuffer, colorLoadAction, colorStoreAction, depthBuffer, depthLoadAction, depthStoreAction);
			CoreUtils.ClearRenderTarget(cmd, clearFlag, clearColor);
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x00022676 File Offset: 0x00020876
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderTargetIdentifier depthBuffer, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, int miplevel = 0, CubemapFace cubemapFace = CubemapFace.Unknown, int depthSlice = -1)
		{
			depthSlice = CoreUtils.FixupDepthSlice(depthSlice, cubemapFace);
			colorBuffer = new RenderTargetIdentifier(colorBuffer, miplevel, cubemapFace, depthSlice);
			depthBuffer = new RenderTargetIdentifier(depthBuffer, miplevel, cubemapFace, depthSlice);
			cmd.SetRenderTarget(colorBuffer, colorLoadAction, colorStoreAction, depthBuffer, depthLoadAction, depthStoreAction);
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x000226B0 File Offset: 0x000208B0
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderTargetIdentifier depthBuffer, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, ClearFlag clearFlag, Color clearColor, int miplevel = 0, CubemapFace cubemapFace = CubemapFace.Unknown, int depthSlice = -1)
		{
			depthSlice = CoreUtils.FixupDepthSlice(depthSlice, cubemapFace);
			colorBuffer = new RenderTargetIdentifier(colorBuffer, miplevel, cubemapFace, depthSlice);
			depthBuffer = new RenderTargetIdentifier(depthBuffer, miplevel, cubemapFace, depthSlice);
			CoreUtils.SetRenderTarget(cmd, colorBuffer, colorLoadAction, colorStoreAction, depthBuffer, depthLoadAction, depthStoreAction, clearFlag, clearColor);
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x000226F8 File Offset: 0x000208F8
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, ClearFlag clearFlag, Color clearColor)
		{
			cmd.SetRenderTarget(buffer, colorLoadAction, colorStoreAction, depthLoadAction, depthStoreAction);
			CoreUtils.ClearRenderTarget(cmd, clearFlag, clearColor);
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x00022714 File Offset: 0x00020914
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderTargetIdentifier depthBuffer, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, ClearFlag clearFlag)
		{
			CoreUtils.SetRenderTarget(cmd, colorBuffer, colorLoadAction, colorStoreAction, depthBuffer, depthLoadAction, depthStoreAction, clearFlag, Color.clear);
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x00022737 File Offset: 0x00020937
		private static void SetViewportAndClear(CommandBuffer cmd, RTHandle buffer, ClearFlag clearFlag, Color clearColor)
		{
			CoreUtils.SetViewport(cmd, buffer);
			CoreUtils.ClearRenderTarget(cmd, clearFlag, clearColor);
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00022748 File Offset: 0x00020948
		public static void SetRenderTarget(CommandBuffer cmd, RTHandle buffer, ClearFlag clearFlag, Color clearColor, int miplevel = 0, CubemapFace cubemapFace = CubemapFace.Unknown, int depthSlice = -1)
		{
			depthSlice = CoreUtils.FixupDepthSlice(depthSlice, buffer);
			cmd.SetRenderTarget(buffer.nameID, miplevel, cubemapFace, depthSlice);
			CoreUtils.SetViewportAndClear(cmd, buffer, clearFlag, clearColor);
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x0002276F File Offset: 0x0002096F
		public static void SetRenderTarget(CommandBuffer cmd, RTHandle buffer, ClearFlag clearFlag = ClearFlag.None, int miplevel = 0, CubemapFace cubemapFace = CubemapFace.Unknown, int depthSlice = -1)
		{
			CoreUtils.SetRenderTarget(cmd, buffer, clearFlag, Color.clear, miplevel, cubemapFace, depthSlice);
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x00022784 File Offset: 0x00020984
		public static void SetRenderTarget(CommandBuffer cmd, RTHandle colorBuffer, RTHandle depthBuffer, int miplevel = 0, CubemapFace cubemapFace = CubemapFace.Unknown, int depthSlice = -1)
		{
			if (colorBuffer.rt != null && depthBuffer.rt != null)
			{
				int width = colorBuffer.rt.width;
				int height = colorBuffer.rt.height;
				int width2 = depthBuffer.rt.width;
				int height2 = depthBuffer.rt.height;
			}
			CoreUtils.SetRenderTarget(cmd, colorBuffer, depthBuffer, ClearFlag.None, Color.clear, miplevel, cubemapFace, depthSlice);
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x000227F0 File Offset: 0x000209F0
		public static void SetRenderTarget(CommandBuffer cmd, RTHandle colorBuffer, RTHandle depthBuffer, ClearFlag clearFlag, int miplevel = 0, CubemapFace cubemapFace = CubemapFace.Unknown, int depthSlice = -1)
		{
			if (colorBuffer.rt != null && depthBuffer.rt != null)
			{
				int width = colorBuffer.rt.width;
				int height = colorBuffer.rt.height;
				int width2 = depthBuffer.rt.width;
				int height2 = depthBuffer.rt.height;
			}
			CoreUtils.SetRenderTarget(cmd, colorBuffer, depthBuffer, clearFlag, Color.clear, miplevel, cubemapFace, depthSlice);
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x00022860 File Offset: 0x00020A60
		public static void SetRenderTarget(CommandBuffer cmd, RTHandle colorBuffer, RTHandle depthBuffer, ClearFlag clearFlag, Color clearColor, int miplevel = 0, CubemapFace cubemapFace = CubemapFace.Unknown, int depthSlice = -1)
		{
			if (colorBuffer.rt != null && depthBuffer.rt != null)
			{
				int width = colorBuffer.rt.width;
				int height = colorBuffer.rt.height;
				int width2 = depthBuffer.rt.width;
				int height2 = depthBuffer.rt.height;
			}
			CoreUtils.SetRenderTarget(cmd, colorBuffer.nameID, depthBuffer.nameID, miplevel, cubemapFace, depthSlice);
			CoreUtils.SetViewportAndClear(cmd, colorBuffer, clearFlag, clearColor);
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x000228DB File Offset: 0x00020ADB
		public static void SetRenderTarget(CommandBuffer cmd, RTHandle buffer, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, ClearFlag clearFlag, Color clearColor, int miplevel = 0, CubemapFace cubemapFace = CubemapFace.Unknown, int depthSlice = -1)
		{
			CoreUtils.SetRenderTarget(cmd, buffer.nameID, loadAction, storeAction, miplevel, cubemapFace, depthSlice);
			CoreUtils.SetViewportAndClear(cmd, buffer, clearFlag, clearColor);
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x000228FC File Offset: 0x00020AFC
		public static void SetRenderTarget(CommandBuffer cmd, RTHandle colorBuffer, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RTHandle depthBuffer, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, ClearFlag clearFlag, Color clearColor, int miplevel = 0, CubemapFace cubemapFace = CubemapFace.Unknown, int depthSlice = -1)
		{
			if (colorBuffer.rt != null && depthBuffer.rt != null)
			{
				int width = colorBuffer.rt.width;
				int height = colorBuffer.rt.height;
				int width2 = depthBuffer.rt.width;
				int height2 = depthBuffer.rt.height;
			}
			CoreUtils.SetRenderTarget(cmd, colorBuffer.nameID, colorLoadAction, colorStoreAction, depthBuffer.nameID, depthLoadAction, depthStoreAction, miplevel, cubemapFace, depthSlice);
			CoreUtils.SetViewportAndClear(cmd, colorBuffer, clearFlag, clearColor);
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x00022982 File Offset: 0x00020B82
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier[] colorBuffers, RTHandle depthBuffer)
		{
			CoreUtils.SetRenderTarget(cmd, colorBuffers, depthBuffer.nameID, ClearFlag.None, Color.clear);
			CoreUtils.SetViewport(cmd, depthBuffer);
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x0002299E File Offset: 0x00020B9E
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier[] colorBuffers, RTHandle depthBuffer, ClearFlag clearFlag = ClearFlag.None)
		{
			CoreUtils.SetRenderTarget(cmd, colorBuffers, depthBuffer.nameID);
			CoreUtils.SetViewportAndClear(cmd, depthBuffer, clearFlag, Color.clear);
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x000229BA File Offset: 0x00020BBA
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier[] colorBuffers, RTHandle depthBuffer, ClearFlag clearFlag, Color clearColor)
		{
			cmd.SetRenderTarget(colorBuffers, depthBuffer.nameID, 0, CubemapFace.Unknown, -1);
			CoreUtils.SetViewportAndClear(cmd, depthBuffer, clearFlag, clearColor);
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x000229D8 File Offset: 0x00020BD8
		public static void SetViewport(CommandBuffer cmd, RTHandle target)
		{
			if (target.useScaling)
			{
				Vector2Int scaledSize = target.GetScaledSize(target.rtHandleProperties.currentViewportSize);
				cmd.SetViewport(new Rect(0f, 0f, (float)scaledSize.x, (float)scaledSize.y));
			}
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x00022A24 File Offset: 0x00020C24
		public static string GetRenderTargetAutoName(int width, int height, int depth, RenderTextureFormat format, string name, bool mips = false, bool enableMSAA = false, MSAASamples msaaSamples = MSAASamples.None)
		{
			return CoreUtils.GetRenderTargetAutoName(width, height, depth, format.ToString(), TextureDimension.None, name, mips, enableMSAA, msaaSamples, false);
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x00022A50 File Offset: 0x00020C50
		public static string GetRenderTargetAutoName(int width, int height, int depth, GraphicsFormat format, string name, bool mips = false, bool enableMSAA = false, MSAASamples msaaSamples = MSAASamples.None)
		{
			return CoreUtils.GetRenderTargetAutoName(width, height, depth, format.ToString(), TextureDimension.None, name, mips, enableMSAA, msaaSamples, false);
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x00022A7C File Offset: 0x00020C7C
		public static string GetRenderTargetAutoName(int width, int height, int depth, GraphicsFormat format, TextureDimension dim, string name, bool mips = false, bool enableMSAA = false, MSAASamples msaaSamples = MSAASamples.None, bool dynamicRes = false)
		{
			return CoreUtils.GetRenderTargetAutoName(width, height, depth, format.ToString(), dim, name, mips, enableMSAA, msaaSamples, dynamicRes);
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x00022AAC File Offset: 0x00020CAC
		private static string GetRenderTargetAutoName(int width, int height, int depth, string format, TextureDimension dim, string name, bool mips, bool enableMSAA, MSAASamples msaaSamples, bool dynamicRes)
		{
			string text = string.Format("{0}_{1}x{2}", name, width, height);
			if (depth > 1)
			{
				text = string.Format("{0}x{1}", text, depth);
			}
			if (mips)
			{
				text = string.Format("{0}_{1}", text, "Mips");
			}
			text = string.Format("{0}_{1}", text, format);
			if (dim != TextureDimension.None)
			{
				text = string.Format("{0}_{1}", text, dim);
			}
			if (enableMSAA)
			{
				text = string.Format("{0}_{1}", text, msaaSamples.ToString());
			}
			if (dynamicRes)
			{
				text = string.Format("{0}_{1}", text, "dynamic");
			}
			return text;
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x00022B54 File Offset: 0x00020D54
		public static string GetTextureAutoName(int width, int height, TextureFormat format, TextureDimension dim = TextureDimension.None, string name = "", bool mips = false, int depth = 0)
		{
			return CoreUtils.GetTextureAutoName(width, height, format.ToString(), dim, name, mips, depth);
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x00022B71 File Offset: 0x00020D71
		public static string GetTextureAutoName(int width, int height, GraphicsFormat format, TextureDimension dim = TextureDimension.None, string name = "", bool mips = false, int depth = 0)
		{
			return CoreUtils.GetTextureAutoName(width, height, format.ToString(), dim, name, mips, depth);
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x00022B90 File Offset: 0x00020D90
		private static string GetTextureAutoName(int width, int height, string format, TextureDimension dim = TextureDimension.None, string name = "", bool mips = false, int depth = 0)
		{
			string arg;
			if (depth == 0)
			{
				arg = string.Format("{0}x{1}{2}_{3}", new object[]
				{
					width,
					height,
					mips ? "_Mips" : "",
					format
				});
			}
			else
			{
				arg = string.Format("{0}x{1}x{2}{3}_{4}", new object[]
				{
					width,
					height,
					depth,
					mips ? "_Mips" : "",
					format
				});
			}
			return string.Format("{0}_{1}_{2}", (name == "") ? "Texture" : name, (dim == TextureDimension.None) ? "" : dim.ToString(), arg);
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x00022C5C File Offset: 0x00020E5C
		public static void ClearCubemap(CommandBuffer cmd, RenderTexture renderTexture, Color clearColor, bool clearMips = false)
		{
			int num = 1;
			if (renderTexture.useMipMap && clearMips)
			{
				num = (int)Mathf.Log((float)renderTexture.width, 2f) + 1;
			}
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < num; j++)
				{
					CoreUtils.SetRenderTarget(cmd, new RenderTargetIdentifier(renderTexture), ClearFlag.Color, clearColor, j, (CubemapFace)i, -1);
				}
			}
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x00022CB3 File Offset: 0x00020EB3
		public static void DrawFullScreen(CommandBuffer commandBuffer, Material material, MaterialPropertyBlock properties = null, int shaderPassId = 0)
		{
			commandBuffer.DrawProcedural(Matrix4x4.identity, material, shaderPassId, MeshTopology.Triangles, 3, 1, properties);
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x00022CC6 File Offset: 0x00020EC6
		public static void DrawFullScreen(CommandBuffer commandBuffer, Material material, RenderTargetIdentifier colorBuffer, MaterialPropertyBlock properties = null, int shaderPassId = 0)
		{
			commandBuffer.SetRenderTarget(colorBuffer, 0, CubemapFace.Unknown, -1);
			commandBuffer.DrawProcedural(Matrix4x4.identity, material, shaderPassId, MeshTopology.Triangles, 3, 1, properties);
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x00022CE4 File Offset: 0x00020EE4
		public static void DrawFullScreen(CommandBuffer commandBuffer, Material material, RenderTargetIdentifier colorBuffer, RenderTargetIdentifier depthStencilBuffer, MaterialPropertyBlock properties = null, int shaderPassId = 0)
		{
			commandBuffer.SetRenderTarget(colorBuffer, depthStencilBuffer, 0, CubemapFace.Unknown, -1);
			commandBuffer.DrawProcedural(Matrix4x4.identity, material, shaderPassId, MeshTopology.Triangles, 3, 1, properties);
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x00022D04 File Offset: 0x00020F04
		public static void DrawFullScreen(CommandBuffer commandBuffer, Material material, RenderTargetIdentifier[] colorBuffers, RenderTargetIdentifier depthStencilBuffer, MaterialPropertyBlock properties = null, int shaderPassId = 0)
		{
			commandBuffer.SetRenderTarget(colorBuffers, depthStencilBuffer, 0, CubemapFace.Unknown, -1);
			commandBuffer.DrawProcedural(Matrix4x4.identity, material, shaderPassId, MeshTopology.Triangles, 3, 1, properties);
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x00022D24 File Offset: 0x00020F24
		public static void DrawFullScreen(CommandBuffer commandBuffer, Material material, RenderTargetIdentifier[] colorBuffers, MaterialPropertyBlock properties = null, int shaderPassId = 0)
		{
			CoreUtils.DrawFullScreen(commandBuffer, material, colorBuffers, colorBuffers[0], properties, shaderPassId);
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x00022D38 File Offset: 0x00020F38
		public static Color ConvertSRGBToActiveColorSpace(Color color)
		{
			if (QualitySettings.activeColorSpace != ColorSpace.Linear)
			{
				return color;
			}
			return color.linear;
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x00022D4B File Offset: 0x00020F4B
		public static Color ConvertLinearToActiveColorSpace(Color color)
		{
			if (QualitySettings.activeColorSpace != ColorSpace.Linear)
			{
				return color.gamma;
			}
			return color;
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x00022D60 File Offset: 0x00020F60
		public static Material CreateEngineMaterial(string shaderPath)
		{
			Shader shader = Shader.Find(shaderPath);
			if (shader == null)
			{
				Debug.LogError("Cannot create required material because shader " + shaderPath + " could not be found");
				return null;
			}
			return new Material(shader)
			{
				hideFlags = HideFlags.HideAndDontSave
			};
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x00022DA2 File Offset: 0x00020FA2
		public static Material CreateEngineMaterial(Shader shader)
		{
			if (shader == null)
			{
				Debug.LogError("Cannot create required material because shader is null");
				return null;
			}
			return new Material(shader)
			{
				hideFlags = HideFlags.HideAndDontSave
			};
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x00022DC7 File Offset: 0x00020FC7
		public static bool HasFlag<T>(T mask, T flag) where T : IConvertible
		{
			return (mask.ToUInt32(null) & flag.ToUInt32(null)) > 0U;
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x00022DEC File Offset: 0x00020FEC
		public static void Swap<T>(ref T a, ref T b)
		{
			T t = a;
			a = b;
			b = t;
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x00022E13 File Offset: 0x00021013
		public static void SetKeyword(CommandBuffer cmd, string keyword, bool state)
		{
			if (state)
			{
				cmd.EnableShaderKeyword(keyword);
				return;
			}
			cmd.DisableShaderKeyword(keyword);
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x00022E27 File Offset: 0x00021027
		public static void SetKeyword(Material material, string keyword, bool state)
		{
			if (state)
			{
				material.EnableKeyword(keyword);
				return;
			}
			material.DisableKeyword(keyword);
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x00022E3B File Offset: 0x0002103B
		public static void SetKeyword(ComputeShader cs, string keyword, bool state)
		{
			if (state)
			{
				cs.EnableKeyword(keyword);
				return;
			}
			cs.DisableKeyword(keyword);
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x00022E4F File Offset: 0x0002104F
		public static void Destroy(Object obj)
		{
			if (obj != null)
			{
				Object.Destroy(obj);
			}
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x00022E60 File Offset: 0x00021060
		public static IEnumerable<Type> GetAllAssemblyTypes()
		{
			if (CoreUtils.m_AssemblyTypes == null)
			{
				CoreUtils.m_AssemblyTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(delegate(Assembly t)
				{
					Type[] result = new Type[0];
					try
					{
						result = t.GetTypes();
					}
					catch
					{
					}
					return result;
				});
			}
			return CoreUtils.m_AssemblyTypes;
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x00022EAC File Offset: 0x000210AC
		public static IEnumerable<Type> GetAllTypesDerivedFrom<T>()
		{
			return from t in CoreUtils.GetAllAssemblyTypes()
			where t.IsSubclassOf(typeof(T))
			select t;
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x00022ED7 File Offset: 0x000210D7
		public static void SafeRelease(GraphicsBuffer buffer)
		{
			if (buffer != null)
			{
				buffer.Release();
			}
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x00022EE2 File Offset: 0x000210E2
		public static void SafeRelease(ComputeBuffer buffer)
		{
			if (buffer != null)
			{
				buffer.Release();
			}
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x00022EF0 File Offset: 0x000210F0
		public static Mesh CreateCubeMesh(Vector3 min, Vector3 max)
		{
			return new Mesh
			{
				vertices = new Vector3[]
				{
					new Vector3(min.x, min.y, min.z),
					new Vector3(max.x, min.y, min.z),
					new Vector3(max.x, max.y, min.z),
					new Vector3(min.x, max.y, min.z),
					new Vector3(min.x, min.y, max.z),
					new Vector3(max.x, min.y, max.z),
					new Vector3(max.x, max.y, max.z),
					new Vector3(min.x, max.y, max.z)
				},
				triangles = new int[]
				{
					0,
					2,
					1,
					0,
					3,
					2,
					1,
					6,
					5,
					1,
					2,
					6,
					5,
					7,
					4,
					5,
					6,
					7,
					4,
					3,
					0,
					4,
					7,
					3,
					3,
					6,
					2,
					3,
					7,
					6,
					4,
					1,
					5,
					4,
					0,
					1
				}
			};
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x000230BA File Offset: 0x000212BA
		public static bool ArePostProcessesEnabled(Camera camera)
		{
			return true;
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x000230BD File Offset: 0x000212BD
		public static bool AreAnimatedMaterialsEnabled(Camera camera)
		{
			return true;
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x000230C0 File Offset: 0x000212C0
		public static bool IsSceneLightingDisabled(Camera camera)
		{
			return false;
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x000230C3 File Offset: 0x000212C3
		public static bool IsLightOverlapDebugEnabled(Camera camera)
		{
			return false;
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x000230C6 File Offset: 0x000212C6
		public static bool IsSceneViewFogEnabled(Camera camera)
		{
			return true;
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x000230C9 File Offset: 0x000212C9
		public static bool IsSceneFilteringEnabled()
		{
			return false;
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x000230CC File Offset: 0x000212CC
		public static bool IsSceneViewPrefabStageContextHidden()
		{
			return false;
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x000230CF File Offset: 0x000212CF
		public static void DrawRendererList(ScriptableRenderContext renderContext, CommandBuffer cmd, RendererList rendererList)
		{
			if (!rendererList.isValid)
			{
				throw new ArgumentException("Invalid renderer list provided to DrawRendererList");
			}
			cmd.DrawRendererList(rendererList);
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x000230EC File Offset: 0x000212EC
		public static int GetTextureHash(Texture texture)
		{
			int num = texture.GetHashCode();
			num = 23 * num + texture.GetInstanceID().GetHashCode();
			num = 23 * num + texture.graphicsFormat.GetHashCode();
			num = 23 * num + texture.wrapMode.GetHashCode();
			num = 23 * num + texture.width.GetHashCode();
			num = 23 * num + texture.height.GetHashCode();
			num = 23 * num + texture.filterMode.GetHashCode();
			num = 23 * num + texture.anisoLevel.GetHashCode();
			num = 23 * num + texture.mipmapCount.GetHashCode();
			return 23 * num + texture.updateCount.GetHashCode();
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x000231C9 File Offset: 0x000213C9
		public static int PreviousPowerOfTwo(int size)
		{
			if (size <= 0)
			{
				return 0;
			}
			size |= size >> 1;
			size |= size >> 2;
			size |= size >> 4;
			size |= size >> 8;
			size |= size >> 16;
			return size - (size >> 1);
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x000231FA File Offset: 0x000213FA
		public static T GetLastEnumValue<T>() where T : Enum
		{
			return typeof(T).GetEnumValues().Cast<T>().Last<T>();
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x00023215 File Offset: 0x00021415
		internal static string GetCorePath()
		{
			return "Packages/com.unity.render-pipelines.core/";
		}

		// Token: 0x04000487 RID: 1159
		public static readonly Vector3[] lookAtList = new Vector3[]
		{
			new Vector3(1f, 0f, 0f),
			new Vector3(-1f, 0f, 0f),
			new Vector3(0f, 1f, 0f),
			new Vector3(0f, -1f, 0f),
			new Vector3(0f, 0f, 1f),
			new Vector3(0f, 0f, -1f)
		};

		// Token: 0x04000488 RID: 1160
		public static readonly Vector3[] upVectorList = new Vector3[]
		{
			new Vector3(0f, 1f, 0f),
			new Vector3(0f, 1f, 0f),
			new Vector3(0f, 0f, -1f),
			new Vector3(0f, 0f, 1f),
			new Vector3(0f, 1f, 0f),
			new Vector3(0f, 1f, 0f)
		};

		// Token: 0x04000489 RID: 1161
		private const string obsoletePriorityMessage = "Use CoreUtils.Priorities instead";

		// Token: 0x0400048A RID: 1162
		[Obsolete("Use CoreUtils.Priorities instead", false)]
		public const int editMenuPriority1 = 320;

		// Token: 0x0400048B RID: 1163
		[Obsolete("Use CoreUtils.Priorities instead", false)]
		public const int editMenuPriority2 = 331;

		// Token: 0x0400048C RID: 1164
		[Obsolete("Use CoreUtils.Priorities instead", false)]
		public const int editMenuPriority3 = 342;

		// Token: 0x0400048D RID: 1165
		[Obsolete("Use CoreUtils.Priorities instead", false)]
		public const int editMenuPriority4 = 353;

		// Token: 0x0400048E RID: 1166
		[Obsolete("Use CoreUtils.Priorities instead", false)]
		public const int assetCreateMenuPriority1 = 230;

		// Token: 0x0400048F RID: 1167
		[Obsolete("Use CoreUtils.Priorities instead", false)]
		public const int assetCreateMenuPriority2 = 241;

		// Token: 0x04000490 RID: 1168
		[Obsolete("Use CoreUtils.Priorities instead", false)]
		public const int assetCreateMenuPriority3 = 300;

		// Token: 0x04000491 RID: 1169
		[Obsolete("Use CoreUtils.Priorities instead", false)]
		public const int gameObjectMenuPriority = 10;

		// Token: 0x04000492 RID: 1170
		private static Cubemap m_BlackCubeTexture;

		// Token: 0x04000493 RID: 1171
		private static Cubemap m_MagentaCubeTexture;

		// Token: 0x04000494 RID: 1172
		private static CubemapArray m_MagentaCubeTextureArray;

		// Token: 0x04000495 RID: 1173
		private static Cubemap m_WhiteCubeTexture;

		// Token: 0x04000496 RID: 1174
		private static RenderTexture m_EmptyUAV;

		// Token: 0x04000497 RID: 1175
		private static Texture3D m_BlackVolumeTexture;

		// Token: 0x04000498 RID: 1176
		private static IEnumerable<Type> m_AssemblyTypes;

		// Token: 0x020001C8 RID: 456
		public static class Sections
		{
			// Token: 0x04000766 RID: 1894
			public const int section1 = 10000;

			// Token: 0x04000767 RID: 1895
			public const int section2 = 20000;

			// Token: 0x04000768 RID: 1896
			public const int section3 = 30000;

			// Token: 0x04000769 RID: 1897
			public const int section4 = 40000;

			// Token: 0x0400076A RID: 1898
			public const int section5 = 50000;

			// Token: 0x0400076B RID: 1899
			public const int section6 = 60000;

			// Token: 0x0400076C RID: 1900
			public const int section7 = 70000;

			// Token: 0x0400076D RID: 1901
			public const int section8 = 80000;
		}

		// Token: 0x020001C9 RID: 457
		public static class Priorities
		{
			// Token: 0x0400076E RID: 1902
			public const int assetsCreateShaderMenuPriority = 83;

			// Token: 0x0400076F RID: 1903
			public const int assetsCreateRenderingMenuPriority = 308;

			// Token: 0x04000770 RID: 1904
			public const int editMenuPriority = 320;

			// Token: 0x04000771 RID: 1905
			public const int gameObjectMenuPriority = 10;

			// Token: 0x04000772 RID: 1906
			public const int srpLensFlareMenuPriority = 303;
		}
	}
}
