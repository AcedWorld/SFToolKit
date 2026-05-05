using System;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x0200020D RID: 525
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	[UsedByNativeCode]
	public class InspectorNameAttribute : PropertyAttribute
	{
		// Token: 0x0600179F RID: 6047 RVA: 0x000274BE File Offset: 0x000256BE
		public InspectorNameAttribute(string displayName)
		{
			this.displayName = displayName;
		}

		// Token: 0x0400086A RID: 2154
		public readonly string displayName;
	}
}
