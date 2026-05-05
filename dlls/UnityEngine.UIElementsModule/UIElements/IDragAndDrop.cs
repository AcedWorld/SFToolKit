using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000165 RID: 357
	internal interface IDragAndDrop
	{
		// Token: 0x06000BA5 RID: 2981
		void StartDrag(StartDragArgs args, Vector3 pointerPosition);

		// Token: 0x06000BA6 RID: 2982
		void UpdateDrag(Vector3 pointerPosition);

		// Token: 0x06000BA7 RID: 2983
		void AcceptDrag();

		// Token: 0x06000BA8 RID: 2984
		void DragCleanup();

		// Token: 0x06000BA9 RID: 2985
		void SetVisualMode(DragVisualMode visualMode);

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000BAA RID: 2986
		DragAndDropData data { get; }
	}
}
