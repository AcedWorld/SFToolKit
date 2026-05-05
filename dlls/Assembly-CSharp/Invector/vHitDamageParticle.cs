using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Invector
{
	// Token: 0x02000382 RID: 898
	[vClassHeader("HITDAMAGE PARTICLE", "Default hit Particle to instantiate every time you receive damage and Custom hit Particle to instantiate based on a custom DamageType that comes from the MeleeControl Behaviour (AnimatorController)")]
	public class vHitDamageParticle : vMonoBehaviour
	{
		// Token: 0x0600123D RID: 4669 RVA: 0x00060F13 File Offset: 0x0005F113
		private IEnumerator Start()
		{
			yield return new WaitForEndOfFrame();
			vHealthController component = base.GetComponent<vHealthController>();
			if (component != null)
			{
				component.onReceiveDamage.AddListener(new UnityAction<vDamage>(this.OnReceiveDamage));
			}
			yield break;
		}

		// Token: 0x0600123E RID: 4670 RVA: 0x00060F24 File Offset: 0x0005F124
		public void OnReceiveDamage(vDamage damage)
		{
			Vector3 vector = damage.hitPosition - new Vector3(base.transform.position.x, damage.hitPosition.y, base.transform.position.z);
			Quaternion rotation = (vector != Vector3.zero) ? Quaternion.LookRotation(vector) : base.transform.rotation;
			if (damage.damageValue > 0f)
			{
				this.TriggerEffect(new vDamageEffectInfo(damage.hitPosition, rotation, damage.damageType, damage.receiver));
			}
		}

		// Token: 0x0600123F RID: 4671 RVA: 0x00060FBC File Offset: 0x0005F1BC
		private void TriggerEffect(vDamageEffectInfo damageEffectInfo)
		{
			if (this._random == null)
			{
				this._random = new vFisherYatesRandom();
			}
			vDamageEffect vDamageEffect = this.customDamageEffects.Find((vDamageEffect effect) => effect.damageType.Equals(damageEffectInfo.damageType));
			if (vDamageEffect != null)
			{
				vDamageEffect.onTriggerEffect.Invoke();
				if (vDamageEffect.customDamageEffect != null && vDamageEffect.customDamageEffect.Count > 0)
				{
					GameObject gameObject = vDamageEffect.customDamageEffect[this._random.Next(vDamageEffect.customDamageEffect.Count)];
					Object.Instantiate<GameObject>(gameObject, damageEffectInfo.position, vDamageEffect.rotateToHitDirection ? damageEffectInfo.rotation : gameObject.transform.rotation, (vDamageEffect.attachInReceiver && damageEffectInfo.receiver) ? damageEffectInfo.receiver : vObjectContainer.root);
					return;
				}
			}
			else if (this.defaultDamageEffects.Count > 0 && damageEffectInfo != null)
			{
				Object.Instantiate<GameObject>(this.defaultDamageEffects[this._random.Next(this.defaultDamageEffects.Count)], damageEffectInfo.position, damageEffectInfo.rotation, vObjectContainer.root);
			}
		}

		// Token: 0x06001240 RID: 4672 RVA: 0x00061108 File Offset: 0x0005F308
		private void Reset()
		{
			this.defaultDamageEffects = new List<GameObject>();
			Object @object = Resources.Load("defaultDamageEffect");
			if (@object != null)
			{
				this.defaultDamageEffects.Add(@object as GameObject);
			}
		}

		// Token: 0x04001808 RID: 6152
		public List<GameObject> defaultDamageEffects = new List<GameObject>();

		// Token: 0x04001809 RID: 6153
		public List<vDamageEffect> customDamageEffects = new List<vDamageEffect>();

		// Token: 0x0400180A RID: 6154
		private vFisherYatesRandom _random;
	}
}
