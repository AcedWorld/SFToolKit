using System;
using System.Collections;
using Invector.vCamera;
using Rewired;
using UnityEngine;
using UnityEngine.Events;

namespace Invector.vCharacterController
{
	// Token: 0x020003EF RID: 1007
	[vClassHeader("Input Manager", true, "icon_v2", false, "", iconName = "inputIcon")]
	public class vThirdPersonInput : vMonoBehaviour, vIAnimatorMoveReceiver
	{
		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06001423 RID: 5155 RVA: 0x00068B54 File Offset: 0x00066D54
		// (remove) Token: 0x06001424 RID: 5156 RVA: 0x00068B8C File Offset: 0x00066D8C
		public event vThirdPersonInput.OnUpdateEvent onUpdate;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06001425 RID: 5157 RVA: 0x00068BC4 File Offset: 0x00066DC4
		// (remove) Token: 0x06001426 RID: 5158 RVA: 0x00068BFC File Offset: 0x00066DFC
		public event vThirdPersonInput.OnUpdateEvent onLateUpdate;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06001427 RID: 5159 RVA: 0x00068C34 File Offset: 0x00066E34
		// (remove) Token: 0x06001428 RID: 5160 RVA: 0x00068C6C File Offset: 0x00066E6C
		public event vThirdPersonInput.OnUpdateEvent onFixedUpdate;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x06001429 RID: 5161 RVA: 0x00068CA4 File Offset: 0x00066EA4
		// (remove) Token: 0x0600142A RID: 5162 RVA: 0x00068CDC File Offset: 0x00066EDC
		public event vThirdPersonInput.OnUpdateEvent onAnimatorMove;

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x0600142B RID: 5163 RVA: 0x00068D14 File Offset: 0x00066F14
		// (set) Token: 0x0600142C RID: 5164 RVA: 0x00068D7C File Offset: 0x00066F7C
		public Camera cameraMain
		{
			get
			{
				if (!this._cameraMain && !this.withoutMainCamera)
				{
					if (!Camera.main)
					{
						Debug.Log("Missing a Camera with the tag MainCamera, please add one.");
						this.withoutMainCamera = true;
					}
					else
					{
						this._cameraMain = Camera.main;
						this.cc.rotateTarget = this._cameraMain.transform;
					}
				}
				return this._cameraMain;
			}
			set
			{
				this._cameraMain = value;
			}
		}

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x0600142D RID: 5165 RVA: 0x00068D88 File Offset: 0x00066F88
		public Animator animator
		{
			get
			{
				if (this.cc == null)
				{
					this.cc = base.GetComponent<vThirdPersonController>();
				}
				if (this.cc.animator == null)
				{
					return base.GetComponent<Animator>();
				}
				return this.cc.animator;
			}
		}

		// Token: 0x0600142E RID: 5166 RVA: 0x00068DD4 File Offset: 0x00066FD4
		protected virtual void Start()
		{
			this.cc = base.GetComponent<vThirdPersonController>();
			this.player = ReInput.players.GetPlayer(this.playerId);
			if (this.cc != null)
			{
				this.cc.Init();
			}
			base.StartCoroutine(this.CharacterInit());
			this.EnableOnAnimatorMove();
		}

		// Token: 0x0600142F RID: 5167 RVA: 0x00068E2F File Offset: 0x0006702F
		protected virtual IEnumerator CharacterInit()
		{
			this.FindCamera();
			yield return new WaitForEndOfFrame();
			this.FindHUD();
			yield break;
		}

		// Token: 0x06001430 RID: 5168 RVA: 0x00068E3E File Offset: 0x0006703E
		public virtual void FindHUD()
		{
			if (this.hud == null && vHUDController.instance != null)
			{
				this.hud = vHUDController.instance;
				this.hud.Init(this.cc);
			}
		}

