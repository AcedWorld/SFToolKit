using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001C1 RID: 449
	public class SimpleLocomotion : MonoBehaviour
	{
		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000C0E RID: 3086 RVA: 0x0004B197 File Offset: 0x00049397
		// (set) Token: 0x06000C0F RID: 3087 RVA: 0x0004B19F File Offset: 0x0004939F
		public bool isGrounded { get; private set; }

		// Token: 0x06000C10 RID: 3088 RVA: 0x0004B1A8 File Offset: 0x000493A8
		private void Start()
		{
			this.animator = base.GetComponent<Animator>();
			this.characterController = base.GetComponent<CharacterController>();
			this.cameraController.enabled = false;
		}

		// Token: 0x06000C11 RID: 3089 RVA: 0x0004B1CE File Offset: 0x000493CE
		private void Update()
		{
			this.isGrounded = (base.transform.position.y < 0.1f);
			this.Rotate();
			this.Move();
		}

		// Token: 0x06000C12 RID: 3090 RVA: 0x0004B1F9 File Offset: 0x000493F9
		private void LateUpdate()
		{
			this.cameraController.UpdateInput();
			this.cameraController.UpdateTransform();
		}

		// Token: 0x06000C13 RID: 3091 RVA: 0x0004B214 File Offset: 0x00049414
		private void Rotate()
		{
			if (!this.isGrounded)
			{
				return;
			}
			Vector3 inputVector = this.GetInputVector();
			if (inputVector == Vector3.zero)
			{
				return;
			}
			Vector3 vector = base.transform.forward;
			SimpleLocomotion.RotationMode rotationMode = this.rotationMode;
			if (rotationMode == SimpleLocomotion.RotationMode.Smooth)
			{
				Vector3 vector2 = this.cameraController.transform.rotation * inputVector;
				float current = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
				float target = Mathf.Atan2(vector2.x, vector2.z) * 57.29578f;
				float angle = Mathf.SmoothDampAngle(current, target, ref this.angleVel, this.turnTime);
				base.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
				return;
			}
			if (rotationMode != SimpleLocomotion.RotationMode.Linear)
			{
				return;
			}
			Vector3 inputVectorRaw = this.GetInputVectorRaw();
			if (inputVectorRaw != Vector3.zero)
			{
				this.linearTargetDirection = this.cameraController.transform.rotation * inputVectorRaw;
			}
			vector = Vector3.RotateTowards(vector, this.linearTargetDirection, Time.deltaTime * (1f / this.turnTime), 1f);
			vector.y = 0f;
			base.transform.rotation = Quaternion.LookRotation(vector);
		}

		// Token: 0x06000C14 RID: 3092 RVA: 0x0004B344 File Offset: 0x00049544
		private void Move()
		{
			float target = this.walkByDefault ? (Input.GetKey(KeyCode.LeftShift) ? 1f : 0.5f) : (Input.GetKey(KeyCode.LeftShift) ? 0.5f : 1f);
			this.speed = Mathf.SmoothDamp(this.speed, target, ref this.speedVel, this.accelerationTime);
			float num = this.GetInputVector().magnitude * this.speed;
			this.animator.SetFloat("Speed", num);
			if (!this.animator.hasRootMotion && this.isGrounded)
			{
				Vector3 a = base.transform.forward * num * this.moveSpeed;
				if (this.characterController != null)
				{
					this.characterController.SimpleMove(a);
					return;
				}
				base.transform.position += a * Time.deltaTime;
			}
		}

		// Token: 0x06000C15 RID: 3093 RVA: 0x0004B444 File Offset: 0x00049644
		private Vector3 GetInputVector()
		{
			Vector3 vector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
			vector.z += Mathf.Abs(vector.x) * 0.05f;
			vector.x -= Mathf.Abs(vector.z) * 0.05f;
			return vector;
		}

		// Token: 0x06000C16 RID: 3094 RVA: 0x0004259E File Offset: 0x0004079E
		private Vector3 GetInputVectorRaw()
		{
			return new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
		}

		// Token: 0x04000C62 RID: 3170
		[Tooltip("The component that updates the camera.")]
		public CameraController cameraController;

		// Token: 0x04000C63 RID: 3171
		[Tooltip("Acceleration of movement.")]
		public float accelerationTime = 0.2f;

		// Token: 0x04000C64 RID: 3172
		[Tooltip("Turning speed.")]
		public float turnTime = 0.2f;

		// Token: 0x04000C65 RID: 3173
		[Tooltip("If true, will run on left shift, if not will walk on left shift.")]
		public bool walkByDefault = true;

		// Token: 0x04000C66 RID: 3174
		[Tooltip("Smooth or linear rotation.")]
		public SimpleLocomotion.RotationMode rotationMode;

		// Token: 0x04000C67 RID: 3175
		[Tooltip("Procedural motion speed (if not using root motion).")]
		public float moveSpeed = 3f;

		// Token: 0x04000C69 RID: 3177
		private Animator animator;

		// Token: 0x04000C6A RID: 3178
		private float speed;

		// Token: 0x04000C6B RID: 3179
		private float angleVel;

		// Token: 0x04000C6C RID: 3180
		private float speedVel;

		// Token: 0x04000C6D RID: 3181
		private Vector3 linearTargetDirection;

		// Token: 0x04000C6E RID: 3182
		private CharacterController characterController;

		// Token: 0x020001C2 RID: 450
		[Serializable]
		public enum RotationMode
		{
			// Token: 0x04000C70 RID: 3184
			Smooth,
			// Token: 0x04000C71 RID: 3185
			Linear
		}
	}
}
