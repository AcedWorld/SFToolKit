using System;
using System.Collections.Generic;
using Invector.vEventSystems;
using UnityEngine;
using UnityEngine.Events;

namespace Invector.vCharacterController
{
	// Token: 0x02000403 RID: 1027
	[vClassHeader("HEAD TRACK", true, "icon_v2", false, "", iconName = "headTrackIcon")]
	public class vHeadTrack : vMonoBehaviour
	{
		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x060014FB RID: 5371 RVA: 0x0006D663 File Offset: 0x0006B863
		public float Smooth
		{
			get
			{
				if (!this.ignoreSmooth)
				{
					return this.smooth * Time.deltaTime;
				}
				return 1f;
			}
		}

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x060014FC RID: 5372 RVA: 0x0006D67F File Offset: 0x0006B87F
		// (set) Token: 0x060014FD RID: 5373 RVA: 0x0006D687 File Offset: 0x0006B887
		public virtual bool freezeLookPoint
		{
			get
			{
				return this._freezeLookPoint;
			}
			set
			{
				this._freezeLookPoint = value;
			}
		}

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x060014FE RID: 5374 RVA: 0x0006D690 File Offset: 0x0006B890
		// (set) Token: 0x060014FF RID: 5375 RVA: 0x0006D6BD File Offset: 0x0006B8BD
		public virtual Vector3 currentLookPosition
		{
			get
			{
				if (!this.freezeLookPoint)
				{
					return base.transform.TransformPoint(this._currentLocalLookPosition);
				}
				return base.transform.TransformPoint(this._lastLocalLookPosition);
			}
			protected set
			{
				this._currentLocalLookPosition = base.transform.InverseTransformPoint(value);
				if (!this.freezeLookPoint)
				{
					this._lastLocalLookPosition = this._currentLocalLookPosition;
				}
			}
		}

		// Token: 0x06001500 RID: 5376 RVA: 0x0006D6E8 File Offset: 0x0006B8E8
		private void Start()
		{
			if (!this.sensor)
			{
				GameObject gameObject = new GameObject("HeadTrackSensor");
				this.sensor = gameObject.AddComponent<vHeadTrackSensor>();
			}
			vThirdPersonInput component = base.GetComponent<vThirdPersonInput>();
			if (component)
			{
				component.onLateUpdate -= this.UpdateHeadTrack;
				component.onLateUpdate += this.UpdateHeadTrack;
			}
			this.vchar = base.GetComponent<vICharacter>();
			this.sensor.headTrack = this;
			this.cameraMain = Camera.main;
			int layer = LayerMask.NameToLayer("HeadTrack");
			this.sensor.transform.parent = base.transform;
			this.sensor.gameObject.layer = layer;
			this.sensor.gameObject.tag = base.transform.tag;
			this.animatorStateInfo = base.GetComponent<vIAnimatorStateInfoController>();
			this.Init();
		}

		// Token: 0x06001501 RID: 5377 RVA: 0x0006D7D0 File Offset: 0x0006B9D0
		public void Init()
		{
			this.currentLookPosition = this.GetLookPoint();
			this._lastLocalLookPosition = this._currentLocalLookPosition;
			if (this.animator == null)
			{
				this.animator = base.GetComponentInChildren<Animator>();
			}
			if (this.autoFindBones)
			{
				this.spine.Clear();
				this.head = this.animator.GetBoneTransform(HumanBodyBones.Head);
				if (this.head)
				{
					if (!this.forwardReference)
					{
						this.forwardReference = new GameObject("FWRF").transform;
					}
					this.forwardReference.SetParent(this.head);
					this.forwardReference.transform.localPosition = Vector3.zero;
					this.forwardReference.transform.rotation = base.transform.rotation;
					Transform boneTransform = this.animator.GetBoneTransform(HumanBodyBones.Hips);
					if (boneTransform)
					{
						Transform parent = this.head;
						int num = 0;
						while (num < 4 && parent.parent && parent.parent.gameObject != boneTransform.gameObject)
						{
							this.spine.Add(parent.parent);
							parent = parent.parent;
							num++;
						}
					}
				}
			}
			if (this.head)
			{
				this.headHeight = Vector3.Distance(base.transform.position, this.head.position);
				this.sensor.transform.position = this.head.transform.position;
			}
			else
			{
				this.headHeight = 1f;
				this.sensor.transform.position = base.transform.position;
			}
			if (this.spine.Count == 0)
			{
				Debug.Log("Headtrack Spines missing");
			}
			this.spine.Reverse();
		}

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x06001502 RID: 5378 RVA: 0x0006D9A8 File Offset: 0x0006BBA8
		private Vector3 headPoint
		{
			get
			{
				return base.transform.position + base.transform.up * this.headHeight;
			}
		}