		// Token: 0x06001431 RID: 5169 RVA: 0x00068E78 File Offset: 0x00067078
		public virtual void FindCamera()
		{
			vThirdPersonCamera[] array = Object.FindObjectsOfType<vThirdPersonCamera>();
			if (array.Length > 1)
			{
				this.tpCamera = Array.Find<vThirdPersonCamera>(array, (vThirdPersonCamera tp) => !tp.isInit);
				if (this.tpCamera == null)
				{
					this.tpCamera = array[0];
				}
				if (this.tpCamera != null)
				{
					for (int i = 0; i < array.Length; i++)
					{
						if (this.tpCamera != array[i])
						{
							Object.Destroy(array[i].gameObject);
						}
					}
				}
			}
			else if (array.Length == 1)
			{
				this.tpCamera = array[0];
			}
			if (this.tpCamera && this.tpCamera.mainTarget != base.transform)
			{
				this.tpCamera.SetMainTarget(base.transform);
			}
		}

		// Token: 0x06001432 RID: 5170 RVA: 0x00068F53 File Offset: 0x00067153
		protected virtual void LateUpdate()
		{
			if (this.cc == null)
			{
				return;
			}
			if (!this.updateIK)
			{
				return;
			}
			if (this.onLateUpdate != null)
			{
				this.onLateUpdate();
			}
			this.CameraInput();
			this.UpdateCameraStates();
			this.updateIK = false;
		}

		// Token: 0x06001433 RID: 5171 RVA: 0x00068F94 File Offset: 0x00067194
		protected virtual void FixedUpdate()
		{
			if (this.onFixedUpdate != null)
			{
				this.onFixedUpdate();
			}
			Physics.SyncTransforms();
			this.cc.UpdateMotor();
			this.cc.ControlLocomotionType();
			this.ControlRotation();
			this.cc.UpdateAnimator();
			this.updateIK = true;
		}

		// Token: 0x06001434 RID: 5172 RVA: 0x00068FE7 File Offset: 0x000671E7
		protected virtual void Update()
		{
			if (this.cc == null || Time.timeScale == 0f)
			{
				return;
			}
			if (this.onUpdate != null)
			{
				this.onUpdate();
			}
			this.InputHandle();
			this.UpdateHUD();
		}

		// Token: 0x06001435 RID: 5173 RVA: 0x00069023 File Offset: 0x00067223
		public virtual void OnAnimatorMoveEvent()
		{
			if (this.cc == null)
			{
				return;
			}
			this.cc.ControlAnimatorRootMotion();
			if (this.onAnimatorMove != null)
			{
				this.onAnimatorMove();
			}
		}

		// Token: 0x06001436 RID: 5174 RVA: 0x00069052 File Offset: 0x00067252
		public virtual void SetLockBasicInput(bool value)
		{
			this.lockInput = value;
		}

		// Token: 0x06001437 RID: 5175 RVA: 0x0006905D File Offset: 0x0006725D
		public virtual void SetLockAllInput(bool value)
		{
			this.SetLockBasicInput(value);
		}

		// Token: 0x06001438 RID: 5176 RVA: 0x0005C010 File Offset: 0x0005A210
		public virtual void ShowCursor(bool value)
		{
			Cursor.visible = value;
		}

		// Token: 0x06001439 RID: 5177 RVA: 0x00069066 File Offset: 0x00067266
		public virtual void LockCursor(bool value)
		{
			if (!value)
			{
				Cursor.lockState = CursorLockMode.Locked;
				return;
			}
			Cursor.lockState = CursorLockMode.None;
		}

		// Token: 0x0600143A RID: 5178 RVA: 0x00069078 File Offset: 0x00067278
		public virtual void SetLockCameraInput(bool value)
		{
			this.lockCameraInput = value;
			if (this.lockCameraInput)
			{
				this.OnLockCamera.Invoke();
				return;
			}
			this.OnUnlockCamera.Invoke();
		}

		// Token: 0x0600143B RID: 5179 RVA: 0x000690A0 File Offset: 0x000672A0
		public virtual void SetLockUpdateMoveDirection(bool value)
		{
			this.lockUpdateMoveDirection = value;
		}

