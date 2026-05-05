using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001EF RID: 495
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public sealed class SkyUniqueID : Attribute
	{
		// Token: 0x06000F1D RID: 3869 RVA: 0x00076FF5 File Offset: 0x000751F5
		public SkyUniqueID(int uniqueID)
		{
			this.uniqueID = uniqueID;
		}

		// Token: 0x0400179E RID: 6046
		internal readonly int uniqueID;
	}
}
