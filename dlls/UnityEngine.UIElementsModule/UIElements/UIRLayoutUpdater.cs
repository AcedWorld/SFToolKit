using System;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine.Yoga;

namespace UnityEngine.UIElements
{
	// Token: 0x020002A9 RID: 681
	internal class UIRLayoutUpdater : BaseVisualTreeUpdater
	{
		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x06001399 RID: 5017 RVA: 0x000447D2 File Offset: 0x000429D2
		public override ProfilerMarker profilerMarker
		{
			get
			{
				return UIRLayoutUpdater.s_ProfilerMarker;
			}
		}

		// Token: 0x0600139A RID: 5018 RVA: 0x000447DC File Offset: 0x000429DC
		public override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType)
		{
			bool flag = (versionChangeType & (VersionChangeType.Hierarchy | VersionChangeType.Layout)) == (VersionChangeType)0;
			if (!flag)
			{
				YogaNode yogaNode = ve.yogaNode;
				bool flag2 = yogaNode != null && yogaNode.IsMeasureDefined;
				if (flag2)
				{
					yogaNode.MarkDirty();
				}
			}
		}

		// Token: 0x0600139B RID: 5019 RVA: 0x00044818 File Offset: 0x00042A18
		public override void Update()
		{
			int num = 0;
			while (base.visualTree.yogaNode.IsDirty)
			{
				this.changeEventsList.Clear();
				bool flag = num > 0;
				if (flag)
				{
					base.panel.ApplyStyles();
				}
				base.panel.duringLayoutPhase = true;
				base.visualTree.yogaNode.CalculateLayout(float.NaN, float.NaN);
				base.panel.duringLayoutPhase = false;
				this.UpdateSubTree(base.visualTree, true, this.changeEventsList);
				this.DispatchChangeEvents(this.changeEventsList, num);
				bool flag2 = num++ >= 10;
				if (flag2)
				{
					string str = "Layout update is struggling to process current layout (consider simplifying to avoid recursive layout): ";
					VisualElement visualTree = base.visualTree;
					Debug.LogError(str + ((visualTree != null) ? visualTree.ToString() : null));
					break;
				}
			}
			base.visualTree.focusController.ReevaluateFocus();
		}

		// Token: 0x0600139C RID: 5020 RVA: 0x00044904 File Offset: 0x00042B04
		private void UpdateSubTree(VisualElement ve, bool isDisplayed, List<KeyValuePair<Rect, VisualElement>> changeEvents)
		{
			Rect lastLayout = new Rect(ve.yogaNode.LayoutX, ve.yogaNode.LayoutY, ve.yogaNode.LayoutWidth, ve.yogaNode.LayoutHeight);
			Rect rect = new Rect(ve.yogaNode.LayoutPaddingLeft, ve.yogaNode.LayoutPaddingLeft, ve.yogaNode.LayoutPaddingRight, ve.yogaNode.LayoutPaddingBottom);
			Rect lastPseudoPadding = new Rect(rect.x, rect.y, lastLayout.width - (rect.x + rect.width), lastLayout.height - (rect.y + rect.height));
			Rect lastLayout2 = ve.lastLayout;
			Rect lastPseudoPadding2 = ve.lastPseudoPadding;
			bool isHierarchyDisplayed = ve.isHierarchyDisplayed;
			VersionChangeType versionChangeType = (VersionChangeType)0;
			bool flag = lastLayout2.size != lastLayout.size;
			bool flag2 = lastPseudoPadding2.size != lastPseudoPadding.size;
			bool flag3 = flag || flag2;
			if (flag3)
			{
				versionChangeType |= (VersionChangeType.Size | VersionChangeType.Repaint);
			}
			bool flag4 = lastLayout.position != lastLayout2.position;
			bool flag5 = lastPseudoPadding.position != lastPseudoPadding2.position;
			bool flag6 = flag4 || flag5;
			if (flag6)
			{
				versionChangeType |= VersionChangeType.Transform;
			}
			bool flag7 = (versionChangeType & VersionChangeType.Size) != (VersionChangeType)0 && (versionChangeType & VersionChangeType.Transform) == (VersionChangeType)0;
			if (flag7)
			{
				bool flag8 = !ve.hasDefaultRotationAndScale;
				if (flag8)
				{
					bool flag9 = !Mathf.Approximately(ve.resolvedStyle.transformOrigin.x, 0f) || !Mathf.Approximately(ve.resolvedStyle.transformOrigin.y, 0f);
					if (flag9)
					{
						versionChangeType |= VersionChangeType.Transform;
					}
				}
			}
			isDisplayed &= (ve.resolvedStyle.display != DisplayStyle.None);
			ve.isHierarchyDisplayed = isDisplayed;
			bool flag10 = versionChangeType > (VersionChangeType)0;
			if (flag10)
			{
				ve.IncrementVersion(versionChangeType);
			}
			ve.lastLayout = lastLayout;
			ve.lastPseudoPadding = lastPseudoPadding;
			bool hasNewLayout = ve.yogaNode.HasNewLayout;
			bool flag11 = hasNewLayout;
			if (flag11)
			{
				int childCount = ve.hierarchy.childCount;
				for (int i = 0; i < childCount; i++)
				{
					VisualElement visualElement = ve.hierarchy[i];
					bool hasNewLayout2 = visualElement.yogaNode.HasNewLayout;
					if (hasNewLayout2)
					{
						this.UpdateSubTree(visualElement, isDisplayed, changeEvents);
					}
				}
			}
			bool flag12 = (flag || flag4) && ve.HasEventCallbacksOrDefaultActions(EventBase<GeometryChangedEvent>.EventCategory);
			if (flag12)
			{
				changeEvents.Add(new KeyValuePair<Rect, VisualElement>(lastLayout2, ve));
			}
			bool flag13 = hasNewLayout;
			if (flag13)
			{
				ve.yogaNode.MarkLayoutSeen();
			}
		}

		// Token: 0x0600139D RID: 5021 RVA: 0x00044BC4 File Offset: 0x00042DC4
		private void DispatchChangeEvents(List<KeyValuePair<Rect, VisualElement>> changeEvents, int currentLayoutPass)
		{
			foreach (KeyValuePair<Rect, VisualElement> keyValuePair in changeEvents)
			{
				VisualElement value = keyValuePair.Value;
				using (GeometryChangedEvent pooled = GeometryChangedEvent.GetPooled(keyValuePair.Key, value.lastLayout))
				{
					pooled.layoutPass = currentLayoutPass;
					pooled.target = value;
					value.HandleEventAtTargetAndDefaultPhase(pooled);
				}
			}
		}

		// Token: 0x040008F0 RID: 2288
		private const int kMaxValidateLayoutCount = 10;

		// Token: 0x040008F1 RID: 2289
		private static readonly string s_Description = "Update Layout";

		// Token: 0x040008F2 RID: 2290
		private static readonly ProfilerMarker s_ProfilerMarker = new ProfilerMarker(UIRLayoutUpdater.s_Description);

		// Token: 0x040008F3 RID: 2291
		private List<KeyValuePair<Rect, VisualElement>> changeEventsList = new List<KeyValuePair<Rect, VisualElement>>();
	}
}
