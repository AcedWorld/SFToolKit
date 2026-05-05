using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Invector
{
	// Token: 0x0200035F RID: 863
	[vClassHeader("Damage Modifier Controller", true, "icon_v2", false, "", openClose = false, useHelpBox = true, helpBoxText = "Needs a HealthController component")]
	public class vDamageModifierController : vMonoBehaviour
	{
		// Token: 0x06001179 RID: 4473 RVA: 0x0005E4A6 File Offset: 0x0005C6A6
		protected virtual void Awake()
		{
			this.Init();
		}

		// Token: 0x0600117A RID: 4474 RVA: 0x0005E4AE File Offset: 0x0005C6AE
		protected void Init()
		{
			this.GetHealthController();
			if (this.healthController != null)
			{
				this.AddDamageEvent();
				this.InitModifiers();
				this.isInit = true;
			}
		}

		// Token: 0x0600117B RID: 4475 RVA: 0x0005E4D4 File Offset: 0x0005C6D4
		protected virtual void InitModifiers()
		{
			for (int i = 0; i < this.modifiers.Count; i++)
			{
				this.modifiers[i].ResetModifier();
				this.modifiers[i].onBroken.AddListener(delegate(vDamageModifier m)
				{
					this.CheckBrokedModifiers();
				});
			}
		}

		// Token: 0x0600117C RID: 4476 RVA: 0x0005E52A File Offset: 0x0005C72A
		protected virtual void AddDamageEvent()
		{
			this.RemoveDamageEvent();
			this.healthController.onStartReceiveDamage.AddListener(new UnityAction<vDamage>(this.ApplyModifiers));
		}

		// Token: 0x0600117D RID: 4477 RVA: 0x0005E54F File Offset: 0x0005C74F
		protected virtual void RemoveDamageEvent()
		{
			this.healthController.onStartReceiveDamage.RemoveListener(new UnityAction<vDamage>(this.ApplyModifiers));
		}

		// Token: 0x0600117E RID: 4478 RVA: 0x0005E570 File Offset: 0x0005C770
		protected virtual void GetHealthController()
		{
			switch (this.getHealthMethod)
			{
			case vDamageModifierController.GetHealthControllerMethod.GetComponent:
				this.healthController = base.GetComponent<vIHealthController>();
				return;
			case vDamageModifierController.GetHealthControllerMethod.GetComponentInParent:
				this.healthController = base.GetComponentInParent<vIHealthController>();
				return;
			case vDamageModifierController.GetHealthControllerMethod.GetComponentInChildren:
				this.healthController = base.GetComponentInChildren<vIHealthController>();
				return;
			default:
				return;
			}
		}

		// Token: 0x0600117F RID: 4479 RVA: 0x0005E5BD File Offset: 0x0005C7BD
		protected virtual void OnEnable()
		{
			if (this.isInit)
			{
				this.AddDamageEvent();
			}
		}

		// Token: 0x06001180 RID: 4480 RVA: 0x0005E5CD File Offset: 0x0005C7CD
		protected virtual void OnDisable()
		{
			if (this.isInit)
			{
				this.RemoveDamageEvent();
			}
		}

		// Token: 0x06001181 RID: 4481 RVA: 0x0005E5DD File Offset: 0x0005C7DD
		protected virtual void CheckBrokedModifiers()
		{
			if (!this.modifiers.Exists((vDamageModifier m) => !m.isBroken))
			{
				this.onAllModifiersIsBroken.Invoke();
			}
		}

		// Token: 0x06001182 RID: 4482 RVA: 0x0005E618 File Offset: 0x0005C818
		protected virtual void ApplyModifiers(vDamage damage)
		{
			for (int i = 0; i < this.modifiers.Count; i++)
			{
				this.modifiers[i].ApplyModifier(damage);
			}
		}

		// Token: 0x06001183 RID: 4483 RVA: 0x0005E650 File Offset: 0x0005C850
		public void ResetAllModifiers()
		{
			for (int i = 0; i < this.modifiers.Count; i++)
			{
				this.modifiers[i].ResetModifier();
			}
		}

		// Token: 0x0400177D RID: 6013
		[vReadOnly(true)]
		public bool isInit;

		// Token: 0x0400177E RID: 6014
		[SerializeField]
		protected vDamageModifierController.GetHealthControllerMethod getHealthMethod;

		// Token: 0x0400177F RID: 6015
		[Tooltip("Modifier List")]
		public List<vDamageModifier> modifiers;

		// Token: 0x04001780 RID: 6016
		public UnityEvent onAllModifiersIsBroken;

		// Token: 0x04001781 RID: 6017
		protected vIHealthController healthController;

		// Token: 0x02000360 RID: 864
		public enum GetHealthControllerMethod
		{
			// Token: 0x04001783 RID: 6019
			GetComponent,
			// Token: 0x04001784 RID: 6020
			GetComponentInParent,
			// Token: 0x04001785 RID: 6021
			GetComponentInChildren
		}
	}
}
