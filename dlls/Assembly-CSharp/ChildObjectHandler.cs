using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

// Token: 0x02000065 RID: 101
public class ChildObjectHandler : NetworkBehaviour
{
	// Token: 0x0600018C RID: 396 RVA: 0x0000CCF9 File Offset: 0x0000AEF9
	public override void OnNetworkSpawn()
	{
		if (!base.IsOwner)
		{
			this.DisableSpecifiedScriptsOnSelf();
			this.ModifyChildObject();
			this.DisableAdditionalObjects();
			this.RemoveAllScriptsFromPlayerComps();
		}
	}

	// Token: 0x0600018D RID: 397 RVA: 0x0000CD1B File Offset: 0x0000AF1B
	private void DisableSpecifiedScriptsOnSelf()
	{
		this.MenuLogic.enabled = false;
		this.SimpleReplay.enabled = false;
		this.SetSpawnOnStart.enabled = false;
		this.ScooterflowInputSystem.enabled = false;
		this.OnFootSpawnPoint.enabled = false;
	}

	// Token: 0x0600018E RID: 398 RVA: 0x0000CD5C File Offset: 0x0000AF5C
	public void RemoveAllScriptsFromPlayerComps()
	{
		if (this.PlayerCompsObj == null)
		{
			return;
		}
		MonoBehaviour[] componentsInChildren = this.PlayerCompsObj.GetComponentsInChildren<MonoBehaviour>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Object.Destroy(componentsInChildren[i]);
		}
		WheelCollider[] componentsInChildren2 = this.PlayerCompsObj.GetComponentsInChildren<WheelCollider>(true);
		for (int i = 0; i < componentsInChildren2.Length; i++)
		{
			Object.Destroy(componentsInChildren2[i]);
		}
	}

	// Token: 0x0600018F RID: 399 RVA: 0x0000CDC0 File Offset: 0x0000AFC0
	private void ModifyChildObject()
	{
		Transform transform = this.PlayerObj.transform;
		if (transform != null && !base.IsOwner)
		{
			this.RemoveAllComponentsRecursive(transform);
			this.ModifyAndReparentSecondChildObject(transform);
		}
	}

	// Token: 0x06000190 RID: 400 RVA: 0x0000CDF8 File Offset: 0x0000AFF8
	private void ModifyAndReparentSecondChildObject(Transform parentObject)
	{
		Transform transform = this.CharacterObj.transform;
		if (transform != null && !base.IsOwner)
		{
			this.RemoveAllComponentsRecursive(transform);
			transform.SetParent(parentObject.parent);
		}
	}

	// Token: 0x06000191 RID: 401 RVA: 0x0000CE38 File Offset: 0x0000B038
	private void RemoveAllComponentsRecursive(Transform target)
	{
		foreach (Transform transform in target.GetComponentsInChildren<Transform>(true))
		{
			if (!(transform == null))
			{
				MonoBehaviour[] components = transform.GetComponents<MonoBehaviour>();
				for (int j = 0; j < components.Length; j++)
				{
					Object.Destroy(components[j]);
				}
				Rigidbody component = transform.GetComponent<Rigidbody>();
				if (component != null)
				{
					Object.Destroy(component);
				}
				Collider component2 = transform.GetComponent<Collider>();
				if (component2 != null)
				{
					Object.Destroy(component2);
				}
				Animator component3 = transform.GetComponent<Animator>();
				if (component3 != null)
				{
					component3.enabled = false;
				}
			}
		}
	}

	// Token: 0x06000192 RID: 402 RVA: 0x0000CEDC File Offset: 0x0000B0DC
	private void DisableAdditionalObjects()
	{
		foreach (GameObject gameObject in this.additionalObjectsToDisable)
		{
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
		}
	}

	// Token: 0x06000194 RID: 404 RVA: 0x0000CF4C File Offset: 0x0000B14C
	protected override void __initializeVariables()
	{
		base.__initializeVariables();
	}

	// Token: 0x06000195 RID: 405 RVA: 0x0000209E File Offset: 0x0000029E
	protected override void __initializeRpcs()
	{
		base.__initializeRpcs();
	}

	// Token: 0x06000196 RID: 406 RVA: 0x0000CF62 File Offset: 0x0000B162
	protected internal override string __getTypeName()
	{
		return "ChildObjectHandler";
	}

	// Token: 0x040001AD RID: 429
	public List<GameObject> additionalObjectsToDisable = new List<GameObject>();

	// Token: 0x040001AE RID: 430
	public GameObject PlayerCompsObj;

	// Token: 0x040001AF RID: 431
	public GameObject PlayerObj;

	// Token: 0x040001B0 RID: 432
	public GameObject CharacterObj;

	// Token: 0x040001B1 RID: 433
	public MenuLogic MenuLogic;

	// Token: 0x040001B2 RID: 434
	public SimpleReplay SimpleReplay;

	// Token: 0x040001B3 RID: 435
	public SetSpawnOnStart SetSpawnOnStart;

	// Token: 0x040001B4 RID: 436
	public ScooterflowInputSystem ScooterflowInputSystem;

	// Token: 0x040001B5 RID: 437
	public onFootSpawnPoint OnFootSpawnPoint;
}
