using System;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x0200022D RID: 557
	[RequiredByNativeCode]
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public sealed class ContextMenu : Attribute
	{
		// Token: 0x0600184F RID: 6223 RVA: 0x00028553 File Offset: 0x00026753
		public ContextMenu(string itemName) : this(itemName, false)
		{
		}

		// Token: 0x06001850 RID: 6224 RVA: 0x0002855F File Offset: 0x0002675F
		public ContextMenu(string itemName, bool isValidateFunction) : this(itemName, isValidateFunction, 1000000)
		{
		}

		// Token: 0x06001851 RID: 6225 RVA: 0x00028570 File Offset: 0x00026770
		public ContextMenu(string itemName, bool isValidateFunction, int priority)
		{
			this.menuItem = itemName;
			this.validate = isValidateFunction;
			this.priority = priority;
		}

		// Token: 0x04000893 RID: 2195
		public readonly string menuItem;

		// Token: 0x04000894 RID: 2196
		public readonly bool validate;

		// Token: 0x04000895 RID: 2197
		public readonly int priority;
	}
}
