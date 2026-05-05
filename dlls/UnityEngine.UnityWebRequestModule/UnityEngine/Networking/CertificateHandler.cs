using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Networking
{
	// Token: 0x02000005 RID: 5
	[NativeHeader("Modules/UnityWebRequest/Public/CertificateHandler/CertificateHandlerScript.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CertificateHandler : IDisposable
	{
		// Token: 0x0600002E RID: 46
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Create(CertificateHandler obj);

		// Token: 0x0600002F RID: 47
		[NativeMethod(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Release();

		// Token: 0x06000030 RID: 48 RVA: 0x000032B7 File Offset: 0x000014B7
		protected CertificateHandler()
		{
			this.m_Ptr = CertificateHandler.Create(this);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000032D0 File Offset: 0x000014D0
		~CertificateHandler()
		{
			this.Dispose();
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003300 File Offset: 0x00001500
		protected virtual bool ValidateCertificate(byte[] certificateData)
		{
			return false;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003314 File Offset: 0x00001514
		[RequiredByNativeCode]
		internal bool ValidateCertificateNative(byte[] certificateData)
		{
			return this.ValidateCertificate(certificateData);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003330 File Offset: 0x00001530
		public void Dispose()
		{
			bool flag = this.m_Ptr != IntPtr.Zero;
			if (flag)
			{
				this.Release();
				this.m_Ptr = IntPtr.Zero;
			}
		}

		// Token: 0x04000019 RID: 25
		[NonSerialized]
		internal IntPtr m_Ptr;
	}
}
