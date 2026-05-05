using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000131 RID: 305
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	[NativeClass("Rectf", "template<typename T> class RectT; typedef RectT<float> Rectf;")]
	[NativeHeader("Runtime/Math/Rect.h")]
	public struct Rect : IEquatable<Rect>, IFormattable
	{
		// Token: 0x060007D7 RID: 2007 RVA: 0x0000C7BB File Offset: 0x0000A9BB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Rect(float x, float y, float width, float height)
		{
			this.m_XMin = x;
			this.m_YMin = y;
			this.m_Width = width;
			this.m_Height = height;
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x0000C7DB File Offset: 0x0000A9DB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Rect(Vector2 position, Vector2 size)
		{
			this.m_XMin = position.x;
			this.m_YMin = position.y;
			this.m_Width = size.x;
			this.m_Height = size.y;
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x0000C80E File Offset: 0x0000AA0E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Rect(Rect source)
		{
			this.m_XMin = source.m_XMin;
			this.m_YMin = source.m_YMin;
			this.m_Width = source.m_Width;
			this.m_Height = source.m_Height;
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x060007DA RID: 2010 RVA: 0x0000C841 File Offset: 0x0000AA41
		public static Rect zero
		{
			get
			{
				return new Rect(0f, 0f, 0f, 0f);
			}
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x0000C85C File Offset: 0x0000AA5C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Rect MinMaxRect(float xmin, float ymin, float xmax, float ymax)
		{
			return new Rect(xmin, ymin, xmax - xmin, ymax - ymin);
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x0000C7BB File Offset: 0x0000A9BB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(float x, float y, float width, float height)
		{
			this.m_XMin = x;
			this.m_YMin = y;
			this.m_Width = width;
			this.m_Height = height;
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x060007DD RID: 2013 RVA: 0x0000C87C File Offset: 0x0000AA7C
		// (set) Token: 0x060007DE RID: 2014 RVA: 0x0000C894 File Offset: 0x0000AA94
		public float x
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.m_XMin;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.m_XMin = value;
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x060007DF RID: 2015 RVA: 0x0000C8A0 File Offset: 0x0000AAA0
		// (set) Token: 0x060007E0 RID: 2016 RVA: 0x0000C8B8 File Offset: 0x0000AAB8
		public float y
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.m_YMin;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.m_YMin = value;
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x060007E1 RID: 2017 RVA: 0x0000C8C4 File Offset: 0x0000AAC4
		// (set) Token: 0x060007E2 RID: 2018 RVA: 0x0000C8E7 File Offset: 0x0000AAE7
		public Vector2 position
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new Vector2(this.m_XMin, this.m_YMin);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.m_XMin = value.x;
				this.m_YMin = value.y;
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x060007E3 RID: 2019 RVA: 0x0000C904 File Offset: 0x0000AB04
		// (set) Token: 0x060007E4 RID: 2020 RVA: 0x0000C941 File Offset: 0x0000AB41
		public Vector2 center
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new Vector2(this.x + this.m_Width / 2f, this.y + this.m_Height / 2f);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.m_XMin = value.x - this.m_Width / 2f;
				this.m_YMin = value.y - this.m_Height / 2f;
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x060007E5 RID: 2021 RVA: 0x0000C978 File Offset: 0x0000AB78
		// (set) Token: 0x060007E6 RID: 2022 RVA: 0x0000C99B File Offset: 0x0000AB9B
		public Vector2 min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new Vector2(this.xMin, this.yMin);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.xMin = value.x;
				this.yMin = value.y;
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x060007E7 RID: 2023 RVA: 0x0000C9B8 File Offset: 0x0000ABB8
		// (set) Token: 0x060007E8 RID: 2024 RVA: 0x0000C9DB File Offset: 0x0000ABDB
		public Vector2 max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new Vector2(this.xMax, this.yMax);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.xMax = value.x;
				this.yMax = value.y;
			}
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x060007E9 RID: 2025 RVA: 0x0000C9F8 File Offset: 0x0000ABF8
		// (set) Token: 0x060007EA RID: 2026 RVA: 0x0000CA10 File Offset: 0x0000AC10
		public float width
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.m_Width;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.m_Width = value;
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x060007EB RID: 2027 RVA: 0x0000CA1C File Offset: 0x0000AC1C
		// (set) Token: 0x060007EC RID: 2028 RVA: 0x0000CA34 File Offset: 0x0000AC34
		public float height
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.m_Height;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.m_Height = value;
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x060007ED RID: 2029 RVA: 0x0000CA40 File Offset: 0x0000AC40
		// (set) Token: 0x060007EE RID: 2030 RVA: 0x0000CA63 File Offset: 0x0000AC63
		public Vector2 size
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new Vector2(this.m_Width, this.m_Height);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.m_Width = value.x;
				this.m_Height = value.y;
			}
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x060007EF RID: 2031 RVA: 0x0000CA80 File Offset: 0x0000AC80
		// (set) Token: 0x060007F0 RID: 2032 RVA: 0x0000CA98 File Offset: 0x0000AC98
		public float xMin
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.m_XMin;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				float xMax = this.xMax;
				this.m_XMin = value;
				this.m_Width = xMax - this.m_XMin;
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x060007F1 RID: 2033 RVA: 0x0000CAC4 File Offset: 0x0000ACC4
		// (set) Token: 0x060007F2 RID: 2034 RVA: 0x0000CADC File Offset: 0x0000ACDC
		public float yMin
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.m_YMin;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				float yMax = this.yMax;
				this.m_YMin = value;
				this.m_Height = yMax - this.m_YMin;
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x060007F3 RID: 2035 RVA: 0x0000CB08 File Offset: 0x0000AD08
		// (set) Token: 0x060007F4 RID: 2036 RVA: 0x0000CB27 File Offset: 0x0000AD27
		public float xMax
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.m_Width + this.m_XMin;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.m_Width = value - this.m_XMin;
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x060007F5 RID: 2037 RVA: 0x0000CB38 File Offset: 0x0000AD38
		// (set) Token: 0x060007F6 RID: 2038 RVA: 0x0000CB57 File Offset: 0x0000AD57
		public float yMax
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.m_Height + this.m_YMin;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.m_Height = value - this.m_YMin;
			}
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x0000CB68 File Offset: 0x0000AD68
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(Vector2 point)
		{
			return point.x >= this.xMin && point.x < this.xMax && point.y >= this.yMin && point.y < this.yMax;
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x0000CBB8 File Offset: 0x0000ADB8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(Vector3 point)
		{
			return point.x >= this.xMin && point.x < this.xMax && point.y >= this.yMin && point.y < this.yMax;
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x0000CC08 File Offset: 0x0000AE08
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(Vector3 point, bool allowInverse)
		{
			bool flag = !allowInverse;
			bool result;
			if (flag)
			{
				result = this.Contains(point);
			}
			else
			{
				bool flag2 = (this.width < 0f && point.x <= this.xMin && point.x > this.xMax) || (this.width >= 0f && point.x >= this.xMin && point.x < this.xMax);
				bool flag3 = (this.height < 0f && point.y <= this.yMin && point.y > this.yMax) || (this.height >= 0f && point.y >= this.yMin && point.y < this.yMax);
				result = (flag2 && flag3);
			}
			return result;
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x0000CCE8 File Offset: 0x0000AEE8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Rect OrderMinMax(Rect rect)
		{
			bool flag = rect.xMin > rect.xMax;
			if (flag)
			{
				float xMin = rect.xMin;
				rect.xMin = rect.xMax;
				rect.xMax = xMin;
			}
			bool flag2 = rect.yMin > rect.yMax;
			if (flag2)
			{
				float yMin = rect.yMin;
				rect.yMin = rect.yMax;
				rect.yMax = yMin;
			}
			return rect;
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x0000CD6C File Offset: 0x0000AF6C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Overlaps(Rect other)
		{
			return other.xMax > this.xMin && other.xMin < this.xMax && other.yMax > this.yMin && other.yMin < this.yMax;
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x0000CDC0 File Offset: 0x0000AFC0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Overlaps(Rect other, bool allowInverse)
		{
			Rect rect = this;
			if (allowInverse)
			{
				rect = Rect.OrderMinMax(rect);
				other = Rect.OrderMinMax(other);
			}
			return rect.Overlaps(other);
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x0000CDF8 File Offset: 0x0000AFF8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 NormalizedToPoint(Rect rectangle, Vector2 normalizedRectCoordinates)
		{
			return new Vector2(Mathf.Lerp(rectangle.x, rectangle.xMax, normalizedRectCoordinates.x), Mathf.Lerp(rectangle.y, rectangle.yMax, normalizedRectCoordinates.y));
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x0000CE44 File Offset: 0x0000B044
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 PointToNormalized(Rect rectangle, Vector2 point)
		{
			return new Vector2(Mathf.InverseLerp(rectangle.x, rectangle.xMax, point.x), Mathf.InverseLerp(rectangle.y, rectangle.yMax, point.y));
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x0000CE90 File Offset: 0x0000B090
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Rect lhs, Rect rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x0000CEAC File Offset: 0x0000B0AC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Rect lhs, Rect rhs)
		{
			return lhs.x == rhs.x && lhs.y == rhs.y && lhs.width == rhs.width && lhs.height == rhs.height;
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x0000CF04 File Offset: 0x0000B104
		public override int GetHashCode()
		{
			return this.x.GetHashCode() ^ this.width.GetHashCode() << 2 ^ this.y.GetHashCode() >> 2 ^ this.height.GetHashCode() >> 1;
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x0000CF58 File Offset: 0x0000B158
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override bool Equals(object other)
		{
			bool flag = !(other is Rect);
			return !flag && this.Equals((Rect)other);
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x0000CF8C File Offset: 0x0000B18C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Rect other)
		{
			return this.x.Equals(other.x) && this.y.Equals(other.y) && this.width.Equals(other.width) && this.height.Equals(other.height);
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x0000CFFC File Offset: 0x0000B1FC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return this.ToString(null, null);
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x0000D018 File Offset: 0x0000B218
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format)
		{
			return this.ToString(format, null);
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x0000D034 File Offset: 0x0000B234
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
			return UnityString.Format("(x:{0}, y:{1}, width:{2}, height:{3})", new object[]
			{
				this.x.ToString(format, formatProvider),
				this.y.ToString(format, formatProvider),
				this.width.ToString(format, formatProvider),
				this.height.ToString(format, formatProvider)
			});
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06000807 RID: 2055 RVA: 0x0000D0C8 File Offset: 0x0000B2C8
		[Obsolete("use xMin")]
		public float left
		{
			get
			{
				return this.m_XMin;
			}
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000808 RID: 2056 RVA: 0x0000D0E0 File Offset: 0x0000B2E0
		[Obsolete("use xMax")]
		public float right
		{
			get
			{
				return this.m_XMin + this.m_Width;
			}
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000809 RID: 2057 RVA: 0x0000D100 File Offset: 0x0000B300
		[Obsolete("use yMin")]
		public float top
		{
			get
			{
				return this.m_YMin;
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x0600080A RID: 2058 RVA: 0x0000D118 File Offset: 0x0000B318
		[Obsolete("use yMax")]
		public float bottom
		{
			get
			{
				return this.m_YMin + this.m_Height;
			}
		}

		// Token: 0x040003ED RID: 1005
		[NativeName("x")]
		private float m_XMin;

		// Token: 0x040003EE RID: 1006
		[NativeName("y")]
		private float m_YMin;

		// Token: 0x040003EF RID: 1007
		[NativeName("width")]
		private float m_Width;

		// Token: 0x040003F0 RID: 1008
		[NativeName("height")]
		private float m_Height;
	}
}
