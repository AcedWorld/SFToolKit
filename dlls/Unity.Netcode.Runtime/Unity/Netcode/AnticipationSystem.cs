using System;
using System.Collections.Generic;

namespace Unity.Netcode
{
	// Token: 0x0200011A RID: 282
	internal class AnticipationSystem
	{
		// Token: 0x060008DD RID: 2269 RVA: 0x000222E2 File Offset: 0x000204E2
		public AnticipationSystem(NetworkManager manager)
		{
			this.m_NetworkManager = manager;
		}

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x060008DE RID: 2270 RVA: 0x00022314 File Offset: 0x00020514
		// (remove) Token: 0x060008DF RID: 2271 RVA: 0x0002234C File Offset: 0x0002054C
		public event NetworkManager.ReanticipateDelegate OnReanticipate;

		// Token: 0x060008E0 RID: 2272 RVA: 0x00022381 File Offset: 0x00020581
		public void RegisterForAnticipationEvents(IAnticipationEventReceiver receiver)
		{
			this.m_AnticipationEventReceivers.Add(receiver);
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x00022390 File Offset: 0x00020590
		public void DeregisterForAnticipationEvents(IAnticipationEventReceiver receiver)
		{
			this.m_AnticipationEventReceivers.Remove(receiver);
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x000223A0 File Offset: 0x000205A0
		public void SetupForUpdate()
		{
			foreach (IAnticipationEventReceiver anticipationEventReceiver in this.m_AnticipationEventReceivers)
			{
				anticipationEventReceiver.SetupForUpdate();
			}
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x000223F0 File Offset: 0x000205F0
		public void SetupForRender()
		{
			foreach (IAnticipationEventReceiver anticipationEventReceiver in this.m_AnticipationEventReceivers)
			{
				anticipationEventReceiver.SetupForRender();
			}
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x00022440 File Offset: 0x00020640
		public void ProcessReanticipation()
		{
			double lastRoundTripTime = this.m_NetworkManager.LocalTime.Time - this.LastAnticipationAckTime;
			foreach (IAnticipatedObject anticipatedObject in this.ObjectsToReanticipate)
			{
				foreach (NetworkBehaviour networkBehaviour in anticipatedObject.OwnerObject.ChildNetworkBehaviours)
				{
					networkBehaviour.OnReanticipate(lastRoundTripTime);
				}
				anticipatedObject.ResetAnticipation();
			}
			this.ObjectsToReanticipate.Clear();
			NetworkManager.ReanticipateDelegate onReanticipate = this.OnReanticipate;
			if (onReanticipate == null)
			{
				return;
			}
			onReanticipate(lastRoundTripTime);
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x00022510 File Offset: 0x00020710
		public void Update()
		{
			foreach (IAnticipatedObject anticipatedObject in this.AllAnticipatedObjects)
			{
				anticipatedObject.Update();
			}
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00022560 File Offset: 0x00020760
		public void Sync()
		{
			if (this.AllAnticipatedObjects.Count != 0 && !this.m_NetworkManager.ShutdownInProgress && !this.m_NetworkManager.ConnectionManager.LocalClient.IsServer && this.m_NetworkManager.ConnectionManager.LocalClient.IsConnected)
			{
				AnticipationCounterSyncPingMessage anticipationCounterSyncPingMessage = new AnticipationCounterSyncPingMessage
				{
					Counter = this.AnticipationCounter,
					Time = this.m_NetworkManager.LocalTime.Time
				};
				this.m_NetworkManager.MessageManager.SendMessage<AnticipationCounterSyncPingMessage>(ref anticipationCounterSyncPingMessage, NetworkDelivery.Reliable, 0UL);
			}
			this.AnticipationCounter += 1UL;
		}

		// Token: 0x0400034D RID: 845
		internal ulong LastAnticipationAck;

		// Token: 0x0400034E RID: 846
		internal double LastAnticipationAckTime;

		// Token: 0x0400034F RID: 847
		internal HashSet<IAnticipatedObject> AllAnticipatedObjects = new HashSet<IAnticipatedObject>();

		// Token: 0x04000350 RID: 848
		internal ulong AnticipationCounter;

		// Token: 0x04000351 RID: 849
		private NetworkManager m_NetworkManager;

		// Token: 0x04000352 RID: 850
		public HashSet<IAnticipatedObject> ObjectsToReanticipate = new HashSet<IAnticipatedObject>();

		// Token: 0x04000354 RID: 852
		private HashSet<IAnticipationEventReceiver> m_AnticipationEventReceivers = new HashSet<IAnticipationEventReceiver>();
	}
}
