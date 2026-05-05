using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001F2 RID: 498
	internal struct XblLeaderboardRow
	{
		// Token: 0x06000D9F RID: 3487 RVA: 0x000105A2 File Offset: 0x0000E7A2
		public string[] GetColumnValues()
		{
			return Converters.PtrToClassArray<string, UTF8StringPtr>(this.columnValues, this.columnValuesCount, (UTF8StringPtr s) => s.GetString());
		}

		// Token: 0x06000DA0 RID: 3488 RVA: 0x000105D4 File Offset: 0x0000E7D4
		internal XblLeaderboardRow(XblLeaderboardRow row, DisposableCollection disposableCollection)
		{
			this.gamertag = Converters.StringToNullTerminatedUTF8ByteArray(row.Gamertag, 48);
			this.modernGamertag = Converters.StringToNullTerminatedUTF8ByteArray(row.ModernGamertag, 97);
			this.modernGamertagSuffix = Converters.StringToNullTerminatedUTF8ByteArray(row.ModernGamertagSuffix, 15);
			this.uniqueModernGamertag = Converters.StringToNullTerminatedUTF8ByteArray(row.UniqueModernGamertag, 101);
			this.xboxUserId = row.XboxUserId;
			this.percentile = row.Percentile;
			this.rank = row.Rank;
			this.globalRank = row.GlobalRank;
			this.columnValues = Converters.ClassArrayToPtr<string, UTF8StringPtr>(row.ColumnValues, (string s, DisposableCollection dc) => new UTF8StringPtr(s, dc), disposableCollection, out this.columnValuesCount);
		}

		// Token: 0x0400069F RID: 1695
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
		internal readonly byte[] gamertag;

		// Token: 0x040006A0 RID: 1696
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 97)]
		internal readonly byte[] modernGamertag;

		// Token: 0x040006A1 RID: 1697
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
		internal readonly byte[] modernGamertagSuffix;

		// Token: 0x040006A2 RID: 1698
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 101)]
		internal readonly byte[] uniqueModernGamertag;

		// Token: 0x040006A3 RID: 1699
		internal readonly ulong xboxUserId;

		// Token: 0x040006A4 RID: 1700
		internal readonly double percentile;

		// Token: 0x040006A5 RID: 1701
		internal readonly uint rank;

		// Token: 0x040006A6 RID: 1702
		internal readonly uint globalRank;

		// Token: 0x040006A7 RID: 1703
		private readonly IntPtr columnValues;

		// Token: 0x040006A8 RID: 1704
		private readonly SizeT columnValuesCount;
	}
}
