using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;

namespace UnityEngine
{
	// Token: 0x02000292 RID: 658
	[NativeHeader("Runtime/Input/KeyboardOnScreen.h")]
	[NativeHeader("Runtime/Export/TouchScreenKeyboard/TouchScreenKeyboard.bindings.h")]
	[NativeConditional("ENABLE_ONSCREEN_KEYBOARD")]
	public class TouchScreenKeyboard
	{
		// Token: 0x06001BDC RID: 7132
		[FreeFunction("TouchScreenKeyboard_Destroy", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Destroy(IntPtr ptr);

		// Token: 0x06001BDD RID: 7133 RVA: 0x0002E2CC File Offset: 0x0002C4CC
		private void Destroy()
		{
			bool flag = this.m_Ptr != IntPtr.Zero;
			if (flag)
			{
				TouchScreenKeyboard.Internal_Destroy(this.m_Ptr);
				this.m_Ptr = IntPtr.Zero;
			}
			GC.SuppressFinalize(this);
		}

		// Token: 0x06001BDE RID: 7134 RVA: 0x0002E310 File Offset: 0x0002C510
		~TouchScreenKeyboard()
		{
			this.Destroy();
		}

		// Token: 0x06001BDF RID: 7135 RVA: 0x0002E340 File Offset: 0x0002C540
		public TouchScreenKeyboard(string text, TouchScreenKeyboardType keyboardType, bool autocorrection, bool multiline, bool secure, bool alert, string textPlaceholder, int characterLimit)
		{
			TouchScreenKeyboard_InternalConstructorHelperArguments touchScreenKeyboard_InternalConstructorHelperArguments = default(TouchScreenKeyboard_InternalConstructorHelperArguments);
			touchScreenKeyboard_InternalConstructorHelperArguments.keyboardType = Convert.ToUInt32(keyboardType);
			touchScreenKeyboard_InternalConstructorHelperArguments.autocorrection = Convert.ToUInt32(autocorrection);
			touchScreenKeyboard_InternalConstructorHelperArguments.multiline = Convert.ToUInt32(multiline);
			touchScreenKeyboard_InternalConstructorHelperArguments.secure = Convert.ToUInt32(secure);
			touchScreenKeyboard_InternalConstructorHelperArguments.alert = Convert.ToUInt32(alert);
			touchScreenKeyboard_InternalConstructorHelperArguments.characterLimit = characterLimit;
			this.m_Ptr = TouchScreenKeyboard.TouchScreenKeyboard_InternalConstructorHelper(ref touchScreenKeyboard_InternalConstructorHelperArguments, text, textPlaceholder);
		}

		// Token: 0x06001BE0 RID: 7136
		[FreeFunction("TouchScreenKeyboard_InternalConstructorHelper")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr TouchScreenKeyboard_InternalConstructorHelper(ref TouchScreenKeyboard_InternalConstructorHelperArguments arguments, string text, string textPlaceholder);

		// Token: 0x17000578 RID: 1400
		// (get) Token: 0x06001BE1 RID: 7137 RVA: 0x0002E3C0 File Offset: 0x0002C5C0
		public static bool isSupported
		{
			get
			{
				RuntimePlatform platform = Application.platform;
				RuntimePlatform runtimePlatform = platform;
				RuntimePlatform runtimePlatform2 = runtimePlatform;
				if (runtimePlatform2 <= RuntimePlatform.MetroPlayerARM)
				{
					if (runtimePlatform2 != RuntimePlatform.IPhonePlayer && runtimePlatform2 != RuntimePlatform.Android && runtimePlatform2 - RuntimePlatform.WebGLPlayer > 3)
					{
						goto IL_63;
					}
				}
				else if (runtimePlatform2 != RuntimePlatform.PS4)
				{
					switch (runtimePlatform2)
					{
					case RuntimePlatform.tvOS:
					case RuntimePlatform.Switch:
					case RuntimePlatform.Stadia:
					case RuntimePlatform.GameCoreXboxSeries:
					case RuntimePlatform.GameCoreXboxOne:
					case RuntimePlatform.PS5:
						break;
					case RuntimePlatform.Lumin:
					case RuntimePlatform.CloudRendering:
						goto IL_63;
					default:
						if (runtimePlatform2 != RuntimePlatform.VisionOS)
						{
							goto IL_63;
						}
						break;
					}
				}
				return true;
				IL_63:
				return false;
			}
		}

		// Token: 0x17000579 RID: 1401
		// (get) Token: 0x06001BE2 RID: 7138 RVA: 0x0002E435 File Offset: 0x0002C635
		// (set) Token: 0x06001BE3 RID: 7139 RVA: 0x0002E43C File Offset: 0x0002C63C
		internal static bool disableInPlaceEditing { get; set; }

		// Token: 0x1700057A RID: 1402
		// (get) Token: 0x06001BE4 RID: 7140 RVA: 0x0002E444 File Offset: 0x0002C644
		public static bool isInPlaceEditingAllowed
		{
			get
			{
				bool disableInPlaceEditing = TouchScreenKeyboard.disableInPlaceEditing;
				return disableInPlaceEditing && false;
			}
		}

		// Token: 0x1700057B RID: 1403
		// (get) Token: 0x06001BE5 RID: 7141 RVA: 0x0002E464 File Offset: 0x0002C664
		internal static bool isRequiredToForceOpen
		{
			get
			{
				return TouchScreenKeyboard.IsRequiredToForceOpen();
			}
		}

		// Token: 0x06001BE6 RID: 7142
		[FreeFunction("TouchScreenKeyboard_IsRequiredToForceOpen")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsRequiredToForceOpen();

		// Token: 0x06001BE7 RID: 7143 RVA: 0x0002E47C File Offset: 0x0002C67C
		public static TouchScreenKeyboard Open(string text, [DefaultValue("TouchScreenKeyboardType.Default")] TouchScreenKeyboardType keyboardType, [DefaultValue("true")] bool autocorrection, [DefaultValue("false")] bool multiline, [DefaultValue("false")] bool secure, [DefaultValue("false")] bool alert, [DefaultValue("\"\"")] string textPlaceholder, [DefaultValue("0")] int characterLimit)
		{
			return new TouchScreenKeyboard(text, keyboardType, autocorrection, multiline, secure, alert, textPlaceholder, characterLimit);
		}

		// Token: 0x06001BE8 RID: 7144 RVA: 0x0002E4A0 File Offset: 0x0002C6A0
		[ExcludeFromDocs]
		public static TouchScreenKeyboard Open(string text, TouchScreenKeyboardType keyboardType, bool autocorrection, bool multiline, bool secure, bool alert, string textPlaceholder)
		{
			int characterLimit = 0;
			return TouchScreenKeyboard.Open(text, keyboardType, autocorrection, multiline, secure, alert, textPlaceholder, characterLimit);
		}

		// Token: 0x06001BE9 RID: 7145 RVA: 0x0002E4C4 File Offset: 0x0002C6C4
		[ExcludeFromDocs]
		public static TouchScreenKeyboard Open(string text, TouchScreenKeyboardType keyboardType, bool autocorrection, bool multiline, bool secure, bool alert)
		{
			int characterLimit = 0;
			string textPlaceholder = "";
			return TouchScreenKeyboard.Open(text, keyboardType, autocorrection, multiline, secure, alert, textPlaceholder, characterLimit);
		}

		// Token: 0x06001BEA RID: 7146 RVA: 0x0002E4F0 File Offset: 0x0002C6F0
		[ExcludeFromDocs]
		public static TouchScreenKeyboard Open(string text, TouchScreenKeyboardType keyboardType, bool autocorrection, bool multiline, bool secure)
		{
			int characterLimit = 0;
			string textPlaceholder = "";
			bool alert = false;
			return TouchScreenKeyboard.Open(text, keyboardType, autocorrection, multiline, secure, alert, textPlaceholder, characterLimit);
		}

		// Token: 0x06001BEB RID: 7147 RVA: 0x0002E51C File Offset: 0x0002C71C
		[ExcludeFromDocs]
		public static TouchScreenKeyboard Open(string text, TouchScreenKeyboardType keyboardType, bool autocorrection, bool multiline)
		{
			int characterLimit = 0;
			string textPlaceholder = "";
			bool alert = false;
			bool secure = false;
			return TouchScreenKeyboard.Open(text, keyboardType, autocorrection, multiline, secure, alert, textPlaceholder, characterLimit);
		}

		// Token: 0x06001BEC RID: 7148 RVA: 0x0002E54C File Offset: 0x0002C74C
		[ExcludeFromDocs]
		public static TouchScreenKeyboard Open(string text, TouchScreenKeyboardType keyboardType, bool autocorrection)
		{
			int characterLimit = 0;
			string textPlaceholder = "";
			bool alert = false;
			bool secure = false;
			bool multiline = false;
			return TouchScreenKeyboard.Open(text, keyboardType, autocorrection, multiline, secure, alert, textPlaceholder, characterLimit);
		}

		// Token: 0x06001BED RID: 7149 RVA: 0x0002E580 File Offset: 0x0002C780
		[ExcludeFromDocs]
		public static TouchScreenKeyboard Open(string text, TouchScreenKeyboardType keyboardType)
		{
			int characterLimit = 0;
			string textPlaceholder = "";
			bool alert = false;
			bool secure = false;
			bool multiline = false;
			bool autocorrection = true;
			return TouchScreenKeyboard.Open(text, keyboardType, autocorrection, multiline, secure, alert, textPlaceholder, characterLimit);
		}

		// Token: 0x06001BEE RID: 7150 RVA: 0x0002E5B8 File Offset: 0x0002C7B8
		[ExcludeFromDocs]
		public static TouchScreenKeyboard Open(string text)
		{
			int characterLimit = 0;
			string textPlaceholder = "";
			bool alert = false;
			bool secure = false;
			bool multiline = false;
			bool autocorrection = true;
			TouchScreenKeyboardType keyboardType = TouchScreenKeyboardType.Default;
			return TouchScreenKeyboard.Open(text, keyboardType, autocorrection, multiline, secure, alert, textPlaceholder, characterLimit);
		}

		// Token: 0x1700057C RID: 1404
		// (get) Token: 0x06001BEF RID: 7151
		// (set) Token: 0x06001BF0 RID: 7152
		public extern string text { [NativeName("GetText")] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeName("SetText")] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700057D RID: 1405
		// (get) Token: 0x06001BF1 RID: 7153
		// (set) Token: 0x06001BF2 RID: 7154
		public static extern bool hideInput { [NativeName("IsInputHidden")] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeName("SetInputHidden")] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700057E RID: 1406
		// (get) Token: 0x06001BF3 RID: 7155
		// (set) Token: 0x06001BF4 RID: 7156
		public extern bool active { [NativeName("IsActive")] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeName("SetActive")] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06001BF5 RID: 7157
		[FreeFunction("TouchScreenKeyboard_GetDone")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetDone(IntPtr ptr);

		// Token: 0x1700057F RID: 1407
		// (get) Token: 0x06001BF6 RID: 7158 RVA: 0x0002E5F4 File Offset: 0x0002C7F4
		[Obsolete("Property done is deprecated, use status instead")]
		public bool done
		{
			get
			{
				return TouchScreenKeyboard.GetDone(this.m_Ptr);
			}
		}

		// Token: 0x06001BF7 RID: 7159
		[FreeFunction("TouchScreenKeyboard_GetWasCanceled")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetWasCanceled(IntPtr ptr);

		// Token: 0x17000580 RID: 1408
		// (get) Token: 0x06001BF8 RID: 7160 RVA: 0x0002E614 File Offset: 0x0002C814
		[Obsolete("Property wasCanceled is deprecated, use status instead.")]
		public bool wasCanceled
		{
			get
			{
				return TouchScreenKeyboard.GetWasCanceled(this.m_Ptr);
			}
		}

		// Token: 0x17000581 RID: 1409
		// (get) Token: 0x06001BF9 RID: 7161
		public extern TouchScreenKeyboard.Status status { [NativeName("GetKeyboardStatus")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000582 RID: 1410
		// (get) Token: 0x06001BFA RID: 7162
		// (set) Token: 0x06001BFB RID: 7163
		public extern int characterLimit { [NativeName("GetCharacterLimit")] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeName("SetCharacterLimit")] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000583 RID: 1411
		// (get) Token: 0x06001BFC RID: 7164
		public extern bool canGetSelection { [NativeName("CanGetSelection")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000584 RID: 1412
		// (get) Token: 0x06001BFD RID: 7165
		public extern bool canSetSelection { [NativeName("CanSetSelection")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000585 RID: 1413
		// (get) Token: 0x06001BFE RID: 7166 RVA: 0x0002E634 File Offset: 0x0002C834
		// (set) Token: 0x06001BFF RID: 7167 RVA: 0x0002E65C File Offset: 0x0002C85C
		public RangeInt selection
		{
			get
			{
				RangeInt result;
				TouchScreenKeyboard.GetSelection(out result.start, out result.length);
				return result;
			}
			set
			{
				bool flag = value.start < 0 || value.length < 0 || value.start + value.length > this.text.Length;
				if (flag)
				{
					throw new ArgumentOutOfRangeException("selection", "Selection is out of range.");
				}
				TouchScreenKeyboard.SetSelection(value.start, value.length);
			}
		}

		// Token: 0x06001C00 RID: 7168
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSelection(out int start, out int length);

		// Token: 0x06001C01 RID: 7169
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetSelection(int start, int length);

		// Token: 0x17000586 RID: 1414
		// (get) Token: 0x06001C02 RID: 7170
		public extern TouchScreenKeyboardType type { [NativeName("GetKeyboardType")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000587 RID: 1415
		// (get) Token: 0x06001C03 RID: 7171 RVA: 0x0002E6C0 File Offset: 0x0002C8C0
		// (set) Token: 0x06001C04 RID: 7172 RVA: 0x00002669 File Offset: 0x00000869
		public int targetDisplay
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		// Token: 0x17000588 RID: 1416
		// (get) Token: 0x06001C05 RID: 7173 RVA: 0x0002E6D4 File Offset: 0x0002C8D4
		[NativeConditional("ENABLE_ONSCREEN_KEYBOARD", "RectT<float>()")]
		public static Rect area
		{
			[NativeName("GetRect")]
			get
			{
				Rect result;
				TouchScreenKeyboard.get_area_Injected(out result);
				return result;
			}
		}

		// Token: 0x17000589 RID: 1417
		// (get) Token: 0x06001C06 RID: 7174
		public static extern bool visible { [NativeName("IsVisible")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06001C07 RID: 7175
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_area_Injected(out Rect ret);

		// Token: 0x04000952 RID: 2386
		[NonSerialized]
		internal IntPtr m_Ptr;

		// Token: 0x02000293 RID: 659
		public enum Status
		{
			// Token: 0x04000955 RID: 2389
			Visible,
			// Token: 0x04000956 RID: 2390
			Done,
			// Token: 0x04000957 RID: 2391
			Canceled,
			// Token: 0x04000958 RID: 2392
			LostFocus
		}

		// Token: 0x02000294 RID: 660
		public class Android
		{
			// Token: 0x1700058A RID: 1418
			// (get) Token: 0x06001C08 RID: 7176 RVA: 0x0002E6EC File Offset: 0x0002C8EC
			// (set) Token: 0x06001C09 RID: 7177 RVA: 0x0002E703 File Offset: 0x0002C903
			[Obsolete("TouchScreenKeyboard.Android.closeKeyboardOnOutsideTap is obsolete. Use TouchScreenKeyboard.Android.consumesOutsideTouches instead (UnityUpgradable) -> UnityEngine.TouchScreenKeyboard/Android.consumesOutsideTouches")]
			public static bool closeKeyboardOnOutsideTap
			{
				get
				{
					return TouchScreenKeyboard.Android.consumesOutsideTouches;
				}
				set
				{
					TouchScreenKeyboard.Android.consumesOutsideTouches = value;
				}
			}

			// Token: 0x1700058B RID: 1419
			// (get) Token: 0x06001C0B RID: 7179 RVA: 0x0002E718 File Offset: 0x0002C918
			// (set) Token: 0x06001C0A RID: 7178 RVA: 0x0002E70D File Offset: 0x0002C90D
			public static bool consumesOutsideTouches
			{
				get
				{
					return TouchScreenKeyboard.Android.TouchScreenKeyboard_GetAndroidKeyboardConsumesOutsideTouches();
				}
				set
				{
					TouchScreenKeyboard.Android.TouchScreenKeyboard_SetAndroidKeyboardConsumesOutsideTouches(value);
				}
			}

			// Token: 0x06001C0C RID: 7180
			[NativeConditional("PLATFORM_ANDROID")]
			[FreeFunction("TouchScreenKeyboard_SetAndroidKeyboardConsumesOutsideTouches")]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern void TouchScreenKeyboard_SetAndroidKeyboardConsumesOutsideTouches(bool enable);

			// Token: 0x06001C0D RID: 7181
			[FreeFunction("TouchScreenKeyboard_GetAndroidKeyboardConsumesOutsideTouches")]
			[NativeConditional("PLATFORM_ANDROID")]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern bool TouchScreenKeyboard_GetAndroidKeyboardConsumesOutsideTouches();
		}
	}
}
