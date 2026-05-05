using System;
using UnityEngine;

namespace Invector.vEventSystems
{
	// Token: 0x020003DC RID: 988
	public class vAnimatorTagByParamenter : vAnimatorTag
	{
		// Token: 0x06001394 RID: 5012 RVA: 0x000660DD File Offset: 0x000642DD
		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (this.paramenter == null)
			{
				this.paramenter = new vAnimatorParameter(animator, this.paramenterName);
			}
		}

		// Token: 0x06001395 RID: 5013 RVA: 0x000660F9 File Offset: 0x000642F9
		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			base.OnStateUpdate(animator, stateInfo, layerIndex);
			this.CheckForParamenter(animator, layerIndex);
		}

		// Token: 0x06001396 RID: 5014 RVA: 0x0006610C File Offset: 0x0006430C
		private void CheckForParamenter(Animator animator, int layerIndex)
		{
			if (this.paramenter.isValid)
			{
				bool flag = false;
				switch (this.paramenterType)
				{
				case vAnimatorTagByParamenter.ParamenterType.Bool:
					flag = (this.boolValue == animator.GetBool(this.paramenter));
					break;
				case vAnimatorTagByParamenter.ParamenterType.Float:
					flag = this.CompareNumber(this.floatValue, animator.GetFloat(this.paramenter), this.compare);
					break;
				case vAnimatorTagByParamenter.ParamenterType.Int:
					flag = this.CompareNumber((float)this.intValue, (float)animator.GetInteger(this.paramenter), this.compare);
					break;
				}
				if (flag != this.tagAdded)
				{
					this.tagAdded = flag;
					if (flag)
					{
						this.AddTags(layerIndex);
						return;
					}
					this.RemoveTags(layerIndex);
				}
			}
		}

		// Token: 0x06001397 RID: 5015 RVA: 0x000661D0 File Offset: 0x000643D0
		private void AddTags(int layerIndex)
		{
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
		}

		// Token: 0x06001398 RID: 5016 RVA: 0x00066228 File Offset: 0x00064428
		private void RemoveTags(int layerIndex)
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
		}

		// Token: 0x06001399 RID: 5017 RVA: 0x00066280 File Offset: 0x00064480
		private bool CompareNumber(float a, float b, vAnimatorTagByParamenter.NumberCompare compare)
		{
			switch (compare)
			{
			case vAnimatorTagByParamenter.NumberCompare.Equals:
				Debug.Log(string.Format("{0} == {1}", b, a));
				return b == a;
			case vAnimatorTagByParamenter.NumberCompare.Greater:
				Debug.Log(string.Format("{0} > {1}", b, a));
				return b > a;
			case vAnimatorTagByParamenter.NumberCompare.Less:
				Debug.Log(string.Format("{0} < {1}", b, a));
				return b < a;
			default:
				return false;
			}
		}

		// Token: 0x0600139A RID: 5018 RVA: 0x00066302 File Offset: 0x00064502
		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (this.tagAdded)
			{
				this.tagAdded = false;
				base.OnStateExit(animator, stateInfo, layerIndex);
			}
		}

		// Token: 0x04001933 RID: 6451
		public string paramenterName;

		// Token: 0x04001934 RID: 6452
		public vAnimatorTagByParamenter.ParamenterType paramenterType;

		// Token: 0x04001935 RID: 6453
		[vCheckProperty("paramenterType", new object[]
		{
			vAnimatorTagByParamenter.ParamenterType.Bool
		}, hideInInspector = true)]
		public bool boolValue;

		// Token: 0x04001936 RID: 6454
		[vCheckProperty("paramenterType", new object[]
		{
			vAnimatorTagByParamenter.ParamenterType.Float
		}, hideInInspector = true)]
		public float floatValue;

		// Token: 0x04001937 RID: 6455
		[vCheckProperty("paramenterType", new object[]
		{
			vAnimatorTagByParamenter.ParamenterType.Int
		}, hideInInspector = true)]
		public int intValue;

		// Token: 0x04001938 RID: 6456
		[vCheckProperty("paramenterType", new object[]
		{
			vAnimatorTagByParamenter.ParamenterType.Bool
		}, hideInInspector = true, invertResult = true)]
		public vAnimatorTagByParamenter.NumberCompare compare;

		// Token: 0x04001939 RID: 6457
		[vReadOnly(true)]
		public bool tagAdded;

		// Token: 0x0400193A RID: 6458
		private vAnimatorParameter paramenter;

		// Token: 0x020003DD RID: 989
		public enum ParamenterType
		{
			// Token: 0x0400193C RID: 6460
			Bool,
			// Token: 0x0400193D RID: 6461
			Float,
			// Token: 0x0400193E RID: 6462
			Int
		}

		// Token: 0x020003DE RID: 990
		public enum NumberCompare
		{
			// Token: 0x04001940 RID: 6464
			Equals,
			// Token: 0x04001941 RID: 6465
			Greater,
			// Token: 0x04001942 RID: 6466
			Less
		}
	}
}
