using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002F8 RID: 760
	public struct Scale : IEquatable<Scale>
	{
		// Token: 0x060019C0 RID: 6592 RVA: 0x00067CEC File Offset: 0x00065EEC
		public Scale(Vector2 scale)
		{
			this.m_Scale = new Vector3(scale.x, scale.y, 1f);
			this.m_IsNone = false;
		}

		// Token: 0x060019C1 RID: 6593 RVA: 0x00067D14 File Offset: 0x00065F14
		public Scale(Vector3 scale)
		{
			bool flag = !Mathf.Approximately(1f, scale.z);
			if (flag)
			{
				Debug.LogWarning("Assigning Z scale different than 1.0f, this is not yet supported. Forcing the value to 1.0f.");
				scale.z = 1f;
			}
			this.m_Scale = scale;
			this.m_IsNone = false;
		}

		// Token: 0x060019C2 RID: 6594 RVA: 0x00067D60 File Offset: 0x00065F60
		internal static Scale Initial()
		{
			return new Scale(Vector3.one);
		}

		// Token: 0x060019C3 RID: 6595 RVA: 0x00067D7C File Offset: 0x00065F7C
		public static Scale None()
		{
			Scale result = Scale.Initial();
			result.m_IsNone = true;
			return result;
		}

		// Token: 0x17000657 RID: 1623
		// (get) Token: 0x060019C4 RID: 6596 RVA: 0x00067D9D File Offset: 0x00065F9D
		// (set) Token: 0x060019C5 RID: 6597 RVA: 0x00067DA5 File Offset: 0x00065FA5
		public Vector3 value
		{
			get
			{
				return this.m_Scale;
			}
			set
			{
				this.m_Scale = value;
			}
		}

		// Token: 0x060019C6 RID: 6598 RVA: 0x00067DAE File Offset: 0x00065FAE
		internal bool IsNone()
		{
			return this.m_IsNone;
		}

		// Token: 0x060019C7 RID: 6599 RVA: 0x00067DB8 File Offset: 0x00065FB8
		public static implicit operator Scale(Vector2 scale)
		{
			return new Scale(scale);
		}

		// Token: 0x060019C8 RID: 6600 RVA: 0x00067DD0 File Offset: 0x00065FD0
		public static bool operator ==(Scale lhs, Scale rhs)
		{
			return lhs.m_Scale == rhs.m_Scale;
		}

		// Token: 0x060019C9 RID: 6601 RVA: 0x00067DF4 File Offset: 0x00065FF4
		public static bool operator !=(Scale lhs, Scale rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x060019CA RID: 6602 RVA: 0x00067E10 File Offset: 0x00066010
		public bool Equals(Scale other)
		{
			return other == this;
		}

		// Token: 0x060019CB RID: 6603 RVA: 0x00067E30 File Offset: 0x00066030
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is Scale)
			{
				Scale other = (Scale)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060019CC RID: 6604 RVA: 0x00067E5C File Offset: 0x0006605C
		public override int GetHashCode()
		{
			return this.m_Scale.GetHashCode() * 793;
		}

		// Token: 0x060019CD RID: 6605 RVA: 0x00067E88 File Offset: 0x00066088
		public override string ToString()
		{
			return this.m_Scale.ToString();
		}

		// Token: 0x04000AD1 RID: 2769
		private Vector3 m_Scale;

		// Token: 0x04000AD2 RID: 2770
		private bool m_IsNone;
	}
}
