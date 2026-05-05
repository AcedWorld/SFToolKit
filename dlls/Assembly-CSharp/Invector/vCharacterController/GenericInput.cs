using System;
using UnityEngine;

namespace Invector.vCharacterController
{
	// Token: 0x020003E9 RID: 1001
	[Serializable]
	public class GenericInput
	{
		// Token: 0x17000385 RID: 901
		// (get) Token: 0x060013DF RID: 5087 RVA: 0x00066E9F File Offset: 0x0006509F
		protected InputDevice inputDevice
		{
			get
			{
				return vInput.instance.inputDevice;
			}
		}

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x060013E0 RID: 5088 RVA: 0x00066EAC File Offset: 0x000650AC
		public bool isAxis
		{
			get
			{
				bool result = false;
				switch (this.inputDevice)
				{
				case InputDevice.MouseKeyboard:
					result = this.keyboardAxis;
					break;
				case InputDevice.Joystick:
					result = this.joystickAxis;
					break;
				case InputDevice.Mobile:
					result = this.mobileAxis;
					break;
				}
				return result;
			}
		}

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x060013E1 RID: 5089 RVA: 0x00066EF0 File Offset: 0x000650F0
		public bool isAxisInvert
		{
			get
			{
				bool result = false;
				switch (this.inputDevice)
				{
				case InputDevice.MouseKeyboard:
					result = this.keyboardAxisInvert;
					break;
				case InputDevice.Joystick:
					result = this.joystickAxisInvert;
					break;
				case InputDevice.Mobile:
					result = this.mobileAxisInvert;
					break;
				}
				return result;
			}
		}

		// Token: 0x060013E2 RID: 5090 RVA: 0x00066F34 File Offset: 0x00065134
		public GenericInput(string keyboard, string joystick, string mobile)
		{
			this.keyboard = keyboard;
			this.joystick = joystick;
			this.mobile = mobile;
		}

		// Token: 0x060013E3 RID: 5091 RVA: 0x00066F58 File Offset: 0x00065158
		public GenericInput(string keyboard, bool keyboardAxis, string joystick, bool joystickAxis, string mobile, bool mobileAxis)
		{
			this.keyboard = keyboard;
			this.keyboardAxis = keyboardAxis;
			this.joystick = joystick;
			this.joystickAxis = joystickAxis;
			this.mobile = mobile;
			this.mobileAxis = mobileAxis;
		}

		// Token: 0x060013E4 RID: 5092 RVA: 0x00066F94 File Offset: 0x00065194
		public GenericInput(string keyboard, bool keyboardAxis, bool keyboardInvert, string joystick, bool joystickAxis, bool joystickInvert, string mobile, bool mobileAxis, bool mobileInvert)
		{
			this.keyboard = keyboard;
			this.keyboardAxis = keyboardAxis;
			this.keyboardAxisInvert = keyboardInvert;
			this.joystick = joystick;
			this.joystickAxis = joystickAxis;
			this.joystickAxisInvert = joystickInvert;
			this.mobile = mobile;
			this.mobileAxis = mobileAxis;
			this.mobileAxisInvert = mobileInvert;
		}

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x060013E5 RID: 5093 RVA: 0x00066FF4 File Offset: 0x000651F4
		public string buttonName
		{
			get
			{
				if (!(vInput.instance != null))
				{
					return string.Empty;
				}
				if (vInput.instance.inputDevice == InputDevice.MouseKeyboard)
				{
					return this.keyboard.ToString();
				}
				if (vInput.instance.inputDevice == InputDevice.Joystick)
				{
					return this.joystick;
				}
				return this.mobile;
			}
		}

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x060013E6 RID: 5094 RVA: 0x00067046 File Offset: 0x00065246
		public bool isKey
		{
			get
			{
				return vInput.instance != null && !this.isUnityInput && Enum.IsDefined(typeof(KeyCode), this.buttonName);
			}
		}

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x060013E7 RID: 5095 RVA: 0x00067077 File Offset: 0x00065277
		public KeyCode key
		{
			get
			{
				return (KeyCode)Enum.Parse(typeof(KeyCode), this.buttonName);
			}
		}

