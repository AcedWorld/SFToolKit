using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000200 RID: 512
	internal struct XblMultiplayerSessionMember
	{
		// Token: 0x06000DA7 RID: 3495 RVA: 0x000107EC File Offset: 0x0000E9EC
		internal unsafe string GetGamertag()
		{
			fixed (byte* ptr = &this.Gamertag.FixedElementField)
			{
				return Converters.BytePointerToString(ptr, 97);
			}
		}

		// Token: 0x06000DA8 RID: 3496 RVA: 0x0001080E File Offset: 0x0000EA0E
		internal T[] GetRoles<T>(Func<XblMultiplayerSessionMemberRole, T> ctor)
		{
			return Converters.PtrToClassArray<T, XblMultiplayerSessionMemberRole>(this.Roles, this.RolesCount, ctor);
		}

		// Token: 0x06000DA9 RID: 3497 RVA: 0x00010822 File Offset: 0x0000EA22
		internal T[] GetMembersInGroupIds<T>(Func<uint, T> ctor)
		{
			return Converters.PtrToClassArray<T, uint>(this.MembersInGroupIds, this.MembersInGroupCount, ctor);
		}

		// Token: 0x06000DAA RID: 3498 RVA: 0x00010836 File Offset: 0x0000EA36
		internal string[] GetGroups()
		{
			return Converters.PtrToClassArray<string, UTF8StringPtr>(this.Groups, this.GroupsCount, (UTF8StringPtr s) => s.GetString());
		}

		// Token: 0x06000DAB RID: 3499 RVA: 0x00010868 File Offset: 0x0000EA68
		internal string[] GetEncounters()
		{
			return Converters.PtrToClassArray<string, UTF8StringPtr>(this.Encounters, this.EncountersCount, (UTF8StringPtr s) => s.GetString());
		}

		// Token: 0x040006D2 RID: 1746
		internal uint MemberId;

		// Token: 0x040006D3 RID: 1747
		internal UTF8StringPtr TeamId;

		// Token: 0x040006D4 RID: 1748
		internal UTF8StringPtr InitialTeam;

		// Token: 0x040006D5 RID: 1749
		internal XblTournamentArbitrationStatus ArbitrationStatus;

		// Token: 0x040006D6 RID: 1750
		internal ulong Xuid;

		// Token: 0x040006D7 RID: 1751
		internal UTF8StringPtr CustomConstantsJson;

		// Token: 0x040006D8 RID: 1752
		internal UTF8StringPtr SecureDeviceBaseAddress64;

		// Token: 0x040006D9 RID: 1753
		private readonly IntPtr Roles;

		// Token: 0x040006DA RID: 1754
		private readonly SizeT RolesCount;

		// Token: 0x040006DB RID: 1755
		internal UTF8StringPtr CustomPropertiesJson;

		// Token: 0x040006DC RID: 1756
		[FixedBuffer(typeof(byte), 48)]
		private XblMultiplayerSessionMember.<Gamertag>e__FixedBuffer Gamertag;

		// Token: 0x040006DD RID: 1757
		internal XblMultiplayerSessionMemberStatus Status;

		// Token: 0x040006DE RID: 1758
		[MarshalAs(UnmanagedType.U1)]
		internal bool IsTurnAvailable;

		// Token: 0x040006DF RID: 1759
		[MarshalAs(UnmanagedType.U1)]
		internal bool IsCurrentUser;

		// Token: 0x040006E0 RID: 1760
		[MarshalAs(UnmanagedType.U1)]
		internal bool InitializeRequested;

		// Token: 0x040006E1 RID: 1761
		internal UTF8StringPtr MatchmakingResultServerMeasurementsJson;

		// Token: 0x040006E2 RID: 1762
		internal UTF8StringPtr ServerMeasurementsJson;

		// Token: 0x040006E3 RID: 1763
		private readonly IntPtr MembersInGroupIds;

		// Token: 0x040006E4 RID: 1764
		private readonly SizeT MembersInGroupCount;

		// Token: 0x040006E5 RID: 1765
		internal UTF8StringPtr QosMeasurementsJson;

		// Token: 0x040006E6 RID: 1766
		internal XblDeviceToken DeviceToken;

		// Token: 0x040006E7 RID: 1767
		internal XblNetworkAddressTranslationSetting Nat;

		// Token: 0x040006E8 RID: 1768
		internal uint ActiveTitleId;

		// Token: 0x040006E9 RID: 1769
		internal uint InitializationEpisode;

		// Token: 0x040006EA RID: 1770
		internal TimeT JoinTime;

		// Token: 0x040006EB RID: 1771
		internal XblMultiplayerMeasurementFailure InitializationFailureCause;

		// Token: 0x040006EC RID: 1772
		private readonly IntPtr Groups;

		// Token: 0x040006ED RID: 1773
		private readonly SizeT GroupsCount;

		// Token: 0x040006EE RID: 1774
		private readonly IntPtr Encounters;

		// Token: 0x040006EF RID: 1775
		private readonly SizeT EncountersCount;

		// Token: 0x040006F0 RID: 1776
		internal XblMultiplayerSessionReference TournamentTeamSessionReference;

		// Token: 0x040006F1 RID: 1777
		internal readonly IntPtr Internal;

		// Token: 0x02000335 RID: 821
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 48)]
		public struct <Gamertag>e__FixedBuffer
		{
			// Token: 0x040009AF RID: 2479
			public byte FixedElementField;
		}
	}
}
