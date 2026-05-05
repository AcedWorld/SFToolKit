using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Interfaces;

namespace Rewired.Platforms.Custom
{
	// Token: 0x0200021D RID: 541
	public abstract class CustomInputSource : IDisposable
	{
		// Token: 0x17000623 RID: 1571
		// (get) Token: 0x06001960 RID: 6496 RVA: 0x00014D54 File Offset: 0x00012F54
		// (set) Token: 0x06001961 RID: 6497 RVA: 0x00014D5C File Offset: 0x00012F5C
		public bool useApproximateMatching
		{
			get
			{
				return this.NvkhRErAhQetxTCQzeIpTIfJjiCEA;
			}
			protected set
			{
				this.NvkhRErAhQetxTCQzeIpTIfJjiCEA = value;
			}
		}

		// Token: 0x14000033 RID: 51
		// (add) Token: 0x06001962 RID: 6498 RVA: 0x00071518 File Offset: 0x0006F718
		// (remove) Token: 0x06001963 RID: 6499 RVA: 0x00071550 File Offset: 0x0006F750
		private event Action RFqIYFFsmsRUPlFlKDKgvdDZANNG;

		// Token: 0x14000034 RID: 52
		// (add) Token: 0x06001964 RID: 6500 RVA: 0x00071588 File Offset: 0x0006F788
		// (remove) Token: 0x06001965 RID: 6501 RVA: 0x000715C0 File Offset: 0x0006F7C0
		private event Action LWlCYwDtRpQOjqzaDxWzuMgtnFDzA;

		// Token: 0x14000035 RID: 53
		// (add) Token: 0x06001966 RID: 6502 RVA: 0x00014D65 File Offset: 0x00012F65
		// (remove) Token: 0x06001967 RID: 6503 RVA: 0x00014D6E File Offset: 0x00012F6E
		internal event Action OCIJgUKOfUZUGllNZnYTtQcWnVjP
		{
			add
			{
				this.RFqIYFFsmsRUPlFlKDKgvdDZANNG += value;
			}
			remove
			{
				this.RFqIYFFsmsRUPlFlKDKgvdDZANNG -= value;
			}
		}

		// Token: 0x14000036 RID: 54
		// (add) Token: 0x06001968 RID: 6504 RVA: 0x00014D77 File Offset: 0x00012F77
		// (remove) Token: 0x06001969 RID: 6505 RVA: 0x00014D80 File Offset: 0x00012F80
		internal event Action esBuenIcaDNTBCTlulCudoizNLJg
		{
			add
			{
				this.LWlCYwDtRpQOjqzaDxWzuMgtnFDzA += value;
			}
			remove
			{
				this.LWlCYwDtRpQOjqzaDxWzuMgtnFDzA -= value;
			}
		}

		// Token: 0x17000624 RID: 1572
		// (get) Token: 0x0600196A RID: 6506 RVA: 0x00014D89 File Offset: 0x00012F89
		internal InputSource gqmHoFRhzjEYMIkPKkmRVUsgxjpg
		{
			get
			{
				return this.wWdAeYbRjYMNWQycNfzllUGsoHYcA;
			}
		}

		// Token: 0x0600196B RID: 6507 RVA: 0x00014D91 File Offset: 0x00012F91
		internal IUnifiedKeyboardSource OYKCcFUDuoxxbZeLGHhfyyQhGsRf()
		{
			return this.dPkhiiJZKQaKjhArFdPTCqZVIOaCb;
		}

		// Token: 0x0600196C RID: 6508 RVA: 0x00014D99 File Offset: 0x00012F99
		internal IUnifiedMouseSource RoGrwwlaTTFqZxlGvVsoZGCktzSI()
		{
			return this.LuiQIzbhqiaQtcsrSBNWAWtARyYyA;
		}

		// Token: 0x0600196D RID: 6509 RVA: 0x000715F8 File Offset: 0x0006F7F8
		public CustomInputSource(int A_1)
		{
			if (!Enum.IsDefined(typeof(InputSource), A_1))
			{
				Logger.LogError("Unknown InputSource (" + A_1.ToString() + ")!");
			}
			this.wWdAeYbRjYMNWQycNfzllUGsoHYcA = (InputSource)A_1;
			this.KdPYAnHaEkvpAsMebHKJWqdYnbFN = new List<CustomInputSource.Joystick>();
			this.lGRWuFlXXqyEHNZvFGZXDjiZVxUC = new ReadOnlyCollection<CustomInputSource.Joystick>(this.KdPYAnHaEkvpAsMebHKJWqdYnbFN);
		}

