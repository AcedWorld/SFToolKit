using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200028B RID: 651
	[Flags]
	internal enum VersionChangeType
	{
		// Token: 0x04000840 RID: 2112
		Bindings = 1,
		// Token: 0x04000841 RID: 2113
		ViewData = 2,
		// Token: 0x04000842 RID: 2114
		Hierarchy = 4,
		// Token: 0x04000843 RID: 2115
		Layout = 8,
		// Token: 0x04000844 RID: 2116
		StyleSheet = 16,
		// Token: 0x04000845 RID: 2117
		Styles = 32,
		// Token: 0x04000846 RID: 2118
		Overflow = 64,
		// Token: 0x04000847 RID: 2119
		BorderRadius = 128,
		// Token: 0x04000848 RID: 2120
		BorderWidth = 256,
		// Token: 0x04000849 RID: 2121
		Transform = 512,
		// Token: 0x0400084A RID: 2122
		Size = 1024,
		// Token: 0x0400084B RID: 2123
		Repaint = 2048,
		// Token: 0x0400084C RID: 2124
		Opacity = 4096,
		// Token: 0x0400084D RID: 2125
		Color = 8192,
		// Token: 0x0400084E RID: 2126
		RenderHints = 16384,
		// Token: 0x0400084F RID: 2127
		TransitionProperty = 32768,
		// Token: 0x04000850 RID: 2128
		EventCallbackCategories = 65536,
		// Token: 0x04000851 RID: 2129
		Picking = 1048576
	}
}
