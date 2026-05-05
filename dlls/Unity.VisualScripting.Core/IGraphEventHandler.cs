using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000059 RID: 89
	public interface IGraphEventHandler<TArgs>
	{
		// Token: 0x06000289 RID: 649
		EventHook GetHook(GraphReference reference);

		// Token: 0x0600028A RID: 650
		void Trigger(GraphReference reference, TArgs args);

		// Token: 0x0600028B RID: 651
		bool IsListening(GraphPointer pointer);
	}
}
