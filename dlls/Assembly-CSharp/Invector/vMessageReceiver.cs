using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Invector
{
	// Token: 0x02000389 RID: 905
	[vClassHeader("MESSAGE RECEIVER", "Use this component with the vMessageSender to call Events.")]
	public class vMessageReceiver : vMonoBehaviour
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06001251 RID: 4689 RVA: 0x000613FC File Offset: 0x0005F5FC
		// (remove) Token: 0x06001252 RID: 4690 RVA: 0x00061430 File Offset: 0x0005F630
		public static event vMessageReceiver.OnReceiveMessage onReceiveGlobalMessage;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06001253 RID: 4691 RVA: 0x00061464 File Offset: 0x0005F664
		// (remove) Token: 0x06001254 RID: 4692 RVA: 0x0006149C File Offset: 0x0005F69C
		public event vMessageReceiver.OnReceiveMessage onReceiveMessage;

		// Token: 0x06001255 RID: 4693 RVA: 0x000614D4 File Offset: 0x0005F6D4
		private void Start()
		{
			for (int i = 0; i < this.messagesListeners.Count; i++)
			{
				vMessageReceiver.vMessageListener vMessageListener = this.messagesListeners[i];
				if (vMessageListener.receiveFromGlobal)
				{
					vMessageReceiver.onReceiveGlobalMessage -= vMessageListener.OnReceiveMessage;
					vMessageReceiver.onReceiveGlobalMessage += vMessageListener.OnReceiveMessage;
				}
				else
				{
					this.onReceiveMessage -= vMessageListener.OnReceiveMessage;
					this.onReceiveMessage += vMessageListener.OnReceiveMessage;
				}
			}
		}

		// Token: 0x06001256 RID: 4694 RVA: 0x00061554 File Offset: 0x0005F754
		public void AddListener(string name, UnityAction<string> listener)
		{
			if (this.messagesListeners.Exists((vMessageReceiver.vMessageListener l) => l.Name.Equals(name)))
			{
				this.messagesListeners.Find((vMessageReceiver.vMessageListener l) => l.Name.Equals(name)).onReceiveMessage.AddListener(listener);
				return;
			}
			this.messagesListeners.Add(new vMessageReceiver.vMessageListener(name, listener));
		}

		// Token: 0x06001257 RID: 4695 RVA: 0x000615C4 File Offset: 0x0005F7C4
		public void RemoveListener(string name, UnityAction<string> listener)
		{
			if (this.messagesListeners.Exists((vMessageReceiver.vMessageListener l) => l.Name.Equals(name)))
			{
				this.messagesListeners.Find((vMessageReceiver.vMessageListener l) => l.Name.Equals(name)).onReceiveMessage.RemoveListener(listener);
			}
		}

		// Token: 0x06001258 RID: 4696 RVA: 0x00061619 File Offset: 0x0005F819
		public void Send(string name, string message)
		{
			if (!base.enabled)
			{
				return;
			}
			vMessageReceiver.OnReceiveMessage onReceiveMessage = this.onReceiveMessage;
			if (onReceiveMessage == null)
			{
				return;
			}
			onReceiveMessage(name, message);
		}

		// Token: 0x06001259 RID: 4697 RVA: 0x00061636 File Offset: 0x0005F836
		public void Send(string name)
		{
			if (!base.enabled)
			{
				return;
			}
			vMessageReceiver.OnReceiveMessage onReceiveMessage = this.onReceiveMessage;
			if (onReceiveMessage == null)
			{
				return;
			}
			onReceiveMessage(name, string.Empty);
		}

		// Token: 0x0600125A RID: 4698 RVA: 0x00061657 File Offset: 0x0005F857
		public static void SendGlobal(string name, string message = null)
		{
			vMessageReceiver.OnReceiveMessage onReceiveMessage = vMessageReceiver.onReceiveGlobalMessage;
			if (onReceiveMessage == null)
			{
				return;
			}
			onReceiveMessage(name, message);
		}

		// Token: 0x04001822 RID: 6178
		public List<vMessageReceiver.vMessageListener> messagesListeners;

		// Token: 0x0200038A RID: 906
		// (Invoke) Token: 0x0600125D RID: 4701
		[Serializable]
		public delegate void OnReceiveMessage(string name, string message = null);

		// Token: 0x0200038B RID: 907
		[Serializable]
		public class OnReceiveMessageEvent : UnityEvent<string>
		{
		}

		// Token: 0x0200038C RID: 908
		[Serializable]
		public class vMessageListener
		{
			// Token: 0x06001261 RID: 4705 RVA: 0x00061672 File Offset: 0x0005F872
			public void OnReceiveMessage(string name, string message = null)
			{
				if (this.Name.Equals(name))
				{
					this.onReceiveMessage.Invoke(string.IsNullOrEmpty(message) ? string.Empty : message);
				}
			}

			// Token: 0x06001262 RID: 4706 RVA: 0x0006169D File Offset: 0x0005F89D
			public vMessageListener(string name)
			{
				this.Name = name;
			}

			// Token: 0x06001263 RID: 4707 RVA: 0x000616AC File Offset: 0x0005F8AC
			public vMessageListener(string name, UnityAction<string> listener)
			{
				this.Name = name;
				this.onReceiveMessage.AddListener(listener);
			}

			// Token: 0x04001824 RID: 6180
			public string Name;

			// Token: 0x04001825 RID: 6181
			public bool receiveFromGlobal;

			// Token: 0x04001826 RID: 6182
			public vMessageReceiver.OnReceiveMessageEvent onReceiveMessage;
		}
	}
}
