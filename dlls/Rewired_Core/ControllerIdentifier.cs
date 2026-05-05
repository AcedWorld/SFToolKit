using System;

namespace Rewired
{
	// Token: 0x0200000D RID: 13
	public struct ControllerIdentifier
	{
		// Token: 0x060000F8 RID: 248 RVA: 0x00002E41 File Offset: 0x00001041
		internal ControllerIdentifier(Controller A_1)
		{
			this.uKCkMXFfBPppIIecrWnLOkuIBLoV = A_1.id;
			this.vVqaaPRGyWcWFEiGSiiqqfsbxMJTA = A_1.type;
			this.XtPYVBDfvScZlhcVNYSpCEdKVQWIA = A_1.legQjhUclFMVpVFTfXDlmJRWuUQj;
			this.EMwlYcruSgmSWgOfJqjDJzxwrxHr = A_1.hardwareIdentifier;
			this.OZCGjEAGZEKbtXdLrXGvINzcJYAg = A_1.deviceInstanceGuid;
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x00002E7F File Offset: 0x0000107F
		// (set) Token: 0x060000FA RID: 250 RVA: 0x00002E87 File Offset: 0x00001087
		public int controllerId
		{
			get
			{
				return this.uKCkMXFfBPppIIecrWnLOkuIBLoV;
			}
			set
			{
				this.uKCkMXFfBPppIIecrWnLOkuIBLoV = value;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000FB RID: 251 RVA: 0x00002E90 File Offset: 0x00001090
		// (set) Token: 0x060000FC RID: 252 RVA: 0x00002E98 File Offset: 0x00001098
		public ControllerType controllerType
		{
			get
			{
				return this.vVqaaPRGyWcWFEiGSiiqqfsbxMJTA;
			}
			set
			{
				this.vVqaaPRGyWcWFEiGSiiqqfsbxMJTA = value;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000FD RID: 253 RVA: 0x00002EA1 File Offset: 0x000010A1
		// (set) Token: 0x060000FE RID: 254 RVA: 0x00002EA9 File Offset: 0x000010A9
		public Guid hardwareTypeGuid
		{
			get
			{
				return this.XtPYVBDfvScZlhcVNYSpCEdKVQWIA;
			}
			set
			{
				this.XtPYVBDfvScZlhcVNYSpCEdKVQWIA = value;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00002EB2 File Offset: 0x000010B2
		// (set) Token: 0x06000100 RID: 256 RVA: 0x00002EBA File Offset: 0x000010BA
		public string hardwareIdentifier
		{
			get
			{
				return this.EMwlYcruSgmSWgOfJqjDJzxwrxHr;
			}
			set
			{
				this.EMwlYcruSgmSWgOfJqjDJzxwrxHr = value;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000101 RID: 257 RVA: 0x00002EC3 File Offset: 0x000010C3
		// (set) Token: 0x06000102 RID: 258 RVA: 0x00002ECB File Offset: 0x000010CB
		public Guid deviceInstanceGuid
		{
			get
			{
				return this.OZCGjEAGZEKbtXdLrXGvINzcJYAg;
			}
			set
			{
				this.OZCGjEAGZEKbtXdLrXGvINzcJYAg = value;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000103 RID: 259 RVA: 0x0002BDEC File Offset: 0x00029FEC
		public static ControllerIdentifier Blank
		{
			get
			{
				return new ControllerIdentifier
				{
					uKCkMXFfBPppIIecrWnLOkuIBLoV = -1
				};
			}
		}

		// Token: 0x0400004A RID: 74
		private int uKCkMXFfBPppIIecrWnLOkuIBLoV;

		// Token: 0x0400004B RID: 75
		private ControllerType vVqaaPRGyWcWFEiGSiiqqfsbxMJTA;

		// Token: 0x0400004C RID: 76
		private Guid XtPYVBDfvScZlhcVNYSpCEdKVQWIA;

		// Token: 0x0400004D RID: 77
		private string EMwlYcruSgmSWgOfJqjDJzxwrxHr;

		// Token: 0x0400004E RID: 78
		private Guid OZCGjEAGZEKbtXdLrXGvINzcJYAg;
	}
}
