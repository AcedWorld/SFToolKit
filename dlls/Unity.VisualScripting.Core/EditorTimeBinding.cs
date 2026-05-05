using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000034 RID: 52
	public static class EditorTimeBinding
	{
		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x00004CF4 File Offset: 0x00002EF4
		public static int frame
		{
			get
			{
				if (EditorTimeBinding.frameBinding == null || !UnityThread.allowsAPI)
				{
					return 0;
				}
				return EditorTimeBinding.frameBinding();
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x00004D10 File Offset: 0x00002F10
		public static float time
		{
			get
			{
				if (EditorTimeBinding.timeBinding == null || !UnityThread.allowsAPI)
				{
					return 0f;
				}
				return EditorTimeBinding.timeBinding();
			}
		}

		// Token: 0x0400002D RID: 45
		public static Func<int> frameBinding = () => Time.frameCount;

		// Token: 0x0400002E RID: 46
		public static Func<float> timeBinding = () => Time.time;
	}
}
