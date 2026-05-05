using System;

namespace Rewired.Internal.Glyphs
{
	// Token: 0x02000459 RID: 1113
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal interface ITryGetGlyph
	{
		// Token: 0x06002C74 RID: 11380
		bool TryGetGlyph(out object value);
	}
}
