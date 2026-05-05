using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.UIElements
{
	// Token: 0x0200027B RID: 635
	[NativeHeader("ModuleOverrides/com.unity.ui/Core/Native/Renderer/UIPainter2D.bindings.h")]
	internal static class UIPainter2D
	{
		// Token: 0x060011EC RID: 4588
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr Create(bool computeBBox = false);

		// Token: 0x060011ED RID: 4589
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void Destroy(IntPtr handle);

		// Token: 0x060011EE RID: 4590
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void Reset(IntPtr handle);

		// Token: 0x060011EF RID: 4591
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern float GetLineWidth(IntPtr handle);

		// Token: 0x060011F0 RID: 4592
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetLineWidth(IntPtr handle, float value);

		// Token: 0x060011F1 RID: 4593 RVA: 0x00040E2C File Offset: 0x0003F02C
		public static Color GetStrokeColor(IntPtr handle)
		{
			Color result;
			UIPainter2D.GetStrokeColor_Injected(handle, out result);
			return result;
		}

		// Token: 0x060011F2 RID: 4594 RVA: 0x00040E42 File Offset: 0x0003F042
		public static void SetStrokeColor(IntPtr handle, Color value)
		{
			UIPainter2D.SetStrokeColor_Injected(handle, ref value);
		}

		// Token: 0x060011F3 RID: 4595
		[NativeName("GetStrokeGradientCopy")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern Gradient GetStrokeGradient(IntPtr handle);

		// Token: 0x060011F4 RID: 4596
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetStrokeGradient(IntPtr handle, Gradient gradient);

		// Token: 0x060011F5 RID: 4597 RVA: 0x00040E4C File Offset: 0x0003F04C
		public static Color GetFillColor(IntPtr handle)
		{
			Color result;
			UIPainter2D.GetFillColor_Injected(handle, out result);
			return result;
		}

		// Token: 0x060011F6 RID: 4598 RVA: 0x00040E62 File Offset: 0x0003F062
		public static void SetFillColor(IntPtr handle, Color value)
		{
			UIPainter2D.SetFillColor_Injected(handle, ref value);
		}

		// Token: 0x060011F7 RID: 4599
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern LineJoin GetLineJoin(IntPtr handle);

		// Token: 0x060011F8 RID: 4600
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetLineJoin(IntPtr handle, LineJoin value);

		// Token: 0x060011F9 RID: 4601
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern LineCap GetLineCap(IntPtr handle);

		// Token: 0x060011FA RID: 4602
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetLineCap(IntPtr handle, LineCap value);

		// Token: 0x060011FB RID: 4603
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern float GetMiterLimit(IntPtr handle);

		// Token: 0x060011FC RID: 4604
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetMiterLimit(IntPtr handle, float value);

		// Token: 0x060011FD RID: 4605
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void BeginPath(IntPtr handle);

		// Token: 0x060011FE RID: 4606 RVA: 0x00040E6C File Offset: 0x0003F06C
		public static void MoveTo(IntPtr handle, Vector2 pos)
		{
			UIPainter2D.MoveTo_Injected(handle, ref pos);
		}

		// Token: 0x060011FF RID: 4607 RVA: 0x00040E76 File Offset: 0x0003F076
		public static void LineTo(IntPtr handle, Vector2 pos)
		{
			UIPainter2D.LineTo_Injected(handle, ref pos);
		}

		// Token: 0x06001200 RID: 4608 RVA: 0x00040E80 File Offset: 0x0003F080
		public static void ArcTo(IntPtr handle, Vector2 p1, Vector2 p2, float radius)
		{
			UIPainter2D.ArcTo_Injected(handle, ref p1, ref p2, radius);
		}

		// Token: 0x06001201 RID: 4609 RVA: 0x00040E8D File Offset: 0x0003F08D
		public static void Arc(IntPtr handle, Vector2 center, float radius, float startAngleRads, float endAngleRads, ArcDirection direction)
		{
			UIPainter2D.Arc_Injected(handle, ref center, radius, startAngleRads, endAngleRads, direction);
		}

		// Token: 0x06001202 RID: 4610 RVA: 0x00040E9D File Offset: 0x0003F09D
		public static void BezierCurveTo(IntPtr handle, Vector2 p1, Vector2 p2, Vector2 p3)
		{
			UIPainter2D.BezierCurveTo_Injected(handle, ref p1, ref p2, ref p3);
		}

		// Token: 0x06001203 RID: 4611 RVA: 0x00040EAB File Offset: 0x0003F0AB
		public static void QuadraticCurveTo(IntPtr handle, Vector2 p1, Vector2 p2)
		{
			UIPainter2D.QuadraticCurveTo_Injected(handle, ref p1, ref p2);
		}

		// Token: 0x06001204 RID: 4612
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void ClosePath(IntPtr handle);

		// Token: 0x06001205 RID: 4613 RVA: 0x00040EB8 File Offset: 0x0003F0B8
		public static Rect GetBBox(IntPtr handle)
		{
			Rect result;
			UIPainter2D.GetBBox_Injected(handle, out result);
			return result;
		}

		// Token: 0x06001206 RID: 4614 RVA: 0x00040ED0 File Offset: 0x0003F0D0
		public static MeshWriteDataInterface Stroke(IntPtr handle)
		{
			MeshWriteDataInterface result;
			UIPainter2D.Stroke_Injected(handle, out result);
			return result;
		}

		// Token: 0x06001207 RID: 4615 RVA: 0x00040EE8 File Offset: 0x0003F0E8
		public static MeshWriteDataInterface Fill(IntPtr handle, FillRule fillRule)
		{
			MeshWriteDataInterface result;
			UIPainter2D.Fill_Injected(handle, fillRule, out result);
			return result;
		}

		// Token: 0x06001208 RID: 4616
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetStrokeColor_Injected(IntPtr handle, out Color ret);

		// Token: 0x06001209 RID: 4617
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetStrokeColor_Injected(IntPtr handle, ref Color value);

		// Token: 0x0600120A RID: 4618
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetFillColor_Injected(IntPtr handle, out Color ret);

		// Token: 0x0600120B RID: 4619
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetFillColor_Injected(IntPtr handle, ref Color value);

		// Token: 0x0600120C RID: 4620
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void MoveTo_Injected(IntPtr handle, ref Vector2 pos);

		// Token: 0x0600120D RID: 4621
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void LineTo_Injected(IntPtr handle, ref Vector2 pos);

		// Token: 0x0600120E RID: 4622
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ArcTo_Injected(IntPtr handle, ref Vector2 p1, ref Vector2 p2, float radius);

		// Token: 0x0600120F RID: 4623
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Arc_Injected(IntPtr handle, ref Vector2 center, float radius, float startAngleRads, float endAngleRads, ArcDirection direction);

		// Token: 0x06001210 RID: 4624
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void BezierCurveTo_Injected(IntPtr handle, ref Vector2 p1, ref Vector2 p2, ref Vector2 p3);

		// Token: 0x06001211 RID: 4625
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void QuadraticCurveTo_Injected(IntPtr handle, ref Vector2 p1, ref Vector2 p2);

		// Token: 0x06001212 RID: 4626
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetBBox_Injected(IntPtr handle, out Rect ret);

		// Token: 0x06001213 RID: 4627
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Stroke_Injected(IntPtr handle, out MeshWriteDataInterface ret);

		// Token: 0x06001214 RID: 4628
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Fill_Injected(IntPtr handle, FillRule fillRule, out MeshWriteDataInterface ret);
	}
}
