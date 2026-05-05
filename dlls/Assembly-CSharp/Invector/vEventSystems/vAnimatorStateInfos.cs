using System;
using System.Collections.Generic;
using UnityEngine;

namespace Invector.vEventSystems
{
	// Token: 0x020003C8 RID: 968
	[Serializable]
	public class vAnimatorStateInfos
	{
		// Token: 0x06001348 RID: 4936 RVA: 0x00064F3A File Offset: 0x0006313A
		public vAnimatorStateInfos(Animator animator)
		{
			this.animator = animator;
			this.Init();
		}

		// Token: 0x06001349 RID: 4937 RVA: 0x00064F5C File Offset: 0x0006315C
		public void Init()
		{
			if (this.animator)
			{
				this.stateInfos = new vAnimatorStateInfos.vStateInfo[this.animator.layerCount];
				for (int i = 0; i < this.stateInfos.Length; i++)
				{
					this.stateInfos[i] = new vAnimatorStateInfos.vStateInfo(i);
				}
			}
		}

		// Token: 0x0600134A RID: 4938 RVA: 0x00064FB0 File Offset: 0x000631B0
		public void RegisterListener()
		{
			vAnimatorTagBase[] behaviours = this.animator.GetBehaviours<vAnimatorTagBase>();
			for (int i = 0; i < behaviours.Length; i++)
			{
				behaviours[i].RemoveStateInfoListener(this);
				behaviours[i].AddStateInfoListener(this);
			}
			if (this.debug)
			{
				Debug.Log("Listeners Registered", this.animator);
			}
		}

		// Token: 0x0600134B RID: 4939 RVA: 0x00065004 File Offset: 0x00063204
		public void RemoveListener()
		{
			if (this.animator)
			{
				vAnimatorTagBase[] behaviours = this.animator.GetBehaviours<vAnimatorTagBase>();
				for (int i = 0; i < behaviours.Length; i++)
				{
					behaviours[i].RemoveStateInfoListener(this);
				}
				if (this.debug)
				{
					Debug.Log("Listeners Removed", this.animator);
				}
			}
		}

		// Token: 0x0600134C RID: 4940 RVA: 0x0006505C File Offset: 0x0006325C
		public void AddStateInfo(string tag, int layer)
		{
			if (this.stateInfos.Length != 0 && layer < this.stateInfos.Length)
			{
				vAnimatorStateInfos.vStateInfo vStateInfo = this.stateInfos[layer];
				vStateInfo.tags.Add(tag);
				vStateInfo.shortPathHash = 0;
				vStateInfo.normalizedTime = 0f;
			}
			if (this.debug)
			{
				Debug.Log(string.Format("<color=green>Add tag : <b><i>{0}</i></b></color>,in the animator layer :{1}", tag, layer), this.animator);
			}
		}

		// Token: 0x0600134D RID: 4941 RVA: 0x000650C6 File Offset: 0x000632C6
		public void UpdateStateInfo(int layer, float normalizedTime, int fullPathHash)
		{
			if (this.stateInfos.Length != 0 && layer < this.stateInfos.Length)
			{
				vAnimatorStateInfos.vStateInfo vStateInfo = this.stateInfos[layer];
				vStateInfo.normalizedTime = normalizedTime;
				vStateInfo.shortPathHash = fullPathHash;
			}
		}

		// Token: 0x0600134E RID: 4942 RVA: 0x000650F4 File Offset: 0x000632F4
		public void RemoveStateInfo(string tag, int layer)
		{
			if (this.stateInfos.Length != 0 && layer < this.stateInfos.Length)
			{
				vAnimatorStateInfos.vStateInfo vStateInfo = this.stateInfos[layer];
				if (vStateInfo.tags.Contains(tag))
				{
					vStateInfo.tags.Remove(tag);
					if (vStateInfo.tags.Count == 0)
					{
						vStateInfo.shortPathHash = 0;
						vStateInfo.normalizedTime = 0f;
					}
					if (this.debug)
					{
						Debug.Log(string.Format("<color=red>Remove tag : <b><i>{0}</i></b></color>, in the animator layer :{1}", tag, layer), this.animator);
					}
				}
			}
		}

		// Token: 0x0600134F RID: 4943 RVA: 0x0006517C File Offset: 0x0006337C
		public bool HasTag(string tag)
		{
			return Array.Exists<vAnimatorStateInfos.vStateInfo>(this.stateInfos, (vAnimatorStateInfos.vStateInfo info) => info.tags.Contains(tag));
		}

		// Token: 0x06001350 RID: 4944 RVA: 0x000651B0 File Offset: 0x000633B0
		public bool HasAllTags(params string[] tags)
		{
			bool result = tags.Length != 0;
			for (int i = 0; i < tags.Length; i++)
			{
				if (!this.HasTag(tags[i]))
				{
					result = false;
					break;
				}
			}
			return result;
		}

		// Token: 0x06001351 RID: 4945 RVA: 0x000651E4 File Offset: 0x000633E4
		public bool HasAnyTag(params string[] tags)
		{
			bool result = false;
			for (int i = 0; i < tags.Length; i++)
			{
				if (this.HasTag(tags[i]))
				{
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x06001352 RID: 4946 RVA: 0x00065214 File Offset: 0x00063414
		public vAnimatorStateInfos.vStateInfo GetStateInfoUsingTag(string tag)
		{
			return Array.Find<vAnimatorStateInfos.vStateInfo>(this.stateInfos, (vAnimatorStateInfos.vStateInfo info) => info.tags.Contains(tag));
		}

		// Token: 0x06001353 RID: 4947 RVA: 0x00065245 File Offset: 0x00063445
		public float GetCurrentNormalizedTime(int layer)
		{
			if (this.stateInfos.Length != 0 && layer < this.stateInfos.Length)
			{
				return this.stateInfos[layer].normalizedTime;
			}
			return 0f;
		}

		// Token: 0x04001904 RID: 6404
		public bool debug;

		// Token: 0x04001905 RID: 6405
		public Animator animator;

		// Token: 0x04001906 RID: 6406
		public vAnimatorStateInfos.vStateInfo[] stateInfos = new vAnimatorStateInfos.vStateInfo[0];

		// Token: 0x020003C9 RID: 969
		[Serializable]
		public class vStateInfo
		{
			// Token: 0x06001354 RID: 4948 RVA: 0x0006526E File Offset: 0x0006346E
			public vStateInfo(int layer)
			{
				this.layer = layer;
			}

			// Token: 0x04001907 RID: 6407
			public int layer;

			// Token: 0x04001908 RID: 6408
			public int shortPathHash;

			// Token: 0x04001909 RID: 6409
			public float normalizedTime;

			// Token: 0x0400190A RID: 6410
			public List<string> tags = new List<string>();
		}
	}
}
