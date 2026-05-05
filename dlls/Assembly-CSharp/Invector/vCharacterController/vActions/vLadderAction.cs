using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Invector.vCharacterController.vActions
{
	// Token: 0x0200041A RID: 1050
	[vClassHeader("Ladder Action", true, "icon_v2", false, "", iconName = "ladderIcon")]
	public class vLadderAction : vActionListener
	{
		// Token: 0x060015C8 RID: 5576 RVA: 0x00071B17 File Offset: 0x0006FD17
		protected override void SetUpListener()
		{
			base.actionEnter = false;
			base.actionStay = true;
			base.actionExit = true;
		}

		// Token: 0x060015C9 RID: 5577 RVA: 0x00071B30 File Offset: 0x0006FD30
		protected override void Start()
		{
			base.Start();
			this.tpInput = base.GetComponent<vThirdPersonInput>();
			if (this.tpInput)
			{
				this.tpInput.onUpdate -= this.UpdateLadderBehavior;
				this.tpInput.onUpdate += this.UpdateLadderBehavior;
				this.tpInput.onAnimatorMove -= this.UsingLadder;
				this.tpInput.onAnimatorMove += this.UsingLadder;
			}
		}

		// Token: 0x060015CA RID: 5578 RVA: 0x00071BBC File Offset: 0x0006FDBC
		protected virtual void UpdateLadderBehavior()
		{
			this.AutoEnterLadder();
			this.EnterLadderInput();
			this.ExitLadderInput();
		}

		// Token: 0x060015CB RID: 5579 RVA: 0x00071BD0 File Offset: 0x0006FDD0
		protected virtual void EnterLadderInput()
		{
			if (this.targetLadderAction == null || this.tpInput.cc.customAction || this.tpInput.cc.isJumping || !this.tpInput.cc.isGrounded || this.tpInput.cc.isRolling)
			{
				return;
			}
			if (this.enterInput.GetButtonDown() && !this.enterLadderStarted && !this.isUsingLadder && !this.targetLadderAction.autoAction)
			{
				this.TriggerEnterLadder();
			}
		}

		// Token: 0x060015CC RID: 5580 RVA: 0x00071C64 File Offset: 0x0006FE64
		protected virtual void ExitLadderInput()
		{
			if (!this.isUsingLadder)
			{
				return;
			}
			if (this.tpInput.cc.baseLayerInfo.IsName("EnterLadderTop") || this.tpInput.cc.baseLayerInfo.IsName("EnterLadderBottom"))
			{
				return;
			}
			if (this.targetLadderAction == null)
			{
				if (this.tpInput.cc.IsAnimatorTag("ClimbLadder"))
				{
					if (this.slideDownInput.GetButtonDown() && !this.inExitingLadderAnimation)
					{
						this.tpInput.cc.animator.CrossFadeInFixedTime("Ladder_SlideDown", 0.2f);
					}
					if (this.exitInput.GetButtonDown())
					{
						if (this.debugMode)
						{
							Debug.Log("Quick Exit..." + this.currentLadderAction.name + "_" + this.currentLadderAction.transform.parent.gameObject.name);
						}
						this.tpInput.cc.animator.speed = 1f;
						this.tpInput.cc.animator.CrossFadeInFixedTime("QuickExitLadder", 0.1f);
						base.Invoke("ResetPlayerSettings", 0.5f);
						return;
					}
				}
			}
			else
			{
				this.currentLadderAction = this.targetLadderAction;
				string exitAnimation = this.targetLadderAction.exitAnimation;
				if (exitAnimation == "ExitLadderBottom")
				{
					if ((this.exitInput.GetButtonDown() && !this.triggerExitOnce) || (this.speed <= -0.05f && !this.triggerExitOnce) || (this.tpInput.cc.IsAnimatorTag("LadderSlideDown") && this.targetLadderAction != null && !this.triggerExitOnce))
					{
						if (this.debugMode)
						{
							Debug.Log("Exit Bottom..." + this.currentLadderAction.name + "_" + this.currentLadderAction.transform.parent.gameObject.name);
						}
						this.triggerExitOnce = true;
						this.tpInput.cc.animator.CrossFadeInFixedTime(this.targetLadderAction.exitAnimation, 0.1f);
						return;
					}
				}
				else if (exitAnimation == "ExitLadderTop" && this.tpInput.cc.IsAnimatorTag("ClimbLadder") && this.speed >= 0.05f && !this.triggerExitOnce && !this.tpInput.cc.animator.IsInTransition(0))
				{
					if (this.debugMode)
					{
						Debug.Log("Exit Top..." + this.currentLadderAction.name + "_" + this.currentLadderAction.transform.parent.gameObject.name);
					}
					this.triggerExitOnce = true;
					this.tpInput.cc.animator.CrossFadeInFixedTime(this.targetLadderAction.exitAnimation, 0.1f);
				}
			}
		}

		// Token: 0x060015CD RID: 5581 RVA: 0x00071F70 File Offset: 0x00070170
		protected virtual void AutoEnterLadder()
		{
			if (this.targetLadderAction == null || !this.targetLadderAction.autoAction)
			{
				return;
			}
			if (this.tpInput.cc.customAction || this.isUsingLadder || this.tpInput.cc.animator.IsInTransition(0))
			{
				return;
			}
			if (this.targetLadderAction.autoAction && this.tpInput.cc.input != Vector3.zero && !this.tpInput.cc.customAction)
			{
				Vector3 vector = Camera.main.transform.TransformDirection(new Vector3(this.tpInput.cc.input.x, 0f, this.tpInput.cc.input.z));
				vector.y = 0f;
				if (Vector3.Distance(vector.normalized, this.targetLadderAction.transform.forward) < 0.8f)
				{
					this.TriggerEnterLadder();
				}
			}
		}

		// Token: 0x060015CE RID: 5582 RVA: 0x00072088 File Offset: 0x00070288
		protected virtual void TriggerEnterLadder()
		{
			if (this.debugMode)
			{
				Debug.Log("Enter Ladder");
			}
			this.OnExitTriggerLadder.Invoke();
			if (this.targetLadderAction.targetCharacterParent)
			{
				base.transform.parent = this.targetLadderAction.targetCharacterParent;
			}
			this.tpInput.cc.isCrouching = false;
			this.tpInput.cc.ControlCapsuleHeight();
			this.tpInput.UpdateCameraStates();
			this.tpInput.cc.UpdateAnimator();
			this.OnEnterLadder.Invoke();
			this.triggerEnterOnce = true;
			this.enterLadderStarted = true;
			this.tpInput.cc.animator.SetInteger(vAnimatorParameters.ActionState, 1);
			this.tpInput.SetLockAllInput(true);
			this.tpInput.cc.ResetInputAnimatorParameters();
			this.targetLadderAction.OnDoAction.Invoke();
			this.currentLadderAction = this.targetLadderAction;
			if (!string.IsNullOrEmpty(this.currentLadderAction.playAnimation))
			{
				if (this.debugMode)
				{
					Debug.Log("TriggerAnimation " + this.currentLadderAction.name + "_" + this.currentLadderAction.transform.parent.gameObject.name);
				}
				this.tpInput.cc.animator.CrossFadeInFixedTime(this.currentLadderAction.playAnimation, 0.25f);
				this.isUsingLadder = true;
				this.tpInput.cc.disableAnimations = true;
				this.tpInput.cc.StopCharacter();
			}
		}

		// Token: 0x060015CF RID: 5583 RVA: 0x00072228 File Offset: 0x00070428
		protected virtual void UsingLadder()
		{
			if (!this.isUsingLadder)
			{
				return;
			}
			this.tpInput.cc.AnimatorLayerControl();
			this.tpInput.cc.ActionsControl();
			this.tpInput.CameraInput();
			this.speed = this.verticallInput.GetAxis();
			this.tpInput.cc.animator.SetFloat(vAnimatorParameters.InputVertical, this.speed, 0.1f, Time.deltaTime);
			if (this.speed >= 0.05f || this.speed <= -0.05f)
			{
				this.tpInput.cc.animator.speed = Mathf.Lerp(this.tpInput.cc.animator.speed, this.currentClimbSpeed, 2f * Time.deltaTime);
			}
			else
			{
				this.tpInput.cc.animator.speed = Mathf.Lerp(this.tpInput.cc.animator.speed, 1f, 2f * Time.deltaTime);
			}
			if (this.fastClimbInput.GetButton() && this.tpInput.cc.currentStamina > 0f)
			{
				this.currentClimbSpeed = this.fastClimbSpeed;
				this.StaminaConsumption();
			}
			else
			{
				this.currentClimbSpeed = this.climbSpeed;
			}
			bool flag = this.tpInput.cc.baseLayerInfo.IsName("EnterLadderTop") || (this.tpInput.cc.baseLayerInfo.IsName("EnterLadderBottom") && !this.tpInput.cc.animator.IsInTransition(0));
			if (flag)
			{
				this.inEnterLadderAnimation = true;
				this.tpInput.cc.DisableGravityAndCollision();
				if (this.currentLadderAction != null)
				{
					this.currentLadderAction.OnPlayerExit.Invoke();
				}
				if (this.currentLadderAction.useTriggerRotation)
				{
					if (this.debugMode)
					{
						Debug.Log("Rotating to target..." + this.currentLadderAction.name + "_" + this.currentLadderAction.transform.parent.gameObject.name);
					}
					this.EvaluateToRotation(this.currentLadderAction.enterRotationCurve, this.currentLadderAction.matchTarget.transform.rotation, this.tpInput.cc.baseLayerInfo.normalizedTime);
				}
				if (this.currentLadderAction.matchTarget != null)
				{
					if (base.transform.parent != this.currentLadderAction.targetCharacterParent)
					{
						base.transform.parent = this.currentLadderAction.targetCharacterParent;
					}
					if (this.debugMode)
					{
						Debug.Log("Match Target to Enter..." + this.currentLadderAction.name + "_" + this.currentLadderAction.transform.parent.gameObject.name);
					}
					this.EvaluateToPosition(this.currentLadderAction.enterPositionXZCurve, this.currentLadderAction.enterPositionYCurve, this.currentLadderAction.matchTarget.position, this.tpInput.cc.baseLayerInfo.normalizedTime);
				}
			}
			if (!flag && this.inEnterLadderAnimation)
			{
				this.enterLadderStarted = false;
				this.inEnterLadderAnimation = false;
			}
			this.TriggerExitLadder();
		}

		// Token: 0x060015D0 RID: 5584 RVA: 0x00072588 File Offset: 0x00070788
		protected virtual void TriggerExitLadder()
		{
			this.inExitingLadderAnimation = (this.tpInput.cc.baseLayerInfo.IsName("ExitLadderTop") || this.tpInput.cc.baseLayerInfo.IsName("ExitLadderBottom") || this.tpInput.cc.baseLayerInfo.IsName("QuickExitLadder"));
			if (this.inExitingLadderAnimation)
			{
				this.tpInput.cc.animator.speed = 1f;
				if (this.currentLadderAction.exitMatchTarget != null && !this.tpInput.cc.baseLayerInfo.IsName("QuickExitLadder"))
				{
					if (this.debugMode)
					{
						Debug.Log("Match Target to exit..." + this.currentLadderAction.name + "_" + this.currentLadderAction.transform.parent.gameObject.name);
					}
					this.EvaluateToPosition(this.currentLadderAction.exitPositionXZCurve, this.currentLadderAction.exitPositionYCurve, this.currentLadderAction.exitMatchTarget.position, this.tpInput.cc.baseLayerInfo.normalizedTime);
				}
				Vector3 euler = new Vector3(0f, this.tpInput.animator.rootRotation.eulerAngles.y, 0f);
				this.EvaluateToRotation(this.currentLadderAction.exitRotationCurve, Quaternion.Euler(euler), this.tpInput.cc.baseLayerInfo.normalizedTime);
				if (this.tpInput.cc.baseLayerInfo.normalizedTime >= 0.8f)
				{
					this.ResetPlayerSettings();
				}
			}
		}

		// Token: 0x060015D1 RID: 5585 RVA: 0x00072748 File Offset: 0x00070948
		protected virtual void EvaluateToPosition(AnimationCurve XZ, AnimationCurve Y, Vector3 targetPosition, float normalizedTime)
		{
			Vector3 rootPosition = this.tpInput.cc.animator.rootPosition;
			float num = XZ.Evaluate(normalizedTime);
			float num2 = Y.Evaluate(normalizedTime);
			if (num < 1f)
			{
				rootPosition.x = Mathf.Lerp(rootPosition.x, targetPosition.x, num);
				rootPosition.z = Mathf.Lerp(rootPosition.z, targetPosition.z, num);
			}
			if (num2 < 1f)
			{
				rootPosition.y = Mathf.Lerp(rootPosition.y, targetPosition.y, num2);
			}
			base.transform.position = rootPosition;
		}

		// Token: 0x060015D2 RID: 5586 RVA: 0x000727E4 File Offset: 0x000709E4
		protected virtual void EvaluateToRotation(AnimationCurve curve, Quaternion targetRotation, float normalizedTime)
		{
			Quaternion quaternion = this.tpInput.cc.animator.rootRotation;
			float num = curve.Evaluate(normalizedTime);
			if (num < 1f)
			{
				quaternion = Quaternion.Lerp(quaternion, targetRotation, num);
			}
			base.transform.rotation = quaternion;
		}

		// Token: 0x060015D3 RID: 5587 RVA: 0x0007282C File Offset: 0x00070A2C
		protected virtual void StaminaConsumption()
		{
			if (this.tpInput.cc.currentStamina <= 0f)
			{
				return;
			}
			this.tpInput.cc.ReduceStamina(this.fastClimbStamina, true);
			this.tpInput.cc.currentStaminaRecoveryDelay = 0.25f;
		}

		// Token: 0x060015D4 RID: 5588 RVA: 0x00072880 File Offset: 0x00070A80
		protected virtual void AddLadderTrigger(vTriggerLadderAction _ladderAction)
		{
			if (this.targetLadderAction != _ladderAction)
			{
				this.targetLadderAction = _ladderAction;
				if (this.debugMode)
				{
					Debug.Log("TriggerStay " + this.targetLadderAction.name + "_" + this.targetLadderAction.transform.parent.gameObject.name);
				}
			}
			if (!this.actionTriggers.Contains(this.targetLadderAction))
			{
				this.actionTriggers.Add(this.targetLadderAction);
				this.targetLadderAction.OnPlayerEnter.Invoke();
			}
		}

		// Token: 0x060015D5 RID: 5589 RVA: 0x00072917 File Offset: 0x00070B17
		protected virtual void RemoveLadderTrigger(vTriggerLadderAction _ladderAction)
		{
			if (_ladderAction == this.targetLadderAction)
			{
				this.targetLadderAction = null;
			}
			if (this.actionTriggers.Contains(_ladderAction))
			{
				this.actionTriggers.Remove(_ladderAction);
				_ladderAction.OnPlayerExit.Invoke();
			}
		}

		// Token: 0x060015D6 RID: 5590 RVA: 0x00072954 File Offset: 0x00070B54
		protected virtual void CheckForTriggerAction(Collider other)
		{
			vTriggerLadderAction component = other.GetComponent<vTriggerLadderAction>();
			if (!component)
			{
				return;
			}
			float num = Vector3.Distance(base.transform.forward, component.transform.forward);
			if (this.isUsingLadder && component != null)
			{
				if (this.targetLadderAction != component)
				{
					this.targetLadderAction = component;
					if (!this.actionTriggers.Contains(this.targetLadderAction))
					{
						this.actionTriggers.Add(this.targetLadderAction);
						return;
					}
				}
			}
			else
			{
				if ((!component.activeFromForward || num <= 0.8f) && !this.isUsingLadder)
				{
					this.AddLadderTrigger(component);
					this.OnEnterTriggerLadder.Invoke();
					return;
				}
				this.RemoveLadderTrigger(component);
			}
		}

		// Token: 0x060015D7 RID: 5591 RVA: 0x00072A0C File Offset: 0x00070C0C
		public virtual void ResetPlayerSettings()
		{
			if (this.debugMode)
			{
				Debug.Log("Reset Player Settings");
			}
			this.speed = 0f;
			this.targetLadderAction = null;
			this.isUsingLadder = false;
			this.OnExitLadder.Invoke();
			this.triggerExitOnce = false;
			this.triggerEnterOnce = false;
			this.inEnterLadderAnimation = false;
			this.enterLadderStarted = false;
			this.tpInput.cc.animator.SetInteger(vAnimatorParameters.ActionState, 0);
			this.tpInput.cc.EnableGravityAndCollision();
			this.tpInput.SetLockAllInput(false);
			this.tpInput.cc.StopCharacter();
			this.tpInput.cc.disableAnimations = false;
			if (base.transform.parent != null)
			{
				base.transform.parent = null;
			}
		}

		// Token: 0x060015D8 RID: 5592 RVA: 0x00072AE2 File Offset: 0x00070CE2
		public override void OnActionStay(Collider other)
		{
			if (other.gameObject.CompareTag(this.actionTag) && !this.enterLadderStarted)
			{
				this.CheckForTriggerAction(other);
			}
		}

		// Token: 0x060015D9 RID: 5593 RVA: 0x00072B08 File Offset: 0x00070D08
		public override void OnActionExit(Collider other)
		{
			if (other.gameObject.CompareTag(this.actionTag))
			{
				vTriggerLadderAction component = other.GetComponent<vTriggerLadderAction>();
				if (!component)
				{
					return;
				}
				this.RemoveLadderTrigger(component);
				if (this.debugMode)
				{
					Debug.Log("TriggerExit " + other.name + "_" + other.transform.parent.gameObject.name);
				}
				this.OnExitTriggerLadder.Invoke();
			}
		}

		// Token: 0x04001B7A RID: 7034
		[vEditorToolbar("Settings", false, "", false, true, order = 0)]
		[Tooltip("Tag of the object you want to access")]
		public string actionTag = "LadderTrigger";

		// Token: 0x04001B7B RID: 7035
		[Tooltip("Speed multiplier for the climb ladder animations")]
		public float climbSpeed = 1.5f;

		// Token: 0x04001B7C RID: 7036
		[Tooltip("Speed multiplier for the climb ladder animations when the fastClimbInput is pressed")]
		public float fastClimbSpeed = 3f;

		// Token: 0x04001B7D RID: 7037
		[Tooltip("How much Stamina will be consumed when climbing faster")]
		public float fastClimbStamina = 30f;

		// Token: 0x04001B7E RID: 7038
		[Tooltip("Input to use the ladder going up or down")]
		public GenericInput verticallInput = new GenericInput("Vertical", "LeftAnalogVertical", "Vertical");

		// Token: 0x04001B7F RID: 7039
		[Tooltip("Input to enter the ladder")]
		public GenericInput enterInput = new GenericInput("E", "A", "A");

		// Token: 0x04001B80 RID: 7040
		[Tooltip("Input to exit the ladder")]
		public GenericInput exitInput = new GenericInput("Space", "B", "B");

		// Token: 0x04001B81 RID: 7041
		[Tooltip("Input to climb faster")]
		public GenericInput fastClimbInput = new GenericInput("LeftShift", "LeftStickClick", "LeftStickClick");

		// Token: 0x04001B82 RID: 7042
		[Tooltip("Input to climb faster")]
		public GenericInput slideDownInput = new GenericInput("Q", "X", "X");

		// Token: 0x04001B83 RID: 7043
		[vEditorToolbar("Events", false, "", false, false)]
		public UnityEvent OnEnterLadder;

		// Token: 0x04001B84 RID: 7044
		public UnityEvent OnExitLadder;

		// Token: 0x04001B85 RID: 7045
		public UnityEvent OnEnterTriggerLadder;

		// Token: 0x04001B86 RID: 7046
		public UnityEvent OnExitTriggerLadder;

		// Token: 0x04001B87 RID: 7047
		[vEditorToolbar("Debug", false, "", false, false)]
		public bool debugMode;

		// Token: 0x04001B88 RID: 7048
		[vReadOnly(false)]
		[SerializeField]
		protected vTriggerLadderAction targetLadderAction;

		// Token: 0x04001B89 RID: 7049
		[vReadOnly(false)]
		[SerializeField]
		protected vTriggerLadderAction currentLadderAction;

		// Token: 0x04001B8A RID: 7050
		protected List<vTriggerLadderAction> actionTriggers = new List<vTriggerLadderAction>();

		// Token: 0x04001B8B RID: 7051
		[vReadOnly(false)]
		[SerializeField]
		protected float speed;

		// Token: 0x04001B8C RID: 7052
		[vReadOnly(false)]
		[SerializeField]
		protected float currentClimbSpeed;

		// Token: 0x04001B8D RID: 7053
		[vReadOnly(false)]
		[SerializeField]
		protected bool isUsingLadder;

		// Token: 0x04001B8E RID: 7054
		[vReadOnly(false)]
		[SerializeField]
		protected bool enterLadderStarted;

		// Token: 0x04001B8F RID: 7055
		[vReadOnly(false)]
		[SerializeField]
		protected bool inEnterLadderAnimation;

		// Token: 0x04001B90 RID: 7056
		[vReadOnly(false)]
		[SerializeField]
		protected bool inExitingLadderAnimation;

		// Token: 0x04001B91 RID: 7057
		[vReadOnly(false)]
		[SerializeField]
		protected bool triggerEnterOnce;

		// Token: 0x04001B92 RID: 7058
		[vReadOnly(false)]
		[SerializeField]
		protected bool triggerExitOnce;

		// Token: 0x04001B93 RID: 7059
		protected vThirdPersonInput tpInput;
	}
}
