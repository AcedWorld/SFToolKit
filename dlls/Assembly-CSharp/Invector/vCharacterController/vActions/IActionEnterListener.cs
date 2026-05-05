using System;
using UnityEngine;

namespace Invector.vCharacterController.vActions
{
	// Token: 0x0200040F RID: 1039
	public interface IActionEnterListener : IActionController
	{
		// Token: 0x0600156C RID: 5484
		void OnActionEnter(Collider actionCollider);
	}
}
