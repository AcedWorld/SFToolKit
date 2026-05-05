using System;

namespace UnityEngine
{
	// Token: 0x02000282 RID: 642
	internal struct SnapAxisFilter : IEquatable<SnapAxisFilter>
	{
		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x06001ABB RID: 6843 RVA: 0x0002CE50 File Offset: 0x0002B050
		public float x
		{
			get
			{
				return ((this.m_Mask & SnapAxis.X) == SnapAxis.X) ? 1f : 0f;
			}
		}

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x06001ABC RID: 6844 RVA: 0x0002CE7C File Offset: 0x0002B07C
		public float y
		{
			get
			{
				return ((this.m_Mask & SnapAxis.Y) == SnapAxis.Y) ? 1f : 0f;
			}
		}

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x06001ABD RID: 6845 RVA: 0x0002CEA8 File Offset: 0x0002B0A8
		public float z
		{
			get
			{
				return ((this.m_Mask & SnapAxis.Z) == SnapAxis.Z) ? 1f : 0f;
			}
		}

		// Token: 0x06001ABE RID: 6846 RVA: 0x0002CED4 File Offset: 0x0002B0D4
		public SnapAxisFilter(Vector3 v)
		{
			this.m_Mask = SnapAxis.None;
			float num = 1E-06f;
			bool flag = Mathf.Abs(v.x) > num;
			if (flag)
			{
				this.m_Mask |= SnapAxis.X;
			}
			bool flag2 = Mathf.Abs(v.y) > num;
			if (flag2)
			{
				this.m_Mask |= SnapAxis.Y;
			}
			bool flag3 = Mathf.Abs(v.z) > num;
			if (flag3)
			{
				this.m_Mask |= SnapAxis.Z;
			}
		}

		// Token: 0x06001ABF RID: 6847 RVA: 0x0002CF50 File Offset: 0x0002B150
		public SnapAxisFilter(SnapAxis axis)
		{
			this.m_Mask = SnapAxis.None;
			bool flag = (axis & SnapAxis.X) == SnapAxis.X;
			if (flag)
			{
				this.m_Mask |= SnapAxis.X;
			}
			bool flag2 = (axis & SnapAxis.Y) == SnapAxis.Y;
			if (flag2)
			{
				this.m_Mask |= SnapAxis.Y;
			}
			bool flag3 = (axis & SnapAxis.Z) == SnapAxis.Z;
			if (flag3)
			{
				this.m_Mask |= SnapAxis.Z;
			}
		}

		// Token: 0x06001AC0 RID: 6848 RVA: 0x0002CFB0 File Offset: 0x0002B1B0
		public override string ToString()
		{
			return string.Format("{{{0}, {1}, {2}}}", this.x, this.y, this.z);
		}

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06001AC1 RID: 6849 RVA: 0x0002CFF0 File Offset: 0x0002B1F0
		public int active
		{
			get
			{
				int num = 0;
				bool flag = (this.m_Mask & SnapAxis.X) > SnapAxis.None;
				if (flag)
				{
					num++;
				}
				bool flag2 = (this.m_Mask & SnapAxis.Y) > SnapAxis.None;
				if (flag2)
				{
					num++;
				}
				bool flag3 = (this.m_Mask & SnapAxis.Z) > SnapAxis.None;
				if (flag3)
				{
					num++;
				}
				return num;
			}
		}

		// Token: 0x06001AC2 RID: 6850 RVA: 0x0002D040 File Offset: 0x0002B240
		public static implicit operator Vector3(SnapAxisFilter mask)
		{
			return new Vector3(mask.x, mask.y, mask.z);
		}

		// Token: 0x06001AC3 RID: 6851 RVA: 0x0002D06C File Offset: 0x0002B26C
		public static explicit operator SnapAxisFilter(Vector3 v)
		{
			return new SnapAxisFilter(v);
		}

		// Token: 0x06001AC4 RID: 6852 RVA: 0x0002D084 File Offset: 0x0002B284
		public static explicit operator SnapAxis(SnapAxisFilter mask)
		{
			return mask.m_Mask;
		}

		// Token: 0x06001AC5 RID: 6853 RVA: 0x0002D09C File Offset: 0x0002B29C
		public static SnapAxisFilter operator |(SnapAxisFilter left, SnapAxisFilter right)
		{
			return new SnapAxisFilter(left.m_Mask | right.m_Mask);
		}

		// Token: 0x06001AC6 RID: 6854 RVA: 0x0002D0C0 File Offset: 0x0002B2C0
		public static SnapAxisFilter operator &(SnapAxisFilter left, SnapAxisFilter right)
		{
			return new SnapAxisFilter(left.m_Mask & right.m_Mask);
		}

