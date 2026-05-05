using System;
using UnityEngine;
using UnityEngine.Playables;

namespace RootMotion
{
	// Token: 0x02000007 RID: 7
	[HelpURL("http://www.root-motion.com/finalikdox/html/page3.html")]
	[AddComponentMenu("Scripts/RootMotion/Baker")]
	public abstract class Baker : MonoBehaviour
	{
		// Token: 0x06000011 RID: 17 RVA: 0x000023EB File Offset: 0x000005EB
		[ContextMenu("User Manual")]
		private void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page3.html");
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000023F7 File Offset: 0x000005F7
		[ContextMenu("Scrpt Reference")]
		private void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_baker.html");
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002403 File Offset: 0x00000603
		[ContextMenu("Support Group")]
		private void SupportGroup()
		{
			Application.OpenURL("https://groups.google.com/forum/#!forum/final-ik");
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000240F File Offset: 0x0000060F
		[ContextMenu("Asset Store Thread")]
		private void ASThread()
		{
			Application.OpenURL("http://forum.unity3d.com/threads/final-ik-full-body-ik-aim-look-at-fabrik-ccd-ik-1-0-released.222685/");
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000015 RID: 21 RVA: 0x0000241B File Offset: 0x0000061B
		// (set) Token: 0x06000016 RID: 22 RVA: 0x00002423 File Offset: 0x00000623
		public bool isBaking { get; private set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000017 RID: 23 RVA: 0x0000242C File Offset: 0x0000062C
		// (set) Token: 0x06000018 RID: 24 RVA: 0x00002434 File Offset: 0x00000634
		public float bakingProgress { get; private set; }

		// Token: 0x06000019 RID: 25
		protected abstract Transform GetCharacterRoot();

		// Token: 0x0600001A RID: 26
		protected abstract void OnStartBaking();

		// Token: 0x0600001B RID: 27
		protected abstract void OnSetLoopFrame(float time);

		// Token: 0x0600001C RID: 28
		protected abstract void OnSetCurves(ref AnimationClip clip);

		// Token: 0x0600001D RID: 29
		protected abstract void OnSetKeyframes(float time, bool lastFrame);

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001E RID: 30 RVA: 0x0000243D File Offset: 0x0000063D
		// (set) Token: 0x0600001F RID: 31 RVA: 0x00002445 File Offset: 0x00000645
		private protected float clipLength { protected get; private set; }

		// Token: 0x06000020 RID: 32 RVA: 0x0000223E File Offset: 0x0000043E
		public void BakeClip()
		{
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000223E File Offset: 0x0000043E
		public void StartBaking()
		{
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000223E File Offset: 0x0000043E
		public void StopBaking()
		{
		}

		// Token: 0x04000011 RID: 17
		[Tooltip("In AnimationClips, AnimationStates or PlayableDirector mode - the frame rate at which the animation clip will be sampled. In Realtime mode - the frame rate at which the pose will be sampled. With the latter, the frame rate is not guaranteed if the player is not able to reach it.")]
		[Range(1f, 90f)]
		public int frameRate = 30;

		// Token: 0x04000012 RID: 18
		[Tooltip("Maximum allowed error for keyframe reduction.")]
		[Range(0f, 0.1f)]
		public float keyReductionError = 0.01f;

		// Token: 0x04000013 RID: 19
		[Tooltip("AnimationClips mode can be used to bake a batch of AnimationClips directly without the need of setting up an AnimatorController. AnimationStates mode is useful for when you need to set up a more complex rig with layers and AvatarMasks in Mecanim. PlayableDirector mode bakes a Timeline. Realtime mode is for continuous baking of gameplay, ragdoll phsysics or PuppetMaster dynamics.")]
		public Baker.Mode mode;

		// Token: 0x04000014 RID: 20
		[Tooltip("AnimationClips to bake.")]
		public AnimationClip[] animationClips = new AnimationClip[0];

		// Token: 0x04000015 RID: 21
		[Tooltip("The name of the AnimationStates to bake (must be on the base layer) in the Animator above (Right-click on this component header and select 'Find Animation States' to have Baker fill those in automatically, required that state names match with the names of the clips used in them).")]
		public string[] animationStates = new string[0];

		// Token: 0x04000016 RID: 22
		[Tooltip("The folder to save the baked AnimationClips to.")]
		public string saveToFolder = "Assets";

		// Token: 0x04000017 RID: 23
		[Tooltip("String that will be added to each clip or animation state name for the saved clip. For example if your animation state/clip names were 'Idle' and 'Walk', then with '_Baked' as Append Name, the Baker will create 'Idle_Baked' and 'Walk_Baked' animation clips.")]
		public string appendName = "_Baked";

		// Token: 0x04000018 RID: 24
		[Tooltip("Name of the created AnimationClip file.")]
		public string saveName = "Baked Clip";

		// Token: 0x0400001B RID: 27
		[HideInInspector]
		public Animator animator;

		// Token: 0x0400001C RID: 28
		[HideInInspector]
		public PlayableDirector director;

		// Token: 0x0400001D RID: 29
		public Baker.BakerDelegate OnStartClip;

		// Token: 0x0400001E RID: 30
		public Baker.BakerDelegate OnUpdateClip;

		// Token: 0x0400001F RID: 31
		[Tooltip("If enabled, baked clips will have the same AnimationClipSettings as the clips used for baking. If disabled, clip settings from below will be applied to all the baked clips.")]
		public bool inheritClipSettings;

		// Token: 0x04000020 RID: 32
		[Tooltip("AnimationClipSettings applied to the baked animation clip.")]
		public Baker.ClipSettings clipSettings;

		// Token: 0x04000022 RID: 34
		protected bool addLoopFrame;

		// Token: 0x02000008 RID: 8
		[Serializable]
		public enum Mode
		{
			// Token: 0x04000024 RID: 36
			AnimationClips,
			// Token: 0x04000025 RID: 37
			AnimationStates,
			// Token: 0x04000026 RID: 38
			PlayableDirector,
			// Token: 0x04000027 RID: 39
			Realtime
		}

		// Token: 0x02000009 RID: 9
		// (Invoke) Token: 0x06000025 RID: 37
		public delegate void BakerDelegate(AnimationClip clip, float time);

		// Token: 0x0200000A RID: 10
		[Serializable]
		public class ClipSettings
		{
			// Token: 0x04000028 RID: 40
			public bool loopTime;

			// Token: 0x04000029 RID: 41
			public bool loopBlend;

			// Token: 0x0400002A RID: 42
			public float cycleOffset;

			// Token: 0x0400002B RID: 43
			public bool loopBlendOrientation;

			// Token: 0x0400002C RID: 44
			public Baker.ClipSettings.BasedUponRotation basedUponRotation;

			// Token: 0x0400002D RID: 45
			public float orientationOffsetY;

			// Token: 0x0400002E RID: 46
			public bool loopBlendPositionY;

			// Token: 0x0400002F RID: 47
			public Baker.ClipSettings.BasedUponY basedUponY;

			// Token: 0x04000030 RID: 48
			public float level;

			// Token: 0x04000031 RID: 49
			public bool loopBlendPositionXZ;

			// Token: 0x04000032 RID: 50
			public Baker.ClipSettings.BasedUponXZ basedUponXZ;

			// Token: 0x04000033 RID: 51
			public bool mirror;

			// Token: 0x0200000B RID: 11
			[Serializable]
			public enum BasedUponRotation
			{
				// Token: 0x04000035 RID: 53
				Original,
				// Token: 0x04000036 RID: 54
				BodyOrientation
			}

			// Token: 0x0200000C RID: 12
			[Serializable]
			public enum BasedUponY
			{
				// Token: 0x04000038 RID: 56
				Original,
				// Token: 0x04000039 RID: 57
				CenterOfMass,
				// Token: 0x0400003A RID: 58
				Feet
			}

			// Token: 0x0200000D RID: 13
			[Serializable]
			public enum BasedUponXZ
			{
				// Token: 0x0400003C RID: 60
				Original,
				// Token: 0x0400003D RID: 61
				CenterOfMass
			}
		}
	}
}
