using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000352 RID: 850
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
	public class vReadOnlyAttribute : PropertyAttribute
	{
		// Token: 0x06001159 RID: 4441 RVA: 0x0005DCCF File Offset: 0x0005BECF
		public vReadOnlyAttribute(bool justInPlayMode = true)
		{
			this.justInPlayMode = justInPlayMode;
		}

		// Token: 0x04001754 RID: 5972
		public readonly bool justInPlayMode;
	}
}
