using System;
using Rewired;

// Token: 0x02000452 RID: 1106
internal static class aIgzybSrpFHIbiUgoNExgtkiaahP
{
	// Token: 0x06002C43 RID: 11331 RVA: 0x00021F4A File Offset: 0x0002014A
	public static qIdXPWaZDFjemNjbsLrswVoVIvUh OdziduRxdrBAnKCQEaAHjFHZSGBeb(ControllerType A_0)
	{
		switch (A_0)
		{
		case ControllerType.Keyboard:
			return qIdXPWaZDFjemNjbsLrswVoVIvUh.Keyboard;
		case ControllerType.Mouse:
			return qIdXPWaZDFjemNjbsLrswVoVIvUh.Mouse;
		case ControllerType.Joystick:
			return qIdXPWaZDFjemNjbsLrswVoVIvUh.Joystick;
		default:
			if (A_0 != ControllerType.Custom)
			{
				throw new NotImplementedException();
			}
			return qIdXPWaZDFjemNjbsLrswVoVIvUh.CustomController;
		}
	}
}
