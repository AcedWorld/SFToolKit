using System;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Unity.Networking.Transport.Utilities
{
	// Token: 0x020000C1 RID: 193
	public struct SimulatorUtility
	{
		// Token: 0x060002E6 RID: 742 RVA: 0x0001081B File Offset: 0x0000EA1B
		public SimulatorUtility(int packetCount, int maxPacketSize, int packetDelayMs, int packetJitterMs)
		{
			this.m_PacketCount = packetCount;
			this.m_MaxPacketSize = maxPacketSize;
			this.m_PacketDelayMs = packetDelayMs;
			this.m_PacketJitterMs = packetJitterMs;
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0001083C File Offset: 0x0000EA3C
		public unsafe static void InitializeContext(SimulatorUtility.Parameters param, byte* sharedProcessBuffer)
		{
			((SimulatorUtility.Context*)sharedProcessBuffer)->MaxPacketCount = param.MaxPacketCount;
			((SimulatorUtility.Context*)sharedProcessBuffer)->MaxPacketSize = param.MaxPacketSize;
			((SimulatorUtility.Context*)sharedProcessBuffer)->PacketDelayMs = param.PacketDelayMs;
			((SimulatorUtility.Context*)sharedProcessBuffer)->PacketJitterMs = param.PacketJitterMs;
			((SimulatorUtility.Context*)sharedProcessBuffer)->PacketDrop = param.PacketDropInterval;
			((SimulatorUtility.Context*)sharedProcessBuffer)->FuzzFactor = param.FuzzFactor;
			((SimulatorUtility.Context*)sharedProcessBuffer)->FuzzOffset = param.FuzzOffset;
			((SimulatorUtility.Context*)sharedProcessBuffer)->PacketCount = 0;
			((SimulatorUtility.Context*)sharedProcessBuffer)->PacketDropCount = 0;
			((SimulatorUtility.Context*)sharedProcessBuffer)->Random = default(Random);
			if (param.RandomSeed > 0U)
			{
				((SimulatorUtility.Context*)sharedProcessBuffer)->Random.InitState(param.RandomSeed);
				((SimulatorUtility.Context*)sharedProcessBuffer)->RandomSeed = param.RandomSeed;
				return;
			}
			((SimulatorUtility.Context*)sharedProcessBuffer)->Random.InitState(1851936439U);
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x000108F0 File Offset: 0x0000EAF0
		public unsafe bool GetEmptyDataSlot(byte* processBufferPtr, ref int packetPayloadOffset, ref int packetDataOffset)
		{
			int num = UnsafeUtility.SizeOf<SimulatorUtility.DelayedPacket>();
			int num2 = this.m_PacketCount * num;
			bool result = false;
			for (int i = 0; i < this.m_PacketCount; i++)
			{
				packetDataOffset = num * i;
				SimulatorUtility.DelayedPacket* ptr = (SimulatorUtility.DelayedPacket*)(processBufferPtr + packetDataOffset);
				if (ptr->delayUntil == 0L)
				{
					result = true;
					packetPayloadOffset = num2 + this.m_MaxPacketSize * i;
					break;
				}
			}
			return result;
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00010944 File Offset: 0x0000EB44
		public unsafe bool GetDelayedPacket(ref NetworkPipelineContext ctx, ref InboundSendBuffer delayedPacket, ref NetworkPipelineStage.Requests requests, long currentTimestamp)
		{
			requests = NetworkPipelineStage.Requests.None;
			int num = UnsafeUtility.SizeOf<SimulatorUtility.DelayedPacket>();
			byte* internalProcessBuffer = ctx.internalProcessBuffer;
			SimulatorUtility.Context* internalSharedProcessBuffer = (SimulatorUtility.Context*)ctx.internalSharedProcessBuffer;
			int num2 = -1;
			long num3 = long.MaxValue;
			int num4 = 0;
			int num5 = 0;
			for (int i = 0; i < this.m_PacketCount; i++)
			{
				SimulatorUtility.DelayedPacket* ptr = (SimulatorUtility.DelayedPacket*)(internalProcessBuffer + num * i);
				if ((int)ptr->delayUntil != 0)
				{
					num5++;
					if (ptr->delayUntil <= currentTimestamp)
					{
						num4++;
						if (num3 > ptr->delayUntil)
						{
							num2 = i;
							num3 = ptr->delayUntil;
						}
					}
				}
			}
			internalSharedProcessBuffer->ReadyPackets = num4;
			internalSharedProcessBuffer->WaitingPackets = num5;
			internalSharedProcessBuffer->NextPacketTime = num3;
			internalSharedProcessBuffer->StatsTime = currentTimestamp;
			if (num4 > 1)
			{
				requests |= NetworkPipelineStage.Requests.Resume;
			}
			else if (num5 > 0)
			{
				requests |= NetworkPipelineStage.Requests.Update;
			}
			if (num2 >= 0)
			{
				SimulatorUtility.DelayedPacket* ptr2 = (SimulatorUtility.DelayedPacket*)(internalProcessBuffer + num * num2);
				ptr2->delayUntil = 0L;
				delayedPacket.bufferWithHeaders = ctx.internalProcessBuffer + ptr2->processBufferOffset;
				delayedPacket.bufferWithHeadersLength = (int)ptr2->packetSize;
				delayedPacket.headerPadding = (int)ptr2->packetHeaderPadding;
				delayedPacket.SetBufferFrombufferWithHeaders();
				return true;
			}
			return false;
		}

		// Token: 0x060002EA RID: 746 RVA: 0x00010A54 File Offset: 0x0000EC54
		public unsafe void FuzzPacket(SimulatorUtility.Context* ctx, ref InboundSendBuffer inboundBuffer)
		{
			int fuzzFactor = ctx->FuzzFactor;
			int fuzzOffset = ctx->FuzzOffset;
			if (ctx->Random.NextInt(0, 100) > fuzzFactor)
			{
				return;
			}
			int bufferLength = inboundBuffer.bufferLength;
			for (int i = fuzzOffset; i < bufferLength; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (fuzzFactor > ctx->Random.NextInt(0, 100))
					{
						byte* ptr = inboundBuffer.buffer + i;
						*ptr ^= (byte)(1 << j);
					}
				}
			}
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00010ACC File Offset: 0x0000ECCC
		public unsafe bool DelayPacket(ref NetworkPipelineContext ctx, InboundSendBuffer inboundBuffer, ref NetworkPipelineStage.Requests requests, long timestamp)
		{
			int num = 0;
			int num2 = 0;
			byte* internalProcessBuffer = ctx.internalProcessBuffer;
			if (!this.GetEmptyDataSlot(internalProcessBuffer, ref num, ref num2))
			{
				return false;
			}
			UnsafeUtility.MemCpy((void*)(ctx.internalProcessBuffer + num + inboundBuffer.headerPadding), (void*)inboundBuffer.buffer, (long)inboundBuffer.bufferLength);
			SimulatorUtility.Context* internalSharedProcessBuffer = (SimulatorUtility.Context*)ctx.internalSharedProcessBuffer;
			SimulatorUtility.DelayedPacket delayedPacket;
			delayedPacket.delayUntil = timestamp + (long)this.m_PacketDelayMs + (long)internalSharedProcessBuffer->Random.NextInt(this.m_PacketJitterMs * 2) - (long)this.m_PacketJitterMs;
			delayedPacket.processBufferOffset = num;
			delayedPacket.packetSize = (ushort)(inboundBuffer.headerPadding + inboundBuffer.bufferLength);
			delayedPacket.packetHeaderPadding = (ushort)inboundBuffer.headerPadding;
			byte* source = (byte*)(&delayedPacket);
			UnsafeUtility.MemCpy((void*)(internalProcessBuffer + num2), (void*)source, (long)UnsafeUtility.SizeOf<SimulatorUtility.DelayedPacket>());
			requests |= NetworkPipelineStage.Requests.Update;
			return true;
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00010B90 File Offset: 0x0000ED90
		public unsafe bool ShouldDropPacket(SimulatorUtility.Context* ctx, SimulatorUtility.Parameters param, long timestamp)
		{
			return (param.PacketDropInterval > 0 && (ctx->PacketCount - 1) % param.PacketDropInterval == 0) || (param.PacketDropPercentage > 0 && ctx->Random.NextInt(0, 100) < param.PacketDropPercentage);
		}

		// Token: 0x04000297 RID: 663
		private int m_PacketCount;

		// Token: 0x04000298 RID: 664
		private int m_MaxPacketSize;

		// Token: 0x04000299 RID: 665
		private int m_PacketDelayMs;

		// Token: 0x0400029A RID: 666
		private int m_PacketJitterMs;

		// Token: 0x020000C2 RID: 194
		public struct Parameters : INetworkParameter
		{
			// Token: 0x060002ED RID: 749 RVA: 0x0000D4B3 File Offset: 0x0000B6B3
			public bool Validate()
			{
				return true;
			}

			// Token: 0x0400029B RID: 667
			public int MaxPacketCount;

			// Token: 0x0400029C RID: 668
			public int MaxPacketSize;

			// Token: 0x0400029D RID: 669
			public int PacketDelayMs;

			// Token: 0x0400029E RID: 670
			public int PacketJitterMs;

			// Token: 0x0400029F RID: 671
			public int PacketDropInterval;

			// Token: 0x040002A0 RID: 672
			public int PacketDropPercentage;

			// Token: 0x040002A1 RID: 673
			public int FuzzFactor;

			// Token: 0x040002A2 RID: 674
			public int FuzzOffset;

			// Token: 0x040002A3 RID: 675
			public uint RandomSeed;
		}

		// Token: 0x020000C3 RID: 195
		public struct Context
		{
			// Token: 0x040002A4 RID: 676
			public int MaxPacketCount;

			// Token: 0x040002A5 RID: 677
			public int MaxPacketSize;

			// Token: 0x040002A6 RID: 678
			public int PacketDelayMs;

			// Token: 0x040002A7 RID: 679
			public int PacketJitterMs;

			// Token: 0x040002A8 RID: 680
			public int PacketDrop;

			// Token: 0x040002A9 RID: 681
			public int FuzzOffset;

			// Token: 0x040002AA RID: 682
			public int FuzzFactor;

			// Token: 0x040002AB RID: 683
			public uint RandomSeed;

			// Token: 0x040002AC RID: 684
			public Random Random;

			// Token: 0x040002AD RID: 685
			public int PacketCount;

			// Token: 0x040002AE RID: 686
			public int PacketDropCount;

			// Token: 0x040002AF RID: 687
			public int ReadyPackets;

			// Token: 0x040002B0 RID: 688
			public int WaitingPackets;

			// Token: 0x040002B1 RID: 689
			public long NextPacketTime;

			// Token: 0x040002B2 RID: 690
			public long StatsTime;
		}

		// Token: 0x020000C4 RID: 196
		public struct DelayedPacket
		{
			// Token: 0x040002B3 RID: 691
			public int processBufferOffset;

			// Token: 0x040002B4 RID: 692
			public ushort packetSize;

			// Token: 0x040002B5 RID: 693
			public ushort packetHeaderPadding;

			// Token: 0x040002B6 RID: 694
			public long delayUntil;
		}
	}
}
