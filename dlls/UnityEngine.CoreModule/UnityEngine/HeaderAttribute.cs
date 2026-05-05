using System;

namespace UnityEngine
{
	// Token: 0x02000210 RID: 528
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
	public class HeaderAttribute : PropertyAttribute
	{
		// Token: 0x060017A3 RID: 6051 RVA: 0x00027506 File Offset: 0x00025706
		public HeaderAttribute(string header)
		{
			this.header = header;
		}

		// Token: 0x0400086D RID: 2157
		public readonly string header;
	}
}
