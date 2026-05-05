using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Multiplayer.Tools.NetStatsMonitor
{
	// Token: 0x0200000E RID: 14
	[CreateAssetMenu(fileName = "NetStatsMonitorConfiguration", menuName = "Multiplayer/NetStatsMonitorConfiguration", order = 900)]
	public class NetStatsMonitorConfiguration : ScriptableObject
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000049 RID: 73 RVA: 0x0000298E File Offset: 0x00000B8E
		// (set) Token: 0x0600004A RID: 74 RVA: 0x00002996 File Offset: 0x00000B96
		public List<DisplayElementConfiguration> DisplayElements { get; set; } = new List<DisplayElementConfiguration>();

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600004B RID: 75 RVA: 0x0000299F File Offset: 0x00000B9F
		// (set) Token: 0x0600004C RID: 76 RVA: 0x000029A7 File Offset: 0x00000BA7
		internal int? ConfigurationHash { get; private set; }

		// Token: 0x0600004D RID: 77 RVA: 0x000029B0 File Offset: 0x00000BB0
		public void OnConfigurationModified()
		{
			this.RecomputeConfigurationHash();
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000029B8 File Offset: 0x00000BB8
		internal void OnValidate()
		{
			for (int i = 0; i < this.DisplayElements.Count; i++)
			{
				if (!this.DisplayElements[i].FieldsInitialized)
				{
					this.DisplayElements[i] = new DisplayElementConfiguration();
				}
				else
				{
					this.DisplayElements[i].OnValidate();
				}
			}
			this.RecomputeConfigurationHash();
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002A18 File Offset: 0x00000C18
		internal void RecomputeConfigurationHash()
		{
			int num = 0;
			foreach (DisplayElementConfiguration displayElementConfiguration in this.DisplayElements)
			{
				num = HashCode.Combine<int, int>(num, displayElementConfiguration.ComputeHashCode());
			}
			this.ConfigurationHash = new int?(num);
		}
	}
}