		// Token: 0x06001AC7 RID: 6855 RVA: 0x0002D0E4 File Offset: 0x0002B2E4
		public static SnapAxisFilter operator ^(SnapAxisFilter left, SnapAxisFilter right)
		{
			return new SnapAxisFilter(left.m_Mask ^ right.m_Mask);
		}

		// Token: 0x06001AC8 RID: 6856 RVA: 0x0002D108 File Offset: 0x0002B308
		public static SnapAxisFilter operator ~(SnapAxisFilter left)
		{
			return new SnapAxisFilter(~left.m_Mask);
		}

		// Token: 0x06001AC9 RID: 6857 RVA: 0x0002D128 File Offset: 0x0002B328
		public static Vector3 operator *(SnapAxisFilter mask, float value)
		{
			return new Vector3(mask.x * value, mask.y * value, mask.z * value);
		}

		// Token: 0x06001ACA RID: 6858 RVA: 0x0002D15C File Offset: 0x0002B35C
		public static Vector3 operator *(SnapAxisFilter mask, Vector3 right)
		{
			return new Vector3(mask.x * right.x, mask.y * right.y, mask.z * right.z);
		}

		// Token: 0x06001ACB RID: 6859 RVA: 0x0002D1A0 File Offset: 0x0002B3A0
		public static Vector3 operator *(Quaternion rotation, SnapAxisFilter mask)
		{
			int active = mask.active;
			bool flag = active > 2;
			Vector3 result;
			if (flag)
			{
				result = mask;
			}
			else
			{
				Vector3 vector = rotation * mask;
				vector = new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
				bool flag2 = active > 1;
				if (flag2)
				{
					result = new Vector3((float)((vector.x > vector.y || vector.x > vector.z) ? 1 : 0), (float)((vector.y > vector.x || vector.y > vector.z) ? 1 : 0), (float)((vector.z > vector.x || vector.z > vector.y) ? 1 : 0));
				}
				else
				{
					result = new Vector3((float)((vector.x > vector.y && vector.x > vector.z) ? 1 : 0), (float)((vector.y > vector.z && vector.y > vector.x) ? 1 : 0), (float)((vector.z > vector.x && vector.z > vector.y) ? 1 : 0));
				}
			}
			return result;
		}

		// Token: 0x06001ACC RID: 6860 RVA: 0x0002D2E4 File Offset: 0x0002B4E4
		public static bool operator ==(SnapAxisFilter left, SnapAxisFilter right)
		{
			return left.m_Mask == right.m_Mask;
		}

		// Token: 0x06001ACD RID: 6861 RVA: 0x0002D304 File Offset: 0x0002B504
		public static bool operator !=(SnapAxisFilter left, SnapAxisFilter right)
		{
			return !(left == right);
		}

		// Token: 0x170004F7 RID: 1271
		public float this[int i]
		{
			get
			{
				bool flag = i < 0 || i > 2;
				if (flag)
				{
					throw new IndexOutOfRangeException();
				}
				return (float)(SnapAxis.X & this.m_Mask >> (i & 31)) * 1f;
			}
			set
			{
				bool flag = i < 0 || i > 2;
				if (flag)
				{
					throw new IndexOutOfRangeException();
				}
				this.m_Mask &= (SnapAxis)(~(SnapAxis)(1 << i));
				this.m_Mask |= (SnapAxis)(((value > 0f) ? 1 : 0) << (i & 31));
			}
		}

		// Token: 0x06001AD0 RID: 6864 RVA: 0x0002D3B4 File Offset: 0x0002B5B4
		public bool Equals(SnapAxisFilter other)
		{
			return this.m_Mask == other.m_Mask;
		}

		// Token: 0x06001AD1 RID: 6865 RVA: 0x0002D3D4 File Offset: 0x0002B5D4
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is SnapAxisFilter && this.Equals((SnapAxisFilter)obj);
		}

		// Token: 0x06001AD2 RID: 6866 RVA: 0x0002D40C File Offset: 0x0002B60C
		public override int GetHashCode()
		{
			return this.m_Mask.GetHashCode();
		}

		// Token: 0x04000925 RID: 2341
		private const SnapAxis X = SnapAxis.X;

		// Token: 0x04000926 RID: 2342
		private const SnapAxis Y = SnapAxis.Y;

		// Token: 0x04000927 RID: 2343
		private const SnapAxis Z = SnapAxis.Z;

		// Token: 0x04000928 RID: 2344
		public static readonly SnapAxisFilter all = new SnapAxisFilter(SnapAxis.All);

		// Token: 0x04000929 RID: 2345
		private SnapAxis m_Mask;
	}
}
