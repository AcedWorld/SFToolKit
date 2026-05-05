using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x0200034E RID: 846
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
	public class vButtonAttribute : PropertyAttribute
	{
		// Token: 0x06001152 RID: 4434 RVA: 0x0005DBF0 File Offset: 0x0005BDF0
		public vButtonAttribute(string label, string function, Type type, bool enabledJustInPlayMode = true)
		{
			this.label = label;
			this.function = function;
			this.type = type;
			this.enabledJustInPlayMode = enabledJustInPlayMode;
		}

		// Token: 0x04001742 RID: 5954
		public readonly string label;

		// Token: 0x04001743 RID: 5955
		public readonly string function;

		// Token: 0x04001744 RID: 5956
		public readonly int id;

		// Token: 0x04001745 RID: 5957
		public readonly Type type;

		// Token: 0x04001746 RID: 5958
		public readonly bool enabledJustInPlayMode;
	}
}
