using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine.Networking
{
	// Token: 0x02000012 RID: 18
	[NativeHeader("Modules/UnityWebRequest/Public/UploadHandler/UploadHandler.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class UploadHandler : IDisposable
	{
		// Token: 0x0600010C RID: 268
		[NativeMethod(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Release();

		// Token: 0x0600010D RID: 269 RVA: 0x00003366 File Offset: 0x00001566
		internal UploadHandler()
		{
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000050C4 File Offset: 0x000032C4
		~UploadHandler()
		{
			this.Dispose();
		}

		// Token: 0x0600010F RID: 271 RVA: 0x000050F4 File Offset: 0x000032F4
		public virtual void Dispose()
		{
			bool flag = this.m_Ptr != IntPtr.Zero;
			if (flag)
			{
				this.Release();
				this.m_Ptr = IntPtr.Zero;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000110 RID: 272 RVA: 0x0000512C File Offset: 0x0000332C
		public byte[] data
		{
			get
			{
				return this.GetData();
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00005144 File Offset: 0x00003344
		// (set) Token: 0x06000112 RID: 274 RVA: 0x0000515C File Offset: 0x0000335C
		public string contentType
		{
			get
			{
				return this.GetContentType();
			}
			set
			{
				this.SetContentType(value);
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00005168 File Offset: 0x00003368
		public float progress
		{
			get
			{
				return this.GetProgress();
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00005180 File Offset: 0x00003380
		internal virtual byte[] GetData()
		{
			return null;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00005194 File Offset: 0x00003394
		internal virtual string GetContentType()
		{
			return this.InternalGetContentType();
		}

		// Token: 0x06000116 RID: 278 RVA: 0x000051AC File Offset: 0x000033AC
		internal virtual void SetContentType(string newContentType)
		{
			this.InternalSetContentType(newContentType);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x000051B8 File Offset: 0x000033B8
		internal virtual float GetProgress()
		{
			return this.InternalGetProgress();
		}

		// Token: 0x06000118 RID: 280
		[NativeMethod("GetContentType")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern string InternalGetContentType();

		// Token: 0x06000119 RID: 281
		[NativeMethod("SetContentType")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void InternalSetContentType(string newContentType);

		// Token: 0x0600011A RID: 282
		[NativeMethod("GetProgress")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern float InternalGetProgress();

		// Token: 0x04000068 RID: 104
		[NonSerialized]
		internal IntPtr m_Ptr;
	}
}