		// Token: 0x0600196E RID: 6510 RVA: 0x00014DA1 File Offset: 0x00012FA1
		internal CustomInputSource(int A_1, IUnifiedKeyboardSource A_2, IUnifiedMouseSource A_3) : this(A_1)
		{
			this.dPkhiiJZKQaKjhArFdPTCqZVIOaCb = A_2;
			this.LuiQIzbhqiaQtcsrSBNWAWtARyYyA = A_3;
		}

		// Token: 0x0600196F RID: 6511 RVA: 0x00014DB8 File Offset: 0x00012FB8
		internal virtual void JLAerzKwkOEHiFXjkpSPmTPwZEIv()
		{
			this.OnInitialize();
		}

		// Token: 0x06001970 RID: 6512 RVA: 0x00002FF9 File Offset: 0x000011F9
		protected virtual void OnInitialize()
		{
		}

		// Token: 0x06001971 RID: 6513 RVA: 0x00071668 File Offset: 0x0006F868
		public void AddJoystick(CustomInputSource.Joystick joystick)
		{
			if (joystick == null)
			{
				return;
			}
			if (this.KdPYAnHaEkvpAsMebHKJWqdYnbFN.Contains(joystick))
			{
				Logger.LogWarning("The joystick is already in the list. Cannot add again.");
				return;
			}
			this.KdPYAnHaEkvpAsMebHKJWqdYnbFN.Add(joystick);
			joystick.ConnectedStateChangedEvent += this.MFivJlSuOqnnbUbzclVjfgehGZVk;
			if (joystick.isConnected)
			{
				this.OnJoystickConnected();
			}
		}

		// Token: 0x06001972 RID: 6514 RVA: 0x000716C0 File Offset: 0x0006F8C0
		public void RemoveJoystick(CustomInputSource.Joystick joystick)
		{
			if (joystick == null)
			{
				return;
			}
			if (!this.KdPYAnHaEkvpAsMebHKJWqdYnbFN.Contains(joystick))
			{
				Logger.LogWarning("The joystick was not found in the list. Cannot remove.");
				return;
			}
			this.KdPYAnHaEkvpAsMebHKJWqdYnbFN.Remove(joystick);
			joystick.ConnectedStateChangedEvent -= this.MFivJlSuOqnnbUbzclVjfgehGZVk;
			if (joystick.isConnected)
			{
				this.OnJoystickDisconnected();
			}
		}

		// Token: 0x06001973 RID: 6515 RVA: 0x00014DC0 File Offset: 0x00012FC0
		public IList<CustomInputSource.Joystick> GetJoysticks()
		{
			return this.lGRWuFlXXqyEHNZvFGZXDjiZVxUC;
		}

		// Token: 0x06001974 RID: 6516 RVA: 0x00014DC8 File Offset: 0x00012FC8
		protected virtual void OnJoystickConnected()
		{
			if (this.RFqIYFFsmsRUPlFlKDKgvdDZANNG != null)
			{
				this.RFqIYFFsmsRUPlFlKDKgvdDZANNG();
			}
		}

		// Token: 0x06001975 RID: 6517 RVA: 0x00014DDD File Offset: 0x00012FDD
		protected virtual void OnJoystickDisconnected()
		{
			if (this.LWlCYwDtRpQOjqzaDxWzuMgtnFDzA != null)
			{
				this.LWlCYwDtRpQOjqzaDxWzuMgtnFDzA();
			}
		}

		// Token: 0x06001976 RID: 6518 RVA: 0x00014DF2 File Offset: 0x00012FF2
		private void MFivJlSuOqnnbUbzclVjfgehGZVk(bool A_1)
		{
			if (A_1)
			{
				this.OnJoystickConnected();
				return;
			}
			this.OnJoystickDisconnected();
		}

