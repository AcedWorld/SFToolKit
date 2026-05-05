using System;
using Unity.Baselib.LowLevel;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Networking.QoS
{
	// Token: 0x0200000A RID: 10
	internal class QosRequest
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000023 RID: 35 RVA: 0x00002CF3 File Offset: 0x00000EF3
		internal byte Magic
		{
			get
			{
				return this.m_Magic;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002CFB File Offset: 0x00000EFB
		internal byte Version
		{
			get
			{
				return (byte)(this.m_VerAndFlow >> 4 & 15);
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002D09 File Offset: 0x00000F09
		internal byte FlowControl
		{
			get
			{
				return this.m_VerAndFlow & 15;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002D15 File Offset: 0x00000F15
		// (set) Token: 0x06000027 RID: 39 RVA: 0x00002D20 File Offset: 0x00000F20
		internal byte[] Title
		{
			get
			{
				return this.m_Title;
			}
			set
			{
				if (15 + value.Length > 1500)
				{
					throw new ArgumentException(string.Format("Encoded title would make the QosPacket have size {0}. Max size is {1}.", 15 + value.Length, 1500));
				}
				this.m_Title = value;
				this.m_TitleLen = (byte)(this.m_Title.Length + 1);
				this.m_PacketLength = (ushort)(14 + this.m_Title.Length);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002D89 File Offset: 0x00000F89
		// (set) Token: 0x06000029 RID: 41 RVA: 0x00002D91 File Offset: 0x00000F91
		internal byte Sequence
		{
			get
			{
				return this.m_Sequence;
			}
			set
			{
				this.m_Sequence = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002D9A File Offset: 0x00000F9A
		// (set) Token: 0x0600002B RID: 43 RVA: 0x00002DA2 File Offset: 0x00000FA2
		internal ushort Identifier
		{
			get
			{
				return this.m_Identifier;
			}
			set
			{
				this.m_Identifier = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00002DAB File Offset: 0x00000FAB
		// (set) Token: 0x0600002D RID: 45 RVA: 0x00002DB3 File Offset: 0x00000FB3
		internal ulong Timestamp
		{
			get
			{
				return this.m_Timestamp;
			}
			set
			{
				this.m_Timestamp = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00002DBC File Offset: 0x00000FBC
		internal int Length
		{
			get
			{
				return (int)this.m_PacketLength;
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002DC4 File Offset: 0x00000FC4
		internal unsafe ValueTuple<uint, int> Send(IntPtr socketHandle, NetworkEndPoint endPoint, DateTime expireTimeUtc)
		{
			if (this.Title == null)
			{
				throw new InvalidOperationException("QosRequest requires a title.");
			}
			UnsafeAppendBuffer unsafeAppendBuffer = this.Serialize();
			uint length = (uint)unsafeAppendBuffer.Length;
			Binding.Baselib_Socket_Message baselib_Socket_Message = default(Binding.Baselib_Socket_Message);
			baselib_Socket_Message.address = &endPoint.rawNetworkAddress;
			baselib_Socket_Message.data = new IntPtr((void*)unsafeAppendBuffer.Ptr);
			baselib_Socket_Message.dataLen = length;
			Binding.Baselib_ErrorState baselib_ErrorState = default(Binding.Baselib_ErrorState);
			Binding.Baselib_Socket_Handle socket = new Binding.Baselib_Socket_Handle
			{
				handle = socketHandle
			};
			while (Binding.Baselib_Socket_UDP_Send(socket, &baselib_Socket_Message, 1U, &baselib_ErrorState) == 0U && QosHelper.WouldBlock(baselib_ErrorState.nativeErrorCode) && !QosHelper.ExpiredUtc(expireTimeUtc))
			{
			}
			unsafeAppendBuffer.Dispose();
			return new ValueTuple<uint, int>((uint)this.Length, (int)baselib_ErrorState.code);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002E84 File Offset: 0x00001084
		internal UnsafeAppendBuffer Serialize()
		{
			int initialCapacity = 2048;
			UnsafeAppendBuffer result = new UnsafeAppendBuffer(initialCapacity, 16, Allocator.TempJob);
			result.Add<byte>(this.m_Magic);
			result.Add<byte>(this.m_VerAndFlow);
			result.Add<byte>(this.m_TitleLen);
			for (int i = 0; i < (int)(this.m_TitleLen - 1); i++)
			{
				result.Add<byte>(this.m_Title[i]);
			}
			result.Add<byte>(this.m_Sequence);
			byte value = (byte)(this.m_Identifier & 255);
			byte value2 = (byte)((this.m_Identifier & 65280) >> 8);
			result.Add<byte>(value);
			result.Add<byte>(value2);
			byte value3 = (byte)(this.m_Timestamp & 255UL);
			byte value4 = (byte)((this.m_Timestamp & 65280UL) >> 8);
			byte value5 = (byte)((this.m_Timestamp & 16711680UL) >> 16);
			byte value6 = (byte)((this.m_Timestamp & (ulong)-16777216) >> 24);
			byte value7 = (byte)((this.m_Timestamp & 1095216660480UL) >> 32);
			byte value8 = (byte)((this.m_Timestamp & 280375465082880UL) >> 40);
			byte value9 = (byte)((this.m_Timestamp & 71776119061217280UL) >> 48);
			byte value10 = (byte)((this.m_Timestamp & 18374686479671623680UL) >> 56);
			result.Add<byte>(value3);
			result.Add<byte>(value4);
			result.Add<byte>(value5);
			result.Add<byte>(value6);
			result.Add<byte>(value7);
			result.Add<byte>(value8);
			result.Add<byte>(value9);
			result.Add<byte>(value10);
			return result;
		}

		// Token: 0x04000022 RID: 34
		private const int MinPacketLen = 15;

		// Token: 0x04000023 RID: 35
		private const int MaxPacketLen = 1500;

		// Token: 0x04000024 RID: 36
		private const byte RequestMagic = 89;

		// Token: 0x04000025 RID: 37
		private const int ConstructedPacketLen = 14;

		// Token: 0x04000026 RID: 38
		private byte m_Magic = 89;

		// Token: 0x04000027 RID: 39
		private byte m_VerAndFlow;

		// Token: 0x04000028 RID: 40
		private byte m_TitleLen;

		// Token: 0x04000029 RID: 41
		private byte[] m_Title;

		// Token: 0x0400002A RID: 42
		private byte m_Sequence;

		// Token: 0x0400002B RID: 43
		private ushort m_Identifier;

		// Token: 0x0400002C RID: 44
		private ulong m_Timestamp;

		// Token: 0x0400002D RID: 45
		private ushort m_PacketLength = 14;
	}
}
