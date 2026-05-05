using System;
using Unity.Services.Core;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000021 RID: 33
	public class CommandInterruptedException : RequestFailedException
	{
		// Token: 0x0600009B RID: 155 RVA: 0x00003A66 File Offset: 0x00001C66
		public CommandInterruptedException(string reason, CentrifugeCloseCode code) : base(23002, "Command interrupted, reason: " + reason)
		{
			this.m_Code = code;
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600009C RID: 156 RVA: 0x00003A85 File Offset: 0x00001C85
		// (set) Token: 0x0600009D RID: 157 RVA: 0x00003A8D File Offset: 0x00001C8D
		public CentrifugeCloseCode m_Code { get; private set; }
	}
}
