using System;
using UnityEngine;
using UnityEngine.UI;

namespace Invector
{
	// Token: 0x0200039F RID: 927
	public class vSetRandomFloat : MonoBehaviour
	{
		// Token: 0x060012A6 RID: 4774 RVA: 0x000626FF File Offset: 0x000608FF
		private void Start()
		{
			if (this.setOnStart)
			{
				this.Set();
			}
		}

		// Token: 0x060012A7 RID: 4775 RVA: 0x0006270F File Offset: 0x0006090F
		public void Set()
		{
			if (this.randomValue)
			{
				this.onSet.Invoke(Random.Range(this.min, this.max));
				return;
			}
			this.onSet.Invoke(this.max);
		}

		// Token: 0x04001864 RID: 6244
		public bool randomValue = true;

		// Token: 0x04001865 RID: 6245
		[vHideInInspector("randomValue", false)]
		public float min;

		// Token: 0x04001866 RID: 6246
		public float max;

		// Token: 0x04001867 RID: 6247
		public bool setOnStart;

		// Token: 0x04001868 RID: 6248
		public Slider.SliderEvent onSet;
	}
}
