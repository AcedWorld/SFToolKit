using System;
using Rewired.Data;
using Rewired.Interfaces;

namespace Rewired
{
	// Token: 0x0200001A RID: 26
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal abstract class PlatformInitializer
	{
		// Token: 0x0600016C RID: 364
		public abstract object Initialize(IConfigVars_Internal configVars);

		// Token: 0x0600016D RID: 365
		public abstract IElementIdentifierTool CreateTool(string inputSourceString);
	}
}
