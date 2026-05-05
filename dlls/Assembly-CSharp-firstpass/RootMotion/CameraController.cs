using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x02000016 RID: 22
	public class CameraController : MonoBehaviour
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00004348 File Offset: 0x00002548
		// (set) Token: 0x06000066 RID: 102 RVA: 0x00004350 File Offset: 0x00002550
		public float x { get; private set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00004359 File Offset: 0x00002559
		// (set) Token: 0x06000068 RID: 104 RVA: 0x00004361 File Offset: 0x00002561
		public float y { get; private set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000069 RID: 105 RVA: 0x0000436A File Offset: 0x0000256A
		// (set) Token: 0x0600006A RID: 106 RVA: 0x00004372 File Offset: 0x00002572
		public float distanceTarget { get; private set; }

		// Token: 0x0600006B RID: 107 RVA: 0x0000437C File Offset: 0x0000257C
		public void SetAngles(Quaternion rotation)
		{
			Vector3 eulerAngles = rotation.eulerAngles;
			this.x = eulerAngles.y;
			this.y = eulerAngles.x;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000043A9 File Offset: 0x000025A9
		public void SetAngles(float yaw, float pitch)
		{
			this.x = yaw;
			this.y = pitch;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000043BC File Offset: 0x000025BC
		protected virtual void Awake()
		{
			Vector3 eulerAngles = base.transform.eulerAngles;
			this.x = eulerAngles.y;
			this.y = eulerAngles.x;
			this.distanceTarget = this.distance;
			this.smoothPosition = base.transform.position;
			this.cam = base.GetComponent<Camera>();
			this.lastUp = ((this.rotationSpace != null) ? this.rotationSpace.up : Vector3.up);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000443C File Offset: 0x0000263C
		protected virtual void Update()
		{
			if (this.updateMode == CameraController.UpdateMode.Update)
			{
				this.UpdateTransform();
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000444C File Offset: 0x0000264C
		protected virtual void FixedUpdate()
		{
			this.fixedFrame = true;
			this.fixedDeltaTime += Time.deltaTime;
			if (this.updateMode == CameraController.UpdateMode.FixedUpdate)
			{
				this.UpdateTransform();
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00004478 File Offset: 0x00002678
		protected virtual void LateUpdate()
		{
			this.UpdateInput();
			if (this.updateMode == CameraController.UpdateMode.LateUpdate)
			{
				this.UpdateTransform();
			}
			if (this.updateMode == CameraController.UpdateMode.FixedLateUpdate && this.fixedFrame)
			{
				this.UpdateTransform(this.fixedDeltaTime);
				this.fixedDeltaTime = 0f;
				this.fixedFrame = false;
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000044CC File Offset: 0x000026CC
		public void UpdateInput()
		{
			if (!this.cam.enabled)
			{
				return;
			}
			Cursor.lockState = (this.lockCursor ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !this.lockCursor;
			if (this.rotateAlways || (this.rotateOnLeftButton && Input.GetMouseButton(0)) || (this.rotateOnRightButton && Input.GetMouseButton(1)) || (this.rotateOnMiddleButton && Input.GetMouseButton(2)))
			{
				this.x += Input.GetAxis("Mouse X") * this.rotationSensitivity;
				this.y = this.ClampAngle(this.y - Input.GetAxis("Mouse Y") * this.rotationSensitivity, this.yMinLimit, this.yMaxLimit);
			}
			this.distanceTarget = Mathf.Clamp(this.distanceTarget + this.zoomAdd, this.minDistance, this.maxDistance);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000045B9 File Offset: 0x000027B9
		public void UpdateTransform()
		{
			this.UpdateTransform(Time.deltaTime);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000045C8 File Offset: 0x000027C8
		public void UpdateTransform(float deltaTime)
		{
			if (!this.cam.enabled)
			{
				return;
			}
			this.rotation = Quaternion.AngleAxis(this.x, Vector3.up) * Quaternion.AngleAxis(this.y, Vector3.right);
			if (this.rotationSpace != null)
			{
				this.r = Quaternion.FromToRotation(this.lastUp, this.rotationSpace.up) * this.r;
				this.rotation = this.r * this.rotation;
				this.lastUp = this.rotationSpace.up;
			}
			if (this.target != null)
			{
				this.distance += (this.distanceTarget - this.distance) * this.zoomSpeed * deltaTime;
				if (!this.smoothFollow)
				{
					this.smoothPosition = this.target.position;
				}
				else
				{
					this.smoothPosition = Vector3.Lerp(this.smoothPosition, this.target.position, deltaTime * this.followSpeed);
				}
				Vector3 a = this.smoothPosition + this.rotation * this.offset;
				Vector3 vector = this.rotation * -Vector3.forward;
				if (this.blockingLayers != -1)
				{
					RaycastHit raycastHit;
					if (Physics.SphereCast(a - vector * this.blockingOriginOffset, this.blockingRadius, vector, out raycastHit, this.blockingOriginOffset + this.distanceTarget - this.blockingRadius, this.blockingLayers))
					{
						this.blockedDistance = Mathf.SmoothDamp(this.blockedDistance, raycastHit.distance + this.blockingRadius * (1f - this.blockedOffset) - this.blockingOriginOffset, ref this.blockedDistanceV, this.blockingSmoothTime);
					}
					else
					{
						this.blockedDistance = this.distanceTarget;
					}
					this.distance = Mathf.Min(this.distance, this.blockedDistance);
				}
				this.position = a + vector * this.distance;
				base.transform.position = this.position;
			}
			base.transform.rotation = this.rotation;
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00004804 File Offset: 0x00002A04
		private float zoomAdd
		{
			get
			{
				float axis = Input.GetAxis("Mouse ScrollWheel");
				if (axis > 0f)
				{
					return -this.zoomSensitivity;
				}
				if (axis < 0f)
				{
					return this.zoomSensitivity;
				}
				return 0f;
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00004840 File Offset: 0x00002A40
		private float ClampAngle(float angle, float min, float max)
		{
			if (angle < -360f)
			{
				angle += 360f;
			}
			if (angle > 360f)
			{
				angle -= 360f;
			}
			return Mathf.Clamp(angle, min, max);
		}

		// Token: 0x0400007A RID: 122
		public Transform target;

		// Token: 0x0400007B RID: 123
		public Transform rotationSpace;

		// Token: 0x0400007C RID: 124
		public CameraController.UpdateMode updateMode = CameraController.UpdateMode.LateUpdate;

		// Token: 0x0400007D RID: 125
		public bool lockCursor = true;

		// Token: 0x0400007E RID: 126
		[Header("Position")]
		public bool smoothFollow;

		// Token: 0x0400007F RID: 127
		public Vector3 offset = new Vector3(0f, 1.5f, 0.5f);

		// Token: 0x04000080 RID: 128
		public float followSpeed = 10f;

		// Token: 0x04000081 RID: 129
		[Header("Rotation")]
		public float rotationSensitivity = 3.5f;

		// Token: 0x04000082 RID: 130
		public float yMinLimit = -20f;

		// Token: 0x04000083 RID: 131
		public float yMaxLimit = 80f;

		// Token: 0x04000084 RID: 132
		public bool rotateAlways = true;

		// Token: 0x04000085 RID: 133
		public bool rotateOnLeftButton;

		// Token: 0x04000086 RID: 134
		public bool rotateOnRightButton;

		// Token: 0x04000087 RID: 135
		public bool rotateOnMiddleButton;

		// Token: 0x04000088 RID: 136
		[Header("Distance")]
		public float distance = 10f;

		// Token: 0x04000089 RID: 137
		public float minDistance = 4f;

		// Token: 0x0400008A RID: 138
		public float maxDistance = 10f;

		// Token: 0x0400008B RID: 139
		public float zoomSpeed = 10f;

		// Token: 0x0400008C RID: 140
		public float zoomSensitivity = 1f;

		// Token: 0x0400008D RID: 141
		[Header("Blocking")]
		public LayerMask blockingLayers;

		// Token: 0x0400008E RID: 142
		public float blockingRadius = 1f;

		// Token: 0x0400008F RID: 143
		public float blockingSmoothTime = 0.1f;

		// Token: 0x04000090 RID: 144
		public float blockingOriginOffset;

		// Token: 0x04000091 RID: 145
		[Range(0f, 1f)]
		public float blockedOffset = 0.5f;

		// Token: 0x04000095 RID: 149
		private Vector3 targetDistance;

		// Token: 0x04000096 RID: 150
		private Vector3 position;

		// Token: 0x04000097 RID: 151
		private Quaternion rotation = Quaternion.identity;

		// Token: 0x04000098 RID: 152
		private Vector3 smoothPosition;

		// Token: 0x04000099 RID: 153
		private Camera cam;

		// Token: 0x0400009A RID: 154
		private bool fixedFrame;

		// Token: 0x0400009B RID: 155
		private float fixedDeltaTime;

		// Token: 0x0400009C RID: 156
		private Quaternion r = Quaternion.identity;

		// Token: 0x0400009D RID: 157
		private Vector3 lastUp;

		// Token: 0x0400009E RID: 158
		private float blockedDistance = 10f;

		// Token: 0x0400009F RID: 159
		private float blockedDistanceV;

		// Token: 0x02000017 RID: 23
		[Serializable]
		public enum UpdateMode
		{
			// Token: 0x040000A1 RID: 161
			Update,
			// Token: 0x040000A2 RID: 162
			FixedUpdate,
			// Token: 0x040000A3 RID: 163
			LateUpdate,
			// Token: 0x040000A4 RID: 164
			FixedLateUpdate
		}
	}
}
