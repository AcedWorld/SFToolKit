using System;
using System.Text;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired
{
	// Token: 0x0200000E RID: 14
	[Preserve]
	[Serializable]
	public sealed class ControllerSetSelector : ISerializationCallbackReceiver, IDeepCloneable
	{
		// Token: 0x06000104 RID: 260 RVA: 0x00002ED4 File Offset: 0x000010D4
		internal ControllerSetSelector(ControllerSetSelector.Type A_1) : this()
		{
			this._type = A_1;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00002EE3 File Offset: 0x000010E3
		public ControllerSetSelector()
		{
			this._controllerId = -1;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0002BE0C File Offset: 0x0002A00C
		public ControllerSetSelector(ControllerSetSelector A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("source");
			}
			this._type = A_1._type;
			this._controllerType = A_1._controllerType;
			this._guid = A_1._guid;
			this._hardwareIdentifier = A_1._hardwareIdentifier;
			this._controllerId = A_1._controllerId;
			this.xfEhPXcFEtADgnLWKbxhfMSkJbPoc = A_1.xfEhPXcFEtADgnLWKbxhfMSkJbPoc;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00002EF2 File Offset: 0x000010F2
		internal ControllerSetSelector(ControllerSetSelector.Type A_1, ControllerType A_2, string A_3, string A_4, int A_5)
		{
			this._type = A_1;
			this._controllerType = A_2;
			this._guid = A_3;
			this.xfEhPXcFEtADgnLWKbxhfMSkJbPoc = StringTools.ToGuid(A_3);
			this._hardwareIdentifier = A_4;
			this._controllerId = A_5;
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000108 RID: 264 RVA: 0x00002F2B File Offset: 0x0000112B
		internal bool IbmnYivTUUXRLmzaaAGPWTFtAPLI
		{
			get
			{
				return this._type > ControllerSetSelector.Type.All;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000109 RID: 265 RVA: 0x00002F36 File Offset: 0x00001136
		// (set) Token: 0x0600010A RID: 266 RVA: 0x00002F3E File Offset: 0x0000113E
		public ControllerSetSelector.Type type
		{
			get
			{
				return this._type;
			}
			set
			{
				if (value != this._type)
				{
					this.CNqGihTlQLHWuVrVsOuFXwlCPDtq();
				}
				this._type = value;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600010B RID: 267 RVA: 0x00002F56 File Offset: 0x00001156
		// (set) Token: 0x0600010C RID: 268 RVA: 0x00002F5E File Offset: 0x0000115E
		public ControllerType controllerType
		{
			get
			{
				return this._controllerType;
			}
			set
			{
				this._controllerType = value;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600010D RID: 269 RVA: 0x00002F67 File Offset: 0x00001167
		// (set) Token: 0x0600010E RID: 270 RVA: 0x0002BE78 File Offset: 0x0002A078
		public Guid hardwareTypeGuid
		{
			get
			{
				if (this._type != ControllerSetSelector.Type.HardwareType)
				{
					return Guid.Empty;
				}
				return this.xfEhPXcFEtADgnLWKbxhfMSkJbPoc;
			}
			set
			{
				if (this._type != ControllerSetSelector.Type.ControllerTemplateType)
				{
					Logger.LogWarning("hardwareTypeGuid can only be set when type is " + ControllerSetSelector.Type.HardwareType.ToString() + ".", true);
					return;
				}
				this.xfEhPXcFEtADgnLWKbxhfMSkJbPoc = value;
				this._guid = value.ToString();
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00002F7E File Offset: 0x0000117E
		// (set) Token: 0x06000110 RID: 272 RVA: 0x00002F86 File Offset: 0x00001186
		public string hardwareIdentifier
		{
			get
			{
				return this._hardwareIdentifier;
			}
			set
			{
				this._hardwareIdentifier = value;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00002F8F File Offset: 0x0000118F
		// (set) Token: 0x06000112 RID: 274 RVA: 0x0002BED0 File Offset: 0x0002A0D0
		public Guid controllerTemplateTypeGuid
		{
			get
			{
				if (this._type != ControllerSetSelector.Type.ControllerTemplateType)
				{
					return Guid.Empty;
				}
				return this.xfEhPXcFEtADgnLWKbxhfMSkJbPoc;
			}
			set
			{
				if (this._type != ControllerSetSelector.Type.ControllerTemplateType)
				{
					Logger.LogWarning("controllerTemplateTypeGuid can only be set when type is " + ControllerSetSelector.Type.ControllerTemplateType.ToString() + ".", true);
					return;
				}
				this.xfEhPXcFEtADgnLWKbxhfMSkJbPoc = value;
				this._guid = value.ToString();
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00002FA6 File Offset: 0x000011A6
		// (set) Token: 0x06000114 RID: 276 RVA: 0x0002BF28 File Offset: 0x0002A128
		public Guid deviceInstanceGuid
		{
			get
			{
				if (this._type != ControllerSetSelector.Type.PersistentControllerInstance)
				{
					return Guid.Empty;
				}
				return this.xfEhPXcFEtADgnLWKbxhfMSkJbPoc;
			}
			set
			{
				if (this._type != ControllerSetSelector.Type.PersistentControllerInstance)
				{
					Logger.LogWarning("deviceInstanceGuid can only be set when type is " + ControllerSetSelector.Type.PersistentControllerInstance.ToString() + ".", true);
					return;
				}
				this.xfEhPXcFEtADgnLWKbxhfMSkJbPoc = value;
				this._guid = value.ToString();
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00002FBD File Offset: 0x000011BD
		// (set) Token: 0x06000116 RID: 278 RVA: 0x00002FC5 File Offset: 0x000011C5
		public int controllerId
		{
			get
			{
				return this._controllerId;
			}
			set
			{
				this._controllerId = value;
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0002BF80 File Offset: 0x0002A180
		public bool Matches(Controller controller)
		{
			if (controller == null)
			{
				return false;
			}
			if (this._type != ControllerSetSelector.Type.All && this._controllerType != controller.type)
			{
				return false;
			}
			switch (this._type)
			{
			case ControllerSetSelector.Type.All:
			case ControllerSetSelector.Type.ControllerType:
				return true;
			case ControllerSetSelector.Type.HardwareType:
				if (this.xfEhPXcFEtADgnLWKbxhfMSkJbPoc != Guid.Empty)
				{
					return this.xfEhPXcFEtADgnLWKbxhfMSkJbPoc == controller.hardwareTypeGuid;
				}
				return string.IsNullOrEmpty(this._hardwareIdentifier) || string.Equals(this._hardwareIdentifier, controller.hardwareIdentifier, StringComparison.Ordinal);
			case ControllerSetSelector.Type.ControllerTemplateType:
				return controller.ImplementsTemplate(this.xfEhPXcFEtADgnLWKbxhfMSkJbPoc);
			case ControllerSetSelector.Type.PersistentControllerInstance:
				return controller.deviceInstanceGuid == this.xfEhPXcFEtADgnLWKbxhfMSkJbPoc;
			case ControllerSetSelector.Type.SessionControllerInstance:
				return controller.id == this._controllerId;
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0002C04C File Offset: 0x0002A24C
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringTools.WriteVar(stringBuilder, "Type", this._type.ToString());
			StringTools.WriteVar(stringBuilder, "Controller Type", this._controllerType.ToString());
			StringTools.WriteVar(stringBuilder, "Guid", this._guid.ToString());
			StringTools.WriteVar(stringBuilder, "Hardware Identifier", this._hardwareIdentifier.ToString());
			StringTools.WriteVar(stringBuilder, "Controller Id", this._controllerId.ToString());
			return stringBuilder.ToString();
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00002FCE File Offset: 0x000011CE
		private void CNqGihTlQLHWuVrVsOuFXwlCPDtq()
		{
			this._guid = string.Empty;
			this.xfEhPXcFEtADgnLWKbxhfMSkJbPoc = Guid.Empty;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00002FE6 File Offset: 0x000011E6
		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			this.xfEhPXcFEtADgnLWKbxhfMSkJbPoc = StringTools.ToGuid(this._guid);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00002FF9 File Offset: 0x000011F9
		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00002FFB File Offset: 0x000011FB
		object IDeepCloneable.DeepClone()
		{
			return new ControllerSetSelector(this);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00003003 File Offset: 0x00001203
		public static ControllerSetSelector SelectAll()
		{
			return new ControllerSetSelector(ControllerSetSelector.Type.All);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000300B File Offset: 0x0000120B
		public static ControllerSetSelector SelectControllerType(ControllerType controllerType)
		{
			return new ControllerSetSelector(ControllerSetSelector.Type.ControllerType)
			{
				_controllerType = controllerType
			};
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0000301A File Offset: 0x0000121A
		public static ControllerSetSelector SelectHardwareType(ControllerType controllerType, Guid hardwareTypeGuid, string hardwareIdentifier)
		{
			return new ControllerSetSelector(ControllerSetSelector.Type.HardwareType)
			{
				_controllerType = controllerType,
				hardwareTypeGuid = hardwareTypeGuid,
				_hardwareIdentifier = hardwareIdentifier
			};
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00003037 File Offset: 0x00001237
		public static ControllerSetSelector SelectHardwareType(Controller controller)
		{
			if (controller == null)
			{
				throw new ArgumentNullException("controller");
			}
			return ControllerSetSelector.SelectHardwareType(controller.type, controller.hardwareTypeGuid, controller.hardwareIdentifier);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000305E File Offset: 0x0000125E
		public static ControllerSetSelector SelectControllerTemplateType(ControllerType controllerType, Guid controllerTemplateTypeGuid)
		{
			return new ControllerSetSelector(ControllerSetSelector.Type.ControllerTemplateType)
			{
				_controllerType = controllerType,
				controllerTemplateTypeGuid = controllerTemplateTypeGuid
			};
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00003074 File Offset: 0x00001274
		public static ControllerSetSelector SelectControllerTemplateType(IControllerTemplate controllerTemplate)
		{
			if (controllerTemplate == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			return ControllerSetSelector.SelectControllerTemplateType(controllerTemplate.controller.type, controllerTemplate.typeGuid);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0000309A File Offset: 0x0000129A
		public static ControllerSetSelector SelectPersistentControllerInstance(ControllerType controllerType, Guid deviceInstanceGuid)
		{
			return new ControllerSetSelector(ControllerSetSelector.Type.PersistentControllerInstance)
			{
				_controllerType = controllerType,
				deviceInstanceGuid = deviceInstanceGuid
			};
		}

		// Token: 0x06000124 RID: 292 RVA: 0x000030B0 File Offset: 0x000012B0
		public static ControllerSetSelector SelectPersistentControllerInstance(Controller controller)
		{
			if (controller == null)
			{
				throw new ArgumentNullException("controller");
			}
			return ControllerSetSelector.SelectPersistentControllerInstance(controller.type, controller.deviceInstanceGuid);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x000030D1 File Offset: 0x000012D1
		public static ControllerSetSelector SelectSessionControllerInstance(ControllerType controllerType, int controllerId)
		{
			return new ControllerSetSelector(ControllerSetSelector.Type.SessionControllerInstance)
			{
				_controllerType = controllerType,
				_controllerId = controllerId
			};
		}

		// Token: 0x06000126 RID: 294 RVA: 0x000030E7 File Offset: 0x000012E7
		public static ControllerSetSelector SelectSessionControllerInstance(Controller controller)
		{
			if (controller == null)
			{
				throw new ArgumentNullException("controller");
			}
			return ControllerSetSelector.SelectSessionControllerInstance(controller.type, controller.id);
		}

		// Token: 0x0400004F RID: 79
		[SerializeField]
		[Serialize(Name = "type")]
		private ControllerSetSelector.Type _type;

		// Token: 0x04000050 RID: 80
		[SerializeField]
		[Serialize(Name = "controllerType")]
		private ControllerType _controllerType;

		// Token: 0x04000051 RID: 81
		[SerializeField]
		[Serialize(Name = "guid")]
		private string _guid;

		// Token: 0x04000052 RID: 82
		[SerializeField]
		[Serialize(Name = "hardwareIdentifier")]
		private string _hardwareIdentifier;

		// Token: 0x04000053 RID: 83
		[SerializeField]
		[Serialize(Name = "controllerId")]
		private int _controllerId;

		// Token: 0x04000054 RID: 84
		[NonSerialized]
		private Guid xfEhPXcFEtADgnLWKbxhfMSkJbPoc;

		// Token: 0x0200000F RID: 15
		public enum Type
		{
			// Token: 0x04000056 RID: 86
			All,
			// Token: 0x04000057 RID: 87
			ControllerType,
			// Token: 0x04000058 RID: 88
			HardwareType,
			// Token: 0x04000059 RID: 89
			ControllerTemplateType,
			// Token: 0x0400005A RID: 90
			PersistentControllerInstance,
			// Token: 0x0400005B RID: 91
			SessionControllerInstance
		}
	}
}
