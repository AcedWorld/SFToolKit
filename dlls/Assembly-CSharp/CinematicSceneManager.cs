using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

// Token: 0x020001EF RID: 495
public class CinematicSceneManager : MonoBehaviour
{
	// Token: 0x060007B8 RID: 1976 RVA: 0x000385AE File Offset: 0x000367AE
	private void Start()
	{
		this.SetupInitialState();
	}

	// Token: 0x060007B9 RID: 1977 RVA: 0x000385B6 File Offset: 0x000367B6
	private void Update()
	{
		if (!this.hasStarted && Input.GetKeyDown(KeyCode.Space))
		{
			this.hasStarted = true;
			base.StartCoroutine(this.CinematicSequence());
		}
	}

	// Token: 0x060007BA RID: 1978 RVA: 0x000385E0 File Offset: 0x000367E0
	private void SetupInitialState()
	{
		this.SetLightsState(this.backLights, false);
		this.SetLightsState(this.middleLights, false);
		this.SetLightsState(this.frontLights, false);
		this.SetReflectionProbe(this.reflectionProbeOff);
		this.SetExposure(7f);
		this.animatedCharacter.SetActive(false);
	}

	// Token: 0x060007BB RID: 1979 RVA: 0x00038637 File Offset: 0x00036837
	private IEnumerator CinematicSequence()
	{
		this.animatedCharacter.SetActive(true);
		base.StartCoroutine(this.CameraZoomAndRotatePole());
		yield return new WaitForSeconds(this.lightsOffDuration);
		this.SetLightsState(this.backLights, true);
		this.SetReflectionProbe(this.reflectionProbeBackLights);
		this.SetExposure(6f);
		yield return new WaitForSeconds(this.backLightsOnDuration);
		this.SetLightsState(this.middleLights, true);
		this.SetReflectionProbe(this.reflectionProbeMiddleLights);
		this.SetExposure(5f);
		yield return new WaitForSeconds(this.middleLightsOnDuration);
		this.SetLightsState(this.frontLights, true);
		this.SetReflectionProbe(this.reflectionProbeAllLights);
		this.SetExposure(4f);
		yield return new WaitForSeconds(this.allLightsOnDuration);
		yield break;
	}

	// Token: 0x060007BC RID: 1980 RVA: 0x00038648 File Offset: 0x00036848
	private void SetLightsState(Light[] lights, bool state)
	{
		for (int i = 0; i < lights.Length; i++)
		{
			lights[i].enabled = state;
		}
	}

	// Token: 0x060007BD RID: 1981 RVA: 0x0003866E File Offset: 0x0003686E
	private void SetReflectionProbe(ReflectionProbe probe)
	{
		this.reflectionProbeOff.enabled = false;
		this.reflectionProbeBackLights.enabled = false;
		this.reflectionProbeMiddleLights.enabled = false;
		this.reflectionProbeAllLights.enabled = false;
		probe.enabled = true;
	}

	// Token: 0x060007BE RID: 1982 RVA: 0x000386A7 File Offset: 0x000368A7
	private void SetExposure(float value)
	{
		if (this.postProcessingVolume.profile.TryGet<Exposure>(out this.exposure))
		{
			this.exposure.fixedExposure.value = value;
		}
	}

	// Token: 0x060007BF RID: 1983 RVA: 0x000386D2 File Offset: 0x000368D2
	private IEnumerator CameraZoomAndRotatePole()
	{
		while (this.cinematicCamera.transform.position != this.cameraTargetPosition)
		{
			this.cinematicCamera.transform.position = Vector3.MoveTowards(this.cinematicCamera.transform.position, this.cameraTargetPosition, this.zoomSpeed * Time.deltaTime);
			this.cameraPole.transform.Rotate(0f, this.rotationSpeed * Time.deltaTime, 0f);
			yield return null;
		}
		yield break;
	}

	// Token: 0x04000D73 RID: 3443
	[Header("Camera Settings")]
	public Camera cinematicCamera;

	// Token: 0x04000D74 RID: 3444
	public float zoomSpeed = 1f;

	// Token: 0x04000D75 RID: 3445
	public Vector3 cameraTargetPosition;

	// Token: 0x04000D76 RID: 3446
	[Header("Camera Pole")]
	public GameObject cameraPole;

	// Token: 0x04000D77 RID: 3447
	public float rotationSpeed = 30f;

	// Token: 0x04000D78 RID: 3448
	[Header("Lights")]
	public Light[] backLights;

	// Token: 0x04000D79 RID: 3449
	public Light[] middleLights;

	// Token: 0x04000D7A RID: 3450
	public Light[] frontLights;

	// Token: 0x04000D7B RID: 3451
	[Header("Reflection Probes")]
	public ReflectionProbe reflectionProbeOff;

	// Token: 0x04000D7C RID: 3452
	public ReflectionProbe reflectionProbeBackLights;

	// Token: 0x04000D7D RID: 3453
	public ReflectionProbe reflectionProbeMiddleLights;

	// Token: 0x04000D7E RID: 3454
	public ReflectionProbe reflectionProbeAllLights;

	// Token: 0x04000D7F RID: 3455
	[Header("Sky and Volume")]
	public Volume postProcessingVolume;

	// Token: 0x04000D80 RID: 3456
	private Exposure exposure;

	// Token: 0x04000D81 RID: 3457
	[Header("Timing (Seconds)")]
	public float lightsOffDuration = 2f;

	// Token: 0x04000D82 RID: 3458
	public float backLightsOnDuration = 2f;

	// Token: 0x04000D83 RID: 3459
	public float middleLightsOnDuration = 2f;

	// Token: 0x04000D84 RID: 3460
	public float allLightsOnDuration = 2f;

	// Token: 0x04000D85 RID: 3461
	[Header("Character")]
	public GameObject animatedCharacter;

	// Token: 0x04000D86 RID: 3462
	private bool hasStarted;
}
