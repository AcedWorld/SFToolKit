using System;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

// Token: 0x020001C3 RID: 451
public class SimpleReplay : MonoBehaviour
{
	// Token: 0x06000706 RID: 1798 RVA: 0x00034198 File Offset: 0x00032398
	private void FixedUpdate()
	{
		if (this.StopRecordReplay && this.state != SimpleReplay.ReplayState.Stopped)
		{
			this.state = SimpleReplay.ReplayState.Stopped;
		}
	}

	// Token: 0x06000707 RID: 1799 RVA: 0x000341B4 File Offset: 0x000323B4
	private void Start()
	{
		this.frameTimes = new List<float>(this.maxFrames);
		this.player = ReInput.players.GetPlayer(this.playerId);
		this.audioMixer.SetFloat("ReplayVolume", 0f);
		this.frameInterval = 1f / (float)this.frameRate;
		this.maxFrames = Mathf.CeilToInt(this.recordDuration * (float)this.frameRate);
		this.playerPositions = new List<Vector3>(this.maxFrames);
		this.playerRotations = new List<Quaternion>(this.maxFrames);
		this.playerChildPositions = new List<List<Vector3>>();
		this.playerChildRotations = new List<List<Quaternion>>();
		for (int i = 0; i < this.playerChildren.Length; i++)
		{
			this.playerChildPositions.Add(new List<Vector3>(this.maxFrames));
			this.playerChildRotations.Add(new List<Quaternion>(this.maxFrames));
			this.playerChildren[i].transformPath = this.GetTransformPath(this.playerChildren[i].target, this.playerRoot);
		}
		this.audioPitches = new List<List<float>>();
		this.audioVolumes = new List<List<float>>();
		for (int j = 0; j < this.constantAudioSources.Length; j++)
		{
			this.audioPitches.Add(new List<float>(this.maxFrames));
			this.audioVolumes.Add(new List<float>(this.maxFrames));
		}
		this.originalObject = this.playerRoot.gameObject;
		this.externalTargetPositions = new List<List<Vector3>>();
		this.externalTargetRotations = new List<List<Quaternion>>();
		for (int k = 0; k < this.externalTargets.Length; k++)
		{
			this.externalTargetPositions.Add(new List<Vector3>(this.maxFrames));
			this.externalTargetRotations.Add(new List<Quaternion>(this.maxFrames));
			this.externalTargets[k].transformPath = this.GetTransformPath(this.externalTargets[k].target, null);
		}
		this.slider.mainSlider.minValue = (float)this.startingFrame;
	}

	// Token: 0x06000708 RID: 1800 RVA: 0x000343BC File Offset: 0x000325BC
	private void LateUpdate()
	{
		if (!this.menuLogic.pauseMenu && this.EnableReplay)
		{
			if (this.stateTrigger != this.state)
			{
				this.OnStateChange();
				this.stateTrigger = this.state;
			}
			if (this.replayInputCooldown > 0f)
			{
				this.replayInputCooldown -= Time.deltaTime;
			}
			switch (this.state)
			{
			case SimpleReplay.ReplayState.Recording:
				this.timeAccumulator += Time.deltaTime;
				if (this.timeAccumulator >= this.frameInterval)
				{
					this.RecordFrame();
					this.timeAccumulator = 0f;
				}
				if (this.player.GetButton("R1") && this.player.GetButton("L1") && this.player.GetButtonDown("Circle") && this.totalRecordedFrames >= 120)
				{
					this.StartReplay();
				}
				break;
			case SimpleReplay.ReplayState.ReplayingPaused:
				this.StopAllConstantAudio();
				this.HandleFrameScrubbing();
				if (this.frameTimes.Count >= 2)
				{
					int num = 0;
					int num2 = 1;
					for (int i = 1; i < this.frameTimes.Count; i++)
					{
						if (this.frameTimes[i] > this.replayTime)
						{
							num = i - 1;
							num2 = i;
							break;
						}
					}
					float t = Mathf.InverseLerp(this.frameTimes[num], this.frameTimes[num2], this.replayTime);
					this.PlayLerpedFrame(num, num2, t);
				}
				for (int j = 1; j < this.frameTimes.Count; j++)
				{
					if (this.frameTimes[j] > this.replayTime)
					{
						this.lastSoundFrame = j - 1;
						break;
					}
				}
				if (this.replayInputCooldown <= 0f && this.player.GetButtonDown("Cross"))
				{
					if (this.currentReplayFrame >= this.totalRecordedFrames - 2)
					{
						this.OnReplayLoop();
						this.currentReplayFrame = this.startingFrame;
						this.replayTime = ((this.frameTimes.Count > this.startingFrame) ? this.frameTimes[this.startingFrame] : 0f);
						for (int k = 1; k < this.frameTimes.Count; k++)
						{
							if (this.frameTimes[k] > this.replayTime)
							{
								this.lastSoundFrame = k - 1;
								break;
							}
						}
						this.state = SimpleReplay.ReplayState.ReplayingPlaying;
					}
					else
					{
						this.state = SimpleReplay.ReplayState.ReplayingPlaying;
					}
				}
				if (this.player.GetButton("R1") && this.player.GetButton("L1") && this.player.GetButtonDown("Circle"))
				{
					this.EndReplay();
				}
				if (this.player.GetButtonDown("Select"))
				{
					this.CameraSwitch();
				}
				if (this.player.GetButtonDown("Triangle"))
				{
					this.ToggleReplayUI();
				}
				break;
			case SimpleReplay.ReplayState.ReplayingPlaying:
			{
				this.ResumeAllConstantAudio(this.currentReplayFrame);
				this.replayTime += Time.deltaTime * this.playbackSpeed;
				int num3 = 0;
				int num4 = 1;
				for (int l = 1; l < this.frameTimes.Count; l++)
				{
					if (this.frameTimes[l] > this.replayTime)
					{
						num3 = l - 1;
						num4 = l;
						break;
					}
				}
				if (this.currentReplayFrame >= this.totalRecordedFrames - 2)
				{
					this.state = SimpleReplay.ReplayState.ReplayingPaused;
				}
				this.currentReplayFrame = num3;
				float a = this.frameTimes[num3];
				float b = this.frameTimes[num4];
				float t2 = Mathf.InverseLerp(a, b, this.replayTime);
				this.PlayLerpedFrame(num3, num4, t2);
				this.HandleSoundInterpolation(num3, num4, t2);
				if (num3 > this.lastSoundFrame)
				{
					this.HandleSoundSpawns(this.lastSoundFrame, num3);
					this.lastSoundFrame = num3;
				}
				if (this.replayInputCooldown <= 0f && this.player.GetButtonDown("Cross"))
				{
					this.state = SimpleReplay.ReplayState.ReplayingPaused;
				}
				if (this.replayInputCooldown <= 0f && (this.player.GetButton("L2") || this.player.GetButton("R2")))
				{
					this.state = SimpleReplay.ReplayState.ReplayingPaused;
				}
				if (this.player.GetButton("R1") && this.player.GetButton("L1") && this.player.GetButtonDown("Circle"))
				{
					this.EndReplay();
				}
				if (this.player.GetButtonDown("Select"))
				{
					this.CameraSwitch();
				}
				if (this.player.GetButtonDown("Triangle"))
				{
					this.ToggleReplayUI();
				}
				break;
			}
			}
		}
		bool flag = !this.menuLogic.pauseMenu && this.replayUIVisible && this.isReplay;
		if (flag != this.isReplayUIActuallyVisible)
		{
			this.replayPanel.alpha = (flag ? 1f : 0f);
			this.replayPanel.interactable = flag;
			this.replayPanel.blocksRaycasts = flag;
			this.isReplayUIActuallyVisible = flag;
		}
		if (this.currentReplayFrame == 0 && this.state == SimpleReplay.ReplayState.ReplayingPlaying)
		{
			this.currentReplayFrame = this.startingFrame;
		}
		this.SmoothSlider();
	}

