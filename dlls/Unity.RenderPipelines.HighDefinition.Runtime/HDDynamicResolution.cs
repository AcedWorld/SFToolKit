using System;
using UnityEngine;
using UnityEngine.Rendering;

// Token: 0x02000002 RID: 2
public class HDDynamicResolution : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	private void Update()
	{
		if (!FrameTimingManager.IsFeatureEnabled())
		{
			return;
		}
		if (!this.m_Initialized)
		{
			if (this.m_InitialFrameCounter >= 1U)
			{
				DynamicResolutionHandler.SetDynamicResScaler(() => HDDynamicResolution.s_CurrentScaleFraction, DynamicResScalePolicyType.ReturnsMinMaxLerpFactor);
				this.m_Initialized = true;
			}
			else
			{
				this.m_InitialFrameCounter += 1U;
			}
		}
		if (this.m_Initialized && this.UpdateFrameStats())
		{
			this.m_GPUFrameTime = this.m_AccumGPUFrameTime / (float)this.EvaluationFrameCount;
			float num = (Application.targetFrameRate > 0) ? ((float)Application.targetFrameRate) : this.DefaultTargetFrameRate;
			if (1000f / num - this.m_GPUFrameTime < 0f)
			{
				this.m_ScaleUpCounter = 0U;
				this.m_ScaleDownCounter += 1U;
				if (this.m_ScaleDownCounter >= this.ScaleDownDuration)
				{
					this.m_ScaleDownCounter = 0U;
					HDDynamicResolution.s_CurrentScaleFraction = Mathf.Clamp01(HDDynamicResolution.s_CurrentScaleFraction - 1f / (float)this.ScaleDownStepCount);
					return;
				}
			}
			else
			{
				this.m_ScaleDownCounter = 0U;
				this.m_ScaleUpCounter += 1U;
				if (this.m_ScaleUpCounter >= this.ScaleUpDuration)
				{
					this.m_ScaleUpCounter = 0U;
					HDDynamicResolution.s_CurrentScaleFraction = Mathf.Clamp01(HDDynamicResolution.s_CurrentScaleFraction + 1f / (float)this.ScaleUpStepCount);
				}
			}
		}
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002197 File Offset: 0x00000397
	private static void ResetScale()
	{
		HDDynamicResolution.s_CurrentScaleFraction = 1f;
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000021A3 File Offset: 0x000003A3
	private void ResetCounters()
	{
		this.m_ScaleUpCounter = 0U;
		this.m_ScaleDownCounter = 0U;
		this.m_CurrentFrameSlot = 0;
	}

	// Token: 0x06000004 RID: 4 RVA: 0x000021BC File Offset: 0x000003BC
	private bool UpdateFrameStats()
	{
		FrameTimingManager.CaptureFrameTimings();
		FrameTiming[] array = new FrameTiming[1];
		if (FrameTimingManager.GetLatestTimings(1U, array) == 0U)
		{
			this.ResetCounters();
			return false;
		}
		if (array[0].gpuFrameTime == 0.0)
		{
			return false;
		}
		if (array[0].cpuTimeFrameComplete < array[0].cpuTimePresentCalled)
		{
			return false;
		}
		if (this.m_CurrentFrameSlot == 0)
		{
			this.m_AccumGPUFrameTime = 0f;
		}
		this.m_AccumGPUFrameTime += (float)array[0].gpuFrameTime;
		this.UpdateGUIData(array[0]);
		this.m_CurrentFrameSlot = (this.m_CurrentFrameSlot + 1) % this.EvaluationFrameCount;
		return this.m_CurrentFrameSlot == 0;
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002273 File Offset: 0x00000473
	private void OnEnable()
	{
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002275 File Offset: 0x00000475
	private void OnDisable()
	{
		HDDynamicResolution.ResetScale();
		this.ResetCounters();
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002282 File Offset: 0x00000482
	private void Start()
	{
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002284 File Offset: 0x00000484
	private void OnDestroy()
	{
		HDDynamicResolution.ResetScale();
	}

	// Token: 0x06000009 RID: 9 RVA: 0x0000228B File Offset: 0x0000048B
	private void UpdateGUIData(FrameTiming timing)
	{
	}

	// Token: 0x0600000A RID: 10 RVA: 0x0000228D File Offset: 0x0000048D
	private void OnGUI()
	{
	}

	// Token: 0x04000001 RID: 1
	[Min(1f)]
	[Tooltip("Sets the desired target frame rate in FPS. If Application.targetFrameRate is already set, Application.targetFrameRate overrides this parameter.")]
	public float DefaultTargetFrameRate = 60f;

	// Token: 0x04000002 RID: 2
	[Min(1f)]
	[Tooltip("Per how many frames we evaluate GPU performance against the target frame rate, using the averaged GPU frame time over frames.")]
	public int EvaluationFrameCount = 15;

	// Token: 0x04000003 RID: 3
	[Tooltip("Sets the number of consecutive times where the GPU performance is above the target to increase dynamic resolution by one step.")]
	public uint ScaleUpDuration = 8U;

	// Token: 0x04000004 RID: 4
	[Tooltip("Sets the number of consecutive times where the GPU performance is below the target to decrease dynamic resolution by one step.")]
	public uint ScaleDownDuration = 4U;

	// Token: 0x04000005 RID: 5
	[Min(1f)]
	[Tooltip("Sets the number of steps to upscale from minimum screen percentage to maximum screen percentage set in the current HDRP Asset.")]
	public int ScaleUpStepCount = 5;

	// Token: 0x04000006 RID: 6
	[Min(1f)]
	[Tooltip("Sets the number of steps to downscale from maximum screen percentage to minimum screen percentage set in the current HDRP Asset.")]
	public int ScaleDownStepCount = 2;

	// Token: 0x04000007 RID: 7
	[Tooltip("Enables the debug view of dynamic resolution.")]
	public bool EnableDebugView;

	// Token: 0x04000008 RID: 8
	private const uint InitialFramesToSkip = 1U;

	// Token: 0x04000009 RID: 9
	private float m_AccumGPUFrameTime;

	// Token: 0x0400000A RID: 10
	private int m_CurrentFrameSlot;

	// Token: 0x0400000B RID: 11
	private float m_GPUFrameTime;

	// Token: 0x0400000C RID: 12
	private uint m_ScaleUpCounter;

	// Token: 0x0400000D RID: 13
	private uint m_ScaleDownCounter;

	// Token: 0x0400000E RID: 14
	private static float s_CurrentScaleFraction = 1f;

	// Token: 0x0400000F RID: 15
	private bool m_Initialized;

	// Token: 0x04000010 RID: 16
	private uint m_InitialFrameCounter;
}
