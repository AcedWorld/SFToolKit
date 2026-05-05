using System;
using Rewired;

// Token: 0x020000F1 RID: 241
internal static class gRvITEHjKMrWaeGYEmAHofbpCtEU
{
	// Token: 0x060007A3 RID: 1955 RVA: 0x0000878D File Offset: 0x0000698D
	public static ControllerElementType oMwnKYUpvUGVFiEwmcEFRbkThNxp(ElementAssignmentType A_0)
	{
		if (A_0 == ElementAssignmentType.Button || A_0 == ElementAssignmentType.KeyboardKey)
		{
			return ControllerElementType.Button;
		}
		if (A_0 == ElementAssignmentType.FullAxis || A_0 == ElementAssignmentType.SplitAxis)
		{
			return ControllerElementType.Axis;
		}
		throw new NotImplementedException();
	}

	// Token: 0x060007A4 RID: 1956 RVA: 0x0003D600 File Offset: 0x0003B800
	public static ElementAssignmentType blpgmPnHOmuTkwCcZxdMASHDrVcg(ControllerType A_0, ControllerElementType A_1, AxisRange A_2)
	{
		ElementAssignmentType result;
		if (A_0 == ControllerType.Keyboard)
		{
			result = ElementAssignmentType.KeyboardKey;
		}
		else if (A_1 == ControllerElementType.Axis)
		{
			if (A_2 == AxisRange.Full)
			{
				result = ElementAssignmentType.FullAxis;
			}
			else
			{
				result = ElementAssignmentType.SplitAxis;
			}
		}
		else
		{
			if (A_1 == ControllerElementType.Button)
			{
				return ElementAssignmentType.Button;
			}
			throw new NotImplementedException();
		}
		return result;
	}

	// Token: 0x060007A5 RID: 1957 RVA: 0x000087A7 File Offset: 0x000069A7
	public static AxisRange ugDENAaYGHElJMWeKzhQUJTehuyI(Pole A_0)
	{
		if (A_0 == Pole.Positive)
		{
			return AxisRange.Positive;
		}
		if (A_0 == Pole.Negative)
		{
			return AxisRange.Negative;
		}
		throw new NotImplementedException();
	}

	// Token: 0x060007A6 RID: 1958 RVA: 0x000087B9 File Offset: 0x000069B9
	public static Type EeMmiIkEapZUqdAqUEWYTsiNMKbx<\u0001>() where \u0001 : Controller
	{
		return gRvITEHjKMrWaeGYEmAHofbpCtEU.PJZtrmGoQCiDTnZkrgHrUktxQSpx(typeof(\u0001));
	}

	// Token: 0x060007A7 RID: 1959 RVA: 0x0003D630 File Offset: 0x0003B830
	public static Type PJZtrmGoQCiDTnZkrgHrUktxQSpx(Type A_0)
	{
		if (A_0 == typeof(Joystick))
		{
			return typeof(JoystickMap);
		}
		if (A_0 == typeof(Keyboard))
		{
			return typeof(KeyboardMap);
		}
		if (A_0 == typeof(Mouse))
		{
			return typeof(MouseMap);
		}
		if (A_0 == typeof(CustomController))
		{
			return typeof(CustomControllerMap);
		}
		if (A_0 == typeof(Controller))
		{
			throw new Exception(A_0.Name + " is not an allowed type.");
		}
		if (A_0 == typeof(ControllerWithMap))
		{
			throw new Exception(A_0.Name + " is not an allowed type.");
		}
		if (A_0 == typeof(ControllerWithAxes))
		{
			throw new Exception(A_0.Name + " is not an allowed type.");
		}
		throw new NotImplementedException();
	}

	// Token: 0x060007A8 RID: 1960 RVA: 0x0003D70C File Offset: 0x0003B90C
	public static Type ZITGhwvDAVaCeWXvPIjpEPOmLtOC(ControllerType A_0)
	{
		switch (A_0)
		{
		case ControllerType.Keyboard:
			return typeof(KeyboardMap);
		case ControllerType.Mouse:
			return typeof(MouseMap);
		case ControllerType.Joystick:
			return typeof(JoystickMap);
		default:
			if (A_0 != ControllerType.Custom)
			{
				throw new NotImplementedException();
			}
			return typeof(CustomControllerMap);
		}
	}

