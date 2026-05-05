using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using UnityEngine;
using UnityEngine.Events;

namespace Rewired.Components
{
	// Token: 0x020003D1 RID: 977
	[AddComponentMenu("Rewired/Player Controllers/Player Controller")]
	[Serializable]
	public class PlayerController : ComponentWrapper<PlayerController>, IPlayerController
	{
		// Token: 0x17000922 RID: 2338
		// (get) Token: 0x060026E7 RID: 9959 RVA: 0x0001CF5E File Offset: 0x0001B15E
		// (set) Token: 0x060026E8 RID: 9960 RVA: 0x00094BC0 File Offset: 0x00092DC0
		public int playerId
		{
			get
			{
				if (!base.initialized)
				{
					return this._playerId;
				}
				return base.source.playerId;
			}
			set
			{
				if (ReInput.isReady && ReInput.players.GetPlayer(value) == null)
				{
					Logger.LogWarning("Player id " + value.ToString() + " does not exist.");
					return;
				}
				this._playerId = value;
				if (base.initialized)
				{
					base.source.playerId = value;
				}
			}
		}

		// Token: 0x17000923 RID: 2339
		// (get) Token: 0x060026E9 RID: 9961 RVA: 0x0001CF7A File Offset: 0x0001B17A
		public IList<PlayerController.Button> buttons
		{
			get
			{
				if (!base.initialized)
				{
					return EmptyObjects<PlayerController.Button>.EmptyReadOnlyIListT;
				}
				return base.source.buttons;
			}
		}

		// Token: 0x17000924 RID: 2340
		// (get) Token: 0x060026EA RID: 9962 RVA: 0x0001CF95 File Offset: 0x0001B195
		public IList<PlayerController.Axis> axes
		{
			get
			{
				if (!base.initialized)
				{
					return EmptyObjects<PlayerController.Axis>.EmptyReadOnlyIListT;
				}
				return base.source.axes;
			}
		}

		// Token: 0x17000925 RID: 2341
		// (get) Token: 0x060026EB RID: 9963 RVA: 0x0001CFB0 File Offset: 0x0001B1B0
		public IList<PlayerController.Element> elements
		{
			get
			{
				if (!base.initialized)
				{
					return EmptyObjects<PlayerController.Element>.EmptyReadOnlyIListT;
				}
				return base.source.elements;
			}
		}

		// Token: 0x17000926 RID: 2342
		// (get) Token: 0x060026EC RID: 9964 RVA: 0x0001CFCB File Offset: 0x0001B1CB
		public int buttonCount
		{
			get
			{
				if (!base.initialized)
				{
					return 0;
				}
				return base.source.buttonCount;
			}
		}

		// Token: 0x17000927 RID: 2343
		// (get) Token: 0x060026ED RID: 9965 RVA: 0x0001CFE2 File Offset: 0x0001B1E2
		public int axisCount
		{
			get
			{
				if (!base.initialized)
				{
					return 0;
				}
				return base.source.axisCount;
			}
		}

		// Token: 0x17000928 RID: 2344
		// (get) Token: 0x060026EE RID: 9966 RVA: 0x0001CFF9 File Offset: 0x0001B1F9
		public int elementCount
		{
			get
			{
				if (!base.initialized)
				{
					return 0;
				}
				return base.source.elementCount;
			}
		}

		// Token: 0x14000038 RID: 56
		// (add) Token: 0x060026EF RID: 9967 RVA: 0x0001D010 File Offset: 0x0001B210
		// (remove) Token: 0x060026F0 RID: 9968 RVA: 0x0001D027 File Offset: 0x0001B227
		public event Action<int, bool> ButtonStateChangedEvent
		{
			add
			{
				if (!base.initialized)
				{
					return;
				}
				base.source.ButtonStateChangedEvent += value;
			}
			remove
			{
				if (!base.initialized)
				{
					return;
				}
				base.source.ButtonStateChangedEvent -= value;
			}
		}

