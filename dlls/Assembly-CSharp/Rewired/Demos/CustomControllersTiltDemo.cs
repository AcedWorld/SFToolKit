using System;
using UnityEngine;

namespace Rewired.Demos
{
	// Token: 0x020002AE RID: 686
	[AddComponentMenu("")]
	public class CustomControllersTiltDemo : MonoBehaviour
	{
		// Token: 0x06000E6F RID: 3695 RVA: 0x0004DBD8 File Offset: 0x0004BDD8
		private void Awake()
		{
			Screen.orientation = ScreenOrientation.LandscapeLeft;
			this.player = ReInput.players.GetPlayer(0);
			ReInput.InputSourceUpdateEvent += this.OnInputUpdate;
			this.controller = (CustomController)this.player.controllers.GetControllerWithTag(ControllerType.Custom, "TiltController");
		}

		// Token: 0x06000E70 RID: 3696 RVA: 0x0004DC30 File Offset: 0x0004BE30
		private void Update()
		{
			if (this.target == null)
			{
				return;
			}
			Vector3 a = Vector3.zero;
			a.y = this.player.GetAxis("Tilt Vertical");
			a.x = this.player.GetAxis("Tilt Horizontal");
			if (a.sqrMagnitude > 1f)
			{
				a.Normalize();
			}
			a *= Time.deltaTime;
			this.target.Translate(a * this.speed);
		}

		// Token: 0x06000E71 RID: 3697 RVA: 0x0004DCB8 File Offset: 0x0004BEB8
		private void OnInputUpdate()
		{
			Vector3 acceleration = Input.acceleration;
			this.controller.SetAxisValue(0, acceleration.x);
			this.controller.SetAxisValue(1, acceleration.y);
			this.controller.SetAxisValue(2, acceleration.z);
		}

		// Token: 0x0400131A RID: 4890
		public Transform target;

		// Token: 0x0400131B RID: 4891
		public float speed = 10f;

		// Token: 0x0400131C RID: 4892
		private CustomController controller;

		// Token: 0x0400131D RID: 4893
		private Player player;
	}
}
