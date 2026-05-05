using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data
{
	// Token: 0x0200029D RID: 669
	[Preserve]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[Serializable]
	public sealed class ControllerMapEnabler_Rule_Editor : IDeepCloneable
	{
		// Token: 0x170006CB RID: 1739
		// (get) Token: 0x06001E56 RID: 7766 RVA: 0x00017C0A File Offset: 0x00015E0A
		// (set) Token: 0x06001E57 RID: 7767 RVA: 0x00017C12 File Offset: 0x00015E12
		public string tag
		{
			get
			{
				return this._tag;
			}
			set
			{
				this._tag = value;
			}
		}

		// Token: 0x170006CC RID: 1740
		// (get) Token: 0x06001E58 RID: 7768 RVA: 0x00017C1B File Offset: 0x00015E1B
		// (set) Token: 0x06001E59 RID: 7769 RVA: 0x00017C23 File Offset: 0x00015E23
		public bool enable
		{
			get
			{
				return this._enable;
			}
			set
			{
				this._enable = value;
			}
		}

		// Token: 0x170006CD RID: 1741
		// (get) Token: 0x06001E5A RID: 7770 RVA: 0x00017C2C File Offset: 0x00015E2C
		// (set) Token: 0x06001E5B RID: 7771 RVA: 0x00017C34 File Offset: 0x00015E34
		public List<int> categoryIds
		{
			get
			{
				return this._categoryIds;
			}
			set
			{
				this._categoryIds = value;
			}
		}

		// Token: 0x170006CE RID: 1742
		// (get) Token: 0x06001E5C RID: 7772 RVA: 0x00017C3D File Offset: 0x00015E3D
		// (set) Token: 0x06001E5D RID: 7773 RVA: 0x00017C45 File Offset: 0x00015E45
		public List<int> layoutIds
		{
			get
			{
				return this._layoutIds;
			}
			set
			{
				this._layoutIds = value;
			}
		}

		// Token: 0x170006CF RID: 1743
		// (get) Token: 0x06001E5E RID: 7774 RVA: 0x00017C4E File Offset: 0x00015E4E
		// (set) Token: 0x06001E5F RID: 7775 RVA: 0x00017C56 File Offset: 0x00015E56
		public ControllerSetSelector_Editor controllerSetSelector
		{
			get
			{
				return this._controllerSetSelector;
			}
			set
			{
				this._controllerSetSelector = value;
			}
		}

		// Token: 0x06001E60 RID: 7776 RVA: 0x00017C5F File Offset: 0x00015E5F
		public ControllerMapEnabler_Rule_Editor()
		{
			this._enable = true;
			this._categoryIds = new List<int>();
			this._layoutIds = new List<int>();
			this._controllerSetSelector = new ControllerSetSelector_Editor(ControllerSetSelector.Type.ControllerType);
		}

		// Token: 0x06001E61 RID: 7777 RVA: 0x00080604 File Offset: 0x0007E804
		public ControllerMapEnabler_Rule_Editor(ControllerMapEnabler_Rule_Editor A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("source");
			}
			this._tag = A_1._tag;
			this._enable = A_1._enable;
			this._categoryIds = ListTools.ShallowCopy<int>(A_1._categoryIds);
			this._layoutIds = ListTools.ShallowCopy<int>(A_1._layoutIds);
			this._controllerSetSelector = MiscTools.DeepClone<ControllerSetSelector_Editor>(A_1._controllerSetSelector);
		}

		// Token: 0x06001E62 RID: 7778 RVA: 0x00080670 File Offset: 0x0007E870
		internal ControllerMapEnabler.Rule ToRuntime()
		{
			return new ControllerMapEnabler.Rule(this._tag, this._enable, (this._categoryIds != null) ? this._categoryIds.ToArray() : new int[0], (this._layoutIds != null) ? this._layoutIds.ToArray() : new int[0], this._controllerSetSelector.DnVhDiIMNWoQXJDFvmsmmAfdFdLS());
		}

		// Token: 0x06001E63 RID: 7779 RVA: 0x00017C90 File Offset: 0x00015E90
		object IDeepCloneable.DeepClone()
		{
			return new ControllerMapEnabler_Rule_Editor(this);
		}

		// Token: 0x04001107 RID: 4359
		[Serialize]
		[SerializeField]
		private string _tag;

		// Token: 0x04001108 RID: 4360
		[Serialize]
		[SerializeField]
		private bool _enable;

		// Token: 0x04001109 RID: 4361
		[Serialize]
		[SerializeField]
		private List<int> _categoryIds;

		// Token: 0x0400110A RID: 4362
		[Serialize]
		[SerializeField]
		private List<int> _layoutIds;

		// Token: 0x0400110B RID: 4363
		[Serialize]
		[SerializeField]
		private ControllerSetSelector_Editor _controllerSetSelector;
	}
}