		// Token: 0x060013E8 RID: 5096 RVA: 0x00067094 File Offset: 0x00065294
		public bool GetButton()
		{
			if (string.IsNullOrEmpty(this.buttonName) || !this.IsButtonAvailable(this.buttonName))
			{
				return false;
			}
			if (this.isAxis)
			{
				return this.GetAxisButton(0.5f);
			}
			if (this.inputDevice == InputDevice.Mobile)
			{
				return true;
			}
			if (this.inputDevice == InputDevice.MouseKeyboard)
			{
				if (this.isKey)
				{
					if (Input.GetKey(this.key))
					{
						return true;
					}
				}
				else if (Input.GetButton(this.buttonName))
				{
					return true;
				}
			}
			else if (this.inputDevice == InputDevice.Joystick && Input.GetButton(this.buttonName))
			{
				return true;
			}
			return false;
		}

		// Token: 0x060013E9 RID: 5097 RVA: 0x00067124 File Offset: 0x00065324
		public bool GetButtonDown()
		{
			if (string.IsNullOrEmpty(this.buttonName) || !this.IsButtonAvailable(this.buttonName))
			{
				return false;
			}
			if (this.isAxis)
			{
				return this.GetAxisButtonDown(0.5f);
			}
			if (this.inputDevice == InputDevice.Mobile)
			{
				return true;
			}
			if (this.inputDevice == InputDevice.MouseKeyboard)
			{
				if (this.isKey)
				{
					if (Input.GetKeyDown(this.key))
					{
						return true;
					}
				}
				else if (Input.GetButtonDown(this.buttonName))
				{
					return true;
				}
			}
			else if (this.inputDevice == InputDevice.Joystick && Input.GetButtonDown(this.buttonName))
			{
				return true;
			}
			return false;
		}

		// Token: 0x060013EA RID: 5098 RVA: 0x000671B4 File Offset: 0x000653B4
		public bool GetButtonUp()
		{
			if (string.IsNullOrEmpty(this.buttonName) || !this.IsButtonAvailable(this.buttonName))
			{
				return false;
			}
			if (this.isAxis)
			{
				return this.GetAxisButtonUp();
			}
			if (this.inputDevice == InputDevice.Mobile)
			{
				return true;
			}
			if (this.inputDevice == InputDevice.MouseKeyboard)
			{
				if (this.isKey)
				{
					if (Input.GetKeyUp(this.key))
					{
						return true;
					}
				}
				else if (Input.GetButtonUp(this.buttonName))
				{
					return true;
				}
			}
			else if (this.inputDevice == InputDevice.Joystick && Input.GetButtonUp(this.buttonName))
			{
				return true;
			}
			return false;
		}

		// Token: 0x060013EB RID: 5099 RVA: 0x00067240 File Offset: 0x00065440
		public float GetAxis()
		{
			if (string.IsNullOrEmpty(this.buttonName) || !this.IsButtonAvailable(this.buttonName) || this.isKey)
			{
				return 0f;
			}
			if (this.inputDevice != InputDevice.Mobile)
			{
				if (this.inputDevice == InputDevice.MouseKeyboard)
				{
					return Input.GetAxis(this.buttonName);
				}
				if (this.inputDevice == InputDevice.Joystick)
				{
					return Input.GetAxis(this.buttonName);
				}
			}
			return 0f;
		}

		// Token: 0x060013EC RID: 5100 RVA: 0x000672B0 File Offset: 0x000654B0
		public float GetAxisRaw()
		{
			if (string.IsNullOrEmpty(this.buttonName) || !this.IsButtonAvailable(this.buttonName) || this.isKey)
			{
				return 0f;
			}
			if (this.inputDevice != InputDevice.Mobile)
			{
				if (this.inputDevice == InputDevice.MouseKeyboard)
				{
					return Input.GetAxisRaw(this.buttonName);
				}
				if (this.inputDevice == InputDevice.Joystick)
				{
					return Input.GetAxisRaw(this.buttonName);
				}
			}
			return 0f;
		}

