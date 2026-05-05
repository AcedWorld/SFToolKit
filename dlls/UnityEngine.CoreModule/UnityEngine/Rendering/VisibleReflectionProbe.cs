using System;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x0200047F RID: 1151
	[UsedByNativeCode]
	public struct VisibleReflectionProbe : IEquatable<VisibleReflectionProbe>
	{
		// Token: 0x17000757 RID: 1879
		// (get) Token: 0x0600277D RID: 10109 RVA: 0x00043D95 File Offset: 0x00041F95
		public Texture texture
		{
			get
			{
				return (Texture)Object.FindObjectFromInstanceID(this.m_TextureId);
			}
		}

		// Token: 0x17000758 RID: 1880
		// (get) Token: 0x0600277E RID: 10110 RVA: 0x00043DA7 File Offset: 0x00041FA7
		public ReflectionProbe reflectionProbe
		{
			get
			{
				return (ReflectionProbe)Object.FindObjectFromInstanceID(this.m_InstanceId);
			}
		}

		// Token: 0x17000759 RID: 1881
		// (get) Token: 0x0600277F RID: 10111 RVA: 0x00043DBC File Offset: 0x00041FBC
		// (set) Token: 0x06002780 RID: 10112 RVA: 0x00043DD4 File Offset: 0x00041FD4
		public Bounds bounds
		{
			get
			{
				return this.m_Bounds;
			}
			set
			{
				this.m_Bounds = value;
			}
		}

		// Token: 0x1700075A RID: 1882
		// (get) Token: 0x06002781 RID: 10113 RVA: 0x00043DE0 File Offset: 0x00041FE0
		// (set) Token: 0x06002782 RID: 10114 RVA: 0x00043DF8 File Offset: 0x00041FF8
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

		// Token: 0x1700075B RID: 1883
		// (get) Token: 0x06002783 RID: 10115 RVA: 0x00043E04 File Offset: 0x00042004
		// (set) Token: 0x06002784 RID: 10116 RVA: 0x00043E1C File Offset: 0x0004201C
		public Vector4 hdrData
		{
			get
			{
				return this.m_HdrData;
			}
			set
			{
				this.m_HdrData = value;
			}
		}

		// Token: 0x1700075C RID: 1884
		// (get) Token: 0x06002785 RID: 10117 RVA: 0x00043E28 File Offset: 0x00042028
		// (set) Token: 0x06002786 RID: 10118 RVA: 0x00043E40 File Offset: 0x00042040
		public Vector3 center
		{
			get
			{
				return this.m_Center;
			}
			set
			{
				this.m_Center = value;
			}
		}

		// Token: 0x1700075D RID: 1885
		// (get) Token: 0x06002787 RID: 10119 RVA: 0x00043E4C File Offset: 0x0004204C
		// (set) Token: 0x06002788 RID: 10120 RVA: 0x00043E64 File Offset: 0x00042064
		public float blendDistance
		{
			get
			{
				return this.m_BlendDistance;
			}
			set
			{
				this.m_BlendDistance = value;
			}
		}

		// Token: 0x1700075E RID: 1886
		// (get) Token: 0x06002789 RID: 10121 RVA: 0x00043E70 File Offset: 0x00042070
		// (set) Token: 0x0600278A RID: 10122 RVA: 0x00043E88 File Offset: 0x00042088
		public int importance
		{
			get
			{
				return this.m_Importance;
			}
			set
			{
				this.m_Importance = value;
			}
		}

		// Token: 0x1700075F RID: 1887
		// (get) Token: 0x0600278B RID: 10123 RVA: 0x00043E94 File Offset: 0x00042094
		// (set) Token: 0x0600278C RID: 10124 RVA: 0x00043EB1 File Offset: 0x000420B1
		public bool isBoxProjection
		{
			get
			{
				return Convert.ToBoolean(this.m_BoxProjection);
			}
			set
			{
				this.m_BoxProjection = Convert.ToInt32(value);
			}
		}

		// Token: 0x0600278D RID: 10125 RVA: 0x00043EC0 File Offset: 0x000420C0
		public bool Equals(VisibleReflectionProbe other)
		{
			return this.m_Bounds.Equals(other.m_Bounds) && this.m_LocalToWorldMatrix.Equals(other.m_LocalToWorldMatrix) && this.m_HdrData.Equals(other.m_HdrData) && this.m_Center.Equals(other.m_Center) && this.m_BlendDistance.Equals(other.m_BlendDistance) && this.m_Importance == other.m_Importance && this.m_BoxProjection == other.m_BoxProjection && this.m_InstanceId == other.m_InstanceId && this.m_TextureId == other.m_TextureId;
		}

		// Token: 0x0600278E RID: 10126 RVA: 0x00043F70 File Offset: 0x00042170
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is VisibleReflectionProbe && this.Equals((VisibleReflectionProbe)obj);
		}

		// Token: 0x0600278F RID: 10127 RVA: 0x00043FA8 File Offset: 0x000421A8
		public override int GetHashCode()
		{
			int num = this.m_Bounds.GetHashCode();
			num = (num * 397 ^ this.m_LocalToWorldMatrix.GetHashCode());
			num = (num * 397 ^ this.m_HdrData.GetHashCode());
			num = (num * 397 ^ this.m_Center.GetHashCode());
			num = (num * 397 ^ this.m_BlendDistance.GetHashCode());
			num = (num * 397 ^ this.m_Importance);
			num = (num * 397 ^ this.m_BoxProjection);
			num = (num * 397 ^ this.m_InstanceId);
			return num * 397 ^ this.m_TextureId;
		}

		// Token: 0x06002790 RID: 10128 RVA: 0x0004406C File Offset: 0x0004226C
		public static bool operator ==(VisibleReflectionProbe left, VisibleReflectionProbe right)
		{
			return left.Equals(right);
		}

		// Token: 0x06002791 RID: 10129 RVA: 0x00044088 File Offset: 0x00042288
		public static bool operator !=(VisibleReflectionProbe left, VisibleReflectionProbe right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000EF6 RID: 3830
		private Bounds m_Bounds;

		// Token: 0x04000EF7 RID: 3831
		private Matrix4x4 m_LocalToWorldMatrix;

		// Token: 0x04000EF8 RID: 3832
		private Vector4 m_HdrData;

		// Token: 0x04000EF9 RID: 3833
		private Vector3 m_Center;

		// Token: 0x04000EFA RID: 3834
		private float m_BlendDistance;

		// Token: 0x04000EFB RID: 3835
		private int m_Importance;

		// Token: 0x04000EFC RID: 3836
		private int m_BoxProjection;

		// Token: 0x04000EFD RID: 3837
		private int m_InstanceId;

		// Token: 0x04000EFE RID: 3838
		private int m_TextureId;
	}
}