		// Token: 0x06001503 RID: 5379 RVA: 0x0006D9D0 File Offset: 0x0006BBD0
		public virtual void UpdateHeadTrack()
		{
			if (this.animator == null || !this.animator.enabled)
			{
				return;
			}
			if (this.vchar != null && this.vchar.currentHealth > 0f && this.animator != null && !this.vchar.ragdolled)
			{
				this.onInitUpdate.Invoke();
				if (!this.freezeLookPoint)
				{
					this.currentLookPosition = this.GetLookPoint();
				}
				this.SetLookAtPosition(this.currentLookPosition, this._currentHeadWeight, this._currentbodyWeight);
				this.onFinishUpdate.Invoke();
			}
		}

		// Token: 0x06001504 RID: 5380 RVA: 0x0006DA70 File Offset: 0x0006BC70
		public virtual void SetLookAtPosition(Vector3 point, float headWeight, float spineWeight)
		{
			Quaternion quaternion = Quaternion.LookRotation(point - this.headPoint);
			this.currentLookRotation = quaternion;
			Vector3 vector = quaternion.eulerAngles - base.transform.rotation.eulerAngles;
			float num = this.NormalizeAngle(vector.y);
			float num2 = this.NormalizeAngle(vector.x);
			Vector3 eulerAngle = this.considerHeadAnimationForward ? (this.forwardReference.eulerAngles - base.transform.eulerAngles) : Vector3.zero;
			this.xAngle = Mathf.Clamp(Mathf.Lerp(this.xAngle, num2 - eulerAngle.NormalizeAngle().x + Quaternion.Euler(this.offsetSpine + this.defaultOffsetSpine).eulerAngles.NormalizeAngle().x, this.Smooth), this.verticalAngleLimit.x, this.verticalAngleLimit.y);
			this.yAngle = Mathf.Clamp(Mathf.Lerp(this.yAngle, num - eulerAngle.NormalizeAngle().y + Quaternion.Euler(this.offsetSpine + this.defaultOffsetSpine).eulerAngles.NormalizeAngle().y, this.Smooth), this.horizontalAngleLimit.x, this.horizontalAngleLimit.y);
			float num3 = this.NormalizeAngle(this.xAngle);
			float num4 = this.NormalizeAngle(this.yAngle);
			foreach (Transform transform in this.spine)
			{
				Quaternion rhs = Quaternion.AngleAxis(num4 * spineWeight / (float)this.spine.Count, transform.InverseTransformDirection(base.transform.up));
				transform.rotation *= rhs;
				Quaternion rhs2 = Quaternion.AngleAxis(num3 * spineWeight / (float)this.spine.Count, transform.InverseTransformDirection(base.transform.TransformDirection(this.upDownAxis)));
				transform.rotation *= rhs2;
			}
			if (this.head)
			{
				float num5 = this.NormalizeAngle(this.xAngle - num3 * spineWeight + Quaternion.Euler(this.offsetHead + this.defaultOffsetHead).eulerAngles.NormalizeAngle().x);
				Quaternion rhs3 = Quaternion.AngleAxis(this.NormalizeAngle(this.yAngle - num4 * spineWeight + Quaternion.Euler(this.offsetHead + this.defaultOffsetHead).eulerAngles.NormalizeAngle().y) * headWeight, this.head.InverseTransformDirection(base.transform.up));
				this.head.rotation *= rhs3;
				Quaternion rhs4 = Quaternion.AngleAxis(num5 * headWeight, this.head.InverseTransformDirection(base.transform.TransformDirection(this.upDownAxis)));
				this.head.rotation *= rhs4;
			}
		}

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x06001505 RID: 5381 RVA: 0x0006DDC4 File Offset: 0x0006BFC4
		private bool lookConditions
		{
			get
			{
				if (!this.cameraMain)
				{
					this.cameraMain = Camera.main;
				}
				return (this.head != null && this.followCamera && this.cameraMain != null) || (!this.followCamera && (this.currentLookTarget || this.simpleTarget)) || this.temporaryLookTime > 0f;
			}
		}

