using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x02000206 RID: 518
	[NativeHeader("Runtime/Export/PlayerConnection/PlayerConnectionInternal.bindings.h")]
	internal class PlayerConnectionInternal : IPlayerEditorConnectionNative
	{
		// Token: 0x06001770 RID: 6000 RVA: 0x000272B8 File Offset: 0x000254B8
		void IPlayerEditorConnectionNative.SendMessage(Guid messageId, byte[] data, int playerId)
		{
			bool flag = messageId == Guid.Empty;
			if (flag)
			{
				throw new ArgumentException("messageId must not be empty");
			}
			PlayerConnectionInternal.SendMessage(messageId.ToString("N"), data, playerId);
		}

		// Token: 0x06001771 RID: 6001 RVA: 0x000272F8 File Offset: 0x000254F8
		bool IPlayerEditorConnectionNative.TrySendMessage(Guid messageId, byte[] data, int playerId)
		{
			bool flag = messageId == Guid.Empty;
			if (flag)
			{
				throw new ArgumentException("messageId must not be empty");
			}
			return PlayerConnectionInternal.TrySendMessage(messageId.ToString("N"), data, playerId);
		}

		// Token: 0x06001772 RID: 6002 RVA: 0x00027338 File Offset: 0x00025538
		void IPlayerEditorConnectionNative.Poll()
		{
			PlayerConnectionInternal.PollInternal();
		}

		// Token: 0x06001773 RID: 6003 RVA: 0x00027341 File Offset: 0x00025541
		void IPlayerEditorConnectionNative.RegisterInternal(Guid messageId)
		{
			PlayerConnectionInternal.RegisterInternal(messageId.ToString("N"));
		}

		// Token: 0x06001774 RID: 6004 RVA: 0x00027356 File Offset: 0x00025556
		void IPlayerEditorConnectionNative.UnregisterInternal(Guid messageId)
		{
			PlayerConnectionInternal.UnregisterInternal(messageId.ToString("N"));
		}

		// Token: 0x06001775 RID: 6005 RVA: 0x0002736B File Offset: 0x0002556B
		void IPlayerEditorConnectionNative.Initialize()
		{
			PlayerConnectionInternal.Initialize();
		}

		// Token: 0x06001776 RID: 6006 RVA: 0x00027374 File Offset: 0x00025574
		bool IPlayerEditorConnectionNative.IsConnected()
		{
			return PlayerConnectionInternal.IsConnected();
		}

		// Token: 0x06001777 RID: 6007 RVA: 0x0002738B File Offset: 0x0002558B
		void IPlayerEditorConnectionNative.DisconnectAll()
		{
			PlayerConnectionInternal.DisconnectAll();
		}

		// Token: 0x06001778 RID: 6008
		[FreeFunction("PlayerConnection_Bindings::IsConnected")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsConnected();

		// Token: 0x06001779 RID: 6009
		[FreeFunction("PlayerConnection_Bindings::Initialize")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Initialize();

		// Token: 0x0600177A RID: 6010
		[FreeFunction("PlayerConnection_Bindings::RegisterInternal")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RegisterInternal(string messageId);

		// Token: 0x0600177B RID: 6011
		[FreeFunction("PlayerConnection_Bindings::UnregisterInternal")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void UnregisterInternal(string messageId);

		// Token: 0x0600177C RID: 6012
		[FreeFunction("PlayerConnection_Bindings::SendMessage")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SendMessage(string messageId, [Unmarshalled] byte[] data, int playerId);

		// Token: 0x0600177D RID: 6013
		[FreeFunction("PlayerConnection_Bindings::TrySendMessage")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TrySendMessage(string messageId, [Unmarshalled] byte[] data, int playerId);

		// Token: 0x0600177E RID: 6014
		[FreeFunction("PlayerConnection_Bindings::PollInternal")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PollInternal();

		// Token: 0x0600177F RID: 6015
		[FreeFunction("PlayerConnection_Bindings::DisconnectAll")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DisconnectAll();

		// Token: 0x02000207 RID: 519
		[Flags]
		public enum MulticastFlags
		{
			// Token: 0x04000863 RID: 2147
			kRequestImmediateConnect = 1,
			// Token: 0x04000864 RID: 2148
			kSupportsProfile = 2,
			// Token: 0x04000865 RID: 2149
			kCustomMessage = 4,
			// Token: 0x04000866 RID: 2150
			kUseAlternateIP = 8
		}
	}
}
