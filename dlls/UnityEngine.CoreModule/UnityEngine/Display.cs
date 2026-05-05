using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x0200013E RID: 318
	[UsedByNativeCode]
	[NativeHeader("Runtime/Graphics/DisplayManager.h")]
	public class Display
	{
		// Token: 0x060008DC RID: 2268 RVA: 0x0000E487 File Offset: 0x0000C687
		internal Display()
		{
			this.nativeDisplay = new IntPtr(0);
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x0000E49D File Offset: 0x0000C69D
		internal Display(IntPtr nativeDisplay)
		{
			this.nativeDisplay = nativeDisplay;
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x060008DE RID: 2270 RVA: 0x0000E4B0 File Offset: 0x0000C6B0
		public int renderingWidth
		{
			get
			{
				int result = 0;
				int num = 0;
				Display.GetRenderingExtImpl(this.nativeDisplay, out result, out num);
				return result;
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x060008DF RID: 2271 RVA: 0x0000E4D8 File Offset: 0x0000C6D8
		public int renderingHeight
		{
			get
			{
				int num = 0;
				int result = 0;
				Display.GetRenderingExtImpl(this.nativeDisplay, out num, out result);
				return result;
			}
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x060008E0 RID: 2272 RVA: 0x0000E500 File Offset: 0x0000C700
		public int systemWidth
		{
			get
			{
				int result = 0;
				int num = 0;
				Display.GetSystemExtImpl(this.nativeDisplay, out result, out num);
				return result;
			}
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x060008E1 RID: 2273 RVA: 0x0000E528 File Offset: 0x0000C728
		public int systemHeight
		{
			get
			{
				int num = 0;
				int result = 0;
				Display.GetSystemExtImpl(this.nativeDisplay, out num, out result);
				return result;
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x060008E2 RID: 2274 RVA: 0x0000E550 File Offset: 0x0000C750
		public RenderBuffer colorBuffer
		{
			get
			{
				RenderBuffer result;
				RenderBuffer renderBuffer;
				Display.GetRenderingBuffersImpl(this.nativeDisplay, out result, out renderBuffer);
				return result;
			}
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x060008E3 RID: 2275 RVA: 0x0000E574 File Offset: 0x0000C774
		public RenderBuffer depthBuffer
		{
			get
			{
				RenderBuffer renderBuffer;
				RenderBuffer result;
				Display.GetRenderingBuffersImpl(this.nativeDisplay, out renderBuffer, out result);
				return result;
			}
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x060008E4 RID: 2276 RVA: 0x0000E598 File Offset: 0x0000C798
		public bool active
		{
			get
			{
				return Display.GetActiveImpl(this.nativeDisplay);
			}
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x060008E5 RID: 2277 RVA: 0x0000E5B8 File Offset: 0x0000C7B8
		public bool requiresBlitToBackbuffer
		{
			get
			{
				int num = this.nativeDisplay.ToInt32();
				bool flag = num < HDROutputSettings.displays.Length;
				if (flag)
				{
					bool flag2 = HDROutputSettings.displays[num].available && HDROutputSettings.displays[num].active;
					bool flag3 = flag2;
					if (flag3)
					{
						return true;
					}
				}
				return Display.RequiresBlitToBackbufferImpl(this.nativeDisplay);
			}
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x060008E6 RID: 2278 RVA: 0x0000E61C File Offset: 0x0000C81C
		public bool requiresSrgbBlitToBackbuffer
		{
			get
			{
				return Display.RequiresSrgbBlitToBackbufferImpl(this.nativeDisplay);
			}
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x0000E63C File Offset: 0x0000C83C
		public void Activate()
		{
			Display.ActivateDisplayImpl(this.nativeDisplay, 0, 0, new RefreshRate
			{
				numerator = 60U,
				denominator = 1U
			});
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x0000E672 File Offset: 0x0000C872
		public void Activate(int width, int height, RefreshRate refreshRate)
		{
			Display.ActivateDisplayImpl(this.nativeDisplay, width, height, refreshRate);
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x0000E684 File Offset: 0x0000C884
		[Obsolete("Activate(int, int, int) is deprecated. Use Activate(int, int, RefreshRate) instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Activate(int width, int height, int refreshRate)
		{
			bool flag = refreshRate < 0;
			if (flag)
			{
				refreshRate = 0;
			}
			Display.ActivateDisplayImpl(this.nativeDisplay, width, height, new RefreshRate
			{
				numerator = (uint)refreshRate,
				denominator = 1U
			});
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x0000E6C4 File Offset: 0x0000C8C4
		public void SetParams(int width, int height, int x, int y)
		{
			Display.SetParamsImpl(this.nativeDisplay, width, height, x, y);
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x0000E6D8 File Offset: 0x0000C8D8
		public void SetRenderingResolution(int w, int h)
		{
			Display.SetRenderingResolutionImpl(this.nativeDisplay, w, h);
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x0000E6EC File Offset: 0x0000C8EC
		[Obsolete("MultiDisplayLicense has been deprecated.", false)]
		public static bool MultiDisplayLicense()
		{
			return true;
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x0000E700 File Offset: 0x0000C900
		public static Vector3 RelativeMouseAt(Vector3 inputMouseCoordinates)
		{
			int num = 0;
			int num2 = 0;
			int x = (int)inputMouseCoordinates.x;
			int y = (int)inputMouseCoordinates.y;
			Vector3 result;
			result.z = (float)Display.RelativeMouseAtImpl(x, y, out num, out num2);
			result.x = (float)num;
			result.y = (float)num2;
			return result;
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x060008EE RID: 2286 RVA: 0x0000E750 File Offset: 0x0000C950
		public static Display main
		{
			get
			{
				return Display._mainDisplay;
			}
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x060008EF RID: 2287 RVA: 0x0000E768 File Offset: 0x0000C968
		// (set) Token: 0x060008F0 RID: 2288 RVA: 0x0000E77F File Offset: 0x0000C97F
		public static int activeEditorGameViewTarget
		{
			get
			{
				return Display.m_ActiveEditorGameViewTarget;
			}
			internal set
			{
				Display.m_ActiveEditorGameViewTarget = value;
			}
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x0000E788 File Offset: 0x0000C988
		[RequiredByNativeCode]
		internal static void RecreateDisplayList(IntPtr[] nativeDisplay)
		{
			bool flag = nativeDisplay.Length == 0;
			if (!flag)
			{
				Display.displays = new Display[nativeDisplay.Length];
				for (int i = 0; i < nativeDisplay.Length; i++)
				{
					Display.displays[i] = new Display(nativeDisplay[i]);
				}
				Display._mainDisplay = Display.displays[0];
			}
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x0000E7DC File Offset: 0x0000C9DC
		[RequiredByNativeCode]
		internal static void FireDisplaysUpdated()
		{
			bool flag = Display.onDisplaysUpdated != null;
			if (flag)
			{
				Display.onDisplaysUpdated();
			}
		}

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x060008F3 RID: 2291 RVA: 0x0000E804 File Offset: 0x0000CA04
		// (remove) Token: 0x060008F4 RID: 2292 RVA: 0x0000E838 File Offset: 0x0000CA38
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Display.DisplaysUpdatedDelegate onDisplaysUpdated;

		// Token: 0x060008F5 RID: 2293
		[FreeFunction("UnityDisplayManager_DisplaySystemResolution")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSystemExtImpl(IntPtr nativeDisplay, out int w, out int h);

		// Token: 0x060008F6 RID: 2294
		[FreeFunction("UnityDisplayManager_DisplayRenderingResolution")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetRenderingExtImpl(IntPtr nativeDisplay, out int w, out int h);

		// Token: 0x060008F7 RID: 2295
		[FreeFunction("UnityDisplayManager_GetRenderingBuffersWrapper")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetRenderingBuffersImpl(IntPtr nativeDisplay, out RenderBuffer color, out RenderBuffer depth);

		// Token: 0x060008F8 RID: 2296
		[FreeFunction("UnityDisplayManager_SetRenderingResolution")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetRenderingResolutionImpl(IntPtr nativeDisplay, int w, int h);

		// Token: 0x060008F9 RID: 2297 RVA: 0x0000E86B File Offset: 0x0000CA6B
		[FreeFunction("UnityDisplayManager_ActivateDisplay")]
		private static void ActivateDisplayImpl(IntPtr nativeDisplay, int width, int height, RefreshRate refreshRate)
		{
			Display.ActivateDisplayImpl_Injected(nativeDisplay, width, height, ref refreshRate);
		}

		// Token: 0x060008FA RID: 2298
		[FreeFunction("UnityDisplayManager_SetDisplayParam")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetParamsImpl(IntPtr nativeDisplay, int width, int height, int x, int y);

		// Token: 0x060008FB RID: 2299
		[FreeFunction("UnityDisplayManager_RelativeMouseAt")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int RelativeMouseAtImpl(int x, int y, out int rx, out int ry);

		// Token: 0x060008FC RID: 2300
		[FreeFunction("UnityDisplayManager_DisplayActive")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetActiveImpl(IntPtr nativeDisplay);

		// Token: 0x060008FD RID: 2301
		[FreeFunction("UnityDisplayManager_RequiresBlitToBackbuffer")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool RequiresBlitToBackbufferImpl(IntPtr nativeDisplay);

		// Token: 0x060008FE RID: 2302
		[FreeFunction("UnityDisplayManager_RequiresSRGBBlitToBackbuffer")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool RequiresSrgbBlitToBackbufferImpl(IntPtr nativeDisplay);

		// Token: 0x060008FF RID: 2303 RVA: 0x0000E877 File Offset: 0x0000CA77
		// Note: this type is marked as 'beforefieldinit'.
		static Display()
		{
			Display.onDisplaysUpdated = null;
		}

		// Token: 0x06000900 RID: 2304
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ActivateDisplayImpl_Injected(IntPtr nativeDisplay, int width, int height, ref RefreshRate refreshRate);

		// Token: 0x04000402 RID: 1026
		internal IntPtr nativeDisplay;

		// Token: 0x04000403 RID: 1027
		public static Display[] displays = new Display[]
		{
			new Display()
		};

		// Token: 0x04000404 RID: 1028
		private static Display _mainDisplay = Display.displays[0];

		// Token: 0x04000405 RID: 1029
		private static int m_ActiveEditorGameViewTarget = -1;

		// Token: 0x0200013F RID: 319
		// (Invoke) Token: 0x06000902 RID: 2306
		public delegate void DisplaysUpdatedDelegate();
	}
}
