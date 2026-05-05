using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x0200000E RID: 14
	internal class EnumMap<[IsUnmanaged] TEnum, TValue> : IEnumerable<KeyValuePair<TEnum, TValue>>, IEnumerable where TEnum : struct, ValueType, Enum
	{
		// Token: 0x0600002C RID: 44 RVA: 0x000023D4 File Offset: 0x000005D4
		public EnumMap()
		{
			this.m_Values = new TValue[EnumMap<TEnum, TValue>.s_Count];
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000023EC File Offset: 0x000005EC
		public EnumMap(TValue value) : this()
		{
			Array.Fill<TValue>(this.m_Values, value);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002400 File Offset: 0x00000600
		public EnumMap(TValue[] values)
		{
			this.m_Values = values;
		}

		// Token: 0x17000005 RID: 5
		public TValue this[TEnum key]
		{
			get
			{
				return this.m_Values[EnumMap<TEnum, TValue>.CastEnumToInt(key)];
			}
			set
			{
				this.m_Values[EnumMap<TEnum, TValue>.CastEnumToInt(key)] = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00002436 File Offset: 0x00000636
		public int Count
		{
			get
			{
				return EnumMap<TEnum, TValue>.s_Count;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000032 RID: 50 RVA: 0x0000243D File Offset: 0x0000063D
		public TValue[] Values
		{
			get
			{
				return this.m_Values;
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002445 File Offset: 0x00000645
		public void Add(TEnum key, TValue value)
		{
			this.m_Values[EnumMap<TEnum, TValue>.CastEnumToInt(key)] = value;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002459 File Offset: 0x00000659
		private unsafe static int CastEnumToInt(TEnum enumValue)
		{
			return *(int*)(&enumValue);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000245F File Offset: 0x0000065F
		private unsafe static TEnum CastIntToEnum(int value)
		{
			return *(TEnum*)(&value);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002469 File Offset: 0x00000669
		public IEnumerator<KeyValuePair<TEnum, TValue>> GetEnumerator()
		{
			int num;
			for (int i = 0; i < EnumMap<TEnum, TValue>.s_Count; i = num)
			{
				yield return new KeyValuePair<TEnum, TValue>(EnumMap<TEnum, TValue>.CastIntToEnum(i), this.m_Values[i]);
				num = i + 1;
			}
			yield break;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002478 File Offset: 0x00000678
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x0400000F RID: 15
		private static readonly int s_Count = EnumContinuity.ValidateEnumForEnumMap<TEnum, TValue>();

		// Token: 0x04000010 RID: 16
		private readonly TValue[] m_Values;
	}
}
