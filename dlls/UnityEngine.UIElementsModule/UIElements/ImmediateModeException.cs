using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200026C RID: 620
	internal class ImmediateModeException : Exception
	{
		// Token: 0x060011AB RID: 4523 RVA: 0x000405BC File Offset: 0x0003E7BC
		public ImmediateModeException(Exception inner) : base("", inner)
		{
		}
	}
}
