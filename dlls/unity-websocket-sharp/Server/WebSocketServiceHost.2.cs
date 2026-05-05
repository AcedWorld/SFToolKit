using System;

namespace UnityWebSocketSharp.Server
{
	// Token: 0x02000020 RID: 32
	internal class WebSocketServiceHost<TBehavior> : WebSocketServiceHost where TBehavior : WebSocketBehavior, new()
	{
		// Token: 0x06000246 RID: 582 RVA: 0x0000AFF6 File Offset: 0x000091F6
		internal WebSocketServiceHost(string path, Action<TBehavior> initializer, Logger log) : base(path, log)
		{
			this._creator = WebSocketServiceHost<TBehavior>.createSessionCreator(initializer);
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000247 RID: 583 RVA: 0x0000B00C File Offset: 0x0000920C
		public override Type BehaviorType
		{
			get
			{
				return typeof(TBehavior);
			}
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000B018 File Offset: 0x00009218
		private static Func<TBehavior> createSessionCreator(Action<TBehavior> initializer)
		{
			if (initializer == null)
			{
				return () => Activator.CreateInstance<TBehavior>();
			}
			return delegate()
			{
				TBehavior tbehavior = Activator.CreateInstance<TBehavior>();
				initializer(tbehavior);
				return tbehavior;
			};
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000B066 File Offset: 0x00009266
		protected override WebSocketBehavior CreateSession()
		{
			return this._creator();
		}

		// Token: 0x040000D6 RID: 214
		private Func<TBehavior> _creator;
	}
}
