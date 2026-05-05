using System;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x020004F1 RID: 1265
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ExpandableArray_DataContainer<T> where T : class, ExpandableArray_DataContainer<T>.YrNAypRzxYCVIPkxNBgtOjmHSnBK, new()
	{
		// Token: 0x17000BBB RID: 3003
		// (get) Token: 0x0600334D RID: 13133 RVA: 0x00027653 File Offset: 0x00025853
		public int Count
		{
			get
			{
				return this.vciccKLvPGekSyQLsUVdAhQdcvDM;
			}
		}

		// Token: 0x17000BBC RID: 3004
		// (get) Token: 0x0600334E RID: 13134 RVA: 0x00027653 File Offset: 0x00025853
		public int Length
		{
			get
			{
				return this.vciccKLvPGekSyQLsUVdAhQdcvDM;
			}
		}

		// Token: 0x17000BBD RID: 3005
		// (get) Token: 0x0600334F RID: 13135 RVA: 0x0002765B File Offset: 0x0002585B
		public int MaxLength
		{
			get
			{
				return this.OOQTYqEcSZysspbeanHwTaEavYKT;
			}
		}

		// Token: 0x17000BBE RID: 3006
		// (get) Token: 0x06003350 RID: 13136 RVA: 0x00027663 File Offset: 0x00025863
		public int FreeSpace
		{
			get
			{
				return this.OOQTYqEcSZysspbeanHwTaEavYKT - this.vciccKLvPGekSyQLsUVdAhQdcvDM;
			}
		}

		// Token: 0x06003351 RID: 13137 RVA: 0x000AFDD8 File Offset: 0x000ADFD8
		public ExpandableArray_DataContainer(int A_1, bool A_2 = true, int A_3 = 0)
		{
			this.injector = Activator.CreateInstance<T>();
			this.eCwFOccEwImjzaOWClGkdExAlMMqb = new T[A_1];
			this.vciccKLvPGekSyQLsUVdAhQdcvDM = 0;
			this.OOQTYqEcSZysspbeanHwTaEavYKT = A_1;
			this.pdqikHvMYVQjsllyOKiGUPqECRFi = A_2;
			this.DbHXZzoWANUvROXIEhtZhamOjHAN = A_3;
			for (int i = 0; i < this.OOQTYqEcSZysspbeanHwTaEavYKT; i++)
			{
				this.eCwFOccEwImjzaOWClGkdExAlMMqb[i] = Activator.CreateInstance<T>();
			}
		}

		// Token: 0x17000BBF RID: 3007
		public T this[int index]
		{
			get
			{
				if (index >= this.vciccKLvPGekSyQLsUVdAhQdcvDM)
				{
					throw new IndexOutOfRangeException();
				}
				return this.eCwFOccEwImjzaOWClGkdExAlMMqb[index];
			}
		}

		// Token: 0x06003353 RID: 13139 RVA: 0x0002768F File Offset: 0x0002588F
		public int Inject()
		{
			int result = this.AddData(this.injector);
			if (this.pdqikHvMYVQjsllyOKiGUPqECRFi)
			{
				this.injector.riLCmUKJcwLEcFktIxfxMnsCMCcXB();
			}
			return result;
		}

		// Token: 0x06003354 RID: 13140 RVA: 0x000276B5 File Offset: 0x000258B5
		public int InjectIfUnique()
		{
			int result = this.AddIfUnique(this.injector);
			if (this.pdqikHvMYVQjsllyOKiGUPqECRFi)
			{
				this.injector.riLCmUKJcwLEcFktIxfxMnsCMCcXB();
			}
			return result;
		}

		// Token: 0x06003355 RID: 13141 RVA: 0x000AFE40 File Offset: 0x000AE040
		public int AddData(T item)
		{
			if (this.vciccKLvPGekSyQLsUVdAhQdcvDM >= this.OOQTYqEcSZysspbeanHwTaEavYKT)
			{
				if (this.DbHXZzoWANUvROXIEhtZhamOjHAN <= 0)
				{
					return -1;
				}
				this.uNSZQdiWtIQYAuOqjsWdHLhvlyI();
			}
			int num = this.vciccKLvPGekSyQLsUVdAhQdcvDM;
			this.eCwFOccEwImjzaOWClGkdExAlMMqb[num].QjBUeTfNiEvNSWZIWUloJVOUBtNo(item);
			this.vciccKLvPGekSyQLsUVdAhQdcvDM = num + 1;
			return num;
		}

		// Token: 0x06003356 RID: 13142 RVA: 0x000AFE98 File Offset: 0x000AE098
		public int AddIfUnique(T item)
		{
			int num = this.IndexOfData(item);
			if (num >= 0)
			{
				return num;
			}
			return this.AddData(item);
		}

		// Token: 0x06003357 RID: 13143 RVA: 0x000AFEBC File Offset: 0x000AE0BC
		public bool ContainsData(T item)
		{
			for (int i = 0; i < this.vciccKLvPGekSyQLsUVdAhQdcvDM; i++)
			{
				if (this.eCwFOccEwImjzaOWClGkdExAlMMqb[i].DSaFXMVtnlaUIVMshviAJTsfdppR(item))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06003358 RID: 13144 RVA: 0x000AFEF8 File Offset: 0x000AE0F8
		public int IndexOfData(T item)
		{
			for (int i = 0; i < this.vciccKLvPGekSyQLsUVdAhQdcvDM; i++)
			{
				if (this.eCwFOccEwImjzaOWClGkdExAlMMqb[i].DSaFXMVtnlaUIVMshviAJTsfdppR(item))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06003359 RID: 13145 RVA: 0x000AFF34 File Offset: 0x000AE134
		public void Clear()
		{
			if (this.pdqikHvMYVQjsllyOKiGUPqECRFi)
			{
				this.injector.riLCmUKJcwLEcFktIxfxMnsCMCcXB();
				for (int i = 0; i < this.vciccKLvPGekSyQLsUVdAhQdcvDM; i++)
				{
					this.eCwFOccEwImjzaOWClGkdExAlMMqb[i].riLCmUKJcwLEcFktIxfxMnsCMCcXB();
				}
			}
			this.vciccKLvPGekSyQLsUVdAhQdcvDM = 0;
		}

		// Token: 0x0600335A RID: 13146 RVA: 0x000AFF88 File Offset: 0x000AE188
		public void RemoveAt(int index)
		{
			if (index < 0 || index >= this.vciccKLvPGekSyQLsUVdAhQdcvDM)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (index == this.vciccKLvPGekSyQLsUVdAhQdcvDM - 1)
			{
				this.RemoveLast();
				return;
			}
			if (this.pdqikHvMYVQjsllyOKiGUPqECRFi)
			{
				this.eCwFOccEwImjzaOWClGkdExAlMMqb[index].riLCmUKJcwLEcFktIxfxMnsCMCcXB();
			}
			for (int i = index; i < this.vciccKLvPGekSyQLsUVdAhQdcvDM - 1; i++)
			{
				this.eCwFOccEwImjzaOWClGkdExAlMMqb[i].QjBUeTfNiEvNSWZIWUloJVOUBtNo(this.eCwFOccEwImjzaOWClGkdExAlMMqb[i + 1]);
			}
			if (this.pdqikHvMYVQjsllyOKiGUPqECRFi)
			{
				this.eCwFOccEwImjzaOWClGkdExAlMMqb[this.vciccKLvPGekSyQLsUVdAhQdcvDM - 1].riLCmUKJcwLEcFktIxfxMnsCMCcXB();
			}
			this.vciccKLvPGekSyQLsUVdAhQdcvDM--;
		}

		// Token: 0x0600335B RID: 13147 RVA: 0x000276DB File Offset: 0x000258DB
		public void RemoveLast()
		{
			if (this.vciccKLvPGekSyQLsUVdAhQdcvDM == 0)
			{
				return;
			}
			if (this.pdqikHvMYVQjsllyOKiGUPqECRFi)
			{
				this.eCwFOccEwImjzaOWClGkdExAlMMqb[this.vciccKLvPGekSyQLsUVdAhQdcvDM - 1].riLCmUKJcwLEcFktIxfxMnsCMCcXB();
			}
			this.vciccKLvPGekSyQLsUVdAhQdcvDM--;
		}

		// Token: 0x0600335C RID: 13148 RVA: 0x000B0048 File Offset: 0x000AE248
		public void Resize(int size)
		{
			if (size <= 0)
			{
				throw new Exception("Size must be greater than 0.");
			}
			if (size == this.OOQTYqEcSZysspbeanHwTaEavYKT)
			{
				return;
			}
			T[] array = new T[size];
			int num = Math.Min(size, this.OOQTYqEcSZysspbeanHwTaEavYKT);
			for (int i = 0; i < num; i++)
			{
				array[i] = this.eCwFOccEwImjzaOWClGkdExAlMMqb[i];
			}
			if (size > this.OOQTYqEcSZysspbeanHwTaEavYKT)
			{
				for (int j = num; j < size; j++)
				{
					array[j] = Activator.CreateInstance<T>();
				}
			}
			else if (this.vciccKLvPGekSyQLsUVdAhQdcvDM > size)
			{
				this.vciccKLvPGekSyQLsUVdAhQdcvDM = size;
			}
			this.OOQTYqEcSZysspbeanHwTaEavYKT = size;
			this.eCwFOccEwImjzaOWClGkdExAlMMqb = array;
		}

		// Token: 0x0600335D RID: 13149 RVA: 0x000B00E4 File Offset: 0x000AE2E4
		public void SortAscending()
		{
			if (this.vciccKLvPGekSyQLsUVdAhQdcvDM == 0)
			{
				return;
			}
			for (int i = 0; i < this.vciccKLvPGekSyQLsUVdAhQdcvDM - 1; i++)
			{
				for (int j = i + 1; j < this.vciccKLvPGekSyQLsUVdAhQdcvDM; j++)
				{
					if (this.eCwFOccEwImjzaOWClGkdExAlMMqb[j].CompareTo(this.eCwFOccEwImjzaOWClGkdExAlMMqb[i]) < 0)
					{
						T t = this.eCwFOccEwImjzaOWClGkdExAlMMqb[i];
						this.eCwFOccEwImjzaOWClGkdExAlMMqb[i] = this.eCwFOccEwImjzaOWClGkdExAlMMqb[j];
						this.eCwFOccEwImjzaOWClGkdExAlMMqb[j] = t;
					}
				}
			}
		}

		// Token: 0x0600335E RID: 13150 RVA: 0x000B0178 File Offset: 0x000AE378
		public void SortDescending()
		{
			if (this.vciccKLvPGekSyQLsUVdAhQdcvDM == 0)
			{
				return;
			}
			for (int i = 0; i < this.vciccKLvPGekSyQLsUVdAhQdcvDM - 1; i++)
			{
				for (int j = i + 1; j < this.vciccKLvPGekSyQLsUVdAhQdcvDM; j++)
				{
					if (this.eCwFOccEwImjzaOWClGkdExAlMMqb[j].CompareTo(this.eCwFOccEwImjzaOWClGkdExAlMMqb[i]) > 0)
					{
						T t = this.eCwFOccEwImjzaOWClGkdExAlMMqb[i];
						this.eCwFOccEwImjzaOWClGkdExAlMMqb[i] = this.eCwFOccEwImjzaOWClGkdExAlMMqb[j];
						this.eCwFOccEwImjzaOWClGkdExAlMMqb[j] = t;
					}
				}
			}
		}

		// Token: 0x0600335F RID: 13151 RVA: 0x00027719 File Offset: 0x00025919
		private void uNSZQdiWtIQYAuOqjsWdHLhvlyI()
		{
			this.GySxEvVDNauwChZzQDoFvJfLdDOQ++;
			this.Resize(this.OOQTYqEcSZysspbeanHwTaEavYKT + this.GySxEvVDNauwChZzQDoFvJfLdDOQ * this.DbHXZzoWANUvROXIEhtZhamOjHAN);
		}

		// Token: 0x04001BB4 RID: 7092
		public readonly T injector;

		// Token: 0x04001BB5 RID: 7093
		private T[] eCwFOccEwImjzaOWClGkdExAlMMqb;

		// Token: 0x04001BB6 RID: 7094
		private int vciccKLvPGekSyQLsUVdAhQdcvDM;

		// Token: 0x04001BB7 RID: 7095
		private int OOQTYqEcSZysspbeanHwTaEavYKT;

		// Token: 0x04001BB8 RID: 7096
		private int DbHXZzoWANUvROXIEhtZhamOjHAN;

		// Token: 0x04001BB9 RID: 7097
		private int GySxEvVDNauwChZzQDoFvJfLdDOQ;

		// Token: 0x04001BBA RID: 7098
		private bool pdqikHvMYVQjsllyOKiGUPqECRFi;

		// Token: 0x020004F2 RID: 1266
		public interface YrNAypRzxYCVIPkxNBgtOjmHSnBK : IComparable<\u0001>
		{
			// Token: 0x06003360 RID: 13152
			void QjBUeTfNiEvNSWZIWUloJVOUBtNo(\u0001);

			// Token: 0x06003361 RID: 13153
			bool DSaFXMVtnlaUIVMshviAJTsfdppR(\u0001);

			// Token: 0x06003362 RID: 13154
			void riLCmUKJcwLEcFktIxfxMnsCMCcXB();
		}
	}
}