		// Token: 0x06001506 RID: 5382 RVA: 0x0006DE40 File Offset: 0x0006C040
		private Vector3 GetLookPoint()
		{
			if (this.animator == null)
			{
				return Vector3.zero;
			}
			int num = 100;
			if (this.lookConditions && !this.IgnoreHeadTrack())
			{
				Vector3 direction = base.transform.forward;
				if (this.temporaryLookTime <= 0f)
				{
					Vector3 a = this.headPoint + base.transform.forward * (float)num;
					if (this.followCamera)
					{
						a = this.cameraMain.transform.position + this.cameraMain.transform.forward * (float)num;
					}
					direction = a - this.headPoint;
					if ((this.followCamera && !this.alwaysFollowCamera) || !this.followCamera)
					{
						if (this.simpleTarget != null)
						{
							direction = this.simpleTarget.position - this.headPoint;
							if (this.currentLookTarget && this.currentLookTarget == this.lastLookTarget)
							{
								this.currentLookTarget.ExitLook(this);
								this.lastLookTarget = null;
							}
						}
						else if (this.currentLookTarget != null && (this.currentLookTarget.ignoreHeadTrackAngle || this.TargetIsOnRange(this.currentLookTarget.lookPoint - this.headPoint)) && this.currentLookTarget.IsVisible(this.headPoint, this.obstacleLayer, false))
						{
							direction = this.currentLookTarget.lookPoint - this.headPoint;
							if (this.currentLookTarget != this.lastLookTarget)
							{
								this.currentLookTarget.EnterLook(this);
								this.lastLookTarget = this.currentLookTarget;
							}
						}
						else if (this.currentLookTarget && this.currentLookTarget == this.lastLookTarget)
						{
							this.currentLookTarget.ExitLook(this);
							this.lastLookTarget = null;
						}
					}
				}
				else
				{
					direction = this.temporaryLookPoint - this.headPoint;
					this.temporaryLookTime -= Time.deltaTime;
					if (this.currentLookTarget && this.currentLookTarget == this.lastLookTarget)
					{
						this.currentLookTarget.ExitLook(this);
						this.lastLookTarget = null;
					}
				}
				Vector2 targetAngle = this.GetTargetAngle(direction);
				if (this.cancelTrackOutOfAngle && (this.lastLookTarget == null || !this.lastLookTarget.ignoreHeadTrackAngle))
				{
					if (this.TargetIsOnRange(direction))
					{
						if (this.animator.GetBool("IsStrafing") && !this.IsAnimatorTag("Upperbody Pose"))
						{
							this.SmoothValues(this.strafeHeadWeight, this.strafeBodyWeight, targetAngle.x, targetAngle.y);
						}
						else if (this.animator.GetBool("IsStrafing") && this.IsAnimatorTag("Upperbody Pose"))
						{
							this.SmoothValues(this.aimingHeadWeight, this.aimingBodyWeight, targetAngle.x, targetAngle.y);
						}
						else
						{
							this.SmoothValues(this.freeHeadWeight, this.freeBodyWeight, targetAngle.x, targetAngle.y);
						}
					}
					else
					{
						this.SmoothValues(0f, 0f, 0f, 0f);
					}
				}
				else if (this.animator.GetBool("IsStrafing") && !this.IsAnimatorTag("Upperbody Pose"))
				{
					this.SmoothValues(this.strafeHeadWeight, this.strafeBodyWeight, targetAngle.x, targetAngle.y);
				}
				else if (this.animator.GetBool("IsStrafing") && this.IsAnimatorTag("Upperbody Pose"))
				{
					this.SmoothValues(this.aimingHeadWeight, this.aimingBodyWeight, targetAngle.x, targetAngle.y);
				}
				else
				{
					this.SmoothValues(this.freeHeadWeight, this.freeBodyWeight, targetAngle.x, targetAngle.y);
				}
				if (this.targetsInArea.Count > 1)
				{
					this.SortTargets();
				}
			}
			else
			{
				this.SmoothValues(0f, 0f, 0f, 0f);
				if (this.targetsInArea.Count > 1)
				{
					this.SortTargets();
				}
			}
			Quaternion lhs = Quaternion.AngleAxis(this.yRotation, base.transform.up);
			Quaternion rhs = Quaternion.AngleAxis(this.xRotation, base.transform.right);
			Vector3 a2 = lhs * rhs * base.transform.forward;
			return this.headPoint + a2 * (float)num;
		}

