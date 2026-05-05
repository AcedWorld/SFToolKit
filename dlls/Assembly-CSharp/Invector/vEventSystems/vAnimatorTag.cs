using System;
using UnityEngine;

namespace Invector.vEventSystems
{
	// Token: 0x020003D6 RID: 982
	public class vAnimatorTag : vAnimatorTagBase
	{
		// Token: 0x0600137A RID: 4986 RVA: 0x00065988 File Offset: 0x00063B88
		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			base.OnStateEnter(animator, stateInfo, layerIndex);
			if (this.stateInfos != null)
			{
				for (int i = 0; i < this.tags.Length; i++)
				{
					for (int j = 0; j < this.stateInfos.Count; j++)
					{
						this.stateInfos[j].AddStateInfo(this.tags[i], layerIndex);
					}
				}
			}
			this.OnStateEnterEvent(this.tags.vToList<string>());
		}

		// Token: 0x0600137B RID: 4987 RVA: 0x000659FC File Offset: 0x00063BFC
		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			base.OnStateUpdate(animator, stateInfo, layerIndex);
			if (this.stateInfos != null)
			{
				for (int i = 0; i < this.stateInfos.Count; i++)
				{
					this.stateInfos[i].UpdateStateInfo(layerIndex, stateInfo.normalizedTime, stateInfo.shortNameHash);
				}
			}
		}

		// Token: 0x0600137C RID: 4988 RVA: 0x00065A50 File Offset: 0x00063C50
		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (this.stateInfos != null)
			{
				for (int i = 0; i < this.tags.Length; i++)
				{
					for (int j = 0; j < this.stateInfos.Count; j++)
					{
						this.stateInfos[j].RemoveStateInfo(this.tags[i], layerIndex);
					}
				}
			}
			base.OnStateExit(animator, stateInfo, layerIndex);
			this.OnStateExitEvent(this.tags.vToList<string>());
		}

		// Token: 0x04001922 RID: 6434
		public string[] tags = new string[]
		{
			"CustomAction"
		};
	}
}
