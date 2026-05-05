using System;
using Rewired;
using UnityEngine;

// Token: 0x020000A7 RID: 167
public class DroneController : MonoBehaviour
{
	// Token: 0x060002C0 RID: 704 RVA: 0x00015EC5 File Offset: 0x000140C5
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
		this.camRB = base.GetComponent<Rigidbody>();
		this.animator = base.GetComponent<Animator>();
	}

	// Token: 0x060002C1 RID: 705 RVA: 0x00015EF8 File Offset: 0x000140F8
	private void Update()
	{
		this.animator.SetFloat("MoveHorizontal", this.hinput, this.animationSmooth, Time.deltaTime);
		this.animator.SetFloat("MoveVertical", this.vinput, this.animationSmooth, Time.deltaTime);
	}

	// Token: 0x060002C2 RID: 706 RVA: 0x00015F48 File Offset: 0x00014148
	private void FixedUpdate()
	{
		this.hinput = this.player.GetAxis("LeftStickX");
		this.vinput = this.player.GetAxis("LeftStickY");
		this.rhinput = this.player.GetAxis("RightStickY");
		this.rvinput = this.player.GetAxis("RightStickX");
		if (this.player.GetButton("R2"))
		{
			this.flipMode = true;
		}
		else
		{
			this.flipMode = false;
		}
		if (!this.flipMode)
		{
			float d;
			Vector3 vector;
			Quaternion.FromToRotation(this.camRB.transform.up, Vector3.up).ToAngleAxis(out d, out vector);
			this.camRB.AddTorque(-this.camRB.angularVelocity * this.dampenFactor, ForceMode.Acceleration);
			this.camRB.AddTorque(vector.normalized * d * this.adjustFactor, ForceMode.Acceleration);
			this.camRB.AddRelativeForce(this.hinput * this.SideSpeed, this.rhinput * this.verticalMoveSpeed, this.vinput * this.ForwardSpeed);
			this.camRB.AddRelativeTorque(0f, this.rvinput * this.rotationSpeed, 0f);
		}
		if (this.flipMode)
		{
			this.camRB.AddRelativeForce(0f, 100f, 0f);
			this.camRB.AddRelativeForce(this.hinput * this.SideSpeed, 0f, this.vinput * this.ForwardSpeed);
			this.camRB.AddRelativeTorque(this.rhinput * this.flipSpeed, 0f, this.rvinput * -this.flipSpeed);
		}
		this.RotateBlades();
	}

	// Token: 0x060002C3 RID: 707 RVA: 0x0001611C File Offset: 0x0001431C
	private void RotateBlades()
	{
		Transform[] array = this.blades;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Rotate(0f, this.bladeSpeed, 0f, Space.Self);
		}
	}

	// Token: 0x04000364 RID: 868
	private int playerId;

	// Token: 0x04000365 RID: 869
	private Player player;

	// Token: 0x04000366 RID: 870
	private Rigidbody camRB;

	// Token: 0x04000367 RID: 871
	public float ForwardSpeed;

	// Token: 0x04000368 RID: 872
	public float SideSpeed;

	// Token: 0x04000369 RID: 873
	public float verticalMoveSpeed;

	// Token: 0x0400036A RID: 874
	public float rotationSpeed;

	// Token: 0x0400036B RID: 875
	public float flipSpeed;

	// Token: 0x0400036C RID: 876
	public float adjustFactor;

	// Token: 0x0400036D RID: 877
	public float dampenFactor;

	// Token: 0x0400036E RID: 878
	private Animator animator;

	// Token: 0x0400036F RID: 879
	public float animationSmooth;

	// Token: 0x04000370 RID: 880
	public Transform[] blades;

	// Token: 0x04000371 RID: 881
	public float bladeSpeed;

	// Token: 0x04000372 RID: 882
	public bool flipMode;

	// Token: 0x04000373 RID: 883
	private float hinput;

	// Token: 0x04000374 RID: 884
	private float vinput;

	// Token: 0x04000375 RID: 885
	private float rhinput;

	// Token: 0x04000376 RID: 886
	private float rvinput;
}
