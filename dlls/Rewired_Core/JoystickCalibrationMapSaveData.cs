using System;

namespace Rewired
{
	// Token: 0x02000112 RID: 274
	public sealed class JoystickCalibrationMapSaveData : CalibrationMapSaveData
	{
		// Token: 0x170002EC RID: 748
		// (get) Token: 0x06000A03 RID: 2563 RVA: 0x0000A24C File Offset: 0x0000844C
		public Guid joystickHardwareTypeGuid
		{
			get
			{
				return this.invVyYVNXoUpQIvCPOeCYQlnLGo;
			}
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x0000A254 File Offset: 0x00008454
		public JoystickCalibrationMapSaveData(CalibrationMap A_1, ControllerType A_2, string A_3, Guid A_4) : base(A_1, A_2, A_3)
		{
			this.invVyYVNXoUpQIvCPOeCYQlnLGo = A_4;
		}

		// Token: 0x04000751 RID: 1873
		private Guid invVyYVNXoUpQIvCPOeCYQlnLGo;
	}
}
