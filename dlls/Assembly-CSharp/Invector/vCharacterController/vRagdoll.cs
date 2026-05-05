using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Invector.vCharacterController
{
	// Token: 0x02000406 RID: 1030
	[vClassHeader("RAGDOLL SYSTEM", true, "ragdollIcon", true, "Every gameobject children of the character must have their tag added in the IgnoreTag List.")]
	public class vRagdoll : vMonoBehaviour
	{
		// Token: 0x170003BC RID: 956
		// (get) Token: 0x0600152C RID: 5420 RVA: 0x0006ECA3 File Offset: 0x0006CEA3
		// (set) Token: 0x0600152D RID: 5421 RVA: 0x0006ECAB File Offset: 0x0006CEAB
		public bool ignoreGetUpAnimation
		{
			get
			{
				return this._ignoreGetUpAnimation;
			}
			set
			{
				this._ignoreGetUpAnimation = value;
			}
		}

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x0600152E RID: 5422 RVA: 0x0006ECB4 File Offset: 0x0006CEB4
		// (set) Token: 0x0600152F RID: 5423 RVA: 0x0006ECC0 File Offset: 0x0006CEC0
		private bool ragdolled
		{
			get
			{
				return this.state > vRagdoll.RagdollState.animated;
			}
			set
			{
				if (value)
				{
					if (this.state == vRagdoll.RagdollState.animated)
					{
						this.setKinematic(false);
						this.setCollider(false);
						this.animator.enabled = false;
						this.state = vRagdoll.RagdollState.ragdolled;
						return;
					}
				}
				else
				{
					this.characterHips.parent = this.hipsParent;
					this.isActive = false;
					if (this.state == vRagdoll.RagdollState.ragdolled)
					{
						this.setKinematic(true);
						this.setCollider(true);
						this.ragdollingEndTime = Time.time;
						this.animator.enabled = true;
						this.state = vRagdoll.RagdollState.blendToAnim;
						foreach (vRagdoll.BodyPart bodyPart in this.bodyParts)
						{
							bodyPart.storedRotation = bodyPart.transform.rotation;
							bodyPart.storedPosition = bodyPart.transform.position;
						}
						this.ragdolledFeetPosition = 0.5f * (this.animator.GetBoneTransform(HumanBodyBones.LeftToes).position + this.animator.GetBoneTransform(HumanBodyBones.RightToes).position);
						this.ragdolledHeadPosition = this.animator.GetBoneTransform(HumanBodyBones.Head).position;
						this.ragdolledHipPosition = this.animator.GetBoneTransform(HumanBodyBones.Hips).position;
						if (!this.ignoreGetUpAnimation)
						{
							if (this.characterHips.TransformDirection(this.localY).y > 0f)
							{
								this.animator.Play("StandUp@FromBack");
								return;
							}
							this.animator.Play("StandUp@FromBelly");
						}
					}
				}
			}
		}

		// Token: 0x06001530 RID: 5424 RVA: 0x0006EE5C File Offset: 0x0006D05C
		private void Start()
		{
			this._parentRigb = base.GetComponent<Rigidbody>();
			this.iChar = base.GetComponent<vICharacter>();
			if (this.iChar != null)
			{
				this.iChar.onActiveRagdoll.AddListener(new UnityAction<vDamage>(this.ActivateRagdoll));
			}
			if (!this.collisionSource)
			{
				GameObject gameObject = new GameObject("ragdollAudioSource");
				gameObject.transform.SetParent(base.gameObject.transform);
				gameObject.transform.position = base.transform.position;
				this.collisionSource = gameObject.AddComponent<AudioSource>();
			}
			this.LoadBodyPart();
			this.CreateRagdollContainer();
			if (this.startRagdolled)
			{
				base.Invoke("ActivateRagdoll", 0.1f);
			}
		}

		// Token: 0x06001531 RID: 5425 RVA: 0x0006EF1C File Offset: 0x0006D11C
		public void LoadBodyPart()
		{
			this.bodyParts.Clear();
			if (!this.animator)
			{
				this.animator = base.GetComponent<Animator>();
			}
			this.characterChest = this.animator.GetBoneTransform(HumanBodyBones.Chest);
			this.characterHips = this.animator.GetBoneTransform(HumanBodyBones.Hips);
			this.localY = this.characterHips.InverseTransformDirection(Vector3.up);
			this.hipsParent = this.characterHips.parent;
			if (this.characterHips)
			{
				Component[] componentsInChildren = this.characterHips.GetComponentsInChildren(typeof(Transform));
				this.bodyParts.Add(new vRagdoll.BodyPart(this.characterHips));
				foreach (Component component in componentsInChildren)
				{
					if (!this.ignoreTags.Contains(component.tag) && component)
					{
						Transform transform = component as Transform;
						if (transform != base.transform && transform.GetComponent<Rigidbody>())
						{
							vRagdoll.BodyPart bodyPart = new vRagdoll.BodyPart(transform);
							if (bodyPart.rigidbody != null)
							{
								bodyPart.rigidbody.isKinematic = true;
								component.tag = base.gameObject.tag;
							}
							this.bodyParts.Add(bodyPart);
						}
					}
				}
				this.setKinematic(true);
				this.setCollider(true);
			}
		}

		// Token: 0x06001532 RID: 5426 RVA: 0x0006F079 File Offset: 0x0006D279
		private void CreateRagdollContainer()
		{
			if (!this._ragdollContainer)
			{
				this._ragdollContainer = new GameObject("RagdollContainer " + base.gameObject.name);
			}
		}

		// Token: 0x06001533 RID: 5427 RVA: 0x0006F0A8 File Offset: 0x0006D2A8
		private void LateUpdate()
		{
			if (this.animator == null)
			{
				return;
			}
			if (!this.updateBehaviour && this.animator.updateMode == AnimatorUpdateMode.AnimatePhysics)
			{
				return;
			}
			this.updateBehaviour = false;
			this.RagdollBehaviour();
		}

		// Token: 0x06001534 RID: 5428 RVA: 0x0006F0E0 File Offset: 0x0006D2E0
		private void FixedUpdate()
		{
			this.updateBehaviour = true;
			if (!this.isActive)
			{
				return;
			}
			if (this.iChar.currentHealth > 0f)
			{
				if (!this._ragdollContainer)
				{
					this.CreateRagdollContainer();
				}
				if (this.characterHips.parent != this._ragdollContainer.transform)
				{
					this.characterHips.SetParent(this._ragdollContainer.transform);
				}
				if (this.ragdolled && !this.inStabilize && !this.keepRagdolled)
				{
					this.ragdolled = false;
					base.StartCoroutine(this.ResetPlayer(1.1f));
					return;
				}
				if ((this.animator != null && !this.animator.isActiveAndEnabled && this.ragdolled) || (this.animator == null && this.ragdolled))
				{
					base.transform.position = this.characterHips.position;
				}
			}
		}

		// Token: 0x06001535 RID: 5429 RVA: 0x0006F1DC File Offset: 0x0006D3DC
		private void OnDestroy()
		{
			try
			{
				if (this._ragdollContainer && this.characterHips && this.characterHips.parent == this._ragdollContainer.transform)
				{
					this.characterHips.SetParent(this.hipsParent);
					Object.Destroy(this._ragdollContainer.gameObject);
				}
			}
			catch (UnityException ex)
			{
				Debug.LogWarning(ex.Message, base.gameObject);
			}
		}

		// Token: 0x06001536 RID: 5430 RVA: 0x0006F268 File Offset: 0x0006D468
		private void ResetCollisionSound()
		{
			this.inApplyCollisionSound = false;
		}

		// Token: 0x06001537 RID: 5431 RVA: 0x0006F271 File Offset: 0x0006D471
		public void ActivateRagdollWithDelayToGetUp()
		{
			this.ActivateRagdoll(null, this.debugTimeToStayRagdolled);
		}

		// Token: 0x06001538 RID: 5432 RVA: 0x0006F280 File Offset: 0x0006D480
		private void KeepRagdolled(float time)
		{
			if (time > 0f)
			{
				this.keepRagdolled = true;
			}
			base.CancelInvoke("ResetStayRagdolled");
			base.Invoke("ResetStayRagdolled", time);
		}

		// Token: 0x06001539 RID: 5433 RVA: 0x0006F2A8 File Offset: 0x0006D4A8
		public void ResetStayRagdolled()
		{
			this.keepRagdolled = false;
		}

		// Token: 0x0600153A RID: 5434 RVA: 0x0006F2B1 File Offset: 0x0006D4B1
		public void ActivateRagdoll()
		{
			this.ActivateRagdoll(null);
		}

		// Token: 0x0600153B RID: 5435 RVA: 0x0006F2BA File Offset: 0x0006D4BA
		public void ActivateRagdoll(vDamage damage, float timeToStayRagdolled)
		{
			if (this.isActive || (damage != null && !damage.activeRagdoll))
			{
				return;
			}
			this.ActivateRagdoll(damage);
			this.KeepRagdolled(timeToStayRagdolled);
		}

		// Token: 0x0600153C RID: 5436 RVA: 0x0006F2E0 File Offset: 0x0006D4E0
		public void ActivateRagdoll(vDamage damage)
		{
			if (this.isActive || (damage != null && !damage.activeRagdoll))
			{
				return;
			}
			if (!this._ragdollContainer)
			{
				this.CreateRagdollContainer();
			}
			if (damage != null && damage.senselessTime > 0f)
			{
				this.KeepRagdolled(damage.senselessTime);
			}
			this.inApplyCollisionSound = true;
			this.isActive = true;
			if (base.transform.parent != null && !base.transform.parent.gameObject.isStatic)
			{
				base.transform.parent = null;
			}
			bool flag = true;
			this.inStabilize = true;
			this.ragdolled = true;
			if (this.iChar != null)
			{
				this.iChar.EnableRagdoll();
				flag = (this.iChar.currentHealth <= 0f);
			}
			base.StartCoroutine(this.RagdollStabilizer(2f));
			if (!flag)
			{
				this.characterHips.SetParent(this._ragdollContainer.transform);
			}
			base.Invoke("ResetCollisionSound", 0.2f);
		}

		// Token: 0x0600153D RID: 5437 RVA: 0x0006F3E8 File Offset: 0x0006D5E8
		public void OnRagdollCollisionEnter(vRagdollCollision ragdolCollision)
		{
			if (!this.inApplyCollisionSound && ragdolCollision.ImpactForce > 1f && this.collisionSource)
			{
				this.collisionSource.clip = this.collisionClip;
				this.collisionSource.volume = ragdolCollision.ImpactForce * 0.05f;
				if (!this.collisionSource.isPlaying)
				{
					this.inApplyCollisionSound = true;
					this.collisionSource.Play();
					base.Invoke("ResetCollisionSound", 0.2f);
				}
			}
		}

		// Token: 0x0600153E RID: 5438 RVA: 0x0006F46E File Offset: 0x0006D66E
		private IEnumerator RagdollStabilizer(float delay)
		{
			float rdStabilize = float.PositiveInfinity;
			yield return new WaitForSeconds(delay);
			while (rdStabilize > ((this.iChar != null && this.iChar.isDead) ? 0.0001f : 0.1f) && this.animator != null && !this.animator.isActiveAndEnabled)
			{
				rdStabilize = this.characterChest.GetComponent<Rigidbody>().velocity.magnitude;
				yield return new WaitForEndOfFrame();
			}
			if (this.iChar != null && this.iChar.isDead)
			{
				yield return new WaitForEndOfFrame();
				this.DestroyComponents();
			}
			this.inStabilize = false;
			yield break;
		}

		// Token: 0x0600153F RID: 5439 RVA: 0x0006F484 File Offset: 0x0006D684
		private IEnumerator ResetPlayer(float waitTime)
		{
			yield return new WaitForSeconds(waitTime);
			if (this.iChar != null)
			{
				this.iChar.ResetRagdoll();
			}
			yield break;
		}

		// Token: 0x06001540 RID: 5440 RVA: 0x0006F49C File Offset: 0x0006D69C
		private void RagdollBehaviour()
		{
			if (this.iChar == null || this.iChar.currentHealth <= 0f)
			{
				return;
			}
			if (this.iChar == null || !this.iChar.ragdolled)
			{
				return;
			}
			if (this.state == vRagdoll.RagdollState.blendToAnim)
			{
				if (Time.time <= this.ragdollingEndTime + this.mecanimToGetUpTransitionTime)
				{
					Vector3 b = this.ragdolledHipPosition - this.animator.GetBoneTransform(HumanBodyBones.Hips).position;
					Vector3 vector = base.transform.position + b;
					foreach (RaycastHit raycastHit in Physics.RaycastAll(new Ray(vector + Vector3.up, Vector3.down), 1f, this.groundLayer, QueryTriggerInteraction.Ignore))
					{
						if (!raycastHit.transform.IsChildOf(base.transform))
						{
							vector.y = Mathf.Max(vector.y, raycastHit.point.y);
						}
					}
					base.transform.position = vector;
					Vector3 vector2 = this.ragdolledHeadPosition - this.ragdolledFeetPosition;
					vector2.y = 0f;
					Vector3 b2 = 0.5f * (this.animator.GetBoneTransform(HumanBodyBones.LeftFoot).position + this.animator.GetBoneTransform(HumanBodyBones.RightFoot).position);
					Vector3 vector3 = this.animator.GetBoneTransform(HumanBodyBones.Head).position - b2;
					vector3.y = 0f;
					base.transform.rotation *= Quaternion.FromToRotation(vector3.normalized, vector2.normalized);
				}
				float num = 1f - (Time.time - this.ragdollingEndTime - this.mecanimToGetUpTransitionTime) / this.ragdollToMecanimBlendTime;
				num = Mathf.Clamp01(num);
				foreach (vRagdoll.BodyPart bodyPart in this.bodyParts)
				{
					if (bodyPart.transform != base.transform)
					{
						if (bodyPart.transform == this.animator.GetBoneTransform(HumanBodyBones.Hips))
						{
							bodyPart.transform.position = Vector3.Lerp(bodyPart.transform.position, bodyPart.storedPosition, num);
						}
						bodyPart.transform.rotation = Quaternion.Slerp(bodyPart.transform.rotation, bodyPart.storedRotation, num);
					}
				}
				if (num == 0f)
				{
					this.state = vRagdoll.RagdollState.animated;
					return;
				}
			}
		}

		// Token: 0x06001541 RID: 5441 RVA: 0x0006F758 File Offset: 0x0006D958
		private void setKinematic(bool newValue)
		{
			foreach (vRagdoll.BodyPart bodyPart in this.bodyParts)
			{
				if (!this.ignoreTags.Contains(bodyPart.transform.tag) && bodyPart.rigidbody && bodyPart.rigidbody.isKinematic != newValue)
				{
					bodyPart.rigidbody.isKinematic = newValue;
					if (!newValue)
					{
						Vector3 velocity = new Vector3(this._parentRigb.velocity.x * this.horizontalMultiplier, this._parentRigb.velocity.y * this.verticalMultiplier, this._parentRigb.velocity.z * this.horizontalMultiplier);
						bodyPart.rigidbody.velocity = velocity;
					}
				}
			}
		}

		// Token: 0x06001542 RID: 5442 RVA: 0x0006F848 File Offset: 0x0006DA48
		private void setCollider(bool newValue)
		{
			foreach (vRagdoll.BodyPart bodyPart in this.bodyParts)
			{
				if (!this.ignoreTags.Contains(bodyPart.transform.tag) && !bodyPart.transform.Equals(base.transform) && bodyPart.collider)
				{
					if (this.disableColliders)
					{
						bodyPart.collider.enabled = !newValue;
					}
					else
					{
						bodyPart.collider.isTrigger = newValue;
					}
				}
			}
		}

		// Token: 0x06001543 RID: 5443 RVA: 0x0006F8F4 File Offset: 0x0006DAF4
		private void DestroyComponents()
		{
			if (this.removePhysicsAfterDie)
			{
				MonoBehaviour[] componentsInChildren = base.GetComponentsInChildren<MonoBehaviour>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					if (componentsInChildren[i].transform != base.transform)
					{
						Object.Destroy(componentsInChildren[i]);
					}
				}
				CharacterJoint[] componentsInChildren2 = base.GetComponentsInChildren<CharacterJoint>();
				if (componentsInChildren2 != null)
				{
					foreach (CharacterJoint characterJoint in componentsInChildren2)
					{
						if (!this.ignoreTags.Contains(characterJoint.gameObject.tag) && characterJoint.transform != base.transform)
						{
							Object.Destroy(characterJoint);
						}
					}
				}
				Rigidbody[] componentsInChildren3 = base.GetComponentsInChildren<Rigidbody>();
				if (componentsInChildren3 != null)
				{
					foreach (Rigidbody rigidbody in componentsInChildren3)
					{
						if (!this.ignoreTags.Contains(rigidbody.gameObject.tag) && rigidbody.transform != base.transform)
						{
							Object.Destroy(rigidbody);
						}
					}
				}
				Collider[] componentsInChildren4 = base.GetComponentsInChildren<Collider>();
				if (componentsInChildren4 != null)
				{
					foreach (Collider collider in componentsInChildren4)
					{
						if (!this.ignoreTags.Contains(collider.gameObject.tag) && collider.transform != base.transform)
						{
							Object.Destroy(collider);
						}
					}
				}
			}
		}

		// Token: 0x04001B05 RID: 6917
		[vEditorToolbar("Debug", false, "", false, false)]
		public bool startRagdolled;

		// Token: 0x04001B06 RID: 6918
		[vButton("Active Ragdoll And Keep Ragdolled", "ActivateRagdollWithDelayToGetUp", typeof(vRagdoll), true)]
		[vButton("Active Ragdoll", "ActivateRagdoll", typeof(vRagdoll), true)]
		[SerializeField]
		protected float debugTimeToStayRagdolled;

		// Token: 0x04001B07 RID: 6919
		[vEditorToolbar("Settings", false, "", false, false)]
		public LayerMask groundLayer = 1;

		// Token: 0x04001B08 RID: 6920
		public bool keepRagdolled;

		// Token: 0x04001B09 RID: 6921
		public bool invertGetUpAnim;

		// Token: 0x04001B0A RID: 6922
		public bool _ignoreGetUpAnimation;

		// Token: 0x04001B0B RID: 6923
		public bool removePhysicsAfterDie;

		// Token: 0x04001B0C RID: 6924
		[Tooltip("SHOOTER: Keep false to use detection hit on each children collider, don't forget to change the layer to BodyPart from hips to all childrens. MELEE: Keep true to only hit the main Capsule Collider.")]
		public bool disableColliders;

		// Token: 0x04001B0D RID: 6925
		public AudioSource collisionSource;

		// Token: 0x04001B0E RID: 6926
		public AudioClip collisionClip;

		// Token: 0x04001B0F RID: 6927
		[Header("Add Tags for Weapons or Itens here:")]
		public List<string> ignoreTags = new List<string>
		{
			"Weapon",
			"Ignore Ragdoll"
		};

		// Token: 0x04001B10 RID: 6928
		public AnimatorStateInfo stateInfo;

		// Token: 0x04001B11 RID: 6929
		[Range(0f, 2f)]
		[Tooltip("The velocity of the parent rigidbody will be applied to the Ragdoll when enabled, creating a more realistic physics")]
		public float horizontalMultiplier = 1f;

		// Token: 0x04001B12 RID: 6930
		[Range(0f, 2f)]
		public float verticalMultiplier = 0.5f;

		// Token: 0x04001B13 RID: 6931
		internal vICharacter iChar;

		// Token: 0x04001B14 RID: 6932
		private Animator animator;

		// Token: 0x04001B15 RID: 6933
		private Rigidbody _parentRigb;

		// Token: 0x04001B16 RID: 6934
		internal Transform characterChest;

		// Token: 0x04001B17 RID: 6935
		internal Transform characterHips;

		// Token: 0x04001B18 RID: 6936
		[NonSerialized]
		public bool isActive;

		// Token: 0x04001B19 RID: 6937
		private bool inStabilize;

		// Token: 0x04001B1A RID: 6938
		private bool updateBehaviour;

		// Token: 0x04001B1B RID: 6939
		private Vector3 localY;

		// Token: 0x04001B1C RID: 6940
		private vRagdoll.RagdollState state;

		// Token: 0x04001B1D RID: 6941
		private readonly float ragdollToMecanimBlendTime = 0.5f;

		// Token: 0x04001B1E RID: 6942
		private readonly float mecanimToGetUpTransitionTime = 0.05f;

		// Token: 0x04001B1F RID: 6943
		private float ragdollingEndTime = -100f;

		// Token: 0x04001B20 RID: 6944
		private Vector3 ragdolledHipPosition;

		// Token: 0x04001B21 RID: 6945
		private Vector3 ragdolledHeadPosition;

		// Token: 0x04001B22 RID: 6946
		private Vector3 ragdolledFeetPosition;

		// Token: 0x04001B23 RID: 6947
		private readonly List<vRagdoll.BodyPart> bodyParts = new List<vRagdoll.BodyPart>();

		// Token: 0x04001B24 RID: 6948
		private Transform hipsParent;

		// Token: 0x04001B25 RID: 6949
		private bool inApplyCollisionSound;

		// Token: 0x04001B26 RID: 6950
		private GameObject _ragdollContainer;

		// Token: 0x02000407 RID: 1031
		private enum RagdollState
		{
			// Token: 0x04001B28 RID: 6952
			animated,
			// Token: 0x04001B29 RID: 6953
			ragdolled,
			// Token: 0x04001B2A RID: 6954
			blendToAnim
		}

		// Token: 0x02000408 RID: 1032
		private class BodyPart
		{
			// Token: 0x06001545 RID: 5445 RVA: 0x0006FADA File Offset: 0x0006DCDA
			public BodyPart(Transform t)
			{
				this.transform = t;
				this.rigidbody = t.GetComponent<Rigidbody>();
				this.collider = t.GetComponent<Collider>();
			}

			// Token: 0x04001B2B RID: 6955
			public Transform transform;

			// Token: 0x04001B2C RID: 6956
			public Rigidbody rigidbody;

			// Token: 0x04001B2D RID: 6957
			public Collider collider;

			// Token: 0x04001B2E RID: 6958
			public Vector3 storedPosition;

			// Token: 0x04001B2F RID: 6959
			public Quaternion storedRotation;
		}
	}
}
