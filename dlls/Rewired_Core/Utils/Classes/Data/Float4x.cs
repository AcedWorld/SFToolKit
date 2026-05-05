using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x02000517 RID: 1303
	[Serializable]
	public struct Float4x : IEquatable<Float4x>
	{
		// Token: 0x17000C05 RID: 3077
		public float this[int index]
		{
			get
			{
				switch (index)
				{
				case 0:
					return this.a;
				case 1:
					return this.b;
				case 2:
					return this.c;
				case 3:
					return this.d;
				default:
					throw new ArgumentOutOfRangeException("index");
				}
			}
			set
			{
				switch (index)
				{
				case 0:
					this.a = value;
					return;
				case 1:
					this.b = value;
					return;
				case 2:
					this.c = value;
					return;
				case 3:
					this.d = value;
					return;
				default:
					throw new ArgumentOutOfRangeException("index");
				}
			}
		}

		// Token: 0x0600359B RID: 13723 RVA: 0x00029CD5 File Offset: 0x00027ED5
		public Float4x(float A_1, float A_2, float A_3, float A_4)
		{
			this.a = A_1;
			this.b = A_2;
			this.c = A_3;
			this.d = A_4;
		}

		// Token: 0x0600359C RID: 13724 RVA: 0x00029CF4 File Offset: 0x00027EF4
		public Float4x Clone()
		{
			return new Float4x(this.a, this.b, this.c, this.d);
		}

		// Token: 0x0600359D RID: 13725 RVA: 0x00029D13 File Offset: 0x00027F13
		public static Float4x Clone(Float4x obj)
		{
			return obj.Clone();
		}

		// Token: 0x17000C06 RID: 3078
		// (get) Token: 0x0600359E RID: 13726 RVA: 0x000B5C94 File Offset: 0x000B3E94
		public static Float4x Zero
		{
			get
			{
				return default(Float4x);
			}
		}

		// Token: 0x0600359F RID: 13727 RVA: 0x000B5CAC File Offset: 0x000B3EAC
		public override bool Equals(object obj)
		{
			if (!(obj is Float4x))
			{
				return false;
			}
			Float4x float4x = (Float4x)obj;
			return float4x.a == this.a && float4x.b == this.b && float4x.c == this.c && float4x.d == this.d;
		}

		// Token: 0x060035A0 RID: 13728 RVA: 0x00029D1C File Offset: 0x00027F1C
		public override int GetHashCode()
		{
			return (((17 * 29 + this.a.GetHashCode()) * 29 + this.b.GetHashCode()) * 29 + this.c.GetHashCode()) * 29 + this.d.GetHashCode();
		}

		// Token: 0x060035A1 RID: 13729 RVA: 0x00029D5C File Offset: 0x00027F5C
		public bool Equals(Float4x other)
		{
			return this.a == other.a && this.b == other.b && this.c == other.c && this.d == other.d;
		}

		// Token: 0x060035A2 RID: 13730 RVA: 0x000B5D04 File Offset: 0x000B3F04
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				this.a.ToString(),
				", ",
				this.b.ToString(),
				", ",
				this.c.ToString(),
				", ",
				this.d.ToString()
			});
		}

		// Token: 0x060035A3 RID: 13731 RVA: 0x00029D98 File Offset: 0x00027F98
		public static Float4x Add(Float4x value1, Float4x value2)
		{
			return value1 + value2;
		}

		// Token: 0x060035A4 RID: 13732 RVA: 0x00029DA1 File Offset: 0x00027FA1
		public static Float4x Subtract(Float4x value1, Float4x value2)
		{
			return value1 - value2;
		}

		// Token: 0x060035A5 RID: 13733 RVA: 0x00029DAA File Offset: 0x00027FAA
		public static Float4x Multiply(Float4x value1, Float4x value2)
		{
			return value1 * value2;
		}

		// Token: 0x060035A6 RID: 13734 RVA: 0x00029DB3 File Offset: 0x00027FB3
		public static Float4x Divide(Float4x value1, Float4x value2)
		{
			return value1 / value2;
		}

		// Token: 0x060035A7 RID: 13735 RVA: 0x00029DBC File Offset: 0x00027FBC
		public static Func<Float4x, Float4x, Float4x> GetAdditionDelegate()
		{
			if (Float4x._additionDelegate == null)
			{
				Float4x._additionDelegate = new Func<Float4x, Float4x, Float4x>(Float4x.Add);
			}
			return Float4x._additionDelegate;
		}

		// Token: 0x060035A8 RID: 13736 RVA: 0x00029DDB File Offset: 0x00027FDB
		public static Func<Float4x, Float4x, Float4x> GetSubtractionDelegate()
		{
			if (Float4x._subtractionDelegate == null)
			{
				Float4x._subtractionDelegate = new Func<Float4x, Float4x, Float4x>(Float4x.Subtract);
			}
			return Float4x._subtractionDelegate;
		}

		// Token: 0x060035A9 RID: 13737 RVA: 0x00029DFA File Offset: 0x00027FFA
		public static Func<Float4x, Float4x, Float4x> GetMultiplicationDelegate()
		{
			if (Float4x._multiplicationDelegate == null)
			{
				Float4x._multiplicationDelegate = new Func<Float4x, Float4x, Float4x>(Float4x.Multiply);
			}
			return Float4x._multiplicationDelegate;
		}

		// Token: 0x060035AA RID: 13738 RVA: 0x00029E19 File Offset: 0x00028019
		public static Func<Float4x, Float4x, Float4x> GetDivisionDelegate()
		{
			if (Float4x._divisionDelegate == null)
			{
				Float4x._divisionDelegate = new Func<Float4x, Float4x, Float4x>(Float4x.Multiply);
			}
			return Float4x._divisionDelegate;
		}

		// Token: 0x060035AB RID: 13739 RVA: 0x00029E38 File Offset: 0x00028038
		public static implicit operator Float4x(Vector4 obj)
		{
			return new Float4x(obj.x, obj.y, obj.z, obj.w);
		}

		// Token: 0x060035AC RID: 13740 RVA: 0x00029E57 File Offset: 0x00028057
		public static implicit operator Vector4(Float4x obj)
		{
			return new Vector4(obj.a, obj.b, obj.c, obj.d);
		}

		// Token: 0x060035AD RID: 13741 RVA: 0x00029E76 File Offset: 0x00028076
		public static Float4x operator +(Float4x value1, Float4x value2)
		{
			return new Float4x(value1.a + value2.a, value1.b + value2.b, value1.c + value2.c, value1.d + value2.d);
		}

		// Token: 0x060035AE RID: 13742 RVA: 0x00029EB1 File Offset: 0x000280B1
		public static Float4x operator -(Float4x value1, Float4x value2)
		{
			return new Float4x(value1.a - value2.a, value1.b - value2.b, value1.c - value2.c, value1.d - value2.d);
		}

		// Token: 0x060035AF RID: 13743 RVA: 0x00029EEC File Offset: 0x000280EC
		public static Float4x operator *(Float4x value1, Float4x value2)
		{
			return new Float4x(value1.a * value2.a, value1.b * value2.b, value1.c * value2.c, value1.d * value2.d);
		}

		// Token: 0x060035B0 RID: 13744 RVA: 0x00029F27 File Offset: 0x00028127
		public static Float4x operator /(Float4x value1, Float4x value2)
		{
			return new Float4x(value1.a / value2.a, value1.b / value2.b, value1.c / value2.c, value1.d / value2.d);
		}

		// Token: 0x060035B1 RID: 13745 RVA: 0x00029F62 File Offset: 0x00028162
		public static Float4x operator +(Float4x value1, float value2)
		{
			return new Float4x(value1.a + value2, value1.b + value2, value1.c + value2, value1.d + value2);
		}

		// Token: 0x060035B2 RID: 13746 RVA: 0x00029F89 File Offset: 0x00028189
		public static Float4x operator -(Float4x value1, float value2)
		{
			return new Float4x(value1.a - value2, value1.b - value2, value1.c - value2, value1.d - value2);
		}

		// Token: 0x060035B3 RID: 13747 RVA: 0x00029FB0 File Offset: 0x000281B0
		public static Float4x operator *(Float4x value1, float value2)
		{
			return new Float4x(value1.a * value2, value1.b * value2, value1.c * value2, value1.d * value2);
		}

		// Token: 0x060035B4 RID: 13748 RVA: 0x00029FD7 File Offset: 0x000281D7
		public static Float4x operator /(Float4x value1, float value2)
		{
			return new Float4x(value1.a / value2, value1.b / value2, value1.c / value2, value1.d / value2);
		}

		// Token: 0x04001C59 RID: 7257
		public const int Length = 4;

		// Token: 0x04001C5A RID: 7258
		public float a;

		// Token: 0x04001C5B RID: 7259
		public float b;

		// Token: 0x04001C5C RID: 7260
		public float c;

		// Token: 0x04001C5D RID: 7261
		public float d;

		// Token: 0x04001C5E RID: 7262
		private static Func<Float4x, Float4x, Float4x> _additionDelegate;

		// Token: 0x04001C5F RID: 7263
		private static Func<Float4x, Float4x, Float4x> _subtractionDelegate;

		// Token: 0x04001C60 RID: 7264
		private static Func<Float4x, Float4x, Float4x> _multiplicationDelegate;

		// Token: 0x04001C61 RID: 7265
		private static Func<Float4x, Float4x, Float4x> _divisionDelegate;
	}
}
