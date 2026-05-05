using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000081 RID: 129
	public interface IGraphEventListener
	{
		// Token: 0x060003CE RID: 974
		void StartListening(GraphStack stack);

		// Token: 0x060003CF RID: 975
		void StopListening(GraphStack stack);

		// Token: 0x060003D0 RID: 976
		bool IsListening(GraphPointer pointer);
	}
}
