using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000153 RID: 339
	internal class SubFrameManager
	{
		// Token: 0x06000AE8 RID: 2792 RVA: 0x0005AF24 File Offset: 0x00059124
		internal CameraData GetCameraData(int camID)
		{
			CameraData cameraData;
			if (!this.m_CameraCache.TryGetValue(camID, out cameraData))
			{
				cameraData.ResetIteration();
				this.m_CameraCache.Add(camID, cameraData);
			}
			return cameraData;
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x0005AF56 File Offset: 0x00059156
		internal void SetCameraData(int camID, CameraData camData)
		{
			this.m_CameraCache[camID] = camData;
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000AEA RID: 2794 RVA: 0x0005AF65 File Offset: 0x00059165
		// (set) Token: 0x06000AEB RID: 2795 RVA: 0x0005AF6D File Offset: 0x0005916D
		public uint subFrameCount
		{
			get
			{
				return this.m_AccumulationSamples;
			}
			set
			{
				this.m_AccumulationSamples = value;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000AEC RID: 2796 RVA: 0x0005AF76 File Offset: 0x00059176
		public bool isRecording
		{
			get
			{
				return this.m_IsRecording;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000AED RID: 2797 RVA: 0x0005AF7E File Offset: 0x0005917E
		public float shutterInterval
		{
			get
			{
				return this.m_ShutterInterval;
			}
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x0005AF88 File Offset: 0x00059188
		internal void Reset(int camID)
		{
			CameraData cameraData = this.GetCameraData(camID);
			cameraData.ResetIteration();
			this.SetCameraData(camID, cameraData);
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x0005AFAC File Offset: 0x000591AC
		internal void Reset()
		{
			foreach (int camID in this.m_CameraCache.Keys.ToList<int>())
			{
				this.Reset(camID);
			}
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x0005B00C File Offset: 0x0005920C
		internal void Clear()
		{
			this.m_CameraCache.Clear();
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x0005B01C File Offset: 0x0005921C
		internal void SelectiveReset(uint maxSamples)
		{
			foreach (int camID in this.m_CameraCache.Keys.ToList<int>())
			{
				CameraData cameraData = this.GetCameraData(camID);
				if (cameraData.currentIteration >= maxSamples)
				{
					cameraData.ResetIteration();
					this.SetCameraData(camID, cameraData);
				}
			}
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x0005B094 File Offset: 0x00059294
		private void Init(int samples, float shutterInterval)
		{
			this.m_AccumulationSamples = (uint)samples;
			this.m_ShutterInterval = ((samples > 1) ? shutterInterval : 0f);
			this.m_IsRecording = true;
			this.Clear();
			this.m_OriginalCaptureDeltaTime = Time.captureDeltaTime;
			this.m_OriginalFixedDeltaTime = Time.fixedDeltaTime;
			if (shutterInterval > 0f)
			{
				Time.captureDeltaTime = this.m_OriginalCaptureDeltaTime / this.m_AccumulationSamples;
				Time.fixedDeltaTime = this.m_OriginalFixedDeltaTime / this.m_AccumulationSamples;
				return;
			}
			Time.captureDeltaTime = 0f;
			Time.fixedDeltaTime = 0f;
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x0005B122 File Offset: 0x00059322
		internal void BeginRecording(int samples, float shutterInterval, float shutterFullyOpen = 0f, float shutterBeginsClosing = 1f)
		{
			this.Init(samples, shutterInterval);
			this.m_ShutterFullyOpen = shutterFullyOpen;
			this.m_ShutterBeginsClosing = shutterBeginsClosing;
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x0005B13B File Offset: 0x0005933B
		internal void BeginRecording(int samples, float shutterInterval, AnimationCurve shutterProfile)
		{
			this.Init(samples, shutterInterval);
			this.m_ShutterCurve = shutterProfile;
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x0005B14C File Offset: 0x0005934C
		internal void EndRecording()
		{
			this.m_IsRecording = false;
			this.m_ShutterCurve = null;
			Time.captureDeltaTime = this.m_OriginalCaptureDeltaTime;
			Time.fixedDeltaTime = this.m_OriginalFixedDeltaTime;
			if ((double)this.m_OriginalTimeScale != 0.0)
			{
				Time.timeScale = this.m_OriginalTimeScale;
				this.m_OriginalTimeScale = 0f;
			}
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x0005B1A8 File Offset: 0x000593A8
		internal void PrepareNewSubFrame()
		{
			uint num = 0U;
			foreach (int camID in this.m_CameraCache.Keys.ToList<int>())
			{
				num = Math.Max(num, this.GetCameraData(camID).currentIteration);
			}
			if (this.m_ShutterInterval == 0f)
			{
				if (num == this.m_AccumulationSamples - 1U)
				{
					Time.captureDeltaTime = this.m_OriginalCaptureDeltaTime;
					Time.fixedDeltaTime = this.m_OriginalFixedDeltaTime;
					Time.timeScale = this.m_OriginalTimeScale;
				}
				else
				{
					if (this.m_OriginalTimeScale == 0f)
					{
						this.m_OriginalTimeScale = Time.timeScale;
					}
					Time.captureDeltaTime = 0f;
					Time.fixedDeltaTime = 0f;
					Time.timeScale = 0f;
				}
			}
			if (num >= this.m_AccumulationSamples)
			{
				this.Reset();
			}
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x0005B294 File Offset: 0x00059494
		private float ShutterProfile(float time)
		{
			if (time > this.m_ShutterInterval)
			{
				return 0f;
			}
			time /= this.m_ShutterInterval;
			if (this.m_ShutterCurve != null)
			{
				return this.m_ShutterCurve.Evaluate(time);
			}
			if (time < this.m_ShutterFullyOpen)
			{
				return 1f / this.m_ShutterFullyOpen * time;
			}
			if (time > this.m_ShutterBeginsClosing)
			{
				float num = 1f / (1f - this.m_ShutterBeginsClosing);
				return 1f - num * (time - this.m_ShutterBeginsClosing);
			}
			return 1f;
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x0005B31C File Offset: 0x0005951C
		internal Vector4 ComputeFrameWeights(int camID)
		{
			CameraData cameraData = this.GetCameraData(camID);
			float accumulatedWeight = cameraData.accumulatedWeight;
			float time = (this.m_AccumulationSamples > 0U) ? (cameraData.currentIteration / this.m_AccumulationSamples) : 0f;
			float num = (this.isRecording && this.m_ShutterInterval > 0f) ? this.ShutterProfile(time) : 1f;
			if (cameraData.currentIteration < this.m_AccumulationSamples)
			{
				cameraData.accumulatedWeight += num;
			}
			this.SetCameraData(camID, cameraData);
			if (cameraData.accumulatedWeight <= 0f)
			{
				return new Vector4(num, accumulatedWeight, 0f, 0f);
			}
			return new Vector4(num, accumulatedWeight, 1f / cameraData.accumulatedWeight, 0f);
		}

		// Token: 0x04000C24 RID: 3108
		private float m_ShutterInterval;

		// Token: 0x04000C25 RID: 3109
		private float m_ShutterFullyOpen;

		// Token: 0x04000C26 RID: 3110
		private float m_ShutterBeginsClosing = 1f;

		// Token: 0x04000C27 RID: 3111
		private AnimationCurve m_ShutterCurve;

		// Token: 0x04000C28 RID: 3112
		private float m_OriginalCaptureDeltaTime;

		// Token: 0x04000C29 RID: 3113
		private float m_OriginalFixedDeltaTime;

		// Token: 0x04000C2A RID: 3114
		private float m_OriginalTimeScale;

		// Token: 0x04000C2B RID: 3115
		private Dictionary<int, CameraData> m_CameraCache = new Dictionary<int, CameraData>();

		// Token: 0x04000C2C RID: 3116
		private uint m_AccumulationSamples;

		// Token: 0x04000C2D RID: 3117
		private bool m_IsRecording;
	}
}
