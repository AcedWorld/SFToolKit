using System;
using UnityEngine;

namespace Unity.Multiplayer.Tools.NetStatsMonitor
{
	// Token: 0x02000006 RID: 6
	[Serializable]
	public sealed class ExponentialMovingAverageParams
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000015 RID: 21 RVA: 0x000021E4 File Offset: 0x000003E4
		// (set) Token: 0x06000016 RID: 22 RVA: 0x000021EC File Offset: 0x000003EC
		public double HalfLife
		{
			get
			{
				return this.m_HalfLife;
			}
			set
			{
				this.m_HalfLife = Math.Max(value, 0.0);
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002204 File Offset: 0x00000404
		internal int ComputeHashCode()
		{
			return this.HalfLife.GetHashCode();
		}

		// Token: 0x04000017 RID: 23
		[SerializeField]
		[Min(0f)]
		private double m_HalfLife = 1.0;
	}
}
