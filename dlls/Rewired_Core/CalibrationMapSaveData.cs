using System;

namespace Rewired
{
	// Token: 0x02000111 RID: 273
	public class CalibrationMapSaveData
	{
		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x060009FF RID: 2559 RVA: 0x0000A217 File Offset: 0x00008417
		public CalibrationMap map
		{
			get
			{
				return this.ZbBXGlziYtqWnpesUOmWJovItYfI;
			}
		}

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x06000A00 RID: 2560 RVA: 0x0000A21F File Offset: 0x0000841F
		public ControllerType controllerType
		{
			get
			{
				return this.LCfLXbUspYeRojJsPOZcPTMHpOks;
			}
		}

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x06000A01 RID: 2561 RVA: 0x0000A227 File Offset: 0x00008427
		public string hardwareIdentifier
		{
			get
			{
				return this.FjTItpEoDDjnEIQkrjDGIenHCZQg;
			}
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x0000A22F File Offset: 0x0000842F
		public CalibrationMapSaveData(CalibrationMap A_1, ControllerType A_2, string A_3)
		{
			this.ZbBXGlziYtqWnpesUOmWJovItYfI = A_1;
			this.LCfLXbUspYeRojJsPOZcPTMHpOks = A_2;
			this.FjTItpEoDDjnEIQkrjDGIenHCZQg = A_3;
		}

		// Token: 0x0400074E RID: 1870
		private CalibrationMap ZbBXGlziYtqWnpesUOmWJovItYfI;

		// Token: 0x0400074F RID: 1871
		private ControllerType LCfLXbUspYeRojJsPOZcPTMHpOks;

		// Token: 0x04000750 RID: 1872
		private string FjTItpEoDDjnEIQkrjDGIenHCZQg;
	}
}