	// Token: 0x060007A9 RID: 1961 RVA: 0x0003D764 File Offset: 0x0003B964
	public static Type OXojwTycodhuFuXdlHTtEuMABZBsA(ControllerType A_0)
	{
		switch (A_0)
		{
		case ControllerType.Keyboard:
			return typeof(Keyboard);
		case ControllerType.Mouse:
			return typeof(Mouse);
		case ControllerType.Joystick:
			return typeof(Joystick);
		default:
			if (A_0 != ControllerType.Custom)
			{
				throw new NotImplementedException();
			}
			return typeof(CustomController);
		}
	}

	// Token: 0x060007AA RID: 1962 RVA: 0x0003D7BC File Offset: 0x0003B9BC
	public static ControllerType FrCGQHeNlNaEnggvcvdFMaQdjVCLd(Type A_0)
	{
		if (A_0 == null)
		{
			throw new ArgumentNullException("controllerType");
		}
		if (A_0 == typeof(Joystick))
		{
			return ControllerType.Joystick;
		}
		if (A_0 == typeof(Keyboard))
		{
			return ControllerType.Keyboard;
		}
		if (A_0 == typeof(Mouse))
		{
			return ControllerType.Mouse;
		}
		if (A_0 == typeof(CustomController))
		{
			return ControllerType.Custom;
		}
		if (A_0 == typeof(Controller))
		{
			throw new Exception(A_0.Name + " is not an allowed type.");
		}
		if (A_0 == typeof(ControllerWithMap))
		{
			throw new Exception(A_0.Name + " is not an allowed type.");
		}
		if (A_0 == typeof(ControllerWithAxes))
		{
			throw new Exception(A_0.Name + " is not an allowed type.");
		}
		throw new NotImplementedException();
	}

	// Token: 0x060007AB RID: 1963 RVA: 0x000087CA File Offset: 0x000069CA
	public static ControllerType sdaTGzPrKPjPURvMxmwHNQmTiDRV<\u0001>()
	{
		return gRvITEHjKMrWaeGYEmAHofbpCtEU.FrCGQHeNlNaEnggvcvdFMaQdjVCLd(typeof(\u0001));
	}

	// Token: 0x060007AC RID: 1964 RVA: 0x0003D888 File Offset: 0x0003BA88
	public static ControllerType NTwdBfHkicvibCAGyJFAyEMSqBcIb(Type A_0)
	{
		ControllerType result;
		if (!gRvITEHjKMrWaeGYEmAHofbpCtEU.vLIiYjPBRUDOtFXhMGjvaBRhUbGsA(A_0, out result))
		{
			throw new Exception(A_0.Name + " is not an allowed type.");
		}
		return result;
	}

	// Token: 0x060007AD RID: 1965 RVA: 0x000087DB File Offset: 0x000069DB
	public static ControllerType DrVFpTBOVLehQeeOJikFfQUjqEZDc<\u0001>() where \u0001 : ControllerMap
	{
		return gRvITEHjKMrWaeGYEmAHofbpCtEU.NTwdBfHkicvibCAGyJFAyEMSqBcIb(typeof(\u0001));
	}

	// Token: 0x060007AE RID: 1966 RVA: 0x0003D8B8 File Offset: 0x0003BAB8
	public static bool vLIiYjPBRUDOtFXhMGjvaBRhUbGsA(Type A_0, out ControllerType A_1)
	{
		if (A_0 == null)
		{
			throw new ArgumentNullException("mapType");
		}
		if (A_0 == typeof(JoystickMap))
		{
			A_1 = ControllerType.Joystick;
			return true;
		}
		if (A_0 == typeof(KeyboardMap))
		{
			A_1 = ControllerType.Keyboard;
			return true;
		}
		if (A_0 == typeof(MouseMap))
		{
			A_1 = ControllerType.Mouse;
			return true;
		}
		if (A_0 == typeof(CustomControllerMap))
		{
			A_1 = ControllerType.Custom;
			return true;
		}
		if (A_0 == typeof(ControllerMap))
		{
			A_1 = ControllerType.Keyboard;
			return false;
		}
		if (A_0 == typeof(ControllerMapWithAxes))
		{
			A_1 = ControllerType.Keyboard;
			return false;
		}
		throw new NotImplementedException();
	}

	// Token: 0x060007AF RID: 1967 RVA: 0x000087EC File Offset: 0x000069EC
	public static bool AsHXrqqkjFxawzlQRepbDoBfHsw<\u0001>(out ControllerType A_0) where \u0001 : ControllerMap
	{
		return gRvITEHjKMrWaeGYEmAHofbpCtEU.vLIiYjPBRUDOtFXhMGjvaBRhUbGsA(typeof(\u0001), out A_0);
	}

