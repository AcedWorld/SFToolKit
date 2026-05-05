using System;

namespace Rewired
{
	// Token: 0x02000039 RID: 57
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal struct HardwareControllerMapIdentifier
	{
		// Token: 0x06000212 RID: 530 RVA: 0x00003CCE File Offset: 0x00001ECE
		public HardwareControllerMapIdentifier(Guid A_1, InputSource A_2, InputPlatform A_3, int A_4)
		{
			this.guid = A_1;
			this.inputSource = A_2;
			this.actualInputPlatform = A_3;
			this.variantIndex = A_4;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0002E34C File Offset: 0x0002C54C
		public static bool Matches(HardwareControllerMapIdentifier a, HardwareControllerMapIdentifier b)
		{
			return a.guid == b.guid && a.inputSource == b.inputSource && a.actualInputPlatform == b.actualInputPlatform && a.variantIndex == b.variantIndex;
		}

		// Token: 0x040000F7 RID: 247
		public readonly Guid guid;

		// Token: 0x040000F8 RID: 248
		public readonly InputSource inputSource;

		// Token: 0x040000F9 RID: 249
		public readonly InputPlatform actualInputPlatform;

		// Token: 0x040000FA RID: 250
		public readonly int variantIndex;
	}
}
