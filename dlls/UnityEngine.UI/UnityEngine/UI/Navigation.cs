using System;

namespace UnityEngine.UI
{
	// Token: 0x02000030 RID: 48
	[Serializable]
	public struct Navigation : IEquatable<Navigation>
	{
		// Token: 0x170000CB RID: 203
		// (get) Token: 0x0600030C RID: 780 RVA: 0x000103B9 File Offset: 0x0000E5B9
		// (set) Token: 0x0600030D RID: 781 RVA: 0x000103C1 File Offset: 0x0000E5C1
		public Navigation.Mode mode
		{
			get
			{
				return this.m_Mode;
			}
			set
			{
				this.m_Mode = value;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x0600030E RID: 782 RVA: 0x000103CA File Offset: 0x0000E5CA
		// (set) Token: 0x0600030F RID: 783 RVA: 0x000103D2 File Offset: 0x0000E5D2
		public bool wrapAround
		{
			get
			{
				return this.m_WrapAround;
			}
			set
			{
				this.m_WrapAround = value;
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000310 RID: 784 RVA: 0x000103DB File Offset: 0x0000E5DB
		// (set) Token: 0x06000311 RID: 785 RVA: 0x000103E3 File Offset: 0x0000E5E3
		public Selectable selectOnUp
		{
			get
			{
				return this.m_SelectOnUp;
			}
			set
			{
				this.m_SelectOnUp = value;
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000312 RID: 786 RVA: 0x000103EC File Offset: 0x0000E5EC
		// (set) Token: 0x06000313 RID: 787 RVA: 0x000103F4 File Offset: 0x0000E5F4
		public Selectable selectOnDown
		{
			get
			{
				return this.m_SelectOnDown;
			}
			set
			{
				this.m_SelectOnDown = value;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000314 RID: 788 RVA: 0x000103FD File Offset: 0x0000E5FD
		// (set) Token: 0x06000315 RID: 789 RVA: 0x00010405 File Offset: 0x0000E605
		public Selectable selectOnLeft
		{
			get
			{
				return this.m_SelectOnLeft;
			}
			set
			{
				this.m_SelectOnLeft = value;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000316 RID: 790 RVA: 0x0001040E File Offset: 0x0000E60E
		// (set) Token: 0x06000317 RID: 791 RVA: 0x00010416 File Offset: 0x0000E616
		public Selectable selectOnRight
		{
			get
			{
				return this.m_SelectOnRight;
			}
			set
			{
				this.m_SelectOnRight = value;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000318 RID: 792 RVA: 0x00010420 File Offset: 0x0000E620
		public static Navigation defaultNavigation
		{
			get
			{
				return new Navigation
				{
					m_Mode = Navigation.Mode.Automatic,
					m_WrapAround = false
				};
			}
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00010448 File Offset: 0x0000E648
		public bool Equals(Navigation other)
		{
			return this.mode == other.mode && this.selectOnUp == other.selectOnUp && this.selectOnDown == other.selectOnDown && this.selectOnLeft == other.selectOnLeft && this.selectOnRight == other.selectOnRight;
		}

		// Token: 0x04000105 RID: 261
		[SerializeField]
		private Navigation.Mode m_Mode;

		// Token: 0x04000106 RID: 262
		[Tooltip("Enables navigation to wrap around from last to first or first to last element. Does not work for automatic grid navigation")]
		[SerializeField]
		private bool m_WrapAround;

		// Token: 0x04000107 RID: 263
		[SerializeField]
		private Selectable m_SelectOnUp;

		// Token: 0x04000108 RID: 264
		[SerializeField]
		private Selectable m_SelectOnDown;

		// Token: 0x04000109 RID: 265
		[SerializeField]
		private Selectable m_SelectOnLeft;

		// Token: 0x0400010A RID: 266
		[SerializeField]
		private Selectable m_SelectOnRight;

		// Token: 0x020000A3 RID: 163
		[Flags]
		public enum Mode
		{
			// Token: 0x040002E9 RID: 745
			None = 0,
			// Token: 0x040002EA RID: 746
			Horizontal = 1,
			// Token: 0x040002EB RID: 747
			Vertical = 2,
			// Token: 0x040002EC RID: 748
			Automatic = 3,
			// Token: 0x040002ED RID: 749
			Explicit = 4
		}
	}
}
