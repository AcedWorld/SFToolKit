using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200020C RID: 524
	[Serializable]
	public struct ProbeCapturePositionSettings
	{
		// Token: 0x06000F90 RID: 3984 RVA: 0x000791A4 File Offset: 0x000773A4
		public static ProbeCapturePositionSettings NewDefault()
		{
			return new ProbeCapturePositionSettings(Vector3.zero, Quaternion.identity, Vector3.zero, Quaternion.identity, Matrix4x4.identity);
		}

		// Token: 0x06000F91 RID: 3985 RVA: 0x000791C4 File Offset: 0x000773C4
		public ProbeCapturePositionSettings(Vector3 proxyPosition, Quaternion proxyRotation, Matrix4x4 influenceToWorld)
		{
			this.proxyPosition = proxyPosition;
			this.proxyRotation = proxyRotation;
			this.referencePosition = Vector3.zero;
			this.referenceRotation = Quaternion.identity;
			this.influenceToWorld = influenceToWorld;
		}

		// Token: 0x06000F92 RID: 3986 RVA: 0x000791F1 File Offset: 0x000773F1
		public ProbeCapturePositionSettings(Vector3 proxyPosition, Quaternion proxyRotation, Vector3 referencePosition, Quaternion referenceRotation, Matrix4x4 influenceToWorld)
		{
			this.proxyPosition = proxyPosition;
			this.proxyRotation = proxyRotation;
			this.referencePosition = referencePosition;
			this.referenceRotation = referenceRotation;
			this.influenceToWorld = influenceToWorld;
		}

		// Token: 0x06000F93 RID: 3987 RVA: 0x00079218 File Offset: 0x00077418
		public static ProbeCapturePositionSettings ComputeFrom(HDProbe probe, Transform reference)
		{
			Vector3 vector = Vector3.zero;
			Quaternion quaternion = Quaternion.identity;
			if (reference != null)
			{
				vector = reference.position;
				quaternion = reference.rotation;
			}
			else if (probe.type == ProbeSettings.ProbeType.PlanarProbe)
			{
				PlanarReflectionProbe planarReflectionProbe = (PlanarReflectionProbe)probe;
				return ProbeCapturePositionSettings.ComputeFromMirroredReference(planarReflectionProbe, planarReflectionProbe.referencePosition);
			}
			return ProbeCapturePositionSettings.ComputeFrom(probe, vector, quaternion);
		}

		// Token: 0x06000F94 RID: 3988 RVA: 0x00079270 File Offset: 0x00077470
		public static ProbeCapturePositionSettings ComputeFromMirroredReference(HDProbe probe, Vector3 referencePosition)
		{
			ProbeCapturePositionSettings probeCapturePositionSettings = ProbeCapturePositionSettings.ComputeFrom(probe, referencePosition, Quaternion.identity);
			Vector3 a = Matrix4x4.TRS(probeCapturePositionSettings.proxyPosition, probeCapturePositionSettings.proxyRotation, Vector3.one).MultiplyPoint(probe.settings.proxySettings.mirrorPositionProxySpace);
			probeCapturePositionSettings.referenceRotation = Quaternion.LookRotation(a - probeCapturePositionSettings.referencePosition);
			return probeCapturePositionSettings;
		}

		// Token: 0x06000F95 RID: 3989 RVA: 0x000792D4 File Offset: 0x000774D4
		public Hash128 ComputeHash()
		{
			Hash128 result = default(Hash128);
			Hash128 hash = default(Hash128);
			HashUtilities.QuantisedVectorHash(ref this.proxyPosition, ref result);
			HashUtilities.QuantisedVectorHash(ref this.referencePosition, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			Vector3 eulerAngles = this.proxyRotation.eulerAngles;
			HashUtilities.QuantisedVectorHash(ref eulerAngles, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			eulerAngles = this.referenceRotation.eulerAngles;
			HashUtilities.QuantisedVectorHash(ref eulerAngles, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			return result;
		}

		// Token: 0x06000F96 RID: 3990 RVA: 0x00079354 File Offset: 0x00077554
		private static ProbeCapturePositionSettings ComputeFrom(HDProbe probe, Vector3 referencePosition, Quaternion referenceRotation)
		{
			ProbeCapturePositionSettings probeCapturePositionSettings = default(ProbeCapturePositionSettings);
			Matrix4x4 proxyToWorld = probe.proxyToWorld;
			probeCapturePositionSettings.proxyPosition = proxyToWorld.GetColumn(3);
			if (Vector3.Distance(probeCapturePositionSettings.proxyPosition, referencePosition) < 0.0001f)
			{
				referencePosition += new Vector3(0.0001f, 0.0001f, 0.0001f);
			}
			probeCapturePositionSettings.proxyRotation = proxyToWorld.rotation;
			probeCapturePositionSettings.referencePosition = referencePosition;
			probeCapturePositionSettings.referenceRotation = referenceRotation;
			probeCapturePositionSettings.influenceToWorld = probe.influenceToWorld;
			return probeCapturePositionSettings;
		}

		// Token: 0x0400180C RID: 6156
		[Obsolete("Since 2019.3, use ProbeCapturePositionSettings.NewDefault() instead.")]
		public static readonly ProbeCapturePositionSettings @default;

		// Token: 0x0400180D RID: 6157
		public Vector3 proxyPosition;

		// Token: 0x0400180E RID: 6158
		public Quaternion proxyRotation;

		// Token: 0x0400180F RID: 6159
		public Vector3 referencePosition;

		// Token: 0x04001810 RID: 6160
		public Quaternion referenceRotation;

		// Token: 0x04001811 RID: 6161
		public Matrix4x4 influenceToWorld;
	}
}
