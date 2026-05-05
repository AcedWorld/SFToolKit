using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Services.Qos.V2.ErrorMitigation
{
	// Token: 0x02000043 RID: 67
	internal class RetryPolicyConfig
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000134 RID: 308 RVA: 0x00005887 File Offset: 0x00003A87
		// (set) Token: 0x06000135 RID: 309 RVA: 0x0000588F File Offset: 0x00003A8F
		public uint MaxRetries { get; set; } = 4U;

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000136 RID: 310 RVA: 0x00005898 File Offset: 0x00003A98
		// (set) Token: 0x06000137 RID: 311 RVA: 0x000058A0 File Offset: 0x00003AA0
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

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000138 RID: 312 RVA: 0x000058B8 File Offset: 0x00003AB8
		// (set) Token: 0x06000139 RID: 313 RVA: 0x000058C0 File Offset: 0x00003AC0
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

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600013A RID: 314 RVA: 0x000058D8 File Offset: 0x00003AD8
		// (set) Token: 0x0600013B RID: 315 RVA: 0x000058E0 File Offset: 0x00003AE0
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

		// Token: 0x0600013C RID: 316 RVA: 0x000058F8 File Offset: 0x00003AF8
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

		// Token: 0x0600013D RID: 317 RVA: 0x00005924 File Offset: 0x00003B24
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

		// Token: 0x0600013E RID: 318 RVA: 0x00005958 File Offset: 0x00003B58
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

		// Token: 0x0400009E RID: 158
		private float _jitterMagnitude = 1f;

		// Token: 0x0400009F RID: 159
		private float _delayScale = 1f;

		// Token: 0x040000A0 RID: 160
		private float _maxDelayTime = 8f;

		// Token: 0x040000A1 RID: 161
		private List<ExceptionPredicate> _exceptionsToHandle = new List<ExceptionPredicate>();
	}
}
