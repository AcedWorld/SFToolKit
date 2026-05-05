using System;
using UnityEngine;

namespace Rewired.Demos
{
	// Token: 0x020002BC RID: 700
	[AddComponentMenu("")]
	[RequireComponent(typeof(CharacterController))]
	public class PressAnyButtonToJoinExample_GamePlayer : MonoBehaviour
	{
		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06000ED5 RID: 3797 RVA: 0x0004FA89 File Offset: 0x0004DC89
		private Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.players.GetPlayer(this.playerId);
			}
		}

		// Token: 0x06000ED6 RID: 3798 RVA: 0x0004FAA4 File Offset: 0x0004DCA4
		private void OnEnable()
		{
			this.cc = base.GetComponent<CharacterController>();
		}

		// Token: 0x06000ED7 RID: 3799 RVA: 0x0004FAB2 File Offset: 0x0004DCB2
		private void Update()
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (this.player == null)
			{
				return;
			}
			this.GetInput();
			this.ProcessInput();
		}

		// Token: 0x06000ED8 RID: 3800 RVA: 0x0004FAD4 File Offset: 0x0004DCD4
		private void GetInput()
		{
			this.moveVector.x = this.player.GetAxis("Move Horizontal");
			this.moveVector.y = this.player.GetAxis("Move Vertical");
			this.fire = this.player.GetButtonDown("Fire");
		}

		// Token: 0x06000ED9 RID: 3801 RVA: 0x0004FB30 File Offset: 0x0004DD30
		private void ProcessInput()
		{
			if (this.moveVector.x != 0f || this.moveVector.y != 0f)
			{
				this.cc.Move(this.moveVector * this.moveSpeed * Time.deltaTime);
			}
			if (this.fire)
			{
				Object.Instantiate<GameObject>(this.bulletPrefab, base.transform.position + base.transform.right, base.transform.rotation).GetComponent<Rigidbody>().AddForce(base.transform.right * this.bulletSpeed, ForceMode.VelocityChange);
			}
		}

		// Token: 0x0400136A RID: 4970
		public int playerId;

		// Token: 0x0400136B RID: 4971
		public float moveSpeed = 3f;

		// Token: 0x0400136C RID: 4972
		public float bulletSpeed = 15f;

		// Token: 0x0400136D RID: 4973
		public GameObject bulletPrefab;

		// Token: 0x0400136E RID: 4974
		private CharacterController cc;

		// Token: 0x0400136F RID: 4975
		private Vector3 moveVector;

		// Token: 0x04001370 RID: 4976
		private bool fire;
	}
}
