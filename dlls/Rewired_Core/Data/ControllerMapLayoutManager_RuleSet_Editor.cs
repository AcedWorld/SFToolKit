using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data
{
	// Token: 0x0200029E RID: 670
	[Preserve]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[Serializable]
	public sealed class ControllerMapLayoutManager_RuleSet_Editor
	{
		// Token: 0x170006D0 RID: 1744
		// (get) Token: 0x06001E64 RID: 7780 RVA: 0x00017C98 File Offset: 0x00015E98
		// (set) Token: 0x06001E65 RID: 7781 RVA: 0x00017CA0 File Offset: 0x00015EA0
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				this._id = value;
			}
		}

		// Token: 0x170006D1 RID: 1745
		// (get) Token: 0x06001E66 RID: 7782 RVA: 0x00017CA9 File Offset: 0x00015EA9
		// (set) Token: 0x06001E67 RID: 7783 RVA: 0x00017CB1 File Offset: 0x00015EB1
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

		// Token: 0x170006D2 RID: 1746
		// (get) Token: 0x06001E68 RID: 7784 RVA: 0x00017CBA File Offset: 0x00015EBA
		// (set) Token: 0x06001E69 RID: 7785 RVA: 0x00017CC2 File Offset: 0x00015EC2
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

		// Token: 0x170006D3 RID: 1747
		// (get) Token: 0x06001E6A RID: 7786 RVA: 0x00017CCB File Offset: 0x00015ECB
		// (set) Token: 0x06001E6B RID: 7787 RVA: 0x00017CD3 File Offset: 0x00015ED3
		public List<ControllerMapLayoutManager_Rule_Editor> rules
		{
			get
			{
				return this._rules;
			}
			set
			{
				this._rules = value;
			}
		}

		// Token: 0x06001E6C RID: 7788 RVA: 0x00017CDC File Offset: 0x00015EDC
		public ControllerMapLayoutManager_RuleSet_Editor()
		{
			this._rules = new List<ControllerMapLayoutManager_Rule_Editor>();
		}

		// Token: 0x06001E6D RID: 7789 RVA: 0x000806D0 File Offset: 0x0007E8D0
		public ControllerMapLayoutManager_RuleSet_Editor(ControllerMapLayoutManager_RuleSet_Editor A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("source");
			}
			this._id = A_1._id;
			this._name = A_1._name;
			this._tag = A_1._tag;
			this._rules = MiscTools.DeepClone<ControllerMapLayoutManager_Rule_Editor>(A_1._rules);
		}

		// Token: 0x06001E6E RID: 7790 RVA: 0x00017CEF File Offset: 0x00015EEF
		internal ControllerMapLayoutManager_RuleSet_Editor Clone()
		{
			return new ControllerMapLayoutManager_RuleSet_Editor(this);
		}

		// Token: 0x06001E6F RID: 7791 RVA: 0x00080728 File Offset: 0x0007E928
		internal ControllerMapLayoutManager.RuleSet ToRuntime()
		{
			List<ControllerMapLayoutManager.Rule> list = new List<ControllerMapLayoutManager.Rule>();
			if (this._rules != null)
			{
				for (int i = 0; i < this._rules.Count; i++)
				{
					if (this._rules[i] != null)
					{
						list.Add(this._rules[i].ToRuntime());
					}
				}
			}
			return new ControllerMapLayoutManager.RuleSet(true, this._tag, list);
		}

		// Token: 0x0400110C RID: 4364
		[Serialize]
		[SerializeField]
		private int _id;

		// Token: 0x0400110D RID: 4365
		[Serialize]
		[SerializeField]
		private string _name;

		// Token: 0x0400110E RID: 4366
		[Serialize]
		[SerializeField]
		private string _tag;

		// Token: 0x0400110F RID: 4367
		[Serialize]
		[SerializeField]
		private List<ControllerMapLayoutManager_Rule_Editor> _rules;
	}
}
