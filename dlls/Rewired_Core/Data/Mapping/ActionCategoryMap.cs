using System;
using System.Collections.Generic;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	// Token: 0x020002A9 RID: 681
	[Serializable]
	public sealed class ActionCategoryMap
	{
		// Token: 0x06001E9F RID: 7839 RVA: 0x00017FAA File Offset: 0x000161AA
		public IEnumerable<int> ActionIdsInCategory(int categoryId)
		{
			if (this.list == null)
			{
				yield break;
			}
			int num = this.IndexOfCategory(categoryId);
			if (num < 0)
			{
				yield break;
			}
			foreach (int num2 in this.list[num].ActionIds)
			{
				yield return num2;
			}
			IEnumerator<int> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06001EA0 RID: 7840 RVA: 0x00017FC1 File Offset: 0x000161C1
		public ActionCategoryMap()
		{
			this.list = new List<ActionCategoryMap.Entry>();
		}

		// Token: 0x06001EA1 RID: 7841 RVA: 0x00080950 File Offset: 0x0007EB50
		public ActionCategoryMap(ActionCategoryMap A_1)
		{
			if (A_1.list != null)
			{
				this.list = new List<ActionCategoryMap.Entry>(A_1.list.Count);
				for (int i = 0; i < A_1.list.Count; i++)
				{
					this.list[i] = A_1.list[i].Clone();
				}
			}
		}

		// Token: 0x06001EA2 RID: 7842 RVA: 0x00017FD4 File Offset: 0x000161D4
		public void AddCategory(int id)
		{
			this.list.Add(new ActionCategoryMap.Entry(id));
		}

		// Token: 0x06001EA3 RID: 7843 RVA: 0x000809B4 File Offset: 0x0007EBB4
		public void RemoveCategory(int id)
		{
			int num = this.IndexOfCategory(id);
			if (num < 0)
			{
				return;
			}
			this.list.RemoveAt(num);
		}

		// Token: 0x06001EA4 RID: 7844 RVA: 0x000809DC File Offset: 0x0007EBDC
		public bool ReorderCategory(int id, bool offsetDown)
		{
			int num = this.IndexOfCategory(id);
			if (num < 0)
			{
				return false;
			}
			if (!offsetDown && num == 0)
			{
				return false;
			}
			if (offsetDown && num >= this.list.Count - 1)
			{
				return false;
			}
			ActionCategoryMap.Entry value = this.list[num];
			if (offsetDown)
			{
				this.list[num] = this.list[num + 1];
				this.list[num + 1] = value;
			}
			else
			{
				this.list[num] = this.list[num - 1];
				this.list[num - 1] = value;
			}
			return true;
		}

		// Token: 0x06001EA5 RID: 7845 RVA: 0x00080A7C File Offset: 0x0007EC7C
		public bool ChangeCategory(int actionId, int newCategoryId)
		{
			if (this.list == null)
			{
				return false;
			}
			bool result = false;
			for (int i = 0; i < this.list.Count; i++)
			{
				if (this.list[i].ContainsAction(actionId))
				{
					this.list[i].RemoveAction(actionId);
				}
			}
			for (int j = 0; j < this.list.Count; j++)
			{
				if (this.list[j].categoryId == newCategoryId)
				{
					this.list[j].AddAction(actionId);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06001EA6 RID: 7846 RVA: 0x00080B10 File Offset: 0x0007ED10
		public int IndexOfCategory(int id)
		{
			if (this.list == null)
			{
				return -1;
			}
			for (int i = 0; i < this.list.Count; i++)
			{
				if (this.list[i].categoryId == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001EA7 RID: 7847 RVA: 0x00080B54 File Offset: 0x0007ED54
		public bool AddAction(int categoryId, int actionId)
		{
			if (this.list == null)
			{
				return false;
			}
			int num = this.IndexOfCategory(categoryId);
			if (num < 0)
			{
				return false;
			}
			this.list[num].AddAction(actionId);
			return true;
		}

		// Token: 0x06001EA8 RID: 7848 RVA: 0x00080B8C File Offset: 0x0007ED8C
		public bool InsertAction(int categoryId, int actionId, int index)
		{
			if (index < 0)
			{
				return false;
			}
			int num = this.IndexOfCategory(categoryId);
			return num >= 0 && this.list[num].InsertAction(actionId, index);
		}

		// Token: 0x06001EA9 RID: 7849 RVA: 0x00080BC0 File Offset: 0x0007EDC0
		public bool ReorderAction(int categoryId, int actionId, bool offsetDown, bool offsetNow)
		{
			int num = this.IndexOfCategory(categoryId);
			return num >= 0 && this.list[num].ReorderAction(actionId, offsetDown, offsetNow);
		}

		// Token: 0x06001EAA RID: 7850 RVA: 0x00080BF0 File Offset: 0x0007EDF0
		public void RemoveAction(int categoryId, int actionId)
		{
			int num = this.IndexOfCategory(categoryId);
			if (num < 0)
			{
				return;
			}
			this.list[num].RemoveAction(actionId);
		}

		// Token: 0x06001EAB RID: 7851 RVA: 0x00080C1C File Offset: 0x0007EE1C
		public int IndexOfAction(int categoryId, int actionId)
		{
			int num = this.IndexOfCategory(categoryId);
			if (num < 0)
			{
				return -1;
			}
			return this.list[num].IndexOfAction(actionId);
		}

		// Token: 0x06001EAC RID: 7852 RVA: 0x00017FE7 File Offset: 0x000161E7
		public ActionCategoryMap Clone()
		{
			return new ActionCategoryMap(this);
		}

		// Token: 0x04001139 RID: 4409
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ActionCategoryMap.Entry> list;

		// Token: 0x020002AA RID: 682
		[Serializable]
		public class Entry
		{
			// Token: 0x170006E3 RID: 1763
			// (get) Token: 0x06001EAD RID: 7853 RVA: 0x00017FEF File Offset: 0x000161EF
			public IEnumerable<int> ActionIds
			{
				get
				{
					if (this.actionIds == null)
					{
						yield break;
					}
					int num;
					for (int i = 0; i < this.actionIds.Count; i = num + 1)
					{
						yield return this.actionIds[i];
						num = i;
					}
					yield break;
				}
			}

			// Token: 0x06001EAE RID: 7854 RVA: 0x00017FFF File Offset: 0x000161FF
			public Entry()
			{
				this.actionIds = new List<int>();
			}

			// Token: 0x06001EAF RID: 7855 RVA: 0x00018012 File Offset: 0x00016212
			public Entry(int A_1) : this()
			{
				this.categoryId = A_1;
			}

			// Token: 0x06001EB0 RID: 7856 RVA: 0x00018021 File Offset: 0x00016221
			public Entry(ActionCategoryMap.Entry A_1)
			{
				this.actionIds = ListTools.ShallowCopy<int>(A_1.actionIds);
			}

			// Token: 0x06001EB1 RID: 7857 RVA: 0x0001803A File Offset: 0x0001623A
			public void AddAction(int actionId)
			{
				if (this.actionIds.Contains(actionId))
				{
					return;
				}
				this.actionIds.Add(actionId);
			}

			// Token: 0x06001EB2 RID: 7858 RVA: 0x00080C4C File Offset: 0x0007EE4C
			public bool InsertAction(int actionId, int index)
			{
				if (index < 0)
				{
					return false;
				}
				if (this.actionIds.Contains(actionId))
				{
					return true;
				}
				if (index >= this.actionIds.Count)
				{
					this.actionIds.Add(actionId);
				}
				else
				{
					this.actionIds.Insert(index, actionId);
				}
				return true;
			}

			// Token: 0x06001EB3 RID: 7859 RVA: 0x00080C9C File Offset: 0x0007EE9C
			public bool ReorderAction(int actionId, bool offsetDown, bool offsetNow)
			{
				int num = this.IndexOfAction(actionId);
				if (num < 0)
				{
					return false;
				}
				if (!offsetDown && num == 0)
				{
					return false;
				}
				if (offsetDown && num >= this.actionIds.Count - 1)
				{
					return false;
				}
				if (!offsetNow)
				{
					return true;
				}
				int value = this.actionIds[num];
				if (offsetDown)
				{
					this.actionIds[num] = this.actionIds[num + 1];
					this.actionIds[num + 1] = value;
				}
				else
				{
					this.actionIds[num] = this.actionIds[num - 1];
					this.actionIds[num - 1] = value;
				}
				return true;
			}

			// Token: 0x06001EB4 RID: 7860 RVA: 0x00080D40 File Offset: 0x0007EF40
			public void RemoveAction(int actionId)
			{
				int num = this.IndexOfAction(actionId);
				if (num < 0)
				{
					return;
				}
				this.actionIds.RemoveAt(num);
			}

			// Token: 0x06001EB5 RID: 7861 RVA: 0x00080D68 File Offset: 0x0007EF68
			public int IndexOfAction(int id)
			{
				if (this.actionIds == null)
				{
					return -1;
				}
				for (int i = 0; i < this.actionIds.Count; i++)
				{
					if (this.actionIds[i] == id)
					{
						return i;
					}
				}
				return -1;
			}

			// Token: 0x06001EB6 RID: 7862 RVA: 0x00018057 File Offset: 0x00016257
			public bool ContainsAction(int id)
			{
				return this.IndexOfAction(id) >= 0;
			}

			// Token: 0x06001EB7 RID: 7863 RVA: 0x00018066 File Offset: 0x00016266
			public ActionCategoryMap.Entry Clone()
			{
				return new ActionCategoryMap.Entry(this);
			}

			// Token: 0x0400113A RID: 4410
			public int categoryId;

			// Token: 0x0400113B RID: 4411
			public List<int> actionIds;
		}
	}
}
