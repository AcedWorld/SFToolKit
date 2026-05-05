using System;
using System.Collections.Generic;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000334 RID: 820
	[Serializable]
	public class vThirdPersonCameraListData : ScriptableObject
	{
		// Token: 0x060010F0 RID: 4336 RVA: 0x0005BD40 File Offset: 0x00059F40
		public vThirdPersonCameraListData()
		{
			this.tpCameraStates = new List<vThirdPersonCameraState>();
			this.tpCameraStates.Add(new vThirdPersonCameraState("Default"));
		}

		// Token: 0x040016BA RID: 5818
		[SerializeField]
		public string Name;

		// Token: 0x040016BB RID: 5819
		[SerializeField]
		public List<vThirdPersonCameraState> tpCameraStates;
	}
}
