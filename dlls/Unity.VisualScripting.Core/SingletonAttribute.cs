using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200014D RID: 333
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
	public sealed class SingletonAttribute : Attribute
	{
		// Token: 0x060008F1 RID: 2289 RVA: 0x00026F59 File Offset: 0x00025159
		public SingletonAttribute()
		{
			this.HideFlags = HideFlags.None;
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x060008F2 RID: 2290 RVA: 0x00026F68 File Offset: 0x00025168
		// (set) Token: 0x060008F3 RID: 2291 RVA: 0x00026F70 File Offset: 0x00025170
		public bool Persistent { get; set; }

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x060008F4 RID: 2292 RVA: 0x00026F79 File Offset: 0x00025179
		// (set) Token: 0x060008F5 RID: 2293 RVA: 0x00026F81 File Offset: 0x00025181
		public bool Automatic { get; set; }

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x060008F6 RID: 2294 RVA: 0x00026F8A File Offset: 0x0002518A
		// (set) Token: 0x060008F7 RID: 2295 RVA: 0x00026F92 File Offset: 0x00025192
		public HideFlags HideFlags { get; set; }

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x060008F8 RID: 2296 RVA: 0x00026F9B File Offset: 0x0002519B
		// (set) Token: 0x060008F9 RID: 2297 RVA: 0x00026FA3 File Offset: 0x000251A3
		public string Name { get; set; }
	}
}
