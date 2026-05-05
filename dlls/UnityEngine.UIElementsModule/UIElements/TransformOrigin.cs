using System;
using System.Globalization;

namespace UnityEngine.UIElements
{
	// Token: 0x02000312 RID: 786
	public struct TransformOrigin : IEquatable<TransformOrigin>
	{
		// Token: 0x06001B1E RID: 6942 RVA: 0x0006A8C8 File Offset: 0x00068AC8
		public TransformOrigin(Length x, Length y, float z)
		{
			this.m_X = x;
			this.m_Y = y;
			this.m_Z = z;
		}

		// Token: 0x06001B1F RID: 6943 RVA: 0x0006A8E0 File Offset: 0x00068AE0
		public TransformOrigin(Length x, Length y)
		{
			this = new TransformOrigin(x, y, 0f);
		}

		// Token: 0x06001B20 RID: 6944 RVA: 0x0006A8F4 File Offset: 0x00068AF4
		public static TransformOrigin Initial()
		{
			return new TransformOrigin(Length.Percent(50f), Length.Percent(50f), 0f);
		}

		// Token: 0x17000684 RID: 1668
		// (get) Token: 0x06001B21 RID: 6945 RVA: 0x0006A924 File Offset: 0x00068B24
		// (set) Token: 0x06001B22 RID: 6946 RVA: 0x0006A92C File Offset: 0x00068B2C
		public Length x
		{
			get
			{
				return this.m_X;
			}
			set
			{
				this.m_X = value;
			}
		}

		// Token: 0x17000685 RID: 1669
		// (get) Token: 0x06001B23 RID: 6947 RVA: 0x0006A935 File Offset: 0x00068B35
		// (set) Token: 0x06001B24 RID: 6948 RVA: 0x0006A93D File Offset: 0x00068B3D
		public Length y
		{
			get
			{
				return this.m_Y;
			}
			set
			{
				this.m_Y = value;
			}
		}

		// Token: 0x17000686 RID: 1670
		// (get) Token: 0x06001B25 RID: 6949 RVA: 0x0006A946 File Offset: 0x00068B46
		// (set) Token: 0x06001B26 RID: 6950 RVA: 0x0006A94E File Offset: 0x00068B4E
		public float z
		{
			get
			{
				return this.m_Z;
			}
			set
			{
				this.m_Z = value;
			}
		}

		// Token: 0x06001B27 RID: 6951 RVA: 0x0006A958 File Offset: 0x00068B58
		public static bool operator ==(TransformOrigin lhs, TransformOrigin rhs)
		{
			return lhs.m_X == rhs.m_X && lhs.m_Y == rhs.m_Y && lhs.m_Z == rhs.m_Z;
		}

		// Token: 0x06001B28 RID: 6952 RVA: 0x0006A9A4 File Offset: 0x00068BA4
		public static bool operator !=(TransformOrigin lhs, TransformOrigin rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001B29 RID: 6953 RVA: 0x0006A9C0 File Offset: 0x00068BC0
		public bool Equals(TransformOrigin other)
		{
			return other == this;
		}

		// Token: 0x06001B2A RID: 6954 RVA: 0x0006A9E0 File Offset: 0x00068BE0
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is TransformOrigin)
			{
				TransformOrigin other = (TransformOrigin)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001B2B RID: 6955 RVA: 0x0006AA0C File Offset: 0x00068C0C
		public override int GetHashCode()
		{
			return this.m_X.GetHashCode() * 793 ^ this.m_Y.GetHashCode() * 791 ^ this.m_Z.GetHashCode() * 571;
		}

		// Token: 0x06001B2C RID: 6956 RVA: 0x0006AA60 File Offset: 0x00068C60
		public override string ToString()
		{
			string text = this.m_Z.ToString(CultureInfo.InvariantCulture.NumberFormat);
			return string.Concat(new string[]
			{
				this.m_X.ToString(),
				" ",
				this.m_Y.ToString(),
				" ",
				text
			});
		}

		// Token: 0x04000B07 RID: 2823
		private Length m_X;

		// Token: 0x04000B08 RID: 2824
		private Length m_Y;

		// Token: 0x04000B09 RID: 2825
		private float m_Z;
	}
}
