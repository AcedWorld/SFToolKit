using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000144 RID: 324
	public class VRIKLODController : MonoBehaviour
	{
		// Token: 0x06000A15 RID: 2581 RVA: 0x0003FF0F File Offset: 0x0003E10F
		private void Start()
		{
			this.ik = base.GetComponent<VRIK>();
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x0003FF1D File Offset: 0x0003E11D
		private void Update()
		{
			this.ik.solver.LOD = this.GetLODLevel();
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x0003FF38 File Offset: 0x0003E138
		private int GetLODLevel()
		{
			if (this.allowCulled)
			{
				if (this.LODRenderer == null)
				{
					return 0;
				}
				if (!this.LODRenderer.isVisible)
				{
					return 2;
				}
			}
			if ((this.ik.transform.position - Camera.main.transform.position).sqrMagnitude > this.LODDistance * this.LODDistance)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x04000972 RID: 2418
		public Renderer LODRenderer;

		// Token: 0x04000973 RID: 2419
		public float LODDistance = 15f;

		// Token: 0x04000974 RID: 2420
		public bool allowCulled = true;

		// Token: 0x04000975 RID: 2421
		private VRIK ik;
	}
}
