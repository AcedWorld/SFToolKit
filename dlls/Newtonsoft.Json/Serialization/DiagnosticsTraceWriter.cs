using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Serialization
{
	// Token: 0x02000077 RID: 119
	public class DiagnosticsTraceWriter : ITraceWriter
	{
		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600064E RID: 1614 RVA: 0x0001ADB4 File Offset: 0x00018FB4
		// (set) Token: 0x0600064F RID: 1615 RVA: 0x0001ADBC File Offset: 0x00018FBC
		public TraceLevel LevelFilter { get; set; }

		// Token: 0x06000650 RID: 1616 RVA: 0x0001ADC5 File Offset: 0x00018FC5
		private TraceEventType GetTraceEventType(TraceLevel level)
		{
			switch (level)
			{
			case TraceLevel.Error:
				return TraceEventType.Error;
			case TraceLevel.Warning:
				return TraceEventType.Warning;
			case TraceLevel.Info:
				return TraceEventType.Information;
			case TraceLevel.Verbose:
				return TraceEventType.Verbose;
			default:
				throw new ArgumentOutOfRangeException("level");
			}
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x0001ADF4 File Offset: 0x00018FF4
		[NullableContext(1)]
		public void Trace(TraceLevel level, string message, [Nullable(2)] Exception ex)
		{
			if (level == TraceLevel.Off)
			{
				return;
			}
			TraceEventCache eventCache = new TraceEventCache();
			TraceEventType traceEventType = this.GetTraceEventType(level);
			foreach (object obj in System.Diagnostics.Trace.Listeners)
			{
				TraceListener traceListener = (TraceListener)obj;
				if (!traceListener.IsThreadSafe)
				{
					TraceListener obj2 = traceListener;
					lock (obj2)
					{
						traceListener.TraceEvent(eventCache, "Newtonsoft.Json", traceEventType, 0, message);
						goto IL_6E;
					}
					goto IL_5F;
				}
				goto IL_5F;
				IL_6E:
				if (System.Diagnostics.Trace.AutoFlush)
				{
					traceListener.Flush();
					continue;
				}
				continue;
				IL_5F:
				traceListener.TraceEvent(eventCache, "Newtonsoft.Json", traceEventType, 0, message);
				goto IL_6E;
			}
		}
	}
}
