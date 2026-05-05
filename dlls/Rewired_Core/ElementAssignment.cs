using System;
using UnityEngine;

namespace Rewired
{
	// Token: 0x0200000A RID: 10
	public struct ElementAssignment
	{
		// Token: 0x060000C8 RID: 200 RVA: 0x0002B79C File Offset: 0x0002999C
		public ElementAssignment(ElementAssignmentType A_1, int A_2, AxisRange A_3, KeyCode A_4, ModifierKeyFlags A_5, int A_6, Pole A_7, bool A_8, int A_9)
		{
			this.type = A_1;
			this.elementIdentifierId = A_2;
			this.axisRange = A_3;
			this.keyboardKey = A_4;
			this.modifierKeyFlags = A_5;
			this.actionId = A_6;
			this.axisContribution = A_7;
			this.invert = A_8;
			this.elementMapId = A_9;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0002B7F0 File Offset: 0x000299F0
		public ElementAssignment(ControllerType A_1, ControllerElementType A_2, int A_3, AxisRange A_4, KeyCode A_5, ModifierKeyFlags A_6, int A_7, Pole A_8, bool A_9, int A_10)
		{
			this.type = gRvITEHjKMrWaeGYEmAHofbpCtEU.blpgmPnHOmuTkwCcZxdMASHDrVcg(A_1, A_2, A_4);
			this.elementIdentifierId = A_3;
			this.axisRange = A_4;
			this.keyboardKey = A_5;
			this.modifierKeyFlags = A_6;
			this.actionId = A_7;
			this.axisContribution = A_8;
			this.invert = A_9;
			this.elementMapId = A_10;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0002B84C File Offset: 0x00029A4C
		public ElementAssignment(ElementAssignmentType A_1, int A_2, AxisRange A_3, KeyCode A_4, ModifierKeyFlags A_5, int A_6, Pole A_7, bool A_8)
		{
			this.type = A_1;
			this.elementIdentifierId = A_2;
			this.axisRange = A_3;
			this.keyboardKey = A_4;
			this.modifierKeyFlags = A_5;
			this.actionId = A_6;
			this.axisContribution = A_7;
			this.invert = A_8;
			this.elementMapId = -1;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0002B8A0 File Offset: 0x00029AA0
		public ElementAssignment(ControllerType A_1, ControllerElementType A_2, int A_3, AxisRange A_4, KeyCode A_5, ModifierKeyFlags A_6, int A_7, Pole A_8, bool A_9)
		{
			this.type = gRvITEHjKMrWaeGYEmAHofbpCtEU.blpgmPnHOmuTkwCcZxdMASHDrVcg(A_1, A_2, A_4);
			this.elementIdentifierId = A_3;
			this.axisRange = A_4;
			this.keyboardKey = A_5;
			this.modifierKeyFlags = A_6;
			this.actionId = A_7;
			this.axisContribution = A_8;
			this.invert = A_9;
			this.elementMapId = -1;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0002B8FC File Offset: 0x00029AFC
		public ElementAssignment(int A_1, int A_2, bool A_3)
		{
			this.type = ElementAssignmentType.FullAxis;
			this.elementIdentifierId = A_1;
			this.axisRange = AxisRange.Full;
			this.keyboardKey = KeyCode.None;
			this.modifierKeyFlags = ModifierKeyFlags.None;
			this.actionId = A_2;
			this.axisContribution = Pole.Positive;
			this.invert = A_3;
			this.elementMapId = -1;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0002B948 File Offset: 0x00029B48
		public ElementAssignment(int A_1, int A_2, bool A_3, int A_4)
		{
			this.type = ElementAssignmentType.FullAxis;
			this.elementIdentifierId = A_1;
			this.axisRange = AxisRange.Full;
			this.keyboardKey = KeyCode.None;
			this.modifierKeyFlags = ModifierKeyFlags.None;
			this.actionId = A_2;
			this.axisContribution = Pole.Positive;
			this.invert = A_3;
			this.elementMapId = A_4;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0002B998 File Offset: 0x00029B98
		public ElementAssignment(int A_1, AxisRange A_2, int A_3, Pole A_4)
		{
			this.type = ElementAssignmentType.SplitAxis;
			this.elementIdentifierId = A_1;
			this.axisRange = A_2;
			this.keyboardKey = KeyCode.None;
			this.modifierKeyFlags = ModifierKeyFlags.None;
			this.actionId = A_3;
			this.axisContribution = A_4;
			this.invert = false;
			this.elementMapId = -1;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0002B9E8 File Offset: 0x00029BE8
		public ElementAssignment(int A_1, AxisRange A_2, int A_3, Pole A_4, int A_5)
		{
			this.type = ElementAssignmentType.SplitAxis;
			this.elementIdentifierId = A_1;
			this.axisRange = A_2;
			this.keyboardKey = KeyCode.None;
			this.modifierKeyFlags = ModifierKeyFlags.None;
			this.actionId = A_3;
			this.axisContribution = A_4;
			this.invert = false;
			this.elementMapId = A_5;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0002BA38 File Offset: 0x00029C38
		public ElementAssignment(int A_1, int A_2, Pole A_3)
		{
			this.type = ElementAssignmentType.Button;
			this.elementIdentifierId = A_1;
			this.axisRange = AxisRange.Positive;
			this.keyboardKey = KeyCode.None;
			this.modifierKeyFlags = ModifierKeyFlags.None;
			this.actionId = A_2;
			this.axisContribution = A_3;
			this.invert = false;
			this.elementMapId = -1;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0002BA84 File Offset: 0x00029C84
		public ElementAssignment(int A_1, int A_2, Pole A_3, int A_4)
		{
			this.type = ElementAssignmentType.Button;
			this.elementIdentifierId = A_1;
			this.axisRange = AxisRange.Positive;
			this.keyboardKey = KeyCode.None;
			this.modifierKeyFlags = ModifierKeyFlags.None;
			this.actionId = A_2;
			this.axisContribution = A_3;
			this.invert = false;
			this.elementMapId = A_4;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0002BAD4 File Offset: 0x00029CD4
		public ElementAssignment(KeyCode A_1, ModifierKeyFlags A_2, int A_3, Pole A_4)
		{
			this.type = ElementAssignmentType.KeyboardKey;
			this.elementIdentifierId = Keyboard.IFoSAsBTTtpfVdkaUlCcapmfGYci(Keyboard.VsDTJkbqYgxyNEBuoIqHeiiGBbXu(A_1));
			this.axisRange = AxisRange.Positive;
			this.keyboardKey = A_1;
			this.modifierKeyFlags = A_2;
			this.actionId = A_3;
			this.axisContribution = A_4;
			this.invert = false;
			this.elementMapId = -1;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0002BB2C File Offset: 0x00029D2C
		public ElementAssignment(KeyCode A_1, ModifierKeyFlags A_2, int A_3, Pole A_4, int A_5)
		{
			this.type = ElementAssignmentType.KeyboardKey;
			this.elementIdentifierId = Keyboard.IFoSAsBTTtpfVdkaUlCcapmfGYci(Keyboard.VsDTJkbqYgxyNEBuoIqHeiiGBbXu(A_1));
			this.axisRange = AxisRange.Positive;
			this.keyboardKey = A_1;
			this.modifierKeyFlags = A_2;
			this.actionId = A_3;
			this.axisContribution = A_4;
			this.invert = false;
			this.elementMapId = A_5;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0002BB84 File Offset: 0x00029D84
		public static ElementAssignment CompleteAssignment(ElementAssignmentType elementAssignmentType, int elementIdentifierId, AxisRange axisRange, KeyCode keyboardKey, ModifierKeyFlags modifierKeyFlags, int actionId, Pole axisContribution, bool invert, int elementMapId)
		{
			return new ElementAssignment(elementAssignmentType, elementIdentifierId, axisRange, keyboardKey, modifierKeyFlags, actionId, axisContribution, invert, elementMapId);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0002BBA4 File Offset: 0x00029DA4
		public static ElementAssignment CompleteAssignment(ControllerType controllerType, ControllerElementType elementType, int elementIdentifierId, AxisRange axisRange, KeyCode keyboardKey, ModifierKeyFlags modifierKeyFlags, int actionId, Pole axisContribution, bool invert, int elementMapId)
		{
			return new ElementAssignment(controllerType, elementType, elementIdentifierId, axisRange, keyboardKey, modifierKeyFlags, actionId, axisContribution, invert, elementMapId);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00002C47 File Offset: 0x00000E47
		public static ElementAssignment CompleteAssignment(ElementAssignmentType elementAssignmentType, int elementIdentifierId, AxisRange axisRange, KeyCode keyboardKey, ModifierKeyFlags modifierKeyFlags, int actionId, Pole axisContribution, bool invert)
		{
			return new ElementAssignment(elementAssignmentType, elementIdentifierId, axisRange, keyboardKey, modifierKeyFlags, actionId, axisContribution, invert);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0002BBC8 File Offset: 0x00029DC8
		public static ElementAssignment CompleteAssignment(ControllerType controllerType, ControllerElementType elementType, int elementIdentifierId, AxisRange axisRange, KeyCode keyboardKey, ModifierKeyFlags modifierKeyFlags, int actionId, Pole axisContribution, bool invert)
		{
			return new ElementAssignment(controllerType, elementType, elementIdentifierId, axisRange, keyboardKey, modifierKeyFlags, actionId, axisContribution, invert);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00002C5A File Offset: 0x00000E5A
		public static ElementAssignment FullAxisAssignment(int elementIdentifierId, int actionId, bool invert)
		{
			return new ElementAssignment(elementIdentifierId, actionId, invert);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00002C64 File Offset: 0x00000E64
		public static ElementAssignment FullAxisAssignment(int elementIdentifierId, int actionId, bool invert, int elementMapId)
		{
			return new ElementAssignment(elementIdentifierId, actionId, invert, elementMapId);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00002C6F File Offset: 0x00000E6F
		public static ElementAssignment SplitAxisAssignment(int elementIdentifierId, AxisRange axisRange, int actionId, Pole axisContribution)
		{
			return new ElementAssignment(elementIdentifierId, axisRange, actionId, axisContribution);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00002C7A File Offset: 0x00000E7A
		public static ElementAssignment SplitAxisAssignment(int elementIdentifierId, AxisRange axisRange, int actionId, Pole axisContribution, int elementMapId)
		{
			return new ElementAssignment(elementIdentifierId, axisRange, actionId, axisContribution, elementMapId);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00002C87 File Offset: 0x00000E87
		public static ElementAssignment ButtonAssignment(int elementIdentifierId, int actionId, Pole axisContribution)
		{
			return new ElementAssignment(elementIdentifierId, actionId, axisContribution);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00002C91 File Offset: 0x00000E91
		public static ElementAssignment ButtonAssignment(int elementIdentifierId, int actionId, Pole axisContribution, int elementMapId)
		{
			return new ElementAssignment(elementIdentifierId, actionId, axisContribution, elementMapId);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00002C9C File Offset: 0x00000E9C
		public static ElementAssignment KeyboardKeyAssignment(KeyCode keyboardKey, ModifierKeyFlags modifierKeyFlags, int actionId, Pole axisContribution)
		{
			return new ElementAssignment(keyboardKey, modifierKeyFlags, actionId, axisContribution);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00002CA7 File Offset: 0x00000EA7
		public static ElementAssignment KeyboardKeyAssignment(KeyCode keyboardKey, ModifierKeyFlags modifierKeyFlags, int actionId, Pole axisContribution, int elementMapId)
		{
			return new ElementAssignment(keyboardKey, modifierKeyFlags, actionId, axisContribution, elementMapId);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0002BBE8 File Offset: 0x00029DE8
		public ElementAssignmentConflictCheck ToElementAssignmentConflictCheck()
		{
			return new ElementAssignmentConflictCheck
			{
				playerId = -1,
				controllerType = ControllerType.Keyboard,
				controllerId = -1,
				controllerMapId = -1,
				controllerMapCategoryId = -1,
				elementAssignmentType = this.type,
				elementIdentifierId = this.elementIdentifierId,
				axisRange = this.axisRange,
				keyboardKey = this.keyboardKey,
				modifierKeyFlags = this.modifierKeyFlags,
				actionId = this.actionId,
				axisContribution = this.axisContribution,
				invert = this.invert,
				elementMapId = this.elementMapId
			};
		}

		// Token: 0x04000034 RID: 52
		public ElementAssignmentType type;

		// Token: 0x04000035 RID: 53
		public int elementMapId;

		// Token: 0x04000036 RID: 54
		public int elementIdentifierId;

		// Token: 0x04000037 RID: 55
		public AxisRange axisRange;

		// Token: 0x04000038 RID: 56
		public KeyCode keyboardKey;

		// Token: 0x04000039 RID: 57
		public ModifierKeyFlags modifierKeyFlags;

		// Token: 0x0400003A RID: 58
		public int actionId;

		// Token: 0x0400003B RID: 59
		public Pole axisContribution;

		// Token: 0x0400003C RID: 60
		public bool invert;
	}
}
