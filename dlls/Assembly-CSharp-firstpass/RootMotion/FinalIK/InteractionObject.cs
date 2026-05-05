using System;
using UnityEngine;
using UnityEngine.Events;

namespace RootMotion.FinalIK
{
	// Token: 0x020000F1 RID: 241
	[HelpURL("https://www.youtube.com/watch?v=r5jiZnsDH3M")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/Interaction System/Interaction Object")]
	public class InteractionObject : MonoBehaviour
	{
		// Token: 0x0600082F RID: 2095 RVA: 0x00036379 File Offset: 0x00034579
		[ContextMenu("User Manual")]
		private void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page10.html");
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x00036385 File Offset: 0x00034585
		[ContextMenu("Scrpt Reference")]
		private void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_interaction_object.html");
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x00036391 File Offset: 0x00034591
		[ContextMenu("TUTORIAL VIDEO (PART 1: BASICS)")]
		private void OpenTutorial1()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=r5jiZnsDH3M");
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x0003639D File Offset: 0x0003459D
		[ContextMenu("TUTORIAL VIDEO (PART 2: PICKING UP...)")]
		private void OpenTutorial2()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=eP9-zycoHLk");
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x000363A9 File Offset: 0x000345A9
		[ContextMenu("TUTORIAL VIDEO (PART 3: ANIMATION)")]
		private void OpenTutorial3()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=sQfB2RcT1T4&index=14&list=PLVxSIA1OaTOu8Nos3CalXbJ2DrKnntMv6");
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x000363B5 File Offset: 0x000345B5
		[ContextMenu("TUTORIAL VIDEO (PART 4: TRIGGERS)")]
		private void OpenTutorial4()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=-TDZpNjt2mk&index=15&list=PLVxSIA1OaTOu8Nos3CalXbJ2DrKnntMv6");
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x00002403 File Offset: 0x00000603
		[ContextMenu("Support Group")]
		private void SupportGroup()
		{
			Application.OpenURL("https://groups.google.com/forum/#!forum/final-ik");
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x0000240F File Offset: 0x0000060F
		[ContextMenu("Asset Store Thread")]
		private void ASThread()
		{
			Application.OpenURL("http://forum.unity3d.com/threads/final-ik-full-body-ik-aim-look-at-fabrik-ccd-ik-1-0-released.222685/");
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000837 RID: 2103 RVA: 0x000363C1 File Offset: 0x000345C1
		// (set) Token: 0x06000838 RID: 2104 RVA: 0x000363C9 File Offset: 0x000345C9
		public float length { get; private set; }

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000839 RID: 2105 RVA: 0x000363D2 File Offset: 0x000345D2
		// (set) Token: 0x0600083A RID: 2106 RVA: 0x000363DA File Offset: 0x000345DA
		public InteractionSystem lastUsedInteractionSystem { get; private set; }

		// Token: 0x0600083B RID: 2107 RVA: 0x000363E4 File Offset: 0x000345E4
		public void Initiate()
		{
			for (int i = 0; i < this.weightCurves.Length; i++)
			{
				if (this.weightCurves[i].curve.length > 0)
				{
					float time = this.weightCurves[i].curve.keys[this.weightCurves[i].curve.length - 1].time;
					this.length = Mathf.Clamp(this.length, time, this.length);
				}
			}
			for (int j = 0; j < this.events.Length; j++)
			{
				this.length = Mathf.Clamp(this.length, this.events[j].time, this.length);
			}
			this.targets = this.targetsRoot.GetComponentsInChildren<InteractionTarget>();
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x0600083C RID: 2108 RVA: 0x000364AA File Offset: 0x000346AA
		public Transform lookAtTarget
		{
			get
			{
				if (this.otherLookAtTarget != null)
				{
					return this.otherLookAtTarget;
				}
				return base.transform;
			}
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x000364C8 File Offset: 0x000346C8
		public InteractionTarget GetTarget(FullBodyBipedEffector effectorType, InteractionSystem interactionSystem)
		{
			if (string.IsNullOrEmpty(interactionSystem.tag))
			{
				foreach (InteractionTarget interactionTarget in this.targets)
				{
					if (interactionTarget.effectorType == effectorType)
					{
						return interactionTarget;
					}
				}
				return null;
			}
			foreach (InteractionTarget interactionTarget2 in this.targets)
			{
				if (interactionTarget2.effectorType == effectorType && interactionTarget2.CompareTag(interactionSystem.tag))
				{
					return interactionTarget2;
				}
			}
			return null;
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x0003653C File Offset: 0x0003473C
		public bool CurveUsed(InteractionObject.WeightCurve.Type type)
		{
			InteractionObject.WeightCurve[] array = this.weightCurves;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].type == type)
				{
					return true;
				}
			}
			InteractionObject.Multiplier[] array2 = this.multipliers;
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i].result == type)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x0003658E File Offset: 0x0003478E
		public InteractionTarget[] GetTargets()
		{
			return this.targets;
		}

		// Token: 0x06000840 RID: 2112 RVA: 0x00036598 File Offset: 0x00034798
		public Transform GetTarget(FullBodyBipedEffector effectorType, string tag)
		{
			if (tag == string.Empty || tag == "")
			{
				return this.GetTarget(effectorType);
			}
			for (int i = 0; i < this.targets.Length; i++)
			{
				if (this.targets[i].effectorType == effectorType && this.targets[i].CompareTag(tag))
				{
					return this.targets[i].transform;
				}
			}
			return base.transform;
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x0003660E File Offset: 0x0003480E
		public void OnStartInteraction(InteractionSystem interactionSystem)
		{
			this.lastUsedInteractionSystem = interactionSystem;
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x00036618 File Offset: 0x00034818
		public void Apply(IKSolverFullBodyBiped solver, FullBodyBipedEffector effector, InteractionTarget target, float timer, float weight, bool isPaused)
		{
			for (int i = 0; i < this.weightCurves.Length; i++)
			{
				if (!isPaused || (this.weightCurves[i].type != InteractionObject.WeightCurve.Type.PositionOffsetX && this.weightCurves[i].type != InteractionObject.WeightCurve.Type.PositionOffsetY && this.weightCurves[i].type != InteractionObject.WeightCurve.Type.PositionOffsetZ))
				{
					float num = (target == null) ? 1f : target.GetValue(this.weightCurves[i].type);
					this.Apply(solver, effector, this.weightCurves[i].type, this.weightCurves[i].GetValue(timer), weight * num);
				}
			}
			for (int j = 0; j < this.multipliers.Length; j++)
			{
				if (!isPaused || (this.multipliers[j].result != InteractionObject.WeightCurve.Type.PositionOffsetX && this.multipliers[j].result != InteractionObject.WeightCurve.Type.PositionOffsetY && this.multipliers[j].result != InteractionObject.WeightCurve.Type.PositionOffsetZ))
				{
					if (this.multipliers[j].curve == this.multipliers[j].result && !Warning.logged)
					{
						Warning.Log("InteractionObject Multiplier 'Curve' " + this.multipliers[j].curve.ToString() + "and 'Result' are the same.", base.transform, false);
					}
					int weightCurveIndex = this.GetWeightCurveIndex(this.multipliers[j].curve);
					if (weightCurveIndex != -1)
					{
						float num2 = (target == null) ? 1f : target.GetValue(this.multipliers[j].result);
						this.Apply(solver, effector, this.multipliers[j].result, this.multipliers[j].GetValue(this.weightCurves[weightCurveIndex], timer), weight * num2);
					}
					else if (!Warning.logged)
					{
						Warning.Log("InteractionObject Multiplier curve " + this.multipliers[j].curve.ToString() + "does not exist.", base.transform, false);
					}
				}
			}
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x00036814 File Offset: 0x00034A14
		public float GetValue(InteractionObject.WeightCurve.Type weightCurveType, InteractionTarget target, float timer)
		{
			int weightCurveIndex = this.GetWeightCurveIndex(weightCurveType);
			if (weightCurveIndex != -1)
			{
				float num = (target == null) ? 1f : target.GetValue(weightCurveType);
				return this.weightCurves[weightCurveIndex].GetValue(timer) * num;
			}
			for (int i = 0; i < this.multipliers.Length; i++)
			{
				if (this.multipliers[i].result == weightCurveType)
				{
					int weightCurveIndex2 = this.GetWeightCurveIndex(this.multipliers[i].curve);
					if (weightCurveIndex2 != -1)
					{
						float num2 = (target == null) ? 1f : target.GetValue(this.multipliers[i].result);
						return this.multipliers[i].GetValue(this.weightCurves[weightCurveIndex2], timer) * num2;
					}
				}
			}
			return 0f;
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000844 RID: 2116 RVA: 0x000368D5 File Offset: 0x00034AD5
		public Transform targetsRoot
		{
			get
			{
				if (this.otherTargetsRoot != null)
				{
					return this.otherTargetsRoot;
				}
				return base.transform;
			}
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x000368F2 File Offset: 0x00034AF2
		private void Start()
		{
			this.Initiate();
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x000368FC File Offset: 0x00034AFC
		private void Apply(IKSolverFullBodyBiped solver, FullBodyBipedEffector effector, InteractionObject.WeightCurve.Type type, float value, float weight)
		{
			switch (type)
			{
			case InteractionObject.WeightCurve.Type.PositionWeight:
				solver.GetEffector(effector).positionWeight = Mathf.Lerp(solver.GetEffector(effector).positionWeight, value, weight);
				return;
			case InteractionObject.WeightCurve.Type.RotationWeight:
				solver.GetEffector(effector).rotationWeight = Mathf.Lerp(solver.GetEffector(effector).rotationWeight, value, weight);
				return;
			case InteractionObject.WeightCurve.Type.PositionOffsetX:
			{
				Vector3 a = ((this.positionOffsetSpace != null) ? this.positionOffsetSpace.rotation : solver.GetRoot().rotation) * Vector3.right * value;
				solver.GetEffector(effector).position += a * weight;
				return;
			}
			case InteractionObject.WeightCurve.Type.PositionOffsetY:
			{
				Vector3 a2 = ((this.positionOffsetSpace != null) ? this.positionOffsetSpace.rotation : solver.GetRoot().rotation) * Vector3.up * value;
				solver.GetEffector(effector).position += a2 * weight;
				return;
			}
			case InteractionObject.WeightCurve.Type.PositionOffsetZ:
			{
				Vector3 a3 = ((this.positionOffsetSpace != null) ? this.positionOffsetSpace.rotation : solver.GetRoot().rotation) * Vector3.forward * value;
				solver.GetEffector(effector).position += a3 * weight;
				return;
			}
			case InteractionObject.WeightCurve.Type.Pull:
				solver.GetChain(effector).pull = Mathf.Lerp(solver.GetChain(effector).pull, value, weight);
				return;
			case InteractionObject.WeightCurve.Type.Reach:
				solver.GetChain(effector).reach = Mathf.Lerp(solver.GetChain(effector).reach, value, weight);
				return;
			case InteractionObject.WeightCurve.Type.RotateBoneWeight:
			case InteractionObject.WeightCurve.Type.PoserWeight:
				return;
			case InteractionObject.WeightCurve.Type.Push:
				solver.GetChain(effector).push = Mathf.Lerp(solver.GetChain(effector).push, value, weight);
				return;
			case InteractionObject.WeightCurve.Type.PushParent:
				solver.GetChain(effector).pushParent = Mathf.Lerp(solver.GetChain(effector).pushParent, value, weight);
				return;
			case InteractionObject.WeightCurve.Type.BendGoalWeight:
				solver.GetChain(effector).bendConstraint.weight = Mathf.Lerp(solver.GetChain(effector).bendConstraint.weight, value, weight);
				return;
			default:
				return;
			}
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x00036B40 File Offset: 0x00034D40
		private Transform GetTarget(FullBodyBipedEffector effectorType)
		{
			for (int i = 0; i < this.targets.Length; i++)
			{
				if (this.targets[i].effectorType == effectorType)
				{
					return this.targets[i].transform;
				}
			}
			return base.transform;
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x00036B84 File Offset: 0x00034D84
		private int GetWeightCurveIndex(InteractionObject.WeightCurve.Type weightCurveType)
		{
			for (int i = 0; i < this.weightCurves.Length; i++)
			{
				if (this.weightCurves[i].type == weightCurveType)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x00036BB8 File Offset: 0x00034DB8
		private int GetMultiplierIndex(InteractionObject.WeightCurve.Type weightCurveType)
		{
			for (int i = 0; i < this.multipliers.Length; i++)
			{
				if (this.multipliers[i].result == weightCurveType)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x040007A4 RID: 1956
		[Tooltip("If the Interaction System has a 'Look At' LookAtIK component assigned, will use it to make the character look at the specified Transform. If unassigned, will look at this GameObject.")]
		public Transform otherLookAtTarget;

		// Token: 0x040007A5 RID: 1957
		[Tooltip("The root Transform of the InteractionTargets. If null, will use this GameObject. GetComponentsInChildren<InteractionTarget>() will be used at initiation to find all InteractionTargets associated with this InteractionObject.")]
		public Transform otherTargetsRoot;

		// Token: 0x040007A6 RID: 1958
		[Tooltip("If assigned, all PositionOffset channels will be applied in the rotation space of this Transform. If not, they will be in the rotation space of the character.")]
		public Transform positionOffsetSpace;

		// Token: 0x040007A7 RID: 1959
		public InteractionObject.WeightCurve[] weightCurves;

		// Token: 0x040007A8 RID: 1960
		public InteractionObject.Multiplier[] multipliers;

		// Token: 0x040007A9 RID: 1961
		public InteractionObject.InteractionEvent[] events;

		// Token: 0x040007AC RID: 1964
		private InteractionTarget[] targets = new InteractionTarget[0];

		// Token: 0x020000F2 RID: 242
		[Serializable]
		public class InteractionEvent
		{
			// Token: 0x0600084B RID: 2123 RVA: 0x00036C00 File Offset: 0x00034E00
			public void Activate(Transform t)
			{
				this.unityEvent.Invoke();
				InteractionObject.AnimatorEvent[] array = this.animations;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Activate(this.pickUp);
				}
				InteractionObject.Message[] array2 = this.messages;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].Send(t);
				}
			}

			// Token: 0x040007AD RID: 1965
			[Tooltip("The time of the event since interaction start.")]
			public float time;

			// Token: 0x040007AE RID: 1966
			[Tooltip("If true, the interaction will be paused on this event. The interaction can be resumed by InteractionSystem.ResumeInteraction() or InteractionSystem.ResumeAll;")]
			public bool pause;

			// Token: 0x040007AF RID: 1967
			[Tooltip("If true, the object will be parented to the effector bone on this event. Note that picking up like this can be done by only a single effector at a time. If you wish to pick up an object with both hands, see the Interaction PickUp2Handed demo scene.")]
			public bool pickUp;

			// Token: 0x040007B0 RID: 1968
			[Tooltip("The animations called on this event.")]
			public InteractionObject.AnimatorEvent[] animations;

			// Token: 0x040007B1 RID: 1969
			[Tooltip("The messages sent on this event using GameObject.SendMessage().")]
			public InteractionObject.Message[] messages;

			// Token: 0x040007B2 RID: 1970
			[Tooltip("The UnityEvent to invoke on this event.")]
			public UnityEvent unityEvent;
		}

		// Token: 0x020000F3 RID: 243
		[Serializable]
		public class Message
		{
			// Token: 0x0600084D RID: 2125 RVA: 0x00036C5C File Offset: 0x00034E5C
			public void Send(Transform t)
			{
				if (this.recipient == null)
				{
					return;
				}
				if (this.function == string.Empty || this.function == "")
				{
					return;
				}
				this.recipient.SendMessage(this.function, t, SendMessageOptions.RequireReceiver);
			}

			// Token: 0x040007B3 RID: 1971
			[Tooltip("The name of the function called.")]
			public string function;

			// Token: 0x040007B4 RID: 1972
			[Tooltip("The recipient game object.")]
			public GameObject recipient;

			// Token: 0x040007B5 RID: 1973
			private const string empty = "";
		}

		// Token: 0x020000F4 RID: 244
		[Serializable]
		public class AnimatorEvent
		{
			// Token: 0x0600084F RID: 2127 RVA: 0x00036CB0 File Offset: 0x00034EB0
			public void Activate(bool pickUp)
			{
				if (this.animator != null)
				{
					if (pickUp)
					{
						this.animator.applyRootMotion = false;
					}
					this.Activate(this.animator);
				}
				if (this.animation != null)
				{
					this.Activate(this.animation);
				}
			}

			// Token: 0x06000850 RID: 2128 RVA: 0x00036D00 File Offset: 0x00034F00
			private void Activate(Animator animator)
			{
				if (this.animationState == "")
				{
					return;
				}
				if (this.resetNormalizedTime)
				{
					animator.CrossFade(this.animationState, this.crossfadeTime, this.layer, 0f);
					return;
				}
				animator.CrossFade(this.animationState, this.crossfadeTime, this.layer);
			}

			// Token: 0x06000851 RID: 2129 RVA: 0x00036D60 File Offset: 0x00034F60
			private void Activate(Animation animation)
			{
				if (this.animationState == "")
				{
					return;
				}
				if (this.resetNormalizedTime)
				{
					animation[this.animationState].normalizedTime = 0f;
				}
				animation[this.animationState].layer = this.layer;
				animation.CrossFade(this.animationState, this.crossfadeTime);
			}

			// Token: 0x040007B6 RID: 1974
			[Tooltip("The Animator component that will receive the AnimatorEvents.")]
			public Animator animator;

			// Token: 0x040007B7 RID: 1975
			[Tooltip("The Animation component that will receive the AnimatorEvents (Legacy).")]
			public Animation animation;

			// Token: 0x040007B8 RID: 1976
			[Tooltip("The name of the animation state.")]
			public string animationState;

			// Token: 0x040007B9 RID: 1977
			[Tooltip("The crossfading time.")]
			public float crossfadeTime = 0.3f;

			// Token: 0x040007BA RID: 1978
			[Tooltip("The layer of the animation state (if using Legacy, the animation state will be forced to this layer).")]
			public int layer;

			// Token: 0x040007BB RID: 1979
			[Tooltip("Should the animation always start from 0 normalized time?")]
			public bool resetNormalizedTime;

			// Token: 0x040007BC RID: 1980
			private const string empty = "";
		}

		// Token: 0x020000F5 RID: 245
		[Serializable]
		public class WeightCurve
		{
			// Token: 0x06000853 RID: 2131 RVA: 0x00036DDA File Offset: 0x00034FDA
			public float GetValue(float timer)
			{
				return this.curve.Evaluate(timer);
			}

			// Token: 0x040007BD RID: 1981
			[Tooltip("The type of the curve (InteractionObject.WeightCurve.Type).")]
			public InteractionObject.WeightCurve.Type type;

			// Token: 0x040007BE RID: 1982
			[Tooltip("The weight curve.")]
			public AnimationCurve curve;

			// Token: 0x020000F6 RID: 246
			[Serializable]
			public enum Type
			{
				// Token: 0x040007C0 RID: 1984
				PositionWeight,
				// Token: 0x040007C1 RID: 1985
				RotationWeight,
				// Token: 0x040007C2 RID: 1986
				PositionOffsetX,
				// Token: 0x040007C3 RID: 1987
				PositionOffsetY,
				// Token: 0x040007C4 RID: 1988
				PositionOffsetZ,
				// Token: 0x040007C5 RID: 1989
				Pull,
				// Token: 0x040007C6 RID: 1990
				Reach,
				// Token: 0x040007C7 RID: 1991
				RotateBoneWeight,
				// Token: 0x040007C8 RID: 1992
				Push,
				// Token: 0x040007C9 RID: 1993
				PushParent,
				// Token: 0x040007CA RID: 1994
				PoserWeight,
				// Token: 0x040007CB RID: 1995
				BendGoalWeight
			}
		}

		// Token: 0x020000F7 RID: 247
		[Serializable]
		public class Multiplier
		{
			// Token: 0x06000855 RID: 2133 RVA: 0x00036DE8 File Offset: 0x00034FE8
			public float GetValue(InteractionObject.WeightCurve weightCurve, float timer)
			{
				return weightCurve.GetValue(timer) * this.multiplier;
			}

			// Token: 0x040007CC RID: 1996
			[Tooltip("The curve type to multiply.")]
			public InteractionObject.WeightCurve.Type curve;

			// Token: 0x040007CD RID: 1997
			[Tooltip("The multiplier of the curve's value.")]
			public float multiplier = 1f;

			// Token: 0x040007CE RID: 1998
			[Tooltip("The resulting value will be applied to this channel.")]
			public InteractionObject.WeightCurve.Type result;
		}
	}
}
