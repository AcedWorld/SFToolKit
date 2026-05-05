using System;
using Invector.vCharacterController;
using UnityEngine;
using UnityEngine.Events;

namespace Invector.vItemManager
{
	// Token: 0x020003AC RID: 940
	public class vChangeInputTypeTrigger : MonoBehaviour
	{
		// Token: 0x060012D8 RID: 4824 RVA: 0x00064024 File Offset: 0x00062224
		private void Start()
		{
			vInput.instance.onChangeInputType -= this.OnChangeInput;
			vInput.instance.onChangeInputType += this.OnChangeInput;
			this.OnChangeInput(vInput.instance.inputDevice);
		}

		// Token: 0x060012D9 RID: 4825 RVA: 0x00064062 File Offset: 0x00062262
		public void OnChangeInput(InputDevice type)
		{
			switch (type)
			{
			case InputDevice.MouseKeyboard:
				this.OnChangeToKeyboard.Invoke();
				return;
			case InputDevice.Joystick:
				this.OnChangeToJoystick.Invoke();
				return;
			case InputDevice.Mobile:
				this.OnChangeToMobile.Invoke();
				return;
			default:
				return;
			}
		}

		// Token: 0x040018B1 RID: 6321
		[Header("Events called when InputType changed")]
		public UnityEvent OnChangeToKeyboard;

		// Token: 0x040018B2 RID: 6322
		public UnityEvent OnChangeToMobile;

		// Token: 0x040018B3 RID: 6323
		public UnityEvent OnChangeToJoystick;
	}
}
