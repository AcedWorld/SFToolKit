using System;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x0200051B RID: 1307
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class GetSetValue<T> : IGetSetValue<T>, IGetValue<T>, ISetValue<T>
	{
		// Token: 0x17000C0A RID: 3082
		// (get) Token: 0x060035D2 RID: 13778 RVA: 0x0002A1EA File Offset: 0x000283EA
		// (set) Token: 0x060035D3 RID: 13779 RVA: 0x0002A1F2 File Offset: 0x000283F2
		public Func<T> getValueDelegate
		{
			get
			{
				return this.fGpcJqvmTBDhCXXZAykHefGFmJUA;
			}
			set
			{
				this.fGpcJqvmTBDhCXXZAykHefGFmJUA = value;
			}
		}

		// Token: 0x17000C0B RID: 3083
		// (get) Token: 0x060035D4 RID: 13780 RVA: 0x0002A1FB File Offset: 0x000283FB
		// (set) Token: 0x060035D5 RID: 13781 RVA: 0x0002A203 File Offset: 0x00028403
		public Action<T> setValueDelegate
		{
			get
			{
				return this.kOpBEvGRaCaoSqbvcijXzUPjxcMWA;
			}
			set
			{
				this.kOpBEvGRaCaoSqbvcijXzUPjxcMWA = value;
			}
		}

		// Token: 0x060035D6 RID: 13782 RVA: 0x0002A20C File Offset: 0x0002840C
		public GetSetValue(Func<T> A_1, Action<T> A_2)
		{
			this.fGpcJqvmTBDhCXXZAykHefGFmJUA = A_1;
			this.kOpBEvGRaCaoSqbvcijXzUPjxcMWA = A_2;
		}

		// Token: 0x060035D7 RID: 13783 RVA: 0x0002A222 File Offset: 0x00028422
		public T GetValue()
		{
			if (this.fGpcJqvmTBDhCXXZAykHefGFmJUA == null)
			{
				throw new ArgumentNullException("getValueDelegate");
			}
			return this.fGpcJqvmTBDhCXXZAykHefGFmJUA();
		}

		// Token: 0x060035D8 RID: 13784 RVA: 0x0002A242 File Offset: 0x00028442
		public void SetValue(T value)
		{
			if (this.kOpBEvGRaCaoSqbvcijXzUPjxcMWA == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			this.kOpBEvGRaCaoSqbvcijXzUPjxcMWA(value);
		}

		// Token: 0x04001C6D RID: 7277
		private Func<T> fGpcJqvmTBDhCXXZAykHefGFmJUA;

		// Token: 0x04001C6E RID: 7278
		private Action<T> kOpBEvGRaCaoSqbvcijXzUPjxcMWA;
	}
}
