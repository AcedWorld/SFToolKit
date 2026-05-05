using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Services.Lobbies.ErrorMitigation
{
	// Token: 0x02000063 RID: 99
	internal class RetryPolicyConfig
	{
		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000299 RID: 665 RVA: 0x0000958F File Offset: 0x0000778F
		// (set) Token: 0x0600029A RID: 666 RVA: 0x00009597 File Offset: 0x00007797
		public uint MaxRetries { get; set; } = 4U;

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x0600029B RID: 667 RVA: 0x000095A0 File Offset: 0x000077A0
		// (set) Token: 0x0600029C RID: 668 RVA: 0x000095A8 File Offset: 0x000077A8
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

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x0600029D RID: 669 RVA: 0x000095C0 File Offset: 0x000077C0
		// (set) Token: 0x0600029E RID: 670 RVA: 0x000095C8 File Offset: 0x000077C8
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

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x0600029F RID: 671 RVA: 0x000095E0 File Offset: 0x000077E0
		// (set) Token: 0x060002A0 RID: 672 RVA: 0x000095E8 File Offset: 0x000077E8
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

		// Token: 0x060002A1 RID: 673 RVA: 0x00009600 File Offset: 0x00007800
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

		// Token: 0x060002A2 RID: 674 RVA: 0x0000962C File Offset: 0x0000782C
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

		// Token: 0x060002A3 RID: 675 RVA: 0x00009660 File Offset: 0x00007860
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

		// Token: 0x0400012D RID: 301
		private float _jitterMagnitude = 1f;

		// Token: 0x0400012E RID: 302
		private float _delayScale = 1f;

		// Token: 0x0400012F RID: 303
		private float _maxDelayTime = 8f;

		// Token: 0x04000130 RID: 304
		private List<ExceptionPredicate> _exceptionsToHandle = new List<ExceptionPredicate>();
	}
}
