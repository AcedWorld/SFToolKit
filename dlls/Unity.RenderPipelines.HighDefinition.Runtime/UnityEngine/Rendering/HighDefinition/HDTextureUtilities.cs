using System;
using System.IO;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200020A RID: 522
	internal static class HDTextureUtilities
	{
		// Token: 0x06000F88 RID: 3976 RVA: 0x00078CC4 File Offset: 0x00076EC4
		public static void WriteTextureFileToDisk(Texture target, string filePath)
		{
			RenderTexture renderTexture = target as RenderTexture;
			Cubemap cubemap = target as Cubemap;
			if (renderTexture != null)
			{
				byte[] bytes = HDTextureUtilities.CopyRenderTextureToTexture2D(renderTexture).EncodeToEXR(Texture2D.EXRFlags.CompressZIP);
				HDBakingUtilities.CreateParentDirectoryIfMissing(filePath);
				File.WriteAllBytes(filePath, bytes);
				return;
			}
			if (cubemap != null)
			{
				Texture2D tex = new Texture2D(cubemap.width * 6, cubemap.height, GraphicsFormat.R16G16B16A16_SFloat, TextureCreationFlags.None);
				CommandBuffer commandBuffer = new CommandBuffer
				{
					name = "CopyCubemapToTexture2D"
				};
				for (int i = 0; i < 6; i++)
				{
					commandBuffer.CopyTexture(cubemap, i, 0, 0, 0, cubemap.width, cubemap.height, tex, 0, 0, cubemap.width * i, 0);
				}
				Graphics.ExecuteCommandBuffer(commandBuffer);
				byte[] bytes2 = tex.EncodeToEXR(Texture2D.EXRFlags.CompressZIP);
				HDBakingUtilities.CreateParentDirectoryIfMissing(filePath);
				File.WriteAllBytes(filePath, bytes2);
				return;
			}
			throw new ArgumentException();
		}

		// Token: 0x06000F89 RID: 3977 RVA: 0x00078D9C File Offset: 0x00076F9C
		public static Texture2D CopyRenderTextureToTexture2D(RenderTexture source)
		{
			GraphicsFormat graphicsFormat = source.graphicsFormat;
			TextureDimension dimension = source.dimension;
			if (dimension == TextureDimension.Tex2D)
			{
				int width = source.width;
				Texture2D texture2D = new Texture2D(width, width, graphicsFormat, TextureCreationFlags.None);
				Graphics.SetRenderTarget(source, 0);
				texture2D.ReadPixels(new Rect(0f, 0f, (float)width, (float)width), 0, 0);
				texture2D.Apply();
				Graphics.SetRenderTarget(null);
				return texture2D;
			}
			if (dimension == TextureDimension.Cube)
			{
				int width2 = source.width;
				RenderTexture temporary = RenderTexture.GetTemporary(width2 * 6, width2, 0, source.format);
				CommandBuffer commandBuffer = new CommandBuffer();
				for (int i = 0; i < 6; i++)
				{
					commandBuffer.CopyTexture(source, i, 0, 0, 0, width2, width2, temporary, 0, 0, i * width2, 0);
				}
				Graphics.ExecuteCommandBuffer(commandBuffer);
				Texture2D texture2D2 = new Texture2D(width2 * 6, width2, graphicsFormat, TextureCreationFlags.None);
				RenderTexture active = RenderTexture.active;
				RenderTexture.active = temporary;
				texture2D2.ReadPixels(new Rect(0f, 0f, (float)(6 * width2), (float)width2), 0, 0, false);
				RenderTexture.active = active;
				RenderTexture.ReleaseTemporary(temporary);
				return texture2D2;
			}
			throw new ArgumentException();
		}
	}
}
