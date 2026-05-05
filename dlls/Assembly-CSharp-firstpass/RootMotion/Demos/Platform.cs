using System;
using System.Collections;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001A7 RID: 423
	public class Platform : MonoBehaviour
	{
		// Token: 0x06000B95 RID: 2965 RVA: 0x0004835F File Offset: 0x0004655F
		private void Start()
		{
			this.r = base.GetComponent<Rigidbody>();
			this.defaultPos = base.transform.position;
			this.targetPosition = base.transform.position;
			base.StartCoroutine(this.NewTargetPos());
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x0004839C File Offset: 0x0004659C
		private void FixedUpdate()
		{
			Platform.Mode mode = this.mode;
			if (mode != Platform.Mode.Random)
			{
				if (mode == Platform.Mode.Velocity)
				{
					this.r.MovePosition(this.r.position + this.velocity * Time.deltaTime);
				}
			}
			else
			{
				this.r.MovePosition(Vector3.SmoothDamp(this.r.position, this.targetPosition, ref this.velocity, 1f, this.moveSpeed));
			}
			foreach (Rigidbody rigidbody in this.rigidbodiesOnPlatform)
			{
				rigidbody.MovePosition(rigidbody.position + this.velocity * Time.deltaTime);
			}
			BehaviourPuppet[] array2 = this.puppetsOnPlatform;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].platformVelocity = this.velocity;
			}
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x00048473 File Offset: 0x00046673
		private IEnumerator NewTargetPos()
		{
			for (;;)
			{
				Platform.Mode mode = this.mode;
				if (mode != Platform.Mode.Random)
				{
					if (mode == Platform.Mode.Velocity)
					{
						yield return null;
					}
				}
				else
				{
					yield return new WaitForSeconds(Random.value * this.randomTime);
					Vector3 b = Random.insideUnitSphere * this.randomMag;
					b.y = 0f;
					this.targetPosition = this.defaultPos + b;
				}
			}
			yield break;
		}

		// Token: 0x04000B96 RID: 2966
		public Platform.Mode mode;

		// Token: 0x04000B97 RID: 2967
		[ShowIf("mode", Platform.Mode.Velocity, null, false, ShowIfMode.Hidden)]
		public Vector3 velocity;

		// Token: 0x04000B98 RID: 2968
		[ShowIf("mode", Platform.Mode.Random, null, false, ShowIfMode.Hidden)]
		public float randomMag = 10f;

		// Token: 0x04000B99 RID: 2969
		[ShowIf("mode", Platform.Mode.Random, null, false, ShowIfMode.Hidden)]
		public float randomTime = 3f;

		// Token: 0x04000B9A RID: 2970
		[ShowIf("mode", Platform.Mode.Random, null, false, ShowIfMode.Hidden)]
		public float moveSpeed = 5f;

		// Token: 0x04000B9B RID: 2971
		private Vector3 defaultPos;

		// Token: 0x04000B9C RID: 2972
		private Vector3 targetPosition;

		// Token: 0x04000B9D RID: 2973
		private Rigidbody r;

		// Token: 0x04000B9E RID: 2974
		public BehaviourPuppet[] puppetsOnPlatform;

		// Token: 0x04000B9F RID: 2975
		public Rigidbody[] rigidbodiesOnPlatform;

		// Token: 0x020001A8 RID: 424
		[Serializable]
		public enum Mode
		{
			// Token: 0x04000BA1 RID: 2977
			Random,
			// Token: 0x04000BA2 RID: 2978
			Velocity
		}
	}
}