		// Token: 0x06001507 RID: 5383 RVA: 0x0006E2EC File Offset: 0x0006C4EC
		private Vector2 GetTargetAngle(Vector3 direction)
		{
			Vector3 eulerAngle = Quaternion.LookRotation(direction, base.transform.up).eulerAngles - base.transform.eulerAngles;
			return new Vector2(eulerAngle.NormalizeAngle().x, eulerAngle.NormalizeAngle().y);
		}

		// Token: 0x06001508 RID: 5384 RVA: 0x0006E340 File Offset: 0x0006C540
		private bool TargetIsOnRange(Vector3 direction)
		{
			Vector2 targetAngle = this.GetTargetAngle(direction);
			return targetAngle.x >= this.verticalAngleLimit.x && targetAngle.x <= this.verticalAngleLimit.y && targetAngle.y >= this.horizontalAngleLimit.x && targetAngle.y <= this.horizontalAngleLimit.y;
		}

		// Token: 0x06001509 RID: 5385 RVA: 0x0006E3A6 File Offset: 0x0006C5A6
		public virtual void SetAlwaysFollowCamera(bool value)
		{
			this.alwaysFollowCamera = value;
		}

		// Token: 0x0600150A RID: 5386 RVA: 0x0006E3AF File Offset: 0x0006C5AF
		public virtual void SetLookTarget(vLookTarget target, bool priority = false)
		{
			if (!this.targetsInArea.Contains(target))
			{
				this.targetsInArea.Add(target);
			}
			if (priority)
			{
				this.currentLookTarget = target;
			}
		}

		// Token: 0x0600150B RID: 5387 RVA: 0x0006E3D5 File Offset: 0x0006C5D5
		public virtual void SetLookTarget(Transform target)
		{
			this.simpleTarget = target;
		}

		// Token: 0x0600150C RID: 5388 RVA: 0x0006E3DE File Offset: 0x0006C5DE
		public virtual void SetTemporaryLookPoint(Vector3 point, float time = 1f)
		{
			this.temporaryLookPoint = point;
			this.temporaryLookTime = time;
		}

		// Token: 0x0600150D RID: 5389 RVA: 0x0006E3EE File Offset: 0x0006C5EE
		public virtual void RemoveLookTarget(vLookTarget target)
		{
			if (this.targetsInArea.Contains(target))
			{
				this.targetsInArea.Remove(target);
			}
			if (this.currentLookTarget == target)
			{
				this.currentLookTarget = null;
			}
		}

		// Token: 0x0600150E RID: 5390 RVA: 0x0006E420 File Offset: 0x0006C620
		public virtual void RemoveLookTarget(Transform target)
		{
			if (this.simpleTarget == target)
			{
				this.simpleTarget = null;
			}
		}

