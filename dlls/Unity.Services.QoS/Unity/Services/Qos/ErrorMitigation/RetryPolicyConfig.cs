using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Services.Qos.ErrorMitigation
{
	// Token: 0x02000073 RID: 115
	internal class RetryPolicyConfig
	{
		// Token: 0x17000083 RID: 131
		// (get) Token: 0x0600022C RID: 556 RVA: 0x00007E53 File Offset: 0x00006053
		// (set) Token: 0x0600022D RID: 557 RVA: 0x00007E5B File Offset: 0x0000605B
		public uint MaxRetries { get; set; } = 4U;

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600022E RID: 558 RVA: 0x00007E64 File Offset: 0x00006064
		// (set) Token: 0x0600022F RID: 559 RVA: 0x00007E6C File Offset: 0x0000606C
		public float JitterMagnitude
		{
			get
			{
				return this._jitterMagnitude;
			}
			set
			{
				this._jitterMagnitude = Mathf.Clamp(value, 0.001f, 1f);
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000230 RID: 560 RVA: 0x00007E84 File Offset: 0x00006084
		// (set) Token: 0x06000231 RID: 561 RVA: 0x00007E8C File Offset: 0x0000608C
		public float DelayScale
		{
			get
			{
				return this._delayScale;
			}
			set
			{
				this._delayScale = Mathf.Clamp(value, 0.05f, 1f);
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000232 RID: 562 RVA: 0x00007EA4 File Offset: 0x000060A4
		// (set) Token: 0x06000233 RID: 563 RVA: 0x00007EAC File Offset: 0x000060AC
		public float MaxDelayTime
		{
			get
			{
				return this._maxDelayTime;
			}
			set
			{
				this._maxDelayTime = Mathf.Clamp(value, 0.1f, 60f);
			}
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00007EC4 File Offset: 0x000060C4
		public void HandleException<TException>() where TException : Exception
		{
			this._exceptionsToHandle.Add(delegate(Exception exception)
			{
				if (!(exception is TException))
				{
					return null;
				}
				return exception;
			});
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00007EF0 File Offset: 0x000060F0
		public void HandleException<TException>(Func<TException, bool> condition) where TException : Exception
		{
			this._exceptionsToHandle.Add(delegate(Exception exception)
			{
				TException ex = exception as TException;
				if (ex == null || !condition(ex))
				{
					return null;
				}
				return exception;
			});
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00007F24 File Offset: 0x00006124
		public bool IsHandledException(Exception e)
		{
			if (this._exceptionsToHandle != null)
			{
				using (List<ExceptionPredicate>.Enumerator enumerator = this._exceptionsToHandle.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current(e) == e)
						{
							return true;
						}
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x040000E2 RID: 226
		private float _jitterMagnitude = 1f;

		// Token: 0x040000E3 RID: 227
		private float _delayScale = 1f;

		// Token: 0x040000E4 RID: 228
		private float _maxDelayTime = 8f;

		// Token: 0x040000E5 RID: 229
		private List<ExceptionPredicate> _exceptionsToHandle = new List<ExceptionPredicate>();
	}
}
