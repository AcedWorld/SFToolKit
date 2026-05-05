using System;
using System.Collections;
using Invector.vCharacterController;
using UnityEngine;

namespace Invector.vCamera
{
	// Token: 0x02000421 RID: 1057
	public class vThirdPersonCamera : MonoBehaviour
	{
		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x060015E8 RID: 5608 RVA: 0x00073085 File Offset: 0x00071285
		public static vThirdPersonCamera instance
		{
			get
			{
				if (vThirdPersonCamera._instance == null)
				{
					vThirdPersonCamera._instance = Object.FindObjectOfType<vThirdPersonCamera>();
				}
				return vThirdPersonCamera._instance;
			}
		}

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x060015E9 RID: 5609 RVA: 0x000730A4 File Offset: 0x000712A4
		protected Transform targetLookAt
		{
			get
			{
				if (!this._lookAtTarget)
				{
					this._lookAtTarget = new GameObject("targetLookAt").transform;
					this._lookAtTarget.rotation = base.transform.rotation;
					this._lookAtTarget.position = this.mainTarget.position;
				}
				return this._lookAtTarget;
			}
		}

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x060015EA RID: 5610 RVA: 0x00073105 File Offset: 0x00071305
		public Rigidbody selfRigidbody
		{
			get
			{
				if (!this._selfRigidbody)
				{
					this._selfRigidbody = base.gameObject.AddComponent<Rigidbody>();
					this._selfRigidbody.isKinematic = true;
					this._selfRigidbody.interpolation = RigidbodyInterpolation.None;
				}
				return this._selfRigidbody;
			}
		}

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x060015EB RID: 5611 RVA: 0x00073143 File Offset: 0x00071343
		// (set) Token: 0x060015EC RID: 5612 RVA: 0x0007314B File Offset: 0x0007134B
		public bool LockCamera
		{
			get
			{
				return this.lockCamera;
			}
			set
			{
				this.lockCamera = value;
			}
		}

		// Token: 0x060015ED RID: 5613 RVA: 0x00073154 File Offset: 0x00071354
		protected virtual void OnDrawGizmos()
		{
			if (this.showGizmos && this.currentTarget)
			{
				Vector3 vector = new Vector3(this.currentTarget.position.x, this.currentTarget.position.y + this.offSetPlayerPivot, this.currentTarget.position.z);
				Gizmos.DrawWireSphere(vector + Vector3.up * this.cullingHeight, this.checkHeightRadius);
				Gizmos.DrawLine(vector, vector + Vector3.up * this.cullingHeight);
			}
		}

		// Token: 0x060015EE RID: 5614 RVA: 0x000731F1 File Offset: 0x000713F1
		protected virtual void Start()
		{
			this.Init();
		}

		// Token: 0x060015EF RID: 5615 RVA: 0x000731FC File Offset: 0x000713FC
		public virtual void Init()
		{
			if (this.mainTarget == null)
			{
				return;
			}
			this.firstUpdated = true;
			this.useSmooth = true;
			this.targetLookAt.rotation = (this.startUsingTargetRotation ? this.mainTarget.rotation : base.transform.rotation);
			this.targetLookAt.position = this.mainTarget.position;
			this.targetLookAt.hideFlags = HideFlags.HideInHierarchy;
			this.startPosition = this.selfRigidbody.position;
			this.startRotation = this.selfRigidbody.rotation;
			this.initialCameraRotation = this.smoothCameraRotation;
			if (!this.targetCamera)
			{
				this.targetCamera = Camera.main;
			}
			this.currentTarget = this.mainTarget;
			this.switchRight = 1f;
			this.currentSwitchRight = 1f;
			this.mouseXStart = base.transform.eulerAngles.NormalizeAngle().y;
			this.mouseYStart = base.transform.eulerAngles.NormalizeAngle().x;
			if (this.startSmooth)
			{
				this.distance = Vector3.Distance(this.targetLookAt.position, base.transform.position);
			}
			else
			{
				this.transformWeight = 1f;
			}
			if (this.startUsingTargetRotation)
			{
				this.mouseY = this.currentTarget.eulerAngles.NormalizeAngle().x;
				this.mouseX = this.currentTarget.eulerAngles.NormalizeAngle().y;
			}
			else
			{
				this.mouseY = base.transform.eulerAngles.NormalizeAngle().x;
				this.mouseX = base.transform.eulerAngles.NormalizeAngle().y;
			}
			this.ChangeState("Default", this.startSmooth);
			this.currentZoom = this.currentState.defaultDistance;
			this.currentHeight = this.currentState.height;
			this.currentTargetPos = new Vector3(this.currentTarget.position.x, this.currentTarget.position.y + this.offSetPlayerPivot, this.currentTarget.position.z) + this.currentTarget.transform.up * this.lerpState.height;
			this.targetLookAt.position = this.currentTargetPos;
			this.isInit = true;
		}

