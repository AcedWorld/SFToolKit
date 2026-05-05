using System;
using UnityEngine;

namespace Rewired
{
	// Token: 0x0200000B RID: 11
	public sealed class ElementAssignmentInfo
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x00002CB4 File Offset: 0x00000EB4
		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (this.XBAnRZvkJiDgYnHCuSDxCWIMRvQX == null)
				{
					return null;
				}
				return this.XBAnRZvkJiDgYnHCuSDxCWIMRvQX.player;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x00002CD4 File Offset: 0x00000ED4
		public InputAction action
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.mapping.GetAction(this.kAxhFaskJLhneJkxxnhKlhjFGHUFA);
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00002CEF File Offset: 0x00000EEF
		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (this.XBAnRZvkJiDgYnHCuSDxCWIMRvQX == null)
				{
					return null;
				}
				return ReInput.controllers.GetController(this.XBAnRZvkJiDgYnHCuSDxCWIMRvQX.controllerType, this.XBAnRZvkJiDgYnHCuSDxCWIMRvQX.controllerId);
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x00002D24 File Offset: 0x00000F24
		public ControllerType controllerType
		{
			get
			{
				if (!ReInput.isReady || this.XBAnRZvkJiDgYnHCuSDxCWIMRvQX == null)
				{
					return ControllerType.Keyboard;
				}
				return this.XBAnRZvkJiDgYnHCuSDxCWIMRvQX.controllerType;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00002D42 File Offset: 0x00000F42
		public int controllerId
		{
			get
			{
				if (!ReInput.isReady || this.XBAnRZvkJiDgYnHCuSDxCWIMRvQX == null)
				{
					return -1;
				}
				return this.XBAnRZvkJiDgYnHCuSDxCWIMRvQX.controllerId;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x00002D60 File Offset: 0x00000F60
		public ControllerMap controllerMap
		{
			get
			{
				return this.XBAnRZvkJiDgYnHCuSDxCWIMRvQX;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x00002D68 File Offset: 0x00000F68
		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (this.controller == null)
				{
					return null;
				}
				return this.controller.GetElementIdentifierById(this.jqmKrAovtUqourjedfliCAWlRRxZ);
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x00002D85 File Offset: 0x00000F85
		public ActionElementMap elementMap
		{
			get
			{
				if (this.XBAnRZvkJiDgYnHCuSDxCWIMRvQX == null)
				{
					return null;
				}
				return this.XBAnRZvkJiDgYnHCuSDxCWIMRvQX.GetElementMap(this.XleaCdoLyYDFFeJclgYPTDLLCTAOA);
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x00002DA2 File Offset: 0x00000FA2
		public ControllerElementType elementType
		{
			get
			{
				return this.iLVlPbVIyTXgXODlymmifQkMHWDGA;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000EA RID: 234 RVA: 0x00002DAA File Offset: 0x00000FAA
		public Pole axisContribution
		{
			get
			{
				return this.LsvVghlqUUATUJnBkebnLyUQffFe;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000EB RID: 235 RVA: 0x00002DB2 File Offset: 0x00000FB2
		public AxisRange axisRange
		{
			get
			{
				return this.uVGrMoNYzWIpVzzgkTfNUExsWdTE;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00002DBA File Offset: 0x00000FBA
		public bool invert
		{
			get
			{
				return this.nBuettaCIWDZLHWedJUbhOVHnCyNA;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000ED RID: 237 RVA: 0x00002DC2 File Offset: 0x00000FC2
		public KeyCode keyCode
		{
			get
			{
				return this.ktrUaRqPyyaZJRKBQBkbrspqBTJe;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000EE RID: 238 RVA: 0x00002DCA File Offset: 0x00000FCA
		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				return this.GHZJbFZpTYcfDexJbqSERCbtOwWeA;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000EF RID: 239 RVA: 0x0002BC9C File Offset: 0x00029E9C
		public string elementDisplayName
		{
			get
			{
				if (this.XBAnRZvkJiDgYnHCuSDxCWIMRvQX == null)
				{
					return string.Empty;
				}
				if (this.controllerType == ControllerType.Keyboard)
				{
					return Keyboard.GetKeyName(this.keyCode, this.modifierKeyFlags);
				}
				Controller controller = this.controller;
				if (controller == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(this.jqmKrAovtUqourjedfliCAWlRRxZ);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				if (this.iLVlPbVIyTXgXODlymmifQkMHWDGA == ControllerElementType.Axis)
				{
					if (this.uVGrMoNYzWIpVzzgkTfNUExsWdTE == AxisRange.Full)
					{
						return elementIdentifierById.name;
					}
					if (this.uVGrMoNYzWIpVzzgkTfNUExsWdTE == AxisRange.Positive)
					{
						return elementIdentifierById.positiveName;
					}
					if (this.uVGrMoNYzWIpVzzgkTfNUExsWdTE == AxisRange.Negative)
					{
						return elementIdentifierById.negativeName;
					}
				}
				return elementIdentifierById.name;
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0002BD34 File Offset: 0x00029F34
		internal ElementAssignmentInfo(ControllerMap A_1, ElementAssignment A_2)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("controllerMap");
			}
			this.kAxhFaskJLhneJkxxnhKlhjFGHUFA = A_2.actionId;
			this.XBAnRZvkJiDgYnHCuSDxCWIMRvQX = A_1;
			this.XleaCdoLyYDFFeJclgYPTDLLCTAOA = A_2.elementMapId;
			this.jqmKrAovtUqourjedfliCAWlRRxZ = A_2.elementIdentifierId;
			this.ktrUaRqPyyaZJRKBQBkbrspqBTJe = A_2.keyboardKey;
			this.GHZJbFZpTYcfDexJbqSERCbtOwWeA = A_2.modifierKeyFlags;
			this.nBuettaCIWDZLHWedJUbhOVHnCyNA = A_2.invert;
			this.iLVlPbVIyTXgXODlymmifQkMHWDGA = gRvITEHjKMrWaeGYEmAHofbpCtEU.oMwnKYUpvUGVFiEwmcEFRbkThNxp(A_2.type);
			this.LsvVghlqUUATUJnBkebnLyUQffFe = A_2.axisContribution;
			this.uVGrMoNYzWIpVzzgkTfNUExsWdTE = A_2.axisRange;
			if (this.XBAnRZvkJiDgYnHCuSDxCWIMRvQX.controllerType == ControllerType.Keyboard)
			{
				Keyboard.FdiUlMlPThEdJiDeaiGhYbnwVhVoA(ref this.jqmKrAovtUqourjedfliCAWlRRxZ, ref this.ktrUaRqPyyaZJRKBQBkbrspqBTJe);
			}
		}

		// Token: 0x0400003D RID: 61
		private readonly ControllerMap XBAnRZvkJiDgYnHCuSDxCWIMRvQX;

		// Token: 0x0400003E RID: 62
		private readonly ControllerElementType iLVlPbVIyTXgXODlymmifQkMHWDGA;

		// Token: 0x0400003F RID: 63
		private readonly int XleaCdoLyYDFFeJclgYPTDLLCTAOA;

		// Token: 0x04000040 RID: 64
		private readonly int jqmKrAovtUqourjedfliCAWlRRxZ;

		// Token: 0x04000041 RID: 65
		private readonly AxisRange uVGrMoNYzWIpVzzgkTfNUExsWdTE;

		// Token: 0x04000042 RID: 66
		private readonly KeyCode ktrUaRqPyyaZJRKBQBkbrspqBTJe;

		// Token: 0x04000043 RID: 67
		private readonly ModifierKeyFlags GHZJbFZpTYcfDexJbqSERCbtOwWeA;

		// Token: 0x04000044 RID: 68
		private readonly int kAxhFaskJLhneJkxxnhKlhjFGHUFA;

		// Token: 0x04000045 RID: 69
		private readonly Pole LsvVghlqUUATUJnBkebnLyUQffFe;

		// Token: 0x04000046 RID: 70
		private readonly bool nBuettaCIWDZLHWedJUbhOVHnCyNA;
	}
}
