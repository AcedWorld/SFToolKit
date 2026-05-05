using System;
using System.Runtime.InteropServices;

namespace Unity.Networking.Transport
{
	// Token: 0x02000065 RID: 101
	internal struct ProcessPacketCommand
	{
		// Token: 0x04000157 RID: 343
		public ProcessPacketCommandType Type;

		// Token: 0x04000158 RID: 344
		public NetworkInterfaceEndPoint Address;

		// Token: 0x04000159 RID: 345
		public SessionIdToken SessionId;

		// Token: 0x0400015A RID: 346
		public ProcessPacketCommand.ProcessPacketCommandAs As;

		// Token: 0x02000066 RID: 102
		[StructLayout(LayoutKind.Explicit)]
		public struct ProcessPacketCommandAs
		{
			// Token: 0x0400015B RID: 347
			[FieldOffset(0)]
			public ProcessPacketCommand.ProcessPacketCommandAs.AsAddressUpdate AddressUpdate;

			// Token: 0x0400015C RID: 348
			[FieldOffset(0)]
			public ProcessPacketCommand.ProcessPacketCommandAs.AsConnectionAccept ConnectionAccept;

			// Token: 0x0400015D RID: 349
			[FieldOffset(0)]
			public ProcessPacketCommand.ProcessPacketCommandAs.AsData Data;

			// Token: 0x0400015E RID: 350
			[FieldOffset(0)]
			public ProcessPacketCommand.ProcessPacketCommandAs.AsDataWithImplicitConnectionAccept DataWithImplicitConnectionAccept;

			// Token: 0x0400015F RID: 351
			[FieldOffset(0)]
			public ProcessPacketCommand.ProcessPacketCommandAs.AsProtocolStatusUpdate ProtocolStatusUpdate;

			// Token: 0x02000067 RID: 103
			public struct AsAddressUpdate
			{
				// Token: 0x04000160 RID: 352
				public NetworkInterfaceEndPoint NewAddress;
			}

			// Token: 0x02000068 RID: 104
			public struct AsConnectionAccept
			{
				// Token: 0x04000161 RID: 353
				public SessionIdToken ConnectionToken;
			}

			// Token: 0x02000069 RID: 105
			public struct AsData
			{
				// Token: 0x17000034 RID: 52
				// (get) Token: 0x060001E3 RID: 483 RVA: 0x0000A606 File Offset: 0x00008806
				public bool HasPipeline
				{
					get
					{
						return this.HasPipelineByte > 0;
					}
				}

				// Token: 0x04000162 RID: 354
				public int Offset;

				// Token: 0x04000163 RID: 355
				public int Length;

				// Token: 0x04000164 RID: 356
				public byte HasPipelineByte;
			}

			// Token: 0x0200006A RID: 106
			public struct AsDataWithImplicitConnectionAccept
			{
				// Token: 0x17000035 RID: 53
				// (get) Token: 0x060001E4 RID: 484 RVA: 0x0000A611 File Offset: 0x00008811
				public bool HasPipeline
				{
					get
					{
						return this.HasPipelineByte > 0;
					}
				}

				// Token: 0x04000165 RID: 357
				public int Offset;

				// Token: 0x04000166 RID: 358
				public int Length;

				// Token: 0x04000167 RID: 359
				public byte HasPipelineByte;

				// Token: 0x04000168 RID: 360
				public SessionIdToken ConnectionToken;
			}

			// Token: 0x0200006B RID: 107
			public struct AsProtocolStatusUpdate
			{
				// Token: 0x04000169 RID: 361
				public int Status;
			}
		}
	}
}
