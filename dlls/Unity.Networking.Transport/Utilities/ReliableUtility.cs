using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

namespace Unity.Networking.Transport.Utilities
{
	// Token: 0x020000AF RID: 175
	public struct ReliableUtility
	{
		// Token: 0x060002B7 RID: 695 RVA: 0x0000F949 File Offset: 0x0000DB49
		private static int AlignedSizeOf<T>() where T : struct
		{
			return UnsafeUtility.SizeOf<T>() + 7 & -8;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000F958 File Offset: 0x0000DB58
		internal static int PacketHeaderWireSize(int windowSize)
		{
			int num = UnsafeUtility.SizeOf<ReliableUtility.ReliableHeader>();
			if (windowSize <= 32)
			{
				return num - 4;
			}
			return num;
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0000F978 File Offset: 0x0000DB78
		internal unsafe static int PacketHeaderWireSize(NetworkPipelineContext ctx)
		{
			ReliableUtility.SharedContext* internalSharedProcessBuffer = (ReliableUtility.SharedContext*)ctx.internalSharedProcessBuffer;
			return ReliableUtility.PacketHeaderWireSize(internalSharedProcessBuffer->WindowSize);
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000F998 File Offset: 0x0000DB98
		public static int SharedCapacityNeeded(ReliableUtility.Parameters param)
		{
			int num = ReliableUtility.AlignedSizeOf<ReliableUtility.PacketTimers>() * param.WindowSize * 2;
			return ReliableUtility.AlignedSizeOf<ReliableUtility.SharedContext>() + num;
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0000F9BC File Offset: 0x0000DBBC
		public static int ProcessCapacityNeeded(ReliableUtility.Parameters param)
		{
			int num = ReliableUtility.AlignedSizeOf<ReliableUtility.PacketInformation>();
			int num2 = 1480;
			num *= param.WindowSize;
			num2 *= param.WindowSize;
			return ReliableUtility.AlignedSizeOf<ReliableUtility.Context>() + num + num2;
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0000F9F0 File Offset: 0x0000DBF0
		public unsafe static ReliableUtility.SharedContext InitializeContext(byte* sharedBuffer, int sharedBufferLength, byte* sendBuffer, int sendBufferLength, byte* recvBuffer, int recvBufferLength, ReliableUtility.Parameters param)
		{
			ReliableUtility.InitializeProcessContext(sendBuffer, sendBufferLength, param);
			ReliableUtility.InitializeProcessContext(recvBuffer, recvBufferLength, param);
			*(ReliableUtility.SharedContext*)sharedBuffer = new ReliableUtility.SharedContext
			{
				WindowSize = param.WindowSize,
				SentPackets = new SequenceBufferContext
				{
					Acked = -1L,
					AckedMask = 0UL
				},
				MinimumResendTime = 64,
				ReceivedPackets = new SequenceBufferContext
				{
					Sequence = -1L,
					AckedMask = 0UL,
					LastAckedMask = 0UL
				},
				RttInfo = new ReliableUtility.RTTInfo
				{
					SmoothedVariance = 5f,
					SmoothedRtt = 50f,
					ResendTimeout = 50,
					LastRtt = 50
				},
				TimerDataOffset = ReliableUtility.AlignedSizeOf<ReliableUtility.SharedContext>(),
				TimerDataStride = ReliableUtility.AlignedSizeOf<ReliableUtility.PacketTimers>(),
				RemoteTimerDataOffset = ReliableUtility.AlignedSizeOf<ReliableUtility.SharedContext>() + ReliableUtility.AlignedSizeOf<ReliableUtility.PacketTimers>() * param.WindowSize,
				RemoteTimerDataStride = ReliableUtility.AlignedSizeOf<ReliableUtility.PacketTimers>()
			};
			return *(ReliableUtility.SharedContext*)sharedBuffer;
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0000FB08 File Offset: 0x0000DD08
		public unsafe static int InitializeProcessContext(byte* buffer, int bufferLength, ReliableUtility.Parameters param)
		{
			int num = ReliableUtility.ProcessCapacityNeeded(param);
			if (bufferLength != num)
			{
				return -8;
			}
			((ReliableUtility.Context*)buffer)->Capacity = param.WindowSize;
			((ReliableUtility.Context*)buffer)->IndexStride = ReliableUtility.AlignedSizeOf<ReliableUtility.PacketInformation>();
			((ReliableUtility.Context*)buffer)->IndexPtrOffset = ReliableUtility.AlignedSizeOf<ReliableUtility.Context>();
			((ReliableUtility.Context*)buffer)->DataStride = 1480;
			((ReliableUtility.Context*)buffer)->DataPtrOffset = ((ReliableUtility.Context*)buffer)->IndexPtrOffset + ((ReliableUtility.Context*)buffer)->IndexStride * ((ReliableUtility.Context*)buffer)->Capacity;
			((ReliableUtility.Context*)buffer)->Resume = -1L;
			((ReliableUtility.Context*)buffer)->Delivered = -1L;
			ReliableUtility.Release(buffer, 0L, param.WindowSize);
			return 0;
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0000FB8B File Offset: 0x0000DD8B
		public unsafe static void SetPacket(byte* self, long sequence, InboundRecvBuffer data)
		{
			ReliableUtility.SetPacket(self, sequence, (void*)data.buffer, data.bufferLength);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0000FBA0 File Offset: 0x0000DDA0
		public unsafe static void SetPacket(byte* self, long sequence, void* data, int length)
		{
			if (length > ((ReliableUtility.Context*)self)->DataStride)
			{
				return;
			}
			long num = sequence % (long)((ReliableUtility.Context*)self)->Capacity;
			ReliableUtility.PacketInformation* packetInformation = ReliableUtility.GetPacketInformation(self, sequence);
			packetInformation->SequenceId = sequence;
			packetInformation->Size = (ushort)length;
			packetInformation->HeaderPadding = 0;
			packetInformation->SendTime = -1L;
			long num2 = (long)((ReliableUtility.Context*)self)->DataPtrOffset + num * (long)((ReliableUtility.Context*)self)->DataStride;
			void* destination = (void*)(self + num2);
			UnsafeUtility.MemCpy(destination, data, (long)length);
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0000FC07 File Offset: 0x0000DE07
		[Obsolete("Internal API that shouldn't be used. Will be removed in Unity Transport 2.0.")]
		public unsafe static void SetHeaderAndPacket(byte* self, long sequence, ReliableUtility.PacketHeader header, InboundSendBuffer data, long timestamp)
		{
			throw new NotImplementedException("Implementation was moved to other internal APIs.");
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0000FC14 File Offset: 0x0000DE14
		internal unsafe static void SetHeaderAndPacket(byte* self, long sequence, ReliableUtility.ReliableHeader header, InboundSendBuffer data, long timestamp)
		{
			int num = data.bufferLength + data.headerPadding;
			if (num > ((ReliableUtility.Context*)self)->DataStride)
			{
				return;
			}
			long num2 = sequence % (long)((ReliableUtility.Context*)self)->Capacity;
			ReliableUtility.PacketInformation* packetInformation = ReliableUtility.GetPacketInformation(self, sequence);
			packetInformation->SequenceId = sequence;
			packetInformation->Size = (ushort)num;
			packetInformation->HeaderPadding = (ushort)data.headerPadding;
			packetInformation->SendTime = timestamp;
			ReliableUtility.GetReliablePacket(self, sequence)->Header = header;
			long num3 = (long)((ReliableUtility.Context*)self)->DataPtrOffset + num2 * (long)((ReliableUtility.Context*)self)->DataStride;
			void* ptr = (void*)(self + num3);
			if (data.bufferLength > 0)
			{
				UnsafeUtility.MemCpy((void*)((byte*)ptr + data.headerPadding), (void*)data.buffer, (long)data.bufferLength);
			}
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0000FCB8 File Offset: 0x0000DEB8
		public unsafe static ReliableUtility.PacketInformation* GetPacketInformation(byte* self, long sequence)
		{
			long num = sequence % (long)((ReliableUtility.Context*)self)->Capacity;
			return (ReliableUtility.PacketInformation*)(self + ((ReliableUtility.Context*)self)->IndexPtrOffset + num * (long)((ReliableUtility.Context*)self)->IndexStride);
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0000FC07 File Offset: 0x0000DE07
		[Obsolete("Internal API that shouldn't be used. Will be removed in Unity Transport 2.0.")]
		public unsafe static ReliableUtility.Packet* GetPacket(byte* self, long sequence)
		{
			throw new NotImplementedException("Implementation was moved to other internal APIs.");
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0000FCE4 File Offset: 0x0000DEE4
		internal unsafe static ReliableUtility.ReliablePacket* GetReliablePacket(byte* self, long sequence)
		{
			long num = sequence % (long)((ReliableUtility.Context*)self)->Capacity;
			long num2 = (long)((ReliableUtility.Context*)self)->DataPtrOffset + num * (long)((ReliableUtility.Context*)self)->DataStride;
			return (ReliableUtility.ReliablePacket*)(self + num2);
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0000FD14 File Offset: 0x0000DF14
		public unsafe static bool TryAquire(byte* self, long sequence)
		{
			long index = sequence % (long)((ReliableUtility.Context*)self)->Capacity;
			if (ReliableUtility.GetIndex(self, index) == -1L)
			{
				ReliableUtility.SetIndex(self, index, sequence);
				return true;
			}
			return false;
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0000FD43 File Offset: 0x0000DF43
		public unsafe static void Release(byte* self, long sequence)
		{
			ReliableUtility.Release(self, sequence, 1);
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0000FD50 File Offset: 0x0000DF50
		public unsafe static void Release(byte* self, long start_sequence, int count)
		{
			for (int i = 0; i < count; i++)
			{
				ReliableUtility.SetIndex(self, (start_sequence + (long)i) % (long)((ReliableUtility.Context*)self)->Capacity, -1L);
			}
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0000FD80 File Offset: 0x0000DF80
		private unsafe static void SetIndex(byte* self, long index, long sequence)
		{
			long* ptr = (long*)(self + ((ReliableUtility.Context*)self)->IndexPtrOffset + index * (long)((ReliableUtility.Context*)self)->IndexStride);
			*ptr = sequence;
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0000FDA8 File Offset: 0x0000DFA8
		private unsafe static long GetIndex(byte* self, long index)
		{
			long* ptr = (long*)(self + ((ReliableUtility.Context*)self)->IndexPtrOffset + index * (long)((ReliableUtility.Context*)self)->IndexStride);
			return *ptr;
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0000FC07 File Offset: 0x0000DE07
		[Obsolete("Internal API that shouldn't be used. Will be removed in Unity Transport 2.0.")]
		public static bool ReleaseOrResumePackets(NetworkPipelineContext context)
		{
			throw new NotImplementedException("Implementation was moved to other internal APIs.");
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000FDD0 File Offset: 0x0000DFD0
		internal unsafe static void ReleaseAcknowledgedPackets(NetworkPipelineContext context)
		{
			ReliableUtility.SharedContext* internalSharedProcessBuffer = (ReliableUtility.SharedContext*)context.internalSharedProcessBuffer;
			ulong ackedMask = internalSharedProcessBuffer->SentPackets.AckedMask;
			long acked = internalSharedProcessBuffer->SentPackets.Acked;
			for (int i = 0; i < internalSharedProcessBuffer->WindowSize; i++)
			{
				ReliableUtility.PacketInformation* packetInformation = ReliableUtility.GetPacketInformation(context.internalProcessBuffer, (long)i);
				if (packetInformation->SequenceId >= 0L && packetInformation->SequenceId <= acked)
				{
					long num = math.abs(acked - packetInformation->SequenceId);
					if (num >= (long)internalSharedProcessBuffer->WindowSize || (1UL << (int)num & ackedMask) != 0UL)
					{
						ReliableUtility.Release(context.internalProcessBuffer, packetInformation->SequenceId);
						packetInformation->SendTime = -1L;
					}
				}
			}
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0000FE74 File Offset: 0x0000E074
		internal unsafe static long GetNextSendResumeSequence(NetworkPipelineContext context)
		{
			ReliableUtility.SharedContext* internalSharedProcessBuffer = (ReliableUtility.SharedContext*)context.internalSharedProcessBuffer;
			long num = -1L;
			for (int i = 0; i < internalSharedProcessBuffer->WindowSize; i++)
			{
				ReliableUtility.PacketInformation* packetInformation = ReliableUtility.GetPacketInformation(context.internalProcessBuffer, (long)i);
				if (packetInformation->SequenceId >= 0L)
				{
					int num2 = ReliableUtility.CurrentResendTime(context.internalSharedProcessBuffer);
					if (context.timestamp > packetInformation->SendTime + (long)num2 && (num == -1L || packetInformation->SequenceId < num))
					{
						num = packetInformation->SequenceId;
					}
				}
			}
			return num;
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0000FEEC File Offset: 0x0000E0EC
		internal unsafe static bool NeedResumeReceive(NetworkPipelineContext context)
		{
			ReliableUtility.Context* internalProcessBuffer = (ReliableUtility.Context*)context.internalProcessBuffer;
			long num = internalProcessBuffer->Delivered + 1L;
			return ReliableUtility.GetPacketInformation(context.internalProcessBuffer, num)->SequenceId == num;
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000FF20 File Offset: 0x0000E120
		public unsafe static InboundRecvBuffer ResumeReceive(NetworkPipelineContext context, int startSequence, ref bool needsResume)
		{
			ReliableUtility.SharedContext* internalSharedProcessBuffer = (ReliableUtility.SharedContext*)context.internalSharedProcessBuffer;
			ReliableUtility.Context* internalProcessBuffer = (ReliableUtility.Context*)context.internalProcessBuffer;
			long num = internalProcessBuffer->Delivered + 1L;
			ReliableUtility.PacketInformation* packetInformation = ReliableUtility.GetPacketInformation(context.internalProcessBuffer, num);
			if (packetInformation->SequenceId == num)
			{
				long num2 = (long)internalProcessBuffer->DataPtrOffset + num % (long)internalProcessBuffer->Capacity * (long)internalProcessBuffer->DataStride;
				InboundRecvBuffer result = default(InboundRecvBuffer);
				result.buffer = context.internalProcessBuffer + num2;
				result.bufferLength = (int)packetInformation->Size;
				internalProcessBuffer->Delivered = num;
				return result;
			}
			return default(InboundRecvBuffer);
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0000FFB0 File Offset: 0x0000E1B0
		[Obsolete("Will be removed in Unity Transport 2.0.")]
		public static InboundSendBuffer ResumeSend(NetworkPipelineContext context, out ReliableUtility.PacketHeader header, ref bool needsResume)
		{
			throw new NotImplementedException("Implementation moved to an internal method. Shouldn't be used anymore.");
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000FFBC File Offset: 0x0000E1BC
		internal unsafe static InboundSendBuffer ResumeSend(NetworkPipelineContext context, out ReliableUtility.ReliableHeader header, ref bool needsResume)
		{
			ReliableUtility.SharedContext* internalSharedProcessBuffer = (ReliableUtility.SharedContext*)context.internalSharedProcessBuffer;
			ReliableUtility.Context* internalProcessBuffer = (ReliableUtility.Context*)context.internalProcessBuffer;
			long resume = internalProcessBuffer->Resume;
			ReliableUtility.PacketInformation* packetInformation = ReliableUtility.GetPacketInformation(context.internalProcessBuffer, resume);
			packetInformation->SendTime = context.timestamp;
			ReliableUtility.ReliablePacket* reliablePacket = ReliableUtility.GetReliablePacket(context.internalProcessBuffer, resume);
			header = reliablePacket->Header;
			header.AckedSequenceId = (ushort)internalSharedProcessBuffer->ReceivedPackets.Sequence;
			header.AckedMask = internalSharedProcessBuffer->ReceivedPackets.AckedMask;
			long num = (long)internalProcessBuffer->DataPtrOffset + resume % (long)internalProcessBuffer->Capacity * (long)internalProcessBuffer->DataStride;
			InboundSendBuffer result = default(InboundSendBuffer);
			result.bufferWithHeaders = context.internalProcessBuffer + num;
			result.bufferWithHeadersLength = (int)packetInformation->Size;
			result.headerPadding = (int)packetInformation->HeaderPadding;
			result.SetBufferFrombufferWithHeaders();
			ReliableUtility.SharedContext* ptr = internalSharedProcessBuffer;
			ptr->stats.PacketsResent = ptr->stats.PacketsResent + 1;
			return result;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000FFB0 File Offset: 0x0000E1B0
		[Obsolete("Will be removed in Unity Transport 2.0.")]
		public static int Write(NetworkPipelineContext context, InboundSendBuffer inboundBuffer, ref ReliableUtility.PacketHeader header)
		{
			throw new NotImplementedException("Implementation moved to an internal method. Shouldn't be used anymore.");
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0001009C File Offset: 0x0000E29C
		internal unsafe static long Write(NetworkPipelineContext context, InboundSendBuffer inboundBuffer, ref ReliableUtility.ReliableHeader header)
		{
			ReliableUtility.SharedContext* internalSharedProcessBuffer = (ReliableUtility.SharedContext*)context.internalSharedProcessBuffer;
			long sequence = internalSharedProcessBuffer->SentPackets.Sequence;
			if (!ReliableUtility.TryAquire(context.internalProcessBuffer, sequence))
			{
				internalSharedProcessBuffer->errorCode = ReliableUtility.ErrorCodes.OutgoingQueueIsFull;
				return -7L;
			}
			ReliableUtility.SharedContext* ptr = internalSharedProcessBuffer;
			ptr->stats.PacketsSent = ptr->stats.PacketsSent + 1;
			header.SequenceId = (ushort)sequence;
			header.AckedSequenceId = (ushort)internalSharedProcessBuffer->ReceivedPackets.Sequence;
			header.AckedMask = internalSharedProcessBuffer->ReceivedPackets.AckedMask;
			internalSharedProcessBuffer->ReceivedPackets.Acked = internalSharedProcessBuffer->ReceivedPackets.Sequence;
			internalSharedProcessBuffer->ReceivedPackets.LastAckedMask = header.AckedMask;
			internalSharedProcessBuffer->DuplicatesSinceLastAck = 0;
			header.ProcessingTime = ReliableUtility.CalculateProcessingTime(context.internalSharedProcessBuffer, (long)((ulong)header.AckedSequenceId), context.timestamp);
			ReliableUtility.SharedContext* ptr2 = internalSharedProcessBuffer;
			ptr2->SentPackets.Sequence = ptr2->SentPackets.Sequence + 1L;
			ReliableUtility.SetHeaderAndPacket(context.internalProcessBuffer, sequence, header, inboundBuffer, context.timestamp);
			ReliableUtility.StoreTimestamp(context.internalSharedProcessBuffer, sequence, context.timestamp);
			return sequence;
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000FFB0 File Offset: 0x0000E1B0
		[Obsolete("Will be removed in Unity Transport 2.0.")]
		public static void WriteAckPacket(NetworkPipelineContext context, ref ReliableUtility.PacketHeader header)
		{
			throw new NotImplementedException("Implementation moved to an internal method. Shouldn't be used anymore.");
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0001019C File Offset: 0x0000E39C
		internal unsafe static void WriteAckPacket(NetworkPipelineContext context, ref ReliableUtility.ReliableHeader header)
		{
			ReliableUtility.SharedContext* internalSharedProcessBuffer = (ReliableUtility.SharedContext*)context.internalSharedProcessBuffer;
			header.Type = 1;
			header.AckedSequenceId = (ushort)internalSharedProcessBuffer->ReceivedPackets.Sequence;
			header.AckedMask = internalSharedProcessBuffer->ReceivedPackets.AckedMask;
			header.ProcessingTime = ReliableUtility.CalculateProcessingTime(context.internalSharedProcessBuffer, (long)((ulong)header.AckedSequenceId), context.timestamp);
			internalSharedProcessBuffer->ReceivedPackets.Acked = internalSharedProcessBuffer->ReceivedPackets.Sequence;
			internalSharedProcessBuffer->ReceivedPackets.LastAckedMask = header.AckedMask;
			internalSharedProcessBuffer->DuplicatesSinceLastAck = 0;
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x00010226 File Offset: 0x0000E426
		public unsafe static void StoreTimestamp(byte* sharedBuffer, long sequenceId, long timestamp)
		{
			ReliableUtility.PacketTimers* localPacketTimer = ReliableUtility.GetLocalPacketTimer(sharedBuffer, sequenceId);
			localPacketTimer->SequenceId = sequenceId;
			localPacketTimer->SentTime = timestamp;
			localPacketTimer->ProcessingTime = 0;
			localPacketTimer->ReceiveTime = 0L;
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0001024C File Offset: 0x0000E44C
		public unsafe static void StoreReceiveTimestamp(byte* sharedBuffer, long sequenceId, long timestamp, ushort processingTime)
		{
			ReliableUtility.RTTInfo rttInfo = ((ReliableUtility.SharedContext*)sharedBuffer)->RttInfo;
			ReliableUtility.PacketTimers* localPacketTimer = ReliableUtility.GetLocalPacketTimer(sharedBuffer, sequenceId);
			if (localPacketTimer != null && localPacketTimer->SequenceId == sequenceId)
			{
				if (localPacketTimer->ReceiveTime > 0L)
				{
					return;
				}
				localPacketTimer->ReceiveTime = timestamp;
				localPacketTimer->ProcessingTime = processingTime;
				rttInfo.LastRtt = (int)Math.Max(localPacketTimer->ReceiveTime - localPacketTimer->SentTime - (long)((ulong)localPacketTimer->ProcessingTime), 1L);
				float num = (float)rttInfo.LastRtt - rttInfo.SmoothedRtt;
				rttInfo.SmoothedRtt += num / 8f;
				rttInfo.SmoothedVariance += (math.abs(num) - rttInfo.SmoothedVariance) / 4f;
				rttInfo.ResendTimeout = (int)(rttInfo.SmoothedRtt + 4f * rttInfo.SmoothedVariance);
				((ReliableUtility.SharedContext*)sharedBuffer)->RttInfo = rttInfo;
			}
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0001031C File Offset: 0x0000E51C
		public unsafe static void StoreRemoteReceiveTimestamp(byte* sharedBuffer, long sequenceId, long timestamp)
		{
			ReliableUtility.PacketTimers* remotePacketTimer = ReliableUtility.GetRemotePacketTimer(sharedBuffer, sequenceId);
			remotePacketTimer->SequenceId = sequenceId;
			remotePacketTimer->ReceiveTime = timestamp;
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00010334 File Offset: 0x0000E534
		private unsafe static int CurrentResendTime(byte* sharedBuffer)
		{
			if (((ReliableUtility.SharedContext*)sharedBuffer)->RttInfo.ResendTimeout > 200)
			{
				return 200;
			}
			return Math.Max(((ReliableUtility.SharedContext*)sharedBuffer)->RttInfo.ResendTimeout, ((ReliableUtility.SharedContext*)sharedBuffer)->MinimumResendTime);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00010374 File Offset: 0x0000E574
		public unsafe static ushort CalculateProcessingTime(byte* sharedBuffer, long sequenceId, long timestamp)
		{
			ReliableUtility.PacketTimers* remotePacketTimer = ReliableUtility.GetRemotePacketTimer(sharedBuffer, sequenceId);
			if (remotePacketTimer != null && remotePacketTimer->SequenceId == sequenceId)
			{
				return Math.Min((ushort)(timestamp - remotePacketTimer->ReceiveTime), ushort.MaxValue);
			}
			return 0;
		}

		// Token: 0x060002DA RID: 730 RVA: 0x000103AC File Offset: 0x0000E5AC
		public unsafe static ReliableUtility.PacketTimers* GetLocalPacketTimer(byte* sharedBuffer, long sequenceId)
		{
			long num = sequenceId % (long)((ReliableUtility.SharedContext*)sharedBuffer)->WindowSize;
			return (ReliableUtility.PacketTimers*)sharedBuffer + (long)((ReliableUtility.SharedContext*)sharedBuffer)->TimerDataOffset / (long)sizeof(ReliableUtility.PacketTimers) + (long)((ReliableUtility.SharedContext*)sharedBuffer)->TimerDataStride * num / (long)sizeof(ReliableUtility.PacketTimers);
		}

		// Token: 0x060002DB RID: 731 RVA: 0x000103DC File Offset: 0x0000E5DC
		public unsafe static ReliableUtility.PacketTimers* GetRemotePacketTimer(byte* sharedBuffer, long sequenceId)
		{
			long num = sequenceId % (long)((ReliableUtility.SharedContext*)sharedBuffer)->WindowSize;
			return (ReliableUtility.PacketTimers*)sharedBuffer + (long)((ReliableUtility.SharedContext*)sharedBuffer)->RemoteTimerDataOffset / (long)sizeof(ReliableUtility.PacketTimers) + (long)((ReliableUtility.SharedContext*)sharedBuffer)->RemoteTimerDataStride * num / (long)sizeof(ReliableUtility.PacketTimers);
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000FFB0 File Offset: 0x0000E1B0
		[Obsolete("Will be removed in Unity Transport 2.0.")]
		public static int Read(NetworkPipelineContext context, ReliableUtility.PacketHeader header)
		{
			throw new NotImplementedException("Implementation moved to an internal method. Shouldn't be used anymore.");
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0001040C File Offset: 0x0000E60C
		internal static long GetSequenceId64Bits(ref SequenceBufferContext context, ushort sequenceId16Bits)
		{
			ushort num = (ushort)(sequenceId16Bits >> 14);
			ushort num2 = sequenceId16Bits & 16383;
			if (num == context.LastReceivedOverflowCycle + 1 || (num == 0 && context.LastReceivedOverflowCycle == 3))
			{
				context.NumberOfOverflowsDetected += 1L;
			}
			long num3;
			if (num == context.LastReceivedOverflowCycle)
			{
				num3 = context.NumberOfOverflowsDetected;
			}
			else
			{
				if (num != context.LastReceivedOverflowCycle - 1 && (num != 3 || context.LastReceivedOverflowCycle != 0))
				{
					return -1L;
				}
				num3 = context.NumberOfOverflowsDetected - 1L;
			}
			return num3 << 14 | (long)((ulong)num2);
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0001048C File Offset: 0x0000E68C
		internal unsafe static long Read(NetworkPipelineContext context, ReliableUtility.ReliableHeader header)
		{
			ReliableUtility.SharedContext* internalSharedProcessBuffer = (ReliableUtility.SharedContext*)context.internalSharedProcessBuffer;
			long sequenceId64Bits = ReliableUtility.GetSequenceId64Bits(ref internalSharedProcessBuffer->ReceivedPackets, header.SequenceId);
			if (sequenceId64Bits == -1L)
			{
				ReliableUtility.SharedContext* ptr = internalSharedProcessBuffer;
				ptr->stats.PacketsStale = ptr->stats.PacketsStale + 1;
				return -1L;
			}
			bool flag = sequenceId64Bits > internalSharedProcessBuffer->ReceivedPackets.Sequence;
			int num = (int)math.abs(sequenceId64Bits - internalSharedProcessBuffer->ReceivedPackets.Sequence);
			ReliableUtility.SharedContext* ptr2 = internalSharedProcessBuffer;
			ptr2->stats.PacketsReceived = ptr2->stats.PacketsReceived + 1;
			if (!flag && num >= internalSharedProcessBuffer->WindowSize)
			{
				ReliableUtility.SharedContext* ptr3 = internalSharedProcessBuffer;
				ptr3->stats.PacketsStale = ptr3->stats.PacketsStale + 1;
				return -1L;
			}
			if (flag && num > internalSharedProcessBuffer->WindowSize)
			{
				return -1L;
			}
			if (flag)
			{
				internalSharedProcessBuffer->ReceivedPackets.Sequence = sequenceId64Bits;
				ReliableUtility.SharedContext* ptr4 = internalSharedProcessBuffer;
				ptr4->ReceivedPackets.AckedMask = ptr4->ReceivedPackets.AckedMask << num;
				ReliableUtility.SharedContext* ptr5 = internalSharedProcessBuffer;
				ptr5->ReceivedPackets.AckedMask = (ptr5->ReceivedPackets.AckedMask | 1UL);
				for (int i = 0; i < num; i++)
				{
					if ((internalSharedProcessBuffer->ReceivedPackets.AckedMask & 1UL << i) == 0UL)
					{
						ReliableUtility.SharedContext* ptr6 = internalSharedProcessBuffer;
						ptr6->stats.PacketsDropped = ptr6->stats.PacketsDropped + 1;
					}
				}
			}
			else
			{
				if ((internalSharedProcessBuffer->ReceivedPackets.AckedMask & 1UL << num) != 0UL)
				{
					ReliableUtility.ReadAckPacket(context, header);
					ReliableUtility.SharedContext* ptr7 = internalSharedProcessBuffer;
					ptr7->stats.PacketsDuplicated = ptr7->stats.PacketsDuplicated + 1;
					internalSharedProcessBuffer->DuplicatesSinceLastAck++;
					return -1L;
				}
				ReliableUtility.SharedContext* ptr8 = internalSharedProcessBuffer;
				ptr8->ReceivedPackets.AckedMask = (ptr8->ReceivedPackets.AckedMask | 1UL << num);
				ReliableUtility.SharedContext* ptr9 = internalSharedProcessBuffer;
				ptr9->stats.PacketsOutOfOrder = ptr9->stats.PacketsOutOfOrder + 1;
			}
			ReliableUtility.StoreRemoteReceiveTimestamp(context.internalSharedProcessBuffer, sequenceId64Bits, context.timestamp);
			ReliableUtility.ReadAckPacket(context, header);
			return sequenceId64Bits;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000FFB0 File Offset: 0x0000E1B0
		[Obsolete("Will be removed in Unity Transport 2.0.")]
		public static void ReadAckPacket(NetworkPipelineContext context, ReliableUtility.PacketHeader header)
		{
			throw new NotImplementedException("Implementation moved to an internal method. Shouldn't be used anymore.");
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00010610 File Offset: 0x0000E810
		internal unsafe static void ReadAckPacket(NetworkPipelineContext context, ReliableUtility.ReliableHeader header)
		{
			ReliableUtility.SharedContext* internalSharedProcessBuffer = (ReliableUtility.SharedContext*)context.internalSharedProcessBuffer;
			ReliableUtility.StoreReceiveTimestamp(context.internalSharedProcessBuffer, (long)((ulong)header.AckedSequenceId), context.timestamp, header.ProcessingTime);
			long sequenceId64Bits = ReliableUtility.GetSequenceId64Bits(ref internalSharedProcessBuffer->SentPackets, header.AckedSequenceId);
			if (sequenceId64Bits == -1L || internalSharedProcessBuffer->SentPackets.Acked > sequenceId64Bits)
			{
				return;
			}
			if (internalSharedProcessBuffer->SentPackets.Acked == sequenceId64Bits)
			{
				ReliableUtility.SharedContext* ptr = internalSharedProcessBuffer;
				ptr->SentPackets.AckedMask = (ptr->SentPackets.AckedMask | header.AckedMask);
				return;
			}
			internalSharedProcessBuffer->SentPackets.Acked = sequenceId64Bits;
			internalSharedProcessBuffer->SentPackets.AckedMask = header.AckedMask;
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x000106AC File Offset: 0x0000E8AC
		public unsafe static bool ShouldSendAck(NetworkPipelineContext ctx)
		{
			ReliableUtility.Context* internalProcessBuffer = (ReliableUtility.Context*)ctx.internalProcessBuffer;
			ReliableUtility.SharedContext* internalSharedProcessBuffer = (ReliableUtility.SharedContext*)ctx.internalSharedProcessBuffer;
			return internalProcessBuffer->LastSentTime < internalProcessBuffer->PreviousTimestamp && (internalSharedProcessBuffer->ReceivedPackets.Acked < internalSharedProcessBuffer->ReceivedPackets.Sequence || internalSharedProcessBuffer->ReceivedPackets.AckedMask != internalSharedProcessBuffer->ReceivedPackets.LastAckedMask || internalSharedProcessBuffer->DuplicatesSinceLastAck >= 3);
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00010714 File Offset: 0x0000E914
		public unsafe static void SetMinimumResendTime(int value, NetworkDriver driver, NetworkPipeline pipeline, NetworkConnection con)
		{
			NativeArray<byte> nativeArray;
			NativeArray<byte> nativeArray2;
			NativeArray<byte> nativeArray3;
			driver.GetPipelineBuffers(pipeline, NetworkPipelineStageCollection.GetStageId(typeof(ReliableSequencedPipelineStage)), con, out nativeArray, out nativeArray2, out nativeArray3);
			ReliableUtility.SharedContext* unsafePtr = (ReliableUtility.SharedContext*)nativeArray3.GetUnsafePtr<byte>();
			unsafePtr->MinimumResendTime = value;
		}

		// Token: 0x0400024E RID: 590
		public const long NullEntry = -1L;

		// Token: 0x0400024F RID: 591
		public const int DefaultMinimumResendTime = 64;

		// Token: 0x04000250 RID: 592
		public const int MaximumResendTime = 200;

		// Token: 0x04000251 RID: 593
		internal const int MaxDuplicatesSinceLastAck = 3;

		// Token: 0x020000B0 RID: 176
		public struct Statistics
		{
			// Token: 0x04000252 RID: 594
			public int PacketsReceived;

			// Token: 0x04000253 RID: 595
			public int PacketsSent;

			// Token: 0x04000254 RID: 596
			public int PacketsDropped;

			// Token: 0x04000255 RID: 597
			public int PacketsOutOfOrder;

			// Token: 0x04000256 RID: 598
			public int PacketsDuplicated;

			// Token: 0x04000257 RID: 599
			public int PacketsStale;

			// Token: 0x04000258 RID: 600
			public int PacketsResent;
		}

		// Token: 0x020000B1 RID: 177
		public struct RTTInfo
		{
			// Token: 0x04000259 RID: 601
			public int LastRtt;

			// Token: 0x0400025A RID: 602
			public float SmoothedRtt;

			// Token: 0x0400025B RID: 603
			public float SmoothedVariance;

			// Token: 0x0400025C RID: 604
			public int ResendTimeout;
		}

		// Token: 0x020000B2 RID: 178
		public enum ErrorCodes
		{
			// Token: 0x0400025E RID: 606
			Stale_Packet = -1,
			// Token: 0x0400025F RID: 607
			Duplicated_Packet = -2,
			// Token: 0x04000260 RID: 608
			OutgoingQueueIsFull = -7,
			// Token: 0x04000261 RID: 609
			InsufficientMemory = -8
		}

		// Token: 0x020000B3 RID: 179
		public enum PacketType : ushort
		{
			// Token: 0x04000263 RID: 611
			Payload,
			// Token: 0x04000264 RID: 612
			Ack
		}

		// Token: 0x020000B4 RID: 180
		public struct SharedContext
		{
			// Token: 0x04000265 RID: 613
			public int WindowSize;

			// Token: 0x04000266 RID: 614
			public int MinimumResendTime;

			// Token: 0x04000267 RID: 615
			public SequenceBufferContext SentPackets;

			// Token: 0x04000268 RID: 616
			public SequenceBufferContext ReceivedPackets;

			// Token: 0x04000269 RID: 617
			internal int DuplicatesSinceLastAck;

			// Token: 0x0400026A RID: 618
			public ReliableUtility.Statistics stats;

			// Token: 0x0400026B RID: 619
			public ReliableUtility.ErrorCodes errorCode;

			// Token: 0x0400026C RID: 620
			public ReliableUtility.RTTInfo RttInfo;

			// Token: 0x0400026D RID: 621
			public int TimerDataOffset;

			// Token: 0x0400026E RID: 622
			public int TimerDataStride;

			// Token: 0x0400026F RID: 623
			public int RemoteTimerDataOffset;

			// Token: 0x04000270 RID: 624
			public int RemoteTimerDataStride;
		}

		// Token: 0x020000B5 RID: 181
		public struct Context
		{
			// Token: 0x04000271 RID: 625
			public int Capacity;

			// Token: 0x04000272 RID: 626
			public long Resume;

			// Token: 0x04000273 RID: 627
			public long Delivered;

			// Token: 0x04000274 RID: 628
			public int IndexStride;

			// Token: 0x04000275 RID: 629
			public int IndexPtrOffset;

			// Token: 0x04000276 RID: 630
			public int DataStride;

			// Token: 0x04000277 RID: 631
			public int DataPtrOffset;

			// Token: 0x04000278 RID: 632
			public long LastSentTime;

			// Token: 0x04000279 RID: 633
			public long PreviousTimestamp;
		}

		// Token: 0x020000B6 RID: 182
		public struct Parameters : INetworkParameter
		{
			// Token: 0x060002E3 RID: 739 RVA: 0x00010750 File Offset: 0x0000E950
			public bool Validate()
			{
				bool result = true;
				if (this.WindowSize < 0 || this.WindowSize > 64)
				{
					result = false;
					Debug.LogError(string.Format("{0} value ({1}) must be greater than 0 and smaller or equal to 32", "WindowSize", this.WindowSize));
				}
				return result;
			}

			// Token: 0x0400027A RID: 634
			public int WindowSize;
		}

		// Token: 0x020000B7 RID: 183
		public struct ParameterConstants
		{
			// Token: 0x0400027B RID: 635
			public const int WindowSize = 32;
		}

		// Token: 0x020000B8 RID: 184
		[Obsolete("Will be removed in Unity Transport 2.0.")]
		public struct PacketHeader
		{
			// Token: 0x0400027C RID: 636
			public ushort Type;

			// Token: 0x0400027D RID: 637
			public ushort ProcessingTime;

			// Token: 0x0400027E RID: 638
			public ushort SequenceId;

			// Token: 0x0400027F RID: 639
			public ushort AckedSequenceId;

			// Token: 0x04000280 RID: 640
			public uint AckMask;
		}

		// Token: 0x020000B9 RID: 185
		internal struct ReliableHeader
		{
			// Token: 0x04000281 RID: 641
			public ushort Type;

			// Token: 0x04000282 RID: 642
			public ushort ProcessingTime;

			// Token: 0x04000283 RID: 643
			public ushort SequenceId;

			// Token: 0x04000284 RID: 644
			public ushort AckedSequenceId;

			// Token: 0x04000285 RID: 645
			public ulong AckedMask;
		}

		// Token: 0x020000BA RID: 186
		public struct PacketInformation
		{
			// Token: 0x04000286 RID: 646
			public long SequenceId;

			// Token: 0x04000287 RID: 647
			public ushort Size;

			// Token: 0x04000288 RID: 648
			public ushort HeaderPadding;

			// Token: 0x04000289 RID: 649
			public long SendTime;
		}

		// Token: 0x020000BB RID: 187
		[Obsolete("Will be removed in Unity Transport 2.0.")]
		[StructLayout(LayoutKind.Explicit)]
		public struct Packet
		{
			// Token: 0x0400028A RID: 650
			internal const int Length = 1472;

			// Token: 0x0400028B RID: 651
			[FieldOffset(0)]
			public ReliableUtility.PacketHeader Header;

			// Token: 0x0400028C RID: 652
			[FixedBuffer(typeof(byte), 1472)]
			[FieldOffset(0)]
			public ReliableUtility.Packet.<Buffer>e__FixedBuffer Buffer;

			// Token: 0x020000BC RID: 188
			[CompilerGenerated]
			[UnsafeValueType]
			[StructLayout(LayoutKind.Sequential, Size = 1472)]
			public struct <Buffer>e__FixedBuffer
			{
				// Token: 0x0400028D RID: 653
				public byte FixedElementField;
			}
		}

		// Token: 0x020000BD RID: 189
		[StructLayout(LayoutKind.Explicit)]
		internal struct ReliablePacket
		{
			// Token: 0x0400028E RID: 654
			internal const int Length = 1476;

			// Token: 0x0400028F RID: 655
			[FieldOffset(0)]
			public ReliableUtility.ReliableHeader Header;

			// Token: 0x04000290 RID: 656
			[FixedBuffer(typeof(byte), 1476)]
			[FieldOffset(0)]
			public ReliableUtility.ReliablePacket.<Buffer>e__FixedBuffer Buffer;

			// Token: 0x020000BE RID: 190
			[CompilerGenerated]
			[UnsafeValueType]
			[StructLayout(LayoutKind.Sequential, Size = 1476)]
			public struct <Buffer>e__FixedBuffer
			{
				// Token: 0x04000291 RID: 657
				public byte FixedElementField;
			}
		}

		// Token: 0x020000BF RID: 191
		public struct PacketTimers
		{
			// Token: 0x04000292 RID: 658
			public ushort ProcessingTime;

			// Token: 0x04000293 RID: 659
			public ushort Padding;

			// Token: 0x04000294 RID: 660
			public long SequenceId;

			// Token: 0x04000295 RID: 661
			public long SentTime;

			// Token: 0x04000296 RID: 662
			public long ReceiveTime;
		}
	}
}
