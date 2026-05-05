using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001AA RID: 426
	public class PropDemo : MonoBehaviour
	{
		// Token: 0x06000B9F RID: 2975 RVA: 0x0004857D File Offset: 0x0004677D
		private void Start()
		{
			if (this.pickUpOnAwake)
			{
				this.connectTo.currentProp = this.prop;
			}
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x00048598 File Offset: 0x00046798
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.P))
			{
				this.connectTo.currentProp = this.prop;
			}
			if (Input.GetKeyDown(KeyCode.X))
			{
				this.connectTo.currentProp = null;
			}
			if (Input.GetKeyDown(KeyCode.S))
			{
				this.right = !this.right;
				this.connectTo.currentProp = this.prop;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000BA1 RID: 2977 RVA: 0x000485FD File Offset: 0x000467FD
		private PropMuscle connectTo
		{
			get
			{
				if (!this.right)
				{
					return this.propMuscleLeft;
				}
				return this.propMuscleRight;
			}
		}

		// Token: 0x04000BA6 RID: 2982
		[Tooltip("The Prop you wish to pick up.")]
		public PuppetMasterProp prop;

		// Token: 0x04000BA7 RID: 2983
		[Tooltip("The Prop Muscle of the left hand.")]
		public PropMuscle propMuscleLeft;

		// Token: 0x04000BA8 RID: 2984
		[Tooltip("The Prop Muscle of the right hand.")]
		public PropMuscle propMuscleRight;

		// Token: 0x04000BA9 RID: 2985
		[Tooltip("If true, the prop will be picked up when PuppetMaster initiates")]
		public bool pickUpOnAwake;

		// Token: 0x04000BAA RID: 2986
		private bool right = true;
	}
}
