using System;
using UnityEngine;

namespace Rewired.Demos
{
	// Token: 0x020002AF RID: 687
	[AddComponentMenu("")]
	public class CustomControllerDemo : MonoBehaviour
	{
		// Token: 0x06000E73 RID: 3699 RVA: 0x0004DD14 File Offset: 0x0004BF14
		private void Awake()
		{
			ScreenOrientation screenOrientation = ScreenOrientation.LandscapeLeft;
			if (SystemInfo.deviceType == DeviceType.Handheld && Screen.orientation != screenOrientation)
			{
				Screen.orientation = screenOrientation;
			}
			this.Initialize();
		}

		// Token: 0x06000E74 RID: 3700 RVA: 0x0004DD40 File Offset: 0x0004BF40
		private void Initialize()
		{
			ReInput.InputSourceUpdateEvent += this.OnInputSourceUpdate;
			this.joysticks = base.GetComponentsInChildren<TouchJoystickExample>();
			this.buttons = base.GetComponentsInChildren<TouchButtonExample>();
			this.axisCount = this.joysticks.Length * 2;
			this.buttonCount = this.buttons.Length;
			this.axisValues = new float[this.axisCount];
			this.buttonValues = new bool[this.buttonCount];
			Player player = ReInput.players.GetPlayer(this.playerId);
			this.controller = player.controllers.GetControllerWithTag<CustomController>(this.controllerTag);
			if (this.controller == null)
			{
				Debug.LogError("A matching controller was not found for tag \"" + this.controllerTag + "\"");
			}
			if (this.controller.buttonCount != this.buttonValues.Length || this.controller.axisCount != this.axisValues.Length)
			{
				Debug.LogError("Controller has wrong number of elements!");
			}
			if (this.useUpdateCallbacks && this.controller != null)
			{
				this.controller.SetAxisUpdateCallback(new Func<int, float>(this.GetAxisValueCallback));
				this.controller.SetButtonUpdateCallback(new Func<int, bool>(this.GetButtonValueCallback));
			}
			this.initialized = true;
		}

		// Token: 0x06000E75 RID: 3701 RVA: 0x0004DE79 File Offset: 0x0004C079
		private void Update()
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (!this.initialized)
			{
				this.Initialize();
			}
		}

		// Token: 0x06000E76 RID: 3702 RVA: 0x0004DE91 File Offset: 0x0004C091
		private void OnInputSourceUpdate()
		{
			this.GetSourceAxisValues();
			this.GetSourceButtonValues();
			if (!this.useUpdateCallbacks)
			{
				this.SetControllerAxisValues();
				this.SetControllerButtonValues();
			}
		}

		// Token: 0x06000E77 RID: 3703 RVA: 0x0004DEB4 File Offset: 0x0004C0B4
		private void GetSourceAxisValues()
		{
			for (int i = 0; i < this.axisValues.Length; i++)
			{
				if (i % 2 != 0)
				{
					this.axisValues[i] = this.joysticks[i / 2].position.y;
				}
				else
				{
					this.axisValues[i] = this.joysticks[i / 2].position.x;
				}
			}
		}

		// Token: 0x06000E78 RID: 3704 RVA: 0x0004DF14 File Offset: 0x0004C114
		private void GetSourceButtonValues()
		{
			for (int i = 0; i < this.buttonValues.Length; i++)
			{
				this.buttonValues[i] = this.buttons[i].isPressed;
			}
		}

		// Token: 0x06000E79 RID: 3705 RVA: 0x0004DF4C File Offset: 0x0004C14C
		private void SetControllerAxisValues()
		{
			for (int i = 0; i < this.axisValues.Length; i++)
			{
				this.controller.SetAxisValue(i, this.axisValues[i]);
			}
		}

		// Token: 0x06000E7A RID: 3706 RVA: 0x0004DF80 File Offset: 0x0004C180
		private void SetControllerButtonValues()
		{
			for (int i = 0; i < this.buttonValues.Length; i++)
			{
				this.controller.SetButtonValue(i, this.buttonValues[i]);
			}
		}

		// Token: 0x06000E7B RID: 3707 RVA: 0x0004DFB4 File Offset: 0x0004C1B4
		private float GetAxisValueCallback(int index)
		{
			if (index >= this.axisValues.Length)
			{
				return 0f;
			}
			return this.axisValues[index];
		}

		// Token: 0x06000E7C RID: 3708 RVA: 0x0004DFCF File Offset: 0x0004C1CF
		private bool GetButtonValueCallback(int index)
		{
			return index < this.buttonValues.Length && this.buttonValues[index];
		}

		// Token: 0x0400131E RID: 4894
		public int playerId;

		// Token: 0x0400131F RID: 4895
		public string controllerTag;

		// Token: 0x04001320 RID: 4896
		public bool useUpdateCallbacks;

		// Token: 0x04001321 RID: 4897
		private int buttonCount;

		// Token: 0x04001322 RID: 4898
		private int axisCount;

		// Token: 0x04001323 RID: 4899
		private float[] axisValues;

		// Token: 0x04001324 RID: 4900
		private bool[] buttonValues;

		// Token: 0x04001325 RID: 4901
		private TouchJoystickExample[] joysticks;

		// Token: 0x04001326 RID: 4902
		private TouchButtonExample[] buttons;

		// Token: 0x04001327 RID: 4903
		private CustomController controller;

		// Token: 0x04001328 RID: 4904
		[NonSerialized]
		private bool initialized;
	}
}
