using System;
using Invector.vCharacterController;
using UnityEngine;

// Token: 0x02000043 RID: 67
public class vEnableDisableByInputDevice : MonoBehaviour
{
	// Token: 0x060000FD RID: 253 RVA: 0x00008FFA File Offset: 0x000071FA
	private void Start()
	{
		vInput.instance.onChangeInputType -= this.OnChangeInput;
		vInput.instance.onChangeInputType += this.OnChangeInput;
		this.OnChangeInput(vInput.instance.inputDevice);
	}

	// Token: 0x060000FE RID: 254 RVA: 0x00009038 File Offset: 0x00007238
	public void OnChangeInput(InputDevice type)
	{
		bool flag = (this.methodToCheck == vEnableDisableByInputDevice.CheckMethod.Different) ? (type != this.inputDevice) : (type == this.inputDevice);
		if (base.gameObject.activeSelf != flag)
		{
			base.gameObject.SetActive(flag);
		}
	}

	// Token: 0x0400012D RID: 301
	public InputDevice inputDevice;

	// Token: 0x0400012E RID: 302
	public vEnableDisableByInputDevice.CheckMethod methodToCheck;

	// Token: 0x02000044 RID: 68
	public enum CheckMethod
	{
		// Token: 0x04000130 RID: 304
		Equals,
		// Token: 0x04000131 RID: 305
		Different
	}
}
