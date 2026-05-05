using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x02000515 RID: 1301
	[Serializable]
	public struct Float2x : IEquatable<Float2x>
	{
		// Token: 0x17000C01 RID: 3073
		public float this[int index]
		{
			get
			{
				if (index == 0)
				{
					return this.a;
				}
				if (index != 1)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return this.b;
			}
			set
			{
				if (index == 0)
				{
					this.a = value;
					return;
				}
				if (index != 1)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				this.b = value;
			}
		}

		// Token: 0x06003563 RID: 13667 RVA: 0x00029754 File Offset: 0x00027954
		public Float2x(float A_1, float A_2)
		{
			this.a = A_1;
			this.b = A_2;
		}

		// Token: 0x06003564 RID: 13668 RVA: 0x00029764 File Offset: 0x00027964
		public Float2x Clone()
		{
			return new Float2x(this.a, this.b);
		}

		// Token: 0x06003565 RID: 13669 RVA: 0x00029777 File Offset: 0x00027977
		public static Float2x Clone(Float2x obj)
		{
			return obj.Clone();
		}

		// Token: 0x17000C02 RID: 3074
		// (get) Token: 0x06003566 RID: 13670 RVA: 0x000B5B38 File Offset: 0x000B3D38
		public static Float2x Zero
		{
			get
			{
				return default(Float2x);
			}
		}

		// Token: 0x06003567 RID: 13671 RVA: 0x000B5B50 File Offset: 0x000B3D50
		public override bool Equals(object obj)
		{
			if (!(obj is Float2x))
			{
				return false;
			}
			Float2x float2x = (Float2x)obj;
			return float2x.a == this.a && float2x.b == this.b;
		}

		// Token: 0x06003568 RID: 13672 RVA: 0x00029780 File Offset: 0x00027980
		public override int GetHashCode()
		{
			return (17 * 29 + this.a.GetHashCode()) * 29 + this.b.GetHashCode();
		}

		// Token: 0x06003569 RID: 13673 RVA: 0x000297A2 File Offset: 0x000279A2
		public bool Equals(Float2x other)
		{
			return this.a == other.a && this.b == other.b;
		}

		// Token: 0x0600356A RID: 13674 RVA: 0x000297C2 File Offset: 0x000279C2
		public override string ToString()
		{
			return this.a.ToString() + ", " + this.b.ToString();
		}

		// Token: 0x0600356B RID: 13675 RVA: 0x000297E4 File Offset: 0x000279E4
		public static Float2x Add(Float2x value1, Float2x value2)
		{
			return value1 + value2;
		}

		// Token: 0x0600356C RID: 13676 RVA: 0x000297ED File Offset: 0x000279ED
		public static Float2x Subtract(Float2x value1, Float2x value2)
		{
			return value1 - value2;
		}

		// Token: 0x0600356D RID: 13677 RVA: 0x000297F6 File Offset: 0x000279F6
		public static Float2x Multiply(Float2x value1, Float2x value2)
		{
			return value1 * value2;
		}

		// Token: 0x0600356E RID: 13678 RVA: 0x000297FF File Offset: 0x000279FF
		public static Float2x Divide(Float2x value1, Float2x value2)
		{
			return value1 / value2;
		}

		// Token: 0x0600356F RID: 13679 RVA: 0x00029808 File Offset: 0x00027A08
		public static Func<Float2x, Float2x, Float2x> GetAdditionDelegate()
		{
			if (Float2x._additionDelegate == null)
			{
				Float2x._additionDelegate = new Func<Float2x, Float2x, Float2x>(Float2x.Add);
			}
			return Float2x._additionDelegate;
		}

		// Token: 0x06003570 RID: 13680 RVA: 0x00029827 File Offset: 0x00027A27
		public static Func<Float2x, Float2x, Float2x> GetSubtractionDelegate()
		{
			if (Float2x._subtractionDelegate == null)
			{
				Float2x._subtractionDelegate = new Func<Float2x, Float2x, Float2x>(Float2x.Subtract);
			}
			return Float2x._subtractionDelegate;
		}

		// Token: 0x06003571 RID: 13681 RVA: 0x00029846 File Offset: 0x00027A46
		public static Func<Float2x, Float2x, Float2x> GetMultiplicationDelegate()
		{
			if (Float2x._multiplicationDelegate == null)
			{
				Float2x._multiplicationDelegate = new Func<Float2x, Float2x, Float2x>(Float2x.Multiply);
			}
			return Float2x._multiplicationDelegate;
		}

		// Token: 0x06003572 RID: 13682 RVA: 0x00029865 File Offset: 0x00027A65
		public static Func<Float2x, Float2x, Float2x> GetDivisionDelegate()
		{
			if (Float2x._divisionDelegate == null)
			{
				Float2x._divisionDelegate = new Func<Float2x, Float2x, Float2x>(Float2x.Multiply);
			}
			return Float2x._divisionDelegate;
		}

		// Token: 0x06003573 RID: 13683 RVA: 0x00029884 File Offset: 0x00027A84
		public static implicit operator Float2x(Vector2 obj)
		{
			return new Float2x(obj.x, obj.y);
		}

		// Token: 0x06003574 RID: 13684 RVA: 0x00029897 File Offset: 0x00027A97
		public static implicit operator Vector2(Float2x obj)
		{
			return new Vector2(obj.a, obj.b);
		}

		// Token: 0x06003575 RID: 13685 RVA: 0x000298AA File Offset: 0x00027AAA
		public static Float2x operator +(Float2x value1, Float2x value2)
		{
			return new Float2x(value1.a + value2.a, value1.b + value2.b);
		}

		// Token: 0x06003576 RID: 13686 RVA: 0x000298CB File Offset: 0x00027ACB
		public static Float2x operator -(Float2x value1, Float2x value2)
		{
			return new Float2x(value1.a - value2.a, value1.b - value2.b);
		}

		// Token: 0x06003577 RID: 13687 RVA: 0x000298EC File Offset: 0x00027AEC
		public static Float2x operator *(Float2x value1, Float2x value2)
		{
			return new Float2x(value1.a * value2.a, value1.b * value2.b);
		}

		// Token: 0x06003578 RID: 13688 RVA: 0x0002990D File Offset: 0x00027B0D
		public static Float2x operator /(Float2x value1, Float2x value2)
		{
			return new Float2x(value1.a / value2.a, value1.b / value2.b);
		}

		// Token: 0x06003579 RID: 13689 RVA: 0x0002992E File Offset: 0x00027B2E
		public static Float2x operator +(Float2x value1, float value2)
		{
			return new Float2x(value1.a + value2, value1.b + value2);
		}

		// Token: 0x0600357A RID: 13690 RVA: 0x00029945 File Offset: 0x00027B45
		public static Float2x operator -(Float2x value1, float value2)
		{
			return new Float2x(value1.a - value2, value1.b - value2);
		}

		// Token: 0x0600357B RID: 13691 RVA: 0x0002995C File Offset: 0x00027B5C
		public static Float2x operator *(Float2x value1, float value2)
		{
			return new Float2x(value1.a * value2, value1.b * value2);
		}

		// Token: 0x0600357C RID: 13692 RVA: 0x00029973 File Offset: 0x00027B73
		public static Float2x operator /(Float2x value1, float value2)
		{
			return new Float2x(value1.a / value2, value1.b / value2);
		}

		// Token: 0x04001C4A RID: 7242
		public const int Length = 2;

		// Token: 0x04001C4B RID: 7243
		public float a;

		// Token: 0x04001C4C RID: 7244
		public float b;

		// Token: 0x04001C4D RID: 7245
		private static Func<Float2x, Float2x, Float2x> _additionDelegate;

		// Token: 0x04001C4E RID: 7246
		private static Func<Float2x, Float2x, Float2x> _subtractionDelegate;

		// Token: 0x04001C4F RID: 7247
		private static Func<Float2x, Float2x, Float2x> _multiplicationDelegate;

		// Token: 0x04001C50 RID: 7248
		private static Func<Float2x, Float2x, Float2x> _divisionDelegate;
	}
}
