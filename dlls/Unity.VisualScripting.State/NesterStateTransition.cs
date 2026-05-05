using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200000E RID: 14
	public abstract class NesterStateTransition<TGraph, TMacro> : StateTransition, INesterStateTransition, IStateTransition, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable, IConnection<IState, IState>, IGraphNesterElement, IGraphParentElement, IGraphParent, IGraphNester where TGraph : class, IGraph, new() where TMacro : Macro<TGraph>
	{
		// Token: 0x06000045 RID: 69 RVA: 0x000026A1 File Offset: 0x000008A1
		protected NesterStateTransition()
		{
			this.nest.nester = this;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000026C0 File Offset: 0x000008C0
		protected NesterStateTransition(IState source, IState destination) : base(source, destination)
		{
			this.nest.nester = this;
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000047 RID: 71 RVA: 0x000026E1 File Offset: 0x000008E1
		// (set) Token: 0x06000048 RID: 72 RVA: 0x000026E9 File Offset: 0x000008E9
		[Serialize]
		public GraphNest<TGraph, TMacro> nest { get; private set; } = new GraphNest<TGraph, TMacro>();

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000049 RID: 73 RVA: 0x000026F2 File Offset: 0x000008F2
		[DoNotSerialize]
		IGraphNest IGraphNester.nest
		{
			get
			{
				return this.nest;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600004A RID: 74 RVA: 0x000026FA File Offset: 0x000008FA
		[DoNotSerialize]
		IGraph IGraphParent.childGraph
		{
			get
			{
				return this.nest.graph;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600004B RID: 75 RVA: 0x0000270C File Offset: 0x0000090C
		[DoNotSerialize]
		bool IGraphParent.isSerializationRoot
		{
			get
			{
				return this.nest.source == GraphSource.Macro;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600004C RID: 76 RVA: 0x0000271C File Offset: 0x0000091C
		[DoNotSerialize]
		Object IGraphParent.serializedObject
		{
			get
			{
				return this.nest.macro;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600004D RID: 77 RVA: 0x0000272E File Offset: 0x0000092E
		[DoNotSerialize]
		public override IEnumerable<ISerializationDependency> deserializationDependencies
		{
			get
			{
				return this.nest.deserializationDependencies;
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000273B File Offset: 0x0000093B
		public override IEnumerable<object> GetAotStubs(HashSet<object> visited)
		{
			return LinqUtility.Concat<object>(new IEnumerable[]
			{
				base.GetAotStubs(visited),
				this.nest.GetAotStubs(visited)
			});
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002761 File Offset: 0x00000961
		protected void CopyFrom(NesterStateTransition<TGraph, TMacro> source)
		{
			base.CopyFrom(source);
			this.nest = source.nest;
		}

		// Token: 0x06000050 RID: 80
		public abstract TGraph DefaultGraph();

		// Token: 0x06000051 RID: 81 RVA: 0x00002776 File Offset: 0x00000976
		IGraph IGraphParent.DefaultGraph()
		{
			return this.DefaultGraph();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002783 File Offset: 0x00000983
		void IGraphNester.InstantiateNest()
		{
			base.InstantiateNest();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000278B File Offset: 0x0000098B
		void IGraphNester.UninstantiateNest()
		{
			base.UninstantiateNest();
		}
	}
}
