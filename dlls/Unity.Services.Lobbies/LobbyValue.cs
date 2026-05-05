using System;

namespace Unity.Services.Lobbies
{
	// Token: 0x02000021 RID: 33
	public static class LobbyValue
	{
		// Token: 0x060000E3 RID: 227 RVA: 0x00004F9B File Offset: 0x0000319B
		public static ChangedLobbyValue<T> Changed<T>(T value)
		{
			return new ChangedLobbyValue<T>(value);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00004FA4 File Offset: 0x000031A4
		public static ChangedLobbyValue<T> Added<T>(T value)
		{
			return new ChangedLobbyValue<T>(value)
			{
				Added = true
			};
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00004FC2 File Offset: 0x000031C2
		public static ChangedOrRemovedLobbyValue<T> ChangedNotRemoved<T>(T value)
		{
			return new ChangedOrRemovedLobbyValue<T>(value, LobbyValueChangeType.Changed);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00004FCB File Offset: 0x000031CB
		public static ChangedOrRemovedLobbyValue<T> ChangeAdded<T>(T value)
		{
			return new ChangedOrRemovedLobbyValue<T>(value, LobbyValueChangeType.Added);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00004FD4 File Offset: 0x000031D4
		public static ChangedOrRemovedLobbyValue<T> Removed<T>()
		{
			return ChangedOrRemovedLobbyValue<T>.RemoveThisValue;
		}
	}
}
