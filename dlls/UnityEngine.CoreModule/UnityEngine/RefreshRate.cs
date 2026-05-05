using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000145 RID: 325
	[NativeType("Runtime/Graphics/RefreshRate.h")]
	public struct RefreshRate : IEquatable<RefreshRate>, IComparable<RefreshRate>
	{
		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000912 RID: 2322 RVA: 0x0000EB2D File Offset: 0x0000CD2D
		public double value
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.numerator / this.denominator;
			}
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x0000EB40 File Offset: 0x0000CD40
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(RefreshRate other)
		{
			bool flag = this.denominator == 0U;
			bool result;
			if (flag)
			{
				result = (other.denominator == 0U);
			}
			else
			{
				bool flag2 = other.denominator == 0U;
				result = (!flag2 && (ulong)this.numerator * (ulong)other.denominator == (ulong)this.denominator * (ulong)other.numerator);
			}
			return result;
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x0000EB9C File Offset: 0x0000CD9C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int CompareTo(RefreshRate other)
		{
			bool flag = this.denominator == 0U;
			int result;
			if (flag)
			{
				result = ((other.denominator == 0U) ? 0 : 1);
			}
			else
			{
				bool flag2 = other.denominator == 0U;
				if (flag2)
				{
					result = -1;
				}
				else
				{
					result = ((ulong)this.numerator * (ulong)other.denominator).CompareTo((ulong)this.denominator * (ulong)other.numerator);
				}
			}
			return result;
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x0000EC04 File Offset: 0x0000CE04
		public override string ToString()
		{
			return this.value.ToString(CultureInfo.InvariantCulture.NumberFormat);
		}

		// Token: 0x04000415 RID: 1045
		[RequiredMember]
		public uint numerator;

		// Token: 0x04000416 RID: 1046
		[RequiredMember]
		public uint denominator;
	}
}
