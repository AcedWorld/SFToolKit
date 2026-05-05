using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data
{
	// Token: 0x0200029F RID: 671
	[Preserve]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[Serializable]
	public sealed class ControllerMapLayoutManager_Rule_Editor : IDeepCloneable
	{
		// Token: 0x170006D4 RID: 1748
		// (get) Token: 0x06001E70 RID: 7792 RVA: 0x00017CF7 File Offset: 0x00015EF7
		// (set) Token: 0x06001E71 RID: 7793 RVA: 0x00017CFF File Offset: 0x00015EFF
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

		// Token: 0x170006D5 RID: 1749
		// (get) Token: 0x06001E72 RID: 7794 RVA: 0x00017D08 File Offset: 0x00015F08
		// (set) Token: 0x06001E73 RID: 7795 RVA: 0x00017D10 File Offset: 0x00015F10
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

		// Token: 0x170006D6 RID: 1750
		// (get) Token: 0x06001E74 RID: 7796 RVA: 0x00017D19 File Offset: 0x00015F19
		// (set) Token: 0x06001E75 RID: 7797 RVA: 0x00017D21 File Offset: 0x00015F21
		public int layoutId
		{
			get
			{
				return this._layoutId;
			}
			set
			{
				this._layoutId = value;
			}
		}

		// Token: 0x170006D7 RID: 1751
		// (get) Token: 0x06001E76 RID: 7798 RVA: 0x00017D2A File Offset: 0x00015F2A
		// (set) Token: 0x06001E77 RID: 7799 RVA: 0x00017D32 File Offset: 0x00015F32
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

		// Token: 0x06001E78 RID: 7800 RVA: 0x00017D3B File Offset: 0x00015F3B
		public ControllerMapLayoutManager_Rule_Editor()
		{
			this._categoryIds = new List<int>();
			this._layoutId = -1;
			this._controllerSetSelector = new ControllerSetSelector_Editor(ControllerSetSelector.Type.ControllerType);
		}

		// Token: 0x06001E79 RID: 7801 RVA: 0x0008078C File Offset: 0x0007E98C
		public ControllerMapLayoutManager_Rule_Editor(ControllerMapLayoutManager_Rule_Editor A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("source");
			}
			this._tag = A_1._tag;
			this._categoryIds = ListTools.ShallowCopy<int>(A_1._categoryIds);
			this._layoutId = A_1._layoutId;
			this._controllerSetSelector = MiscTools.DeepClone<ControllerSetSelector_Editor>(A_1._controllerSetSelector);
		}

		// Token: 0x06001E7A RID: 7802 RVA: 0x00017D61 File Offset: 0x00015F61
		internal ControllerMapLayoutManager.Rule ToRuntime()
		{
			return new ControllerMapLayoutManager.Rule(this._tag, (this._categoryIds != null) ? this._categoryIds.ToArray() : new int[0], this._layoutId, this._controllerSetSelector.DnVhDiIMNWoQXJDFvmsmmAfdFdLS());
		}

		// Token: 0x06001E7B RID: 7803 RVA: 0x00017D9A File Offset: 0x00015F9A
		object IDeepCloneable.DeepClone()
		{
			return new ControllerMapLayoutManager_Rule_Editor(this);
		}

		// Token: 0x04001110 RID: 4368
		[Serialize]
		[SerializeField]
		private string _tag;

		// Token: 0x04001111 RID: 4369
		[Serialize]
		[SerializeField]
		private List<int> _categoryIds;

		// Token: 0x04001112 RID: 4370
		[Serialize]
		[SerializeField]
		private int _layoutId;

		// Token: 0x04001113 RID: 4371
		[Serialize]
		[SerializeField]
		private ControllerSetSelector_Editor _controllerSetSelector;
	}
}