		// Token: 0x14000039 RID: 57
		// (add) Token: 0x060026F1 RID: 9969 RVA: 0x0001D03E File Offset: 0x0001B23E
		// (remove) Token: 0x060026F2 RID: 9970 RVA: 0x0001D055 File Offset: 0x0001B255
		public event Action<int, float> AxisValueChangedEvent
		{
			add
			{
				if (!base.initialized)
				{
					return;
				}
				base.source.AxisValueChangedEvent += value;
			}
			remove
			{
				if (!base.initialized)
				{
					return;
				}
				base.source.AxisValueChangedEvent -= value;
			}
		}

		// Token: 0x1400003A RID: 58
		// (add) Token: 0x060026F3 RID: 9971 RVA: 0x0001D06C File Offset: 0x0001B26C
		// (remove) Token: 0x060026F4 RID: 9972 RVA: 0x0001D083 File Offset: 0x0001B283
		public event Action<bool> EnabledStateChangedEvent
		{
			add
			{
				if (!base.initialized)
				{
					return;
				}
				base.source.EnabledStateChangedEvent += value;
			}
			remove
			{
				if (!base.initialized)
				{
					return;
				}
				base.source.EnabledStateChangedEvent -= value;
			}
		}

		// Token: 0x060026F5 RID: 9973 RVA: 0x0001D09A File Offset: 0x0001B29A
		public bool GetButton(int index)
		{
			return base.initialized && base.source.GetButton(index);
		}

		// Token: 0x060026F6 RID: 9974 RVA: 0x0001D0B2 File Offset: 0x0001B2B2
		public bool GetButtonDown(int index)
		{
			return base.initialized && base.source.GetButtonDown(index);
		}

		// Token: 0x060026F7 RID: 9975 RVA: 0x0001D0CA File Offset: 0x0001B2CA
		public bool GetButtonUp(int index)
		{
			return base.initialized && base.source.GetButtonUp(index);
		}

		// Token: 0x060026F8 RID: 9976 RVA: 0x0001D0E2 File Offset: 0x0001B2E2
		public float GetAxis(int index)
		{
			if (!base.initialized)
			{
				return 0f;
			}
			return base.source.GetAxis(index);
		}

		// Token: 0x060026F9 RID: 9977 RVA: 0x0001D0FE File Offset: 0x0001B2FE
		public float GetAxisRaw(int index)
		{
			if (!base.initialized)
			{
				return 0f;
			}
			return base.source.GetAxisRaw(index);
		}

		// Token: 0x060026FA RID: 9978 RVA: 0x0001D11A File Offset: 0x0001B31A
		public PlayerController.Element GetElement(int index)
		{
			if (!base.initialized)
			{
				return null;
			}
			return base.source.GetElement(index);
		}

		// Token: 0x060026FB RID: 9979 RVA: 0x00094C18 File Offset: 0x00092E18
		public T GetElement<T>(int index) where T : PlayerController.Element
		{
			if (!base.initialized)
			{
				return default(T);
			}
			return base.source.GetElement<T>(index);
		}

		// Token: 0x060026FC RID: 9980 RVA: 0x0001D132 File Offset: 0x0001B332
		protected override void OnAwake()
		{
			this.wGhfKmicyaVnoLSUgxxXSpyAJKRt();
			base.OnAwake();
		}

		// Token: 0x060026FD RID: 9981 RVA: 0x0001D140 File Offset: 0x0001B340
		protected override void OnAwakeFinished()
		{
			base.OnAwakeFinished();
			if (base.initialized)
			{
				this.snjUkVDnwdWAUAFrXtGZLWPJSiwW(true);
			}
		}

		// Token: 0x060026FE RID: 9982 RVA: 0x0001D157 File Offset: 0x0001B357
		protected override void OnEnabled()
		{
			base.OnEnabled();
			if (base.initialized && ReInput.isReady)
			{
				base.source.enabled = true;
			}
		}

		// Token: 0x060026FF RID: 9983 RVA: 0x0001D17A File Offset: 0x0001B37A
		protected override void OnDisabled()
		{
			base.OnDisabled();
			if (base.initialized && ReInput.isReady)
			{
				base.source.enabled = false;
			}
		}

		// Token: 0x06002700 RID: 9984 RVA: 0x0001D19D File Offset: 0x0001B39D
		protected override void OnValidated()
		{
			base.OnValidated();
			this.playerId = this._playerId;
			this._playerId = this.playerId;
		}

