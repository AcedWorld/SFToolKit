using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200005E RID: 94
	public abstract class Graph : IGraph, IDisposable, IPrewarmable, IAotStubbable, ISerializationDepender, ISerializationCallbackReceiver
	{
		// Token: 0x06000296 RID: 662 RVA: 0x00006711 File Offset: 0x00004911
		protected Graph()
		{
			this.elements = new MergedGraphElementCollection();
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000673A File Offset: 0x0000493A
		public override string ToString()
		{
			return StringUtility.FallbackWhitespace(this.title, base.ToString());
		}

		// Token: 0x06000298 RID: 664
		public abstract IGraphData CreateData();

		// Token: 0x06000299 RID: 665 RVA: 0x0000674D File Offset: 0x0000494D
		public virtual IGraphDebugData CreateDebugData()
		{
			return new GraphDebugData(this);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00006758 File Offset: 0x00004958
		public virtual void Instantiate(GraphReference instance)
		{
			foreach (IGraphElement graphElement in this.elements)
			{
				graphElement.Instantiate(instance);
			}
		}

		// Token: 0x0600029B RID: 667 RVA: 0x000067AC File Offset: 0x000049AC
		public virtual void Uninstantiate(GraphReference instance)
		{
			foreach (IGraphElement graphElement in this.elements)
			{
				graphElement.Uninstantiate(instance);
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600029C RID: 668 RVA: 0x00006800 File Offset: 0x00004A00
		[DoNotSerialize]
		public MergedGraphElementCollection elements { get; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600029D RID: 669 RVA: 0x00006808 File Offset: 0x00004A08
		// (set) Token: 0x0600029E RID: 670 RVA: 0x00006810 File Offset: 0x00004A10
		[Serialize]
		public string title { get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600029F RID: 671 RVA: 0x00006819 File Offset: 0x00004A19
		// (set) Token: 0x060002A0 RID: 672 RVA: 0x00006821 File Offset: 0x00004A21
		[Serialize]
		[InspectorTextArea(minLines = 1f, maxLines = 10f)]
		public string summary { get; set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060002A1 RID: 673 RVA: 0x0000682A File Offset: 0x00004A2A
		// (set) Token: 0x060002A2 RID: 674 RVA: 0x00006832 File Offset: 0x00004A32
		[Serialize]
		public Vector2 pan { get; set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060002A3 RID: 675 RVA: 0x0000683B File Offset: 0x00004A3B
		// (set) Token: 0x060002A4 RID: 676 RVA: 0x00006843 File Offset: 0x00004A43
		[Serialize]
		public float zoom { get; set; } = 1f;

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x0000684C File Offset: 0x00004A4C
		public IEnumerable<ISerializationDependency> deserializationDependencies
		{
			get
			{
				return this._elements.SelectMany((IGraphElement e) => e.deserializationDependencies);
			}
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x00006878 File Offset: 0x00004A78
		public virtual void OnBeforeSerialize()
		{
			this._elements.Clear();
			this._elements.AddRange(this.elements);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00006896 File Offset: 0x00004A96
		public void OnAfterDeserialize()
		{
			Serialization.AwaitDependencies(this);
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x000068A0 File Offset: 0x00004AA0
		public virtual void OnAfterDependenciesDeserialized()
		{
			this.elements.Clear();
			List<IGraphElement> list = ListPool<IGraphElement>.New();
			foreach (IGraphElement item in this._elements)
			{
				list.Add(item);
			}
			list.Sort((IGraphElement a, IGraphElement b) => a.dependencyOrder.CompareTo(b.dependencyOrder));
			foreach (IGraphElement graphElement in list)
			{
				try
				{
					if (graphElement.HandleDependencies())
					{
						this.elements.Add(graphElement);
					}
				}
				catch (Exception arg)
				{
					Debug.LogWarning(string.Format("Failed to add element to graph during deserialization: {0}\n{1}", graphElement, arg));
				}
			}
			ListPool<IGraphElement>.Free(list);
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x000069A0 File Offset: 0x00004BA0
		public IEnumerable<object> GetAotStubs(HashSet<object> visited)
		{
			return (from element in this.elements
			where !visited.Contains(element)
			select element).Select(delegate(IGraphElement element)
			{
				visited.Add(element);
				return element;
			}).SelectMany((IGraphElement element) => element.GetAotStubs(visited));
		}

		// Token: 0x060002AA RID: 682 RVA: 0x000069F4 File Offset: 0x00004BF4
		public void Prewarm()
		{
			if (this.prewarmed)
			{
				return;
			}
			foreach (IGraphElement graphElement in this.elements)
			{
				graphElement.Prewarm();
			}
			this.prewarmed = true;
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00006A54 File Offset: 0x00004C54
		public virtual void Dispose()
		{
			foreach (IGraphElement graphElement in this.elements)
			{
				graphElement.Dispose();
			}
		}

		// Token: 0x040000BA RID: 186
		[SerializeAs("elements")]
		private List<IGraphElement> _elements = new List<IGraphElement>();

		// Token: 0x040000C0 RID: 192
		private bool prewarmed;
	}
}
