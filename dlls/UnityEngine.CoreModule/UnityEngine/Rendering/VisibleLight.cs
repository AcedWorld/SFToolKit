using System;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x0200047D RID: 1149
	[UsedByNativeCode]
	public struct VisibleLight : IEquatable<VisibleLight>
	{
		// Token: 0x1700074E RID: 1870
		// (get) Token: 0x06002767 RID: 10087 RVA: 0x00043A42 File Offset: 0x00041C42
		public Light light
		{
			get
			{
				return (Light)Object.FindObjectFromInstanceID(this.m_InstanceId);
			}
		}

		// Token: 0x1700074F RID: 1871
		// (get) Token: 0x06002768 RID: 10088 RVA: 0x00043A54 File Offset: 0x00041C54
		// (set) Token: 0x06002769 RID: 10089 RVA: 0x00043A6C File Offset: 0x00041C6C
		public LightType lightType
		{
			get
			{
				return this.m_LightType;
			}
			set
			{
				this.m_LightType = value;
			}
		}

		// Token: 0x17000750 RID: 1872
		// (get) Token: 0x0600276A RID: 10090 RVA: 0x00043A78 File Offset: 0x00041C78
		// (set) Token: 0x0600276B RID: 10091 RVA: 0x00043A90 File Offset: 0x00041C90
		public Color finalColor
		{
			get
			{
				return this.m_FinalColor;
			}
			set
			{
				this.m_FinalColor = value;
			}
		}

		// Token: 0x17000751 RID: 1873
		// (get) Token: 0x0600276C RID: 10092 RVA: 0x00043A9C File Offset: 0x00041C9C
		// (set) Token: 0x0600276D RID: 10093 RVA: 0x00043AB4 File Offset: 0x00041CB4
		public Rect screenRect
		{
			get
			{
				return this.m_ScreenRect;
			}
			set
			{
				this.m_ScreenRect = value;
			}
		}

		// Token: 0x17000752 RID: 1874
		// (get) Token: 0x0600276E RID: 10094 RVA: 0x00043AC0 File Offset: 0x00041CC0
		// (set) Token: 0x0600276F RID: 10095 RVA: 0x00043AD8 File Offset: 0x00041CD8
		public Matrix4x4 localToWorldMatrix
		{
			get
			{
				return this.m_LocalToWorldMatrix;
			}
			set
			{
				this.m_LocalToWorldMatrix = value;
			}
		}

		// Token: 0x17000753 RID: 1875
		// (get) Token: 0x06002770 RID: 10096 RVA: 0x00043AE4 File Offset: 0x00041CE4
		// (set) Token: 0x06002771 RID: 10097 RVA: 0x00043AFC File Offset: 0x00041CFC
		public float range
		{
			get
			{
				return this.m_Range;
			}
			set
			{
				this.m_Range = value;
			}
		}

		// Token: 0x17000754 RID: 1876
		// (get) Token: 0x06002772 RID: 10098 RVA: 0x00043B08 File Offset: 0x00041D08
		// (set) Token: 0x06002773 RID: 10099 RVA: 0x00043B20 File Offset: 0x00041D20
		public float spotAngle
		{
			get
			{
				return this.m_SpotAngle;
			}
			set
			{
				this.m_SpotAngle = value;
			}
		}

		// Token: 0x17000755 RID: 1877
		// (get) Token: 0x06002774 RID: 10100 RVA: 0x00043B2C File Offset: 0x00041D2C
		// (set) Token: 0x06002775 RID: 10101 RVA: 0x00043B4C File Offset: 0x00041D4C
		public bool intersectsNearPlane
		{
			get
			{
				return (this.m_Flags & VisibleLightFlags.IntersectsNearPlane) > (VisibleLightFlags)0;
			}
			set
			{
				if (value)
				{
					this.m_Flags |= VisibleLightFlags.IntersectsNearPlane;
				}
				else
				{
					this.m_Flags &= ~VisibleLightFlags.IntersectsNearPlane;
				}
			}
		}

		// Token: 0x17000756 RID: 1878
		// (get) Token: 0x06002776 RID: 10102 RVA: 0x00043B80 File Offset: 0x00041D80
		// (set) Token: 0x06002777 RID: 10103 RVA: 0x00043BA0 File Offset: 0x00041DA0
		public bool intersectsFarPlane
		{
			get
			{
				return (this.m_Flags & VisibleLightFlags.IntersectsFarPlane) > (VisibleLightFlags)0;
			}
			set
			{
				if (value)
				{
					this.m_Flags |= VisibleLightFlags.IntersectsFarPlane;
				}
				else
				{
					this.m_Flags &= ~VisibleLightFlags.IntersectsFarPlane;
				}
			}
		}

		// Token: 0x06002778 RID: 10104 RVA: 0x00043BD4 File Offset: 0x00041DD4
		public bool Equals(VisibleLight other)
		{
			return this.m_LightType == other.m_LightType && this.m_FinalColor.Equals(other.m_FinalColor) && this.m_ScreenRect.Equals(other.m_ScreenRect) && this.m_LocalToWorldMatrix.Equals(other.m_LocalToWorldMatrix) && this.m_Range.Equals(other.m_Range) && this.m_SpotAngle.Equals(other.m_SpotAngle) && this.m_InstanceId == other.m_InstanceId && this.m_Flags == other.m_Flags;
		}

		// Token: 0x06002779 RID: 10105 RVA: 0x00043C74 File Offset: 0x00041E74
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is VisibleLight && this.Equals((VisibleLight)obj);
		}

		// Token: 0x0600277A RID: 10106 RVA: 0x00043CAC File Offset: 0x00041EAC
		public override int GetHashCode()
		{
			int num = (int)this.m_LightType;
			num = (num * 397 ^ this.m_FinalColor.GetHashCode());
			num = (num * 397 ^ this.m_ScreenRect.GetHashCode());
			num = (num * 397 ^ this.m_LocalToWorldMatrix.GetHashCode());
			num = (num * 397 ^ this.m_Range.GetHashCode());
			num = (num * 397 ^ this.m_SpotAngle.GetHashCode());
			num = (num * 397 ^ this.m_InstanceId);
			return num * 397 ^ (int)this.m_Flags;
		}

		// Token: 0x0600277B RID: 10107 RVA: 0x00043D5C File Offset: 0x00041F5C
		public static bool operator ==(VisibleLight left, VisibleLight right)
		{
			return left.Equals(right);
		}

		// Token: 0x0600277C RID: 10108 RVA: 0x00043D78 File Offset: 0x00041F78
		public static bool operator !=(VisibleLight left, VisibleLight right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000EEB RID: 3819
		private LightType m_LightType;

		// Token: 0x04000EEC RID: 3820
		private Color m_FinalColor;

		// Token: 0x04000EED RID: 3821
		private Rect m_ScreenRect;

		// Token: 0x04000EEE RID: 3822
		private Matrix4x4 m_LocalToWorldMatrix;

		// Token: 0x04000EEF RID: 3823
		private float m_Range;

		// Token: 0x04000EF0 RID: 3824
		private float m_SpotAngle;

		// Token: 0x04000EF1 RID: 3825
		private int m_InstanceId;

		// Token: 0x04000EF2 RID: 3826
		private VisibleLightFlags m_Flags;
	}
}
