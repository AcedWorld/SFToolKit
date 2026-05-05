using System;
using UnityEngine;
using UnityEngine.Events;

namespace Invector.vCharacterController.vActions
{
	// Token: 0x02000420 RID: 1056
	[vClassHeader("Trigger Ladder Action", false, "icon_v2", false, "")]
	public class vTriggerLadderAction : vMonoBehaviour
	{
		// Token: 0x04001BCB RID: 7115
		[vEditorToolbar("Settings", false, "", false, false)]
		[Header("Trigger Action Options")]
		[Tooltip("Automatically execute the action without the need to press a Button")]
		public bool autoAction;

		// Token: 0x04001BCC RID: 7116
		[Header("Enter")]
		[Tooltip("Trigger an Animation - Use the exactly same name of the AnimationState you want to trigger")]
		public string playAnimation;

		// Token: 0x04001BCD RID: 7117
		[Header("Exit")]
		[Tooltip("Trigger an Animation - Use the exactly same name of the AnimationState you want to trigger")]
		public string exitAnimation;

		// Token: 0x04001BCE RID: 7118
		[Tooltip("Use this to limit the trigger to active if forward of character is close to this forward")]
		public bool activeFromForward;

		// Token: 0x04001BCF RID: 7119
		[Tooltip("Rotate Character for this rotation when active")]
		public bool useTriggerRotation;

		// Token: 0x04001BD0 RID: 7120
		[Tooltip("Target Character parent, used to movable ladders to set character child of target, keep empty if ladder is static")]
		public Transform targetCharacterParent;

		// Token: 0x04001BD1 RID: 7121
		[vEditorToolbar("MatchTarget", false, "", false, false)]
		[Tooltip("Use a transform to help the character climb any height, take a look at the Example Scene ClimbUp, StepUp, JumpOver objects.")]
		public Transform matchTarget;

		// Token: 0x04001BD2 RID: 7122
		[Tooltip("Use a empty gameObject as a reference for the character to exit")]
		public Transform exitMatchTarget;

		// Token: 0x04001BD3 RID: 7123
		public AnimationCurve enterPositionXZCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(1f, 1f)
		});

		// Token: 0x04001BD4 RID: 7124
		public AnimationCurve enterPositionYCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(1f, 1f)
		});

		// Token: 0x04001BD5 RID: 7125
		public AnimationCurve exitPositionXZCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(1f, 1f)
		});

		// Token: 0x04001BD6 RID: 7126
		public AnimationCurve exitPositionYCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(1f, 1f)
		});

		// Token: 0x04001BD7 RID: 7127
		public AnimationCurve enterRotationCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(1f, 1f)
		});

		// Token: 0x04001BD8 RID: 7128
		public AnimationCurve exitRotationCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(1f, 1f)
		});

		// Token: 0x04001BD9 RID: 7129
		public UnityEvent OnDoAction;

		// Token: 0x04001BDA RID: 7130
		public UnityEvent OnPlayerEnter;

		// Token: 0x04001BDB RID: 7131
		public UnityEvent OnPlayerStay;

		// Token: 0x04001BDC RID: 7132
		public UnityEvent OnPlayerExit;
	}
}