		// Token: 0x06001977 RID: 6519 RVA: 0x00071718 File Offset: 0x0006F918
		internal CustomInputSource.Joystick[] WDGbOlKfyvSlsCRXyhZoaKzfxZYqB()
		{
			List<CustomInputSource.Joystick> list = new List<CustomInputSource.Joystick>(this.KdPYAnHaEkvpAsMebHKJWqdYnbFN.Count);
			for (int i = 0; i < this.KdPYAnHaEkvpAsMebHKJWqdYnbFN.Count; i++)
			{
				CustomInputSource.Joystick joystick = this.KdPYAnHaEkvpAsMebHKJWqdYnbFN[i];
				if (joystick != null && joystick.isConnected)
				{
					list.Add(joystick);
				}
			}
			return list.ToArray();
		}

		// Token: 0x06001978 RID: 6520 RVA: 0x00002FF9 File Offset: 0x000011F9
		internal virtual void pkUAzDKcsykDawzPXDyONdNaTfuU()
		{
		}

		// Token: 0x06001979 RID: 6521 RVA: 0x00014E04 File Offset: 0x00013004
		public virtual void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600197A RID: 6522 RVA: 0x00071774 File Offset: 0x0006F974
		~CustomInputSource()
		{
			this.Dispose(false);
		}

		// Token: 0x0600197B RID: 6523 RVA: 0x000717A4 File Offset: 0x0006F9A4
		protected virtual void Dispose(bool disposing)
		{
			if (this.fcAbWOGYOnXAyRloJNlzYuIfQKd)
			{
				return;
			}
			if (disposing)
			{
				if (this.dPkhiiJZKQaKjhArFdPTCqZVIOaCb is IDisposable)
				{
					try
					{
						(this.dPkhiiJZKQaKjhArFdPTCqZVIOaCb as IDisposable).Dispose();
					}
					catch (Exception msg)
					{
						Logger.LogError(msg);
					}
				}
				if (this.LuiQIzbhqiaQtcsrSBNWAWtARyYyA is IDisposable)
				{
					try
					{
						(this.LuiQIzbhqiaQtcsrSBNWAWtARyYyA as IDisposable).Dispose();
					}
					catch (Exception msg2)
					{
						Logger.LogError(msg2);
					}
				}
			}
			this.fcAbWOGYOnXAyRloJNlzYuIfQKd = true;
		}

		// Token: 0x17000625 RID: 1573
		// (get) Token: 0x0600197C RID: 6524
		public abstract bool isReady { get; }

		// Token: 0x0600197D RID: 6525
		public abstract void Update();

		// Token: 0x04000E8B RID: 3723
		private readonly InputSource wWdAeYbRjYMNWQycNfzllUGsoHYcA;

		// Token: 0x04000E8C RID: 3724
		private readonly List<CustomInputSource.Joystick> KdPYAnHaEkvpAsMebHKJWqdYnbFN;

		// Token: 0x04000E8D RID: 3725
		private readonly ReadOnlyCollection<CustomInputSource.Joystick> lGRWuFlXXqyEHNZvFGZXDjiZVxUC;

		// Token: 0x04000E8E RID: 3726
		private bool NvkhRErAhQetxTCQzeIpTIfJjiCEA = true;

		// Token: 0x04000E8F RID: 3727
		private IUnifiedKeyboardSource dPkhiiJZKQaKjhArFdPTCqZVIOaCb;

		// Token: 0x04000E90 RID: 3728
		private IUnifiedMouseSource LuiQIzbhqiaQtcsrSBNWAWtARyYyA;

		// Token: 0x04000E93 RID: 3731
		private bool fcAbWOGYOnXAyRloJNlzYuIfQKd;

		// Token: 0x0200021E RID: 542
		public abstract class Controller
		{
			// Token: 0x14000037 RID: 55
			// (add) Token: 0x0600197E RID: 6526 RVA: 0x00014E13 File Offset: 0x00013013
			// (remove) Token: 0x0600197F RID: 6527 RVA: 0x00014E2C File Offset: 0x0001302C
			public event Action<bool> ConnectedStateChangedEvent
			{
				add
				{
					this.OxnjSmNcvlJSzHwxTfRcLqBXMoVh = (Action<bool>)Delegate.Combine(this.OxnjSmNcvlJSzHwxTfRcLqBXMoVh, value);
				}
				remove
				{
					this.OxnjSmNcvlJSzHwxTfRcLqBXMoVh = (Action<bool>)Delegate.Remove(this.OxnjSmNcvlJSzHwxTfRcLqBXMoVh, value);
				}
			}

