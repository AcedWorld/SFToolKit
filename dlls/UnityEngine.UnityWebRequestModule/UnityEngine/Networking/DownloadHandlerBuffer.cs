using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using UnityEngine.Bindings;

namespace UnityEngine.Networking
{
	// Token: 0x02000007 RID: 7
	[NativeHeader("Modules/UnityWebRequest/Public/DownloadHandler/DownloadHandlerBuffer.h")]
	[StructLayout(LayoutKind.Sequential)]
	public sealed class DownloadHandlerBuffer : DownloadHandler
	{
		// Token: 0x06000050 RID: 80
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Create(DownloadHandlerBuffer obj);

		// Token: 0x06000051 RID: 81 RVA: 0x0000375D File Offset: 0x0000195D
		private void InternalCreateBuffer()
		{
			this.m_Ptr = DownloadHandlerBuffer.Create(this);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000376C File Offset: 0x0000196C
		public DownloadHandlerBuffer()
		{
			this.InternalCreateBuffer();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003780 File Offset: 0x00001980
		protected override NativeArray<byte> GetNativeData()
		{
			return DownloadHandler.InternalGetNativeArray(this, ref this.m_NativeData);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000379E File Offset: 0x0000199E
		public override void Dispose()
		{
			DownloadHandler.DisposeNativeArray(ref this.m_NativeData);
			base.Dispose();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000037B4 File Offset: 0x000019B4
		public static string GetContent(UnityWebRequest www)
		{
			return DownloadHandler.GetCheckedDownloader<DownloadHandlerBuffer>(www).text;
		}

		// Token: 0x0400001B RID: 27
		private NativeArray<byte> m_NativeData;
	}
}
