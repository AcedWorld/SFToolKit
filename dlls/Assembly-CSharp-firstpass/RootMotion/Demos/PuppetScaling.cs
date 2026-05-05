using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001B1 RID: 433
	public class PuppetScaling : MonoBehaviour
	{
		// Token: 0x06000BC0 RID: 3008 RVA: 0x00048C41 File Offset: 0x00046E41
		private void Start()
		{
			this.puppetMaster.updateJointAnchors = true;
			this.puppetMaster.supportTranslationAnimation = true;
			this.defaultMuscleSpring = this.puppetMaster.muscleSpring;
		}

		// Token: 0x06000BC1 RID: 3009 RVA: 0x00048C6C File Offset: 0x00046E6C
		private void Update()
		{
			this.puppetMaster.transform.parent.localScale = Vector3.one * this.masterScale;
			this.puppetMaster.muscleSpring = this.defaultMuscleSpring * Mathf.Pow(this.masterScale, 2f);
			this.muscleIndex = Mathf.Clamp(this.muscleIndex, 0, this.puppetMaster.muscles.Length - 1);
			for (int i = 0; i < this.puppetMaster.muscles.Length; i++)
			{
				if (i == this.muscleIndex)
				{
					this.puppetMaster.muscles[i].target.localScale = Vector3.one * this.muscleScale;
					this.puppetMaster.muscles[i].transform.localScale = Vector3.one * this.muscleScale;
				}
				else
				{
					this.puppetMaster.muscles[i].target.localScale = Vector3.one;
					this.puppetMaster.muscles[i].transform.localScale = Vector3.one;
				}
			}
			if (this.puppetMaster.muscles[1].transform.parent == this.puppetMaster.transform)
			{
				for (int j = 0; j < this.puppetMaster.muscles[this.muscleIndex].childIndexes.Length; j++)
				{
					this.puppetMaster.muscles[this.puppetMaster.muscles[this.muscleIndex].childIndexes[j]].transform.localScale = Vector3.one * this.muscleScale;
				}
			}
		}

		// Token: 0x04000BCE RID: 3022
		public PuppetMaster puppetMaster;

		// Token: 0x04000BCF RID: 3023
		[Range(0.01f, 10f)]
		public float masterScale = 1f;

		// Token: 0x04000BD0 RID: 3024
		public int muscleIndex;

		// Token: 0x04000BD1 RID: 3025
		[Range(0.01f, 10f)]
		public float muscleScale = 1f;

		// Token: 0x04000BD2 RID: 3026
		private float defaultMuscleSpring;
	}
}
