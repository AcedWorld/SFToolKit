using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000156 RID: 342
	internal class CursorManager : ICursorManager
	{
		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000B09 RID: 2825 RVA: 0x0002C3A3 File Offset: 0x0002A5A3
		// (set) Token: 0x06000B0A RID: 2826 RVA: 0x0002C3AB File Offset: 0x0002A5AB
		public bool isCursorOverriden { get; private set; }

		// Token: 0x06000B0B RID: 2827 RVA: 0x0002C3B4 File Offset: 0x0002A5B4
		public void SetCursor(Cursor cursor)
		{
			bool flag = cursor.texture != null;
			if (flag)
			{
				Cursor.SetCursor(cursor.texture, cursor.hotspot, CursorMode.Auto);
				this.isCursorOverriden = true;
			}
			else
			{
				bool flag2 = cursor.defaultCursorId != 0;
				if (flag2)
				{
					Debug.LogWarning("Runtime cursors other than the default cursor need to be defined using a texture.");
				}
				this.ResetCursor();
			}
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x0002C418 File Offset: 0x0002A618
		public void ResetCursor()
		{
			bool isCursorOverriden = this.isCursorOverriden;
			if (isCursorOverriden)
			{
				Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
			}
			this.isCursorOverriden = false;
		}
	}
}