	// Token: 0x060007B0 RID: 1968 RVA: 0x0003D94C File Offset: 0x0003BB4C
	public static ControllerType GEngUavQDLVAWRNpYqJGrjelEDleA(Type A_0)
	{
		if (A_0 == null)
		{
			throw new ArgumentNullException("controllerMapSaveDataType");
		}
		if (A_0 == typeof(JoystickMapSaveData))
		{
			return ControllerType.Joystick;
		}
		if (A_0 == typeof(KeyboardMapSaveData))
		{
			return ControllerType.Keyboard;
		}
		if (A_0 == typeof(MouseMapSaveData))
		{
			return ControllerType.Mouse;
		}
		if (A_0 == typeof(CustomControllerMapSaveData))
		{
			return ControllerType.Custom;
		}
		if (A_0 == typeof(ControllerMapSaveData))
		{
			throw new Exception(A_0.Name + " is not an allowed type.");
		}
		throw new NotImplementedException();
	}

	// Token: 0x060007B1 RID: 1969 RVA: 0x000087FE File Offset: 0x000069FE
	public static ControllerType pYJAxlSeDJMiKWGPKnMmTlnaovEM<\u0001>() where \u0001 : ControllerMapSaveData
	{
		return gRvITEHjKMrWaeGYEmAHofbpCtEU.GEngUavQDLVAWRNpYqJGrjelEDleA(typeof(\u0001));
	}

	// Token: 0x060007B2 RID: 1970 RVA: 0x0000880F File Offset: 0x00006A0F
	public static bool OTBocvISlRKBAUnyQtOPzQbOOoit(ControllerTemplateElementType A_0, ControllerElementType A_1)
	{
		if (A_1 == ControllerElementType.Axis)
		{
			return A_0 == ControllerTemplateElementType.Axis;
		}
		if (A_1 == ControllerElementType.Button)
		{
			return A_0 == ControllerTemplateElementType.Button;
		}
		if (A_1 != ControllerElementType.CompoundElement)
		{
			throw new NotImplementedException();
		}
		return false;
	}

	// Token: 0x060007B3 RID: 1971 RVA: 0x0003D9D4 File Offset: 0x0003BBD4
	public static ControllerElementType rWmttbzDhkUyaRzogdiwQRutjWNU(object A_0)
	{
		if (A_0 == null)
		{
			throw new ArgumentNullException("type");
		}
		Type type = A_0.GetType();
		if (type == typeof(ControllerElementType))
		{
			return (ControllerElementType)A_0;
		}
		if (type == typeof(ControllerTemplateElementType))
		{
			return gRvITEHjKMrWaeGYEmAHofbpCtEU.xDUDoLbiYOUQjsjnuftaWlowBoTm((ControllerTemplateElementType)A_0);
		}
		throw new NotImplementedException();
	}

	// Token: 0x060007B4 RID: 1972 RVA: 0x00003E2E File Offset: 0x0000202E
	public static ControllerElementType xDUDoLbiYOUQjsjnuftaWlowBoTm(ControllerTemplateElementType A_0)
	{
		if (A_0 == ControllerTemplateElementType.Axis)
		{
			return ControllerElementType.Axis;
		}
		if (A_0 != ControllerTemplateElementType.Button)
		{
			throw new NotImplementedException();
		}
		return ControllerElementType.Button;
	}

	// Token: 0x060007B5 RID: 1973 RVA: 0x00008830 File Offset: 0x00006A30
	public static ControllerTemplateElementSourceType hJNAZHESiCJKfmEEpOgaeJWFLauL(ControllerTemplateElementType A_0, bool A_1)
	{
		if (A_0 == ControllerTemplateElementType.Axis)
		{
			return ControllerTemplateElementSourceType.Axis;
		}
		if (A_0 == ControllerTemplateElementType.Button)
		{
			return ControllerTemplateElementSourceType.Button;
		}
		if (A_1)
		{
			throw new NotImplementedException();
		}
		return (ControllerTemplateElementSourceType)(-1);
	}

	// Token: 0x060007B6 RID: 1974 RVA: 0x00008830 File Offset: 0x00006A30
	public static ControllerTemplateElementType CkKlzxvjUXxuZLFtnYQkTRGMtKjm(ControllerElementType A_0, bool A_1)
	{
		if (A_0 == ControllerElementType.Axis)
		{
			return ControllerTemplateElementType.Axis;
		}
		if (A_0 == ControllerElementType.Button)
		{
			return ControllerTemplateElementType.Button;
		}
		if (A_1)
		{
			throw new NotImplementedException();
		}
		return (ControllerTemplateElementType)(-1);
	}
}
