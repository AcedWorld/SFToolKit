using System;

namespace Rewired.Dev
{
	// Token: 0x0200053D RID: 1341
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	public class ActionIdFieldInfoAttribute : Attribute
	{
		// Token: 0x04001C99 RID: 7321
		public string categoryName;

		// Token: 0x04001C9A RID: 7322
		public string friendlyName;
	}
}