		// Token: 0x0600150F RID: 5391 RVA: 0x0006E437 File Offset: 0x0006C637
		private float NormalizeAngle(float angle)
		{
			if (angle > 180f)
			{
				angle -= 360f;
			}
			else if (angle < -180f)
			{
				angle += 360f;
			}
			return angle;
		}

		// Token: 0x06001510 RID: 5392 RVA: 0x0006E45E File Offset: 0x0006C65E
		private void ResetValues()
		{
			this._currentHeadWeight = 0f;
			this._currentbodyWeight = 0f;
			this.yRotation = 0f;
			this.xRotation = 0f;
		}

		// Token: 0x06001511 RID: 5393 RVA: 0x0006E48C File Offset: 0x0006C68C
		private void SmoothValues(float _headWeight = 0f, float _bodyWeight = 0f, float _x = 0f, float _y = 0f)
		{
			this._currentHeadWeight = Mathf.Lerp(this._currentHeadWeight, _headWeight, this.Smooth);
			this._currentbodyWeight = Mathf.Lerp(this._currentbodyWeight, _bodyWeight, this.Smooth);
			this.yRotation = Mathf.Lerp(this.yRotation, _y, this.Smooth);
			this.xRotation = Mathf.Lerp(this.xRotation, _x, this.Smooth);
			this.yRotation = Mathf.Clamp(this.yRotation, this.horizontalAngleLimit.x, this.horizontalAngleLimit.y);
			this.xRotation = Mathf.Clamp(this.xRotation, this.verticalAngleLimit.x, this.verticalAngleLimit.y);
		}

		// Token: 0x06001512 RID: 5394 RVA: 0x0006E548 File Offset: 0x0006C748
		private void SortTargets()
		{
			this.interation += Time.deltaTime;
			if (this.interation > this.updateTargetInteration)
			{
				this.interation -= this.updateTargetInteration;
				if (this.targetsInArea == null || this.targetsInArea.Count < 2)
				{
					if (this.targetsInArea != null && this.targetsInArea.Count > 0)
					{
						this.currentLookTarget = this.targetsInArea[0];
					}
					return;
				}
				for (int i = this.targetsInArea.Count - 1; i >= 0; i--)
				{
					if (this.targetsInArea[i] == null)
					{
						this.targetsInArea.RemoveAt(i);
					}
				}
				this.targetsInArea.Sort((vLookTarget c1, vLookTarget c2) => Vector3.Distance(base.transform.position, (c1 != null) ? c1.transform.position : (Vector3.one * float.PositiveInfinity)).CompareTo(Vector3.Distance(base.transform.position, (c2 != null) ? c2.transform.position : (Vector3.one * float.PositiveInfinity))));
				if (this.targetsInArea.Count > 0)
				{
					this.currentLookTarget = this.targetsInArea[0];
				}
			}
		}

		// Token: 0x06001513 RID: 5395 RVA: 0x0006E63C File Offset: 0x0006C83C
		public virtual void OnDetect(Collider other)
		{
			if (this.tagsToDetect.Contains(other.gameObject.tag) && other.GetComponent<vLookTarget>() != null)
			{
				this.currentLookTarget = other.GetComponent<vLookTarget>();
				vHeadTrack componentInParent = other.GetComponentInParent<vHeadTrack>();
				if (!this.targetsInArea.Contains(this.currentLookTarget) && (componentInParent == null || componentInParent != this))
				{
					this.targetsInArea.Add(this.currentLookTarget);
					this.SortTargets();
					this.currentLookTarget = this.targetsInArea[0];
				}
			}
		}

