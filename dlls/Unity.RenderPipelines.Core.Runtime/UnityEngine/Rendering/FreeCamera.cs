using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000033 RID: 51
	public class FreeCamera : MonoBehaviour
	{
		// Token: 0x060001F5 RID: 501 RVA: 0x00009EFA File Offset: 0x000080FA
		private void OnEnable()
		{
			this.RegisterInputs();
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00009F02 File Offset: 0x00008102
		private void RegisterInputs()
		{
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00009F04 File Offset: 0x00008104
		private void UpdateInputs()
		{
			this.inputRotateAxisX = 0f;
			this.inputRotateAxisY = 0f;
			this.leftShiftBoost = false;
			this.fire1 = false;
			if (Input.GetMouseButton(1))
			{
				this.leftShiftBoost = true;
				this.inputRotateAxisX = Input.GetAxis(FreeCamera.kMouseX) * this.m_LookSpeedMouse;
				this.inputRotateAxisY = Input.GetAxis(FreeCamera.kMouseY) * this.m_LookSpeedMouse;
			}
			this.inputRotateAxisX += Input.GetAxis(FreeCamera.kRightStickX) * this.m_LookSpeedController * 0.01f;
			this.inputRotateAxisY += Input.GetAxis(FreeCamera.kRightStickY) * this.m_LookSpeedController * 0.01f;
			this.leftShift = Input.GetKey(KeyCode.LeftShift);
			this.fire1 = (Input.GetAxis("Fire1") > 0f);
			this.inputChangeSpeed = Input.GetAxis(FreeCamera.kSpeedAxis);
			this.inputVertical = Input.GetAxis(FreeCamera.kVertical);
			this.inputHorizontal = Input.GetAxis(FreeCamera.kHorizontal);
			this.inputYAxis = Input.GetAxis(FreeCamera.kYAxis);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000A024 File Offset: 0x00008224
		private void Update()
		{
			if (DebugManager.instance.displayRuntimeUI)
			{
				return;
			}
			this.UpdateInputs();
			if (this.inputChangeSpeed != 0f)
			{
				this.m_MoveSpeed += this.inputChangeSpeed * this.m_MoveSpeedIncrement;
				if (this.m_MoveSpeed < this.m_MoveSpeedIncrement)
				{
					this.m_MoveSpeed = this.m_MoveSpeedIncrement;
				}
			}
			if (this.inputRotateAxisX != 0f || this.inputRotateAxisY != 0f || this.inputVertical != 0f || this.inputHorizontal != 0f || this.inputYAxis != 0f)
			{
				float x = base.transform.localEulerAngles.x;
				float y = base.transform.localEulerAngles.y + this.inputRotateAxisX;
				float num = x - this.inputRotateAxisY;
				if (x <= 90f && num >= 0f)
				{
					num = Mathf.Clamp(num, 0f, 90f);
				}
				if (x >= 270f)
				{
					num = Mathf.Clamp(num, 270f, 360f);
				}
				base.transform.localRotation = Quaternion.Euler(num, y, base.transform.localEulerAngles.z);
				float num2 = Time.deltaTime * this.m_MoveSpeed;
				if (this.fire1 || (this.leftShiftBoost && this.leftShift))
				{
					num2 *= this.m_Turbo;
				}
				base.transform.position += base.transform.forward * num2 * this.inputVertical;
				base.transform.position += base.transform.right * num2 * this.inputHorizontal;
				base.transform.position += Vector3.up * num2 * this.inputYAxis;
			}
		}

		// Token: 0x04000120 RID: 288
		private const float k_MouseSensitivityMultiplier = 0.01f;

		// Token: 0x04000121 RID: 289
		public float m_LookSpeedController = 120f;

		// Token: 0x04000122 RID: 290
		public float m_LookSpeedMouse = 4f;

		// Token: 0x04000123 RID: 291
		public float m_MoveSpeed = 10f;

		// Token: 0x04000124 RID: 292
		public float m_MoveSpeedIncrement = 2.5f;

		// Token: 0x04000125 RID: 293
		public float m_Turbo = 10f;

		// Token: 0x04000126 RID: 294
		private static string kMouseX = "Mouse X";

		// Token: 0x04000127 RID: 295
		private static string kMouseY = "Mouse Y";

		// Token: 0x04000128 RID: 296
		private static string kRightStickX = "Controller Right Stick X";

		// Token: 0x04000129 RID: 297
		private static string kRightStickY = "Controller Right Stick Y";

		// Token: 0x0400012A RID: 298
		private static string kVertical = "Vertical";

		// Token: 0x0400012B RID: 299
		private static string kHorizontal = "Horizontal";

		// Token: 0x0400012C RID: 300
		private static string kYAxis = "YAxis";

		// Token: 0x0400012D RID: 301
		private static string kSpeedAxis = "Speed Axis";

		// Token: 0x0400012E RID: 302
		private float inputRotateAxisX;

		// Token: 0x0400012F RID: 303
		private float inputRotateAxisY;

		// Token: 0x04000130 RID: 304
		private float inputChangeSpeed;

		// Token: 0x04000131 RID: 305
		private float inputVertical;

		// Token: 0x04000132 RID: 306
		private float inputHorizontal;

		// Token: 0x04000133 RID: 307
		private float inputYAxis;

		// Token: 0x04000134 RID: 308
		private bool leftShiftBoost;

		// Token: 0x04000135 RID: 309
		private bool leftShift;

		// Token: 0x04000136 RID: 310
		private bool fire1;
	}
}
