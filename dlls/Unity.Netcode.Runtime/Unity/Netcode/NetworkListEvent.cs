using System;

namespace Unity.Netcode
{
	// Token: 0x020000B2 RID: 178
	public struct NetworkListEvent<T>
	{
		// Token: 0x0400023B RID: 571
		public NetworkListEvent<T>.EventType Type;

		// Token: 0x0400023C RID: 572
		public T Value;

		// Token: 0x0400023D RID: 573
		public T PreviousValue;

		// Token: 0x0400023E RID: 574
		public int Index;

		// Token: 0x020000B3 RID: 179
		public enum EventType : byte
		{
			// Token: 0x04000240 RID: 576
			Add,
			// Token: 0x04000241 RID: 577
			Insert,
			// Token: 0x04000242 RID: 578
			Remove,
			// Token: 0x04000243 RID: 579
			RemoveAt,
			// Token: 0x04000244 RID: 580
			Value,
			// Token: 0x04000245 RID: 581
			Clear,
			// Token: 0x04000246 RID: 582
			Full
		}
	}
}
