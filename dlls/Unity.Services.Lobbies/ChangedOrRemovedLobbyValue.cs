using System;

namespace Unity.Services.Lobbies
{
	// Token: 0x0200001A RID: 26
	public struct ChangedOrRemovedLobbyValue<T>
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600008A RID: 138 RVA: 0x00004988 File Offset: 0x00002B88
		public readonly T Value { get; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600008B RID: 139 RVA: 0x00004990 File Offset: 0x00002B90
		public bool Removed
		{
			get
			{
				return this.ChangeType == LobbyValueChangeType.Removed;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600008C RID: 140 RVA: 0x0000499B File Offset: 0x00002B9B
		public bool Changed
		{
			get
			{
				return this.ChangeType == LobbyValueChangeType.Changed || this.ChangeType == LobbyValueChangeType.Added;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600008D RID: 141 RVA: 0x000049B1 File Offset: 0x00002BB1
		public bool Added
		{
			get
			{
				return this.ChangeType == LobbyValueChangeType.Added;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600008E RID: 142 RVA: 0x000049BC File Offset: 0x00002BBC
		public readonly LobbyValueChangeType ChangeType { get; }

		// Token: 0x0600008F RID: 143 RVA: 0x000049C4 File Offset: 0x00002BC4
		public ChangedOrRemovedLobbyValue(T value, LobbyValueChangeType status)
		{
			this.Value = value;
			this.ChangeType = status;
		}

		// Token: 0x0400006B RID: 107
		public static readonly ChangedOrRemovedLobbyValue<T> RemoveThisValue = new ChangedOrRemovedLobbyValue<T>(default(T), LobbyValueChangeType.Removed);
	}
}
