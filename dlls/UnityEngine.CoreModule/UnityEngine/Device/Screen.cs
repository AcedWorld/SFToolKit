using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.Internal;

namespace UnityEngine.Device
{
	// Token: 0x020004B0 RID: 1200
	public static class Screen
	{
		// Token: 0x170007C6 RID: 1990
		// (get) Token: 0x06002A18 RID: 10776 RVA: 0x00047167 File Offset: 0x00045367
		// (set) Token: 0x06002A19 RID: 10777 RVA: 0x0004716E File Offset: 0x0004536E
		public static float brightness
		{
			get
			{
				return Screen.brightness;
			}
			set
			{
				Screen.brightness = value;
			}
		}

		// Token: 0x170007C7 RID: 1991
		// (get) Token: 0x06002A1A RID: 10778 RVA: 0x00047177 File Offset: 0x00045377
		// (set) Token: 0x06002A1B RID: 10779 RVA: 0x0004717E File Offset: 0x0004537E
		public static bool autorotateToLandscapeLeft
		{
			get
			{
				return Screen.autorotateToLandscapeLeft;
			}
			set
			{
				Screen.autorotateToLandscapeLeft = value;
			}
		}

		// Token: 0x170007C8 RID: 1992
		// (get) Token: 0x06002A1C RID: 10780 RVA: 0x00047187 File Offset: 0x00045387
		// (set) Token: 0x06002A1D RID: 10781 RVA: 0x0004718E File Offset: 0x0004538E
		public static bool autorotateToLandscapeRight
		{
			get
			{
				return Screen.autorotateToLandscapeRight;
			}
			set
			{
				Screen.autorotateToLandscapeRight = value;
			}
		}

		// Token: 0x170007C9 RID: 1993
		// (get) Token: 0x06002A1E RID: 10782 RVA: 0x00047197 File Offset: 0x00045397
		// (set) Token: 0x06002A1F RID: 10783 RVA: 0x0004719E File Offset: 0x0004539E
		public static bool autorotateToPortrait
		{
			get
			{
				return Screen.autorotateToPortrait;
			}
			set
			{
				Screen.autorotateToPortrait = value;
			}
		}

		// Token: 0x170007CA RID: 1994
		// (get) Token: 0x06002A20 RID: 10784 RVA: 0x000471A7 File Offset: 0x000453A7
		// (set) Token: 0x06002A21 RID: 10785 RVA: 0x000471AE File Offset: 0x000453AE
		public static bool autorotateToPortraitUpsideDown
		{
			get
			{
				return Screen.autorotateToPortraitUpsideDown;
			}
			set
			{
				Screen.autorotateToPortraitUpsideDown = value;
			}
		}

		// Token: 0x170007CB RID: 1995
		// (get) Token: 0x06002A22 RID: 10786 RVA: 0x000471B7 File Offset: 0x000453B7
		public static Resolution currentResolution
		{
			get
			{
				return Screen.currentResolution;
			}
		}

		// Token: 0x170007CC RID: 1996
		// (get) Token: 0x06002A23 RID: 10787 RVA: 0x000471BE File Offset: 0x000453BE
		public static Rect[] cutouts
		{
			get
			{
				return Screen.cutouts;
			}
		}

		// Token: 0x170007CD RID: 1997
		// (get) Token: 0x06002A24 RID: 10788 RVA: 0x000471C5 File Offset: 0x000453C5
		public static float dpi
		{
			get
			{
				return Screen.dpi;
			}
		}

		// Token: 0x170007CE RID: 1998
		// (get) Token: 0x06002A25 RID: 10789 RVA: 0x000471CC File Offset: 0x000453CC
		// (set) Token: 0x06002A26 RID: 10790 RVA: 0x000471D3 File Offset: 0x000453D3
		public static bool fullScreen
		{
			get
			{
				return Screen.fullScreen;
			}
			set
			{
				Screen.fullScreen = value;
			}
		}

		// Token: 0x170007CF RID: 1999
		// (get) Token: 0x06002A27 RID: 10791 RVA: 0x000471DC File Offset: 0x000453DC
		// (set) Token: 0x06002A28 RID: 10792 RVA: 0x000471E3 File Offset: 0x000453E3
		public static FullScreenMode fullScreenMode
		{
			get
			{
				return Screen.fullScreenMode;
			}
			set
			{
				Screen.fullScreenMode = value;
			}
		}

