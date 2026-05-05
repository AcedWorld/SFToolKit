using System;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004D8 RID: 1240
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct SetAndRestoreVar<T> : IDisposable
	{
		// Token: 0x060031BF RID: 12735 RVA: 0x000261E6 File Offset: 0x000243E6
		public SetAndRestoreVar(T A_1, T A_2, Action<T> A_3)
		{
			if (A_3 == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			this.kwuwHfCXXYjFLRdOpimtbYuoSGug = A_3;
			this.LPjtDXITZugSjNOuMVXZKcEwjenbA = A_1;
			A_3(A_2);
		}

		// Token: 0x060031C0 RID: 12736 RVA: 0x0002620B File Offset: 0x0002440B
		public void Dispose()
		{
			this.kwuwHfCXXYjFLRdOpimtbYuoSGug(this.LPjtDXITZugSjNOuMVXZKcEwjenbA);
		}

		// Token: 0x04001B4A RID: 6986
		private readonly Action<T> kwuwHfCXXYjFLRdOpimtbYuoSGug;

		// Token: 0x04001B4B RID: 6987
		private readonly T LPjtDXITZugSjNOuMVXZKcEwjenbA;
	}
}
