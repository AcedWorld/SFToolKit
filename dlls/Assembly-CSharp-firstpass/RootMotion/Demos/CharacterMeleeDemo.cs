using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000191 RID: 401
	public class CharacterMeleeDemo : CharacterPuppet
	{
		// Token: 0x06000B3C RID: 2876 RVA: 0x00047224 File Offset: 0x00045424
		protected override void Start()
		{
			this.currentActionIndex = -1;
			this.lastActionTime = 0f;
			base.Start();
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000B3D RID: 2877 RVA: 0x0004723E File Offset: 0x0004543E
		public CharacterMeleeDemo.Action currentAction
		{
			get
			{
				if (this.currentActionIndex < 0)
				{
					return null;
				}
				return this.actions[this.currentActionIndex];
			}
		}

		// Token: 0x06000B3E RID: 2878 RVA: 0x00047258 File Offset: 0x00045458
		protected override void Update()
		{
			if (base.puppet.state == BehaviourPuppet.State.Puppet)
			{
				for (int i = 0; i < this.actions.Length; i++)
				{
					if (this.StartAction(this.actions[i]))
					{
						this.currentActionIndex = i;
						Booster[] boosters = this.actions[i].boosters;
						for (int j = 0; j < boosters.Length; j++)
						{
							boosters[j].Boost(base.puppet);
						}
						if (this.propMuscle.currentProp is PuppetMasterPropMelee)
						{
							(this.propMuscle.currentProp as PuppetMasterPropMelee).StartAction(this.actions[i].duration);
						}
						this.lastActionTime = Time.time;
						this.lastActionMoveMag = this.moveDirection.magnitude;
					}
				}
			}
			if (Time.time < this.lastActionTime + 0.5f)
			{
				this.moveDirection = this.moveDirection.normalized * Mathf.Max(this.moveDirection.magnitude, this.lastActionMoveMag);
			}
			base.Update();
		}

		// Token: 0x06000B3F RID: 2879 RVA: 0x00047368 File Offset: 0x00045568
		private bool StartAction(CharacterMeleeDemo.Action action)
		{
			if (Time.time < this.lastActionTime + action.minFrequency)
			{
				return false;
			}
			if (this.userControl.state.actionIndex != action.inputActionIndex)
			{
				return false;
			}
			if (action.requiredPropTypes.Length != 0)
			{
				if (this.propMuscle.currentProp == null && action.requiredPropTypes[0] == -1)
				{
					return true;
				}
				if (this.propMuscle.currentProp == null)
				{
					return false;
				}
				bool flag = false;
				for (int i = 0; i < action.requiredPropTypes.Length; i++)
				{
					if (action.requiredPropTypes[i] == this.propMuscle.currentProp.propType)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x04000B39 RID: 2873
		[Header("Melee")]
		public CharacterMeleeDemo.Action[] actions;

		// Token: 0x04000B3A RID: 2874
		[HideInInspector]
		public int currentActionIndex = -1;

		// Token: 0x04000B3B RID: 2875
		[HideInInspector]
		public float lastActionTime;

		// Token: 0x04000B3C RID: 2876
		private float lastActionMoveMag;

		// Token: 0x02000192 RID: 402
		[Serializable]
		public class Action
		{
			// Token: 0x04000B3D RID: 2877
			public string name;

			// Token: 0x04000B3E RID: 2878
			public int inputActionIndex = 1;

			// Token: 0x04000B3F RID: 2879
			public float duration;

			// Token: 0x04000B40 RID: 2880
			public float minFrequency;

			// Token: 0x04000B41 RID: 2881
			public CharacterMeleeDemo.Action.Anim anim;

			// Token: 0x04000B42 RID: 2882
			public int[] requiredPropTypes;

			// Token: 0x04000B43 RID: 2883
			public Booster[] boosters;

			// Token: 0x02000193 RID: 403
			[Serializable]
			public class Anim
			{
				// Token: 0x04000B44 RID: 2884
				public string stateName;

				// Token: 0x04000B45 RID: 2885
				public int layer;

				// Token: 0x04000B46 RID: 2886
				public float transitionDuration;

				// Token: 0x04000B47 RID: 2887
				public float fixedTime;
			}
		}
	}
}
