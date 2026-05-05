using System;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000021 RID: 33
	[RequireComponent(typeof(Collider))]
	internal class VFXMouseEventBinder : VFXEventBinderBase
	{
		// Token: 0x060000A8 RID: 168 RVA: 0x000068C4 File Offset: 0x00004AC4
		protected override void SetEventAttribute(object[] parameters)
		{
			if (this.RaycastMousePosition)
			{
				Ray ray = Camera.main.ScreenPointToRay(VFXMouseEventBinder.GetMousePosition());
				RaycastHit raycastHit;
				if (base.GetComponent<Collider>().Raycast(ray, out raycastHit, 3.4028235E+38f))
				{
					this.eventAttribute.SetVector3(this.position, raycastHit.point);
				}
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00006920 File Offset: 0x00004B20
		private static Vector2 GetMousePosition()
		{
			return Input.mousePosition;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000692C File Offset: 0x00004B2C
		private void DoOnMouseDown()
		{
			if (this.activation == VFXMouseEventBinder.Activation.OnMouseDown)
			{
				base.SendEventToVisualEffect(Array.Empty<object>());
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00006942 File Offset: 0x00004B42
		private void DoOnMouseUp()
		{
			if (this.activation == VFXMouseEventBinder.Activation.OnMouseUp)
			{
				base.SendEventToVisualEffect(Array.Empty<object>());
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00006957 File Offset: 0x00004B57
		private void DoOnMouseDrag()
		{
			if (this.activation == VFXMouseEventBinder.Activation.OnMouseDrag)
			{
				base.SendEventToVisualEffect(Array.Empty<object>());
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000696D File Offset: 0x00004B6D
		private void DoOnMouseOver()
		{
			if (this.activation == VFXMouseEventBinder.Activation.OnMouseOver)
			{
				base.SendEventToVisualEffect(Array.Empty<object>());
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00006983 File Offset: 0x00004B83
		private void DoOnMouseEnter()
		{
			if (this.activation == VFXMouseEventBinder.Activation.OnMouseEnter)
			{
				base.SendEventToVisualEffect(Array.Empty<object>());
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00006999 File Offset: 0x00004B99
		private void DoOnMouseExit()
		{
			if (this.activation == VFXMouseEventBinder.Activation.OnMouseExit)
			{
				base.SendEventToVisualEffect(Array.Empty<object>());
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000069AF File Offset: 0x00004BAF
		private void OnMouseDown()
		{
			this.DoOnMouseDown();
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000069B7 File Offset: 0x00004BB7
		private void OnMouseUp()
		{
			this.DoOnMouseUp();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000069BF File Offset: 0x00004BBF
		private void OnMouseDrag()
		{
			this.DoOnMouseDrag();
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000069C7 File Offset: 0x00004BC7
		private void OnMouseOver()
		{
			this.DoOnMouseOver();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000069CF File Offset: 0x00004BCF
		private void OnMouseEnter()
		{
			this.DoOnMouseEnter();
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x000069D7 File Offset: 0x00004BD7
		private void OnMouseExit()
		{
			this.DoOnMouseExit();
		}

		// Token: 0x04000087 RID: 135
		public VFXMouseEventBinder.Activation activation = VFXMouseEventBinder.Activation.OnMouseDown;

		// Token: 0x04000088 RID: 136
		private ExposedProperty position = "position";

		// Token: 0x04000089 RID: 137
		[Tooltip("Computes intersection in world space and sets it to the position EventAttribute")]
		public bool RaycastMousePosition;

		// Token: 0x02000060 RID: 96
		public enum Activation
		{
			// Token: 0x040001D5 RID: 469
			OnMouseUp,
			// Token: 0x040001D6 RID: 470
			OnMouseDown,
			// Token: 0x040001D7 RID: 471
			OnMouseEnter,
			// Token: 0x040001D8 RID: 472
			OnMouseExit,
			// Token: 0x040001D9 RID: 473
			OnMouseOver,
			// Token: 0x040001DA RID: 474
			OnMouseDrag
		}
	}
}