		// Token: 0x06001514 RID: 5396 RVA: 0x0006E6D0 File Offset: 0x0006C8D0
		public virtual void OnLost(Collider other)
		{
			if (this.tagsToDetect.Contains(other.gameObject.tag) && other.GetComponentInParent<vLookTarget>() != null)
			{
				vLookTarget componentInParent = other.GetComponentInParent<vLookTarget>();
				if (this.targetsInArea.Contains(componentInParent))
				{
					this.targetsInArea.Remove(componentInParent);
					if (componentInParent == this.lastLookTarget)
					{
						componentInParent.ExitLook(this);
					}
				}
				this.SortTargets();
				if (this.targetsInArea.Count > 0)
				{
					this.currentLookTarget = this.targetsInArea[0];
					return;
				}
				this.currentLookTarget = null;
			}
		}

		// Token: 0x06001515 RID: 5397 RVA: 0x0006E768 File Offset: 0x0006C968
		public virtual bool IgnoreHeadTrack()
		{
			return this.animatorIgnoreTags.Exists((string tag) => this.IsAnimatorTag(tag));
		}

		// Token: 0x06001516 RID: 5398 RVA: 0x0006E786 File Offset: 0x0006C986
		public virtual bool IsAnimatorTag(string tag)
		{
			return !(this.animator == null) && (this.animatorStateInfo.isValid() && this.animatorStateInfo.animatorStateInfos.HasTag(tag));
		}

		// Token: 0x04001ABC RID: 6844
		[vEditorToolbar("Settings", false, "", false, false)]
		[vHelpBox("If your character is not looking up/down, try changing the axis", vHelpBoxAttribute.MessageType.Info)]
		public Vector3 upDownAxis = Vector3.right;

		// Token: 0x04001ABD RID: 6845
		[Header("Head & Body Weight")]
		public float strafeHeadWeight = 0.6f;

		// Token: 0x04001ABE RID: 6846
		public float strafeBodyWeight = 0.6f;

		// Token: 0x04001ABF RID: 6847
		public float aimingHeadWeight = 0.8f;

		// Token: 0x04001AC0 RID: 6848
		public float aimingBodyWeight = 0.8f;

		// Token: 0x04001AC1 RID: 6849
		public float freeHeadWeight = 0.6f;

		// Token: 0x04001AC2 RID: 6850
		public float freeBodyWeight = 0.6f;

		// Token: 0x04001AC3 RID: 6851
		[SerializeField]
		protected float smooth = 10f;

		// Token: 0x04001AC4 RID: 6852
		[Header("Default Offsets ")]
		[SerializeField]
		protected Vector2 defaultOffsetSpine;

		// Token: 0x04001AC5 RID: 6853
		[SerializeField]
		protected Vector2 defaultOffsetHead;

		// Token: 0x04001AC6 RID: 6854
		[vReadOnly(true)]
		public Vector2 offsetSpine;

		// Token: 0x04001AC7 RID: 6855
		[vReadOnly(true)]
		public Vector2 offsetHead;

		// Token: 0x04001AC8 RID: 6856
		[Header("Tracking")]
		[Tooltip("Follow the Camera Forward")]
		public bool followCamera = true;

		// Token: 0x04001AC9 RID: 6857
		public bool _freezeLookPoint;

		// Token: 0x04001ACA RID: 6858
		[vHideInInspector("followCamera", false)]
		[Tooltip("Force to follow camera")]
		public bool alwaysFollowCamera;

		// Token: 0x04001ACB RID: 6859
		[Tooltip("Ignore the Limits and continue to follow the camera")]
		public bool cancelTrackOutOfAngle = true;

		// Token: 0x04001ACC RID: 6860
		[Tooltip("Considerer the head animation forward while tracking, try it to see different results")]
		public bool considerHeadAnimationForward;

		// Token: 0x04001ACD RID: 6861
		[Header("Limits")]
		[vMinMax(minLimit = -180f, maxLimit = 180f)]
		public Vector2 horizontalAngleLimit = new Vector2(-100f, 100f);

		// Token: 0x04001ACE RID: 6862
		[vMinMax(minLimit = -90f, maxLimit = 90f)]
		public Vector2 verticalAngleLimit = new Vector2(-80f, 80f);

