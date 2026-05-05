using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200005D RID: 93
	public abstract class GameObjectEventUnit<TArgs> : EventUnit<TArgs>, IGameObjectEventUnit, IEventUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable, IGraphEventListener
	{
		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000379 RID: 889 RVA: 0x00008D81 File Offset: 0x00006F81
		protected sealed override bool register
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x0600037A RID: 890
		public abstract Type MessageListenerType { get; }

		// Token: 0x0600037B RID: 891 RVA: 0x00008D84 File Offset: 0x00006F84
		public override IGraphElementData CreateData()
		{
			return new GameObjectEventUnit<TArgs>.Data();
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x0600037C RID: 892 RVA: 0x00008D8B File Offset: 0x00006F8B
		// (set) Token: 0x0600037D RID: 893 RVA: 0x00008D93 File Offset: 0x00006F93
		[DoNotSerialize]
		[NullMeansSelf]
		[PortLabel("Target")]
		[PortLabelHidden]
		public ValueInput target { get; private set; }

		// Token: 0x0600037E RID: 894 RVA: 0x00008D9C File Offset: 0x00006F9C
		protected override void Definition()
		{
			base.Definition();
			this.target = base.ValueInput<GameObject>("target", null).NullMeansSelf();
		}

		// Token: 0x0600037F RID: 895 RVA: 0x00008DBC File Offset: 0x00006FBC
		public override EventHook GetHook(GraphReference reference)
		{
			if (!reference.hasData)
			{
				return this.hookName;
			}
			GameObjectEventUnit<TArgs>.Data elementData = reference.GetElementData<GameObjectEventUnit<TArgs>.Data>(this);
			return new EventHook(this.hookName, elementData.target, null);
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000380 RID: 896 RVA: 0x00008DF7 File Offset: 0x00006FF7
		protected virtual string hookName
		{
			get
			{
				throw new InvalidImplementationException(string.Format("Missing event hook for '{0}'.", this));
			}
		}

		// Token: 0x06000381 RID: 897 RVA: 0x00008E0C File Offset: 0x0000700C
		private void UpdateTarget(GraphStack stack)
		{
			GameObjectEventUnit<TArgs>.Data elementData = stack.GetElementData<GameObjectEventUnit<TArgs>.Data>(this);
			bool isListening = elementData.isListening;
			GameObject gameObject = Flow.FetchValue<GameObject>(this.target, stack.ToReference());
			if (gameObject != elementData.target)
			{
				if (isListening)
				{
					this.StopListening(stack);
				}
				elementData.target = gameObject;
				if (isListening)
				{
					this.StartListening(stack, false);
				}
			}
		}

		// Token: 0x06000382 RID: 898 RVA: 0x00008E64 File Offset: 0x00007064
		protected void StartListening(GraphStack stack, bool updateTarget)
		{
			if (updateTarget)
			{
				this.UpdateTarget(stack);
			}
			GameObjectEventUnit<TArgs>.Data elementData = stack.GetElementData<GameObjectEventUnit<TArgs>.Data>(this);
			if (elementData.target == null)
			{
				return;
			}
			if (UnityThread.allowsAPI && this.MessageListenerType != null)
			{
				MessageListener.AddTo(this.MessageListenerType, elementData.target);
			}
			base.StartListening(stack);
		}

		// Token: 0x06000383 RID: 899 RVA: 0x00008EBF File Offset: 0x000070BF
		public override void StartListening(GraphStack stack)
		{
			this.StartListening(stack, true);
		}

		// Token: 0x06000385 RID: 901 RVA: 0x00008ED1 File Offset: 0x000070D1
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}

		// Token: 0x020001B2 RID: 434
		public new class Data : EventUnit<TArgs>.Data
		{
			// Token: 0x040003A2 RID: 930
			public GameObject target;
		}
	}
}