		// Token: 0x06002701 RID: 9985 RVA: 0x00094C44 File Offset: 0x00092E44
		protected override void OnReset()
		{
			base.OnReset();
			this._rewiredInputManager = null;
			this._playerId = -1;
			this._elements = new List<PlayerController.ElementInfo>();
			this._onButtonStateChanged = new PlayerController.ButtonStateChangedHandler();
			this._onAxisValueChanged = new PlayerController.AxisValueChangedHandler();
			this._onEnabledStateChanged = new PlayerController.EnabledStateChangedHandler();
			this.wGhfKmicyaVnoLSUgxxXSpyAJKRt();
		}

		// Token: 0x06002702 RID: 9986 RVA: 0x00094C98 File Offset: 0x00092E98
		protected override void Subscribe()
		{
			base.Subscribe();
			if (base.source != null)
			{
				base.source.ButtonStateChangedEvent += this.ynCNJiSxwIxxiCBTgKUsEOZqAMSv;
				base.source.AxisValueChangedEvent += this.RNdzSjANwotClGFLIRMNmZOFaspg;
				base.source.EnabledStateChangedEvent += this.snjUkVDnwdWAUAFrXtGZLWPJSiwW;
			}
		}

		// Token: 0x06002703 RID: 9987 RVA: 0x00094CF8 File Offset: 0x00092EF8
		protected override void Unsubscribe()
		{
			base.Unsubscribe();
			if (base.source != null)
			{
				base.source.ButtonStateChangedEvent -= this.ynCNJiSxwIxxiCBTgKUsEOZqAMSv;
				base.source.AxisValueChangedEvent -= this.RNdzSjANwotClGFLIRMNmZOFaspg;
				base.source.EnabledStateChangedEvent -= this.snjUkVDnwdWAUAFrXtGZLWPJSiwW;
			}
		}

		// Token: 0x06002704 RID: 9988 RVA: 0x0001D1BD File Offset: 0x0001B3BD
		protected override object GetCreateSourceArgs()
		{
			return this._elements;
		}

		// Token: 0x06002705 RID: 9989 RVA: 0x00094D58 File Offset: 0x00092F58
		protected override PlayerController CreateSource(object args)
		{
			IList<PlayerController.ElementInfo> list = args as IList<PlayerController.ElementInfo>;
			if (list == null || list.Count == 0)
			{
				Logger.LogWarning("Invalid element information. Did you configure elements in the inspector? Using defaults.");
				list = this.sTvASyFgRApCVUjziioirnomHUnjA();
			}
			List<PlayerController.Element.Definition> list2 = new List<PlayerController.Element.Definition>(list.Count);
			foreach (PlayerController.ElementInfo elementInfo in list)
			{
				list2.Add(elementInfo.ToDefinition());
			}
			return PlayerController.Factory.Create(new PlayerController.Definition
			{
				playerId = this._playerId,
				elements = list2
			});
		}

		// Token: 0x06002706 RID: 9990 RVA: 0x00094DF4 File Offset: 0x00092FF4
		internal virtual List<PlayerController.ElementInfo> sTvASyFgRApCVUjziioirnomHUnjA()
		{
			return new List<PlayerController.ElementInfo>
			{
				new PlayerController.ElementInfo
				{
					name = "Stick",
					elementType = PlayerController.Element.Type.Axis2D,
					elements = new PlayerController.ElementWithSourceInfo[]
					{
						new PlayerController.ElementWithSourceInfo
						{
							name = "Stick Horizontal",
							elementType = PlayerController.Element.TypeWithSource.Axis,
							coordinateMode = AxisCoordinateMode.Absolute
						},
						new PlayerController.ElementWithSourceInfo
						{
							name = "Stick Vertical",
							elementType = PlayerController.Element.TypeWithSource.Axis,
							coordinateMode = AxisCoordinateMode.Absolute
						}
					}
				},
				new PlayerController.ElementInfo
				{
					elements = new PlayerController.ElementWithSourceInfo[]
					{
						new PlayerController.ElementWithSourceInfo
						{
							name = "Button 1",
							elementType = PlayerController.Element.TypeWithSource.Button
						}
					}
				},
				new PlayerController.ElementInfo
				{
					elements = new PlayerController.ElementWithSourceInfo[]
					{
						new PlayerController.ElementWithSourceInfo
						{
							name = "Button 2",
							elementType = PlayerController.Element.TypeWithSource.Button
						}
					}
				},
				new PlayerController.ElementInfo
				{
					elements = new PlayerController.ElementWithSourceInfo[]
					{
						new PlayerController.ElementWithSourceInfo
						{
							name = "Button 3",
							elementType = PlayerController.Element.TypeWithSource.Button
						}
					}
				},
				new PlayerController.ElementInfo
				{
					elements = new PlayerController.ElementWithSourceInfo[]
					{
						new PlayerController.ElementWithSourceInfo
						{
							name = "Button 4",
							elementType = PlayerController.Element.TypeWithSource.Button
						}
					}
				}
			};
		}

