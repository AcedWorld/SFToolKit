using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x020003D4 RID: 980
	[Serializable]
	internal class UxmlAsset : IUxmlAttributes
	{
		// Token: 0x0600201B RID: 8219 RVA: 0x00079517 File Offset: 0x00077717
		public UxmlAsset(string fullTypeName)
		{
			this.m_FullTypeName = fullTypeName;
		}

		// Token: 0x17000777 RID: 1911
		// (get) Token: 0x0600201C RID: 8220 RVA: 0x00079528 File Offset: 0x00077728
		// (set) Token: 0x0600201D RID: 8221 RVA: 0x00079530 File Offset: 0x00077730
		public string fullTypeName
		{
			get
			{
				return this.m_FullTypeName;
			}
			set
			{
				this.m_FullTypeName = value;
			}
		}

		// Token: 0x17000778 RID: 1912
		// (get) Token: 0x0600201E RID: 8222 RVA: 0x00079539 File Offset: 0x00077739
		// (set) Token: 0x0600201F RID: 8223 RVA: 0x00079541 File Offset: 0x00077741
		public int id
		{
			get
			{
				return this.m_Id;
			}
			set
			{
				this.m_Id = value;
			}
		}

		// Token: 0x17000779 RID: 1913
		// (get) Token: 0x06002020 RID: 8224 RVA: 0x0007954A File Offset: 0x0007774A
		// (set) Token: 0x06002021 RID: 8225 RVA: 0x00079552 File Offset: 0x00077752
		public int orderInDocument
		{
			get
			{
				return this.m_OrderInDocument;
			}
			set
			{
				this.m_OrderInDocument = value;
			}
		}

		// Token: 0x1700077A RID: 1914
		// (get) Token: 0x06002022 RID: 8226 RVA: 0x0007955B File Offset: 0x0007775B
		// (set) Token: 0x06002023 RID: 8227 RVA: 0x00079563 File Offset: 0x00077763
		public int parentId
		{
			get
			{
				return this.m_ParentId;
			}
			set
			{
				this.m_ParentId = value;
			}
		}

		// Token: 0x06002024 RID: 8228 RVA: 0x0007956C File Offset: 0x0007776C
		public List<string> GetProperties()
		{
			return this.m_Properties;
		}

		// Token: 0x06002025 RID: 8229 RVA: 0x00079574 File Offset: 0x00077774
		public bool HasParent()
		{
			return this.m_ParentId != 0;
		}

		// Token: 0x06002026 RID: 8230 RVA: 0x00079580 File Offset: 0x00077780
		public bool HasAttribute(string attributeName)
		{
			bool flag = this.m_Properties == null || this.m_Properties.Count <= 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < this.m_Properties.Count; i += 2)
				{
					string a = this.m_Properties[i];
					bool flag2 = a == attributeName;
					if (flag2)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06002027 RID: 8231 RVA: 0x000795F4 File Offset: 0x000777F4
		public string GetAttributeValue(string attributeName)
		{
			string result;
			this.TryGetAttributeValue(attributeName, out result);
			return result;
		}

		// Token: 0x06002028 RID: 8232 RVA: 0x00079614 File Offset: 0x00077814
		public bool TryGetAttributeValue(string propertyName, out string value)
		{
			bool flag = this.m_Properties == null;
			bool result;
			if (flag)
			{
				value = null;
				result = false;
			}
			else
			{
				for (int i = 0; i < this.m_Properties.Count - 1; i += 2)
				{
					bool flag2 = this.m_Properties[i] == propertyName;
					if (flag2)
					{
						value = this.m_Properties[i + 1];
						return true;
					}
				}
				value = null;
				result = false;
			}
			return result;
		}

		// Token: 0x06002029 RID: 8233 RVA: 0x0007968A File Offset: 0x0007788A
		public void SetAttribute(string name, string value)
		{
			this.SetOrAddProperty(name, value);
		}

		// Token: 0x0600202A RID: 8234 RVA: 0x00079698 File Offset: 0x00077898
		public void RemoveAttribute(string attributeName)
		{
			bool flag = this.m_Properties == null || this.m_Properties.Count <= 0;
			if (!flag)
			{
				for (int i = 0; i < this.m_Properties.Count; i += 2)
				{
					string a = this.m_Properties[i];
					bool flag2 = a != attributeName;
					if (!flag2)
					{
						this.m_Properties.RemoveAt(i);
						this.m_Properties.RemoveAt(i);
						break;
					}
				}
			}
		}

		// Token: 0x0600202B RID: 8235 RVA: 0x0007971C File Offset: 0x0007791C
		private void SetOrAddProperty(string propertyName, string propertyValue)
		{
			bool flag = this.m_Properties == null;
			if (flag)
			{
				this.m_Properties = new List<string>();
			}
			for (int i = 0; i < this.m_Properties.Count - 1; i += 2)
			{
				bool flag2 = this.m_Properties[i] == propertyName;
				if (flag2)
				{
					this.m_Properties[i + 1] = propertyValue;
					return;
				}
			}
			this.m_Properties.Add(propertyName);
			this.m_Properties.Add(propertyValue);
		}

		// Token: 0x04000D3D RID: 3389
		[SerializeField]
		private string m_FullTypeName;

		// Token: 0x04000D3E RID: 3390
		[SerializeField]
		private int m_Id;

		// Token: 0x04000D3F RID: 3391
		[SerializeField]
		private int m_OrderInDocument;

		// Token: 0x04000D40 RID: 3392
		[SerializeField]
		private int m_ParentId;

		// Token: 0x04000D41 RID: 3393
		[SerializeField]
		protected List<string> m_Properties;
	}
}
