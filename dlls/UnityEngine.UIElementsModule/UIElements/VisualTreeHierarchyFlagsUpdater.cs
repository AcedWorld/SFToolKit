using System;
using Unity.Profiling;

namespace UnityEngine.UIElements
{
	// Token: 0x02000410 RID: 1040
	internal class VisualTreeHierarchyFlagsUpdater : BaseVisualTreeUpdater
	{
		// Token: 0x170007B0 RID: 1968
		// (get) Token: 0x06002134 RID: 8500 RVA: 0x0007D831 File Offset: 0x0007BA31
		public override ProfilerMarker profilerMarker
		{
			get
			{
				return VisualTreeHierarchyFlagsUpdater.s_ProfilerMarker;
			}
		}

		// Token: 0x06002135 RID: 8501 RVA: 0x0007D838 File Offset: 0x0007BA38
		public override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType)
		{
			bool flag = (versionChangeType & (VersionChangeType.Hierarchy | VersionChangeType.Overflow | VersionChangeType.BorderWidth | VersionChangeType.Transform | VersionChangeType.Size | VersionChangeType.EventCallbackCategories | VersionChangeType.Picking)) == (VersionChangeType)0;
			if (!flag)
			{
				bool flag2 = (versionChangeType & VersionChangeType.Transform) > (VersionChangeType)0;
				bool flag3 = (versionChangeType & (VersionChangeType.Overflow | VersionChangeType.BorderWidth | VersionChangeType.Transform | VersionChangeType.Size)) > (VersionChangeType)0;
				bool flag4 = (versionChangeType & (VersionChangeType.Hierarchy | VersionChangeType.EventCallbackCategories)) > (VersionChangeType)0;
				VisualElementFlags visualElementFlags = (flag2 ? (VisualElementFlags.WorldTransformDirty | VisualElementFlags.WorldBoundingBoxDirty) : ((VisualElementFlags)0)) | (flag3 ? VisualElementFlags.WorldClipDirty : ((VisualElementFlags)0)) | (flag4 ? VisualElementFlags.EventCallbackParentCategoriesDirty : ((VisualElementFlags)0));
				VisualElementFlags visualElementFlags2 = visualElementFlags & ~ve.m_Flags;
				bool flag5 = visualElementFlags2 > (VisualElementFlags)0;
				if (flag5)
				{
					VisualTreeHierarchyFlagsUpdater.DirtyHierarchy(ve, visualElementFlags2);
				}
				VisualTreeHierarchyFlagsUpdater.DirtyBoundingBoxHierarchy(ve);
				this.m_Version += 1U;
			}
		}

		// Token: 0x06002136 RID: 8502 RVA: 0x0007D8CC File Offset: 0x0007BACC
		private static void DirtyHierarchy(VisualElement ve, VisualElementFlags mustDirtyFlags)
		{
			ve.m_Flags |= mustDirtyFlags;
			int childCount = ve.hierarchy.childCount;
			for (int i = 0; i < childCount; i++)
			{
				VisualElement visualElement = ve.hierarchy[i];
				VisualElementFlags visualElementFlags = mustDirtyFlags & ~visualElement.m_Flags;
				bool flag = visualElementFlags > (VisualElementFlags)0;
				if (flag)
				{
					VisualTreeHierarchyFlagsUpdater.DirtyHierarchy(visualElement, visualElementFlags);
				}
			}
		}

		// Token: 0x06002137 RID: 8503 RVA: 0x0007D93C File Offset: 0x0007BB3C
		private static void DirtyBoundingBoxHierarchy(VisualElement ve)
		{
			ve.isBoundingBoxDirty = true;
			ve.isWorldBoundingBoxDirty = true;
			VisualElement parent = ve.hierarchy.parent;
			while (parent != null && !parent.isBoundingBoxDirty)
			{
				parent.isBoundingBoxDirty = true;
				parent.isWorldBoundingBoxDirty = true;
				parent = parent.hierarchy.parent;
			}
		}

		// Token: 0x06002138 RID: 8504 RVA: 0x0007D9A0 File Offset: 0x0007BBA0
		public override void Update()
		{
			bool flag = this.m_Version == this.m_LastVersion;
			if (!flag)
			{
				this.m_LastVersion = this.m_Version;
				base.panel.UpdateElementUnderPointers();
				base.panel.visualTree.UpdateBoundingBox();
			}
		}

		// Token: 0x04000E0B RID: 3595
		private uint m_Version = 0U;

		// Token: 0x04000E0C RID: 3596
		private uint m_LastVersion = 0U;

		// Token: 0x04000E0D RID: 3597
		private static readonly string s_Description = "Update Hierarchy Flags";

		// Token: 0x04000E0E RID: 3598
		private static readonly ProfilerMarker s_ProfilerMarker = new ProfilerMarker(VisualTreeHierarchyFlagsUpdater.s_Description);
	}
}
