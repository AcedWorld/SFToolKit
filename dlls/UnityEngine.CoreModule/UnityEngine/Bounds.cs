using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x0200012A RID: 298
	[NativeHeader("Runtime/Geometry/Ray.h")]
	[NativeType(Header = "Runtime/Geometry/AABB.h")]
	[NativeHeader("Runtime/Geometry/AABB.h")]
	[NativeClass("AABB")]
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	[NativeHeader("Runtime/Geometry/Intersection.h")]
	[NativeHeader("Runtime/Math/MathScripting.h")]
	public struct Bounds : IEquatable<Bounds>, IFormattable
	{
		// Token: 0x06000750 RID: 1872 RVA: 0x0000B08F File Offset: 0x0000928F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Bounds(Vector3 center, Vector3 size)
		{
			this.m_Center = center;
			this.m_Extents = size * 0.5f;
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x0000B0AC File Offset: 0x000092AC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return this.center.GetHashCode() ^ this.extents.GetHashCode() << 2;
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x0000B0EC File Offset: 0x000092EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override bool Equals(object other)
		{
			bool flag = !(other is Bounds);
			return !flag && this.Equals((Bounds)other);
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x0000B120 File Offset: 0x00009320
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Bounds other)
		{
			return this.center.Equals(other.center) && this.extents.Equals(other.extents);
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000754 RID: 1876 RVA: 0x0000B164 File Offset: 0x00009364
		// (set) Token: 0x06000755 RID: 1877 RVA: 0x0000B17C File Offset: 0x0000937C
		public Vector3 center
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.m_Center;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.m_Center = value;
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000756 RID: 1878 RVA: 0x0000B188 File Offset: 0x00009388
		// (set) Token: 0x06000757 RID: 1879 RVA: 0x0000B1AA File Offset: 0x000093AA
		public Vector3 size
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.m_Extents * 2f;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.m_Extents = value * 0.5f;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000758 RID: 1880 RVA: 0x0000B1C0 File Offset: 0x000093C0
		// (set) Token: 0x06000759 RID: 1881 RVA: 0x0000B1D8 File Offset: 0x000093D8
		public Vector3 extents
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.m_Extents;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.m_Extents = value;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x0600075A RID: 1882 RVA: 0x0000B1E4 File Offset: 0x000093E4
		// (set) Token: 0x0600075B RID: 1883 RVA: 0x0000B207 File Offset: 0x00009407
		public Vector3 min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.center - this.extents;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.SetMinMax(value, this.max);
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x0600075C RID: 1884 RVA: 0x0000B218 File Offset: 0x00009418
		// (set) Token: 0x0600075D RID: 1885 RVA: 0x0000B23B File Offset: 0x0000943B
		public Vector3 max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.center + this.extents;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.SetMinMax(this.min, value);
			}
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x0000B24C File Offset: 0x0000944C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Bounds lhs, Bounds rhs)
		{
			return lhs.center == rhs.center && lhs.extents == rhs.extents;
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x0000B28C File Offset: 0x0000948C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Bounds lhs, Bounds rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x0000B2A8 File Offset: 0x000094A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetMinMax(Vector3 min, Vector3 max)
		{
			this.extents = (max - min) * 0.5f;
			this.center = min + this.extents;
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x0000B2D6 File Offset: 0x000094D6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Encapsulate(Vector3 point)
		{
			this.SetMinMax(Vector3.Min(this.min, point), Vector3.Max(this.max, point));
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x0000B2F8 File Offset: 0x000094F8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Encapsulate(Bounds bounds)
		{
			this.Encapsulate(bounds.center - bounds.extents);
			this.Encapsulate(bounds.center + bounds.extents);
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x0000B32F File Offset: 0x0000952F
		public void Expand(float amount)
		{
			amount *= 0.5f;
			this.extents += new Vector3(amount, amount, amount);
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x0000B355 File Offset: 0x00009555
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Expand(Vector3 amount)
		{
			this.extents += amount * 0.5f;
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x0000B378 File Offset: 0x00009578
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Intersects(Bounds bounds)
		{
			return this.min.x <= bounds.max.x && this.max.x >= bounds.min.x && this.min.y <= bounds.max.y && this.max.y >= bounds.min.y && this.min.z <= bounds.max.z && this.max.z >= bounds.min.z;
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x0000B42C File Offset: 0x0000962C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IntersectRay(Ray ray)
		{
			float num;
			return Bounds.IntersectRayAABB(ray, this, out num);
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x0000B44C File Offset: 0x0000964C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IntersectRay(Ray ray, out float distance)
		{
			return Bounds.IntersectRayAABB(ray, this, out distance);
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x0000B46C File Offset: 0x0000966C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return this.ToString(null, null);
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x0000B488 File Offset: 0x00009688
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format)
		{
			return this.ToString(format, null);
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x0000B4A4 File Offset: 0x000096A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			bool flag = string.IsNullOrEmpty(format);
			if (flag)
			{
				format = "F2";
			}
			bool flag2 = formatProvider == null;
			if (flag2)
			{
				formatProvider = CultureInfo.InvariantCulture.NumberFormat;
			}
			return UnityString.Format("Center: {0}, Extents: {1}", new object[]
			{
				this.m_Center.ToString(format, formatProvider),
				this.m_Extents.ToString(format, formatProvider)
			});
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x0000B50B File Offset: 0x0000970B
		[NativeMethod("IsInside", IsThreadSafe = true)]
		public bool Contains(Vector3 point)
		{
			return Bounds.Contains_Injected(ref this, ref point);
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x0000B515 File Offset: 0x00009715
		[FreeFunction("BoundsScripting::SqrDistance", HasExplicitThis = true, IsThreadSafe = true)]
		public float SqrDistance(Vector3 point)
		{
			return Bounds.SqrDistance_Injected(ref this, ref point);
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x0000B51F File Offset: 0x0000971F
		[FreeFunction("IntersectRayAABB", IsThreadSafe = true)]
		private static bool IntersectRayAABB(Ray ray, Bounds bounds, out float dist)
		{
			return Bounds.IntersectRayAABB_Injected(ref ray, ref bounds, out dist);
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x0000B52C File Offset: 0x0000972C
		[FreeFunction("BoundsScripting::ClosestPoint", HasExplicitThis = true, IsThreadSafe = true)]
		public Vector3 ClosestPoint(Vector3 point)
		{
			Vector3 result;
			Bounds.ClosestPoint_Injected(ref this, ref point, out result);
			return result;
		}

		// Token: 0x0600076F RID: 1903
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Contains_Injected(ref Bounds _unity_self, ref Vector3 point);

		// Token: 0x06000770 RID: 1904
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float SqrDistance_Injected(ref Bounds _unity_self, ref Vector3 point);

		// Token: 0x06000771 RID: 1905
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IntersectRayAABB_Injected(ref Ray ray, ref Bounds bounds, out float dist);

		// Token: 0x06000772 RID: 1906
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ClosestPoint_Injected(ref Bounds _unity_self, ref Vector3 point, out Vector3 ret);

		// Token: 0x040003DF RID: 991
		private Vector3 m_Center;

		// Token: 0x040003E0 RID: 992
		[NativeName("m_Extent")]
		private Vector3 m_Extents;
	}
}
