using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000063 RID: 99
	public static class GraphInstances
	{
		// Token: 0x060002ED RID: 749 RVA: 0x00007484 File Offset: 0x00005684
		public static void Instantiate(GraphReference instance)
		{
			object obj = GraphInstances.@lock;
			lock (obj)
			{
				Ensure.That("instance").IsNotNull<GraphReference>(instance);
				instance.CreateGraphData();
				instance.graph.Instantiate(instance);
				HashSet<GraphReference> hashSet;
				if (!GraphInstances.byGraph.TryGetValue(instance.graph, out hashSet))
				{
					hashSet = new HashSet<GraphReference>();
					GraphInstances.byGraph.Add(instance.graph, hashSet);
				}
				if (!hashSet.Add(instance))
				{
					Debug.LogWarning(string.Format("Attempting to add duplicate graph instance mapping:\n{0} => {1}", instance.graph, instance));
				}
				HashSet<GraphReference> hashSet2;
				if (!GraphInstances.byParent.TryGetValue(instance.parent, out hashSet2))
				{
					hashSet2 = new HashSet<GraphReference>();
					GraphInstances.byParent.Add(instance.parent, hashSet2);
				}
				if (!hashSet2.Add(instance))
				{
					Debug.LogWarning(string.Format("Attempting to add duplicate parent instance mapping:\n{0} => {1}", instance.parent.ToSafeString(), instance));
				}
			}
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0000757C File Offset: 0x0000577C
		public static void Uninstantiate(GraphReference instance)
		{
			object obj = GraphInstances.@lock;
			lock (obj)
			{
				instance.graph.Uninstantiate(instance);
				HashSet<GraphReference> hashSet;
				if (!GraphInstances.byGraph.TryGetValue(instance.graph, out hashSet))
				{
					throw new InvalidOperationException("Graph instance not found via graph.");
				}
				if (hashSet.Remove(instance))
				{
					if (hashSet.Count == 0)
					{
						GraphInstances.byGraph.Remove(instance.graph);
					}
				}
				else
				{
					Debug.LogWarning(string.Format("Could not find graph instance mapping to remove:\n{0} => {1}", instance.graph, instance));
				}
				HashSet<GraphReference> hashSet2;
				if (!GraphInstances.byParent.TryGetValue(instance.parent, out hashSet2))
				{
					throw new InvalidOperationException("Graph instance not found via parent.");
				}
				if (hashSet2.Remove(instance))
				{
					if (hashSet2.Count == 0)
					{
						GraphInstances.byParent.Remove(instance.parent);
					}
				}
				else
				{
					Debug.LogWarning(string.Format("Could not find parent instance mapping to remove:\n{0} => {1}", instance.parent.ToSafeString(), instance));
				}
				instance.FreeGraphData();
			}
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00007680 File Offset: 0x00005880
		public static HashSet<GraphReference> OfPooled(IGraph graph)
		{
			Ensure.That("graph").IsNotNull<IGraph>(graph);
			object obj = GraphInstances.@lock;
			HashSet<GraphReference> result;
			lock (obj)
			{
				HashSet<GraphReference> source;
				if (GraphInstances.byGraph.TryGetValue(graph, out source))
				{
					result = source.ToHashSetPooled<GraphReference>();
				}
				else
				{
					result = HashSetPool<GraphReference>.New();
				}
			}
			return result;
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x000076E8 File Offset: 0x000058E8
		public static HashSet<GraphReference> ChildrenOfPooled(IGraphParent parent)
		{
			Ensure.That("parent").IsNotNull<IGraphParent>(parent);
			object obj = GraphInstances.@lock;
			HashSet<GraphReference> result;
			lock (obj)
			{
				HashSet<GraphReference> source;
				if (GraphInstances.byParent.TryGetValue(parent, out source))
				{
					result = source.ToHashSetPooled<GraphReference>();
				}
				else
				{
					result = HashSetPool<GraphReference>.New();
				}
			}
			return result;
		}

		// Token: 0x040000CF RID: 207
		private static readonly object @lock = new object();

		// Token: 0x040000D0 RID: 208
		private static readonly Dictionary<IGraph, HashSet<GraphReference>> byGraph = new Dictionary<IGraph, HashSet<GraphReference>>();

		// Token: 0x040000D1 RID: 209
		private static readonly Dictionary<IGraphParent, HashSet<GraphReference>> byParent = new Dictionary<IGraphParent, HashSet<GraphReference>>();
	}
}
