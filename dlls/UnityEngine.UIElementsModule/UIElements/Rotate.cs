using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002F7 RID: 759
	public struct Rotate : IEquatable<Rotate>
	{
		// Token: 0x060019B0 RID: 6576 RVA: 0x00067AD6 File Offset: 0x00065CD6
		internal Rotate(Angle angle, Vector3 axis)
		{
			this.m_Angle = angle;
			this.m_Axis = axis;
			this.m_IsNone = false;
		}

		// Token: 0x060019B1 RID: 6577 RVA: 0x00067AEE File Offset: 0x00065CEE
		public Rotate(Angle angle)
		{
			this.m_Angle = angle;
			this.m_Axis = Vector3.forward;
			this.m_IsNone = false;
		}

		// Token: 0x060019B2 RID: 6578 RVA: 0x00067B0C File Offset: 0x00065D0C
		internal static Rotate Initial()
		{
			return new Rotate(0f);
		}

		// Token: 0x060019B3 RID: 6579 RVA: 0x00067B30 File Offset: 0x00065D30
		public static Rotate None()
		{
			Rotate result = Rotate.Initial();
			result.m_IsNone = true;
			return result;
		}

		// Token: 0x17000655 RID: 1621
		// (get) Token: 0x060019B4 RID: 6580 RVA: 0x00067B51 File Offset: 0x00065D51
		// (set) Token: 0x060019B5 RID: 6581 RVA: 0x00067B59 File Offset: 0x00065D59
		public Angle angle
		{
			get
			{
				return this.m_Angle;
			}
			set
			{
				this.m_Angle = value;
			}
		}

		// Token: 0x17000656 RID: 1622
		// (get) Token: 0x060019B6 RID: 6582 RVA: 0x00067B62 File Offset: 0x00065D62
		// (set) Token: 0x060019B7 RID: 6583 RVA: 0x00067B6A File Offset: 0x00065D6A
		internal Vector3 axis
		{
			get
			{
				return this.m_Axis;
			}
			set
			{
				this.m_Axis = value;
			}
		}

		// Token: 0x060019B8 RID: 6584 RVA: 0x00067B73 File Offset: 0x00065D73
		internal bool IsNone()
		{
			return this.m_IsNone;
		}

		// Token: 0x060019B9 RID: 6585 RVA: 0x00067B7C File Offset: 0x00065D7C
		public static bool operator ==(Rotate lhs, Rotate rhs)
		{
			return lhs.m_Angle == rhs.m_Angle && lhs.m_Axis == rhs.m_Axis && lhs.m_IsNone == rhs.m_IsNone;
		}

		// Token: 0x060019BA RID: 6586 RVA: 0x00067BC8 File Offset: 0x00065DC8
		public static bool operator !=(Rotate lhs, Rotate rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x060019BB RID: 6587 RVA: 0x00067BE4 File Offset: 0x00065DE4
		public bool Equals(Rotate other)
		{
			return other == this;
		}

		// Token: 0x060019BC RID: 6588 RVA: 0x00067C04 File Offset: 0x00065E04
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is Rotate)
			{
				Rotate other = (Rotate)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060019BD RID: 6589 RVA: 0x00067C30 File Offset: 0x00065E30
		public override int GetHashCode()
		{
			return this.m_Angle.GetHashCode() * 793 ^ this.m_Axis.GetHashCode() * 791 ^ this.m_IsNone.GetHashCode() * 197;
		}

		// Token: 0x060019BE RID: 6590 RVA: 0x00067C84 File Offset: 0x00065E84
		public override string ToString()
		{
			return this.m_Angle.ToString() + " " + this.m_Axis.ToString();
		}

		// Token: 0x060019BF RID: 6591 RVA: 0x00067CC4 File Offset: 0x00065EC4
		internal Quaternion ToQuaternion()
		{
			return Quaternion.AngleAxis(this.m_Angle.ToDegrees(), this.m_Axis);
		}

		// Token: 0x04000ACE RID: 2766
		private Angle m_Angle;

		// Token: 0x04000ACF RID: 2767
		private Vector3 m_Axis;

		// Token: 0x04000AD0 RID: 2768
		private bool m_IsNone;
	}
}
