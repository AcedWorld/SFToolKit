using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnityEngine.UIElements
{
	// Token: 0x020003C5 RID: 965
	public abstract class BaseUxmlTraits
	{
		// Token: 0x06001FD5 RID: 8149 RVA: 0x00078CE8 File Offset: 0x00076EE8
		protected BaseUxmlTraits()
		{
			this.canHaveAnyAttribute = true;
		}

		// Token: 0x1700075A RID: 1882
		// (get) Token: 0x06001FD6 RID: 8150 RVA: 0x00078CFA File Offset: 0x00076EFA
		// (set) Token: 0x06001FD7 RID: 8151 RVA: 0x00078D02 File Offset: 0x00076F02
		public bool canHaveAnyAttribute { get; protected set; }

		// Token: 0x1700075B RID: 1883
		// (get) Token: 0x06001FD8 RID: 8152 RVA: 0x00078D0C File Offset: 0x00076F0C
		public virtual IEnumerable<UxmlAttributeDescription> uxmlAttributesDescription
		{
			get
			{
				foreach (UxmlAttributeDescription attributeDescription in this.GetAllAttributeDescriptionForType(base.GetType()))
				{
					yield return attributeDescription;
					attributeDescription = null;
				}
				IEnumerator<UxmlAttributeDescription> enumerator = null;
				yield break;
				yield break;
			}
		}

		// Token: 0x1700075C RID: 1884
		// (get) Token: 0x06001FD9 RID: 8153 RVA: 0x00078D2C File Offset: 0x00076F2C
		public virtual IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
		{
			get
			{
				yield break;
			}
		}

		// Token: 0x06001FDA RID: 8154 RVA: 0x00078D4B File Offset: 0x00076F4B
		private IEnumerable<UxmlAttributeDescription> GetAllAttributeDescriptionForType(Type t)
		{
			Type baseType = t.BaseType;
			bool flag = baseType != null;
			if (flag)
			{
				foreach (UxmlAttributeDescription ident in this.GetAllAttributeDescriptionForType(baseType))
				{
					yield return ident;
					ident = null;
				}
				IEnumerator<UxmlAttributeDescription> enumerator = null;
			}
			foreach (FieldInfo fieldInfo in from f in t.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
			where typeof(UxmlAttributeDescription).IsAssignableFrom(f.FieldType)
			select f)
			{
				yield return (UxmlAttributeDescription)fieldInfo.GetValue(this);
				fieldInfo = null;
			}
			IEnumerator<FieldInfo> enumerator2 = null;
			yield break;
			yield break;
		}
	}
}
