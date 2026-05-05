using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

namespace UnityEngine.Networking.PlayerConnection
{
	// Token: 0x020003D2 RID: 978
	[Serializable]
	internal class PlayerEditorConnectionEvents
	{
		// Token: 0x06002134 RID: 8500 RVA: 0x000372D0 File Offset: 0x000354D0
		public void InvokeMessageIdSubscribers(Guid messageId, byte[] data, int playerId)
		{
			IEnumerable<PlayerEditorConnectionEvents.MessageTypeSubscribers> enumerable = from x in this.messageTypeSubscribers
			where x.MessageTypeId == messageId
			select x;
			bool flag = !enumerable.Any<PlayerEditorConnectionEvents.MessageTypeSubscribers>();
			if (flag)
			{
				string str = "No actions found for messageId: ";
				Guid messageId2 = messageId;
				Debug.LogError(str + messageId2.ToString());
			}
			else
			{
				MessageEventArgs arg = new MessageEventArgs
				{
					playerId = playerId,
					data = data
				};
				foreach (PlayerEditorConnectionEvents.MessageTypeSubscribers messageTypeSubscribers in enumerable)
				{
					messageTypeSubscribers.messageCallback.Invoke(arg);
				}
			}
		}

		// Token: 0x06002135 RID: 8501 RVA: 0x00037398 File Offset: 0x00035598
		public UnityEvent<MessageEventArgs> AddAndCreate(Guid messageId)
		{
			PlayerEditorConnectionEvents.MessageTypeSubscribers messageTypeSubscribers = this.messageTypeSubscribers.SingleOrDefault((PlayerEditorConnectionEvents.MessageTypeSubscribers x) => x.MessageTypeId == messageId);
			bool flag = messageTypeSubscribers == null;
			if (flag)
			{
				messageTypeSubscribers = new PlayerEditorConnectionEvents.MessageTypeSubscribers
				{
					MessageTypeId = messageId,
					messageCallback = new PlayerEditorConnectionEvents.MessageEvent()
				};
				this.messageTypeSubscribers.Add(messageTypeSubscribers);
			}
			messageTypeSubscribers.subscriberCount++;
			return messageTypeSubscribers.messageCallback;
		}

		// Token: 0x06002136 RID: 8502 RVA: 0x00037418 File Offset: 0x00035618
		public void UnregisterManagedCallback(Guid messageId, UnityAction<MessageEventArgs> callback)
		{
			PlayerEditorConnectionEvents.MessageTypeSubscribers messageTypeSubscribers = this.messageTypeSubscribers.SingleOrDefault((PlayerEditorConnectionEvents.MessageTypeSubscribers x) => x.MessageTypeId == messageId);
			bool flag = messageTypeSubscribers == null;
			if (!flag)
			{
				messageTypeSubscribers.subscriberCount--;
				messageTypeSubscribers.messageCallback.RemoveListener(callback);
				bool flag2 = messageTypeSubscribers.subscriberCount <= 0;
				if (flag2)
				{
					this.messageTypeSubscribers.Remove(messageTypeSubscribers);
				}
			}
		}

		// Token: 0x04000AFD RID: 2813
		[SerializeField]
		public List<PlayerEditorConnectionEvents.MessageTypeSubscribers> messageTypeSubscribers = new List<PlayerEditorConnectionEvents.MessageTypeSubscribers>();

		// Token: 0x04000AFE RID: 2814
		[SerializeField]
		public PlayerEditorConnectionEvents.ConnectionChangeEvent connectionEvent = new PlayerEditorConnectionEvents.ConnectionChangeEvent();

		// Token: 0x04000AFF RID: 2815
		[SerializeField]
		public PlayerEditorConnectionEvents.ConnectionChangeEvent disconnectionEvent = new PlayerEditorConnectionEvents.ConnectionChangeEvent();

		// Token: 0x020003D3 RID: 979
		[Serializable]
		public class MessageEvent : UnityEvent<MessageEventArgs>
		{
		}

		// Token: 0x020003D4 RID: 980
		[Serializable]
		public class ConnectionChangeEvent : UnityEvent<int>
		{
		}

		// Token: 0x020003D5 RID: 981
		[Serializable]
		public class MessageTypeSubscribers
		{
			// Token: 0x1700064A RID: 1610
			// (get) Token: 0x0600213A RID: 8506 RVA: 0x000374CC File Offset: 0x000356CC
			// (set) Token: 0x0600213B RID: 8507 RVA: 0x000374E9 File Offset: 0x000356E9
			public Guid MessageTypeId
			{
				get
				{
					return new Guid(this.m_messageTypeId);
				}
				set
				{
					this.m_messageTypeId = value.ToString();
				}
			}

			// Token: 0x04000B00 RID: 2816
			[SerializeField]
			private string m_messageTypeId;

			// Token: 0x04000B01 RID: 2817
			public int subscriberCount = 0;

			// Token: 0x04000B02 RID: 2818
			public PlayerEditorConnectionEvents.MessageEvent messageCallback = new PlayerEditorConnectionEvents.MessageEvent();
		}
	}
}
