using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x02000014 RID: 20
	[Serializable]
	public class BakerTransform
	{
		// Token: 0x06000055 RID: 85 RVA: 0x0000388C File Offset: 0x00001A8C
		public BakerTransform(Transform transform, Transform root, bool recordPosition, bool isRootNode)
		{
			this.transform = transform;
			this.recordPosition = (recordPosition || isRootNode);
			this.isRootNode = isRootNode;
			this.relativePath = string.Empty;
			this.Reset();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000038BE File Offset: 0x00001ABE
		public void SetRelativeSpace(Vector3 position, Quaternion rotation)
		{
			this.relativePosition = position;
			this.relativeRotation = rotation;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000038D0 File Offset: 0x00001AD0
		public void SetCurves(ref AnimationClip clip)
		{
			if (this.recordPosition)
			{
				clip.SetCurve(this.relativePath, typeof(Transform), "localPosition.x", this.posX);
				clip.SetCurve(this.relativePath, typeof(Transform), "localPosition.y", this.posY);
				clip.SetCurve(this.relativePath, typeof(Transform), "localPosition.z", this.posZ);
			}
			clip.SetCurve(this.relativePath, typeof(Transform), "localRotation.x", this.rotX);
			clip.SetCurve(this.relativePath, typeof(Transform), "localRotation.y", this.rotY);
			clip.SetCurve(this.relativePath, typeof(Transform), "localRotation.z", this.rotZ);
			clip.SetCurve(this.relativePath, typeof(Transform), "localRotation.w", this.rotW);
			if (this.isRootNode)
			{
				this.AddRootMotionCurves(ref clip);
			}
			clip.EnsureQuaternionContinuity();
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000039EC File Offset: 0x00001BEC
		private void AddRootMotionCurves(ref AnimationClip clip)
		{
			if (this.recordPosition)
			{
				clip.SetCurve("", typeof(Animator), "MotionT.x", this.posX);
				clip.SetCurve("", typeof(Animator), "MotionT.y", this.posY);
				clip.SetCurve("", typeof(Animator), "MotionT.z", this.posZ);
			}
			clip.SetCurve("", typeof(Animator), "MotionQ.x", this.rotX);
			clip.SetCurve("", typeof(Animator), "MotionQ.y", this.rotY);
			clip.SetCurve("", typeof(Animator), "MotionQ.z", this.rotZ);
			clip.SetCurve("", typeof(Animator), "MotionQ.w", this.rotW);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003AE8 File Offset: 0x00001CE8
		public void Reset()
		{
			this.posX = new AnimationCurve();
			this.posY = new AnimationCurve();
			this.posZ = new AnimationCurve();
			this.rotX = new AnimationCurve();
			this.rotY = new AnimationCurve();
			this.rotZ = new AnimationCurve();
			this.rotW = new AnimationCurve();
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003B44 File Offset: 0x00001D44
		public void ReduceKeyframes(float maxError)
		{
			BakerUtilities.ReduceKeyframes(this.rotX, maxError);
			BakerUtilities.ReduceKeyframes(this.rotY, maxError);
			BakerUtilities.ReduceKeyframes(this.rotZ, maxError);
			BakerUtilities.ReduceKeyframes(this.rotW, maxError);
			BakerUtilities.ReduceKeyframes(this.posX, maxError);
			BakerUtilities.ReduceKeyframes(this.posY, maxError);
			BakerUtilities.ReduceKeyframes(this.posZ, maxError);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003BA8 File Offset: 0x00001DA8
		public void SetKeyframes(float time)
		{
			if (this.recordPosition)
			{
				Vector3 vector = this.transform.localPosition;
				if (this.isRootNode)
				{
					vector = this.transform.position - this.relativePosition;
				}
				this.posX.AddKey(time, vector.x);
				this.posY.AddKey(time, vector.y);
				this.posZ.AddKey(time, vector.z);
			}
			Quaternion quaternion = this.transform.localRotation;
			if (this.isRootNode)
			{
				quaternion = Quaternion.Inverse(this.relativeRotation) * this.transform.rotation;
			}
			this.rotX.AddKey(time, quaternion.x);
			this.rotY.AddKey(time, quaternion.y);
			this.rotZ.AddKey(time, quaternion.z);
			this.rotW.AddKey(time, quaternion.w);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003CA0 File Offset: 0x00001EA0
		public void AddLoopFrame(float time)
		{
			if (this.recordPosition && !this.isRootNode)
			{
				this.posX.AddKey(time, this.posX.keys[0].value);
				this.posY.AddKey(time, this.posY.keys[0].value);
				this.posZ.AddKey(time, this.posZ.keys[0].value);
			}
			this.rotX.AddKey(time, this.rotX.keys[0].value);
			this.rotY.AddKey(time, this.rotY.keys[0].value);
			this.rotZ.AddKey(time, this.rotZ.keys[0].value);
			this.rotW.AddKey(time, this.rotW.keys[0].value);
		}

		// Token: 0x0400005D RID: 93
		public Transform transform;

		// Token: 0x0400005E RID: 94
		public AnimationCurve posX;

		// Token: 0x0400005F RID: 95
		public AnimationCurve posY;

		// Token: 0x04000060 RID: 96
		public AnimationCurve posZ;

		// Token: 0x04000061 RID: 97
		public AnimationCurve rotX;

		// Token: 0x04000062 RID: 98
		public AnimationCurve rotY;

		// Token: 0x04000063 RID: 99
		public AnimationCurve rotZ;

		// Token: 0x04000064 RID: 100
		public AnimationCurve rotW;

		// Token: 0x04000065 RID: 101
		private string relativePath;

		// Token: 0x04000066 RID: 102
		private bool recordPosition;

		// Token: 0x04000067 RID: 103
		private Vector3 relativePosition;

		// Token: 0x04000068 RID: 104
		private bool isRootNode;

		// Token: 0x04000069 RID: 105
		private Quaternion relativeRotation;
	}
}
