using System;
using System.Collections.Generic;
using UnityEngine;

namespace Invector
{
	// Token: 0x020003AA RID: 938
	public class vSpikeControl : MonoBehaviour
	{
		// Token: 0x060012CA RID: 4810 RVA: 0x00063828 File Offset: 0x00061A28
		private void Start()
		{
			this.attachColliders = new List<Transform>();
			vSpike[] componentsInChildren = base.GetComponentsInChildren<vSpike>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].control = this;
			}
		}

		// Token: 0x040018A4 RID: 6308
		[HideInInspector]
		public List<Transform> attachColliders;
	}
}
