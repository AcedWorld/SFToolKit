using System;
using System.Collections.Generic;
using System.Text;

namespace UnityEngine.UIElements.StyleSheets
{
	// Token: 0x020004A4 RID: 1188
	internal class StylePropertyValueParser
	{
		// Token: 0x06002519 RID: 9497 RVA: 0x0009C594 File Offset: 0x0009A794
		public string[] Parse(string propertyValue)
		{
			this.m_PropertyValue = propertyValue;
			this.m_ValueList.Clear();
			this.m_StringBuilder.Remove(0, this.m_StringBuilder.Length);
			this.m_ParseIndex = 0;
			while (this.m_ParseIndex < this.m_PropertyValue.Length)
			{
				char c = this.m_PropertyValue[this.m_ParseIndex];
				char c2 = c;
				char c3 = c2;
				if (c3 != ' ')
				{
					if (c3 != '(')
					{
						if (c3 != ',')
						{
							this.m_StringBuilder.Append(c);
						}
						else
						{
							this.EatSpace();
							this.AddValuePart();
							this.m_ValueList.Add(",");
						}
					}
					else
					{
						this.AppendFunction();
					}
				}
				else
				{
					this.EatSpace();
					this.AddValuePart();
				}
				this.m_ParseIndex++;
			}
			string text = this.m_StringBuilder.ToString();
			bool flag = !string.IsNullOrEmpty(text);
			if (flag)
			{
				this.m_ValueList.Add(text);
			}
			return this.m_ValueList.ToArray();
		}

		// Token: 0x0600251A RID: 9498 RVA: 0x0009C6B4 File Offset: 0x0009A8B4
		private void AddValuePart()
		{
			string item = this.m_StringBuilder.ToString();
			this.m_StringBuilder.Remove(0, this.m_StringBuilder.Length);
			this.m_ValueList.Add(item);
		}

		// Token: 0x0600251B RID: 9499 RVA: 0x0009C6F4 File Offset: 0x0009A8F4
		private void AppendFunction()
		{
			while (this.m_ParseIndex < this.m_PropertyValue.Length && this.m_PropertyValue[this.m_ParseIndex] != ')')
			{
				this.m_StringBuilder.Append(this.m_PropertyValue[this.m_ParseIndex]);
				this.m_ParseIndex++;
			}
			this.m_StringBuilder.Append(this.m_PropertyValue[this.m_ParseIndex]);
		}

		// Token: 0x0600251C RID: 9500 RVA: 0x0009C780 File Offset: 0x0009A980
		private void EatSpace()
		{
			while (this.m_ParseIndex + 1 < this.m_PropertyValue.Length && this.m_PropertyValue[this.m_ParseIndex + 1] == ' ')
			{
				this.m_ParseIndex++;
			}
		}

		// Token: 0x040011D6 RID: 4566
		private string m_PropertyValue;

		// Token: 0x040011D7 RID: 4567
		private List<string> m_ValueList = new List<string>();

		// Token: 0x040011D8 RID: 4568
		private StringBuilder m_StringBuilder = new StringBuilder();

		// Token: 0x040011D9 RID: 4569
		private int m_ParseIndex = 0;
	}
}