	// Token: 0x06000709 RID: 1801 RVA: 0x000348F4 File Offset: 0x00032AF4
	private void OnStateChange()
	{
		SimpleReplay.ReplayState replayState = this.state;
		if (replayState == SimpleReplay.ReplayState.ReplayingPaused)
		{
			this.playText.text = "Play";
			return;
		}
		if (replayState == SimpleReplay.ReplayState.ReplayingPlaying)
		{
			this.playText.text = "Pause";
			return;
		}
		this.playText.text = "";
	}

	// Token: 0x0600070A RID: 1802 RVA: 0x00034944 File Offset: 0x00032B44
	public void ReplayButton()
	{
		if (this.state == SimpleReplay.ReplayState.ReplayingPaused || this.state == SimpleReplay.ReplayState.ReplayingPlaying)
		{
			this.EndReplay();
		}
		else if (this.state == SimpleReplay.ReplayState.Recording && this.totalRecordedFrames >= 20)
		{
			this.StartReplay();
		}
		if (this.menuLogic.pauseMenu)
		{
			this.menuLogic.ResumeGame();
		}
	}

	// Token: 0x0600070B RID: 1803 RVA: 0x0003499C File Offset: 0x00032B9C
	private void SmoothSlider()
	{
		if (this.isReplay)
		{
			float value = Mathf.Lerp(this.slider.mainSlider.value, (float)this.currentReplayFrame, Time.deltaTime * this.sliderSmooth);
			this.slider.mainSlider.value = value;
		}
	}

	// Token: 0x0600070C RID: 1804 RVA: 0x000349EB File Offset: 0x00032BEB
	private void OnReplayLoop()
	{
		this.teleportPlayer.CreateLoadScreen();
	}

	// Token: 0x0600070D RID: 1805 RVA: 0x000349F8 File Offset: 0x00032BF8
	private void CameraSwitch()
	{
		this.cameraMode = ((this.cameraMode == SimpleReplay.CameraPlaybackMode.Recorded) ? SimpleReplay.CameraPlaybackMode.Free : SimpleReplay.CameraPlaybackMode.Recorded);
		this.SwitchCameraMode();
	}

	// Token: 0x0600070E RID: 1806 RVA: 0x00034A14 File Offset: 0x00032C14
	private void HandleFrameScrubbing()
	{
		this.panAccumulator += Time.deltaTime;
		float num = 1f / this.panSpeed;
		bool button = this.player.GetButton("L2");
		bool button2 = this.player.GetButton("R2");
		if ((button || button2) && this.frameTimes.Count >= 2 && this.panAccumulator >= num)
		{
			float num2 = this.frameInterval;
			if (button)
			{
				this.replayTime = Mathf.Max(this.replayTime - num2, this.frameTimes[this.startingFrame]);
			}
			else if (button2)
			{
				this.replayTime = Mathf.Min(this.replayTime + num2, this.frameTimes[this.frameTimes.Count - 2]);
			}
			this.panAccumulator = 0f;
			this.currentReplayFrame = Mathf.Clamp(this.FindClosestFrame(this.replayTime), 0, this.frameTimes.Count - 2);
		}
	}

	// Token: 0x0600070F RID: 1807 RVA: 0x00034B18 File Offset: 0x00032D18
	private int FindClosestFrame(float time)
	{
		for (int i = 1; i < this.frameTimes.Count; i++)
		{
			if (this.frameTimes[i] > time)
			{
				return i - 1;
			}
		}
		return this.frameTimes.Count - 2;
	}