		// Token: 0x060015F0 RID: 5616 RVA: 0x00073470 File Offset: 0x00071670
		public virtual void FixedUpdate()
		{
			if (this.mainTarget == null || this.targetLookAt == null || this.currentState == null || this.lerpState == null || !this.isInit || this.isFreezed)
			{
				return;
			}
			switch (this.currentState.cameraMode)
			{
			case TPCameraMode.FreeDirectional:
				this.CameraMovement(false);
				return;
			case TPCameraMode.FixedAngle:
				this.CameraMovement(false);
				return;
			case TPCameraMode.FixedPoint:
				this.CameraFixed();
				return;
			default:
				return;
			}
		}

		// Token: 0x060015F1 RID: 5617 RVA: 0x000734F0 File Offset: 0x000716F0
		public virtual void SetLockTarget(Transform lockTarget)
		{
			if (this.lockTarget != null && this.lockTarget == lockTarget)
			{
				return;
			}
			this.isNewTarget = (lockTarget != this.lockTarget);
			this.lockTarget = lockTarget;
			this.lockTargetWeight = 0f;
			this.lockTargetSpeed = 1f;
		}

		// Token: 0x060015F2 RID: 5618 RVA: 0x0007354C File Offset: 0x0007174C
		public virtual void SetLockTarget(Transform lockTarget, float heightOffset, float lockSpeed = 1f)
		{
			if (this.lockTarget != null && this.lockTarget == lockTarget)
			{
				return;
			}
			this.isNewTarget = (lockTarget != this.lockTarget);
			this.lockTarget = lockTarget;
			this.heightOffset = heightOffset;
			this.lockTargetWeight = 0f;
			this.lockTargetSpeed = lockSpeed;
		}

		// Token: 0x060015F3 RID: 5619 RVA: 0x000735A8 File Offset: 0x000717A8
		public virtual void RemoveLockTarget()
		{
			this.lockTargetWeight = 0f;
			this.lockTarget = null;
		}

		// Token: 0x060015F4 RID: 5620 RVA: 0x000735BC File Offset: 0x000717BC
		public virtual void SetTarget(Transform newTarget)
		{
			this.lockTargetWeight = 0f;
			this.currentTarget = (newTarget ? newTarget : this.mainTarget);
		}

		// Token: 0x060015F5 RID: 5621 RVA: 0x000735E0 File Offset: 0x000717E0
		public virtual void SetMainTarget(Transform newTarget)
		{
			this.mainTarget = newTarget;
			this.currentTarget = newTarget;
			if (!this.isInit)
			{
				this.Init();
			}
		}

		// Token: 0x060015F6 RID: 5622 RVA: 0x000735FE File Offset: 0x000717FE
		public virtual void ResetTarget()
		{
			if (this.currentTarget != this.mainTarget)
			{
				this.currentTarget = this.mainTarget;
				if (!this.isInit)
				{
					this.Init();
				}
			}
		}

		// Token: 0x060015F7 RID: 5623 RVA: 0x00073630 File Offset: 0x00071830
		public virtual void ResetAngle()
		{
			if (this.currentTarget)
			{
				this.mouseY = this.currentTarget.eulerAngles.NormalizeAngle().x;
				this.mouseX = this.currentTarget.eulerAngles.NormalizeAngle().y;
				return;
			}
			this.mouseY = 0f;
			this.mouseX = 0f;
		}

		// Token: 0x060015F8 RID: 5624 RVA: 0x00073697 File Offset: 0x00071897
		public virtual Ray ScreenPointToRay(Vector3 Point)
		{
			return base.GetComponent<Camera>().ScreenPointToRay(Point);
		}

		// Token: 0x060015F9 RID: 5625 RVA: 0x000736A5 File Offset: 0x000718A5
		public virtual void ChangeState(string stateName)
		{
			this.ChangeState(stateName, true);
		}

		// Token: 0x060015FA RID: 5626 RVA: 0x000736B0 File Offset: 0x000718B0
		public virtual void ChangeState(string stateName, bool hasSmooth)
		{
			if ((this.currentState != null && this.currentState.Name.Equals(stateName)) || (!this.isInit && this.firstStateIsInit))
			{
				if (this.firstStateIsInit)
				{
					this.useSmooth = hasSmooth;
				}
				return;
			}
			this.useSmooth = ((!this.firstStateIsInit) ? this.startSmooth : hasSmooth);
			vThirdPersonCameraState vThirdPersonCameraState = (this.CameraStateList != null) ? this.CameraStateList.tpCameraStates.Find((vThirdPersonCameraState obj) => obj.Name.Equals(stateName)) : new vThirdPersonCameraState("Default");
			if (vThirdPersonCameraState != null)
			{
				this.currentStateName = stateName;
				this.currentState.cameraMode = vThirdPersonCameraState.cameraMode;
				this.lerpState = vThirdPersonCameraState;
				if (!this.firstStateIsInit)
				{
					this.currentState.defaultDistance = Vector3.Distance(this.targetLookAt.position, base.transform.position);
					this.currentState.forward = this.lerpState.forward;
					this.currentState.height = vThirdPersonCameraState.height;
					this.currentState.fov = vThirdPersonCameraState.fov;
					if (this.useSmooth)
					{
						base.StartCoroutine(this.ResetFirstState());
					}
					else
					{
						this.distance = this.lerpState.defaultDistance;
						this.firstStateIsInit = true;
					}
				}
				if (this.currentState != null && !this.useSmooth)
				{
					this.currentState.CopyState(vThirdPersonCameraState);
				}
			}
			else if (this.CameraStateList != null && this.CameraStateList.tpCameraStates.Count > 0)
			{
				if (this.lerpState != null)
				{
					return;
				}
				vThirdPersonCameraState = this.CameraStateList.tpCameraStates[0];
				this.currentStateName = vThirdPersonCameraState.Name;
				this.currentState.cameraMode = vThirdPersonCameraState.cameraMode;
				this.lerpState = vThirdPersonCameraState;
				if (this.currentState != null && !this.useSmooth)
				{
					this.currentState.CopyState(vThirdPersonCameraState);
				}
			}
			if (this.currentState == null)
			{
				this.currentState = new vThirdPersonCameraState("Null");
				this.currentStateName = this.currentState.Name;
			}
			if (this.CameraStateList != null)
			{
				this.indexList = this.CameraStateList.tpCameraStates.IndexOf(vThirdPersonCameraState);
			}
			this.currentZoom = vThirdPersonCameraState.defaultDistance;
			if (this.currentState.cameraMode == TPCameraMode.FixedAngle)
			{
				this.mouseX = this.currentState.fixedAngle.x;
				this.mouseY = this.currentState.fixedAngle.y;
			}
			this.currentState.fixedAngle = new Vector3(this.mouseX, this.mouseY);
			this.indexLookPoint = 0;
			if (!this.isInit)
			{
				this.CameraMovement(true);
			}
		}

