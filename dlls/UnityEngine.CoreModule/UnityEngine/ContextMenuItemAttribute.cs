using System;

namespace UnityEngine
{
	// Token: 0x0200020C RID: 524
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
	public class ContextMenuItemAttribute : PropertyAttribute
	{
		// Token: 0x0600179E RID: 6046 RVA: 0x000274A6 File Offset: 0x000256A6
		public ContextMenuItemAttribute(string name, string function)
		{
			this.name = name;
			this.function = function;
		}

		// Token: 0x04000868 RID: 2152
		public readonly string name;

		// Token: 0x04000869 RID: 2153
		public readonly string function;
	}
}