			// Token: 0x17000626 RID: 1574
			// (get) Token: 0x06001980 RID: 6528 RVA: 0x00014E45 File Offset: 0x00013045
			public string customName
			{
				get
				{
					return this._customName;
				}
			}

			// Token: 0x17000627 RID: 1575
			// (get) Token: 0x06001981 RID: 6529 RVA: 0x00014E4D File Offset: 0x0001304D
			// (set) Token: 0x06001982 RID: 6530 RVA: 0x0007182C File Offset: 0x0006FA2C
			public bool isConnected
			{
				get
				{
					return this._isConnected;
				}
				set
				{
					if (value == this._isConnected)
					{
						return;
					}
					this._isConnected = value;
					Action<bool> oxnjSmNcvlJSzHwxTfRcLqBXMoVh = this.OxnjSmNcvlJSzHwxTfRcLqBXMoVh;
					if (oxnjSmNcvlJSzHwxTfRcLqBXMoVh != null)
					{
						try
						{
							oxnjSmNcvlJSzHwxTfRcLqBXMoVh(value);
						}
						catch (Exception exception)
						{
							ReInput.HandleCallbackException("CustomInputSource.Controller.ConnectedStateChangedEvent", exception);
						}
					}
				}
			}

			// Token: 0x17000628 RID: 1576
			// (get) Token: 0x06001983 RID: 6531 RVA: 0x00014E55 File Offset: 0x00013055
			public string deviceName
			{
				get
				{
					return this._deviceName;
				}
			}

			// Token: 0x17000629 RID: 1577
			// (get) Token: 0x06001984 RID: 6532 RVA: 0x00014E5D File Offset: 0x0001305D
			// (set) Token: 0x06001985 RID: 6533 RVA: 0x00014E65 File Offset: 0x00013065
			public object customIdentifier
			{
				get
				{
					return this._customIdentifier;
				}
				set
				{
					this._customIdentifier = value;
				}
			}

			// Token: 0x1700062A RID: 1578
			// (get) Token: 0x06001986 RID: 6534 RVA: 0x00014E6E File Offset: 0x0001306E
			// (set) Token: 0x06001987 RID: 6535 RVA: 0x00014E76 File Offset: 0x00013076
			public Guid deviceInstanceGuid
			{
				get
				{
					return this._persistentGuid;
				}
				set
				{
					this._persistentGuid = value;
				}
			}

			// Token: 0x06001988 RID: 6536 RVA: 0x00014E7F File Offset: 0x0001307F
			protected Controller(string A_1)
			{
				this._deviceName = A_1;
			}

			// Token: 0x06001989 RID: 6537 RVA: 0x00014E8E File Offset: 0x0001308E
			public void Disconnect()
			{
				if (!this._isConnected)
				{
					return;
				}
				this.isConnected = false;
			}

			// Token: 0x0600198A RID: 6538 RVA: 0x00014EA0 File Offset: 0x000130A0
			public void Connect()
			{
				if (this._isConnected)
				{
					return;
				}
				this.isConnected = true;
			}

			// Token: 0x0600198B RID: 6539
			public abstract void Update();

			// Token: 0x04000E94 RID: 3732
			protected bool _isConnected;

			// Token: 0x04000E95 RID: 3733
			protected string _deviceName;

			// Token: 0x04000E96 RID: 3734
			protected string _customName;

			// Token: 0x04000E97 RID: 3735
			protected object _customIdentifier;

			// Token: 0x04000E98 RID: 3736
			protected Guid _persistentGuid;

			// Token: 0x04000E99 RID: 3737
			private Action<bool> OxnjSmNcvlJSzHwxTfRcLqBXMoVh;
		}

		// Token: 0x0200021F RID: 543
		public abstract class Joystick : CustomInputSource.Controller
		{
			// Token: 0x1700062B RID: 1579
			// (get) Token: 0x0600198C RID: 6540 RVA: 0x00014EB2 File Offset: 0x000130B2
			// (set) Token: 0x0600198D RID: 6541 RVA: 0x00014EBA File Offset: 0x000130BA
			public long? systemId
			{
				get
				{
					return this.TTHvjQtaqBPsguOsACitwMMigmFy;
				}
				protected set
				{
					this.TTHvjQtaqBPsguOsACitwMMigmFy = value;
				}
			}

