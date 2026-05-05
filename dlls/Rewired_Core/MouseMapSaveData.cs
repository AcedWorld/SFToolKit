using System;

namespace Rewired
{
	// Token: 0x0200012B RID: 299
	public sealed class MouseMapSaveData : ControllerMapSaveData
	{
		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06000BB8 RID: 3000 RVA: 0x0000B8A8 File Offset: 0x00009AA8
		public MouseMap keyboardMap
		{
			get
			{
				if (ReInput._id != this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI)
				{
					ReInput.CheckInitialized(this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI);
					return null;
				}
				return (MouseMap)this._map;
			}
		}

		// Token: 0x06000BB9 RID: 3001 RVA: 0x0000B89E File Offset: 0x00009A9E
		internal MouseMapSaveData(Mouse A_1, MouseMap A_2) : base(A_1, A_2)
		{
		}
	}
}
