using System;
using UnityEngine;

namespace Invector.vCharacterController.vActions
{
	// Token: 0x02000410 RID: 1040
	public interface IActionExitListener : IActionController
	{
		// Token: 0x0600156D RID: 5485
		void OnActionExit(Collider actionCollider);
	}
}
