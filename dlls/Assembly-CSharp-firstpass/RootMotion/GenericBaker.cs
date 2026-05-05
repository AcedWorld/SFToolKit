using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x0200000E RID: 14
	public class GenericBaker : Baker
	{
		// Token: 0x06000029 RID: 41 RVA: 0x000024B0 File Offset: 0x000006B0
		private void Awake()
		{
			Transform[] componentsInChildren = this.root.GetComponentsInChildren<Transform>();
			this.children = new BakerTransform[0];
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (!this.IsIgnored(componentsInChildren[i]))
				{
					Array.Resize<BakerTransform>(ref this.children, this.children.Length + 1);
					bool flag = componentsInChildren[i] == this.rootNode;
					if (flag)
					{
						this.rootChildIndex = this.children.Length - 1;
					}
					this.children[this.children.Length - 1] = new BakerTransform(componentsInChildren[i], this.root, this.BakePosition(componentsInChildren[i]), flag);
				}
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x0000254E File Offset: 0x0000074E
		protected override Transform GetCharacterRoot()
		{
			return this.root;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002558 File Offset: 0x00000758
		protected override void OnStartBaking()
		{
			for (int i = 0; i < this.children.Length; i++)
			{
				this.children[i].Reset();
				if (i == this.rootChildIndex)
				{
					this.children[i].SetRelativeSpace(this.root.position, this.root.rotation);
				}
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000025B4 File Offset: 0x000007B4
		protected override void OnSetLoopFrame(float time)
		{
			for (int i = 0; i < this.children.Length; i++)
			{
				this.children[i].AddLoopFrame(time);
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000025E4 File Offset: 0x000007E4
		protected override void OnSetCurves(ref AnimationClip clip)
		{
			for (int i = 0; i < this.children.Length; i++)
			{
				this.children[i].SetCurves(ref clip);
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002614 File Offset: 0x00000814
		protected override void OnSetKeyframes(float time, bool lastFrame)
		{
			for (int i = 0; i < this.children.Length; i++)
			{
				this.children[i].SetKeyframes(time);
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002644 File Offset: 0x00000844
		private bool IsIgnored(Transform t)
		{
			for (int i = 0; i < this.ignoreList.Length; i++)
			{
				if (t == this.ignoreList[i])
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002678 File Offset: 0x00000878
		private bool BakePosition(Transform t)
		{
			for (int i = 0; i < this.bakePositionList.Length; i++)
			{
				if (t == this.bakePositionList[i])
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0400003E RID: 62
		[Tooltip("If true, produced AnimationClips will be marked as Legacy and usable with the Legacy animation system.")]
		public bool markAsLegacy;

		// Token: 0x0400003F RID: 63
		[Tooltip("Root Transform of the hierarchy to bake.")]
		public Transform root;

		// Token: 0x04000040 RID: 64
		[Tooltip("Root Node used for root motion.")]
		public Transform rootNode;

		// Token: 0x04000041 RID: 65
		[Tooltip("List of Transforms to ignore, rotation curves will not be baked for these Transforms.")]
		public Transform[] ignoreList;

		// Token: 0x04000042 RID: 66
		[Tooltip("LocalPosition curves will be baked for these Transforms only. If you are baking a character, the pelvis bone should be added to this array.")]
		public Transform[] bakePositionList;

		// Token: 0x04000043 RID: 67
		private BakerTransform[] children = new BakerTransform[0];

		// Token: 0x04000044 RID: 68
		private BakerTransform rootChild;

		// Token: 0x04000045 RID: 69
		private int rootChildIndex = -1;
	}
}
