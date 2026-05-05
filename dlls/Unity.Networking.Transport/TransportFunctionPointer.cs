using System;
using System.Runtime.InteropServices;
using Unity.Burst;

namespace Unity.Networking.Transport
{
	// Token: 0x0200007D RID: 125
	public struct TransportFunctionPointer<T> where T : Delegate
	{
		// Token: 0x06000226 RID: 550 RVA: 0x0000BC8C File Offset: 0x00009E8C
		public TransportFunctionPointer(T executeDelegate)
		{
			this.Ptr = BurstCompiler.CompileFunctionPointer<T>(executeDelegate);
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000BC9A File Offset: 0x00009E9A
		public TransportFunctionPointer(FunctionPointer<T> Pointer)
		{
			this.Ptr = Pointer;
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000BCA3 File Offset: 0x00009EA3
		public static TransportFunctionPointer<T> Burst(T burstCompilableDelegate)
		{
			return new TransportFunctionPointer<T>(BurstCompiler.CompileFunctionPointer<T>(burstCompilableDelegate));
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000BCB0 File Offset: 0x00009EB0
		public static TransportFunctionPointer<T> Managed(T managedDelegate)
		{
			GCHandle.Alloc(managedDelegate);
			return new TransportFunctionPointer<T>(new FunctionPointer<T>(Marshal.GetFunctionPointerForDelegate<T>(managedDelegate)));
		}

		// Token: 0x04000196 RID: 406
		public readonly FunctionPointer<T> Ptr;
	}
}
