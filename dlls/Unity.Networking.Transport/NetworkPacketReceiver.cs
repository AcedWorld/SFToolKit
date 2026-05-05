using System;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Networking.Transport
{
	// Token: 0x02000016 RID: 22
	public struct NetworkPacketReceiver
	{
		// Token: 0x0600009F RID: 159 RVA: 0x000045D8 File Offset: 0x000027D8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public IntPtr AllocateMemory(ref int dataLen)
		{
			return this.m_Driver.AllocateMemory(ref dataLen);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x000045E8 File Offset: 0x000027E8
		public bool AppendPacket(IntPtr data, ref NetworkInterfaceEndPoint address, int dataLen, NetworkPacketReceiver.AppendPacketMode mode = NetworkPacketReceiver.AppendPacketMode.None)
		{
			if ((mode & NetworkPacketReceiver.AppendPacketMode.NoCopyNeeded) != NetworkPacketReceiver.AppendPacketMode.None)
			{
				this.m_Driver.AppendPacket(data, ref address, dataLen);
				return true;
			}
			int num = dataLen;
			IntPtr intPtr = this.m_Driver.AllocateMemory(ref num);
			if (intPtr == IntPtr.Zero || num < dataLen)
			{
				this.OutOfMemoryError();
				return false;
			}
			UnsafeUtility.MemCpy(intPtr.ToPointer(), data.ToPointer(), (long)dataLen);
			this.m_Driver.AppendPacket(intPtr, ref address, dataLen);
			return true;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00004658 File Offset: 0x00002858
		public bool IsAddressUsed(NetworkInterfaceEndPoint address)
		{
			return this.m_Driver.IsAddressUsed(address);
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x00004666 File Offset: 0x00002866
		public long LastUpdateTime
		{
			get
			{
				return this.m_Driver.LastUpdateTime;
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00004673 File Offset: 0x00002873
		private void OutOfMemoryError()
		{
			this.ReceiveErrorCode = 10040;
		}

		// Token: 0x17000011 RID: 17
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x00004680 File Offset: 0x00002880
		public int ReceiveErrorCode
		{
			set
			{
				this.m_Driver.ReceiveErrorCode = value;
			}
		}

		// Token: 0x04000042 RID: 66
		internal NetworkDriver m_Driver;

		// Token: 0x02000017 RID: 23
		[Flags]
		public enum AppendPacketMode
		{
			// Token: 0x04000044 RID: 68
			None = 0,
			// Token: 0x04000045 RID: 69
			NoCopyNeeded = 1
		}
	}
}