			// Token: 0x1700062C RID: 1580
			// (get) Token: 0x0600198E RID: 6542 RVA: 0x00014EC3 File Offset: 0x000130C3
			// (set) Token: 0x0600198F RID: 6543 RVA: 0x00014ECB File Offset: 0x000130CB
			public int unityId
			{
				get
				{
					return this.zWTiXKisjTLAQWwoHWALIctVyegB;
				}
				protected set
				{
					this.zWTiXKisjTLAQWwoHWALIctVyegB = value;
				}
			}

			// Token: 0x1700062D RID: 1581
			// (get) Token: 0x06001990 RID: 6544 RVA: 0x00014ED4 File Offset: 0x000130D4
			public IList<CustomInputSource.Axis> Axes
			{
				get
				{
					return this.wbXAaRHDTVDyRrzpJqvgKwndAtjBA;
				}
			}

			// Token: 0x1700062E RID: 1582
			// (get) Token: 0x06001991 RID: 6545 RVA: 0x00014EDC File Offset: 0x000130DC
			public IList<CustomInputSource.Button> Buttons
			{
				get
				{
					return this.JPIcnVGzFzgEmRvPcjeWAaHDZEFLB;
				}
			}

			// Token: 0x1700062F RID: 1583
			// (get) Token: 0x06001992 RID: 6546 RVA: 0x00014EE4 File Offset: 0x000130E4
			// (set) Token: 0x06001993 RID: 6547 RVA: 0x00014EEC File Offset: 0x000130EC
			public bool supportsVibration
			{
				get
				{
					return this.KCCMjxyWWCspZlffQYnbBAKjVwTF;
				}
				set
				{
					this.KCCMjxyWWCspZlffQYnbBAKjVwTF = value;
				}
			}

			// Token: 0x17000630 RID: 1584
			// (get) Token: 0x06001994 RID: 6548 RVA: 0x00014EF5 File Offset: 0x000130F5
			// (set) Token: 0x06001995 RID: 6549 RVA: 0x00014EFD File Offset: 0x000130FD
			public Rewired.Controller.Extension extension
			{
				get
				{
					return this.RmCOBbjNwQVnCxLayPLiXeVHZyVH;
				}
				set
				{
					this.RmCOBbjNwQVnCxLayPLiXeVHZyVH = value;
					if (this.RmCOBbjNwQVnCxLayPLiXeVHZyVH is IControllerVibrator)
					{
						this.KCCMjxyWWCspZlffQYnbBAKjVwTF = true;
					}
				}
			}

			// Token: 0x17000631 RID: 1585
			// (get) Token: 0x06001996 RID: 6550 RVA: 0x00014F1A File Offset: 0x0001311A
			public int buttonCount
			{
				get
				{
					return this.ZEvTcNVJbnSSrEnmRMalyczhUJMT.Length;
				}
			}

			// Token: 0x17000632 RID: 1586
			// (get) Token: 0x06001997 RID: 6551 RVA: 0x00014F24 File Offset: 0x00013124
			public int axisCount
			{
				get
				{
					return this.PIVmiBkkUftGgqgzunpYHcdFiscV.Length;
				}
			}

			// Token: 0x06001998 RID: 6552 RVA: 0x00014F2E File Offset: 0x0001312E
			protected Joystick(string A_1, long A_2, int A_3, int A_4) : this(A_1, new long?(A_2), 0, A_3, A_4)
			{
			}

