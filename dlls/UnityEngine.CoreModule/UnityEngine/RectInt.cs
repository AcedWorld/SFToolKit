using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000132 RID: 306
	[UsedByNativeCode]
	public struct RectInt : IEquatable<RectInt>, IFormattable
	{
		// Token: 0x170001BA RID: 442
		// (get) Token: 0x0600080B RID: 2059 RVA: 0x0000D138 File Offset: 0x0000B338
		// (set) Token: 0x0600080C RID: 2060 RVA: 0x0000D150 File Offset: 0x0000B350
		public int x
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

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x0600080D RID: 2061 RVA: 0x0000D15C File Offset: 0x0000B35C
		// (set) Token: 0x0600080E RID: 2062 RVA: 0x0000D174 File Offset: 0x0000B374
		public int y
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

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x0600080F RID: 2063 RVA: 0x0000D180 File Offset: 0x0000B380
		public Vector2 center
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new Vector2((float)this.x + (float)this.m_Width / 2f, (float)this.y + (float)this.m_Height / 2f);
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000810 RID: 2064 RVA: 0x0000D1C4 File Offset: 0x0000B3C4
		// (set) Token: 0x06000811 RID: 2065 RVA: 0x0000D1E7 File Offset: 0x0000B3E7
		public Vector2Int min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new Vector2Int(this.xMin, this.yMin);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.xMin = value.x;
				this.yMin = value.y;
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000812 RID: 2066 RVA: 0x0000D208 File Offset: 0x0000B408
		// (set) Token: 0x06000813 RID: 2067 RVA: 0x0000D22B File Offset: 0x0000B42B
		public Vector2Int max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new Vector2Int(this.xMax, this.yMax);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.xMax = value.x;
				this.yMax = value.y;
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000814 RID: 2068 RVA: 0x0000D24C File Offset: 0x0000B44C
		// (set) Token: 0x06000815 RID: 2069 RVA: 0x0000D264 File Offset: 0x0000B464
		public int width
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

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06000816 RID: 2070 RVA: 0x0000D270 File Offset: 0x0000B470
		// (set) Token: 0x06000817 RID: 2071 RVA: 0x0000D288 File Offset: 0x0000B488
		public int height
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

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000818 RID: 2072 RVA: 0x0000D294 File Offset: 0x0000B494
		// (set) Token: 0x06000819 RID: 2073 RVA: 0x0000D2C0 File Offset: 0x0000B4C0
		public int xMin
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Math.Min(this.m_XMin, this.m_XMin + this.m_Width);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				int xMax = this.xMax;
				this.m_XMin = value;
				this.m_Width = xMax - this.m_XMin;
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x0600081A RID: 2074 RVA: 0x0000D2EC File Offset: 0x0000B4EC
		// (set) Token: 0x0600081B RID: 2075 RVA: 0x0000D318 File Offset: 0x0000B518
		public int yMin
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Math.Min(this.m_YMin, this.m_YMin + this.m_Height);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				int yMax = this.yMax;
				this.m_YMin = value;
				this.m_Height = yMax - this.m_YMin;
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x0600081C RID: 2076 RVA: 0x0000D344 File Offset: 0x0000B544
		// (set) Token: 0x0600081D RID: 2077 RVA: 0x0000D36E File Offset: 0x0000B56E
		public int xMax
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Math.Max(this.m_XMin, this.m_XMin + this.m_Width);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.m_Width = value - this.m_XMin;
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x0600081E RID: 2078 RVA: 0x0000D380 File Offset: 0x0000B580
		// (set) Token: 0x0600081F RID: 2079 RVA: 0x0000D3AA File Offset: 0x0000B5AA
		public int yMax
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Math.Max(this.m_YMin, this.m_YMin + this.m_Height);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.m_Height = value - this.m_YMin;
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000820 RID: 2080 RVA: 0x0000D3BC File Offset: 0x0000B5BC
		// (set) Token: 0x06000821 RID: 2081 RVA: 0x0000D3DF File Offset: 0x0000B5DF
		public Vector2Int position
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new Vector2Int(this.m_XMin, this.m_YMin);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.m_XMin = value.x;
				this.m_YMin = value.y;
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000822 RID: 2082 RVA: 0x0000D3FC File Offset: 0x0000B5FC
		// (set) Token: 0x06000823 RID: 2083 RVA: 0x0000D41F File Offset: 0x0000B61F
		public Vector2Int size
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new Vector2Int(this.m_Width, this.m_Height);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.m_Width = value.x;
				this.m_Height = value.y;
			}
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x0000D43C File Offset: 0x0000B63C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetMinMax(Vector2Int minPosition, Vector2Int maxPosition)
		{
			this.min = minPosition;
			this.max = maxPosition;
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x0000D44F File Offset: 0x0000B64F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public RectInt(int xMin, int yMin, int width, int height)
		{
			this.m_XMin = xMin;
			this.m_YMin = yMin;
			this.m_Width = width;
			this.m_Height = height;
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x0000D46F File Offset: 0x0000B66F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public RectInt(Vector2Int position, Vector2Int size)
		{
			this.m_XMin = position.x;
			this.m_YMin = position.y;
			this.m_Width = size.x;
			this.m_Height = size.y;
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x0000D4A8 File Offset: 0x0000B6A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ClampToBounds(RectInt bounds)
		{
			this.position = new Vector2Int(Math.Max(Math.Min(bounds.xMax, this.position.x), bounds.xMin), Math.Max(Math.Min(bounds.yMax, this.position.y), bounds.yMin));
			this.size = new Vector2Int(Math.Min(bounds.xMax - this.position.x, this.size.x), Math.Min(bounds.yMax - this.position.y, this.size.y));
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x0000D56C File Offset: 0x0000B76C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(Vector2Int position)
		{
			return position.x >= this.xMin && position.y >= this.yMin && position.x < this.xMax && position.y < this.yMax;
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x0000D5C0 File Offset: 0x0000B7C0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Overlaps(RectInt other)
		{
			return other.xMin < this.xMax && other.xMax > this.xMin && other.yMin < this.yMax && other.yMax > this.yMin;
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x0000D614 File Offset: 0x0000B814
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return this.ToString(null, null);
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x0000D630 File Offset: 0x0000B830
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format)
		{
			return this.ToString(format, null);
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x0000D64C File Offset: 0x0000B84C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			bool flag = formatProvider == null;
			if (flag)
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

		// Token: 0x0600082D RID: 2093 RVA: 0x0000D6D0 File Offset: 0x0000B8D0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(RectInt other)
		{
			return this.m_XMin == other.m_XMin && this.m_YMin == other.m_YMin && this.m_Width == other.m_Width && this.m_Height == other.m_Height;
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x0600082E RID: 2094 RVA: 0x0000D720 File Offset: 0x0000B920
		public RectInt.PositionEnumerator allPositionsWithin
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new RectInt.PositionEnumerator(this.min, this.max);
			}
		}

		// Token: 0x040003F1 RID: 1009
		private int m_XMin;

		// Token: 0x040003F2 RID: 1010
		private int m_YMin;

		// Token: 0x040003F3 RID: 1011
		private int m_Width;

		// Token: 0x040003F4 RID: 1012
		private int m_Height;

		// Token: 0x02000133 RID: 307
		public struct PositionEnumerator : IEnumerator<Vector2Int>, IEnumerator, IDisposable
		{
			// Token: 0x0600082F RID: 2095 RVA: 0x0000D744 File Offset: 0x0000B944
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public PositionEnumerator(Vector2Int min, Vector2Int max)
			{
				this._current = min;
				this._min = min;
				this._max = max;
				this.Reset();
			}

			// Token: 0x06000830 RID: 2096 RVA: 0x0000D770 File Offset: 0x0000B970
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public RectInt.PositionEnumerator GetEnumerator()
			{
				return this;
			}

			// Token: 0x06000831 RID: 2097 RVA: 0x0000D788 File Offset: 0x0000B988
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				bool flag = this._current.y >= this._max.y;
				bool result;
				if (flag)
				{
					result = false;
				}
				else
				{
					int num = this._current.x;
					this._current.x = num + 1;
					bool flag2 = this._current.x >= this._max.x;
					if (flag2)
					{
						this._current.x = this._min.x;
						bool flag3 = this._current.x >= this._max.x;
						if (flag3)
						{
							return false;
						}
						num = this._current.y;
						this._current.y = num + 1;
						bool flag4 = this._current.y >= this._max.y;
						if (flag4)
						{
							return false;
						}
					}
					result = true;
				}
				return result;
			}

			// Token: 0x06000832 RID: 2098 RVA: 0x0000D884 File Offset: 0x0000BA84
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Reset()
			{
				this._current = this._min;
				int x = this._current.x;
				this._current.x = x - 1;
			}

			// Token: 0x170001C8 RID: 456
			// (get) Token: 0x06000833 RID: 2099 RVA: 0x0000D8B4 File Offset: 0x0000BAB4
			public Vector2Int Current
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					return this._current;
				}
			}

			// Token: 0x170001C9 RID: 457
			// (get) Token: 0x06000834 RID: 2100 RVA: 0x0000D8CC File Offset: 0x0000BACC
			object IEnumerator.Current
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					return this.Current;
				}
			}

			// Token: 0x06000835 RID: 2101 RVA: 0x00002669 File Offset: 0x00000869
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			void IDisposable.Dispose()
			{
			}

			// Token: 0x040003F5 RID: 1013
			private readonly Vector2Int _min;

			// Token: 0x040003F6 RID: 1014
			private readonly Vector2Int _max;

			// Token: 0x040003F7 RID: 1015
			private Vector2Int _current;
		}
	}
}
