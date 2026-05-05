using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000058 RID: 88
	public interface IEventMachine : IMachine, IGraphRoot, IGraphParent, IGraphNester, IAotStubbable
	{
		// Token: 0x06000287 RID: 647
		void TriggerAnimationEvent(AnimationEvent animationEvent);

		// Token: 0x06000288 RID: 648
		void TriggerUnityEvent(string name);
	}
}
