using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000331 RID: 817
	public class vAnimateUV : MonoBehaviour
	{
		// Token: 0x060010E3 RID: 4323 RVA: 0x0005B5C8 File Offset: 0x000597C8
		private void Update()
		{
			this.offSet.x = this.offSet.x + this.speed.x * Time.deltaTime;
			this.offSet.y = this.offSet.y + this.speed.y * Time.deltaTime;
			for (int i = 0; i < this.textureParameters.Length; i++)
			{
				this._renderer.material.SetTextureOffset(this.textureParameters[i], this.offSet);
			}
		}

		// Token: 0x040016AC RID: 5804
		public Vector2 speed;

		// Token: 0x040016AD RID: 5805
		public Renderer _renderer;

		// Token: 0x040016AE RID: 5806
		public string[] textureParameters = new string[]
		{
			"_MainTex"
		};

		// Token: 0x040016AF RID: 5807
		private Vector2 offSet;
	}
}
