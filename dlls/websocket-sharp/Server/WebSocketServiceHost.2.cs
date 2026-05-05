using System;

namespace WebSocketSharp.Server
{
	// Token: 0x0200004E RID: 78
	internal class WebSocketServiceHost<TBehavior> : WebSocketServiceHost where TBehavior : WebSocketBehavior, new()
	{
		// Token: 0x06000551 RID: 1361 RVA: 0x0001E298 File Offset: 0x0001C498
		internal WebSocketServiceHost(string path, Action<TBehavior> initializer, Logger log) : base(path, log)
		{
			this._creator = WebSocketServiceHost<TBehavior>.createSessionCreator(initializer);
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000552 RID: 1362 RVA: 0x0001E2B0 File Offset: 0x0001C4B0
		public override Type BehaviorType
		{
			get
			{
				return typeof(TBehavior);
			}
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x0001E2CC File Offset: 0x0001C4CC
		private static Func<TBehavior> createSessionCreator(Action<TBehavior> initializer)
		{
			bool flag = initializer == null;
			Func<TBehavior> result;
			if (flag)
			{
				result = (() => Activator.CreateInstance<TBehavior>());
			}
			else
			{
				result = delegate()
				{
					TBehavior tbehavior = Activator.CreateInstance<TBehavior>();
					initializer(tbehavior);
					return tbehavior;
				};
			}
			return result;
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x0001E328 File Offset: 0x0001C528
		protected override WebSocketBehavior CreateSession()
		{
			return this._creator();
		}

		// Token: 0x0400025B RID: 603
		private Func<TBehavior> _creator;
	}
}
