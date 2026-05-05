using System;
using UnityEngine;

// Token: 0x02000135 RID: 309
public class ImageResizeAnimation : MonoBehaviour
{
	// Token: 0x060004F5 RID: 1269 RVA: 0x0002255A File Offset: 0x0002075A
	private void Start()
	{
		this.rectTransform = base.GetComponent<RectTransform>();
		this.currentSize = this.minSize;
		this.increasingSize = true;
	}

	// Token: 0x060004F6 RID: 1270 RVA: 0x0002257B File Offset: 0x0002077B
	private void OnEnable()
	{
		this.animating = true;
	}

	// Token: 0x060004F7 RID: 1271 RVA: 0x00022584 File Offset: 0x00020784
	private void Update()
	{
		if (this.animating)
		{
			if (this.increasingSize)
			{
				this.currentSize += this.speed * Time.deltaTime;
				if (this.currentSize > this.maxSize)
				{
					this.currentSize = this.maxSize;
					this.increasingSize = false;
				}
			}
			else
			{
				this.currentSize -= this.speed * Time.deltaTime;
				if (this.currentSize < this.minSize)
				{
					this.currentSize = this.minSize;
					this.increasingSize = true;
				}
			}
			this.rectTransform.localScale = new Vector3(this.currentSize, this.currentSize, 1f);
		}
	}

	// Token: 0x040007C5 RID: 1989
	private RectTransform rectTransform;

	// Token: 0x040007C6 RID: 1990
	private bool animating;

	// Token: 0x040007C7 RID: 1991
	public float minSize = 0.5f;

	// Token: 0x040007C8 RID: 1992
	public float maxSize = 1f;

	// Token: 0x040007C9 RID: 1993
	public float speed = 1f;

	// Token: 0x040007CA RID: 1994
	private float currentSize;

	// Token: 0x040007CB RID: 1995
	private bool increasingSize;
}
