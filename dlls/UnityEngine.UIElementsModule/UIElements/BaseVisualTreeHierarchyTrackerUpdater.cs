using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000412 RID: 1042
	internal abstract class BaseVisualTreeHierarchyTrackerUpdater : BaseVisualTreeUpdater
	{
		// Token: 0x0600213B RID: 8507
		protected abstract void OnHierarchyChange(VisualElement ve, HierarchyChangeType type);

		// Token: 0x0600213C RID: 8508 RVA: 0x0007DA20 File Offset: 0x0007BC20
		public override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType)
		{
			bool flag = (versionChangeType & VersionChangeType.Hierarchy) == VersionChangeType.Hierarchy;
			if (flag)
			{
				switch (this.m_State)
				{
				case BaseVisualTreeHierarchyTrackerUpdater.State.Waiting:
					this.ProcessNewChange(ve);
					break;
				case BaseVisualTreeHierarchyTrackerUpdater.State.TrackingAddOrMove:
					this.ProcessAddOrMove(ve);
					break;
				case BaseVisualTreeHierarchyTrackerUpdater.State.TrackingRemove:
					this.ProcessRemove(ve);
					break;
				}
			}
		}

		// Token: 0x0600213D RID: 8509 RVA: 0x0007DA78 File Offset: 0x0007BC78
		public override void Update()
		{
			Debug.Assert(this.m_State == BaseVisualTreeHierarchyTrackerUpdater.State.TrackingAddOrMove || this.m_State == BaseVisualTreeHierarchyTrackerUpdater.State.Waiting);
			bool flag = this.m_State == BaseVisualTreeHierarchyTrackerUpdater.State.TrackingAddOrMove;
			if (flag)
			{
				this.OnHierarchyChange(this.m_CurrentChangeElement, HierarchyChangeType.Move);
				this.m_State = BaseVisualTreeHierarchyTrackerUpdater.State.Waiting;
			}
			this.m_CurrentChangeElement = null;
			this.m_CurrentChangeParent = null;
		}

		// Token: 0x0600213E RID: 8510 RVA: 0x0007DAD4 File Offset: 0x0007BCD4
		private void ProcessNewChange(VisualElement ve)
		{
			this.m_CurrentChangeElement = ve;
			this.m_CurrentChangeParent = ve.parent;
			bool flag = this.m_CurrentChangeParent == null && ve.panel != null;
			if (flag)
			{
				this.OnHierarchyChange(this.m_CurrentChangeElement, HierarchyChangeType.Move);
				this.m_State = BaseVisualTreeHierarchyTrackerUpdater.State.Waiting;
			}
			else
			{
				this.m_State = ((this.m_CurrentChangeParent == null) ? BaseVisualTreeHierarchyTrackerUpdater.State.TrackingRemove : BaseVisualTreeHierarchyTrackerUpdater.State.TrackingAddOrMove);
			}
		}

		// Token: 0x0600213F RID: 8511 RVA: 0x0007DB3C File Offset: 0x0007BD3C
		private void ProcessAddOrMove(VisualElement ve)
		{
			Debug.Assert(this.m_CurrentChangeParent != null);
			bool flag = this.m_CurrentChangeParent == ve;
			if (flag)
			{
				this.OnHierarchyChange(this.m_CurrentChangeElement, HierarchyChangeType.Add);
				this.m_State = BaseVisualTreeHierarchyTrackerUpdater.State.Waiting;
			}
			else
			{
				this.OnHierarchyChange(this.m_CurrentChangeElement, HierarchyChangeType.Move);
				this.ProcessNewChange(ve);
			}
		}

		// Token: 0x06002140 RID: 8512 RVA: 0x0007DB98 File Offset: 0x0007BD98
		private void ProcessRemove(VisualElement ve)
		{
			this.OnHierarchyChange(this.m_CurrentChangeElement, HierarchyChangeType.Remove);
			bool flag = ve.panel != null;
			if (flag)
			{
				this.m_CurrentChangeParent = null;
				this.m_CurrentChangeElement = null;
				this.m_State = BaseVisualTreeHierarchyTrackerUpdater.State.Waiting;
			}
			else
			{
				this.m_CurrentChangeElement = ve;
			}
		}

		// Token: 0x04000E13 RID: 3603
		private BaseVisualTreeHierarchyTrackerUpdater.State m_State = BaseVisualTreeHierarchyTrackerUpdater.State.Waiting;

		// Token: 0x04000E14 RID: 3604
		private VisualElement m_CurrentChangeElement;

		// Token: 0x04000E15 RID: 3605
		private VisualElement m_CurrentChangeParent;

		// Token: 0x02000413 RID: 1043
		private enum State
		{
			// Token: 0x04000E17 RID: 3607
			Waiting,
			// Token: 0x04000E18 RID: 3608
			TrackingAddOrMove,
			// Token: 0x04000E19 RID: 3609
			TrackingRemove
		}
	}
}
