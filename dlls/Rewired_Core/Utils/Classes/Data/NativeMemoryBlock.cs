using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x02000507 RID: 1287
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeMemoryBlock : IDisposable
	{
		// Token: 0x17000BF6 RID: 3062
		// (get) Token: 0x06003491 RID: 13457 RVA: 0x00028636 File Offset: 0x00026836
		public uint size
		{
			get
			{
				return this.LOmNchafUOJGZPEJxMasmXvOnNal;
			}
		}

		// Token: 0x06003492 RID: 13458 RVA: 0x000B51A4 File Offset: 0x000B33A4
		public NativeMemoryBlock(uint A_1)
		{
			if (A_1 == 0U)
			{
				throw new Exception("size must be > 0!");
			}
			this.LOmNchafUOJGZPEJxMasmXvOnNal = A_1;
			this.btNVcVlhnYoQiOFUYZfjQtjvVitn = 0;
			try
			{
				this.dcOTIkkjfykXLZJLVbjGQLszItaX = Marshal.AllocHGlobal((int)A_1);
				if (this.dcOTIkkjfykXLZJLVbjGQLszItaX == IntPtr.Zero)
				{
					throw new Exception("Could not allocate native memory.");
				}
			}
			catch
			{
				throw;
			}
		}

		// Token: 0x06003493 RID: 13459 RVA: 0x000B5214 File Offset: 0x000B3414
		public IntPtr Allocate(uint bytes, IntPtr ptrToData)
		{
			if (this.hnOgapfOmIKeQCEqHjdhODXBUVlqA)
			{
				return IntPtr.Zero;
			}
			if (bytes == 0U)
			{
				return IntPtr.Zero;
			}
			if (bytes > this.LOmNchafUOJGZPEJxMasmXvOnNal)
			{
				return IntPtr.Zero;
			}
			if ((long)this.btNVcVlhnYoQiOFUYZfjQtjvVitn + (long)((ulong)bytes) >= (long)((ulong)this.LOmNchafUOJGZPEJxMasmXvOnNal))
			{
				this.btNVcVlhnYoQiOFUYZfjQtjvVitn = 0;
			}
			IntPtr intPtr = new IntPtr(this.dcOTIkkjfykXLZJLVbjGQLszItaX.ToInt64() + (long)this.btNVcVlhnYoQiOFUYZfjQtjvVitn);
			if (ptrToData != IntPtr.Zero)
			{
				NativeTools.CopyMemory(ptrToData, intPtr, 0, 0, (int)bytes, true);
			}
			this.btNVcVlhnYoQiOFUYZfjQtjvVitn += (int)bytes;
			return intPtr;
		}

		// Token: 0x06003494 RID: 13460 RVA: 0x0002863E File Offset: 0x0002683E
		public IntPtr Allocate(uint bytes)
		{
			return this.Allocate(bytes, IntPtr.Zero);
		}

		// Token: 0x06003495 RID: 13461 RVA: 0x0002864C File Offset: 0x0002684C
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06003496 RID: 13462 RVA: 0x000B52A4 File Offset: 0x000B34A4
		~NativeMemoryBlock()
		{
			this.Dispose(false);
		}

		// Token: 0x06003497 RID: 13463 RVA: 0x0002865B File Offset: 0x0002685B
		protected virtual void Dispose(bool disposing)
		{
			if (this.hnOgapfOmIKeQCEqHjdhODXBUVlqA)
			{
				return;
			}
			this.hnOgapfOmIKeQCEqHjdhODXBUVlqA = true;
			if (this.dcOTIkkjfykXLZJLVbjGQLszItaX != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.dcOTIkkjfykXLZJLVbjGQLszItaX);
				this.dcOTIkkjfykXLZJLVbjGQLszItaX = IntPtr.Zero;
			}
		}

		// Token: 0x04001C05 RID: 7173
		private int btNVcVlhnYoQiOFUYZfjQtjvVitn;

		// Token: 0x04001C06 RID: 7174
		private uint LOmNchafUOJGZPEJxMasmXvOnNal;

		// Token: 0x04001C07 RID: 7175
		private IntPtr dcOTIkkjfykXLZJLVbjGQLszItaX;

		// Token: 0x04001C08 RID: 7176
		private bool hnOgapfOmIKeQCEqHjdhODXBUVlqA;
	}
}
