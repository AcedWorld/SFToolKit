using System;
using UnityEngine;

namespace Unity.Multiplayer.Tools.NetStatsMonitor
{
	// Token: 0x0200000F RID: 15
	[Serializable]
	public class PositionConfiguration
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002A93 File Offset: 0x00000C93
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00002A9B File Offset: 0x00000C9B
		public bool OverridePosition { get; set; } = true;

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00002AA4 File Offset: 0x00000CA4
		// (set) Token: 0x06000054 RID: 84 RVA: 0x00002AAC File Offset: 0x00000CAC
		public float PositionLeftToRight
		{
			get
			{
				return this.m_PositionLeftToRight;
			}
			set
			{
				this.m_PositionLeftToRight = Mathf.Clamp(value, 0f, 1f);
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00002AC4 File Offset: 0x00000CC4
		// (set) Token: 0x06000056 RID: 86 RVA: 0x00002ACC File Offset: 0x00000CCC
		public float PositionTopToBottom
		{
			get
			{
				return this.m_PositionTopToBottom;
			}
			set
			{
				this.m_PositionTopToBottom = Mathf.Clamp(value, 0f, 1f);
			}
		}

		// Token: 0x04000037 RID: 55
		[Tooltip("The position of the Net Stats Monitor from left to right in the range from 0 to 1. 0 is flush left, 0.5 is centered, and 1 is flush right.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float m_PositionLeftToRight;

		// Token: 0x04000038 RID: 56
		[Tooltip("The position of the Net Stats Monitor from top to bottom in the range from 0 to 1. 0 is flush to the top, 0.5 is centered, and 1 is flush to the bottom.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float m_PositionTopToBottom;
	}
}
