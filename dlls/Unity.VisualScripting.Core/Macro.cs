using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000BB RID: 187
	[DisableAnnotation]
	public abstract class Macro<TGraph> : MacroScriptableObject, IMacro, IGraphRoot, IGraphParent, ISerializationDependency, ISerializationCallbackReceiver, IAotStubbable where TGraph : class, IGraph, new()
	{
		// Token: 0x17000100 RID: 256
		// (get) Token: 0x0600049F RID: 1183 RVA: 0x0000A4E5 File Offset: 0x000086E5
		// (set) Token: 0x060004A0 RID: 1184 RVA: 0x0000A4ED File Offset: 0x000086ED
		[DoNotSerialize]
		public TGraph graph
		{
			get
			{
				return this._graph;
			}
			set
			{
				if (value == null)
				{
					throw new InvalidOperationException("Macros must have a graph.");
				}
				if (value == this.graph)
				{
					return;
				}
				this._graph = value;
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x0000A51D File Offset: 0x0000871D
		// (set) Token: 0x060004A2 RID: 1186 RVA: 0x0000A52A File Offset: 0x0000872A
		[DoNotSerialize]
		IGraph IMacro.graph
		{
			get
			{
				return this.graph;
			}
			set
			{
				this.graph = (TGraph)((object)value);
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x0000A538 File Offset: 0x00008738
		[DoNotSerialize]
		IGraph IGraphParent.childGraph
		{
			get
			{
				return this.graph;
			}
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x0000A545 File Offset: 0x00008745
		public IEnumerable<object> GetAotStubs(HashSet<object> visited)
		{
			return this.graph.GetAotStubs(visited);
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x0000A558 File Offset: 0x00008758
		[DoNotSerialize]
		bool IGraphParent.isSerializationRoot
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060004A6 RID: 1190 RVA: 0x0000A55B File Offset: 0x0000875B
		[DoNotSerialize]
		Object IGraphParent.serializedObject
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060004A7 RID: 1191 RVA: 0x0000A55E File Offset: 0x0000875E
		[DoNotSerialize]
		protected GraphReference reference
		{
			get
			{
				if (!(this._reference == null))
				{
					return this._reference;
				}
				return GraphReference.New(this, false);
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060004A8 RID: 1192 RVA: 0x0000A57C File Offset: 0x0000877C
		// (set) Token: 0x060004A9 RID: 1193 RVA: 0x0000A57F File Offset: 0x0000877F
		public bool isDescriptionValid
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x0000A581 File Offset: 0x00008781
		protected override void OnBeforeDeserialize()
		{
			base.OnBeforeDeserialize();
			Serialization.NotifyDependencyDeserializing(this);
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x0000A58F File Offset: 0x0000878F
		protected override void OnAfterDeserialize()
		{
			base.OnAfterDeserialize();
			Serialization.NotifyDependencyDeserialized(this);
		}

		// Token: 0x060004AC RID: 1196
		public abstract TGraph DefaultGraph();

		// Token: 0x060004AD RID: 1197 RVA: 0x0000A59D File Offset: 0x0000879D
		IGraph IGraphParent.DefaultGraph()
		{
			return this.DefaultGraph();
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x0000A5AA File Offset: 0x000087AA
		protected virtual void OnEnable()
		{
			Serialization.NotifyDependencyAvailable(this);
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x0000A5B2 File Offset: 0x000087B2
		protected virtual void OnDisable()
		{
			Serialization.NotifyDependencyUnavailable(this);
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x0000A5BA File Offset: 0x000087BA
		public GraphPointer GetReference()
		{
			return this.reference;
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060004B1 RID: 1201 RVA: 0x0000A5C2 File Offset: 0x000087C2
		// (set) Token: 0x060004B2 RID: 1202 RVA: 0x0000A5CA File Offset: 0x000087CA
		bool ISerializationDependency.IsDeserialized { get; set; }

		// Token: 0x04000100 RID: 256
		[SerializeAs("graph")]
		private TGraph _graph = Activator.CreateInstance<TGraph>();

		// Token: 0x04000101 RID: 257
		[DoNotSerialize]
		private GraphReference _reference;
	}
}
