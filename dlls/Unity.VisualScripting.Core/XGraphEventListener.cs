using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000082 RID: 130
	public static class XGraphEventListener
	{
		// Token: 0x060003D1 RID: 977 RVA: 0x000094D4 File Offset: 0x000076D4
		public static void StartListening(this IGraphEventListener listener, GraphReference reference)
		{
			using (GraphStack graphStack = reference.ToStackPooled())
			{
				listener.StartListening(graphStack);
			}
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x0000950C File Offset: 0x0000770C
		public static void StopListening(this IGraphEventListener listener, GraphReference reference)
		{
			using (GraphStack graphStack = reference.ToStackPooled())
			{
				listener.StopListening(graphStack);
			}
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00009544 File Offset: 0x00007744
		public static bool IsHierarchyListening(GraphReference reference)
		{
			bool result;
			using (GraphStack graphStack = reference.ToStackPooled())
			{
				while (graphStack.isChild)
				{
					IGraphParent parent = graphStack.parent;
					graphStack.ExitParentElement();
					IGraphEventListener graphEventListener = parent as IGraphEventListener;
					if (graphEventListener != null && !graphEventListener.IsListening(graphStack))
					{
						return false;
					}
				}
				IGraphEventListener graphEventListener2 = graphStack.graph as IGraphEventListener;
				if (graphEventListener2 != null && !graphEventListener2.IsListening(graphStack))
				{
					result = false;
				}
				else
				{
					result = true;
				}
			}
			return result;
		}
	}
}
