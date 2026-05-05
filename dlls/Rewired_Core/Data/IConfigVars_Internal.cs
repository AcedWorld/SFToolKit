using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Data
{
	// Token: 0x0200029A RID: 666
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	internal interface IConfigVars_Internal
	{
		// Token: 0x170006BE RID: 1726
		// (get) Token: 0x06001E3C RID: 7740
		KeyedGetSetValueStore<string> values { get; }
	}
}
