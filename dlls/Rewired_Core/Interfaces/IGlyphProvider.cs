using System;

namespace Rewired.Interfaces
{
	// Token: 0x020001F8 RID: 504
	public interface IGlyphProvider
	{
		// Token: 0x06001924 RID: 6436
		bool TryGetGlyph(string key, out object result);
	}
}
