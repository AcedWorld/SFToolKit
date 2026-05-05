using System;
using System.Collections.Generic;
using UnityEngine;

namespace Invector.vEventSystems
{
	// Token: 0x020003DA RID: 986
	public abstract class vAnimatorTagBase : StateMachineBehaviour
	{
		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06001387 RID: 4999 RVA: 0x00065F88 File Offset: 0x00064188
		// (remove) Token: 0x06001388 RID: 5000 RVA: 0x00065FC0 File Offset: 0x000641C0
		public event vAnimatorTagBase.OnStateTrigger onStateEnter;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06001389 RID: 5001 RVA: 0x00065FF8 File Offset: 0x000641F8
		// (remove) Token: 0x0600138A RID: 5002 RVA: 0x00066030 File Offset: 0x00064230
		public event vAnimatorTagBase.OnStateTrigger onStateExit;

		// Token: 0x0600138B RID: 5003 RVA: 0x00066065 File Offset: 0x00064265
		public virtual void AddStateInfoListener(vAnimatorStateInfos stateInfo)
		{
			if (!this.stateInfos.Contains(stateInfo))
			{
				this.stateInfos.Add(stateInfo);
			}
		}

		// Token: 0x0600138C RID: 5004 RVA: 0x00066081 File Offset: 0x00064281
		public virtual void RemoveStateInfoListener(vAnimatorStateInfos stateInfo)
		{
			if (this.stateInfos.Contains(stateInfo))
			{
				this.stateInfos.Remove(stateInfo);
			}
		}

		// Token: 0x0600138D RID: 5005 RVA: 0x0006609E File Offset: 0x0006429E
		protected virtual void OnStateEnterEvent(List<string> tags)
		{
			if (this.onStateEnter != null)
			{
				this.onStateEnter(tags);
			}
		}

		// Token: 0x0600138E RID: 5006 RVA: 0x000660B4 File Offset: 0x000642B4
		protected virtual void OnStateExitEvent(List<string> tags)
		{
			if (this.onStateEnter != null)
			{
				this.onStateExit(tags);
			}
		}

		// Token: 0x04001930 RID: 6448
		public List<vAnimatorStateInfos> stateInfos = new List<vAnimatorStateInfos>();

		// Token: 0x020003DB RID: 987
		// (Invoke) Token: 0x06001391 RID: 5009
		public delegate void OnStateTrigger(List<string> tags);
	}
}