		// Token: 0x0600143C RID: 5180 RVA: 0x000690A9 File Offset: 0x000672A9
		public virtual void SetWalkByDefault(bool value)
		{
			this.cc.freeSpeed.walkByDefault = value;
			this.cc.strafeSpeed.walkByDefault = value;
		}

		// Token: 0x0600143D RID: 5181 RVA: 0x000690CD File Offset: 0x000672CD
		public virtual void SetStrafeLocomotion(bool value)
		{
			this.cc.lockInStrafe = value;
			this.cc.isStrafing = value;
		}

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x0600143E RID: 5182 RVA: 0x000690E7 File Offset: 0x000672E7
		// (set) Token: 0x0600143F RID: 5183 RVA: 0x000690EF File Offset: 0x000672EF
		internal virtual vAnimatorMoveSender animatorMoveSender { get; set; }

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x06001440 RID: 5184 RVA: 0x000690F8 File Offset: 0x000672F8
		// (set) Token: 0x06001441 RID: 5185 RVA: 0x00069100 File Offset: 0x00067300
		protected bool _useAnimatorMove { get; set; }

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06001442 RID: 5186 RVA: 0x00069109 File Offset: 0x00067309
		// (set) Token: 0x06001443 RID: 5187 RVA: 0x00069114 File Offset: 0x00067314
		public virtual bool UseAnimatorMove
		{
			get
			{
				return this._useAnimatorMove;
			}
			set
			{
				if (this._useAnimatorMove != value)
				{
					if (value)
					{
						this.animatorMoveSender = base.gameObject.AddComponent<vAnimatorMoveSender>();
						UnityEvent unityEvent = this.onEnableAnimatorMove;
						if (unityEvent != null)
						{
							unityEvent.Invoke();
						}
					}
					else
					{
						if (this.animatorMoveSender)
						{
							Object.Destroy(this.animatorMoveSender);
						}
						UnityEvent unityEvent2 = this.onEnableAnimatorMove;
						if (unityEvent2 != null)
						{
							unityEvent2.Invoke();
						}
					}
				}
				this._useAnimatorMove = value;
			}
		}

		// Token: 0x06001444 RID: 5188 RVA: 0x00069181 File Offset: 0x00067381
		public virtual void EnableOnAnimatorMove()
		{
			this.UseAnimatorMove = true;
		}

		// Token: 0x06001445 RID: 5189 RVA: 0x0006918A File Offset: 0x0006738A
		public virtual void DisableOnAnimatorMove()
		{
			this.UseAnimatorMove = false;
		}

		// Token: 0x06001446 RID: 5190 RVA: 0x00069193 File Offset: 0x00067393
		protected virtual void InputHandle()
		{
			if (this.lockInput || this.cc.ragdolled)
			{
				return;
			}
			this.MoveInput();
			this.SprintInput();
			this.CrouchInput();
			this.StrafeInput();
			this.JumpInput();
			this.RollInput();
		}

		// Token: 0x06001447 RID: 5191 RVA: 0x000691D0 File Offset: 0x000673D0
		public virtual void MoveInput()
		{
			if (!this.lockMoveInput)
			{
				if (!this.firstpersoncontrols)
				{
					this.cc.input.x = this.player.GetAxis("LeftStickX");
					this.cc.input.z = this.player.GetAxis("LeftStickY");
				}
				else
				{
					float axis = this.player.GetAxis("LeftStickY");
					this.cc.input.z = Mathf.Clamp(axis, 0f, 1f);
					this.cc.input.x = this.player.GetAxis("LeftStickX") / 2f;
				}
			}
			if (Input.GetKeyDown(this.toggleWalk))
			{
				this.cc.alwaysWalkByDefault = !this.cc.alwaysWalkByDefault;
			}
			this.cc.ControlKeepDirection();
		}

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06001448 RID: 5192 RVA: 0x000692BC File Offset: 0x000674BC
		protected virtual bool rotateToLockTargetConditions
		{
			get
			{
				return this.tpCamera && this.tpCamera.lockTarget && this.cc.isStrafing && !this.cc.isRolling && !this.cc.isJumping && !this.cc.customAction;
			}
		}