	// Token: 0x06000710 RID: 1808 RVA: 0x00034B5C File Offset: 0x00032D5C
	private void RecordFrame()
	{
		if (this.playerPositions.Count >= this.maxFrames)
		{
			foreach (SimpleReplay.CameraReplayData cameraReplayData in this.cameraReplayData)
			{
				if (cameraReplayData.fovFrames.Count > 0)
				{
					cameraReplayData.fovFrames.RemoveAt(0);
				}
			}
			this.playerPositions.RemoveAt(0);
			this.playerRotations.RemoveAt(0);
			for (int j = 0; j < this.playerChildren.Length; j++)
			{
				this.playerChildPositions[j].RemoveAt(0);
				this.playerChildRotations[j].RemoveAt(0);
			}
			for (int k = 0; k < this.constantAudioSources.Length; k++)
			{
				this.audioPitches[k].RemoveAt(0);
				this.audioVolumes[k].RemoveAt(0);
			}
			for (int l = 0; l < this.externalTargets.Length; l++)
			{
				this.externalTargetPositions[l].RemoveAt(0);
				this.externalTargetRotations[l].RemoveAt(0);
			}
			this.soundSpawns.RemoveAll((SimpleReplay.SoundSpawn s) => s.frame < this.earliestFrame + 1);
			this.latestRecordedFrame = this.maxFrames - 1;
			this.earliestFrame = 0;
		}
		this.playerPositions.Add(this.playerRoot.position);
		this.playerRotations.Add(this.playerRoot.rotation);
		for (int m = 0; m < this.playerChildren.Length; m++)
		{
			SimpleReplay.ReplayTarget replayTarget = this.playerChildren[m];
			if (replayTarget.target == null)
			{
				this.playerChildPositions[m].Add(Vector3.zero);
				this.playerChildRotations[m].Add(Quaternion.identity);
			}
			else
			{
				this.playerChildPositions[m].Add((replayTarget.spaceMode == SimpleReplay.SpaceMode.World) ? replayTarget.target.position : replayTarget.target.localPosition);
				this.playerChildRotations[m].Add((replayTarget.spaceMode == SimpleReplay.SpaceMode.World) ? replayTarget.target.rotation : replayTarget.target.localRotation);
			}
		}
		for (int n = 0; n < this.constantAudioSources.Length; n++)
		{
			AudioSource audioSource = this.constantAudioSources[n];
			this.audioPitches[n].Add(audioSource ? audioSource.pitch : 1f);
			this.audioVolumes[n].Add(audioSource ? audioSource.volume : 0f);
		}
		for (int num = 0; num < this.externalTargets.Length; num++)
		{
			SimpleReplay.ReplayTarget replayTarget2 = this.externalTargets[num];
			if (replayTarget2.target == null)
			{
				this.externalTargetPositions[num].Add(Vector3.zero);
				this.externalTargetRotations[num].Add(Quaternion.identity);
			}
			else
			{
				this.externalTargetPositions[num].Add((replayTarget2.spaceMode == SimpleReplay.SpaceMode.World) ? replayTarget2.target.position : replayTarget2.target.localPosition);
				this.externalTargetRotations[num].Add((replayTarget2.spaceMode == SimpleReplay.SpaceMode.World) ? replayTarget2.target.rotation : replayTarget2.target.localRotation);
			}
		}
		this.frameTimes.Add(Time.time);
		this.latestRecordedFrame++;
		this.totalRecordedFrames = Mathf.Min(this.totalRecordedFrames + 1, this.maxFrames);
		if (this.playerPositions.Count >= this.maxFrames)
		{
			for (int num2 = this.soundSpawns.Count - 1; num2 >= 0; num2--)
			{
				this.soundSpawns[num2].frame--;
				if (this.soundSpawns[num2].frame < 0)
				{
					this.soundSpawns.RemoveAt(num2);
				}
			}
		}
		foreach (SimpleReplay.CameraReplayData cameraReplayData2 in this.cameraReplayData)
		{
			if (cameraReplayData2.camera != null)
			{
				cameraReplayData2.fovFrames.Add(cameraReplayData2.camera.fieldOfView);
			}
		}
	}

