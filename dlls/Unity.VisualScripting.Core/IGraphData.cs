using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200006C RID: 108
	public interface IGraphData
	{
		// Token: 0x06000385 RID: 901
		bool TryGetElementData(IGraphElementWithData element, out IGraphElementData data);

		// Token: 0x06000386 RID: 902
		bool TryGetChildGraphData(IGraphParentElement element, out IGraphData data);

		// Token: 0x06000387 RID: 903
		IGraphElementData CreateElementData(IGraphElementWithData element);

		// Token: 0x06000388 RID: 904
		void FreeElementData(IGraphElementWithData element);

		// Token: 0x06000389 RID: 905
		IGraphData CreateChildGraphData(IGraphParentElement element);

		// Token: 0x0600038A RID: 906
		void FreeChildGraphData(IGraphParentElement element);
	}
}
