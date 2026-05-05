using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x0200002E RID: 46
	public class LargeHeader : PropertyAttribute
	{
		// Token: 0x0600010A RID: 266 RVA: 0x000074E2 File Offset: 0x000056E2
		public LargeHeader(string name)
		{
			this.name = name;
			this.color = "white";
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00007507 File Offset: 0x00005707
		public LargeHeader(string name, string color)
		{
			this.name = name;
			this.color = color;
		}

		// Token: 0x04000114 RID: 276
		public string name;

		// Token: 0x04000115 RID: 277
		public string color = "white";
	}
}
