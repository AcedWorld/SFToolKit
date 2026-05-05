using System;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003B9 RID: 953
	public interface IHIDControllerExtension
	{
		// Token: 0x170008FE RID: 2302
		// (get) Token: 0x0600265B RID: 9819
		ushort vendorId { get; }

		// Token: 0x170008FF RID: 2303
		// (get) Token: 0x0600265C RID: 9820
		ushort productId { get; }

		// Token: 0x17000900 RID: 2304
		// (get) Token: 0x0600265D RID: 9821
		string productName { get; }

		// Token: 0x17000901 RID: 2305
		// (get) Token: 0x0600265E RID: 9822
		string manufacturer { get; }

		// Token: 0x17000902 RID: 2306
		// (get) Token: 0x0600265F RID: 9823
		ushort usagePage { get; }

		// Token: 0x17000903 RID: 2307
		// (get) Token: 0x06002660 RID: 9824
		ushort usage { get; }
	}
}
