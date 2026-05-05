using System;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x02000015 RID: 21
	public class PendingClient
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000079 RID: 121 RVA: 0x0000507D File Offset: 0x0000327D
		// (set) Token: 0x0600007A RID: 122 RVA: 0x00005085 File Offset: 0x00003285
		public ulong ClientId { get; internal set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600007B RID: 123 RVA: 0x0000508E File Offset: 0x0000328E
		// (set) Token: 0x0600007C RID: 124 RVA: 0x00005096 File Offset: 0x00003296
		public PendingClient.State ConnectionState { get; internal set; }

		// Token: 0x0400005E RID: 94
		internal Coroutine ApprovalCoroutine;

		// Token: 0x02000016 RID: 22
		public enum State
		{
			// Token: 0x04000062 RID: 98
			PendingConnection,
			// Token: 0x04000063 RID: 99
			PendingApproval
		}
	}
}
