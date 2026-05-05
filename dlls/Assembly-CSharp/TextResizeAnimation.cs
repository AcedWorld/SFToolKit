using System;
using TMPro;
using UnityEngine;

// Token: 0x02000138 RID: 312
public class TextResizeAnimation : MonoBehaviour
{
	// Token: 0x06000507 RID: 1287 RVA: 0x00022904 File Offset: 0x00020B04
	private void Start()
	{
		this.text = base.GetComponent<TMP_Text>();
		this.currentSize = this.minSize;
		this.increasingSize = true;
	}

	// Token: 0x06000508 RID: 1288 RVA: 0x00022925 File Offset: 0x00020B25
	private void OnEnable()
	{
		this.animating = true;
	}

	// Token: 0x06000509 RID: 1289 RVA: 0x00022930 File Offset: 0x00020B30
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
			this.text.fontSize = this.currentSize;
		}
	}

	// Token: 0x040007D4 RID: 2004
	private TMP_Text text;

	// Token: 0x040007D5 RID: 2005
	private bool animating;

	// Token: 0x040007D6 RID: 2006
	public float minSize = 10f;

	// Token: 0x040007D7 RID: 2007
	public float maxSize = 20f;

	// Token: 0x040007D8 RID: 2008
	public float speed = 1f;

	// Token: 0x040007D9 RID: 2009
	private float currentSize;

	// Token: 0x040007DA RID: 2010
	private bool increasingSize;
}
