using System;

namespace Unity.Services.Lobbies
{
	// Token: 0x02000018 RID: 24
	public struct ChangedLobbyValue<T>
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00004950 File Offset: 0x00002B50
		public readonly T Value { get; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00004958 File Offset: 0x00002B58
		public readonly bool Changed { get; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00004960 File Offset: 0x00002B60
		// (set) Token: 0x06000088 RID: 136 RVA: 0x00004968 File Offset: 0x00002B68
		public bool Added { readonly get; internal set; }

		// Token: 0x06000089 RID: 137 RVA: 0x00004971 File Offset: 0x00002B71
		public ChangedLobbyValue(T value)
		{
			this.Value = value;
			this.Changed = 1;
			this.Added = false;
		}
	}
}
