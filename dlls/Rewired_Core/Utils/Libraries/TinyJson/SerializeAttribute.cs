using System;

namespace Rewired.Utils.Libraries.TinyJson
{
	// Token: 0x020004B7 RID: 1207
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	public class SerializeAttribute : Attribute
	{
		// Token: 0x04001AC6 RID: 6854
		public string Name;
	}
}
