using System;
using Unity.Profiling;

namespace UnityEngine.UIElements
{
	// Token: 0x0200041C RID: 1052
	internal interface IVisualTreeUpdater : IDisposable
	{
		// Token: 0x170007B9 RID: 1977
		// (get) Token: 0x0600217C RID: 8572
		// (set) Token: 0x0600217D RID: 8573
		BaseVisualElementPanel panel { get; set; }

		// Token: 0x170007BA RID: 1978
		// (get) Token: 0x0600217E RID: 8574
		ProfilerMarker profilerMarker { get; }

		// Token: 0x0600217F RID: 8575
		void Update();

		// Token: 0x06002180 RID: 8576
		void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType);
	}
}
