using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000141 RID: 321
	public abstract class SerializedPropertyProvider<T> : ScriptableObject, ISerializedPropertyProvider
	{
		// Token: 0x1700019B RID: 411
		// (get) Token: 0x060008AA RID: 2218 RVA: 0x00026415 File Offset: 0x00024615
		// (set) Token: 0x060008AB RID: 2219 RVA: 0x00026422 File Offset: 0x00024622
		object ISerializedPropertyProvider.item
		{
			get
			{
				return this.item;
			}
			set
			{
				this.item = (T)((object)value);
			}
		}

		// Token: 0x04000211 RID: 529
		[SerializeField]
		protected T item;
	}
}
