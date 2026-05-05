using System;
using UnityEngine;

namespace Cinemachine
{
	// Token: 0x02000055 RID: 85
	[DocumentationSorting(DocumentationSortingAttribute.Level.API)]
	[Serializable]
	public class CinemachineImpulseDefinition
	{
		// Token: 0x06000385 RID: 901 RVA: 0x00015CE8 File Offset: 0x00013EE8
		public void OnValidate()
		{
			RuntimeUtility.NormalizeCurve(this.m_CustomImpulseShape, true, false);
			this.m_ImpulseDuration = Mathf.Max(0.0001f, this.m_ImpulseDuration);
			this.m_DissipationDistance = Mathf.Max(0.0001f, this.m_DissipationDistance);
			this.m_DissipationRate = Mathf.Clamp01(this.m_DissipationRate);
			this.m_PropagationSpeed = Mathf.Max(1f, this.m_PropagationSpeed);
			this.m_ImpactRadius = Mathf.Max(0f, this.m_ImpactRadius);
			this.m_TimeEnvelope.Validate();
			this.m_PropagationSpeed = Mathf.Max(1f, this.m_PropagationSpeed);
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00015D90 File Offset: 0x00013F90
		private static void CreateStandardShapes()
		{
			int num = 0;
			foreach (object obj in Enum.GetValues(typeof(CinemachineImpulseDefinition.ImpulseShapes)))
			{
				num = Mathf.Max(num, (int)obj);
			}
			CinemachineImpulseDefinition.sStandardShapes = new AnimationCurve[num + 1];
			CinemachineImpulseDefinition.sStandardShapes[1] = new AnimationCurve(new Keyframe[]
			{
				new Keyframe(0f, 1f, -3.2f, -3.2f),
				new Keyframe(1f, 0f, 0f, 0f)
			});
			CinemachineImpulseDefinition.sStandardShapes[2] = new AnimationCurve(new Keyframe[]
			{
				new Keyframe(0f, 0f, -4.9f, -4.9f),
				new Keyframe(0.2f, 0f, 8.25f, 8.25f),
				new Keyframe(1f, 0f, -0.25f, -0.25f)
			});
			CinemachineImpulseDefinition.sStandardShapes[3] = new AnimationCurve(new Keyframe[]
			{
				new Keyframe(0f, -1.4f, -7.9f, -7.9f),
				new Keyframe(0.27f, 0.78f, 23.4f, 23.4f),
				new Keyframe(0.54f, -0.12f, 22.6f, 22.6f),
				new Keyframe(0.75f, 0.042f, 9.23f, 9.23f),
				new Keyframe(0.9f, -0.02f, 5.8f, 5.8f),
				new Keyframe(0.95f, -0.006f, -3f, -3f),
				new Keyframe(1f, 0f, 0f, 0f)
			});
			CinemachineImpulseDefinition.sStandardShapes[4] = new AnimationCurve(new Keyframe[]
			{
				new Keyframe(0f, 0f, 0f, 0f),
				new Keyframe(0.1f, 0.25f, 0f, 0f),
				new Keyframe(0.2f, 0f, 0f, 0f),
				new Keyframe(0.3f, 0.75f, 0f, 0f),
				new Keyframe(0.4f, 0f, 0f, 0f),
				new Keyframe(0.5f, 1f, 0f, 0f),
				new Keyframe(0.6f, 0f, 0f, 0f),
				new Keyframe(0.7f, 0.75f, 0f, 0f),
				new Keyframe(0.8f, 0f, 0f, 0f),
				new Keyframe(0.9f, 0.25f, 0f, 0f),
				new Keyframe(1f, 0f, 0f, 0f)
			});
		}

		// Token: 0x06000387 RID: 903 RVA: 0x00016130 File Offset: 0x00014330
		internal static AnimationCurve GetStandardCurve(CinemachineImpulseDefinition.ImpulseShapes shape)
		{
			if (CinemachineImpulseDefinition.sStandardShapes == null)
			{
				CinemachineImpulseDefinition.CreateStandardShapes();
			}
			return CinemachineImpulseDefinition.sStandardShapes[(int)shape];
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000388 RID: 904 RVA: 0x00016148 File Offset: 0x00014348
		internal AnimationCurve ImpulseCurve
		{
			get
			{
				if (this.m_ImpulseShape == CinemachineImpulseDefinition.ImpulseShapes.Custom)
				{
					if (this.m_CustomImpulseShape == null)
					{
						this.m_CustomImpulseShape = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
					}
					return this.m_CustomImpulseShape;
				}
				return CinemachineImpulseDefinition.GetStandardCurve(this.m_ImpulseShape);
			}
		}

		// Token: 0x06000389 RID: 905 RVA: 0x00016196 File Offset: 0x00014396
		public void CreateEvent(Vector3 position, Vector3 velocity)
		{
			this.CreateAndReturnEvent(position, velocity);
		}

		// Token: 0x0600038A RID: 906 RVA: 0x000161A4 File Offset: 0x000143A4
		public CinemachineImpulseManager.ImpulseEvent CreateAndReturnEvent(Vector3 position, Vector3 velocity)
		{
			if (this.m_ImpulseType == CinemachineImpulseDefinition.ImpulseTypes.Legacy)
			{
				return this.LegacyCreateAndReturnEvent(position, velocity);
			}
			if ((this.m_ImpulseShape == CinemachineImpulseDefinition.ImpulseShapes.Custom && this.m_CustomImpulseShape == null) || Mathf.Abs(this.m_DissipationDistance) < 0.0001f || Mathf.Abs(this.m_ImpulseDuration) < 0.0001f)
			{
				return null;
			}
			CinemachineImpulseManager.ImpulseEvent impulseEvent = CinemachineImpulseManager.Instance.NewImpulseEvent();
			impulseEvent.m_Envelope = new CinemachineImpulseManager.EnvelopeDefinition
			{
				m_SustainTime = this.m_ImpulseDuration
			};
			impulseEvent.m_SignalSource = new CinemachineImpulseDefinition.SignalSource(this, velocity);
			impulseEvent.m_Position = position;
			impulseEvent.m_Radius = ((this.m_ImpulseType == CinemachineImpulseDefinition.ImpulseTypes.Uniform) ? 9999999f : 0f);
			impulseEvent.m_Channel = this.m_ImpulseChannel;
			impulseEvent.m_DirectionMode = CinemachineImpulseManager.ImpulseEvent.DirectionMode.Fixed;
			impulseEvent.m_DissipationDistance = ((this.m_ImpulseType == CinemachineImpulseDefinition.ImpulseTypes.Uniform) ? 0f : this.m_DissipationDistance);
			impulseEvent.m_PropagationSpeed = ((this.m_ImpulseType == CinemachineImpulseDefinition.ImpulseTypes.Propagating) ? this.m_PropagationSpeed : 9999999f);
			impulseEvent.m_CustomDissipation = this.m_DissipationRate;
			CinemachineImpulseManager.Instance.AddImpulseEvent(impulseEvent);
			return impulseEvent;
		}

		// Token: 0x0600038B RID: 907 RVA: 0x000162B0 File Offset: 0x000144B0
		private CinemachineImpulseManager.ImpulseEvent LegacyCreateAndReturnEvent(Vector3 position, Vector3 velocity)
		{
			if (this.m_RawSignal == null || Mathf.Abs(this.m_TimeEnvelope.Duration) < 0.0001f)
			{
				return null;
			}
			CinemachineImpulseManager.ImpulseEvent impulseEvent = CinemachineImpulseManager.Instance.NewImpulseEvent();
			impulseEvent.m_Envelope = this.m_TimeEnvelope;
			impulseEvent.m_Envelope = this.m_TimeEnvelope;
			if (this.m_TimeEnvelope.m_ScaleWithImpact)
			{
				CinemachineImpulseManager.ImpulseEvent impulseEvent2 = impulseEvent;
				impulseEvent2.m_Envelope.m_DecayTime = impulseEvent2.m_Envelope.m_DecayTime * Mathf.Sqrt(velocity.magnitude);
			}
			impulseEvent.m_SignalSource = new CinemachineImpulseDefinition.LegacySignalSource(this, velocity);
			impulseEvent.m_Position = position;
			impulseEvent.m_Radius = this.m_ImpactRadius;
			impulseEvent.m_Channel = this.m_ImpulseChannel;
			impulseEvent.m_DirectionMode = this.m_DirectionMode;
			impulseEvent.m_DissipationMode = this.m_DissipationMode;
			impulseEvent.m_DissipationDistance = this.m_DissipationDistance;
			impulseEvent.m_PropagationSpeed = this.m_PropagationSpeed;
			CinemachineImpulseManager.Instance.AddImpulseEvent(impulseEvent);
			return impulseEvent;
		}

		// Token: 0x0400025E RID: 606
		[CinemachineImpulseChannelProperty]
		[Tooltip("Impulse events generated here will appear on the channels included in the mask.")]
		public int m_ImpulseChannel = 1;

		// Token: 0x0400025F RID: 607
		[Tooltip("Shape of the impact signal")]
		public CinemachineImpulseDefinition.ImpulseShapes m_ImpulseShape;

		// Token: 0x04000260 RID: 608
		[Tooltip("Defines the custom shape of the impact signal that will be generated.")]
		public AnimationCurve m_CustomImpulseShape = new AnimationCurve();

		// Token: 0x04000261 RID: 609
		[Tooltip("The time during which the impact signal will occur.  The signal shape will be stretched to fill that time.")]
		public float m_ImpulseDuration = 0.2f;

		// Token: 0x04000262 RID: 610
		[Tooltip("How the impulse travels through space and time.")]
		public CinemachineImpulseDefinition.ImpulseTypes m_ImpulseType = CinemachineImpulseDefinition.ImpulseTypes.Legacy;

		// Token: 0x04000263 RID: 611
		[Tooltip("This defines how the widely signal will spread within the effect radius before dissipating with distance from the impact point")]
		[Range(0f, 1f)]
		public float m_DissipationRate;

		// Token: 0x04000264 RID: 612
		[Header("Signal Shape")]
		[Tooltip("Legacy mode only: Defines the signal that will be generated.")]
		[CinemachineEmbeddedAssetProperty(true)]
		public SignalSourceAsset m_RawSignal;

		// Token: 0x04000265 RID: 613
		[Tooltip("Legacy mode only: Gain to apply to the amplitudes defined in the signal source.  1 is normal.  Setting this to 0 completely mutes the signal.")]
		public float m_AmplitudeGain = 1f;

		// Token: 0x04000266 RID: 614
		[Tooltip("Legacy mode only: Scale factor to apply to the time axis.  1 is normal.  Larger magnitudes will make the signal progress more rapidly.")]
		public float m_FrequencyGain = 1f;

		// Token: 0x04000267 RID: 615
		[Tooltip("Legacy mode only: How to fit the signal into the envelope time")]
		public CinemachineImpulseDefinition.RepeatMode m_RepeatMode;

		// Token: 0x04000268 RID: 616
		[Tooltip("Legacy mode only: Randomize the signal start time")]
		public bool m_Randomize = true;

		// Token: 0x04000269 RID: 617
		[Tooltip("Legacy mode only: This defines the time-envelope of the signal.  The raw signal will be time-scaled to fit in the envelope.")]
		public CinemachineImpulseManager.EnvelopeDefinition m_TimeEnvelope = CinemachineImpulseManager.EnvelopeDefinition.Default();

		// Token: 0x0400026A RID: 618
		[Header("Spatial Range")]
		[Tooltip("Legacy mode only: The signal will have full amplitude in this radius surrounding the impact point.  Beyond that it will dissipate with distance.")]
		public float m_ImpactRadius = 100f;

		// Token: 0x0400026B RID: 619
		[Tooltip("Legacy mode only: How the signal direction behaves as the listener moves away from the origin.")]
		public CinemachineImpulseManager.ImpulseEvent.DirectionMode m_DirectionMode;

		// Token: 0x0400026C RID: 620
		[Tooltip("Legacy mode only: This defines how the signal will dissipate with distance beyond the impact radius.")]
		public CinemachineImpulseManager.ImpulseEvent.DissipationMode m_DissipationMode = CinemachineImpulseManager.ImpulseEvent.DissipationMode.ExponentialDecay;

		// Token: 0x0400026D RID: 621
		[Tooltip("The signal will have no effect outside this radius surrounding the impact point.")]
		public float m_DissipationDistance = 100f;

		// Token: 0x0400026E RID: 622
		[Tooltip("The speed (m/s) at which the impulse propagates through space.  High speeds allow listeners to react instantaneously, while slower speeds allow listeners in the scene to react as if to a wave spreading from the source.")]
		public float m_PropagationSpeed = 343f;

		// Token: 0x0400026F RID: 623
		private static AnimationCurve[] sStandardShapes;

		// Token: 0x020000C3 RID: 195
		public enum ImpulseShapes
		{
			// Token: 0x040003DF RID: 991
			Custom,
			// Token: 0x040003E0 RID: 992
			Recoil,
			// Token: 0x040003E1 RID: 993
			Bump,
			// Token: 0x040003E2 RID: 994
			Explosion,
			// Token: 0x040003E3 RID: 995
			Rumble
		}

		// Token: 0x020000C4 RID: 196
		public enum ImpulseTypes
		{
			// Token: 0x040003E5 RID: 997
			Uniform,
			// Token: 0x040003E6 RID: 998
			Dissipating,
			// Token: 0x040003E7 RID: 999
			Propagating,
			// Token: 0x040003E8 RID: 1000
			Legacy
		}

		// Token: 0x020000C5 RID: 197
		public enum RepeatMode
		{
			// Token: 0x040003EA RID: 1002
			Stretch,
			// Token: 0x040003EB RID: 1003
			Loop
		}

		// Token: 0x020000C6 RID: 198
		private class SignalSource : ISignalSource6D
		{
			// Token: 0x0600047F RID: 1151 RVA: 0x0001A2E9 File Offset: 0x000184E9
			public SignalSource(CinemachineImpulseDefinition def, Vector3 velocity)
			{
				this.m_Def = def;
				this.m_Velocity = velocity;
			}

			// Token: 0x170000EB RID: 235
			// (get) Token: 0x06000480 RID: 1152 RVA: 0x0001A2FF File Offset: 0x000184FF
			public float SignalDuration
			{
				get
				{
					return this.m_Def.m_ImpulseDuration;
				}
			}

			// Token: 0x06000481 RID: 1153 RVA: 0x0001A30C File Offset: 0x0001850C
			public void GetSignal(float timeSinceSignalStart, out Vector3 pos, out Quaternion rot)
			{
				pos = this.m_Velocity * this.m_Def.ImpulseCurve.Evaluate(timeSinceSignalStart / this.SignalDuration);
				rot = Quaternion.identity;
			}

			// Token: 0x040003EC RID: 1004
			private CinemachineImpulseDefinition m_Def;

			// Token: 0x040003ED RID: 1005
			private Vector3 m_Velocity;
		}

		// Token: 0x020000C7 RID: 199
		private class LegacySignalSource : ISignalSource6D
		{
			// Token: 0x06000482 RID: 1154 RVA: 0x0001A344 File Offset: 0x00018544
			public LegacySignalSource(CinemachineImpulseDefinition def, Vector3 velocity)
			{
				this.m_Def = def;
				this.m_Velocity = velocity;
				if (this.m_Def.m_Randomize && this.m_Def.m_RawSignal.SignalDuration <= 0f)
				{
					this.m_StartTimeOffset = Random.Range(-1000f, 1000f);
				}
			}

			// Token: 0x170000EC RID: 236
			// (get) Token: 0x06000483 RID: 1155 RVA: 0x0001A39E File Offset: 0x0001859E
			public float SignalDuration
			{
				get
				{
					return this.m_Def.m_RawSignal.SignalDuration;
				}
			}

			// Token: 0x06000484 RID: 1156 RVA: 0x0001A3B0 File Offset: 0x000185B0
			public void GetSignal(float timeSinceSignalStart, out Vector3 pos, out Quaternion rot)
			{
				float num = this.m_StartTimeOffset + timeSinceSignalStart * this.m_Def.m_FrequencyGain;
				float signalDuration = this.SignalDuration;
				if (signalDuration > 0f)
				{
					if (this.m_Def.m_RepeatMode == CinemachineImpulseDefinition.RepeatMode.Loop)
					{
						num %= signalDuration;
					}
					else if (this.m_Def.m_TimeEnvelope.Duration > 0.0001f)
					{
						num *= this.m_Def.m_TimeEnvelope.Duration / signalDuration;
					}
				}
				this.m_Def.m_RawSignal.GetSignal(num, out pos, out rot);
				float num2 = this.m_Velocity.magnitude;
				Vector3 normalized = this.m_Velocity.normalized;
				num2 *= this.m_Def.m_AmplitudeGain;
				pos *= num2;
				pos = Quaternion.FromToRotation(Vector3.down, this.m_Velocity) * pos;
				rot = Quaternion.SlerpUnclamped(Quaternion.identity, rot, num2);
			}

			// Token: 0x040003EE RID: 1006
			private CinemachineImpulseDefinition m_Def;

			// Token: 0x040003EF RID: 1007
			private Vector3 m_Velocity;

			// Token: 0x040003F0 RID: 1008
			private float m_StartTimeOffset;
		}
	}
}
