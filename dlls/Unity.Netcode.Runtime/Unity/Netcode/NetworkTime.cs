using System;

namespace Unity.Netcode
{
	// Token: 0x0200011D RID: 285
	public struct NetworkTime
	{
		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060008F6 RID: 2294 RVA: 0x00022802 File Offset: 0x00020A02
		public double TickOffset
		{
			get
			{
				return this.m_CachedTickOffset;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060008F7 RID: 2295 RVA: 0x0002280A File Offset: 0x00020A0A
		public double TickWithPartial
		{
			get
			{
				return (double)this.Tick + this.TickOffset / this.m_TickInterval;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060008F8 RID: 2296 RVA: 0x00022821 File Offset: 0x00020A21
		public double Time
		{
			get
			{
				return this.m_TimeSec;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060008F9 RID: 2297 RVA: 0x00022829 File Offset: 0x00020A29
		public float TimeAsFloat
		{
			get
			{
				return (float)this.m_TimeSec;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060008FA RID: 2298 RVA: 0x00022832 File Offset: 0x00020A32
		public double FixedTime
		{
			get
			{
				return (double)this.m_CachedTick * this.m_TickInterval;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060008FB RID: 2299 RVA: 0x00022842 File Offset: 0x00020A42
		public float FixedDeltaTime
		{
			get
			{
				return (float)this.m_TickInterval;
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060008FC RID: 2300 RVA: 0x0002284B File Offset: 0x00020A4B
		public int Tick
		{
			get
			{
				return this.m_CachedTick;
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060008FD RID: 2301 RVA: 0x00022853 File Offset: 0x00020A53
		public uint TickRate
		{
			get
			{
				return this.m_TickRate;
			}
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x0002285C File Offset: 0x00020A5C
		public NetworkTime(uint tickRate)
		{
			this.m_TickRate = tickRate;
			this.m_TickInterval = (double)(1f / this.m_TickRate);
			this.m_CachedTickOffset = 0.0;
			this.m_CachedTick = 0;
			this.m_TimeSec = 0.0;
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x000228AA File Offset: 0x00020AAA
		public NetworkTime(uint tickRate, int tick, double tickOffset = 0.0)
		{
			this = new NetworkTime(tickRate);
			this.m_CachedTickOffset = tickOffset;
			this.m_CachedTick = tick;
			this.m_TimeSec = (double)tick * this.m_TickInterval + tickOffset;
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x000228D2 File Offset: 0x00020AD2
		public NetworkTime(uint tickRate, double timeSec)
		{
			this = new NetworkTime(tickRate);
			this += timeSec;
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x000228ED File Offset: 0x00020AED
		public NetworkTime ToFixedTime()
		{
			return new NetworkTime(this.m_TickRate, this.m_CachedTick, 0.0);
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x00022909 File Offset: 0x00020B09
		public NetworkTime TimeTicksAgo(int ticks)
		{
			return this - new NetworkTime(this.TickRate, ticks, 0.0);
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x0002292C File Offset: 0x00020B2C
		private void UpdateCache()
		{
			double num = this.m_TimeSec / this.m_TickInterval;
			this.m_CachedTick = (int)num;
			if (num - (double)this.m_CachedTick >= 0.999999999999)
			{
				this.m_CachedTick++;
			}
			this.m_CachedTickOffset = (num - Math.Truncate(num)) * this.m_TickInterval;
			if (this.m_CachedTick < 0 && this.m_CachedTickOffset != 0.0)
			{
				this.m_CachedTick--;
				this.m_CachedTickOffset = this.m_TickInterval + this.m_CachedTickOffset;
			}
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x000229C1 File Offset: 0x00020BC1
		public static NetworkTime operator -(NetworkTime a, NetworkTime b)
		{
			return new NetworkTime(a.TickRate, a.Time - b.Time);
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x000229DE File Offset: 0x00020BDE
		public static NetworkTime operator +(NetworkTime a, NetworkTime b)
		{
			return new NetworkTime(a.TickRate, a.Time + b.Time);
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x000229FB File Offset: 0x00020BFB
		public static NetworkTime operator +(NetworkTime a, double b)
		{
			a.m_TimeSec += b;
			a.UpdateCache();
			return a;
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x00022A11 File Offset: 0x00020C11
		public static NetworkTime operator -(NetworkTime a, double b)
		{
			return a + -b;
		}

		// Token: 0x0400035A RID: 858
		private double m_TimeSec;

		// Token: 0x0400035B RID: 859
		private uint m_TickRate;

		// Token: 0x0400035C RID: 860
		private double m_TickInterval;

		// Token: 0x0400035D RID: 861
		private int m_CachedTick;

		// Token: 0x0400035E RID: 862
		private double m_CachedTickOffset;
	}
}
