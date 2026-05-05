using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001CA RID: 458
	internal struct UTF8StringPtr
	{
		// Token: 0x06000AA6 RID: 2726 RVA: 0x00010140 File Offset: 0x0000E340
		internal UTF8StringPtr(string str, DisposableCollection disposableCollection)
		{
			if (str == null)
			{
				this.pointer = IntPtr.Zero;
				return;
			}
			byte[] array = Converters.StringToNullTerminatedUTF8ByteArray(str);
			DisposableBuffer disposableBuffer = new DisposableBuffer(array.Length);
			Marshal.Copy(array, 0, disposableBuffer.IntPtr, array.Length);
			disposableCollection.Add<DisposableBuffer>(disposableBuffer);
			this.pointer = disposableBuffer.IntPtr;
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x00010190 File Offset: 0x0000E390
		internal string GetString()
		{
			if (this.pointer == IntPtr.Zero)
			{
				return null;
			}
			return Converters.PtrToStringUTF8(this.pointer);
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x000101B1 File Offset: 0x0000E3B1
		internal IntPtr ToPointer()
		{
			return this.pointer;
		}

		// Token: 0x040005F2 RID: 1522
		private IntPtr pointer;
	}
}
