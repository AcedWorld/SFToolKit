using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200003B RID: 59
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple = false)]
	public class DisplayInfoAttribute : Attribute
	{
		// Token: 0x04000146 RID: 326
		public string name;

		// Token: 0x04000147 RID: 327
		public int order;
	}
}
