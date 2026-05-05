using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x02000473 RID: 1139
	[UsedByNativeCode]
	public struct ShadowSplitData : IEquatable<ShadowSplitData>
	{
		// Token: 0x17000715 RID: 1813
		// (get) Token: 0x060026C6 RID: 9926 RVA: 0x00042828 File Offset: 0x00040A28
		// (set) Token: 0x060026C7 RID: 9927 RVA: 0x00042840 File Offset: 0x00040A40
		public int cullingPlaneCount
		{
			get
			{
				return this.m_CullingPlaneCount;
			}
			set
			{
				bool flag = value < 0 || value > 10;
				if (flag)
				{
					throw new ArgumentException(string.Format("Value should range from {0} to ShadowSplitData.maximumCullingPlaneCount ({1}), but was {2}.", 0, 10, value));
				}
				this.m_CullingPlaneCount = value;
			}
		}

		// Token: 0x17000716 RID: 1814
		// (get) Token: 0x060026C8 RID: 9928 RVA: 0x00042888 File Offset: 0x00040A88
		// (set) Token: 0x060026C9 RID: 9929 RVA: 0x000428A0 File Offset: 0x00040AA0
		public Vector4 cullingSphere
		{
			get
			{
				return this.m_CullingSphere;
			}
			set
			{
				this.m_CullingSphere = value;
			}
		}

		// Token: 0x17000717 RID: 1815
		// (get) Token: 0x060026CA RID: 9930 RVA: 0x000428AC File Offset: 0x00040AAC
		// (set) Token: 0x060026CB RID: 9931 RVA: 0x000428C4 File Offset: 0x00040AC4
		public Matrix4x4 cullingMatrix
		{
			get
			{
				return this.m_CullingMatrix;
			}
			set
			{
				this.m_CullingMatrix = value;
			}
		}

		// Token: 0x17000718 RID: 1816
		// (get) Token: 0x060026CC RID: 9932 RVA: 0x000428D0 File Offset: 0x00040AD0
		// (set) Token: 0x060026CD RID: 9933 RVA: 0x000428E8 File Offset: 0x00040AE8
		public float cullingNearPlane
		{
			get
			{
				return this.m_CullingNearPlane;
			}
			set
			{
				this.m_CullingNearPlane = value;
			}
		}

		// Token: 0x17000719 RID: 1817
		// (get) Token: 0x060026CE RID: 9934 RVA: 0x000428F4 File Offset: 0x00040AF4
		// (set) Token: 0x060026CF RID: 9935 RVA: 0x0004290C File Offset: 0x00040B0C
		public float shadowCascadeBlendCullingFactor
		{
			get
			{
				return this.m_ShadowCascadeBlendCullingFactor;
			}
			set
			{
				bool flag = value < 0f || value > 1f;
				if (flag)
				{
					throw new ArgumentException(string.Format("Value should range from {0} to {1}, but was {2}.", 0, 1, value));
				}
				this.m_ShadowCascadeBlendCullingFactor = value;
			}
		}

		// Token: 0x060026D0 RID: 9936 RVA: 0x0004295C File Offset: 0x00040B5C
		public unsafe Plane GetCullingPlane(int index)
		{
			bool flag = index < 0 || index >= this.cullingPlaneCount;
			if (flag)
			{
				throw new ArgumentException("index", string.Format("Index should be at least {0} and less than cullingPlaneCount ({1}), but was {2}.", 0, this.cullingPlaneCount, index));
			}
			fixed (byte* ptr = &this.m_CullingPlanes.FixedElementField)
			{
				byte* ptr2 = ptr;
				Plane* ptr3 = (Plane*)ptr2;
				return ptr3[index];
			}
		}

		// Token: 0x060026D1 RID: 9937 RVA: 0x000429D8 File Offset: 0x00040BD8
		public unsafe void SetCullingPlane(int index, Plane plane)
		{
			bool flag = index < 0 || index >= this.cullingPlaneCount;
			if (flag)
			{
				throw new ArgumentException("index", string.Format("Index should be at least {0} and less than cullingPlaneCount ({1}), but was {2}.", 0, this.cullingPlaneCount, index));
			}
			fixed (byte* ptr = &this.m_CullingPlanes.FixedElementField)
			{
				byte* ptr2 = ptr;
				Plane* ptr3 = (Plane*)ptr2;
				ptr3[index] = plane;
			}
		}

		// Token: 0x060026D2 RID: 9938 RVA: 0x00042A50 File Offset: 0x00040C50
		public bool Equals(ShadowSplitData other)
		{
			bool flag = this.m_CullingPlaneCount != other.m_CullingPlaneCount;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < this.cullingPlaneCount; i++)
				{
					bool flag2 = !this.GetCullingPlane(i).Equals(other.GetCullingPlane(i));
					if (flag2)
					{
						return false;
					}
				}
				result = this.m_CullingSphere.Equals(other.m_CullingSphere);
			}
			return result;
		}

		// Token: 0x060026D3 RID: 9939 RVA: 0x00042AD8 File Offset: 0x00040CD8
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is ShadowSplitData && this.Equals((ShadowSplitData)obj);
		}

		// Token: 0x060026D4 RID: 9940 RVA: 0x00042B10 File Offset: 0x00040D10
		public override int GetHashCode()
		{
			return this.m_CullingPlaneCount * 397 ^ this.m_CullingSphere.GetHashCode();
		}

		// Token: 0x060026D5 RID: 9941 RVA: 0x00042B44 File Offset: 0x00040D44
		public static bool operator ==(ShadowSplitData left, ShadowSplitData right)
		{
			return left.Equals(right);
		}

		// Token: 0x060026D6 RID: 9942 RVA: 0x00042B60 File Offset: 0x00040D60
		public static bool operator !=(ShadowSplitData left, ShadowSplitData right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000E99 RID: 3737
		private const int k_MaximumCullingPlaneCount = 10;

		// Token: 0x04000E9A RID: 3738
		public static readonly int maximumCullingPlaneCount = 10;

		// Token: 0x04000E9B RID: 3739
		private int m_CullingPlaneCount;

		// Token: 0x04000E9C RID: 3740
		[FixedBuffer(typeof(byte), 160)]
		internal ShadowSplitData.<m_CullingPlanes>e__FixedBuffer m_CullingPlanes;

		// Token: 0x04000E9D RID: 3741
		private Vector4 m_CullingSphere;

		// Token: 0x04000E9E RID: 3742
		private float m_ShadowCascadeBlendCullingFactor;

		// Token: 0x04000E9F RID: 3743
		private float m_CullingNearPlane;

		// Token: 0x04000EA0 RID: 3744
		private Matrix4x4 m_CullingMatrix;

		// Token: 0x02000474 RID: 1140
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 160)]
		public struct <m_CullingPlanes>e__FixedBuffer
		{
			// Token: 0x04000EA1 RID: 3745
			public byte FixedElementField;
		}
	}
}
