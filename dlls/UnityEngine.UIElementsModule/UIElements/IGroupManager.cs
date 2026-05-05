using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000263 RID: 611
	internal interface IGroupManager
	{
		// Token: 0x0600115B RID: 4443
		void Init(IGroupBox groupBox);

		// Token: 0x0600115C RID: 4444
		IGroupBoxOption GetSelectedOption();

		// Token: 0x0600115D RID: 4445
		void OnOptionSelectionChanged(IGroupBoxOption selectedOption);

		// Token: 0x0600115E RID: 4446
		void RegisterOption(IGroupBoxOption option);

		// Token: 0x0600115F RID: 4447
		void UnregisterOption(IGroupBoxOption option);
	}
}
