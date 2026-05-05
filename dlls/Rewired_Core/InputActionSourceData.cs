using System;

namespace Rewired
{
	// Token: 0x0200000C RID: 12
	public struct InputActionSourceData
	{
		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000F1 RID: 241 RVA: 0x00002DD2 File Offset: 0x00000FD2
		public Controller controller
		{
			get
			{
				return this.hMvbjqPDVIfgZBHFvzAcrLzgtqIi;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00002DDA File Offset: 0x00000FDA
		public ControllerType controllerType
		{
			get
			{
				return this.hMvbjqPDVIfgZBHFvzAcrLzgtqIi.type;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x00002DE7 File Offset: 0x00000FE7
		public ControllerMap controllerMap
		{
			get
			{
				return this.qCnValQredJZKIfuYoTtfXKXrWJR;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x00002DEF File Offset: 0x00000FEF
		public ActionElementMap actionElementMap
		{
			get
			{
				return this.NayeLsCgVBBXSBnHLpPyJxQEgqvLA;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x00002DF7 File Offset: 0x00000FF7
		public string elementIdentifierName
		{
			get
			{
				return this.NayeLsCgVBBXSBnHLpPyJxQEgqvLA.elementIdentifierName;
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00002E04 File Offset: 0x00001004
		internal InputActionSourceData(Controller A_1, ControllerMap A_2, ActionElementMap A_3)
		{
			this.hMvbjqPDVIfgZBHFvzAcrLzgtqIi = A_1;
			this.qCnValQredJZKIfuYoTtfXKXrWJR = A_2;
			this.NayeLsCgVBBXSBnHLpPyJxQEgqvLA = A_3;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00002E1B File Offset: 0x0000101B
		internal InputActionSourceData(ccTpHyuBLmqwaKhsPmaxvVJtLJHK A_1)
		{
			this.hMvbjqPDVIfgZBHFvzAcrLzgtqIi = A_1.vUPtknPZXgiYgZbiabYfevsXxZQW;
			this.qCnValQredJZKIfuYoTtfXKXrWJR = A_1.RgVKpTFJJjWTjYwTmmaoSgwzKrYr;
			this.NayeLsCgVBBXSBnHLpPyJxQEgqvLA = A_1.iVNgfDiGatAWZcJBXeFAgVaADoNeb;
		}

		// Token: 0x04000047 RID: 71
		private Controller hMvbjqPDVIfgZBHFvzAcrLzgtqIi;

		// Token: 0x04000048 RID: 72
		private ControllerMap qCnValQredJZKIfuYoTtfXKXrWJR;

		// Token: 0x04000049 RID: 73
		private ActionElementMap NayeLsCgVBBXSBnHLpPyJxQEgqvLA;
	}
}
