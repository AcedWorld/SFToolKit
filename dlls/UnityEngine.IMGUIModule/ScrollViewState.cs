using System;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000039 RID: 57
	internal class ScrollViewState
	{
		// Token: 0x0600041F RID: 1055 RVA: 0x0000F423 File Offset: 0x0000D623
		[RequiredByNativeCode]
		public ScrollViewState()
		{
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x0000F42D File Offset: 0x0000D62D
		public void ScrollTo(Rect pos)
		{
			this.ScrollTowards(pos, float.PositiveInfinity);
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0000F440 File Offset: 0x0000D640
		public bool ScrollTowards(Rect pos, float maxDelta)
		{
			Vector2 b = this.ScrollNeeded(pos);
			bool flag = b.sqrMagnitude < 0.0001f;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = maxDelta == 0f;
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool flag3 = b.magnitude > maxDelta;
					if (flag3)
					{
						b = b.normalized * maxDelta;
					}
					this.scrollPosition += b;
					this.apply = true;
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x0000F4B8 File Offset: 0x0000D6B8
		private Vector2 ScrollNeeded(Rect pos)
		{
			Rect rect = this.visibleRect;
			rect.x += this.scrollPosition.x;
			rect.y += this.scrollPosition.y;
			float num = pos.width - this.visibleRect.width;
			bool flag = num > 0f;
			if (flag)
			{
				pos.width -= num;
				pos.x += num * 0.5f;
			}
			num = pos.height - this.visibleRect.height;
			bool flag2 = num > 0f;
			if (flag2)
			{
				pos.height -= num;
				pos.y += num * 0.5f;
			}
			Vector2 zero = Vector2.zero;
			bool flag3 = pos.xMax > rect.xMax;
			if (flag3)
			{
				zero.x += pos.xMax - rect.xMax;
			}
			else
			{
				bool flag4 = pos.xMin < rect.xMin;
				if (flag4)
				{
					zero.x -= rect.xMin - pos.xMin;
				}
			}
			bool flag5 = pos.yMax > rect.yMax;
			if (flag5)
			{
				zero.y += pos.yMax - rect.yMax;
			}
			else
			{
				bool flag6 = pos.yMin < rect.yMin;
				if (flag6)
				{
					zero.y -= rect.yMin - pos.yMin;
				}
			}
			Rect rect2 = this.viewRect;
			rect2.width = Mathf.Max(rect2.width, this.visibleRect.width);
			rect2.height = Mathf.Max(rect2.height, this.visibleRect.height);
			zero.x = Mathf.Clamp(zero.x, rect2.xMin - this.scrollPosition.x, rect2.xMax - this.visibleRect.width - this.scrollPosition.x);
			zero.y = Mathf.Clamp(zero.y, rect2.yMin - this.scrollPosition.y, rect2.yMax - this.visibleRect.height - this.scrollPosition.y);
			return zero;
		}

		// Token: 0x04000129 RID: 297
		public Rect position;

		// Token: 0x0400012A RID: 298
		public Rect visibleRect;

		// Token: 0x0400012B RID: 299
		public Rect viewRect;

		// Token: 0x0400012C RID: 300
		public Vector2 scrollPosition;

		// Token: 0x0400012D RID: 301
		public bool apply;

		// Token: 0x0400012E RID: 302
		public bool isDuringTouchScroll;

		// Token: 0x0400012F RID: 303
		public Vector2 touchScrollStartMousePosition;

		// Token: 0x04000130 RID: 304
		public Vector2 touchScrollStartPosition;

		// Token: 0x04000131 RID: 305
		public Vector2 velocity;

		// Token: 0x04000132 RID: 306
		public float previousTimeSinceStartup;
	}
}
