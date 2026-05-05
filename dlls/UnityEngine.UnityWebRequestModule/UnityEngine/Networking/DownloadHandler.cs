using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Networking
{
	// Token: 0x02000006 RID: 6
	[NativeHeader("Modules/UnityWebRequest/Public/DownloadHandler/DownloadHandler.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class DownloadHandler : IDisposable
	{
		// Token: 0x06000035 RID: 53
		[NativeMethod(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Release();

		// Token: 0x06000036 RID: 54 RVA: 0x00003366 File Offset: 0x00001566
		[VisibleToOtherModules]
		internal DownloadHandler()
		{
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003370 File Offset: 0x00001570
		~DownloadHandler()
		{
			this.Dispose();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000033A0 File Offset: 0x000015A0
		public virtual void Dispose()
		{
			bool flag = this.m_Ptr != IntPtr.Zero;
			if (flag)
			{
				this.Release();
				this.m_Ptr = IntPtr.Zero;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000039 RID: 57 RVA: 0x000033D8 File Offset: 0x000015D8
		public bool isDone
		{
			get
			{
				return this.IsDone();
			}
		}

		// Token: 0x0600003A RID: 58
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool IsDone();

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600003B RID: 59 RVA: 0x000033F0 File Offset: 0x000015F0
		public string error
		{
			get
			{
				return this.GetErrorMsg();
			}
		}

		// Token: 0x0600003C RID: 60
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern string GetErrorMsg();

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00003408 File Offset: 0x00001608
		public NativeArray<byte>.ReadOnly nativeData
		{
			get
			{
				return this.GetNativeData().AsReadOnly();
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00003428 File Offset: 0x00001628
		public byte[] data
		{
			get
			{
				return this.GetData();
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00003440 File Offset: 0x00001640
		public string text
		{
			get
			{
				return this.GetText();
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003458 File Offset: 0x00001658
		protected virtual NativeArray<byte> GetNativeData()
		{
			return default(NativeArray<byte>);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003474 File Offset: 0x00001674
		protected virtual byte[] GetData()
		{
			return DownloadHandler.InternalGetByteArray(this);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000348C File Offset: 0x0000168C
		protected unsafe virtual string GetText()
		{
			NativeArray<byte> nativeData = this.GetNativeData();
			bool flag = nativeData.IsCreated && nativeData.Length > 0;
			string result;
			if (flag)
			{
				result = new string((sbyte*)nativeData.GetUnsafeReadOnlyPtr<byte>(), 0, nativeData.Length, this.GetTextEncoder());
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000034E4 File Offset: 0x000016E4
		private Encoding GetTextEncoder()
		{
			string contentType = this.GetContentType();
			bool flag = !string.IsNullOrEmpty(contentType);
			if (flag)
			{
				int num = contentType.IndexOf("charset", StringComparison.OrdinalIgnoreCase);
				bool flag2 = num > -1;
				if (flag2)
				{
					int num2 = contentType.IndexOf('=', num);
					bool flag3 = num2 > -1;
					if (flag3)
					{
						string text = contentType.Substring(num2 + 1).Trim().Trim(new char[]
						{
							'\'',
							'"'
						}).Trim();
						int num3 = text.IndexOf(';');
						bool flag4 = num3 > -1;
						if (flag4)
						{
							text = text.Substring(0, num3);
						}
						try
						{
							return Encoding.GetEncoding(text);
						}
						catch (ArgumentException ex)
						{
							Debug.LogWarning(string.Format("Unsupported encoding '{0}': {1}", text, ex.Message));
						}
						catch (NotSupportedException ex2)
						{
							Debug.LogWarning(string.Format("Unsupported encoding '{0}': {1}", text, ex2.Message));
						}
					}
				}
			}
			return Encoding.UTF8;
		}

		// Token: 0x06000044 RID: 68
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern string GetContentType();

		// Token: 0x06000045 RID: 69 RVA: 0x00003600 File Offset: 0x00001800
		[RequiredByNativeCode]
		protected virtual bool ReceiveData(byte[] data, int dataLength)
		{
			return true;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003613 File Offset: 0x00001813
		[RequiredByNativeCode]
		protected virtual void ReceiveContentLengthHeader(ulong contentLength)
		{
			this.ReceiveContentLength((int)contentLength);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x0000361F File Offset: 0x0000181F
		[Obsolete("Use ReceiveContentLengthHeader")]
		protected virtual void ReceiveContentLength(int contentLength)
		{
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000361F File Offset: 0x0000181F
		[RequiredByNativeCode]
		protected virtual void CompleteContent()
		{
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003624 File Offset: 0x00001824
		[RequiredByNativeCode]
		protected virtual float GetProgress()
		{
			return 0f;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000363C File Offset: 0x0000183C
		protected static T GetCheckedDownloader<T>(UnityWebRequest www) where T : DownloadHandler
		{
			bool flag = www == null;
			if (flag)
			{
				throw new NullReferenceException("Cannot get content from a null UnityWebRequest object");
			}
			bool flag2 = !www.isDone;
			if (flag2)
			{
				throw new InvalidOperationException("Cannot get content from an unfinished UnityWebRequest object");
			}
			bool flag3 = www.result == UnityWebRequest.Result.ProtocolError;
			if (flag3)
			{
				throw new InvalidOperationException(www.error);
			}
			return (T)((object)www.downloadHandler);
		}

		// Token: 0x0600004B RID: 75
		[VisibleToOtherModules]
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal unsafe static extern byte* InternalGetByteArray(DownloadHandler dh, out int length);

		// Token: 0x0600004C RID: 76 RVA: 0x000036A0 File Offset: 0x000018A0
		internal static byte[] InternalGetByteArray(DownloadHandler dh)
		{
			NativeArray<byte> nativeData = dh.GetNativeData();
			bool isCreated = nativeData.IsCreated;
			byte[] result;
			if (isCreated)
			{
				result = nativeData.ToArray();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000036D0 File Offset: 0x000018D0
		internal unsafe static NativeArray<byte> InternalGetNativeArray(DownloadHandler dh, ref NativeArray<byte> nativeArray)
		{
			int num;
			byte* bytes = DownloadHandler.InternalGetByteArray(dh, out num);
			bool isCreated = nativeArray.IsCreated;
			if (isCreated)
			{
				bool flag = nativeArray.Length == num;
				if (flag)
				{
					return nativeArray;
				}
				DownloadHandler.DisposeNativeArray(ref nativeArray);
			}
			DownloadHandler.CreateNativeArrayForNativeData(ref nativeArray, bytes, num);
			return nativeArray;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003728 File Offset: 0x00001928
		internal static void DisposeNativeArray(ref NativeArray<byte> data)
		{
			bool flag = !data.IsCreated;
			if (!flag)
			{
				data = default(NativeArray<byte>);
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000374C File Offset: 0x0000194C
		internal unsafe static void CreateNativeArrayForNativeData(ref NativeArray<byte> data, byte* bytes, int length)
		{
			data = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>((void*)bytes, length, Allocator.Persistent);
		}

		// Token: 0x0400001A RID: 26
		[VisibleToOtherModules]
		[NonSerialized]
		internal IntPtr m_Ptr;
	}
}
