using System;
using System.Collections.Generic;
using Unity.Profiling;

namespace UnityEngine.UIElements
{
	// Token: 0x0200041E RID: 1054
	internal class VisualTreeViewDataUpdater : BaseVisualTreeUpdater
	{
		// Token: 0x170007BE RID: 1982
		// (get) Token: 0x0600218C RID: 8588 RVA: 0x0007EE7B File Offset: 0x0007D07B
		public override ProfilerMarker profilerMarker
		{
			get
			{
				return VisualTreeViewDataUpdater.s_ProfilerMarker;
			}
		}

		// Token: 0x0600218D RID: 8589 RVA: 0x0007EE84 File Offset: 0x0007D084
		public override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType)
		{
			bool flag = (versionChangeType & VersionChangeType.ViewData) != VersionChangeType.ViewData;
			if (!flag)
			{
				this.m_Version += 1U;
				this.m_UpdateList.Add(ve);
				this.PropagateToParents(ve);
			}
		}

		// Token: 0x0600218E RID: 8590 RVA: 0x0007EEC4 File Offset: 0x0007D0C4
		public override void Update()
		{
			bool flag = this.m_Version == this.m_LastVersion;
			if (!flag)
			{
				int num = 0;
				while (this.m_LastVersion != this.m_Version)
				{
					this.m_LastVersion = this.m_Version;
					this.ValidateViewDataOnSubTree(base.visualTree, true);
					num++;
					bool flag2 = num > 5;
					if (flag2)
					{
						string str = "UIElements: Too many children recursively added that rely on persistent view data: ";
						VisualElement visualTree = base.visualTree;
						Debug.LogError(str + ((visualTree != null) ? visualTree.ToString() : null));
						break;
					}
				}
				this.m_UpdateList.Clear();
				this.m_ParentList.Clear();
			}
		}

		// Token: 0x0600218F RID: 8591 RVA: 0x0007EF64 File Offset: 0x0007D164
		private void ValidateViewDataOnSubTree(VisualElement ve, bool enablePersistence)
		{
			enablePersistence = ve.IsViewDataPersitenceSupportedOnChildren(enablePersistence);
			bool flag = this.m_UpdateList.Contains(ve);
			if (flag)
			{
				this.m_UpdateList.Remove(ve);
				ve.OnViewDataReady(enablePersistence);
			}
			bool flag2 = this.m_ParentList.Contains(ve);
			if (flag2)
			{
				this.m_ParentList.Remove(ve);
				int childCount = ve.hierarchy.childCount;
				for (int i = 0; i < childCount; i++)
				{
					this.ValidateViewDataOnSubTree(ve.hierarchy[i], enablePersistence);
				}
			}
		}

		// Token: 0x06002190 RID: 8592 RVA: 0x0007F000 File Offset: 0x0007D200
		private void PropagateToParents(VisualElement ve)
		{
			for (VisualElement parent = ve.hierarchy.parent; parent != null; parent = parent.hierarchy.parent)
			{
				bool flag = !this.m_ParentList.Add(parent);
				if (flag)
				{
					break;
				}
			}
		}

		// Token: 0x04000E43 RID: 3651
		private HashSet<VisualElement> m_UpdateList = new HashSet<VisualElement>();

		// Token: 0x04000E44 RID: 3652
		private HashSet<VisualElement> m_ParentList = new HashSet<VisualElement>();

		// Token: 0x04000E45 RID: 3653
		private const int kMaxValidatePersistentDataCount = 5;

		// Token: 0x04000E46 RID: 3654
		private uint m_Version = 0U;

		// Token: 0x04000E47 RID: 3655
		private uint m_LastVersion = 0U;

		// Token: 0x04000E48 RID: 3656
		private static readonly string s_Description = "Update ViewData";

		// Token: 0x04000E49 RID: 3657
		private static readonly ProfilerMarker s_ProfilerMarker = new ProfilerMarker(VisualTreeViewDataUpdater.s_Description);
	}
}