		// Token: 0x06001449 RID: 5193 RVA: 0x00069320 File Offset: 0x00067520
		public virtual void ControlRotation()
		{
			if (this.cameraMain && !this.lockUpdateMoveDirection && !this.cc.keepDirection)
			{
				this.cc.UpdateMoveDirection(this.cameraMain.transform);
			}
			if (this.rotateToLockTargetConditions)
			{
				this.cc.RotateToPosition(this.tpCamera.lockTarget.position);
				return;
			}
			this.cc.ControlRotationType();
		}

		// Token: 0x0600144A RID: 5194 RVA: 0x00069394 File Offset: 0x00067594
		protected virtual void StrafeInput()
		{
			if (this.strafeInput.GetButtonDown())
			{
				this.cc.Strafe();
			}
		}

		// Token: 0x0600144B RID: 5195 RVA: 0x000693B0 File Offset: 0x000675B0
		protected virtual void SprintInput()
		{
			if (this.sprintInput.useInput)
			{
				this.cc.Sprint(this.cc.useContinuousSprint ? this.player.GetButtonDown("Cross") : this.player.GetButton("Cross"));
			}
		}

		// Token: 0x0600144C RID: 5196 RVA: 0x00069404 File Offset: 0x00067604
		protected virtual void CrouchInput()
		{
			this.cc.AutoCrouch();
			if (this.crouchInput.useInput && this.crouchInput.GetButtonDown())
			{
				this.cc.Crouch();
			}
		}

		// Token: 0x0600144D RID: 5197 RVA: 0x00069438 File Offset: 0x00067638
		protected virtual bool JumpConditions()
		{
			return !this.cc.customAction && !this.cc.isCrouching && this.cc.isGrounded && this.cc.GroundAngle() < this.cc.slopeLimit && this.cc.currentStamina >= this.cc.jumpStamina && !this.cc.isJumping && !this.cc.isRolling;
		}

		// Token: 0x0600144E RID: 5198 RVA: 0x000694B9 File Offset: 0x000676B9
		protected virtual void JumpInput()
		{
			if (this.player.GetButtonDown("Square") && this.JumpConditions())
			{
				this.cc.Jump(true);
			}
		}

		// Token: 0x0600144F RID: 5199 RVA: 0x000694E4 File Offset: 0x000676E4
		protected virtual bool RollConditions()
		{
			return (!this.cc.isRolling || this.cc.canRollAgain) && this.cc.isGrounded && this.cc.input != Vector3.zero && !this.cc.customAction && this.cc.currentStamina > this.cc.rollStamina && !this.cc.isJumping && !this.cc.isSliding;
		}

		// Token: 0x06001450 RID: 5200 RVA: 0x00069571 File Offset: 0x00067771
		protected virtual void RollInput()
		{
			if (this.rollInput.GetButtonDown() && this.RollConditions())
			{
				this.cc.Roll();
			}
		}

		// Token: 0x06001451 RID: 5201 RVA: 0x00069594 File Offset: 0x00067794
		public virtual void CameraInput()
		{
			if (!this.cameraMain)
			{
				return;
			}
			if (this.tpCamera == null)
			{
				return;
			}
			float num = this.lockCameraInput ? 0f : this.rotateCameraYInput.GetAxis();
			float num2 = this.lockCameraInput ? 0f : this.rotateCameraXInput.GetAxis();
			if (this.invertCameraInputHorizontal)
			{
				num2 *= -1f;
			}
			if (this.invertCameraInputVertical)
			{
				num *= -1f;
			}
			float axis = this.cameraZoomInput.GetAxis();
			this.tpCamera.RotateCamera(num2, num);
			if (!this.lockCameraInput)
			{
				this.tpCamera.Zoom(axis);
			}
		}

