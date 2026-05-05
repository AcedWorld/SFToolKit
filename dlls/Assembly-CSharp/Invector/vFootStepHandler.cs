using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000343 RID: 835
	public class vFootStepHandler : MonoBehaviour
	{
		// Token: 0x1700033E RID: 830
		// (get) Token: 0x06001135 RID: 4405 RVA: 0x0005D48B File Offset: 0x0005B68B
		public int material_ID
		{
			get
			{
				return this.materialIndex;
			}
		}

		// Token: 0x04001710 RID: 5904
		[Tooltip("Use this to select a specific material or texture if your mesh has multiple materials, the footstep will play only the selected index.")]
		[SerializeField]
		private int materialIndex;

		// Token: 0x04001711 RID: 5905
		public vFootStepHandler.StepHandleType stepHandleType;

		// Token: 0x02000344 RID: 836
		public enum StepHandleType
		{
			// Token: 0x04001713 RID: 5907
			materialName,
			// Token: 0x04001714 RID: 5908
			textureName
		}
	}
}
