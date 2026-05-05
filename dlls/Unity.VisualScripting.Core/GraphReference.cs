using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000067 RID: 103
	public sealed class GraphReference : GraphPointer
	{
		// Token: 0x0600034E RID: 846 RVA: 0x0000895C File Offset: 0x00006B5C
		static GraphReference()
		{
			ReferenceCollector.onSceneUnloaded += GraphReference.FreeInvalidInterns;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00008979 File Offset: 0x00006B79
		private GraphReference()
		{
		}

		// Token: 0x06000350 RID: 848 RVA: 0x00008981 File Offset: 0x00006B81
		public static GraphReference New(IGraphRoot root, bool ensureValid)
		{
			if (!ensureValid && !GraphPointer.IsValidRoot(root))
			{
				return null;
			}
			GraphReference graphReference = new GraphReference();
			graphReference.Initialize(root);
			graphReference.Hash();
			return graphReference;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x000089A2 File Offset: 0x00006BA2
		public static GraphReference New(IGraphRoot root, IEnumerable<IGraphParentElement> parentElements, bool ensureValid)
		{
			if (!ensureValid && !GraphPointer.IsValidRoot(root))
			{
				return null;
			}
			GraphReference graphReference = new GraphReference();
			graphReference.Initialize(root, parentElements, ensureValid);
			graphReference.Hash();
			return graphReference;
		}

		// Token: 0x06000352 RID: 850 RVA: 0x000089C5 File Offset: 0x00006BC5
		public static GraphReference New(Object rootObject, IEnumerable<Guid> parentElementGuids, bool ensureValid)
		{
			if (!ensureValid && !GraphPointer.IsValidRoot(rootObject))
			{
				return null;
			}
			GraphReference graphReference = new GraphReference();
			graphReference.Initialize(rootObject, parentElementGuids, ensureValid);
			graphReference.Hash();
			return graphReference;
		}

		// Token: 0x06000353 RID: 851 RVA: 0x000089E8 File Offset: 0x00006BE8
		private static GraphReference New(GraphPointer model)
		{
			GraphReference graphReference = new GraphReference();
			graphReference.CopyFrom(model);
			return graphReference;
		}

		// Token: 0x06000354 RID: 852 RVA: 0x000089F8 File Offset: 0x00006BF8
		public override void CopyFrom(GraphPointer other)
		{
			base.CopyFrom(other);
			GraphReference graphReference = other as GraphReference;
			if (graphReference != null)
			{
				this.hashCode = graphReference.hashCode;
				return;
			}
			this.Hash();
		}

		// Token: 0x06000355 RID: 853 RVA: 0x00008A29 File Offset: 0x00006C29
		public GraphReference Clone()
		{
			return GraphReference.New(this);
		}

		// Token: 0x06000356 RID: 854 RVA: 0x00008A31 File Offset: 0x00006C31
		public override GraphReference AsReference()
		{
			return this;
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00008A34 File Offset: 0x00006C34
		public GraphStack ToStackPooled()
		{
			return GraphStack.New(this);
		}

		// Token: 0x06000358 RID: 856 RVA: 0x00008A3C File Offset: 0x00006C3C
		internal void Release()
		{
			Action<IGraphRoot> releaseDebugDataBinding = GraphPointer.releaseDebugDataBinding;
			if (releaseDebugDataBinding == null)
			{
				return;
			}
			releaseDebugDataBinding(base.root);
		}

		// Token: 0x06000359 RID: 857 RVA: 0x00008A54 File Offset: 0x00006C54
		public void CreateGraphData()
		{
			if (base._data != null)
			{
				throw new GraphPointerException("Graph data already exists.", this);
			}
			if (base.isRoot)
			{
				if (base.machine != null)
				{
					base._data = (base.machine.graphData = base.graph.CreateData());
					return;
				}
				throw new GraphPointerException("Root graph data can only be created on machines.", this);
			}
			else
			{
				if (base._parentData == null)
				{
					throw new GraphPointerException("Child graph data can only be created from parent graph data.", this);
				}
				base._data = base._parentData.CreateChildGraphData(base.parentElement);
				return;
			}
		}

		// Token: 0x0600035A RID: 858 RVA: 0x00008ADC File Offset: 0x00006CDC
		public void FreeGraphData()
		{
			if (base._data == null)
			{
				throw new GraphPointerException("Graph data does not exist.", this);
			}
			if (base.isRoot)
			{
				if (base.machine != null)
				{
					base._data = (base.machine.graphData = null);
					return;
				}
				throw new GraphPointerException("Root graph data can only be freed on machines.", this);
			}
			else
			{
				if (base._parentData == null)
				{
					throw new GraphPointerException("Child graph data can only be freed from parent graph data.", this);
				}
				base._parentData.FreeChildGraphData(base.parentElement);
				base._data = null;
				return;
			}
		}

		// Token: 0x0600035B RID: 859 RVA: 0x00008B5C File Offset: 0x00006D5C
		public override bool Equals(object obj)
		{
			GraphReference graphReference = obj as GraphReference;
			return graphReference != null && base.InstanceEquals(graphReference);
		}

		// Token: 0x0600035C RID: 860 RVA: 0x00008B7C File Offset: 0x00006D7C
		private void Hash()
		{
			this.hashCode = base.ComputeHashCode();
		}

		// Token: 0x0600035D RID: 861 RVA: 0x00008B8A File Offset: 0x00006D8A
		public override int GetHashCode()
		{
			return this.hashCode;
		}

		// Token: 0x0600035E RID: 862 RVA: 0x00008B92 File Offset: 0x00006D92
		public static bool operator ==(GraphReference x, GraphReference y)
		{
			return x == y || (x != null && y != null && x.Equals(y));
		}

		// Token: 0x0600035F RID: 863 RVA: 0x00008BA9 File Offset: 0x00006DA9
		public static bool operator !=(GraphReference x, GraphReference y)
		{
			return !(x == y);
		}

		// Token: 0x06000360 RID: 864 RVA: 0x00008BB5 File Offset: 0x00006DB5
		public GraphReference ParentReference(bool ensureValid)
		{
			if (!base.isRoot)
			{
				GraphReference graphReference = this.Clone();
				graphReference.ExitParentElement();
				graphReference.Hash();
				return graphReference;
			}
			if (ensureValid)
			{
				throw new GraphPointerException("Trying to get parent graph reference of a root.", this);
			}
			return null;
		}

		// Token: 0x06000361 RID: 865 RVA: 0x00008BE4 File Offset: 0x00006DE4
		public GraphReference ChildReference(IGraphParentElement parentElement, bool ensureValid, int? maxRecursionDepth = null)
		{
			GraphReference graphReference = this.Clone();
			string message;
			if (graphReference.TryEnterParentElement(parentElement, out message, maxRecursionDepth, false))
			{
				graphReference.Hash();
				return graphReference;
			}
			if (ensureValid)
			{
				throw new GraphPointerException(message, this);
			}
			return null;
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00008C1C File Offset: 0x00006E1C
		public GraphReference Revalidate(bool ensureValid)
		{
			GraphReference result;
			try
			{
				result = GraphReference.New(base.rootObject, base.parentElementGuids, ensureValid);
			}
			catch (Exception ex)
			{
				if (ensureValid)
				{
					throw;
				}
				string str = "Failed to revalidate graph pointer: \n";
				Exception ex2 = ex;
				Debug.LogWarning(str + ((ex2 != null) ? ex2.ToString() : null));
				result = null;
			}
			return result;
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00008C78 File Offset: 0x00006E78
		public IEnumerable<GraphReference> GetBreadcrumbs()
		{
			int num;
			for (int depth = 0; depth < base.depth; depth = num + 1)
			{
				yield return GraphReference.New(base.root, this.parentElementStack.Take(depth), true);
				num = depth;
			}
			yield break;
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00008C88 File Offset: 0x00006E88
		public static GraphReference Intern(GraphPointer pointer)
		{
			int key = pointer.ComputeHashCode();
			List<GraphReference> list;
			if (GraphReference.internPool.TryGetValue(key, out list))
			{
				foreach (GraphReference graphReference in list)
				{
					if (graphReference.InstanceEquals(pointer))
					{
						return graphReference;
					}
				}
				GraphReference graphReference2 = GraphReference.New(pointer);
				list.Add(graphReference2);
				return graphReference2;
			}
			GraphReference graphReference3 = GraphReference.New(pointer);
			GraphReference.internPool.Add(graphReference3.hashCode, new List<GraphReference>
			{
				graphReference3
			});
			return graphReference3;
		}

		// Token: 0x06000365 RID: 869 RVA: 0x00008D34 File Offset: 0x00006F34
		internal static void ClearIntern(GraphPointer pointer)
		{
			int key = pointer.ComputeHashCode();
			List<GraphReference> list;
			if (!GraphReference.internPool.TryGetValue(key, out list))
			{
				return;
			}
			for (int i = list.Count - 1; i >= 0; i--)
			{
				if (list[i].InstanceEquals(pointer))
				{
					list.RemoveAt(i);
					break;
				}
			}
			if (list.Count == 0)
			{
				GraphReference.internPool.Remove(key);
			}
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00008D98 File Offset: 0x00006F98
		public static void FreeInvalidInterns()
		{
			List<int> list = ListPool<int>.New();
			foreach (KeyValuePair<int, List<GraphReference>> keyValuePair in GraphReference.internPool)
			{
				int key = keyValuePair.Key;
				List<GraphReference> value = keyValuePair.Value;
				List<GraphReference> list2 = ListPool<GraphReference>.New();
				foreach (GraphReference graphReference in value)
				{
					if (!graphReference.isValid)
					{
						list2.Add(graphReference);
					}
				}
				foreach (GraphReference item in list2)
				{
					value.Remove(item);
				}
				if (value.Count == 0)
				{
					list.Add(key);
				}
				list2.Free<GraphReference>();
			}
			foreach (int key2 in list)
			{
				GraphReference.internPool.Remove(key2);
			}
			list.Free<int>();
		}

		// Token: 0x040000E2 RID: 226
		[DoNotSerialize]
		private int hashCode;

		// Token: 0x040000E3 RID: 227
		private static readonly Dictionary<int, List<GraphReference>> internPool = new Dictionary<int, List<GraphReference>>();
	}
}
