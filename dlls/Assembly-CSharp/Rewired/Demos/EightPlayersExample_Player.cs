using System;
using UnityEngine;

namespace Rewired.Demos
{
	// Token: 0x020002B6 RID: 694
	[AddComponentMenu("")]
	[RequireComponent(typeof(CharacterController))]
	public class EightPlayersExample_Player : MonoBehaviour
	{
		// Token: 0x06000EA5 RID: 3749 RVA: 0x0004EB02 File Offset: 0x0004CD02
		private void Awake()
		{
			this.cc = base.GetComponent<CharacterController>();
		}

		// Token: 0x06000EA6 RID: 3750 RVA: 0x0004EB10 File Offset: 0x0004CD10
		private void Initialize()
		{
			this.player = ReInput.players.GetPlayer(this.playerId);
			this.initialized = true;
		}

		// Token: 0x06000EA7 RID: 3751 RVA: 0x0004EB2F File Offset: 0x0004CD2F
		private void Update()
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (!this.initialized)
			{
				this.Initialize();
			}
			this.GetInput();
			this.ProcessInput();
		}

		// Token: 0x06000EA8 RID: 3752 RVA: 0x0004EB54 File Offset: 0x0004CD54
		private void GetInput()
		{
			this.moveVector.x = this.player.GetAxis("Move Horizontal");
			this.moveVector.y = this.player.GetAxis("Move Vertical");
			this.fire = this.player.GetButtonDown("Fire");
		}

		// Token: 0x06000EA9 RID: 3753 RVA: 0x0004EBB0 File Offset: 0x0004CDB0
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

		// Token: 0x04001346 RID: 4934
		public int playerId;

		// Token: 0x04001347 RID: 4935
		public float moveSpeed = 3f;

		// Token: 0x04001348 RID: 4936
		public float bulletSpeed = 15f;

		// Token: 0x04001349 RID: 4937
		public GameObject bulletPrefab;

		// Token: 0x0400134A RID: 4938
		private Player player;

		// Token: 0x0400134B RID: 4939
		private CharacterController cc;

		// Token: 0x0400134C RID: 4940
		private Vector3 moveVector;

		// Token: 0x0400134D RID: 4941
		private bool fire;

		// Token: 0x0400134E RID: 4942
		[NonSerialized]
		private bool initialized;
	}
}
