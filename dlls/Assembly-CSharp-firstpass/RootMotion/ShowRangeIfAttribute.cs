using System;

namespace RootMotion
{
	// Token: 0x0200002C RID: 44
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public class ShowRangeIfAttribute : ShowIfAttribute
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000103 RID: 259 RVA: 0x0000744A File Offset: 0x0000564A
		// (set) Token: 0x06000104 RID: 260 RVA: 0x00007452 File Offset: 0x00005652
		public float min { get; private set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000105 RID: 261 RVA: 0x0000745B File Offset: 0x0000565B
		// (set) Token: 0x06000106 RID: 262 RVA: 0x00007463 File Offset: 0x00005663
		public float max { get; private set; }

		// Token: 0x06000107 RID: 263 RVA: 0x0000746C File Offset: 0x0000566C
		public ShowRangeIfAttribute(float min, float max, string propertyName, object propertyValue = null, object otherPropertyValue = null, bool indent = false, ShowIfMode mode = ShowIfMode.Hidden) : base(propertyName, propertyValue, otherPropertyValue, indent, mode)
		{
			this.min = min;
			this.max = max;
		}
	}
}
