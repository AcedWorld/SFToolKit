using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x020003DB RID: 987
	[Serializable]
	internal class VisualElementAsset : UxmlAsset, ISerializationCallbackReceiver
	{
		// Token: 0x17000782 RID: 1922
		// (get) Token: 0x06002047 RID: 8263 RVA: 0x00079BD4 File Offset: 0x00077DD4
		// (set) Token: 0x06002048 RID: 8264 RVA: 0x00079BEC File Offset: 0x00077DEC
		public int ruleIndex
		{
			get
			{
				return this.m_RuleIndex;
			}
			set
			{
				this.m_RuleIndex = value;
			}
		}

		// Token: 0x17000783 RID: 1923
		// (get) Token: 0x06002049 RID: 8265 RVA: 0x00079BF8 File Offset: 0x00077DF8
		// (set) Token: 0x0600204A RID: 8266 RVA: 0x00079C10 File Offset: 0x00077E10
		public string[] classes
		{
			get
			{
				return this.m_Classes;
			}
			set
			{
				this.m_Classes = value;
			}
		}

		// Token: 0x17000784 RID: 1924
		// (get) Token: 0x0600204B RID: 8267 RVA: 0x00079C1C File Offset: 0x00077E1C
		// (set) Token: 0x0600204C RID: 8268 RVA: 0x00079C46 File Offset: 0x00077E46
		public List<string> stylesheetPaths
		{
			get
			{
				List<string> result;
				if ((result = this.m_StylesheetPaths) == null)
				{
					result = (this.m_StylesheetPaths = new List<string>());
				}
				return result;
			}
			set
			{
				this.m_StylesheetPaths = value;
			}
		}

		// Token: 0x17000785 RID: 1925
		// (get) Token: 0x0600204D RID: 8269 RVA: 0x00079C50 File Offset: 0x00077E50
		public bool hasStylesheetPaths
		{
			get
			{
				return this.m_StylesheetPaths != null;
			}
		}

		// Token: 0x17000786 RID: 1926
		// (get) Token: 0x0600204E RID: 8270 RVA: 0x00079C5C File Offset: 0x00077E5C
		// (set) Token: 0x0600204F RID: 8271 RVA: 0x00079C86 File Offset: 0x00077E86
		public List<StyleSheet> stylesheets
		{
			get
			{
				List<StyleSheet> result;
				if ((result = this.m_Stylesheets) == null)
				{
					result = (this.m_Stylesheets = new List<StyleSheet>());
				}
				return result;
			}
			set
			{
				this.m_Stylesheets = value;
			}
		}

		// Token: 0x17000787 RID: 1927
		// (get) Token: 0x06002050 RID: 8272 RVA: 0x00079C90 File Offset: 0x00077E90
		public bool hasStylesheets
		{
			get
			{
				return this.m_Stylesheets != null;
			}
		}

		// Token: 0x17000788 RID: 1928
		// (get) Token: 0x06002051 RID: 8273 RVA: 0x00079C9B File Offset: 0x00077E9B
		// (set) Token: 0x06002052 RID: 8274 RVA: 0x00079CA3 File Offset: 0x00077EA3
		internal bool skipClone
		{
			get
			{
				return this.m_SkipClone;
			}
			set
			{
				this.m_SkipClone = value;
			}
		}

		// Token: 0x06002053 RID: 8275 RVA: 0x00079CAC File Offset: 0x00077EAC
		public VisualElementAsset(string fullTypeName) : base(fullTypeName)
		{
			this.m_Name = string.Empty;
			this.m_Text = string.Empty;
			this.m_PickingMode = PickingMode.Position;
		}

		// Token: 0x06002054 RID: 8276 RVA: 0x00003CD2 File Offset: 0x00001ED2
		public void OnBeforeSerialize()
		{
		}

		// Token: 0x06002055 RID: 8277 RVA: 0x00079CDC File Offset: 0x00077EDC
		public void OnAfterDeserialize()
		{
			bool flag = !string.IsNullOrEmpty(this.m_Name) && !this.m_Properties.Contains("name");
			if (flag)
			{
				base.SetAttribute("name", this.m_Name);
			}
			bool flag2 = !string.IsNullOrEmpty(this.m_Text) && !this.m_Properties.Contains("text");
			if (flag2)
			{
				base.SetAttribute("text", this.m_Text);
			}
			bool flag3 = this.m_PickingMode != PickingMode.Position && !this.m_Properties.Contains("picking-mode") && !this.m_Properties.Contains("pickingMode");
			if (flag3)
			{
				base.SetAttribute("picking-mode", this.m_PickingMode.ToString());
			}
		}

		// Token: 0x04000D49 RID: 3401
		[SerializeField]
		private string m_Name;

		// Token: 0x04000D4A RID: 3402
		[SerializeField]
		private int m_RuleIndex = -1;

		// Token: 0x04000D4B RID: 3403
		[SerializeField]
		private string m_Text;

		// Token: 0x04000D4C RID: 3404
		[SerializeField]
		private PickingMode m_PickingMode;

		// Token: 0x04000D4D RID: 3405
		[SerializeField]
		private string[] m_Classes;

		// Token: 0x04000D4E RID: 3406
		[SerializeField]
		private List<string> m_StylesheetPaths;

		// Token: 0x04000D4F RID: 3407
		[SerializeField]
		private List<StyleSheet> m_Stylesheets;

		// Token: 0x04000D50 RID: 3408
		[SerializeField]
		private bool m_SkipClone;
	}
}
