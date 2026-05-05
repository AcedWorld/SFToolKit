using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200021E RID: 542
	internal class WaterCPUSimulation
	{
		// Token: 0x06000FCA RID: 4042 RVA: 0x0007A5BC File Offset: 0x000787BC
		internal static uint4 WaterHashFunctionUInt4(uint3 coord)
		{
			uint4 x = coord.xyzz;
			x = (x >> 16 ^ x.yzxy) * 73244475U;
			x = (x >> 16 ^ x.yzxz) * 73244475U;
			return (x >> 16 ^ x.yzxx) * 73244475U;
		}

		// Token: 0x06000FCB RID: 4043 RVA: 0x0007A630 File Offset: 0x00078830
		internal static float4 WaterHashFunctionFloat4(uint3 p)
		{
			uint4 @uint = WaterCPUSimulation.WaterHashFunctionUInt4(p);
			return new float4(@uint.x, @uint.y, @uint.z, @uint.w) / 4.2949673E+09f;
		}

		// Token: 0x06000FCC RID: 4044 RVA: 0x0007A673 File Offset: 0x00078873
		internal static float GaussianDis(float u, float v)
		{
			return Mathf.Sqrt(-2f * Mathf.Log(Mathf.Max(u, 1E-06f))) * Mathf.Cos(3.1415927f * v);
		}

		// Token: 0x06000FCD RID: 4045 RVA: 0x0007A69D File Offset: 0x0007889D
		internal static float2 ComplexExp(float arg)
		{
			return new float2(Mathf.Cos(arg), Mathf.Sin(arg));
		}

		// Token: 0x06000FCE RID: 4046 RVA: 0x0007A6B0 File Offset: 0x000788B0
		internal static float2 ComplexMult(float2 a, float2 b)
		{
			return new float2(a.x * b.x - a.y * b.y, a.x * b.y + a.y * b.x);
		}

		// Token: 0x0400186E RID: 6254
		internal const float k_EarthGravity = 9.81f;

		// Token: 0x0400186F RID: 6255
		internal const float k_OneOverSqrt2 = 0.70710677f;

		// Token: 0x04001870 RID: 6256
		internal const float k_PhillipsAmplitudeScalar = 0.2f;

		// Token: 0x04001871 RID: 6257
		internal const int k_NoiseFunctionOffset = 64;

		// Token: 0x0200044B RID: 1099
		[BurstCompile]
		internal struct PhillipsSpectrumInitialization : IJobParallelFor
		{
			// Token: 0x0600144F RID: 5199 RVA: 0x000995E8 File Offset: 0x000977E8
			private float Phillips(float2 k, float2 w, float V, float directionDampener, float patchSize)
			{
				float num = k.x * k.x + k.y * k.y;
				float num2 = 0f;
				if ((double)num != 0.0)
				{
					float num3 = V * V / 9.81f;
					float num4 = Mathf.Lerp(Vector2.Dot(k / Mathf.Sqrt(num), w), 0.5f, this.directionDampner);
					num2 = Mathf.Exp(-1f / (num * num3 * num3)) / (num * num) * (num4 * num4) * ((num4 < 0f) ? this.directionDampner : 1f);
				}
				return 0.2f * num2 / (patchSize * patchSize);
			}

			// Token: 0x06001450 RID: 5200 RVA: 0x00099698 File Offset: 0x00097898
			public void Execute(int index)
			{
				int num = index % this.simulationResolution;
				int num2 = index / this.simulationResolution;
				uint3 @uint = new uint3((uint)num, (uint)num2, (uint)this.sliceIndex);
				float4 @float = WaterCPUSimulation.WaterHashFunctionFloat4(new uint3((uint)(num + this.waterSampleOffset), (uint)(num2 + this.waterSampleOffset), (uint)this.sliceIndex) + 64U);
				float2 lhs = 0.70710677f * new float2(WaterCPUSimulation.GaussianDis(@float.x, @float.y), WaterCPUSimulation.GaussianDis(@float.z, @float.w));
				float2 k = 6.2831855f * (@uint.xy - (float)this.simulationResolution * 0.5f) / this.patchSize;
				float2 w = -HDRenderPipeline.OrientationToDirection(this.windOrientation);
				float f = this.Phillips(k, w, this.windSpeed, this.directionDampner, this.patchSize);
				this.H0Buffer[index + this.bufferOffset] = lhs * Mathf.Sqrt(f);
			}

			// Token: 0x040029A8 RID: 10664
			public int simulationResolution;

			// Token: 0x040029A9 RID: 10665
			public int waterSampleOffset;

			// Token: 0x040029AA RID: 10666
			public int sliceIndex;

			// Token: 0x040029AB RID: 10667
			public int bufferOffset;

			// Token: 0x040029AC RID: 10668
			public float windSpeed;

			// Token: 0x040029AD RID: 10669
			public float windOrientation;

			// Token: 0x040029AE RID: 10670
			public float directionDampner;

			// Token: 0x040029AF RID: 10671
			public float patchSize;

			// Token: 0x040029B0 RID: 10672
			[WriteOnly]
			[NativeDisableParallelForRestriction]
			public NativeArray<float2> H0Buffer;
		}

		// Token: 0x0200044C RID: 1100
		[BurstCompile]
		internal struct EvaluateDispersion : IJobParallelFor
		{
			// Token: 0x06001451 RID: 5201 RVA: 0x000997AC File Offset: 0x000979AC
			public void Execute(int index)
			{
				int num = index % this.simulationResolution;
				int num2 = index / this.simulationResolution;
				float2 @float = 6.2831855f * (new float2((float)num, (float)num2) - (float)this.simulationResolution * 0.5f) / this.patchSize;
				float num3 = Mathf.Sqrt(@float.x * @float.x + @float.y * @float.y);
				float num4 = Mathf.Sqrt(9.81f * num3);
				float2 b = new float2(@float.x / num3, 0f);
				float2 b2 = new float2(@float.y / num3, 0f);
				float2 float2 = WaterCPUSimulation.ComplexMult(this.H0Buffer[index + this.bufferOffset], WaterCPUSimulation.ComplexExp(num4 * this.simulationTime));
				float2 float3 = WaterCPUSimulation.ComplexMult(WaterCPUSimulation.ComplexMult(new float2(0f, -1f), b), float2);
				float2 float4 = WaterCPUSimulation.ComplexMult(WaterCPUSimulation.ComplexMult(new float2(0f, -1f), b2), float2);
				if (float.IsNaN(float3.x))
				{
					float3.x = 0f;
				}
				if (float.IsNaN(float3.y))
				{
					float3.y = 0f;
				}
				if (float.IsNaN(float4.x))
				{
					float4.x = 0f;
				}
				if (float.IsNaN(float4.y))
				{
					float4.y = 0f;
				}
				int num5 = this.simulationResolution / 2;
				if (num == num5 && num2 == num5)
				{
					float3 = new float2(0f, 0f);
					float4 = new float2(0f, 0f);
				}
				this.HtRealBuffer[index] = new float4(float2.x, float3.x, float4.x, 0f);
				this.HtImaginaryBuffer[index] = new float4(float2.y, float3.y, float4.y, 0f);
			}

			// Token: 0x040029B1 RID: 10673
			public int simulationResolution;

			// Token: 0x040029B2 RID: 10674
			public int bufferOffset;

			// Token: 0x040029B3 RID: 10675
			public float patchSize;

			// Token: 0x040029B4 RID: 10676
			public float simulationTime;

			// Token: 0x040029B5 RID: 10677
			[ReadOnly]
			public NativeArray<float2> H0Buffer;

			// Token: 0x040029B6 RID: 10678
			[WriteOnly]
			public NativeArray<float4> HtRealBuffer;

			// Token: 0x040029B7 RID: 10679
			[WriteOnly]
			public NativeArray<float4> HtImaginaryBuffer;
		}

		// Token: 0x0200044D RID: 1101
		[BurstCompile]
		internal struct InverseFFT : IJobParallelFor
		{
			// Token: 0x06001452 RID: 5202 RVA: 0x000999B0 File Offset: 0x00097BB0
			private uint2 reversebits_uint2(uint2 input)
			{
				uint2 @uint = (input & 2863311530U) >> 1 | (input & 1431655765U) << 1;
				@uint = ((@uint & 3435973836U) >> 2 | (@uint & 858993459U) << 2);
				@uint = ((@uint & 4042322160U) >> 4 | (@uint & 252645135U) << 4);
				@uint = ((@uint & 4278255360U) >> 8 | (@uint & 16711935U) << 8);
				return @uint >> 16 | @uint << 16;
			}

			// Token: 0x06001453 RID: 5203 RVA: 0x00099A74 File Offset: 0x00097C74
			private void GetButterflyValues(uint passIndex, uint x, out uint2 indices, out float2 weights)
			{
				uint num = 2U << (int)passIndex;
				uint num2 = num / 2U;
				uint num3 = x & ~(num - 1U);
				uint num4 = x & num2 - 1U;
				uint num5 = x & num - 1U;
				float f = 6.2831855f * num5 / num;
				weights.y = -Mathf.Sin(f);
				weights.x = Mathf.Cos(f);
				indices.x = num3 + num4;
				indices.y = num3 + num4 + num2;
				if (passIndex == 0U)
				{
					uint2 @uint = this.reversebits_uint2(indices.xy);
					indices = new uint2(@uint.x >> 32 - this.butterflyCount & (uint)(this.simulationResolution - 1), @uint.y >> 32 - this.butterflyCount & (uint)(this.simulationResolution - 1));
				}
			}

			// Token: 0x06001454 RID: 5204 RVA: 0x00099B38 File Offset: 0x00097D38
			private void ButterflyPass(uint passIndex, uint x, uint t0, uint t1, int ppOffset, out float3 resultR, out float3 resultI)
			{
				uint2 @uint;
				float2 @float;
				this.GetButterflyValues(passIndex, x, out @uint, out @float);
				float3 lhs = this.pingPongArray[ppOffset + (int)(t0 * (uint)this.simulationResolution) + (int)@uint.x];
				float3 lhs2 = this.pingPongArray[ppOffset + (int)(t1 * (uint)this.simulationResolution) + (int)@uint.x];
				float3 rhs = this.pingPongArray[ppOffset + (int)(t0 * (uint)this.simulationResolution) + (int)@uint.y];
				float3 rhs2 = this.pingPongArray[ppOffset + (int)(t1 * (uint)this.simulationResolution) + (int)@uint.y];
				resultR = lhs + @float.x * rhs + @float.y * rhs2;
				resultI = lhs2 - @float.y * rhs + @float.x * rhs2;
			}

			// Token: 0x06001455 RID: 5205 RVA: 0x00099C28 File Offset: 0x00097E28
			public void Execute(int index)
			{
				int num = 4 * this.simulationResolution * index;
				for (int i = 0; i < this.simulationResolution; i++)
				{
					uint2 @uint;
					if (this.columnPass)
					{
						@uint = new uint2((uint)index, (uint)i);
					}
					else
					{
						@uint = new uint2((uint)i, (uint)index);
					}
					uint index2 = @uint.x + @uint.y * (uint)this.simulationResolution;
					this.pingPongArray[num + 0 + i] = this.HtRealBufferInput[(int)index2].xyz;
					this.pingPongArray[num + this.simulationResolution + i] = this.HtImaginaryBufferInput[(int)index2].xyz;
				}
				for (int j = 0; j < this.simulationResolution; j++)
				{
					this.textureIndicesArray[index * this.simulationResolution + j] = new uint4(0U, 1U, 2U, 3U);
				}
				for (int k = 0; k < this.butterflyCount - 1; k++)
				{
					for (int l = 0; l < this.simulationResolution; l++)
					{
						int2 @int = new int2(l, index);
						uint4 uint2 = this.textureIndicesArray[index * this.simulationResolution + l];
						float3 value;
						float3 value2;
						this.ButterflyPass((uint)k, (uint)l, uint2.x, uint2.y, num, out value, out value2);
						this.pingPongArray[num + (int)(uint2.z * (uint)this.simulationResolution) + @int.x] = value;
						this.pingPongArray[num + (int)(uint2.w * (uint)this.simulationResolution) + @int.x] = value2;
						uint2.xyzw = uint2.zwxy;
						this.textureIndicesArray[index * this.simulationResolution + @int.x] = uint2;
					}
				}
				for (int m = 0; m < this.simulationResolution; m++)
				{
					uint2 uint3;
					if (this.columnPass)
					{
						uint3 = new uint2((uint)index, (uint)m);
					}
					else
					{
						uint3 = new uint2((uint)m, (uint)index);
					}
					uint num2 = uint3.x + uint3.y * (uint)this.simulationResolution;
					uint4 uint4 = this.textureIndicesArray[index * this.simulationResolution + m];
					float3 @float;
					float3 xyz;
					this.ButterflyPass((uint)(this.butterflyCount - 1), (uint)m, uint4.x, uint4.y, num, out @float, out xyz);
					if (this.columnPass)
					{
						float rhs = ((m + index & 1) != 0) ? -1f : 1f;
						this.HtRealBufferOutput[(int)(num2 + (uint)this.bufferOffset)] = new float4(@float * rhs, 0f);
					}
					else
					{
						this.HtRealBufferOutput[(int)num2] = new float4(@float, 0f);
						this.HtImaginaryBufferOutput[(int)num2] = new float4(xyz, 0f);
					}
				}
			}

			// Token: 0x040029B8 RID: 10680
			public int simulationResolution;

			// Token: 0x040029B9 RID: 10681
			public int butterflyCount;

			// Token: 0x040029BA RID: 10682
			public int bufferOffset;

			// Token: 0x040029BB RID: 10683
			public bool columnPass;

			// Token: 0x040029BC RID: 10684
			[ReadOnly]
			public NativeArray<float4> HtRealBufferInput;

			// Token: 0x040029BD RID: 10685
			[ReadOnly]
			public NativeArray<float4> HtImaginaryBufferInput;

			// Token: 0x040029BE RID: 10686
			[NativeDisableParallelForRestriction]
			public NativeArray<float3> pingPongArray;

			// Token: 0x040029BF RID: 10687
			[NativeDisableParallelForRestriction]
			public NativeArray<uint4> textureIndicesArray;

			// Token: 0x040029C0 RID: 10688
			[WriteOnly]
			[NativeDisableParallelForRestriction]
			public NativeArray<float4> HtRealBufferOutput;

			// Token: 0x040029C1 RID: 10689
			[WriteOnly]
			[NativeDisableParallelForRestriction]
			public NativeArray<float4> HtImaginaryBufferOutput;
		}
	}
}
