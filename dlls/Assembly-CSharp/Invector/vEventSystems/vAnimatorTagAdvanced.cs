using System;
using System.Collections.Generic;
using UnityEngine;

namespace Invector.vEventSystems
{
	// Token: 0x020003D7 RID: 983
	public class vAnimatorTagAdvanced : vAnimatorTagBase
	{
		// Token: 0x0600137E RID: 4990 RVA: 0x00065AE0 File Offset: 0x00063CE0
		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			base.OnStateEnter(animator, stateInfo, layerIndex);
			if (this.stateInfos != null)
			{
				for (int i = 0; i < this.tags.Count; i++)
				{
					this.tags[i].Init(this.stateInfos, layerIndex);
					if (this.debug)
					{
						Debug.Log("Init " + this.tags[i].tagName + " OnStateEnter  ");
					}
					if (this.tags[i].tagType == vAnimatorTagAdvanced.vAnimatorEventTriggerType.EnterStateExitState || this.tags[i].tagType == vAnimatorTagAdvanced.vAnimatorEventTriggerType.EnterStateExitByNormalized)
					{
						if (this.debug)
						{
							Debug.Log("ADD TAG " + this.tags[i].tagName + " OnStateEnter  ");
						}
						this.tags[i].AddTag(this.stateInfos, layerIndex);
					}
					else
					{
						this.tags[i].UpdateEventTrigger(stateInfo.normalizedTime, this.stateInfos, layerIndex, animator.speed, stateInfo.loop, false, this.debug);
					}
				}
			}
		}

