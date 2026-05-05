using System;
using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	// Token: 0x0200054B RID: 1355
	[AddComponentMenu("")]
	[RequireComponent(typeof(GUIText))]
	public sealed class UnityJoystickElementIdentifier : MonoBehaviour
	{
		// Token: 0x060036CC RID: 14028 RVA: 0x0002AB89 File Offset: 0x00028D89
		public void Awake()
		{
			this.USDEObqSntqlOGdbADNvALQhIqpAb = new rpjCwFVejnUNhmtoFIjprRMLBUAH();
			this.USDEObqSntqlOGdbADNvALQhIqpAb.Initialize(GUIText.CreateLogger(base.gameObject));
		}

		// Token: 0x060036CD RID: 14029 RVA: 0x0002ABAC File Offset: 0x00028DAC
		public void Start()
		{
			this.USDEObqSntqlOGdbADNvALQhIqpAb.Start();
		}

		// Token: 0x060036CE RID: 14030 RVA: 0x0002ABB9 File Offset: 0x00028DB9
		public void Update()
		{
			this.USDEObqSntqlOGdbADNvALQhIqpAb.Update();
		}

		// Token: 0x060036CF RID: 14031 RVA: 0x0002ABC6 File Offset: 0x00028DC6
		public void OnDestroy()
		{
			this.USDEObqSntqlOGdbADNvALQhIqpAb.OnDestroy();
		}

		// Token: 0x04001CB3 RID: 7347
		private IElementIdentifierTool USDEObqSntqlOGdbADNvALQhIqpAb;
	}
}
