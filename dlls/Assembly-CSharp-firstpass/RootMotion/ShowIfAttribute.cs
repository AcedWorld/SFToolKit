using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x0200002B RID: 43
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public class ShowIfAttribute : PropertyAttribute
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x000073C8 File Offset: 0x000055C8
		// (set) Token: 0x060000F9 RID: 249 RVA: 0x000073D0 File Offset: 0x000055D0
		public string propName { get; protected set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000FA RID: 250 RVA: 0x000073D9 File Offset: 0x000055D9
		// (set) Token: 0x060000FB RID: 251 RVA: 0x000073E1 File Offset: 0x000055E1
		public object propValue { get; protected set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000FC RID: 252 RVA: 0x000073EA File Offset: 0x000055EA
		// (set) Token: 0x060000FD RID: 253 RVA: 0x000073F2 File Offset: 0x000055F2
		public object otherPropValue { get; protected set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000FE RID: 254 RVA: 0x000073FB File Offset: 0x000055FB
		// (set) Token: 0x060000FF RID: 255 RVA: 0x00007403 File Offset: 0x00005603
		public bool indent { get; private set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000100 RID: 256 RVA: 0x0000740C File Offset: 0x0000560C
		// (set) Token: 0x06000101 RID: 257 RVA: 0x00007414 File Offset: 0x00005614
		public ShowIfMode mode { get; protected set; }

		// Token: 0x06000102 RID: 258 RVA: 0x0000741D File Offset: 0x0000561D
		public ShowIfAttribute(string propertyName, object propertyValue = null, object otherPropertyValue = null, bool indent = false, ShowIfMode mode = ShowIfMode.Hidden)
		{
			this.propName = propertyName;
			this.propValue = propertyValue;
			this.otherPropValue = otherPropertyValue;
			this.indent = indent;
			this.mode = mode;
		}
	}
}
