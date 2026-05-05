using System;
using UnityEngine;

namespace Cinemachine.Utility
{
	// Token: 0x0200006A RID: 106
	public static class UnityRectExtensions
	{
		// Token: 0x06000401 RID: 1025 RVA: 0x000187A8 File Offset: 0x000169A8
		public static Rect Inflated(this Rect r, Vector2 delta)
		{
			return new Rect(r.xMin - delta.x, r.yMin - delta.y, r.width + delta.x * 2f, r.height + delta.y * 2f);
		}
	}
}
