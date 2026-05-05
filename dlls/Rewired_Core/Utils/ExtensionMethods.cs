using System;
using UnityEngine;

namespace Rewired.Utils
{
	// Token: 0x0200047F RID: 1151
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class ExtensionMethods
	{
		// Token: 0x06002D87 RID: 11655 RVA: 0x000231A1 File Offset: 0x000213A1
		public static bool IsNullOrDestroyed(this object @object)
		{
			return @object == null || (@object is Object && (Object)@object == null);
		}
	}
}
