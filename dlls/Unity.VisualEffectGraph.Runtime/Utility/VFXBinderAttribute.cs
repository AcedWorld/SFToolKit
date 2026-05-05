using System;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x0200003D RID: 61
	[AttributeUsage(AttributeTargets.Class)]
	public class VFXBinderAttribute : PropertyAttribute
	{
		// Token: 0x0600018A RID: 394 RVA: 0x00008F2F File Offset: 0x0000712F
		public VFXBinderAttribute(string menuPath)
		{
			this.MenuPath = menuPath;
		}

		// Token: 0x0400010F RID: 271
		public string MenuPath;
	}
}
