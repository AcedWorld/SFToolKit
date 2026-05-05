using System;
using Invector;
using Invector.vCharacterController;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000031 RID: 49
[vClassHeader("Simple Trigger Input", true, "icon_v2", false, "")]
public class vSimpleTriggerWithInput : vSimpleTrigger
{
	// Token: 0x060000AA RID: 170 RVA: 0x00008058 File Offset: 0x00006258
	private void Update()
	{
		if (!this.other)
		{
			this._currentInputDelay = this.inputDelay;
			return;
		}
		if (this.inputType == vSimpleTriggerWithInput.InputType.GetButtonDown)
		{
			if (this.actionInput.GetButtonDown())
			{
				this.OnPressButton.Invoke();
				return;
			}
		}
		else if (this.inputType == vSimpleTriggerWithInput.InputType.GetDoubleButton)
		{
			if (this.actionInput.GetDoubleButtonDown(this.doubleButtomTime))
			{
				this.OnPressButton.Invoke();
				return;
			}
		}
		else if (this.inputType == vSimpleTriggerWithInput.InputType.GetButtonTimer)
		{
			if (this._currentInputDelay <= 0f)
			{
				bool flag = false;
				float value = 0f;
				if (this.actionInput.GetButtonTimer(ref value, ref flag, this.buttonTimer))
				{
					this._currentInputDelay = this.inputDelay;
					this.OnPressButton.Invoke();
				}
				if (this.actionInput.inButtomTimer)
				{
					this.UpdateButtonTimer(value);
				}
				if (flag)
				{
					this.CancelButtonTimer();
					return;
				}
			}
			else
			{
				this._currentInputDelay -= Time.deltaTime;
			}
		}
	}

	// Token: 0x060000AB RID: 171 RVA: 0x0000814A File Offset: 0x0000634A
	public void UpdateButtonTimer(float value)
	{
		if (value != this.currentButtonTimer)
		{
			this.currentButtonTimer = value;
			this.OnUpdateButtonTimer.Invoke(value);
		}
	}

	// Token: 0x060000AC RID: 172 RVA: 0x00008168 File Offset: 0x00006368
	private void CancelButtonTimer()
	{
		this.OnCancelButtonTimer.Invoke();
		this._currentInputDelay = this.inputDelay;
		this.UpdateButtonTimer(0f);
	}

	// Token: 0x040000F6 RID: 246
	public vSimpleTriggerWithInput.InputType inputType;

	// Token: 0x040000F7 RID: 247
	[Tooltip("Input to make the action")]
	public GenericInput actionInput = new GenericInput("E", "A", "A");

	// Token: 0x040000F8 RID: 248
	[vHelpBox("Time you have to hold the button *Only for GetButtonTimer*", vHelpBoxAttribute.MessageType.None)]
	public float buttonTimer = 3f;

	// Token: 0x040000F9 RID: 249
	[vHelpBox("Add delay to start the input count *Only for GetButtonTimer*", vHelpBoxAttribute.MessageType.None)]
	public float inputDelay = 0.1f;

	// Token: 0x040000FA RID: 250
	[vHelpBox("Time to press the button twice *Only for GetDoubleButton*", vHelpBoxAttribute.MessageType.None)]
	public float doubleButtomTime = 0.25f;

	// Token: 0x040000FB RID: 251
	public float _currentInputDelay;

	// Token: 0x040000FC RID: 252
	public float currentButtonTimer;

	// Token: 0x040000FD RID: 253
	public UnityEvent OnPressButton;

	// Token: 0x040000FE RID: 254
	public UnityEvent OnCancelButtonTimer;

	// Token: 0x040000FF RID: 255
	public vSimpleTriggerWithInput.OnUpdateValue OnUpdateButtonTimer;

	// Token: 0x02000032 RID: 50
	public enum InputType
	{
		// Token: 0x04000101 RID: 257
		GetButtonDown,
		// Token: 0x04000102 RID: 258
		GetDoubleButton,
		// Token: 0x04000103 RID: 259
		GetButtonTimer
	}

	// Token: 0x02000033 RID: 51
	[Serializable]
	public class OnUpdateValue : UnityEvent<float>
	{
	}
}
