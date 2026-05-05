using System;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000200 RID: 512
public class EditorButton : MonoBehaviour
{
	// Token: 0x0600080F RID: 2063 RVA: 0x00039FA4 File Offset: 0x000381A4
	public void ButtonPressed()
	{
		UnityEvent unityEvent = this.onButtonPressed;
		if (unityEvent == null)
		{
			return;
		}
		unityEvent.Invoke();
	}

	// Token: 0x04000E1A RID: 3610
	public UnityEvent onButtonPressed;
}
