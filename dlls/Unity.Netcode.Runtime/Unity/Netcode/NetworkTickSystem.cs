using System;

namespace Unity.Netcode
{
	// Token: 0x0200011C RID: 284
	public class NetworkTickSystem
	{
		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060008EB RID: 2283 RVA: 0x0002260E File Offset: 0x0002080E
		// (set) Token: 0x060008EC RID: 2284 RVA: 0x00022616 File Offset: 0x00020816
		public uint TickRate { get; internal set; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060008ED RID: 2285 RVA: 0x0002261F File Offset: 0x0002081F
		// (set) Token: 0x060008EE RID: 2286 RVA: 0x00022627 File Offset: 0x00020827
		public NetworkTime LocalTime { get; internal set; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060008EF RID: 2287 RVA: 0x00022630 File Offset: 0x00020830
		// (set) Token: 0x060008F0 RID: 2288 RVA: 0x00022638 File Offset: 0x00020838
		public NetworkTime ServerTime { get; internal set; }

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x060008F1 RID: 2289 RVA: 0x00022644 File Offset: 0x00020844
		// (remove) Token: 0x060008F2 RID: 2290 RVA: 0x0002267C File Offset: 0x0002087C
		public event Action Tick;

		// Token: 0x060008F3 RID: 2291 RVA: 0x000226B4 File Offset: 0x000208B4
		public NetworkTickSystem(uint tickRate, double localTimeSec, double serverTimeSec)
		{
			if (tickRate == 0U)
			{
				throw new ArgumentException("Tick rate must be a positive value.", "tickRate");
			}
			this.TickRate = tickRate;
			this.Tick = null;
			this.LocalTime = new NetworkTime(tickRate, localTimeSec);
			this.ServerTime = new NetworkTime(tickRate, serverTimeSec);
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x00022702 File Offset: 0x00020902
		public void Reset(double localTimeSec, double serverTimeSec)
		{
			this.LocalTime = new NetworkTime(this.TickRate, localTimeSec);
			this.ServerTime = new NetworkTime(this.TickRate, serverTimeSec);
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x00022728 File Offset: 0x00020928
		public void UpdateTick(double localTimeSec, double serverTimeSec)
		{
			int tick = this.LocalTime.Tick;
			this.LocalTime = new NetworkTime(this.TickRate, localTimeSec);
			this.ServerTime = new NetworkTime(this.TickRate, serverTimeSec);
			NetworkTime localTime = this.LocalTime;
			NetworkTime serverTime = this.ServerTime;
			int tick2 = this.LocalTime.Tick;
			int num = tick2 - this.ServerTime.Tick;
			for (int i = tick + 1; i <= tick2; i++)
			{
				this.LocalTime = new NetworkTime(this.TickRate, i, 0.0);
				this.ServerTime = new NetworkTime(this.TickRate, i - num, 0.0);
				Action tick3 = this.Tick;
				if (tick3 != null)
				{
					tick3();
				}
			}
			this.LocalTime = localTime;
			this.ServerTime = serverTime;
		}

		// Token: 0x04000355 RID: 853
		public const int NoTick = -2147483648;
	}
}
