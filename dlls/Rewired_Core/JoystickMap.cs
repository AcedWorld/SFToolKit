using System;

namespace Rewired
{
	// Token: 0x0200013E RID: 318
	public sealed class JoystickMap : ControllerMapWithAxes
	{
		// Token: 0x06000D4A RID: 3402 RVA: 0x0000CA40 File Offset: 0x0000AC40
		public JoystickMap()
		{
			this._controllerType = ControllerType.Joystick;
		}

		// Token: 0x06000D4B RID: 3403 RVA: 0x0000CA14 File Offset: 0x0000AC14
		public JoystickMap(JoystickMap A_1) : base(A_1)
		{
		}

		// Token: 0x06000D4C RID: 3404 RVA: 0x0000C9C4 File Offset: 0x0000ABC4
		internal void XLLVBHcQxQsleIwRyOozlDabqaKS(Guid A_1, int A_2, int A_3)
		{
			this._hardwareGuid = A_1;
			this._categoryId = A_2;
			this._layoutId = A_3;
		}

		// Token: 0x06000D4D RID: 3405 RVA: 0x0000CA4F File Offset: 0x0000AC4F
		internal static JoystickMap HKXFkYgXWGhCJSjCCpslBeOMKWGxA(Guid A_0, int A_1, int A_2)
		{
			return new JoystickMap
			{
				_hardwareGuid = A_0,
				_categoryId = A_1,
				_layoutId = A_2,
				_sourceMapId = -1
			};
		}
	}
}
