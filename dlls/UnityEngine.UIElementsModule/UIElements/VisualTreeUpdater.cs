using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200041A RID: 1050
	internal sealed class VisualTreeUpdater : IDisposable
	{
		// Token: 0x0600216E RID: 8558 RVA: 0x0007EB09 File Offset: 0x0007CD09
		public VisualTreeUpdater(BaseVisualElementPanel panel)
		{
			this.m_Panel = panel;
			this.m_UpdaterArray = new VisualTreeUpdater.UpdaterArray();
			this.SetDefaultUpdaters();
		}

		// Token: 0x0600216F RID: 8559 RVA: 0x0007EB2C File Offset: 0x0007CD2C
		public void Dispose()
		{
			for (int i = 0; i < 7; i++)
			{
				IVisualTreeUpdater visualTreeUpdater = this.m_UpdaterArray[i];
				visualTreeUpdater.Dispose();
			}
		}

		// Token: 0x06002170 RID: 8560 RVA: 0x0007EB60 File Offset: 0x0007CD60
		public void UpdateVisualTree()
		{
			for (int i = 0; i < 7; i++)
			{
				IVisualTreeUpdater visualTreeUpdater = this.m_UpdaterArray[i];
				using (visualTreeUpdater.profilerMarker.Auto())
				{
					visualTreeUpdater.Update();
				}
			}
		}

		// Token: 0x06002171 RID: 8561 RVA: 0x0007EBC8 File Offset: 0x0007CDC8
		public void UpdateVisualTreePhase(VisualTreeUpdatePhase phase)
		{
			IVisualTreeUpdater visualTreeUpdater = this.m_UpdaterArray[phase];
			using (visualTreeUpdater.profilerMarker.Auto())
			{
				visualTreeUpdater.Update();
			}
		}

		// Token: 0x06002172 RID: 8562 RVA: 0x0007EC1C File Offset: 0x0007CE1C
		public void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType)
		{
			for (int i = 0; i < 7; i++)
			{
				IVisualTreeUpdater visualTreeUpdater = this.m_UpdaterArray[i];
				visualTreeUpdater.OnVersionChanged(ve, versionChangeType);
			}
		}

		// Token: 0x06002173 RID: 8563 RVA: 0x0007EC52 File Offset: 0x0007CE52
		public void SetUpdater(IVisualTreeUpdater updater, VisualTreeUpdatePhase phase)
		{
			IVisualTreeUpdater visualTreeUpdater = this.m_UpdaterArray[phase];
			if (visualTreeUpdater != null)
			{
				visualTreeUpdater.Dispose();
			}
			updater.panel = this.m_Panel;
			this.m_UpdaterArray[phase] = updater;
		}

		// Token: 0x06002174 RID: 8564 RVA: 0x0007EC88 File Offset: 0x0007CE88
		public void SetUpdater<T>(VisualTreeUpdatePhase phase) where T : IVisualTreeUpdater, new()
		{
			IVisualTreeUpdater visualTreeUpdater = this.m_UpdaterArray[phase];
			if (visualTreeUpdater != null)
			{
				visualTreeUpdater.Dispose();
			}
			T t = Activator.CreateInstance<T>();
			t.panel = this.m_Panel;
			T t2 = t;
			this.m_UpdaterArray[phase] = t2;
		}

		// Token: 0x06002175 RID: 8565 RVA: 0x0007ECE0 File Offset: 0x0007CEE0
		public IVisualTreeUpdater GetUpdater(VisualTreeUpdatePhase phase)
		{
			return this.m_UpdaterArray[phase];
		}

		// Token: 0x06002176 RID: 8566 RVA: 0x0007ECFE File Offset: 0x0007CEFE
		private void SetDefaultUpdaters()
		{
			this.SetUpdater<VisualTreeViewDataUpdater>(VisualTreeUpdatePhase.ViewData);
			this.SetUpdater<VisualTreeBindingsUpdater>(VisualTreeUpdatePhase.Bindings);
			this.SetUpdater<VisualElementAnimationSystem>(VisualTreeUpdatePhase.Animation);
			this.SetUpdater<VisualTreeStyleUpdater>(VisualTreeUpdatePhase.Styles);
			this.SetUpdater<UIRLayoutUpdater>(VisualTreeUpdatePhase.Layout);
			this.SetUpdater<VisualTreeHierarchyFlagsUpdater>(VisualTreeUpdatePhase.TransformClip);
			this.SetUpdater<UIRRepaintUpdater>(VisualTreeUpdatePhase.Repaint);
		}

		// Token: 0x04000E3E RID: 3646
		private BaseVisualElementPanel m_Panel;

		// Token: 0x04000E3F RID: 3647
		private VisualTreeUpdater.UpdaterArray m_UpdaterArray;

		// Token: 0x0200041B RID: 1051
		private class UpdaterArray
		{
			// Token: 0x06002177 RID: 8567 RVA: 0x0007ED39 File Offset: 0x0007CF39
			public UpdaterArray()
			{
				this.m_VisualTreeUpdaters = new IVisualTreeUpdater[7];
			}

			// Token: 0x170007B7 RID: 1975
			public IVisualTreeUpdater this[VisualTreeUpdatePhase phase]
			{
				get
				{
					return this.m_VisualTreeUpdaters[(int)phase];
				}
				set
				{
					this.m_VisualTreeUpdaters[(int)phase] = value;
				}
			}

			// Token: 0x170007B8 RID: 1976
			public IVisualTreeUpdater this[int index]
			{
				get
				{
					return this.m_VisualTreeUpdaters[index];
				}
				set
				{
					this.m_VisualTreeUpdaters[index] = value;
				}
			}

			// Token: 0x04000E40 RID: 3648
			private IVisualTreeUpdater[] m_VisualTreeUpdaters;
		}
	}
}
