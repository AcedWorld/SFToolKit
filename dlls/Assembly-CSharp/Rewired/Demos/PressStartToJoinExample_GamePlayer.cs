using System;
using UnityEngine;

namespace Rewired.Demos
{
	// Token: 0x020002BF RID: 703
	[AddComponentMenu("")]
	[RequireComponent(typeof(CharacterController))]
	public class PressStartToJoinExample_GamePlayer : MonoBehaviour
	{
		// Token: 0x17000300 RID: 768
		// (get) Token: 0x06000EE2 RID: 3810 RVA: 0x0004FDBB File Offset: 0x0004DFBB
		private Player player
		{
			get
			{
				return PressStartToJoinExample_Assigner.GetRewiredPlayer(this.gamePlayerId);
			}
		}

		// Token: 0x06000EE3 RID: 3811 RVA: 0x0004FDC8 File Offset: 0x0004DFC8
		private void OnEnable()
		{
			this.cc = base.GetComponent<CharacterController>();
		}

		// Token: 0x06000EE4 RID: 3812 RVA: 0x0004FDD6 File Offset: 0x0004DFD6
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

		// Token: 0x06000EE5 RID: 3813 RVA: 0x0004FDF8 File Offset: 0x0004DFF8
		private void GetInput()
		{
			this.moveVector.x = this.player.GetAxis("Move Horizontal");
			this.moveVector.y = this.player.GetAxis("Move Vertical");
			this.fire = this.player.GetButtonDown("Fire");
		}

		// Token: 0x06000EE6 RID: 3814 RVA: 0x0004FE54 File Offset: 0x0004E054
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

		// Token: 0x04001377 RID: 4983
		public int gamePlayerId;

		// Token: 0x04001378 RID: 4984
		public float moveSpeed = 3f;

		// Token: 0x04001379 RID: 4985
		public float bulletSpeed = 15f;

		// Token: 0x0400137A RID: 4986
		public GameObject bulletPrefab;

		// Token: 0x0400137B RID: 4987
		private CharacterController cc;

		// Token: 0x0400137C RID: 4988
		private Vector3 moveVector;

		// Token: 0x0400137D RID: 4989
		private bool fire;
	}
}
