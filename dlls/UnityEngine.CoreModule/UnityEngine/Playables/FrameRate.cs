using System;
using System.Globalization;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Playables
{
	// Token: 0x02000491 RID: 1169
	[UsedByNativeCode("FrameRate")]
	[NativeHeader("Runtime/Director/Core/FrameRate.h")]
	internal struct FrameRate : IEquatable<FrameRate>
	{
		// Token: 0x17000793 RID: 1939
		// (get) Token: 0x06002848 RID: 10312 RVA: 0x0004511F File Offset: 0x0004331F
		public bool dropFrame
		{
			get
			{
				return this.m_Rate < 0;
			}
		}

		// Token: 0x17000794 RID: 1940
		// (get) Token: 0x06002849 RID: 10313 RVA: 0x0004512A File Offset: 0x0004332A
		public double rate
		{
			get
			{
				return this.dropFrame ? ((double)(-(double)this.m_Rate) * 0.999000999000999) : ((double)this.m_Rate);
			}
		}

		// Token: 0x0600284A RID: 10314 RVA: 0x0004514F File Offset: 0x0004334F
		public FrameRate(uint frameRate = 0U, bool drop = false)
		{
			this.m_Rate = (int)((drop ? uint.MaxValue : 1U) * frameRate);
		}

		// Token: 0x0600284B RID: 10315 RVA: 0x00045164 File Offset: 0x00043364
		public bool IsValid()
		{
			return this.m_Rate != 0;
		}

		// Token: 0x0600284C RID: 10316 RVA: 0x00045180 File Offset: 0x00043380
		public bool Equals(FrameRate other)
		{
			return this.m_Rate == other.m_Rate;
		}

		// Token: 0x0600284D RID: 10317 RVA: 0x000451A0 File Offset: 0x000433A0
		public override bool Equals(object obj)
		{
			return obj is FrameRate && this.Equals((FrameRate)obj);
		}

		// Token: 0x0600284E RID: 10318 RVA: 0x000451C9 File Offset: 0x000433C9
		public static bool operator ==(FrameRate a, FrameRate b)
		{
			return a.Equals(b);
		}

		// Token: 0x0600284F RID: 10319 RVA: 0x000451D3 File Offset: 0x000433D3
		public static bool operator !=(FrameRate a, FrameRate b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06002850 RID: 10320 RVA: 0x000451E0 File Offset: 0x000433E0
		public static bool operator <(FrameRate a, FrameRate b)
		{
			return a.rate < b.rate;
		}

		// Token: 0x06002851 RID: 10321 RVA: 0x000451F2 File Offset: 0x000433F2
		public static bool operator <=(FrameRate a, FrameRate b)
		{
			return a.rate <= b.rate;
		}

		// Token: 0x06002852 RID: 10322 RVA: 0x00045207 File Offset: 0x00043407
		public static bool operator >(FrameRate a, FrameRate b)
		{
			return a.rate > b.rate;
		}

		// Token: 0x06002853 RID: 10323 RVA: 0x000451F2 File Offset: 0x000433F2
		public static bool operator >=(FrameRate a, FrameRate b)
		{
			return a.rate <= b.rate;
		}

		// Token: 0x06002854 RID: 10324 RVA: 0x0004521C File Offset: 0x0004341C
		public override int GetHashCode()
		{
			return this.m_Rate;
		}

		// Token: 0x06002855 RID: 10325 RVA: 0x00045234 File Offset: 0x00043434
		public override string ToString()
		{
			return this.ToString(null, null);
		}

		// Token: 0x06002856 RID: 10326 RVA: 0x00045250 File Offset: 0x00043450
		public string ToString(string format)
		{
			return this.ToString(format, null);
		}

		// Token: 0x06002857 RID: 10327 RVA: 0x0004526C File Offset: 0x0004346C
		public string ToString(string format, IFormatProvider formatProvider)
		{
			bool flag = string.IsNullOrEmpty(format);
			if (flag)
			{
				format = (this.dropFrame ? "F2" : "F0");
			}
			bool flag2 = formatProvider == null;
			if (flag2)
			{
				formatProvider = CultureInfo.InvariantCulture.NumberFormat;
			}
			return UnityString.Format("{0} Fps", new object[]
			{
				this.rate.ToString(format, formatProvider)
			});
		}

		// Token: 0x06002858 RID: 10328 RVA: 0x000452D8 File Offset: 0x000434D8
		internal static int FrameRateToInt(FrameRate framerate)
		{
			return framerate.m_Rate;
		}

		// Token: 0x06002859 RID: 10329 RVA: 0x000452F0 File Offset: 0x000434F0
		internal static FrameRate DoubleToFrameRate(double framerate)
		{
			uint num = (uint)Math.Ceiling(framerate);
			bool flag = num <= 0U;
			FrameRate result;
			if (flag)
			{
				result = new FrameRate(1U, false);
			}
			else
			{
				FrameRate frameRate = new FrameRate(num, true);
				bool flag2 = Math.Abs(framerate - frameRate.rate) < Math.Abs(framerate - num);
				if (flag2)
				{
					result = frameRate;
				}
				else
				{
					result = new FrameRate(num, false);
				}
			}
			return result;
		}

		// Token: 0x04000F51 RID: 3921
		[Ignore]
		public static readonly FrameRate k_24Fps = new FrameRate(24U, false);

		// Token: 0x04000F52 RID: 3922
		[Ignore]
		public static readonly FrameRate k_23_976Fps = new FrameRate(24U, true);

		// Token: 0x04000F53 RID: 3923
		[Ignore]
		public static readonly FrameRate k_25Fps = new FrameRate(25U, false);

		// Token: 0x04000F54 RID: 3924
		[Ignore]
		public static readonly FrameRate k_30Fps = new FrameRate(30U, false);

		// Token: 0x04000F55 RID: 3925
		[Ignore]
		public static readonly FrameRate k_29_97Fps = new FrameRate(30U, true);

		// Token: 0x04000F56 RID: 3926
		[Ignore]
		public static readonly FrameRate k_50Fps = new FrameRate(50U, false);

		// Token: 0x04000F57 RID: 3927
		[Ignore]
		public static readonly FrameRate k_60Fps = new FrameRate(60U, false);

		// Token: 0x04000F58 RID: 3928
		[Ignore]
		public static readonly FrameRate k_59_94Fps = new FrameRate(60U, true);

		// Token: 0x04000F59 RID: 3929
		[SerializeField]
		private int m_Rate;
	}
}
