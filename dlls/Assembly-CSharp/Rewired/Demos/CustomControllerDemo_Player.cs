using System;
using UnityEngine;

namespace Rewired.Demos
{
	// Token: 0x020002B0 RID: 688
	[AddComponentMenu("")]
	[RequireComponent(typeof(CharacterController))]
	public class CustomControllerDemo_Player : MonoBehaviour
	{
		// Token: 0x170002FA RID: 762
		// (get) Token: 0x06000E7E RID: 3710 RVA: 0x0004DFE6 File Offset: 0x0004C1E6
		private Player player
		{
			get
			{
				if (this._player == null)
				{
					this._player = ReInput.players.GetPlayer(this.playerId);
				}
				return this._player;
			}
		}

		// Token: 0x06000E7F RID: 3711 RVA: 0x0004E00C File Offset: 0x0004C20C
		private void Awake()
		{
			this.cc = base.GetComponent<CharacterController>();
		}

		// Token: 0x06000E80 RID: 3712 RVA: 0x0004E01C File Offset: 0x0004C21C
		private void Update()
		{
			if (!ReInput.isReady)
			{
				return;
			}
			Vector2 a = new Vector2(this.player.GetAxis("Move Horizontal"), this.player.GetAxis("Move Vertical"));
			this.cc.Move(a * this.speed * Time.deltaTime);
			if (this.player.GetButtonDown("Fire"))
			{
				Vector3 b = Vector3.Scale(new Vector3(1f, 0f, 0f), base.transform.right);
				GameObject gameObject = Object.Instantiate<GameObject>(this.bulletPrefab, base.transform.position + b, Quaternion.identity);
				Vector3 velocity = new Vector3(this.bulletSpeed * base.transform.right.x, 0f, 0f);
				gameObject.GetComponent<Rigidbody>().velocity = velocity;
			}
			if (this.player.GetButtonDown("Change Color"))
			{
				Renderer component = base.GetComponent<Renderer>();
				Material material = component.material;
				material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
				component.material = material;
			}
		}

		// Token: 0x04001329 RID: 4905
		public int playerId;

		// Token: 0x0400132A RID: 4906
		public float speed = 1f;

		// Token: 0x0400132B RID: 4907
		public float bulletSpeed = 20f;

		// Token: 0x0400132C RID: 4908
		public GameObject bulletPrefab;

		// Token: 0x0400132D RID: 4909
		private Player _player;

		// Token: 0x0400132E RID: 4910
		private CharacterController cc;
	}
}
