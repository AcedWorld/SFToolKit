using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000398 RID: 920
	public class vRotateObject : MonoBehaviour
	{
		// Token: 0x06001288 RID: 4744 RVA: 0x00061D6C File Offset: 0x0005FF6C
		private void Update()
		{
			base.transform.Rotate(this.rotationSpeed * Time.deltaTime, Space.Self);
		}

		// Token: 0x0400183B RID: 6203
		public Vector3 rotationSpeed;
	}
}
