using System;
using UnityEngine;

namespace Kamgam.UGUIBlurredBackground
{
	// Token: 0x02000018 RID: 24
	public static class SquareResolutionsUtils
	{
		// Token: 0x060000D6 RID: 214 RVA: 0x00004DD4 File Offset: 0x00002FD4
		public static Vector2Int ToResolution(this SquareResolution res)
		{
			switch (res)
			{
			case SquareResolution._32:
				return new Vector2Int(32, 32);
			case SquareResolution._64:
				return new Vector2Int(64, 64);
			case SquareResolution._128:
				return new Vector2Int(128, 128);
			case SquareResolution._256:
				return new Vector2Int(256, 256);
			case SquareResolution._512:
				return new Vector2Int(512, 512);
			case SquareResolution._1024:
				return new Vector2Int(1024, 1024);
			case SquareResolution._2048:
				return new Vector2Int(2048, 2048);
			default:
				return new Vector2Int(512, 512);
			}
		}
	}
}
