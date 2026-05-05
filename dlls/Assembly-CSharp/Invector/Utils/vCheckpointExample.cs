using System;
using Invector.vCharacterController;
using UnityEngine;
using UnityEngine.Events;

namespace Invector.Utils
{
	// Token: 0x020003AE RID: 942
	[RequireComponent(typeof(BoxCollider))]
	public class vCheckpointExample : MonoBehaviour
	{
		// Token: 0x060012DE RID: 4830 RVA: 0x000640C6 File Offset: 0x000622C6
		private void Start()
		{
			this.gm = base.GetComponentInParent<vGameController>();
			base.GetComponent<BoxCollider>().isTrigger = true;
		}

		// Token: 0x060012DF RID: 4831 RVA: 0x000640E0 File Offset: 0x000622E0
		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				vHUDController.instance.ShowText("Checkpoint reached!");
				this.gm.spawnPoint = base.gameObject.transform;
				this.onTriggerEnter.Invoke();
				base.gameObject.SetActive(false);
			}
		}

		// Token: 0x040018B7 RID: 6327
		private vGameController gm;

		// Token: 0x040018B8 RID: 6328
		public UnityEvent onTriggerEnter;
	}
}
