using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x0200002B RID: 43
	[NativeHeader("IMGUIScriptingClasses.h")]
	[RequiredByNativeCode]
	[NativeHeader("Modules/IMGUI/GUIStyle.bindings.h")]
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public sealed class GUIStyle
	{
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060002EF RID: 751
		// (set) Token: 0x060002F0 RID: 752
		[NativeProperty("Name", false, TargetType.Function)]
		internal extern string rawName { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060002F1 RID: 753
		// (set) Token: 0x060002F2 RID: 754
		[NativeProperty("Font", false, TargetType.Function)]
		public extern Font font { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060002F3 RID: 755
		// (set) Token: 0x060002F4 RID: 756
		[NativeProperty("m_ImagePosition", false, TargetType.Field)]
		public extern ImagePosition imagePosition { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060002F5 RID: 757
		// (set) Token: 0x060002F6 RID: 758
		[NativeProperty("m_Alignment", false, TargetType.Field)]
		public extern TextAnchor alignment { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060002F7 RID: 759
		// (set) Token: 0x060002F8 RID: 760
		[NativeProperty("m_WordWrap", false, TargetType.Field)]
		public extern bool wordWrap { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060002F9 RID: 761
		// (set) Token: 0x060002FA RID: 762
		[NativeProperty("m_Clipping", false, TargetType.Field)]
		public extern TextClipping clipping { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060002FB RID: 763 RVA: 0x0000B710 File Offset: 0x00009910
		// (set) Token: 0x060002FC RID: 764 RVA: 0x0000B726 File Offset: 0x00009926
		[NativeProperty("m_ContentOffset", false, TargetType.Field)]
		public Vector2 contentOffset
		{
			get
			{
				Vector2 result;
				this.get_contentOffset_Injected(out result);
				return result;
			}
			set
			{
				this.set_contentOffset_Injected(ref value);
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060002FD RID: 765
		// (set) Token: 0x060002FE RID: 766
		[NativeProperty("m_FixedWidth", false, TargetType.Field)]
		public extern float fixedWidth { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060002FF RID: 767
		// (set) Token: 0x06000300 RID: 768
		[NativeProperty("m_FixedHeight", false, TargetType.Field)]
		public extern float fixedHeight { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000301 RID: 769
		// (set) Token: 0x06000302 RID: 770
		[NativeProperty("m_StretchWidth", false, TargetType.Field)]
		public extern bool stretchWidth { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000303 RID: 771
		// (set) Token: 0x06000304 RID: 772
		[NativeProperty("m_StretchHeight", false, TargetType.Field)]
		public extern bool stretchHeight { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000305 RID: 773
		// (set) Token: 0x06000306 RID: 774
		[NativeProperty("m_FontSize", false, TargetType.Field)]
		public extern int fontSize { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000307 RID: 775
		// (set) Token: 0x06000308 RID: 776
		[NativeProperty("m_FontStyle", false, TargetType.Field)]
		public extern FontStyle fontStyle { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000309 RID: 777
		// (set) Token: 0x0600030A RID: 778
		[NativeProperty("m_RichText", false, TargetType.Field)]
		public extern bool richText { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x0600030B RID: 779 RVA: 0x0000B730 File Offset: 0x00009930
		// (set) Token: 0x0600030C RID: 780 RVA: 0x0000B746 File Offset: 0x00009946
		[NativeProperty("m_ClipOffset", false, TargetType.Field)]
		[Obsolete("Don't use clipOffset - put things inside BeginGroup instead. This functionality will be removed in a later version.", false)]
		public Vector2 clipOffset
		{
			get
			{
				Vector2 result;
				this.get_clipOffset_Injected(out result);
				return result;
			}
			set
			{
				this.set_clipOffset_Injected(ref value);
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600030D RID: 781 RVA: 0x0000B750 File Offset: 0x00009950
		// (set) Token: 0x0600030E RID: 782 RVA: 0x0000B766 File Offset: 0x00009966
		[NativeProperty("m_ClipOffset", false, TargetType.Field)]
		internal Vector2 Internal_clipOffset
		{
			get
			{
				Vector2 result;
				this.get_Internal_clipOffset_Injected(out result);
				return result;
			}
			set
			{
				this.set_Internal_clipOffset_Injected(ref value);
			}
		}

		// Token: 0x0600030F RID: 783
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_Create", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Internal_Create(GUIStyle self);

		// Token: 0x06000310 RID: 784
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_Copy", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Internal_Copy(GUIStyle self, GUIStyle other);

		// Token: 0x06000311 RID: 785
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_Destroy", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Destroy(IntPtr self);

		// Token: 0x06000312 RID: 786
		[FreeFunction(Name = "GUIStyle_Bindings::GetStyleStatePtr", IsThreadSafe = true, HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern IntPtr GetStyleStatePtr(int idx);

		// Token: 0x06000313 RID: 787
		[FreeFunction(Name = "GUIStyle_Bindings::AssignStyleState", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void AssignStyleState(int idx, IntPtr srcStyleState);

		// Token: 0x06000314 RID: 788
		[FreeFunction(Name = "GUIStyle_Bindings::GetRectOffsetPtr", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern IntPtr GetRectOffsetPtr(int idx);

		// Token: 0x06000315 RID: 789
		[FreeFunction(Name = "GUIStyle_Bindings::AssignRectOffset", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void AssignRectOffset(int idx, IntPtr srcRectOffset);

		// Token: 0x06000316 RID: 790
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_GetLineHeight")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float Internal_GetLineHeight(IntPtr target);

		// Token: 0x06000317 RID: 791 RVA: 0x0000B770 File Offset: 0x00009970
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_Draw", HasExplicitThis = true)]
		private void Internal_Draw(Rect screenRect, GUIContent content, bool isHover, bool isActive, bool on, bool hasKeyboardFocus)
		{
			this.Internal_Draw_Injected(ref screenRect, content, isHover, isActive, on, hasKeyboardFocus);
		}

		// Token: 0x06000318 RID: 792 RVA: 0x0000B782 File Offset: 0x00009982
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_Draw2", HasExplicitThis = true)]
		private void Internal_Draw2(Rect position, GUIContent content, int controlID, bool on)
		{
			this.Internal_Draw2_Injected(ref position, content, controlID, on);
		}

		// Token: 0x06000319 RID: 793 RVA: 0x0000B790 File Offset: 0x00009990
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_DrawCursor", HasExplicitThis = true)]
		private void Internal_DrawCursor(Rect position, GUIContent content, int pos, Color cursorColor)
		{
			this.Internal_DrawCursor_Injected(ref position, content, pos, ref cursorColor);
		}

		// Token: 0x0600031A RID: 794 RVA: 0x0000B7A0 File Offset: 0x000099A0
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_DrawWithTextSelection", HasExplicitThis = true)]
		private void Internal_DrawWithTextSelection(Rect screenRect, GUIContent content, bool isHover, bool isActive, bool on, bool hasKeyboardFocus, bool drawSelectionAsComposition, int cursorFirst, int cursorLast, Color cursorColor, Color selectionColor)
		{
			this.Internal_DrawWithTextSelection_Injected(ref screenRect, content, isHover, isActive, on, hasKeyboardFocus, drawSelectionAsComposition, cursorFirst, cursorLast, ref cursorColor, ref selectionColor);
		}

		// Token: 0x0600031B RID: 795 RVA: 0x0000B7C8 File Offset: 0x000099C8
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_GetCursorPixelPosition", HasExplicitThis = true)]
		internal Vector2 Internal_GetCursorPixelPosition(Rect position, GUIContent content, int cursorStringIndex)
		{
			Vector2 result;
			this.Internal_GetCursorPixelPosition_Injected(ref position, content, cursorStringIndex, out result);
			return result;
		}

		// Token: 0x0600031C RID: 796 RVA: 0x0000B7E2 File Offset: 0x000099E2
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_GetCursorStringIndex", HasExplicitThis = true)]
		internal int Internal_GetCursorStringIndex(Rect position, GUIContent content, Vector2 cursorPixelPosition)
		{
			return this.Internal_GetCursorStringIndex_Injected(ref position, content, ref cursorPixelPosition);
		}

		// Token: 0x0600031D RID: 797 RVA: 0x0000B7EF File Offset: 0x000099EF
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_GetSelectedRenderedText", HasExplicitThis = true)]
		internal string Internal_GetSelectedRenderedText(Rect localPosition, GUIContent mContent, int selectIndex, int cursorIndex)
		{
			return this.Internal_GetSelectedRenderedText_Injected(ref localPosition, mContent, selectIndex, cursorIndex);
		}

		// Token: 0x0600031E RID: 798 RVA: 0x0000B7FD File Offset: 0x000099FD
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_GetHyperlinksRect", HasExplicitThis = true)]
		internal Rect[] Internal_GetHyperlinksRect(Rect localPosition, GUIContent mContent)
		{
			return this.Internal_GetHyperlinksRect_Injected(ref localPosition, mContent);
		}

		// Token: 0x0600031F RID: 799
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_GetNumCharactersThatFitWithinWidth", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern int Internal_GetNumCharactersThatFitWithinWidth(string text, float width);

		// Token: 0x06000320 RID: 800 RVA: 0x0000B808 File Offset: 0x00009A08
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_CalcSize", HasExplicitThis = true)]
		internal Vector2 Internal_CalcSize(GUIContent content)
		{
			Vector2 result;
			this.Internal_CalcSize_Injected(content, out result);
			return result;
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0000B820 File Offset: 0x00009A20
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_CalcSizeWithConstraints", HasExplicitThis = true)]
		internal Vector2 Internal_CalcSizeWithConstraints(GUIContent content, Vector2 maxSize)
		{
			Vector2 result;
			this.Internal_CalcSizeWithConstraints_Injected(content, ref maxSize, out result);
			return result;
		}

		// Token: 0x06000322 RID: 802
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_CalcHeight", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern float Internal_CalcHeight(GUIContent content, float width);

		// Token: 0x06000323 RID: 803 RVA: 0x0000B83C File Offset: 0x00009A3C
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_CalcMinMaxWidth", HasExplicitThis = true)]
		private Vector2 Internal_CalcMinMaxWidth(GUIContent content)
		{
			Vector2 result;
			this.Internal_CalcMinMaxWidth_Injected(content, out result);
			return result;
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0000B853 File Offset: 0x00009A53
		[FreeFunction(Name = "GUIStyle_Bindings::SetMouseTooltip")]
		internal static void SetMouseTooltip(string tooltip, Rect screenRect)
		{
			GUIStyle.SetMouseTooltip_Injected(tooltip, ref screenRect);
		}

		// Token: 0x06000325 RID: 805
		[FreeFunction(Name = "GUIStyle_Bindings::IsTooltipActive")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool IsTooltipActive(string tooltip);

		// Token: 0x06000326 RID: 806
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_GetCursorFlashOffset")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float Internal_GetCursorFlashOffset();

		// Token: 0x06000327 RID: 807
		[FreeFunction(Name = "GUIStyle::SetDefaultFont")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void SetDefaultFont(Font font);

		// Token: 0x06000328 RID: 808 RVA: 0x0000B85D File Offset: 0x00009A5D
		public GUIStyle()
		{
			this.m_Ptr = GUIStyle.Internal_Create(this);
		}

		// Token: 0x06000329 RID: 809 RVA: 0x0000B874 File Offset: 0x00009A74
		public GUIStyle(GUIStyle other)
		{
			bool flag = other == null;
			if (flag)
			{
				Debug.LogError("Copied style is null. Using StyleNotFound instead.");
				other = GUISkin.error;
			}
			this.m_Ptr = GUIStyle.Internal_Copy(this, other);
		}

		// Token: 0x0600032A RID: 810 RVA: 0x0000B8B4 File Offset: 0x00009AB4
		protected override void Finalize()
		{
			try
			{
				bool flag = this.m_Ptr != IntPtr.Zero;
				if (flag)
				{
					GUIStyle.Internal_Destroy(this.m_Ptr);
					this.m_Ptr = IntPtr.Zero;
				}
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x0600032B RID: 811 RVA: 0x0000B90C File Offset: 0x00009B0C
		internal static void CleanupRoots()
		{
			GUIStyle.s_None = null;
		}

		// Token: 0x0600032C RID: 812 RVA: 0x0000B918 File Offset: 0x00009B18
		internal void InternalOnAfterDeserialize()
		{
			this.m_Normal = GUIStyleState.ProduceGUIStyleStateFromDeserialization(this, this.GetStyleStatePtr(0));
			this.m_Hover = GUIStyleState.ProduceGUIStyleStateFromDeserialization(this, this.GetStyleStatePtr(1));
			this.m_Active = GUIStyleState.ProduceGUIStyleStateFromDeserialization(this, this.GetStyleStatePtr(2));
			this.m_Focused = GUIStyleState.ProduceGUIStyleStateFromDeserialization(this, this.GetStyleStatePtr(3));
			this.m_OnNormal = GUIStyleState.ProduceGUIStyleStateFromDeserialization(this, this.GetStyleStatePtr(4));
			this.m_OnHover = GUIStyleState.ProduceGUIStyleStateFromDeserialization(this, this.GetStyleStatePtr(5));
			this.m_OnActive = GUIStyleState.ProduceGUIStyleStateFromDeserialization(this, this.GetStyleStatePtr(6));
			this.m_OnFocused = GUIStyleState.ProduceGUIStyleStateFromDeserialization(this, this.GetStyleStatePtr(7));
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600032D RID: 813 RVA: 0x0000B9C0 File Offset: 0x00009BC0
		// (set) Token: 0x0600032E RID: 814 RVA: 0x0000B9EB File Offset: 0x00009BEB
		public string name
		{
			get
			{
				string result;
				if ((result = this.m_Name) == null)
				{
					result = (this.m_Name = this.rawName);
				}
				return result;
			}
			set
			{
				this.m_Name = value;
				this.rawName = value;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600032F RID: 815 RVA: 0x0000BA00 File Offset: 0x00009C00
		// (set) Token: 0x06000330 RID: 816 RVA: 0x0000BA32 File Offset: 0x00009C32
		public GUIStyleState normal
		{
			get
			{
				GUIStyleState result;
				if ((result = this.m_Normal) == null)
				{
					result = (this.m_Normal = GUIStyleState.GetGUIStyleState(this, this.GetStyleStatePtr(0)));
				}
				return result;
			}
			set
			{
				this.AssignStyleState(0, value.m_Ptr);
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000331 RID: 817 RVA: 0x0000BA44 File Offset: 0x00009C44
		// (set) Token: 0x06000332 RID: 818 RVA: 0x0000BA76 File Offset: 0x00009C76
		public GUIStyleState hover
		{
			get
			{
				GUIStyleState result;
				if ((result = this.m_Hover) == null)
				{
					result = (this.m_Hover = GUIStyleState.GetGUIStyleState(this, this.GetStyleStatePtr(1)));
				}
				return result;
			}
			set
			{
				this.AssignStyleState(1, value.m_Ptr);
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000333 RID: 819 RVA: 0x0000BA88 File Offset: 0x00009C88
		// (set) Token: 0x06000334 RID: 820 RVA: 0x0000BABA File Offset: 0x00009CBA
		public GUIStyleState active
		{
			get
			{
				GUIStyleState result;
				if ((result = this.m_Active) == null)
				{
					result = (this.m_Active = GUIStyleState.GetGUIStyleState(this, this.GetStyleStatePtr(2)));
				}
				return result;
			}
			set
			{
				this.AssignStyleState(2, value.m_Ptr);
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000335 RID: 821 RVA: 0x0000BACC File Offset: 0x00009CCC
		// (set) Token: 0x06000336 RID: 822 RVA: 0x0000BAFE File Offset: 0x00009CFE
		public GUIStyleState onNormal
		{
			get
			{
				GUIStyleState result;
				if ((result = this.m_OnNormal) == null)
				{
					result = (this.m_OnNormal = GUIStyleState.GetGUIStyleState(this, this.GetStyleStatePtr(4)));
				}
				return result;
			}
			set
			{
				this.AssignStyleState(4, value.m_Ptr);
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000337 RID: 823 RVA: 0x0000BB10 File Offset: 0x00009D10
		// (set) Token: 0x06000338 RID: 824 RVA: 0x0000BB42 File Offset: 0x00009D42
		public GUIStyleState onHover
		{
			get
			{
				GUIStyleState result;
				if ((result = this.m_OnHover) == null)
				{
					result = (this.m_OnHover = GUIStyleState.GetGUIStyleState(this, this.GetStyleStatePtr(5)));
				}
				return result;
			}
			set
			{
				this.AssignStyleState(5, value.m_Ptr);
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000339 RID: 825 RVA: 0x0000BB54 File Offset: 0x00009D54
		// (set) Token: 0x0600033A RID: 826 RVA: 0x0000BB86 File Offset: 0x00009D86
		public GUIStyleState onActive
		{
			get
			{
				GUIStyleState result;
				if ((result = this.m_OnActive) == null)
				{
					result = (this.m_OnActive = GUIStyleState.GetGUIStyleState(this, this.GetStyleStatePtr(6)));
				}
				return result;
			}
			set
			{
				this.AssignStyleState(6, value.m_Ptr);
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600033B RID: 827 RVA: 0x0000BB98 File Offset: 0x00009D98
		// (set) Token: 0x0600033C RID: 828 RVA: 0x0000BBCA File Offset: 0x00009DCA
		public GUIStyleState focused
		{
			get
			{
				GUIStyleState result;
				if ((result = this.m_Focused) == null)
				{
					result = (this.m_Focused = GUIStyleState.GetGUIStyleState(this, this.GetStyleStatePtr(3)));
				}
				return result;
			}
			set
			{
				this.AssignStyleState(3, value.m_Ptr);
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600033D RID: 829 RVA: 0x0000BBDC File Offset: 0x00009DDC
		// (set) Token: 0x0600033E RID: 830 RVA: 0x0000BC0E File Offset: 0x00009E0E
		public GUIStyleState onFocused
		{
			get
			{
				GUIStyleState result;
				if ((result = this.m_OnFocused) == null)
				{
					result = (this.m_OnFocused = GUIStyleState.GetGUIStyleState(this, this.GetStyleStatePtr(7)));
				}
				return result;
			}
			set
			{
				this.AssignStyleState(7, value.m_Ptr);
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600033F RID: 831 RVA: 0x0000BC20 File Offset: 0x00009E20
		// (set) Token: 0x06000340 RID: 832 RVA: 0x0000BC52 File Offset: 0x00009E52
		public RectOffset border
		{
			get
			{
				RectOffset result;
				if ((result = this.m_Border) == null)
				{
					result = (this.m_Border = new RectOffset(this, this.GetRectOffsetPtr(0)));
				}
				return result;
			}
			set
			{
				this.AssignRectOffset(0, value.m_Ptr);
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000341 RID: 833 RVA: 0x0000BC64 File Offset: 0x00009E64
		// (set) Token: 0x06000342 RID: 834 RVA: 0x0000BC96 File Offset: 0x00009E96
		public RectOffset margin
		{
			get
			{
				RectOffset result;
				if ((result = this.m_Margin) == null)
				{
					result = (this.m_Margin = new RectOffset(this, this.GetRectOffsetPtr(1)));
				}
				return result;
			}
			set
			{
				this.AssignRectOffset(1, value.m_Ptr);
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000343 RID: 835 RVA: 0x0000BCA8 File Offset: 0x00009EA8
		// (set) Token: 0x06000344 RID: 836 RVA: 0x0000BCDA File Offset: 0x00009EDA
		public RectOffset padding
		{
			get
			{
				RectOffset result;
				if ((result = this.m_Padding) == null)
				{
					result = (this.m_Padding = new RectOffset(this, this.GetRectOffsetPtr(2)));
				}
				return result;
			}
			set
			{
				this.AssignRectOffset(2, value.m_Ptr);
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000345 RID: 837 RVA: 0x0000BCEC File Offset: 0x00009EEC
		// (set) Token: 0x06000346 RID: 838 RVA: 0x0000BD1E File Offset: 0x00009F1E
		public RectOffset overflow
		{
			get
			{
				RectOffset result;
				if ((result = this.m_Overflow) == null)
				{
					result = (this.m_Overflow = new RectOffset(this, this.GetRectOffsetPtr(3)));
				}
				return result;
			}
			set
			{
				this.AssignRectOffset(3, value.m_Ptr);
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000347 RID: 839 RVA: 0x0000BD2F File Offset: 0x00009F2F
		public float lineHeight
		{
			get
			{
				return Mathf.Round(GUIStyle.Internal_GetLineHeight(this.m_Ptr));
			}
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0000BD41 File Offset: 0x00009F41
		public void Draw(Rect position, bool isHover, bool isActive, bool on, bool hasKeyboardFocus)
		{
			this.Draw(position, GUIContent.none, -1, isHover, isActive, on, hasKeyboardFocus);
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0000BD58 File Offset: 0x00009F58
		public void Draw(Rect position, string text, bool isHover, bool isActive, bool on, bool hasKeyboardFocus)
		{
			this.Draw(position, GUIContent.Temp(text), -1, isHover, isActive, on, hasKeyboardFocus);
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0000BD71 File Offset: 0x00009F71
		public void Draw(Rect position, Texture image, bool isHover, bool isActive, bool on, bool hasKeyboardFocus)
		{
			this.Draw(position, GUIContent.Temp(image), -1, isHover, isActive, on, hasKeyboardFocus);
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0000BD8A File Offset: 0x00009F8A
		public void Draw(Rect position, GUIContent content, bool isHover, bool isActive, bool on, bool hasKeyboardFocus)
		{
			this.Draw(position, content, -1, isHover, isActive, on, hasKeyboardFocus);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0000BD9E File Offset: 0x00009F9E
		public void Draw(Rect position, GUIContent content, int controlID)
		{
			this.Draw(position, content, controlID, false, false, false, false);
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0000BDAF File Offset: 0x00009FAF
		public void Draw(Rect position, GUIContent content, int controlID, bool on)
		{
			this.Draw(position, content, controlID, false, false, on, false);
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0000BDC1 File Offset: 0x00009FC1
		public void Draw(Rect position, GUIContent content, int controlID, bool on, bool hover)
		{
			this.Draw(position, content, controlID, hover, GUIUtility.hotControl == controlID, on, GUIUtility.HasKeyFocus(controlID));
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0000BDE0 File Offset: 0x00009FE0
		private void Draw(Rect position, GUIContent content, int controlId, bool isHover, bool isActive, bool on, bool hasKeyboardFocus)
		{
			bool flag = controlId == -1;
			if (flag)
			{
				this.Internal_Draw(position, content, isHover, isActive, on, hasKeyboardFocus);
			}
			else
			{
				this.Internal_Draw2(position, content, controlId, on);
			}
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0000BE18 File Offset: 0x0000A018
		public void DrawCursor(Rect position, GUIContent content, int controlID, int character)
		{
			Event current = Event.current;
			bool flag = current.type == EventType.Repaint;
			if (flag)
			{
				Color cursorColor = new Color(0f, 0f, 0f, 0f);
				float cursorFlashSpeed = GUI.skin.settings.cursorFlashSpeed;
				float num = (Time.realtimeSinceStartup - GUIStyle.Internal_GetCursorFlashOffset()) % cursorFlashSpeed / cursorFlashSpeed;
				bool flag2 = cursorFlashSpeed == 0f || num < 0.5f;
				if (flag2)
				{
					cursorColor = GUI.skin.settings.cursorColor;
				}
				this.Internal_DrawCursor(position, content, character, cursorColor);
			}
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0000BEB0 File Offset: 0x0000A0B0
		internal void DrawWithTextSelection(Rect position, GUIContent content, bool isActive, bool hasKeyboardFocus, int firstSelectedCharacter, int lastSelectedCharacter, bool drawSelectionAsComposition, Color selectionColor)
		{
			Color cursorColor = new Color(0f, 0f, 0f, 0f);
			float cursorFlashSpeed = GUI.skin.settings.cursorFlashSpeed;
			float num = (Time.realtimeSinceStartup - GUIStyle.Internal_GetCursorFlashOffset()) % cursorFlashSpeed / cursorFlashSpeed;
			bool flag = cursorFlashSpeed == 0f || num < 0.5f;
			if (flag)
			{
				cursorColor = GUI.skin.settings.cursorColor;
			}
			bool isHover = position.Contains(Event.current.mousePosition);
			this.Internal_DrawWithTextSelection(position, content, isHover, isActive, false, hasKeyboardFocus, drawSelectionAsComposition, firstSelectedCharacter, lastSelectedCharacter, cursorColor, selectionColor);
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0000BF50 File Offset: 0x0000A150
		internal void DrawWithTextSelection(Rect position, GUIContent content, int controlID, int firstSelectedCharacter, int lastSelectedCharacter, bool drawSelectionAsComposition)
		{
			this.DrawWithTextSelection(position, content, controlID == GUIUtility.hotControl, controlID == GUIUtility.keyboardControl && GUIStyle.showKeyboardFocus, firstSelectedCharacter, lastSelectedCharacter, drawSelectionAsComposition, GUI.skin.settings.selectionColor);
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0000BF94 File Offset: 0x0000A194
		public void DrawWithTextSelection(Rect position, GUIContent content, int controlID, int firstSelectedCharacter, int lastSelectedCharacter)
		{
			this.DrawWithTextSelection(position, content, controlID, firstSelectedCharacter, lastSelectedCharacter, false);
		}

		// Token: 0x06000354 RID: 852 RVA: 0x0000BFA8 File Offset: 0x0000A1A8
		public static implicit operator GUIStyle(string str)
		{
			bool flag = GUISkin.current == null;
			GUIStyle result;
			if (flag)
			{
				Debug.LogError("Unable to use a named GUIStyle without a current skin. Most likely you need to move your GUIStyle initialization code to OnGUI");
				result = GUISkin.error;
			}
			else
			{
				result = GUISkin.current.GetStyle(str);
			}
			return result;
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000355 RID: 853 RVA: 0x0000BFE8 File Offset: 0x0000A1E8
		public static GUIStyle none
		{
			get
			{
				GUIStyle result;
				if ((result = GUIStyle.s_None) == null)
				{
					result = (GUIStyle.s_None = new GUIStyle());
				}
				return result;
			}
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0000C000 File Offset: 0x0000A200
		public Vector2 GetCursorPixelPosition(Rect position, GUIContent content, int cursorStringIndex)
		{
			return this.Internal_GetCursorPixelPosition(position, content, cursorStringIndex);
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0000C01C File Offset: 0x0000A21C
		public int GetCursorStringIndex(Rect position, GUIContent content, Vector2 cursorPixelPosition)
		{
			return this.Internal_GetCursorStringIndex(position, content, cursorPixelPosition);
		}

		// Token: 0x06000358 RID: 856 RVA: 0x0000C038 File Offset: 0x0000A238
		internal int GetNumCharactersThatFitWithinWidth(string text, float width)
		{
			return this.Internal_GetNumCharactersThatFitWithinWidth(text, width);
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0000C054 File Offset: 0x0000A254
		public Vector2 CalcSize(GUIContent content)
		{
			return this.Internal_CalcSize(content);
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0000C070 File Offset: 0x0000A270
		internal Vector2 CalcSizeWithConstraints(GUIContent content, Vector2 constraints)
		{
			return this.Internal_CalcSizeWithConstraints(content, constraints);
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0000C08C File Offset: 0x0000A28C
		public Vector2 CalcScreenSize(Vector2 contentSize)
		{
			return new Vector2((this.fixedWidth != 0f) ? this.fixedWidth : Mathf.Ceil(contentSize.x + (float)this.padding.left + (float)this.padding.right), (this.fixedHeight != 0f) ? this.fixedHeight : Mathf.Ceil(contentSize.y + (float)this.padding.top + (float)this.padding.bottom));
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0000C118 File Offset: 0x0000A318
		public float CalcHeight(GUIContent content, float width)
		{
			return this.Internal_CalcHeight(content, width);
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600035D RID: 861 RVA: 0x0000C132 File Offset: 0x0000A332
		public bool isHeightDependantOnWidth
		{
			get
			{
				return this.fixedHeight == 0f && this.wordWrap && this.imagePosition != ImagePosition.ImageOnly;
			}
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0000C15C File Offset: 0x0000A35C
		public void CalcMinMaxWidth(GUIContent content, out float minWidth, out float maxWidth)
		{
			Vector2 vector = this.Internal_CalcMinMaxWidth(content);
			minWidth = vector.x;
			maxWidth = vector.y;
		}

		// Token: 0x0600035F RID: 863 RVA: 0x0000C184 File Offset: 0x0000A384
		public override string ToString()
		{
			return UnityString.Format("GUIStyle '{0}'", new object[]
			{
				this.name
			});
		}

		// Token: 0x06000361 RID: 865
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_contentOffset_Injected(out Vector2 ret);

		// Token: 0x06000362 RID: 866
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void set_contentOffset_Injected(ref Vector2 value);

		// Token: 0x06000363 RID: 867
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_clipOffset_Injected(out Vector2 ret);

		// Token: 0x06000364 RID: 868
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void set_clipOffset_Injected(ref Vector2 value);

		// Token: 0x06000365 RID: 869
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_Internal_clipOffset_Injected(out Vector2 ret);

		// Token: 0x06000366 RID: 870
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void set_Internal_clipOffset_Injected(ref Vector2 value);

		// Token: 0x06000367 RID: 871
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Internal_Draw_Injected(ref Rect screenRect, GUIContent content, bool isHover, bool isActive, bool on, bool hasKeyboardFocus);

		// Token: 0x06000368 RID: 872
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Internal_Draw2_Injected(ref Rect position, GUIContent content, int controlID, bool on);

		// Token: 0x06000369 RID: 873
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Internal_DrawCursor_Injected(ref Rect position, GUIContent content, int pos, ref Color cursorColor);

		// Token: 0x0600036A RID: 874
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Internal_DrawWithTextSelection_Injected(ref Rect screenRect, GUIContent content, bool isHover, bool isActive, bool on, bool hasKeyboardFocus, bool drawSelectionAsComposition, int cursorFirst, int cursorLast, ref Color cursorColor, ref Color selectionColor);

		// Token: 0x0600036B RID: 875
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Internal_GetCursorPixelPosition_Injected(ref Rect position, GUIContent content, int cursorStringIndex, out Vector2 ret);

		// Token: 0x0600036C RID: 876
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int Internal_GetCursorStringIndex_Injected(ref Rect position, GUIContent content, ref Vector2 cursorPixelPosition);

		// Token: 0x0600036D RID: 877
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern string Internal_GetSelectedRenderedText_Injected(ref Rect localPosition, GUIContent mContent, int selectIndex, int cursorIndex);

		// Token: 0x0600036E RID: 878
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern Rect[] Internal_GetHyperlinksRect_Injected(ref Rect localPosition, GUIContent mContent);

		// Token: 0x0600036F RID: 879
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Internal_CalcSize_Injected(GUIContent content, out Vector2 ret);

		// Token: 0x06000370 RID: 880
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Internal_CalcSizeWithConstraints_Injected(GUIContent content, ref Vector2 maxSize, out Vector2 ret);

		// Token: 0x06000371 RID: 881
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Internal_CalcMinMaxWidth_Injected(GUIContent content, out Vector2 ret);

		// Token: 0x06000372 RID: 882
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetMouseTooltip_Injected(string tooltip, ref Rect screenRect);

		// Token: 0x040000CC RID: 204
		[NonSerialized]
		internal IntPtr m_Ptr;

		// Token: 0x040000CD RID: 205
		[NonSerialized]
		private GUIStyleState m_Normal;

		// Token: 0x040000CE RID: 206
		[NonSerialized]
		private GUIStyleState m_Hover;

		// Token: 0x040000CF RID: 207
		[NonSerialized]
		private GUIStyleState m_Active;

		// Token: 0x040000D0 RID: 208
		[NonSerialized]
		private GUIStyleState m_Focused;

		// Token: 0x040000D1 RID: 209
		[NonSerialized]
		private GUIStyleState m_OnNormal;

		// Token: 0x040000D2 RID: 210
		[NonSerialized]
		private GUIStyleState m_OnHover;

		// Token: 0x040000D3 RID: 211
		[NonSerialized]
		private GUIStyleState m_OnActive;

		// Token: 0x040000D4 RID: 212
		[NonSerialized]
		private GUIStyleState m_OnFocused;

		// Token: 0x040000D5 RID: 213
		[NonSerialized]
		private RectOffset m_Border;

		// Token: 0x040000D6 RID: 214
		[NonSerialized]
		private RectOffset m_Padding;

		// Token: 0x040000D7 RID: 215
		[NonSerialized]
		private RectOffset m_Margin;

		// Token: 0x040000D8 RID: 216
		[NonSerialized]
		private RectOffset m_Overflow;

		// Token: 0x040000D9 RID: 217
		[NonSerialized]
		private string m_Name;

		// Token: 0x040000DA RID: 218
		internal static bool showKeyboardFocus = true;

		// Token: 0x040000DB RID: 219
		private static GUIStyle s_None;
	}
}
