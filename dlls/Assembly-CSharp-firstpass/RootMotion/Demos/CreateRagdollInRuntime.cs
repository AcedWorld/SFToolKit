using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000196 RID: 406
	public class CreateRagdollInRuntime : MonoBehaviour
	{
		// Token: 0x06000B4C RID: 2892 RVA: 0x00047598 File Offset: 0x00045798
		private void Start()
		{
			BipedRagdollReferences r = BipedRagdollReferences.FromAvatar(Object.Instantiate<GameObject>(this.prefab).GetComponent<Animator>());
			BipedRagdollCreator.Options options = BipedRagdollCreator.AutodetectOptions(r);
			BipedRagdollCreator.Create(r, options);
			Debug.Log("A ragdoll was successfully created.");
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x0000223E File Offset: 0x0000043E
		private void Update()
		{
		}

		// Token: 0x04000B4E RID: 2894
		[Tooltip("The character prefab/FBX.")]
		public GameObject prefab;
	}
}
