using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000019 RID: 25
	public interface INotifiedCollectionItem
	{
		// Token: 0x06000097 RID: 151
		void BeforeAdd();

		// Token: 0x06000098 RID: 152
		void AfterAdd();

		// Token: 0x06000099 RID: 153
		void BeforeRemove();

		// Token: 0x0600009A RID: 154
		void AfterRemove();
	}
}
