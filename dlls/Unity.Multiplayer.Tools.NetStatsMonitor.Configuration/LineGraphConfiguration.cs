using System;
using UnityEngine;

namespace Unity.Multiplayer.Tools.NetStatsMonitor
{
	// Token: 0x0200000D RID: 13
	[Serializable]
	public sealed class LineGraphConfiguration
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00002940 File Offset: 0x00000B40
		// (set) Token: 0x06000046 RID: 70 RVA: 0x00002948 File Offset: 0x00000B48
		public float LineThickness
		{
			get
			{
				return this.m_LineThickness;
			}
			set
			{
				this.m_LineThickness = Mathf.Clamp(value, 1f, 5f);
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002960 File Offset: 0x00000B60
		internal int ComputeHashCode()
		{
			return this.LineThickness.GetHashCode();
		}

		// Token: 0x04000033 RID: 51
		[SerializeField]
		[Range(1f, 5f)]
		private float m_LineThickness = 1f;
	}
}
