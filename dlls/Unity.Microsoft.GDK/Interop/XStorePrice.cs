using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000271 RID: 625
	internal struct XStorePrice
	{
		// Token: 0x04000862 RID: 2146
		internal float basePrice;

		// Token: 0x04000863 RID: 2147
		internal float price;

		// Token: 0x04000864 RID: 2148
		internal float recurrencePrice;

		// Token: 0x04000865 RID: 2149
		[MarshalAs(UnmanagedType.LPStr)]
		internal string currencyCode;

		// Token: 0x04000866 RID: 2150
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
		internal string formattedBasePrice;

		// Token: 0x04000867 RID: 2151
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
		internal string formattedPrice;

		// Token: 0x04000868 RID: 2152
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
		internal string formattedRecurrencePrice;

		// Token: 0x04000869 RID: 2153
		[MarshalAs(UnmanagedType.I1)]
		internal bool isOnSale;

		// Token: 0x0400086A RID: 2154
		internal long saleEndDate;
	}
}
