using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Unity.VisualScripting
{
	// Token: 0x020000D9 RID: 217
	public sealed class Namespace
	{
		// Token: 0x0600060F RID: 1551 RVA: 0x0000FA84 File Offset: 0x0000DC84
		private Namespace(string fullName)
		{
			this.FullName = fullName;
			if (fullName == null)
			{
				this.Root = this;
				this.IsRoot = 1;
				this.IsGlobal = 1;
				return;
			}
			string[] array = fullName.Split('.', StringSplitOptions.None);
			this.Name = array[array.Length - 1];
			if (array.Length > 1)
			{
				this.Root = array[0];
				this.Parent = fullName.Substring(0, fullName.LastIndexOf('.'));
				return;
			}
			this.Root = this;
			this.IsRoot = 1;
			this.Parent = Namespace.Global;
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000610 RID: 1552 RVA: 0x0000FB16 File Offset: 0x0000DD16
		public Namespace Root { get; }

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000611 RID: 1553 RVA: 0x0000FB1E File Offset: 0x0000DD1E
		public Namespace Parent { get; }

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000612 RID: 1554 RVA: 0x0000FB26 File Offset: 0x0000DD26
		public string FullName { get; }

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000613 RID: 1555 RVA: 0x0000FB2E File Offset: 0x0000DD2E
		public string Name { get; }

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000614 RID: 1556 RVA: 0x0000FB36 File Offset: 0x0000DD36
		public bool IsRoot { get; }

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000615 RID: 1557 RVA: 0x0000FB3E File Offset: 0x0000DD3E
		public bool IsGlobal { get; }

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000616 RID: 1558 RVA: 0x0000FB46 File Offset: 0x0000DD46
		public IEnumerable<Namespace> Ancestors
		{
			get
			{
				Namespace ancestor = this.Parent;
				while (ancestor != null)
				{
					yield return ancestor;
					ancestor = ancestor.Parent;
				}
				yield break;
			}
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x0000FB56 File Offset: 0x0000DD56
		public IEnumerable<Namespace> AndAncestors()
		{
			yield return this;
			foreach (Namespace @namespace in this.Ancestors)
			{
				yield return @namespace;
			}
			IEnumerator<Namespace> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x0000FB66 File Offset: 0x0000DD66
		public override int GetHashCode()
		{
			if (this.FullName == null)
			{
				return 0;
			}
			return this.FullName.GetHashCode();
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x0000FB7D File Offset: 0x0000DD7D
		public override string ToString()
		{
			return this.FullName;
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x0600061B RID: 1563 RVA: 0x0000FB9C File Offset: 0x0000DD9C
		public static Namespace Global { get; } = new Namespace(null);

		// Token: 0x0600061C RID: 1564 RVA: 0x0000FBA4 File Offset: 0x0000DDA4
		public static Namespace FromFullName(string fullName)
		{
			if (fullName == null)
			{
				return Namespace.Global;
			}
			Namespace @namespace;
			if (!Namespace.collection.TryGetValue(fullName, out @namespace))
			{
				@namespace = new Namespace(fullName);
				Namespace.collection.Add(@namespace);
			}
			return @namespace;
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x0000FBDC File Offset: 0x0000DDDC
		public override bool Equals(object obj)
		{
			Namespace @namespace = obj as Namespace;
			return !(@namespace == null) && this.FullName == @namespace.FullName;
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x0000FC0C File Offset: 0x0000DE0C
		public static implicit operator Namespace(string fullName)
		{
			return Namespace.FromFullName(fullName);
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x0000FC14 File Offset: 0x0000DE14
		public static implicit operator string(Namespace @namespace)
		{
			return @namespace.FullName;
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x0000FC1C File Offset: 0x0000DE1C
		public static bool operator ==(Namespace a, Namespace b)
		{
			return a == b || (a != null && b != null && a.Equals(b));
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x0000FC33 File Offset: 0x0000DE33
		public static bool operator !=(Namespace a, Namespace b)
		{
			return !(a == b);
		}

		// Token: 0x0400015B RID: 347
		private static readonly Namespace.Collection collection = new Namespace.Collection();

		// Token: 0x020001DE RID: 478
		private class Collection : KeyedCollection<string, Namespace>, IKeyedCollection<string, Namespace>, ICollection<Namespace>, IEnumerable<Namespace>, IEnumerable
		{
			// Token: 0x06000C53 RID: 3155 RVA: 0x00032D54 File Offset: 0x00030F54
			protected override string GetKeyForItem(Namespace item)
			{
				return item.FullName;
			}

			// Token: 0x06000C54 RID: 3156 RVA: 0x00032D5C File Offset: 0x00030F5C
			public new bool TryGetValue(string key, out Namespace value)
			{
				if (base.Dictionary == null)
				{
					value = null;
					return false;
				}
				return base.Dictionary.TryGetValue(key, out value);
			}

			// Token: 0x06000C56 RID: 3158 RVA: 0x00032D80 File Offset: 0x00030F80
			Namespace IKeyedCollection<string, Namespace>.get_Item(string key)
			{
				return base[key];
			}

			// Token: 0x06000C57 RID: 3159 RVA: 0x00032D89 File Offset: 0x00030F89
			bool IKeyedCollection<string, Namespace>.Contains(string key)
			{
				return base.Contains(key);
			}

			// Token: 0x06000C58 RID: 3160 RVA: 0x00032D92 File Offset: 0x00030F92
			bool IKeyedCollection<string, Namespace>.Remove(string key)
			{
				return base.Remove(key);
			}
		}
	}
}
