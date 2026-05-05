using System;

namespace Rewired.Interfaces
{
	// Token: 0x020001E4 RID: 484
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	internal interface IInputManagerJoystickPublic
	{
		// Token: 0x170005F0 RID: 1520
		// (get) Token: 0x060018B0 RID: 6320
		int rewiredId { get; }

		// Token: 0x170005F1 RID: 1521
		// (get) Token: 0x060018B1 RID: 6321
		int inputManagerId { get; }

		// Token: 0x170005F2 RID: 1522
		// (get) Token: 0x060018B2 RID: 6322
		string name { get; }

		// Token: 0x170005F3 RID: 1523
		// (get) Token: 0x060018B3 RID: 6323
		long? systemId { get; }

		// Token: 0x170005F4 RID: 1524
		// (get) Token: 0x060018B4 RID: 6324
		int unityId { get; }

		// Token: 0x170005F5 RID: 1525
		// (get) Token: 0x060018B5 RID: 6325
		Controller.Extension extension { get; }

		// Token: 0x170005F6 RID: 1526
		// (get) Token: 0x060018B6 RID: 6326
		Guid instanceGuid { get; }

		// Token: 0x170005F7 RID: 1527
		// (get) Token: 0x060018B7 RID: 6327
		Guid persistentGuid { get; }

		// Token: 0x060018B8 RID: 6328
		void SetVibration(float amount, int motorIndex);

		// Token: 0x060018B9 RID: 6329
		void StopVibration();
	}
}
