using System;
using TMPro;
using Unity.Netcode;
using UnityEngine;

// Token: 0x02000070 RID: 112
public class NameTagSpawner : NetworkBehaviour
{
	// Token: 0x060001C3 RID: 451 RVA: 0x0000F378 File Offset: 0x0000D578
	public override void OnNetworkSpawn()
	{
		if (base.IsOwner)
		{
			this.nameTagInstance = Object.Instantiate<GameObject>(this.nameTagPrefab, base.transform.position + this.nameTagOffset, Quaternion.identity);
			TextMeshPro componentInChildren = this.nameTagInstance.GetComponentInChildren<TextMeshPro>();
			if (componentInChildren != null)
			{
				componentInChildren.text = string.Format("Player {0}", base.NetworkObject.NetworkObjectId);
				return;
			}
			Debug.LogError("TextMeshPro component is missing on the NameTag prefab!");
		}
	}

	// Token: 0x060001C4 RID: 452 RVA: 0x0000F3FC File Offset: 0x0000D5FC
	private void Update()
	{
		if (this.nameTagInstance != null)
		{
			this.nameTagInstance.transform.position = base.transform.position + this.nameTagOffset;
			this.nameTagInstance.transform.LookAt(Camera.main.transform);
		}
	}

	// Token: 0x060001C6 RID: 454 RVA: 0x0000F47C File Offset: 0x0000D67C
	protected override void __initializeVariables()
	{
		base.__initializeVariables();
	}

	// Token: 0x060001C7 RID: 455 RVA: 0x0000209E File Offset: 0x0000029E
	protected override void __initializeRpcs()
	{
		base.__initializeRpcs();
	}

	// Token: 0x060001C8 RID: 456 RVA: 0x0000F492 File Offset: 0x0000D692
	protected internal override string __getTypeName()
	{
		return "NameTagSpawner";
	}

	// Token: 0x0400020E RID: 526
	public GameObject nameTagPrefab;

	// Token: 0x0400020F RID: 527
	private GameObject nameTagInstance;

	// Token: 0x04000210 RID: 528
	private Vector3 nameTagOffset = new Vector3(0f, 2f, 0f);
}
