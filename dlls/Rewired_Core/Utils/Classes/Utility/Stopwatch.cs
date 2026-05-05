using System;
using System.Diagnostics;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004DA RID: 1242
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class Stopwatch : StopwatchBase
	{
		// Token: 0x17000B48 RID: 2888
		// (get) Token: 0x060031D0 RID: 12752 RVA: 0x0002621E File Offset: 0x0002441E
		public static long frequency
		{
			get
			{
				return Stopwatch.XxPvKieKAGVhXvxhsGStbFsdDasz;
			}
		}

		// Token: 0x060031D1 RID: 12753 RVA: 0x00026225 File Offset: 0x00024425
		static Stopwatch()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Stopwatch.Global = stopwatch;
		}

		// Token: 0x060031D2 RID: 12754 RVA: 0x00026241 File Offset: 0x00024441
		public static Stopwatch StartNew()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			return stopwatch;
		}

		// Token: 0x060031D3 RID: 12755 RVA: 0x0002624E File Offset: 0x0002444E
		public static long ConvertTo100NSTicks(long ticks)
		{
			if (Stopwatch.XxPvKieKAGVhXvxhsGStbFsdDasz == 10000000L)
			{
				return ticks;
			}
			return 10000000L / Stopwatch.XxPvKieKAGVhXvxhsGStbFsdDasz;
		}

		// Token: 0x17000B49 RID: 2889
		// (get) Token: 0x060031D4 RID: 12756 RVA: 0x0002626B File Offset: 0x0002446B
		// (set) Token: 0x060031D5 RID: 12757 RVA: 0x0002627B File Offset: 0x0002447B
		public override double offsetSeconds
		{
			get
			{
				return (double)this.XZVFBHNeCDQXCUZGjlFgvikOykac / (double)Stopwatch.XxPvKieKAGVhXvxhsGStbFsdDasz;
			}
			set
			{
				this.XZVFBHNeCDQXCUZGjlFgvikOykac = (long)(value * (double)Stopwatch.XxPvKieKAGVhXvxhsGStbFsdDasz);
			}
		}

		// Token: 0x17000B4A RID: 2890
		// (get) Token: 0x060031D6 RID: 12758 RVA: 0x0002628C File Offset: 0x0002448C
		// (set) Token: 0x060031D7 RID: 12759 RVA: 0x00026294 File Offset: 0x00024494
		public override long offsetTicks
		{
			get
			{
				return this.XZVFBHNeCDQXCUZGjlFgvikOykac;
			}
			set
			{
				this.XZVFBHNeCDQXCUZGjlFgvikOykac = value;
			}
		}

		// Token: 0x17000B4B RID: 2891
		// (get) Token: 0x060031D8 RID: 12760 RVA: 0x0002629D File Offset: 0x0002449D
		public override double elapsedSeconds
		{
			get
			{
				return (double)(this.pgGgVYsxAvHivQXdxdmuBSzLpOhm.ElapsedTicks + this.offsetTicks) / (double)Stopwatch.XxPvKieKAGVhXvxhsGStbFsdDasz;
			}
		}

		// Token: 0x17000B4C RID: 2892
		// (get) Token: 0x060031D9 RID: 12761 RVA: 0x000262B9 File Offset: 0x000244B9
		public override double elapsedSecondsRaw
		{
			get
			{
				return (double)this.pgGgVYsxAvHivQXdxdmuBSzLpOhm.ElapsedTicks / (double)Stopwatch.XxPvKieKAGVhXvxhsGStbFsdDasz;
			}
		}

		// Token: 0x17000B4D RID: 2893
		// (get) Token: 0x060031DA RID: 12762 RVA: 0x000262CE File Offset: 0x000244CE
		public override long elapsedMilliseconds
		{
			get
			{
				return (long)((double)(this.pgGgVYsxAvHivQXdxdmuBSzLpOhm.ElapsedTicks + this.offsetTicks) / (double)Stopwatch.XxPvKieKAGVhXvxhsGStbFsdDasz * 1000.0);
			}
		}

		// Token: 0x17000B4E RID: 2894
		// (get) Token: 0x060031DB RID: 12763 RVA: 0x000262F5 File Offset: 0x000244F5
		public override long elapsedMillisecondsRaw
		{
			get
			{
				return this.pgGgVYsxAvHivQXdxdmuBSzLpOhm.ElapsedMilliseconds;
			}
		}

		// Token: 0x17000B4F RID: 2895
		// (get) Token: 0x060031DC RID: 12764 RVA: 0x00026302 File Offset: 0x00024502
		public override long elapsedTicks
		{
			get
			{
				return this.pgGgVYsxAvHivQXdxdmuBSzLpOhm.ElapsedTicks + this.XZVFBHNeCDQXCUZGjlFgvikOykac;
			}
		}

		// Token: 0x17000B50 RID: 2896
		// (get) Token: 0x060031DD RID: 12765 RVA: 0x00026316 File Offset: 0x00024516
		public override long elapsedTicksRaw
		{
			get
			{
				return this.pgGgVYsxAvHivQXdxdmuBSzLpOhm.ElapsedTicks;
			}
		}

		// Token: 0x17000B51 RID: 2897
		// (get) Token: 0x060031DE RID: 12766 RVA: 0x00026323 File Offset: 0x00024523
		public override bool isRunning
		{
			get
			{
				return this.pgGgVYsxAvHivQXdxdmuBSzLpOhm.IsRunning;
			}
		}

		// Token: 0x060031DF RID: 12767 RVA: 0x00026330 File Offset: 0x00024530
		public Stopwatch()
		{
			this.pgGgVYsxAvHivQXdxdmuBSzLpOhm = new Stopwatch();
		}

		// Token: 0x060031E0 RID: 12768 RVA: 0x00026343 File Offset: 0x00024543
		public override void Stop()
		{
			if (this == Stopwatch.Global)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			this.pgGgVYsxAvHivQXdxdmuBSzLpOhm.Stop();
		}

		// Token: 0x060031E1 RID: 12769 RVA: 0x00026363 File Offset: 0x00024563
		public override void Start()
		{
			if (this == Stopwatch.Global)
			{
				return;
			}
			this.pgGgVYsxAvHivQXdxdmuBSzLpOhm.Start();
		}

		// Token: 0x060031E2 RID: 12770 RVA: 0x00026379 File Offset: 0x00024579
		public override void Reset()
		{
			if (this == Stopwatch.Global)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			this.pgGgVYsxAvHivQXdxdmuBSzLpOhm.Reset();
		}

		// Token: 0x04001B4C RID: 6988
		private const long immaXlhzQJCGIjibtrhEPYxvDdjkA = 10000000L;

		// Token: 0x04001B4D RID: 6989
		public static readonly Stopwatch Global;

		// Token: 0x04001B4E RID: 6990
		private static long XxPvKieKAGVhXvxhsGStbFsdDasz = Stopwatch.Frequency;

		// Token: 0x04001B4F RID: 6991
		private Stopwatch pgGgVYsxAvHivQXdxdmuBSzLpOhm;

		// Token: 0x04001B50 RID: 6992
		private long XZVFBHNeCDQXCUZGjlFgvikOykac;
	}
}
