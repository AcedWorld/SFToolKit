using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

namespace Unity.Netcode.Components
{
	// Token: 0x0200000E RID: 14
	public struct HalfVector3 : INetworkSerializable
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600003D RID: 61 RVA: 0x0000333F File Offset: 0x0000153F
		public half X
		{
			get
			{
				return this.Axis.x;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600003E RID: 62 RVA: 0x0000334C File Offset: 0x0000154C
		public half Y
		{
			get
			{
				return this.Axis.y;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00003359 File Offset: 0x00001559
		public half Z
		{
			get
			{
				return this.Axis.z;
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003366 File Offset: 0x00001566
		internal void Set(float x, float y, float z)
		{
			this.Axis.x = math.half(x);
			this.Axis.y = math.half(y);
			this.Axis.z = math.half(z);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000339C File Offset: 0x0000159C
		private void SerializeWrite(FastBufferWriter writer)
		{
			for (int i = 0; i < 3; i++)
			{
				if (this.AxisToSynchronize[i])
				{
					half half = this.Axis[i];
					writer.WriteUnmanagedSafe<half>(half);
				}
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000033DC File Offset: 0x000015DC
		private void SerializeRead(FastBufferReader reader)
		{
			for (int i = 0; i < 3; i++)
			{
				if (this.AxisToSynchronize[i])
				{
					half value = this.Axis[i];
					reader.ReadUnmanagedSafe<half>(out value);
					this.Axis[i] = value;
				}
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003426 File Offset: 0x00001626
		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
			if (serializer.IsReader)
			{
				this.SerializeRead(serializer.GetFastBufferReader());
				return;
			}
			this.SerializeWrite(serializer.GetFastBufferWriter());
		}

		// Token: 0x06000044 RID: 68 RVA: 0x0000344C File Offset: 0x0000164C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 ToVector3()
		{
			Vector3 zero = Vector3.zero;
			Vector3 vector = math.float3(this.Axis);
			for (int i = 0; i < 3; i++)
			{
				if (this.AxisToSynchronize[i])
				{
					zero[i] = vector[i];
				}
			}
			return zero;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x0000349C File Offset: 0x0000169C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void UpdateFrom(ref Vector3 vector3)
		{
			half3 half = math.half3(vector3);
			for (int i = 0; i < 3; i++)
			{
				if (this.AxisToSynchronize[i])
				{
					this.Axis[i] = half[i];
				}
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000034E8 File Offset: 0x000016E8
		public HalfVector3(Vector3 vector3, bool3 axisToSynchronize)
		{
			this.Axis = half3.zero;
			this.AxisToSynchronize = axisToSynchronize;
			this.UpdateFrom(ref vector3);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003504 File Offset: 0x00001704
		public HalfVector3(Vector3 vector3)
		{
			this = new HalfVector3(vector3, math.bool3(true));
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00003513 File Offset: 0x00001713
		public HalfVector3(float x, float y, float z, bool3 axisToSynchronize)
		{
			this = new HalfVector3(new Vector3(x, y, z), axisToSynchronize);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003525 File Offset: 0x00001725
		public HalfVector3(float x, float y, float z)
		{
			this = new HalfVector3(new Vector3(x, y, z), math.bool3(true));
		}

		// Token: 0x04000037 RID: 55
		internal const int Length = 3;

		// Token: 0x04000038 RID: 56
		public half3 Axis;

		// Token: 0x04000039 RID: 57
		public bool3 AxisToSynchronize;
	}
}
