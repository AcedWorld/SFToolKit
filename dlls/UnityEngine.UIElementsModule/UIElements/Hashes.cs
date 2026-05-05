using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine.UIElements
{
	// Token: 0x0200034A RID: 842
	internal struct Hashes
	{
		// Token: 0x04000BAC RID: 2988
		public const int kSize = 4;

		// Token: 0x04000BAD RID: 2989
		[FixedBuffer(typeof(int), 4)]
		public Hashes.<hashes>e__FixedBuffer hashes;

		// Token: 0x0200034B RID: 843
		[UnsafeValueType]
		[CompilerGenerated]
		[StructLayout(LayoutKind.Sequential, Size = 16)]
		public struct <hashes>e__FixedBuffer
		{
			// Token: 0x04000BAE RID: 2990
			public int FixedElementField;
		}
	}
}
