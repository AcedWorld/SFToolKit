using System;
using Rewired;
using Rewired.Utils.Classes.Utility;

// Token: 0x02000002 RID: 2
internal static class jbcfMDoFeBFAQElVePZhKkwUdctNA
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000001 RID: 1 RVA: 0x000111E8 File Offset: 0x0000F3E8
	public static int dHcfLGecBdWpOuQXknheqwKuIFtT
	{
		get
		{
			return jbcfMDoFeBFAQElVePZhKkwUdctNA.ENrmHVxeXyogdHIVzYDGANfMCnaHA;
		}
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000002 RID: 2 RVA: 0x000111EF File Offset: 0x0000F3EF
	public static ThreadHelper UNwhYSKkSCFjORvKlnIzsjTYMhXw
	{
		get
		{
			return jbcfMDoFeBFAQElVePZhKkwUdctNA.ROWBpkeHEDjSTGmvJbgFQMqIqHRV;
		}
	}

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000003 RID: 3 RVA: 0x000111F6 File Offset: 0x0000F3F6
	public static ThreadHelper prRtvFqbpHFFuejHFlkEaBqjmwLU
	{
		get
		{
			return jbcfMDoFeBFAQElVePZhKkwUdctNA.pccFHQDGjKIotJjWmOlGhOTPbuhUA;
		}
	}

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x06000004 RID: 4 RVA: 0x000111EF File Offset: 0x0000F3EF
	public static ThreadHelper ZDYmSbdCWXNMZFZsjWAgCzkVkDMh
	{
		get
		{
			return jbcfMDoFeBFAQElVePZhKkwUdctNA.ROWBpkeHEDjSTGmvJbgFQMqIqHRV;
		}
	}

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x06000005 RID: 5 RVA: 0x000111F6 File Offset: 0x0000F3F6
	public static ThreadHelper EqGdpsfqHLTddwKzexbHrfPVtYZPA
	{
		get
		{
			return jbcfMDoFeBFAQElVePZhKkwUdctNA.pccFHQDGjKIotJjWmOlGhOTPbuhUA;
		}
	}

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x06000006 RID: 6 RVA: 0x000111EF File Offset: 0x0000F3EF
	public static ThreadHelper eQmyubfXFfDTkZSIsiJXwJNPzMdS
	{
		get
		{
			return jbcfMDoFeBFAQElVePZhKkwUdctNA.ROWBpkeHEDjSTGmvJbgFQMqIqHRV;
		}
	}

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x06000007 RID: 7 RVA: 0x000111EF File Offset: 0x0000F3EF
	public static ThreadHelper ptDgIhpTpaBgqHexjkEmiBrVOPDgb
	{
		get
		{
			return jbcfMDoFeBFAQElVePZhKkwUdctNA.ROWBpkeHEDjSTGmvJbgFQMqIqHRV;
		}
	}

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x06000008 RID: 8 RVA: 0x000111FD File Offset: 0x0000F3FD
	public static bool EXRGczsVoSxEBAiNjvLMBJHhGCaI
	{
		get
		{
			return jbcfMDoFeBFAQElVePZhKkwUdctNA.ROWBpkeHEDjSTGmvJbgFQMqIqHRV != null && jbcfMDoFeBFAQElVePZhKkwUdctNA.ROWBpkeHEDjSTGmvJbgFQMqIqHRV.isRunning;
		}
	}

	// Token: 0x06000009 RID: 9 RVA: 0x0001D62C File Offset: 0x0001B82C
	public static void mEaapnChteVJwORTrycWUfioKHRfA(bool A_0)
	{
		jbcfMDoFeBFAQElVePZhKkwUdctNA.ENrmHVxeXyogdHIVzYDGANfMCnaHA = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
		if (jbcfMDoFeBFAQElVePZhKkwUdctNA.ROWBpkeHEDjSTGmvJbgFQMqIqHRV != null)
		{
			throw new Exception("Input Thread Manager is already initialized.");
		}
		jbcfMDoFeBFAQElVePZhKkwUdctNA.ROWBpkeHEDjSTGmvJbgFQMqIqHRV = ThreadHelper.CreateFixedTimeStep(jbcfMDoFeBFAQElVePZhKkwUdctNA.ENrmHVxeXyogdHIVzYDGANfMCnaHA, false, 0);
		jbcfMDoFeBFAQElVePZhKkwUdctNA.ROWBpkeHEDjSTGmvJbgFQMqIqHRV.Start(true);
		if (A_0)
		{
			jbcfMDoFeBFAQElVePZhKkwUdctNA.pccFHQDGjKIotJjWmOlGhOTPbuhUA = ThreadHelper.CreateFixedTimeStep(100, false, 0);
			jbcfMDoFeBFAQElVePZhKkwUdctNA.pccFHQDGjKIotJjWmOlGhOTPbuhUA.Start(true);
		}
		ReInput.UpdateStartedEvent += jbcfMDoFeBFAQElVePZhKkwUdctNA.JqvjunSAxFjRYRVhpTcxAUehwnPX;
	}

	// Token: 0x0600000A RID: 10 RVA: 0x0001D6A8 File Offset: 0x0001B8A8
	private static void JqvjunSAxFjRYRVhpTcxAUehwnPX(UpdateLoopType A_0)
	{
		if (A_0 != UpdateLoopType.Update)
		{
			return;
		}
		int platformVar_joystickRefreshRate = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
		if (jbcfMDoFeBFAQElVePZhKkwUdctNA.ENrmHVxeXyogdHIVzYDGANfMCnaHA != platformVar_joystickRefreshRate)
		{
			jbcfMDoFeBFAQElVePZhKkwUdctNA.ENrmHVxeXyogdHIVzYDGANfMCnaHA = platformVar_joystickRefreshRate;
			jbcfMDoFeBFAQElVePZhKkwUdctNA.ROWBpkeHEDjSTGmvJbgFQMqIqHRV.fixedTimeStepFPS = platformVar_joystickRefreshRate;
		}
	}

	// Token: 0x0600000B RID: 11 RVA: 0x0001D6E0 File Offset: 0x0001B8E0
	public static void EivjXMyDJrcuzHrbmimqGXwBZEXgA()
	{
		ReInput.UpdateStartedEvent -= jbcfMDoFeBFAQElVePZhKkwUdctNA.JqvjunSAxFjRYRVhpTcxAUehwnPX;
		if (jbcfMDoFeBFAQElVePZhKkwUdctNA.ROWBpkeHEDjSTGmvJbgFQMqIqHRV != null)
		{
			jbcfMDoFeBFAQElVePZhKkwUdctNA.ROWBpkeHEDjSTGmvJbgFQMqIqHRV.WaitForActionQueueToFinish();
			jbcfMDoFeBFAQElVePZhKkwUdctNA.ROWBpkeHEDjSTGmvJbgFQMqIqHRV.Dispose();
			jbcfMDoFeBFAQElVePZhKkwUdctNA.ROWBpkeHEDjSTGmvJbgFQMqIqHRV = null;
		}
		if (jbcfMDoFeBFAQElVePZhKkwUdctNA.pccFHQDGjKIotJjWmOlGhOTPbuhUA != null)
		{
			jbcfMDoFeBFAQElVePZhKkwUdctNA.pccFHQDGjKIotJjWmOlGhOTPbuhUA.WaitForActionQueueToFinish();
			jbcfMDoFeBFAQElVePZhKkwUdctNA.pccFHQDGjKIotJjWmOlGhOTPbuhUA.Dispose();
			jbcfMDoFeBFAQElVePZhKkwUdctNA.pccFHQDGjKIotJjWmOlGhOTPbuhUA = null;
		}
	}

	// Token: 0x04000001 RID: 1
	private const bool pLVYcODFXqOGGlJgNTymjlANrdXX = false;

	// Token: 0x04000002 RID: 2
	private static int ENrmHVxeXyogdHIVzYDGANfMCnaHA;

	// Token: 0x04000003 RID: 3
	private static ThreadHelper ROWBpkeHEDjSTGmvJbgFQMqIqHRV;

	// Token: 0x04000004 RID: 4
	private static ThreadHelper pccFHQDGjKIotJjWmOlGhOTPbuhUA;
}
