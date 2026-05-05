using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Utils;

namespace Rewired
{
	// Token: 0x02000032 RID: 50
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class UpdateLoopDataSet<T> where T : class
	{
		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x00003AA4 File Offset: 0x00001CA4
		public T Current
		{
			get
			{
				return this.EMUdlArBICEjWNnBuMfirndZAarG.ZdxnoxyUBnLChMTgIppWLMlVUcpF;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001E7 RID: 487 RVA: 0x00003AB1 File Offset: 0x00001CB1
		public int Count
		{
			get
			{
				return this.GTnzuZfwfjjCyenPHwthbuCCgDgg;
			}
		}

		// Token: 0x17000077 RID: 119
		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= this.GTnzuZfwfjjCyenPHwthbuCCgDgg)
				{
					throw new IndexOutOfRangeException();
				}
				return this.KeniDpcLEbfDIBDKPgIxCCSmgqqEA[index].ZdxnoxyUBnLChMTgIppWLMlVUcpF;
			}
			set
			{
				if (index < 0 || index >= this.GTnzuZfwfjjCyenPHwthbuCCgDgg)
				{
					throw new IndexOutOfRangeException();
				}
				this.KeniDpcLEbfDIBDKPgIxCCSmgqqEA[index].ZdxnoxyUBnLChMTgIppWLMlVUcpF = value;
			}
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00003AFE File Offset: 0x00001CFE
		public UpdateLoopDataSet(UpdateLoopSetting A_1) : this(A_1, null)
		{
		}

		// Token: 0x060001EB RID: 491 RVA: 0x0002DF1C File Offset: 0x0002C11C
		public UpdateLoopDataSet(UpdateLoopSetting A_1, Func<T> A_2)
		{
			this.JrlDeEgFlJcOGuVbeBITLYCzEjux = new int[3];
			ArrayTools.Fill<int>(this.JrlDeEgFlJcOGuVbeBITLYCzEjux, -1);
			List<UpdateLoopDataSet<T>.LZIaGCKBriZqZpzTsbJDpjVoDUiCb> list = new List<UpdateLoopDataSet<T>.LZIaGCKBriZqZpzTsbJDpjVoDUiCb>();
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tlist = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tlist.list;
				EnumConverter.ToUpdateLoopTypes(A_1, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					UpdateLoopDataSet<T>.LZIaGCKBriZqZpzTsbJDpjVoDUiCb lziaGCKBriZqZpzTsbJDpjVoDUiCb = new UpdateLoopDataSet<T>.LZIaGCKBriZqZpzTsbJDpjVoDUiCb(list2[i]);
					if (A_2 != null)
					{
						T zdxnoxyUBnLChMTgIppWLMlVUcpF = A_2();
						lziaGCKBriZqZpzTsbJDpjVoDUiCb.ZdxnoxyUBnLChMTgIppWLMlVUcpF = zdxnoxyUBnLChMTgIppWLMlVUcpF;
					}
					list.Add(lziaGCKBriZqZpzTsbJDpjVoDUiCb);
					this.JrlDeEgFlJcOGuVbeBITLYCzEjux[(int)list2[i]] = num;
					if (list2[i] == UpdateLoopType.FixedUpdate)
					{
						this.fixedUpdateSetIndex = num;
					}
					num++;
				}
			}
			this.KeniDpcLEbfDIBDKPgIxCCSmgqqEA = list.ToArray();
			this.GTnzuZfwfjjCyenPHwthbuCCgDgg = this.KeniDpcLEbfDIBDKPgIxCCSmgqqEA.Length;
			this.SetUpdateLoop(this.KeniDpcLEbfDIBDKPgIxCCSmgqqEA[0].oYRAdcBRIQjckDDCKdaFvhvHEjXn);
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00003B08 File Offset: 0x00001D08
		public void SetUpdateLoop(UpdateLoopType updateLoop)
		{
			if (this.qIsqrPjuAAtTWTVePVfpZlFmxYsc == updateLoop)
			{
				return;
			}
			this.qIsqrPjuAAtTWTVePVfpZlFmxYsc = updateLoop;
			this.EMUdlArBICEjWNnBuMfirndZAarG = this.KeniDpcLEbfDIBDKPgIxCCSmgqqEA[this.JrlDeEgFlJcOGuVbeBITLYCzEjux[(int)updateLoop]];
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00003AB9 File Offset: 0x00001CB9
		public T Get(int index)
		{
			if (index < 0 || index >= this.GTnzuZfwfjjCyenPHwthbuCCgDgg)
			{
				throw new IndexOutOfRangeException();
			}
			return this.KeniDpcLEbfDIBDKPgIxCCSmgqqEA[index].ZdxnoxyUBnLChMTgIppWLMlVUcpF;
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00003B30 File Offset: 0x00001D30
		public T Get(UpdateLoopType updateLoop)
		{
			return this.KeniDpcLEbfDIBDKPgIxCCSmgqqEA[this.JrlDeEgFlJcOGuVbeBITLYCzEjux[(int)updateLoop]].ZdxnoxyUBnLChMTgIppWLMlVUcpF;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00003ADB File Offset: 0x00001CDB
		public void Set(int index, T item)
		{
			if (index < 0 || index >= this.GTnzuZfwfjjCyenPHwthbuCCgDgg)
			{
				throw new IndexOutOfRangeException();
			}
			this.KeniDpcLEbfDIBDKPgIxCCSmgqqEA[index].ZdxnoxyUBnLChMTgIppWLMlVUcpF = item;
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00003B46 File Offset: 0x00001D46
		public UpdateLoopType GetUpdateLoopType(int index)
		{
			if (index < 0 || index >= this.GTnzuZfwfjjCyenPHwthbuCCgDgg)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return this.KeniDpcLEbfDIBDKPgIxCCSmgqqEA[index].oYRAdcBRIQjckDDCKdaFvhvHEjXn;
		}

		// Token: 0x040000D9 RID: 217
		private const int igdadbnxWyYRQSglJYgrnGGFdcnI = 0;

		// Token: 0x040000DA RID: 218
		private UpdateLoopDataSet<T>.LZIaGCKBriZqZpzTsbJDpjVoDUiCb EMUdlArBICEjWNnBuMfirndZAarG;

		// Token: 0x040000DB RID: 219
		private int GTnzuZfwfjjCyenPHwthbuCCgDgg;

		// Token: 0x040000DC RID: 220
		public readonly int fixedUpdateSetIndex = -1;

		// Token: 0x040000DD RID: 221
		private readonly int[] JrlDeEgFlJcOGuVbeBITLYCzEjux;

		// Token: 0x040000DE RID: 222
		private readonly UpdateLoopDataSet<T>.LZIaGCKBriZqZpzTsbJDpjVoDUiCb[] KeniDpcLEbfDIBDKPgIxCCSmgqqEA;

		// Token: 0x040000DF RID: 223
		private UpdateLoopType qIsqrPjuAAtTWTVePVfpZlFmxYsc = (UpdateLoopType)(-1);

		// Token: 0x02000033 RID: 51
		private class LZIaGCKBriZqZpzTsbJDpjVoDUiCb
		{
			// Token: 0x060001F1 RID: 497 RVA: 0x00003B6D File Offset: 0x00001D6D
			public LZIaGCKBriZqZpzTsbJDpjVoDUiCb(UpdateLoopType A_1)
			{
				this.oYRAdcBRIQjckDDCKdaFvhvHEjXn = A_1;
			}

			// Token: 0x040000E0 RID: 224
			public readonly UpdateLoopType oYRAdcBRIQjckDDCKdaFvhvHEjXn;

			// Token: 0x040000E1 RID: 225
			public \u0001 ZdxnoxyUBnLChMTgIppWLMlVUcpF;
		}
	}
}
