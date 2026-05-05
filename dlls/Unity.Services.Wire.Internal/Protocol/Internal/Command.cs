using System;
using System.Text;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Wire.Protocol.Internal
{
	// Token: 0x02000005 RID: 5
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	internal class Command
	{
		// Token: 0x06000004 RID: 4 RVA: 0x000020C8 File Offset: 0x000002C8
		[Preserve]
		public Command()
		{
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020D0 File Offset: 0x000002D0
		public Command(PingRequest request)
		{
			this.id = CommandID.GenerateNewId();
			this.ping = request;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020EA File Offset: 0x000002EA
		public Command(ConnectRequest request)
		{
			this.id = CommandID.GenerateNewId();
			this.connect = request;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002104 File Offset: 0x00000304
		public Command(SubscribeRequest request)
		{
			this.id = CommandID.GenerateNewId();
			this.subscribe = request;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000211E File Offset: 0x0000031E
		public Command(UnsubscribeRequest request)
		{
			this.id = CommandID.GenerateNewId();
			this.unsubscribe = request;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002138 File Offset: 0x00000338
		public static Command FromJSON(byte[] data)
		{
			return JsonConvert.DeserializeObject<Command>(Encoding.UTF8.GetString(data));
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000214A File Offset: 0x0000034A
		public byte[] GetBytes()
		{
			return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this, Formatting.None));
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000215D File Offset: 0x0000035D
		public new string ToString()
		{
			return JsonConvert.SerializeObject(this, Formatting.None);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002166 File Offset: 0x00000366
		internal bool IsPing()
		{
			return this.ping != null;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002171 File Offset: 0x00000371
		public string GetMethod()
		{
			if (this.connect != null)
			{
				return "CONNECT";
			}
			if (this.subscribe != null)
			{
				return "SUBSCRIBE";
			}
			if (this.unsubscribe != null)
			{
				return "UNSUBSCRIBE";
			}
			if (this.ping != null)
			{
				return "PING";
			}
			return "UNKNOWN";
		}

		// Token: 0x04000013 RID: 19
		public uint id;

		// Token: 0x04000014 RID: 20
		public ConnectRequest connect;

		// Token: 0x04000015 RID: 21
		public SubscribeRequest subscribe;

		// Token: 0x04000016 RID: 22
		public UnsubscribeRequest unsubscribe;

		// Token: 0x04000017 RID: 23
		public PingRequest ping;
	}
}