		// Token: 0x0600137F RID: 4991 RVA: 0x00065C04 File Offset: 0x00063E04
		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (this.stateInfos != null)
			{
				for (int i = 0; i < this.tags.Count; i++)
				{
					if (this.tags[i].tagType != vAnimatorTagAdvanced.vAnimatorEventTriggerType.EnterStateExitState)
					{
						this.tags[i].UpdateEventTrigger(stateInfo.normalizedTime, this.stateInfos, layerIndex, animator.speed, stateInfo.loop, false, this.debug);
					}
				}
				for (int j = 0; j < this.stateInfos.Count; j++)
				{
					this.stateInfos[j].UpdateStateInfo(layerIndex, stateInfo.normalizedTime, stateInfo.shortNameHash);
				}
			}
			base.OnStateUpdate(animator, stateInfo, layerIndex);
		}

		// Token: 0x06001380 RID: 4992 RVA: 0x00065CB8 File Offset: 0x00063EB8
		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (this.stateInfos != null)
			{
				for (int i = 0; i < this.tags.Count; i++)
				{
					if (this.tags[i].tagType == vAnimatorTagAdvanced.vAnimatorEventTriggerType.EnterStateExitState || this.tags[i].tagType == vAnimatorTagAdvanced.vAnimatorEventTriggerType.EnterByNormalizedExitState)
					{
						if (this.debug)
						{
							Debug.Log("REMOVE TAG " + this.tags[i].tagName + " OnStateExit  ");
						}
						this.tags[i].RemoveTag(this.stateInfos, layerIndex);
					}
					else
					{
						this.tags[i].UpdateEventTrigger(stateInfo.normalizedTime, this.stateInfos, layerIndex, animator.speed, stateInfo.loop, true, this.debug);
					}
				}
			}
			base.OnStateExit(animator, stateInfo, layerIndex);
		}

		// Token: 0x04001923 RID: 6435
		public bool debug;

		// Token: 0x04001924 RID: 6436
		public List<vAnimatorTagAdvanced.vAdvancedTags> tags = new List<vAnimatorTagAdvanced.vAdvancedTags>
		{
			new vAnimatorTagAdvanced.vAdvancedTags("CustomAction")
		};

		// Token: 0x020003D8 RID: 984
		public enum vAnimatorEventTriggerType
		{
			// Token: 0x04001926 RID: 6438
			AllByNormalizedTime,
			// Token: 0x04001927 RID: 6439
			EnterStateExitByNormalized,
			// Token: 0x04001928 RID: 6440
			EnterByNormalizedExitState,
			// Token: 0x04001929 RID: 6441
			EnterStateExitState
		}

		// Token: 0x020003D9 RID: 985
		[Serializable]
		public class vAdvancedTags
		{
			// Token: 0x06001382 RID: 4994 RVA: 0x00065DBA File Offset: 0x00063FBA
			public vAdvancedTags(string tag)
			{
				this.tagName = tag;
				this.tagType = vAnimatorTagAdvanced.vAnimatorEventTriggerType.AllByNormalizedTime;
			}

			// Token: 0x06001383 RID: 4995 RVA: 0x00065DE8 File Offset: 0x00063FE8
			public void UpdateEventTrigger(float normalizedTime, List<vAnimatorStateInfos> stateInfos, int layer, float speed = 1f, bool looping = false, bool inExit = false, bool debug = false)
			{
				float num = normalizedTime % 1f;
				if (!this.isEnter && !inExit && this.tagType != vAnimatorTagAdvanced.vAnimatorEventTriggerType.EnterStateExitByNormalized && this.tagType != vAnimatorTagAdvanced.vAnimatorEventTriggerType.EnterStateExitState && num >= this.normalizedTime.x)
				{
					if (debug)
					{
						Debug.Log("ADD TAG " + this.tagName + " in  " + normalizedTime.ToString());
					}
					this.AddTag(stateInfos, layer);
				}
				if (!this.isExit && this.isEnter && this.tagType != vAnimatorTagAdvanced.vAnimatorEventTriggerType.EnterByNormalizedExitState && this.tagType != vAnimatorTagAdvanced.vAnimatorEventTriggerType.EnterStateExitState && (num >= this.normalizedTime.y || inExit))
				{
					this.RemoveTag(stateInfos, layer);
					if (debug)
					{
						Debug.Log("REMOVE TAG " + this.tagName + " in  " + normalizedTime.ToString());
					}
				}
				if (looping && normalizedTime > (float)(this.loopCount + 1))
				{
					this.isEnter = false;
					this.isExit = false;
					this.loopCount++;
				}
			}

			// Token: 0x06001384 RID: 4996 RVA: 0x00065EE8 File Offset: 0x000640E8
			public void AddTag(List<vAnimatorStateInfos> stateInfos, int layer)
			{
				for (int i = 0; i < stateInfos.Count; i++)
				{
					stateInfos[i].AddStateInfo(this.tagName, layer);
				}
				this.isEnter = true;
			}

			// Token: 0x06001385 RID: 4997 RVA: 0x00065F20 File Offset: 0x00064120
			public void RemoveTag(List<vAnimatorStateInfos> stateInfos, int layer)
			{
				for (int i = 0; i < stateInfos.Count; i++)
				{
					stateInfos[i].RemoveStateInfo(this.tagName, layer);
					this.isExit = true;
				}
			}

			// Token: 0x06001386 RID: 4998 RVA: 0x00065F58 File Offset: 0x00064158
			public void Init(List<vAnimatorStateInfos> stateInfos, int layer)
			{
				if (this.isEnter && !this.isExit)
				{
					this.RemoveTag(stateInfos, layer);
				}
				this.isEnter = false;
				this.isExit = false;
				this.loopCount = 0;
			}

			// Token: 0x0400192A RID: 6442
			public string tagName;

			// Token: 0x0400192B RID: 6443
			public vAnimatorTagAdvanced.vAnimatorEventTriggerType tagType;

			// Token: 0x0400192C RID: 6444
			public Vector2 normalizedTime = new Vector2(0.1f, 0.8f);

			// Token: 0x0400192D RID: 6445
			private int loopCount;

			// Token: 0x0400192E RID: 6446
			private bool isEnter;

			// Token: 0x0400192F RID: 6447
			private bool isExit;
		}
	}
}
