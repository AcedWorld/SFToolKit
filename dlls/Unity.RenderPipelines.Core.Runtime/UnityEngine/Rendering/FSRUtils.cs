using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000D6 RID: 214
	public static class FSRUtils
	{
		// Token: 0x06000740 RID: 1856 RVA: 0x000233F0 File Offset: 0x000215F0
		public static void SetEasuConstants(CommandBuffer cmd, Vector2 inputViewportSizeInPixels, Vector2 inputImageSizeInPixels, Vector2 outputImageSizeInPixels)
		{
			Vector4 value;
			value.x = inputViewportSizeInPixels.x / outputImageSizeInPixels.x;
			value.y = inputViewportSizeInPixels.y / outputImageSizeInPixels.y;
			value.z = 0.5f * inputViewportSizeInPixels.x / outputImageSizeInPixels.x - 0.5f;
			value.w = 0.5f * inputViewportSizeInPixels.y / outputImageSizeInPixels.y - 0.5f;
			Vector4 value2;
			value2.x = 1f / inputImageSizeInPixels.x;
			value2.y = 1f / inputImageSizeInPixels.y;
			value2.z = 1f / inputImageSizeInPixels.x;
			value2.w = -1f / inputImageSizeInPixels.y;
			Vector4 value3;
			value3.x = -1f / inputImageSizeInPixels.x;
			value3.y = 2f / inputImageSizeInPixels.y;
			value3.z = 1f / inputImageSizeInPixels.x;
			value3.w = 2f / inputImageSizeInPixels.y;
			Vector4 value4;
			value4.x = 0f / inputImageSizeInPixels.x;
			value4.y = 4f / inputImageSizeInPixels.y;
			value4.z = 0f;
			value4.w = 0f;
			cmd.SetGlobalVector(FSRUtils.ShaderConstants._FsrEasuConstants0, value);
			cmd.SetGlobalVector(FSRUtils.ShaderConstants._FsrEasuConstants1, value2);
			cmd.SetGlobalVector(FSRUtils.ShaderConstants._FsrEasuConstants2, value3);
			cmd.SetGlobalVector(FSRUtils.ShaderConstants._FsrEasuConstants3, value4);
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x0002356C File Offset: 0x0002176C
		public static void SetRcasConstants(CommandBuffer cmd, float sharpnessStops = 0.2f)
		{
			float num = Mathf.Pow(2f, -sharpnessStops);
			ushort num2 = Mathf.FloatToHalf(num);
			float y = BitConverter.Int32BitsToSingle((int)num2 | (int)num2 << 16);
			Vector4 value;
			value.x = num;
			value.y = y;
			value.z = 0f;
			value.w = 0f;
			cmd.SetGlobalVector(FSRUtils.ShaderConstants._FsrRcasConstants, value);
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x000235CC File Offset: 0x000217CC
		public static void SetRcasConstantsLinear(CommandBuffer cmd, float sharpnessLinear = 0.92f)
		{
			float sharpnessStops = (1f - sharpnessLinear) * 2.5f;
			FSRUtils.SetRcasConstants(cmd, sharpnessStops);
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x000235EE File Offset: 0x000217EE
		public static bool IsSupported()
		{
			return SystemInfo.graphicsShaderLevel >= 45;
		}

		// Token: 0x04000499 RID: 1177
		internal const float kMaxSharpnessStops = 2.5f;

		// Token: 0x0400049A RID: 1178
		public const float kDefaultSharpnessStops = 0.2f;

		// Token: 0x0400049B RID: 1179
		public const float kDefaultSharpnessLinear = 0.92f;

		// Token: 0x020001CC RID: 460
		private static class ShaderConstants
		{
			// Token: 0x04000777 RID: 1911
			public static readonly int _FsrEasuConstants0 = Shader.PropertyToID("_FsrEasuConstants0");

			// Token: 0x04000778 RID: 1912
			public static readonly int _FsrEasuConstants1 = Shader.PropertyToID("_FsrEasuConstants1");

			// Token: 0x04000779 RID: 1913
			public static readonly int _FsrEasuConstants2 = Shader.PropertyToID("_FsrEasuConstants2");

			// Token: 0x0400077A RID: 1914
			public static readonly int _FsrEasuConstants3 = Shader.PropertyToID("_FsrEasuConstants3");

			// Token: 0x0400077B RID: 1915
			public static readonly int _FsrRcasConstants = Shader.PropertyToID("_FsrRcasConstants");
		}
	}
}
