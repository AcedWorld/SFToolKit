using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Invector.vCharacterController.vActions
{
	// Token: 0x0200041B RID: 1051
	[vClassHeader("Trigger Generic Action", false, "icon_v2", false, "", iconName = "triggerIcon")]
	public class vTriggerGenericAction : vMonoBehaviour
	{
		// Token: 0x060015DB RID: 5595 RVA: 0x00072C50 File Offset: 0x00070E50
		protected virtual void Start()
		{
			base.gameObject.tag = this.actionTag;
			base.gameObject.layer = LayerMask.NameToLayer("Triggers");
			this._collider = base.GetComponent<Collider>();
			this._collider.isTrigger = true;
			if (this.disableOnStart)
			{
				base.enabled = false;
			}
		}

		// Token: 0x060015DC RID: 5596 RVA: 0x00072CAA File Offset: 0x00070EAA
		public virtual IEnumerator OnPressActionDelay(GameObject obj)
		{
			yield return new WaitForSeconds(this.onPressActionDelay);
			this.OnPressActionInput.Invoke();
			if (obj)
			{
				this.onPressActionInputWithTarget.Invoke(obj);
			}
			yield break;
		}

		// Token: 0x060015DD RID: 5597 RVA: 0x00072CC0 File Offset: 0x00070EC0
		public void UpdateButtonTimer(float value)
		{
			if (value != this.currentButtonTimer)
			{
				this.currentButtonTimer = value;
				this.OnUpdateButtonTimer.Invoke(value);
			}
		}

		// Token: 0x04001B94 RID: 7060
		[vEditorToolbar("Input", false, "", false, false, order = 1)]
		public vTriggerGenericAction.InputType inputType;

		// Token: 0x04001B95 RID: 7061
		[Tooltip("Input to make the action")]
		public GenericInput actionInput = new GenericInput("E", "A", "A");

		// Token: 0x04001B96 RID: 7062
		[vHelpBox("Time you have to hold the button *Only for GetButtonTimer*", vHelpBoxAttribute.MessageType.None)]
		public float buttonTimer = 3f;

		// Token: 0x04001B97 RID: 7063
		[vHelpBox("Add delay to start the input count *Only for GetButtonTimer*", vHelpBoxAttribute.MessageType.None)]
		public float inputDelay = 0.1f;

		// Token: 0x04001B98 RID: 7064
		[vHelpBox("*Only for GetButtonTimer* \n\n<b>TRUE: </b> Play the animation while you're holding the button \n<b>FALSE: </b>Play the animation after you finish holding the button", vHelpBoxAttribute.MessageType.None)]
		public bool playAnimationWhileHoldingButton = true;

		// Token: 0x04001B99 RID: 7065
		[vHelpBox("Time to press the button twice *Only for GetDoubleButton*", vHelpBoxAttribute.MessageType.None)]
		public float doubleButtomTime = 0.25f;

		// Token: 0x04001B9A RID: 7066
		[vEditorToolbar("Trigger", false, "", false, false, order = 2)]
		public string actionName = "Action";

		// Token: 0x04001B9B RID: 7067
		public string actionTag = "Action";

		// Token: 0x04001B9C RID: 7068
		[vHelpBox("Disable this trigger OnStart", vHelpBoxAttribute.MessageType.None)]
		public bool disableOnStart;

		// Token: 0x04001B9D RID: 7069
		[vHelpBox("Disable the Player's Capsule Collider Collision, useful for animations with closer interactions", vHelpBoxAttribute.MessageType.None)]
		public bool disableCollision;

		// Token: 0x04001B9E RID: 7070
		[vHelpBox("Disable the Player's Rigidbody Gravity, useful for on air animations", vHelpBoxAttribute.MessageType.None)]
		public bool disableGravity;

		// Token: 0x04001B9F RID: 7071
		[vHelpBox("It will only use the trigger if the forward of the character is close to the forward of this transform", vHelpBoxAttribute.MessageType.None)]
		public bool activeFromForward;

		// Token: 0x04001BA0 RID: 7072
		[vHelpBox("Max angle between character forward and trigger forward to active trigger", vHelpBoxAttribute.MessageType.None)]
		[Range(5f, 180f)]
		public float forwardAngle = 55f;

		// Token: 0x04001BA1 RID: 7073
		[vHelpBox("Rotate Character to the Forward Rotation of this Trigger", vHelpBoxAttribute.MessageType.None)]
		public bool useTriggerRotation;

		// Token: 0x04001BA2 RID: 7074
		[vHelpBox("Destroy this Trigger after pressing the Input or AutoAction or finishing the Action", vHelpBoxAttribute.MessageType.None)]
		public bool destroyAfter;

		// Token: 0x04001BA3 RID: 7075
		[vHideInInspector("destroyAfter", false)]
		public float destroyDelay;

		// Token: 0x04001BA4 RID: 7076
		[vHelpBox("Change your CameraState to a Custom State while playing the animation", vHelpBoxAttribute.MessageType.None)]
		public string customCameraState;

		// Token: 0x04001BA5 RID: 7077
		[vEditorToolbar("Animation", false, "", false, false, order = 2)]
		[vHelpBox("Trigger a Animation - Use the exactly same name of the AnimationState you want to trigger, don't forget to add a vAnimatorTag to your State", vHelpBoxAttribute.MessageType.None)]
		public string playAnimation;

		// Token: 0x04001BA6 RID: 7078
		public float crossFadeTransition = 0.25f;

		// Token: 0x04001BA7 RID: 7079
		public int animatorLayer;

		// Token: 0x04001BA8 RID: 7080
		[vHelpBox("Check the Exit Time of your animation (if it doesn't loop) and insert here. \n\nFor example if your Exit Time is 0.82 you need to insert 0.82\n\nAlways check with the Debug of the GenericAction if your animation is finishing correctly, otherwise the controller won't reset to the default physics and collision.", vHelpBoxAttribute.MessageType.Warning)]
		[Tooltip("You can use this to make a persistent action, and finish the action calling FinishAction method of the vGenericAction  component in your character")]
		public bool endActionManualy;

		// Token: 0x04001BA9 RID: 7081
		[vHideInInspector("endActionManualy", false, invertValue = true)]
		public float endExitTimeAnimation = 0.8f;

		// Token: 0x04001BAA RID: 7082
		[vHelpBox("Use a ActionState value to apply special conditions for your AnimatorController transitions", vHelpBoxAttribute.MessageType.None)]
		public int animatorActionState;

		// Token: 0x04001BAB RID: 7083
		[vHelpBox("Reset the ActionState parameter to 0 after playing the animation", vHelpBoxAttribute.MessageType.None)]
		public bool resetAnimatorActionState = true;

		// Token: 0x04001BAC RID: 7084
		[vHelpBox("Use a empty transform as reference for the MatchTarget", vHelpBoxAttribute.MessageType.None)]
		public Transform matchTarget;

		// Token: 0x04001BAD RID: 7085
		[vHelpBox("Select the bone you want to use as reference to the Match Target", vHelpBoxAttribute.MessageType.None)]
		public AvatarTarget avatarTarget;

		// Token: 0x04001BAE RID: 7086
		[Header("Curve Match target system")]
		public bool useLocalX;

		// Token: 0x04001BAF RID: 7087
		public bool useLocalZ = true;

		// Token: 0x04001BB0 RID: 7088
		public AnimationCurve matchPositionXZCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(0.5f, 1f),
			new Keyframe(1f, 1f)
		});

		// Token: 0x04001BB1 RID: 7089
		public AnimationCurve matchPositionYCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(0.5f, 1f),
			new Keyframe(1f, 1f)
		});

		// Token: 0x04001BB2 RID: 7090
		public AnimationCurve matchRotationCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(0.5f, 1f),
			new Keyframe(1f, 1f)
		});

		// Token: 0x04001BB3 RID: 7091
		[vEditorToolbar("Events", false, "", false, false, order = 3)]
		[Tooltip("Delay to run the OnDoAction Event")]
		[FormerlySerializedAs("onDoActionDelay")]
		public float onPressActionDelay;

		// Token: 0x04001BB4 RID: 7092
		[Header("--- INPUT EVENTS ---")]
		[FormerlySerializedAs("OnDoAction")]
		public UnityEvent OnPressActionInput;

		// Token: 0x04001BB5 RID: 7093
		public OnDoActionWithTarget onPressActionInputWithTarget;

		// Token: 0x04001BB6 RID: 7094
		[Header("--- ONLY FOR GET BUTTON TIMER ---")]
		public UnityEvent OnCancelActionInput;

		// Token: 0x04001BB7 RID: 7095
		public UnityEvent OnFinishActionInput;

		// Token: 0x04001BB8 RID: 7096
		public vTriggerGenericAction.OnUpdateValue OnUpdateButtonTimer;

		// Token: 0x04001BB9 RID: 7097
		[Header("--- ANIMATION EVENTS ---")]
		public UnityEvent OnStartAnimation;

		// Token: 0x04001BBA RID: 7098
		public UnityEvent OnEndAnimation;

		// Token: 0x04001BBB RID: 7099
		[Header("--- PLAYER AND TRIGGER DETECTION ---")]
		public OnDoActionWithTarget OnPlayerEnter;

		// Token: 0x04001BBC RID: 7100
		public OnDoActionWithTarget OnPlayerStay;

		// Token: 0x04001BBD RID: 7101
		public OnDoActionWithTarget OnPlayerExit;

		// Token: 0x04001BBE RID: 7102
		[Header("--- ACTION VALIDATION  ---")]
		public OnDoActionWithTarget OnValidate;

		// Token: 0x04001BBF RID: 7103
		public OnDoActionWithTarget OnInvalidate;

		// Token: 0x04001BC0 RID: 7104
		private float currentButtonTimer;

		// Token: 0x04001BC1 RID: 7105
		internal Collider _collider;

		// Token: 0x0200041C RID: 1052
		public enum InputType
		{
			// Token: 0x04001BC3 RID: 7107
			GetButtonDown,
			// Token: 0x04001BC4 RID: 7108
			GetDoubleButton,
			// Token: 0x04001BC5 RID: 7109
			GetButtonTimer,
			// Token: 0x04001BC6 RID: 7110
			AutoAction
		}

		// Token: 0x0200041D RID: 1053
		[Serializable]
		public class OnUpdateValue : UnityEvent<float>
		{
		}
	}
}
