using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Invector
{
	// Token: 0x0200037C RID: 892
	[vClassHeader("Destroy GameObject", true, "icon_v2", false, "", openClose = false)]
	public class vDestroyGameObject : vMonoBehaviour
	{
		// Token: 0x06001210 RID: 4624 RVA: 0x000603BE File Offset: 0x0005E5BE
		private IEnumerator Start()
		{
			yield return new WaitForSeconds(this.delay);
			this.onDestroy.Invoke();
			Object.Destroy(base.gameObject);
			yield break;
		}

		// Token: 0x040017FD RID: 6141
		public float delay;

		// Token: 0x040017FE RID: 6142
		public UnityEvent onDestroy;
	}
}
