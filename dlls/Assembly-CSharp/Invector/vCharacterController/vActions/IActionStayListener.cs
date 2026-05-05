using System;
using UnityEngine;

namespace Invector.vCharacterController.vActions
{
	// Token: 0x02000411 RID: 1041
	public interface IActionStayListener : IActionController
	{
		// Token: 0x0600156E RID: 5486
		void OnActionStay(Collider actionCollider);
	}
}
