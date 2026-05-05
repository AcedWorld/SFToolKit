using System;
using System.Collections.Generic;
using Invector;
using Invector.vCharacterController.vActions;
using UnityEngine.Events;

// Token: 0x0200001F RID: 31
[vClassHeader("Trigger Action Event", true, "icon_v2", false, "", helpBoxText = "Use this to filter a specific TriggerAction so you can use Events with the Controller or components attached to the Controller", useHelpBox = true)]
public class vTriggerActionEvent : vMonoBehaviour
{
	// Token: 0x06000088 RID: 136 RVA: 0x00007B44 File Offset: 0x00005D44
	public void TriggerEvent(vTriggerGenericAction action)
	{
		vTriggerActionEvent.ActionEvent actionEvent = this.actionFinders.Find((vTriggerActionEvent.ActionEvent a) => a.actionName.Equals(action.gameObject.name));
		if (actionEvent != null)
		{
			actionEvent.onTriggerEvent.Invoke();
		}
	}

	// Token: 0x040000C8 RID: 200
	public List<vTriggerActionEvent.ActionEvent> actionFinders;

	// Token: 0x02000020 RID: 32
	[Serializable]
	public class ActionEvent
	{
		// Token: 0x040000C9 RID: 201
		public string actionName;

		// Token: 0x040000CA RID: 202
		public UnityEvent onTriggerEvent;
	}
}
