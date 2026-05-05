using System;
using System.Collections.Generic;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000EF RID: 239
	[Serializable]
	public class InteractionEffector
	{
		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000814 RID: 2068 RVA: 0x000350A9 File Offset: 0x000332A9
		// (set) Token: 0x06000815 RID: 2069 RVA: 0x000350B1 File Offset: 0x000332B1
		public FullBodyBipedEffector effectorType { get; private set; }

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000816 RID: 2070 RVA: 0x000350BA File Offset: 0x000332BA
		// (set) Token: 0x06000817 RID: 2071 RVA: 0x000350C2 File Offset: 0x000332C2
		public bool isPaused { get; private set; }

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000818 RID: 2072 RVA: 0x000350CB File Offset: 0x000332CB
		// (set) Token: 0x06000819 RID: 2073 RVA: 0x000350D3 File Offset: 0x000332D3
		public InteractionObject interactionObject { get; private set; }

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600081A RID: 2074 RVA: 0x000350DC File Offset: 0x000332DC
		public bool inInteraction
		{
			get
			{
				return this.interactionObject != null;
			}
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x000350EA File Offset: 0x000332EA
		public InteractionEffector(FullBodyBipedEffector effectorType)
		{
			this.effectorType = effectorType;
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x00035104 File Offset: 0x00033304
		public void Initiate(InteractionSystem interactionSystem)
		{
			this.interactionSystem = interactionSystem;
			this.effector = interactionSystem.ik.solver.GetEffector(this.effectorType);
			this.poser = this.effector.bone.GetComponent<Poser>();
			this.StoreDefaults();
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x00035150 File Offset: 0x00033350
		public void StoreDefaults()
		{
			if (this.interactionSystem == null)
			{
				return;
			}
			this.defaultPositionWeight = this.interactionSystem.ik.solver.GetEffector(this.effectorType).positionWeight;
			this.defaultRotationWeight = this.interactionSystem.ik.solver.GetEffector(this.effectorType).rotationWeight;
			this.defaultPoserWeight = ((this.poser != null) ? this.poser.weight : 0f);
			this.defaultPull = this.interactionSystem.ik.solver.GetChain(this.effectorType).pull;
			this.defaultReach = this.interactionSystem.ik.solver.GetChain(this.effectorType).reach;
			this.defaultPush = this.interactionSystem.ik.solver.GetChain(this.effectorType).push;
			this.defaultPushParent = this.interactionSystem.ik.solver.GetChain(this.effectorType).pushParent;
			this.defaultBendGoalWeight = this.interactionSystem.ik.solver.GetChain(this.effectorType).bendConstraint.weight;
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x000352A4 File Offset: 0x000334A4
		public bool ResetToDefaults(float speed, float deltaTime)
		{
			if (this.inInteraction)
			{
				return false;
			}
			if (this.isPaused)
			{
				return false;
			}
			if (this.defaults)
			{
				return false;
			}
			this.resetTimer = Mathf.MoveTowards(this.resetTimer, 0f, deltaTime * speed);
			if (this.effector.isEndEffector)
			{
				if (this.pullUsed)
				{
					this.interactionSystem.ik.solver.GetChain(this.effectorType).pull = Mathf.Lerp(this.defaultPull, this.interactionSystem.ik.solver.GetChain(this.effectorType).pull, this.resetTimer);
				}
				if (this.reachUsed)
				{
					this.interactionSystem.ik.solver.GetChain(this.effectorType).reach = Mathf.Lerp(this.defaultReach, this.interactionSystem.ik.solver.GetChain(this.effectorType).reach, this.resetTimer);
				}
				if (this.pushUsed)
				{
					this.interactionSystem.ik.solver.GetChain(this.effectorType).push = Mathf.Lerp(this.defaultPush, this.interactionSystem.ik.solver.GetChain(this.effectorType).push, this.resetTimer);
				}
				if (this.pushParentUsed)
				{
					this.interactionSystem.ik.solver.GetChain(this.effectorType).pushParent = Mathf.Lerp(this.defaultPushParent, this.interactionSystem.ik.solver.GetChain(this.effectorType).pushParent, this.resetTimer);
				}
				if (this.bendGoalWeightUsed)
				{
					this.interactionSystem.ik.solver.GetChain(this.effectorType).bendConstraint.weight = Mathf.Lerp(this.defaultBendGoalWeight, this.interactionSystem.ik.solver.GetChain(this.effectorType).bendConstraint.weight, this.resetTimer);
				}
			}
			if (this.positionWeightUsed)
			{
				this.effector.positionWeight = Mathf.Lerp(this.defaultPositionWeight, this.effector.positionWeight, this.resetTimer);
			}
			if (this.rotationWeightUsed)
			{
				this.effector.rotationWeight = Mathf.Lerp(this.defaultRotationWeight, this.effector.rotationWeight, this.resetTimer);
			}
			if (this.resetTimer <= 0f)
			{
				this.pullUsed = false;
				this.reachUsed = false;
				this.pushUsed = false;
				this.pushParentUsed = false;
				this.positionWeightUsed = false;
				this.rotationWeightUsed = false;
				this.bendGoalWeightUsed = false;
				this.poserUsed = false;
				this.defaults = true;
			}
			return true;
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x0003556C File Offset: 0x0003376C
		public bool Pause()
		{
			if (!this.inInteraction)
			{
				return false;
			}
			this.isPaused = true;
			this.pausePositionRelative = this.target.InverseTransformPoint(this.effector.position);
			this.pauseRotationRelative = Quaternion.Inverse(this.target.rotation) * this.effector.rotation;
			if (this.interactionSystem.OnInteractionPause != null)
			{
				this.interactionSystem.OnInteractionPause(this.effectorType, this.interactionObject);
			}
			return true;
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x000355F6 File Offset: 0x000337F6
		public bool Resume()
		{
			if (!this.inInteraction)
			{
				return false;
			}
			this.isPaused = false;
			if (this.interactionSystem.OnInteractionResume != null)
			{
				this.interactionSystem.OnInteractionResume(this.effectorType, this.interactionObject);
			}
			return true;
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x00035634 File Offset: 0x00033834
		public bool Start(InteractionObject interactionObject, string tag, float fadeInTime, bool interrupt)
		{
			InteractionTarget interactionTarget = null;
			this.target = interactionObject.GetTarget(this.effectorType, tag);
			if (this.target != null)
			{
				interactionTarget = this.target.GetComponent<InteractionTarget>();
			}
			return this.Start(interactionObject, interactionTarget, fadeInTime, interrupt);
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x0003567C File Offset: 0x0003387C
		public bool Start(InteractionObject interactionObject, InteractionTarget interactionTarget, float fadeInTime, bool interrupt)
		{
			this.interactionTarget = interactionTarget;
			if (!this.inInteraction)
			{
				this.effector.position = this.effector.bone.position;
				this.effector.rotation = this.effector.bone.rotation;
			}
			else
			{
				if (!interrupt)
				{
					return false;
				}
				this.defaults = false;
			}
			this.target = ((interactionTarget != null) ? interactionTarget.transform : interactionObject.transform);
			this.interactionObject = interactionObject;
			if (this.interactionSystem.OnInteractionStart != null)
			{
				this.interactionSystem.OnInteractionStart(this.effectorType, interactionObject);
			}
			interactionObject.OnStartInteraction(this.interactionSystem);
			this.triggered.Clear();
			for (int i = 0; i < interactionObject.events.Length; i++)
			{
				this.triggered.Add(false);
			}
			this.positionWeightUsed = interactionObject.CurveUsed(InteractionObject.WeightCurve.Type.PositionWeight);
			this.rotationWeightUsed = interactionObject.CurveUsed(InteractionObject.WeightCurve.Type.RotationWeight);
			this.pullUsed = interactionObject.CurveUsed(InteractionObject.WeightCurve.Type.Pull);
			this.reachUsed = interactionObject.CurveUsed(InteractionObject.WeightCurve.Type.Reach);
			this.pushUsed = interactionObject.CurveUsed(InteractionObject.WeightCurve.Type.Push);
			this.pushParentUsed = interactionObject.CurveUsed(InteractionObject.WeightCurve.Type.PushParent);
			this.bendGoalWeightUsed = interactionObject.CurveUsed(InteractionObject.WeightCurve.Type.BendGoalWeight);
			this.poserUsed = (this.poser != null && interactionObject.CurveUsed(InteractionObject.WeightCurve.Type.PoserWeight));
			if (this.poser != null && this.poserUsed)
			{
				if (this.poser.poseRoot == null)
				{
					this.poser.weight = 0f;
				}
				if (interactionTarget != null)
				{
					if (interactionTarget.usePoser)
					{
						this.poser.poseRoot = this.target.transform;
						this.poser.AutoMapping(interactionTarget.bones);
					}
				}
				else
				{
					this.poser.poseRoot = null;
				}
				this.poser.AutoMapping();
			}
			if (this.defaults)
			{
				this.StoreDefaults();
			}
			this.timer = 0f;
			this.weight = 0f;
			this.fadeInSpeed = ((fadeInTime > 0f) ? (1f / fadeInTime) : 1000f);
			this.length = interactionObject.length;
			this.isPaused = false;
			this.pickedUp = false;
			this.pickUpPosition = Vector3.zero;
			this.pickUpRotation = Quaternion.identity;
			if (interactionTarget != null)
			{
				interactionTarget.RotateTo(this.effector.bone);
			}
			this.started = true;
			return true;
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x000358F4 File Offset: 0x00033AF4
		public void Update(Transform root, float speed, float deltaTime)
		{
			if (!this.inInteraction)
			{
				if (this.started)
				{
					this.isPaused = false;
					this.pickedUp = false;
					this.defaults = false;
					this.resetTimer = 1f;
					this.started = false;
				}
				return;
			}
			if (this.interactionTarget != null && !this.interactionTarget.rotateOnce)
			{
				this.interactionTarget.RotateTo(this.effector.bone);
			}
			if (this.isPaused)
			{
				if (!this.pickedUp)
				{
					this.effector.position = this.target.TransformPoint(this.pausePositionRelative);
					this.effector.rotation = this.target.rotation * this.pauseRotationRelative;
				}
				this.interactionObject.Apply(this.interactionSystem.ik.solver, this.effectorType, this.interactionTarget, this.timer, this.weight, true);
				return;
			}
			this.timer += deltaTime * speed * ((this.interactionTarget != null) ? this.interactionTarget.interactionSpeedMlp : 1f);
			this.weight = Mathf.Clamp(this.weight + deltaTime * this.fadeInSpeed * speed, 0f, 1f);
			bool flag = false;
			bool flag2 = false;
			this.TriggerUntriggeredEvents(true, out flag, out flag2);
			Vector3 b = this.pickedUp ? this.interactionSystem.transform.TransformPoint(this.pickUpPosition) : this.target.position;
			Quaternion b2 = this.pickedUp ? (this.interactionSystem.transform.rotation * this.pickUpRotation) : this.target.rotation;
			this.effector.position = Vector3.Lerp(this.effector.bone.position, b, this.weight);
			this.effector.rotation = Quaternion.Lerp(this.effector.bone.rotation, b2, this.weight);
			this.interactionObject.Apply(this.interactionSystem.ik.solver, this.effectorType, this.interactionTarget, this.timer, this.weight, false);
			if (flag)
			{
				this.PickUp(root);
			}
			if (flag2)
			{
				this.Pause();
			}
			float value = this.interactionObject.GetValue(InteractionObject.WeightCurve.Type.PoserWeight, this.interactionTarget, this.timer);
			if (this.poser != null && this.poserUsed)
			{
				this.poser.weight = Mathf.Lerp(this.poser.weight, value, this.weight);
			}
			else if (value > 0f)
			{
				Warning.Log(string.Concat(new string[]
				{
					"InteractionObject ",
					this.interactionObject.name,
					" has a curve/multipler for Poser Weight, but the bone of effector ",
					this.effectorType.ToString(),
					" has no HandPoser/GenericPoser attached."
				}), this.effector.bone, false);
			}
			if (this.timer >= this.length)
			{
				this.Stop();
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000824 RID: 2084 RVA: 0x00035C13 File Offset: 0x00033E13
		public float progress
		{
			get
			{
				if (!this.inInteraction)
				{
					return 0f;
				}
				if (this.length == 0f)
				{
					return 0f;
				}
				return this.timer / this.length;
			}
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x00035C44 File Offset: 0x00033E44
		private void TriggerUntriggeredEvents(bool checkTime, out bool pickUp, out bool pause)
		{
			pickUp = false;
			pause = false;
			for (int i = 0; i < this.triggered.Count; i++)
			{
				if (!this.triggered[i] && (!checkTime || this.interactionObject.events[i].time < this.timer))
				{
					this.interactionObject.events[i].Activate(this.effector.bone);
					if (this.interactionObject.events[i].pickUp)
					{
						if (this.timer >= this.interactionObject.events[i].time)
						{
							this.timer = this.interactionObject.events[i].time;
						}
						pickUp = true;
					}
					if (this.interactionObject.events[i].pause)
					{
						if (this.timer >= this.interactionObject.events[i].time)
						{
							this.timer = this.interactionObject.events[i].time;
						}
						pause = true;
					}
					if (this.interactionSystem.OnInteractionEvent != null)
					{
						this.interactionSystem.OnInteractionEvent(this.effectorType, this.interactionObject, this.interactionObject.events[i]);
					}
					this.triggered[i] = true;
				}
			}
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x00035D98 File Offset: 0x00033F98
		private void PickUp(Transform root)
		{
			this.pickUpPosition = root.InverseTransformPoint(this.effector.position);
			this.pickUpRotation = Quaternion.Inverse(this.interactionSystem.transform.rotation) * this.effector.rotation;
			this.pickUpOnPostFBBIK = true;
			this.pickedUp = true;
			Rigidbody component = this.interactionObject.targetsRoot.GetComponent<Rigidbody>();
			if (component != null)
			{
				if (!component.isKinematic)
				{
					component.isKinematic = true;
				}
				Collider component2 = root.GetComponent<Collider>();
				if (component2 != null)
				{
					foreach (Collider collider in this.interactionObject.targetsRoot.GetComponentsInChildren<Collider>())
					{
						if (!collider.isTrigger && collider.enabled)
						{
							Physics.IgnoreCollision(component2, collider);
						}
					}
				}
			}
			if (this.interactionSystem.OnInteractionPickUp != null)
			{
				this.interactionSystem.OnInteractionPickUp(this.effectorType, this.interactionObject);
			}
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x00035E98 File Offset: 0x00034098
		public bool Stop()
		{
			if (!this.inInteraction)
			{
				return false;
			}
			bool flag = false;
			bool flag2 = false;
			this.TriggerUntriggeredEvents(false, out flag, out flag2);
			if (this.interactionSystem.OnInteractionStop != null)
			{
				this.interactionSystem.OnInteractionStop(this.effectorType, this.interactionObject);
			}
			if (this.interactionTarget != null)
			{
				this.interactionTarget.ResetRotation();
			}
			this.interactionObject = null;
			this.weight = 0f;
			this.timer = 0f;
			this.isPaused = false;
			this.target = null;
			this.defaults = false;
			this.resetTimer = 1f;
			this.pickedUp = false;
			this.started = false;
			return true;
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x00035F4C File Offset: 0x0003414C
		public void OnPostFBBIK()
		{
			if (!this.inInteraction)
			{
				return;
			}
			float num = this.interactionObject.GetValue(InteractionObject.WeightCurve.Type.RotateBoneWeight, this.interactionTarget, this.timer) * this.weight;
			if (num > 0f)
			{
				Quaternion b = this.pickedUp ? (this.interactionSystem.transform.rotation * this.pickUpRotation) : this.effector.rotation;
				Quaternion rhs = Quaternion.Slerp(this.effector.bone.rotation, b, num * num);
				this.effector.bone.localRotation = Quaternion.Inverse(this.effector.bone.parent.rotation) * rhs;
			}
			if (this.pickUpOnPostFBBIK)
			{
				Vector3 position = this.effector.bone.position;
				this.effector.bone.position = this.interactionSystem.transform.TransformPoint(this.pickUpPosition);
				this.interactionObject.targetsRoot.parent = this.effector.bone;
				this.effector.bone.position = position;
				this.pickUpOnPostFBBIK = false;
			}
		}

		// Token: 0x04000779 RID: 1913
		private Poser poser;

		// Token: 0x0400077A RID: 1914
		private IKEffector effector;

		// Token: 0x0400077B RID: 1915
		private float timer;

		// Token: 0x0400077C RID: 1916
		private float length;

		// Token: 0x0400077D RID: 1917
		private float weight;

		// Token: 0x0400077E RID: 1918
		private float fadeInSpeed;

		// Token: 0x0400077F RID: 1919
		private float defaultPositionWeight;

		// Token: 0x04000780 RID: 1920
		private float defaultRotationWeight;

		// Token: 0x04000781 RID: 1921
		private float defaultPull;

		// Token: 0x04000782 RID: 1922
		private float defaultReach;

		// Token: 0x04000783 RID: 1923
		private float defaultPush;

		// Token: 0x04000784 RID: 1924
		private float defaultPushParent;

		// Token: 0x04000785 RID: 1925
		private float defaultBendGoalWeight;

		// Token: 0x04000786 RID: 1926
		private float defaultPoserWeight;

		// Token: 0x04000787 RID: 1927
		private float resetTimer;

		// Token: 0x04000788 RID: 1928
		private bool positionWeightUsed;

		// Token: 0x04000789 RID: 1929
		private bool rotationWeightUsed;

		// Token: 0x0400078A RID: 1930
		private bool pullUsed;

		// Token: 0x0400078B RID: 1931
		private bool reachUsed;

		// Token: 0x0400078C RID: 1932
		private bool pushUsed;

		// Token: 0x0400078D RID: 1933
		private bool pushParentUsed;

		// Token: 0x0400078E RID: 1934
		private bool bendGoalWeightUsed;

		// Token: 0x0400078F RID: 1935
		private bool poserUsed;

		// Token: 0x04000790 RID: 1936
		private bool pickedUp;

		// Token: 0x04000791 RID: 1937
		private bool defaults;

		// Token: 0x04000792 RID: 1938
		private bool pickUpOnPostFBBIK;

		// Token: 0x04000793 RID: 1939
		private Vector3 pickUpPosition;

		// Token: 0x04000794 RID: 1940
		private Vector3 pausePositionRelative;

		// Token: 0x04000795 RID: 1941
		private Quaternion pickUpRotation;

		// Token: 0x04000796 RID: 1942
		private Quaternion pauseRotationRelative;

		// Token: 0x04000797 RID: 1943
		private InteractionTarget interactionTarget;

		// Token: 0x04000798 RID: 1944
		private Transform target;

		// Token: 0x04000799 RID: 1945
		private List<bool> triggered = new List<bool>();

		// Token: 0x0400079A RID: 1946
		private InteractionSystem interactionSystem;

		// Token: 0x0400079B RID: 1947
		private bool started;
	}
}
