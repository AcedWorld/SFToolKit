using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000025 RID: 37
[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
public class vCheckPropertyAttribute : PropertyAttribute
{
	// Token: 0x06000093 RID: 147 RVA: 0x00007C64 File Offset: 0x00005E64
	public vCheckPropertyAttribute(string propertyNames, params object[] values)
	{
		this.checkValues.Clear();
		string[] array = propertyNames.Split(',', StringSplitOptions.None);
		for (int i = 0; i < array.Length; i++)
		{
			try
			{
				this.checkValues.Add(new vCheckPropertyAttribute.CheckValue(array[i], values[i]));
			}
			catch
			{
				break;
			}
		}
	}

	// Token: 0x040000D5 RID: 213
	public List<vCheckPropertyAttribute.CheckValue> checkValues = new List<vCheckPropertyAttribute.CheckValue>();

	// Token: 0x040000D6 RID: 214
	public bool hideInInspector;

	// Token: 0x040000D7 RID: 215
	public bool invertResult;

	// Token: 0x02000026 RID: 38
	[Serializable]
	public struct CheckValue
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00007CD4 File Offset: 0x00005ED4
		public bool isValid
		{
			get
			{
				return this.value != null;
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00007CDF File Offset: 0x00005EDF
		public CheckValue(string property, object value)
		{
			this.property = property;
			this.value = value;
		}

		// Token: 0x040000D8 RID: 216
		public string property;

		// Token: 0x040000D9 RID: 217
		public object value;
	}
}
