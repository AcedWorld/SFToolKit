using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001E1 RID: 481
	public interface IMouseEvent
	{
		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x06000E68 RID: 3688
		EventModifiers modifiers { get; }

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x06000E69 RID: 3689
		Vector2 mousePosition { get; }

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x06000E6A RID: 3690
		Vector2 localMousePosition { get; }

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06000E6B RID: 3691
		Vector2 mouseDelta { get; }

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x06000E6C RID: 3692
		int clickCount { get; }

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06000E6D RID: 3693
		int button { get; }

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06000E6E RID: 3694
		int pressedButtons { get; }

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06000E6F RID: 3695
		bool shiftKey { get; }

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x06000E70 RID: 3696
		bool ctrlKey { get; }

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x06000E71 RID: 3697
		bool commandKey { get; }

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x06000E72 RID: 3698
		bool altKey { get; }

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06000E73 RID: 3699
		bool actionKey { get; }
	}
}
