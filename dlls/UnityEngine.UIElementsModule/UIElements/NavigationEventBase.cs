using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000201 RID: 513
	[EventCategory(EventCategory.Navigation)]
	public abstract class NavigationEventBase<T> : EventBase<T>, INavigationEvent where T : NavigationEventBase<T>, new()
	{
		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06000F15 RID: 3861 RVA: 0x000389B3 File Offset: 0x00036BB3
		// (set) Token: 0x06000F16 RID: 3862 RVA: 0x000389BB File Offset: 0x00036BBB
		public EventModifiers modifiers { get; protected set; }

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x06000F17 RID: 3863 RVA: 0x000389C4 File Offset: 0x00036BC4
		public bool shiftKey
		{
			get
			{
				return (this.modifiers & EventModifiers.Shift) > EventModifiers.None;
			}
		}

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06000F18 RID: 3864 RVA: 0x000389E4 File Offset: 0x00036BE4
		public bool ctrlKey
		{
			get
			{
				return (this.modifiers & EventModifiers.Control) > EventModifiers.None;
			}
		}

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x06000F19 RID: 3865 RVA: 0x00038A04 File Offset: 0x00036C04
		public bool commandKey
		{
			get
			{
				return (this.modifiers & EventModifiers.Command) > EventModifiers.None;
			}
		}

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06000F1A RID: 3866 RVA: 0x00038A24 File Offset: 0x00036C24
		public bool altKey
		{
			get
			{
				return (this.modifiers & EventModifiers.Alt) > EventModifiers.None;
			}
		}

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x06000F1B RID: 3867 RVA: 0x00038A44 File Offset: 0x00036C44
		public bool actionKey
		{
			get
			{
				bool flag = Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer;
				bool result;
				if (flag)
				{
					result = this.commandKey;
				}
				else
				{
					result = this.ctrlKey;
				}
				return result;
			}
		}

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x06000F1C RID: 3868 RVA: 0x00038A7D File Offset: 0x00036C7D
		NavigationDeviceType INavigationEvent.deviceType
		{
			get
			{
				return this.deviceType;
			}
		}

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x06000F1D RID: 3869 RVA: 0x00038A85 File Offset: 0x00036C85
		// (set) Token: 0x06000F1E RID: 3870 RVA: 0x00038A8D File Offset: 0x00036C8D
		internal NavigationDeviceType deviceType { get; private set; }

		// Token: 0x06000F1F RID: 3871 RVA: 0x00038A96 File Offset: 0x00036C96
		protected NavigationEventBase()
		{
			this.LocalInit();
		}

		// Token: 0x06000F20 RID: 3872 RVA: 0x00038AA7 File Offset: 0x00036CA7
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000F21 RID: 3873 RVA: 0x00038AB8 File Offset: 0x00036CB8
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown | EventBase.EventPropagation.Cancellable | EventBase.EventPropagation.SkipDisabledElements);
			base.propagateToIMGUI = false;
			this.modifiers = EventModifiers.None;
			this.deviceType = NavigationDeviceType.Unknown;
		}

		// Token: 0x06000F22 RID: 3874 RVA: 0x00038ADC File Offset: 0x00036CDC
		public static T GetPooled(EventModifiers modifiers = EventModifiers.None)
		{
			T pooled = EventBase<T>.GetPooled();
			pooled.modifiers = modifiers;
			pooled.deviceType = NavigationDeviceType.Unknown;
			return pooled;
		}

		// Token: 0x06000F23 RID: 3875 RVA: 0x00038B10 File Offset: 0x00036D10
		internal static T GetPooled(NavigationDeviceType deviceType, EventModifiers modifiers = EventModifiers.None)
		{
			T pooled = EventBase<T>.GetPooled();
			pooled.modifiers = modifiers;
			pooled.deviceType = deviceType;
			return pooled;
		}
	}
}
