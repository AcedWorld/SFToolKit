using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000183 RID: 387
	public struct EventDispatcherGate : IDisposable, IEquatable<EventDispatcherGate>
	{
		// Token: 0x06000C3F RID: 3135 RVA: 0x00030FBC File Offset: 0x0002F1BC
		public EventDispatcherGate(EventDispatcher d)
		{
			bool flag = d == null;
			if (flag)
			{
				throw new ArgumentNullException("d");
			}
			this.m_Dispatcher = d;
			this.m_Dispatcher.CloseGate();
		}

		// Token: 0x06000C40 RID: 3136 RVA: 0x00030FF1 File Offset: 0x0002F1F1
		public void Dispose()
		{
			this.m_Dispatcher.OpenGate();
		}

		// Token: 0x06000C41 RID: 3137 RVA: 0x00031000 File Offset: 0x0002F200
		public bool Equals(EventDispatcherGate other)
		{
			return object.Equals(this.m_Dispatcher, other.m_Dispatcher);
		}

		// Token: 0x06000C42 RID: 3138 RVA: 0x00031024 File Offset: 0x0002F224
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is EventDispatcherGate && this.Equals((EventDispatcherGate)obj);
		}

		// Token: 0x06000C43 RID: 3139 RVA: 0x0003105C File Offset: 0x0002F25C
		public override int GetHashCode()
		{
			return (this.m_Dispatcher != null) ? this.m_Dispatcher.GetHashCode() : 0;
		}

		// Token: 0x06000C44 RID: 3140 RVA: 0x00031084 File Offset: 0x0002F284
		public static bool operator ==(EventDispatcherGate left, EventDispatcherGate right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000C45 RID: 3141 RVA: 0x000310A0 File Offset: 0x0002F2A0
		public static bool operator !=(EventDispatcherGate left, EventDispatcherGate right)
		{
			return !left.Equals(right);
		}

		// Token: 0x040005D8 RID: 1496
		private readonly EventDispatcher m_Dispatcher;
	}
}
