using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000214 RID: 532
	public static class PointerType
	{
		// Token: 0x06000F6F RID: 3951 RVA: 0x000394D4 File Offset: 0x000376D4
		internal static string GetPointerType(int pointerId)
		{
			bool flag = pointerId == PointerId.mousePointerId;
			string result;
			if (flag)
			{
				result = PointerType.mouse;
			}
			else
			{
				bool flag2 = pointerId == PointerId.penPointerIdBase;
				if (flag2)
				{
					result = PointerType.pen;
				}
				else
				{
					result = PointerType.touch;
				}
			}
			return result;
		}

		// Token: 0x06000F70 RID: 3952 RVA: 0x00039514 File Offset: 0x00037714
		internal static bool IsDirectManipulationDevice(string pointerType)
		{
			return pointerType == PointerType.touch || pointerType == PointerType.pen;
		}

		// Token: 0x040006F2 RID: 1778
		public static readonly string mouse = "mouse";

		// Token: 0x040006F3 RID: 1779
		public static readonly string touch = "touch";

		// Token: 0x040006F4 RID: 1780
		public static readonly string pen = "pen";

		// Token: 0x040006F5 RID: 1781
		public static readonly string unknown = "";
	}
}
