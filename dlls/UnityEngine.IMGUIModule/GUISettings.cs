using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x02000025 RID: 37
	[NativeHeader("Modules/IMGUI/GUISkin.bindings.h")]
	[Serializable]
	public sealed class GUISettings
	{
		// Token: 0x06000290 RID: 656
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float Internal_GetCursorFlashSpeed();

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000291 RID: 657 RVA: 0x0000A744 File Offset: 0x00008944
		// (set) Token: 0x06000292 RID: 658 RVA: 0x0000A75C File Offset: 0x0000895C
		public bool doubleClickSelectsWord
		{
			get
			{
				return this.m_DoubleClickSelectsWord;
			}
			set
			{
				this.m_DoubleClickSelectsWord = value;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000293 RID: 659 RVA: 0x0000A768 File Offset: 0x00008968
		// (set) Token: 0x06000294 RID: 660 RVA: 0x0000A780 File Offset: 0x00008980
		public bool tripleClickSelectsLine
		{
			get
			{
				return this.m_TripleClickSelectsLine;
			}
			set
			{
				this.m_TripleClickSelectsLine = value;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000295 RID: 661 RVA: 0x0000A78C File Offset: 0x0000898C
		// (set) Token: 0x06000296 RID: 662 RVA: 0x0000A7A4 File Offset: 0x000089A4
		public Color cursorColor
		{
			get
			{
				return this.m_CursorColor;
			}
			set
			{
				this.m_CursorColor = value;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000297 RID: 663 RVA: 0x0000A7B0 File Offset: 0x000089B0
		// (set) Token: 0x06000298 RID: 664 RVA: 0x0000A7E5 File Offset: 0x000089E5
		public float cursorFlashSpeed
		{
			get
			{
				bool flag = this.m_CursorFlashSpeed >= 0f;
				float result;
				if (flag)
				{
					result = this.m_CursorFlashSpeed;
				}
				else
				{
					result = GUISettings.Internal_GetCursorFlashSpeed();
				}
				return result;
			}
			set
			{
				this.m_CursorFlashSpeed = value;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000299 RID: 665 RVA: 0x0000A7F0 File Offset: 0x000089F0
		// (set) Token: 0x0600029A RID: 666 RVA: 0x0000A808 File Offset: 0x00008A08
		public Color selectionColor
		{
			get
			{
				return this.m_SelectionColor;
			}
			set
			{
				this.m_SelectionColor = value;
			}
		}

		// Token: 0x040000A2 RID: 162
		[SerializeField]
		private bool m_DoubleClickSelectsWord = true;

		// Token: 0x040000A3 RID: 163
		[SerializeField]
		private bool m_TripleClickSelectsLine = true;

		// Token: 0x040000A4 RID: 164
		[SerializeField]
		private Color m_CursorColor = Color.white;

		// Token: 0x040000A5 RID: 165
		[SerializeField]
		private float m_CursorFlashSpeed = -1f;

		// Token: 0x040000A6 RID: 166
		[SerializeField]
		private Color m_SelectionColor = new Color(0.5f, 0.5f, 1f);
	}
}
