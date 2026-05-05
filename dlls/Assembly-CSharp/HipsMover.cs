using System;
using UnityEngine;

// Token: 0x020001E2 RID: 482
public class HipsMover : MonoBehaviour
{
	// Token: 0x0600078F RID: 1935 RVA: 0x00037D78 File Offset: 0x00035F78
	private void FixedUpdate()
	{
		if (this.characterStates.currentState == CharacterState.Ragdolling)
		{
			float leftStickX = this.scooterflowInputSystem.LeftStickX;
			this.hipsRigidbody.AddRelativeTorque(Vector3.up * leftStickX * this.torqueForce);
			this.spineRigidbody.AddRelativeTorque(Vector3.up * leftStickX * this.torqueForce);
		}
	}

	// Token: 0x04000D3D RID: 3389
	public ScooterflowInputSystem scooterflowInputSystem;

	// Token: 0x04000D3E RID: 3390
	public Rigidbody hipsRigidbody;

	// Token: 0x04000D3F RID: 3391
	public Rigidbody spineRigidbody;

	// Token: 0x04000D40 RID: 3392
	public CharacterStates characterStates;

	// Token: 0x04000D41 RID: 3393
	public float torqueForce = 5000f;
}
