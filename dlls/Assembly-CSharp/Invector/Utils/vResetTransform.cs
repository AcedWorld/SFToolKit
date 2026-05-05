using System;
using UnityEngine;

namespace Invector.Utils
{
	// Token: 0x020003BD RID: 957
	[vClassHeader("Reset Transform", true, "icon_v2", false, "", useHelpBox = true, helpBoxText = "Use this to Reset transformation values<b><color=red>\nPosition Zero\nRotation Zero\nScale One</color> </b>", openClose = false)]
	public class vResetTransform : vMonoBehaviour
	{
		// Token: 0x06001319 RID: 4889 RVA: 0x000649C8 File Offset: 0x00062BC8
		private void Start()
		{
			if (this.resetPositionOnStart)
			{
				this.ResetPosition();
			}
			if (this.resetRotationOnStart)
			{
				this.ResetRotation();
			}
			if (this.resetScaleOnStart)
			{
				this.ResetScale();
			}
		}

		// Token: 0x0600131A RID: 4890 RVA: 0x000649F4 File Offset: 0x00062BF4
		public void ResetRotation()
		{
			if (base.transform.parent)
			{
				base.transform.localEulerAngles = Vector3.zero;
				return;
			}
			base.transform.eulerAngles = Vector3.zero;
		}

		// Token: 0x0600131B RID: 4891 RVA: 0x00064A29 File Offset: 0x00062C29
		public void ResetPosition()
		{
			if (base.transform.parent)
			{
				base.transform.localPosition = Vector3.zero;
				return;
			}
			base.transform.position = Vector3.zero;
		}

		// Token: 0x0600131C RID: 4892 RVA: 0x00064A5E File Offset: 0x00062C5E
		public void ResetScale()
		{
			base.transform.localScale = Vector3.one;
		}

		// Token: 0x040018E3 RID: 6371
		public bool resetPositionOnStart;

		// Token: 0x040018E4 RID: 6372
		public bool resetRotationOnStart;

		// Token: 0x040018E5 RID: 6373
		public bool resetScaleOnStart;
	}
}
