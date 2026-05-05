using System;

namespace Invector.vEventSystems
{
	// Token: 0x020003C7 RID: 967
	public static class vIAnimatorStateInfoHelper
	{
		// Token: 0x06001345 RID: 4933 RVA: 0x00064EF0 File Offset: 0x000630F0
		public static void Register(this vIAnimatorStateInfoController animatorStateInfos)
		{
			if (animatorStateInfos.isValid())
			{
				animatorStateInfos.animatorStateInfos.RegisterListener();
			}
		}

		// Token: 0x06001346 RID: 4934 RVA: 0x00064F05 File Offset: 0x00063105
		public static void UnRegister(this vIAnimatorStateInfoController animatorStateInfos)
		{
			if (animatorStateInfos.isValid())
			{
				animatorStateInfos.animatorStateInfos.RemoveListener();
			}
		}

		// Token: 0x06001347 RID: 4935 RVA: 0x00064F1A File Offset: 0x0006311A
		public static bool isValid(this vIAnimatorStateInfoController animatorStateInfos)
		{
			return animatorStateInfos != null && animatorStateInfos.animatorStateInfos != null && animatorStateInfos.animatorStateInfos.animator != null;
		}
	}
}