	// Token: 0x06000711 RID: 1809 RVA: 0x00034FD0 File Offset: 0x000331D0
	private void PlayFrame(int index)
	{
		if (!this.playerClone)
		{
			return;
		}
		this.playerClone.transform.position = this.playerPositions[index];
		this.playerClone.transform.rotation = this.playerRotations[index];
		for (int i = 0; i < this.playerChildren.Length; i++)
		{
			SimpleReplay.ReplayTarget replayTarget = this.playerChildren[i];
			Transform transform = this.playerClone.transform.Find(replayTarget.transformPath);
			if (!(transform == null))
			{
				if (replayTarget.dataType == SimpleReplay.TransformDataType.Position || replayTarget.dataType == SimpleReplay.TransformDataType.Both)
				{
					Vector3 vector = this.playerChildPositions[i][index];
					if (replayTarget.spaceMode == SimpleReplay.SpaceMode.World)
					{
						transform.position = vector;
					}
					else
					{
						transform.localPosition = vector;
					}
				}
				if (replayTarget.dataType == SimpleReplay.TransformDataType.Rotation || replayTarget.dataType == SimpleReplay.TransformDataType.Both)
				{
					Quaternion quaternion = this.playerChildRotations[i][index];
					if (replayTarget.spaceMode == SimpleReplay.SpaceMode.World)
					{
						transform.rotation = quaternion;
					}
					else
					{
						transform.localRotation = quaternion;
					}
				}
			}
		}
		for (int j = 0; j < this.externalTargets.Length; j++)
		{
			SimpleReplay.ReplayTarget replayTarget2 = this.externalTargets[j];
			if (!(replayTarget2.target == null) && this.cameraMode != SimpleReplay.CameraPlaybackMode.Free)
			{
				Vector3 vector2 = this.externalTargetPositions[j][index];
				Quaternion quaternion2 = this.externalTargetRotations[j][index];
				if (replayTarget2.dataType == SimpleReplay.TransformDataType.Position || replayTarget2.dataType == SimpleReplay.TransformDataType.Both)
				{
					if (replayTarget2.spaceMode == SimpleReplay.SpaceMode.World)
					{
						replayTarget2.target.position = vector2;
					}
					else
					{
						replayTarget2.target.localPosition = vector2;
					}
				}
				if (replayTarget2.dataType == SimpleReplay.TransformDataType.Rotation || replayTarget2.dataType == SimpleReplay.TransformDataType.Both)
				{
					if (replayTarget2.spaceMode == SimpleReplay.SpaceMode.World)
					{
						replayTarget2.target.rotation = quaternion2;
					}
					else
					{
						replayTarget2.target.localRotation = quaternion2;
					}
				}
			}
		}
		foreach (SimpleReplay.CameraReplayData cameraReplayData in this.cameraReplayData)
		{
			if (this.cameraMode != SimpleReplay.CameraPlaybackMode.Free && index < cameraReplayData.fovFrames.Count && cameraReplayData.camera != null)
			{
				cameraReplayData.camera.fieldOfView = cameraReplayData.fovFrames[index];
			}
		}
	}

	// Token: 0x06000712 RID: 1810 RVA: 0x00035228 File Offset: 0x00033428
	private void PlayLerpedFrame(int from, int to, float t)
	{
		if (!this.playerClone)
		{
			return;
		}
		this.playerClone.transform.position = Vector3.Lerp(this.playerPositions[from], this.playerPositions[to], t);
		this.playerClone.transform.rotation = Quaternion.Slerp(this.playerRotations[from], this.playerRotations[to], t);
		for (int i = 0; i < this.playerChildren.Length; i++)
		{
			SimpleReplay.ReplayTarget replayTarget = this.playerChildren[i];
			Transform transform = this.playerClone.transform.Find(replayTarget.transformPath);
			if (!(transform == null))
			{
				if (replayTarget.dataType == SimpleReplay.TransformDataType.Position || replayTarget.dataType == SimpleReplay.TransformDataType.Both)
				{
					Vector3 a = this.playerChildPositions[i][from];
					Vector3 b = this.playerChildPositions[i][to];
					Vector3 vector = Vector3.Lerp(a, b, t);
					if (replayTarget.spaceMode == SimpleReplay.SpaceMode.World)
					{
						transform.position = vector;
					}
					else
					{
						transform.localPosition = vector;
					}
				}
				if (replayTarget.dataType == SimpleReplay.TransformDataType.Rotation || replayTarget.dataType == SimpleReplay.TransformDataType.Both)
				{
					Quaternion a2 = this.playerChildRotations[i][from];
					Quaternion b2 = this.playerChildRotations[i][to];
					Quaternion quaternion = Quaternion.Slerp(a2, b2, t);
					if (replayTarget.spaceMode == SimpleReplay.SpaceMode.World)
					{
						transform.rotation = quaternion;
					}
					else
					{
						transform.localRotation = quaternion;
					}
				}
			}
		}
		for (int j = 0; j < this.externalTargets.Length; j++)
		{
			SimpleReplay.ReplayTarget replayTarget2 = this.externalTargets[j];
			if (!(replayTarget2.target == null) && this.cameraMode != SimpleReplay.CameraPlaybackMode.Free)
			{
				Vector3 a3 = this.externalTargetPositions[j][from];
				Vector3 b3 = this.externalTargetPositions[j][to];
				Quaternion a4 = this.externalTargetRotations[j][from];
				Quaternion b4 = this.externalTargetRotations[j][to];
				if (replayTarget2.dataType == SimpleReplay.TransformDataType.Position || replayTarget2.dataType == SimpleReplay.TransformDataType.Both)
				{
					Vector3 vector2 = Vector3.Lerp(a3, b3, t);
					if (replayTarget2.spaceMode == SimpleReplay.SpaceMode.World)
					{
						replayTarget2.target.position = vector2;
					}
					else
					{
						replayTarget2.target.localPosition = vector2;
					}
				}
				if (replayTarget2.dataType == SimpleReplay.TransformDataType.Rotation || replayTarget2.dataType == SimpleReplay.TransformDataType.Both)
				{
					Quaternion quaternion2 = Quaternion.Slerp(a4, b4, t);
					if (replayTarget2.spaceMode == SimpleReplay.SpaceMode.World)
					{
						replayTarget2.target.rotation = quaternion2;
					}
					else
					{
						replayTarget2.target.localRotation = quaternion2;
					}
				}
			}
		}
		foreach (SimpleReplay.CameraReplayData cameraReplayData in this.cameraReplayData)
		{
			if (this.cameraMode != SimpleReplay.CameraPlaybackMode.Free && from < cameraReplayData.fovFrames.Count && to < cameraReplayData.fovFrames.Count && cameraReplayData.camera != null)
			{
				float fieldOfView = Mathf.Lerp(cameraReplayData.fovFrames[from], cameraReplayData.fovFrames[to], t);
				cameraReplayData.camera.fieldOfView = fieldOfView;
			}
		}
	}

