using System;
using JetBrains.Annotations;
using Unity.Multiplayer.Tools.NetStats;
using UnityEngine;
using UnityEngine.UIElements;

namespace Unity.Multiplayer.Tools.NetStatsMonitor
{
	// Token: 0x02000005 RID: 5
	[AddComponentMenu("Netcode/RuntimeNetStatsMonitor", 1000)]
	public class RuntimeNetStatsMonitor : MonoBehaviour
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000021BC File Offset: 0x000003BC
		// (set) Token: 0x0600000E RID: 14 RVA: 0x000021C4 File Offset: 0x000003C4
		public bool Visible
		{
			get
			{
				return this.m_Visible;
			}
			set
			{
				this.m_Visible = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000021CD File Offset: 0x000003CD
		// (set) Token: 0x06000010 RID: 16 RVA: 0x000021D5 File Offset: 0x000003D5
		public double MaxRefreshRate
		{
			get
			{
				return this.m_MaxRefreshRate;
			}
			set
			{
				this.m_MaxRefreshRate = Math.Max(value, 1.0);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000011 RID: 17 RVA: 0x000021EC File Offset: 0x000003EC
		// (set) Token: 0x06000012 RID: 18 RVA: 0x000021F4 File Offset: 0x000003F4
		public StyleSheet CustomStyleSheet { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000013 RID: 19 RVA: 0x000021FD File Offset: 0x000003FD
		// (set) Token: 0x06000014 RID: 20 RVA: 0x00002205 File Offset: 0x00000405
		public PanelSettings PanelSettingsOverride { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000015 RID: 21 RVA: 0x0000220E File Offset: 0x0000040E
		// (set) Token: 0x06000016 RID: 22 RVA: 0x00002216 File Offset: 0x00000416
		public PositionConfiguration Position { get; set; } = new PositionConfiguration();

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000017 RID: 23 RVA: 0x0000221F File Offset: 0x0000041F
		// (set) Token: 0x06000018 RID: 24 RVA: 0x00002227 File Offset: 0x00000427
		[CanBeNull]
		public NetStatsMonitorConfiguration Configuration { get; set; }

		// Token: 0x06000019 RID: 25 RVA: 0x00002230 File Offset: 0x00000430
		private void Start()
		{
			this.Setup();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002238 File Offset: 0x00000438
		private void OnEnable()
		{
			this.Setup();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002240 File Offset: 0x00000440
		private void OnDisable()
		{
			this.Teardown();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002248 File Offset: 0x00000448
		private void OnDestroy()
		{
			this.Teardown();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002250 File Offset: 0x00000450
		private void OnValidate()
		{
			if (base.enabled)
			{
				this.ApplyConfiguration();
				return;
			}
			this.Teardown();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002267 File Offset: 0x00000467
		internal void Setup()
		{
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002269 File Offset: 0x00000469
		internal void Teardown()
		{
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000226B File Offset: 0x0000046B
		public void ApplyConfiguration()
		{
			if (this.Configuration != null)
			{
				this.Configuration.RecomputeConfigurationHash();
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002286 File Offset: 0x00000486
		public void AddCustomValue(MetricId metricId, float value)
		{
		}

		// Token: 0x04000006 RID: 6
		[SerializeField]
		[Tooltip("Visibility toggle to hide or show the on-screen display.")]
		private bool m_Visible = true;

		// Token: 0x04000007 RID: 7
		[SerializeField]
		[Min(1f)]
		[Tooltip("The maximum rate at which the Runtime Net Stats Monitor's on-screen display is updated (per second). The on-screen display will never be updated faster than the overall refresh rate.")]
		private double m_MaxRefreshRate = 30.0;
	}
}
