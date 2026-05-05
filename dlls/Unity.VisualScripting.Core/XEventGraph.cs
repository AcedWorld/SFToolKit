using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000057 RID: 87
	public static class XEventGraph
	{
		// Token: 0x06000285 RID: 645 RVA: 0x000064A8 File Offset: 0x000046A8
		public static void TriggerEventHandler<TArgs>(this GraphReference reference, Func<EventHook, bool> predicate, TArgs args, Func<IGraphParentElement, bool> recurse, bool force)
		{
			Ensure.That("reference").IsNotNull<GraphReference>(reference);
			foreach (IGraphElement graphElement in reference.graph.elements)
			{
				IGraphEventHandler<TArgs> graphEventHandler = graphElement as IGraphEventHandler<TArgs>;
				if (graphEventHandler != null && (predicate == null || predicate(graphEventHandler.GetHook(reference))) && (force || graphEventHandler.IsListening(reference)))
				{
					graphEventHandler.Trigger(reference, args);
				}
				IGraphParentElement graphParentElement = graphElement as IGraphParentElement;
				if (graphParentElement != null && recurse(graphParentElement))
				{
					GraphReference graphReference = reference.ChildReference(graphParentElement, false, new int?(0));
					if (graphReference != null)
					{
						graphReference.TriggerEventHandler(predicate, args, recurse, force);
					}
				}
			}
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000656C File Offset: 0x0000476C
		public static void TriggerEventHandler<TArgs>(this GraphStack stack, Func<EventHook, bool> predicate, TArgs args, Func<IGraphParentElement, bool> recurse, bool force)
		{
			Ensure.That("stack").IsNotNull<GraphStack>(stack);
			GraphReference graphReference = null;
			foreach (IGraphElement graphElement in stack.graph.elements)
			{
				IGraphEventHandler<TArgs> graphEventHandler = graphElement as IGraphEventHandler<TArgs>;
				if (graphEventHandler != null)
				{
					if (graphReference == null)
					{
						graphReference = stack.ToReference();
					}
					if ((predicate == null || predicate(graphEventHandler.GetHook(graphReference))) && (force || graphEventHandler.IsListening(graphReference)))
					{
						graphEventHandler.Trigger(graphReference, args);
					}
				}
				IGraphParentElement graphParentElement = graphElement as IGraphParentElement;
				if (graphParentElement != null && recurse(graphParentElement) && stack.TryEnterParentElementUnsafe(graphParentElement))
				{
					stack.TriggerEventHandler(predicate, args, recurse, force);
					stack.ExitParentElement();
				}
			}
		}
	}
}
