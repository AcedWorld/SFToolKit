using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.Utils.Classes
{
	// Token: 0x020004C1 RID: 1217
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[Serializable]
	public abstract class SerializedMethod : ScriptableObject
	{
		// Token: 0x17000B26 RID: 2854
		// (get) Token: 0x060030F7 RID: 12535
		internal abstract TypeWrapper.DataType ResultType { get; }

		// Token: 0x17000B27 RID: 2855
		// (get) Token: 0x060030F8 RID: 12536 RVA: 0x00025692 File Offset: 0x00023892
		internal int DataCount
		{
			get
			{
				if (this._data == null)
				{
					return 0;
				}
				return this._data.Count;
			}
		}

		// Token: 0x17000B28 RID: 2856
		// (get) Token: 0x060030F9 RID: 12537 RVA: 0x000256A9 File Offset: 0x000238A9
		internal TypeWrapper Result
		{
			get
			{
				return this._result;
			}
		}

		// Token: 0x17000B29 RID: 2857
		// (get) Token: 0x060030FA RID: 12538 RVA: 0x000256B1 File Offset: 0x000238B1
		internal bool ResultIsValid
		{
			get
			{
				return this._resultIsValid;
			}
		}

		// Token: 0x060030FB RID: 12539 RVA: 0x000256B9 File Offset: 0x000238B9
		internal TypeWrapper GetData(int index)
		{
			if (index < 0 || index >= this.DataCount)
			{
				throw new IndexOutOfRangeException();
			}
			return this._data[index];
		}

		// Token: 0x060030FC RID: 12540 RVA: 0x000256DA File Offset: 0x000238DA
		internal void AddData(byte item)
		{
			if (!this.rTdXWIsRkCEwnuuXwzeqOyggahoL)
			{
				this.TXutKLGpfYDmERcZBBYnaLbKnUcBA();
			}
			this._data.Add(new TypeWrapper(item));
		}

		// Token: 0x060030FD RID: 12541 RVA: 0x000256FB File Offset: 0x000238FB
		internal void AddData(sbyte item)
		{
			if (!this.rTdXWIsRkCEwnuuXwzeqOyggahoL)
			{
				this.TXutKLGpfYDmERcZBBYnaLbKnUcBA();
			}
			this._data.Add(new TypeWrapper(item));
		}

		// Token: 0x060030FE RID: 12542 RVA: 0x0002571C File Offset: 0x0002391C
		internal void AddData(char item)
		{
			if (!this.rTdXWIsRkCEwnuuXwzeqOyggahoL)
			{
				this.TXutKLGpfYDmERcZBBYnaLbKnUcBA();
			}
			this._data.Add(new TypeWrapper(item));
		}

		// Token: 0x060030FF RID: 12543 RVA: 0x0002573D File Offset: 0x0002393D
		internal void AddData(int item)
		{
			if (!this.rTdXWIsRkCEwnuuXwzeqOyggahoL)
			{
				this.TXutKLGpfYDmERcZBBYnaLbKnUcBA();
			}
			this._data.Add(new TypeWrapper(item));
		}

		// Token: 0x06003100 RID: 12544 RVA: 0x0002575E File Offset: 0x0002395E
		internal void AddData(uint item)
		{
			if (!this.rTdXWIsRkCEwnuuXwzeqOyggahoL)
			{
				this.TXutKLGpfYDmERcZBBYnaLbKnUcBA();
			}
			this._data.Add(new TypeWrapper(item));
		}

		// Token: 0x06003101 RID: 12545 RVA: 0x0002577F File Offset: 0x0002397F
		internal void AddData(long item)
		{
			if (!this.rTdXWIsRkCEwnuuXwzeqOyggahoL)
			{
				this.TXutKLGpfYDmERcZBBYnaLbKnUcBA();
			}
			this._data.Add(new TypeWrapper(item));
		}

		// Token: 0x06003102 RID: 12546 RVA: 0x000257A0 File Offset: 0x000239A0
		internal void AddData(ulong item)
		{
			if (!this.rTdXWIsRkCEwnuuXwzeqOyggahoL)
			{
				this.TXutKLGpfYDmERcZBBYnaLbKnUcBA();
			}
			this._data.Add(new TypeWrapper(item));
		}

		// Token: 0x06003103 RID: 12547 RVA: 0x000257C1 File Offset: 0x000239C1
		internal void AddData(float item)
		{
			if (!this.rTdXWIsRkCEwnuuXwzeqOyggahoL)
			{
				this.TXutKLGpfYDmERcZBBYnaLbKnUcBA();
			}
			this._data.Add(new TypeWrapper(item));
		}

		// Token: 0x06003104 RID: 12548 RVA: 0x000257E2 File Offset: 0x000239E2
		internal void AddData(double item)
		{
			if (!this.rTdXWIsRkCEwnuuXwzeqOyggahoL)
			{
				this.TXutKLGpfYDmERcZBBYnaLbKnUcBA();
			}
			this._data.Add(new TypeWrapper(item));
		}

		// Token: 0x06003105 RID: 12549 RVA: 0x00025803 File Offset: 0x00023A03
		internal void AddData(bool item)
		{
			if (!this.rTdXWIsRkCEwnuuXwzeqOyggahoL)
			{
				this.TXutKLGpfYDmERcZBBYnaLbKnUcBA();
			}
			this._data.Add(new TypeWrapper(item));
		}

		// Token: 0x06003106 RID: 12550 RVA: 0x00025824 File Offset: 0x00023A24
		internal void AddData(string item)
		{
			if (!this.rTdXWIsRkCEwnuuXwzeqOyggahoL)
			{
				this.TXutKLGpfYDmERcZBBYnaLbKnUcBA();
			}
			this._data.Add(new TypeWrapper(item));
		}

		// Token: 0x06003107 RID: 12551 RVA: 0x00025845 File Offset: 0x00023A45
		internal void AddData(object item)
		{
			if (!this.rTdXWIsRkCEwnuuXwzeqOyggahoL)
			{
				this.TXutKLGpfYDmERcZBBYnaLbKnUcBA();
			}
			this._data.Add(new TypeWrapper(item));
		}

		// Token: 0x06003108 RID: 12552 RVA: 0x00025866 File Offset: 0x00023A66
		internal void AddData(TypeWrapper item)
		{
			if (!this.rTdXWIsRkCEwnuuXwzeqOyggahoL)
			{
				this.TXutKLGpfYDmERcZBBYnaLbKnUcBA();
			}
			this._data.Add(item);
		}

		// Token: 0x06003109 RID: 12553 RVA: 0x00025882 File Offset: 0x00023A82
		internal void ClearData()
		{
			if (!this.rTdXWIsRkCEwnuuXwzeqOyggahoL)
			{
				return;
			}
			this._data.Clear();
		}

		// Token: 0x0600310A RID: 12554 RVA: 0x00025898 File Offset: 0x00023A98
		internal void ClearResult()
		{
			this._resultIsValid = false;
			this._result.Clear();
		}

		// Token: 0x0600310B RID: 12555
		internal abstract bool Process();

		// Token: 0x0600310C RID: 12556 RVA: 0x000258AC File Offset: 0x00023AAC
		private void TXutKLGpfYDmERcZBBYnaLbKnUcBA()
		{
			this._data = new List<TypeWrapper>(3);
			this.rTdXWIsRkCEwnuuXwzeqOyggahoL = true;
		}

		// Token: 0x04001ADF RID: 6879
		private const int QnGPQwZrqIuojwClSubtnfsIuwnf = 3;

		// Token: 0x04001AE0 RID: 6880
		[NonSerialized]
		private bool rTdXWIsRkCEwnuuXwzeqOyggahoL;

		// Token: 0x04001AE1 RID: 6881
		[NonSerialized]
		internal List<TypeWrapper> _data;

		// Token: 0x04001AE2 RID: 6882
		[NonSerialized]
		internal TypeWrapper _result;

		// Token: 0x04001AE3 RID: 6883
		[NonSerialized]
		internal bool _resultIsValid;
	}
}
