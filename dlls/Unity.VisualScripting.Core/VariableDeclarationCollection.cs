using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Unity.VisualScripting
{
	// Token: 0x02000171 RID: 369
	[SerializationVersion("A", new Type[]
	{

	})]
	public sealed class VariableDeclarationCollection : KeyedCollection<string, VariableDeclaration>, IKeyedCollection<string, VariableDeclaration>, ICollection<VariableDeclaration>, IEnumerable<VariableDeclaration>, IEnumerable
	{
		// Token: 0x060009D3 RID: 2515 RVA: 0x00029724 File Offset: 0x00027924
		protected override string GetKeyForItem(VariableDeclaration item)
		{
			return item.name;
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x0002972C File Offset: 0x0002792C
		public void EditorRename(VariableDeclaration item, string newName)
		{
			base.ChangeItemKey(item, newName);
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x00029736 File Offset: 0x00027936
		public new bool TryGetValue(string key, out VariableDeclaration value)
		{
			if (base.Dictionary == null)
			{
				value = null;
				return false;
			}
			return base.Dictionary.TryGetValue(key, out value);
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x0002975A File Offset: 0x0002795A
		VariableDeclaration IKeyedCollection<string, VariableDeclaration>.get_Item(string key)
		{
			return base[key];
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x00029763 File Offset: 0x00027963
		bool IKeyedCollection<string, VariableDeclaration>.Contains(string key)
		{
			return base.Contains(key);
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x0002976C File Offset: 0x0002796C
		bool IKeyedCollection<string, VariableDeclaration>.Remove(string key)
		{
			return base.Remove(key);
		}
	}
}
