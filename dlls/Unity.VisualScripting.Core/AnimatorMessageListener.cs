using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200007F RID: 127
	[AddComponentMenu("Visual Scripting/Listeners/Animator Message Listener")]
	public sealed class AnimatorMessageListener : MonoBehaviour
	{
		// Token: 0x060003C5 RID: 965 RVA: 0x0000942B File Offset: 0x0000762B
		private void OnAnimatorMove()
		{
			EventBus.Trigger("OnAnimatorMove", base.gameObject);
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x0000943D File Offset: 0x0000763D
		private void OnAnimatorIK(int layerIndex)
		{
			EventBus.Trigger<int>("OnAnimatorIK", base.gameObject, layerIndex);
		}
	}
}
