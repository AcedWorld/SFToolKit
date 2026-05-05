using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002CE RID: 718
	public struct EasingFunction : IEquatable<EasingFunction>
	{
		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x0600155F RID: 5471 RVA: 0x00054CC8 File Offset: 0x00052EC8
		// (set) Token: 0x06001560 RID: 5472 RVA: 0x00054CD0 File Offset: 0x00052ED0
		public EasingMode mode
		{
			get
			{
				return this.m_Mode;
			}
			set
			{
				this.m_Mode = value;
			}
		}

		// Token: 0x06001561 RID: 5473 RVA: 0x00054CD9 File Offset: 0x00052ED9
		public EasingFunction(EasingMode mode)
		{
			this.m_Mode = mode;
		}

		// Token: 0x06001562 RID: 5474 RVA: 0x00054CE4 File Offset: 0x00052EE4
		public static implicit operator EasingFunction(EasingMode easingMode)
		{
			return new EasingFunction(easingMode);
		}

		// Token: 0x06001563 RID: 5475 RVA: 0x00054CFC File Offset: 0x00052EFC
		public static bool operator ==(EasingFunction lhs, EasingFunction rhs)
		{
			return lhs.m_Mode == rhs.m_Mode;
		}

		// Token: 0x06001564 RID: 5476 RVA: 0x00054D1C File Offset: 0x00052F1C
		public static bool operator !=(EasingFunction lhs, EasingFunction rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001565 RID: 5477 RVA: 0x00054D38 File Offset: 0x00052F38
		public bool Equals(EasingFunction other)
		{
			return other == this;
		}

		// Token: 0x06001566 RID: 5478 RVA: 0x00054D58 File Offset: 0x00052F58
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is EasingFunction)
			{
				EasingFunction other = (EasingFunction)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001567 RID: 5479 RVA: 0x00054D84 File Offset: 0x00052F84
		public override string ToString()
		{
			return this.m_Mode.ToString();
		}

		// Token: 0x06001568 RID: 5480 RVA: 0x00054DA8 File Offset: 0x00052FA8
		public override int GetHashCode()
		{
			return (int)this.m_Mode;
		}

		// Token: 0x040009D1 RID: 2513
		private EasingMode m_Mode;
	}
}