		// Token: 0x060015FB RID: 5627 RVA: 0x00073988 File Offset: 0x00071B88
		public virtual void ChangeState(string stateName, string pointName, bool hasSmooth)
		{
			this.useSmooth = hasSmooth;
			if (!this.currentState.Name.Equals(stateName))
			{
				vThirdPersonCameraState vThirdPersonCameraState = this.CameraStateList.tpCameraStates.Find((vThirdPersonCameraState obj) => obj.Name.Equals(stateName));
				if (vThirdPersonCameraState != null)
				{
					this.currentStateName = stateName;
					this.currentState.cameraMode = vThirdPersonCameraState.cameraMode;
					this.lerpState = vThirdPersonCameraState;
					if (this.currentState != null && !hasSmooth)
					{
						this.currentState.CopyState(vThirdPersonCameraState);
					}
				}
				else if (this.CameraStateList.tpCameraStates.Count > 0)
				{
					vThirdPersonCameraState = this.CameraStateList.tpCameraStates[0];
					this.currentStateName = vThirdPersonCameraState.Name;
					this.currentState.cameraMode = vThirdPersonCameraState.cameraMode;
					this.lerpState = vThirdPersonCameraState;
					if (this.currentState != null && !hasSmooth)
					{
						this.currentState.CopyState(vThirdPersonCameraState);
					}
				}
				if (this.currentState == null)
				{
					this.currentState = new vThirdPersonCameraState("Null");
					this.currentStateName = this.currentState.Name;
				}
				this.indexList = this.CameraStateList.tpCameraStates.IndexOf(vThirdPersonCameraState);
				this.currentZoom = vThirdPersonCameraState.defaultDistance;
				this.currentState.fixedAngle = new Vector3(this.mouseX, this.mouseY);
				this.indexLookPoint = 0;
			}
			if (this.currentState.cameraMode == TPCameraMode.FixedPoint)
			{
				LookPoint lookPoint = this.currentState.lookPoints.Find((LookPoint obj) => obj.pointName.Equals(pointName));
				if (lookPoint != null)
				{
					this.indexLookPoint = this.currentState.lookPoints.IndexOf(lookPoint);
					return;
				}
				this.indexLookPoint = 0;
			}
		}

		// Token: 0x060015FC RID: 5628 RVA: 0x00073B49 File Offset: 0x00071D49
		protected virtual IEnumerator ResetFirstState()
		{
			yield return new WaitForEndOfFrame();
			this.firstStateIsInit = true;
			yield break;
		}

		// Token: 0x060015FD RID: 5629 RVA: 0x00073B58 File Offset: 0x00071D58
		public virtual void ChangePoint(string pointName)
		{
			if (this.currentState == null || this.currentState.cameraMode != TPCameraMode.FixedPoint || this.currentState.lookPoints == null)
			{
				return;
			}
			LookPoint lookPoint = this.currentState.lookPoints.Find((LookPoint obj) => obj.pointName.Equals(pointName));
			if (lookPoint != null)
			{
				this.indexLookPoint = this.currentState.lookPoints.IndexOf(lookPoint);
				return;
			}
			this.indexLookPoint = 0;
		}

		// Token: 0x060015FE RID: 5630 RVA: 0x00073BD8 File Offset: 0x00071DD8
		public virtual void FreezeCamera()
		{
			this.isFreezed = true;
			if (this.mainTarget)
			{
				this.lastLookAtForward = this.mainTarget.InverseTransformDirection(this.targetLookAt.forward);
				this.lastLookAtPosition = this.mainTarget.InverseTransformPoint(this.targetLookAt.position);
				this.current_cPos = this.mainTarget.InverseTransformPoint(this.current_cPos);
				this.desired_cPos = this.mainTarget.InverseTransformPoint(this.desired_cPos);
			}
		}

