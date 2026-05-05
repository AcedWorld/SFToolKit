using System;
using UnityEngine;
using UnityEngine.Events;

namespace Invector.vCharacterController
{
	// Token: 0x020003FE RID: 1022
	public class vPunchingBag : MonoBehaviour
	{
		// Token: 0x060014E6 RID: 5350 RVA: 0x0006CCB2 File Offset: 0x0006AEB2
		private void Start()
		{
			this._rigidbody = base.GetComponent<Rigidbody>();
			this.character = base.GetComponent<vHealthController>();
			this.character.onReceiveDamage.AddListener(new UnityAction<vDamage>(this.TakeDamage));
		}

		// Token: 0x060014E7 RID: 5351 RVA: 0x0006CCE8 File Offset: 0x0006AEE8
		public void TakeDamage(vDamage damage)
		{
			Vector3 hitPosition = damage.hitPosition;
			Vector3 position = base.transform.position;
			position.y = hitPosition.y;
			Vector3 a = position - hitPosition;
			if (this.character != null && this.joint != null && this.character.currentHealth < 0f)
			{
				this.joint.connectedBody = null;
				if (this.removeComponentsAfterDie)
				{
					foreach (MonoBehaviour monoBehaviour in this.character.gameObject.GetComponentsInChildren<MonoBehaviour>())
					{
						if (monoBehaviour != this)
						{
							Object.Destroy(monoBehaviour);
						}
					}
				}
			}
			if (this._rigidbody != null)
			{
				this._rigidbody.AddForce(a * (damage.damageValue * this.forceMultipler), ForceMode.Impulse);
			}
		}

		// Token: 0x04001AA3 RID: 6819
		public Rigidbody _rigidbody;

		// Token: 0x04001AA4 RID: 6820
		public float forceMultipler = 0.5f;

		// Token: 0x04001AA5 RID: 6821
		public SpringJoint joint;

		// Token: 0x04001AA6 RID: 6822
		public vHealthController character;

		// Token: 0x04001AA7 RID: 6823
		public bool removeComponentsAfterDie;
	}
}
