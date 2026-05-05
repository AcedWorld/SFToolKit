using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200015E RID: 350
	[SpecialUnit]
	public abstract class NesterUnit<TGraph, TMacro> : Unit, INesterUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable, IGraphNesterElement, IGraphParentElement, IGraphParent, IGraphNester where TGraph : class, IGraph, new() where TMacro : Macro<TGraph>
	{
		// Token: 0x06000913 RID: 2323 RVA: 0x0001066F File Offset: 0x0000E86F
		protected NesterUnit()
		{
			this.nest.nester = this;
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x0001068E File Offset: 0x0000E88E
		protected NesterUnit(TMacro macro)
		{
			this.nest.nester = this;
			this.nest.macro = macro;
			this.nest.source = GraphSource.Macro;
		}

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x06000915 RID: 2325 RVA: 0x000106C5 File Offset: 0x0000E8C5
		public override bool canDefine
		{
			get
			{
				return this.nest.graph != null;
			}
		}

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x06000916 RID: 2326 RVA: 0x000106DA File Offset: 0x0000E8DA
		// (set) Token: 0x06000917 RID: 2327 RVA: 0x000106E2 File Offset: 0x0000E8E2
		[Serialize]
		public GraphNest<TGraph, TMacro> nest { get; private set; } = new GraphNest<TGraph, TMacro>();

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x06000918 RID: 2328 RVA: 0x000106EB File Offset: 0x0000E8EB
		[DoNotSerialize]
		IGraphNest IGraphNester.nest
		{
			get
			{
				return this.nest;
			}
		}

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x06000919 RID: 2329 RVA: 0x000106F3 File Offset: 0x0000E8F3
		[DoNotSerialize]
		IGraph IGraphParent.childGraph
		{
			get
			{
				return this.nest.graph;
			}
		}

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x0600091A RID: 2330 RVA: 0x00010705 File Offset: 0x0000E905
		[DoNotSerialize]
		bool IGraphParent.isSerializationRoot
		{
			get
			{
				return this.nest.source == GraphSource.Macro;
			}
		}

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x0600091B RID: 2331 RVA: 0x00010715 File Offset: 0x0000E915
		[DoNotSerialize]
		Object IGraphParent.serializedObject
		{
			get
			{
				return this.nest.macro;
			}
		}

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x0600091C RID: 2332 RVA: 0x00010727 File Offset: 0x0000E927
		[DoNotSerialize]
		public override IEnumerable<ISerializationDependency> deserializationDependencies
		{
			get
			{
				return this.nest.deserializationDependencies;
			}
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x00010734 File Offset: 0x0000E934
		public override IEnumerable<object> GetAotStubs(HashSet<object> visited)
		{
			return LinqUtility.Concat<object>(new IEnumerable[]
			{
				base.GetAotStubs(visited),
				this.nest.GetAotStubs(visited)
			});
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x0001075A File Offset: 0x0000E95A
		protected void CopyFrom(NesterUnit<TGraph, TMacro> source)
		{
			base.CopyFrom(source);
			this.nest = source.nest;
		}

		// Token: 0x0600091F RID: 2335
		public abstract TGraph DefaultGraph();

		// Token: 0x06000920 RID: 2336 RVA: 0x0001076F File Offset: 0x0000E96F
		IGraph IGraphParent.DefaultGraph()
		{
			return this.DefaultGraph();
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x0001077C File Offset: 0x0000E97C
		void IGraphNester.InstantiateNest()
		{
			base.InstantiateNest();
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x00010784 File Offset: 0x0000E984
		void IGraphNester.UninstantiateNest()
		{
			base.UninstantiateNest();
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x0001078C File Offset: 0x0000E98C
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
