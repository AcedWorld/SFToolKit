using System;
using System.Globalization;

namespace UnityEngine.UIElements
{
	// Token: 0x02000313 RID: 787
	public struct Translate : IEquatable<Translate>
	{
		// Token: 0x06001B2D RID: 6957 RVA: 0x0006AACF File Offset: 0x00068CCF
		public Translate(Length x, Length y, float z)
		{
			this.m_X = x;
			this.m_Y = y;
			this.m_Z = z;
			this.m_isNone = false;
		}

		// Token: 0x06001B2E RID: 6958 RVA: 0x0006AAEE File Offset: 0x00068CEE
		public Translate(Length x, Length y)
		{
			this = new Translate(x, y, 0f);
		}

		// Token: 0x06001B2F RID: 6959 RVA: 0x0006AB00 File Offset: 0x00068D00
		public static Translate None()
		{
			return new Translate
			{
				m_isNone = true
			};
		}

		// Token: 0x17000687 RID: 1671
		// (get) Token: 0x06001B30 RID: 6960 RVA: 0x0006AB23 File Offset: 0x00068D23
		// (set) Token: 0x06001B31 RID: 6961 RVA: 0x0006AB2B File Offset: 0x00068D2B
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

		// Token: 0x17000688 RID: 1672
		// (get) Token: 0x06001B32 RID: 6962 RVA: 0x0006AB34 File Offset: 0x00068D34
		// (set) Token: 0x06001B33 RID: 6963 RVA: 0x0006AB3C File Offset: 0x00068D3C
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

		// Token: 0x17000689 RID: 1673
		// (get) Token: 0x06001B34 RID: 6964 RVA: 0x0006AB45 File Offset: 0x00068D45
		// (set) Token: 0x06001B35 RID: 6965 RVA: 0x0006AB4D File Offset: 0x00068D4D
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

		// Token: 0x06001B36 RID: 6966 RVA: 0x0006AB56 File Offset: 0x00068D56
		internal bool IsNone()
		{
			return this.m_isNone;
		}

		// Token: 0x06001B37 RID: 6967 RVA: 0x0006AB60 File Offset: 0x00068D60
		public static bool operator ==(Translate lhs, Translate rhs)
		{
			return lhs.m_X == rhs.m_X && lhs.m_Y == rhs.m_Y && lhs.m_Z == rhs.m_Z && lhs.m_isNone == rhs.m_isNone;
		}

		// Token: 0x06001B38 RID: 6968 RVA: 0x0006ABB8 File Offset: 0x00068DB8
		public static bool operator !=(Translate lhs, Translate rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001B39 RID: 6969 RVA: 0x0006ABD4 File Offset: 0x00068DD4
		public bool Equals(Translate other)
		{
			return other == this;
		}

		// Token: 0x06001B3A RID: 6970 RVA: 0x0006ABF4 File Offset: 0x00068DF4
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is Translate)
			{
				Translate other = (Translate)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001B3B RID: 6971 RVA: 0x0006AC20 File Offset: 0x00068E20
		public override int GetHashCode()
		{
			return this.m_X.GetHashCode() * 793 ^ this.m_Y.GetHashCode() * 791 ^ this.m_Z.GetHashCode() * 571;
		}

		// Token: 0x06001B3C RID: 6972 RVA: 0x0006AC74 File Offset: 0x00068E74
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

		// Token: 0x04000B0A RID: 2826
		private Length m_X;

		// Token: 0x04000B0B RID: 2827
		private Length m_Y;

		// Token: 0x04000B0C RID: 2828
		private float m_Z;

		// Token: 0x04000B0D RID: 2829
		private bool m_isNone;
	}
}
