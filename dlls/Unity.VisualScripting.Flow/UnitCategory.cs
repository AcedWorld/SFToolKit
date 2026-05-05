using System;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;

namespace Unity.VisualScripting
{
	// Token: 0x0200017F RID: 383
	[AttributeUsage(AttributeTargets.Class)]
	[fsObject(Converter = typeof(UnitCategoryConverter))]
	public class UnitCategory : Attribute
	{
		// Token: 0x06000A47 RID: 2631 RVA: 0x00012718 File Offset: 0x00010918
		public UnitCategory(string fullName)
		{
			Ensure.That("fullName").IsNotNull(fullName);
			fullName = fullName.Replace('\\', '/');
			this.fullName = fullName;
			string[] array = fullName.Split('/', StringSplitOptions.None);
			this.name = array[array.Length - 1];
			if (array.Length > 1)
			{
				this.root = new UnitCategory(array[0]);
				this.parent = new UnitCategory(fullName.Substring(0, fullName.LastIndexOf('/')));
				return;
			}
			this.root = this;
			this.isRoot = 1;
		}

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x06000A48 RID: 2632 RVA: 0x000127A2 File Offset: 0x000109A2
		public UnitCategory root { get; }

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x06000A49 RID: 2633 RVA: 0x000127AA File Offset: 0x000109AA
		public UnitCategory parent { get; }

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x06000A4A RID: 2634 RVA: 0x000127B2 File Offset: 0x000109B2
		public string fullName { get; }

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06000A4B RID: 2635 RVA: 0x000127BA File Offset: 0x000109BA
		public string name { get; }

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x06000A4C RID: 2636 RVA: 0x000127C2 File Offset: 0x000109C2
		public bool isRoot { get; }

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06000A4D RID: 2637 RVA: 0x000127CA File Offset: 0x000109CA
		public IEnumerable<UnitCategory> ancestors
		{
			get
			{
				UnitCategory ancestor = this.parent;
				while (ancestor != null)
				{
					yield return ancestor;
					ancestor = ancestor.parent;
				}
				yield break;
			}
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x000127DA File Offset: 0x000109DA
		public IEnumerable<UnitCategory> AndAncestors()
		{
			yield return this;
			foreach (UnitCategory unitCategory in this.ancestors)
			{
				yield return unitCategory;
			}
			IEnumerator<UnitCategory> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x000127EA File Offset: 0x000109EA
		public override bool Equals(object obj)
		{
			return obj is UnitCategory && ((UnitCategory)obj).fullName == this.fullName;
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x0001280C File Offset: 0x00010A0C
		public override int GetHashCode()
		{
			return this.fullName.GetHashCode();
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x00012819 File Offset: 0x00010A19
		public override string ToString()
		{
			return this.fullName;
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x00012821 File Offset: 0x00010A21
		public static bool operator ==(UnitCategory a, UnitCategory b)
		{
			return a == b || (a != null && b != null && a.Equals(b));
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x00012838 File Offset: 0x00010A38
		public static bool operator !=(UnitCategory a, UnitCategory b)
		{
			return !(a == b);
		}
	}
}