		// Token: 0x06002707 RID: 9991 RVA: 0x00094F44 File Offset: 0x00093144
		private void ynCNJiSxwIxxiCBTgKUsEOZqAMSv(int A_1, bool A_2)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			try
			{
				if (this._onButtonStateChanged != null)
				{
					this._onButtonStateChanged.Invoke(A_1, A_2);
				}
			}
			catch (Exception ex)
			{
				string str = "An exception occurred in a listener of ButtonStateChangedEvent. This means an exception was thrown by your code.\n";
				Exception ex2 = ex;
				Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null));
			}
		}

		// Token: 0x06002708 RID: 9992 RVA: 0x00094FA4 File Offset: 0x000931A4
		private void RNdzSjANwotClGFLIRMNmZOFaspg(int A_1, float A_2)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			try
			{
				if (this._onAxisValueChanged != null)
				{
					this._onAxisValueChanged.Invoke(A_1, A_2);
				}
			}
			catch (Exception ex)
			{
				string str = "An exception occurred in a listener of AxisValueChangedEvent. This means an exception was thrown by your code.\n";
				Exception ex2 = ex;
				Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null));
			}
		}

		// Token: 0x06002709 RID: 9993 RVA: 0x00095004 File Offset: 0x00093204
		private void snjUkVDnwdWAUAFrXtGZLWPJSiwW(bool A_1)
		{
			try
			{
				if (this._onEnabledStateChanged != null)
				{
					this._onEnabledStateChanged.Invoke(A_1);
				}
			}
			catch (Exception ex)
			{
				string str = "An exception occurred in a listener of EnabledStateChangedEvent. This means an exception was thrown by your code.\n";
				Exception ex2 = ex;
				Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null));
			}
		}

		// Token: 0x0600270A RID: 9994 RVA: 0x0001D1C5 File Offset: 0x0001B3C5
		private void wGhfKmicyaVnoLSUgxxXSpyAJKRt()
		{
			if (this._elements != null && this._elements.Count > 0)
			{
				return;
			}
			this._elements = this.sTvASyFgRApCVUjziioirnomHUnjA();
		}

		// Token: 0x0600270C RID: 9996 RVA: 0x0001D225 File Offset: 0x0001B425
		bool IPlayerController.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x0600270D RID: 9997 RVA: 0x0001D22D File Offset: 0x0001B42D
		void IPlayerController.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x040016E1 RID: 5857
		[Tooltip("(Optional) Link the Rewired Input Manager here for easier access to Action ids, Player ids, etc.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private InputManager_Base _rewiredInputManager;

		// Token: 0x040016E2 RID: 5858
		[Tooltip("The Player id of the Player used for the source of input.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _playerId = -1;

		// Token: 0x040016E3 RID: 5859
		[Tooltip("The elements that will be created in the controller.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<PlayerController.ElementInfo> _elements = new List<PlayerController.ElementInfo>();

		// Token: 0x040016E4 RID: 5860
		[Tooltip("Triggered the first frame the button is pressed or released.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private PlayerController.ButtonStateChangedHandler _onButtonStateChanged = new PlayerController.ButtonStateChangedHandler();

		// Token: 0x040016E5 RID: 5861
		[Tooltip("Triggered when the axis value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private PlayerController.AxisValueChangedHandler _onAxisValueChanged = new PlayerController.AxisValueChangedHandler();

		// Token: 0x040016E6 RID: 5862
		[Tooltip("Triggered when the controller is enabled or disabled.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private PlayerController.EnabledStateChangedHandler _onEnabledStateChanged = new PlayerController.EnabledStateChangedHandler();

		// Token: 0x020003D2 RID: 978
		[Serializable]
		public class ButtonStateChangedHandler : UnityEvent<int, bool>
		{
		}

		// Token: 0x020003D3 RID: 979
		[Serializable]
		public class AxisValueChangedHandler : UnityEvent<int, float>
		{
		}

		// Token: 0x020003D4 RID: 980
		[Serializable]
		public class EnabledStateChangedHandler : UnityEvent<bool>
		{
		}

		// Token: 0x020003D5 RID: 981
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
		[Serializable]
		internal sealed class ElementWithSourceInfo
		{
			// Token: 0x17000929 RID: 2345
			// (get) Token: 0x06002711 RID: 10001 RVA: 0x0001D24E File Offset: 0x0001B44E
			// (set) Token: 0x06002712 RID: 10002 RVA: 0x0001D256 File Offset: 0x0001B456
			public string name
			{
				get
				{
					return this._name;
				}
				set
				{
					this._name = value;
				}
			}

			// Token: 0x1700092A RID: 2346
			// (get) Token: 0x06002713 RID: 10003 RVA: 0x0001D25F File Offset: 0x0001B45F
			// (set) Token: 0x06002714 RID: 10004 RVA: 0x0001D267 File Offset: 0x0001B467
			public PlayerController.Element.TypeWithSource elementType
			{
				get
				{
					return this._elementType;
				}
				set
				{
					this._elementType = value;
				}
			}

			// Token: 0x1700092B RID: 2347
			// (get) Token: 0x06002715 RID: 10005 RVA: 0x0001D270 File Offset: 0x0001B470
			// (set) Token: 0x06002716 RID: 10006 RVA: 0x0001D278 File Offset: 0x0001B478
			public bool enabled
			{
				get
				{
					return this._enabled;
				}
				set
				{
					this._enabled = value;
				}
			}

			// Token: 0x1700092C RID: 2348
			// (get) Token: 0x06002717 RID: 10007 RVA: 0x0001D281 File Offset: 0x0001B481
			// (set) Token: 0x06002718 RID: 10008 RVA: 0x0001D289 File Offset: 0x0001B489
			public int actionId
			{
				get
				{
					return this._actionId;
				}
				set
				{
					this._actionId = value;
				}
			}

			// Token: 0x1700092D RID: 2349
			// (get) Token: 0x06002719 RID: 10009 RVA: 0x0001D292 File Offset: 0x0001B492
			// (set) Token: 0x0600271A RID: 10010 RVA: 0x0001D29A File Offset: 0x0001B49A
			public AxisCoordinateMode coordinateMode
			{
				get
				{
					return this._coordinateMode;
				}
				set
				{
					this._coordinateMode = value;
				}
			}

			// Token: 0x1700092E RID: 2350
			// (get) Token: 0x0600271B RID: 10011 RVA: 0x0001D2A3 File Offset: 0x0001B4A3
			// (set) Token: 0x0600271C RID: 10012 RVA: 0x0001D2AB File Offset: 0x0001B4AB
			public float absoluteSourceSensitivity
			{
				get
				{
					return this._absoluteToRelativeSensitivity;
				}
				set
				{
					this._absoluteToRelativeSensitivity = value;
				}
			}

			// Token: 0x1700092F RID: 2351
			// (get) Token: 0x0600271D RID: 10013 RVA: 0x0001D2B4 File Offset: 0x0001B4B4
			// (set) Token: 0x0600271E RID: 10014 RVA: 0x0001D2BC File Offset: 0x0001B4BC
			public float repeatRate
			{
				get
				{
					return this._repeatRate;
				}
				set
				{
					this._repeatRate = value;
				}
			}

			// Token: 0x0600271F RID: 10015 RVA: 0x00095058 File Offset: 0x00093258
			public PlayerController.Element.Definition ToDefinition()
			{
				PlayerController.Element.Definition definition = PlayerController.Element.CreateDefinition((PlayerController.Element.Type)this.elementType);
				if (definition is PlayerController.ElementWithSource.Definition)
				{
					((PlayerController.ElementWithSource.Definition)definition).actionId = this.actionId;
				}
				if (definition is PlayerController.Axis.Definition)
				{
					PlayerController.Axis.Definition definition2 = (PlayerController.Axis.Definition)definition;
					definition2.coordinateMode = this.coordinateMode;
					definition2.absoluteToRelativeSensitivity = this.absoluteSourceSensitivity;
				}
				if (definition is PlayerController.MouseWheelAxis.Definition)
				{
					((PlayerController.MouseWheelAxis.Definition)definition).repeatRate = this.repeatRate;
				}
				definition.enabled = this.enabled;
				definition.name = this.name;
				return definition;
			}

			// Token: 0x040016E7 RID: 5863
			[Tooltip("The name of the element.")]
			[SerializeField]
			private string _name;

			// Token: 0x040016E8 RID: 5864
			[Tooltip("The element type.")]
			[SerializeField]
			private PlayerController.Element.TypeWithSource _elementType;

			// Token: 0x040016E9 RID: 5865
			[Tooltip("Is this element enabled? Disabled elements return no value.")]
			[SerializeField]
			private bool _enabled = true;

			// Token: 0x040016EA RID: 5866
			[Tooltip("The Action id of the Action which will be used as the input source for the Element.")]
			[SerializeField]
			private int _actionId = -1;

			// Token: 0x040016EB RID: 5867
			[Tooltip("The output coordinate mode of the axis. An Absolute axis will only return value for input received from Absolute sources. A Relative axis will return value for input received from both Relative and Absolute sources. When converting from an Absolute input source to a Relative output, absoluteToRelativeSensitivity will be multiplied by the Absolute value to yield a simulated Relative value.")]
			[SerializeField]
			private AxisCoordinateMode _coordinateMode;

			// Token: 0x040016EC RID: 5868
			[Tooltip("The absolute to relative sensitivity multiplier. This is only applied when the axis coordinate mode is set to Relative and the axis receives Absolute coordinate mode input (joystick axes, keyboard keys, etc.).")]
			[SerializeField]
			[FieldRange(0f, 3.4028235E+38f)]
			private float _absoluteToRelativeSensitivity = 1f;

			// Token: 0x040016ED RID: 5869
			[Tooltip("The number of times per second the wheel ticks when the value source is an absolute axis value.")]
			[SerializeField]
			[FieldRange(0f, 3.4028235E+38f)]
			private float _repeatRate = 4f;
		}

		// Token: 0x020003D6 RID: 982
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
		[Serializable]
		internal sealed class ElementInfo
		{
			// Token: 0x17000930 RID: 2352
			// (get) Token: 0x06002721 RID: 10017 RVA: 0x0001D2F1 File Offset: 0x0001B4F1
			// (set) Token: 0x06002722 RID: 10018 RVA: 0x0001D2F9 File Offset: 0x0001B4F9
			public string name
			{
				get
				{
					return this._name;
				}
				set
				{
					this._name = value;
				}
			}

			// Token: 0x17000931 RID: 2353
			// (get) Token: 0x06002723 RID: 10019 RVA: 0x0001D302 File Offset: 0x0001B502
			// (set) Token: 0x06002724 RID: 10020 RVA: 0x0001D30A File Offset: 0x0001B50A
			public PlayerController.Element.Type elementType
			{
				get
				{
					return this._elementType;
				}
				set
				{
					this._elementType = value;
				}
			}

			// Token: 0x17000932 RID: 2354
			// (get) Token: 0x06002725 RID: 10021 RVA: 0x0001D313 File Offset: 0x0001B513
			// (set) Token: 0x06002726 RID: 10022 RVA: 0x0001D31B File Offset: 0x0001B51B
			public bool enabled
			{
				get
				{
					return this._enabled;
				}
				set
				{
					this._enabled = value;
				}
			}

			// Token: 0x17000933 RID: 2355
			// (get) Token: 0x06002727 RID: 10023 RVA: 0x0001D324 File Offset: 0x0001B524
			// (set) Token: 0x06002728 RID: 10024 RVA: 0x0001D32C File Offset: 0x0001B52C
			public PlayerController.ElementWithSourceInfo[] elements
			{
				get
				{
					return this._elements;
				}
				set
				{
					this._elements = value;
				}
			}

			// Token: 0x06002729 RID: 10025 RVA: 0x000950E4 File Offset: 0x000932E4
			public PlayerController.Element.Definition ToDefinition()
			{
				PlayerController.Element.Definition definition = PlayerController.Element.CreateDefinition(this.elementType);
				if (definition is PlayerController.ElementWithSource.Definition)
				{
					if (this._elements == null || this._elements.Length == 0)
					{
						Logger.LogError("No element source was found for element with source definition.");
						return null;
					}
					PlayerController.ElementWithSource.Definition definition2 = (PlayerController.ElementWithSource.Definition)definition;
					definition2.name = this._elements[0].name;
					definition2.enabled = this._elements[0].enabled;
					definition2.actionId = this._elements[0].actionId;
				}
				if (definition is PlayerController.Axis.Definition)
				{
					PlayerController.Axis.Definition definition3 = (PlayerController.Axis.Definition)definition;
					definition3.coordinateMode = this._elements[0].coordinateMode;
					definition3.absoluteToRelativeSensitivity = this._elements[0].absoluteSourceSensitivity;
				}
				if (definition is PlayerController.MouseWheelAxis.Definition)
				{
					((PlayerController.MouseWheelAxis.Definition)definition).repeatRate = this._elements[0].repeatRate;
				}
				if (definition is PlayerController.CompoundElement.Definition)
				{
					definition.name = this.name;
					definition.enabled = this.enabled;
					if (this._elements == null || this._elements.Length == 0)
					{
						Logger.LogError("No element source was found for element with source definition.");
						return null;
					}
					if (definition is PlayerController.MouseWheel.Definition)
					{
						PlayerController.MouseWheel.Definition definition4 = definition as PlayerController.MouseWheel.Definition;
						try
						{
							if (this._elements.Length >= 1)
							{
								definition4.xAxis = (PlayerController.MouseWheelAxis.Definition)this._elements[0].ToDefinition();
							}
							if (this._elements.Length >= 2)
							{
								definition4.yAxis = (PlayerController.MouseWheelAxis.Definition)this._elements[1].ToDefinition();
							}
							return definition;
						}
						catch
						{
							Logger.LogError("Incorrect element source type found. Expecting MouseWheelAxis.");
							return null;
						}
					}
					if (definition is PlayerController.Axis2D.Definition)
					{
						PlayerController.Axis2D.Definition definition5 = definition as PlayerController.Axis2D.Definition;
						try
						{
							if (this._elements.Length >= 1)
							{
								definition5.xAxis = (PlayerController.Axis.Definition)this._elements[0].ToDefinition();
							}
							if (this._elements.Length >= 2)
							{
								definition5.yAxis = (PlayerController.Axis.Definition)this._elements[1].ToDefinition();
							}
							return definition;
						}
						catch
						{
							Logger.LogError("Incorrect element source type found. Expecting Axis.");
							return null;
						}
					}
					throw new NotImplementedException();
				}
				return definition;
			}

			// Token: 0x040016EE RID: 5870
			[Tooltip("The name of the element.")]
			[SerializeField]
			private string _name;

			// Token: 0x040016EF RID: 5871
			[Tooltip("The element type.")]
			[SerializeField]
			private PlayerController.Element.Type _elementType;

			// Token: 0x040016F0 RID: 5872
			[Tooltip("Is this element enabled? Disabled elements return no value.")]
			[SerializeField]
			private bool _enabled = true;

			// Token: 0x040016F1 RID: 5873
			[SerializeField]
			private PlayerController.ElementWithSourceInfo[] _elements = new PlayerController.ElementWithSourceInfo[0];
		}
	}
}
