using System;

namespace Rewired
{
	// Token: 0x0200013C RID: 316
	public sealed class KeyboardMap : ControllerMap
	{
		// Token: 0x06000D42 RID: 3394 RVA: 0x0000C9A5 File Offset: 0x0000ABA5
		public KeyboardMap()
		{
			this._controllerType = ControllerType.Keyboard;
			this._controllerId = 0;
		}

		// Token: 0x06000D43 RID: 3395 RVA: 0x0000C9BB File Offset: 0x0000ABBB
		public KeyboardMap(KeyboardMap A_1) : base(A_1)
		{
		}

		// Token: 0x06000D44 RID: 3396 RVA: 0x0000C9C4 File Offset: 0x0000ABC4
		internal void yUkhcSLWGUxPKUABHGsjYhImYVXc(Guid A_1, int A_2, int A_3)
		{
			this._hardwareGuid = A_1;
			this._categoryId = A_2;
			this._layoutId = A_3;
		}

		// Token: 0x06000D45 RID: 3397 RVA: 0x0000C9DB File Offset: 0x0000ABDB
		internal static KeyboardMap JFaSyrHBRaiVbkesrgmCvmgtAwXT(Guid A_0, int A_1, int A_2)
		{
			return new KeyboardMap
			{
				_hardwareGuid = A_0,
				_categoryId = A_1,
				_layoutId = A_2,
				_sourceMapId = -1
			};
		}
	}
}
