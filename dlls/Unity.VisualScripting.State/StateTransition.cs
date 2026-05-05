using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000019 RID: 25
	public abstract class StateTransition : GraphElement<StateGraph>, IStateTransition, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable, IConnection<IState, IState>
	{
		// Token: 0x06000094 RID: 148 RVA: 0x00003107 File Offset: 0x00001307
		protected StateTransition()
		{
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00003110 File Offset: 0x00001310
		protected StateTransition(IState source, IState destination)
		{
			Ensure.That("source").IsNotNull<IState>(source);
			Ensure.That("destination").IsNotNull<IState>(destination);
			if (source.graph != destination.graph)
			{
				throw new NotSupportedException("Cannot create transitions across state graphs.");
			}
			this.source = source;
			this.destination = destination;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000316A File Offset: 0x0000136A
		public IGraphElementDebugData CreateDebugData()
		{
			return new StateTransition.DebugData();
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00003171 File Offset: 0x00001371
		public override int dependencyOrder
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00003174 File Offset: 0x00001374
		// (set) Token: 0x06000099 RID: 153 RVA: 0x0000317C File Offset: 0x0000137C
		[Serialize]
		public IState source { get; internal set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600009A RID: 154 RVA: 0x00003185 File Offset: 0x00001385
		// (set) Token: 0x0600009B RID: 155 RVA: 0x0000318D File Offset: 0x0000138D
		[Serialize]
		public IState destination { get; internal set; }

		// Token: 0x0600009C RID: 156 RVA: 0x00003198 File Offset: 0x00001398
		public override void Instantiate(GraphReference instance)
		{
			base.Instantiate(instance);
			IGraphEventListener graphEventListener = this as IGraphEventListener;
			if (graphEventListener != null && instance.GetElementData<State.Data>(this.source).isActive)
			{
				graphEventListener.StartListening(instance);
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000031D0 File Offset: 0x000013D0
		public override void Uninstantiate(GraphReference instance)
		{
			IGraphEventListener graphEventListener = this as IGraphEventListener;
			if (graphEventListener != null)
			{
				graphEventListener.StopListening(instance);
			}
			base.Uninstantiate(instance);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000031F8 File Offset: 0x000013F8
		public void Branch(Flow flow)
		{
			if (flow.enableDebug)
			{
				StateTransition.DebugData elementDebugData = flow.stack.GetElementDebugData<StateTransition.DebugData>(this);
				elementDebugData.lastBranchFrame = EditorTimeBinding.frame;
				elementDebugData.lastBranchTime = EditorTimeBinding.time;
			}
			try
			{
				this.source.OnExit(flow, StateExitReason.Branch);
			}
			catch (Exception ex)
			{
				this.source.HandleException(flow.stack, ex);
				throw;
			}
			this.source.OnBranchTo(flow, this.destination);
			try
			{
				this.destination.OnEnter(flow, StateEnterReason.Branch);
			}
			catch (Exception ex2)
			{
				this.destination.HandleException(flow.stack, ex2);
				throw;
			}
		}

		// Token: 0x0600009F RID: 159
		public abstract void OnEnter(Flow flow);

		// Token: 0x060000A0 RID: 160
		public abstract void OnExit(Flow flow);

		// Token: 0x060000A1 RID: 161 RVA: 0x000032A8 File Offset: 0x000014A8
		public override AnalyticsIdentifier GetAnalyticsIdentifier()
		{
			return null;
		}

		// Token: 0x02000028 RID: 40
		public class DebugData : IStateTransitionDebugData, IGraphElementDebugData
		{
			// Token: 0x1700003A RID: 58
			// (get) Token: 0x060000DC RID: 220 RVA: 0x00003683 File Offset: 0x00001883
			// (set) Token: 0x060000DD RID: 221 RVA: 0x0000368B File Offset: 0x0000188B
			public Exception runtimeException { get; set; }

			// Token: 0x1700003B RID: 59
			// (get) Token: 0x060000DE RID: 222 RVA: 0x00003694 File Offset: 0x00001894
			// (set) Token: 0x060000DF RID: 223 RVA: 0x0000369C File Offset: 0x0000189C
			public int lastBranchFrame { get; set; }

			// Token: 0x1700003C RID: 60
			// (get) Token: 0x060000E0 RID: 224 RVA: 0x000036A5 File Offset: 0x000018A5
			// (set) Token: 0x060000E1 RID: 225 RVA: 0x000036AD File Offset: 0x000018AD
			public float lastBranchTime { get; set; }
		}
	}
}
