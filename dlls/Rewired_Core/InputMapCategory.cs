using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	// Token: 0x0200014B RID: 331
	[Serializable]
	public sealed class InputMapCategory : InputCategory
	{
		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x06000E4E RID: 3662 RVA: 0x0000D395 File Offset: 0x0000B595
		internal override string keyCategory
		{
			get
			{
				return "controller_map/category";
			}
		}

		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x06000E4F RID: 3663 RVA: 0x0000D39C File Offset: 0x0000B59C
		// (set) Token: 0x06000E50 RID: 3664 RVA: 0x0000D3A4 File Offset: 0x0000B5A4
		public bool checkConflictsWithAllCategories
		{
			get
			{
				return this._checkConflictsWithAllCategories;
			}
			internal set
			{
				this._checkConflictsWithAllCategories = value;
			}
		}

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x06000E51 RID: 3665 RVA: 0x0000D3AD File Offset: 0x0000B5AD
		public IList<int> checkConflictsCategoryIds
		{
			get
			{
				return this._checkConflictsCategoryIds_readOnly;
			}
		}

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x06000E52 RID: 3666 RVA: 0x0000D3B5 File Offset: 0x0000B5B5
		internal List<int> ORYHklPObneiXhTAKBFvplSmwmTbA
		{
			get
			{
				return this._checkConflictsCategoryIds;
			}
		}

		// Token: 0x06000E53 RID: 3667 RVA: 0x0000D3BD File Offset: 0x0000B5BD
		public InputMapCategory()
		{
			this._checkConflictsCategoryIds = new List<int>();
		}

		// Token: 0x06000E54 RID: 3668 RVA: 0x0000D3D0 File Offset: 0x0000B5D0
		public InputMapCategory(InputMapCategory A_1) : base(A_1)
		{
			this._checkConflictsWithAllCategories = A_1._checkConflictsWithAllCategories;
			this._checkConflictsCategoryIds = ListTools.ShallowCopy<int>(A_1._checkConflictsCategoryIds);
		}

		// Token: 0x06000E55 RID: 3669 RVA: 0x0000D3F6 File Offset: 0x0000B5F6
		internal void wAKoVzcTJIgFLzytbAugYPQPhnbb()
		{
			base.AdhUFRQHbIPQhLkhPNdOptnZYpLD();
			if (this._checkConflictsCategoryIds != null)
			{
				this._checkConflictsCategoryIds_readOnly = new ReadOnlyCollection<int>(this._checkConflictsCategoryIds);
			}
		}

		// Token: 0x06000E56 RID: 3670 RVA: 0x0000D417 File Offset: 0x0000B617
		internal void jGVoYIoEawrnTlAGqNmLFEiaCucu()
		{
			base.kfObqanLScTcVFWnrgBWhuUanFgD();
		}

		// Token: 0x040008D3 RID: 2259
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _checkConflictsWithAllCategories;

		// Token: 0x040008D4 RID: 2260
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<int> _checkConflictsCategoryIds;

		// Token: 0x040008D5 RID: 2261
		private ReadOnlyCollection<int> _checkConflictsCategoryIds_readOnly;
	}
}
