using System;
using UnityEngine;
using UnityEngine.Events;

namespace Invector.vCharacterController
{
	// Token: 0x020003EA RID: 1002
	public class vOnDeadTrigger : MonoBehaviour
	{
		// Token: 0x060013F5 RID: 5109 RVA: 0x00067814 File Offset: 0x00065A14
		private void Start()
		{
			vCharacter component = base.GetComponent<vCharacter>();
			if (component)
			{
				component.onDead.AddListener(new UnityAction<GameObject>(this.OnDeadHandle));
			}
		}

		// Token: 0x060013F6 RID: 5110 RVA: 0x00067847 File Offset: 0x00065A47
		public void OnDeadHandle(GameObject target)
		{
			this.OnDead.Invoke();
		}

		// Token: 0x0400198D RID: 6541
		public UnityEvent OnDead;
	}
}
