using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.Data
{
	// Token: 0x02000299 RID: 665
	[RequireComponent(typeof(InputManager_Base))]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public abstract class UserDataStore : MonoBehaviour, IUserDataStore, IControllerMapStore
	{
		// Token: 0x06001E28 RID: 7720 RVA: 0x00017AB5 File Offset: 0x00015CB5
		private void OnDestroy()
		{
			if (!ReInput.isReady)
			{
				return;
			}
			ReInput.ControllerConnectedEvent -= this.OnControllerConnected;
			ReInput.ControllerDisconnectedEvent -= this.OnControllerDisconnected;
			ReInput.ControllerPreDisconnectEvent -= this.OnControllerPreDisconnect;
		}

		// Token: 0x06001E29 RID: 7721 RVA: 0x00017AF5 File Offset: 0x00015CF5
		internal void Initialize()
		{
			ReInput.ControllerConnectedEvent += this.OnControllerConnected;
			ReInput.ControllerDisconnectedEvent += this.OnControllerDisconnected;
			ReInput.ControllerPreDisconnectEvent += this.OnControllerPreDisconnect;
			this.OnInitialize();
		}

		// Token: 0x06001E2A RID: 7722
		public abstract void Load();

		// Token: 0x06001E2B RID: 7723
		public abstract void LoadControllerData(int playerId, ControllerType controllerType, int controllerId);

		// Token: 0x06001E2C RID: 7724
		public abstract void LoadControllerData(ControllerType controllerType, int controllerId);

		// Token: 0x06001E2D RID: 7725
		public abstract void LoadPlayerData(int playerId);

		// Token: 0x06001E2E RID: 7726
		public abstract void LoadInputBehavior(int playerId, int behaviorId);

		// Token: 0x06001E2F RID: 7727
		public abstract void Save();

		// Token: 0x06001E30 RID: 7728
		public abstract void SaveControllerData(int playerId, ControllerType controllerType, int controllerId);

		// Token: 0x06001E31 RID: 7729
		public abstract void SaveControllerData(ControllerType controllerType, int controllerId);

		// Token: 0x06001E32 RID: 7730
		public abstract void SavePlayerData(int playerId);

		// Token: 0x06001E33 RID: 7731
		public abstract void SaveInputBehavior(int playerId, int behaviorId);

		// Token: 0x06001E34 RID: 7732 RVA: 0x00002FF9 File Offset: 0x000011F9
		public virtual void SaveControllerMap(int playerId, ControllerMap controllerMap)
		{
		}

		// Token: 0x06001E35 RID: 7733 RVA: 0x000067FE File Offset: 0x000049FE
		public virtual ControllerMap LoadControllerMap(int playerId, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
		{
			return null;
		}

		// Token: 0x06001E36 RID: 7734
		protected abstract void OnInitialize();

		// Token: 0x06001E37 RID: 7735
		protected abstract void OnControllerConnected(ControllerStatusChangedEventArgs args);

		// Token: 0x06001E38 RID: 7736
		protected abstract void OnControllerDisconnected(ControllerStatusChangedEventArgs args);

		// Token: 0x06001E39 RID: 7737 RVA: 0x00002FF9 File Offset: 0x000011F9
		[Obsolete("This method is deprecated and will be removed in a future version. Use OnControllerPreDisconnect instead.", false)]
		protected virtual void OnControllerPreDiscconnect(ControllerStatusChangedEventArgs args)
		{
		}

		// Token: 0x06001E3A RID: 7738 RVA: 0x00017B33 File Offset: 0x00015D33
		protected virtual void OnControllerPreDisconnect(ControllerStatusChangedEventArgs args)
		{
			this.OnControllerPreDiscconnect(args);
		}
	}
}
