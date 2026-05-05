using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000105 RID: 261
	public class HandPoser : Poser
	{
		// Token: 0x060008C9 RID: 2249 RVA: 0x00038D1B File Offset: 0x00036F1B
		public override void AutoMapping()
		{
			if (this.poseRoot == null)
			{
				this.poseChildren = new Transform[0];
			}
			else
			{
				this.poseChildren = this.poseRoot.GetComponentsInChildren<Transform>();
			}
			this._poseRoot = this.poseRoot;
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x00038D56 File Offset: 0x00036F56
		protected override void InitiatePoser()
		{
			this.children = base.GetComponentsInChildren<Transform>();
			this.StoreDefaultState();
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x00038D6C File Offset: 0x00036F6C
		protected override void FixPoserTransforms()
		{
			for (int i = 0; i < this.children.Length; i++)
			{
				this.children[i].localPosition = this.defaultLocalPositions[i];
				this.children[i].localRotation = this.defaultLocalRotations[i];
			}
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x00038DC0 File Offset: 0x00036FC0
		protected override void UpdatePoser()
		{
			if (this.weight <= 0f)
			{
				return;
			}
			if (this.localPositionWeight <= 0f && this.localRotationWeight <= 0f)
			{
				return;
			}
			if (this._poseRoot != this.poseRoot)
			{
				this.AutoMapping();
			}
			if (this.poseRoot == null)
			{
				return;
			}
			if (this.children.Length != this.poseChildren.Length)
			{
				Warning.Log("Number of children does not match with the pose", base.transform, false);
				return;
			}
			float t = this.localRotationWeight * this.weight;
			float t2 = this.localPositionWeight * this.weight;
			for (int i = 0; i < this.children.Length; i++)
			{
				if (this.children[i] != base.transform)
				{
					this.children[i].localRotation = Quaternion.Lerp(this.children[i].localRotation, this.poseChildren[i].localRotation, t);
					this.children[i].localPosition = Vector3.Lerp(this.children[i].localPosition, this.poseChildren[i].localPosition, t2);
				}
			}
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x00038EE0 File Offset: 0x000370E0
		protected void StoreDefaultState()
		{
			this.defaultLocalPositions = new Vector3[this.children.Length];
			this.defaultLocalRotations = new Quaternion[this.children.Length];
			for (int i = 0; i < this.children.Length; i++)
			{
				this.defaultLocalPositions[i] = this.children[i].localPosition;
				this.defaultLocalRotations[i] = this.children[i].localRotation;
			}
		}

		// Token: 0x04000814 RID: 2068
		protected Transform[] children;

		// Token: 0x04000815 RID: 2069
		private Transform _poseRoot;

		// Token: 0x04000816 RID: 2070
		private Transform[] poseChildren;

		// Token: 0x04000817 RID: 2071
		private Vector3[] defaultLocalPositions;

		// Token: 0x04000818 RID: 2072
		private Quaternion[] defaultLocalRotations;
	}
}
