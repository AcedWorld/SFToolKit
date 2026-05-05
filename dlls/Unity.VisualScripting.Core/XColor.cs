using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000168 RID: 360
	public static class XColor
	{
		// Token: 0x0600099F RID: 2463 RVA: 0x00029104 File Offset: 0x00027304
		public static string ToHexString(this Color color)
		{
			return ((byte)(color.r * 255f)).ToString("X2") + ((byte)(color.g * 255f)).ToString("X2") + ((byte)(color.b * 255f)).ToString("X2") + ((byte)(color.a * 255f)).ToString("X2");
		}
	}
}
