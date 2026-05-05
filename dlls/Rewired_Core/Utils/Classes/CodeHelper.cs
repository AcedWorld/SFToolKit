using System;
using System.ComponentModel;

namespace Rewired.Utils.Classes
{
	// Token: 0x020004C0 RID: 1216
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class CodeHelper
	{
		// Token: 0x060030F3 RID: 12531 RVA: 0x00025681 File Offset: 0x00023881
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		// Token: 0x060030F4 RID: 12532 RVA: 0x00024E75 File Offset: 0x00023075
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x060030F5 RID: 12533 RVA: 0x0002568A File Offset: 0x0002388A
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}
	}
}
