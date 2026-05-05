using System;
using System.Collections.Generic;
using UnityEngine;

namespace Invector
{
	// Token: 0x0200038F RID: 911
	[vClassHeader("Message Sender", "Requires a vMessageReceiver to receive messages.", openClose = false)]
	public class vMessageSender : vMonoBehaviour
	{
		// Token: 0x0600126A RID: 4714 RVA: 0x000616F0 File Offset: 0x0005F8F0
		public virtual void SendToDefaultReceiver(int messageIndex)
		{
			vMessageSender.vMessage vMessage = (this.messages.Count > 0 && messageIndex < this.messages.Count) ? this.messages[messageIndex] : null;
			if (vMessage != null)
			{
				for (int i = 0; i < vMessage.defaultReceivers.Count; i++)
				{
					if (vMessage.defaultReceivers[i])
					{
						vMessage.defaultReceivers[i].Send(vMessage.name, vMessage.message);
					}
				}
			}
		}

		// Token: 0x0600126B RID: 4715 RVA: 0x00061774 File Offset: 0x0005F974
		public virtual void SendToDefaultReceiver(string messageName)
		{
			List<vMessageSender.vMessage> list = this.messages.FindAll((vMessageSender.vMessage m) => m.name.Equals(messageName));
			if (list != null && list.Count > 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					for (int j = 0; j < list[i].defaultReceivers.Count; j++)
					{
						if (list[i].defaultReceivers[j])
						{
							list[i].defaultReceivers[j].Send(list[i].name, list[i].message);
						}
					}
				}
			}
		}

		// Token: 0x0600126C RID: 4716 RVA: 0x00061828 File Offset: 0x0005FA28
		public virtual void SendToParentReceiver(int messageIndex)
		{
			vMessageReceiver componentInParent = base.GetComponentInParent<vMessageReceiver>();
			if (!componentInParent)
			{
				return;
			}
			vMessageSender.vMessage vMessage = (this.messages.Count > 0 && messageIndex < this.messages.Count) ? this.messages[messageIndex] : null;
			if (vMessage != null)
			{
				componentInParent.Send(vMessage.name, vMessage.message);
			}
		}

