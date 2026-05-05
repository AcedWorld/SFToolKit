using System;
using System.Text;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Wire.Protocol.Internal
{
	// Token: 0x0200000E RID: 14
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	internal class Reply
	{
		// Token: 0x0600001D RID: 29 RVA: 0x0000227A File Offset: 0x0000047A
		[Preserve]
		public Reply()
		{
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000228D File Offset: 0x0000048D
		internal static Reply PingReply(uint id)
		{
			return new Reply
			{
				id = id,
				ping = new PingResult()
			};
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000022A6 File Offset: 0x000004A6
		internal static Reply ErrorReply(uint id, Error error)
		{
			return new Reply
			{
				id = id,
				error = error
			};
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000022BB File Offset: 0x000004BB
		internal static Reply SubscribeReply(uint id, SubscribeResult result)
		{
			return new Reply
			{
				id = id,
				subscribe = result
			};
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000022D0 File Offset: 0x000004D0
		internal static Reply UnsubscribeReply(uint id)
		{
			return new Reply
			{
				id = id,
				unsubscribe = new UnsubscribeResult()
			};
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000022E9 File Offset: 0x000004E9
		internal static Reply ConnectReply(uint id, ConnectResult result)
		{
			return new Reply
			{
				id = id,
				connect = result
			};
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000022FE File Offset: 0x000004FE
		internal static Reply PushReply(Push push)
		{
			return new Reply
			{
				push = push
			};
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000230C File Offset: 0x0000050C
		public static Reply FromJson(byte[] jsonData)
		{
			return Reply.FromJson(Encoding.UTF8.GetString(jsonData));
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000231E File Offset: 0x0000051E
		public static Reply FromJson(string jsonData)
		{
			Reply reply = JsonConvert.DeserializeObject<Reply>(jsonData);
			reply.originalString = jsonData;
			return reply;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000232D File Offset: 0x0000052D
		public byte[] ToJson()
		{
			return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this));
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000233F File Offset: 0x0000053F
		public bool HasError()
		{
			return this.error != null && this.error.code > (CentrifugeErrorCode)0;
		}

		// Token: 0x0400002C RID: 44
		public uint id;

		// Token: 0x0400002D RID: 45
		public Error error;

		// Token: 0x0400002E RID: 46
		public ConnectResult connect;

		// Token: 0x0400002F RID: 47
		public SubscribeResult subscribe;

		// Token: 0x04000030 RID: 48
		public UnsubscribeResult unsubscribe;

		// Token: 0x04000031 RID: 49
		public Push push;

		// Token: 0x04000032 RID: 50
		public PingResult ping;

		// Token: 0x04000033 RID: 51
		[JsonIgnore]
		public string originalString = "";
	}
}