		// Token: 0x060015FF RID: 5631 RVA: 0x00073C60 File Offset: 0x00071E60
		public virtual void UnFreezeCamera()
		{
			if (this.mainTarget)
			{
				this.targetLookAt.forward = this.mainTarget.TransformDirection(this.lastLookAtForward);
				this.targetLookAt.position = this.mainTarget.TransformPoint(this.lastLookAtPosition);
				this.current_cPos = this.mainTarget.TransformPoint(this.current_cPos);
				this.desired_cPos = this.mainTarget.TransformPoint(this.desired_cPos);
			}
			this.isFreezed = false;
		}

		// Token: 0x06001600 RID: 5632 RVA: 0x00073CE7 File Offset: 0x00071EE7
		public virtual void Zoom(float scroolValue)
		{
			this.currentZoom -= scroolValue * this.scrollSpeed;
		}

		// Token: 0x06001601 RID: 5633 RVA: 0x00073D00 File Offset: 0x00071F00
		public virtual void CheckCameraIsRotating()
		{
			this.cameraIsRotating = ((double)(base.transform.eulerAngles - this.lastCameraRotation.eulerAngles).magnitude > 0.1 || this.movementSpeed.magnitude > 0f);
			this.lastCameraRotation.eulerAngles = base.transform.eulerAngles;
		}

		// Token: 0x06001602 RID: 5634 RVA: 0x00073D70 File Offset: 0x00071F70
		public virtual void RotateCamera(float x, float y)
		{
			if (this.currentState.cameraMode.Equals(TPCameraMode.FixedPoint) || !this.isInit)
			{
				this.smoothCameraRotation = this.initialCameraRotation;
				return;
			}
			if (!this.currentState.cameraMode.Equals(TPCameraMode.FixedAngle))
			{
				if (this.lockTarget)
				{
					this.smoothCameraRotation = this.initialCameraRotation;
					return;
				}
				this.mouseX += x * ((vInput.instance.inputDevice == InputDevice.Joystick) ? (this.currentState.xMouseSensitivity * this.joystickSensitivity) : this.currentState.xMouseSensitivity);
				this.mouseY -= y * ((vInput.instance.inputDevice == InputDevice.Joystick) ? (this.currentState.yMouseSensitivity * this.joystickSensitivity) : this.currentState.yMouseSensitivity);
				this.movementSpeed.x = x;
				this.movementSpeed.y = -y;
				this.CheckCameraIsRotating();
				bool flag = (base.transform.forward - this.currentTarget.forward).magnitude <= 0.5f;
				if (!this.LockCamera && this.cameraIsRotating)
				{
					this.lastRotationTimer = Time.time;
					if (this.movementSpeed.x != 0f || this.movementSpeed.y != 0f)
					{
						this.smoothCameraRotation = this.initialCameraRotation;
					}
					this.mouseY = vExtensions.ClampAngle(this.mouseY, this.lerpState.yMinLimit, this.lerpState.yMaxLimit);
					this.mouseX = vExtensions.ClampAngle(this.mouseX, this.lerpState.xMinLimit, this.lerpState.xMaxLimit);
					return;
				}
				if (this.LockCamera || (!flag && this.autoBehindTarget))
				{
					if (this.autoBehindTarget)
					{
						this.smoothCameraRotation = Mathf.Lerp(this.smoothCameraRotation, this.behindTargetSmoothRotation, 6f * Time.fixedDeltaTime);
					}
					if (this.LockCamera || Time.time > this.lastRotationTimer + this.behindTargetDelay)
					{
						this.mouseY = this.currentTarget.root.eulerAngles.NormalizeAngle().x;
						this.mouseX = this.currentTarget.root.eulerAngles.NormalizeAngle().y;
						return;
					}
				}
			}
			else
			{
				this.smoothCameraRotation = this.initialCameraRotation;
				float x2 = this.lerpState.fixedAngle.x;
				float y2 = this.lerpState.fixedAngle.y;
				this.mouseX = (this.useSmooth ? Mathf.LerpAngle(this.mouseX, x2, this.smoothBetweenState * Time.fixedDeltaTime) : x2);
				this.mouseY = (this.useSmooth ? Mathf.LerpAngle(this.mouseY, y2, this.smoothBetweenState * Time.fixedDeltaTime) : y2);
			}
		}

		// Token: 0x06001603 RID: 5635 RVA: 0x00074074 File Offset: 0x00072274
		public virtual void SwitchRight(bool value = false)
		{
			this.switchRight = (float)(value ? -1 : 1);
		}

