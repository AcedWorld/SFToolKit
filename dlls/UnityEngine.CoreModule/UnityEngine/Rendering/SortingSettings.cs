using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000478 RID: 1144
	public struct SortingSettings : IEquatable<SortingSettings>
	{
		// Token: 0x060026E3 RID: 9955 RVA: 0x00042CDC File Offset: 0x00040EDC
		public SortingSettings(Camera camera)
		{
			ScriptableRenderContext.InitializeSortSettings(camera, out this);
			this.m_Criteria = this.criteria;
		}

		// Token: 0x1700071D RID: 1821
		// (get) Token: 0x060026E4 RID: 9956 RVA: 0x00042CF4 File Offset: 0x00040EF4
		// (set) Token: 0x060026E5 RID: 9957 RVA: 0x00042D0C File Offset: 0x00040F0C
		public Matrix4x4 worldToCameraMatrix
		{
			get
			{
				return this.m_WorldToCameraMatrix;
			}
			set
			{
				this.m_WorldToCameraMatrix = value;
			}
		}

		// Token: 0x1700071E RID: 1822
		// (get) Token: 0x060026E6 RID: 9958 RVA: 0x00042D18 File Offset: 0x00040F18
		// (set) Token: 0x060026E7 RID: 9959 RVA: 0x00042D30 File Offset: 0x00040F30
		public Vector3 cameraPosition
		{
			get
			{
				return this.m_CameraPosition;
			}
			set
			{
				this.m_CameraPosition = value;
			}
		}

		// Token: 0x1700071F RID: 1823
		// (get) Token: 0x060026E8 RID: 9960 RVA: 0x00042D3C File Offset: 0x00040F3C
		// (set) Token: 0x060026E9 RID: 9961 RVA: 0x00042D54 File Offset: 0x00040F54
		public Vector3 customAxis
		{
			get
			{
				return this.m_CustomAxis;
			}
			set
			{
				this.m_CustomAxis = value;
			}
		}

		// Token: 0x17000720 RID: 1824
		// (get) Token: 0x060026EA RID: 9962 RVA: 0x00042D60 File Offset: 0x00040F60
		// (set) Token: 0x060026EB RID: 9963 RVA: 0x00042D78 File Offset: 0x00040F78
		public SortingCriteria criteria
		{
			get
			{
				return this.m_Criteria;
			}
			set
			{
				this.m_Criteria = value;
			}
		}

		// Token: 0x17000721 RID: 1825
		// (get) Token: 0x060026EC RID: 9964 RVA: 0x00042D84 File Offset: 0x00040F84
		// (set) Token: 0x060026ED RID: 9965 RVA: 0x00042D9C File Offset: 0x00040F9C
		public DistanceMetric distanceMetric
		{
			get
			{
				return this.m_DistanceMetric;
			}
			set
			{
				this.m_DistanceMetric = value;
			}
		}

		// Token: 0x060026EE RID: 9966 RVA: 0x00042DA8 File Offset: 0x00040FA8
		public bool Equals(SortingSettings other)
		{
			return this.m_WorldToCameraMatrix.Equals(other.m_WorldToCameraMatrix) && this.m_CameraPosition.Equals(other.m_CameraPosition) && this.m_CustomAxis.Equals(other.m_CustomAxis) && this.m_Criteria == other.m_Criteria && this.m_DistanceMetric == other.m_DistanceMetric;
		}

		// Token: 0x060026EF RID: 9967 RVA: 0x00042E14 File Offset: 0x00041014
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is SortingSettings && this.Equals((SortingSettings)obj);
		}

		// Token: 0x060026F0 RID: 9968 RVA: 0x00042E4C File Offset: 0x0004104C
		public override int GetHashCode()
		{
			int num = this.m_WorldToCameraMatrix.GetHashCode();
			num = (num * 397 ^ this.m_CameraPosition.GetHashCode());
			num = (num * 397 ^ this.m_CustomAxis.GetHashCode());
			num = (num * 397 ^ (int)this.m_Criteria);
			return num * 397 ^ (int)this.m_DistanceMetric;
		}

		// Token: 0x060026F1 RID: 9969 RVA: 0x00042EC4 File Offset: 0x000410C4
		public static bool operator ==(SortingSettings left, SortingSettings right)
		{
			return left.Equals(right);
		}

		// Token: 0x060026F2 RID: 9970 RVA: 0x00042EE0 File Offset: 0x000410E0
		public static bool operator !=(SortingSettings left, SortingSettings right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000EB3 RID: 3763
		private Matrix4x4 m_WorldToCameraMatrix;

		// Token: 0x04000EB4 RID: 3764
		private Vector3 m_CameraPosition;

		// Token: 0x04000EB5 RID: 3765
		private Vector3 m_CustomAxis;

		// Token: 0x04000EB6 RID: 3766
		private SortingCriteria m_Criteria;

		// Token: 0x04000EB7 RID: 3767
		private DistanceMetric m_DistanceMetric;
	}
}
