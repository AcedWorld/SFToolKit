using System;

namespace UnityEngine.Assertions
{
	// Token: 0x020004F3 RID: 1267
	public class AssertionException : Exception
	{
		// Token: 0x06002C43 RID: 11331 RVA: 0x0004A5C3 File Offset: 0x000487C3
		public AssertionException(string message, string userMessage) : base(message)
		{
			this.m_UserMessage = userMessage;
		}

		// Token: 0x17000843 RID: 2115
		// (get) Token: 0x06002C44 RID: 11332 RVA: 0x0004A5D8 File Offset: 0x000487D8
		public override string Message
		{
			get
			{
				string text = base.Message;
				bool flag = this.m_UserMessage != null;
				if (flag)
				{
					text = this.m_UserMessage + "\n" + text;
				}
				return text;
			}
		}

		// Token: 0x04001124 RID: 4388
		private string m_UserMessage;
	}
}
