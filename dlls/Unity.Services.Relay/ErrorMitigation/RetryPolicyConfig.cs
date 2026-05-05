using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Services.Relay.ErrorMitigation
{
	// Token: 0x02000049 RID: 73
	internal class RetryPolicyConfig
	{
		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600014E RID: 334 RVA: 0x00004EF3 File Offset: 0x000030F3
		// (set) Token: 0x0600014F RID: 335 RVA: 0x00004EFB File Offset: 0x000030FB
		public uint MaxRetries { get; set; } = 4U;

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000150 RID: 336 RVA: 0x00004F04 File Offset: 0x00003104
		// (set) Token: 0x06000151 RID: 337 RVA: 0x00004F0C File Offset: 0x0000310C
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

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000152 RID: 338 RVA: 0x00004F24 File Offset: 0x00003124
		// (set) Token: 0x06000153 RID: 339 RVA: 0x00004F2C File Offset: 0x0000312C
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

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000154 RID: 340 RVA: 0x00004F44 File Offset: 0x00003144
		// (set) Token: 0x06000155 RID: 341 RVA: 0x00004F4C File Offset: 0x0000314C
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

		// Token: 0x06000156 RID: 342 RVA: 0x00004F64 File Offset: 0x00003164
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

		// Token: 0x06000157 RID: 343 RVA: 0x00004F90 File Offset: 0x00003190
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

		// Token: 0x06000158 RID: 344 RVA: 0x00004FC4 File Offset: 0x000031C4
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

		// Token: 0x040000A2 RID: 162
		private float _jitterMagnitude = 1f;

		// Token: 0x040000A3 RID: 163
		private float _delayScale = 1f;

		// Token: 0x040000A4 RID: 164
		private float _maxDelayTime = 8f;

		// Token: 0x040000A5 RID: 165
		private List<ExceptionPredicate> _exceptionsToHandle = new List<ExceptionPredicate>();
	}
}