		// Token: 0x06001604 RID: 5636 RVA: 0x00074084 File Offset: 0x00072284
		protected virtual void CalculeLockOnPoint()
		{
			if (this.currentState.cameraMode.Equals(TPCameraMode.FixedAngle) && this.lockTarget)
			{
				return;
			}
			Collider component = this.lockTarget.GetComponent<Collider>();
			if (component == null)
			{
				return;
			}
			Quaternion quaternion = Quaternion.LookRotation(component.bounds.center - this.desired_cPos);
			float y = quaternion.eulerAngles.y;
			float angle;
			if (quaternion.eulerAngles.x < -180f)
			{
				angle = quaternion.eulerAngles.x + 360f;
			}
			else if (quaternion.eulerAngles.x > 180f)
			{
				angle = quaternion.eulerAngles.x - 360f;
			}
			else
			{
				angle = quaternion.eulerAngles.x;
			}
			if (this.lockTargetWeight < 1f)
			{
				this.lockTargetWeight += Time.fixedDeltaTime * this.lockTargetSpeed;
			}
			this.mouseY = Mathf.LerpAngle(this.mouseY, vExtensions.ClampAngle(angle, this.currentState.yMinLimit, this.currentState.yMaxLimit), this.lockTargetWeight);
			this.mouseX = Mathf.LerpAngle(this.mouseX, vExtensions.ClampAngle(y, this.currentState.xMinLimit, this.currentState.xMaxLimit), this.lockTargetWeight);
		}

		// Token: 0x06001605 RID: 5637 RVA: 0x000741F0 File Offset: 0x000723F0
		protected virtual void CameraMovement(bool forceUpdate = false)
		{
			if (this.currentTarget == null || this.targetCamera == null || (!this.firstStateIsInit && !forceUpdate))
			{
				return;
			}
			this.transformWeight = Mathf.Clamp(this.transformWeight += Time.fixedDeltaTime, 0f, 1f);
			if (this.useSmooth)
			{
				this.currentState.Slerp(this.lerpState, this.smoothBetweenState * Time.fixedDeltaTime);
			}
			else
			{
				this.currentState.CopyState(this.lerpState);
			}
			if (this.currentState.useZoom)
			{
				this.currentZoom = Mathf.Clamp(this.currentZoom, this.currentState.minDistance, this.currentState.maxDistance);
				this.distance = (this.useSmooth ? Mathf.Lerp(this.distance, this.currentZoom, this.lerpState.smooth * Time.fixedDeltaTime) : this.currentZoom);
			}
			else
			{
				this.distance = (this.useSmooth ? Mathf.Lerp(this.distance, this.currentState.defaultDistance, this.lerpState.smooth * Time.fixedDeltaTime) : this.currentState.defaultDistance);
				this.currentZoom = this.currentState.defaultDistance;
			}
			this.targetCamera.fieldOfView = this.currentState.fov;
			this.cullingDistance = Mathf.Lerp(this.cullingDistance, this.currentZoom, this.smoothBetweenState * Time.fixedDeltaTime);
			this.currentSwitchRight = Mathf.Lerp(this.currentSwitchRight, this.switchRight, this.smoothSwitchSide * Time.fixedDeltaTime);
			Vector3 normalized = (this.currentState.forward * this.targetLookAt.forward + this.currentState.right * this.currentSwitchRight * this.targetLookAt.right).normalized;
			Vector3 vector = new Vector3(this.currentTarget.position.x, this.currentTarget.position.y, this.currentTarget.position.z) + this.currentTarget.transform.up * this.offSetPlayerPivot;
			this.currentTargetPos = vector;
			this.desired_cPos = vector + this.currentTarget.transform.up * this.currentState.height;
			this.current_cPos = (this.firstUpdated ? (vector + this.currentTarget.transform.up * this.currentHeight) : Vector3.SmoothDamp(this.current_cPos, vector + this.currentTarget.transform.up * this.currentHeight, ref this.cameraVelocityDamp, this.lerpState.smoothDamp * Time.fixedDeltaTime));
			this.firstUpdated = false;
			ClipPlanePoints to = this.targetCamera.NearClipPlanePoints(this.current_cPos + normalized * this.distance, this.clipPlaneMargin);
			ClipPlanePoints to2 = this.targetCamera.NearClipPlanePoints(this.desired_cPos + normalized * this.currentZoom, this.clipPlaneMargin);
			RaycastHit raycastHit;
			if (Physics.SphereCast(vector, this.checkHeightRadius, this.currentTarget.transform.up, out raycastHit, this.currentState.cullingHeight + 0.2f, this.cullingLayer))
			{
				float num = raycastHit.distance - 0.2f;
				num -= this.currentState.height;
				num /= this.currentState.cullingHeight - this.currentState.height;
				this.cullingHeight = Mathf.Lerp(this.currentState.height, this.currentState.cullingHeight, Mathf.Clamp(num, 0f, 1f));
			}
			else
			{
				this.cullingHeight = (this.useSmooth ? Mathf.Lerp(this.cullingHeight, this.currentState.cullingHeight, this.smoothBetweenState * Time.fixedDeltaTime) : this.currentState.cullingHeight);
			}
			if (this.CullingRayCast(this.desired_cPos, to2, out raycastHit, this.currentZoom + 0.2f, this.cullingLayer, Color.blue))
			{
				float num2 = raycastHit.distance;
				if (num2 < this.currentState.defaultDistance)
				{
					float num3 = num2;
					num3 -= this.currentState.cullingMinDist;
					num3 /= this.currentZoom - this.currentState.cullingMinDist;
					this.currentHeight = Mathf.Lerp(this.cullingHeight, this.currentState.height, Mathf.Clamp(num3, 0f, 1f));
					this.current_cPos = vector + this.currentTarget.transform.up * this.currentHeight;
				}
			}
			else
			{
				this.currentHeight = (this.useSmooth ? Mathf.Lerp(this.currentHeight, this.currentState.height, this.smoothBetweenState * Time.fixedDeltaTime) : this.currentState.height);
			}
			if (this.cullingDistance < this.distance)
			{
				this.distance = this.cullingDistance;
			}
			if (this.CullingRayCast(this.current_cPos, to, out raycastHit, this.distance, this.cullingLayer, Color.cyan))
			{
				this.distance = Mathf.Clamp(this.cullingDistance, 0f, this.currentState.defaultDistance);
			}
			Vector3 a = this.current_cPos + this.targetLookAt.forward * this.targetCamera.farClipPlane + this.targetLookAt.right * Vector3.Dot(normalized * this.distance, this.targetLookAt.right);
			this.targetLookAt.position = this.current_cPos;
			float num4 = Mathf.LerpAngle(this.mouseYStart, this.mouseY, this.transformWeight);
			float num5 = Mathf.LerpAngle(this.mouseXStart, this.mouseX, this.transformWeight);
			Quaternion quaternion = Quaternion.Euler(num4 + this.offsetMouse.y, num5 + this.offsetMouse.x, 0f);
			this.targetLookAt.rotation = (this.useSmooth ? Quaternion.Lerp(this.targetLookAt.rotation, quaternion, this.smoothCameraRotation * Time.fixedDeltaTime) : quaternion);
			this.selfRigidbody.MovePosition(Vector3.Lerp(this.startPosition, this.current_cPos + normalized * this.distance, this.transformWeight));
			Quaternion quaternion2 = Quaternion.LookRotation(a - this.selfRigidbody.position);
			if (this.lockTarget)
			{
				this.CalculeLockOnPoint();
				if (!this.currentState.cameraMode.Equals(TPCameraMode.FixedAngle))
				{
					Collider component = this.lockTarget.GetComponent<Collider>();
					if (component != null)
					{
						Vector3 vector2 = Quaternion.LookRotation(component.bounds.center + Vector3.up * this.heightOffset - this.selfRigidbody.position).eulerAngles - quaternion2.eulerAngles;
						if (this.isNewTarget)
						{
							this.lookTargetAdjust.x = Mathf.LerpAngle(this.lookTargetAdjust.x, vector2.x, this.lockTargetWeight);
							this.lookTargetAdjust.y = Mathf.LerpAngle(this.lookTargetAdjust.y, vector2.y, this.lockTargetWeight);
							this.lookTargetAdjust.z = Mathf.LerpAngle(this.lookTargetAdjust.z, vector2.z, this.lockTargetWeight);
							if (Vector3.Distance(this.lookTargetAdjust, vector2) < 0.5f)
							{
								this.isNewTarget = false;
							}
						}
						else
						{
							this.lookTargetAdjust = vector2;
						}
					}
				}
			}
			else
			{
				this.lookTargetAdjust.x = Mathf.LerpAngle(this.lookTargetAdjust.x, 0f, this.currentState.smooth * Time.fixedDeltaTime);
				this.lookTargetAdjust.y = Mathf.LerpAngle(this.lookTargetAdjust.y, 0f, this.currentState.smooth * Time.fixedDeltaTime);
				this.lookTargetAdjust.z = Mathf.LerpAngle(this.lookTargetAdjust.z, 0f, this.currentState.smooth * Time.fixedDeltaTime);
			}
			Vector3 a2 = quaternion2.eulerAngles + this.lookTargetAdjust;
			a2.z = 0f;
			Quaternion b = Quaternion.Euler(a2 + this.currentState.rotationOffSet);
			this.selfRigidbody.MoveRotation(Quaternion.Lerp(this.startRotation, b, this.transformWeight));
			this.movementSpeed = Vector2.zero;
		}