			// Token: 0x06001999 RID: 6553 RVA: 0x0007187C File Offset: 0x0006FA7C
			public Joystick(string A_1, long? A_2, int A_3, int A_4, int A_5) : base(A_1)
			{
				if (A_4 < 0)
				{
					A_4 = 0;
				}
				if (A_5 < 0)
				{
					A_5 = 0;
				}
				this.TTHvjQtaqBPsguOsACitwMMigmFy = A_2;
				this.zWTiXKisjTLAQWwoHWALIctVyegB = A_3;
				this.PIVmiBkkUftGgqgzunpYHcdFiscV = new CustomInputSource.Axis[A_4];
				this.ZEvTcNVJbnSSrEnmRMalyczhUJMT = new CustomInputSource.Button[A_5];
				for (int i = 0; i < A_4; i++)
				{
					this.PIVmiBkkUftGgqgzunpYHcdFiscV[i] = new CustomInputSource.Axis();
				}
				for (int j = 0; j < A_5; j++)
				{
					this.ZEvTcNVJbnSSrEnmRMalyczhUJMT[j] = new CustomInputSource.Button();
				}
				this.wbXAaRHDTVDyRrzpJqvgKwndAtjBA = new ReadOnlyCollection<CustomInputSource.Axis>(this.PIVmiBkkUftGgqgzunpYHcdFiscV);
				this.JPIcnVGzFzgEmRvPcjeWAaHDZEFLB = new ReadOnlyCollection<CustomInputSource.Button>(this.ZEvTcNVJbnSSrEnmRMalyczhUJMT);
			}

			// Token: 0x0600199A RID: 6554 RVA: 0x00014F41 File Offset: 0x00013141
			public virtual float GetAxisValue(int index)
			{
				if (index < 0 || index >= this.PIVmiBkkUftGgqgzunpYHcdFiscV.Length)
				{
					return 0f;
				}
				return this.PIVmiBkkUftGgqgzunpYHcdFiscV[index].value;
			}

			// Token: 0x0600199B RID: 6555 RVA: 0x00014F65 File Offset: 0x00013165
			public virtual bool GetButtonValue(int index)
			{
				return index >= 0 && index < this.ZEvTcNVJbnSSrEnmRMalyczhUJMT.Length && this.ZEvTcNVJbnSSrEnmRMalyczhUJMT[index].boolValue;
			}

			// Token: 0x0600199C RID: 6556 RVA: 0x00014F85 File Offset: 0x00013185
			public virtual float GetButtonFloatValue(int index)
			{
				if (index < 0 || index >= this.ZEvTcNVJbnSSrEnmRMalyczhUJMT.Length)
				{
					return 0f;
				}
				return this.ZEvTcNVJbnSSrEnmRMalyczhUJMT[index].floatValue;
			}

			// Token: 0x0600199D RID: 6557 RVA: 0x00014FA9 File Offset: 0x000131A9
			public virtual void SetAxisValue(int index, float value)
			{
				if (index < 0 || index >= this.PIVmiBkkUftGgqgzunpYHcdFiscV.Length)
				{
					return;
				}
				this.PIVmiBkkUftGgqgzunpYHcdFiscV[index].value = value;
			}

			// Token: 0x0600199E RID: 6558 RVA: 0x00014FC9 File Offset: 0x000131C9
			public virtual void SetButtonValue(int index, bool value)
			{
				if (index < 0 || index >= this.ZEvTcNVJbnSSrEnmRMalyczhUJMT.Length)
				{
					return;
				}
				this.ZEvTcNVJbnSSrEnmRMalyczhUJMT[index].boolValue = value;
			}

			// Token: 0x0600199F RID: 6559 RVA: 0x00014FE9 File Offset: 0x000131E9
			public virtual void SetButtonFloatValue(int index, float value)
			{
				if (index < 0 || index >= this.ZEvTcNVJbnSSrEnmRMalyczhUJMT.Length)
				{
					return;
				}
				this.ZEvTcNVJbnSSrEnmRMalyczhUJMT[index].floatValue = value;
			}

			// Token: 0x060019A0 RID: 6560 RVA: 0x00015009 File Offset: 0x00013209
			internal void rnUAqEHMzdnSQgQvgOybSnKdmHyr(int A_1, out bool A_2, out float A_3)
			{
				if (A_1 < 0 || A_1 >= this.ZEvTcNVJbnSSrEnmRMalyczhUJMT.Length)
				{
					A_2 = false;
					A_3 = 0f;
					return;
				}
				A_2 = this.ZEvTcNVJbnSSrEnmRMalyczhUJMT[A_1].OqLnAQeIOIjPqfjOBEYvAkBCqyqaB;
				A_3 = this.ZEvTcNVJbnSSrEnmRMalyczhUJMT[A_1].floatValue;
			}

