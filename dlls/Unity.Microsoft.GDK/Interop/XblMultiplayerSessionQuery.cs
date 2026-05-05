using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000204 RID: 516
	internal struct XblMultiplayerSessionQuery
	{
		// Token: 0x06000DB3 RID: 3507 RVA: 0x000109AC File Offset: 0x0000EBAC
		internal XblMultiplayerSessionQuery(XblMultiplayerSessionQuery publicObject, DisposableCollection disposableCollection)
		{
			this.Scid = Converters.StringToNullTerminatedUTF8ByteArray(publicObject.Scid ?? "", 40);
			this.MaxItems = publicObject.MaxItems;
			this.IncludePrivateSessions = publicObject.IncludePrivateSessions;
			this.IncludeReservations = publicObject.IncludeReservations;
			this.IncludeInactiveSessions = publicObject.IncludeInactiveSessions;
			this.XuidFilters = Converters.ClassArrayToPtr<ulong, ulong>(publicObject.XuidFilters, (ulong x, DisposableCollection dc) => x, disposableCollection, out this.XuidFiltersCount);
			this.KeywordFilter = new UTF8StringPtr(publicObject.KeywordFilter, disposableCollection);
			this.SessionTemplateNameFilter = Converters.StringToNullTerminatedUTF8ByteArray(publicObject.SessionTemplateNameFilter ?? "", 100);
			this.VisibilityFilter = publicObject.VisibilityFilter;
			this.ContractVersionFilter = publicObject.ContractVersionFilter;
		}

		// Token: 0x04000708 RID: 1800
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
		internal readonly byte[] Scid;

		// Token: 0x04000709 RID: 1801
		private uint MaxItems;

		// Token: 0x0400070A RID: 1802
		[MarshalAs(UnmanagedType.U1)]
		internal bool IncludePrivateSessions;

		// Token: 0x0400070B RID: 1803
		[MarshalAs(UnmanagedType.U1)]
		internal bool IncludeReservations;

		// Token: 0x0400070C RID: 1804
		[MarshalAs(UnmanagedType.U1)]
		internal bool IncludeInactiveSessions;

		// Token: 0x0400070D RID: 1805
		private readonly IntPtr XuidFilters;

		// Token: 0x0400070E RID: 1806
		private SizeT XuidFiltersCount;

		// Token: 0x0400070F RID: 1807
		internal UTF8StringPtr KeywordFilter;

		// Token: 0x04000710 RID: 1808
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
		internal readonly byte[] SessionTemplateNameFilter;

		// Token: 0x04000711 RID: 1809
		private XblMultiplayerSessionVisibility VisibilityFilter;

		// Token: 0x04000712 RID: 1810
		private uint ContractVersionFilter;
	}
}
