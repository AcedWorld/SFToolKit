using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x02000064 RID: 100
	public sealed class GraphNest<TGraph, TMacro> : IGraphNest, IAotStubbable where TGraph : class, IGraph, new() where TMacro : Macro<TGraph>
	{
		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x00007770 File Offset: 0x00005970
		// (set) Token: 0x060002F3 RID: 755 RVA: 0x00007778 File Offset: 0x00005978
		[DoNotSerialize]
		public IGraphNester nester { get; set; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x00007781 File Offset: 0x00005981
		// (set) Token: 0x060002F5 RID: 757 RVA: 0x00007789 File Offset: 0x00005989
		[Serialize]
		public GraphSource source
		{
			get
			{
				return this._source;
			}
			set
			{
				if (value == this.source)
				{
					return;
				}
				this.BeforeGraphChange();
				this._source = value;
				this.AfterGraphChange();
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x000077A8 File Offset: 0x000059A8
		// (set) Token: 0x060002F7 RID: 759 RVA: 0x000077B0 File Offset: 0x000059B0
		[Serialize]
		public TMacro macro
		{
			get
			{
				return this._macro;
			}
			set
			{
				if (value == this.macro)
				{
					return;
				}
				this.BeforeGraphChange();
				this._macro = value;
				this.AfterGraphChange();
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060002F8 RID: 760 RVA: 0x000077DE File Offset: 0x000059DE
		// (set) Token: 0x060002F9 RID: 761 RVA: 0x000077E6 File Offset: 0x000059E6
		[Serialize]
		public TGraph embed
		{
			get
			{
				return this._embed;
			}
			set
			{
				if (value == this.embed)
				{
					return;
				}
				this.BeforeGraphChange();
				this._embed = value;
				this.AfterGraphChange();
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060002FA RID: 762 RVA: 0x00007810 File Offset: 0x00005A10
		[DoNotSerialize]
		public TGraph graph
		{
			get
			{
				GraphSource source = this.source;
				if (source == GraphSource.Embed)
				{
					return this.embed;
				}
				if (source != GraphSource.Macro)
				{
					throw new UnexpectedEnumValueException<GraphSource>(this.source);
				}
				TMacro tmacro = this.macro;
				if (tmacro == null)
				{
					return default(TGraph);
				}
				return tmacro.graph;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060002FB RID: 763 RVA: 0x0000785E File Offset: 0x00005A5E
		// (set) Token: 0x060002FC RID: 764 RVA: 0x0000786B File Offset: 0x00005A6B
		IMacro IGraphNest.macro
		{
			get
			{
				return this.macro;
			}
			set
			{
				this.macro = (TMacro)((object)value);
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060002FD RID: 765 RVA: 0x00007879 File Offset: 0x00005A79
		// (set) Token: 0x060002FE RID: 766 RVA: 0x00007886 File Offset: 0x00005A86
		IGraph IGraphNest.embed
		{
			get
			{
				return this.embed;
			}
			set
			{
				this.embed = (TGraph)((object)value);
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060002FF RID: 767 RVA: 0x00007894 File Offset: 0x00005A94
		IGraph IGraphNest.graph
		{
			get
			{
				return this.graph;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000300 RID: 768 RVA: 0x000078A1 File Offset: 0x00005AA1
		Type IGraphNest.graphType
		{
			get
			{
				return typeof(TGraph);
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000301 RID: 769 RVA: 0x000078AD File Offset: 0x00005AAD
		Type IGraphNest.macroType
		{
			get
			{
				return typeof(TMacro);
			}
		}

		// Token: 0x06000302 RID: 770 RVA: 0x000078BC File Offset: 0x00005ABC
		public void SwitchToEmbed(TGraph embed)
		{
			if (this.source == GraphSource.Embed && this.embed == embed)
			{
				return;
			}
			this.BeforeGraphChange();
			this._source = GraphSource.Embed;
			this._embed = embed;
			this._macro = default(TMacro);
			this.AfterGraphChange();
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0000790C File Offset: 0x00005B0C
		public void SwitchToMacro(TMacro macro)
		{
			if (this.source == GraphSource.Macro && this.macro == macro)
			{
				return;
			}
			this.BeforeGraphChange();
			this._source = GraphSource.Macro;
			this._embed = default(TGraph);
			this._macro = macro;
			this.AfterGraphChange();
		}

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x06000304 RID: 772 RVA: 0x00007964 File Offset: 0x00005B64
		// (remove) Token: 0x06000305 RID: 773 RVA: 0x0000799C File Offset: 0x00005B9C
		public event Action beforeGraphChange;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000306 RID: 774 RVA: 0x000079D4 File Offset: 0x00005BD4
		// (remove) Token: 0x06000307 RID: 775 RVA: 0x00007A0C File Offset: 0x00005C0C
		public event Action afterGraphChange;

		// Token: 0x06000308 RID: 776 RVA: 0x00007A41 File Offset: 0x00005C41
		private void BeforeGraphChange()
		{
			if (this.graph != null)
			{
				this.nester.UninstantiateNest();
			}
			Action action = this.beforeGraphChange;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x06000309 RID: 777 RVA: 0x00007A6B File Offset: 0x00005C6B
		private void AfterGraphChange()
		{
			Action action = this.afterGraphChange;
			if (action != null)
			{
				action();
			}
			if (this.graph != null)
			{
				this.nester.InstantiateNest();
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600030A RID: 778 RVA: 0x00007A96 File Offset: 0x00005C96
		public IEnumerable<ISerializationDependency> deserializationDependencies
		{
			get
			{
				if (this.macro != null)
				{
					yield return this.macro;
				}
				yield break;
			}
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00007AA6 File Offset: 0x00005CA6
		public IEnumerable<object> GetAotStubs(HashSet<object> visited)
		{
			IEnumerable[] array = new IEnumerable[1];
			int num = 0;
			TGraph tgraph = this.graph;
			array[num] = ((tgraph != null) ? tgraph.GetAotStubs(visited) : null);
			return LinqUtility.Concat<object>(array);
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600030C RID: 780 RVA: 0x00007ACE File Offset: 0x00005CCE
		[DoNotSerialize]
		public bool hasBackgroundEmbed
		{
			get
			{
				return this.source == GraphSource.Macro && this.embed != null;
			}
		}

		// Token: 0x040000D3 RID: 211
		[DoNotSerialize]
		private GraphSource _source = GraphSource.Macro;

		// Token: 0x040000D4 RID: 212
		[DoNotSerialize]
		private TMacro _macro;

		// Token: 0x040000D5 RID: 213
		[DoNotSerialize]
		private TGraph _embed;
	}
}
