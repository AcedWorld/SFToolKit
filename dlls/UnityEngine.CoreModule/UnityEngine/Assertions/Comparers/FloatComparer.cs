using System;
using System.Collections.Generic;

namespace UnityEngine.Assertions.Comparers
{
	// Token: 0x020004F6 RID: 1270
	public class FloatComparer : IEqualityComparer<float>
	{
		// Token: 0x06002C5F RID: 11359 RVA: 0x0004A85A File Offset: 0x00048A5A
		public FloatComparer() : this(1E-05f, false)
		{
		}

		// Token: 0x06002C60 RID: 11360 RVA: 0x0004A86A File Offset: 0x00048A6A
		public FloatComparer(bool relative) : this(1E-05f, relative)
		{
		}

		// Token: 0x06002C61 RID: 11361 RVA: 0x0004A87A File Offset: 0x00048A7A
		public FloatComparer(float error) : this(error, false)
		{
		}

		// Token: 0x06002C62 RID: 11362 RVA: 0x0004A886 File Offset: 0x00048A86
		public FloatComparer(float error, bool relative)
		{
			this.m_Error = error;
			this.m_Relative = relative;
		}

		// Token: 0x06002C63 RID: 11363 RVA: 0x0004A8A0 File Offset: 0x00048AA0
		public bool Equals(float a, float b)
		{
			return this.m_Relative ? FloatComparer.AreEqualRelative(a, b, this.m_Error) : FloatComparer.AreEqual(a, b, this.m_Error);
		}

		// Token: 0x06002C64 RID: 11364 RVA: 0x0004A8D8 File Offset: 0x00048AD8
		public int GetHashCode(float obj)
		{
			return base.GetHashCode();
		}

		// Token: 0x06002C65 RID: 11365 RVA: 0x0004A8F0 File Offset: 0x00048AF0
		public static bool AreEqual(float expected, float actual, float error)
		{
			return Math.Abs(actual - expected) <= error;
		}

		// Token: 0x06002C66 RID: 11366 RVA: 0x0004A910 File Offset: 0x00048B10
		public static bool AreEqualRelative(float expected, float actual, float error)
		{
			bool flag = expected == actual;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				float num = Math.Abs(expected);
				float num2 = Math.Abs(actual);
				float num3 = Math.Abs((actual - expected) / ((num > num2) ? num : num2));
				result = (num3 <= error);
			}
			return result;
		}

		// Token: 0x04001127 RID: 4391
		private readonly float m_Error;

		// Token: 0x04001128 RID: 4392
		private readonly bool m_Relative;

		// Token: 0x04001129 RID: 4393
		public static readonly FloatComparer s_ComparerWithDefaultTolerance = new FloatComparer(1E-05f);

		// Token: 0x0400112A RID: 4394
		public const float kEpsilon = 1E-05f;
	}
}
