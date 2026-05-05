using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000E8 RID: 232
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class VolumeComponentMenu : Attribute
	{
		// Token: 0x060007AA RID: 1962 RVA: 0x000255DC File Offset: 0x000237DC
		public VolumeComponentMenu(string menu)
		{
			this.menu = menu;
		}

		// Token: 0x040004C8 RID: 1224
		public readonly string menu;
	}
}
