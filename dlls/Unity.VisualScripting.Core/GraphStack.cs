using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x0200006A RID: 106
	public sealed class GraphStack : GraphPointer, IPoolable, IDisposable
	{
		// Token: 0x0600036B RID: 875 RVA: 0x0000901E File Offset: 0x0000721E
		private GraphStack()
		{
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00009028 File Offset: 0x00007228
		private void InitializeNoAlloc(IGraphRoot root, List<IGraphParentElement> parentElements, bool ensureValid)
		{
			base.Initialize(root);
			Ensure.That("parentElements").IsNotNull<List<IGraphParentElement>>(parentElements);
			foreach (IGraphParentElement parentElement in parentElements)
			{
				string message;
				if (!base.TryEnterParentElement(parentElement, out message, null, false))
				{
					if (ensureValid)
					{
						throw new GraphPointerException(message, this);
					}
					break;
				}
			}
		}

		// Token: 0x0600036D RID: 877 RVA: 0x000090A8 File Offset: 0x000072A8
		internal static GraphStack New(IGraphRoot root, List<IGraphParentElement> parentElements)
		{
			GraphStack graphStack = GenericPool<GraphStack>.New(() => new GraphStack());
			graphStack.InitializeNoAlloc(root, parentElements, true);
			return graphStack;
		}

		// Token: 0x0600036E RID: 878 RVA: 0x000090D7 File Offset: 0x000072D7
		internal static GraphStack New(GraphPointer model)
		{
			GraphStack graphStack = GenericPool<GraphStack>.New(() => new GraphStack());
			graphStack.CopyFrom(model);
			return graphStack;
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00009104 File Offset: 0x00007304
		public GraphStack Clone()
		{
			return GraphStack.New(this);
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0000910C File Offset: 0x0000730C
		public void Dispose()
		{
			GenericPool<GraphStack>.Free(this);
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00009114 File Offset: 0x00007314
		void IPoolable.New()
		{
		}

		// Token: 0x06000372 RID: 882 RVA: 0x00009116 File Offset: 0x00007316
		void IPoolable.Free()
		{
			base.root = null;
			this.parentStack.Clear();
			this.parentElementStack.Clear();
			this.graphStack.Clear();
			this.dataStack.Clear();
			this.debugDataStack.Clear();
		}

		// Token: 0x06000373 RID: 883 RVA: 0x00009156 File Offset: 0x00007356
		public override GraphReference AsReference()
		{
			return this.ToReference();
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0000915E File Offset: 0x0000735E
		public GraphReference ToReference()
		{
			return GraphReference.Intern(this);
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00009166 File Offset: 0x00007366
		internal void ClearReference()
		{
			GraphReference.ClearIntern(this);
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0000916E File Offset: 0x0000736E
		public new void EnterParentElement(IGraphParentElement parentElement)
		{
			base.EnterParentElement(parentElement);
		}

		// Token: 0x06000377 RID: 887 RVA: 0x00009178 File Offset: 0x00007378
		public bool TryEnterParentElement(IGraphParentElement parentElement)
		{
			string text;
			return base.TryEnterParentElement(parentElement, out text, null, false);
		}

		// Token: 0x06000378 RID: 888 RVA: 0x00009198 File Offset: 0x00007398
		public bool TryEnterParentElementUnsafe(IGraphParentElement parentElement)
		{
			string text;
			return base.TryEnterParentElement(parentElement, out text, null, true);
		}

		// Token: 0x06000379 RID: 889 RVA: 0x000091B8 File Offset: 0x000073B8
		public new void ExitParentElement()
		{
			base.ExitParentElement();
		}
	}
}
