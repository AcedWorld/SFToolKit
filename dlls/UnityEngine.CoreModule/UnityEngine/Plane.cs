using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x0200012E RID: 302
	[UsedByNativeCode]
	public struct Plane : IFormattable
	{
		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x060007B0 RID: 1968 RVA: 0x0000C224 File Offset: 0x0000A424
		// (set) Token: 0x060007B1 RID: 1969 RVA: 0x0000C23C File Offset: 0x0000A43C
		public Vector3 normal
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.m_Normal;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.m_Normal = value;
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x060007B2 RID: 1970 RVA: 0x0000C248 File Offset: 0x0000A448
		// (set) Token: 0x060007B3 RID: 1971 RVA: 0x0000C260 File Offset: 0x0000A460
		public float distance
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.m_Distance;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.m_Distance = value;
			}
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x0000C26A File Offset: 0x0000A46A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Plane(Vector3 inNormal, Vector3 inPoint)
		{
			this.m_Normal = Vector3.Normalize(inNormal);
			this.m_Distance = -Vector3.Dot(this.m_Normal, inPoint);
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x0000C28C File Offset: 0x0000A48C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Plane(Vector3 inNormal, float d)
		{
			this.m_Normal = Vector3.Normalize(inNormal);
			this.m_Distance = d;
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x0000C2A2 File Offset: 0x0000A4A2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Plane(Vector3 a, Vector3 b, Vector3 c)
		{
			this.m_Normal = Vector3.Normalize(Vector3.Cross(b - a, c - a));
			this.m_Distance = -Vector3.Dot(this.m_Normal, a);
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x0000C26A File Offset: 0x0000A46A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetNormalAndPosition(Vector3 inNormal, Vector3 inPoint)
		{
			this.m_Normal = Vector3.Normalize(inNormal);
			this.m_Distance = -Vector3.Dot(this.m_Normal, inPoint);
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x0000C2A2 File Offset: 0x0000A4A2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set3Points(Vector3 a, Vector3 b, Vector3 c)
		{
			this.m_Normal = Vector3.Normalize(Vector3.Cross(b - a, c - a));
			this.m_Distance = -Vector3.Dot(this.m_Normal, a);
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x0000C2D6 File Offset: 0x0000A4D6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Flip()
		{
			this.m_Normal = -this.m_Normal;
			this.m_Distance = -this.m_Distance;
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x060007BA RID: 1978 RVA: 0x0000C2F8 File Offset: 0x0000A4F8
		public Plane flipped
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new Plane(-this.m_Normal, -this.m_Distance);
			}
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x0000C321 File Offset: 0x0000A521
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Translate(Vector3 translation)
		{
			this.m_Distance += Vector3.Dot(this.m_Normal, translation);
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x0000C340 File Offset: 0x0000A540
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Plane Translate(Plane plane, Vector3 translation)
		{
			return new Plane(plane.m_Normal, plane.m_Distance += Vector3.Dot(plane.m_Normal, translation));
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x0000C378 File Offset: 0x0000A578
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 ClosestPointOnPlane(Vector3 point)
		{
			float d = Vector3.Dot(this.m_Normal, point) + this.m_Distance;
			return point - this.m_Normal * d;
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x0000C3B0 File Offset: 0x0000A5B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float GetDistanceToPoint(Vector3 point)
		{
			return Vector3.Dot(this.m_Normal, point) + this.m_Distance;
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x0000C3D8 File Offset: 0x0000A5D8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool GetSide(Vector3 point)
		{
			return Vector3.Dot(this.m_Normal, point) + this.m_Distance > 0f;
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x0000C404 File Offset: 0x0000A604
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool SameSide(Vector3 inPt0, Vector3 inPt1)
		{
			float distanceToPoint = this.GetDistanceToPoint(inPt0);
			float distanceToPoint2 = this.GetDistanceToPoint(inPt1);
			return (distanceToPoint > 0f && distanceToPoint2 > 0f) || (distanceToPoint <= 0f && distanceToPoint2 <= 0f);
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x0000C450 File Offset: 0x0000A650
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Raycast(Ray ray, out float enter)
		{
			float num = Vector3.Dot(ray.direction, this.m_Normal);
			float num2 = -Vector3.Dot(ray.origin, this.m_Normal) - this.m_Distance;
			bool flag = Mathf.Approximately(num, 0f);
			bool result;
			if (flag)
			{
				enter = 0f;
				result = false;
			}
			else
			{
				enter = num2 / num;
				result = (enter > 0f);
			}
			return result;
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x0000C4BC File Offset: 0x0000A6BC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return this.ToString(null, null);
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x0000C4D8 File Offset: 0x0000A6D8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format)
		{
			return this.ToString(format, null);
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x0000C4F4 File Offset: 0x0000A6F4
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
			return UnityString.Format("(normal:{0}, distance:{1})", new object[]
			{
				this.m_Normal.ToString(format, formatProvider),
				this.m_Distance.ToString(format, formatProvider)
			});
		}

		// Token: 0x040003E6 RID: 998
		internal const int size = 16;

		// Token: 0x040003E7 RID: 999
		private Vector3 m_Normal;

		// Token: 0x040003E8 RID: 1000
		private float m_Distance;
	}
}
