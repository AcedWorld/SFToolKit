using System;
using Invector.vCharacterController;
using UnityEngine;
using UnityEngine.Events;

namespace Invector.Utils
{
	// Token: 0x020003C0 RID: 960
	public class vSetParentOfController : MonoBehaviour
	{
		// Token: 0x06001327 RID: 4903 RVA: 0x00064B27 File Offset: 0x00062D27
		private void Start()
		{
			this.cc = base.GetComponentInParent<vThirdPersonController>();
			base.transform.parent = this.cc.transform;
			this.onStart.Invoke();
		}

		// Token: 0x040018E8 RID: 6376
		[vHelpBox("Set this GameObject as parent of the Controller", vHelpBoxAttribute.MessageType.None)]
		private vThirdPersonController cc;

		// Token: 0x040018E9 RID: 6377
		public UnityEvent onStart;
	}
}
