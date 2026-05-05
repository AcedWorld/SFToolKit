using System;
using System.Collections;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200019B RID: 411
	public class Destructor : MonoBehaviour
	{
		// Token: 0x06000B67 RID: 2919 RVA: 0x0004793B File Offset: 0x00045B3B
		private void Start()
		{
			base.StartCoroutine(this.Destruct());
		}

		// Token: 0x06000B68 RID: 2920 RVA: 0x0004794A File Offset: 0x00045B4A
		private IEnumerator Destruct()
		{
			yield return new WaitForSeconds(this.delay);
			Object.Destroy(base.gameObject);
			yield break;
		}

		// Token: 0x04000B62 RID: 2914
		public float delay = 5f;
	}
}
