using System;
using System.Collections;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000040 RID: 64
	[HelpURL("http://root-motion.com/puppetmasterdox/html/page11.html")]
	[AddComponentMenu("Scripts/RootMotion.Dynamics/PuppetMaster/Behaviours/BehaviourFall")]
	public class BehaviourFall : BehaviourBase
	{
		// Token: 0x060001A2 RID: 418 RVA: 0x0000919E File Offset: 0x0000739E
		protected override string GetTypeSpring()
		{
			return "BehaviourFall";
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x000091A5 File Offset: 0x000073A5
		[ContextMenu("User Manual")]
		private void OpenUserManual()
		{
			Application.OpenURL("http://root-motion.com/puppetmasterdox/html/page11.html");
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x000091B1 File Offset: 0x000073B1
		[ContextMenu("Scrpt Reference")]
		private void OpenScriptReference()
		{
			Application.OpenURL("http://root-motion.com/puppetmasterdox/html/class_root_motion_1_1_dynamics_1_1_behaviour_fall.html");
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x000091BD File Offset: 0x000073BD
		protected override void OnActivate()
		{
			base.forceActive = true;
			base.StopAllCoroutines();
			base.StartCoroutine(this.SmoothActivate());
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x000091D9 File Offset: 0x000073D9
		protected override void OnDeactivate()
		{
			base.forceActive = false;
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x000091E2 File Offset: 0x000073E2
		public override void OnReactivate()
		{
			this.timer = 0f;
			this.endTriggered = false;
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x000091F6 File Offset: 0x000073F6
		private IEnumerator SmoothActivate()
		{
			this.timer = 0f;
			this.endTriggered = false;
			this.puppetMaster.targetAnimator.CrossFadeInFixedTime(this.stateName, this.transitionDuration, this.layer, this.fixedTime);
			foreach (Muscle muscle in this.puppetMaster.muscles)
			{
				muscle.state.pinWeightMlp = 0f;
				muscle.rigidbody.velocity = muscle.mappedVelocity;
				muscle.rigidbody.angularVelocity = muscle.mappedAngularVelocity;
			}
			float fader = 0f;
			while (fader < 1f)
			{
				fader += Time.deltaTime;
				foreach (Muscle muscle2 in this.puppetMaster.muscles)
				{
					muscle2.state.pinWeightMlp = muscle2.state.pinWeightMlp - Time.deltaTime;
					muscle2.state.mappingWeightMlp = muscle2.state.mappingWeightMlp + Time.deltaTime * this.blendMappingSpeed;
				}
				yield return null;
			}
			yield break;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00009208 File Offset: 0x00007408
		protected override void OnFixedUpdate(float deltaTime)
		{
			if (this.raycastLayers == -1)
			{
				Debug.LogWarning("BehaviourFall has no layers to raycast to.", base.transform);
			}
			float blendTarget = this.GetBlendTarget(this.GetGroundHeight());
			float value = Mathf.MoveTowards(this.puppetMaster.targetAnimator.GetFloat(this.blendParameter), blendTarget, deltaTime * this.blendSpeed);
			this.puppetMaster.targetAnimator.SetFloat(this.blendParameter, value);
			this.timer += deltaTime;
			if (!this.endTriggered && this.canEnd && this.timer >= this.minTime && !this.puppetMaster.isBlending && this.puppetMaster.muscles[0].rigidbody.velocity.magnitude < this.maxEndVelocity)
			{
				this.endTriggered = true;
				this.onEnd.Trigger(this.puppetMaster, true);
				return;
			}
		}

		// Token: 0x060001AA RID: 426 RVA: 0x000092F8 File Offset: 0x000074F8
		protected override void OnLateUpdate(float deltaTime)
		{
			if (this.puppetMaster.muscles[0].state.mappingWeightMlp < 1f)
			{
				return;
			}
			if (this.puppetMaster.muscles[0].rigidbody.isKinematic)
			{
				return;
			}
			if (this.puppetMaster.isBlending)
			{
				return;
			}
			this.puppetMaster.targetRoot.position += this.puppetMaster.muscles[0].transform.position - this.puppetMaster.muscles[0].target.position;
			this.GroundTarget(this.raycastLayers);
		}

		// Token: 0x060001AB RID: 427 RVA: 0x000093A8 File Offset: 0x000075A8
		public override void Resurrect()
		{
			Muscle[] muscles = this.puppetMaster.muscles;
			for (int i = 0; i < muscles.Length; i++)
			{
				muscles[i].state.pinWeightMlp = 0f;
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x000093E4 File Offset: 0x000075E4
		private float GetBlendTarget(float groundHeight)
		{
			if (groundHeight > this.writheHeight)
			{
				return 1f;
			}
			Vector3 lhs = V3Tools.ExtractVertical(this.puppetMaster.muscles[0].rigidbody.velocity, this.puppetMaster.targetRoot.up, 1f);
			float num = lhs.magnitude;
			if (Vector3.Dot(lhs, this.puppetMaster.targetRoot.up) < 0f)
			{
				num = -num;
			}
			if (num > this.writheYVelocity)
			{
				return 1f;
			}
			return 0f;
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00009470 File Offset: 0x00007670
		private float GetGroundHeight()
		{
			RaycastHit raycastHit = default(RaycastHit);
			if (Physics.Raycast(this.puppetMaster.muscles[0].rigidbody.position, -this.puppetMaster.targetRoot.up, out raycastHit, 100f, this.raycastLayers))
			{
				return raycastHit.distance;
			}
			return float.PositiveInfinity;
		}

		// Token: 0x060001AE RID: 430 RVA: 0x000094D8 File Offset: 0x000076D8
		public override void OnMuscleReconnected(Muscle m)
		{
			base.OnMuscleReconnected(m);
			m.state.pinWeightMlp = 0f;
			m.state.muscleWeightMlp = 1f;
			m.state.muscleDamperMlp = 1f;
			m.state.maxForceMlp = 1f;
			m.state.mappingWeightMlp = 1f;
		}

		// Token: 0x04000151 RID: 337
		private const string typeSpring = "BehaviourFall";

		// Token: 0x04000152 RID: 338
		[LargeHeader("Animation State")]
		[Tooltip("Animation State to crossfade to when this behaviour is activated.")]
		public string stateName = "Falling";

		// Token: 0x04000153 RID: 339
		[Tooltip("The duration of crossfading to 'State Name'. Value is in seconds.")]
		public float transitionDuration = 0.4f;

		// Token: 0x04000154 RID: 340
		[Tooltip("Layer index containing the destination state. If no layer is specified or layer is -1, the first state that is found with the given name or hash will be played.")]
		public int layer;

		// Token: 0x04000155 RID: 341
		[Tooltip("Start time of the current destination state. Value is in seconds. If no explicit fixedTime is specified or fixedTime value is float.NegativeInfinity, the state will either be played from the start if it's not already playing, or will continue playing from its current time and no transition will happen.")]
		public float fixedTime;

		// Token: 0x04000156 RID: 342
		[LargeHeader("Blending")]
		[Tooltip("The layers that will be raycasted against to find colliding objects.")]
		public LayerMask raycastLayers;

		// Token: 0x04000157 RID: 343
		[Tooltip("The parameter in the Animator that blends between catch fall and writhe animations.")]
		public string blendParameter = "FallBlend";

		// Token: 0x04000158 RID: 344
		[Tooltip("The height of the pelvis from the ground at which will blend to writhe animation.")]
		public float writheHeight = 4f;

		// Token: 0x04000159 RID: 345
		[Tooltip("The vertical velocity of the pelvis at which will blend to writhe animation.")]
		public float writheYVelocity = 1f;

		// Token: 0x0400015A RID: 346
		[Tooltip("The speed of blendig between the two falling animations.")]
		public float blendSpeed = 3f;

		// Token: 0x0400015B RID: 347
		[Tooltip("The speed of blending in mapping on activation.")]
		public float blendMappingSpeed = 1f;

		// Token: 0x0400015C RID: 348
		[LargeHeader("Ending")]
		[Tooltip("If false, this behaviour will never end.")]
		public bool canEnd;

		// Token: 0x0400015D RID: 349
		[Tooltip("The minimum time since this behaviour activated before it can end.")]
		public float minTime = 1.5f;

		// Token: 0x0400015E RID: 350
		[Tooltip("If the velocity of the pelvis falls below this value, can end the behaviour.")]
		public float maxEndVelocity = 0.5f;

		// Token: 0x0400015F RID: 351
		[Tooltip("Event triggered when all end conditions are met.")]
		public BehaviourBase.PuppetEvent onEnd;

		// Token: 0x04000160 RID: 352
		private float timer;

		// Token: 0x04000161 RID: 353
		private bool endTriggered;
	}
}
