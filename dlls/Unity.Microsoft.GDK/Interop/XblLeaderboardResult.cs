using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001F1 RID: 497
	internal struct XblLeaderboardResult
	{
		// Token: 0x06000D9C RID: 3484 RVA: 0x000104CD File Offset: 0x0000E6CD
		internal T[] GetColumns<T>(Func<XblLeaderboardColumn, T> ctor)
		{
			return Converters.PtrToClassArray<T, XblLeaderboardColumn>(this.columns, this.columnsCount, ctor);
		}

		// Token: 0x06000D9D RID: 3485 RVA: 0x000104E1 File Offset: 0x0000E6E1
		internal T[] GetRows<T>(Func<XblLeaderboardRow, T> ctor)
		{
			return Converters.PtrToClassArray<T, XblLeaderboardRow>(this.rows, this.rowsCount, ctor);
		}

		// Token: 0x06000D9E RID: 3486 RVA: 0x000104F8 File Offset: 0x0000E6F8
		internal XblLeaderboardResult(XblLeaderboardResult result, DisposableCollection disposableCollection)
		{
			this.totalRowCount = result.TotalRowCount;
			this.columns = Converters.ClassArrayToPtr<XblLeaderboardColumn, XblLeaderboardColumn>(result.Columns, (XblLeaderboardColumn c, DisposableCollection dc) => new XblLeaderboardColumn(c, dc), disposableCollection, out this.columnsCount);
			this.rows = Converters.ClassArrayToPtr<XblLeaderboardRow, XblLeaderboardRow>(result.Rows, (XblLeaderboardRow r, DisposableCollection dc) => new XblLeaderboardRow(r, dc), disposableCollection, out this.rowsCount);
			this.hasNext = new NativeBool(result.HasNext);
			this.nextQuery = new XblLeaderboardQuery(result.NextQuery, disposableCollection);
		}

		// Token: 0x04000698 RID: 1688
		internal readonly uint totalRowCount;

		// Token: 0x04000699 RID: 1689
		private readonly IntPtr columns;

		// Token: 0x0400069A RID: 1690
		private readonly SizeT columnsCount;

		// Token: 0x0400069B RID: 1691
		private readonly IntPtr rows;

		// Token: 0x0400069C RID: 1692
		private readonly SizeT rowsCount;

		// Token: 0x0400069D RID: 1693
		internal readonly NativeBool hasNext;

		// Token: 0x0400069E RID: 1694
		internal readonly XblLeaderboardQuery nextQuery;
	}
}
