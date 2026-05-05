using System;

namespace Rewired
{
	// Token: 0x0200014A RID: 330
	[Serializable]
	public sealed class InputActionCategory : InputCategory
	{
		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x06000E4B RID: 3659 RVA: 0x0000D37D File Offset: 0x0000B57D
		internal override string keyCategory
		{
			get
			{
				return "action/category";
			}
		}

		// Token: 0x06000E4C RID: 3660 RVA: 0x0000D384 File Offset: 0x0000B584
		public InputActionCategory()
		{
		}

		// Token: 0x06000E4D RID: 3661 RVA: 0x0000D38C File Offset: 0x0000B58C
		public InputActionCategory(InputActionCategory A_1) : base(A_1)
		{
		}
	}
}
