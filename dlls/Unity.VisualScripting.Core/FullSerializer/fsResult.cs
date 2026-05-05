using System;
using System.Collections.Generic;
using System.Linq;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x020001A7 RID: 423
	public struct fsResult
	{
		// Token: 0x06000B14 RID: 2836 RVA: 0x0002E8EC File Offset: 0x0002CAEC
		public void AddMessage(string message)
		{
			if (this._messages == null)
			{
				this._messages = new List<string>();
			}
			this._messages.Add(message);
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x0002E90D File Offset: 0x0002CB0D
		public void AddMessages(fsResult result)
		{
			if (result._messages == null)
			{
				return;
			}
			if (this._messages == null)
			{
				this._messages = new List<string>();
			}
			this._messages.AddRange(result._messages);
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x0002E93C File Offset: 0x0002CB3C
		public fsResult Merge(fsResult other)
		{
			this._success = (this._success && other._success);
			if (other._messages != null)
			{
				if (this._messages == null)
				{
					this._messages = new List<string>(other._messages);
				}
				else
				{
					this._messages.AddRange(other._messages);
				}
			}
			return this;
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x0002E99C File Offset: 0x0002CB9C
		public static fsResult Warn(string warning)
		{
			return new fsResult
			{
				_success = true,
				_messages = new List<string>
				{
					warning
				}
			};
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x0002E9D0 File Offset: 0x0002CBD0
		public static fsResult Fail(string warning)
		{
			return new fsResult
			{
				_success = false,
				_messages = new List<string>
				{
					warning
				}
			};
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x0002EA01 File Offset: 0x0002CC01
		public static fsResult operator +(fsResult a, fsResult b)
		{
			return a.Merge(b);
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000B1A RID: 2842 RVA: 0x0002EA0B File Offset: 0x0002CC0B
		public bool Failed
		{
			get
			{
				return !this._success;
			}
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000B1B RID: 2843 RVA: 0x0002EA16 File Offset: 0x0002CC16
		public bool Succeeded
		{
			get
			{
				return this._success;
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000B1C RID: 2844 RVA: 0x0002EA1E File Offset: 0x0002CC1E
		public bool HasWarnings
		{
			get
			{
				return this._messages != null && this._messages.Any<string>();
			}
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x0002EA35 File Offset: 0x0002CC35
		public fsResult AssertSuccess()
		{
			if (this.Failed)
			{
				throw this.AsException;
			}
			return this;
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x0002EA4C File Offset: 0x0002CC4C
		public fsResult AssertSuccessWithoutWarnings()
		{
			if (this.Failed || this.RawMessages.Any<string>())
			{
				throw this.AsException;
			}
			return this;
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000B1F RID: 2847 RVA: 0x0002EA70 File Offset: 0x0002CC70
		public Exception AsException
		{
			get
			{
				if (!this.Failed && !this.RawMessages.Any<string>())
				{
					throw new Exception("Only a failed result can be converted to an exception");
				}
				return new Exception(this.FormattedMessages);
			}
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000B20 RID: 2848 RVA: 0x0002EA9D File Offset: 0x0002CC9D
		public IEnumerable<string> RawMessages
		{
			get
			{
				if (this._messages != null)
				{
					return this._messages;
				}
				return fsResult.EmptyStringArray;
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06000B21 RID: 2849 RVA: 0x0002EAB3 File Offset: 0x0002CCB3
		public string FormattedMessages
		{
			get
			{
				return string.Join(",\n", this.RawMessages.ToArray<string>());
			}
		}

		// Token: 0x04000295 RID: 661
		private static readonly string[] EmptyStringArray = new string[0];

		// Token: 0x04000296 RID: 662
		private bool _success;

		// Token: 0x04000297 RID: 663
		private List<string> _messages;

		// Token: 0x04000298 RID: 664
		public static fsResult Success = new fsResult
		{
			_success = true
		};
	}
}
