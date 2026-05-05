using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x02000038 RID: 56
	[NativeHeader("Modules/IMGUI/GUIState.h")]
	internal class ObjectGUIState : IDisposable
	{
		// Token: 0x06000419 RID: 1049 RVA: 0x0000F38F File Offset: 0x0000D58F
		public ObjectGUIState()
		{
			this.m_Ptr = ObjectGUIState.Internal_Create();
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x0000F3A4 File Offset: 0x0000D5A4
		public void Dispose()
		{
			this.Destroy();
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x0000F3B8 File Offset: 0x0000D5B8
		~ObjectGUIState()
		{
			this.Destroy();
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x0000F3E8 File Offset: 0x0000D5E8
		private void Destroy()
		{
			bool flag = this.m_Ptr != IntPtr.Zero;
			if (flag)
			{
				ObjectGUIState.Internal_Destroy(this.m_Ptr);
				this.m_Ptr = IntPtr.Zero;
			}
		}

		// Token: 0x0600041D RID: 1053
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Internal_Create();

		// Token: 0x0600041E RID: 1054
		[NativeMethod(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Destroy(IntPtr ptr);

		// Token: 0x04000128 RID: 296
		internal IntPtr m_Ptr;
	}
}
