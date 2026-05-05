using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000160 RID: 352
	internal static class DragAndDropUtility
	{
		// Token: 0x06000B80 RID: 2944 RVA: 0x0002DA6C File Offset: 0x0002BC6C
		internal static IDragAndDrop GetDragAndDrop(IPanel panel)
		{
			bool flag = panel.contextType == ContextType.Player;
			IDragAndDrop result;
			if (flag)
			{
				IDragAndDrop dragAndDrop;
				if ((dragAndDrop = DragAndDropUtility.s_DragAndDropPlayMode) == null)
				{
					dragAndDrop = (DragAndDropUtility.s_DragAndDropPlayMode = new DefaultDragAndDropClient());
				}
				result = dragAndDrop;
			}
			else
			{
				IDragAndDrop dragAndDrop2;
				if ((dragAndDrop2 = DragAndDropUtility.s_DragAndDropEditor) == null)
				{
					IDragAndDrop dragAndDrop4;
					if (DragAndDropUtility.s_MakeDragAndDropClientFunc == null)
					{
						IDragAndDrop dragAndDrop3 = new DefaultDragAndDropClient();
						dragAndDrop4 = dragAndDrop3;
					}
					else
					{
						dragAndDrop4 = DragAndDropUtility.s_MakeDragAndDropClientFunc();
					}
					dragAndDrop2 = (DragAndDropUtility.s_DragAndDropEditor = dragAndDrop4);
				}
				result = dragAndDrop2;
			}
			return result;
		}

		// Token: 0x06000B81 RID: 2945 RVA: 0x0002DACC File Offset: 0x0002BCCC
		internal static void RegisterMakeClientFunc(Func<IDragAndDrop> makeClient)
		{
			DragAndDropUtility.s_MakeDragAndDropClientFunc = makeClient;
			DragAndDropUtility.s_DragAndDropEditor = null;
		}

		// Token: 0x0400056C RID: 1388
		private static Func<IDragAndDrop> s_MakeDragAndDropClientFunc;

		// Token: 0x0400056D RID: 1389
		private static IDragAndDrop s_DragAndDropEditor;

		// Token: 0x0400056E RID: 1390
		private static IDragAndDrop s_DragAndDropPlayMode;
	}
}
