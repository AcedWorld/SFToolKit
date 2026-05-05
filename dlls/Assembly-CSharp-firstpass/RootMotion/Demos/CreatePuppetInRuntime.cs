using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000195 RID: 405
	public class CreatePuppetInRuntime : MonoBehaviour
	{
		// Token: 0x06000B4A RID: 2890 RVA: 0x0004752C File Offset: 0x0004572C
		private void Start()
		{
			Transform transform = Object.Instantiate<Transform>(this.ragdollPrefab, base.transform.position, base.transform.rotation);
			transform.name = this.instanceName;
			PuppetMaster.SetUp(transform, this.characterControllerLayer, this.ragdollLayer);
			Debug.Log("A ragdoll was successfully converted to a Puppet.");
		}

		// Token: 0x04000B4A RID: 2890
		[Tooltip("Creating a Puppet from a ragdoll character prefab.")]
		public Transform ragdollPrefab;

		// Token: 0x04000B4B RID: 2891
		[Tooltip("What will the Puppet be named?")]
		public string instanceName = "My Character";

		// Token: 0x04000B4C RID: 2892
		[Tooltip("The layer to assign the character controller to. Collisions between this layer and the 'Ragdoll Layer' will be ignored, or else the ragdoll would collide with the character controller.")]
		public int characterControllerLayer;

		// Token: 0x04000B4D RID: 2893
		[Tooltip("The layer to assign the PuppetMaster and all its muscles to. Collisions between this layer and the 'Character Controller Layer' will be ignored, or else the ragdoll would collide with the character controller.")]
		public int ragdollLayer;
	}
}
