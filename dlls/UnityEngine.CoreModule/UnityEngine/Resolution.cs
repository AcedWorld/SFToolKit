using System;
using System.ComponentModel;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000156 RID: 342
	[RequiredByNativeCode]
	public struct Resolution
	{
		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000AD0 RID: 2768 RVA: 0x00011710 File Offset: 0x0000F910
		// (set) Token: 0x06000AD1 RID: 2769 RVA: 0x00011728 File Offset: 0x0000F928
		public int width
		{
			get
			{
				return this.m_Width;
			}
			set
			{
				this.m_Width = value;
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000AD2 RID: 2770 RVA: 0x00011734 File Offset: 0x0000F934
		// (set) Token: 0x06000AD3 RID: 2771 RVA: 0x0001174C File Offset: 0x0000F94C
		public int height
		{
			get
			{
				return this.m_Height;
			}
			set
			{
				this.m_Height = value;
			}
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06000AD4 RID: 2772 RVA: 0x00011758 File Offset: 0x0000F958
		// (set) Token: 0x06000AD5 RID: 2773 RVA: 0x00011770 File Offset: 0x0000F970
		public RefreshRate refreshRateRatio
		{
			get
			{
				return this.m_RefreshRate;
			}
			set
			{
				this.m_RefreshRate = value;
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000AD6 RID: 2774 RVA: 0x0001177C File Offset: 0x0000F97C
		// (set) Token: 0x06000AD7 RID: 2775 RVA: 0x0001179F File Offset: 0x0000F99F
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Resolution.refreshRate is obsolete. Use refreshRateRatio instead.", false)]
		public int refreshRate
		{
			get
			{
				return (int)Math.Round(this.m_RefreshRate.value);
			}
			set
			{
				this.m_RefreshRate.numerator = (uint)value;
				this.m_RefreshRate.denominator = 1U;
			}
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x000117BC File Offset: 0x0000F9BC
		public override string ToString()
		{
			return UnityString.Format("{0} x {1} @ {2}Hz", new object[]
			{
				this.m_Width,
				this.m_Height,
				this.m_RefreshRate
			});
		}

		// Token: 0x04000446 RID: 1094
		private int m_Width;

		// Token: 0x04000447 RID: 1095
		private int m_Height;

		// Token: 0x04000448 RID: 1096
		private RefreshRate m_RefreshRate;
	}
}
