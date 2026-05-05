using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000B9 RID: 185
	public abstract class Machine<TGraph, TMacro> : LudiqBehaviour, IMachine, IGraphRoot, IGraphParent, IGraphNester, IAotStubbable where TGraph : class, IGraph, new() where TMacro : Macro<TGraph>
	{
		// Token: 0x0600047D RID: 1149 RVA: 0x0000A1F1 File Offset: 0x000083F1
		protected Machine()
		{
			this.nest.nester = this;
			this.nest.source = GraphSource.Macro;
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600047E RID: 1150 RVA: 0x0000A21C File Offset: 0x0000841C
		// (set) Token: 0x0600047F RID: 1151 RVA: 0x0000A224 File Offset: 0x00008424
		[Serialize]
		public GraphNest<TGraph, TMacro> nest { get; private set; } = new GraphNest<TGraph, TMacro>();

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000480 RID: 1152 RVA: 0x0000A22D File Offset: 0x0000842D
		[DoNotSerialize]
		IGraphNest IGraphNester.nest
		{
			get
			{
				return this.nest;
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000481 RID: 1153 RVA: 0x0000A235 File Offset: 0x00008435
		[DoNotSerialize]
		GameObject IMachine.threadSafeGameObject
		{
			get
			{
				return this.threadSafeGameObject;
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x0000A23D File Offset: 0x0000843D
		[DoNotSerialize]
		protected GraphReference reference
		{
			get
			{
				if (!this.isReferenceCached)
				{
					return GraphReference.New(this, false);
				}
				return this._reference;
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x0000A255 File Offset: 0x00008455
		[DoNotSerialize]
		protected bool hasGraph
		{
			get
			{
				return this.reference != null;
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x0000A263 File Offset: 0x00008463
		[DoNotSerialize]
		public TGraph graph
		{
			get
			{
				return this.nest.graph;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000485 RID: 1157 RVA: 0x0000A270 File Offset: 0x00008470
		// (set) Token: 0x06000486 RID: 1158 RVA: 0x0000A278 File Offset: 0x00008478
		[DoNotSerialize]
		public IGraphData graphData { get; set; }

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000487 RID: 1159 RVA: 0x0000A281 File Offset: 0x00008481
		[DoNotSerialize]
		bool IGraphParent.isSerializationRoot
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000488 RID: 1160 RVA: 0x0000A284 File Offset: 0x00008484
		[DoNotSerialize]
		Object IGraphParent.serializedObject
		{
			get
			{
				GraphSource source = this.nest.source;
				if (source == GraphSource.Embed)
				{
					return this;
				}
				if (source == GraphSource.Macro)
				{
					return this.nest.macro;
				}
				throw new UnexpectedEnumValueException<GraphSource>(this.nest.source);
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000489 RID: 1161 RVA: 0x0000A2C7 File Offset: 0x000084C7
		[DoNotSerialize]
		IGraph IGraphParent.childGraph
		{
			get
			{
				return this.graph;
			}
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x0000A2D4 File Offset: 0x000084D4
		public IEnumerable<object> GetAotStubs(HashSet<object> visited)
		{
			return this.nest.GetAotStubs(visited);
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x0600048B RID: 1163 RVA: 0x0000A2E2 File Offset: 0x000084E2
		// (set) Token: 0x0600048C RID: 1164 RVA: 0x0000A2E5 File Offset: 0x000084E5
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

		// Token: 0x0600048D RID: 1165 RVA: 0x0000A2E8 File Offset: 0x000084E8
		protected virtual void Awake()
		{
			this._alive = true;
			this.threadSafeGameObject = base.gameObject;
			this.nest.afterGraphChange += this.CacheReference;
			this.nest.beforeGraphChange += this.ClearCachedReference;
			this.CacheReference();
			if (this.graph != null)
			{
				this.graph.Prewarm();
				this.InstantiateNest();
			}
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x0000A35F File Offset: 0x0000855F
		protected virtual void OnEnable()
		{
			this._enabled = true;
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x0000A368 File Offset: 0x00008568
		protected virtual void OnInstantiateWhileEnabled()
		{
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x0000A36A File Offset: 0x0000856A
		protected virtual void OnUninstantiateWhileEnabled()
		{
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x0000A36C File Offset: 0x0000856C
		protected virtual void OnDisable()
		{
			this._enabled = false;
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x0000A375 File Offset: 0x00008575
		protected virtual void OnDestroy()
		{
			this.ClearCachedReference();
			if (this.graph != null)
			{
				this.UninstantiateNest();
			}
			this.threadSafeGameObject = null;
			this._alive = false;
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0000A39E File Offset: 0x0000859E
		protected virtual void OnValidate()
		{
			this.threadSafeGameObject = base.gameObject;
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x0000A3AC File Offset: 0x000085AC
		public GraphPointer GetReference()
		{
			return this.reference;
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0000A3B4 File Offset: 0x000085B4
		private void CacheReference()
		{
			this._reference = GraphReference.New(this, false);
			this.isReferenceCached = true;
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x0000A3CA File Offset: 0x000085CA
		private void ClearCachedReference()
		{
			if (this._reference != null)
			{
				this._reference.Release();
				this._reference = null;
			}
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x0000A3EC File Offset: 0x000085EC
		public virtual void InstantiateNest()
		{
			if (this._alive)
			{
				GraphInstances.Instantiate(this.reference);
			}
			if (this._enabled)
			{
				if (UnityThread.allowsAPI)
				{
					this.OnInstantiateWhileEnabled();
					return;
				}
				Debug.LogWarning("Could not run instantiation events on " + this.ToSafeString() + " because the Unity API is not available.\nThis can happen when undoing / redoing a graph source change.", this);
			}
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x0000A440 File Offset: 0x00008640
		public virtual void UninstantiateNest()
		{
			if (this._enabled)
			{
				if (UnityThread.allowsAPI)
				{
					this.OnUninstantiateWhileEnabled();
				}
				else
				{
					Debug.LogWarning("Could not run uninstantiation events on " + this.ToSafeString() + " because the Unity API is not available.\nThis can happen when undoing / redoing a graph source change.", this);
				}
			}
			if (this._alive)
			{
				HashSet<GraphReference> hashSet = GraphInstances.ChildrenOfPooled(this);
				foreach (GraphReference instance in hashSet)
				{
					GraphInstances.Uninstantiate(instance);
				}
				hashSet.Free<GraphReference>();
			}
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x0000A4D4 File Offset: 0x000086D4
		public virtual void TriggerAnimationEvent(AnimationEvent animationEvent)
		{
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x0000A4D6 File Offset: 0x000086D6
		public virtual void TriggerUnityEvent(string name)
		{
		}

		// Token: 0x0600049B RID: 1179
		public abstract TGraph DefaultGraph();

		// Token: 0x0600049C RID: 1180 RVA: 0x0000A4D8 File Offset: 0x000086D8
		IGraph IGraphParent.DefaultGraph()
		{
			return this.DefaultGraph();
		}

		// Token: 0x040000FA RID: 250
		[DoNotSerialize]
		private bool _alive;

		// Token: 0x040000FB RID: 251
		[DoNotSerialize]
		private bool _enabled;

		// Token: 0x040000FC RID: 252
		[DoNotSerialize]
		private GameObject threadSafeGameObject;

		// Token: 0x040000FD RID: 253
		[DoNotSerialize]
		private bool isReferenceCached;

		// Token: 0x040000FE RID: 254
		[DoNotSerialize]
		private GraphReference _reference;
	}
}
