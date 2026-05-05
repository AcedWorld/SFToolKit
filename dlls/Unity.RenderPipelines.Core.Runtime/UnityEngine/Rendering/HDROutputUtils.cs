using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000DA RID: 218
	public static class HDROutputUtils
	{
		// Token: 0x06000762 RID: 1890 RVA: 0x00023D54 File Offset: 0x00021F54
		public static bool GetColorSpaceForGamut(ColorGamut gamut, out int colorspace)
		{
			if (ColorGamutUtility.GetWhitePoint(gamut) != WhitePoint.D65)
			{
				Debug.LogWarningFormat("{0} white point is currently unsupported for outputting to HDR.", new object[]
				{
					gamut.ToString()
				});
				colorspace = -1;
				return false;
			}
			switch (ColorGamutUtility.GetColorPrimaries(gamut))
			{
			case ColorPrimaries.Rec709:
				colorspace = 0;
				return true;
			case ColorPrimaries.Rec2020:
				colorspace = 1;
				return true;
			case ColorPrimaries.P3:
				colorspace = 2;
				return true;
			default:
				Debug.LogWarningFormat("{0} color space is currently unsupported for outputting to HDR.", new object[]
				{
					gamut.ToString()
				});
				colorspace = -1;
				return false;
			}
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x00023DDC File Offset: 0x00021FDC
		public static bool GetColorEncodingForGamut(ColorGamut gamut, out int encoding)
		{
			switch (ColorGamutUtility.GetTransferFunction(gamut))
			{
			case TransferFunction.sRGB:
				encoding = 0;
				return true;
			case TransferFunction.PQ:
				encoding = 2;
				return true;
			case TransferFunction.Linear:
				encoding = 3;
				return true;
			case TransferFunction.Gamma22:
				encoding = 4;
				return true;
			}
			Debug.LogWarningFormat("{0} color encoding is currently unsupported for outputting to HDR.", new object[]
			{
				gamut.ToString()
			});
			encoding = -1;
			return false;
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x00023E44 File Offset: 0x00022044
		public static void ConfigureHDROutput(Material material, ColorGamut gamut, HDROutputUtils.Operation operations)
		{
			int value;
			int value2;
			if (!HDROutputUtils.GetColorSpaceForGamut(gamut, out value) || !HDROutputUtils.GetColorEncodingForGamut(gamut, out value2))
			{
				return;
			}
			material.SetInteger(HDROutputUtils.ShaderPropertyId.hdrColorSpace, value);
			material.SetInteger(HDROutputUtils.ShaderPropertyId.hdrEncoding, value2);
			CoreUtils.SetKeyword(material, HDROutputUtils.ShaderKeywords.HDRColorSpaceConversionAndEncoding.name, operations.HasFlag(HDROutputUtils.Operation.ColorConversion) && operations.HasFlag(HDROutputUtils.Operation.ColorEncoding));
			CoreUtils.SetKeyword(material, HDROutputUtils.ShaderKeywords.HDREncoding.name, operations.HasFlag(HDROutputUtils.Operation.ColorEncoding) && !operations.HasFlag(HDROutputUtils.Operation.ColorConversion));
			CoreUtils.SetKeyword(material, HDROutputUtils.ShaderKeywords.HDRColorSpaceConversion.name, operations.HasFlag(HDROutputUtils.Operation.ColorConversion) && !operations.HasFlag(HDROutputUtils.Operation.ColorEncoding));
			CoreUtils.SetKeyword(material, HDROutputUtils.ShaderKeywords.HDRInput.name, operations == HDROutputUtils.Operation.None);
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x00023F4C File Offset: 0x0002214C
		public static void ConfigureHDROutput(MaterialPropertyBlock properties, ColorGamut gamut)
		{
			int value;
			int value2;
			if (!HDROutputUtils.GetColorSpaceForGamut(gamut, out value) || !HDROutputUtils.GetColorEncodingForGamut(gamut, out value2))
			{
				return;
			}
			properties.SetInteger(HDROutputUtils.ShaderPropertyId.hdrColorSpace, value);
			properties.SetInteger(HDROutputUtils.ShaderPropertyId.hdrEncoding, value2);
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x00023F88 File Offset: 0x00022188
		public static void ConfigureHDROutput(Material material, HDROutputUtils.Operation operations)
		{
			CoreUtils.SetKeyword(material, HDROutputUtils.ShaderKeywords.HDRColorSpaceConversionAndEncoding.name, operations.HasFlag(HDROutputUtils.Operation.ColorConversion) && operations.HasFlag(HDROutputUtils.Operation.ColorEncoding));
			CoreUtils.SetKeyword(material, HDROutputUtils.ShaderKeywords.HDREncoding.name, operations.HasFlag(HDROutputUtils.Operation.ColorEncoding) && !operations.HasFlag(HDROutputUtils.Operation.ColorConversion));
			CoreUtils.SetKeyword(material, HDROutputUtils.ShaderKeywords.HDRColorSpaceConversion.name, operations.HasFlag(HDROutputUtils.Operation.ColorConversion) && !operations.HasFlag(HDROutputUtils.Operation.ColorEncoding));
			CoreUtils.SetKeyword(material, HDROutputUtils.ShaderKeywords.HDRInput.name, operations == HDROutputUtils.Operation.None);
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x00024060 File Offset: 0x00022260
		public static void ConfigureHDROutput(ComputeShader computeShader, ColorGamut gamut, HDROutputUtils.Operation operations)
		{
			int val;
			int val2;
			if (!HDROutputUtils.GetColorSpaceForGamut(gamut, out val) || !HDROutputUtils.GetColorEncodingForGamut(gamut, out val2))
			{
				return;
			}
			computeShader.SetInt(HDROutputUtils.ShaderPropertyId.hdrColorSpace, val);
			computeShader.SetInt(HDROutputUtils.ShaderPropertyId.hdrEncoding, val2);
			CoreUtils.SetKeyword(computeShader, HDROutputUtils.ShaderKeywords.HDRColorSpaceConversionAndEncoding.name, operations.HasFlag(HDROutputUtils.Operation.ColorConversion) && operations.HasFlag(HDROutputUtils.Operation.ColorEncoding));
			CoreUtils.SetKeyword(computeShader, HDROutputUtils.ShaderKeywords.HDREncoding.name, operations.HasFlag(HDROutputUtils.Operation.ColorEncoding) && !operations.HasFlag(HDROutputUtils.Operation.ColorConversion));
			CoreUtils.SetKeyword(computeShader, HDROutputUtils.ShaderKeywords.HDRColorSpaceConversion.name, operations.HasFlag(HDROutputUtils.Operation.ColorConversion) && !operations.HasFlag(HDROutputUtils.Operation.ColorEncoding));
			CoreUtils.SetKeyword(computeShader, HDROutputUtils.ShaderKeywords.HDRInput.name, operations == HDROutputUtils.Operation.None);
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x00024168 File Offset: 0x00022368
		public static bool IsShaderVariantValid(ShaderKeywordSet shaderKeywordSet, bool isHDREnabled)
		{
			bool flag = shaderKeywordSet.IsEnabled(HDROutputUtils.ShaderKeywords.HDREncoding) || shaderKeywordSet.IsEnabled(HDROutputUtils.ShaderKeywords.HDRColorSpaceConversion) || shaderKeywordSet.IsEnabled(HDROutputUtils.ShaderKeywords.HDRColorSpaceConversionAndEncoding) || shaderKeywordSet.IsEnabled(HDROutputUtils.ShaderKeywords.HDRInput);
			return isHDREnabled || !flag;
		}

		// Token: 0x020001D0 RID: 464
		[Flags]
		public enum Operation
		{
			// Token: 0x0400078C RID: 1932
			None = 0,
			// Token: 0x0400078D RID: 1933
			ColorConversion = 1,
			// Token: 0x0400078E RID: 1934
			ColorEncoding = 2
		}

		// Token: 0x020001D1 RID: 465
		public struct HDRDisplayInformation
		{
			// Token: 0x06000B65 RID: 2917 RVA: 0x0002FCBB File Offset: 0x0002DEBB
			public HDRDisplayInformation(int maxFullFrameToneMapLuminance, int maxToneMapLuminance, int minToneMapLuminance, float hdrPaperWhiteNits)
			{
				this.maxFullFrameToneMapLuminance = maxFullFrameToneMapLuminance;
				this.maxToneMapLuminance = maxToneMapLuminance;
				this.minToneMapLuminance = minToneMapLuminance;
				this.paperWhiteNits = hdrPaperWhiteNits;
			}

			// Token: 0x0400078F RID: 1935
			public int maxFullFrameToneMapLuminance;

			// Token: 0x04000790 RID: 1936
			public int maxToneMapLuminance;

			// Token: 0x04000791 RID: 1937
			public int minToneMapLuminance;

			// Token: 0x04000792 RID: 1938
			public float paperWhiteNits;
		}

		// Token: 0x020001D2 RID: 466
		public static class ShaderKeywords
		{
			// Token: 0x04000793 RID: 1939
			public const string HDR_COLORSPACE_CONVERSION = "HDR_COLORSPACE_CONVERSION";

			// Token: 0x04000794 RID: 1940
			public const string HDR_ENCODING = "HDR_ENCODING";

			// Token: 0x04000795 RID: 1941
			public const string HDR_COLORSPACE_CONVERSION_AND_ENCODING = "HDR_COLORSPACE_CONVERSION_AND_ENCODING";

			// Token: 0x04000796 RID: 1942
			public const string HDR_INPUT = "HDR_INPUT";

			// Token: 0x04000797 RID: 1943
			internal static readonly ShaderKeyword HDRColorSpaceConversion = new ShaderKeyword("HDR_COLORSPACE_CONVERSION");

			// Token: 0x04000798 RID: 1944
			internal static readonly ShaderKeyword HDREncoding = new ShaderKeyword("HDR_ENCODING");

			// Token: 0x04000799 RID: 1945
			internal static readonly ShaderKeyword HDRColorSpaceConversionAndEncoding = new ShaderKeyword("HDR_COLORSPACE_CONVERSION_AND_ENCODING");

			// Token: 0x0400079A RID: 1946
			internal static readonly ShaderKeyword HDRInput = new ShaderKeyword("HDR_INPUT");
		}

		// Token: 0x020001D3 RID: 467
		private static class ShaderPropertyId
		{
			// Token: 0x0400079B RID: 1947
			public static readonly int hdrColorSpace = Shader.PropertyToID("_HDRColorspace");

			// Token: 0x0400079C RID: 1948
			public static readonly int hdrEncoding = Shader.PropertyToID("_HDREncoding");
		}
	}
}
