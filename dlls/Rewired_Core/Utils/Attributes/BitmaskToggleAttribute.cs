using System;
using UnityEngine;

namespace Rewired.Utils.Attributes
{
	// Token: 0x02000537 RID: 1335
	public class BitmaskToggleAttribute : PropertyAttribute
	{
		// Token: 0x06003665 RID: 13925 RVA: 0x0002A713 File Offset: 0x00028913
		public BitmaskToggleAttribute(Type A_1)
		{
			this.propType = A_1;
		}

		// Token: 0x04001C8D RID: 7309
		public Type propType;

		// Token: 0x04001C8E RID: 7310
		public bool showNone = true;

		// Token: 0x04001C8F RID: 7311
		public bool showAll = true;
	}
}
