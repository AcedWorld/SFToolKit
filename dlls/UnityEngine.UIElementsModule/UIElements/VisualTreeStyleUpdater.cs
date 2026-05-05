using System;
using System.Collections.Generic;
using Unity.Profiling;

namespace UnityEngine.UIElements
{
	// Token: 0x02000415 RID: 1045
	internal class VisualTreeStyleUpdater : BaseVisualTreeUpdater
	{
		// Token: 0x170007B1 RID: 1969
		// (get) Token: 0x0600214A RID: 8522 RVA: 0x0007DD28 File Offset: 0x0007BF28
		// (set) Token: 0x0600214B RID: 8523 RVA: 0x0007DD30 File Offset: 0x0007BF30
		public VisualTreeStyleUpdaterTraversal traversal
		{
			get
			{
				return this.m_StyleContextHierarchyTraversal;
			}
			set
			{
				this.m_StyleContextHierarchyTraversal = value;
				BaseVisualElementPanel panel = base.panel;
				if (panel != null)
				{
					panel.visualTree.IncrementVersion(VersionChangeType.Layout | VersionChangeType.StyleSheet | VersionChangeType.Styles | VersionChangeType.Transform);
				}
			}
		}

		// Token: 0x170007B2 RID: 1970
		// (get) Token: 0x0600214C RID: 8524 RVA: 0x0007DD56 File Offset: 0x0007BF56
		public override ProfilerMarker profilerMarker
		{
			get
			{
				return VisualTreeStyleUpdater.s_ProfilerMarker;
			}
		}

		// Token: 0x0600214D RID: 8525 RVA: 0x0007DD60 File Offset: 0x0007BF60
		public override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType)
		{
			bool flag = (versionChangeType & (VersionChangeType.StyleSheet | VersionChangeType.TransitionProperty)) == (VersionChangeType)0;
			if (!flag)
			{
				this.m_Version += 1U;
				bool flag2 = (versionChangeType & VersionChangeType.StyleSheet) > (VersionChangeType)0;
				if (flag2)
				{
					bool isApplyingStyles = this.m_IsApplyingStyles;
					if (isApplyingStyles)
					{
						this.m_ApplyStyleUpdateList.Add(ve);
					}
					else
					{
						this.m_StyleContextHierarchyTraversal.AddChangedElement(ve, versionChangeType);
					}
				}
				bool flag3 = (versionChangeType & VersionChangeType.TransitionProperty) > (VersionChangeType)0;
				if (flag3)
				{
					this.m_TransitionPropertyUpdateList.Add(ve);
				}
			}
		}

		// Token: 0x0600214E RID: 8526 RVA: 0x0007DDE4 File Offset: 0x0007BFE4
		public override void Update()
		{
			bool flag = this.m_Version == this.m_LastVersion;
			if (!flag)
			{
				this.m_LastVersion = this.m_Version;
				this.ApplyStyles();
				this.m_StyleContextHierarchyTraversal.Clear();
				foreach (VisualElement ve in this.m_ApplyStyleUpdateList)
				{
					this.m_StyleContextHierarchyTraversal.AddChangedElement(ve, VersionChangeType.StyleSheet);
				}
				this.m_ApplyStyleUpdateList.Clear();
				foreach (VisualElement visualElement in this.m_TransitionPropertyUpdateList)
				{
					bool flag2 = visualElement.hasRunningAnimations || visualElement.hasCompletedAnimations;
					if (flag2)
					{
						ComputedTransitionUtils.UpdateComputedTransitions(visualElement.computedStyle);
						this.m_StyleContextHierarchyTraversal.CancelAnimationsWithNoTransitionProperty(visualElement, visualElement.computedStyle);
					}
				}
				this.m_TransitionPropertyUpdateList.Clear();
			}
		}

		// Token: 0x170007B3 RID: 1971
		// (get) Token: 0x0600214F RID: 8527 RVA: 0x0007DF10 File Offset: 0x0007C110
		// (set) Token: 0x06002150 RID: 8528 RVA: 0x0007DF18 File Offset: 0x0007C118
		private protected bool disposed { protected get; private set; }

		// Token: 0x06002151 RID: 8529 RVA: 0x0007DF24 File Offset: 0x0007C124
		protected override void Dispose(bool disposing)
		{
			bool disposed = this.disposed;
			if (!disposed)
			{
				if (disposing)
				{
					this.m_StyleContextHierarchyTraversal.Clear();
				}
				this.disposed = true;
			}
		}

		// Token: 0x06002152 RID: 8530 RVA: 0x0007DF58 File Offset: 0x0007C158
		private void ApplyStyles()
		{
			Debug.Assert(base.visualTree.panel != null);
			this.m_IsApplyingStyles = true;
			this.m_StyleContextHierarchyTraversal.PrepareTraversal(base.panel.scaledPixelsPerPoint);
			this.m_StyleContextHierarchyTraversal.Traverse(base.visualTree);
			this.m_IsApplyingStyles = false;
		}

		// Token: 0x04000E1D RID: 3613
		private HashSet<VisualElement> m_ApplyStyleUpdateList = new HashSet<VisualElement>();

		// Token: 0x04000E1E RID: 3614
		private HashSet<VisualElement> m_TransitionPropertyUpdateList = new HashSet<VisualElement>();

		// Token: 0x04000E1F RID: 3615
		private bool m_IsApplyingStyles = false;

		// Token: 0x04000E20 RID: 3616
		private uint m_Version = 0U;

		// Token: 0x04000E21 RID: 3617
		private uint m_LastVersion = 0U;

		// Token: 0x04000E22 RID: 3618
		private VisualTreeStyleUpdaterTraversal m_StyleContextHierarchyTraversal = new VisualTreeStyleUpdaterTraversal();

		// Token: 0x04000E23 RID: 3619
		private static readonly string s_Description = "Update Style";

		// Token: 0x04000E24 RID: 3620
		private static readonly ProfilerMarker s_ProfilerMarker = new ProfilerMarker(VisualTreeStyleUpdater.s_Description);
	}
}