	// Token: 0x06000713 RID: 1811 RVA: 0x00035548 File Offset: 0x00033748
	public void StartReplay()
	{
		this.replayTime = ((this.frameTimes.Count > this.startingFrame) ? this.frameTimes[this.startingFrame] : 0f);
		this.replayInputCooldown = 0.25f;
		this.cameraBrain.enabled = false;
		foreach (SimpleReplay.ReplayTarget replayTarget in this.externalTargets)
		{
			if (replayTarget.target != null)
			{
				replayTarget.target.parent = null;
			}
		}
		this.teleportPlayer.TeleportToSpawnpointWithoutBufferReset();
		this.state = SimpleReplay.ReplayState.ReplayingPlaying;
		this.currentReplayFrame = this.startingFrame;
		this.playerClone = Object.Instantiate<GameObject>(this.playerRoot.gameObject, this.playerRoot.position, this.playerRoot.rotation);
		this.playerClone.name = this.playerRoot.name + "_ReplayClone";
		this.DestroyImmediateComponentsRecursive(this.playerClone);
		this.playerRoot.gameObject.SetActive(false);
		AudioSource[] array2 = this.constantAudioSources;
		this.constantAudioSources = new AudioSource[array2.Length];
		for (int j = 0; j < array2.Length; j++)
		{
			if (!(array2[j] == null))
			{
				AudioSource audioSource = array2[j];
				AudioSource audioSource2 = this.playerClone.AddComponent<AudioSource>();
				audioSource2.clip = audioSource.clip;
				audioSource2.loop = audioSource.loop;
				audioSource2.spatialBlend = audioSource.spatialBlend;
				audioSource2.volume = audioSource.volume;
				audioSource2.pitch = audioSource.pitch;
				audioSource2.playOnAwake = false;
				audioSource2.outputAudioMixerGroup = this.audioMixerGroup;
				audioSource2.Play();
				this.constantAudioSources[j] = audioSource2;
			}
		}
		foreach (MonoBehaviour monoBehaviour in this.cameraScriptsToDisable)
		{
			if (monoBehaviour != null)
			{
				monoBehaviour.enabled = false;
			}
		}
		this.slider.mainSlider.maxValue = (float)(this.latestRecordedFrame - 2);
		this.replayPanel.alpha = 1f;
		this.replayPanel.interactable = true;
		this.replayPanel.blocksRaycasts = true;
		this.isReplay = true;
		this.replayUIVisible = true;
		this.replayButtonText.text = "Exit Replay Mode";
	}

	// Token: 0x06000714 RID: 1812 RVA: 0x000357A4 File Offset: 0x000339A4
	public void EndReplay()
	{
		if (this.cameraMode == SimpleReplay.CameraPlaybackMode.Free)
		{
			this.CameraSwitch();
		}
		this.state = SimpleReplay.ReplayState.Recording;
		this.currentReplayFrame = 0;
		if (this.playerClone)
		{
			Object.Destroy(this.playerClone);
		}
		if (this.playerRoot)
		{
			this.playerRoot.gameObject.SetActive(true);
		}
		this.StopAllConstantAudio();
		this.ResetConstantAudioSources();
		foreach (MonoBehaviour monoBehaviour in this.cameraScriptsToDisable)
		{
			if (monoBehaviour != null)
			{
				monoBehaviour.enabled = true;
			}
		}
		this.teleportPlayer.TeleportToSpawnpoint();
		this.replayPanel.alpha = 0f;
		this.replayPanel.interactable = false;
		this.replayPanel.blocksRaycasts = false;
		this.isReplay = false;
		this.replayButtonText.text = "Enter Replay Mode";
	}

	// Token: 0x06000715 RID: 1813 RVA: 0x00035884 File Offset: 0x00033A84
	private void HandleSoundInterpolation(int from, int to, float t)
	{
		for (int i = 0; i < this.constantAudioSources.Length; i++)
		{
			AudioSource audioSource = this.constantAudioSources[i];
			if (audioSource)
			{
				float pitch = Mathf.Lerp(this.audioPitches[i][from], this.audioPitches[i][to], t);
				float volume = Mathf.Lerp(this.audioVolumes[i][from], this.audioVolumes[i][to], t);
				audioSource.pitch = pitch;
				audioSource.volume = volume;
			}
		}
	}

	// Token: 0x06000716 RID: 1814 RVA: 0x0003591C File Offset: 0x00033B1C
	public void OnMainMenuOpen()
	{
		if (this.state == SimpleReplay.ReplayState.ReplayingPlaying)
		{
			this.state = SimpleReplay.ReplayState.ReplayingPaused;
		}
		this.audioMixer.SetFloat("ReplayVolume", -80f);
	}

	// Token: 0x06000717 RID: 1815 RVA: 0x00035944 File Offset: 0x00033B44
	public void OnMainMenuClose()
	{
		this.audioMixer.SetFloat("ReplayVolume", 0f);
	}

	// Token: 0x06000718 RID: 1816 RVA: 0x0003595C File Offset: 0x00033B5C
	private void StopAllConstantAudio()
	{
		for (int i = 0; i < this.constantAudioSources.Length; i++)
		{
			if (this.constantAudioSources[i])
			{
				this.constantAudioSources[i].Stop();
			}
		}
	}

	// Token: 0x06000719 RID: 1817 RVA: 0x00035998 File Offset: 0x00033B98
	private void ResumeAllConstantAudio(int frameIndex)
	{
		for (int i = 0; i < this.constantAudioSources.Length; i++)
		{
			AudioSource audioSource = this.constantAudioSources[i];
			if (!(audioSource == null))
			{
				float pitch = this.audioPitches[i][frameIndex];
				float volume = this.audioVolumes[i][frameIndex];
				audioSource.pitch = pitch;
				audioSource.volume = volume;
				if (!audioSource.isPlaying)
				{
					audioSource.Play();
				}
			}
		}
	}

