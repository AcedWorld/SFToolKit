using System;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.Rendering
{
	// Token: 0x020000DC RID: 220
	[MovedFrom("Utilities")]
	public static class MaterialQualityUtilities
	{
		// Token: 0x06000769 RID: 1897 RVA: 0x000241BC File Offset: 0x000223BC
		public static MaterialQuality GetHighestQuality(this MaterialQuality levels)
		{
			for (int i = MaterialQualityUtilities.Keywords.Length - 1; i >= 0; i--)
			{
				MaterialQuality materialQuality = (MaterialQuality)(1 << i);
				if ((levels & materialQuality) != (MaterialQuality)0)
				{
					return materialQuality;
				}
			}
			return (MaterialQuality)0;
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x000241EC File Offset: 0x000223EC
		public static MaterialQuality GetClosestQuality(this MaterialQuality availableLevels, MaterialQuality requestedLevel)
		{
			if (availableLevels == (MaterialQuality)0)
			{
				return MaterialQuality.Low;
			}
			int num = requestedLevel.ToFirstIndex();
			MaterialQuality materialQuality = (MaterialQuality)0;
			for (int i = num; i >= 0; i--)
			{
				MaterialQuality materialQuality2 = MaterialQualityUtilities.FromIndex(i);
				if ((materialQuality2 & availableLevels) != (MaterialQuality)0)
				{
					materialQuality = materialQuality2;
					break;
				}
			}
			if (materialQuality != (MaterialQuality)0)
			{
				return materialQuality;
			}
			for (int j = num + 1; j < MaterialQualityUtilities.Keywords.Length; j++)
			{
				MaterialQuality materialQuality3 = MaterialQualityUtilities.FromIndex(j);
				Math.Abs(requestedLevel - materialQuality3);
				if ((materialQuality3 & availableLevels) != (MaterialQuality)0)
				{
					materialQuality = materialQuality3;
					break;
				}
			}
			return materialQuality;
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x00024260 File Offset: 0x00022460
		public static void SetGlobalShaderKeywords(this MaterialQuality level)
		{
			for (int i = 0; i < MaterialQualityUtilities.KeywordNames.Length; i++)
			{
				if ((level & (MaterialQuality)(1 << i)) != (MaterialQuality)0)
				{
					Shader.EnableKeyword(MaterialQualityUtilities.KeywordNames[i]);
				}
				else
				{
					Shader.DisableKeyword(MaterialQualityUtilities.KeywordNames[i]);
				}
			}
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x000242A4 File Offset: 0x000224A4
		public static void SetGlobalShaderKeywords(this MaterialQuality level, CommandBuffer cmd)
		{
			for (int i = 0; i < MaterialQualityUtilities.KeywordNames.Length; i++)
			{
				if ((level & (MaterialQuality)(1 << i)) != (MaterialQuality)0)
				{
					cmd.EnableShaderKeyword(MaterialQualityUtilities.KeywordNames[i]);
				}
				else
				{
					cmd.DisableShaderKeyword(MaterialQualityUtilities.KeywordNames[i]);
				}
			}
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x000242EC File Offset: 0x000224EC
		public static int ToFirstIndex(this MaterialQuality level)
		{
			for (int i = 0; i < MaterialQualityUtilities.KeywordNames.Length; i++)
			{
				if ((level & (MaterialQuality)(1 << i)) != (MaterialQuality)0)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x00024318 File Offset: 0x00022518
		public static MaterialQuality FromIndex(int index)
		{
			return (MaterialQuality)(1 << index);
		}

		// Token: 0x040004A9 RID: 1193
		public static string[] KeywordNames = new string[]
		{
			"MATERIAL_QUALITY_LOW",
			"MATERIAL_QUALITY_MEDIUM",
			"MATERIAL_QUALITY_HIGH"
		};

		// Token: 0x040004AA RID: 1194
		public static string[] EnumNames = Enum.GetNames(typeof(MaterialQuality));

		// Token: 0x040004AB RID: 1195
		public static ShaderKeyword[] Keywords = new ShaderKeyword[]
		{
			new ShaderKeyword(MaterialQualityUtilities.KeywordNames[0]),
			new ShaderKeyword(MaterialQualityUtilities.KeywordNames[1]),
			new ShaderKeyword(MaterialQualityUtilities.KeywordNames[2])
		};
	}
}
