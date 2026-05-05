using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x02000516 RID: 1302
	[Serializable]
	public struct Float3x : IEquatable<Float3x>
	{
		// Token: 0x17000C03 RID: 3075
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
				default:
					throw new ArgumentOutOfRangeException("index");
				}
			}
		}

		// Token: 0x0600357F RID: 13695 RVA: 0x000299F7 File Offset: 0x00027BF7
		public Float3x(float A_1, float A_2, float A_3)
		{
			this.a = A_1;
			this.b = A_2;
			this.c = A_3;
		}

		// Token: 0x06003580 RID: 13696 RVA: 0x00029A0E File Offset: 0x00027C0E
		public Float3x Clone()
		{
			return new Float3x(this.a, this.b, this.c);
		}

		// Token: 0x06003581 RID: 13697 RVA: 0x00029A27 File Offset: 0x00027C27
		public static Float3x Clone(Float3x obj)
		{
			return obj.Clone();
		}

		// Token: 0x17000C04 RID: 3076
		// (get) Token: 0x06003582 RID: 13698 RVA: 0x000B5B8C File Offset: 0x000B3D8C
		public static Float3x Zero
		{
			get
			{
				return default(Float3x);
			}
		}

		// Token: 0x06003583 RID: 13699 RVA: 0x000B5BA4 File Offset: 0x000B3DA4
		public override bool Equals(object obj)
		{
			if (!(obj is Float3x))
			{
				return false;
			}
			Float3x float3x = (Float3x)obj;
			return float3x.a == this.a && float3x.b == this.b && float3x.c == this.c;
		}

		// Token: 0x06003584 RID: 13700 RVA: 0x00029A30 File Offset: 0x00027C30
		public override int GetHashCode()
		{
			return ((17 * 29 + this.a.GetHashCode()) * 29 + this.b.GetHashCode()) * 29 + this.c.GetHashCode();
		}

		// Token: 0x06003585 RID: 13701 RVA: 0x00029A61 File Offset: 0x00027C61
		public bool Equals(Float3x other)
		{
			return this.a == other.a && this.b == other.b && this.c == other.c;
		}

		// Token: 0x06003586 RID: 13702 RVA: 0x000B5BF0 File Offset: 0x000B3DF0
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				this.a.ToString(),
				", ",
				this.b.ToString(),
				", ",
				this.c.ToString()
			});
		}

		// Token: 0x06003587 RID: 13703 RVA: 0x00029A8F File Offset: 0x00027C8F
		public static Float3x Add(Float3x value1, Float3x value2)
		{
			return value1 + value2;
		}

		// Token: 0x06003588 RID: 13704 RVA: 0x00029A98 File Offset: 0x00027C98
		public static Float3x Subtract(Float3x value1, Float3x value2)
		{
			return value1 - value2;
		}

		// Token: 0x06003589 RID: 13705 RVA: 0x00029AA1 File Offset: 0x00027CA1
		public static Float3x Multiply(Float3x value1, Float3x value2)
		{
			return value1 * value2;
		}

		// Token: 0x0600358A RID: 13706 RVA: 0x00029AAA File Offset: 0x00027CAA
		public static Float3x Divide(Float3x value1, Float3x value2)
		{
			return value1 / value2;
		}

		// Token: 0x0600358B RID: 13707 RVA: 0x00029AB3 File Offset: 0x00027CB3
		public static Func<Float3x, Float3x, Float3x> GetAdditionDelegate()
		{
			if (Float3x._additionDelegate == null)
			{
				Float3x._additionDelegate = new Func<Float3x, Float3x, Float3x>(Float3x.Add);
			}
			return Float3x._additionDelegate;
		}

		// Token: 0x0600358C RID: 13708 RVA: 0x00029AD2 File Offset: 0x00027CD2
		public static Func<Float3x, Float3x, Float3x> GetSubtractionDelegate()
		{
			if (Float3x._subtractionDelegate == null)
			{
				Float3x._subtractionDelegate = new Func<Float3x, Float3x, Float3x>(Float3x.Subtract);
			}
			return Float3x._subtractionDelegate;
		}

		// Token: 0x0600358D RID: 13709 RVA: 0x00029AF1 File Offset: 0x00027CF1
		public static Func<Float3x, Float3x, Float3x> GetMultiplicationDelegate()
		{
			if (Float3x._multiplicationDelegate == null)
			{
				Float3x._multiplicationDelegate = new Func<Float3x, Float3x, Float3x>(Float3x.Multiply);
			}
			return Float3x._multiplicationDelegate;
		}

		// Token: 0x0600358E RID: 13710 RVA: 0x00029B10 File Offset: 0x00027D10
		public static Func<Float3x, Float3x, Float3x> GetDivisionDelegate()
		{
			if (Float3x._divisionDelegate == null)
			{
				Float3x._divisionDelegate = new Func<Float3x, Float3x, Float3x>(Float3x.Multiply);
			}
			return Float3x._divisionDelegate;
		}

		// Token: 0x0600358F RID: 13711 RVA: 0x00029B2F File Offset: 0x00027D2F
		public static implicit operator Float3x(Vector3 obj)
		{
			return new Float3x(obj.x, obj.y, obj.z);
		}

		// Token: 0x06003590 RID: 13712 RVA: 0x00029B48 File Offset: 0x00027D48
		public static implicit operator Vector3(Float3x obj)
		{
			return new Vector3(obj.a, obj.b, obj.c);
		}

		// Token: 0x06003591 RID: 13713 RVA: 0x00029B61 File Offset: 0x00027D61
		public static Float3x operator +(Float3x value1, Float3x value2)
		{
			return new Float3x(value1.a + value2.a, value1.b + value2.b, value1.c + value2.c);
		}

		// Token: 0x06003592 RID: 13714 RVA: 0x00029B8F File Offset: 0x00027D8F
		public static Float3x operator -(Float3x value1, Float3x value2)
		{
			return new Float3x(value1.a - value2.a, value1.b - value2.b, value1.c - value2.c);
		}

		// Token: 0x06003593 RID: 13715 RVA: 0x00029BBD File Offset: 0x00027DBD
		public static Float3x operator *(Float3x value1, Float3x value2)
		{
			return new Float3x(value1.a * value2.a, value1.b * value2.b, value1.c * value2.c);
		}

		// Token: 0x06003594 RID: 13716 RVA: 0x00029BEB File Offset: 0x00027DEB
		public static Float3x operator /(Float3x value1, Float3x value2)
		{
			return new Float3x(value1.a / value2.a, value1.b / value2.b, value1.c / value2.c);
		}

		// Token: 0x06003595 RID: 13717 RVA: 0x00029C19 File Offset: 0x00027E19
		public static Float3x operator +(Float3x value1, float value2)
		{
			return new Float3x(value1.a + value2, value1.b + value2, value1.c + value2);
		}

		// Token: 0x06003596 RID: 13718 RVA: 0x00029C38 File Offset: 0x00027E38
		public static Float3x operator -(Float3x value1, float value2)
		{
			return new Float3x(value1.a - value2, value1.b - value2, value1.c - value2);
		}

		// Token: 0x06003597 RID: 13719 RVA: 0x00029C57 File Offset: 0x00027E57
		public static Float3x operator *(Float3x value1, float value2)
		{
			return new Float3x(value1.a * value2, value1.b * value2, value1.c * value2);
		}

		// Token: 0x06003598 RID: 13720 RVA: 0x00029C76 File Offset: 0x00027E76
		public static Float3x operator /(Float3x value1, float value2)
		{
			return new Float3x(value1.a / value2, value1.b / value2, value1.c / value2);
		}

		// Token: 0x04001C51 RID: 7249
		public const int Length = 3;

		// Token: 0x04001C52 RID: 7250
		public float a;

		// Token: 0x04001C53 RID: 7251
		public float b;

		// Token: 0x04001C54 RID: 7252
		public float c;

		// Token: 0x04001C55 RID: 7253
		private static Func<Float3x, Float3x, Float3x> _additionDelegate;

		// Token: 0x04001C56 RID: 7254
		private static Func<Float3x, Float3x, Float3x> _subtractionDelegate;

		// Token: 0x04001C57 RID: 7255
		private static Func<Float3x, Float3x, Float3x> _multiplicationDelegate;

		// Token: 0x04001C58 RID: 7256
		private static Func<Float3x, Float3x, Float3x> _divisionDelegate;
	}
}
