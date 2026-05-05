using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x02000012 RID: 18
	[NativeHeader("Modules/IMGUI/GUIState.h")]
	[NativeHeader("Modules/IMGUI/GUIClip.h")]
	internal sealed class GUIClip
	{
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000156 RID: 342
		internal static extern bool enabled { [FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.GetEnabled")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000157 RID: 343 RVA: 0x00007708 File Offset: 0x00005908
		internal static Rect visibleRect
		{
			[FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.GetVisibleRect")]
			get
			{
				Rect result;
				GUIClip.get_visibleRect_Injected(out result);
				return result;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000158 RID: 344 RVA: 0x00007720 File Offset: 0x00005920
		internal static Rect topmostRect
		{
			[FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.GetTopMostPhysicalRect")]
			get
			{
				Rect result;
				GUIClip.get_topmostRect_Injected(out result);
				return result;
			}
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00007735 File Offset: 0x00005935
		internal static void Internal_Push(Rect screenRect, Vector2 scrollOffset, Vector2 renderOffset, bool resetOffset)
		{
			GUIClip.Internal_Push_Injected(ref screenRect, ref scrollOffset, ref renderOffset, resetOffset);
		}

		// Token: 0x0600015A RID: 346
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_Pop();

		// Token: 0x0600015B RID: 347
		[FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.GetCount")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int Internal_GetCount();

		// Token: 0x0600015C RID: 348 RVA: 0x00007744 File Offset: 0x00005944
		[FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.GetTopRect")]
		internal static Rect GetTopRect()
		{
			Rect result;
			GUIClip.GetTopRect_Injected(out result);
			return result;
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0000775C File Offset: 0x0000595C
		[FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.Unclip")]
		private static Vector2 Unclip_Vector2(Vector2 pos)
		{
			Vector2 result;
			GUIClip.Unclip_Vector2_Injected(ref pos, out result);
			return result;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00007774 File Offset: 0x00005974
		[FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.Unclip")]
		private static Rect Unclip_Rect(Rect rect)
		{
			Rect result;
			GUIClip.Unclip_Rect_Injected(ref rect, out result);
			return result;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0000778C File Offset: 0x0000598C
		[FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.Clip")]
		private static Vector2 Clip_Vector2(Vector2 absolutePos)
		{
			Vector2 result;
			GUIClip.Clip_Vector2_Injected(ref absolutePos, out result);
			return result;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x000077A4 File Offset: 0x000059A4
		[FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.Clip")]
		private static Rect Internal_Clip_Rect(Rect absoluteRect)
		{
			Rect result;
			GUIClip.Internal_Clip_Rect_Injected(ref absoluteRect, out result);
			return result;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x000077BC File Offset: 0x000059BC
		[FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.UnclipToWindow")]
		private static Vector2 UnclipToWindow_Vector2(Vector2 pos)
		{
			Vector2 result;
			GUIClip.UnclipToWindow_Vector2_Injected(ref pos, out result);
			return result;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x000077D4 File Offset: 0x000059D4
		[FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.UnclipToWindow")]
		private static Rect UnclipToWindow_Rect(Rect rect)
		{
			Rect result;
			GUIClip.UnclipToWindow_Rect_Injected(ref rect, out result);
			return result;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x000077EC File Offset: 0x000059EC
		[FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.ClipToWindow")]
		private static Vector2 ClipToWindow_Vector2(Vector2 absolutePos)
		{
			Vector2 result;
			GUIClip.ClipToWindow_Vector2_Injected(ref absolutePos, out result);
			return result;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00007804 File Offset: 0x00005A04
		[FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.ClipToWindow")]
		private static Rect ClipToWindow_Rect(Rect absoluteRect)
		{
			Rect result;
			GUIClip.ClipToWindow_Rect_Injected(ref absoluteRect, out result);
			return result;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000781C File Offset: 0x00005A1C
		[FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.GetAbsoluteMousePosition")]
		private static Vector2 Internal_GetAbsoluteMousePosition()
		{
			Vector2 result;
			GUIClip.Internal_GetAbsoluteMousePosition_Injected(out result);
			return result;
		}

		// Token: 0x06000166 RID: 358
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Reapply();

		// Token: 0x06000167 RID: 359 RVA: 0x00007834 File Offset: 0x00005A34
		[FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.GetUserMatrix")]
		internal static Matrix4x4 GetMatrix()
		{
			Matrix4x4 result;
			GUIClip.GetMatrix_Injected(out result);
			return result;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00007849 File Offset: 0x00005A49
		internal static void SetMatrix(Matrix4x4 m)
		{
			GUIClip.SetMatrix_Injected(ref m);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00007854 File Offset: 0x00005A54
		[FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.GetParentTransform")]
		internal static Matrix4x4 GetParentMatrix()
		{
			Matrix4x4 result;
			GUIClip.GetParentMatrix_Injected(out result);
			return result;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00007869 File Offset: 0x00005A69
		internal static void Internal_PushParentClip(Matrix4x4 objectTransform, Rect clipRect)
		{
			GUIClip.Internal_PushParentClip(objectTransform, objectTransform, clipRect);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00007875 File Offset: 0x00005A75
		internal static void Internal_PushParentClip(Matrix4x4 renderTransform, Matrix4x4 inputTransform, Rect clipRect)
		{
			GUIClip.Internal_PushParentClip_Injected(ref renderTransform, ref inputTransform, ref clipRect);
		}

		// Token: 0x0600016C RID: 364
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_PopParentClip();

		// Token: 0x0600016D RID: 365 RVA: 0x00007882 File Offset: 0x00005A82
		internal static void Push(Rect screenRect, Vector2 scrollOffset, Vector2 renderOffset, bool resetOffset)
		{
			GUIClip.Internal_Push(screenRect, scrollOffset, renderOffset, resetOffset);
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0000788F File Offset: 0x00005A8F
		internal static void Pop()
		{
			GUIClip.Internal_Pop();
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00007898 File Offset: 0x00005A98
		public static Vector2 Unclip(Vector2 pos)
		{
			return GUIClip.Unclip_Vector2(pos);
		}

		// Token: 0x06000170 RID: 368 RVA: 0x000078B0 File Offset: 0x00005AB0
		public static Rect Unclip(Rect rect)
		{
			return GUIClip.Unclip_Rect(rect);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x000078C8 File Offset: 0x00005AC8
		public static Vector2 Clip(Vector2 absolutePos)
		{
			return GUIClip.Clip_Vector2(absolutePos);
		}

		// Token: 0x06000172 RID: 370 RVA: 0x000078E0 File Offset: 0x00005AE0
		public static Rect Clip(Rect absoluteRect)
		{
			return GUIClip.Internal_Clip_Rect(absoluteRect);
		}

		// Token: 0x06000173 RID: 371 RVA: 0x000078F8 File Offset: 0x00005AF8
		public static Vector2 UnclipToWindow(Vector2 pos)
		{
			return GUIClip.UnclipToWindow_Vector2(pos);
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00007910 File Offset: 0x00005B10
		public static Rect UnclipToWindow(Rect rect)
		{
			return GUIClip.UnclipToWindow_Rect(rect);
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00007928 File Offset: 0x00005B28
		public static Vector2 ClipToWindow(Vector2 absolutePos)
		{
			return GUIClip.ClipToWindow_Vector2(absolutePos);
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00007940 File Offset: 0x00005B40
		public static Rect ClipToWindow(Rect absoluteRect)
		{
			return GUIClip.ClipToWindow_Rect(absoluteRect);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00007958 File Offset: 0x00005B58
		public static Vector2 GetAbsoluteMousePosition()
		{
			return GUIClip.Internal_GetAbsoluteMousePosition();
		}

		// Token: 0x06000179 RID: 377
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_visibleRect_Injected(out Rect ret);

		// Token: 0x0600017A RID: 378
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_topmostRect_Injected(out Rect ret);

		// Token: 0x0600017B RID: 379
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Push_Injected(ref Rect screenRect, ref Vector2 scrollOffset, ref Vector2 renderOffset, bool resetOffset);

		// Token: 0x0600017C RID: 380
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetTopRect_Injected(out Rect ret);

		// Token: 0x0600017D RID: 381
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Unclip_Vector2_Injected(ref Vector2 pos, out Vector2 ret);

		// Token: 0x0600017E RID: 382
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Unclip_Rect_Injected(ref Rect rect, out Rect ret);

		// Token: 0x0600017F RID: 383
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Clip_Vector2_Injected(ref Vector2 absolutePos, out Vector2 ret);

		// Token: 0x06000180 RID: 384
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Clip_Rect_Injected(ref Rect absoluteRect, out Rect ret);

		// Token: 0x06000181 RID: 385
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void UnclipToWindow_Vector2_Injected(ref Vector2 pos, out Vector2 ret);

		// Token: 0x06000182 RID: 386
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void UnclipToWindow_Rect_Injected(ref Rect rect, out Rect ret);

		// Token: 0x06000183 RID: 387
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ClipToWindow_Vector2_Injected(ref Vector2 absolutePos, out Vector2 ret);

		// Token: 0x06000184 RID: 388
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ClipToWindow_Rect_Injected(ref Rect absoluteRect, out Rect ret);

		// Token: 0x06000185 RID: 389
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_GetAbsoluteMousePosition_Injected(out Vector2 ret);

		// Token: 0x06000186 RID: 390
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetMatrix_Injected(out Matrix4x4 ret);

		// Token: 0x06000187 RID: 391
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetMatrix_Injected(ref Matrix4x4 m);

		// Token: 0x06000188 RID: 392
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetParentMatrix_Injected(out Matrix4x4 ret);

		// Token: 0x06000189 RID: 393
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_PushParentClip_Injected(ref Matrix4x4 renderTransform, ref Matrix4x4 inputTransform, ref Rect clipRect);

		// Token: 0x02000013 RID: 19
		internal struct ParentClipScope : IDisposable
		{
			// Token: 0x0600018A RID: 394 RVA: 0x0000796F File Offset: 0x00005B6F
			public ParentClipScope(Matrix4x4 objectTransform, Rect clipRect)
			{
				this.m_Disposed = false;
				GUIClip.Internal_PushParentClip(objectTransform, clipRect);
			}

			// Token: 0x0600018B RID: 395 RVA: 0x00007984 File Offset: 0x00005B84
			public void Dispose()
			{
				bool disposed = this.m_Disposed;
				if (!disposed)
				{
					this.m_Disposed = true;
					GUIClip.Internal_PopParentClip();
				}
			}

			// Token: 0x0400006C RID: 108
			private bool m_Disposed;
		}
	}
}
