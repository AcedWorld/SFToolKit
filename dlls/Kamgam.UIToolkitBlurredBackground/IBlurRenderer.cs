using System;
using UnityEngine;

namespace Kamgam.UGUIBlurredBackground
{
	// Token: 0x02000013 RID: 19
	public interface IBlurRenderer
	{
		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000BF RID: 191
		// (set) Token: 0x060000C0 RID: 192
		int Iterations { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000C1 RID: 193
		// (set) Token: 0x060000C2 RID: 194
		float Offset { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000C3 RID: 195
		// (set) Token: 0x060000C4 RID: 196
		Vector2Int Resolution { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000C5 RID: 197
		// (set) Token: 0x060000C6 RID: 198
		ShaderQuality Quality { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000C7 RID: 199
		// (set) Token: 0x060000C8 RID: 200
		Color AdditiveColor { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000C9 RID: 201
		// (set) Token: 0x060000CA RID: 202
		bool Active { get; set; }

		// Token: 0x060000CB RID: 203
		Texture GetBlurredTexture(RenderMode renderMode);

		// Token: 0x060000CC RID: 204
		void Update();

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x060000CD RID: 205
		// (remove) Token: 0x060000CE RID: 206
		event Action OnPostRender;

		// Token: 0x060000CF RID: 207
		void SetImage(BlurredBackgroundImage image);
	}
}
