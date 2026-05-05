using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x02000018 RID: 24
	public class CameraControllerFPS : MonoBehaviour
	{
		// Token: 0x06000077 RID: 119 RVA: 0x00004954 File Offset: 0x00002B54
		private void Awake()
		{
			Vector3 eulerAngles = base.transform.eulerAngles;
			this.x = eulerAngles.y;
			this.y = eulerAngles.x;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00004988 File Offset: 0x00002B88
		public void LateUpdate()
		{
			Cursor.lockState = CursorLockMode.Locked;
			this.x += Input.GetAxis("Mouse X") * this.rotationSensitivity;
			this.y = this.ClampAngle(this.y - Input.GetAxis("Mouse Y") * this.rotationSensitivity, this.yMinLimit, this.yMaxLimit);
			base.transform.rotation = Quaternion.AngleAxis(this.x, Vector3.up) * Quaternion.AngleAxis(this.y, Vector3.right);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00004840 File Offset: 0x00002A40
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

		// Token: 0x040000A5 RID: 165
		public float rotationSensitivity = 3f;

		// Token: 0x040000A6 RID: 166
		public float yMinLimit = -89f;

		// Token: 0x040000A7 RID: 167
		public float yMaxLimit = 89f;

		// Token: 0x040000A8 RID: 168
		private float x;

		// Token: 0x040000A9 RID: 169
		private float y;
	}
}
