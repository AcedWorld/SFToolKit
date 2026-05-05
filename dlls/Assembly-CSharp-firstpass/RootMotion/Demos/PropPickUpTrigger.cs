using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001AD RID: 429
	public class PropPickUpTrigger : MonoBehaviour
	{
		// Token: 0x06000BAF RID: 2991 RVA: 0x000488BC File Offset: 0x00046ABC
		private void OnTriggerEnter(Collider collider)
		{
			if (this.prop.isPickedUp)
			{
				return;
			}
			if (!LayerMaskExtensions.Contains(this.characterLayers, collider.gameObject.layer))
			{
				return;
			}
			this.characterPuppet = collider.GetComponent<CharacterPuppet>();
			if (this.characterPuppet == null)
			{
				return;
			}
			if (this.characterPuppet.puppet.state != BehaviourPuppet.State.Puppet)
			{
				return;
			}
			if (this.characterPuppet.propMuscle == null)
			{
				return;
			}
			if (this.characterPuppet.propMuscle.currentProp != null)
			{
				return;
			}
			this.characterPuppet.propMuscle.currentProp = this.prop;
		}

		// Token: 0x04000BBA RID: 3002
		public PuppetMasterProp prop;

		// Token: 0x04000BBB RID: 3003
		public LayerMask characterLayers;

		// Token: 0x04000BBC RID: 3004
		private CharacterPuppet characterPuppet;
	}
}
