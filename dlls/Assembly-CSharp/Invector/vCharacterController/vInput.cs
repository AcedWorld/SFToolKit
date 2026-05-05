using System;
using UnityEngine;

namespace Invector.vCharacterController
{
	// Token: 0x020003E6 RID: 998
	public class vInput : MonoBehaviour
	{
		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060013CF RID: 5071 RVA: 0x00066DC8 File Offset: 0x00064FC8
		// (remove) Token: 0x060013D0 RID: 5072 RVA: 0x00066E00 File Offset: 0x00065000
		public event vInput.OnChangeInputType onChangeInputType;

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x060013D1 RID: 5073 RVA: 0x00066E38 File Offset: 0x00065038
		public static vInput instance
		{
			get
			{
				if (vInput._instance == null)
				{
					vInput._instance = Object.FindObjectOfType<vInput>();
					if (vInput._instance == null)
					{
						vInput._instance = new GameObject("vInputType").AddComponent<vInput>();
						return vInput._instance;
					}
				}
				return vInput._instance;
			}
		}

		// Token: 0x060013D2 RID: 5074 RVA: 0x000020BE File Offset: 0x000002BE
		private void Start()
		{
		}

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x060013D3 RID: 5075 RVA: 0x00066E88 File Offset: 0x00065088
		// (set) Token: 0x060013D4 RID: 5076 RVA: 0x00066E90 File Offset: 0x00065090
		[HideInInspector]
		public InputDevice inputDevice
		{
			get
			{
				return this._inputType;
			}
			set
			{
				this._inputType = value;
				this.OnChangeInput();
			}
		}

		// Token: 0x060013D5 RID: 5077 RVA: 0x000020BE File Offset: 0x000002BE
		private void OnGUI()
		{
		}

		// Token: 0x060013D6 RID: 5078 RVA: 0x0000889E File Offset: 0x00006A9E
		private bool isMobileInput()
		{
			return false;
		}

		// Token: 0x060013D7 RID: 5079 RVA: 0x0000889E File Offset: 0x00006A9E
		private bool isMouseKeyboard()
		{
			return false;
		}

		// Token: 0x060013D8 RID: 5080 RVA: 0x0000889E File Offset: 0x00006A9E
		private bool isJoystickInput()
		{
			return false;
		}

		// Token: 0x060013D9 RID: 5081 RVA: 0x000020BE File Offset: 0x000002BE
		private void OnChangeInput()
		{
		}

		// Token: 0x04001975 RID: 6517
		private static vInput _instance;

		// Token: 0x04001976 RID: 6518
		public vHUDController hud;

		// Token: 0x04001977 RID: 6519
		private InputDevice _inputType;

		// Token: 0x020003E7 RID: 999
		// (Invoke) Token: 0x060013DC RID: 5084
		public delegate void OnChangeInputType(InputDevice type);
	}
}
