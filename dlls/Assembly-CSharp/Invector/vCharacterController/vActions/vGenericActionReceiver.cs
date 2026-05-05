using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Invector.vCharacterController.vActions
{
	// Token: 0x02000418 RID: 1048
	[vClassHeader("Action Receiver", true, "icon_v2", false, "")]
	public class vGenericActionReceiver : vMonoBehaviour
	{
		// Token: 0x060015B9 RID: 5561 RVA: 0x000717E4 File Offset: 0x0006F9E4
		private void Start()
		{
			vGenericAction componentInParent = base.gameObject.GetComponentInParent<vGenericAction>();
			if (componentInParent)
			{
				componentInParent.OnEnterTriggerAction.AddListener(new UnityAction<vTriggerGenericAction>(this.OnEnterTriggerAction));
				componentInParent.OnExitTriggerAction.AddListener(new UnityAction<vTriggerGenericAction>(this.OnExitTriggerAction));
				componentInParent.OnStartAction.AddListener(new UnityAction<vTriggerGenericAction>(this.OnStartAction));
				componentInParent.OnCancelAction.AddListener(new UnityAction<vTriggerGenericAction>(this.OnCancelAction));
				componentInParent.OnEndAction.AddListener(new UnityAction<vTriggerGenericAction>(this.OnEndAction));
			}
		}

		// Token: 0x060015BA RID: 5562 RVA: 0x00071880 File Offset: 0x0006FA80
		private void OnDestroy()
		{
			vGenericAction componentInParent = base.GetComponentInParent<vGenericAction>();
			if (componentInParent)
			{
				componentInParent.OnEnterTriggerAction.RemoveListener(new UnityAction<vTriggerGenericAction>(this.OnEnterTriggerAction));
				componentInParent.OnExitTriggerAction.RemoveListener(new UnityAction<vTriggerGenericAction>(this.OnExitTriggerAction));
				componentInParent.OnStartAction.RemoveListener(new UnityAction<vTriggerGenericAction>(this.OnStartAction));
				componentInParent.OnCancelAction.RemoveListener(new UnityAction<vTriggerGenericAction>(this.OnCancelAction));
				componentInParent.OnEndAction.RemoveListener(new UnityAction<vTriggerGenericAction>(this.OnEndAction));
			}
		}

		// Token: 0x060015BB RID: 5563 RVA: 0x00071914 File Offset: 0x0006FB14
		protected virtual bool IsValidAction(vTriggerGenericAction actionInfo)
		{
			return base.enabled && base.gameObject.activeInHierarchy && actionInfo != null && this.supportedActionNames.Contains(actionInfo.actionName);
		}

		// Token: 0x060015BC RID: 5564 RVA: 0x00071947 File Offset: 0x0006FB47
		public virtual void OnEnterTriggerAction(vTriggerGenericAction actionInfo)
		{
			if (this.IsValidAction(actionInfo))
			{
				this.onEnterTriggerAction.Invoke();
			}
		}

		// Token: 0x060015BD RID: 5565 RVA: 0x0007195D File Offset: 0x0006FB5D
		public virtual void OnExitTriggerAction(vTriggerGenericAction actionInfo)
		{
			if (this.IsValidAction(actionInfo))
			{
				this.onExitTriggerAction.Invoke();
			}
		}

		// Token: 0x060015BE RID: 5566 RVA: 0x00071973 File Offset: 0x0006FB73
		public virtual void OnStartAction(vTriggerGenericAction actionInfo)
		{
			if (this.IsValidAction(actionInfo))
			{
				this.onStartAction.Invoke();
			}
		}

		// Token: 0x060015BF RID: 5567 RVA: 0x00071989 File Offset: 0x0006FB89
		public virtual void OnCancelAction(vTriggerGenericAction actionInfo)
		{
			if (this.IsValidAction(actionInfo))
			{
				this.onCancelAction.Invoke();
			}
		}

		// Token: 0x060015C0 RID: 5568 RVA: 0x0007199F File Offset: 0x0006FB9F
		public virtual void OnEndAction(vTriggerGenericAction actionInfo)
		{
			if (this.IsValidAction(actionInfo))
			{
				this.onEndAction.Invoke();
			}
		}

		// Token: 0x04001B6C RID: 7020
		public List<string> supportedActionNames = new List<string>
		{
			"Action"
		};

		// Token: 0x04001B6D RID: 7021
		public UnityEvent onEnterTriggerAction;

		// Token: 0x04001B6E RID: 7022
		public UnityEvent onExitTriggerAction;

		// Token: 0x04001B6F RID: 7023
		public UnityEvent onStartAction;

		// Token: 0x04001B70 RID: 7024
		public UnityEvent onCancelAction;

		// Token: 0x04001B71 RID: 7025
		public UnityEvent onEndAction;
	}
}