		// Token: 0x06001452 RID: 5202 RVA: 0x00069644 File Offset: 0x00067844
		public virtual void UpdateCameraStates()
		{
			if (this.ignoreTpCamera)
			{
				return;
			}
			if (this.tpCamera == null)
			{
				this.tpCamera = Object.FindObjectOfType<vThirdPersonCamera>();
				if (this.tpCamera == null)
				{
					return;
				}
				if (this.tpCamera)
				{
					this.tpCamera.SetMainTarget(base.transform);
					this.tpCamera.Init();
				}
			}
			if (this.changeCameraState)
			{
				this.tpCamera.ChangeState(this.customCameraState, this.customlookAtPoint, this.smoothCameraState);
				return;
			}
			if (this.cc.isCrouching)
			{
				this.tpCamera.ChangeState("Crouch", true);
				return;
			}
			if (this.cc.isStrafing)
			{
				this.tpCamera.ChangeState("Strafing", true);
				return;
			}
			this.tpCamera.ChangeState("Default", true);
		}

		// Token: 0x06001453 RID: 5203 RVA: 0x00069720 File Offset: 0x00067920
		public virtual void ChangeCameraState(string cameraState, bool useLerp = true)
		{
			if (useLerp)
			{
				this.ChangeCameraStateWithLerp(cameraState);
				return;
			}
			this.ChangeCameraStateNoLerp(cameraState);
		}

		// Token: 0x06001454 RID: 5204 RVA: 0x00069734 File Offset: 0x00067934
		public virtual void ResetCameraAngle()
		{
			if (this.tpCamera)
			{
				this.tpCamera.ResetAngle();
			}
		}

		// Token: 0x06001455 RID: 5205 RVA: 0x0006974E File Offset: 0x0006794E
		public virtual void ChangeCameraStateWithLerp(string cameraState)
		{
			this.changeCameraState = true;
			this.customCameraState = cameraState;
			this.smoothCameraState = true;
		}

		// Token: 0x06001456 RID: 5206 RVA: 0x00069765 File Offset: 0x00067965
		public virtual void ChangeCameraStateNoLerp(string cameraState)
		{
			this.changeCameraState = true;
			this.customCameraState = cameraState;
			this.smoothCameraState = false;
		}

		// Token: 0x06001457 RID: 5207 RVA: 0x0006977C File Offset: 0x0006797C
		public virtual void ResetCameraState()
		{
			this.changeCameraState = false;
			this.customCameraState = string.Empty;
		}

		// Token: 0x06001458 RID: 5208 RVA: 0x00069790 File Offset: 0x00067990
		public virtual void UpdateHUD()
		{
			if (this.hud == null)
			{
				if (!(vHUDController.instance != null))
				{
					return;
				}
				this.hud = vHUDController.instance;
				this.hud.Init(this.cc);
			}
			this.hud.UpdateHUD(this.cc);
		}

		// Token: 0x0600145A RID: 5210 RVA: 0x00069920 File Offset: 0x00067B20
		bool vIAnimatorMoveReceiver.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x0600145B RID: 5211 RVA: 0x00069928 File Offset: 0x00067B28
		void vIAnimatorMoveReceiver.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x040019AF RID: 6575
		private int playerId;

		// Token: 0x040019B0 RID: 6576
		private Player player;

		// Token: 0x040019B1 RID: 6577
		[vEditorToolbar("Inputs", false, "", false, false)]
		[vHelpBox("Check these options if you need to use the mouse cursor, ex: <b>2.5D, Topdown or Mobile</b>", vHelpBoxAttribute.MessageType.Info)]
		public bool unlockCursorOnStart;

		// Token: 0x040019B2 RID: 6578
		public bool showCursorOnStart;

		// Token: 0x040019B3 RID: 6579
		[vHelpBox("PC only - use it to toggle between run/walk", vHelpBoxAttribute.MessageType.Info)]
		public KeyCode toggleWalk = KeyCode.CapsLock;

		// Token: 0x040019B4 RID: 6580
		[Header("Movement Input")]
		public GenericInput horizontalInput = new GenericInput("Horizontal", "LeftAnalogHorizontal", "Horizontal");

