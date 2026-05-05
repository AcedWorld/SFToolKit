using System;
using UnityEngine;

namespace Invector.vCharacterController
{
	// Token: 0x020003F4 RID: 1012
	internal class vAnimatorMoveSender : MonoBehaviour
	{
		// Token: 0x0600146C RID: 5228 RVA: 0x000699B4 File Offset: 0x00067BB4
		private void Awake()
		{
			base.hideFlags = HideFlags.HideInInspector;
			vIAnimatorMoveReceiver[] components = base.GetComponents<vIAnimatorMoveReceiver>();
			for (int i = 0; i < components.Length; i++)
			{
				vIAnimatorMoveReceiver receiver = components[i];
				this.animatorMoveEvent = (Action)Delegate.Combine(this.animatorMoveEvent, new Action(delegate()
				{
					if (receiver.enabled)
					{
						receiver.OnAnimatorMoveEvent();
					}
				}));
			}
		}

		// Token: 0x0600146D RID: 5229 RVA: 0x00069A0E File Offset: 0x00067C0E
		private void OnAnimatorMove()
		{
			Action action = this.animatorMoveEvent;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x040019DC RID: 6620
		public Action animatorMoveEvent;
	}
}
