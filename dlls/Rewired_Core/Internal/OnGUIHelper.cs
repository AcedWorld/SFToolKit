using System;
using System.ComponentModel;
using UnityEngine;

namespace Rewired.Internal
{
	// Token: 0x0200042D RID: 1069
	[ExecuteInEditMode]
	[AddComponentMenu("")]
	[RequireComponent(typeof(InputManager_Base))]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class OnGUIHelper : MonoBehaviour
	{
		// Token: 0x06002AFF RID: 11007 RVA: 0x00021102 File Offset: 0x0001F302
		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			this.LDiuBKWMKXbdMAzyufpjBsVNgKWe = base.GetComponent<InputManager_Base>();
		}

		// Token: 0x06002B00 RID: 11008 RVA: 0x00021110 File Offset: 0x0001F310
		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (this.LDiuBKWMKXbdMAzyufpjBsVNgKWe == null)
			{
				return;
			}
			this.LDiuBKWMKXbdMAzyufpjBsVNgKWe.OnGUIUpdate();
		}

		// Token: 0x040018AB RID: 6315
		private InputManager_Base LDiuBKWMKXbdMAzyufpjBsVNgKWe;
	}
}
