using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000194 RID: 404
	public class CharacterPuppet : CharacterThirdPerson
	{
		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000B43 RID: 2883 RVA: 0x0004743A File Offset: 0x0004563A
		// (set) Token: 0x06000B44 RID: 2884 RVA: 0x00047442 File Offset: 0x00045642
		public BehaviourPuppet puppet { get; private set; }

		// Token: 0x06000B45 RID: 2885 RVA: 0x0004744B File Offset: 0x0004564B
		protected override void Start()
		{
			base.Start();
			this.puppet = base.transform.parent.GetComponentInChildren<BehaviourPuppet>();
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x00047469 File Offset: 0x00045669
		public override void Move(Vector3 deltaPosition, Quaternion deltaRotation)
		{
			if (this.puppet.state != BehaviourPuppet.State.Puppet)
			{
				this.userControl.state.move = Vector3.zero;
				return;
			}
			base.Move(deltaPosition, deltaRotation);
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x00047498 File Offset: 0x00045698
		protected override void Rotate()
		{
			if (this.puppet.state != BehaviourPuppet.State.Puppet)
			{
				if (this.gravityTarget != null)
				{
					base.transform.rotation = Quaternion.FromToRotation(base.transform.up, base.transform.position - this.gravityTarget.position) * base.transform.rotation;
				}
				return;
			}
			base.Rotate();
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x0004750D File Offset: 0x0004570D
		protected override bool Jump()
		{
			return this.puppet.state == BehaviourPuppet.State.Puppet && base.Jump();
		}

		// Token: 0x04000B48 RID: 2888
		[Header("Puppet")]
		public PropMuscle propMuscle;
	}
}
