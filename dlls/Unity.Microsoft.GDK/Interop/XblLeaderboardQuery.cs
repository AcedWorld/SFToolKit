using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001F0 RID: 496
	internal struct XblLeaderboardQuery
	{
		// Token: 0x06000D98 RID: 3480 RVA: 0x00010391 File Offset: 0x0000E591
		internal string[] GetAdditionalColumnleaderboardNames()
		{
			return Converters.PtrToClassArray<string, UTF8StringPtr>(this.additionalColumnleaderboardNames, this.additionalColumnleaderboardNamesCount, (UTF8StringPtr s) => s.GetString());
		}

		// Token: 0x06000D99 RID: 3481 RVA: 0x000103C4 File Offset: 0x0000E5C4
		internal unsafe string GetScid()
		{
			fixed (byte* ptr = &this.scid.FixedElementField)
			{
				return Converters.BytePointerToString(ptr, 40);
			}
		}

		// Token: 0x06000D9A RID: 3482 RVA: 0x000103E8 File Offset: 0x0000E5E8
		internal unsafe XblLeaderboardQuery(XblLeaderboardQuery query, DisposableCollection disposableCollection)
		{
			this.xboxUserId = query.XboxUserId;
			fixed (byte* ptr = &this.scid.FixedElementField)
			{
				byte* bytePointer = ptr;
				Converters.StringToNullTerminatedUTF8FixedPointer(query.ServiceConfigurationId, bytePointer, 40);
			}
			this.leaderboardName = new UTF8StringPtr(query.LeaderboardName, disposableCollection);
			this.statName = new UTF8StringPtr(query.StatName, disposableCollection);
			this.socialGroup = query.SocialGroup;
			this.additionalColumnleaderboardNames = Converters.StringArrayToUTF8StringArray(query.AdditionalColumnleaderboardNames, disposableCollection, out this.additionalColumnleaderboardNamesCount);
			this.order = query.Order;
			this.maxItems = query.MaxItems;
			this.skipToXboxUserId = query.SkipToXboxUserId;
			this.skipResultToRank = query.SkipResultToRank;
			this.continuationToken = new UTF8StringPtr(query.ContinuationToken, disposableCollection);
			this.queryType = query.QueryType;
		}

		// Token: 0x06000D9B RID: 3483 RVA: 0x000104B7 File Offset: 0x0000E6B7
		internal static bool ValidateFields(string scid)
		{
			return scid != null && Converters.StringToNullTerminatedUTF8ByteArray(scid).Length <= 40;
		}

		// Token: 0x0400068B RID: 1675
		internal readonly ulong xboxUserId;

		// Token: 0x0400068C RID: 1676
		[FixedBuffer(typeof(byte), 40)]
		private XblLeaderboardQuery.<scid>e__FixedBuffer scid;

		// Token: 0x0400068D RID: 1677
		internal readonly UTF8StringPtr leaderboardName;

		// Token: 0x0400068E RID: 1678
		internal readonly UTF8StringPtr statName;

		// Token: 0x0400068F RID: 1679
		internal readonly XblSocialGroupType socialGroup;

		// Token: 0x04000690 RID: 1680
		private readonly IntPtr additionalColumnleaderboardNames;

		// Token: 0x04000691 RID: 1681
		private readonly SizeT additionalColumnleaderboardNamesCount;

		// Token: 0x04000692 RID: 1682
		internal readonly XblLeaderboardSortOrder order;

		// Token: 0x04000693 RID: 1683
		internal readonly uint maxItems;

		// Token: 0x04000694 RID: 1684
		internal readonly ulong skipToXboxUserId;

		// Token: 0x04000695 RID: 1685
		internal readonly uint skipResultToRank;

		// Token: 0x04000696 RID: 1686
		internal readonly UTF8StringPtr continuationToken;

		// Token: 0x04000697 RID: 1687
		internal readonly XblLeaderboardQueryType queryType;

		// Token: 0x0200032E RID: 814
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 40)]
		public struct <scid>e__FixedBuffer
		{
			// Token: 0x040009A1 RID: 2465
			public byte FixedElementField;
		}
	}
}
