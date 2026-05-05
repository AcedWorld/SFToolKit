using System;
using System.ComponentModel;
using UnityEngine.Internal;

namespace UnityEngine
{
	// Token: 0x02000016 RID: 22
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("GUIElement has been removed. Consider using https://docs.unity3d.com/ScriptReference/UIElements.Image.html, https://docs.unity3d.com/ScriptReference/UIElements.TextElement.html or TextMeshPro instead.", true)]
	[ExcludeFromObjectFactory]
	[ExcludeFromPreset]
	public sealed class GUIElement
	{
		// Token: 0x060001B1 RID: 433 RVA: 0x00007E40 File Offset: 0x00006040
		private static void FeatureRemoved()
		{
			throw new Exception("GUIElement has been removed from Unity. Consider using https://docs.unity3d.com/ScriptReference/UIElements.Image.html, https://docs.unity3d.com/ScriptReference/UIElements.TextElement.html or TextMeshPro instead.");
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00007E50 File Offset: 0x00006050
		[Obsolete("GUIElement has been removed. Consider using https://docs.unity3d.com/ScriptReference/UIElements.Image.html, https://docs.unity3d.com/ScriptReference/UIElements.TextElement.html or TextMeshPro instead.", true)]
		public bool HitTest(Vector3 screenPosition)
		{
			GUIElement.FeatureRemoved();
			return false;
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00007E6C File Offset: 0x0000606C
		[Obsolete("GUIElement has been removed. Consider using https://docs.unity3d.com/ScriptReference/UIElements.Image.html, https://docs.unity3d.com/ScriptReference/UIElements.TextElement.html or TextMeshPro instead.", true)]
		public bool HitTest(Vector3 screenPosition, [DefaultValue("null")] Camera camera)
		{
			GUIElement.FeatureRemoved();
			return false;
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00007E88 File Offset: 0x00006088
		[Obsolete("GUIElement has been removed. Consider using https://docs.unity3d.com/ScriptReference/UIElements.Image.html, https://docs.unity3d.com/ScriptReference/UIElements.TextElement.html or TextMeshPro instead.", true)]
		public Rect GetScreenRect([DefaultValue("null")] Camera camera)
		{
			GUIElement.FeatureRemoved();
			return new Rect(0f, 0f, 0f, 0f);
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00007EBC File Offset: 0x000060BC
		[Obsolete("GUIElement has been removed. Consider using https://docs.unity3d.com/ScriptReference/UIElements.Image.html, https://docs.unity3d.com/ScriptReference/UIElements.TextElement.html or TextMeshPro instead.", true)]
		public Rect GetScreenRect()
		{
			GUIElement.FeatureRemoved();
			return new Rect(0f, 0f, 0f, 0f);
		}
	}
}