		// Token: 0x170007D0 RID: 2000
		// (get) Token: 0x06002A29 RID: 10793 RVA: 0x000471EC File Offset: 0x000453EC
		public static int height
		{
			get
			{
				return Screen.height;
			}
		}

		// Token: 0x170007D1 RID: 2001
		// (get) Token: 0x06002A2A RID: 10794 RVA: 0x000471F3 File Offset: 0x000453F3
		public static int width
		{
			get
			{
				return Screen.width;
			}
		}

		// Token: 0x170007D2 RID: 2002
		// (get) Token: 0x06002A2B RID: 10795 RVA: 0x000471FA File Offset: 0x000453FA
		// (set) Token: 0x06002A2C RID: 10796 RVA: 0x00047201 File Offset: 0x00045401
		public static ScreenOrientation orientation
		{
			get
			{
				return Screen.orientation;
			}
			set
			{
				Screen.orientation = value;
			}
		}

		// Token: 0x170007D3 RID: 2003
		// (get) Token: 0x06002A2D RID: 10797 RVA: 0x0004720A File Offset: 0x0004540A
		public static Resolution[] resolutions
		{
			get
			{
				return Screen.resolutions;
			}
		}

		// Token: 0x170007D4 RID: 2004
		// (get) Token: 0x06002A2E RID: 10798 RVA: 0x00047211 File Offset: 0x00045411
		public static Rect safeArea
		{
			get
			{
				return Screen.safeArea;
			}
		}

		// Token: 0x170007D5 RID: 2005
		// (get) Token: 0x06002A2F RID: 10799 RVA: 0x00047218 File Offset: 0x00045418
		// (set) Token: 0x06002A30 RID: 10800 RVA: 0x0004721F File Offset: 0x0004541F
		public static int sleepTimeout
		{
			get
			{
				return Screen.sleepTimeout;
			}
			set
			{
				Screen.sleepTimeout = value;
			}
		}

		// Token: 0x06002A31 RID: 10801 RVA: 0x00047228 File Offset: 0x00045428
		public static void SetResolution(int width, int height, FullScreenMode fullscreenMode, RefreshRate preferredRefreshRate)
		{
			Screen.SetResolution(width, height, fullscreenMode, preferredRefreshRate);
		}

		// Token: 0x06002A32 RID: 10802 RVA: 0x00047238 File Offset: 0x00045438
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

		// Token: 0x06002A33 RID: 10803 RVA: 0x00047274 File Offset: 0x00045474
		public static void SetResolution(int width, int height, FullScreenMode fullscreenMode)
		{
			Screen.SetResolution(width, height, fullscreenMode, new RefreshRate
			{
				numerator = 0U,
				denominator = 1U
			});
		}

		// Token: 0x06002A34 RID: 10804 RVA: 0x000472A4 File Offset: 0x000454A4
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

		// Token: 0x06002A35 RID: 10805 RVA: 0x000472E8 File Offset: 0x000454E8
		public static void SetResolution(int width, int height, bool fullscreen)
		{
			Screen.SetResolution(width, height, fullscreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed, new RefreshRate
			{
				numerator = 0U,
				denominator = 1U
			});
		}

		// Token: 0x170007D6 RID: 2006
		// (get) Token: 0x06002A36 RID: 10806 RVA: 0x0004731E File Offset: 0x0004551E
		public static Vector2Int mainWindowPosition
		{
			get
			{
				return Screen.mainWindowPosition;
			}
		}

		// Token: 0x170007D7 RID: 2007
		// (get) Token: 0x06002A37 RID: 10807 RVA: 0x00047325 File Offset: 0x00045525
		public static DisplayInfo mainWindowDisplayInfo
		{
			get
			{
				return Screen.mainWindowDisplayInfo;
			}
		}

		// Token: 0x06002A38 RID: 10808 RVA: 0x0004732C File Offset: 0x0004552C
		public static void GetDisplayLayout(List<DisplayInfo> displayLayout)
		{
			Screen.GetDisplayLayout(displayLayout);
		}

		// Token: 0x06002A39 RID: 10809 RVA: 0x00047335 File Offset: 0x00045535
		public static AsyncOperation MoveMainWindowTo(in DisplayInfo display, Vector2Int position)
		{
			return Screen.MoveMainWindowTo(display, position);
		}
	}
}
