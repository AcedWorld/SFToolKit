using System;
using Invector;
using UnityEngine;

// Token: 0x02000040 RID: 64
public class vUIIndicatorPosition : MonoBehaviour
{
	// Token: 0x060000F3 RID: 243 RVA: 0x00008C74 File Offset: 0x00006E74
	private void Start()
	{
		this._camera = Camera.main;
		if (this.canvas == null)
		{
			this.canvas = base.GetComponentInParent<Canvas>();
		}
		if (this.container == null)
		{
			this.container = base.GetComponentInParent<RectTransform>();
		}
		this.rectTransform = base.GetComponent<RectTransform>();
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x00008CCC File Offset: 0x00006ECC
	public void Update()
	{
		if (this.canvas && this.referencePosition)
		{
			this.rectTransform.anchoredPosition = this.ClampToWindow();
		}
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x00008CFC File Offset: 0x00006EFC
	private Vector2 ClampToWindow()
	{
		Vector3 point = this.referencePosition.position - this._camera.transform.position;
		Vector3 vector = this._camera.transform.forward.AngleFormOtherDirection(point.normalized);
		float t = Mathf.Clamp(Mathf.Abs(vector.y) - 60f, 0f, 20f) / 20f;
		Vector3 position = this.referencePosition.position;
		Vector3 b = position + Quaternion.AngleAxis(-vector.y, Vector3.up) * point;
		return this.canvas.WorldToCanvas(Vector3.Lerp(position, b, t), this._camera).ClampInsideRectagle(this.container, this.rectTransform.rect.size);
	}

	// Token: 0x04000123 RID: 291
	public Transform referencePosition;

	// Token: 0x04000124 RID: 292
	public RectTransform container;

	// Token: 0x04000125 RID: 293
	public Canvas canvas;

	// Token: 0x04000126 RID: 294
	protected RectTransform rectTransform;

	// Token: 0x04000127 RID: 295
	protected Camera _camera;
}
