using System;
using Invector.vEventSystems;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000347 RID: 839
	public static class vAnimatorEventExtencion
	{
		// Token: 0x0600113E RID: 4414 RVA: 0x0005D7E0 File Offset: 0x0005B9E0
		public static void RegisterEvent(this Animator animator, string eventName, vAnimatorEvent.OnTriggerEvent onTriggerEventAction)
		{
			if (animator)
			{
				vAnimatorEvent[] behaviours = animator.GetBehaviours<vAnimatorEvent>();
				for (int i = 0; i < behaviours.Length; i++)
				{
					if (behaviours[i].HasEvent(eventName))
					{
						behaviours[i].RegisterEvents(eventName, onTriggerEventAction);
					}
				}
			}
		}

		// Token: 0x0600113F RID: 4415 RVA: 0x0005D820 File Offset: 0x0005BA20
		public static void RemoveEvent(this Animator animator, string eventName, vAnimatorEvent.OnTriggerEvent onTriggerEventAction)
		{
			if (animator)
			{
				vAnimatorEvent[] behaviours = animator.GetBehaviours<vAnimatorEvent>();
				for (int i = 0; i < behaviours.Length; i++)
				{
					if (behaviours[i].HasEvent(eventName))
					{
						behaviours[i].RemoveEvents(eventName, onTriggerEventAction);
					}
				}
			}
		}
	}
}
