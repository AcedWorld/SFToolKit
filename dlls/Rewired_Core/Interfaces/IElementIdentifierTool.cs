using System;
using Rewired.Internal;

namespace Rewired.Interfaces
{
	// Token: 0x020001E6 RID: 486
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	internal interface IElementIdentifierTool
	{
		// Token: 0x060018C2 RID: 6338
		void Initialize(GUIText guiText);

		// Token: 0x060018C3 RID: 6339
		void Start();

		// Token: 0x060018C4 RID: 6340
		void Update();

		// Token: 0x060018C5 RID: 6341
		void OnDestroy();
	}
}
