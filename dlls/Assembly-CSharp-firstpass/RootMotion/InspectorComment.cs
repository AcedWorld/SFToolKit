using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x02000025 RID: 37
	public class InspectorComment : PropertyAttribute
	{
		// Token: 0x060000C7 RID: 199 RVA: 0x0000689D File Offset: 0x00004A9D
		public InspectorComment(string name)
		{
			this.name = name;
			this.color = "white";
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x000068C2 File Offset: 0x00004AC2
		public InspectorComment(string name, string color)
		{
			this.name = name;
			this.color = color;
		}

		// Token: 0x040000E9 RID: 233
		public string name;

		// Token: 0x040000EA RID: 234
		public string color = "white";
	}
}
