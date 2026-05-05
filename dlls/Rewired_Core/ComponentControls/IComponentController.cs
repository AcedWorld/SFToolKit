using System;
using Rewired.Utils.Interfaces;

namespace Rewired.ComponentControls
{
	// Token: 0x020003E2 RID: 994
	public interface IComponentController : IRegistrar<IComponentControl>
	{
		// Token: 0x060027D6 RID: 10198
		void ClearControlValues();
	}
}
