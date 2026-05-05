using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Profiling;
using UnityEngine.UIElements.Experimental;

namespace UnityEngine.UIElements
{
	// Token: 0x0200040F RID: 1039
	internal class VisualElementAnimationSystem : BaseVisualTreeUpdater
	{
		// Token: 0x06002129 RID: 8489 RVA: 0x0007D5B8 File Offset: 0x0007B7B8
		private long CurrentTimeMs()
		{
			return Panel.TimeSinceStartupMs();
		}

		// Token: 0x170007AE RID: 1966
		// (get) Token: 0x0600212A RID: 8490 RVA: 0x0007D5CF File Offset: 0x0007B7CF
		public override ProfilerMarker profilerMarker
		{
			get
			{
				return VisualElementAnimationSystem.s_ProfilerMarker;
			}
		}

		// Token: 0x170007AF RID: 1967
		// (get) Token: 0x0600212B RID: 8491 RVA: 0x0007D5D6 File Offset: 0x0007B7D6
		private static ProfilerMarker stylePropertyAnimationProfilerMarker
		{
			get
			{
				return VisualElementAnimationSystem.s_StylePropertyAnimationProfilerMarker;
			}
		}

		// Token: 0x0600212C RID: 8492 RVA: 0x0007D5DD File Offset: 0x0007B7DD
		public void UnregisterAnimation(IValueAnimationUpdate anim)
		{
			this.m_Animations.Remove(anim);
			this.m_IterationListDirty = true;
		}

		// Token: 0x0600212D RID: 8493 RVA: 0x0007D5F4 File Offset: 0x0007B7F4
		public void UnregisterAnimations(List<IValueAnimationUpdate> anims)
		{
			foreach (IValueAnimationUpdate item in anims)
			{
				this.m_Animations.Remove(item);
			}
			this.m_IterationListDirty = true;
		}

		// Token: 0x0600212E RID: 8494 RVA: 0x0007D654 File Offset: 0x0007B854
		public void RegisterAnimation(IValueAnimationUpdate anim)
		{
			this.m_Animations.Add(anim);
			this.m_HasNewAnimations = true;
			this.m_IterationListDirty = true;
		}

		// Token: 0x0600212F RID: 8495 RVA: 0x0007D674 File Offset: 0x0007B874
		public void RegisterAnimations(List<IValueAnimationUpdate> anims)
		{
			foreach (IValueAnimationUpdate item in anims)
			{
				this.m_Animations.Add(item);
			}
			this.m_HasNewAnimations = true;
			this.m_IterationListDirty = true;
		}

		// Token: 0x06002130 RID: 8496 RVA: 0x0007D6DC File Offset: 0x0007B8DC
		public override void Update()
		{
			long num = Panel.TimeSinceStartupMs();
			bool iterationListDirty = this.m_IterationListDirty;
			if (iterationListDirty)
			{
				this.m_IterationList = this.m_Animations.ToList<IValueAnimationUpdate>();
				this.m_IterationListDirty = false;
			}
			bool flag = this.m_HasNewAnimations || this.lastUpdate != num;
			if (flag)
			{
				foreach (IValueAnimationUpdate valueAnimationUpdate in this.m_IterationList)
				{
					valueAnimationUpdate.Tick(num);
				}
				this.m_HasNewAnimations = false;
				this.lastUpdate = num;
			}
			IStylePropertyAnimationSystem styleAnimationSystem = base.panel.styleAnimationSystem;
			using (VisualElementAnimationSystem.stylePropertyAnimationProfilerMarker.Auto())
			{
				styleAnimationSystem.Update();
			}
		}

		// Token: 0x06002131 RID: 8497 RVA: 0x00003CD2 File Offset: 0x00001ED2
		public override void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType)
		{
		}

		// Token: 0x04000E02 RID: 3586
		private HashSet<IValueAnimationUpdate> m_Animations = new HashSet<IValueAnimationUpdate>();

		// Token: 0x04000E03 RID: 3587
		private List<IValueAnimationUpdate> m_IterationList = new List<IValueAnimationUpdate>();

		// Token: 0x04000E04 RID: 3588
		private bool m_HasNewAnimations = false;

		// Token: 0x04000E05 RID: 3589
		private bool m_IterationListDirty = false;

		// Token: 0x04000E06 RID: 3590
		private static readonly string s_Description = "Animation Update";

		// Token: 0x04000E07 RID: 3591
		private static readonly ProfilerMarker s_ProfilerMarker = new ProfilerMarker(VisualElementAnimationSystem.s_Description);

		// Token: 0x04000E08 RID: 3592
		private static readonly string s_StylePropertyAnimationDescription = "StylePropertyAnimation Update";

		// Token: 0x04000E09 RID: 3593
		private static readonly ProfilerMarker s_StylePropertyAnimationProfilerMarker = new ProfilerMarker(VisualElementAnimationSystem.s_StylePropertyAnimationDescription);

		// Token: 0x04000E0A RID: 3594
		private long lastUpdate;
	}
}
