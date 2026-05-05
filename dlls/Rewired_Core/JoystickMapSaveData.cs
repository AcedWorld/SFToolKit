using System;

namespace Rewired
{
	// Token: 0x0200012C RID: 300
	public sealed class JoystickMapSaveData : ControllerMapSaveData
	{
		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06000BBA RID: 3002 RVA: 0x0000B8D0 File Offset: 0x00009AD0
		public Joystick joystick
		{
			get
			{
				if (ReInput._id != this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI)
				{
					ReInput.CheckInitialized(this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI);
					return null;
				}
				return this._controller as Joystick;
			}
		}

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x06000BBB RID: 3003 RVA: 0x0000B8F8 File Offset: 0x00009AF8
		public JoystickMap joystickMap
		{
			get
			{
				if (ReInput._id != this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI)
				{
					ReInput.CheckInitialized(this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI);
					return null;
				}
				return this._map as JoystickMap;
			}
		}

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x06000BBC RID: 3004 RVA: 0x0000B920 File Offset: 0x00009B20
		public Guid joystickHardwareTypeGuid
		{
			get
			{
				if (ReInput._id != this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI)
				{
					ReInput.CheckInitialized(this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI);
					return Guid.Empty;
				}
				return this.joystick.hardwareTypeGuid;
			}
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x0000B89E File Offset: 0x00009A9E
		internal JoystickMapSaveData(Joystick A_1, JoystickMap A_2) : base(A_1, A_2)
		{
		}
	}
}