		// Token: 0x060013ED RID: 5101 RVA: 0x00067320 File Offset: 0x00065520
		public bool GetDoubleButtonDown(float inputTime = 1f)
		{
			if (string.IsNullOrEmpty(this.buttonName) || !this.IsButtonAvailable(this.buttonName))
			{
				return false;
			}
			if (this.multTapCounter == 0 && this.GetButtonDown())
			{
				this.multTapTimer = Time.time;
				this.multTapCounter = 1;
				return false;
			}
			if (this.multTapCounter == 1 && this.GetButtonDown())
			{
				float num = this.multTapTimer + inputTime;
				bool result = Time.time < num;
				this.multTapTimer = 0f;
				this.multTapCounter = 0;
				return result;
			}
			if (this.multTapCounter == 1 && this.multTapTimer + inputTime < Time.time)
			{
				this.multTapTimer = 0f;
				this.multTapCounter = 0;
			}
			return false;
		}

		// Token: 0x060013EE RID: 5102 RVA: 0x000673D0 File Offset: 0x000655D0
		public bool GetButtonTimer(float inputTime = 2f)
		{
			if (string.IsNullOrEmpty(this.buttonName) || !this.IsButtonAvailable(this.buttonName))
			{
				return false;
			}
			if (this.GetButtonDown() && !this.inButtomTimer)
			{
				this.lastTimeTheButtonWasPressed = Time.time + 0.1f;
				this.timeButtonWasPressed = Time.time;
				this.inButtomTimer = true;
			}
			if (!this.inButtomTimer)
			{
				return false;
			}
			bool flag = this.timeButtonWasPressed + inputTime - Time.time <= 0f;
			if (!this.GetButton() || this.lastTimeTheButtonWasPressed < Time.time)
			{
				this.inButtomTimer = false;
				return false;
			}
			this.lastTimeTheButtonWasPressed = Time.time + 0.1f;
			if (flag)
			{
				this.inButtomTimer = false;
			}
			return flag;
		}

		// Token: 0x060013EF RID: 5103 RVA: 0x0006748C File Offset: 0x0006568C
		public bool GetButtonTimer(ref float currentTimer, float inputTime = 2f)
		{
			if (string.IsNullOrEmpty(this.buttonName) || !this.IsButtonAvailable(this.buttonName))
			{
				return false;
			}
			if (this.GetButtonDown() && !this.inButtomTimer)
			{
				this.lastTimeTheButtonWasPressed = Time.time + 0.1f;
				this.timeButtonWasPressed = Time.time;
				this.inButtomTimer = true;
			}
			if (!this.inButtomTimer)
			{
				return false;
			}
			float num = this.timeButtonWasPressed + inputTime;
			currentTimer = num - Time.time;
			bool flag = num - Time.time <= 0f;
			if (!this.GetButton() || this.lastTimeTheButtonWasPressed < Time.time)
			{
				this.inButtomTimer = false;
				return false;
			}
			this.lastTimeTheButtonWasPressed = Time.time + 0.1f;
			if (flag)
			{
				this.inButtomTimer = false;
			}
			return flag;
		}

		// Token: 0x060013F0 RID: 5104 RVA: 0x00067554 File Offset: 0x00065754
		public bool GetButtonTimer(ref float currentTimer, ref bool upAfterPressed, float inputTime = 2f)
		{
			if (string.IsNullOrEmpty(this.buttonName) || !this.IsButtonAvailable(this.buttonName))
			{
				return false;
			}
			if (this.GetButtonDown())
			{
				this.lastTimeTheButtonWasPressed = Time.time + 0.1f;
				this.timeButtonWasPressed = Time.time;
				this.inButtomTimer = true;
			}
			if (!this.inButtomTimer)
			{
				return false;
			}
			float num = this.timeButtonWasPressed + inputTime;
			currentTimer = (inputTime - (num - Time.time)) / inputTime;
			bool flag = num - Time.time <= 0f;
			if (!this.GetButton() || this.lastTimeTheButtonWasPressed < Time.time)
			{
				this.inButtomTimer = false;
				upAfterPressed = true;
				return false;
			}
			upAfterPressed = false;
			this.lastTimeTheButtonWasPressed = Time.time + 0.1f;
			if (flag)
			{
				this.inButtomTimer = false;
			}
			return flag;
		}

