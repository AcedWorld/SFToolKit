using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003F7 RID: 1015
	public static class VisualElementExtensions
	{
		// Token: 0x060020CA RID: 8394 RVA: 0x0007BF90 File Offset: 0x0007A190
		public static void StretchToParentSize(this VisualElement elem)
		{
			bool flag = elem == null;
			if (flag)
			{
				throw new ArgumentNullException("elem");
			}
			IStyle style = elem.style;
			style.position = Position.Absolute;
			style.left = 0f;
			style.top = 0f;
			style.right = 0f;
			style.bottom = 0f;
		}

		// Token: 0x060020CB RID: 8395 RVA: 0x0007C00C File Offset: 0x0007A20C
		public static void StretchToParentWidth(this VisualElement elem)
		{
			bool flag = elem == null;
			if (flag)
			{
				throw new ArgumentNullException("elem");
			}
			IStyle style = elem.style;
			style.position = Position.Absolute;
			style.left = 0f;
			style.right = 0f;
		}

		// Token: 0x060020CC RID: 8396 RVA: 0x0007C064 File Offset: 0x0007A264
		public static void AddManipulator(this VisualElement ele, IManipulator manipulator)
		{
			bool flag = manipulator != null;
			if (flag)
			{
				manipulator.target = ele;
			}
		}

		// Token: 0x060020CD RID: 8397 RVA: 0x0007C084 File Offset: 0x0007A284
		public static void RemoveManipulator(this VisualElement ele, IManipulator manipulator)
		{
			bool flag = manipulator != null;
			if (flag)
			{
				manipulator.target = null;
			}
		}

		// Token: 0x060020CE RID: 8398 RVA: 0x0007C0A4 File Offset: 0x0007A2A4
		public static Vector2 WorldToLocal(this VisualElement ele, Vector2 p)
		{
			bool flag = ele == null;
			if (flag)
			{
				throw new ArgumentNullException("ele");
			}
			return VisualElement.MultiplyMatrix44Point2(ele.worldTransformInverse, p);
		}

		// Token: 0x060020CF RID: 8399 RVA: 0x0007C0D8 File Offset: 0x0007A2D8
		public static Vector2 LocalToWorld(this VisualElement ele, Vector2 p)
		{
			bool flag = ele == null;
			if (flag)
			{
				throw new ArgumentNullException("ele");
			}
			return VisualElement.MultiplyMatrix44Point2(ele.worldTransformRef, p);
		}

		// Token: 0x060020D0 RID: 8400 RVA: 0x0007C10C File Offset: 0x0007A30C
		public static Rect WorldToLocal(this VisualElement ele, Rect r)
		{
			bool flag = ele == null;
			if (flag)
			{
				throw new ArgumentNullException("ele");
			}
			return VisualElement.CalculateConservativeRect(ele.worldTransformInverse, r);
		}

		// Token: 0x060020D1 RID: 8401 RVA: 0x0007C140 File Offset: 0x0007A340
		public static Rect LocalToWorld(this VisualElement ele, Rect r)
		{
			bool flag = ele == null;
			if (flag)
			{
				throw new ArgumentNullException("ele");
			}
			return VisualElement.CalculateConservativeRect(ele.worldTransformRef, r);
		}

		// Token: 0x060020D2 RID: 8402 RVA: 0x0007C174 File Offset: 0x0007A374
		public static Vector2 ChangeCoordinatesTo(this VisualElement src, VisualElement dest, Vector2 point)
		{
			return dest.WorldToLocal(src.LocalToWorld(point));
		}

		// Token: 0x060020D3 RID: 8403 RVA: 0x0007C194 File Offset: 0x0007A394
		public static Rect ChangeCoordinatesTo(this VisualElement src, VisualElement dest, Rect rect)
		{
			return dest.WorldToLocal(src.LocalToWorld(rect));
		}
	}
}
