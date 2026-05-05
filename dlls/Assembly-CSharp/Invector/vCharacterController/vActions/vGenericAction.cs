using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Invector.vCharacterController.vActions
{
	// Token: 0x02000415 RID: 1045
	[vClassHeader("GENERIC ACTION", "Use the vTriggerGenericAction to trigger a simple animation.\n<b><size=12>You can use <color=red>vGenericActionReceiver</color> component to filter events by action name</size></b>", iconName = "triggerIcon")]
	public class vGenericAction : vActionListener
	{
		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x0600158D RID: 5517 RVA: 0x0007001C File Offset: 0x0006E21C
		protected virtual Vector3 screenCenter
		{
			get
			{
				this._screenCenter.x = (float)Screen.width * 0.5f;
				this._screenCenter.y = (float)Screen.height * 0.5f;
				this._screenCenter.z = 0f;
				return this._screenCenter;
			}
		}

		// Token: 0x0600158E RID: 5518 RVA: 0x0007006D File Offset: 0x0006E26D
		protected override void SetUpListener()
		{
			base.actionEnter = true;
			base.actionStay = true;
			base.actionExit = true;
			this.actions = new Dictionary<Collider, vGenericAction.ActionStorage>();
		}

		// Token: 0x0600158F RID: 5519 RVA: 0x00070090 File Offset: 0x0006E290
		protected override void Start()
		{
			base.Start();
			this.tpInput = base.GetComponent<vThirdPersonInput>();
			if (this.tpInput != null)
			{
				this.tpInput.onUpdate -= this.CheckForTriggerAction;
				this.tpInput.onUpdate += this.CheckForTriggerAction;
				this.tpInput.onLateUpdate -= this.UpdateGenericAction;
				this.tpInput.onLateUpdate += this.UpdateGenericAction;
			}
			if (!this.mainCamera)
			{
				this.mainCamera = Camera.main;
			}
		}

		// Token: 0x06001590 RID: 5520 RVA: 0x00070135 File Offset: 0x0006E335
		protected virtual void UpdateGenericAction()
		{
			if (!this.mainCamera)
			{
				this.mainCamera = Camera.main;
			}
			if (!this.mainCamera)
			{
				return;
			}
			this.AnimationBehaviour();
			this.HandleColliders();
		}

		// Token: 0x06001591 RID: 5521 RVA: 0x0007016C File Offset: 0x0006E36C
		private void HandleColliders()
		{
			this.colliders.Clear();
			foreach (Collider item in this.actions.Keys)
			{
				this.colliders.Add(item);
			}
			if (!base.doingAction && this.triggerAction && !this.isLockTriggerEvents)
			{
				if (this.timeInTrigger <= 0f)
				{
					this.actions.Clear();
					this.triggerAction = null;
					return;
				}
				this.timeInTrigger -= Time.deltaTime;
			}
		}

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x06001592 RID: 5522 RVA: 0x00070224 File Offset: 0x0006E424
		protected virtual bool inActionAnimation
		{
			get
			{
				return !string.IsNullOrEmpty(this.triggerAction.playAnimation) && this.tpInput.cc.animatorStateInfos.stateInfos[this.triggerAction.animatorLayer].shortPathHash.Equals(Animator.StringToHash(this.triggerAction.playAnimation));
			}
		}

		// Token: 0x06001593 RID: 5523 RVA: 0x00070280 File Offset: 0x0006E480
		protected virtual void CheckForTriggerAction()
		{
			if ((this.actions.Count == 0 && !this.triggerAction) || this.isLockTriggerEvents)
			{
				return;
			}
			vTriggerGenericAction nearAction = this.GetNearAction();
			if (!base.doingAction && this.triggerAction != nearAction)
			{
				this.triggerAction = nearAction;
				if (this.triggerAction)
				{
					this.triggerAction.OnValidate.Invoke(base.gameObject);
					this.OnEnterTriggerAction.Invoke(this.triggerAction);
				}
			}
			this.TriggerActionInput();
		}

		// Token: 0x06001594 RID: 5524 RVA: 0x00070310 File Offset: 0x0006E510
		protected vTriggerGenericAction GetNearAction()
		{
			if (this.isLockTriggerEvents || base.doingAction || this.playingAnimation)
			{
				return null;
			}
			float num = float.PositiveInfinity;
			vTriggerGenericAction vTriggerGenericAction = null;
			foreach (Collider collider in this.actions.Keys)
			{
				if (collider)
				{
					try
					{
						vTriggerGenericAction vTriggerGenericAction2 = this.actions[collider];
						Vector3 a = this.mainCamera ? this.mainCamera.WorldToScreenPoint(collider.transform.position) : this.screenCenter;
						if (this.mainCamera)
						{
							if (vTriggerGenericAction2.enabled && vTriggerGenericAction2.gameObject.activeInHierarchy && ((!vTriggerGenericAction2.activeFromForward && (a - this.screenCenter).magnitude < num) || (this.IsInForward(vTriggerGenericAction2.transform, vTriggerGenericAction2.forwardAngle) && (a - this.screenCenter).magnitude < num)))
							{
								num = (a - this.screenCenter).magnitude;
								if (vTriggerGenericAction && vTriggerGenericAction != vTriggerGenericAction2)
								{
									if (this.actions[vTriggerGenericAction._collider].isValid)
									{
										vTriggerGenericAction.OnInvalidate.Invoke(base.gameObject);
									}
									vTriggerGenericAction = vTriggerGenericAction2;
								}
								else if (vTriggerGenericAction == null)
								{
									vTriggerGenericAction = vTriggerGenericAction2;
								}
							}
							else
							{
								if (this.actions[vTriggerGenericAction2._collider].isValid)
								{
									vTriggerGenericAction2.OnInvalidate.Invoke(base.gameObject);
								}
								this.OnExitTriggerAction.Invoke(this.triggerAction);
							}
						}
						else if (!vTriggerGenericAction)
						{
							vTriggerGenericAction = vTriggerGenericAction2;
						}
						else
						{
							if (this.actions[vTriggerGenericAction2._collider].isValid)
							{
								vTriggerGenericAction2.OnInvalidate.Invoke(base.gameObject);
							}
							this.OnExitTriggerAction.Invoke(this.triggerAction);
						}
						continue;
					}
					catch
					{
						break;
					}
				}
				this.actions.Remove(collider);
				return null;
			}
			return vTriggerGenericAction;
		}

		// Token: 0x06001595 RID: 5525 RVA: 0x0007058C File Offset: 0x0006E78C
		protected virtual bool IsInForward(Transform target, float angleToCompare)
		{
			return Vector3.Angle(base.transform.forward, target.forward) <= angleToCompare;
		}

		// Token: 0x06001596 RID: 5526 RVA: 0x000705AC File Offset: 0x0006E7AC
		protected virtual void AnimationBehaviour()
		{
			if (this.animationBehaviourDelay > 0f && !this.playingAnimation)
			{
				this.animationBehaviourDelay -= Time.deltaTime;
				return;
			}
			if (this.playingAnimation)
			{
				if (this.triggerAction.matchTarget != null)
				{
					if (this.debugMode)
					{
						Debug.Log("<b>GenericAction: </b><color=blue>Match Target...</color> ");
					}
					this.EvaluateToTargetPosition();
				}
				if (this.triggerAction.useTriggerRotation)
				{
					if (this.debugMode)
					{
						Debug.Log("<b>GenericAction: </b><color=blue>Rotate to Target...</color> ");
					}
					this.EvaluateToTargetRotation();
				}
				if (this.actionStarted && !this.triggerAction.endActionManualy && (this.triggerAction.inputType != vTriggerGenericAction.InputType.GetButtonTimer || !this.triggerAction.playAnimationWhileHoldingButton) && this.tpInput.cc.animatorStateInfos.GetCurrentNormalizedTime(this.triggerAction.animatorLayer) >= this.triggerAction.endExitTimeAnimation)
				{
					if (this.debugMode)
					{
						Debug.Log("<b>GenericAction: </b>Finish Animation ");
					}
					this.EndAction();
					return;
				}
			}
			else if (base.doingAction && this.actionStarted && (this.triggerAction == null || !this.triggerAction.endActionManualy))
			{
				if (this.triggerAction != null && this.triggerAction.inputType == vTriggerGenericAction.InputType.GetButtonTimer && this.triggerAction.playAnimationWhileHoldingButton)
				{
					return;
				}
				if (this.debugMode)
				{
					Debug.Log("<b>GenericAction: </b>Force ResetTriggerSettings ");
				}
				this.EndAction();
			}
		}

		// Token: 0x06001597 RID: 5527 RVA: 0x0007072C File Offset: 0x0006E92C
		protected virtual void EvaluateToTargetPosition()
		{
			Vector3 vector = this.triggerAction.matchTarget.position;
			switch (this.triggerAction.avatarTarget)
			{
			case AvatarTarget.LeftFoot:
				vector = this.triggerAction.matchTarget.position - base.transform.rotation * base.transform.InverseTransformPoint(this.tpInput.animator.GetBoneTransform(HumanBodyBones.LeftFoot).position);
				break;
			case AvatarTarget.RightFoot:
				vector = this.triggerAction.matchTarget.position - base.transform.rotation * base.transform.InverseTransformPoint(this.tpInput.animator.GetBoneTransform(HumanBodyBones.RightFoot).position);
				break;
			case AvatarTarget.LeftHand:
				vector = this.triggerAction.matchTarget.position - base.transform.rotation * base.transform.InverseTransformPoint(this.tpInput.animator.GetBoneTransform(HumanBodyBones.LeftHand).position);
				break;
			case AvatarTarget.RightHand:
				vector = this.triggerAction.matchTarget.position - base.transform.rotation * base.transform.InverseTransformPoint(this.tpInput.animator.GetBoneTransform(HumanBodyBones.RightHand).position);
				break;
			}
			AnimationCurve matchPositionXZCurve = this.triggerAction.matchPositionXZCurve;
			AnimationCurve matchPositionYCurve = this.triggerAction.matchPositionYCurve;
			float time = Mathf.Clamp(this.tpInput.cc.animatorStateInfos.GetCurrentNormalizedTime(this.triggerAction.animatorLayer), 0f, 1f);
			Vector3 position = this.triggerAction.matchTarget.InverseTransformPoint(vector);
			if (!this.triggerAction.useLocalX)
			{
				position.x = this.triggerAction.matchTarget.InverseTransformPoint(base.transform.position).x;
			}
			if (!this.triggerAction.useLocalZ)
			{
				position.z = this.triggerAction.matchTarget.InverseTransformPoint(base.transform.position).z;
			}
			vector = this.triggerAction.matchTarget.TransformPoint(position);
			Vector3 rootPosition = this.tpInput.cc.animator.rootPosition;
			float num = matchPositionXZCurve.Evaluate(time);
			float num2 = matchPositionYCurve.Evaluate(time);
			if (num < 1f)
			{
				rootPosition.x = Mathf.Lerp(rootPosition.x, vector.x, num);
				rootPosition.z = Mathf.Lerp(rootPosition.z, vector.z, num);
				this.finishPositionXZMatch = true;
			}
			else if (this.finishPositionXZMatch)
			{
				this.finishPositionXZMatch = false;
				rootPosition.x = vector.x;
				rootPosition.z = vector.z;
			}
			if (num2 < 1f)
			{
				rootPosition.y = Mathf.Lerp(rootPosition.y, vector.y, num2);
				this.finishPositionYMatch = true;
			}
			else if (this.finishPositionYMatch)
			{
				this.finishPositionYMatch = false;
				rootPosition.y = vector.y;
			}
			base.transform.position = rootPosition;
		}

		// Token: 0x06001598 RID: 5528 RVA: 0x00070A64 File Offset: 0x0006EC64
		protected virtual void EvaluateToTargetRotation()
		{
			Quaternion quaternion = Quaternion.Euler(new Vector3(base.transform.eulerAngles.x, this.triggerAction.transform.eulerAngles.y, base.transform.eulerAngles.z));
			Quaternion quaternion2 = this.tpInput.cc.animator.rootRotation;
			AnimationCurve matchRotationCurve = this.triggerAction.matchRotationCurve;
			float currentNormalizedTime = this.tpInput.cc.animatorStateInfos.GetCurrentNormalizedTime(this.triggerAction.animatorLayer);
			float num = matchRotationCurve.Evaluate(currentNormalizedTime);
			if (num < 1f)
			{
				quaternion2 = Quaternion.Lerp(quaternion2, quaternion, num);
				this.finishRotationMatch = true;
			}
			else if (this.finishRotationMatch)
			{
				this.finishRotationMatch = false;
				quaternion2 = quaternion;
			}
			base.transform.rotation = quaternion2;
		}

		// Token: 0x06001599 RID: 5529 RVA: 0x00070B34 File Offset: 0x0006ED34
		protected virtual void EndAction()
		{
			this.OnEndAction.Invoke(this.triggerAction);
			vTriggerGenericAction vTriggerGenericAction = this.triggerAction;
			vTriggerGenericAction.OnEndAnimation.Invoke();
			this.OnExitTriggerAction.Invoke(this.triggerAction);
			this.ResetTriggerSettings(true);
			if (vTriggerGenericAction.destroyAfter)
			{
				base.StartCoroutine(this.DestroyActionDelay(vTriggerGenericAction));
			}
			if (this.debugMode)
			{
				Debug.Log("<b>GenericAction: </b>End Action ");
			}
		}

		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x0600159A RID: 5530 RVA: 0x00070BA4 File Offset: 0x0006EDA4
		// (set) Token: 0x0600159B RID: 5531 RVA: 0x00070C1E File Offset: 0x0006EE1E
		public virtual bool playingAnimation
		{
			get
			{
				if (this.triggerAction == null || !base.doingAction)
				{
					return this._playingAnimation = false;
				}
				if (!this._playingAnimation && this.inActionAnimation)
				{
					this._playingAnimation = true;
					this.triggerAction.OnStartAnimation.Invoke();
					this.DisablePlayerGravityAndCollision();
				}
				else if (this._playingAnimation && !this.inActionAnimation)
				{
					this._playingAnimation = false;
				}
				return this._playingAnimation;
			}
			protected set
			{
				this._playingAnimation = true;
			}
		}

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x0600159C RID: 5532 RVA: 0x00070C27 File Offset: 0x0006EE27
		public virtual bool actionConditions
		{
			get
			{
				return !base.doingAction && !this.playingAnimation && !this.tpInput.cc.isJumping && !this.tpInput.cc.customAction;
			}
		}

		// Token: 0x0600159D RID: 5533 RVA: 0x00070C60 File Offset: 0x0006EE60
		public override void OnActionEnter(Collider other)
		{
			if (this.isLockTriggerEvents)
			{
				return;
			}
			if (other != null && other.gameObject.CompareTag(this.actionTag) && !this.actions.ContainsKey(other))
			{
				vTriggerGenericAction component = other.GetComponent<vTriggerGenericAction>();
				if (component && component.enabled)
				{
					this.actions.Add(other, component);
					component.OnPlayerEnter.Invoke(base.gameObject);
					if (this.debugMode)
					{
						string str = "<color=green>Enter in Trigger </color>";
						GameObject gameObject = other.gameObject;
						Debug.Log(str + ((gameObject != null) ? gameObject.ToString() : null), other.gameObject);
					}
				}
			}
		}

		// Token: 0x0600159E RID: 5534 RVA: 0x00070D0C File Offset: 0x0006EF0C
		public override void OnActionExit(Collider other)
		{
			if (this.isLockTriggerEvents)
			{
				return;
			}
			if (other.gameObject.CompareTag(this.actionTag) && this.actions.ContainsKey(other) && (!base.doingAction || other != this.triggerAction._collider))
			{
				vTriggerGenericAction vTriggerGenericAction = this.actions[other];
				this.actions.Remove(other);
				vTriggerGenericAction.OnPlayerExit.Invoke(base.gameObject);
				vTriggerGenericAction.OnInvalidate.Invoke(base.gameObject);
				this.OnExitTriggerAction.Invoke(vTriggerGenericAction);
				if (this.debugMode)
				{
					string str = "<color=red>Exit of Trigger </color> ";
					GameObject gameObject = other.gameObject;
					Debug.Log(str + ((gameObject != null) ? gameObject.ToString() : null), other.gameObject);
				}
			}
		}

		// Token: 0x0600159F RID: 5535 RVA: 0x00070DE0 File Offset: 0x0006EFE0
		public override void OnActionStay(Collider other)
		{
			if (this.isLockTriggerEvents)
			{
				return;
			}
			if (other != null && this.actions.ContainsKey(other))
			{
				this.actions[other].action.OnPlayerStay.Invoke(base.gameObject);
				this.timeInTrigger = 0.5f;
				if (this.debugMode)
				{
					string str = "<color=yellow>Stay in Trigger </color>";
					GameObject gameObject = other.gameObject;
					Debug.Log(str + ((gameObject != null) ? gameObject.ToString() : null), other.gameObject);
				}
			}
		}

		// Token: 0x060015A0 RID: 5536 RVA: 0x00070E68 File Offset: 0x0006F068
		public virtual void FinishAction()
		{
			if (this.triggerAction && this.actionStarted && this.triggerAction.endActionManualy)
			{
				this.EndAction();
			}
		}

		// Token: 0x060015A1 RID: 5537 RVA: 0x00070E94 File Offset: 0x0006F094
		public virtual void TriggerActionInput()
		{
			if (this.triggerAction == null || !this.triggerAction.gameObject.activeInHierarchy)
			{
				return;
			}
			if (this.triggerAction.inputType == vTriggerGenericAction.InputType.AutoAction && this.actionConditions)
			{
				this.TriggerActionEvents();
				this.TriggerAnimation();
				return;
			}
			if (this.triggerAction.inputType == vTriggerGenericAction.InputType.GetButtonDown && this.actionConditions)
			{
				if (this.triggerAction.actionInput.GetButtonDown())
				{
					this.TriggerActionEvents();
					this.TriggerAnimation();
					return;
				}
			}
			else if (this.triggerAction.inputType == vTriggerGenericAction.InputType.GetDoubleButton && this.actionConditions)
			{
				if (this.triggerAction.actionInput.GetDoubleButtonDown(this.triggerAction.doubleButtomTime))
				{
					this.TriggerActionEvents();
					this.TriggerAnimation();
					return;
				}
			}
			else if (this.triggerAction.inputType == vTriggerGenericAction.InputType.GetButtonTimer)
			{
				if (this._currentInputDelay <= 0f)
				{
					bool flag = false;
					float value = 0f;
					if (this.triggerAction.playAnimationWhileHoldingButton)
					{
						this.TriggerActionEventsInput();
						if (this.triggerAction.actionInput.GetButtonTimer(ref value, ref flag, this.triggerAction.buttonTimer))
						{
							if (this.debugMode)
							{
								Debug.Log("<b>GenericAction: </b>Finish Action Input ");
							}
							this.triggerAction.UpdateButtonTimer(0f);
							this.triggerAction.OnFinishActionInput.Invoke();
							this.ResetActionState();
							this.EndAction();
						}
						if (this.triggerAction && this.triggerAction.actionInput.inButtomTimer)
						{
							if (this.debugMode)
							{
								Debug.Log("<b>GenericAction: </b><color=blue>Holding Input</color>  ");
							}
							this.triggerAction.UpdateButtonTimer(value);
							this.TriggerAnimation();
						}
						if (flag && this.triggerAction)
						{
							this.CancelButtonTimer();
							return;
						}
					}
					else
					{
						this.TriggerActionEventsInput();
						if (this.triggerAction.actionInput.GetButtonTimer(ref value, ref flag, this.triggerAction.buttonTimer))
						{
							if (this.debugMode)
							{
								Debug.Log("<b>GenericAction: </b>Finish Action Input ");
							}
							this.triggerAction.UpdateButtonTimer(0f);
							this.triggerAction.OnFinishActionInput.Invoke();
							this.TriggerAnimation();
						}
						if (this.triggerAction && this.triggerAction.actionInput.inButtomTimer)
						{
							if (this.debugMode)
							{
								Debug.Log("<b>GenericAction: </b><color=blue>Holding Input</color>");
							}
							this.triggerAction.UpdateButtonTimer(value);
						}
						if (flag && this.triggerAction)
						{
							this.CancelButtonTimer();
							return;
						}
					}
				}
				else
				{
					this._currentInputDelay -= Time.deltaTime;
				}
			}
		}

		// Token: 0x060015A2 RID: 5538 RVA: 0x00071124 File Offset: 0x0006F324
		private void CancelButtonTimer()
		{
			if (this.debugMode)
			{
				Debug.Log("<b>GenericAction: </b>Cancel Action ");
			}
			this.triggerAction.OnCancelActionInput.Invoke();
			this._currentInputDelay = this.triggerAction.inputDelay;
			this.triggerAction.UpdateButtonTimer(0f);
			this.OnCancelAction.Invoke(this.triggerAction);
			this.ResetActionState();
			this.ResetTriggerSettings(false);
		}

		// Token: 0x060015A3 RID: 5539 RVA: 0x00071192 File Offset: 0x0006F392
		private void TriggerActionEventsInput()
		{
			if (this.triggerAction && this.triggerAction.actionInput.GetButtonDown())
			{
				this.TriggerActionEvents();
			}
		}

		// Token: 0x060015A4 RID: 5540 RVA: 0x000711BC File Offset: 0x0006F3BC
		public virtual void TriggerActionEvents()
		{
			if (this.debugMode)
			{
				Debug.Log("<b>GenericAction: </b>TriggerAction Events ", base.gameObject);
			}
			base.doingAction = true;
			this.OnStartAction.Invoke(this.triggerAction);
			this.OnDoAction.Invoke(this.triggerAction);
			base.StartCoroutine(this.triggerAction.OnPressActionDelay(base.gameObject));
		}

		// Token: 0x060015A5 RID: 5541 RVA: 0x00071224 File Offset: 0x0006F424
		public virtual void TriggerAnimation()
		{
			if (this.playingAnimation || this.actionStarted)
			{
				return;
			}
			if (this.debugMode)
			{
				Debug.Log("<b>GenericAction: </b>TriggerAnimation ", base.gameObject);
			}
			if (this.triggerAction.animatorActionState != 0)
			{
				if (this.debugMode)
				{
					Debug.Log("<b>GenericAction: </b>Applied ActionState: " + this.triggerAction.animatorActionState.ToString() + " ", base.gameObject);
				}
				this.tpInput.cc.SetActionState(this.triggerAction.animatorActionState);
			}
			if (!string.IsNullOrEmpty(this.triggerAction.playAnimation))
			{
				if (!this.actionStarted)
				{
					if (this.debugMode)
					{
						Debug.Log("<b>GenericAction: </b>PlayAnimation: " + this.triggerAction.playAnimation + " ", base.gameObject);
					}
					this.actionStarted = true;
					this.playingAnimation = true;
					this.tpInput.cc.animator.CrossFadeInFixedTime(this.triggerAction.playAnimation, this.triggerAction.crossFadeTransition);
					if (!string.IsNullOrEmpty(this.triggerAction.customCameraState))
					{
						this.tpInput.ChangeCameraState(this.triggerAction.customCameraState, true);
					}
				}
				this.animationBehaviourDelay = this.triggerAction.crossFadeTransition + 0.1f;
				return;
			}
			this.actionStarted = true;
		}

		// Token: 0x060015A6 RID: 5542 RVA: 0x00071382 File Offset: 0x0006F582
		public virtual void ResetActionState()
		{
			if (this.triggerAction && this.triggerAction.resetAnimatorActionState)
			{
				this.tpInput.cc.SetActionState(0);
			}
		}

		// Token: 0x060015A7 RID: 5543 RVA: 0x000713B0 File Offset: 0x0006F5B0
		public virtual void ResetTriggerSettings(bool removeTrigger = true)
		{
			if (this.debugMode)
			{
				Debug.Log("<b>GenericAction: </b>Reset Trigger Settings ");
			}
			this.EnablePlayerGravityAndCollision();
			this.ResetActionState();
			if (this.triggerAction != null && !string.IsNullOrEmpty(this.triggerAction.customCameraState))
			{
				this.tpInput.ResetCameraState();
			}
			if (this.triggerAction != null && this.actions.ContainsKey(this.triggerAction._collider) && removeTrigger)
			{
				this.actions.Remove(this.triggerAction._collider);
			}
			this.triggerAction = null;
			base.doingAction = false;
			this.actionStarted = false;
		}

		// Token: 0x060015A8 RID: 5544 RVA: 0x00071460 File Offset: 0x0006F660
		public virtual void DisablePlayerGravityAndCollision()
		{
			if (this.triggerAction && this.triggerAction.disableGravity)
			{
				if (this.debugMode)
				{
					Debug.Log("<b>GenericAction: </b><color=red>Disable Player's Gravity</color> ");
				}
				this.tpInput.cc._rigidbody.useGravity = false;
				this.tpInput.cc._rigidbody.isKinematic = true;
				this.tpInput.cc._rigidbody.velocity = Vector3.zero;
			}
			if (this.triggerAction && this.triggerAction.disableCollision)
			{
				if (this.debugMode)
				{
					Debug.Log("<b>GenericAction: </b><color=red>Disable Player's Collision</color> ");
				}
				this.tpInput.cc._capsuleCollider.isTrigger = true;
			}
		}

		// Token: 0x060015A9 RID: 5545 RVA: 0x00071524 File Offset: 0x0006F724
		public virtual void EnablePlayerGravityAndCollision()
		{
			if (this.triggerAction && this.triggerAction.disableGravity)
			{
				if (this.debugMode)
				{
					Debug.Log("<b>GenericAction: </b><color=red>Enable Player's Gravity</color> ");
				}
				this.tpInput.cc._rigidbody.useGravity = true;
				this.tpInput.cc._rigidbody.isKinematic = false;
			}
			if (this.triggerAction && this.triggerAction.disableCollision)
			{
				if (this.debugMode)
				{
					Debug.Log("<b>GenericAction: </b><color=red>Enable Player's Collision</color> ");
				}
				this.tpInput.cc._capsuleCollider.isTrigger = false;
			}
		}

		// Token: 0x060015AA RID: 5546 RVA: 0x000715CB File Offset: 0x0006F7CB
		public virtual IEnumerator DestroyActionDelay(vTriggerGenericAction triggerAction)
		{
			yield return new WaitForSeconds(triggerAction.destroyDelay);
			if (triggerAction != null && triggerAction.gameObject != null)
			{
				this.OnExitTriggerAction.Invoke(triggerAction);
				Object.Destroy(triggerAction.gameObject);
			}
			if (this.debugMode)
			{
				Debug.Log("<b>GenericAction: </b>Destroy Trigger ");
			}
			yield break;
		}

		// Token: 0x060015AB RID: 5547 RVA: 0x000715E4 File Offset: 0x0006F7E4
		public virtual void SetLockTriggerEvents(bool value)
		{
			foreach (Collider collider in this.actions.Keys)
			{
				if (collider)
				{
					this.actions[collider].action.OnPlayerExit.Invoke(base.gameObject);
					this.actions[collider].action.OnInvalidate.Invoke(base.gameObject);
				}
			}
			this.actions.Clear();
			this.isLockTriggerEvents = value;
		}

		// Token: 0x04001B4E RID: 6990
		[vEditorToolbar("Settings", false, "", false, false)]
		[Tooltip("Tag of the object you want to access")]
		public string actionTag = "Action";

		// Token: 0x04001B4F RID: 6991
		[Tooltip("Use root motion of the animation")]
		public bool useRootMotion = true;

		// Token: 0x04001B50 RID: 6992
		[vEditorToolbar("Debug", false, "", false, false)]
		[Header("--- Debug Only ---")]
		[Tooltip("Check this to enter the debug mode")]
		public bool debugMode;

		// Token: 0x04001B51 RID: 6993
		[vReadOnly(true)]
		public vTriggerGenericAction triggerAction;

		// Token: 0x04001B52 RID: 6994
		[vReadOnly(true)]
		[SerializeField]
		protected bool _playingAnimation;

		// Token: 0x04001B53 RID: 6995
		[vReadOnly(true)]
		[SerializeField]
		protected bool actionStarted;

		// Token: 0x04001B54 RID: 6996
		[vReadOnly(true)]
		public bool isLockTriggerEvents;

		// Token: 0x04001B55 RID: 6997
		[vReadOnly(true)]
		[SerializeField]
		protected List<Collider> colliders = new List<Collider>();

		// Token: 0x04001B56 RID: 6998
		[vEditorToolbar("Events", false, "", false, false)]
		public vOnActionHandle OnEnterTriggerAction;

		// Token: 0x04001B57 RID: 6999
		public vOnActionHandle OnExitTriggerAction;

		// Token: 0x04001B58 RID: 7000
		public vOnActionHandle OnStartAction;

		// Token: 0x04001B59 RID: 7001
		public vOnActionHandle OnCancelAction;

		// Token: 0x04001B5A RID: 7002
		public vOnActionHandle OnEndAction;

		// Token: 0x04001B5B RID: 7003
		internal Camera mainCamera;

		// Token: 0x04001B5C RID: 7004
		internal vThirdPersonInput tpInput;

		// Token: 0x04001B5D RID: 7005
		protected float _currentInputDelay;

		// Token: 0x04001B5E RID: 7006
		protected Vector3 _screenCenter;

		// Token: 0x04001B5F RID: 7007
		protected float timeInTrigger;

		// Token: 0x04001B60 RID: 7008
		protected float animationBehaviourDelay;

		// Token: 0x04001B61 RID: 7009
		protected bool finishRotationMatch;

		// Token: 0x04001B62 RID: 7010
		protected bool finishPositionXZMatch;

		// Token: 0x04001B63 RID: 7011
		protected bool finishPositionYMatch;

		// Token: 0x04001B64 RID: 7012
		internal Dictionary<Collider, vGenericAction.ActionStorage> actions;

		// Token: 0x02000416 RID: 1046
		internal class ActionStorage
		{
			// Token: 0x060015AD RID: 5549 RVA: 0x00002392 File Offset: 0x00000592
			internal ActionStorage()
			{
			}

			// Token: 0x060015AE RID: 5550 RVA: 0x000716B9 File Offset: 0x0006F8B9
			internal ActionStorage(vTriggerGenericAction action)
			{
				this.action = action;
				action.OnValidate.AddListener(delegate(GameObject o)
				{
					this.isValid = true;
				});
				action.OnInvalidate.AddListener(delegate(GameObject o)
				{
					this.isValid = false;
				});
			}

			// Token: 0x060015AF RID: 5551 RVA: 0x000716F6 File Offset: 0x0006F8F6
			public static implicit operator vTriggerGenericAction(vGenericAction.ActionStorage storage)
			{
				return storage.action;
			}

			// Token: 0x060015B0 RID: 5552 RVA: 0x000716FE File Offset: 0x0006F8FE
			public static implicit operator vGenericAction.ActionStorage(vTriggerGenericAction action)
			{
				return new vGenericAction.ActionStorage(action);
			}

			// Token: 0x04001B65 RID: 7013
			internal vTriggerGenericAction action;

			// Token: 0x04001B66 RID: 7014
			internal bool isValid;
		}
	}
}
