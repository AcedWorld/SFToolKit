using System;
using System.Collections.Generic;
using UnityEngine;

namespace Invector.vEventSystems
{
	// Token: 0x020003CC RID: 972
	public class vAnimatorEvent : StateMachineBehaviour
	{
		// Token: 0x06001359 RID: 4953 RVA: 0x000652B0 File Offset: 0x000634B0
		public bool HasEvent(string eventName)
		{
			return this.eventTriggers.Exists((vAnimatorEvent.vAnimatorEventTrigger e) => e.eventName.Equals(eventName));
		}

		// Token: 0x0600135A RID: 4954 RVA: 0x000652E4 File Offset: 0x000634E4
		public void RegisterEvents(string eventName, vAnimatorEvent.OnTriggerEvent onTriggerEvent)
		{
			List<vAnimatorEvent.vAnimatorEventTrigger> list = this.eventTriggers.FindAll((vAnimatorEvent.vAnimatorEventTrigger e) => e.eventName.Equals(eventName));
			for (int i = 0; i < list.Count; i++)
			{
				list[i].onTriggerEvent -= onTriggerEvent;
				list[i].onTriggerEvent += onTriggerEvent;
			}
		}

		// Token: 0x0600135B RID: 4955 RVA: 0x00065344 File Offset: 0x00063544
		public void RemoveEvents(string eventName, vAnimatorEvent.OnTriggerEvent onTriggerEvent)
		{
			List<vAnimatorEvent.vAnimatorEventTrigger> list = this.eventTriggers.FindAll((vAnimatorEvent.vAnimatorEventTrigger e) => e.eventName.Equals(eventName));
			for (int i = 0; i < list.Count; i++)
			{
				list[i].onTriggerEvent -= onTriggerEvent;
			}
		}

		// Token: 0x0600135C RID: 4956 RVA: 0x00065394 File Offset: 0x00063594
		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			for (int i = 0; i < this.eventTriggers.Count; i++)
			{
				if (this.eventTriggers[i].eventTriggerType == vAnimatorEvent.vAnimatorEventTrigger.vAnimatorEventTriggerType.EnterState)
				{
					this.eventTriggers[i].TriggerEvent();
				}
				else if (this.eventTriggers[i].eventTriggerType == vAnimatorEvent.vAnimatorEventTrigger.vAnimatorEventTriggerType.NormalizedTime)
				{
					this.hasNormalizedEvents = true;
					this.eventTriggers[i].Init();
					this.eventTriggers[i].UpdateEventTrigger(stateInfo.normalizedTime);
				}
			}
		}

		// Token: 0x0600135D RID: 4957 RVA: 0x00065424 File Offset: 0x00063624
		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if ((!stateInfo.loop && stateInfo.normalizedTime > 1f) || !this.hasNormalizedEvents)
			{
				return;
			}
			for (int i = 0; i < this.eventTriggers.Count; i++)
			{
				if (this.eventTriggers[i].eventTriggerType == vAnimatorEvent.vAnimatorEventTrigger.vAnimatorEventTriggerType.NormalizedTime)
				{
					this.eventTriggers[i].UpdateEventTrigger(stateInfo.normalizedTime);
				}
			}
		}

		// Token: 0x0600135E RID: 4958 RVA: 0x00065494 File Offset: 0x00063694
		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			for (int i = 0; i < this.eventTriggers.Count; i++)
			{
				if (this.eventTriggers[i].eventTriggerType == vAnimatorEvent.vAnimatorEventTrigger.vAnimatorEventTriggerType.ExitState)
				{
					this.eventTriggers[i].TriggerEvent();
				}
			}
		}

		// Token: 0x0400190D RID: 6413
		public List<vAnimatorEvent.vAnimatorEventTrigger> eventTriggers;

		// Token: 0x0400190E RID: 6414
		protected bool hasNormalizedEvents;

		// Token: 0x020003CD RID: 973
		[Serializable]
		public class vAnimatorEventTrigger
		{
			// Token: 0x14000005 RID: 5
			// (add) Token: 0x06001360 RID: 4960 RVA: 0x000654DC File Offset: 0x000636DC
			// (remove) Token: 0x06001361 RID: 4961 RVA: 0x00065514 File Offset: 0x00063714
			public event vAnimatorEvent.OnTriggerEvent onTriggerEvent;

			// Token: 0x06001362 RID: 4962 RVA: 0x0006554C File Offset: 0x0006374C
			public void UpdateEventTrigger(float normalizedTime)
			{
				if (Mathf.Clamp(normalizedTime, 0f, (float)this.loopCount + 1f) >= (float)this.loopCount + this.normalizedTime)
				{
					if (this.onTriggerEvent != null)
					{
						this.onTriggerEvent(this.eventName);
					}
					this.loopCount++;
				}
			}

			// Token: 0x06001363 RID: 4963 RVA: 0x000655A8 File Offset: 0x000637A8
			public void TriggerEvent()
			{
				if (this.onTriggerEvent != null)
				{
					this.onTriggerEvent(this.eventName);
				}
			}

			// Token: 0x06001364 RID: 4964 RVA: 0x000655C3 File Offset: 0x000637C3
			public void Init()
			{
				this.loopCount = 0;
			}

			// Token: 0x0400190F RID: 6415
			public string eventName = "New Event";

			// Token: 0x04001910 RID: 6416
			public vAnimatorEvent.vAnimatorEventTrigger.vAnimatorEventTriggerType eventTriggerType;

			// Token: 0x04001911 RID: 6417
			public float normalizedTime;

			// Token: 0x04001912 RID: 6418
			private int loopCount;

			// Token: 0x020003CE RID: 974
			public enum vAnimatorEventTriggerType
			{
				// Token: 0x04001915 RID: 6421
				NormalizedTime,
				// Token: 0x04001916 RID: 6422
				EnterState,
				// Token: 0x04001917 RID: 6423
				ExitState
			}
		}

		// Token: 0x020003CF RID: 975
		// (Invoke) Token: 0x06001367 RID: 4967
		public delegate void OnTriggerEvent(string eventName);
	}
}
