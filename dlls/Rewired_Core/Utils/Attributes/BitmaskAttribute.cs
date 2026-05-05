using System;
using UnityEngine;

namespace Rewired.Utils.Attributes
{
	// Token: 0x02000536 RID: 1334
	public class BitmaskAttribute : PropertyAttribute
	{
		// Token: 0x06003664 RID: 13924 RVA: 0x0002A704 File Offset: 0x00028904
		public BitmaskAttribute(Type A_1)
		{
			this.propType = A_1;
		}

		// Token: 0x04001C8C RID: 7308
		public Type propType;
	}
}
