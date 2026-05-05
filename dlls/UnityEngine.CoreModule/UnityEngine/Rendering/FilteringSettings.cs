using System;
using UnityEngine.Internal;

namespace UnityEngine.Rendering
{
	// Token: 0x02000459 RID: 1113
	public struct FilteringSettings : IEquatable<FilteringSettings>
	{
		// Token: 0x170006C7 RID: 1735
		// (get) Token: 0x06002564 RID: 9572 RVA: 0x0003FC56 File Offset: 0x0003DE56
		public static FilteringSettings defaultValue
		{
			get
			{
				return new FilteringSettings(new RenderQueueRange?(RenderQueueRange.all), -1, uint.MaxValue, 0);
			}
		}

		// Token: 0x06002565 RID: 9573 RVA: 0x0003FC6C File Offset: 0x0003DE6C
		public FilteringSettings([DefaultValue("RenderQueueRange.all")] RenderQueueRange? renderQueueRange = null, int layerMask = -1, uint renderingLayerMask = 4294967295U, int excludeMotionVectorObjects = 0)
		{
			this = default(FilteringSettings);
			this.m_RenderQueueRange = (renderQueueRange ?? RenderQueueRange.all);
			this.m_LayerMask = layerMask;
			this.m_RenderingLayerMask = renderingLayerMask;
			this.m_ExcludeMotionVectorObjects = excludeMotionVectorObjects;
			this.m_SortingLayerRange = SortingLayerRange.all;
		}

		// Token: 0x170006C8 RID: 1736
		// (get) Token: 0x06002566 RID: 9574 RVA: 0x0003FCC4 File Offset: 0x0003DEC4
		// (set) Token: 0x06002567 RID: 9575 RVA: 0x0003FCDC File Offset: 0x0003DEDC
		public RenderQueueRange renderQueueRange
		{
			get
			{
				return this.m_RenderQueueRange;
			}
			set
			{
				this.m_RenderQueueRange = value;
			}
		}

		// Token: 0x170006C9 RID: 1737
		// (get) Token: 0x06002568 RID: 9576 RVA: 0x0003FCE8 File Offset: 0x0003DEE8
		// (set) Token: 0x06002569 RID: 9577 RVA: 0x0003FD00 File Offset: 0x0003DF00
		public int layerMask
		{
			get
			{
				return this.m_LayerMask;
			}
			set
			{
				this.m_LayerMask = value;
			}
		}

		// Token: 0x170006CA RID: 1738
		// (get) Token: 0x0600256A RID: 9578 RVA: 0x0003FD0C File Offset: 0x0003DF0C
		// (set) Token: 0x0600256B RID: 9579 RVA: 0x0003FD24 File Offset: 0x0003DF24
		public uint renderingLayerMask
		{
			get
			{
				return this.m_RenderingLayerMask;
			}
			set
			{
				this.m_RenderingLayerMask = value;
			}
		}

		// Token: 0x170006CB RID: 1739
		// (get) Token: 0x0600256C RID: 9580 RVA: 0x0003FD30 File Offset: 0x0003DF30
		// (set) Token: 0x0600256D RID: 9581 RVA: 0x0003FD4B File Offset: 0x0003DF4B
		public bool excludeMotionVectorObjects
		{
			get
			{
				return this.m_ExcludeMotionVectorObjects != 0;
			}
			set
			{
				this.m_ExcludeMotionVectorObjects = (value ? 1 : 0);
			}
		}

		// Token: 0x170006CC RID: 1740
		// (get) Token: 0x0600256E RID: 9582 RVA: 0x0003FD5C File Offset: 0x0003DF5C
		// (set) Token: 0x0600256F RID: 9583 RVA: 0x0003FD74 File Offset: 0x0003DF74
		public SortingLayerRange sortingLayerRange
		{
			get
			{
				return this.m_SortingLayerRange;
			}
			set
			{
				this.m_SortingLayerRange = value;
			}
		}

		// Token: 0x06002570 RID: 9584 RVA: 0x0003FD80 File Offset: 0x0003DF80
		public bool Equals(FilteringSettings other)
		{
			return this.m_RenderQueueRange.Equals(other.m_RenderQueueRange) && this.m_LayerMask == other.m_LayerMask && this.m_RenderingLayerMask == other.m_RenderingLayerMask && this.m_ExcludeMotionVectorObjects == other.m_ExcludeMotionVectorObjects;
		}

		// Token: 0x06002571 RID: 9585 RVA: 0x0003FDD4 File Offset: 0x0003DFD4
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is FilteringSettings && this.Equals((FilteringSettings)obj);
		}

		// Token: 0x06002572 RID: 9586 RVA: 0x0003FE0C File Offset: 0x0003E00C
		public override int GetHashCode()
		{
			int num = this.m_RenderQueueRange.GetHashCode();
			num = (num * 397 ^ this.m_LayerMask);
			num = (num * 397 ^ (int)this.m_RenderingLayerMask);
			return num * 397 ^ this.m_ExcludeMotionVectorObjects;
		}

		// Token: 0x06002573 RID: 9587 RVA: 0x0003FE60 File Offset: 0x0003E060
		public static bool operator ==(FilteringSettings left, FilteringSettings right)
		{
			return left.Equals(right);
		}

		// Token: 0x06002574 RID: 9588 RVA: 0x0003FE7C File Offset: 0x0003E07C
		public static bool operator !=(FilteringSettings left, FilteringSettings right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000E1B RID: 3611
		private RenderQueueRange m_RenderQueueRange;

		// Token: 0x04000E1C RID: 3612
		private int m_LayerMask;

		// Token: 0x04000E1D RID: 3613
		private uint m_RenderingLayerMask;

		// Token: 0x04000E1E RID: 3614
		private int m_ExcludeMotionVectorObjects;

		// Token: 0x04000E1F RID: 3615
		private SortingLayerRange m_SortingLayerRange;
	}
}
