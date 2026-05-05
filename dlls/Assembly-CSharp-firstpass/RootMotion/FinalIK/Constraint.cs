using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000094 RID: 148
	[Serializable]
	public abstract class Constraint
	{
		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600048C RID: 1164 RVA: 0x0001C1EB File Offset: 0x0001A3EB
		public bool isValid
		{
			get
			{
				return this.transform != null;
			}
		}

		// Token: 0x0600048D RID: 1165
		public abstract void UpdateConstraint();

		// Token: 0x0400040A RID: 1034
		public Transform transform;

		// Token: 0x0400040B RID: 1035
		public float weight;
	}
}
