using System;
using System.Collections.Generic;

namespace Unity.Netcode
{
	// Token: 0x0200011E RID: 286
	public class NetworkTimeSystem
	{
		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000908 RID: 2312 RVA: 0x00022A1B File Offset: 0x00020C1B
		// (set) Token: 0x06000909 RID: 2313 RVA: 0x00022A23 File Offset: 0x00020C23
		public double LocalBufferSec { get; set; }

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x0600090A RID: 2314 RVA: 0x00022A2C File Offset: 0x00020C2C
		// (set) Token: 0x0600090B RID: 2315 RVA: 0x00022A34 File Offset: 0x00020C34
		public double ServerBufferSec { get; set; }

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x0600090C RID: 2316 RVA: 0x00022A3D File Offset: 0x00020C3D
		// (set) Token: 0x0600090D RID: 2317 RVA: 0x00022A45 File Offset: 0x00020C45
		public double HardResetThresholdSec { get; set; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x0600090E RID: 2318 RVA: 0x00022A4E File Offset: 0x00020C4E
		// (set) Token: 0x0600090F RID: 2319 RVA: 0x00022A56 File Offset: 0x00020C56
		public double AdjustmentRatio { get; set; }

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000910 RID: 2320 RVA: 0x00022A5F File Offset: 0x00020C5F
		public double LocalTime
		{
			get
			{
				return this.m_TimeSec + this.m_CurrentLocalTimeOffset;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000911 RID: 2321 RVA: 0x00022A6E File Offset: 0x00020C6E
		public double ServerTime
		{
			get
			{
				return this.m_TimeSec + this.m_CurrentServerTimeOffset;
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000912 RID: 2322 RVA: 0x00022A7D File Offset: 0x00020C7D
		// (set) Token: 0x06000913 RID: 2323 RVA: 0x00022A85 File Offset: 0x00020C85
		internal double LastSyncedServerTimeSec { get; private set; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000914 RID: 2324 RVA: 0x00022A8E File Offset: 0x00020C8E
		// (set) Token: 0x06000915 RID: 2325 RVA: 0x00022A96 File Offset: 0x00020C96
		internal double LastSyncedRttSec { get; private set; }

		// Token: 0x06000916 RID: 2326 RVA: 0x00022A9F File Offset: 0x00020C9F
		public NetworkTimeSystem(double localBufferSec, double serverBufferSec = 0.05000000074505806, double hardResetThresholdSec = 0.2, double adjustmentRatio = 0.01)
		{
			this.LocalBufferSec = localBufferSec;
			this.ServerBufferSec = serverBufferSec;
			this.HardResetThresholdSec = hardResetThresholdSec;
			this.AdjustmentRatio = adjustmentRatio;
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x00022AC4 File Offset: 0x00020CC4
		internal NetworkTickSystem Initialize(NetworkManager networkManager)
		{
			this.m_NetworkManager = networkManager;
			this.m_ConnectionManager = networkManager.ConnectionManager;
			this.m_NetworkTransport = networkManager.NetworkConfig.NetworkTransport;
			this.m_TimeSyncFrequencyTicks = (int)(1.0 * networkManager.NetworkConfig.TickRate);
			this.m_NetworkTickSystem = new NetworkTickSystem(networkManager.NetworkConfig.TickRate, 0.0, 0.0);
			if (this.m_ConnectionManager.LocalClient.IsServer)
			{
				this.m_NetworkTickSystem.Tick += this.OnTickSyncTime;
			}
			return this.m_NetworkTickSystem;
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x00022B6C File Offset: 0x00020D6C
		internal void UpdateTime()
		{
			if (!this.m_ConnectionManager.LocalClient.IsServer && !this.m_ConnectionManager.LocalClient.IsConnected)
			{
				return;
			}
			if (this.Advance((double)this.m_NetworkManager.RealTimeProvider.UnscaledDeltaTime))
			{
				this.m_NetworkTickSystem.Reset(this.LocalTime, this.ServerTime);
			}
			this.m_NetworkTickSystem.UpdateTick(this.LocalTime, this.ServerTime);
			if (!this.m_ConnectionManager.LocalClient.IsServer)
			{
				this.Sync(this.LastSyncedServerTimeSec + (double)this.m_NetworkManager.RealTimeProvider.UnscaledDeltaTime, this.m_NetworkTransport.GetCurrentRtt(0UL) / 1000.0);
			}
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x00022C30 File Offset: 0x00020E30
		private void OnTickSyncTime()
		{
			if (this.m_ConnectionManager.LocalClient.IsServer && this.m_NetworkTickSystem.ServerTime.Tick % this.m_TimeSyncFrequencyTicks == 0)
			{
				TimeSyncMessage timeSyncMessage = new TimeSyncMessage
				{
					Tick = this.m_NetworkTickSystem.ServerTime.Tick
				};
				this.m_ConnectionManager.SendMessage<TimeSyncMessage, List<ulong>>(ref timeSyncMessage, NetworkDelivery.Unreliable, this.m_ConnectionManager.ConnectedClientIds);
			}
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x00022CA9 File Offset: 0x00020EA9
		internal void Shutdown()
		{
			if (this.m_ConnectionManager.LocalClient.IsServer)
			{
				this.m_NetworkTickSystem.Tick -= this.OnTickSyncTime;
			}
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x00022CD4 File Offset: 0x00020ED4
		public static NetworkTimeSystem ServerTimeSystem()
		{
			return new NetworkTimeSystem(0.0, 0.0, double.MaxValue, 0.01);
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x00022D00 File Offset: 0x00020F00
		public bool Advance(double deltaTimeSec)
		{
			this.m_TimeSec += deltaTimeSec;
			if (Math.Abs(this.m_DesiredLocalTimeOffset - this.m_CurrentLocalTimeOffset) > this.HardResetThresholdSec || Math.Abs(this.m_DesiredServerTimeOffset - this.m_CurrentServerTimeOffset) > this.HardResetThresholdSec)
			{
				this.m_TimeSec += this.m_DesiredServerTimeOffset;
				this.m_DesiredLocalTimeOffset -= this.m_DesiredServerTimeOffset;
				this.m_CurrentLocalTimeOffset = this.m_DesiredLocalTimeOffset;
				this.m_DesiredServerTimeOffset = 0.0;
				this.m_CurrentServerTimeOffset = 0.0;
				return true;
			}
			this.m_CurrentLocalTimeOffset += deltaTimeSec * ((this.m_DesiredLocalTimeOffset > this.m_CurrentLocalTimeOffset) ? this.AdjustmentRatio : (-this.AdjustmentRatio));
			this.m_CurrentServerTimeOffset += deltaTimeSec * ((this.m_DesiredServerTimeOffset > this.m_CurrentServerTimeOffset) ? this.AdjustmentRatio : (-this.AdjustmentRatio));
			return false;
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x00022DFA File Offset: 0x00020FFA
		public void Reset(double serverTimeSec, double rttSec)
		{
			this.Sync(serverTimeSec, rttSec);
			this.Advance(0.0);
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x00022E14 File Offset: 0x00021014
		public void Sync(double serverTimeSec, double rttSec)
		{
			this.LastSyncedRttSec = rttSec;
			this.LastSyncedServerTimeSec = serverTimeSec;
			double num = serverTimeSec - this.m_TimeSec;
			this.m_DesiredServerTimeOffset = num - this.ServerBufferSec;
			this.m_DesiredLocalTimeOffset = num + rttSec + this.LocalBufferSec;
		}

		// Token: 0x0400035F RID: 863
		private const float k_DefaultBufferSizeSec = 0.05f;

		// Token: 0x04000360 RID: 864
		private const double k_TimeSyncFrequency = 1.0;

		// Token: 0x04000361 RID: 865
		private const double k_HardResetThresholdSeconds = 0.2;

		// Token: 0x04000362 RID: 866
		private const double k_DefaultAdjustmentRatio = 0.01;

		// Token: 0x04000363 RID: 867
		private double m_TimeSec;

		// Token: 0x04000364 RID: 868
		private double m_CurrentLocalTimeOffset;

		// Token: 0x04000365 RID: 869
		private double m_DesiredLocalTimeOffset;

		// Token: 0x04000366 RID: 870
		private double m_CurrentServerTimeOffset;

		// Token: 0x04000367 RID: 871
		private double m_DesiredServerTimeOffset;

		// Token: 0x0400036E RID: 878
		private NetworkConnectionManager m_ConnectionManager;

		// Token: 0x0400036F RID: 879
		private NetworkTransport m_NetworkTransport;

		// Token: 0x04000370 RID: 880
		private NetworkTickSystem m_NetworkTickSystem;

		// Token: 0x04000371 RID: 881
		private NetworkManager m_NetworkManager;

		// Token: 0x04000372 RID: 882
		private int m_TimeSyncFrequencyTicks;
	}
}
