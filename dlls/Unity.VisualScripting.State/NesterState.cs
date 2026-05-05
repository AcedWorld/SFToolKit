using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200000D RID: 13
	public abstract class NesterState<TGraph, TMacro> : State, INesterState, IState, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable, IGraphElementWithData, IGraphNesterElement, IGraphParentElement, IGraphParent, IGraphNester where TGraph : class, IGraph, new() where TMacro : Macro<TGraph>
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00002591 File Offset: 0x00000791
		protected NesterState()
		{
			this.nest.nester = this;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000025B0 File Offset: 0x000007B0
		protected NesterState(TMacro macro)
		{
			this.nest.nester = this;
			this.nest.macro = macro;
			this.nest.source = GraphSource.Macro;
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000037 RID: 55 RVA: 0x000025E7 File Offset: 0x000007E7
		// (set) Token: 0x06000038 RID: 56 RVA: 0x000025EF File Offset: 0x000007EF
		[Serialize]
		public GraphNest<TGraph, TMacro> nest { get; private set; } = new GraphNest<TGraph, TMacro>();

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000039 RID: 57 RVA: 0x000025F8 File Offset: 0x000007F8
		[DoNotSerialize]
		IGraphNest IGraphNester.nest
		{
			get
			{
				return this.nest;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00002600 File Offset: 0x00000800
		[DoNotSerialize]
		IGraph IGraphParent.childGraph
		{
			get
			{
				return this.nest.graph;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002612 File Offset: 0x00000812
		[DoNotSerialize]
		bool IGraphParent.isSerializationRoot
		{
			get
			{
				return this.nest.source == GraphSource.Macro;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002622 File Offset: 0x00000822
		[DoNotSerialize]
		Object IGraphParent.serializedObject
		{
			get
			{
				return this.nest.macro;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002634 File Offset: 0x00000834
		[DoNotSerialize]
		public override IEnumerable<ISerializationDependency> deserializationDependencies
		{
			get
			{
				return this.nest.deserializationDependencies;
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002641 File Offset: 0x00000841
		protected void CopyFrom(NesterState<TGraph, TMacro> source)
		{
			base.CopyFrom(source);
			this.nest = source.nest;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002656 File Offset: 0x00000856
		public override IEnumerable<object> GetAotStubs(HashSet<object> visited)
		{
			return LinqUtility.Concat<object>(new IEnumerable[]
			{
				base.GetAotStubs(visited),
				this.nest.GetAotStubs(visited)
			});
		}

		// Token: 0x06000040 RID: 64
		public abstract TGraph DefaultGraph();

		// Token: 0x06000041 RID: 65 RVA: 0x0000267C File Offset: 0x0000087C
		IGraph IGraphParent.DefaultGraph()
		{
			return this.DefaultGraph();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002689 File Offset: 0x00000889
		void IGraphNester.InstantiateNest()
		{
			base.InstantiateNest();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002691 File Offset: 0x00000891
		void IGraphNester.UninstantiateNest()
		{
			base.UninstantiateNest();
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002699 File Offset: 0x00000899
		StateGraph IState.get_graph()
		{
			return base.graph;
		}
	}
}
