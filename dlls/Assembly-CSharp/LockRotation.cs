using System;
using Rewired;
using UnityEngine;

// Token: 0x0200015F RID: 351
public class LockRotation : MonoBehaviour
{
	// Token: 0x060005A3 RID: 1443 RVA: 0x000285C0 File Offset: 0x000267C0
	private void Start()
	{
		this.rb = this.Player.GetComponent<Rigidbody>();
		this.player = ReInput.players.GetPlayer(this.playerId);
		this.cached_fwSFC = this.fwl.sidewaysFriction;
		this.cached_rwSFC = this.rwl.sidewaysFriction;
		this.cached_fwFC = this.fwl.forwardFriction;
		this.cached_rwFC = this.rwl.forwardFriction;
		this.grind_WS.asymptoteSlip = 20f;
		this.grind_WS.extremumSlip = 20f;
	}

	// Token: 0x060005A4 RID: 1444 RVA: 0x00028658 File Offset: 0x00026858
	private void FixedUpdate()
	{
		if (this.isGrinding && this.ragdollControl.ragdollActive)
		{
			this.isGrinding = false;
		}
		if (this.scooterController.fakie && !this.isGrinding && !this.scooterController.revertSettings.RevertActivated)
		{
			this.fwl.sidewaysFriction = this.rwl.sidewaysFriction;
			this.fwl.forwardFriction = this.rwl.forwardFriction;
			this.rwl.sidewaysFriction = this.cached_rwSFC;
		}
		if (!this.scooterController.fakie && !this.isGrinding && !this.scooterController.revertSettings.RevertActivated)
		{
			this.fwl.sidewaysFriction = this.cached_fwSFC;
			this.fwl.forwardFriction = this.cached_fwFC;
			this.rwl.sidewaysFriction = this.cached_rwSFC;
		}
		if (this.isGrinding)
		{
			this.fwl.sidewaysFriction = this.grind_WS;
			this.rwl.sidewaysFriction = this.grind_WS;
		}
		if (!this.GrindSystem.isGrinding)
		{
			this.isGrinding = false;
		}
	}

	// Token: 0x060005A5 RID: 1445 RVA: 0x00028780 File Offset: 0x00026980
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Rail"))
		{
			if (this.testing && !this.ragdollControl.ragdollActive && this.GrindSystem.isGrinding)
			{
				this.isGrinding = true;
			}
			bool flag = this.GrindSystem.isGrinding;
			return;
		}
	}

	// Token: 0x060005A6 RID: 1446 RVA: 0x000287D5 File Offset: 0x000269D5
	public void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Rail") && this.testing && !this.ragdollControl.ragdollActive && this.GrindSystem.isGrinding)
		{
			this.isGrinding = true;
		}
	}

	// Token: 0x060005A7 RID: 1447 RVA: 0x00028812 File Offset: 0x00026A12
	public void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Rail") && this.testing)
		{
			this.isGrinding = false;
		}
	}

	// Token: 0x0400092A RID: 2346
	public GameObject Player;

	// Token: 0x0400092B RID: 2347
	public RagdollControl ragdollControl;

	// Token: 0x0400092C RID: 2348
	public ScooterController scooterController;

	// Token: 0x0400092D RID: 2349
	public Rigidbody rb;

	// Token: 0x0400092E RID: 2350
	public WheelCollider fwl;

	// Token: 0x0400092F RID: 2351
	public WheelCollider rwl;

	// Token: 0x04000930 RID: 2352
	public int playerId;

	// Token: 0x04000931 RID: 2353
	private Player player;

	// Token: 0x04000932 RID: 2354
	public bool testing;

	// Token: 0x04000933 RID: 2355
	public bool isGrinding;

	// Token: 0x04000934 RID: 2356
	private WheelFrictionCurve cached_fwSFC;

	// Token: 0x04000935 RID: 2357
	private WheelFrictionCurve cached_rwSFC;

	// Token: 0x04000936 RID: 2358
	private WheelFrictionCurve cached_fwFC;

	// Token: 0x04000937 RID: 2359
	private WheelFrictionCurve cached_rwFC;

	// Token: 0x04000938 RID: 2360
	private WheelFrictionCurve grind_WS;

	// Token: 0x04000939 RID: 2361
	public float spinSpeed;

	// Token: 0x0400093A RID: 2362
	public GrindSystem GrindSystem;
}