		// Token: 0x06001606 RID: 5638 RVA: 0x00074B1C File Offset: 0x00072D1C
		protected virtual void CameraFixed()
		{
			if (this.useSmooth)
			{
				this.currentState.Slerp(this.lerpState, this.smoothBetweenState);
			}
			else
			{
				this.currentState.CopyState(this.lerpState);
			}
			this.transformWeight = Mathf.Clamp(this.transformWeight += Time.fixedDeltaTime, 0f, 1f);
			Vector3 vector = new Vector3(this.currentTarget.position.x, this.currentTarget.position.y + this.offSetPlayerPivot + this.currentState.height, this.currentTarget.position.z);
			this.currentTargetPos = (this.useSmooth ? Vector3.MoveTowards(this.currentTargetPos, vector, this.currentState.smooth * Time.fixedDeltaTime) : vector);
			this.current_cPos = this.currentTargetPos;
			Vector3 vector2 = this.isValidFixedPoint ? this.currentState.lookPoints[this.indexLookPoint].positionPoint : base.transform.position;
			base.transform.position = Vector3.Lerp(this.startPosition, this.useSmooth ? Vector3.Lerp(base.transform.position, vector2, this.currentState.smooth * Time.fixedDeltaTime) : vector2, this.transformWeight);
			this.targetLookAt.position = this.current_cPos;
			if (this.isValidFixedPoint && this.currentState.lookPoints[this.indexLookPoint].freeRotation)
			{
				Quaternion quaternion = Quaternion.Euler(this.currentState.lookPoints[this.indexLookPoint].eulerAngle);
				base.transform.rotation = Quaternion.Lerp(this.startRotation, this.useSmooth ? Quaternion.Slerp(base.transform.rotation, quaternion, this.currentState.smooth * 0.5f * Time.fixedDeltaTime) : quaternion, this.transformWeight);
			}
			else if (this.isValidFixedPoint)
			{
				Quaternion quaternion2 = Quaternion.LookRotation(this.currentTargetPos - base.transform.position);
				base.transform.rotation = Quaternion.Lerp(this.startRotation, this.useSmooth ? Quaternion.Slerp(base.transform.rotation, quaternion2, this.currentState.smooth * Time.fixedDeltaTime) : quaternion2, this.transformWeight);
			}
			this.targetCamera.fieldOfView = this.currentState.fov;
		}

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x06001607 RID: 5639 RVA: 0x00074DB4 File Offset: 0x00072FB4
		protected virtual bool isValidFixedPoint
		{
			get
			{
				return this.currentState.lookPoints != null && this.currentState.cameraMode.Equals(TPCameraMode.FixedPoint) && (this.indexLookPoint < this.currentState.lookPoints.Count || this.currentState.lookPoints.Count > 0);
			}
		}

