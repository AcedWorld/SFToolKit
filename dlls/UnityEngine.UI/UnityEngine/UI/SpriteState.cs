using System;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
	// Token: 0x02000038 RID: 56
	[Serializable]
	public struct SpriteState : IEquatable<SpriteState>
	{
		// Token: 0x1700011F RID: 287
		// (get) Token: 0x0600042E RID: 1070 RVA: 0x00014AEE File Offset: 0x00012CEE
		// (set) Token: 0x0600042F RID: 1071 RVA: 0x00014AF6 File Offset: 0x00012CF6
		public Sprite highlightedSprite
		{
			get
			{
				return this.m_HighlightedSprite;
			}
			set
			{
				this.m_HighlightedSprite = value;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000430 RID: 1072 RVA: 0x00014AFF File Offset: 0x00012CFF
		// (set) Token: 0x06000431 RID: 1073 RVA: 0x00014B07 File Offset: 0x00012D07
		public Sprite pressedSprite
		{
			get
			{
				return this.m_PressedSprite;
			}
			set
			{
				this.m_PressedSprite = value;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000432 RID: 1074 RVA: 0x00014B10 File Offset: 0x00012D10
		// (set) Token: 0x06000433 RID: 1075 RVA: 0x00014B18 File Offset: 0x00012D18
		public Sprite selectedSprite
		{
			get
			{
				return this.m_SelectedSprite;
			}
			set
			{
				this.m_SelectedSprite = value;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000434 RID: 1076 RVA: 0x00014B21 File Offset: 0x00012D21
		// (set) Token: 0x06000435 RID: 1077 RVA: 0x00014B29 File Offset: 0x00012D29
		public Sprite disabledSprite
		{
			get
			{
				return this.m_DisabledSprite;
			}
			set
			{
				this.m_DisabledSprite = value;
			}
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00014B34 File Offset: 0x00012D34
		public bool Equals(SpriteState other)
		{
			return this.highlightedSprite == other.highlightedSprite && this.pressedSprite == other.pressedSprite && this.selectedSprite == other.selectedSprite && this.disabledSprite == other.disabledSprite;
		}

		// Token: 0x0400016A RID: 362
		[SerializeField]
		private Sprite m_HighlightedSprite;

		// Token: 0x0400016B RID: 363
		[SerializeField]
		private Sprite m_PressedSprite;

		// Token: 0x0400016C RID: 364
		[FormerlySerializedAs("m_HighlightedSprite")]
		[SerializeField]
		private Sprite m_SelectedSprite;

		// Token: 0x0400016D RID: 365
		[SerializeField]
		private Sprite m_DisabledSprite;
	}
}
