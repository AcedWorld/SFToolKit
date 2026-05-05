using System;

namespace Invector
{
	// Token: 0x0200034F RID: 847
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
	public sealed class vClassHeaderAttribute : Attribute
	{
		// Token: 0x06001153 RID: 4435 RVA: 0x0005DC15 File Offset: 0x0005BE15
		public vClassHeaderAttribute(string header, bool openClose = true, string iconName = "icon_v2", bool useHelpBox = false, string helpBoxText = "")
		{
			this.header = header.ToUpper();
			this.openClose = openClose;
			this.iconName = iconName;
			this.useHelpBox = useHelpBox;
			this.helpBoxText = helpBoxText;
		}

		// Token: 0x06001154 RID: 4436 RVA: 0x0005DC47 File Offset: 0x0005BE47
		public vClassHeaderAttribute(string header, string helpBoxText)
		{
			this.header = header.ToUpper();
			this.openClose = true;
			this.iconName = "icon_v2";
			this.useHelpBox = true;
			this.helpBoxText = helpBoxText;
		}

		// Token: 0x04001747 RID: 5959
		public string header;

		// Token: 0x04001748 RID: 5960
		public bool openClose;

		// Token: 0x04001749 RID: 5961
		public string iconName;

		// Token: 0x0400174A RID: 5962
		public bool useHelpBox;

		// Token: 0x0400174B RID: 5963
		public string helpBoxText;
	}
}