		// Token: 0x060013F1 RID: 5105 RVA: 0x0006761C File Offset: 0x0006581C
		public bool GetAxisButton(float value = 0.5f)
		{
			if (string.IsNullOrEmpty(this.buttonName) || !this.IsButtonAvailable(this.buttonName))
			{
				return false;
			}
			if (this.isAxisInvert)
			{
				value *= -1f;
			}
			if (value > 0f)
			{
				return this.GetAxisRaw() >= value;
			}
			return value < 0f && this.GetAxisRaw() <= value;
		}

		// Token: 0x060013F2 RID: 5106 RVA: 0x00067684 File Offset: 0x00065884
		public bool GetAxisButtonDown(float value = 0.5f)
		{
			if (string.IsNullOrEmpty(this.buttonName) || !this.IsButtonAvailable(this.buttonName))
			{
				return false;
			}
			if (this.isAxisInvert)
			{
				value *= -1f;
			}
			if (value > 0f)
			{
				if (!this.isAxisInUse && this.GetAxisRaw() >= value)
				{
					this.isAxisInUse = true;
					return true;
				}
				if (this.isAxisInUse && this.GetAxisRaw() == 0f)
				{
					this.isAxisInUse = false;
				}
			}
			else if (value < 0f)
			{
				if (!this.isAxisInUse && this.GetAxisRaw() <= value)
				{
					this.isAxisInUse = true;
					return true;
				}
				if (this.isAxisInUse && this.GetAxisRaw() == 0f)
				{
					this.isAxisInUse = false;
				}
			}
			return false;
		}

		// Token: 0x060013F3 RID: 5107 RVA: 0x00067740 File Offset: 0x00065940
		public bool GetAxisButtonUp()
		{
			if (string.IsNullOrEmpty(this.buttonName) || !this.IsButtonAvailable(this.buttonName))
			{
				return false;
			}
			if (this.isAxisInUse && this.GetAxisRaw() == 0f)
			{
				this.isAxisInUse = false;
				return true;
			}
			if (!this.isAxisInUse && this.GetAxisRaw() != 0f)
			{
				this.isAxisInUse = true;
			}
			return false;
		}

		// Token: 0x060013F4 RID: 5108 RVA: 0x000677A8 File Offset: 0x000659A8
		private bool IsButtonAvailable(string btnName)
		{
			if (!this.useInput)
			{
				return false;
			}
			bool result;
			try
			{
				if (this.isKey)
				{
					result = true;
				}
				else
				{
					Input.GetButton(this.buttonName);
					result = true;
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning(" Failure to try access button :" + this.buttonName + "\n" + ex.Message);
				result = false;
			}
			return result;
		}

		// Token: 0x0400197C RID: 6524
		public bool useInput = true;

		// Token: 0x0400197D RID: 6525
		[SerializeField]
		private bool isAxisInUse;

		// Token: 0x0400197E RID: 6526
		[SerializeField]
		private bool isUnityInput;

		// Token: 0x0400197F RID: 6527
		[SerializeField]
		public string keyboard;

		// Token: 0x04001980 RID: 6528
		[SerializeField]
		public bool keyboardAxis;

		// Token: 0x04001981 RID: 6529
		[SerializeField]
		public string joystick;

		// Token: 0x04001982 RID: 6530
		[SerializeField]
		public bool joystickAxis;

		// Token: 0x04001983 RID: 6531
		[SerializeField]
		public string mobile;

		// Token: 0x04001984 RID: 6532
		[SerializeField]
		public bool mobileAxis;

		// Token: 0x04001985 RID: 6533
		[SerializeField]
		public bool joystickAxisInvert;

		// Token: 0x04001986 RID: 6534
		[SerializeField]
		public bool keyboardAxisInvert;

		// Token: 0x04001987 RID: 6535
		[SerializeField]
		public bool mobileAxisInvert;

		// Token: 0x04001988 RID: 6536
		public float timeButtonWasPressed;

		// Token: 0x04001989 RID: 6537
		public float lastTimeTheButtonWasPressed;

		// Token: 0x0400198A RID: 6538
		public bool inButtomTimer;

		// Token: 0x0400198B RID: 6539
		private float multTapTimer;

		// Token: 0x0400198C RID: 6540
		private int multTapCounter;
	}
}
