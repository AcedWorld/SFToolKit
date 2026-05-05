using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001DB RID: 475
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public sealed class CloudUniqueID : Attribute
	{
		// Token: 0x06000E6C RID: 3692 RVA: 0x000729B4 File Offset: 0x00070BB4
		public CloudUniqueID(int uniqueID)
		{
			this.uniqueID = uniqueID;
		}

		// Token: 0x040016BE RID: 5822
		internal readonly int uniqueID;
	}
}
