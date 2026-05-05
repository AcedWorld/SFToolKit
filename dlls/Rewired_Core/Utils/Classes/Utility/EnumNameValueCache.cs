using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004DD RID: 1245
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class EnumNameValueCache<TEnum> where TEnum : struct, IComparable, IFormattable
	{
		// Token: 0x17000B5F RID: 2911
		// (get) Token: 0x06003202 RID: 12802 RVA: 0x000265FD File Offset: 0x000247FD
		public static EnumNameValueCache<TEnum> Default
		{
			get
			{
				EnumNameValueCache<TEnum> result;
				if ((result = EnumNameValueCache<TEnum>.SZppqWoliIyxjiuUYBIHHIrGTnxG) == null)
				{
					result = (EnumNameValueCache<TEnum>.SZppqWoliIyxjiuUYBIHHIrGTnxG = new EnumNameValueCache<TEnum>());
				}
				return result;
			}
		}

		// Token: 0x06003203 RID: 12803 RVA: 0x00026613 File Offset: 0x00024813
		public static void Free()
		{
			EnumNameValueCache<TEnum>.SZppqWoliIyxjiuUYBIHHIrGTnxG = null;
		}

		// Token: 0x17000B60 RID: 2912
		// (get) Token: 0x06003204 RID: 12804 RVA: 0x0002661B File Offset: 0x0002481B
		public int Count
		{
			get
			{
				return this.YBfTnmVJGIxowUUOFudccaAdpQFI.Length;
			}
		}

		// Token: 0x06003205 RID: 12805 RVA: 0x000AD0B8 File Offset: 0x000AB2B8
		private EnumNameValueCache()
		{
			Type typeFromHandle = typeof(TEnum);
			if (!EnumTools.IsEnum(typeFromHandle))
			{
				throw new Exception("enumType is not an enum type.");
			}
			Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(typeFromHandle);
			this.fbyEKJAYTObtNNXKhynrLluYJFhhb = Enum.GetNames(typeFromHandle);
			TEnum[] array = (TEnum[])Enum.GetValues(typeFromHandle);
			this.lXmKuoNhUbfREKhQisQSBdjYMfsA = new ADictionary<string, TEnum>();
			this.YBfTnmVJGIxowUUOFudccaAdpQFI = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				this.YBfTnmVJGIxowUUOFudccaAdpQFI[i] = MiscTools.ToLongUnchecked(Convert.ChangeType(array[i], underlyingEnumType));
				this.lXmKuoNhUbfREKhQisQSBdjYMfsA.Add(this.fbyEKJAYTObtNNXKhynrLluYJFhhb[i], array[i]);
			}
		}

		// Token: 0x06003206 RID: 12806 RVA: 0x00026625 File Offset: 0x00024825
		public TEnum GetValue(string name)
		{
			return this.lXmKuoNhUbfREKhQisQSBdjYMfsA[name];
		}

		// Token: 0x06003207 RID: 12807 RVA: 0x00026633 File Offset: 0x00024833
		public bool TryGetValue(string name, out TEnum value)
		{
			return this.lXmKuoNhUbfREKhQisQSBdjYMfsA.TryGetValue(name, out value);
		}

		// Token: 0x06003208 RID: 12808 RVA: 0x000AD168 File Offset: 0x000AB368
		public string GetName(long value)
		{
			int num = this.IndexOf(value);
			if (num < 0)
			{
				throw new Exception("The value does not exist in the enum.");
			}
			return this.fbyEKJAYTObtNNXKhynrLluYJFhhb[num];
		}

		// Token: 0x06003209 RID: 12809 RVA: 0x000AD194 File Offset: 0x000AB394
		public bool TryGetName(long value, out string name)
		{
			int num = this.IndexOf(value);
			if (num < 0)
			{
				name = string.Empty;
				return false;
			}
			name = this.fbyEKJAYTObtNNXKhynrLluYJFhhb[num];
			return true;
		}

		// Token: 0x0600320A RID: 12810 RVA: 0x00026642 File Offset: 0x00024842
		public TEnum GetValueAt(int index)
		{
			if (index >= this.YBfTnmVJGIxowUUOFudccaAdpQFI.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return this.lXmKuoNhUbfREKhQisQSBdjYMfsA[this.fbyEKJAYTObtNNXKhynrLluYJFhhb[index]];
		}

		// Token: 0x0600320B RID: 12811 RVA: 0x0002666D File Offset: 0x0002486D
		public string GetNameAt(int index)
		{
			if (index >= this.YBfTnmVJGIxowUUOFudccaAdpQFI.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return this.fbyEKJAYTObtNNXKhynrLluYJFhhb[index];
		}

		// Token: 0x0600320C RID: 12812 RVA: 0x0002668D File Offset: 0x0002488D
		public int IndexOf(string name)
		{
			return Array.IndexOf<string>(this.fbyEKJAYTObtNNXKhynrLluYJFhhb, name);
		}

		// Token: 0x0600320D RID: 12813 RVA: 0x0002669B File Offset: 0x0002489B
		public int IndexOf(long value)
		{
			return Array.IndexOf<long>(this.YBfTnmVJGIxowUUOFudccaAdpQFI, value);
		}

		// Token: 0x0600320E RID: 12814 RVA: 0x000266A9 File Offset: 0x000248A9
		public bool Contains(string name)
		{
			return this.lXmKuoNhUbfREKhQisQSBdjYMfsA.ContainsKey(name);
		}

		// Token: 0x0600320F RID: 12815 RVA: 0x000266B7 File Offset: 0x000248B7
		public bool Contains(long value)
		{
			return this.IndexOf(value) >= 0;
		}

		// Token: 0x04001B5B RID: 7003
		private static EnumNameValueCache<TEnum> SZppqWoliIyxjiuUYBIHHIrGTnxG;

		// Token: 0x04001B5C RID: 7004
		private readonly ADictionary<string, TEnum> lXmKuoNhUbfREKhQisQSBdjYMfsA;

		// Token: 0x04001B5D RID: 7005
		private readonly string[] fbyEKJAYTObtNNXKhynrLluYJFhhb;

		// Token: 0x04001B5E RID: 7006
		private readonly long[] YBfTnmVJGIxowUUOFudccaAdpQFI;
	}
}
