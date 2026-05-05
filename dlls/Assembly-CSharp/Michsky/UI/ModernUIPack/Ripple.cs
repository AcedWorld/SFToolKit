using System;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x02000315 RID: 789
	public class Ripple : MonoBehaviour
	{
		// Token: 0x06001077 RID: 4215 RVA: 0x00057F28 File Offset: 0x00056128
		private void Start()
		{
			base.transform.localScale = new Vector3(0f, 0f, 0f);
			this.colorImg = base.GetComponent<Image>();
			this.colorImg.color = new Color(this.startColor.r, this.startColor.g, this.startColor.b, this.startColor.a);
		}

		// Token: 0x06001078 RID: 4216 RVA: 0x00057F9C File Offset: 0x0005619C
		private void Update()
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(this.maxSize, this.maxSize, this.maxSize), Time.deltaTime * this.speed);
			this.colorImg.color = Color.Lerp(this.colorImg.color, new Color(this.transitionColor.r, this.transitionColor.g, this.transitionColor.b, this.transitionColor.a), Time.deltaTime * this.speed);
			if ((double)base.transform.localScale.x >= (double)this.maxSize * 0.998)
			{
				if (base.transform.parent.childCount == 1)
				{
					base.transform.parent.gameObject.SetActive(false);
				}
				Object.Destroy(base.gameObject);
			}
		}

		// Token: 0x040015B6 RID: 5558
		public float speed;

		// Token: 0x040015B7 RID: 5559
		public float maxSize;

		// Token: 0x040015B8 RID: 5560
		public Color startColor;

		// Token: 0x040015B9 RID: 5561
		public Color transitionColor;

		// Token: 0x040015BA RID: 5562
		private Image colorImg;
	}
}