		// Token: 0x06001608 RID: 5640 RVA: 0x00074E1C File Offset: 0x0007301C
		protected virtual bool CullingRayCast(Vector3 from, ClipPlanePoints _to, out RaycastHit hitInfo, float distance, LayerMask cullingLayer, Color color)
		{
			bool flag = false;
			if (this.showGizmos)
			{
				Debug.DrawRay(from, _to.LowerLeft - from, color);
				Debug.DrawLine(_to.LowerLeft, _to.LowerRight, color);
				Debug.DrawLine(_to.UpperLeft, _to.UpperRight, color);
				Debug.DrawLine(_to.UpperLeft, _to.LowerLeft, color);
				Debug.DrawLine(_to.UpperRight, _to.LowerRight, color);
				Debug.DrawRay(from, _to.LowerRight - from, color);
				Debug.DrawRay(from, _to.UpperLeft - from, color);
				Debug.DrawRay(from, _to.UpperRight - from, color);
			}
			if (Physics.Raycast(from, _to.LowerLeft - from, out hitInfo, distance, cullingLayer))
			{
				flag = true;
				this.cullingDistance = hitInfo.distance;
			}
			if (Physics.Raycast(from, _to.LowerRight - from, out hitInfo, distance, cullingLayer))
			{
				flag = true;
				if (this.cullingDistance > hitInfo.distance)
				{
					this.cullingDistance = hitInfo.distance;
				}
			}
			if (Physics.Raycast(from, _to.UpperLeft - from, out hitInfo, distance, cullingLayer))
			{
				flag = true;
				if (this.cullingDistance > hitInfo.distance)
				{
					this.cullingDistance = hitInfo.distance;
				}
			}
			if (Physics.Raycast(from, _to.UpperRight - from, out hitInfo, distance, cullingLayer))
			{
				flag = true;
				if (this.cullingDistance > hitInfo.distance)
				{
					this.cullingDistance = hitInfo.distance;
				}
			}
			return hitInfo.collider && flag;
		}

		// Token: 0x04001BDD RID: 7133
		private static vThirdPersonCamera _instance;

		// Token: 0x04001BDE RID: 7134
		public Transform mainTarget;

		// Token: 0x04001BDF RID: 7135
		[Tooltip("Lerp speed between Camera States")]
		public float smoothBetweenState = 6f;

		// Token: 0x04001BE0 RID: 7136
		public float smoothCameraRotation = 6f;

		// Token: 0x04001BE1 RID: 7137
		public float smoothSwitchSide = 2f;

		// Token: 0x04001BE2 RID: 7138
		public float scrollSpeed = 10f;

		// Token: 0x04001BE3 RID: 7139
		[Tooltip("Multiplier of Mouse x and y when using joystick")]
		public float joystickSensitivity = 1f;

		// Token: 0x04001BE4 RID: 7140
		[Tooltip("What layer will be culled")]
		public LayerMask cullingLayer = 1;

		// Token: 0x04001BE5 RID: 7141
		[Tooltip("Change this value If the camera pass through the wall")]
		public float clipPlaneMargin;

		// Token: 0x04001BE6 RID: 7142
		public float checkHeightRadius;

		// Token: 0x04001BE7 RID: 7143
		public bool showGizmos;

		// Token: 0x04001BE8 RID: 7144
		public bool startUsingTargetRotation = true;

		// Token: 0x04001BE9 RID: 7145
		public bool startSmooth;

		// Token: 0x04001BEA RID: 7146
		[Tooltip("Returns to behind the target automatically after 'behindTargetDelay' period")]
		public bool autoBehindTarget;

