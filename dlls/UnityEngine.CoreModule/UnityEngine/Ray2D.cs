using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace UnityEngine
{
	// Token: 0x02000130 RID: 304
	public struct Ray2D : IFormattable
	{
		// Token: 0x060007CE RID: 1998 RVA: 0x0000C68B File Offset: 0x0000A88B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Ray2D(Vector2 origin, Vector2 direction)
		{
			this.m_Origin = origin;
			this.m_Direction = direction.normalized;
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x060007CF RID: 1999 RVA: 0x0000C6A4 File Offset: 0x0000A8A4
		// (set) Token: 0x060007D0 RID: 2000 RVA: 0x0000C6BC File Offset: 0x0000A8BC
		public Vector2 origin
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.m_Origin;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.m_Origin = value;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x060007D1 RID: 2001 RVA: 0x0000C6C8 File Offset: 0x0000A8C8
		// (set) Token: 0x060007D2 RID: 2002 RVA: 0x0000C6E0 File Offset: 0x0000A8E0
		public Vector2 direction
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.m_Direction;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.m_Direction = value.normalized;
			}
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x0000C6F0 File Offset: 0x0000A8F0
		public Vector2 GetPoint(float distance)
		{
			return this.m_Origin + this.m_Direction * distance;
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x0000C71C File Offset: 0x0000A91C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return this.ToString(null, null);
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x0000C738 File Offset: 0x0000A938
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format)
		{
			return this.ToString(format, null);
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x0000C754 File Offset: 0x0000A954
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
			return UnityString.Format("Origin: {0}, Dir: {1}", new object[]
			{
				this.m_Origin.ToString(format, formatProvider),
				this.m_Direction.ToString(format, formatProvider)
			});
		}

		// Token: 0x040003EB RID: 1003
		private Vector2 m_Origin;

		// Token: 0x040003EC RID: 1004
		private Vector2 m_Direction;
	}
}
