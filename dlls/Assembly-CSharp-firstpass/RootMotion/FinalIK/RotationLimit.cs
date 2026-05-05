using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x0200010D RID: 269
	public abstract class RotationLimit : MonoBehaviour
	{
		// Token: 0x06000903 RID: 2307 RVA: 0x00039CB0 File Offset: 0x00037EB0
		public void SetDefaultLocalRotation()
		{
			this.defaultLocalRotation = base.transform.localRotation;
			this.defaultLocalRotationSet = true;
			this.defaultLocalRotationOverride = false;
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x00039CD1 File Offset: 0x00037ED1
		public void SetDefaultLocalRotation(Quaternion localRotation)
		{
			this.defaultLocalRotation = localRotation;
			this.defaultLocalRotationSet = true;
			this.defaultLocalRotationOverride = true;
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x00039CE8 File Offset: 0x00037EE8
		public Quaternion GetLimitedLocalRotation(Quaternion localRotation, out bool changed)
		{
			if (!this.initiated)
			{
				this.Awake();
			}
			Quaternion quaternion = Quaternion.Inverse(this.defaultLocalRotation) * localRotation;
			Quaternion quaternion2 = this.LimitRotation(quaternion);
			quaternion2 = Quaternion.Normalize(quaternion2);
			changed = (quaternion2 != quaternion);
			if (!changed)
			{
				return localRotation;
			}
			return this.defaultLocalRotation * quaternion2;
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x00039D40 File Offset: 0x00037F40
		public bool Apply()
		{
			bool result = false;
			base.transform.localRotation = this.GetLimitedLocalRotation(base.transform.localRotation, out result);
			return result;
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x00039D6E File Offset: 0x00037F6E
		public void Disable()
		{
			if (this.initiated)
			{
				base.enabled = false;
				return;
			}
			this.Awake();
			base.enabled = false;
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000908 RID: 2312 RVA: 0x00039D8D File Offset: 0x00037F8D
		public Vector3 secondaryAxis
		{
			get
			{
				return new Vector3(this.axis.y, this.axis.z, this.axis.x);
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000909 RID: 2313 RVA: 0x00039DB5 File Offset: 0x00037FB5
		public Vector3 crossAxis
		{
			get
			{
				return Vector3.Cross(this.axis, this.secondaryAxis);
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x0600090A RID: 2314 RVA: 0x00039DC8 File Offset: 0x00037FC8
		// (set) Token: 0x0600090B RID: 2315 RVA: 0x00039DD0 File Offset: 0x00037FD0
		public bool defaultLocalRotationOverride { get; private set; }

		// Token: 0x0600090C RID: 2316
		protected abstract Quaternion LimitRotation(Quaternion rotation);

		// Token: 0x0600090D RID: 2317 RVA: 0x00039DD9 File Offset: 0x00037FD9
		private void Awake()
		{
			if (!this.defaultLocalRotationSet)
			{
				this.SetDefaultLocalRotation();
			}
			if (this.axis == Vector3.zero)
			{
				Debug.LogError("Axis is Vector3.zero.");
			}
			this.initiated = true;
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x00039E0C File Offset: 0x0003800C
		private void LateUpdate()
		{
			this.Apply();
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x0001BF4E File Offset: 0x0001A14E
		public void LogWarning(string message)
		{
			Warning.Log(message, base.transform, false);
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x00039E15 File Offset: 0x00038015
		protected static Quaternion Limit1DOF(Quaternion rotation, Vector3 axis)
		{
			return Quaternion.FromToRotation(rotation * axis, axis) * rotation;
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x00039E2C File Offset: 0x0003802C
		protected static Quaternion LimitTwist(Quaternion rotation, Vector3 axis, Vector3 orthoAxis, float twistLimit)
		{
			twistLimit = Mathf.Clamp(twistLimit, 0f, 180f);
			if (twistLimit >= 180f)
			{
				return rotation;
			}
			Vector3 vector = rotation * axis;
			Vector3 toDirection = orthoAxis;
			Vector3.OrthoNormalize(ref vector, ref toDirection);
			Vector3 fromDirection = rotation * orthoAxis;
			Vector3.OrthoNormalize(ref vector, ref fromDirection);
			Quaternion quaternion = Quaternion.FromToRotation(fromDirection, toDirection) * rotation;
			if (twistLimit <= 0f)
			{
				return quaternion;
			}
			return Quaternion.RotateTowards(quaternion, rotation, twistLimit);
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x00039E99 File Offset: 0x00038099
		protected static float GetOrthogonalAngle(Vector3 v1, Vector3 v2, Vector3 normal)
		{
			Vector3.OrthoNormalize(ref normal, ref v1);
			Vector3.OrthoNormalize(ref normal, ref v2);
			return Vector3.Angle(v1, v2);
		}

		// Token: 0x04000849 RID: 2121
		public Vector3 axis = Vector3.forward;

		// Token: 0x0400084A RID: 2122
		[HideInInspector]
		public Quaternion defaultLocalRotation;

		// Token: 0x0400084C RID: 2124
		private bool initiated;

		// Token: 0x0400084D RID: 2125
		private bool applicationQuit;

		// Token: 0x0400084E RID: 2126
		private bool defaultLocalRotationSet;
	}
}
