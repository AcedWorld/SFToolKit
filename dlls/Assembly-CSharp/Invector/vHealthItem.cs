using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000367 RID: 871
	public class vHealthItem : MonoBehaviour
	{
		// Token: 0x060011AD RID: 4525 RVA: 0x0005EC14 File Offset: 0x0005CE14
		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag(this.tagFilter))
			{
				vHealthController component = other.GetComponent<vHealthController>();
				if (component != null && component.currentHealth < (float)component.maxHealth)
				{
					component.AddHealth((int)this.value);
					Object.Destroy(base.gameObject);
				}
			}
		}

		// Token: 0x040017A2 RID: 6050
		[Tooltip("How much health will be recovery")]
		public float value;

		// Token: 0x040017A3 RID: 6051
		public string tagFilter = "Player";
	}
}
