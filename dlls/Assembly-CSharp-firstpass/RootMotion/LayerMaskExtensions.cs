using System;
using System.Collections.Generic;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x02000028 RID: 40
	public static class LayerMaskExtensions
	{
		// Token: 0x060000E8 RID: 232 RVA: 0x000071D4 File Offset: 0x000053D4
		public static bool Contains(LayerMask mask, int layer)
		{
			return mask == (mask | 1 << layer);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000071EB File Offset: 0x000053EB
		public static LayerMask Create(params string[] layerNames)
		{
			return LayerMaskExtensions.NamesToMask(layerNames);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000071F3 File Offset: 0x000053F3
		public static LayerMask Create(params int[] layerNumbers)
		{
			return LayerMaskExtensions.LayerNumbersToMask(layerNumbers);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000071FC File Offset: 0x000053FC
		public static LayerMask NamesToMask(params string[] layerNames)
		{
			LayerMask layerMask = 0;
			foreach (string layerName in layerNames)
			{
				layerMask |= 1 << LayerMask.NameToLayer(layerName);
			}
			return layerMask;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00007240 File Offset: 0x00005440
		public static LayerMask LayerNumbersToMask(params int[] layerNumbers)
		{
			LayerMask layerMask = 0;
			foreach (int num in layerNumbers)
			{
				layerMask |= 1 << num;
			}
			return layerMask;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000727C File Offset: 0x0000547C
		public static LayerMask Inverse(this LayerMask original)
		{
			return ~original;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000728A File Offset: 0x0000548A
		public static LayerMask AddToMask(this LayerMask original, params string[] layerNames)
		{
			return original | LayerMaskExtensions.NamesToMask(layerNames);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000072A3 File Offset: 0x000054A3
		public static LayerMask RemoveFromMask(this LayerMask original, params string[] layerNames)
		{
			return ~(~original | LayerMaskExtensions.NamesToMask(layerNames));
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000072C8 File Offset: 0x000054C8
		public static string[] MaskToNames(this LayerMask original)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < 32; i++)
			{
				int num = 1 << i;
				if ((original & num) == num)
				{
					string text = LayerMask.LayerToName(i);
					if (!string.IsNullOrEmpty(text))
					{
						list.Add(text);
					}
				}
			}
			return list.ToArray();
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00007318 File Offset: 0x00005518
		public static int[] MaskToNumbers(this LayerMask original)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < 32; i++)
			{
				int num = 1 << i;
				if ((original & num) == num)
				{
					list.Add(i);
				}
			}
			return list.ToArray();
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00007357 File Offset: 0x00005557
		public static string MaskToString(this LayerMask original)
		{
			return original.MaskToString(", ");
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00007364 File Offset: 0x00005564
		public static string MaskToString(this LayerMask original, string delimiter)
		{
			return string.Join(delimiter, original.MaskToNames());
		}
	}
}
