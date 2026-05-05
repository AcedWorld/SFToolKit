using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.VisualScripting
{
	// Token: 0x02000065 RID: 101
	public abstract class GraphPointer
	{
		// Token: 0x0600030E RID: 782 RVA: 0x00007AF8 File Offset: 0x00005CF8
		protected static bool IsValidRoot(IGraphRoot root)
		{
			return ((root != null) ? root.childGraph : null) != null && root as Object != null;
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00007B16 File Offset: 0x00005D16
		protected static bool IsValidRoot(Object rootObject)
		{
			if (rootObject != null)
			{
				IGraphRoot graphRoot = rootObject as IGraphRoot;
				return ((graphRoot != null) ? graphRoot.childGraph : null) != null;
			}
			return false;
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00007B38 File Offset: 0x00005D38
		internal GraphPointer()
		{
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00007B78 File Offset: 0x00005D78
		protected void Initialize(IGraphRoot root)
		{
			if (!GraphPointer.IsValidRoot(root))
			{
				throw new ArgumentException("Graph pointer root must be a valid Unity object with a non-null child graph.", "root");
			}
			if ((!(root is IMachine) || !(root is MonoBehaviour)) && (!(root is IMacro) || !(root is ScriptableObject)))
			{
				throw new ArgumentException("Graph pointer root must be either a machine or a macro.", "root");
			}
			this.root = root;
			this.parentStack.Add(root);
			this.graphStack.Add(root.childGraph);
			List<IGraphData> list = this.dataStack;
			IMachine machine = this.machine;
			list.Add((machine != null) ? machine.graphData : null);
			List<IGraphDebugData> list2 = this.debugDataStack;
			Func<IGraphRoot, IGraphDebugData> fetchRootDebugDataBinding = GraphPointer.fetchRootDebugDataBinding;
			list2.Add((fetchRootDebugDataBinding != null) ? fetchRootDebugDataBinding(root) : null);
			if (this.machine == null)
			{
				this.gameObject = null;
				return;
			}
			if (this.machine.threadSafeGameObject != null)
			{
				this.gameObject = this.machine.threadSafeGameObject;
				return;
			}
			if (UnityThread.allowsAPI)
			{
				this.gameObject = this.component.gameObject;
				return;
			}
			throw new GraphPointerException("Could not fetch graph pointer root game object.", this);
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00007C84 File Offset: 0x00005E84
		protected void Initialize(IGraphRoot root, IEnumerable<IGraphParentElement> parentElements, bool ensureValid)
		{
			this.Initialize(root);
			Ensure.That("parentElements").IsNotNull<IEnumerable<IGraphParentElement>>(parentElements);
			foreach (IGraphParentElement parentElement in parentElements)
			{
				string message;
				if (!this.TryEnterParentElement(parentElement, out message, null, false))
				{
					if (ensureValid)
					{
						throw new GraphPointerException(message, this);
					}
					break;
				}
			}
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00007CFC File Offset: 0x00005EFC
		protected void Initialize(Object rootObject, IEnumerable<Guid> parentElementGuids, bool ensureValid)
		{
			this.Initialize(rootObject as IGraphRoot);
			Ensure.That("parentElementGuids").IsNotNull<IEnumerable<Guid>>(parentElementGuids);
			foreach (Guid parentElementGuid in parentElementGuids)
			{
				string message;
				if (!this.TryEnterParentElement(parentElementGuid, out message, null))
				{
					if (ensureValid)
					{
						throw new GraphPointerException(message, this);
					}
					break;
				}
			}
		}

		// Token: 0x06000314 RID: 788
		public abstract GraphReference AsReference();

		// Token: 0x06000315 RID: 789 RVA: 0x00007D78 File Offset: 0x00005F78
		public virtual void CopyFrom(GraphPointer other)
		{
			this.root = other.root;
			this.gameObject = other.gameObject;
			this.parentStack.Clear();
			this.parentElementStack.Clear();
			this.graphStack.Clear();
			this.dataStack.Clear();
			this.debugDataStack.Clear();
			foreach (IGraphParent item in other.parentStack)
			{
				this.parentStack.Add(item);
			}
			foreach (IGraphParentElement item2 in other.parentElementStack)
			{
				this.parentElementStack.Add(item2);
			}
			foreach (IGraph item3 in other.graphStack)
			{
				this.graphStack.Add(item3);
			}
			foreach (IGraphData item4 in other.dataStack)
			{
				this.dataStack.Add(item4);
			}
			foreach (IGraphDebugData item5 in other.debugDataStack)
			{
				this.debugDataStack.Add(item5);
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000316 RID: 790 RVA: 0x00007F44 File Offset: 0x00006144
		// (set) Token: 0x06000317 RID: 791 RVA: 0x00007F4C File Offset: 0x0000614C
		public IGraphRoot root { get; protected set; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000318 RID: 792 RVA: 0x00007F55 File Offset: 0x00006155
		public Object rootObject
		{
			get
			{
				return this.root as Object;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000319 RID: 793 RVA: 0x00007F62 File Offset: 0x00006162
		public IMachine machine
		{
			get
			{
				return this.root as IMachine;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600031A RID: 794 RVA: 0x00007F6F File Offset: 0x0000616F
		public IMacro macro
		{
			get
			{
				return this.root as IMacro;
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x0600031B RID: 795 RVA: 0x00007F7C File Offset: 0x0000617C
		public MonoBehaviour component
		{
			get
			{
				return this.root as MonoBehaviour;
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x0600031C RID: 796 RVA: 0x00007F89 File Offset: 0x00006189
		// (set) Token: 0x0600031D RID: 797 RVA: 0x00007F91 File Offset: 0x00006191
		public GameObject gameObject { get; private set; }

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x0600031E RID: 798 RVA: 0x00007F9A File Offset: 0x0000619A
		public GameObject self
		{
			get
			{
				return this.gameObject;
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x0600031F RID: 799 RVA: 0x00007FA2 File Offset: 0x000061A2
		public ScriptableObject scriptableObject
		{
			get
			{
				return this.root as ScriptableObject;
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000320 RID: 800 RVA: 0x00007FB0 File Offset: 0x000061B0
		public Scene? scene
		{
			get
			{
				if (this.gameObject == null)
				{
					return null;
				}
				Scene scene = this.gameObject.scene;
				if (!scene.IsValid())
				{
					return null;
				}
				return new Scene?(scene);
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000321 RID: 801 RVA: 0x00007FFC File Offset: 0x000061FC
		public Object serializedObject
		{
			get
			{
				for (int i = this.depth; i > 0; i--)
				{
					IGraphParent graphParent = this.parentStack[i - 1];
					if (graphParent.isSerializationRoot)
					{
						return graphParent.serializedObject;
					}
				}
				throw new GraphPointerException("Could not find serialized object.", this);
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000322 RID: 802 RVA: 0x00008043 File Offset: 0x00006243
		public IEnumerable<Guid> parentElementGuids
		{
			get
			{
				return from parentElement in this.parentElementStack
				select parentElement.guid;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000323 RID: 803 RVA: 0x0000806F File Offset: 0x0000626F
		public int depth
		{
			get
			{
				return this.parentStack.Count;
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000324 RID: 804 RVA: 0x0000807C File Offset: 0x0000627C
		public bool isRoot
		{
			get
			{
				return this.depth == 1;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000325 RID: 805 RVA: 0x00008087 File Offset: 0x00006287
		public bool isChild
		{
			get
			{
				return this.depth > 1;
			}
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00008092 File Offset: 0x00006292
		public void EnsureDepthValid(int depth)
		{
			Ensure.That("depth").IsGte<int>(depth, 1);
			if (depth > this.depth)
			{
				throw new GraphPointerException(string.Format("Trying to fetch a graph pointer level above depth: {0} > {1}", depth, this.depth), this);
			}
		}

		// Token: 0x06000327 RID: 807 RVA: 0x000080D0 File Offset: 0x000062D0
		public void EnsureChild()
		{
			if (!this.isChild)
			{
				throw new GraphPointerException("Graph pointer does not point to a child graph.", this);
			}
		}

		// Token: 0x06000328 RID: 808 RVA: 0x000080E6 File Offset: 0x000062E6
		public bool IsWithin<T>() where T : IGraphParent
		{
			return this.parent is T;
		}

		// Token: 0x06000329 RID: 809 RVA: 0x000080F6 File Offset: 0x000062F6
		public void EnsureWithin<T>() where T : IGraphParent
		{
			if (!this.IsWithin<T>())
			{
				throw new GraphPointerException(string.Format("Graph pointer must be within a {0} for this operation.", typeof(T)), this);
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600032A RID: 810 RVA: 0x0000811B File Offset: 0x0000631B
		public IGraphParent parent
		{
			get
			{
				return this.parentStack[this.parentStack.Count - 1];
			}
		}

		// Token: 0x0600032B RID: 811 RVA: 0x00008135 File Offset: 0x00006335
		public T GetParent<T>() where T : IGraphParent
		{
			this.EnsureWithin<T>();
			return (T)((object)this.parent);
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x0600032C RID: 812 RVA: 0x00008148 File Offset: 0x00006348
		public IGraphParentElement parentElement
		{
			get
			{
				this.EnsureChild();
				return this.parentElementStack[this.parentElementStack.Count - 1];
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x0600032D RID: 813 RVA: 0x00008168 File Offset: 0x00006368
		public IGraph rootGraph
		{
			get
			{
				return this.graphStack[0];
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x0600032E RID: 814 RVA: 0x00008176 File Offset: 0x00006376
		public IGraph graph
		{
			get
			{
				return this.graphStack[this.graphStack.Count - 1];
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x0600032F RID: 815 RVA: 0x00008190 File Offset: 0x00006390
		// (set) Token: 0x06000330 RID: 816 RVA: 0x000081AA File Offset: 0x000063AA
		protected IGraphData _data
		{
			get
			{
				return this.dataStack[this.dataStack.Count - 1];
			}
			set
			{
				this.dataStack[this.dataStack.Count - 1] = value;
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000331 RID: 817 RVA: 0x000081C5 File Offset: 0x000063C5
		public IGraphData data
		{
			get
			{
				this.EnsureDataAvailable();
				return this._data;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000332 RID: 818 RVA: 0x000081D3 File Offset: 0x000063D3
		protected IGraphData _parentData
		{
			get
			{
				return this.dataStack[this.dataStack.Count - 2];
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000333 RID: 819 RVA: 0x000081ED File Offset: 0x000063ED
		public bool hasData
		{
			get
			{
				return this._data != null;
			}
		}

		// Token: 0x06000334 RID: 820 RVA: 0x000081F8 File Offset: 0x000063F8
		public void EnsureDataAvailable()
		{
			if (!this.hasData)
			{
				throw new GraphPointerException("Graph data is not available.", this);
			}
		}

		// Token: 0x06000335 RID: 821 RVA: 0x00008210 File Offset: 0x00006410
		public T GetGraphData<T>() where T : IGraphData
		{
			IGraphData data = this.data;
			if (data is T)
			{
				return (T)((object)data);
			}
			throw new GraphPointerException(string.Format("Graph data type mismatch. Found {0}, expected {1}.", data.GetType(), typeof(T)), this);
		}

		// Token: 0x06000336 RID: 822 RVA: 0x00008254 File Offset: 0x00006454
		public T GetElementData<T>(IGraphElementWithData element) where T : IGraphElementData
		{
			IGraphElementData graphElementData;
			if (!this._data.TryGetElementData(element, out graphElementData))
			{
				throw new GraphPointerException(string.Format("Missing graph element data for {0}.", element), this);
			}
			if (graphElementData is T)
			{
				return (T)((object)graphElementData);
			}
			throw new GraphPointerException(string.Format("Graph element data type mismatch. Found {0}, expected {1}.", graphElementData.GetType(), typeof(T)), this);
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000337 RID: 823 RVA: 0x000082B2 File Offset: 0x000064B2
		// (set) Token: 0x06000338 RID: 824 RVA: 0x000082B9 File Offset: 0x000064B9
		public static Func<IGraphRoot, IGraphDebugData> fetchRootDebugDataBinding { get; set; }

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000339 RID: 825 RVA: 0x000082C1 File Offset: 0x000064C1
		public bool hasDebugData
		{
			get
			{
				return this._debugData != null;
			}
		}

		// Token: 0x0600033A RID: 826 RVA: 0x000082CC File Offset: 0x000064CC
		public void EnsureDebugDataAvailable()
		{
			if (!this.hasDebugData)
			{
				throw new GraphPointerException("Graph debug data is not available.", this);
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600033B RID: 827 RVA: 0x000082E2 File Offset: 0x000064E2
		// (set) Token: 0x0600033C RID: 828 RVA: 0x000082FC File Offset: 0x000064FC
		protected IGraphDebugData _debugData
		{
			get
			{
				return this.debugDataStack[this.debugDataStack.Count - 1];
			}
			set
			{
				this.debugDataStack[this.debugDataStack.Count - 1] = value;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x0600033D RID: 829 RVA: 0x00008317 File Offset: 0x00006517
		public IGraphDebugData debugData
		{
			get
			{
				this.EnsureDebugDataAvailable();
				return this._debugData;
			}
		}

		// Token: 0x0600033E RID: 830 RVA: 0x00008328 File Offset: 0x00006528
		public T GetGraphDebugData<T>() where T : IGraphDebugData
		{
			IGraphDebugData debugData = this.debugData;
			if (debugData is T)
			{
				return (T)((object)debugData);
			}
			throw new GraphPointerException(string.Format("Graph debug data type mismatch. Found {0}, expected {1}.", debugData.GetType(), typeof(T)), this);
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0000836C File Offset: 0x0000656C
		public T GetElementDebugData<T>(IGraphElementWithDebugData element)
		{
			IGraphElementDebugData orCreateElementData = this.debugData.GetOrCreateElementData(element);
			if (orCreateElementData is T)
			{
				return (T)((object)orCreateElementData);
			}
			throw new GraphPointerException(string.Format("Graph element runtime debug data type mismatch. Found {0}, expected {1}.", orCreateElementData.GetType(), typeof(T)), this);
		}

		// Token: 0x06000340 RID: 832 RVA: 0x000083B8 File Offset: 0x000065B8
		protected bool TryEnterParentElement(Guid parentElementGuid, out string error, int? maxRecursionDepth = null)
		{
			IGraphElement graphElement;
			if (!this.graph.elements.TryGetValue(parentElementGuid, out graphElement))
			{
				error = "Trying to enter a graph parent element with a GUID that is not within the current graph.";
				return false;
			}
			if (!(graphElement is IGraphParentElement))
			{
				error = "Provided element GUID does not point to a graph parent element.";
				return false;
			}
			IGraphParentElement parentElement = (IGraphParentElement)graphElement;
			return this.TryEnterParentElement(parentElement, out error, maxRecursionDepth, false);
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00008408 File Offset: 0x00006608
		protected bool TryEnterParentElement(IGraphParentElement parentElement, out string error, int? maxRecursionDepth = null, bool skipContainsCheck = false)
		{
			if (!skipContainsCheck && !this.graph.elements.Contains(parentElement))
			{
				error = "Trying to enter a graph parent element that is not within the current graph.";
				return false;
			}
			IGraph childGraph = parentElement.childGraph;
			if (childGraph == null)
			{
				error = "Trying to enter a graph parent element without a child graph.";
				return false;
			}
			if (Recursion.safeMode)
			{
				int num = 0;
				int num2 = maxRecursionDepth ?? Recursion.defaultMaxDepth;
				using (List<IGraph>.Enumerator enumerator = this.graphStack.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current == childGraph)
						{
							num++;
						}
					}
				}
				if (num > num2)
				{
					error = string.Format("Max recursion depth of {0} has been exceeded. Are you nesting a graph within itself?\nIf not, consider increasing '{1}.{2}'.", num2, "Recursion", "defaultMaxDepth");
					return false;
				}
			}
			this.EnterValidParentElement(parentElement);
			error = null;
			return true;
		}

		// Token: 0x06000342 RID: 834 RVA: 0x000084E0 File Offset: 0x000066E0
		protected void EnterParentElement(IGraphParentElement parentElement)
		{
			string message;
			if (!this.TryEnterParentElement(parentElement, out message, null, false))
			{
				throw new GraphPointerException(message, this);
			}
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0000850C File Offset: 0x0000670C
		protected void EnterParentElement(Guid parentElementGuid)
		{
			string message;
			if (!this.TryEnterParentElement(parentElementGuid, out message, null))
			{
				throw new GraphPointerException(message, this);
			}
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00008538 File Offset: 0x00006738
		private void EnterValidParentElement(IGraphParentElement parentElement)
		{
			IGraph childGraph = parentElement.childGraph;
			this.parentStack.Add(parentElement);
			this.parentElementStack.Add(parentElement);
			this.graphStack.Add(childGraph);
			IGraphData item = null;
			IGraphData data = this._data;
			if (data != null)
			{
				data.TryGetChildGraphData(parentElement, out item);
			}
			this.dataStack.Add(item);
			IGraphDebugData debugData = this._debugData;
			IGraphDebugData item2 = (debugData != null) ? debugData.GetOrCreateChildGraphData(parentElement) : null;
			this.debugDataStack.Add(item2);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x000085B4 File Offset: 0x000067B4
		protected void ExitParentElement()
		{
			if (!this.isChild)
			{
				throw new GraphPointerException("Trying to exit the root graph.", this);
			}
			this.parentStack.RemoveAt(this.parentStack.Count - 1);
			this.parentElementStack.RemoveAt(this.parentElementStack.Count - 1);
			this.graphStack.RemoveAt(this.graphStack.Count - 1);
			this.dataStack.RemoveAt(this.dataStack.Count - 1);
			this.debugDataStack.RemoveAt(this.debugDataStack.Count - 1);
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000346 RID: 838 RVA: 0x00008650 File Offset: 0x00006850
		public bool isValid
		{
			get
			{
				bool result;
				try
				{
					if (this.rootObject == null)
					{
						result = false;
					}
					else if (this.rootGraph != this.root.childGraph)
					{
						result = false;
					}
					else if (this.serializedObject == null)
					{
						result = false;
					}
					else
					{
						for (int i = 1; i < this.depth; i++)
						{
							IGraphParentElement graphParentElement = this.parentElementStack[i - 1];
							IGraph graph = this.graphStack[i - 1];
							IGraph graph2 = this.graphStack[i];
							if (!graph.elements.Contains(graphParentElement))
							{
								return false;
							}
							if (graphParentElement.childGraph != graph2)
							{
								return false;
							}
						}
						result = true;
					}
				}
				catch (Exception ex)
				{
					string str = "Failed to check graph pointer validity: \n";
					Exception ex2 = ex;
					Debug.LogWarning(str + ((ex2 != null) ? ex2.ToString() : null));
					result = false;
				}
				return result;
			}
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00008734 File Offset: 0x00006934
		public void EnsureValid()
		{
			if (!this.isValid)
			{
				throw new GraphPointerException("Graph pointer is invalid.", this);
			}
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0000874C File Offset: 0x0000694C
		public bool InstanceEquals(GraphPointer other)
		{
			if (this == other)
			{
				return true;
			}
			if (!UnityObjectUtility.TrulyEqual(this.rootObject, other.rootObject))
			{
				return false;
			}
			if (!this.DefinitionEquals(other))
			{
				return false;
			}
			int depth = this.depth;
			for (int i = 0; i < depth; i++)
			{
				IGraphData graphData = this.dataStack[i];
				IGraphData graphData2 = other.dataStack[i];
				if (graphData != graphData2)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x000087B4 File Offset: 0x000069B4
		public bool DefinitionEquals(GraphPointer other)
		{
			if (other == null)
			{
				return false;
			}
			if (this.rootGraph != other.rootGraph)
			{
				return false;
			}
			int depth = this.depth;
			if (depth != other.depth)
			{
				return false;
			}
			for (int i = 1; i < depth; i++)
			{
				IGraphParentElement graphParentElement = this.parentElementStack[i - 1];
				IGraphParentElement graphParentElement2 = other.parentElementStack[i - 1];
				if (graphParentElement != graphParentElement2)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00008818 File Offset: 0x00006A18
		public int ComputeHashCode()
		{
			int num = 17;
			int num2 = num * 23;
			Object @object = this.rootObject.AsUnityNull<Object>();
			num = num2 + ((@object != null) ? @object.GetHashCode() : 0);
			int num3 = num * 23;
			IGraph rootGraph = this.rootGraph;
			num = num3 + ((rootGraph != null) ? rootGraph.GetHashCode() : 0);
			int depth = this.depth;
			for (int i = 1; i < depth; i++)
			{
				Guid guid = this.parentElementStack[i - 1].guid;
				num = num * 23 + guid.GetHashCode();
			}
			return num;
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00008898 File Offset: 0x00006A98
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[ ");
			stringBuilder.Append(this.rootObject.ToSafeString());
			for (int i = 1; i < this.depth; i++)
			{
				stringBuilder.Append(" > ");
				int num = i - 1;
				if (num >= this.parentElementStack.Count)
				{
					stringBuilder.Append("?");
					break;
				}
				IGraphParentElement value = this.parentElementStack[num];
				stringBuilder.Append(value);
			}
			stringBuilder.Append(" ]");
			return stringBuilder.ToString();
		}

		// Token: 0x040000DA RID: 218
		protected readonly List<IGraphParent> parentStack = new List<IGraphParent>();

		// Token: 0x040000DB RID: 219
		protected readonly List<IGraphParentElement> parentElementStack = new List<IGraphParentElement>();

		// Token: 0x040000DC RID: 220
		protected readonly List<IGraph> graphStack = new List<IGraph>();

		// Token: 0x040000DD RID: 221
		protected readonly List<IGraphData> dataStack = new List<IGraphData>();

		// Token: 0x040000DE RID: 222
		protected readonly List<IGraphDebugData> debugDataStack = new List<IGraphDebugData>();

		// Token: 0x040000E0 RID: 224
		internal static Action<IGraphRoot> releaseDebugDataBinding;
	}
}
