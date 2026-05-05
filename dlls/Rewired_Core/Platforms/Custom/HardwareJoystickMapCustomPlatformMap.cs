using System;
using System.Collections.Generic;
using Rewired.Data.Mapping;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Platforms.Custom
{
	// Token: 0x0200022F RID: 559
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[Serializable]
	public abstract class HardwareJoystickMapCustomPlatformMap : HardwareJoystickMap.Platform_Custom
	{
		// Token: 0x1700063C RID: 1596
		// (get) Token: 0x060019DA RID: 6618 RVA: 0x000152D2 File Offset: 0x000134D2
		public override int assignedButtonCount
		{
			get
			{
				if (this.elements == null)
				{
					return 0;
				}
				return this.elements.buttonCount;
			}
		}

		// Token: 0x1700063D RID: 1597
		// (get) Token: 0x060019DB RID: 6619 RVA: 0x000152E9 File Offset: 0x000134E9
		public override int assignedAxisCount
		{
			get
			{
				if (this.elements == null)
				{
					return 0;
				}
				return this.elements.axisCount;
			}
		}

		// Token: 0x1700063E RID: 1598
		// (get) Token: 0x060019DC RID: 6620 RVA: 0x00015300 File Offset: 0x00013500
		internal override InputPlatform platform
		{
			get
			{
				return InputPlatform.Custom;
			}
		}

		// Token: 0x1700063F RID: 1599
		// (get) Token: 0x060019DD RID: 6621 RVA: 0x00071F6C File Offset: 0x0007016C
		internal override HardwareJoystickMap.Platform_Custom.Axis[] Axes
		{
			get
			{
				if (this._axesOrigGame == null)
				{
					HardwareJoystickMapCustomPlatformMap.Axis[] axes_orig = this.Axes_orig;
					if (axes_orig != null)
					{
						this._axesOrigGame = new HardwareJoystickMap.Platform_Custom.Axis[axes_orig.Length];
						for (int i = 0; i < axes_orig.Length; i++)
						{
							this._axesOrigGame[i] = axes_orig[i];
						}
					}
				}
				return this._axesOrigGame;
			}
		}

		// Token: 0x17000640 RID: 1600
		// (get) Token: 0x060019DE RID: 6622 RVA: 0x00071FB8 File Offset: 0x000701B8
		internal override HardwareJoystickMap.Platform_Custom.Button[] Buttons
		{
			get
			{
				if (this._buttonsOrigGame == null)
				{
					HardwareJoystickMapCustomPlatformMap.Button[] buttons_orig = this.Buttons_orig;
					if (buttons_orig != null)
					{
						this._buttonsOrigGame = new HardwareJoystickMap.Platform_Custom.Button[buttons_orig.Length];
						for (int i = 0; i < buttons_orig.Length; i++)
						{
							this._buttonsOrigGame[i] = buttons_orig[i];
						}
					}
				}
				return this._buttonsOrigGame;
			}
		}

		// Token: 0x17000641 RID: 1601
		// (get) Token: 0x060019DF RID: 6623 RVA: 0x00015304 File Offset: 0x00013504
		internal HardwareJoystickMapCustomPlatformMap.Axis[] Axes_orig
		{
			get
			{
				if (this.elements == null)
				{
					return null;
				}
				return this.elements.axes;
			}
		}

		// Token: 0x17000642 RID: 1602
		// (get) Token: 0x060019E0 RID: 6624 RVA: 0x0001531B File Offset: 0x0001351B
		internal HardwareJoystickMapCustomPlatformMap.Button[] Buttons_orig
		{
			get
			{
				if (this.elements == null)
				{
					return null;
				}
				return this.elements.buttons;
			}
		}

		// Token: 0x17000643 RID: 1603
		// (get) Token: 0x060019E1 RID: 6625 RVA: 0x00015332 File Offset: 0x00013532
		internal override bool hasData
		{
			get
			{
				return this.assignedButtonCount != 0 || this.assignedAxisCount != 0;
			}
		}

		// Token: 0x17000644 RID: 1604
		// (get) Token: 0x060019E2 RID: 6626 RVA: 0x00015347 File Offset: 0x00013547
		internal override bool isAllowed
		{
			get
			{
				return base.isAllowed;
			}
		}

		// Token: 0x17000645 RID: 1605
		// (get) Token: 0x060019E3 RID: 6627 RVA: 0x00015354 File Offset: 0x00013554
		internal override HardwareJoystickMap.Elements_Base elements_base
		{
			get
			{
				return this.elements;
			}
		}

		// Token: 0x060019E4 RID: 6628 RVA: 0x000067FE File Offset: 0x000049FE
		public override IList<HardwareJoystickMap.Platform> GetVariants()
		{
			return null;
		}

		// Token: 0x060019E5 RID: 6629
		protected abstract object CreateInstance();

		// Token: 0x060019E6 RID: 6630 RVA: 0x00002FF9 File Offset: 0x000011F9
		protected virtual void DeepClone(object destination)
		{
		}

		// Token: 0x060019E7 RID: 6631 RVA: 0x00072004 File Offset: 0x00070204
		public override object DeepClone()
		{
			object obj = this.CreateInstance();
			if (obj == null)
			{
				throw new ArgumentNullException("Returned object is null.");
			}
			HardwareJoystickMapCustomPlatformMap hardwareJoystickMapCustomPlatformMap = obj as HardwareJoystickMapCustomPlatformMap;
			if (hardwareJoystickMapCustomPlatformMap == null)
			{
				throw new Exception("Object does not inherit from " + typeof(HardwareJoystickMapCustomPlatformMap).Name + ".");
			}
			if (hardwareJoystickMapCustomPlatformMap == this)
			{
				throw new Exception("Returned object is self. This is not supported.");
			}
			this.DeepClone(obj);
			this.CopyVars(hardwareJoystickMapCustomPlatformMap);
			return hardwareJoystickMapCustomPlatformMap;
		}

		// Token: 0x060019E8 RID: 6632 RVA: 0x00072074 File Offset: 0x00070274
		internal override void CopyVars(HardwareJoystickMap.Platform destination)
		{
			base.CopyVars(destination);
			HardwareJoystickMapCustomPlatformMap hardwareJoystickMapCustomPlatformMap = destination as HardwareJoystickMapCustomPlatformMap;
			if (hardwareJoystickMapCustomPlatformMap == null)
			{
				return;
			}
			hardwareJoystickMapCustomPlatformMap.elements = MiscTools.DeepClone<HardwareJoystickMapCustomPlatformMap.Elements>(this.elements);
		}

		// Token: 0x04000EBF RID: 3775
		[Tooltip("The list of controller elements.")]
		public HardwareJoystickMapCustomPlatformMap.Elements elements;

		// Token: 0x04000EC0 RID: 3776
		private HardwareJoystickMap.Platform_Custom.Axis[] _axesOrigGame;

		// Token: 0x04000EC1 RID: 3777
		private HardwareJoystickMap.Platform_Custom.Button[] _buttonsOrigGame;

		// Token: 0x02000230 RID: 560
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public new sealed class Elements : HardwareJoystickMap.Platform_Custom.Elements
		{
			// Token: 0x17000646 RID: 1606
			// (get) Token: 0x060019EA RID: 6634 RVA: 0x00015364 File Offset: 0x00013564
			public override int buttonCount
			{
				get
				{
					if (this.buttons == null)
					{
						return 0;
					}
					return this.buttons.Length;
				}
			}

			// Token: 0x17000647 RID: 1607
			// (get) Token: 0x060019EB RID: 6635 RVA: 0x00015378 File Offset: 0x00013578
			public override int axisCount
			{
				get
				{
					if (this.axes == null)
					{
						return 0;
					}
					return this.axes.Length;
				}
			}

			// Token: 0x060019EC RID: 6636 RVA: 0x000720A4 File Offset: 0x000702A4
			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				for (int i = 0; i < this.axisCount; i++)
				{
					if (this.axes[i].elementIdentifier == elementIdentifier.id)
					{
						return ControllerElementType.Axis;
					}
				}
				for (int j = 0; j < this.buttonCount; j++)
				{
					if (this.buttons[j].elementIdentifier == elementIdentifier.id)
					{
						return ControllerElementType.Button;
					}
				}
				return elementIdentifier.elementType;
			}

			// Token: 0x060019ED RID: 6637 RVA: 0x00072108 File Offset: 0x00070308
			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				int i = 0;
				while (i < this.axisCount)
				{
					if (this.axes[i].elementIdentifier == elementIdentifier.id)
					{
						int sourceType = this.axes[i].sourceType;
						if (sourceType == 0)
						{
							axisRange = AxisRange.Positive;
							return true;
						}
						if (sourceType == 1 || sourceType == 100)
						{
							axisRange = this.axes[i].sourceAxisRange;
							if (this.axes[i].invert)
							{
								axisRange = InputTools.InvertAxisRange(axisRange);
							}
							return true;
						}
						throw new NotImplementedException();
					}
					else
					{
						i++;
					}
				}
				axisRange = AxisRange.Full;
				return false;
			}

			// Token: 0x060019EE RID: 6638 RVA: 0x00072190 File Offset: 0x00070390
			public override object DeepClone()
			{
				HardwareJoystickMapCustomPlatformMap.Elements elements = new HardwareJoystickMapCustomPlatformMap.Elements();
				this.CopyVars(elements);
				return elements;
			}

			// Token: 0x060019EF RID: 6639 RVA: 0x000721AC File Offset: 0x000703AC
			internal override void CopyVars(HardwareJoystickMap.Elements_Base destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMapCustomPlatformMap.Elements elements = destination as HardwareJoystickMapCustomPlatformMap.Elements;
				if (elements == null)
				{
					return;
				}
				elements.axes = ArrayTools.DeepClone<HardwareJoystickMapCustomPlatformMap.Axis>(this.axes);
				elements.buttons = ArrayTools.DeepClone<HardwareJoystickMapCustomPlatformMap.Button>(this.buttons);
			}

			// Token: 0x04000EC2 RID: 3778
			[Tooltip("The list of axes in this controller.")]
			public HardwareJoystickMapCustomPlatformMap.Axis[] axes;

			// Token: 0x04000EC3 RID: 3779
			[Tooltip("The list of buttons in this controller.")]
			public HardwareJoystickMapCustomPlatformMap.Button[] buttons;
		}

		// Token: 0x02000231 RID: 561
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public new sealed class Button : HardwareJoystickMap.Platform_Custom.Button
		{
			// Token: 0x060019F1 RID: 6641 RVA: 0x000721F0 File Offset: 0x000703F0
			public override object DeepClone()
			{
				HardwareJoystickMapCustomPlatformMap.Button button = new HardwareJoystickMapCustomPlatformMap.Button();
				this.CopyVars(button);
				return button;
			}

			// Token: 0x060019F2 RID: 6642 RVA: 0x00015394 File Offset: 0x00013594
			internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMapCustomPlatformMap.Button button = destination as HardwareJoystickMapCustomPlatformMap.Button;
			}
		}

		// Token: 0x02000232 RID: 562
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public new sealed class Axis : HardwareJoystickMap.Platform_Custom.Axis
		{
			// Token: 0x060019F4 RID: 6644 RVA: 0x0007220C File Offset: 0x0007040C
			public override object DeepClone()
			{
				HardwareJoystickMapCustomPlatformMap.Axis axis = new HardwareJoystickMapCustomPlatformMap.Axis();
				this.CopyVars(axis);
				return axis;
			}

			// Token: 0x060019F5 RID: 6645 RVA: 0x000153AC File Offset: 0x000135AC
			internal override void CopyVars(HardwareJoystickMap.Platform_Custom.Element destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMapCustomPlatformMap.Axis axis = destination as HardwareJoystickMapCustomPlatformMap.Axis;
			}
		}

		// Token: 0x02000233 RID: 563
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public new abstract class MatchingCriteria : HardwareJoystickMap.Platform_Custom.MatchingCriteria
		{
			// Token: 0x060019F7 RID: 6647 RVA: 0x00003E2B File Offset: 0x0000202B
			public virtual bool Matches(object customIdentifier)
			{
				return false;
			}

			// Token: 0x17000648 RID: 1608
			// (get) Token: 0x060019F8 RID: 6648 RVA: 0x000042E2 File Offset: 0x000024E2
			internal override bool hasData
			{
				get
				{
					return true;
				}
			}

			// Token: 0x17000649 RID: 1609
			// (get) Token: 0x060019F9 RID: 6649 RVA: 0x000153C4 File Offset: 0x000135C4
			internal override bool isAllowed
			{
				get
				{
					return base.isAllowed && !this.disabled;
				}
			}

			// Token: 0x060019FA RID: 6650 RVA: 0x00072228 File Offset: 0x00070428
			internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
			{
				if (bridgedControllerHWInfo.isMock && this.hasData && this.isAllowed)
				{
					return true;
				}
				if (!base.Matches(bridgedControllerHWInfo, strictMatch))
				{
					return false;
				}
				if (this.alwaysMatch)
				{
					return true;
				}
				if (bridgedControllerHWInfo.userCustomIdentifier != null && this.Matches(bridgedControllerHWInfo.userCustomIdentifier))
				{
					return true;
				}
				string text = bridgedControllerHWInfo.hw_productName;
				if (text == null)
				{
					text = string.Empty;
				}
				text = text.Trim();
				if (this.name != null)
				{
					for (int i = 0; i < this.name.Length; i++)
					{
						string searchFor = this.name[i];
						if (HardwareJoystickMap.MatchingCriteria_Base.StringMatches(text, searchFor, this.nameUseRegex))
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x060019FB RID: 6651
			protected abstract object CreateInstance();

			// Token: 0x060019FC RID: 6652 RVA: 0x00002FF9 File Offset: 0x000011F9
			protected virtual void DeepClone(object destination)
			{
			}

			// Token: 0x060019FD RID: 6653 RVA: 0x000722CC File Offset: 0x000704CC
			public override object DeepClone()
			{
				object obj = this.CreateInstance();
				if (obj == null)
				{
					throw new ArgumentNullException("Returned object is null.");
				}
				HardwareJoystickMapCustomPlatformMap.MatchingCriteria matchingCriteria = obj as HardwareJoystickMapCustomPlatformMap.MatchingCriteria;
				if (matchingCriteria == null)
				{
					throw new Exception("Object does not inherit from " + typeof(HardwareJoystickMapCustomPlatformMap.MatchingCriteria).Name + ".");
				}
				if (matchingCriteria == this)
				{
					throw new Exception("Returned object is self. This is not supported.");
				}
				this.DeepClone(obj);
				this.CopyVars(matchingCriteria);
				return matchingCriteria;
			}

			// Token: 0x060019FE RID: 6654 RVA: 0x0007233C File Offset: 0x0007053C
			internal override void CopyVars(HardwareJoystickMap.MatchingCriteria_Base destination)
			{
				base.CopyVars(destination);
				HardwareJoystickMapCustomPlatformMap.MatchingCriteria matchingCriteria = destination as HardwareJoystickMapCustomPlatformMap.MatchingCriteria;
				if (matchingCriteria == null)
				{
					return;
				}
				matchingCriteria.nameUseRegex = this.nameUseRegex;
				matchingCriteria.name = ArrayTools.ShallowCopy<string>(this.name);
			}

			// Token: 0x04000EC4 RID: 3780
			[Tooltip("If enabled, name strings can contain regular expressions for matching.")]
			public bool nameUseRegex;

			// Token: 0x04000EC5 RID: 3781
			[Tooltip("A list of string names to match on. If defined, any matching name will result in a match.")]
			public string[] name;
		}
	}
}