	// Token: 0x0600071A RID: 1818 RVA: 0x00035A0C File Offset: 0x00033C0C
	public void RecordSoundSpawn(GameObject prefab, Vector3 position, float pitch = 1f, float volume = 1f)
	{
		this.soundSpawns.Add(new SimpleReplay.SoundSpawn
		{
			prefab = prefab,
			position = position,
			frame = this.playerPositions.Count - 1,
			pitch = pitch,
			volume = volume
		});
	}

	// Token: 0x0600071B RID: 1819 RVA: 0x00035A5C File Offset: 0x00033C5C
	private void HandleSoundSpawns(int lastFrame, int newFrame)
	{
		if (newFrame < lastFrame)
		{
			using (List<SimpleReplay.SoundSpawn>.Enumerator enumerator = this.soundSpawns.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					SimpleReplay.SoundSpawn soundSpawn = enumerator.Current;
					if ((soundSpawn.frame > lastFrame && soundSpawn.frame < this.totalRecordedFrames) || (soundSpawn.frame >= 0 && soundSpawn.frame <= newFrame))
					{
						AudioSource component = Object.Instantiate<GameObject>(soundSpawn.prefab, soundSpawn.position, Quaternion.identity).GetComponent<AudioSource>();
						if (component)
						{
							component.pitch = soundSpawn.pitch;
							component.volume = soundSpawn.volume;
						}
					}
				}
				return;
			}
		}
		foreach (SimpleReplay.SoundSpawn soundSpawn2 in this.soundSpawns)
		{
			if (soundSpawn2.frame > lastFrame && soundSpawn2.frame <= newFrame)
			{
				AudioSource component2 = Object.Instantiate<GameObject>(soundSpawn2.prefab, soundSpawn2.position, Quaternion.identity).GetComponent<AudioSource>();
				if (component2)
				{
					component2.pitch = soundSpawn2.pitch;
					component2.volume = soundSpawn2.volume;
				}
			}
		}
	}

	// Token: 0x0600071C RID: 1820 RVA: 0x00035BA4 File Offset: 0x00033DA4
	private void DestroyImmediateComponentsRecursive(GameObject go)
	{
		foreach (object obj in go.transform)
		{
			Transform transform = (Transform)obj;
			this.DestroyImmediateComponentsRecursive(transform.gameObject);
		}
		Joint[] components = go.GetComponents<Joint>();
		for (int i = 0; i < components.Length; i++)
		{
			Object.Destroy(components[i]);
		}
		foreach (Component component in go.GetComponents<Component>())
		{
			if (!(component is Transform) && !(component is MeshFilter) && !(component is MeshRenderer) && !(component is SkinnedMeshRenderer))
			{
				Object.Destroy(component);
			}
		}
	}

	// Token: 0x0600071D RID: 1821 RVA: 0x00035C74 File Offset: 0x00033E74
	private string GetTransformPath(Transform target, Transform root)
	{
		if (target == root)
		{
			return "";
		}
		if (target.parent == null)
		{
			return target.name;
		}
		string transformPath = this.GetTransformPath(target.parent, root);
		if (!string.IsNullOrEmpty(transformPath))
		{
			return transformPath + "/" + target.name;
		}
		return target.name;
	}

	// Token: 0x0600071E RID: 1822 RVA: 0x00035CD4 File Offset: 0x00033ED4
	private void ResetConstantAudioSources()
	{
		AudioSource[] componentsInChildren = this.playerRoot.GetComponentsInChildren<AudioSource>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (i < this.constantAudioSources.Length)
			{
				this.constantAudioSources[i] = componentsInChildren[i];
			}
		}
	}

	// Token: 0x0600071F RID: 1823 RVA: 0x00035D14 File Offset: 0x00033F14
	private void SwitchCameraMode()
	{
		this.state = SimpleReplay.ReplayState.ReplayingPlaying;
		if (this.cameraMode == SimpleReplay.CameraPlaybackMode.Free)
		{
			foreach (MonoBehaviour monoBehaviour in this.cameraScriptsToDisable)
			{
				if (monoBehaviour != null)
				{
					monoBehaviour.enabled = true;
				}
			}
			if (!this.freeCamInstance && this.freeCamPrefab != null)
			{
				Vector3 position = this.externalTargetPositions[0][this.currentReplayFrame];
				Quaternion rotation = this.externalTargetRotations[0][this.currentReplayFrame];
				this.freeCamInstance = Object.Instantiate<GameObject>(this.freeCamPrefab, position, rotation);
				CameraFreeCam component = this.freeCamInstance.GetComponent<CameraFreeCam>();
				if (component != null)
				{
					component.menuLogic = this.menuLogic;
				}
			}
			foreach (GameObject gameObject in this.UI_Buttons)
			{
				if (gameObject != null)
				{
					gameObject.SetActive(true);
				}
			}
			return;
		}
		if (this.cameraMode == SimpleReplay.CameraPlaybackMode.Recorded)
		{
			foreach (MonoBehaviour monoBehaviour2 in this.cameraScriptsToDisable)
			{
				if (monoBehaviour2 != null)
				{
					monoBehaviour2.enabled = false;
				}
			}
			if (this.freeCamInstance)
			{
				Object.Destroy(this.freeCamInstance);
				this.freeCamInstance = null;
			}
			foreach (GameObject gameObject2 in this.UI_Buttons)
			{
				if (gameObject2 != null)
				{
					gameObject2.SetActive(false);
				}
			}
		}
	}

	// Token: 0x06000720 RID: 1824 RVA: 0x00035E94 File Offset: 0x00034094
	public void ResetBuffer()
	{
		if (this.playerClone)
		{
			Object.Destroy(this.playerClone);
		}
		if (this.freeCamInstance)
		{
			Object.Destroy(this.freeCamInstance);
		}
		if (this.playerRoot)
		{
			this.playerRoot.gameObject.SetActive(true);
		}
		this.state = SimpleReplay.ReplayState.Recording;
		this.currentReplayFrame = 0;
		this.latestRecordedFrame = 0;
		this.totalRecordedFrames = 0;
		this.earliestFrame = 0;
		this.timeAccumulator = 0f;
		this.panAccumulator = 0f;
		this.replayTime = 0f;
		this.frameTimes.Clear();
		this.lastSoundFrame = this.startingFrame;
		this.playerPositions.Clear();
		this.playerRotations.Clear();
		foreach (List<Vector3> list in this.playerChildPositions)
		{
			list.Clear();
		}
		foreach (List<Quaternion> list2 in this.playerChildRotations)
		{
			list2.Clear();
		}
		foreach (List<float> list3 in this.audioPitches)
		{
			list3.Clear();
		}
		foreach (List<float> list4 in this.audioVolumes)
		{
			list4.Clear();
		}
		SimpleReplay.CameraReplayData[] array = this.cameraReplayData;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].fovFrames.Clear();
		}
		foreach (List<Vector3> list5 in this.externalTargetPositions)
		{
			list5.Clear();
		}
		foreach (List<Quaternion> list6 in this.externalTargetRotations)
		{
			list6.Clear();
		}
		this.soundSpawns.Clear();
		this.ResetConstantAudioSources();
		foreach (MonoBehaviour monoBehaviour in this.cameraScriptsToDisable)
		{
			if (monoBehaviour != null)
			{
				monoBehaviour.enabled = true;
			}
		}
		if (this.cameraBrain != null)
		{
			this.cameraBrain.enabled = true;
		}
	}

	// Token: 0x06000721 RID: 1825 RVA: 0x00036164 File Offset: 0x00034364
	public void TurnInstantReplayOff()
	{
		this.StopRecordReplay = true;
		this.state = SimpleReplay.ReplayState.Stopped;
	}

	// Token: 0x06000722 RID: 1826 RVA: 0x00036174 File Offset: 0x00034374
	public void TurnInstantReplayOn()
	{
		this.StopRecordReplay = false;
	}

	// Token: 0x06000723 RID: 1827 RVA: 0x00036180 File Offset: 0x00034380
	private void ToggleReplayUI()
	{
		this.replayUIVisible = !this.replayUIVisible;
		this.replayPanel.alpha = (this.replayUIVisible ? 1f : 0f);
		this.replayPanel.interactable = this.replayUIVisible;
		this.replayPanel.blocksRaycasts = this.replayUIVisible;
	}

	// Token: 0x04000C68 RID: 3176
	public bool EnableReplay;

	// Token: 0x04000C69 RID: 3177
	public TeleportPlayer teleportPlayer;

	// Token: 0x04000C6A RID: 3178
	public CanvasGroup replayPanel;

	// Token: 0x04000C6B RID: 3179
	public SliderManager slider;

	// Token: 0x04000C6C RID: 3180
	public bool isReplay;

	// Token: 0x04000C6D RID: 3181
	public float sliderSmooth;

	// Token: 0x04000C6E RID: 3182
	public bool LoopReplay;

	// Token: 0x04000C6F RID: 3183
	private float replayInputCooldown;

	// Token: 0x04000C70 RID: 3184
	public TMP_Text replayButtonText;

	// Token: 0x04000C71 RID: 3185
	public TMP_Text playText;

	// Token: 0x04000C72 RID: 3186
	private bool replayUIVisible = true;

	// Token: 0x04000C73 RID: 3187
	private SimpleReplay.ReplayState stateTrigger;

	// Token: 0x04000C74 RID: 3188
	public MenuLogic menuLogic;

	// Token: 0x04000C75 RID: 3189
	private bool isReplayUIActuallyVisible;

	// Token: 0x04000C76 RID: 3190
	public AudioMixer audioMixer;

	// Token: 0x04000C77 RID: 3191
	public AudioMixerGroup audioMixerGroup;

	// Token: 0x04000C78 RID: 3192
	public GameObject[] UI_Buttons;

	// Token: 0x04000C79 RID: 3193
	private List<float> frameTimes;

	// Token: 0x04000C7A RID: 3194
	private float replayTime;

	// Token: 0x04000C7B RID: 3195
	private int lastSoundFrame;

	// Token: 0x04000C7C RID: 3196
	public bool StopRecordReplay;

	// Token: 0x04000C7D RID: 3197
	public CameraBrain cameraBrain;

	// Token: 0x04000C7E RID: 3198
	[Header("Main Transform")]
	public Transform playerRoot;

	// Token: 0x04000C7F RID: 3199
	[Header("External Transforms to Record")]
	public SimpleReplay.ReplayTarget[] externalTargets;

	// Token: 0x04000C80 RID: 3200
	[Header("Cameras to Record FOV")]
	public SimpleReplay.CameraReplayData[] cameraReplayData;

	// Token: 0x04000C81 RID: 3201
	[Header("Camera Scripts to Disable During Replay")]
	public MonoBehaviour[] cameraScriptsToDisable;

	// Token: 0x04000C82 RID: 3202
	[Header("Children to Record")]
	public SimpleReplay.ReplayTarget[] playerChildren;

	// Token: 0x04000C83 RID: 3203
	[Header("Constant Audio Sources")]
	public AudioSource[] constantAudioSources;

	// Token: 0x04000C84 RID: 3204
	[Header("Recording Settings")]
	public float recordDuration = 120f;

	// Token: 0x04000C85 RID: 3205
	public int frameRate = 40;

	// Token: 0x04000C86 RID: 3206
	[Header("Playback Settings")]
	public float playbackSpeed = 1f;

	// Token: 0x04000C87 RID: 3207
	public float panSpeed = 10f;

	// Token: 0x04000C88 RID: 3208
	public int startingFrame = 11;

	// Token: 0x04000C89 RID: 3209
	[Header("Debug Info")]
	public SimpleReplay.ReplayState state;

	// Token: 0x04000C8A RID: 3210
	public int currentReplayFrame;

	// Token: 0x04000C8B RID: 3211
	public int latestRecordedFrame;

	// Token: 0x04000C8C RID: 3212
	public int totalRecordedFrames;

	// Token: 0x04000C8D RID: 3213
	[Header("Camera Playback Settings")]
	public SimpleReplay.CameraPlaybackMode cameraMode;

	// Token: 0x04000C8E RID: 3214
	public GameObject freeCamPrefab;

	// Token: 0x04000C8F RID: 3215
	private GameObject freeCamInstance;

	// Token: 0x04000C90 RID: 3216
	private int maxFrames;

	// Token: 0x04000C91 RID: 3217
	private List<Vector3> playerPositions;

	// Token: 0x04000C92 RID: 3218
	private List<Quaternion> playerRotations;

	// Token: 0x04000C93 RID: 3219
	private List<List<Vector3>> playerChildPositions;

	// Token: 0x04000C94 RID: 3220
	private List<List<Quaternion>> playerChildRotations;

	// Token: 0x04000C95 RID: 3221
	private List<List<float>> audioPitches;

	// Token: 0x04000C96 RID: 3222
	private List<List<float>> audioVolumes;

	// Token: 0x04000C97 RID: 3223
	private List<SimpleReplay.SoundSpawn> soundSpawns = new List<SimpleReplay.SoundSpawn>();

	// Token: 0x04000C98 RID: 3224
	private float timeAccumulator;

	// Token: 0x04000C99 RID: 3225
	private float panAccumulator;

	// Token: 0x04000C9A RID: 3226
	private float frameInterval;

	// Token: 0x04000C9B RID: 3227
	private GameObject playerClone;

	// Token: 0x04000C9C RID: 3228
	private GameObject originalObject;

	// Token: 0x04000C9D RID: 3229
	private List<Vector3> savedTargetPositions = new List<Vector3>();

	// Token: 0x04000C9E RID: 3230
	private Transform activeFollowTarget;

	// Token: 0x04000C9F RID: 3231
	private List<List<Vector3>> externalTargetPositions;

	// Token: 0x04000CA0 RID: 3232
	private List<List<Quaternion>> externalTargetRotations;

	// Token: 0x04000CA1 RID: 3233
	private int earliestFrame;

	// Token: 0x04000CA2 RID: 3234
	private int playerId;

	// Token: 0x04000CA3 RID: 3235
	private Player player;

	// Token: 0x020001C4 RID: 452
	public enum ReplayState
	{
		// Token: 0x04000CA5 RID: 3237
		Recording,
		// Token: 0x04000CA6 RID: 3238
		ReplayingPaused,
		// Token: 0x04000CA7 RID: 3239
		ReplayingPlaying,
		// Token: 0x04000CA8 RID: 3240
		Stopped
	}

	// Token: 0x020001C5 RID: 453
	public enum TransformDataType
	{
		// Token: 0x04000CAA RID: 3242
		Position,
		// Token: 0x04000CAB RID: 3243
		Rotation,
		// Token: 0x04000CAC RID: 3244
		Both
	}

	// Token: 0x020001C6 RID: 454
	public enum SpaceMode
	{
		// Token: 0x04000CAE RID: 3246
		World,
		// Token: 0x04000CAF RID: 3247
		Local
	}

	// Token: 0x020001C7 RID: 455
	[Serializable]
	public class ReplayTarget
	{
		// Token: 0x04000CB0 RID: 3248
		public Transform target;

		// Token: 0x04000CB1 RID: 3249
		public SimpleReplay.TransformDataType dataType = SimpleReplay.TransformDataType.Both;

		// Token: 0x04000CB2 RID: 3250
		public SimpleReplay.SpaceMode spaceMode = SimpleReplay.SpaceMode.Local;

		// Token: 0x04000CB3 RID: 3251
		[HideInInspector]
		public string transformPath;
	}

	// Token: 0x020001C8 RID: 456
	[Serializable]
	public class CameraReplayData
	{
		// Token: 0x04000CB4 RID: 3252
		public Camera camera;

		// Token: 0x04000CB5 RID: 3253
		public List<float> fovFrames = new List<float>();
	}

	// Token: 0x020001C9 RID: 457
	[Serializable]
	public class SoundSpawn
	{
		// Token: 0x04000CB6 RID: 3254
		public GameObject prefab;

		// Token: 0x04000CB7 RID: 3255
		public Vector3 position;

		// Token: 0x04000CB8 RID: 3256
		public int frame;

		// Token: 0x04000CB9 RID: 3257
		public float pitch = 1f;

		// Token: 0x04000CBA RID: 3258
		public float volume = 1f;
	}

	// Token: 0x020001CA RID: 458
	public enum CameraPlaybackMode
	{
		// Token: 0x04000CBC RID: 3260
		Recorded,
		// Token: 0x04000CBD RID: 3261
		Free
	}
}
