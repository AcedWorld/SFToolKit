using System;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data
{
	// Token: 0x020002A0 RID: 672
	[Preserve]
	[Serializable]
	public sealed class ControllerSetSelector_Editor : IDeepCloneable
	{
		// Token: 0x06001E7C RID: 7804 RVA: 0x00017DA2 File Offset: 0x00015FA2
		internal ControllerSetSelector_Editor(ControllerSetSelector.Type A_1) : this()
		{
			this._type = A_1;
		}

		// Token: 0x06001E7D RID: 7805 RVA: 0x000807E8 File Offset: 0x0007E9E8
		public ControllerSetSelector_Editor()
		{
			this._controllerId = -1;
			this._customControllerSourceId = -1;
			this._hardwareTypeGuidString = Guid.Empty.ToString();
		}

		// Token: 0x06001E7E RID: 7806 RVA: 0x00080824 File Offset: 0x0007EA24
		public ControllerSetSelector_Editor(ControllerSetSelector_Editor A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("source");
			}
			this._type = A_1._type;
			this._controllerType = A_1._controllerType;
			this._hardwareTypeGuidString = A_1._hardwareTypeGuidString;
			this._controllerTemplateTypeGuidString = A_1._controllerTemplateTypeGuidString;
			this._deviceInstanceGuidString = A_1._deviceInstanceGuidString;
			this._hardwareIdentifier = A_1._hardwareIdentifier;
			this._customControllerSourceId = A_1._customControllerSourceId;
			this._controllerId = A_1._controllerId;
		}

		// Token: 0x170006D8 RID: 1752
		// (get) Token: 0x06001E7F RID: 7807 RVA: 0x00017DB1 File Offset: 0x00015FB1
		// (set) Token: 0x06001E80 RID: 7808 RVA: 0x00017DB9 File Offset: 0x00015FB9
		public ControllerSetSelector.Type type
		{
			get
			{
				return this._type;
			}
			set
			{
				this._type = value;
			}
		}

		// Token: 0x170006D9 RID: 1753
		// (get) Token: 0x06001E81 RID: 7809 RVA: 0x00017DC2 File Offset: 0x00015FC2
		// (set) Token: 0x06001E82 RID: 7810 RVA: 0x00017DCA File Offset: 0x00015FCA
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

		// Token: 0x170006DA RID: 1754
		// (get) Token: 0x06001E83 RID: 7811 RVA: 0x00017DD3 File Offset: 0x00015FD3
		// (set) Token: 0x06001E84 RID: 7812 RVA: 0x00017DE0 File Offset: 0x00015FE0
		public Guid hardwareTypeGuid
		{
			get
			{
				return StringTools.ToGuid(this._hardwareTypeGuidString);
			}
			set
			{
				this._hardwareTypeGuidString = value.ToString();
			}
		}

		// Token: 0x170006DB RID: 1755
		// (get) Token: 0x06001E85 RID: 7813 RVA: 0x00017DF5 File Offset: 0x00015FF5
		// (set) Token: 0x06001E86 RID: 7814 RVA: 0x00017DFD File Offset: 0x00015FFD
		public string hardwareTypeGuidString
		{
			get
			{
				return this._hardwareTypeGuidString;
			}
			set
			{
				this._hardwareTypeGuidString = value;
			}
		}

		// Token: 0x170006DC RID: 1756
		// (get) Token: 0x06001E87 RID: 7815 RVA: 0x00017E06 File Offset: 0x00016006
		// (set) Token: 0x06001E88 RID: 7816 RVA: 0x00017E0E File Offset: 0x0001600E
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

		// Token: 0x170006DD RID: 1757
		// (get) Token: 0x06001E89 RID: 7817 RVA: 0x00017E17 File Offset: 0x00016017
		// (set) Token: 0x06001E8A RID: 7818 RVA: 0x00017E24 File Offset: 0x00016024
		public Guid controllerTemplateTypeGuid
		{
			get
			{
				return StringTools.ToGuid(this._controllerTemplateTypeGuidString);
			}
			set
			{
				this._controllerTemplateTypeGuidString = value.ToString();
			}
		}

		// Token: 0x170006DE RID: 1758
		// (get) Token: 0x06001E8B RID: 7819 RVA: 0x00017E39 File Offset: 0x00016039
		// (set) Token: 0x06001E8C RID: 7820 RVA: 0x00017E41 File Offset: 0x00016041
		public string controllerTemplateTypeGuidString
		{
			get
			{
				return this._controllerTemplateTypeGuidString;
			}
			set
			{
				this._controllerTemplateTypeGuidString = value;
			}
		}

		// Token: 0x170006DF RID: 1759
		// (get) Token: 0x06001E8D RID: 7821 RVA: 0x00017E4A File Offset: 0x0001604A
		// (set) Token: 0x06001E8E RID: 7822 RVA: 0x00017E57 File Offset: 0x00016057
		public Guid deviceInstanceGuid
		{
			get
			{
				return StringTools.ToGuid(this._deviceInstanceGuidString);
			}
			set
			{
				this._deviceInstanceGuidString = value.ToString();
			}
		}

		// Token: 0x170006E0 RID: 1760
		// (get) Token: 0x06001E8F RID: 7823 RVA: 0x00017E6C File Offset: 0x0001606C
		// (set) Token: 0x06001E90 RID: 7824 RVA: 0x00017E74 File Offset: 0x00016074
		public string deviceInstanceGuidString
		{
			get
			{
				return this._deviceInstanceGuidString;
			}
			set
			{
				this._deviceInstanceGuidString = value;
			}
		}

		// Token: 0x170006E1 RID: 1761
		// (get) Token: 0x06001E91 RID: 7825 RVA: 0x00017E7D File Offset: 0x0001607D
		// (set) Token: 0x06001E92 RID: 7826 RVA: 0x00017E85 File Offset: 0x00016085
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

		// Token: 0x170006E2 RID: 1762
		// (get) Token: 0x06001E93 RID: 7827 RVA: 0x00017E8E File Offset: 0x0001608E
		// (set) Token: 0x06001E94 RID: 7828 RVA: 0x00017E96 File Offset: 0x00016096
		public int customControllerSourceId
		{
			get
			{
				return this._customControllerSourceId;
			}
			set
			{
				this._customControllerSourceId = value;
			}
		}

		// Token: 0x06001E95 RID: 7829 RVA: 0x000808A8 File Offset: 0x0007EAA8
		internal ControllerSetSelector DnVhDiIMNWoQXJDFvmsmmAfdFdLS()
		{
			string text = string.Empty;
			if (this._type != ControllerSetSelector.Type.All && this._controllerType == ControllerType.Custom)
			{
				CustomController_Editor customControllerById = ReInput.UserData.GetCustomControllerById(this._controllerId);
				if (customControllerById != null)
				{
					text = customControllerById.typeGuidString;
				}
			}
			else
			{
				switch (this._type)
				{
				case ControllerSetSelector.Type.All:
				case ControllerSetSelector.Type.ControllerType:
				case ControllerSetSelector.Type.SessionControllerInstance:
					break;
				case ControllerSetSelector.Type.HardwareType:
					text = this._hardwareTypeGuidString;
					break;
				case ControllerSetSelector.Type.ControllerTemplateType:
					text = this._controllerTemplateTypeGuidString;
					break;
				case ControllerSetSelector.Type.PersistentControllerInstance:
					text = this._deviceInstanceGuidString;
					break;
				default:
					throw new NotImplementedException();
				}
			}
			return new ControllerSetSelector(this._type, this._controllerType, text, this._hardwareIdentifier, this._controllerId);
		}

		// Token: 0x06001E96 RID: 7830 RVA: 0x00017E9F File Offset: 0x0001609F
		object IDeepCloneable.DeepClone()
		{
			return new ControllerSetSelector_Editor(this);
		}

		// Token: 0x04001114 RID: 4372
		[Serialize]
		[SerializeField]
		private ControllerSetSelector.Type _type;

		// Token: 0x04001115 RID: 4373
		[Serialize]
		[SerializeField]
		private ControllerType _controllerType;

		// Token: 0x04001116 RID: 4374
		[Serialize]
		[SerializeField]
		private string _hardwareTypeGuidString;

		// Token: 0x04001117 RID: 4375
		[Serialize]
		[SerializeField]
		private string _hardwareIdentifier;

		// Token: 0x04001118 RID: 4376
		[Serialize]
		[SerializeField]
		private string _controllerTemplateTypeGuidString;

		// Token: 0x04001119 RID: 4377
		[Serialize]
		[SerializeField]
		private string _deviceInstanceGuidString;

		// Token: 0x0400111A RID: 4378
		[Serialize]
		[SerializeField]
		private int _customControllerSourceId;

		// Token: 0x0400111B RID: 4379
		[Serialize]
		[SerializeField]
		private int _controllerId;
	}
}
