using System;
using UnityEngine;

namespace Invector.Utils
{
	// Token: 0x020003BE RID: 958
	public class vScaleControl : MonoBehaviour
	{
		// Token: 0x0600131E RID: 4894 RVA: 0x00064A70 File Offset: 0x00062C70
		private void Awake()
		{
			this.defaultScale = base.transform.localScale;
			this.targetScale = this.defaultScale;
		}

		// Token: 0x17000371 RID: 881
		// (set) Token: 0x0600131F RID: 4895 RVA: 0x00064A8F File Offset: 0x00062C8F
		public float scaleX
		{
			set
			{
				this.targetScale.x = this.defaultScale.x * value;
				base.transform.localScale = this.targetScale;
			}
		}

		// Token: 0x17000372 RID: 882
		// (set) Token: 0x06001320 RID: 4896 RVA: 0x00064ABA File Offset: 0x00062CBA
		public float scaleY
		{
			set
			{
				this.targetScale.y = this.defaultScale.y * value;
				base.transform.localScale = this.targetScale;
			}
		}

		// Token: 0x17000373 RID: 883
		// (set) Token: 0x06001321 RID: 4897 RVA: 0x00064AE5 File Offset: 0x00062CE5
		public float scaleZ
		{
			set
			{
				this.targetScale.z = this.defaultScale.z * value;
				base.transform.localScale = this.targetScale;
			}
		}

		// Token: 0x040018E6 RID: 6374
		private Vector3 targetScale;

		// Token: 0x040018E7 RID: 6375
		private Vector3 defaultScale;
	}
}
