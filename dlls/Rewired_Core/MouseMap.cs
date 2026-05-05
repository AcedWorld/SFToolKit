using System;

namespace Rewired
{
	// Token: 0x0200013D RID: 317
	public sealed class MouseMap : ControllerMapWithAxes
	{
		// Token: 0x06000D46 RID: 3398 RVA: 0x0000C9FE File Offset: 0x0000ABFE
		public MouseMap()
		{
			this._controllerType = ControllerType.Mouse;
			this._controllerId = 0;
		}

		// Token: 0x06000D47 RID: 3399 RVA: 0x0000CA14 File Offset: 0x0000AC14
		public MouseMap(MouseMap A_1) : base(A_1)
		{
		}

		// Token: 0x06000D48 RID: 3400 RVA: 0x0000C9C4 File Offset: 0x0000ABC4
		internal void DaIUDwcOBiNKdDPlNBvjUsMbjBoe(Guid A_1, int A_2, int A_3)
		{
			this._hardwareGuid = A_1;
			this._categoryId = A_2;
			this._layoutId = A_3;
		}

		// Token: 0x06000D49 RID: 3401 RVA: 0x0000CA1D File Offset: 0x0000AC1D
		internal static MouseMap RNwLiQPNKIHevYltYooFXsuqwmkl(Guid A_0, int A_1, int A_2)
		{
			return new MouseMap
			{
				_hardwareGuid = A_0,
				_categoryId = A_1,
				_layoutId = A_2,
				_sourceMapId = -1
			};
		}
	}
}
