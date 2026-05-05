using System;

namespace UnityEngine
{
	// Token: 0x02000031 RID: 49
	public sealed class ExitGUIException : Exception
	{
		// Token: 0x060003E5 RID: 997 RVA: 0x0000CB5A File Offset: 0x0000AD5A
		public ExitGUIException()
		{
			GUIUtility.guiIsExiting = true;
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x0000CB6B File Offset: 0x0000AD6B
		internal ExitGUIException(string message) : base(message)
		{
			GUIUtility.guiIsExiting = true;
		}
	}
}
