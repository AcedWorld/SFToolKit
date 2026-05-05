using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x020001E9 RID: 489
	[UsedByNativeCode]
	[StructLayout(LayoutKind.Explicit)]
	public struct Color32 : IFormattable
	{
		// Token: 0x06001516 RID: 5398 RVA: 0x0001F672 File Offset: 0x0001D872
		public Color32(byte r, byte g, byte b, byte a)
		{
			this.rgba = 0;
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = a;
		}

		// Token: 0x06001517 RID: 5399 RVA: 0x0001F69C File Offset: 0x0001D89C
		public static implicit operator Color32(Color c)
		{
			return new Color32((byte)Mathf.Round(Mathf.Clamp01(c.r) * 255f), (byte)Mathf.Round(Mathf.Clamp01(c.g) * 255f), (byte)Mathf.Round(Mathf.Clamp01(c.b) * 255f), (byte)Mathf.Round(Mathf.Clamp01(c.a) * 255f));
		}

		// Token: 0x06001518 RID: 5400 RVA: 0x0001F710 File Offset: 0x0001D910
		public static implicit operator Color(Color32 c)
		{
			return new Color((float)c.r / 255f, (float)c.g / 255f, (float)c.b / 255f, (float)c.a / 255f);
		}

		// Token: 0x06001519 RID: 5401 RVA: 0x0001F75C File Offset: 0x0001D95C
		public static Color32 Lerp(Color32 a, Color32 b, float t)
		{
			t = Mathf.Clamp01(t);
			return new Color32((byte)((float)a.r + (float)(b.r - a.r) * t), (byte)((float)a.g + (float)(b.g - a.g) * t), (byte)((float)a.b + (float)(b.b - a.b) * t), (byte)((float)a.a + (float)(b.a - a.a) * t));
		}

		// Token: 0x0600151A RID: 5402 RVA: 0x0001F7E0 File Offset: 0x0001D9E0
		public static Color32 LerpUnclamped(Color32 a, Color32 b, float t)
		{
			return new Color32((byte)((float)a.r + (float)(b.r - a.r) * t), (byte)((float)a.g + (float)(b.g - a.g) * t), (byte)((float)a.b + (float)(b.b - a.b) * t), (byte)((float)a.a + (float)(b.a - a.a) * t));
		}

		// Token: 0x1700044C RID: 1100
		public byte this[int index]
		{
			get
			{
				byte result;
				switch (index)
				{
				case 0:
					result = this.r;
					break;
				case 1:
					result = this.g;
					break;
				case 2:
					result = this.b;
					break;
				case 3:
					result = this.a;
					break;
				default:
					throw new IndexOutOfRangeException("Invalid Color32 index(" + index.ToString() + ")!");
				}
				return result;
			}
			set
			{
				switch (index)
				{
				case 0:
					this.r = value;
					break;
				case 1:
					this.g = value;
					break;
				case 2:
					this.b = value;
					break;
				case 3:
					this.a = value;
					break;
				default:
					throw new IndexOutOfRangeException("Invalid Color32 index(" + index.ToString() + ")!");
				}
			}
		}

		// Token: 0x0600151D RID: 5405 RVA: 0x0001F934 File Offset: 0x0001DB34
		[VisibleToOtherModules]
		internal bool InternalEquals(Color32 other)
		{
			return this.rgba == other.rgba;
		}

		// Token: 0x0600151E RID: 5406 RVA: 0x0001F954 File Offset: 0x0001DB54
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return this.ToString(null, null);
		}

		// Token: 0x0600151F RID: 5407 RVA: 0x0001F970 File Offset: 0x0001DB70
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format)
		{
			return this.ToString(format, null);
		}

		// Token: 0x06001520 RID: 5408 RVA: 0x0001F98C File Offset: 0x0001DB8C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			bool flag = formatProvider == null;
			if (flag)
			{
				formatProvider = CultureInfo.InvariantCulture.NumberFormat;
			}
			return UnityString.Format("RGBA({0}, {1}, {2}, {3})", new object[]
			{
				this.r.ToString(format, formatProvider),
				this.g.ToString(format, formatProvider),
				this.b.ToString(format, formatProvider),
				this.a.ToString(format, formatProvider)
			});
		}

		// Token: 0x040007D6 RID: 2006
		[Ignore(DoesNotContributeToSize = true)]
		[FieldOffset(0)]
		private int rgba;

		// Token: 0x040007D7 RID: 2007
		[FieldOffset(0)]
		public byte r;

		// Token: 0x040007D8 RID: 2008
		[FieldOffset(1)]
		public byte g;

		// Token: 0x040007D9 RID: 2009
		[FieldOffset(2)]
		public byte b;

		// Token: 0x040007DA RID: 2010
		[FieldOffset(3)]
		public byte a;
	}
}
