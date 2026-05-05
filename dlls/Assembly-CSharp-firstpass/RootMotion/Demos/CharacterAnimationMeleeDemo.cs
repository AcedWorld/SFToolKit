using System;

namespace RootMotion.Demos
{
	// Token: 0x02000190 RID: 400
	public class CharacterAnimationMeleeDemo : CharacterAnimationThirdPerson
	{
		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000B39 RID: 2873 RVA: 0x00047188 File Offset: 0x00045388
		private CharacterMeleeDemo melee
		{
			get
			{
				return this.characterController as CharacterMeleeDemo;
			}
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x00047198 File Offset: 0x00045398
		protected override void Update()
		{
			base.Update();
			this.animator.SetInteger("ActionIndex", -1);
			if (this.melee.currentAction != null)
			{
				this.animator.SetInteger("ActionIndex", this.melee.currentActionIndex);
				CharacterMeleeDemo.Action.Anim anim = this.melee.currentAction.anim;
				this.animator.CrossFadeInFixedTime(anim.stateName, anim.transitionDuration, anim.layer, anim.fixedTime);
				this.melee.currentActionIndex = -1;
			}
		}
	}
}
