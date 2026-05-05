using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Rendering
{
	// Token: 0x02000430 RID: 1072
	[NativeHeader("Runtime/Graphics/DrawSplashScreenAndWatermarks.h")]
	public class SplashScreen
	{
		// Token: 0x17000683 RID: 1667
		// (get) Token: 0x06002420 RID: 9248
		public static extern bool isFinished { [FreeFunction("IsSplashScreenFinished")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06002421 RID: 9249
		[FreeFunction]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CancelSplashScreen();

		// Token: 0x06002422 RID: 9250
		[FreeFunction]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void BeginSplashScreenFade();

		// Token: 0x06002423 RID: 9251
		[FreeFunction("BeginSplashScreen_Binding")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void Begin();

		// Token: 0x06002424 RID: 9252 RVA: 0x0003C018 File Offset: 0x0003A218
		public static void Stop(SplashScreen.StopBehavior stopBehavior)
		{
			bool flag = stopBehavior == SplashScreen.StopBehavior.FadeOut;
			if (flag)
			{
				SplashScreen.BeginSplashScreenFade();
			}
			else
			{
				SplashScreen.CancelSplashScreen();
			}
		}

		// Token: 0x06002425 RID: 9253
		[FreeFunction("DrawSplashScreen_Binding")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void Draw();

		// Token: 0x06002426 RID: 9254
		[FreeFunction("SetSplashScreenTime")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void SetTime(float time);

		// Token: 0x02000431 RID: 1073
		public enum StopBehavior
		{
			// Token: 0x04000D19 RID: 3353
			StopImmediate,
			// Token: 0x04000D1A RID: 3354
			FadeOut
		}
	}
}
