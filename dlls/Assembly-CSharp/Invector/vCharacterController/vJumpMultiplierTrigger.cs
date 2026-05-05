using System;
using UnityEngine;

namespace Invector.vCharacterController
{
	// Token: 0x02000400 RID: 1024
	public class vJumpMultiplierTrigger : MonoBehaviour
	{
		// Token: 0x060014EC RID: 5356 RVA: 0x0006CE90 File Offset: 0x0006B090
		private void OnTriggerStay(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				vThirdPersonController component = other.GetComponent<vThirdPersonController>();
				if (component && (component.isJumping || !component.isGrounded) && component._rigidbody.velocity.y <= 0f)
				{
					component.SetJumpMultiplier(this.multiplier, this.timeToReset);
					component.isJumping = false;
					component.verticalVelocity = 0f;
					component.heightReached = base.transform.position.y;
					component.isGrounded = true;
					component.Jump(false);
				}
			}
		}

		// Token: 0x04001AAB RID: 6827
		public float multiplier = 5f;

		// Token: 0x04001AAC RID: 6828
		public float timeToReset = 0.5f;
	}
}
