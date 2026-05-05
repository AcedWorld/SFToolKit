using System;
using RootMotion.Dynamics;
using UnityEngine;
using UnityEngine.AI;

namespace RootMotion.Demos
{
	// Token: 0x020001A4 RID: 420
	public class NavMeshPuppet : MonoBehaviour
	{
		// Token: 0x06000B8D RID: 2957 RVA: 0x000481D4 File Offset: 0x000463D4
		private void Update()
		{
			this.agent.enabled = (this.puppet.state == BehaviourPuppet.State.Puppet);
			if (this.agent.enabled)
			{
				this.agent.SetDestination(this.target.position);
				this.animator.SetFloat("Forward", this.agent.velocity.magnitude * 0.25f);
			}
		}

		// Token: 0x04000B8E RID: 2958
		public BehaviourPuppet puppet;

		// Token: 0x04000B8F RID: 2959
		public NavMeshAgent agent;

		// Token: 0x04000B90 RID: 2960
		public Transform target;

		// Token: 0x04000B91 RID: 2961
		public Animator animator;
	}
}
