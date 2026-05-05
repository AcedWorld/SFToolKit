using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityEngine.UIElements
{
	// Token: 0x020003A8 RID: 936
	public abstract class UxmlAttributeDescription
	{
		// Token: 0x06001F4A RID: 8010 RVA: 0x0007786E File Offset: 0x00075A6E
		protected UxmlAttributeDescription()
		{
			this.use = UxmlAttributeDescription.Use.Optional;
			this.restriction = null;
		}

		// Token: 0x17000742 RID: 1858
		// (get) Token: 0x06001F4B RID: 8011 RVA: 0x00077888 File Offset: 0x00075A88
		// (set) Token: 0x06001F4C RID: 8012 RVA: 0x00077890 File Offset: 0x00075A90
		public string name { get; set; }

		// Token: 0x17000743 RID: 1859
		// (get) Token: 0x06001F4D RID: 8013 RVA: 0x0007789C File Offset: 0x00075A9C
		// (set) Token: 0x06001F4E RID: 8014 RVA: 0x000778B4 File Offset: 0x00075AB4
		public IEnumerable<string> obsoleteNames
		{
			get
			{
				return this.m_ObsoleteNames;
			}
			set
			{
				this.m_ObsoleteNames = value.ToArray<string>();
			}
		}

		// Token: 0x17000744 RID: 1860
		// (get) Token: 0x06001F4F RID: 8015 RVA: 0x000778C3 File Offset: 0x00075AC3
		// (set) Token: 0x06001F50 RID: 8016 RVA: 0x000778CB File Offset: 0x00075ACB
		public string type { get; protected set; }

		// Token: 0x17000745 RID: 1861
		// (get) Token: 0x06001F51 RID: 8017 RVA: 0x000778D4 File Offset: 0x00075AD4
		// (set) Token: 0x06001F52 RID: 8018 RVA: 0x000778DC File Offset: 0x00075ADC
		public string typeNamespace { get; protected set; }

		// Token: 0x17000746 RID: 1862
		// (get) Token: 0x06001F53 RID: 8019
		public abstract string defaultValueAsString { get; }

		// Token: 0x17000747 RID: 1863
		// (get) Token: 0x06001F54 RID: 8020 RVA: 0x000778E5 File Offset: 0x00075AE5
		// (set) Token: 0x06001F55 RID: 8021 RVA: 0x000778ED File Offset: 0x00075AED
		public UxmlAttributeDescription.Use use { get; set; }

		// Token: 0x17000748 RID: 1864
		// (get) Token: 0x06001F56 RID: 8022 RVA: 0x000778F6 File Offset: 0x00075AF6
		// (set) Token: 0x06001F57 RID: 8023 RVA: 0x000778FE File Offset: 0x00075AFE
		public UxmlTypeRestriction restriction { get; set; }

		// Token: 0x06001F58 RID: 8024 RVA: 0x00077908 File Offset: 0x00075B08
		internal bool TryGetValueFromBagAsString(IUxmlAttributes bag, CreationContext cc, out string value)
		{
			bool flag = this.name == null && (this.m_ObsoleteNames == null || this.m_ObsoleteNames.Length == 0);
			bool result;
			if (flag)
			{
				Debug.LogError("Attribute description has no name.");
				value = null;
				result = false;
			}
			else
			{
				string text;
				bag.TryGetAttributeValue("name", out text);
				bool flag2 = !string.IsNullOrEmpty(text) && cc.attributeOverrides != null;
				if (flag2)
				{
					for (int i = 0; i < cc.attributeOverrides.Count; i++)
					{
						bool flag3 = cc.attributeOverrides[i].m_ElementName != text;
						if (!flag3)
						{
							bool flag4 = cc.attributeOverrides[i].m_AttributeName != this.name;
							if (flag4)
							{
								bool flag5 = this.m_ObsoleteNames != null;
								if (!flag5)
								{
									goto IL_147;
								}
								bool flag6 = false;
								for (int j = 0; j < this.m_ObsoleteNames.Length; j++)
								{
									bool flag7 = cc.attributeOverrides[i].m_AttributeName == this.m_ObsoleteNames[j];
									if (flag7)
									{
										flag6 = true;
										break;
									}
								}
								bool flag8 = !flag6;
								if (flag8)
								{
									goto IL_147;
								}
							}
							value = cc.attributeOverrides[i].m_Value;
							return true;
						}
						IL_147:;
					}
				}
				bool flag9 = this.name == null;
				if (flag9)
				{
					for (int k = 0; k < this.m_ObsoleteNames.Length; k++)
					{
						bool flag10 = bag.TryGetAttributeValue(this.m_ObsoleteNames[k], out value);
						if (flag10)
						{
							bool flag11 = cc.visualTreeAsset != null;
							if (flag11)
							{
							}
							return true;
						}
					}
					value = null;
					result = false;
				}
				else
				{
					bool flag12 = !bag.TryGetAttributeValue(this.name, out value);
					if (flag12)
					{
						bool flag13 = this.m_ObsoleteNames != null;
						if (flag13)
						{
							for (int l = 0; l < this.m_ObsoleteNames.Length; l++)
							{
								bool flag14 = bag.TryGetAttributeValue(this.m_ObsoleteNames[l], out value);
								if (flag14)
								{
									bool flag15 = cc.visualTreeAsset != null;
									if (flag15)
									{
									}
									return true;
								}
							}
						}
						value = null;
						result = false;
					}
					else
					{
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x06001F59 RID: 8025 RVA: 0x00077B6C File Offset: 0x00075D6C
		protected bool TryGetValueFromBag<T>(IUxmlAttributes bag, CreationContext cc, Func<string, T, T> converterFunc, T defaultValue, ref T value)
		{
			string arg;
			bool flag = this.TryGetValueFromBagAsString(bag, cc, out arg);
			bool result;
			if (flag)
			{
				bool flag2 = converterFunc != null;
				if (flag2)
				{
					value = converterFunc(arg, defaultValue);
				}
				else
				{
					value = defaultValue;
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001F5A RID: 8026 RVA: 0x00077BBC File Offset: 0x00075DBC
		protected T GetValueFromBag<T>(IUxmlAttributes bag, CreationContext cc, Func<string, T, T> converterFunc, T defaultValue)
		{
			bool flag = converterFunc == null;
			if (flag)
			{
				throw new ArgumentNullException("converterFunc");
			}
			string arg;
			bool flag2 = this.TryGetValueFromBagAsString(bag, cc, out arg);
			T result;
			if (flag2)
			{
				result = converterFunc(arg, defaultValue);
			}
			else
			{
				result = defaultValue;
			}
			return result;
		}

		// Token: 0x04000CF3 RID: 3315
		protected const string xmlSchemaNamespace = "http://www.w3.org/2001/XMLSchema";

		// Token: 0x04000CF5 RID: 3317
		private string[] m_ObsoleteNames;

		// Token: 0x020003A9 RID: 937
		public enum Use
		{
			// Token: 0x04000CFB RID: 3323
			None,
			// Token: 0x04000CFC RID: 3324
			Optional,
			// Token: 0x04000CFD RID: 3325
			Prohibited,
			// Token: 0x04000CFE RID: 3326
			Required
		}
	}
}
