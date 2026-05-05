using System;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.TLS.LowLevel;

namespace Unity.Networking.Transport.TLS
{
	// Token: 0x02000082 RID: 130
	internal static class ManagedSecureFunctions
	{
		// Token: 0x0600023D RID: 573 RVA: 0x0000C354 File Offset: 0x0000A554
		internal unsafe static void Initialize()
		{
			if (ManagedSecureFunctions.IsInitialized)
			{
				return;
			}
			ManagedSecureFunctions.IsInitialized = true;
			ManagedSecureFunctions.s_sendCallback = new Binding.unitytls_client_data_send_callback(ManagedSecureFunctions.SecureDataSendCallback);
			ManagedSecureFunctions.s_recvCallback = new Binding.unitytls_client_data_receive_callback(ManagedSecureFunctions.SecureDataReceiveCallback);
			*ManagedSecureFunctions.s_SendCallback.Data = new FunctionPointer<Binding.unitytls_client_data_send_callback>(Marshal.GetFunctionPointerForDelegate<Binding.unitytls_client_data_send_callback>(ManagedSecureFunctions.s_sendCallback));
			*ManagedSecureFunctions.s_RecvMethod.Data = new FunctionPointer<Binding.unitytls_client_data_receive_callback>(Marshal.GetFunctionPointerForDelegate<Binding.unitytls_client_data_receive_callback>(ManagedSecureFunctions.s_recvCallback));
		}

		// Token: 0x0600023E RID: 574 RVA: 0x0000C3D0 File Offset: 0x0000A5D0
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(Binding.unitytls_client_data_send_callback))]
		private unsafe static int SecureDataSendCallback(IntPtr userData, byte* data, UIntPtr dataLen, uint status)
		{
			SecureUserData* ptr = (SecureUserData*)((void*)userData);
			NetworkInterfaceSendHandle networkInterfaceSendHandle;
			if (ptr->Interface.BeginSendMessage.Ptr.Invoke(out networkInterfaceSendHandle, ptr->Interface.UserData, (int)dataLen.ToUInt32()) != 0)
			{
				return -26752;
			}
			networkInterfaceSendHandle.size = (int)dataLen.ToUInt32();
			byte* destination = (byte*)((void*)networkInterfaceSendHandle.data);
			UnsafeUtility.MemCpy((void*)destination, (void*)data, (long)dataLen.ToUInt64());
			return ptr->Interface.EndSendMessage.Ptr.Invoke(ref networkInterfaceSendHandle, ref ptr->Remote, ptr->Interface.UserData, ref ptr->QueueHandle);
		}

		// Token: 0x0600023F RID: 575 RVA: 0x0000C478 File Offset: 0x0000A678
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(Binding.unitytls_client_data_receive_callback))]
		private unsafe static int SecureDataReceiveCallback(IntPtr userData, byte* data, UIntPtr dataLen, uint status)
		{
			SecureUserData* ptr = (SecureUserData*)((void*)userData);
			byte* ptr2 = (byte*)((void*)ptr->StreamData);
			if (ptr2 == null || ptr->Size <= 0)
			{
				return -26880;
			}
			if (ptr->BytesProcessed != 0)
			{
				return -26880;
			}
			UnsafeUtility.MemCpy((void*)data, (void*)ptr2, (long)ptr->Size);
			ptr->BytesProcessed = ptr->Size;
			return ptr->Size;
		}

		// Token: 0x040001AD RID: 429
		private const int UNITYTLS_ERR_SSL_WANT_READ = -26880;

		// Token: 0x040001AE RID: 430
		private const int UNITYTLS_ERR_SSL_WANT_WRITE = -26752;

		// Token: 0x040001AF RID: 431
		private static Binding.unitytls_client_data_send_callback s_sendCallback;

		// Token: 0x040001B0 RID: 432
		private static Binding.unitytls_client_data_receive_callback s_recvCallback;

		// Token: 0x040001B1 RID: 433
		private static bool IsInitialized;

		// Token: 0x040001B2 RID: 434
		internal static readonly SharedStatic<FunctionPointer<Binding.unitytls_client_data_send_callback>> s_SendCallback = SharedStatic<FunctionPointer<Binding.unitytls_client_data_send_callback>>.GetOrCreateUnsafe(0U, -5978926962771261641L, 641209945766110788L);

		// Token: 0x040001B3 RID: 435
		internal static readonly SharedStatic<FunctionPointer<Binding.unitytls_client_data_receive_callback>> s_RecvMethod = SharedStatic<FunctionPointer<Binding.unitytls_client_data_receive_callback>>.GetOrCreateUnsafe(0U, -5365965991464889048L, 641209945766110788L);

		// Token: 0x02000083 RID: 131
		private struct ManagedSecureFunctionsKey
		{
		}
	}
}
