using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Baselib.LowLevel;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Networking.QoS
{
	// Token: 0x0200000C RID: 12
	internal class QosResponse
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00003031 File Offset: 0x00001231
		internal byte Magic
		{
			get
			{
				return this.m_Magic;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00003039 File Offset: 0x00001239
		internal byte Version
		{
			get
			{
				return (byte)(this.m_VerAndFlow >> 4 & 15);
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00003047 File Offset: 0x00001247
		internal byte FlowControl
		{
			get
			{
				return this.m_VerAndFlow & 15;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00003053 File Offset: 0x00001253
		internal byte Sequence
		{
			get
			{
				return this.m_Sequence;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000036 RID: 54 RVA: 0x0000305B File Offset: 0x0000125B
		internal ushort Identifier
		{
			get
			{
				return this.m_Identifier;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00003063 File Offset: 0x00001263
		internal ulong Timestamp
		{
			get
			{
				return this.m_Timestamp;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000038 RID: 56 RVA: 0x0000306B File Offset: 0x0000126B
		internal ushort Length
		{
			get
			{
				return this.m_PacketLength;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00003073 File Offset: 0x00001273
		internal int LatencyMs
		{
			get
			{
				return this.m_LatencyMs;
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000307C File Offset: 0x0000127C
		[return: TupleElementNames(new string[]
		{
			"received",
			"errorCode"
		})]
		internal unsafe ValueTuple<int, int> Recv(IntPtr socketHandle, bool wait, DateTime expireTimeUtc, ref NetworkEndPoint endPoint)
		{
			Binding.Baselib_Socket_Message baselib_Socket_Message = default(Binding.Baselib_Socket_Message);
			UnsafeAppendBuffer unsafeAppendBuffer = new UnsafeAppendBuffer(2048, 16, Allocator.Persistent);
			DateTime utcNow = DateTime.UtcNow;
			fixed (Binding.Baselib_NetworkAddress* ptr = &endPoint.rawNetworkAddress)
			{
				Binding.Baselib_NetworkAddress* address = ptr;
				baselib_Socket_Message.dataLen = (uint)unsafeAppendBuffer.Capacity;
				baselib_Socket_Message.address = address;
				baselib_Socket_Message.data = new IntPtr((void*)unsafeAppendBuffer.Ptr);
				Binding.Baselib_ErrorState baselib_ErrorState = default(Binding.Baselib_ErrorState);
				Binding.Baselib_Socket_Handle socket = new Binding.Baselib_Socket_Handle
				{
					handle = socketHandle
				};
				uint num = 0U;
				int num2 = 0;
				while (!QosHelper.ExpiredUtc(expireTimeUtc))
				{
					baselib_ErrorState = default(Binding.Baselib_ErrorState);
					num2++;
					num = Binding.Baselib_Socket_UDP_Recv(socket, &baselib_Socket_Message, 1U, &baselib_ErrorState);
					if (num != 0U || !QosHelper.WouldBlock(baselib_ErrorState.nativeErrorCode))
					{
						break;
					}
					if (!wait)
					{
						return new ValueTuple<int, int>(0, 0);
					}
				}
				if (num == 0U)
				{
					unsafeAppendBuffer.Dispose();
					return new ValueTuple<int, int>(0, (int)baselib_ErrorState.code);
				}
				endPoint.rawNetworkAddress = *baselib_Socket_Message.address;
				this.m_PacketLength = (ushort)baselib_Socket_Message.dataLen;
				this.Deserialize(baselib_Socket_Message.data);
				this.m_LatencyMs = ((this.Length >= 13) ? ((int)(DateTime.UtcNow.Ticks / 10000L - (long)this.m_Timestamp)) : -1);
			}
			unsafeAppendBuffer.Dispose();
			return new ValueTuple<int, int>((int)this.Length, 0);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000031D0 File Offset: 0x000013D0
		internal void Deserialize(IntPtr msgData)
		{
			this.m_Magic = Marshal.ReadByte(msgData);
			this.m_VerAndFlow = Marshal.ReadByte(msgData, 1);
			this.m_Sequence = Marshal.ReadByte(msgData, 2);
			ushort num = (ushort)Marshal.ReadByte(msgData, 3);
			ushort num2 = (ushort)(Marshal.ReadByte(msgData, 4) << 8);
			this.m_Identifier = num + num2;
			ulong num3 = (ulong)Marshal.ReadByte(msgData, 5);
			ulong num4 = (ulong)Marshal.ReadByte(msgData, 6) << 8;
			ulong num5 = (ulong)Marshal.ReadByte(msgData, 7) << 16;
			ulong num6 = (ulong)Marshal.ReadByte(msgData, 8) << 24;
			ulong num7 = (ulong)Marshal.ReadByte(msgData, 9) << 32;
			ulong num8 = (ulong)Marshal.ReadByte(msgData, 10) << 40;
			ulong num9 = (ulong)Marshal.ReadByte(msgData, 11) << 48;
			ulong num10 = (ulong)Marshal.ReadByte(msgData, 12) << 56;
			this.m_Timestamp = num3 + num4 + num5 + num6 + num7 + num8 + num9 + num10;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000032A4 File Offset: 0x000014A4
		internal bool Verify(uint maxSequence, ref string error)
		{
			if (this.Length < 13)
			{
				error = string.Format("response is too small got {0} bytes min expected {1} bytes", this.Length, 13);
				return false;
			}
			if (this.Magic != 149)
			{
				error = string.Format("response contains an invalid signature 0x{0:X} expected 0x{1:X}", this.Magic, 149);
				return false;
			}
			if (this.Version != 0)
			{
				error = string.Format("response contains an invalid version {0} expected {1}", this.Version, 0);
				return false;
			}
			if ((uint)this.Sequence > maxSequence)
			{
				error = string.Format("response contains an invalid sequence {0} max expected {1}", this.Sequence, maxSequence);
				return false;
			}
			return true;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000335C File Offset: 0x0000155C
		[return: TupleElementNames(new string[]
		{
			"type",
			"units"
		})]
		internal ValueTuple<FcType, byte> ParseFlowControl()
		{
			if (this.FlowControl == 0)
			{
				return new ValueTuple<FcType, byte>(FcType.None, 0);
			}
			object obj = ((this.FlowControl & 8) != 0) ? 2 : 1;
			byte b = this.FlowControl & 7;
			object obj2 = obj;
			if (obj2 == 2)
			{
				b += 1;
			}
			return new ValueTuple<FcType, byte>(obj2, b);
		}

		// Token: 0x04000032 RID: 50
		private const int MinPacketLen = 13;

		// Token: 0x04000033 RID: 51
		private const int MaxPacketLen = 1500;

		// Token: 0x04000034 RID: 52
		private const byte ResponseMagic = 149;

		// Token: 0x04000035 RID: 53
		private const byte ResponseVersion = 0;

		// Token: 0x04000036 RID: 54
		private byte m_Magic;

		// Token: 0x04000037 RID: 55
		private byte m_VerAndFlow;

		// Token: 0x04000038 RID: 56
		private byte m_Sequence;

		// Token: 0x04000039 RID: 57
		private ushort m_Identifier;

		// Token: 0x0400003A RID: 58
		private ulong m_Timestamp;

		// Token: 0x0400003B RID: 59
		private int m_LatencyMs;

		// Token: 0x0400003C RID: 60
		private ushort m_PacketLength;
	}
}
