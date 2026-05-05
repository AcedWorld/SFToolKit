using System;

namespace Rewired
{
	// Token: 0x02000129 RID: 297
	public abstract class ControllerMapSaveData
	{
		// Token: 0x1700038A RID: 906
		// (get) Token: 0x06000BAA RID: 2986 RVA: 0x0000B709 File Offset: 0x00009909
		public ControllerMap map
		{
			get
			{
				if (ReInput._id != this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI)
				{
					ReInput.CheckInitialized(this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI);
					return null;
				}
				return this._map;
			}
		}

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x06000BAB RID: 2987 RVA: 0x0000B72C File Offset: 0x0000992C
		public int categoryId
		{
			get
			{
				if (ReInput._id != this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI)
				{
					ReInput.CheckInitialized(this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI);
					return -1;
				}
				return this._map.categoryId;
			}
		}

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x06000BAC RID: 2988 RVA: 0x0000B754 File Offset: 0x00009954
		public int layoutId
		{
			get
			{
				if (ReInput._id != this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI)
				{
					ReInput.CheckInitialized(this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI);
					return -1;
				}
				return this._map.layoutId;
			}
		}

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x06000BAD RID: 2989 RVA: 0x0000B77C File Offset: 0x0000997C
		public Type mapType
		{
			get
			{
				if (ReInput._id != this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI)
				{
					ReInput.CheckInitialized(this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI);
					return null;
				}
				return this._map.GetType();
			}
		}

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x06000BAE RID: 2990 RVA: 0x0000B7A4 File Offset: 0x000099A4
		public string mapTypeString
		{
			get
			{
				if (ReInput._id != this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI)
				{
					ReInput.CheckInitialized(this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI);
					return string.Empty;
				}
				return this._controller.mapTypeString;
			}
		}

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x06000BAF RID: 2991 RVA: 0x0000B7D0 File Offset: 0x000099D0
		public Controller controller
		{
			get
			{
				if (ReInput._id != this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI)
				{
					ReInput.CheckInitialized(this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI);
					return null;
				}
				return this._controller;
			}
		}

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06000BB0 RID: 2992 RVA: 0x0000B7F3 File Offset: 0x000099F3
		public ControllerType controllerType
		{
			get
			{
				if (ReInput._id != this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI)
				{
					ReInput.CheckInitialized(this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI);
					return ControllerType.Keyboard;
				}
				return this._controller.type;
			}
		}

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x06000BB1 RID: 2993 RVA: 0x0000B81B File Offset: 0x00009A1B
		public string controllerHardwareIdentifier
		{
			get
			{
				if (ReInput._id != this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI)
				{
					ReInput.CheckInitialized(this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI);
					return string.Empty;
				}
				return this._controller.hardwareIdentifier;
			}
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x0004AA7C File Offset: 0x00048C7C
		public T GetMap<T>() where T : ControllerMap
		{
			if (ReInput._id != this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI)
			{
				ReInput.CheckInitialized(this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI);
				return default(T);
			}
			return this._map as T;
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x0000B847 File Offset: 0x00009A47
		internal ControllerMapSaveData(Controller A_1, ControllerMap A_2)
		{
			this._controller = A_1;
			this._map = A_2;
			this.DDSyjRaFqKfhUdxtDVMJHXLQjtQI = ReInput.id;
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x0000B868 File Offset: 0x00009A68
		internal static \u0001 ArIhRHdbhRfQWDsIiNGUGfYhCwKSb<\u0001>(Controller A_0, ControllerMap A_1) where \u0001 : ControllerMapSaveData
		{
			return (\u0001)((object)ControllerMapSaveData.ArIhRHdbhRfQWDsIiNGUGfYhCwKSb(A_0, A_1));
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x0004AABC File Offset: 0x00048CBC
		internal static ControllerMapSaveData ArIhRHdbhRfQWDsIiNGUGfYhCwKSb(Controller A_0, ControllerMap A_1)
		{
			ControllerType type = A_0.type;
			switch (type)
			{
			case ControllerType.Keyboard:
				return new KeyboardMapSaveData((Keyboard)A_0, (KeyboardMap)A_1);
			case ControllerType.Mouse:
				return new MouseMapSaveData((Mouse)A_0, (MouseMap)A_1);
			case ControllerType.Joystick:
				return new JoystickMapSaveData((Joystick)A_0, (JoystickMap)A_1);
			default:
				if (type != ControllerType.Custom)
				{
					throw new ArgumentNullException();
				}
				return new CustomControllerMapSaveData((CustomController)A_0, (CustomControllerMap)A_1);
			}
		}

		// Token: 0x040007D5 RID: 2005
		protected Controller _controller;

		// Token: 0x040007D6 RID: 2006
		protected ControllerMap _map;

		// Token: 0x040007D7 RID: 2007
		internal readonly int DDSyjRaFqKfhUdxtDVMJHXLQjtQI;
	}
}
