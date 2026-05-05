using System;

namespace Rewired
{
	// Token: 0x0200012D RID: 301
	public sealed class CustomControllerMapSaveData : ControllerMapSaveData
	{
		// Token: 0x17000397 RID: 919
		// (get) Token: 0x06000BBE RID: 3006 RVA: 0x0000B94C File Offset: 0x00009B4C
		public CustomController customController
		{
			get
			{
				if (ReInput._id != this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI)
				{
					ReInput.CheckInitialized(this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI);
					return null;
				}
				return this._controller as CustomController;
			}
		}

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x06000BBF RID: 3007 RVA: 0x0000B974 File Offset: 0x00009B74
		public CustomControllerMap customControllerMap
		{
			get
			{
				if (ReInput._id != this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI)
				{
					ReInput.CheckInitialized(this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI);
					return null;
				}
				return this._map as CustomControllerMap;
			}
		}

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x06000BC0 RID: 3008 RVA: 0x0000B99C File Offset: 0x00009B9C
		public int customControllerSourceId
		{
			get
			{
				if (ReInput._id != this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI)
				{
					ReInput.CheckInitialized(this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI);
					return -1;
				}
				return this.customController.sourceControllerId;
			}
		}

		// Token: 0x06000BC1 RID: 3009 RVA: 0x0000B89E File Offset: 0x00009A9E
		internal CustomControllerMapSaveData(CustomController A_1, CustomControllerMap A_2) : base(A_1, A_2)
		{
		}
	}
}
