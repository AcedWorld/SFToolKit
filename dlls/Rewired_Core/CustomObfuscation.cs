using System;
using System.Runtime.InteropServices;

namespace Rewired
{
	// Token: 0x020000E4 RID: 228
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
	[ComVisible(false)]
	internal sealed class CustomObfuscation : Attribute
	{
		// Token: 0x04000617 RID: 1559
		public bool rename;
	}
}