		// Token: 0x0600126D RID: 4717 RVA: 0x00061888 File Offset: 0x0005FA88
		public virtual void SendToParentReceiver(string messageName)
		{
			vMessageReceiver componentInParent = base.GetComponentInParent<vMessageReceiver>();
			if (!componentInParent)
			{
				return;
			}
			List<vMessageSender.vMessage> list = this.messages.FindAll((vMessageSender.vMessage m) => m.name.Equals(messageName));
			if (list != null && list.Count > 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					componentInParent.Send(list[i].name, list[i].message);
				}
			}
		}

		// Token: 0x0600126E RID: 4718 RVA: 0x00061908 File Offset: 0x0005FB08
		public virtual void Send(GameObject target, int messageIndex)
		{
			if (target)
			{
				return;
			}
			vMessageReceiver component = target.GetComponent<vMessageReceiver>();
			if (!component)
			{
				return;
			}
			vMessageSender.vMessage vMessage = (this.messages.Count > 0 && messageIndex < this.messages.Count) ? this.messages[messageIndex] : null;
			if (vMessage != null)
			{
				component.Send(vMessage.name, vMessage.message);
			}
		}

		// Token: 0x0600126F RID: 4719 RVA: 0x0006196F File Offset: 0x0005FB6F
		public virtual void Send(Collider target, int messageIndex)
		{
			if (target)
			{
				return;
			}
			this.Send(target.gameObject, messageIndex);
		}

		// Token: 0x06001270 RID: 4720 RVA: 0x0006196F File Offset: 0x0005FB6F
		public virtual void Send(Transform target, int messageIndex)
		{
			if (target)
			{
				return;
			}
			this.Send(target.gameObject, messageIndex);
		}

		// Token: 0x06001271 RID: 4721 RVA: 0x00061988 File Offset: 0x0005FB88
		public virtual void Send(GameObject target, string messageName)
		{
			if (target)
			{
				return;
			}
			vMessageReceiver component = target.GetComponent<vMessageReceiver>();
			if (!component)
			{
				return;
			}
			List<vMessageSender.vMessage> list = this.messages.FindAll((vMessageSender.vMessage m) => m.name.Equals(messageName));
			if (list != null && list.Count > 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					component.Send(list[i].name, list[i].message);
				}
			}
		}

		// Token: 0x06001272 RID: 4722 RVA: 0x00061A0E File Offset: 0x0005FC0E
		public virtual void Send(Collider target, string messageName)
		{
			if (!target)
			{
				return;
			}
			this.Send(target.gameObject, messageName);
		}

		// Token: 0x06001273 RID: 4723 RVA: 0x00061A0E File Offset: 0x0005FC0E
		public virtual void Send(Transform target, string messageName)
		{
			if (!target)
			{
				return;
			}
			this.Send(target.gameObject, messageName);
		}

		// Token: 0x06001274 RID: 4724 RVA: 0x00061A28 File Offset: 0x0005FC28
		public virtual void SendAllToDefaultReceiver()
		{
			if (this.messages != null && this.messages.Count > 0)
			{
				for (int i = 0; i < this.messages.Count; i++)
				{
					for (int j = 0; j < this.messages[i].defaultReceivers.Count; j++)
					{
						if (this.messages[i].defaultReceivers[j])
						{
							this.messages[i].defaultReceivers[j].Send(this.messages[i].name, this.messages[i].message);
						}
					}
				}
			}
		}

		// Token: 0x06001275 RID: 4725 RVA: 0x00061AEC File Offset: 0x0005FCEC
		public virtual void SendAll(GameObject target)
		{
			if (!target)
			{
				return;
			}
			vMessageReceiver component = target.GetComponent<vMessageReceiver>();
			if (!component)
			{
				return;
			}
			for (int i = 0; i < this.messages.Count; i++)
			{
				component.Send(this.messages[i].name, this.messages[i].message);
			}
		}

		// Token: 0x06001276 RID: 4726 RVA: 0x00061B50 File Offset: 0x0005FD50
		public virtual void OnTrigger(Collider target)
		{
			if (!target)
			{
				return;
			}
			vMessageReceiver component = target.gameObject.GetComponent<vMessageReceiver>();
			if (!component)
			{
				return;
			}
			for (int i = 0; i < this.messages.Count; i++)
			{
				if (this.messages[i].sendByTrigger)
				{
					component.Send(this.messages[i].name, this.messages[i].message);
				}
			}
		}

		// Token: 0x06001277 RID: 4727 RVA: 0x00061BCC File Offset: 0x0005FDCC
		public virtual void SendGlobal(string messageName)
		{
			List<vMessageSender.vGlobalMessage> list = this.globalMessages.FindAll((vMessageSender.vGlobalMessage m) => m.name.Equals(messageName));
			for (int i = 0; i < list.Count; i++)
			{
				vMessageReceiver.SendGlobal(list[i].name, list[i].message);
			}
		}

		// Token: 0x06001278 RID: 4728 RVA: 0x00061C2C File Offset: 0x0005FE2C
		public virtual void SendGlobal(int messageIndex)
		{
			vMessageSender.vGlobalMessage vGlobalMessage = (this.globalMessages.Count > 0 && messageIndex < this.globalMessages.Count) ? this.globalMessages[messageIndex] : null;
			if (vGlobalMessage != null)
			{
				vMessageReceiver.SendGlobal(vGlobalMessage.name, vGlobalMessage.message);
			}
		}

		// Token: 0x04001829 RID: 6185
		public List<vMessageSender.vMessage> messages;

		// Token: 0x0400182A RID: 6186
		public List<vMessageSender.vGlobalMessage> globalMessages;

		// Token: 0x02000390 RID: 912
		[Serializable]
		public class vMessage
		{
			// Token: 0x0400182B RID: 6187
			public string name;

			// Token: 0x0400182C RID: 6188
			public string message;

			// Token: 0x0400182D RID: 6189
			[vHelpBox("- sendByTrigger (You can use vSimpleTrigger to verify the Player and Send messages using Events by calling the 'OnTrigger' method", vHelpBoxAttribute.MessageType.None)]
			public bool sendByTrigger;

			// Token: 0x0400182E RID: 6190
			public List<vMessageReceiver> defaultReceivers;
		}

		// Token: 0x02000391 RID: 913
		[Serializable]
		public class vGlobalMessage
		{
			// Token: 0x0400182F RID: 6191
			public string name;

			// Token: 0x04001830 RID: 6192
			public string message;
		}
	}
}
