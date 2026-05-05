using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x02000012 RID: 18
	[Serializable]
	public class BakerHumanoidQT
	{
		// Token: 0x0600003F RID: 63 RVA: 0x00002DB8 File Offset: 0x00000FB8
		public BakerHumanoidQT(string name)
		{
			this.Qx = name + "Q.x";
			this.Qy = name + "Q.y";
			this.Qz = name + "Q.z";
			this.Qw = name + "Q.w";
			this.Tx = name + "T.x";
			this.Ty = name + "T.y";
			this.Tz = name + "T.z";
			this.Reset();
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002E48 File Offset: 0x00001048
		public BakerHumanoidQT(Transform transform, AvatarIKGoal goal, string name)
		{
			this.transform = transform;
			this.goal = goal;
			this.Qx = name + "Q.x";
			this.Qy = name + "Q.y";
			this.Qz = name + "Q.z";
			this.Qw = name + "Q.w";
			this.Tx = name + "T.x";
			this.Ty = name + "T.y";
			this.Tz = name + "T.z";
			this.Reset();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002EE6 File Offset: 0x000010E6
		public Quaternion EvaluateRotation(float time)
		{
			return new Quaternion(this.rotX.Evaluate(time), this.rotY.Evaluate(time), this.rotZ.Evaluate(time), this.rotW.Evaluate(time));
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002F1D File Offset: 0x0000111D
		public Vector3 EvaluatePosition(float time)
		{
			return new Vector3(this.posX.Evaluate(time), this.posY.Evaluate(time), this.posZ.Evaluate(time));
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002F48 File Offset: 0x00001148
		public TQ Evaluate(float time)
		{
			return new TQ(this.EvaluatePosition(time), this.EvaluateRotation(time));
		}

		// Token: 0x06000044 RID: 68 RVA: 0x0000223E File Offset: 0x0000043E
		public void GetCurvesFromClip(AnimationClip clip, Animator animator)
		{
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002F60 File Offset: 0x00001160
		public void Reset()
		{
			this.rotX = new AnimationCurve();
			this.rotY = new AnimationCurve();
			this.rotZ = new AnimationCurve();
			this.rotW = new AnimationCurve();
			this.posX = new AnimationCurve();
			this.posY = new AnimationCurve();
			this.posZ = new AnimationCurve();
			this.lastQ = Quaternion.identity;
			this.lastQSet = false;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002FCC File Offset: 0x000011CC
		public void SetIKKeyframes(float time, Avatar avatar, Transform root, float humanScale, Vector3 bodyPosition, Quaternion bodyRotation)
		{
			Vector3 vector = this.transform.position;
			Quaternion quaternion = this.transform.rotation;
			if (root.parent != null)
			{
				vector = root.parent.InverseTransformPoint(vector);
				quaternion = Quaternion.Inverse(root.parent.rotation) * quaternion;
			}
			TQ ikgoalTQ = AvatarUtility.GetIKGoalTQ(avatar, humanScale, this.goal, new TQ(bodyPosition, bodyRotation), new TQ(vector, quaternion));
			Quaternion quaternion2 = ikgoalTQ.q;
			if (this.lastQSet)
			{
				quaternion2 = BakerUtilities.EnsureQuaternionContinuity(this.lastQ, ikgoalTQ.q);
			}
			this.lastQ = quaternion2;
			this.lastQSet = true;
			this.rotX.AddKey(time, quaternion2.x);
			this.rotY.AddKey(time, quaternion2.y);
			this.rotZ.AddKey(time, quaternion2.z);
			this.rotW.AddKey(time, quaternion2.w);
			Vector3 t = ikgoalTQ.t;
			this.posX.AddKey(time, t.x);
			this.posY.AddKey(time, t.y);
			this.posZ.AddKey(time, t.z);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003104 File Offset: 0x00001304
		public void SetKeyframes(float time, Vector3 pos, Quaternion rot)
		{
			this.rotX.AddKey(time, rot.x);
			this.rotY.AddKey(time, rot.y);
			this.rotZ.AddKey(time, rot.z);
			this.rotW.AddKey(time, rot.w);
			this.posX.AddKey(time, pos.x);
			this.posY.AddKey(time, pos.y);
			this.posZ.AddKey(time, pos.z);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00003198 File Offset: 0x00001398
		public void MoveLastKeyframes(float time)
		{
			this.MoveLastKeyframe(time, this.rotX);
			this.MoveLastKeyframe(time, this.rotY);
			this.MoveLastKeyframe(time, this.rotZ);
			this.MoveLastKeyframe(time, this.rotW);
			this.MoveLastKeyframe(time, this.posX);
			this.MoveLastKeyframe(time, this.posY);
			this.MoveLastKeyframe(time, this.posZ);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003200 File Offset: 0x00001400
		public void SetLoopFrame(float time)
		{
			BakerUtilities.SetLoopFrame(time, this.rotX);
			BakerUtilities.SetLoopFrame(time, this.rotY);
			BakerUtilities.SetLoopFrame(time, this.rotZ);
			BakerUtilities.SetLoopFrame(time, this.rotW);
			BakerUtilities.SetLoopFrame(time, this.posX);
			BakerUtilities.SetLoopFrame(time, this.posY);
			BakerUtilities.SetLoopFrame(time, this.posZ);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000223E File Offset: 0x0000043E
		public void SetRootLoopFrame(float time)
		{
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003264 File Offset: 0x00001464
		private void MoveLastKeyframe(float time, AnimationCurve curve)
		{
			Keyframe[] keys = curve.keys;
			keys[keys.Length - 1].time = time;
			curve.keys = keys;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003290 File Offset: 0x00001490
		public void MultiplyLength(AnimationCurve curve, float mlp)
		{
			Keyframe[] keys = curve.keys;
			for (int i = 0; i < keys.Length; i++)
			{
				Keyframe[] array = keys;
				int num = i;
				array[num].time = array[num].time * mlp;
			}
			curve.keys = keys;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000032D0 File Offset: 0x000014D0
		public void SetCurves(ref AnimationClip clip, float maxError, float lengthMlp)
		{
			this.MultiplyLength(this.rotX, lengthMlp);
			this.MultiplyLength(this.rotY, lengthMlp);
			this.MultiplyLength(this.rotZ, lengthMlp);
			this.MultiplyLength(this.rotW, lengthMlp);
			this.MultiplyLength(this.posX, lengthMlp);
			this.MultiplyLength(this.posY, lengthMlp);
			this.MultiplyLength(this.posZ, lengthMlp);
			BakerUtilities.ReduceKeyframes(this.rotX, maxError);
			BakerUtilities.ReduceKeyframes(this.rotY, maxError);
			BakerUtilities.ReduceKeyframes(this.rotZ, maxError);
			BakerUtilities.ReduceKeyframes(this.rotW, maxError);
			BakerUtilities.ReduceKeyframes(this.posX, maxError);
			BakerUtilities.ReduceKeyframes(this.posY, maxError);
			BakerUtilities.ReduceKeyframes(this.posZ, maxError);
			BakerUtilities.SetTangentMode(this.rotX);
			BakerUtilities.SetTangentMode(this.rotY);
			BakerUtilities.SetTangentMode(this.rotZ);
			BakerUtilities.SetTangentMode(this.rotW);
			clip.SetCurve(string.Empty, typeof(Animator), this.Qx, this.rotX);
			clip.SetCurve(string.Empty, typeof(Animator), this.Qy, this.rotY);
			clip.SetCurve(string.Empty, typeof(Animator), this.Qz, this.rotZ);
			clip.SetCurve(string.Empty, typeof(Animator), this.Qw, this.rotW);
			clip.SetCurve(string.Empty, typeof(Animator), this.Tx, this.posX);
			clip.SetCurve(string.Empty, typeof(Animator), this.Ty, this.posY);
			clip.SetCurve(string.Empty, typeof(Animator), this.Tz, this.posZ);
		}

		// Token: 0x04000048 RID: 72
		private Transform transform;

		// Token: 0x04000049 RID: 73
		private string Qx;

		// Token: 0x0400004A RID: 74
		private string Qy;

		// Token: 0x0400004B RID: 75
		private string Qz;

		// Token: 0x0400004C RID: 76
		private string Qw;

		// Token: 0x0400004D RID: 77
		private string Tx;

		// Token: 0x0400004E RID: 78
		private string Ty;

		// Token: 0x0400004F RID: 79
		private string Tz;

		// Token: 0x04000050 RID: 80
		public AnimationCurve rotX;

		// Token: 0x04000051 RID: 81
		public AnimationCurve rotY;

		// Token: 0x04000052 RID: 82
		public AnimationCurve rotZ;

		// Token: 0x04000053 RID: 83
		public AnimationCurve rotW;

		// Token: 0x04000054 RID: 84
		public AnimationCurve posX;

		// Token: 0x04000055 RID: 85
		public AnimationCurve posY;

		// Token: 0x04000056 RID: 86
		public AnimationCurve posZ;

		// Token: 0x04000057 RID: 87
		private AvatarIKGoal goal;

		// Token: 0x04000058 RID: 88
		private Quaternion lastQ;

		// Token: 0x04000059 RID: 89
		private bool lastQSet;
	}
}
