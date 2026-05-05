using System;
using UnityEngine;
using UnityEngine.UI;

namespace Invector
{
	// Token: 0x02000387 RID: 903
	public class vImageColorChange : MonoBehaviour
	{
		// Token: 0x0600124C RID: 4684 RVA: 0x00061241 File Offset: 0x0005F441
		public void ChangeColor(int colorIndex)
		{
			if (this.colors.Length != 0 && colorIndex < this.colors.Length)
			{
				this.image.color = this.colors[colorIndex];
			}
		}

		// Token: 0x04001818 RID: 6168
		public Image image;

		// Token: 0x04001819 RID: 6169
		public Color[] colors;
	}
}