			// Token: 0x060019A1 RID: 6561 RVA: 0x00071920 File Offset: 0x0006FB20
			internal virtual void eEaDExzqnDgLWQgylYwrAzNWKbBK()
			{
				for (int i = 0; i < this.ZEvTcNVJbnSSrEnmRMalyczhUJMT.Length; i++)
				{
					if (this.ZEvTcNVJbnSSrEnmRMalyczhUJMT[i] != null)
					{
						this.ZEvTcNVJbnSSrEnmRMalyczhUJMT[i].JLCdyhaLnzBzigRFBaIeHPkmtbBfb();
					}
				}
			}

			// Token: 0x04000E9A RID: 3738
			private long? TTHvjQtaqBPsguOsACitwMMigmFy;

			// Token: 0x04000E9B RID: 3739
			private int zWTiXKisjTLAQWwoHWALIctVyegB;

			// Token: 0x04000E9C RID: 3740
			private readonly CustomInputSource.Axis[] PIVmiBkkUftGgqgzunpYHcdFiscV;

			// Token: 0x04000E9D RID: 3741
			private readonly CustomInputSource.Button[] ZEvTcNVJbnSSrEnmRMalyczhUJMT;

			// Token: 0x04000E9E RID: 3742
			private readonly ReadOnlyCollection<CustomInputSource.Axis> wbXAaRHDTVDyRrzpJqvgKwndAtjBA;

			// Token: 0x04000E9F RID: 3743
			private readonly ReadOnlyCollection<CustomInputSource.Button> JPIcnVGzFzgEmRvPcjeWAaHDZEFLB;

			// Token: 0x04000EA0 RID: 3744
			private bool KCCMjxyWWCspZlffQYnbBAKjVwTF;

			// Token: 0x04000EA1 RID: 3745
			private Rewired.Controller.Extension RmCOBbjNwQVnCxLayPLiXeVHZyVH;
		}

		// Token: 0x02000220 RID: 544
		public abstract class Element
		{
		}

		// Token: 0x02000221 RID: 545
		public sealed class Axis : CustomInputSource.Element
		{
			// Token: 0x04000EA2 RID: 3746
			public float value;
		}

		// Token: 0x02000222 RID: 546
		public sealed class Button : CustomInputSource.Element
		{
			// Token: 0x17000633 RID: 1587
			// (get) Token: 0x060019A4 RID: 6564 RVA: 0x0001504B File Offset: 0x0001324B
			// (set) Token: 0x060019A5 RID: 6565 RVA: 0x00015053 File Offset: 0x00013253
			public bool boolValue
			{
				get
				{
					return this.value;
				}
				set
				{
					bool flag = this.value;
					if (!this.value && value)
					{
						this.VxLChnHEgIgPGzSbGAJdTsXlsxhM = true;
					}
					this.value = value;
				}
			}

			// Token: 0x17000634 RID: 1588
			// (get) Token: 0x060019A6 RID: 6566 RVA: 0x00015077 File Offset: 0x00013277
			// (set) Token: 0x060019A7 RID: 6567 RVA: 0x0001507F File Offset: 0x0001327F
			public float floatValue
			{
				get
				{
					return this.yAJOIZYeVRVlQvsizfWoffmQvpOK;
				}
				set
				{
					this.yAJOIZYeVRVlQvsizfWoffmQvpOK = value;
				}
			}

			// Token: 0x17000635 RID: 1589
			// (get) Token: 0x060019A8 RID: 6568 RVA: 0x00015088 File Offset: 0x00013288
			internal bool OqLnAQeIOIjPqfjOBEYvAkBCqyqaB
			{
				get
				{
					return this.value || this.VxLChnHEgIgPGzSbGAJdTsXlsxhM;
				}
			}

			// Token: 0x060019A9 RID: 6569 RVA: 0x0001509A File Offset: 0x0001329A
			internal void JLCdyhaLnzBzigRFBaIeHPkmtbBfb()
			{
				this.VxLChnHEgIgPGzSbGAJdTsXlsxhM = false;
			}

			// Token: 0x04000EA3 RID: 3747
			[Obsolete("Deprecated. Use boolValue instead.", false)]
			public bool value;

			// Token: 0x04000EA4 RID: 3748
			private float yAJOIZYeVRVlQvsizfWoffmQvpOK;

			// Token: 0x04000EA5 RID: 3749
			private bool VxLChnHEgIgPGzSbGAJdTsXlsxhM;
		}
	}
}
