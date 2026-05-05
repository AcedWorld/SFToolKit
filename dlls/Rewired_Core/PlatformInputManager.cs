using System;
using Rewired.Interfaces;

namespace Rewired
{
	// Token: 0x0200001B RID: 27
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal abstract class PlatformInputManager
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600016F RID: 367 RVA: 0x000035B7 File Offset: 0x000017B7
		// (remove) Token: 0x06000170 RID: 368 RVA: 0x000035D0 File Offset: 0x000017D0
		[CustomObfuscation(rename = false)]
		public event Action<BridgedController> DeviceConnectedEvent
		{
			add
			{
				this._DeviceConnectedEvent = (Action<BridgedController>)Delegate.Combine(this._DeviceConnectedEvent, value);
			}
			remove
			{
				this._DeviceConnectedEvent = (Action<BridgedController>)Delegate.Remove(this._DeviceConnectedEvent, value);
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000171 RID: 369 RVA: 0x000035E9 File Offset: 0x000017E9
		// (remove) Token: 0x06000172 RID: 370 RVA: 0x00003602 File Offset: 0x00001802
		[CustomObfuscation(rename = false)]
		public event Action<ControllerDisconnectedEventArgs> DeviceDisconnectedEvent
		{
			add
			{
				this._DeviceDisconnectedEvent = (Action<ControllerDisconnectedEventArgs>)Delegate.Combine(this._DeviceDisconnectedEvent, value);
			}
			remove
			{
				this._DeviceDisconnectedEvent = (Action<ControllerDisconnectedEventArgs>)Delegate.Remove(this._DeviceDisconnectedEvent, value);
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000173 RID: 371 RVA: 0x0000361B File Offset: 0x0000181B
		// (remove) Token: 0x06000174 RID: 372 RVA: 0x00003634 File Offset: 0x00001834
		[CustomObfuscation(rename = false)]
		public event Action<UpdateControllerInfoEventArgs> UpdateControllerInfoEvent
		{
			add
			{
				this._UpdateControllerInfoEvent = (Action<UpdateControllerInfoEventArgs>)Delegate.Combine(this._UpdateControllerInfoEvent, value);
			}
			remove
			{
				this._UpdateControllerInfoEvent = (Action<UpdateControllerInfoEventArgs>)Delegate.Remove(this._UpdateControllerInfoEvent, value);
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000175 RID: 373 RVA: 0x0000364D File Offset: 0x0000184D
		// (remove) Token: 0x06000176 RID: 374 RVA: 0x00003666 File Offset: 0x00001866
		[CustomObfuscation(rename = false)]
		public event Action SystemDeviceConnectedEvent
		{
			add
			{
				this._SystemDeviceConnectedEvent = (Action)Delegate.Combine(this._SystemDeviceConnectedEvent, value);
			}
			remove
			{
				this._SystemDeviceConnectedEvent = (Action)Delegate.Remove(this._SystemDeviceConnectedEvent, value);
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000177 RID: 375 RVA: 0x0000367F File Offset: 0x0000187F
		// (remove) Token: 0x06000178 RID: 376 RVA: 0x00003698 File Offset: 0x00001898
		[CustomObfuscation(rename = false)]
		public event Action SystemDeviceDisconnectedEvent
		{
			add
			{
				this._SystemDeviceDisconnectedEvent = (Action)Delegate.Combine(this._SystemDeviceDisconnectedEvent, value);
			}
			remove
			{
				this._SystemDeviceDisconnectedEvent = (Action)Delegate.Remove(this._SystemDeviceDisconnectedEvent, value);
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000179 RID: 377
		public abstract int deviceCount { get; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600017A RID: 378
		public abstract PlatformInputManager primaryInputManager { get; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600017B RID: 379
		public abstract IInputSource inputSource { get; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600017C RID: 380
		public abstract InputSource inputSourceType { get; }

		// Token: 0x0600017D RID: 381
		public abstract void Initialize();

		// Token: 0x0600017E RID: 382
		public abstract void Update(UpdateLoopType currentUpdateLoop);

		// Token: 0x0600017F RID: 383
		public abstract void OnDestroy();

		// Token: 0x06000180 RID: 384
		public abstract void SystemDeviceConnected();

		// Token: 0x06000181 RID: 385
		public abstract void SystemDeviceDisconnected();

		// Token: 0x06000182 RID: 386
		public abstract void UpdateControllerData(int controllerId, ControllerDataUpdater data);

		// Token: 0x06000183 RID: 387
		public abstract Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate();

		// Token: 0x06000184 RID: 388
		public abstract void SetUnityJoystickId(int joystickId, int unityJoystickId);

		// Token: 0x06000185 RID: 389
		public abstract IUnifiedMouseSource GetUnifiedMouseSource();

		// Token: 0x06000186 RID: 390
		public abstract IUnifiedKeyboardSource GetUnifiedKeyboardSource();

		// Token: 0x04000092 RID: 146
		protected Action<BridgedController> _DeviceConnectedEvent;

		// Token: 0x04000093 RID: 147
		protected Action<ControllerDisconnectedEventArgs> _DeviceDisconnectedEvent;

		// Token: 0x04000094 RID: 148
		protected Action<UpdateControllerInfoEventArgs> _UpdateControllerInfoEvent;

		// Token: 0x04000095 RID: 149
		protected Action _SystemDeviceConnectedEvent;

		// Token: 0x04000096 RID: 150
		protected Action _SystemDeviceDisconnectedEvent;
	}
}
