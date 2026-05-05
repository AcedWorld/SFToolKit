using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

namespace Unity.Netcode.Components
{
	// Token: 0x0200001D RID: 29
	public struct NetworkDeltaPosition : INetworkSerializable
	{
		// Token: 0x06000095 RID: 149 RVA: 0x00005F08 File Offset: 0x00004108
		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
			if (!this.SynchronizeBase)
			{
				this.HalfVector3.NetworkSerialize<T>(serializer);
				return;
			}
			serializer.SerializeValue(ref this.DeltaPosition);
			serializer.SerializeValue(ref this.CurrentBasePosition);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00005F3C File Offset: 0x0000413C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 ToVector3(int networkTick)
		{
			if (networkTick == this.NetworkTick)
			{
				return this.CurrentBasePosition + this.DeltaPosition;
			}
			for (int i = 0; i < 3; i++)
			{
				if (this.HalfVector3.AxisToSynchronize[i])
				{
					this.DeltaPosition[i] = Mathf.HalfToFloat(this.HalfVector3.Axis[i].value);
					if (Mathf.Abs(this.DeltaPosition[i]) >= 64f)
					{
						ref Vector3 ptr = ref this.CurrentBasePosition;
						int index = i;
						ptr[index] += this.DeltaPosition[i];
						this.DeltaPosition[i] = 0f;
						this.HalfVector3.Axis[i] = half.zero;
					}
				}
			}
			return this.CurrentBasePosition + this.DeltaPosition;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00006027 File Offset: 0x00004227
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 GetCurrentBasePosition()
		{
			return this.CurrentBasePosition;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000602F File Offset: 0x0000422F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 GetFullPosition()
		{
			return this.CurrentBasePosition + this.DeltaPosition;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00006042 File Offset: 0x00004242
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 GetConvertedDelta()
		{
			return this.HalfDeltaConvertedBack;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000604A File Offset: 0x0000424A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 GetDeltaPosition()
		{
			return this.DeltaPosition;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00006054 File Offset: 0x00004254
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void UpdateFrom(ref Vector3 vector3, int networkTick)
		{
			this.CollapsedDeltaIntoBase = false;
			this.NetworkTick = networkTick;
			this.DeltaPosition = vector3 + this.PrecisionLossDelta - this.CurrentBasePosition;
			for (int i = 0; i < 3; i++)
			{
				if (this.HalfVector3.AxisToSynchronize[i])
				{
					this.HalfVector3.Axis[i] = math.half(this.DeltaPosition[i]);
					this.HalfDeltaConvertedBack[i] = Mathf.HalfToFloat(this.HalfVector3.Axis[i].value);
					this.PrecisionLossDelta[i] = this.DeltaPosition[i] - this.HalfDeltaConvertedBack[i];
					if (Mathf.Abs(this.HalfDeltaConvertedBack[i]) >= 64f)
					{
						ref Vector3 ptr = ref this.CurrentBasePosition;
						int index = i;
						ptr[index] += this.HalfDeltaConvertedBack[i];
						this.HalfDeltaConvertedBack[i] = 0f;
						this.DeltaPosition[i] = 0f;
						this.CollapsedDeltaIntoBase = true;
					}
				}
			}
			for (int j = 0; j < 3; j++)
			{
				if (this.HalfVector3.AxisToSynchronize[j])
				{
					this.PreviousPosition[j] = vector3[j];
				}
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000061C0 File Offset: 0x000043C0
		public NetworkDeltaPosition(Vector3 vector3, int networkTick, bool3 axisToSynchronize)
		{
			this.NetworkTick = networkTick;
			this.CurrentBasePosition = vector3;
			this.PreviousPosition = vector3;
			this.PrecisionLossDelta = Vector3.zero;
			this.DeltaPosition = Vector3.zero;
			this.HalfDeltaConvertedBack = Vector3.zero;
			this.HalfVector3 = new HalfVector3(vector3, axisToSynchronize);
			this.SynchronizeBase = false;
			this.CollapsedDeltaIntoBase = false;
			this.UpdateFrom(ref vector3, networkTick);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00006227 File Offset: 0x00004427
		public NetworkDeltaPosition(Vector3 vector3, int networkTick)
		{
			this = new NetworkDeltaPosition(vector3, networkTick, math.bool3(true));
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00006237 File Offset: 0x00004437
		public NetworkDeltaPosition(float x, float y, float z, int networkTick, bool3 axisToSynchronize)
		{
			this = new NetworkDeltaPosition(new Vector3(x, y, z), networkTick, axisToSynchronize);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000624B File Offset: 0x0000444B
		public NetworkDeltaPosition(float x, float y, float z, int networkTick)
		{
			this = new NetworkDeltaPosition(new Vector3(x, y, z), networkTick, math.bool3(true));
		}

		// Token: 0x04000079 RID: 121
		internal const float MaxDeltaBeforeAdjustment = 64f;

		// Token: 0x0400007A RID: 122
		public HalfVector3 HalfVector3;

		// Token: 0x0400007B RID: 123
		internal Vector3 CurrentBasePosition;

		// Token: 0x0400007C RID: 124
		internal Vector3 PrecisionLossDelta;

		// Token: 0x0400007D RID: 125
		internal Vector3 HalfDeltaConvertedBack;

		// Token: 0x0400007E RID: 126
		internal Vector3 PreviousPosition;

		// Token: 0x0400007F RID: 127
		internal Vector3 DeltaPosition;

		// Token: 0x04000080 RID: 128
		internal int NetworkTick;

		// Token: 0x04000081 RID: 129
		internal bool SynchronizeBase;

		// Token: 0x04000082 RID: 130
		internal bool CollapsedDeltaIntoBase;
	}
}
