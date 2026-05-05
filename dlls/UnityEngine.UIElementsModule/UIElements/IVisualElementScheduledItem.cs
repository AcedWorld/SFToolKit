using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000408 RID: 1032
	public interface IVisualElementScheduledItem
	{
		// Token: 0x170007A7 RID: 1959
		// (get) Token: 0x060020FC RID: 8444
		VisualElement element { get; }

		// Token: 0x170007A8 RID: 1960
		// (get) Token: 0x060020FD RID: 8445
		bool isActive { get; }

		// Token: 0x060020FE RID: 8446
		void Resume();

		// Token: 0x060020FF RID: 8447
		void Pause();

		// Token: 0x06002100 RID: 8448
		void ExecuteLater(long delayMs);

		// Token: 0x06002101 RID: 8449
		IVisualElementScheduledItem StartingIn(long delayMs);

		// Token: 0x06002102 RID: 8450
		IVisualElementScheduledItem Every(long intervalMs);

		// Token: 0x06002103 RID: 8451
		IVisualElementScheduledItem Until(Func<bool> stopCondition);

		// Token: 0x06002104 RID: 8452
		IVisualElementScheduledItem ForDuration(long durationMs);
	}
}
