using System;

namespace Rewired
{
	// Token: 0x0200013F RID: 319
	public sealed class CustomControllerMap : ControllerMapWithAxes
	{
		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x06000D4E RID: 3406 RVA: 0x0000CA72 File Offset: 0x0000AC72
		// (set) Token: 0x06000D4F RID: 3407 RVA: 0x0000CA7A File Offset: 0x0000AC7A
		public int sourceControllerId
		{
			get
			{
				return this.jcfEPbsQfhfxmvogPvAPLxqyyWtA;
			}
			set
			{
				this.jcfEPbsQfhfxmvogPvAPLxqyyWtA = value;
			}
		}

		// Token: 0x06000D50 RID: 3408 RVA: 0x0000CA83 File Offset: 0x0000AC83
		public CustomControllerMap()
		{
			this._controllerType = ControllerType.Custom;
		}

		// Token: 0x06000D51 RID: 3409 RVA: 0x0000CA93 File Offset: 0x0000AC93
		public CustomControllerMap(CustomControllerMap A_1) : base(A_1)
		{
			this.jcfEPbsQfhfxmvogPvAPLxqyyWtA = A_1.jcfEPbsQfhfxmvogPvAPLxqyyWtA;
		}

		// Token: 0x06000D52 RID: 3410 RVA: 0x0000CAA8 File Offset: 0x0000ACA8
		internal void NWOGoEOsoPcpvkmXyMKLethdNbuMc(Guid A_1, int A_2, int A_3, int A_4)
		{
			this._hardwareGuid = A_1;
			this.jcfEPbsQfhfxmvogPvAPLxqyyWtA = A_2;
			this._categoryId = A_3;
			this._layoutId = A_4;
		}

		// Token: 0x06000D53 RID: 3411 RVA: 0x0000CAC7 File Offset: 0x0000ACC7
		internal static CustomControllerMap CktVxwkSxOMnGYFuGSaZIHydTBRF(Guid A_0, int A_1, int A_2, int A_3)
		{
			return new CustomControllerMap
			{
				_hardwareGuid = A_0,
				jcfEPbsQfhfxmvogPvAPLxqyyWtA = A_1,
				_sourceMapId = -1,
				_categoryId = A_2,
				_layoutId = A_3
			};
		}

		// Token: 0x04000861 RID: 2145
		private int jcfEPbsQfhfxmvogPvAPLxqyyWtA;
	}
}
