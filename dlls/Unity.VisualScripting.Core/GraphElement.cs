using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unity.VisualScripting
{
	// Token: 0x02000061 RID: 97
	public abstract class GraphElement<TGraph> : IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable where TGraph : class, IGraph
	{
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060002BE RID: 702 RVA: 0x00006D47 File Offset: 0x00004F47
		// (set) Token: 0x060002BF RID: 703 RVA: 0x00006D4F File Offset: 0x00004F4F
		[Serialize]
		public Guid guid { get; set; } = Guid.NewGuid();

		// Token: 0x060002C0 RID: 704 RVA: 0x00006D58 File Offset: 0x00004F58
		public virtual void Instantiate(GraphReference instance)
		{
			IGraphElementWithData graphElementWithData = this as IGraphElementWithData;
			if (graphElementWithData != null)
			{
				instance.data.CreateElementData(graphElementWithData);
			}
			IGraphNesterElement graphNesterElement = this as IGraphNesterElement;
			if (graphNesterElement != null && graphNesterElement.nest.graph != null)
			{
				GraphInstances.Instantiate(instance.ChildReference(graphNesterElement, true, null));
			}
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00006DAC File Offset: 0x00004FAC
		public virtual void Uninstantiate(GraphReference instance)
		{
			IGraphNesterElement graphNesterElement = this as IGraphNesterElement;
			if (graphNesterElement != null && graphNesterElement.nest.graph != null)
			{
				GraphInstances.Uninstantiate(instance.ChildReference(graphNesterElement, true, null));
			}
			IGraphElementWithData graphElementWithData = this as IGraphElementWithData;
			if (graphElementWithData != null)
			{
				instance.data.FreeElementData(graphElementWithData);
			}
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00006DFC File Offset: 0x00004FFC
		public virtual void BeforeAdd()
		{
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x00006E00 File Offset: 0x00005000
		public virtual void AfterAdd()
		{
			HashSet<GraphReference> hashSet = GraphInstances.OfPooled(this.graph);
			foreach (GraphReference instance in hashSet)
			{
				this.Instantiate(instance);
			}
			hashSet.Free<GraphReference>();
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00006E68 File Offset: 0x00005068
		public virtual void BeforeRemove()
		{
			HashSet<GraphReference> hashSet = GraphInstances.OfPooled(this.graph);
			foreach (GraphReference instance in hashSet)
			{
				this.Uninstantiate(instance);
			}
			hashSet.Free<GraphReference>();
			this.Dispose();
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00006ED4 File Offset: 0x000050D4
		public virtual void AfterRemove()
		{
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x00006ED6 File Offset: 0x000050D6
		public virtual void Dispose()
		{
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x00006ED8 File Offset: 0x000050D8
		protected void InstantiateNest()
		{
			IGraphNesterElement parentElement = (IGraphNesterElement)this;
			if (this.graph == null)
			{
				return;
			}
			HashSet<GraphReference> hashSet = GraphInstances.OfPooled(this.graph);
			foreach (GraphReference graphReference in hashSet)
			{
				GraphInstances.Instantiate(graphReference.ChildReference(parentElement, true, null));
			}
			hashSet.Free<GraphReference>();
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x00006F60 File Offset: 0x00005160
		protected void UninstantiateNest()
		{
			HashSet<GraphReference> hashSet = GraphInstances.ChildrenOfPooled((IGraphNesterElement)this);
			foreach (GraphReference instance in hashSet)
			{
				GraphInstances.Uninstantiate(instance);
			}
			hashSet.Free<GraphReference>();
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060002C9 RID: 713 RVA: 0x00006FC0 File Offset: 0x000051C0
		[DoNotSerialize]
		public virtual int dependencyOrder
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00006FC3 File Offset: 0x000051C3
		public virtual bool HandleDependencies()
		{
			return true;
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060002CB RID: 715 RVA: 0x00006FC6 File Offset: 0x000051C6
		// (set) Token: 0x060002CC RID: 716 RVA: 0x00006FCE File Offset: 0x000051CE
		[DoNotSerialize]
		public TGraph graph { get; set; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060002CD RID: 717 RVA: 0x00006FD7 File Offset: 0x000051D7
		// (set) Token: 0x060002CE RID: 718 RVA: 0x00006FE4 File Offset: 0x000051E4
		[DoNotSerialize]
		IGraph IGraphElement.graph
		{
			get
			{
				return this.graph;
			}
			set
			{
				Ensure.That("value").IsOfType<TGraph>(value);
				this.graph = (TGraph)((object)value);
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060002CF RID: 719 RVA: 0x00007002 File Offset: 0x00005202
		[DoNotSerialize]
		IGraph IGraphItem.graph
		{
			get
			{
				return this.graph;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060002D0 RID: 720 RVA: 0x0000700F File Offset: 0x0000520F
		public virtual IEnumerable<ISerializationDependency> deserializationDependencies
		{
			get
			{
				return Enumerable.Empty<ISerializationDependency>();
			}
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x00007016 File Offset: 0x00005216
		public virtual IEnumerable<object> GetAotStubs(HashSet<object> visited)
		{
			return Enumerable.Empty<object>();
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000701D File Offset: 0x0000521D
		public virtual void Prewarm()
		{
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000701F File Offset: 0x0000521F
		protected void CopyFrom(GraphElement<TGraph> source)
		{
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x00007024 File Offset: 0x00005224
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(base.GetType().Name);
			stringBuilder.Append("#");
			stringBuilder.Append(this.guid.ToString().Substring(0, 5));
			stringBuilder.Append("...");
			return stringBuilder.ToString();
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x00007087 File Offset: 0x00005287
		public virtual AnalyticsIdentifier GetAnalyticsIdentifier()
		{
			throw new NotImplementedException();
		}
	}
}
