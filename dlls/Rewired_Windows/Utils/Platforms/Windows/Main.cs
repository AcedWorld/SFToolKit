using System;
using System.ComponentModel;
using Rewired.InputManagers;

namespace Rewired.Utils.Platforms.Windows
{
	// Token: 0x020000DD RID: 221
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class Main
	{
		// Token: 0x06000740 RID: 1856 RVA: 0x00014EDA File Offset: 0x000130DA
		public static object GetPlatformInitializer()
		{
			return Initializer.GetPlatformInitializer();
		}
	}
}
