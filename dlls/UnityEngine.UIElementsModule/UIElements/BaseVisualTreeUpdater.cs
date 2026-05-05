using System;
using System.Diagnostics;
using Unity.Profiling;

namespace UnityEngine.UIElements
{
	// Token: 0x0200041D RID: 1053
	internal abstract class BaseVisualTreeUpdater : IVisualTreeUpdater, IDisposable
	{
		// Token: 0x14000041 RID: 65
		// (add) Token: 0x06002181 RID: 8577 RVA: 0x0007ED94 File Offset: 0x0007CF94
		// (remove) Token: 0x06002182 RID: 8578 RVA: 0x0007EDCC File Offset: 0x0007CFCC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action<BaseVisualElementPanel> panelChanged;

		// Token: 0x170007BB RID: 1979
		// (get) Token: 0x06002183 RID: 8579 RVA: 0x0007EE04 File Offset: 0x0007D004
		// (set) Token: 0x06002184 RID: 8580 RVA: 0x0007EE1C File Offset: 0x0007D01C
		public BaseVisualElementPanel panel
		{
			get
			{
				return this.m_Panel;
			}
			set
			{
				this.m_Panel = value;
				bool flag = this.panelChanged != null;
				if (flag)
				{
					this.panelChanged(value);
				}
			}
		}

		// Token: 0x170007BC RID: 1980
		// (get) Token: 0x06002185 RID: 8581 RVA: 0x0007EE4C File Offset: 0x0007D04C
		public VisualElement visualTree
		{
			get
			{
				return this.panel.visualTree;
			}
		}

		// Token: 0x170007BD RID: 1981
		// (get) Token: 0x06002186 RID: 8582
		public abstract ProfilerMarker profilerMarker { get; }

		// Token: 0x06002187 RID: 8583 RVA: 0x0007EE69 File Offset: 0x0007D069
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06002188 RID: 8584 RVA: 0x00003CD2 File Offset: 0x00001ED2
		protected virtual void Dispose(bool disposing)
		{
		}

		// Token: 0x06002189 RID: 8585
		public abstract void Update();

		// Token: 0x0600218A RID: 8586
		public abstract void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType);

		// Token: 0x04000E42 RID: 3650
		private BaseVisualElementPanel m_Panel;
	}
}
