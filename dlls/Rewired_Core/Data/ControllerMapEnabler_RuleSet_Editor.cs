using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data
{
	// Token: 0x0200029C RID: 668
	[Preserve]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[Serializable]
	public sealed class ControllerMapEnabler_RuleSet_Editor
	{
		// Token: 0x170006C7 RID: 1735
		// (get) Token: 0x06001E4A RID: 7754 RVA: 0x00017BAB File Offset: 0x00015DAB
		// (set) Token: 0x06001E4B RID: 7755 RVA: 0x00017BB3 File Offset: 0x00015DB3
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

		// Token: 0x170006C8 RID: 1736
		// (get) Token: 0x06001E4C RID: 7756 RVA: 0x00017BBC File Offset: 0x00015DBC
		// (set) Token: 0x06001E4D RID: 7757 RVA: 0x00017BC4 File Offset: 0x00015DC4
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

		// Token: 0x170006C9 RID: 1737
		// (get) Token: 0x06001E4E RID: 7758 RVA: 0x00017BCD File Offset: 0x00015DCD
		// (set) Token: 0x06001E4F RID: 7759 RVA: 0x00017BD5 File Offset: 0x00015DD5
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

		// Token: 0x170006CA RID: 1738
		// (get) Token: 0x06001E50 RID: 7760 RVA: 0x00017BDE File Offset: 0x00015DDE
		// (set) Token: 0x06001E51 RID: 7761 RVA: 0x00017BE6 File Offset: 0x00015DE6
		public List<ControllerMapEnabler_Rule_Editor> rules
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

		// Token: 0x06001E52 RID: 7762 RVA: 0x00017BEF File Offset: 0x00015DEF
		public ControllerMapEnabler_RuleSet_Editor()
		{
			this._rules = new List<ControllerMapEnabler_Rule_Editor>();
		}

		// Token: 0x06001E53 RID: 7763 RVA: 0x00080548 File Offset: 0x0007E748
		public ControllerMapEnabler_RuleSet_Editor(ControllerMapEnabler_RuleSet_Editor A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("source");
			}
			this._id = A_1._id;
			this._name = A_1._name;
			this._tag = A_1._tag;
			this._rules = MiscTools.DeepClone<ControllerMapEnabler_Rule_Editor>(A_1._rules);
		}

		// Token: 0x06001E54 RID: 7764 RVA: 0x00017C02 File Offset: 0x00015E02
		internal ControllerMapEnabler_RuleSet_Editor Clone()
		{
			return new ControllerMapEnabler_RuleSet_Editor(this);
		}

		// Token: 0x06001E55 RID: 7765 RVA: 0x000805A0 File Offset: 0x0007E7A0
		internal ControllerMapEnabler.RuleSet ToRuntime()
		{
			List<ControllerMapEnabler.Rule> list = new List<ControllerMapEnabler.Rule>();
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
			return new ControllerMapEnabler.RuleSet(true, this._tag, list);
		}

		// Token: 0x04001103 RID: 4355
		[Serialize]
		[SerializeField]
		private int _id;

		// Token: 0x04001104 RID: 4356
		[Serialize]
		[SerializeField]
		private string _name;

		// Token: 0x04001105 RID: 4357
		[Serialize]
		[SerializeField]
		private string _tag;

		// Token: 0x04001106 RID: 4358
		[Serialize]
		[SerializeField]
		private List<ControllerMapEnabler_Rule_Editor> _rules;
	}
}
