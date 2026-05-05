using System;
using Invector;
using Invector.vCharacterController;
using RootMotion.Dynamics;
using RootMotion.FinalIK;

// Token: 0x020001DC RID: 476
[Serializable]
public class CharacterScripts
{
	// Token: 0x04000D18 RID: 3352
	public BipedIK bipedIK;

	// Token: 0x04000D19 RID: 3353
	public vThirdPersonController VThirdPersonController;

	// Token: 0x04000D1A RID: 3354
	public vThirdPersonInput VThirdPersonInput;

	// Token: 0x04000D1B RID: 3355
	public vFootStep VFootStep;

	// Token: 0x04000D1C RID: 3356
	public PuppetMaster puppetMaster;

	// Token: 0x04000D1D RID: 3357
	public BoneAnimator boneAnimator;
}