		// Token: 0x040019B5 RID: 6581
		public GenericInput verticallInput = new GenericInput("Vertical", "LeftAnalogVertical", "Vertical");

		// Token: 0x040019B6 RID: 6582
		public GenericInput sprintInput = new GenericInput("LeftShift", "LeftStickClick", "LeftStickClick");

		// Token: 0x040019B7 RID: 6583
		public GenericInput crouchInput = new GenericInput("C", "Y", "Y");

		// Token: 0x040019B8 RID: 6584
		public GenericInput strafeInput = new GenericInput("Tab", "RightStickClick", "RightStickClick");

		// Token: 0x040019B9 RID: 6585
		public GenericInput jumpInput = new GenericInput("Space", "X", "X");

		// Token: 0x040019BA RID: 6586
		public GenericInput rollInput = new GenericInput("Q", "B", "B");

		// Token: 0x040019BB RID: 6587
		[HideInInspector]
		public bool lockInput;

		// Token: 0x040019BC RID: 6588
		[vEditorToolbar("Camera Settings", false, "", false, false)]
		public bool lockCameraInput;

		// Token: 0x040019BD RID: 6589
		public bool invertCameraInputVertical;

		// Token: 0x040019BE RID: 6590
		public bool invertCameraInputHorizontal;

		// Token: 0x040019BF RID: 6591
		[vEditorToolbar("Inputs", false, "", false, false)]
		[Header("Camera Input")]
		public GenericInput rotateCameraXInput = new GenericInput("Mouse X", "RightAnalogHorizontal", "Mouse X");

		// Token: 0x040019C0 RID: 6592
		public GenericInput rotateCameraYInput = new GenericInput("Mouse Y", "RightAnalogVertical", "Mouse Y");

		// Token: 0x040019C1 RID: 6593
		public GenericInput cameraZoomInput = new GenericInput("Mouse ScrollWheel", "", "");

		// Token: 0x040019C2 RID: 6594
		[vEditorToolbar("Events", false, "", false, false)]
		public UnityEvent OnLockCamera;

		// Token: 0x040019C3 RID: 6595
		public UnityEvent OnUnlockCamera;

		// Token: 0x040019C4 RID: 6596
		public UnityEvent onEnableAnimatorMove = new UnityEvent();

		// Token: 0x040019C5 RID: 6597
		public UnityEvent onDisableDisableAnimatorMove = new UnityEvent();

		// Token: 0x040019C6 RID: 6598
		[HideInInspector]
		public vThirdPersonCamera tpCamera;

		// Token: 0x040019C7 RID: 6599
		[HideInInspector]
		public bool ignoreTpCamera;

		// Token: 0x040019C8 RID: 6600
		[HideInInspector]
		public string customCameraState;

		// Token: 0x040019C9 RID: 6601
		[HideInInspector]
		public string customlookAtPoint;

		// Token: 0x040019CA RID: 6602
		[HideInInspector]
		public bool changeCameraState;

		// Token: 0x040019CB RID: 6603
		[HideInInspector]
		public bool smoothCameraState;

		// Token: 0x040019CC RID: 6604
		[HideInInspector]
		public vThirdPersonController cc;

		// Token: 0x040019CD RID: 6605
		[HideInInspector]
		public vHUDController hud;

		// Token: 0x040019CE RID: 6606
		protected bool updateIK;

		// Token: 0x040019CF RID: 6607
		protected bool isInit;

		// Token: 0x040019D0 RID: 6608
		[HideInInspector]
		public bool lockMoveInput;

		// Token: 0x040019D1 RID: 6609
		public bool firstpersoncontrols;

		// Token: 0x040019D2 RID: 6610
		protected Camera _cameraMain;

		// Token: 0x040019D3 RID: 6611
		protected bool withoutMainCamera;

		// Token: 0x040019D4 RID: 6612
		internal bool lockUpdateMoveDirection;

		// Token: 0x020003F0 RID: 1008
		// (Invoke) Token: 0x0600145D RID: 5213
		public delegate void OnUpdateEvent();
	}
}
