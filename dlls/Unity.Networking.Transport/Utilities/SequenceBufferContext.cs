using System;

namespace Unity.Networking.Transport.Utilities
{
	// Token: 0x020000AD RID: 173
	public struct SequenceBufferContext
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x0000F8F2 File Offset: 0x0000DAF2
		internal ushort LastReceivedOverflowCycle
		{
			get
			{
				return (ushort)(this.NumberOfOverflowsDetected & 3L);
			}
		}

		// Token: 0x04000247 RID: 583
		public long Sequence;

		// Token: 0x04000248 RID: 584
		public long Acked;

		// Token: 0x04000249 RID: 585
		internal ulong AckedMask;

		// Token: 0x0400024A RID: 586
		internal ulong LastAckedMask;

		// Token: 0x0400024B RID: 587
		internal long NumberOfOverflowsDetected;

		// Token: 0x0400024C RID: 588
		public uint AckMask;

		// Token: 0x0400024D RID: 589
		public uint LastAckMask;
	}
}
