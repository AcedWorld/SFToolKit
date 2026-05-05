using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace UnityEngine.UIElements.StyleSheets
{
	// Token: 0x0200049C RID: 1180
	[DebuggerDisplay("id = {id}, keyword = {keyword}, number = {number}, boolean = {boolean}, color = {color}, object = {resource}")]
	[StructLayout(LayoutKind.Explicit)]
	internal struct StyleValue
	{
		// Token: 0x040011AF RID: 4527
		[FieldOffset(0)]
		public StylePropertyId id;

		// Token: 0x040011B0 RID: 4528
		[FieldOffset(4)]
		public StyleKeyword keyword;

		// Token: 0x040011B1 RID: 4529
		[FieldOffset(8)]
		public float number;

		// Token: 0x040011B2 RID: 4530
		[FieldOffset(8)]
		public Length length;

		// Token: 0x040011B3 RID: 4531
		[FieldOffset(8)]
		public Color color;

		// Token: 0x040011B4 RID: 4532
		[FieldOffset(8)]
		public GCHandle resource;

		// Token: 0x040011B5 RID: 4533
		[FieldOffset(8)]
		public BackgroundPosition position;

		// Token: 0x040011B6 RID: 4534
		[FieldOffset(8)]
		public BackgroundRepeat repeat;
	}
}
