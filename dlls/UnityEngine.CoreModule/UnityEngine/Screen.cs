using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine
{
	// Token: 0x02000148 RID: 328
	[StaticAccessor("GetScreenManager()", StaticAccessorType.Dot)]
	[NativeHeader("Runtime/Graphics/ScreenManager.h")]
	[NativeHeader("Runtime/Graphics/WindowLayout.h")]
	[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
	public sealed class Screen
	{
		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000918 RID: 2328
		public static extern int width { [NativeMethod(Name = "GetWidth", IsThreadSafe = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000919 RID: 2329
		public static extern int height { [NativeMethod(Name = "GetHeight", IsThreadSafe = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x0600091A RID: 2330
		public static extern float dpi { [NativeName("GetDPI")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x0600091B RID: 2331
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RequestOrientation(ScreenOrientation orient);

		// Token: 0x0600091C RID: 2332
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ScreenOrientation GetScreenOrientation();

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x0600091D RID: 2333 RVA: 0x0000ECA8 File Offset: 0x0000CEA8
		// (set) Token: 0x0600091E RID: 2334 RVA: 0x0000ECC0 File Offset: 0x0000CEC0
		public static ScreenOrientation orientation
		{
			get
			{
				return Screen.GetScreenOrientation();
			}
			set
			{
				bool flag = value == ScreenOrientation.Unknown;
				if (flag)
				{
					Debug.Log("ScreenOrientation.Unknown is deprecated. Please use ScreenOrientation.AutoRotation");
					value = ScreenOrientation.AutoRotation;
				}
				Screen.RequestOrientation(value);
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x0600091F RID: 2335
		// (set) Token: 0x06000920 RID: 2336
		[NativeProperty("ScreenTimeout")]
		public static extern int sleepTimeout { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06000921 RID: 2337
		[NativeName("GetIsOrientationEnabled")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsOrientationEnabled(EnabledOrientation orient);

		// Token: 0x06000922 RID: 2338
		[NativeName("SetIsOrientationEnabled")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetOrientationEnabled(EnabledOrientation orient, bool enabled);

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000923 RID: 2339 RVA: 0x0000ECF0 File Offset: 0x0000CEF0
		// (set) Token: 0x06000924 RID: 2340 RVA: 0x0000ED08 File Offset: 0x0000CF08
		public static bool autorotateToPortrait
		{
			get
			{
				return Screen.IsOrientationEnabled(EnabledOrientation.kAutorotateToPortrait);
			}
			set
			{
				Screen.SetOrientationEnabled(EnabledOrientation.kAutorotateToPortrait, value);
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000925 RID: 2341 RVA: 0x0000ED14 File Offset: 0x0000CF14
		// (set) Token: 0x06000926 RID: 2342 RVA: 0x0000ED2C File Offset: 0x0000CF2C
		public static bool autorotateToPortraitUpsideDown
		{
			get
			{
				return Screen.IsOrientationEnabled(EnabledOrientation.kAutorotateToPortraitUpsideDown);
			}
			set
			{
				Screen.SetOrientationEnabled(EnabledOrientation.kAutorotateToPortraitUpsideDown, value);
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000927 RID: 2343 RVA: 0x0000ED38 File Offset: 0x0000CF38
		// (set) Token: 0x06000928 RID: 2344 RVA: 0x0000ED50 File Offset: 0x0000CF50
		public static bool autorotateToLandscapeLeft
		{
			get
			{
				return Screen.IsOrientationEnabled(EnabledOrientation.kAutorotateToLandscapeLeft);
			}
			set
			{
				Screen.SetOrientationEnabled(EnabledOrientation.kAutorotateToLandscapeLeft, value);
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000929 RID: 2345 RVA: 0x0000ED5C File Offset: 0x0000CF5C
		// (set) Token: 0x0600092A RID: 2346 RVA: 0x0000ED74 File Offset: 0x0000CF74
		public static bool autorotateToLandscapeRight
		{
			get
			{
				return Screen.IsOrientationEnabled(EnabledOrientation.kAutorotateToLandscapeRight);
			}
			set
			{
				Screen.SetOrientationEnabled(EnabledOrientation.kAutorotateToLandscapeRight, value);
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x0600092B RID: 2347 RVA: 0x0000ED80 File Offset: 0x0000CF80
		public static Resolution currentResolution
		{
			get
			{
				Resolution result;
				Screen.get_currentResolution_Injected(out result);
				return result;
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x0600092C RID: 2348
		// (set) Token: 0x0600092D RID: 2349
		public static extern bool fullScreen { [NativeName("IsFullscreen")] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeName("RequestSetFullscreenFromScript")] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x0600092E RID: 2350
		// (set) Token: 0x0600092F RID: 2351
		public static extern FullScreenMode fullScreenMode { [NativeName("GetFullscreenMode")] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeName("RequestSetFullscreenModeFromScript")] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000930 RID: 2352 RVA: 0x0000ED98 File Offset: 0x0000CF98
		public static Rect safeArea
		{
			get
			{
				Rect result;
				Screen.get_safeArea_Injected(out result);
				return result;
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000931 RID: 2353
		public static extern Rect[] cutouts { [FreeFunction("ScreenScripting::GetCutouts")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000932 RID: 2354 RVA: 0x0000EDAD File Offset: 0x0000CFAD
		[NativeName("RequestResolution")]
		public static void SetResolution(int width, int height, FullScreenMode fullscreenMode, RefreshRate preferredRefreshRate)
		{
			Screen.SetResolution_Injected(width, height, fullscreenMode, ref preferredRefreshRate);
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x0000EDBC File Offset: 0x0000CFBC
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("SetResolution(int, int, FullScreenMode, int) is obsolete. Use SetResolution(int, int, FullScreenMode, RefreshRate) instead.")]
		public static void SetResolution(int width, int height, FullScreenMode fullscreenMode, [DefaultValue("0")] int preferredRefreshRate)
		{
			bool flag = preferredRefreshRate < 0;
			if (flag)
			{
				preferredRefreshRate = 0;
			}
			Screen.SetResolution(width, height, fullscreenMode, new RefreshRate
			{
				numerator = (uint)preferredRefreshRate,
				denominator = 1U
			});
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x0000EDF8 File Offset: 0x0000CFF8
		public static void SetResolution(int width, int height, FullScreenMode fullscreenMode)
		{
			Screen.SetResolution(width, height, fullscreenMode, new RefreshRate
			{
				numerator = 0U,
				denominator = 1U
			});
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x0000EE28 File Offset: 0x0000D028
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("SetResolution(int, int, bool, int) is obsolete. Use SetResolution(int, int, FullScreenMode, RefreshRate) instead.")]
		public static void SetResolution(int width, int height, bool fullscreen, [DefaultValue("0")] int preferredRefreshRate)
		{
			bool flag = preferredRefreshRate < 0;
			if (flag)
			{
				preferredRefreshRate = 0;
			}
			Screen.SetResolution(width, height, fullscreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed, new RefreshRate
			{
				numerator = (uint)preferredRefreshRate,
				denominator = 1U
			});
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x0000EE69 File Offset: 0x0000D069
		public static void SetResolution(int width, int height, bool fullscreen)
		{
			Screen.SetResolution(width, height, fullscreen, 0);
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000937 RID: 2359 RVA: 0x0000EE78 File Offset: 0x0000D078
		public static Vector2Int mainWindowPosition
		{
			get
			{
				return Screen.GetMainWindowPosition();
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000938 RID: 2360 RVA: 0x0000EE90 File Offset: 0x0000D090
		public static DisplayInfo mainWindowDisplayInfo
		{
			get
			{
				return Screen.GetMainWindowDisplayInfo();
			}
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x0000EEA8 File Offset: 0x0000D0A8
		public static void GetDisplayLayout(List<DisplayInfo> displayLayout)
		{
			bool flag = displayLayout == null;
			if (flag)
			{
				throw new ArgumentNullException();
			}
			Screen.GetDisplayLayoutImpl(displayLayout);
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x0000EECC File Offset: 0x0000D0CC
		public static AsyncOperation MoveMainWindowTo(in DisplayInfo display, Vector2Int position)
		{
			return Screen.MoveMainWindowImpl(display, position);
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x0000EEE8 File Offset: 0x0000D0E8
		[FreeFunction("GetMainWindowPosition")]
		private static Vector2Int GetMainWindowPosition()
		{
			Vector2Int result;
			Screen.GetMainWindowPosition_Injected(out result);
			return result;
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x0000EF00 File Offset: 0x0000D100
		[FreeFunction("GetMainWindowDisplayInfo")]
		private static DisplayInfo GetMainWindowDisplayInfo()
		{
			DisplayInfo result;
			Screen.GetMainWindowDisplayInfo_Injected(out result);
			return result;
		}

		// Token: 0x0600093D RID: 2365
		[FreeFunction("GetDisplayLayout")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetDisplayLayoutImpl(List<DisplayInfo> displayLayout);

		// Token: 0x0600093E RID: 2366 RVA: 0x0000EF15 File Offset: 0x0000D115
		[FreeFunction("MoveMainWindow")]
		private static AsyncOperation MoveMainWindowImpl(in DisplayInfo display, Vector2Int position)
		{
			return Screen.MoveMainWindowImpl_Injected(display, ref position);
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x0600093F RID: 2367
		public static extern Resolution[] resolutions { [FreeFunction("ScreenScripting::GetResolutions")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000940 RID: 2368
		// (set) Token: 0x06000941 RID: 2369
		public static extern float brightness { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000942 RID: 2370 RVA: 0x0000EF20 File Offset: 0x0000D120
		// (set) Token: 0x06000943 RID: 2371 RVA: 0x0000EF3C File Offset: 0x0000D13C
		[Obsolete("Use Cursor.lockState and Cursor.visible instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static bool lockCursor
		{
			get
			{
				return CursorLockMode.Locked == Cursor.lockState;
			}
			set
			{
				if (value)
				{
					Cursor.visible = false;
					Cursor.lockState = CursorLockMode.Locked;
				}
				else
				{
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
				}
			}
		}

		// Token: 0x06000945 RID: 2373
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_currentResolution_Injected(out Resolution ret);

		// Token: 0x06000946 RID: 2374
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_safeArea_Injected(out Rect ret);

		// Token: 0x06000947 RID: 2375
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetResolution_Injected(int width, int height, FullScreenMode fullscreenMode, ref RefreshRate preferredRefreshRate);

		// Token: 0x06000948 RID: 2376
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetMainWindowPosition_Injected(out Vector2Int ret);

		// Token: 0x06000949 RID: 2377
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetMainWindowDisplayInfo_Injected(out DisplayInfo ret);

		// Token: 0x0600094A RID: 2378
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AsyncOperation MoveMainWindowImpl_Injected(in DisplayInfo display, ref Vector2Int position);
	}
}
