using System;

namespace Rewired.Utils
{
	// Token: 0x02000480 RID: 1152
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class SafeDelegate : ICloneable
	{
		// Token: 0x17000AE1 RID: 2785
		// (get) Token: 0x06002D88 RID: 11656
		internal abstract int Count { get; }

		// Token: 0x06002D89 RID: 11657
		internal abstract void RemoveDelegateOrAllDelegatesFromAnObject(object obj);

		// Token: 0x17000AE2 RID: 2786
		// (get) Token: 0x06002D8A RID: 11658
		// (set) Token: 0x06002D8B RID: 11659
		internal abstract Action<Exception> ExceptionHandler { get; set; }

		// Token: 0x06002D8C RID: 11660
		internal abstract void Clear();

		// Token: 0x06002D8D RID: 11661
		public abstract object Clone();

		// Token: 0x17000AE3 RID: 2787
		// (get) Token: 0x06002D8E RID: 11662 RVA: 0x000231BE File Offset: 0x000213BE
		// (set) Token: 0x06002D8F RID: 11663 RVA: 0x000231C5 File Offset: 0x000213C5
		internal static Action<Exception> S_ExceptionHandler
		{
			get
			{
				return SafeDelegate.KCuTypVrDLVLzwIzIGqiBooZnkodA;
			}
			set
			{
				SafeDelegate.KCuTypVrDLVLzwIzIGqiBooZnkodA = value;
			}
		}

		// Token: 0x04001993 RID: 6547
		private static Action<Exception> KCuTypVrDLVLzwIzIGqiBooZnkodA;
	}
}
