using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200015B RID: 347
	public class ExplosionDemo : MonoBehaviour
	{
		// Token: 0x06000A74 RID: 2676 RVA: 0x0004284C File Offset: 0x00040A4C
		private void Start()
		{
			this.defaultScale = base.transform.localScale;
			this.r = this.character.GetComponent<Rigidbody>();
			this.ik = this.character.GetComponent<FullBodyBipedIK>();
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x00042884 File Offset: 0x00040A84
		private void Update()
		{
			this.weight = Mathf.Clamp(this.weight - Time.deltaTime * this.weightFalloffSpeed, 0f, 1f);
			if (Input.GetKeyDown(KeyCode.E) && this.character.isGrounded)
			{
				this.ik.solver.IKPositionWeight = 1f;
				this.ik.solver.leftHandEffector.position = this.ik.solver.leftHandEffector.bone.position;
				this.ik.solver.rightHandEffector.position = this.ik.solver.rightHandEffector.bone.position;
				this.ik.solver.leftFootEffector.position = this.ik.solver.leftFootEffector.bone.position;
				this.ik.solver.rightFootEffector.position = this.ik.solver.rightFootEffector.bone.position;
				this.weight = 1f;
				Vector3 vector = this.r.position - base.transform.position;
				vector.y = 0f;
				float d = this.explosionForceByDistance.Evaluate(vector.magnitude);
				this.r.velocity = (vector.normalized + Vector3.up * this.upForce) * d * this.forceMlp;
			}
			if (this.weight < 0.5f && this.character.isGrounded)
			{
				this.weight = Mathf.Clamp(this.weight - Time.deltaTime * 3f, 0f, 1f);
			}
			this.SetEffectorWeights(this.weightFalloff.Evaluate(this.weight));
			base.transform.localScale = this.scale.Evaluate(this.weight) * this.defaultScale;
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x00042AA4 File Offset: 0x00040CA4
		private void SetEffectorWeights(float w)
		{
			this.ik.solver.leftHandEffector.positionWeight = w;
			this.ik.solver.rightHandEffector.positionWeight = w;
			this.ik.solver.leftFootEffector.positionWeight = w;
			this.ik.solver.rightFootEffector.positionWeight = w;
		}

		// Token: 0x04000A12 RID: 2578
		public SimpleLocomotion character;

		// Token: 0x04000A13 RID: 2579
		public float forceMlp = 1f;

		// Token: 0x04000A14 RID: 2580
		public float upForce = 1f;

		// Token: 0x04000A15 RID: 2581
		public float weightFalloffSpeed = 1f;

		// Token: 0x04000A16 RID: 2582
		public AnimationCurve weightFalloff;

		// Token: 0x04000A17 RID: 2583
		public AnimationCurve explosionForceByDistance;

		// Token: 0x04000A18 RID: 2584
		public AnimationCurve scale;

		// Token: 0x04000A19 RID: 2585
		private float weight;

		// Token: 0x04000A1A RID: 2586
		private Vector3 defaultScale = Vector3.one;

		// Token: 0x04000A1B RID: 2587
		private Rigidbody r;

		// Token: 0x04000A1C RID: 2588
		private FullBodyBipedIK ik;
	}
}
