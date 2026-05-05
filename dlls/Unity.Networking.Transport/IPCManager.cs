using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Networking.Transport.Utilities;

namespace Unity.Networking.Transport
{
	// Token: 0x02000020 RID: 32
	internal struct IPCManager
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000BC RID: 188 RVA: 0x000046E0 File Offset: 0x000028E0
		public bool IsCreated
		{
			get
			{
				return this.m_IPCQueue.IsCreated;
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000046ED File Offset: 0x000028ED
		public void AddRef()
		{
			if (this.m_RefCount == 0)
			{
				this.m_IPCQueue = new NativeMultiQueue<IPCManager.IPCData>(128);
				this.m_IPCChannels = new NativeHashMap<ushort, int>(64, Allocator.Persistent);
			}
			this.m_RefCount++;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00004728 File Offset: 0x00002928
		public void Release()
		{
			this.m_RefCount--;
			if (this.m_RefCount == 0)
			{
				IPCManager.ManagerAccessHandle.Complete();
				this.m_IPCQueue.Dispose();
				this.m_IPCChannels.Dispose();
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00004760 File Offset: 0x00002960
		internal unsafe void Update(NetworkInterfaceEndPoint local, NativeQueue<QueuedSendMessage> queue)
		{
			QueuedSendMessage queuedSendMessage;
			while (queue.TryDequeue(out queuedSendMessage))
			{
				IPCManager.IPCData value = default(IPCManager.IPCData);
				UnsafeUtility.MemCpy((void*)(&value.data.FixedElementField), (void*)(&queuedSendMessage.Data.FixedElementField), (long)queuedSendMessage.DataLength);
				value.length = queuedSendMessage.DataLength;
				value.from = *(int*)(&local.data.FixedElementField);
				this.m_IPCQueue.Enqueue(*(int*)(&queuedSendMessage.Dest.data.FixedElementField), value);
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x000047EC File Offset: 0x000029EC
		public unsafe NetworkInterfaceEndPoint CreateEndPoint(ushort port)
		{
			IPCManager.ManagerAccessHandle.Complete();
			int num = 0;
			if (port == 0)
			{
				while (num == 0)
				{
					port = RandomHelpers.GetRandomUShort();
					int num2;
					if (!this.m_IPCChannels.TryGetValue(port, out num2))
					{
						num = this.m_IPCChannels.Count() + 1;
						this.m_IPCChannels.TryAdd(port, num);
					}
				}
			}
			else if (!this.m_IPCChannels.TryGetValue(port, out num))
			{
				num = this.m_IPCChannels.Count() + 1;
				this.m_IPCChannels.TryAdd(port, num);
			}
			NetworkInterfaceEndPoint result = default(NetworkInterfaceEndPoint);
			result.dataLength = 4;
			*(int*)(&result.data.FixedElementField) = num;
			return result;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00004890 File Offset: 0x00002A90
		public unsafe bool GetEndPointPort(NetworkInterfaceEndPoint ep, out ushort port)
		{
			IPCManager.ManagerAccessHandle.Complete();
			int num = *(int*)(&ep.data.FixedElementField);
			NativeArray<int> valueArray = this.m_IPCChannels.GetValueArray(Allocator.Temp);
			NativeArray<ushort> keyArray = this.m_IPCChannels.GetKeyArray(Allocator.Temp);
			port = 0;
			for (int i = 0; i < this.m_IPCChannels.Count(); i++)
			{
				if (valueArray[i] == num)
				{
					port = keyArray[i];
					return true;
				}
			}
			return false;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000490C File Offset: 0x00002B0C
		public unsafe int PeekNext(NetworkInterfaceEndPoint local, void* slice, out int length, out NetworkInterfaceEndPoint from)
		{
			IPCManager.ManagerAccessHandle.Complete();
			from = default(NetworkInterfaceEndPoint);
			length = 0;
			IPCManager.IPCData ipcdata;
			if (this.m_IPCQueue.Peek(*(int*)(&local.data.FixedElementField), out ipcdata))
			{
				UnsafeUtility.MemCpy(slice, (void*)(&ipcdata.data.FixedElementField), (long)ipcdata.length);
				length = ipcdata.length;
			}
			this.GetEndPointByHandle(ipcdata.from, out from);
			return length;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00004980 File Offset: 0x00002B80
		public unsafe int ReceiveMessageEx(NetworkInterfaceEndPoint local, void* payloadData, int payloadLen, ref NetworkInterfaceEndPoint remote)
		{
			IPCManager.IPCData ipcdata;
			if (!this.m_IPCQueue.Peek(*(int*)(&local.data.FixedElementField), out ipcdata))
			{
				return 0;
			}
			this.GetEndPointByHandle(ipcdata.from, out remote);
			int num = Math.Min(payloadLen, ipcdata.length);
			UnsafeUtility.MemCpy(payloadData, (void*)(&ipcdata.data.FixedElementField), (long)num);
			if (num < ipcdata.length)
			{
				return -10040;
			}
			this.m_IPCQueue.Dequeue(*(int*)(&local.data.FixedElementField), out ipcdata);
			return num;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00004A08 File Offset: 0x00002C08
		private unsafe void GetEndPointByHandle(int handle, out NetworkInterfaceEndPoint endpoint)
		{
			NetworkInterfaceEndPoint networkInterfaceEndPoint = default(NetworkInterfaceEndPoint);
			networkInterfaceEndPoint.dataLength = 4;
			*(int*)(&networkInterfaceEndPoint.data.FixedElementField) = handle;
			endpoint = networkInterfaceEndPoint;
		}

		// Token: 0x04000052 RID: 82
		public static IPCManager Instance;

		// Token: 0x04000053 RID: 83
		private NativeMultiQueue<IPCManager.IPCData> m_IPCQueue;

		// Token: 0x04000054 RID: 84
		private NativeHashMap<ushort, int> m_IPCChannels;

		// Token: 0x04000055 RID: 85
		internal static JobHandle ManagerAccessHandle;

		// Token: 0x04000056 RID: 86
		private int m_RefCount;

		// Token: 0x02000021 RID: 33
		[StructLayout(LayoutKind.Explicit)]
		internal struct IPCData
		{
			// Token: 0x04000057 RID: 87
			[FieldOffset(0)]
			public int from;

			// Token: 0x04000058 RID: 88
			[FieldOffset(4)]
			public int length;

			// Token: 0x04000059 RID: 89
			[FixedBuffer(typeof(byte), 1472)]
			[FieldOffset(8)]
			public IPCManager.IPCData.<data>e__FixedBuffer data;

			// Token: 0x02000022 RID: 34
			[CompilerGenerated]
			[UnsafeValueType]
			[StructLayout(LayoutKind.Sequential, Size = 1472)]
			public struct <data>e__FixedBuffer
			{
				// Token: 0x0400005A RID: 90
				public byte FixedElementField;
			}
		}
	}
}
