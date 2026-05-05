using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000050 RID: 80
	[Serializable]
	public class Booster
	{
		// Token: 0x06000236 RID: 566 RVA: 0x0000C59C File Offset: 0x0000A79C
		public void Boost(BehaviourPuppet puppet)
		{
			if (this.fullBody)
			{
				puppet.Boost(this.immunity, this.impulseMlp);
				return;
			}
			foreach (ConfigurableJoint y in this.muscles)
			{
				for (int j = 0; j < puppet.puppetMaster.muscles.Length; j++)
				{
					if (puppet.puppetMaster.muscles[j].joint == y)
					{
						puppet.Boost(j, this.immunity, this.impulseMlp, this.boostParents, this.boostChildren);
						break;
					}
				}
			}
			foreach (Muscle.Group group in this.groups)
			{
				for (int k = 0; k < puppet.puppetMaster.muscles.Length; k++)
				{
					if (puppet.puppetMaster.muscles[k].props.group == group)
					{
						puppet.Boost(k, this.immunity, this.impulseMlp, this.boostParents, this.boostChildren);
					}
				}
			}
		}

		// Token: 0x040001EE RID: 494
		[Tooltip("If true, all the muscles will be boosted and the 'Muscles' and 'Groups' properties below will be ignored.")]
		public bool fullBody;

		// Token: 0x040001EF RID: 495
		[Tooltip("Muscles to boost. Used only when 'Full Body' is false.")]
		public ConfigurableJoint[] muscles = new ConfigurableJoint[0];

		// Token: 0x040001F0 RID: 496
		[Tooltip("Muscle groups to boost. Used only when 'Full Body' is false.")]
		public Muscle.Group[] groups = new Muscle.Group[0];

		// Token: 0x040001F1 RID: 497
		[Tooltip("Immunity to apply to the muscles. If muscle immunity is 1, it can not be damaged.")]
		[Range(0f, 1f)]
		public float immunity;

		// Token: 0x040001F2 RID: 498
		[Tooltip("Impulse multiplier to be applied to the muscles. This makes them deal more damage to other puppets.")]
		public float impulseMlp;

		// Token: 0x040001F3 RID: 499
		[Tooltip("Falloff for parent muscles (power of kinship degree).")]
		public float boostParents;

		// Token: 0x040001F4 RID: 500
		[Tooltip("Falloff for child muscles (power of kinship degree).")]
		public float boostChildren;

		// Token: 0x040001F5 RID: 501
		[Tooltip("This does nothing on its own, you can use it in a 'yield return new WaitForseconds(delay);' call.")]
		public float delay;
	}
}