		// Token: 0x04001ACF RID: 6863
		[vHelpBox("Animations with vAnimatorTag Behavior will ignore the HeadTrack while is being played", vHelpBoxAttribute.MessageType.None)]
		[Header("Ignore AnimatorTags")]
		public List<string> animatorIgnoreTags = new List<string>
		{
			"Attack",
			"LockMovement",
			"CustomAction",
			"IsEquipping",
			"IgnoreHeadtrack"
		};

		// Token: 0x04001AD0 RID: 6864
		[vEditorToolbar("Bones", false, "", false, false)]
		[vHelpBox("Auto Find Bones using Humanoid", vHelpBoxAttribute.MessageType.None)]
		public bool autoFindBones = true;

		// Token: 0x04001AD1 RID: 6865
		public Transform head;

		// Token: 0x04001AD2 RID: 6866
		public List<Transform> spine = new List<Transform>();

		// Token: 0x04001AD3 RID: 6867
		[vEditorToolbar("Detection", false, "", false, false)]
		public float updateTargetInteration = 1f;

		// Token: 0x04001AD4 RID: 6868
		public float distanceToDetect = 10f;

		// Token: 0x04001AD5 RID: 6869
		public LayerMask obstacleLayer = 1;

		// Token: 0x04001AD6 RID: 6870
		[vHelpBox("Gameobjects Tags to detect", vHelpBoxAttribute.MessageType.None)]
		public List<string> tagsToDetect = new List<string>
		{
			"LookAt"
		};

		// Token: 0x04001AD7 RID: 6871
		internal UnityEvent onInitUpdate = new UnityEvent();

		// Token: 0x04001AD8 RID: 6872
		internal UnityEvent onFinishUpdate = new UnityEvent();

		// Token: 0x04001AD9 RID: 6873
		internal Camera cameraMain;

		// Token: 0x04001ADA RID: 6874
		internal vLookTarget currentLookTarget;

		// Token: 0x04001ADB RID: 6875
		internal vLookTarget lastLookTarget;

		// Token: 0x04001ADC RID: 6876
		internal Quaternion currentLookRotation;

		// Token: 0x04001ADD RID: 6877
		internal List<vLookTarget> targetsInArea = new List<vLookTarget>();

		// Token: 0x04001ADE RID: 6878
		internal bool ignoreSmooth;

		// Token: 0x04001ADF RID: 6879
		private float yRotation;

		// Token: 0x04001AE0 RID: 6880
		private float xRotation;

		// Token: 0x04001AE1 RID: 6881
		private float _currentHeadWeight;

		// Token: 0x04001AE2 RID: 6882
		private float _currentbodyWeight;

		// Token: 0x04001AE3 RID: 6883
		private Animator animator;

		// Token: 0x04001AE4 RID: 6884
		private vIAnimatorStateInfoController animatorStateInfo;

		// Token: 0x04001AE5 RID: 6885
		private float headHeight;

		// Token: 0x04001AE6 RID: 6886
		private Transform simpleTarget;

		// Token: 0x04001AE7 RID: 6887
		private Vector3 temporaryLookPoint;

		// Token: 0x04001AE8 RID: 6888
		private float temporaryLookTime;

		// Token: 0x04001AE9 RID: 6889
		private vHeadTrackSensor sensor;

		// Token: 0x04001AEA RID: 6890
		private float interation;

		// Token: 0x04001AEB RID: 6891
		private vICharacter vchar;

		// Token: 0x04001AEC RID: 6892
		private float yAngle;

		// Token: 0x04001AED RID: 6893
		private float xAngle;

		// Token: 0x04001AEE RID: 6894
		private float _yAngle;

		// Token: 0x04001AEF RID: 6895
		private float _xAngle;

		// Token: 0x04001AF0 RID: 6896
		private Transform forwardReference;

		// Token: 0x04001AF1 RID: 6897
		protected Vector3 _currentLocalLookPosition;

		// Token: 0x04001AF2 RID: 6898
		protected Vector3 _lastLocalLookPosition;
	}
}
