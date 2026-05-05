using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000076 RID: 118
	public class MousePositionDebug
	{
		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060003AD RID: 941 RVA: 0x0000FFDD File Offset: 0x0000E1DD
		public static MousePositionDebug instance
		{
			get
			{
				if (MousePositionDebug.s_Instance == null)
				{
					MousePositionDebug.s_Instance = new MousePositionDebug();
				}
				return MousePositionDebug.s_Instance;
			}
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0000FFF5 File Offset: 0x0000E1F5
		public void Build()
		{
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0000FFF7 File Offset: 0x0000E1F7
		public void Cleanup()
		{
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0000FFF9 File Offset: 0x0000E1F9
		public Vector2 GetMousePosition(float ScreenHeight, bool sceneView)
		{
			return this.GetInputMousePosition();
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00010001 File Offset: 0x0000E201
		private Vector2 GetInputMousePosition()
		{
			return Input.mousePosition;
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0001000D File Offset: 0x0000E20D
		public Vector2 GetMouseClickPosition(float ScreenHeight)
		{
			return Vector2.zero;
		}

		// Token: 0x04000215 RID: 533
		private static MousePositionDebug s_Instance;
	}
}
