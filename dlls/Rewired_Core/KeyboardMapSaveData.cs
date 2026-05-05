using System;

namespace Rewired
{
	// Token: 0x0200012A RID: 298
	public sealed class KeyboardMapSaveData : ControllerMapSaveData
	{
		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06000BB6 RID: 2998 RVA: 0x0000B876 File Offset: 0x00009A76
		public KeyboardMap keyboardMap
		{
			get
			{
				if (ReInput._id != this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI)
				{
					ReInput.CheckInitialized(this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI);
					return null;
				}
				return (KeyboardMap)this._map;
			}
		}

		// Token: 0x06000BB7 RID: 2999 RVA: 0x0000B89E File Offset: 0x00009A9E
		internal KeyboardMapSaveData(Keyboard A_1, KeyboardMap A_2) : base(A_1, A_2)
		{
		}
	}
}
