using System;
using System.Runtime.InteropServices;

namespace Rewired
{
	// Token: 0x020000E5 RID: 229
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
	[ComVisible(false)]
	internal sealed class CustomClassObfuscation : Attribute
	{
		// Token: 0x04000618 RID: 1560
		public bool renamePubIntMembers;

		// Token: 0x04000619 RID: 1561
		public bool renamePrivateMembers = true;
	}
}
