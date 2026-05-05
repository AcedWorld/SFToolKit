using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000024 RID: 36
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct float3x4 : IEquatable<float3x4>, IFormattable
	{
		// Token: 0x0600129B RID: 4763 RVA: 0x00035B98 File Offset: 0x00033D98
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x4(float3 c0, float3 c1, float3 c2, float3 c3)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
			this.c3 = c3;
		}

		// Token: 0x0600129C RID: 4764 RVA: 0x00035BB8 File Offset: 0x00033DB8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23)
		{
			this.c0 = new float3(m00, m10, m20);
			this.c1 = new float3(m01, m11, m21);
			this.c2 = new float3(m02, m12, m22);
			this.c3 = new float3(m03, m13, m23);
		}

		// Token: 0x0600129D RID: 4765 RVA: 0x00035C06 File Offset: 0x00033E06
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x4(float v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
			this.c3 = v;
		}

		// Token: 0x0600129E RID: 4766 RVA: 0x00035C38 File Offset: 0x00033E38
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x4(bool v)
		{
			this.c0 = math.select(new float3(0f), new float3(1f), v);
			this.c1 = math.select(new float3(0f), new float3(1f), v);
			this.c2 = math.select(new float3(0f), new float3(1f), v);
			this.c3 = math.select(new float3(0f), new float3(1f), v);
		}

		// Token: 0x0600129F RID: 4767 RVA: 0x00035CC8 File Offset: 0x00033EC8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x4(bool3x4 v)
		{
			this.c0 = math.select(new float3(0f), new float3(1f), v.c0);
			this.c1 = math.select(new float3(0f), new float3(1f), v.c1);
			this.c2 = math.select(new float3(0f), new float3(1f), v.c2);
			this.c3 = math.select(new float3(0f), new float3(1f), v.c3);
		}

		// Token: 0x060012A0 RID: 4768 RVA: 0x00035D69 File Offset: 0x00033F69
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x4(int v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
			this.c3 = v;
		}

		// Token: 0x060012A1 RID: 4769 RVA: 0x00035D9C File Offset: 0x00033F9C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x4(int3x4 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
			this.c3 = v.c3;
		}

		// Token: 0x060012A2 RID: 4770 RVA: 0x00035DED File Offset: 0x00033FED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x4(uint v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
			this.c3 = v;
		}

		// Token: 0x060012A3 RID: 4771 RVA: 0x00035E20 File Offset: 0x00034020
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x4(uint3x4 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
			this.c3 = v.c3;
		}

		// Token: 0x060012A4 RID: 4772 RVA: 0x00035E71 File Offset: 0x00034071
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x4(double v)
		{
			this.c0 = (float3)v;
			this.c1 = (float3)v;
			this.c2 = (float3)v;
			this.c3 = (float3)v;
		}

		// Token: 0x060012A5 RID: 4773 RVA: 0x00035EA4 File Offset: 0x000340A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x4(double3x4 v)
		{
			this.c0 = (float3)v.c0;
			this.c1 = (float3)v.c1;
			this.c2 = (float3)v.c2;
			this.c3 = (float3)v.c3;
		}

		// Token: 0x060012A6 RID: 4774 RVA: 0x00035EF5 File Offset: 0x000340F5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3x4(float v)
		{
			return new float3x4(v);
		}

		// Token: 0x060012A7 RID: 4775 RVA: 0x00035EFD File Offset: 0x000340FD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float3x4(bool v)
		{
			return new float3x4(v);
		}

		// Token: 0x060012A8 RID: 4776 RVA: 0x00035F05 File Offset: 0x00034105
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float3x4(bool3x4 v)
		{
			return new float3x4(v);
		}

		// Token: 0x060012A9 RID: 4777 RVA: 0x00035F0D File Offset: 0x0003410D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3x4(int v)
		{
			return new float3x4(v);
		}

		// Token: 0x060012AA RID: 4778 RVA: 0x00035F15 File Offset: 0x00034115
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3x4(int3x4 v)
		{
			return new float3x4(v);
		}

		// Token: 0x060012AB RID: 4779 RVA: 0x00035F1D File Offset: 0x0003411D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3x4(uint v)
		{
			return new float3x4(v);
		}

		// Token: 0x060012AC RID: 4780 RVA: 0x00035F25 File Offset: 0x00034125
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3x4(uint3x4 v)
		{
			return new float3x4(v);
		}

		// Token: 0x060012AD RID: 4781 RVA: 0x00035F2D File Offset: 0x0003412D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float3x4(double v)
		{
			return new float3x4(v);
		}

		// Token: 0x060012AE RID: 4782 RVA: 0x00035F35 File Offset: 0x00034135
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float3x4(double3x4 v)
		{
			return new float3x4(v);
		}

		// Token: 0x060012AF RID: 4783 RVA: 0x00035F40 File Offset: 0x00034140
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 operator *(float3x4 lhs, float3x4 rhs)
		{
			return new float3x4(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2, lhs.c3 * rhs.c3);
		}

		// Token: 0x060012B0 RID: 4784 RVA: 0x00035F96 File Offset: 0x00034196
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 operator *(float3x4 lhs, float rhs)
		{
			return new float3x4(lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs, lhs.c3 * rhs);
		}

		// Token: 0x060012B1 RID: 4785 RVA: 0x00035FCD File Offset: 0x000341CD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 operator *(float lhs, float3x4 rhs)
		{
			return new float3x4(lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2, lhs * rhs.c3);
		}

		// Token: 0x060012B2 RID: 4786 RVA: 0x00036004 File Offset: 0x00034204
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 operator +(float3x4 lhs, float3x4 rhs)
		{
			return new float3x4(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2, lhs.c3 + rhs.c3);
		}

		// Token: 0x060012B3 RID: 4787 RVA: 0x0003605A File Offset: 0x0003425A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 operator +(float3x4 lhs, float rhs)
		{
			return new float3x4(lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs, lhs.c3 + rhs);
		}

		// Token: 0x060012B4 RID: 4788 RVA: 0x00036091 File Offset: 0x00034291
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 operator +(float lhs, float3x4 rhs)
		{
			return new float3x4(lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2, lhs + rhs.c3);
		}

		// Token: 0x060012B5 RID: 4789 RVA: 0x000360C8 File Offset: 0x000342C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 operator -(float3x4 lhs, float3x4 rhs)
		{
			return new float3x4(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2, lhs.c3 - rhs.c3);
		}

		// Token: 0x060012B6 RID: 4790 RVA: 0x0003611E File Offset: 0x0003431E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 operator -(float3x4 lhs, float rhs)
		{
			return new float3x4(lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs, lhs.c3 - rhs);
		}

		// Token: 0x060012B7 RID: 4791 RVA: 0x00036155 File Offset: 0x00034355
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 operator -(float lhs, float3x4 rhs)
		{
			return new float3x4(lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2, lhs - rhs.c3);
		}

		// Token: 0x060012B8 RID: 4792 RVA: 0x0003618C File Offset: 0x0003438C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 operator /(float3x4 lhs, float3x4 rhs)
		{
			return new float3x4(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2, lhs.c3 / rhs.c3);
		}

		// Token: 0x060012B9 RID: 4793 RVA: 0x000361E2 File Offset: 0x000343E2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 operator /(float3x4 lhs, float rhs)
		{
			return new float3x4(lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs, lhs.c3 / rhs);
		}

		// Token: 0x060012BA RID: 4794 RVA: 0x00036219 File Offset: 0x00034419
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 operator /(float lhs, float3x4 rhs)
		{
			return new float3x4(lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2, lhs / rhs.c3);
		}

		// Token: 0x060012BB RID: 4795 RVA: 0x00036250 File Offset: 0x00034450
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 operator %(float3x4 lhs, float3x4 rhs)
		{
			return new float3x4(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2, lhs.c3 % rhs.c3);
		}

		// Token: 0x060012BC RID: 4796 RVA: 0x000362A6 File Offset: 0x000344A6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 operator %(float3x4 lhs, float rhs)
		{
			return new float3x4(lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs, lhs.c3 % rhs);
		}

		// Token: 0x060012BD RID: 4797 RVA: 0x000362DD File Offset: 0x000344DD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 operator %(float lhs, float3x4 rhs)
		{
			return new float3x4(lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2, lhs % rhs.c3);
		}

		// Token: 0x060012BE RID: 4798 RVA: 0x00036314 File Offset: 0x00034514
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 operator ++(float3x4 val)
		{
			float3 @float = ++val.c0;
			val.c0 = @float;
			float3 float2 = @float;
			@float = ++val.c1;
			val.c1 = @float;
			float3 float3 = @float;
			@float = ++val.c2;
			val.c2 = @float;
			float3 float4 = @float;
			@float = ++val.c3;
			val.c3 = @float;
			return new float3x4(float2, float3, float4, @float);
		}

		// Token: 0x060012BF RID: 4799 RVA: 0x00036390 File Offset: 0x00034590
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 operator --(float3x4 val)
		{
			float3 @float = --val.c0;
			val.c0 = @float;
			float3 float2 = @float;
			@float = --val.c1;
			val.c1 = @float;
			float3 float3 = @float;
			@float = --val.c2;
			val.c2 = @float;
			float3 float4 = @float;
			@float = --val.c3;
			val.c3 = @float;
			return new float3x4(float2, float3, float4, @float);
		}

		// Token: 0x060012C0 RID: 4800 RVA: 0x0003640C File Offset: 0x0003460C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator <(float3x4 lhs, float3x4 rhs)
		{
			return new bool3x4(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2, lhs.c3 < rhs.c3);
		}

		// Token: 0x060012C1 RID: 4801 RVA: 0x00036462 File Offset: 0x00034662
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator <(float3x4 lhs, float rhs)
		{
			return new bool3x4(lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs, lhs.c3 < rhs);
		}

		// Token: 0x060012C2 RID: 4802 RVA: 0x00036499 File Offset: 0x00034699
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator <(float lhs, float3x4 rhs)
		{
			return new bool3x4(lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2, lhs < rhs.c3);
		}

		// Token: 0x060012C3 RID: 4803 RVA: 0x000364D0 File Offset: 0x000346D0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator <=(float3x4 lhs, float3x4 rhs)
		{
			return new bool3x4(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2, lhs.c3 <= rhs.c3);
		}

		// Token: 0x060012C4 RID: 4804 RVA: 0x00036526 File Offset: 0x00034726
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator <=(float3x4 lhs, float rhs)
		{
			return new bool3x4(lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs, lhs.c3 <= rhs);
		}

		// Token: 0x060012C5 RID: 4805 RVA: 0x0003655D File Offset: 0x0003475D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator <=(float lhs, float3x4 rhs)
		{
			return new bool3x4(lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2, lhs <= rhs.c3);
		}

		// Token: 0x060012C6 RID: 4806 RVA: 0x00036594 File Offset: 0x00034794
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator >(float3x4 lhs, float3x4 rhs)
		{
			return new bool3x4(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2, lhs.c3 > rhs.c3);
		}

		// Token: 0x060012C7 RID: 4807 RVA: 0x000365EA File Offset: 0x000347EA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator >(float3x4 lhs, float rhs)
		{
			return new bool3x4(lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs, lhs.c3 > rhs);
		}

		// Token: 0x060012C8 RID: 4808 RVA: 0x00036621 File Offset: 0x00034821
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator >(float lhs, float3x4 rhs)
		{
			return new bool3x4(lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2, lhs > rhs.c3);
		}

		// Token: 0x060012C9 RID: 4809 RVA: 0x00036658 File Offset: 0x00034858
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator >=(float3x4 lhs, float3x4 rhs)
		{
			return new bool3x4(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2, lhs.c3 >= rhs.c3);
		}

		// Token: 0x060012CA RID: 4810 RVA: 0x000366AE File Offset: 0x000348AE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator >=(float3x4 lhs, float rhs)
		{
			return new bool3x4(lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs, lhs.c3 >= rhs);
		}

		// Token: 0x060012CB RID: 4811 RVA: 0x000366E5 File Offset: 0x000348E5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator >=(float lhs, float3x4 rhs)
		{
			return new bool3x4(lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2, lhs >= rhs.c3);
		}

		// Token: 0x060012CC RID: 4812 RVA: 0x0003671C File Offset: 0x0003491C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 operator -(float3x4 val)
		{
			return new float3x4(-val.c0, -val.c1, -val.c2, -val.c3);
		}

		// Token: 0x060012CD RID: 4813 RVA: 0x0003674F File Offset: 0x0003494F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 operator +(float3x4 val)
		{
			return new float3x4(+val.c0, +val.c1, +val.c2, +val.c3);
		}

		// Token: 0x060012CE RID: 4814 RVA: 0x00036784 File Offset: 0x00034984
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator ==(float3x4 lhs, float3x4 rhs)
		{
			return new bool3x4(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2, lhs.c3 == rhs.c3);
		}

		// Token: 0x060012CF RID: 4815 RVA: 0x000367DA File Offset: 0x000349DA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator ==(float3x4 lhs, float rhs)
		{
			return new bool3x4(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs, lhs.c3 == rhs);
		}

		// Token: 0x060012D0 RID: 4816 RVA: 0x00036811 File Offset: 0x00034A11
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator ==(float lhs, float3x4 rhs)
		{
			return new bool3x4(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2, lhs == rhs.c3);
		}

		// Token: 0x060012D1 RID: 4817 RVA: 0x00036848 File Offset: 0x00034A48
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator !=(float3x4 lhs, float3x4 rhs)
		{
			return new bool3x4(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2, lhs.c3 != rhs.c3);
		}

		// Token: 0x060012D2 RID: 4818 RVA: 0x0003689E File Offset: 0x00034A9E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator !=(float3x4 lhs, float rhs)
		{
			return new bool3x4(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs, lhs.c3 != rhs);
		}

		// Token: 0x060012D3 RID: 4819 RVA: 0x000368D5 File Offset: 0x00034AD5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator !=(float lhs, float3x4 rhs)
		{
			return new bool3x4(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2, lhs != rhs.c3);
		}

		// Token: 0x17000473 RID: 1139
		public unsafe float3 this[int index]
		{
			get
			{
				fixed (float3x4* ptr = &this)
				{
					return ref *(float3*)(ptr + (IntPtr)index * (IntPtr)sizeof(float3) / (IntPtr)sizeof(float3x4));
				}
			}
		}

		// Token: 0x060012D5 RID: 4821 RVA: 0x00036928 File Offset: 0x00034B28
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(float3x4 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2) && this.c3.Equals(rhs.c3);
		}

		// Token: 0x060012D6 RID: 4822 RVA: 0x00036984 File Offset: 0x00034B84
		public override bool Equals(object o)
		{
			if (o is float3x4)
			{
				float3x4 rhs = (float3x4)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x060012D7 RID: 4823 RVA: 0x000369A9 File Offset: 0x00034BA9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x060012D8 RID: 4824 RVA: 0x000369B8 File Offset: 0x00034BB8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("float3x4({0}f, {1}f, {2}f, {3}f,  {4}f, {5}f, {6}f, {7}f,  {8}f, {9}f, {10}f, {11}f)", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c2.x,
				this.c3.x,
				this.c0.y,
				this.c1.y,
				this.c2.y,
				this.c3.y,
				this.c0.z,
				this.c1.z,
				this.c2.z,
				this.c3.z
			});
		}

		// Token: 0x060012D9 RID: 4825 RVA: 0x00036AC0 File Offset: 0x00034CC0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("float3x4({0}f, {1}f, {2}f, {3}f,  {4}f, {5}f, {6}f, {7}f,  {8}f, {9}f, {10}f, {11}f)", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c2.x.ToString(format, formatProvider),
				this.c3.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider),
				this.c2.y.ToString(format, formatProvider),
				this.c3.y.ToString(format, formatProvider),
				this.c0.z.ToString(format, formatProvider),
				this.c1.z.ToString(format, formatProvider),
				this.c2.z.ToString(format, formatProvider),
				this.c3.z.ToString(format, formatProvider)
			});
		}

		// Token: 0x0400008A RID: 138
		public float3 c0;

		// Token: 0x0400008B RID: 139
		public float3 c1;

		// Token: 0x0400008C RID: 140
		public float3 c2;

		// Token: 0x0400008D RID: 141
		public float3 c3;

		// Token: 0x0400008E RID: 142
		public static readonly float3x4 zero;
	}
}
