using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x0200022E RID: 558
	internal class PropagationPaths
	{
		// Token: 0x0600101D RID: 4125 RVA: 0x0003B043 File Offset: 0x00039243
		public PropagationPaths()
		{
			this.trickleDownPath = new List<VisualElement>(16);
			this.targetElements = new List<VisualElement>(4);
			this.bubbleUpPath = new List<VisualElement>(16);
		}

		// Token: 0x0600101E RID: 4126 RVA: 0x0003B073 File Offset: 0x00039273
		public PropagationPaths(PropagationPaths paths)
		{
			this.trickleDownPath = new List<VisualElement>(paths.trickleDownPath);
			this.targetElements = new List<VisualElement>(paths.targetElements);
			this.bubbleUpPath = new List<VisualElement>(paths.bubbleUpPath);
		}

		// Token: 0x0600101F RID: 4127 RVA: 0x0003B0B0 File Offset: 0x000392B0
		internal static PropagationPaths Copy(PropagationPaths paths)
		{
			PropagationPaths propagationPaths = PropagationPaths.s_Pool.Get();
			propagationPaths.trickleDownPath.AddRange(paths.trickleDownPath);
			propagationPaths.targetElements.AddRange(paths.targetElements);
			propagationPaths.bubbleUpPath.AddRange(paths.bubbleUpPath);
			return propagationPaths;
		}

		// Token: 0x06001020 RID: 4128 RVA: 0x0003B104 File Offset: 0x00039304
		public static PropagationPaths Build(VisualElement elem, EventBase evt)
		{
			PropagationPaths propagationPaths = PropagationPaths.s_Pool.Get();
			EventCategory eventCategory = evt.eventCategory;
			bool flag = elem.HasEventCallbacksOrDefaultActions(eventCategory);
			if (flag)
			{
				propagationPaths.targetElements.Add(elem);
			}
			for (VisualElement nextParentWithEventCallback = elem.nextParentWithEventCallback; nextParentWithEventCallback != null; nextParentWithEventCallback = nextParentWithEventCallback.nextParentWithEventCallback)
			{
				bool flag2 = nextParentWithEventCallback.isCompositeRoot && !evt.ignoreCompositeRoots;
				if (flag2)
				{
					bool flag3 = nextParentWithEventCallback.HasEventCallbacksOrDefaultActions(eventCategory);
					if (flag3)
					{
						propagationPaths.targetElements.Add(nextParentWithEventCallback);
					}
				}
				else
				{
					bool flag4 = nextParentWithEventCallback.HasEventCallbacks(eventCategory);
					if (flag4)
					{
						bool flag5 = evt.tricklesDown && nextParentWithEventCallback.HasTrickleDownHandlers();
						if (flag5)
						{
							propagationPaths.trickleDownPath.Add(nextParentWithEventCallback);
						}
						bool flag6 = evt.bubbles && nextParentWithEventCallback.HasBubbleUpHandlers();
						if (flag6)
						{
							propagationPaths.bubbleUpPath.Add(nextParentWithEventCallback);
						}
					}
				}
			}
			return propagationPaths;
		}

		// Token: 0x06001021 RID: 4129 RVA: 0x0003B1F8 File Offset: 0x000393F8
		public void Release()
		{
			this.bubbleUpPath.Clear();
			this.targetElements.Clear();
			this.trickleDownPath.Clear();
			PropagationPaths.s_Pool.Release(this);
		}

		// Token: 0x04000723 RID: 1827
		private static readonly ObjectPool<PropagationPaths> s_Pool = new ObjectPool<PropagationPaths>(() => new PropagationPaths(), 100);

		// Token: 0x04000724 RID: 1828
		public readonly List<VisualElement> trickleDownPath;

		// Token: 0x04000725 RID: 1829
		public readonly List<VisualElement> targetElements;

		// Token: 0x04000726 RID: 1830
		public readonly List<VisualElement> bubbleUpPath;

		// Token: 0x04000727 RID: 1831
		private const int k_DefaultPropagationDepth = 16;

		// Token: 0x04000728 RID: 1832
		private const int k_DefaultTargetCount = 4;

		// Token: 0x0200022F RID: 559
		[Flags]
		public enum Type
		{
			// Token: 0x0400072A RID: 1834
			None = 0,
			// Token: 0x0400072B RID: 1835
			TrickleDown = 1,
			// Token: 0x0400072C RID: 1836
			BubbleUp = 2
		}
	}
}
