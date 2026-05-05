using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001A3 RID: 419
	public class LayerSetup : MonoBehaviour
	{
		// Token: 0x06000B8B RID: 2955 RVA: 0x000480DC File Offset: 0x000462DC
		private void Awake()
		{
			this.puppetMaster = base.GetComponent<PuppetMaster>();
			this.puppetMaster.gameObject.layer = this.ragdollLayer;
			Muscle[] muscles = this.puppetMaster.muscles;
			for (int i = 0; i < muscles.Length; i++)
			{
				muscles[i].joint.gameObject.layer = this.ragdollLayer;
			}
			this.characterController.gameObject.layer = this.characterControllerLayer;
			Physics.IgnoreLayerCollision(this.characterControllerLayer, this.ragdollLayer);
			Physics.IgnoreLayerCollision(this.characterControllerLayer, this.characterControllerLayer);
			foreach (int layer in this.ignoreCollisionWithCharacterController.MaskToNumbers())
			{
				Physics.IgnoreLayerCollision(this.characterControllerLayer, layer);
			}
			foreach (int layer2 in this.ignoreCollisionWithRagdoll.MaskToNumbers())
			{
				Physics.IgnoreLayerCollision(this.ragdollLayer, layer2);
			}
			Object.Destroy(this);
		}

		// Token: 0x04000B88 RID: 2952
		[Header("References")]
		[Tooltip("Reference to the character controller gameobject (the one that has the capsule collider/CharacterController.")]
		public Transform characterController;

		// Token: 0x04000B89 RID: 2953
		[Header("Layers")]
		[Tooltip("The layer to assign the character controller to. Collisions between this layer and the 'Ragdoll Layer' will be ignored, or else the ragdoll would collide with the character controller.")]
		public int characterControllerLayer;

		// Token: 0x04000B8A RID: 2954
		[Tooltip("The layer to assign the PuppetMaster and all its muscles to. Collisions between this layer and the 'Character Controller Layer' will be ignored, or else the ragdoll would collide with the character controller.")]
		public int ragdollLayer;

		// Token: 0x04000B8B RID: 2955
		[Tooltip("Layers that will be ignored by the character controller")]
		public LayerMask ignoreCollisionWithCharacterController;

		// Token: 0x04000B8C RID: 2956
		[Tooltip("Layers that will not collide with the Ragdoll layer.")]
		public LayerMask ignoreCollisionWithRagdoll;

		// Token: 0x04000B8D RID: 2957
		private PuppetMaster puppetMaster;
	}
}
