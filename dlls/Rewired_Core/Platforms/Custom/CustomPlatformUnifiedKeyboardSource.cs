using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired.Platforms.Custom
{
	// Token: 0x0200022B RID: 555
	public abstract class CustomPlatformUnifiedKeyboardSource : CustomPlatformUnifiedControllerSource
	{
		// Token: 0x060019CB RID: 6603 RVA: 0x0001520C File Offset: 0x0001340C
		public CustomPlatformUnifiedKeyboardSource() : base(0, Consts._keyboardKeyValues.Length)
		{
		}

		// Token: 0x1700063A RID: 1594
		// (get) Token: 0x060019CC RID: 6604 RVA: 0x0001521C File Offset: 0x0001341C
		// (set) Token: 0x060019CD RID: 6605 RVA: 0x00015237 File Offset: 0x00013437
		public CustomPlatformUnifiedKeyboardSource.KeyPropertyMap keyPropertyMap
		{
			get
			{
				if (this.CatxjSMDQOWTDajaJdkjVpwCRcNW == null)
				{
					this.CatxjSMDQOWTDajaJdkjVpwCRcNW = new CustomPlatformUnifiedKeyboardSource.KeyPropertyMap();
				}
				return this.CatxjSMDQOWTDajaJdkjVpwCRcNW;
			}
			set
			{
				if (value == null)
				{
					value = new CustomPlatformUnifiedKeyboardSource.KeyPropertyMap();
				}
				this.CatxjSMDQOWTDajaJdkjVpwCRcNW = value;
				this.VrcCUOdiufZkgwDeXipGNWgQaWoV();
			}
		}

		// Token: 0x060019CE RID: 6606 RVA: 0x00071D34 File Offset: 0x0006FF34
		protected void SetKeyValue(KeyboardKeyCode keyCode, bool value)
		{
			int buttonIndex = ReInput.controllers.Keyboard.GetButtonIndex(keyCode);
			if (buttonIndex < 0)
			{
				return;
			}
			base.SetButtonValue(buttonIndex, value);
		}

		// Token: 0x060019CF RID: 6607 RVA: 0x00015250 File Offset: 0x00013450
		internal virtual void TpndvFjGxbEGGwoitSqbGQAYIaSd()
		{
			base.xKzVJkKASxJwMuJCSdFUwhgAYzYN();
			if (this.CatxjSMDQOWTDajaJdkjVpwCRcNW != null && this.CatxjSMDQOWTDajaJdkjVpwCRcNW.snyZLmvjqJVsLqLKgdiZdBdWmTWy)
			{
				this.VrcCUOdiufZkgwDeXipGNWgQaWoV();
			}
		}

		// Token: 0x060019D0 RID: 6608 RVA: 0x00071D60 File Offset: 0x0006FF60
		private void VrcCUOdiufZkgwDeXipGNWgQaWoV()
		{
			HardwareControllerMap_Game wgnseNgKihPuTwMSEeDkNInQXGEb = ReInput.controllers.Keyboard.WGnseNgKihPuTwMSEeDkNInQXGEb;
			int totalCount = wgnseNgKihPuTwMSEeDkNInQXGEb.elementIdentifiers.TotalCount;
			for (int i = 0; i < totalCount; i++)
			{
				ControllerElementIdentifier controllerElementIdentifier;
				if (wgnseNgKihPuTwMSEeDkNInQXGEb.elementIdentifiers.TryGetValueAt(i, out controllerElementIdentifier))
				{
					KeyboardKeyCode keyCode = (KeyboardKeyCode)Consts.keyboardKeyValues[controllerElementIdentifier.id];
					string label = this.CatxjSMDQOWTDajaJdkjVpwCRcNW.Get(keyCode).label;
					if (!string.Equals(controllerElementIdentifier.name, label))
					{
						controllerElementIdentifier.name = label;
					}
				}
			}
			this.CatxjSMDQOWTDajaJdkjVpwCRcNW.snyZLmvjqJVsLqLKgdiZdBdWmTWy = false;
		}

		// Token: 0x04000EBA RID: 3770
		private CustomPlatformUnifiedKeyboardSource.KeyPropertyMap CatxjSMDQOWTDajaJdkjVpwCRcNW;

		// Token: 0x0200022C RID: 556
		public sealed class KeyPropertyMap
		{
			// Token: 0x1700063B RID: 1595
			// (get) Token: 0x060019D1 RID: 6609 RVA: 0x00015273 File Offset: 0x00013473
			// (set) Token: 0x060019D2 RID: 6610 RVA: 0x0001527B File Offset: 0x0001347B
			internal bool snyZLmvjqJVsLqLKgdiZdBdWmTWy
			{
				get
				{
					return this.UqtdcwEnrsZUiiiWOcRLxGoNXqLQA;
				}
				set
				{
					this.UqtdcwEnrsZUiiiWOcRLxGoNXqLQA = value;
				}
			}

			// Token: 0x060019D3 RID: 6611 RVA: 0x00071DF0 File Offset: 0x0006FFF0
			public KeyPropertyMap()
			{
				this.LNteEbyCPDkaaHLehgLQFfqsyKDdA = new IndexedDictionary<int, string>();
				IList<int> keyboardKeyValues = Consts.keyboardKeyValues;
				IList<string> keyboardKeyNames = Consts.keyboardKeyNames;
				for (int i = 0; i < 132; i++)
				{
					this.LNteEbyCPDkaaHLehgLQFfqsyKDdA.Add(keyboardKeyValues[i], keyboardKeyNames[i]);
				}
				this.UqtdcwEnrsZUiiiWOcRLxGoNXqLQA = true;
			}

			// Token: 0x060019D4 RID: 6612 RVA: 0x00015284 File Offset: 0x00013484
			public KeyPropertyMap(CustomPlatformUnifiedKeyboardSource.KeyPropertyMap A_1)
			{
				if (A_1 == null)
				{
					throw new ArgumentNullException("other");
				}
				this.LNteEbyCPDkaaHLehgLQFfqsyKDdA = new IndexedDictionary<int, string>(A_1.LNteEbyCPDkaaHLehgLQFfqsyKDdA);
				this.UqtdcwEnrsZUiiiWOcRLxGoNXqLQA = true;
			}

			// Token: 0x060019D5 RID: 6613 RVA: 0x00071E4C File Offset: 0x0007004C
			public CustomPlatformUnifiedKeyboardSource.KeyPropertyMap.Key Get(KeyboardKeyCode keyCode)
			{
				string label;
				if (!this.LNteEbyCPDkaaHLehgLQFfqsyKDdA.TryGetValue((int)keyCode, out label))
				{
					return default(CustomPlatformUnifiedKeyboardSource.KeyPropertyMap.Key);
				}
				return new CustomPlatformUnifiedKeyboardSource.KeyPropertyMap.Key
				{
					keyCode = keyCode,
					label = label
				};
			}

			// Token: 0x060019D6 RID: 6614 RVA: 0x000152B2 File Offset: 0x000134B2
			public void Set(CustomPlatformUnifiedKeyboardSource.KeyPropertyMap.Key key)
			{
				this.LNteEbyCPDkaaHLehgLQFfqsyKDdA.SetValue((int)key.keyCode, key.label);
				this.UqtdcwEnrsZUiiiWOcRLxGoNXqLQA = true;
			}

			// Token: 0x060019D7 RID: 6615 RVA: 0x00071E8C File Offset: 0x0007008C
			public CustomPlatformUnifiedKeyboardSource.KeyPropertyMap.Key[] Get()
			{
				CustomPlatformUnifiedKeyboardSource.KeyPropertyMap.Key[] array = new CustomPlatformUnifiedKeyboardSource.KeyPropertyMap.Key[this.LNteEbyCPDkaaHLehgLQFfqsyKDdA.Count];
				int count = this.LNteEbyCPDkaaHLehgLQFfqsyKDdA.Count;
				for (int i = 0; i < count; i++)
				{
					array[i] = new CustomPlatformUnifiedKeyboardSource.KeyPropertyMap.Key
					{
						keyCode = (KeyboardKeyCode)this.LNteEbyCPDkaaHLehgLQFfqsyKDdA.GetKeyAt(i),
						label = this.LNteEbyCPDkaaHLehgLQFfqsyKDdA[i]
					};
				}
				return array;
			}

			// Token: 0x060019D8 RID: 6616 RVA: 0x00071EFC File Offset: 0x000700FC
			public void Set(ICollection<CustomPlatformUnifiedKeyboardSource.KeyPropertyMap.Key> keys)
			{
				if (keys == null)
				{
					throw new ArgumentNullException("keys");
				}
				foreach (CustomPlatformUnifiedKeyboardSource.KeyPropertyMap.Key key in keys)
				{
					this.LNteEbyCPDkaaHLehgLQFfqsyKDdA.SetValue((int)key.keyCode, key.label);
				}
				this.UqtdcwEnrsZUiiiWOcRLxGoNXqLQA = true;
			}

			// Token: 0x04000EBB RID: 3771
			private IndexedDictionary<int, string> LNteEbyCPDkaaHLehgLQFfqsyKDdA;

			// Token: 0x04000EBC RID: 3772
			private bool UqtdcwEnrsZUiiiWOcRLxGoNXqLQA;

			// Token: 0x0200022D RID: 557
			public struct Key
			{
				// Token: 0x04000EBD RID: 3773
				public KeyboardKeyCode keyCode;

				// Token: 0x04000EBE RID: 3774
				public string label;
			}
		}
	}
}
