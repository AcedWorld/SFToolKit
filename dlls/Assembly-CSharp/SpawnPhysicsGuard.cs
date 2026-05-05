using System;
using System.Collections;
using Unity.Netcode;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class SpawnPhysicsGuard : NetworkBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public override void OnNetworkSpawn()
	{
		if (base.IsServer)
		{
			return;
		}
		base.StartCoroutine(this.Guard());
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002068 File Offset: 0x00000268
	private IEnumerator Guard()
	{
		Rigidbody rb = base.GetComponent<Rigidbody>();
		CharacterController cc = base.GetComponent<CharacterController>();
		bool rbHadCollisions = false;
		if (rb)
		{
			rbHadCollisions = rb.detectCollisions;
			rb.isKinematic = true;
			rb.detectCollisions = false;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
		if (cc)
		{
			cc.enabled = false;
		}
		int num;
		for (int i = 0; i < this.framesToGuard; i = num + 1)
		{
			yield return null;
			num = i;
		}
		if (rb)
		{
			rb.isKinematic = false;
			rb.detectCollisions = rbHadCollisions;
		}
		if (cc)
		{
			cc.enabled = true;
		}
		yield break;
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00002088 File Offset: 0x00000288
	protected override void __initializeVariables()
	{
		base.__initializeVariables();
	}

	// Token: 0x06000005 RID: 5 RVA: 0x0000209E File Offset: 0x0000029E
	protected override void __initializeRpcs()
	{
		base.__initializeRpcs();
	}

	// Token: 0x06000006 RID: 6 RVA: 0x000020A8 File Offset: 0x000002A8
	protected internal override string __getTypeName()
	{
		return "SpawnPhysicsGuard";
	}

	// Token: 0x04000001 RID: 1
	[SerializeField]
	private int framesToGuard = 2;
}
