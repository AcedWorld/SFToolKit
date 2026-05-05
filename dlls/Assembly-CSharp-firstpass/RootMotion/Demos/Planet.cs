using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001A5 RID: 421
	public class Planet : MonoBehaviour
	{
		// Token: 0x06000B8F RID: 2959 RVA: 0x00048248 File Offset: 0x00046448
		private void Awake()
		{
			Rigidbody[] array = Object.FindObjectsOfType<Rigidbody>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.AddComponent<PlanetaryGravity>().planet = this;
			}
		}

		// Token: 0x04000B92 RID: 2962
		public float mass = 1000f;
	}
}