		// Token: 0x04001BEB RID: 7147
		[vHideInInspector("autoBehindTarget", false)]
		public float behindTargetDelay = 2f;

		// Token: 0x04001BEC RID: 7148
		[vHideInInspector("autoBehindTarget", false)]
		public float behindTargetSmoothRotation = 1f;

		// Token: 0x04001BED RID: 7149
		[Tooltip("Debug purposes, lock the camera behind the character for better align the states")]
		[SerializeField]
		protected bool lockCamera;

		// Token: 0x04001BEE RID: 7150
		private WaitForEndOfFrame waitFrame = new WaitForEndOfFrame();

		// Token: 0x04001BEF RID: 7151
		public Vector2 offsetMouse;

		// Token: 0x04001BF0 RID: 7152
		[HideInInspector]
		public int indexList;

		// Token: 0x04001BF1 RID: 7153
		[HideInInspector]
		public int indexLookPoint;

		// Token: 0x04001BF2 RID: 7154
		[HideInInspector]
		public float offSetPlayerPivot;

		// Token: 0x04001BF3 RID: 7155
		[HideInInspector]
		public float distance = 5f;

		// Token: 0x04001BF4 RID: 7156
		[HideInInspector]
		public string currentStateName;

		// Token: 0x04001BF5 RID: 7157
		[HideInInspector]
		public Transform currentTarget;

		// Token: 0x04001BF6 RID: 7158
		[HideInInspector]
		public vThirdPersonCameraState currentState;

		// Token: 0x04001BF7 RID: 7159
		[HideInInspector]
		public vThirdPersonCameraListData CameraStateList;

		// Token: 0x04001BF8 RID: 7160
		[HideInInspector]
		public Transform lockTarget;

		// Token: 0x04001BF9 RID: 7161
		[HideInInspector]
		public Vector2 movementSpeed;

		// Token: 0x04001BFA RID: 7162
		[HideInInspector]
		public vThirdPersonCameraState lerpState;

		// Token: 0x04001BFB RID: 7163
		protected float lockTargetSpeed;

		// Token: 0x04001BFC RID: 7164
		protected float lockTargetWeight;

		// Token: 0x04001BFD RID: 7165
		protected float initialCameraRotation;

		// Token: 0x04001BFE RID: 7166
		protected bool cameraIsRotating;

		// Token: 0x04001BFF RID: 7167
		protected Quaternion lastCameraRotation;

		// Token: 0x04001C00 RID: 7168
		protected float lastRotationTimer;

		// Token: 0x04001C01 RID: 7169
		protected Vector3 currentTargetPos;

		// Token: 0x04001C02 RID: 7170
		protected Vector3 lookPoint;

		// Token: 0x04001C03 RID: 7171
		protected Vector3 current_cPos;

		// Token: 0x04001C04 RID: 7172
		protected Vector3 desired_cPos;

		// Token: 0x04001C05 RID: 7173
		protected Vector3 lookTargetAdjust;

		// Token: 0x04001C06 RID: 7174
		internal float mouseY;

		// Token: 0x04001C07 RID: 7175
		internal float mouseX;

		// Token: 0x04001C08 RID: 7176
		protected float currentHeight;

		// Token: 0x04001C09 RID: 7177
		protected float currentZoom;

		// Token: 0x04001C0A RID: 7178
		protected float cullingHeight;

		// Token: 0x04001C0B RID: 7179
		protected float cullingDistance;

		// Token: 0x04001C0C RID: 7180
		internal float switchRight;

		// Token: 0x04001C0D RID: 7181
		protected float currentSwitchRight;

		// Token: 0x04001C0E RID: 7182
		protected float heightOffset;

		// Token: 0x04001C0F RID: 7183
		internal bool isInit;

		// Token: 0x04001C10 RID: 7184
		protected bool useSmooth;

		// Token: 0x04001C11 RID: 7185
		protected bool isNewTarget;

		// Token: 0x04001C12 RID: 7186
		protected bool firstStateIsInit;

		// Token: 0x04001C13 RID: 7187
		protected Quaternion fixedRotation;

		// Token: 0x04001C14 RID: 7188
		internal Camera targetCamera;

		// Token: 0x04001C15 RID: 7189
		protected float transformWeight;

		// Token: 0x04001C16 RID: 7190
		protected float mouseXStart;

		// Token: 0x04001C17 RID: 7191
		protected float mouseYStart;

		// Token: 0x04001C18 RID: 7192
		protected Vector3 startPosition;

		// Token: 0x04001C19 RID: 7193
		protected Quaternion startRotation;

		// Token: 0x04001C1A RID: 7194
		private protected Vector3 cameraVelocityDamp;

		// Token: 0x04001C1B RID: 7195
		private protected bool firstUpdated;

		// Token: 0x04001C1C RID: 7196
		protected Transform _lookAtTarget;

		// Token: 0x04001C1D RID: 7197
		protected Vector3 lastLookAtPosition;

		// Token: 0x04001C1E RID: 7198
		protected Vector3 lastLookAtForward;

		// Token: 0x04001C1F RID: 7199
		public bool isFreezed;

		// Token: 0x04001C20 RID: 7200
		protected Rigidbody _selfRigidbody;
	}
}
