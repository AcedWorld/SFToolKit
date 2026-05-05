using System;

namespace Rewired.Utils.Interfaces
{
	// Token: 0x02000528 RID: 1320
	public interface IRegistrar<T> where T : class
	{
		// Token: 0x06003648 RID: 13896
		void Register(T registrant);

		// Token: 0x06003649 RID: 13897
		void Deregister(T registrant);
	}
}
