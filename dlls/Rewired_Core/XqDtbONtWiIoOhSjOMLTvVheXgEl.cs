using System;
using Rewired;
using Rewired.Interfaces;
using Rewired.Platforms.Custom;
using UnityEngine;

// Token: 0x0200023E RID: 574
internal class XqDtbONtWiIoOhSjOMLTvVheXgEl : BhlfjTlGObGwOdBRJeLDpeideLfDb, IUnifiedMouseSource
{
	// Token: 0x06001A40 RID: 6720 RVA: 0x000156D2 File Offset: 0x000138D2
	public XqDtbONtWiIoOhSjOMLTvVheXgEl(CustomPlatformUnifiedMouseSource A_1) : base(A_1, UnityUnifiedMouseSource.CreateHardwareMap())
	{
	}

	// Token: 0x17000658 RID: 1624
	// (get) Token: 0x06001A41 RID: 6721 RVA: 0x000156E0 File Offset: 0x000138E0
	Vector2 IUnifiedMouseSource.mousePosition
	{
		get
		{
			return ((CustomPlatformUnifiedMouseSource)this.SMfjVbxMEJEZMpylRcGtwXfQinVT).mousePosition;
		}
	}
}
