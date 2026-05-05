using System;

namespace UnityEngine.UIElements.Experimental
{
	// Token: 0x020004C1 RID: 1217
	public interface IValueAnimation
	{
		// Token: 0x060025F3 RID: 9715
		void Start();

		// Token: 0x060025F4 RID: 9716
		void Stop();

		// Token: 0x060025F5 RID: 9717
		void Recycle();

		// Token: 0x17000895 RID: 2197
		// (get) Token: 0x060025F6 RID: 9718
		bool isRunning { get; }

		// Token: 0x17000896 RID: 2198
		// (get) Token: 0x060025F7 RID: 9719
		// (set) Token: 0x060025F8 RID: 9720
		int durationMs { get; set; }
	}
}
