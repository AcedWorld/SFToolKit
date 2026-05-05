using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200003E RID: 62
[Serializable]
public class vTagMask : IList<string>, ICollection<string>, IEnumerable<string>, IEnumerable
{
	// Token: 0x060000D5 RID: 213 RVA: 0x000087E6 File Offset: 0x000069E6
	public vTagMask()
	{
		this.tags = new List<string>();
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x00008804 File Offset: 0x00006A04
	public vTagMask(List<string> tags)
	{
		this.tags = tags;
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x0000881E File Offset: 0x00006A1E
	public vTagMask(params string[] arg)
	{
		this.tags = new List<string>(arg);
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x0000883D File Offset: 0x00006A3D
	public bool Contains(string tag)
	{
		return this.tags.Contains(tag);
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x0000884B File Offset: 0x00006A4B
	public void Add(string tag)
	{
		if (!this.tags.Contains(tag))
		{
			this.tags.Add(tag);
		}
	}

	// Token: 0x060000DA RID: 218 RVA: 0x00008867 File Offset: 0x00006A67
	public void Remove(string tag)
	{
		if (this.tags.Contains(tag))
		{
			this.tags.Remove(tag);
		}
	}

	// Token: 0x060000DB RID: 219 RVA: 0x00008884 File Offset: 0x00006A84
	public void Clear()
	{
		this.tags.Clear();
	}

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x060000DC RID: 220 RVA: 0x00008891 File Offset: 0x00006A91
	public int Count
	{
		get
		{
			return this.tags.Count;
		}
	}

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x060000DD RID: 221 RVA: 0x0000889E File Offset: 0x00006A9E
	public bool IsReadOnly
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000009 RID: 9
	public string this[int index]
	{
		get
		{
			return this.tags[index];
		}
		set
		{
			if (!this.tags.Contains(value))
			{
				this.tags[index] = value;
			}
		}
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x000088CC File Offset: 0x00006ACC
	IEnumerator<string> IEnumerable<string>.GetEnumerator()
	{
		return this.tags.GetEnumerator();
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x000088CC File Offset: 0x00006ACC
	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.tags.GetEnumerator();
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x000088DE File Offset: 0x00006ADE
	public int IndexOf(string item)
	{
		return this.tags.IndexOf(item);
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x000088EC File Offset: 0x00006AEC
	public void Insert(int index, string item)
	{
		if (!this.tags.Contains(item))
		{
			this.tags.Insert(index, item);
		}
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x00008909 File Offset: 0x00006B09
	public void RemoveAt(int index)
	{
		if (index >= 0 && index < this.tags.Count)
		{
			this.tags.RemoveAt(index);
		}
	}

	// Token: 0x060000E5 RID: 229 RVA: 0x00008929 File Offset: 0x00006B29
	public void CopyTo(string[] array, int arrayIndex)
	{
		this.tags.CopyTo(array, arrayIndex);
	}

	// Token: 0x060000E6 RID: 230 RVA: 0x00008938 File Offset: 0x00006B38
	bool ICollection<string>.Remove(string item)
	{
		return this.tags.Contains(item) && this.tags.Remove(item);
	}

	// Token: 0x060000E7 RID: 231 RVA: 0x00008956 File Offset: 0x00006B56
	public static implicit operator List<string>(vTagMask t)
	{
		return t.tags;
	}

	// Token: 0x060000E8 RID: 232 RVA: 0x0000895E File Offset: 0x00006B5E
	public static implicit operator string[](vTagMask t)
	{
		return t.tags.ToArray();
	}

	// Token: 0x060000E9 RID: 233 RVA: 0x0000896B File Offset: 0x00006B6B
	public static implicit operator vTagMask(List<string> l)
	{
		return new vTagMask(l);
	}

	// Token: 0x060000EA RID: 234 RVA: 0x00008973 File Offset: 0x00006B73
	public static implicit operator vTagMask(string[] l)
	{
		return new vTagMask(l);
	}

	// Token: 0x060000EB RID: 235 RVA: 0x0000897C File Offset: 0x00006B7C
	public static vTagMask operator +(vTagMask a, vTagMask b)
	{
		for (int i = 0; i < b.tags.Count; i++)
		{
			if (!a.Contains(b.tags[i]))
			{
				a.Add(b.tags[i]);
			}
		}
		return a.tags;
	}

	// Token: 0x060000EC RID: 236 RVA: 0x000089D0 File Offset: 0x00006BD0
	public static vTagMask operator -(vTagMask a, vTagMask b)
	{
		for (int i = 0; i < b.tags.Count; i++)
		{
			if (a.Contains(b.tags[i]))
			{
				a.Remove(b.tags[i]);
			}
		}
		return a.tags;
	}

	// Token: 0x060000ED RID: 237 RVA: 0x00008A24 File Offset: 0x00006C24
	public static vTagMask operator +(vTagMask a, List<string> b)
	{
		for (int i = 0; i < b.Count; i++)
		{
			if (!a.Contains(b[i]))
			{
				a.Add(b[i]);
			}
		}
		return a.tags;
	}

	// Token: 0x060000EE RID: 238 RVA: 0x00008A6C File Offset: 0x00006C6C
	public static vTagMask operator -(vTagMask a, List<string> b)
	{
		for (int i = 0; i < b.Count; i++)
		{
			if (a.Contains(b[i]))
			{
				a.Remove(b[i]);
			}
		}
		return a.tags;
	}

	// Token: 0x060000EF RID: 239 RVA: 0x00008AB4 File Offset: 0x00006CB4
	public static vTagMask operator +(vTagMask a, string[] b)
	{
		for (int i = 0; i < b.Length; i++)
		{
			if (!a.Contains(b[i]))
			{
				a.Add(b[i]);
			}
		}
		return a.tags;
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x00008AF0 File Offset: 0x00006CF0
	public static vTagMask operator -(vTagMask a, string[] b)
	{
		for (int i = 0; i < b.Length; i++)
		{
			if (a.Contains(b[i]))
			{
				a.Remove(b[i]);
			}
		}
		return a.tags;
	}

	// Token: 0x0400011F RID: 287
	[SerializeField]
	private List<string> tags = new List<string>();
}
