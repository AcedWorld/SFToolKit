using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000183 RID: 387
	public class Turret : MonoBehaviour
	{
		// Token: 0x06000B15 RID: 2837 RVA: 0x000464FC File Offset: 0x000446FC
		private void Update()
		{
			Turret.Part[] array = this.parts;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].AimAt(this.target);
			}
		}

		// Token: 0x04000AF8 RID: 2808
		public Transform target;

		// Token: 0x04000AF9 RID: 2809
		public Turret.Part[] parts;

		// Token: 0x02000184 RID: 388
		[Serializable]
		public class Part
		{
			// Token: 0x06000B17 RID: 2839 RVA: 0x0004652C File Offset: 0x0004472C
			public void AimAt(Transform target)
			{
				this.transform.LookAt(target.position, this.transform.up);
				if (this.rotationLimit == null)
				{
					this.rotationLimit = this.transform.GetComponent<RotationLimit>();
					this.rotationLimit.Disable();
				}
				this.rotationLimit.Apply();
			}

			// Token: 0x04000AFA RID: 2810
			public Transform transform;

			// Token: 0x04000AFB RID: 2811
			private RotationLimit rotationLimit;
		}
	}
}
