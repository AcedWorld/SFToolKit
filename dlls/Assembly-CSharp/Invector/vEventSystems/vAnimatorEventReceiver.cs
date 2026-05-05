using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Invector.vEventSystems
{
	// Token: 0x020003D3 RID: 979
	[vClassHeader("Animator Event Receiver", true, "icon_v2", false, "")]
	public class vAnimatorEventReceiver : vMonoBehaviour
	{
		// Token: 0x06001370 RID: 4976 RVA: 0x00065618 File Offset: 0x00063818
		private void Start()
		{
			this.RegisterEvents();
		}

		// Token: 0x06001371 RID: 4977 RVA: 0x00065620 File Offset: 0x00063820
		private void OnDisable()
		{
			this.RemoveEvents();
		}

		// Token: 0x06001372 RID: 4978 RVA: 0x00065628 File Offset: 0x00063828
		public void OnEnable()
		{
			if (this.hasAnimator && this.hasValidBehaviours)
			{
				this.RemoveEvents();
				this.RegisterEvents();
			}
		}

		// Token: 0x06001373 RID: 4979 RVA: 0x00065620 File Offset: 0x00063820
		private void OnDestroy()
		{
			this.RemoveEvents();
		}

		// Token: 0x06001374 RID: 4980 RVA: 0x00065648 File Offset: 0x00063848
		public virtual void RegisterEvents()
		{
			if (this.animatorEvents.Count > 0)
			{
				Animator animator = this.getAnimatorInParent ? base.GetComponentInParent<Animator>() : base.GetComponent<Animator>();
				if (animator)
				{
					this.hasAnimator = true;
					Invector.vEventSystems.vAnimatorEvent[] behaviours = animator.GetBehaviours<Invector.vEventSystems.vAnimatorEvent>();
					for (int i = 0; i < this.animatorEvents.Count; i++)
					{
						bool flag = false;
						for (int j = 0; j < behaviours.Length; j++)
						{
							if (behaviours[j].HasEvent(this.animatorEvents[i].eventName))
							{
								behaviours[j].RegisterEvents(this.animatorEvents[i].eventName, new Invector.vEventSystems.vAnimatorEvent.OnTriggerEvent(this.animatorEvents[i].OnTriggerEvent));
								if (this.animatorEvents[i].debug)
								{
									Debug.Log(string.Concat(new string[]
									{
										"<color=green>",
										base.gameObject.name,
										" Register event : ",
										this.animatorEvents[i].eventName,
										"</color> in the ",
										animator.gameObject.name
									}), base.gameObject);
								}
								this.hasValidBehaviours = true;
								flag = true;
							}
						}
						if (!flag && this.animatorEvents[i].debug)
						{
							Debug.LogWarning(animator.gameObject.name + " Animator doesn't have Event with name: " + this.animatorEvents[i].eventName, base.gameObject);
						}
					}
					return;
				}
				Debug.LogWarning("Can't Find Animator to register Events in " + base.gameObject.name + (this.getAnimatorInParent ? " Parent" : ""), base.gameObject);
			}
		}

		// Token: 0x06001375 RID: 4981 RVA: 0x00065814 File Offset: 0x00063A14
		public virtual void RemoveEvents()
		{
			if (!this.hasAnimator || !this.hasValidBehaviours)
			{
				return;
			}
			if (this.animatorEvents.Count > 0)
			{
				Animator animator = this.getAnimatorInParent ? base.GetComponentInParent<Animator>() : base.GetComponent<Animator>();
				if (animator)
				{
					Invector.vEventSystems.vAnimatorEvent[] behaviours = animator.GetBehaviours<Invector.vEventSystems.vAnimatorEvent>();
					for (int i = 0; i < this.animatorEvents.Count; i++)
					{
						for (int j = 0; j < behaviours.Length; j++)
						{
							if (behaviours[j].HasEvent(this.animatorEvents[i].eventName))
							{
								behaviours[j].RemoveEvents(this.animatorEvents[i].eventName, new Invector.vEventSystems.vAnimatorEvent.OnTriggerEvent(this.animatorEvents[i].OnTriggerEvent));
								if (this.animatorEvents[i].debug)
								{
									Debug.Log(string.Concat(new string[]
									{
										"<color=red>",
										base.gameObject.name,
										" Remove event : ",
										this.animatorEvents[i].eventName,
										"</color> Of the ",
										animator.gameObject.name
									}), base.gameObject);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0400191B RID: 6427
		[Tooltip("Check this option if the Animator component is on the parent of this GameObject")]
		public bool getAnimatorInParent;

		// Token: 0x0400191C RID: 6428
		[vHelpBox("Use <b>vAnimatorEvent</b> on a AnimatorState to trigger a Event below", vHelpBoxAttribute.MessageType.Info)]
		public List<vAnimatorEventReceiver.vAnimatorEvent> animatorEvents;

		// Token: 0x0400191D RID: 6429
		private bool hasValidBehaviours;

		// Token: 0x0400191E RID: 6430
		private bool hasAnimator;

		// Token: 0x020003D4 RID: 980
		[Serializable]
		public class vAnimatorEvent
		{
			// Token: 0x06001377 RID: 4983 RVA: 0x0006595C File Offset: 0x00063B5C
			public virtual void OnTriggerEvent(string eventName)
			{
				if (this.debug)
				{
					Debug.Log("<color=green><b>Event " + eventName + " was called</b></color>");
				}
				this.onTriggerEvent.Invoke(eventName);
			}

			// Token: 0x0400191F RID: 6431
			public string eventName;

			// Token: 0x04001920 RID: 6432
			public bool debug;

			// Token: 0x04001921 RID: 6433
			public vAnimatorEventReceiver.vAnimatorEvent.StateEvent onTriggerEvent;

			// Token: 0x020003D5 RID: 981
			[Serializable]
			public class StateEvent : UnityEvent<string>
			{
			}
		}
	}
}
