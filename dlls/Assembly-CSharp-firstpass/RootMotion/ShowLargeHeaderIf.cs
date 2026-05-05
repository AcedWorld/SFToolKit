using System;

namespace RootMotion
{
	// Token: 0x0200002D RID: 45
	public class ShowLargeHeaderIf : ShowIfAttribute
	{
		// Token: 0x06000108 RID: 264 RVA: 0x0000748B File Offset: 0x0000568B
		public ShowLargeHeaderIf(string name, string propertyName, object propertyValue = null, object otherPropertyValue = null, bool indent = false, ShowIfMode mode = ShowIfMode.Hidden) : base(propertyName, propertyValue, otherPropertyValue, indent, mode)
		{
			this.name = name;
			this.color = "white";
		}

		// Token: 0x06000109 RID: 265 RVA: 0x000074B8 File Offset: 0x000056B8
		public ShowLargeHeaderIf(string name, string color, string propertyName, object propertyValue = null, object otherPropertyValue = null, bool indent = false, ShowIfMode mode = ShowIfMode.Hidden) : base(propertyName, propertyValue, otherPropertyValue, indent, mode)
		{
			this.name = name;
			this.color = color;
		}

		// Token: 0x04000112 RID: 274
		public string name;

		// Token: 0x04000113 RID: 275
		public string color = "white";
	}
}
