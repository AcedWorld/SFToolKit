using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

namespace Unity.Netcode.Components
{
	// Token: 0x0200000F RID: 15
	public struct HalfVector4 : INetworkSerializable
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600004A RID: 74 RVA: 0x0000353B File Offset: 0x0000173B
		public half X
		{
			get
			{
				return this.Axis.x;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00003548 File Offset: 0x00001748
		public half Y
		{
			get
			{
				return this.Axis.y;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600004C RID: 76 RVA: 0x00003555 File Offset: 0x00001755
		public half Z
		{
			get
			{
				return this.Axis.z;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00003562 File Offset: 0x00001762
		public half W
		{
			get
			{
				return this.Axis.w;
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003570 File Offset: 0x00001770
		private void SerializeWrite(FastBufferWriter writer)
		{
			for (int i = 0; i < 4; i++)
			{
				half half = this.Axis[i];
				writer.WriteUnmanagedSafe<half>(half);
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000035A0 File Offset: 0x000017A0
		private void SerializeRead(FastBufferReader reader)
		{
			for (int i = 0; i < 4; i++)
			{
				half value = this.Axis[i];
				reader.ReadUnmanagedSafe<half>(out value);
				this.Axis[i] = value;
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000035DC File Offset: 0x000017DC
		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
			if (serializer.IsReader)
			{
				this.SerializeRead(serializer.GetFastBufferReader());
				return;
			}
			this.SerializeWrite(serializer.GetFastBufferWriter());
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003602 File Offset: 0x00001802
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector4 ToVector4()
		{
			return math.float4(this.Axis);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003614 File Offset: 0x00001814
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Quaternion ToQuaternion()
		{
			return math.quaternion(this.Axis);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000362B File Offset: 0x0000182B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void UpdateFrom(ref Vector4 vector4)
		{
			this.Axis = math.half4(vector4);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003643 File Offset: 0x00001843
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void UpdateFrom(ref Quaternion quaternion)
		{
			this.Axis = math.half4(math.half(quaternion.x), math.half(quaternion.y), math.half(quaternion.z), math.half(quaternion.w));
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000367C File Offset: 0x0000187C
		public HalfVector4(Vector4 vector4)
		{
			this.Axis = default(half4);
			this.UpdateFrom(ref vector4);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00003692 File Offset: 0x00001892
		public HalfVector4(float x, float y, float z, float w)
		{
			this = new HalfVector4(new Vector4(x, y, z, w));
		}

		// Token: 0x0400003A RID: 58
		internal const int Length = 4;

		// Token: 0x0400003B RID: 59
		public half4 Axis;
	}
}
